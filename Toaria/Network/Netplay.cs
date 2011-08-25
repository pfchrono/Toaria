namespace Terraria
{
    using System;
    using System.IO;
    using System.Net;
    using System.Net.Sockets;
    using System.Threading;
    using TerrariaAPI.Hooks;

    public class Netplay
    {
        public static bool anyClients = false;
        public static string banFile = "banlist.txt";
        public const int bufferSize = 0x400;
        public static ClientSock clientSock = new ClientSock();
        public static bool disconnect = false;
        public const int maxConnections = 0x100;
        public static string password = "";
        public static IPAddress serverIP;
        public static IPAddress serverListenIP = IPAddress.Any;
        public static int serverPort = 0x1e61;
        public static ServerSock[] serverSock = new ServerSock[0x100];
        public static bool ServerUp = false;
        public static bool spamCheck = false;
        public static bool stopListen = false;
        public static TcpListener tcpListener;

        public static void AddBan(int plr)
        {
            string str = serverSock[plr].tcpClient.Client.RemoteEndPoint.ToString();
            string str2 = str;
            for (int i = 0; i < str.Length; i++)
            {
                if (str.Substring(i, 1) == ":")
                {
                    str2 = str.Substring(0, i);
                }
            }
            using (StreamWriter writer = new StreamWriter(banFile, true))
            {
                writer.WriteLine("//" + Main.player[plr].name);
                writer.WriteLine(str2);
            }
        }

        public static bool CheckBan(string ip)
        {
            try
            {
                string str = ip;
                for (int i = 0; i < ip.Length; i++)
                {
                    if (ip.Substring(i, 1) == ":")
                    {
                        str = ip.Substring(0, i);
                    }
                }
                if (System.IO.File.Exists(banFile))
                {
                    using (StreamReader reader = new StreamReader(banFile))
                    {
                        string str2;
                        while ((str2 = reader.ReadLine()) != null)
                        {
                            if (str2 == str)
                            {
                                return true;
                            }
                        }
                    }
                }
            }
            catch
            {
            }
            return false;
        }

        public static int GetSectionX(int x)
        {
            return (x / 200);
        }

        public static int GetSectionY(int y)
        {
            return (y / 150);
        }

        public static void Init()
        {
            for (int i = 0; i < 0x101; i++)
            {
                if (i < 0x100)
                {
                    serverSock[i] = new ServerSock();
                    serverSock[i].tcpClient.NoDelay = true;
                }
                NetMessage.buffer[i] = new messageBuffer();
                NetMessage.buffer[i].whoAmI = i;
            }
            clientSock.tcpClient.NoDelay = true;
        }

        public static void ListenForClients(object threadContext)
        {
            while (!disconnect && !stopListen)
            {
                int index = -1;
                for (int i = 0; i < Main.maxNetPlayers; i++)
                {
                    if ((serverSock[i].tcpClient.Client == null) || !serverSock[i].tcpClient.Connected)
                    {
                        index = i;
                        break;
                    }
                }
                if (index >= 0)
                {
                    try
                    {
                        serverSock[index].tcpClient = tcpListener.AcceptTcpClient();
                        serverSock[index].tcpClient.NoDelay = true;
                        Console.WriteLine(serverSock[index].tcpClient.Client.RemoteEndPoint + " is connecting...");
                    }
                    catch (Exception exception)
                    {
                        if (!disconnect)
                        {
                            Main.menuMode = 15;
                            Main.statusText = exception.ToString();
                            disconnect = true;
                        }
                    }
                }
                else
                {
                    stopListen = true;
                    tcpListener.Stop();
                }
            }
        }

        public static void newRecent()
        {
            for (int i = 0; i < Main.maxMP; i++)
            {
                if ((Main.recentIP[i] == serverIP.ToString()) && (Main.recentPort[i] == serverPort))
                {
                    for (int k = i; k < (Main.maxMP - 1); k++)
                    {
                        Main.recentIP[k] = Main.recentIP[k + 1];
                        Main.recentPort[k] = Main.recentPort[k + 1];
                        Main.recentWorld[k] = Main.recentWorld[k + 1];
                    }
                }
            }
            for (int j = Main.maxMP - 1; j > 0; j--)
            {
                Main.recentIP[j] = Main.recentIP[j - 1];
                Main.recentPort[j] = Main.recentPort[j - 1];
                Main.recentWorld[j] = Main.recentWorld[j - 1];
            }
            Main.recentIP[0] = serverIP.ToString();
            Main.recentPort[0] = serverPort;
            Main.recentWorld[0] = Main.worldName;
            Main.SaveRecent();
        }

        public static void ServerLoop(object threadContext)
        {
            if (Main.rand == null)
            {
                Main.rand = new Random((int) DateTime.Now.Ticks);
            }
            if (WorldGen.genRand == null)
            {
                WorldGen.genRand = new Random((int) DateTime.Now.Ticks);
            }
            Main.myPlayer = 0xff;
            serverIP = IPAddress.Any;
            Main.menuMode = 14;
            Main.statusText = "Starting server...";
            Main.netMode = 2;
            disconnect = false;
            for (int i = 0; i < 0x100; i++)
            {
                serverSock[i] = new ServerSock();
                serverSock[i].Reset();
                serverSock[i].whoAmI = i;
                serverSock[i].tcpClient = new TcpClient();
                serverSock[i].tcpClient.NoDelay = true;
                serverSock[i].readBuffer = new byte[0x400];
                serverSock[i].writeBuffer = new byte[0x400];
            }
            tcpListener = new TcpListener(serverListenIP, serverPort);
            try
            {
                tcpListener.Start();
            }
            catch (Exception exception)
            {
                Main.menuMode = 15;
                Main.statusText = exception.ToString();
                disconnect = true;
            }
            if (!disconnect)
            {
                ThreadPool.QueueUserWorkItem(new WaitCallback(Netplay.ListenForClients), 1);
                Main.statusText = "Server started";
            }
            int num2 = 0;
            while (!disconnect)
            {
                if (stopListen)
                {
                    int num3 = -1;
                    for (int m = 0; m < Main.maxNetPlayers; m++)
                    {
                        if ((serverSock[m].tcpClient.Client == null) || !serverSock[m].tcpClient.Connected)
                        {
                            num3 = m;
                            break;
                        }
                    }
                    if (num3 >= 0)
                    {
                        if (Main.ignoreErrors)
                        {
                            try
                            {
                                tcpListener.Start();
                                stopListen = false;
                                ThreadPool.QueueUserWorkItem(new WaitCallback(Netplay.ListenForClients), 1);
                            }
                            catch
                            {
                            }
                        }
                        else
                        {
                            tcpListener.Start();
                            stopListen = false;
                            ThreadPool.QueueUserWorkItem(new WaitCallback(Netplay.ListenForClients), 1);
                        }
                    }
                }
                int num5 = 0;
                for (int k = 0; k < 0x100; k++)
                {
                    if (NetMessage.buffer[k].checkBytes)
                    {
                        NetMessage.CheckBytes(k);
                    }
                    if (serverSock[k].kill)
                    {
                        ServerHooks.OnLeave(serverSock[k].whoAmI);
                        serverSock[k].Reset();
                        NetMessage.syncPlayers();
                    }
                    else if ((serverSock[k].tcpClient.Client != null) && serverSock[k].tcpClient.Connected)
                    {
                        if (!serverSock[k].active)
                        {
                            serverSock[k].state = 0;
                        }
                        serverSock[k].active = true;
                        num5++;
                        if (!serverSock[k].locked)
                        {
                            try
                            {
                                serverSock[k].networkStream = serverSock[k].tcpClient.GetStream();
                                if (serverSock[k].networkStream.DataAvailable)
                                {
                                    serverSock[k].locked = true;
                                    serverSock[k].networkStream.BeginRead(serverSock[k].readBuffer, 0, serverSock[k].readBuffer.Length, new AsyncCallback(serverSock[k].ServerReadCallBack), serverSock[k].networkStream);
                                }
                            }
                            catch
                            {
                                serverSock[k].kill = true;
                            }
                        }
                        if ((serverSock[k].statusMax > 0) && (serverSock[k].statusText2 != ""))
                        {
                            if (serverSock[k].statusCount >= serverSock[k].statusMax)
                            {
                                serverSock[k].statusText = string.Concat(new object[] { "(", serverSock[k].tcpClient.Client.RemoteEndPoint, ") ", serverSock[k].name, " ", serverSock[k].statusText2, ": Complete!" });
                                serverSock[k].statusText2 = "";
                                serverSock[k].statusMax = 0;
                                serverSock[k].statusCount = 0;
                            }
                            else
                            {
                                serverSock[k].statusText = string.Concat(new object[] { "(", serverSock[k].tcpClient.Client.RemoteEndPoint, ") ", serverSock[k].name, " ", serverSock[k].statusText2, ": ", (int) ((((float) serverSock[k].statusCount) / ((float) serverSock[k].statusMax)) * 100f), "%" });
                            }
                        }
                        else if (serverSock[k].state == 0)
                        {
                            serverSock[k].statusText = string.Concat(new object[] { "(", serverSock[k].tcpClient.Client.RemoteEndPoint, ") ", serverSock[k].name, " is connecting..." });
                        }
                        else if (serverSock[k].state == 1)
                        {
                            serverSock[k].statusText = string.Concat(new object[] { "(", serverSock[k].tcpClient.Client.RemoteEndPoint, ") ", serverSock[k].name, " is sending player data..." });
                        }
                        else if (serverSock[k].state == 2)
                        {
                            serverSock[k].statusText = string.Concat(new object[] { "(", serverSock[k].tcpClient.Client.RemoteEndPoint, ") ", serverSock[k].name, " requested world information" });
                        }
                        else if ((serverSock[k].state != 3) && (serverSock[k].state == 10))
                        {
                            serverSock[k].statusText = string.Concat(new object[] { "(", serverSock[k].tcpClient.Client.RemoteEndPoint, ") ", serverSock[k].name, " is playing" });
                        }
                    }
                    else if (serverSock[k].active)
                    {
                        serverSock[k].kill = true;
                    }
                    else
                    {
                        serverSock[k].statusText2 = "";
                        if (k < 0xff)
                        {
                            Main.player[k].active = false;
                        }
                    }
                }
                num2++;
                if (num2 > 10)
                {
                    Thread.Sleep(1);
                    num2 = 0;
                }
                else
                {
                    Thread.Sleep(0);
                }
                if (!WorldGen.saveLock && !Main.dedServ)
                {
                    if (num5 == 0)
                    {
                        Main.statusText = "Waiting for clients...";
                    }
                    else
                    {
                        Main.statusText = num5 + " clients connected";
                    }
                }
                if (num5 == 0)
                {
                    anyClients = false;
                }
                else
                {
                    anyClients = true;
                }
                ServerUp = true;
            }
            tcpListener.Stop();
            for (int j = 0; j < 0x100; j++)
            {
                serverSock[j].Reset();
            }
            if (Main.menuMode != 15)
            {
                Main.netMode = 0;
                Main.menuMode = 10;
                WorldGen.saveWorld(false);
                while (WorldGen.saveLock)
                {
                }
                Main.menuMode = 0;
            }
            else
            {
                Main.netMode = 0;
            }
            Main.myPlayer = 0;
        }

        public static bool SetIP(string newIP)
        {
            try
            {
                serverIP = IPAddress.Parse(newIP);
            }
            catch
            {
                return false;
            }
            return true;
        }

        public static bool SetIP2(string newIP)
        {
            try
            {
                IPAddress[] addressList = Dns.GetHostEntry(newIP).AddressList;
                for (int i = 0; i < addressList.Length; i++)
                {
                    if (addressList[i].AddressFamily == AddressFamily.InterNetwork)
                    {
                        serverIP = addressList[i];
                        return true;
                    }
                }
                return false;
            }
            catch
            {
                return false;
            }
        }

        public static void StartServer()
        {
            ThreadPool.QueueUserWorkItem(new WaitCallback(Netplay.ServerLoop), 1);
        }
    }
}

