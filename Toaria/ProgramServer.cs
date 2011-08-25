namespace Terraria
{
    using System;
    using System.IO;
    using TerrariaAPI;

    internal class ProgramServer
    {
        private static Terraria.Main Game;

        private static void Main(string[] args)
        {
            try
            {
                Game = new Terraria.Main();
                for (int i = 0; i < args.Length; i++)
                {
                    if (args[i].ToLower() == "-config")
                    {
                        i++;
                        Game.LoadDedConfig(args[i]);
                    }
                    if (args[i].ToLower() == "-port")
                    {
                        i++;
                        try
                        {
                            Netplay.serverPort = Convert.ToInt32(args[i]);
                        }
                        catch
                        {
                        }
                    }
                    if ((args[i].ToLower() == "-players") || (args[i].ToLower() == "-maxplayers"))
                    {
                        i++;
                        try
                        {
                            int mPlayers = Convert.ToInt32(args[i]);
                            Game.SetNetPlayers(mPlayers);
                        }
                        catch
                        {
                        }
                    }
                    if ((args[i].ToLower() == "-pass") || (args[i].ToLower() == "-password"))
                    {
                        i++;
                        Netplay.password = args[i];
                    }
                    if (args[i].ToLower() == "-world")
                    {
                        i++;
                        Game.SetWorld(args[i]);
                    }
                    if (args[i].ToLower() == "-worldname")
                    {
                        i++;
                        Game.SetWorldName(args[i]);
                    }
                    if (args[i].ToLower() == "-motd")
                    {
                        i++;
                        Game.NewMOTD(args[i]);
                    }
                    if (args[i].ToLower() == "-banlist")
                    {
                        i++;
                        Netplay.banFile = args[i];
                    }
                    if (args[i].ToLower() == "-autoshutdown")
                    {
                        Game.autoShut();
                    }
                    if (args[i].ToLower() == "-secure")
                    {
                        Netplay.spamCheck = true;
                    }
                    if (args[i].ToLower() == "-autocreate")
                    {
                        i++;
                        string newOpt = args[i];
                        Game.autoCreate(newOpt);
                    }
                    if (args[i].ToLower() == "-loadlib")
                    {
                        i++;
                        string path = args[i];
                        Game.loadLib(path);
                    }
                }
                Program.Initialize(Game);
                Game.DedServ();
                Program.DeInitialize();
            }
            catch (Exception exception)
            {
                try
                {
                    using (StreamWriter writer = new StreamWriter("crashlog.txt", true))
                    {
                        writer.WriteLine(DateTime.Now);
                        writer.WriteLine(exception);
                        writer.WriteLine("");
                    }
                    Console.WriteLine("Server crash: " + DateTime.Now);
                    Console.WriteLine(exception);
                    Console.WriteLine("");
                    Console.WriteLine("Please send crashlog.txt to support@terraria.org");
                }
                catch
                {
                }
            }
        }
    }
}

