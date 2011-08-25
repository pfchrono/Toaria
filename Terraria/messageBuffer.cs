namespace Terraria
{
    using System;
    using System.Text;

    public class messageBuffer
    {
        public bool broadcast;
        public bool checkBytes;
        public int maxSpam;
        public int messageLength;
        public byte[] readBuffer = new byte[0xffff];
        public const int readBufferMax = 0xffff;
        public int spamCount;
        public int totalData;
        public int whoAmI;
        public byte[] writeBuffer = new byte[0xffff];
        public const int writeBufferMax = 0xffff;
        public bool writeLocked;

        public void GetData(int start, int length)
        {
            byte num62;
            int num63;
            int num64;
            int num65;
            int num165;
            int num166;
            int team;
            string str16;
            int num168;
            if (this.whoAmI < 0x100)
            {
                Netplay.serverSock[this.whoAmI].timeOut = 0;
            }
            else
            {
                Netplay.clientSock.timeOut = 0;
            }
            byte msgType = 0;
            int startIndex = 0;
            startIndex = start + 1;
            msgType = this.readBuffer[start];
            if ((Main.netMode == 1) && (Netplay.clientSock.statusMax > 0))
            {
                Netplay.clientSock.statusCount++;
            }
            if (Main.verboseNetplay)
            {
                for (int i = start; i < (start + length); i++)
                {
                }
                for (int j = start; j < (start + length); j++)
                {
                    byte num1 = this.readBuffer[j];
                }
            }
            if (((Main.netMode == 2) && (msgType != 0x26)) && (Netplay.serverSock[this.whoAmI].state == -1))
            {
                NetMessage.SendData(2, this.whoAmI, -1, "Incorrect password.", 0, 0f, 0f, 0f, 0);
                return;
            }
            if ((((Main.netMode == 2) && (Netplay.serverSock[this.whoAmI].state < 10)) && ((msgType > 12) && (msgType != 0x10))) && (((msgType != 0x2a) && (msgType != 50)) && (msgType != 0x26)))
            {
                NetMessage.BootPlayer(this.whoAmI, "Invalid operation at this state.");
            }
            if ((msgType == 1) && (Main.netMode == 2))
            {
                if (Main.dedServ && Netplay.CheckBan(Netplay.serverSock[this.whoAmI].tcpClient.Client.RemoteEndPoint.ToString()))
                {
                    NetMessage.SendData(2, this.whoAmI, -1, "You are banned from this server.", 0, 0f, 0f, 0f, 0);
                    return;
                }
                if (Netplay.serverSock[this.whoAmI].state == 0)
                {
                    if (Encoding.ASCII.GetString(this.readBuffer, start + 1, length - 1) == ("Terraria" + Main.curRelease))
                    {
                        if ((Netplay.password == null) || (Netplay.password == ""))
                        {
                            Netplay.serverSock[this.whoAmI].state = 1;
                            NetMessage.SendData(3, this.whoAmI, -1, "", 0, 0f, 0f, 0f, 0);
                            return;
                        }
                        Netplay.serverSock[this.whoAmI].state = -1;
                        NetMessage.SendData(0x25, this.whoAmI, -1, "", 0, 0f, 0f, 0f, 0);
                        return;
                    }
                    NetMessage.SendData(2, this.whoAmI, -1, "You are not using the same version as this server.", 0, 0f, 0f, 0f, 0);
                    return;
                }
                return;
            }
            if ((msgType == 2) && (Main.netMode == 1))
            {
                Netplay.disconnect = true;
                Main.statusText = Encoding.ASCII.GetString(this.readBuffer, start + 1, length - 1);
                return;
            }
            if ((msgType == 3) && (Main.netMode == 1))
            {
                if (Netplay.clientSock.state == 1)
                {
                    Netplay.clientSock.state = 2;
                }
                int index = this.readBuffer[start + 1];
                if (index != Main.myPlayer)
                {
                    Main.player[index] = (Player) Main.player[Main.myPlayer].Clone();
                    Main.player[Main.myPlayer] = new Player();
                    Main.player[index].whoAmi = index;
                    Main.myPlayer = index;
                }
                NetMessage.SendData(4, -1, -1, Main.player[Main.myPlayer].name, Main.myPlayer, 0f, 0f, 0f, 0);
                NetMessage.SendData(0x10, -1, -1, "", Main.myPlayer, 0f, 0f, 0f, 0);
                NetMessage.SendData(0x2a, -1, -1, "", Main.myPlayer, 0f, 0f, 0f, 0);
                NetMessage.SendData(50, -1, -1, "", Main.myPlayer, 0f, 0f, 0f, 0);
                for (int k = 0; k < 0x2c; k++)
                {
                    NetMessage.SendData(5, -1, -1, Main.player[Main.myPlayer].inventory[k].name, Main.myPlayer, (float) k, 0f, 0f, 0);
                }
                NetMessage.SendData(5, -1, -1, Main.player[Main.myPlayer].armor[0].name, Main.myPlayer, 44f, 0f, 0f, 0);
                NetMessage.SendData(5, -1, -1, Main.player[Main.myPlayer].armor[1].name, Main.myPlayer, 45f, 0f, 0f, 0);
                NetMessage.SendData(5, -1, -1, Main.player[Main.myPlayer].armor[2].name, Main.myPlayer, 46f, 0f, 0f, 0);
                NetMessage.SendData(5, -1, -1, Main.player[Main.myPlayer].armor[3].name, Main.myPlayer, 47f, 0f, 0f, 0);
                NetMessage.SendData(5, -1, -1, Main.player[Main.myPlayer].armor[4].name, Main.myPlayer, 48f, 0f, 0f, 0);
                NetMessage.SendData(5, -1, -1, Main.player[Main.myPlayer].armor[5].name, Main.myPlayer, 49f, 0f, 0f, 0);
                NetMessage.SendData(5, -1, -1, Main.player[Main.myPlayer].armor[6].name, Main.myPlayer, 50f, 0f, 0f, 0);
                NetMessage.SendData(5, -1, -1, Main.player[Main.myPlayer].armor[7].name, Main.myPlayer, 51f, 0f, 0f, 0);
                NetMessage.SendData(5, -1, -1, Main.player[Main.myPlayer].armor[8].name, Main.myPlayer, 52f, 0f, 0f, 0);
                NetMessage.SendData(5, -1, -1, Main.player[Main.myPlayer].armor[9].name, Main.myPlayer, 53f, 0f, 0f, 0);
                NetMessage.SendData(5, -1, -1, Main.player[Main.myPlayer].armor[10].name, Main.myPlayer, 54f, 0f, 0f, 0);
                NetMessage.SendData(6, -1, -1, "", 0, 0f, 0f, 0f, 0);
                if (Netplay.clientSock.state == 2)
                {
                    Netplay.clientSock.state = 3;
                    return;
                }
                return;
            }
            switch (msgType)
            {
                case 5:
                {
                    int whoAmI = this.readBuffer[start + 1];
                    if (Main.netMode == 2)
                    {
                        whoAmI = this.whoAmI;
                    }
                    if (whoAmI == Main.myPlayer)
                    {
                        return;
                    }
                    lock (Main.player[whoAmI])
                    {
                        int num13 = this.readBuffer[start + 2];
                        int num14 = this.readBuffer[start + 3];
                        string itemName = Encoding.ASCII.GetString(this.readBuffer, start + 4, length - 4);
                        if (num13 < 0x2c)
                        {
                            Main.player[whoAmI].inventory[num13] = new Item();
                            Main.player[whoAmI].inventory[num13].SetDefaults(itemName);
                            Main.player[whoAmI].inventory[num13].stack = num14;
                        }
                        else
                        {
                            Main.player[whoAmI].armor[num13 - 0x2c] = new Item();
                            Main.player[whoAmI].armor[num13 - 0x2c].SetDefaults(itemName);
                            Main.player[whoAmI].armor[num13 - 0x2c].stack = num14;
                        }
                        if ((Main.netMode == 2) && (whoAmI == this.whoAmI))
                        {
                            NetMessage.SendData(5, -1, this.whoAmI, itemName, whoAmI, (float) num13, 0f, 0f, 0);
                        }
                        return;
                    }
                }
                case 6:
                    if (Main.netMode == 2)
                    {
                        if (Netplay.serverSock[this.whoAmI].state == 1)
                        {
                            Netplay.serverSock[this.whoAmI].state = 2;
                        }
                        NetMessage.SendData(7, this.whoAmI, -1, "", 0, 0f, 0f, 0f, 0);
                        return;
                    }
                    return;

                case 7:
                    if (Main.netMode == 1)
                    {
                        Main.time = BitConverter.ToInt32(this.readBuffer, startIndex);
                        startIndex += 4;
                        Main.dayTime = false;
                        if (this.readBuffer[startIndex] == 1)
                        {
                            Main.dayTime = true;
                        }
                        startIndex++;
                        Main.moonPhase = this.readBuffer[startIndex];
                        startIndex++;
                        int num15 = this.readBuffer[startIndex];
                        startIndex++;
                        if (num15 == 1)
                        {
                            Main.bloodMoon = true;
                        }
                        else
                        {
                            Main.bloodMoon = false;
                        }
                        Main.maxTilesX = BitConverter.ToInt32(this.readBuffer, startIndex);
                        startIndex += 4;
                        Main.maxTilesY = BitConverter.ToInt32(this.readBuffer, startIndex);
                        startIndex += 4;
                        Main.spawnTileX = BitConverter.ToInt32(this.readBuffer, startIndex);
                        startIndex += 4;
                        Main.spawnTileY = BitConverter.ToInt32(this.readBuffer, startIndex);
                        startIndex += 4;
                        Main.worldSurface = BitConverter.ToInt32(this.readBuffer, startIndex);
                        startIndex += 4;
                        Main.rockLayer = BitConverter.ToInt32(this.readBuffer, startIndex);
                        startIndex += 4;
                        Main.worldID = BitConverter.ToInt32(this.readBuffer, startIndex);
                        startIndex += 4;
                        byte num16 = this.readBuffer[startIndex];
                        if ((num16 & 1) == 1)
                        {
                            WorldGen.shadowOrbSmashed = true;
                        }
                        if ((num16 & 2) == 2)
                        {
                            NPC.downedBoss1 = true;
                        }
                        if ((num16 & 4) == 4)
                        {
                            NPC.downedBoss2 = true;
                        }
                        if ((num16 & 8) == 8)
                        {
                            NPC.downedBoss3 = true;
                        }
                        startIndex++;
                        Main.worldName = Encoding.ASCII.GetString(this.readBuffer, startIndex, (length - startIndex) + start);
                        if (Netplay.clientSock.state == 3)
                        {
                            Netplay.clientSock.state = 4;
                            return;
                        }
                    }
                    return;

                case 4:
                {
                    bool flag = false;
                    int num7 = this.readBuffer[start + 1];
                    if (Main.netMode == 2)
                    {
                        num7 = this.whoAmI;
                    }
                    if (num7 != Main.myPlayer)
                    {
                        int num8 = this.readBuffer[start + 2];
                        if (num8 >= 0x24)
                        {
                            num8 = 0;
                        }
                        Main.player[num7].hair = num8;
                        Main.player[num7].whoAmi = num7;
                        startIndex += 2;
                        byte num9 = this.readBuffer[startIndex];
                        startIndex++;
                        if (num9 == 1)
                        {
                            Main.player[num7].male = true;
                        }
                        else
                        {
                            Main.player[num7].male = false;
                        }
                        Main.player[num7].hairColor.R = this.readBuffer[startIndex];
                        startIndex++;
                        Main.player[num7].hairColor.G = this.readBuffer[startIndex];
                        startIndex++;
                        Main.player[num7].hairColor.B = this.readBuffer[startIndex];
                        startIndex++;
                        Main.player[num7].skinColor.R = this.readBuffer[startIndex];
                        startIndex++;
                        Main.player[num7].skinColor.G = this.readBuffer[startIndex];
                        startIndex++;
                        Main.player[num7].skinColor.B = this.readBuffer[startIndex];
                        startIndex++;
                        Main.player[num7].eyeColor.R = this.readBuffer[startIndex];
                        startIndex++;
                        Main.player[num7].eyeColor.G = this.readBuffer[startIndex];
                        startIndex++;
                        Main.player[num7].eyeColor.B = this.readBuffer[startIndex];
                        startIndex++;
                        Main.player[num7].shirtColor.R = this.readBuffer[startIndex];
                        startIndex++;
                        Main.player[num7].shirtColor.G = this.readBuffer[startIndex];
                        startIndex++;
                        Main.player[num7].shirtColor.B = this.readBuffer[startIndex];
                        startIndex++;
                        Main.player[num7].underShirtColor.R = this.readBuffer[startIndex];
                        startIndex++;
                        Main.player[num7].underShirtColor.G = this.readBuffer[startIndex];
                        startIndex++;
                        Main.player[num7].underShirtColor.B = this.readBuffer[startIndex];
                        startIndex++;
                        Main.player[num7].pantsColor.R = this.readBuffer[startIndex];
                        startIndex++;
                        Main.player[num7].pantsColor.G = this.readBuffer[startIndex];
                        startIndex++;
                        Main.player[num7].pantsColor.B = this.readBuffer[startIndex];
                        startIndex++;
                        Main.player[num7].shoeColor.R = this.readBuffer[startIndex];
                        startIndex++;
                        Main.player[num7].shoeColor.G = this.readBuffer[startIndex];
                        startIndex++;
                        Main.player[num7].shoeColor.B = this.readBuffer[startIndex];
                        startIndex++;
                        byte num10 = this.readBuffer[startIndex];
                        Main.player[num7].difficulty = num10;
                        startIndex++;
                        string text = Encoding.ASCII.GetString(this.readBuffer, startIndex, (length - startIndex) + start).Trim();
                        Main.player[num7].name = text.Trim();
                        if (Main.netMode == 2)
                        {
                            if (Netplay.serverSock[this.whoAmI].state < 10)
                            {
                                for (int m = 0; m < 0xff; m++)
                                {
                                    if (((m != num7) && (text == Main.player[m].name)) && Netplay.serverSock[m].active)
                                    {
                                        flag = true;
                                    }
                                }
                            }
                            if (flag)
                            {
                                NetMessage.SendData(2, this.whoAmI, -1, text + " is already on this server.", 0, 0f, 0f, 0f, 0);
                                return;
                            }
                            if (text.Length > Player.nameLen)
                            {
                                NetMessage.SendData(2, this.whoAmI, -1, "Name is too long.", 0, 0f, 0f, 0f, 0);
                                return;
                            }
                            if (text == "")
                            {
                                NetMessage.SendData(2, this.whoAmI, -1, "Empty name.", 0, 0f, 0f, 0f, 0);
                                return;
                            }
                            Netplay.serverSock[this.whoAmI].oldName = text;
                            Netplay.serverSock[this.whoAmI].name = text;
                            NetMessage.SendData(4, -1, this.whoAmI, text, num7, 0f, 0f, 0f, 0);
                            return;
                        }
                    }
                    return;
                }
                case 8:
                    if (Main.netMode == 2)
                    {
                        int x = BitConverter.ToInt32(this.readBuffer, startIndex);
                        startIndex += 4;
                        int y = BitConverter.ToInt32(this.readBuffer, startIndex);
                        startIndex += 4;
                        bool flag3 = true;
                        if ((x == -1) || (y == -1))
                        {
                            flag3 = false;
                        }
                        else if ((x < 10) || (x > (Main.maxTilesX - 10)))
                        {
                            flag3 = false;
                        }
                        else if ((y < 10) || (y > (Main.maxTilesY - 10)))
                        {
                            flag3 = false;
                        }
                        int number = 0x546;
                        if (flag3)
                        {
                            number *= 2;
                        }
                        if (Netplay.serverSock[this.whoAmI].state == 2)
                        {
                            Netplay.serverSock[this.whoAmI].state = 3;
                        }
                        NetMessage.SendData(9, this.whoAmI, -1, "Receiving tile data", number, 0f, 0f, 0f, 0);
                        Netplay.serverSock[this.whoAmI].statusText2 = "is receiving tile data";
                        ServerSock sock1 = Netplay.serverSock[this.whoAmI];
                        sock1.statusMax += number;
                        int sectionX = Netplay.GetSectionX(Main.spawnTileX);
                        int sectionY = Netplay.GetSectionY(Main.spawnTileY);
                        for (int n = sectionX - 2; n < (sectionX + 3); n++)
                        {
                            for (int num23 = sectionY - 1; num23 < (sectionY + 2); num23++)
                            {
                                NetMessage.SendSection(this.whoAmI, n, num23);
                            }
                        }
                        if (flag3)
                        {
                            x = Netplay.GetSectionX(x);
                            y = Netplay.GetSectionY(y);
                            for (int num24 = x - 2; num24 < (x + 3); num24++)
                            {
                                for (int num25 = y - 1; num25 < (y + 2); num25++)
                                {
                                    NetMessage.SendSection(this.whoAmI, num24, num25);
                                }
                            }
                            NetMessage.SendData(11, this.whoAmI, -1, "", x - 2, (float) (y - 1), (float) (x + 2), (float) (y + 1), 0);
                        }
                        NetMessage.SendData(11, this.whoAmI, -1, "", sectionX - 2, (float) (sectionY - 1), (float) (sectionX + 2), (float) (sectionY + 1), 0);
                        for (int num26 = 0; num26 < 200; num26++)
                        {
                            if (Main.item[num26].active)
                            {
                                NetMessage.SendData(0x15, this.whoAmI, -1, "", num26, 0f, 0f, 0f, 0);
                                NetMessage.SendData(0x16, this.whoAmI, -1, "", num26, 0f, 0f, 0f, 0);
                            }
                        }
                        for (int num27 = 0; num27 < 0x3e8; num27++)
                        {
                            if (Main.npc[num27].active)
                            {
                                NetMessage.SendData(0x17, this.whoAmI, -1, "", num27, 0f, 0f, 0f, 0);
                            }
                        }
                        NetMessage.SendData(0x31, this.whoAmI, -1, "", 0, 0f, 0f, 0f, 0);
                        return;
                    }
                    return;

                case 9:
                    if (Main.netMode == 1)
                    {
                        int num28 = BitConverter.ToInt32(this.readBuffer, start + 1);
                        string str4 = Encoding.ASCII.GetString(this.readBuffer, start + 5, length - 5);
                        Netplay.clientSock.statusMax += num28;
                        Netplay.clientSock.statusText = str4;
                        return;
                    }
                    return;
            }
            if ((msgType == 10) && (Main.netMode == 1))
            {
                short num29 = BitConverter.ToInt16(this.readBuffer, start + 1);
                int num30 = BitConverter.ToInt32(this.readBuffer, start + 3);
                int num31 = BitConverter.ToInt32(this.readBuffer, start + 7);
                startIndex = start + 11;
                for (int num33 = num30; num33 < (num30 + num29); num33++)
                {
                    if (Main.tile[num33, num31] == null)
                    {
                        Main.tile[num33, num31] = new Tile();
                    }
                    byte num32 = this.readBuffer[startIndex];
                    startIndex++;
                    bool active = Main.tile[num33, num31].active;
                    if ((num32 & 1) == 1)
                    {
                        Main.tile[num33, num31].active = true;
                    }
                    else
                    {
                        Main.tile[num33, num31].active = false;
                    }
                    if ((num32 & 2) == 2)
                    {
                        Main.tile[num33, num31].lighted = true;
                    }
                    if ((num32 & 4) == 4)
                    {
                        Main.tile[num33, num31].wall = 1;
                    }
                    else
                    {
                        Main.tile[num33, num31].wall = 0;
                    }
                    if ((num32 & 8) == 8)
                    {
                        Main.tile[num33, num31].liquid = 1;
                    }
                    else
                    {
                        Main.tile[num33, num31].liquid = 0;
                    }
                    if (Main.tile[num33, num31].active)
                    {
                        int type = Main.tile[num33, num31].type;
                        Main.tile[num33, num31].type = this.readBuffer[startIndex];
                        startIndex++;
                        if (Main.tileFrameImportant[Main.tile[num33, num31].type])
                        {
                            Main.tile[num33, num31].frameX = BitConverter.ToInt16(this.readBuffer, startIndex);
                            startIndex += 2;
                            Main.tile[num33, num31].frameY = BitConverter.ToInt16(this.readBuffer, startIndex);
                            startIndex += 2;
                        }
                        else if (!active || (Main.tile[num33, num31].type != type))
                        {
                            Main.tile[num33, num31].frameX = -1;
                            Main.tile[num33, num31].frameY = -1;
                        }
                    }
                    if (Main.tile[num33, num31].wall > 0)
                    {
                        Main.tile[num33, num31].wall = this.readBuffer[startIndex];
                        startIndex++;
                    }
                    if (Main.tile[num33, num31].liquid > 0)
                    {
                        Main.tile[num33, num31].liquid = this.readBuffer[startIndex];
                        startIndex++;
                        byte num35 = this.readBuffer[startIndex];
                        startIndex++;
                        if (num35 == 1)
                        {
                            Main.tile[num33, num31].lava = true;
                        }
                        else
                        {
                            Main.tile[num33, num31].lava = false;
                        }
                    }
                }
                if (Main.netMode == 2)
                {
                    NetMessage.SendData(msgType, -1, this.whoAmI, "", num29, (float) num30, (float) num31, 0f, 0);
                    return;
                }
                return;
            }
            if (msgType == 11)
            {
                if (Main.netMode == 1)
                {
                    int startX = BitConverter.ToInt16(this.readBuffer, startIndex);
                    startIndex += 4;
                    int startY = BitConverter.ToInt16(this.readBuffer, startIndex);
                    startIndex += 4;
                    int endX = BitConverter.ToInt16(this.readBuffer, startIndex);
                    startIndex += 4;
                    int endY = BitConverter.ToInt16(this.readBuffer, startIndex);
                    startIndex += 4;
                    WorldGen.SectionTileFrame(startX, startY, endX, endY);
                    return;
                }
                return;
            }
            if (msgType == 12)
            {
                int num40 = this.readBuffer[startIndex];
                if (Main.netMode == 2)
                {
                    num40 = this.whoAmI;
                }
                startIndex++;
                Main.player[num40].SpawnX = BitConverter.ToInt32(this.readBuffer, startIndex);
                startIndex += 4;
                Main.player[num40].SpawnY = BitConverter.ToInt32(this.readBuffer, startIndex);
                startIndex += 4;
                Main.player[num40].Spawn();
                if ((Main.netMode == 2) && (Netplay.serverSock[this.whoAmI].state >= 3))
                {
                    if (Netplay.serverSock[this.whoAmI].state == 3)
                    {
                        Netplay.serverSock[this.whoAmI].state = 10;
                        NetMessage.greetPlayer(this.whoAmI);
                        NetMessage.buffer[this.whoAmI].broadcast = true;
                        NetMessage.syncPlayers();
                        NetMessage.SendData(12, -1, this.whoAmI, "", this.whoAmI, 0f, 0f, 0f, 0);
                        return;
                    }
                    NetMessage.SendData(12, -1, this.whoAmI, "", this.whoAmI, 0f, 0f, 0f, 0);
                    return;
                }
                return;
            }
            if (msgType == 13)
            {
                int num41 = this.readBuffer[startIndex];
                if (num41 != Main.myPlayer)
                {
                    if (Main.netMode == 1)
                    {
                        bool flag1 = Main.player[num41].active;
                    }
                    if (Main.netMode == 2)
                    {
                        num41 = this.whoAmI;
                    }
                    startIndex++;
                    int num42 = this.readBuffer[startIndex];
                    startIndex++;
                    int num43 = this.readBuffer[startIndex];
                    startIndex++;
                    float num44 = BitConverter.ToSingle(this.readBuffer, startIndex);
                    startIndex += 4;
                    float num45 = BitConverter.ToSingle(this.readBuffer, startIndex);
                    startIndex += 4;
                    float num46 = BitConverter.ToSingle(this.readBuffer, startIndex);
                    startIndex += 4;
                    float num47 = BitConverter.ToSingle(this.readBuffer, startIndex);
                    startIndex += 4;
                    Main.player[num41].selectedItem = num43;
                    Main.player[num41].position.X = num44;
                    Main.player[num41].position.Y = num45;
                    Main.player[num41].velocity.X = num46;
                    Main.player[num41].velocity.Y = num47;
                    Main.player[num41].oldVelocity = Main.player[num41].velocity;
                    Main.player[num41].fallStart = (int) (num45 / 16f);
                    Main.player[num41].controlUp = false;
                    Main.player[num41].controlDown = false;
                    Main.player[num41].controlLeft = false;
                    Main.player[num41].controlRight = false;
                    Main.player[num41].controlJump = false;
                    Main.player[num41].controlUseItem = false;
                    Main.player[num41].direction = -1;
                    if ((num42 & 1) == 1)
                    {
                        Main.player[num41].controlUp = true;
                    }
                    if ((num42 & 2) == 2)
                    {
                        Main.player[num41].controlDown = true;
                    }
                    if ((num42 & 4) == 4)
                    {
                        Main.player[num41].controlLeft = true;
                    }
                    if ((num42 & 8) == 8)
                    {
                        Main.player[num41].controlRight = true;
                    }
                    if ((num42 & 0x10) == 0x10)
                    {
                        Main.player[num41].controlJump = true;
                    }
                    if ((num42 & 0x20) == 0x20)
                    {
                        Main.player[num41].controlUseItem = true;
                    }
                    if ((num42 & 0x40) == 0x40)
                    {
                        Main.player[num41].direction = 1;
                    }
                    if ((Main.netMode == 2) && (Netplay.serverSock[this.whoAmI].state == 10))
                    {
                        NetMessage.SendData(13, -1, this.whoAmI, "", num41, 0f, 0f, 0f, 0);
                        return;
                    }
                }
                return;
            }
            if (msgType == 14)
            {
                if (Main.netMode == 1)
                {
                    int num48 = this.readBuffer[startIndex];
                    startIndex++;
                    int num49 = this.readBuffer[startIndex];
                    if (num49 == 1)
                    {
                        if (!Main.player[num48].active)
                        {
                            Main.player[num48] = new Player();
                        }
                        Main.player[num48].active = true;
                        return;
                    }
                    Main.player[num48].active = false;
                    return;
                }
                return;
            }
            if (msgType == 15)
            {
                if (Main.netMode == 2)
                {
                    return;
                }
                return;
            }
            if (msgType == 0x10)
            {
                int num50 = this.readBuffer[startIndex];
                startIndex++;
                if (num50 != Main.myPlayer)
                {
                    int num51 = BitConverter.ToInt16(this.readBuffer, startIndex);
                    startIndex += 2;
                    int num52 = BitConverter.ToInt16(this.readBuffer, startIndex);
                    if (Main.netMode == 2)
                    {
                        num50 = this.whoAmI;
                    }
                    Main.player[num50].statLife = num51;
                    Main.player[num50].statLifeMax = num52;
                    if (Main.player[num50].statLife <= 0)
                    {
                        Main.player[num50].dead = true;
                    }
                    if (Main.netMode == 2)
                    {
                        NetMessage.SendData(0x10, -1, this.whoAmI, "", num50, 0f, 0f, 0f, 0);
                        return;
                    }
                }
                return;
            }
            if (msgType != 0x11)
            {
                if (msgType == 0x12)
                {
                    if (Main.netMode == 1)
                    {
                        byte num58 = this.readBuffer[startIndex];
                        startIndex++;
                        int num59 = BitConverter.ToInt32(this.readBuffer, startIndex);
                        startIndex += 4;
                        short num60 = BitConverter.ToInt16(this.readBuffer, startIndex);
                        startIndex += 2;
                        short num61 = BitConverter.ToInt16(this.readBuffer, startIndex);
                        startIndex += 2;
                        if (num58 == 1)
                        {
                            Main.dayTime = true;
                        }
                        else
                        {
                            Main.dayTime = false;
                        }
                        Main.time = num59;
                        Main.sunModY = num60;
                        Main.moonModY = num61;
                        if (Main.netMode == 2)
                        {
                            NetMessage.SendData(0x12, -1, this.whoAmI, "", 0, 0f, 0f, 0f, 0);
                            return;
                        }
                    }
                    return;
                }
                if (msgType != 0x13)
                {
                    if (msgType == 20)
                    {
                        short num67 = BitConverter.ToInt16(this.readBuffer, start + 1);
                        int num68 = BitConverter.ToInt32(this.readBuffer, start + 3);
                        int num69 = BitConverter.ToInt32(this.readBuffer, start + 7);
                        startIndex = start + 11;
                        for (int num71 = num68; num71 < (num68 + num67); num71++)
                        {
                            for (int num72 = num69; num72 < (num69 + num67); num72++)
                            {
                                if (Main.tile[num71, num72] == null)
                                {
                                    Main.tile[num71, num72] = new Tile();
                                }
                                byte num70 = this.readBuffer[startIndex];
                                startIndex++;
                                bool flag6 = Main.tile[num71, num72].active;
                                if ((num70 & 1) == 1)
                                {
                                    Main.tile[num71, num72].active = true;
                                }
                                else
                                {
                                    Main.tile[num71, num72].active = false;
                                }
                                if ((num70 & 2) == 2)
                                {
                                    Main.tile[num71, num72].lighted = true;
                                }
                                if ((num70 & 4) == 4)
                                {
                                    Main.tile[num71, num72].wall = 1;
                                }
                                else
                                {
                                    Main.tile[num71, num72].wall = 0;
                                }
                                if ((num70 & 8) == 8)
                                {
                                    Main.tile[num71, num72].liquid = 1;
                                }
                                else
                                {
                                    Main.tile[num71, num72].liquid = 0;
                                }
                                if (Main.tile[num71, num72].active)
                                {
                                    int num73 = Main.tile[num71, num72].type;
                                    Main.tile[num71, num72].type = this.readBuffer[startIndex];
                                    startIndex++;
                                    if (Main.tileFrameImportant[Main.tile[num71, num72].type])
                                    {
                                        Main.tile[num71, num72].frameX = BitConverter.ToInt16(this.readBuffer, startIndex);
                                        startIndex += 2;
                                        Main.tile[num71, num72].frameY = BitConverter.ToInt16(this.readBuffer, startIndex);
                                        startIndex += 2;
                                    }
                                    else if (!flag6 || (Main.tile[num71, num72].type != num73))
                                    {
                                        Main.tile[num71, num72].frameX = -1;
                                        Main.tile[num71, num72].frameY = -1;
                                    }
                                }
                                if (Main.tile[num71, num72].wall > 0)
                                {
                                    Main.tile[num71, num72].wall = this.readBuffer[startIndex];
                                    startIndex++;
                                }
                                if (Main.tile[num71, num72].liquid > 0)
                                {
                                    Main.tile[num71, num72].liquid = this.readBuffer[startIndex];
                                    startIndex++;
                                    byte num74 = this.readBuffer[startIndex];
                                    startIndex++;
                                    if (num74 == 1)
                                    {
                                        Main.tile[num71, num72].lava = true;
                                    }
                                    else
                                    {
                                        Main.tile[num71, num72].lava = false;
                                    }
                                }
                            }
                        }
                        WorldGen.RangeFrame(num68, num69, num68 + num67, num69 + num67);
                        if (Main.netMode == 2)
                        {
                            NetMessage.SendData(msgType, -1, this.whoAmI, "", num67, (float) num68, (float) num69, 0f, 0);
                            return;
                        }
                        return;
                    }
                    if (msgType == 0x15)
                    {
                        short num75 = BitConverter.ToInt16(this.readBuffer, startIndex);
                        startIndex += 2;
                        float num76 = BitConverter.ToSingle(this.readBuffer, startIndex);
                        startIndex += 4;
                        float num77 = BitConverter.ToSingle(this.readBuffer, startIndex);
                        startIndex += 4;
                        float num78 = BitConverter.ToSingle(this.readBuffer, startIndex);
                        startIndex += 4;
                        float num79 = BitConverter.ToSingle(this.readBuffer, startIndex);
                        startIndex += 4;
                        byte stack = this.readBuffer[startIndex];
                        startIndex++;
                        string str5 = Encoding.ASCII.GetString(this.readBuffer, startIndex, (length - startIndex) + start);
                        if (Main.netMode == 1)
                        {
                            if (str5 == "0")
                            {
                                Main.item[num75].active = false;
                                return;
                            }
                            Main.item[num75].SetDefaults(str5);
                            Main.item[num75].stack = stack;
                            Main.item[num75].position.X = num76;
                            Main.item[num75].position.Y = num77;
                            Main.item[num75].velocity.X = num78;
                            Main.item[num75].velocity.Y = num79;
                            Main.item[num75].active = true;
                            Main.item[num75].wet = Collision.WetCollision(Main.item[num75].position, Main.item[num75].width, Main.item[num75].height);
                            return;
                        }
                        if (str5 != "0")
                        {
                            bool flag7 = false;
                            if (num75 == 200)
                            {
                                flag7 = true;
                            }
                            if (flag7)
                            {
                                Item item = new Item();
                                item.SetDefaults(str5);
                                num75 = (short) Item.NewItem((int) num76, (int) num77, item.width, item.height, item.type, stack, true);
                            }
                            Main.item[num75].SetDefaults(str5);
                            Main.item[num75].stack = stack;
                            Main.item[num75].position.X = num76;
                            Main.item[num75].position.Y = num77;
                            Main.item[num75].velocity.X = num78;
                            Main.item[num75].velocity.Y = num79;
                            Main.item[num75].active = true;
                            Main.item[num75].owner = Main.myPlayer;
                            if (flag7)
                            {
                                NetMessage.SendData(0x15, -1, -1, "", num75, 0f, 0f, 0f, 0);
                                Main.item[num75].ownIgnore = this.whoAmI;
                                Main.item[num75].ownTime = 100;
                                Main.item[num75].FindOwner(num75);
                                return;
                            }
                            NetMessage.SendData(0x15, -1, this.whoAmI, "", num75, 0f, 0f, 0f, 0);
                            return;
                        }
                        if (num75 < 200)
                        {
                            Main.item[num75].active = false;
                            NetMessage.SendData(0x15, -1, -1, "", num75, 0f, 0f, 0f, 0);
                            return;
                        }
                        return;
                    }
                    if (msgType == 0x16)
                    {
                        short num81 = BitConverter.ToInt16(this.readBuffer, startIndex);
                        startIndex += 2;
                        byte num82 = this.readBuffer[startIndex];
                        if ((Main.netMode != 2) || (Main.item[num81].owner == this.whoAmI))
                        {
                            Main.item[num81].owner = num82;
                            if (num82 == Main.myPlayer)
                            {
                                Main.item[num81].keepTime = 15;
                            }
                            else
                            {
                                Main.item[num81].keepTime = 0;
                            }
                            if (Main.netMode == 2)
                            {
                                Main.item[num81].owner = 0xff;
                                Main.item[num81].keepTime = 15;
                                NetMessage.SendData(0x16, -1, -1, "", num81, 0f, 0f, 0f, 0);
                                return;
                            }
                        }
                        return;
                    }
                    if ((msgType == 0x17) && (Main.netMode == 1))
                    {
                        short num83 = BitConverter.ToInt16(this.readBuffer, startIndex);
                        startIndex += 2;
                        float num84 = BitConverter.ToSingle(this.readBuffer, startIndex);
                        startIndex += 4;
                        float num85 = BitConverter.ToSingle(this.readBuffer, startIndex);
                        startIndex += 4;
                        float num86 = BitConverter.ToSingle(this.readBuffer, startIndex);
                        startIndex += 4;
                        float num87 = BitConverter.ToSingle(this.readBuffer, startIndex);
                        startIndex += 4;
                        int num88 = BitConverter.ToInt16(this.readBuffer, startIndex);
                        startIndex += 2;
                        int num89 = this.readBuffer[startIndex] - 1;
                        startIndex++;
                        int num90 = this.readBuffer[startIndex] - 1;
                        startIndex++;
                        int num91 = BitConverter.ToInt16(this.readBuffer, startIndex);
                        startIndex += 2;
                        float[] numArray = new float[NPC.maxAI];
                        for (int num92 = 0; num92 < NPC.maxAI; num92++)
                        {
                            numArray[num92] = BitConverter.ToSingle(this.readBuffer, startIndex);
                            startIndex += 4;
                        }
                        string name = Encoding.ASCII.GetString(this.readBuffer, startIndex, (length - startIndex) + start);
                        if (!Main.npc[num83].active || (Main.npc[num83].name != name))
                        {
                            Main.npc[num83].active = true;
                            Main.npc[num83].SetDefaults(name);
                        }
                        Main.npc[num83].position.X = num84;
                        Main.npc[num83].position.Y = num85;
                        Main.npc[num83].velocity.X = num86;
                        Main.npc[num83].velocity.Y = num87;
                        Main.npc[num83].target = num88;
                        Main.npc[num83].direction = num89;
                        Main.npc[num83].directionY = num90;
                        Main.npc[num83].life = num91;
                        if (num91 <= 0)
                        {
                            Main.npc[num83].active = false;
                        }
                        for (int num93 = 0; num93 < NPC.maxAI; num93++)
                        {
                            Main.npc[num83].ai[num93] = numArray[num93];
                        }
                        return;
                    }
                    if (msgType == 0x18)
                    {
                        short num94 = BitConverter.ToInt16(this.readBuffer, startIndex);
                        startIndex += 2;
                        byte num95 = this.readBuffer[startIndex];
                        if (Main.netMode == 2)
                        {
                            num95 = (byte) this.whoAmI;
                        }
                        Main.npc[num94].StrikeNPC(Main.player[num95].inventory[Main.player[num95].selectedItem].damage, Main.player[num95].inventory[Main.player[num95].selectedItem].knockBack, Main.player[num95].direction, false);
                        if (Main.netMode == 2)
                        {
                            NetMessage.SendData(0x18, -1, this.whoAmI, "", num94, (float) num95, 0f, 0f, 0);
                            NetMessage.SendData(0x17, -1, -1, "", num94, 0f, 0f, 0f, 0);
                            return;
                        }
                        return;
                    }
                    if (msgType == 0x19)
                    {
                        int num96 = this.readBuffer[start + 1];
                        if (Main.netMode == 2)
                        {
                            num96 = this.whoAmI;
                        }
                        byte r = this.readBuffer[start + 2];
                        byte g = this.readBuffer[start + 3];
                        byte b = this.readBuffer[start + 4];
                        if (Main.netMode == 2)
                        {
                            r = 0xff;
                            g = 0xff;
                            b = 0xff;
                        }
                        string str7 = Encoding.ASCII.GetString(this.readBuffer, start + 5, length - 5);
                        if (Main.netMode == 1)
                        {
                            string newText = str7;
                            if (num96 < 0xff)
                            {
                                newText = "<" + Main.player[num96].name + "> " + str7;
                                Main.player[num96].chatText = str7;
                                Main.player[num96].chatShowTime = Main.chatLength / 2;
                            }
                            Main.NewText(newText, r, g, b);
                            return;
                        }
                        if (Main.netMode == 2)
                        {
                            string str9 = str7.ToLower();
                            if (str9 == "/playing")
                            {
                                string str10 = "";
                                for (int num100 = 0; num100 < 0xff; num100++)
                                {
                                    if (Main.player[num100].active)
                                    {
                                        if (str10 == "")
                                        {
                                            str10 = str10 + Main.player[num100].name;
                                        }
                                        else
                                        {
                                            str10 = str10 + ", " + Main.player[num100].name;
                                        }
                                    }
                                }
                                NetMessage.SendData(0x19, this.whoAmI, -1, "Current players: " + str10 + ".", 0xff, 255f, 240f, 20f, 0);
                                return;
                            }
                            if ((str9.Length >= 4) && (str9.Substring(0, 4) == "/me "))
                            {
                                NetMessage.SendData(0x19, -1, -1, "*" + Main.player[this.whoAmI].name + " " + str7.Substring(4), 0xff, 200f, 100f, 0f, 0);
                                return;
                            }
                            if ((str9.Length >= 3) && (str9.Substring(0, 3) == "/p "))
                            {
                                if (Main.player[this.whoAmI].team != 0)
                                {
                                    for (int num101 = 0; num101 < 0xff; num101++)
                                    {
                                        if (Main.player[num101].team == Main.player[this.whoAmI].team)
                                        {
                                            NetMessage.SendData(0x19, num101, -1, str7.Substring(3), num96, (float) Main.teamColor[Main.player[this.whoAmI].team].R, (float) Main.teamColor[Main.player[this.whoAmI].team].G, (float) Main.teamColor[Main.player[this.whoAmI].team].B, 0);
                                        }
                                    }
                                    return;
                                }
                                NetMessage.SendData(0x19, this.whoAmI, -1, "You are not in a party!", 0xff, 255f, 240f, 20f, 0);
                                return;
                            }
                            if (Main.player[this.whoAmI].difficulty == 2)
                            {
                                r = Main.hcColor.R;
                                g = Main.hcColor.G;
                                b = Main.hcColor.B;
                            }
                            else if (Main.player[this.whoAmI].difficulty == 1)
                            {
                                r = Main.mcColor.R;
                                g = Main.mcColor.G;
                                b = Main.mcColor.B;
                            }
                            NetMessage.SendData(0x19, -1, -1, str7, num96, (float) r, (float) g, (float) b, 0);
                            if (Main.dedServ)
                            {
                                Console.WriteLine("<" + Main.player[this.whoAmI].name + "> " + str7);
                                return;
                            }
                        }
                        return;
                    }
                    if (msgType == 0x1a)
                    {
                        byte num102 = this.readBuffer[startIndex];
                        if (((Main.netMode != 2) || (this.whoAmI == num102)) || (Main.player[num102].hostile && Main.player[this.whoAmI].hostile))
                        {
                            startIndex++;
                            int hitDirection = this.readBuffer[startIndex] - 1;
                            startIndex++;
                            short damage = BitConverter.ToInt16(this.readBuffer, startIndex);
                            startIndex += 2;
                            byte num105 = this.readBuffer[startIndex];
                            startIndex++;
                            bool pvp = false;
                            byte num106 = this.readBuffer[startIndex];
                            startIndex++;
                            bool crit = false;
                            string deathText = Encoding.ASCII.GetString(this.readBuffer, startIndex, (length - startIndex) + start);
                            if (num105 != 0)
                            {
                                pvp = true;
                            }
                            if (num106 != 0)
                            {
                                crit = true;
                            }
                            Main.player[num102].Hurt(damage, hitDirection, pvp, true, deathText, crit);
                            if (Main.netMode == 2)
                            {
                                NetMessage.SendData(0x1a, -1, this.whoAmI, deathText, num102, (float) hitDirection, (float) damage, (float) num105, 0);
                                return;
                            }
                        }
                        return;
                    }
                    if (msgType == 0x1b)
                    {
                        short num107 = BitConverter.ToInt16(this.readBuffer, startIndex);
                        startIndex += 2;
                        float num108 = BitConverter.ToSingle(this.readBuffer, startIndex);
                        startIndex += 4;
                        float num109 = BitConverter.ToSingle(this.readBuffer, startIndex);
                        startIndex += 4;
                        float num110 = BitConverter.ToSingle(this.readBuffer, startIndex);
                        startIndex += 4;
                        float num111 = BitConverter.ToSingle(this.readBuffer, startIndex);
                        startIndex += 4;
                        float num112 = BitConverter.ToSingle(this.readBuffer, startIndex);
                        startIndex += 4;
                        short num113 = BitConverter.ToInt16(this.readBuffer, startIndex);
                        startIndex += 2;
                        byte num114 = this.readBuffer[startIndex];
                        startIndex++;
                        byte num115 = this.readBuffer[startIndex];
                        startIndex++;
                        float[] numArray2 = new float[Projectile.maxAI];
                        for (int num116 = 0; num116 < Projectile.maxAI; num116++)
                        {
                            numArray2[num116] = BitConverter.ToSingle(this.readBuffer, startIndex);
                            startIndex += 4;
                        }
                        int num117 = 0x3e8;
                        for (int num118 = 0; num118 < 0x3e8; num118++)
                        {
                            if (((Main.projectile[num118].owner == num114) && (Main.projectile[num118].identity == num107)) && Main.projectile[num118].active)
                            {
                                num117 = num118;
                                break;
                            }
                        }
                        if (num117 == 0x3e8)
                        {
                            for (int num119 = 0; num119 < 0x3e8; num119++)
                            {
                                if (!Main.projectile[num119].active)
                                {
                                    num117 = num119;
                                    break;
                                }
                            }
                        }
                        if (!Main.projectile[num117].active || (Main.projectile[num117].type != num115))
                        {
                            Main.projectile[num117].SetDefaults(num115);
                            if (Main.netMode == 2)
                            {
                                ServerSock sock4 = Netplay.serverSock[this.whoAmI];
                                sock4.spamProjectile++;
                            }
                        }
                        Main.projectile[num117].identity = num107;
                        Main.projectile[num117].position.X = num108;
                        Main.projectile[num117].position.Y = num109;
                        Main.projectile[num117].velocity.X = num110;
                        Main.projectile[num117].velocity.Y = num111;
                        Main.projectile[num117].damage = num113;
                        Main.projectile[num117].type = num115;
                        Main.projectile[num117].owner = num114;
                        Main.projectile[num117].knockBack = num112;
                        for (int num120 = 0; num120 < Projectile.maxAI; num120++)
                        {
                            Main.projectile[num117].ai[num120] = numArray2[num120];
                        }
                        if (Main.netMode == 2)
                        {
                            NetMessage.SendData(0x1b, -1, this.whoAmI, "", num117, 0f, 0f, 0f, 0);
                        }
                        return;
                    }
                    if (msgType == 0x1c)
                    {
                        short num121 = BitConverter.ToInt16(this.readBuffer, startIndex);
                        startIndex += 2;
                        short num122 = BitConverter.ToInt16(this.readBuffer, startIndex);
                        startIndex += 2;
                        float knockBack = BitConverter.ToSingle(this.readBuffer, startIndex);
                        startIndex += 4;
                        int num124 = this.readBuffer[startIndex] - 1;
                        startIndex++;
                        int num125 = this.readBuffer[startIndex];
                        if (num122 >= 0)
                        {
                            if (num125 == 1)
                            {
                                Main.npc[num121].StrikeNPC(num122, knockBack, num124, true);
                            }
                            else
                            {
                                Main.npc[num121].StrikeNPC(num122, knockBack, num124, false);
                            }
                        }
                        else
                        {
                            Main.npc[num121].life = 0;
                            Main.npc[num121].HitEffect(0, 10.0);
                            Main.npc[num121].active = false;
                        }
                        if (Main.netMode == 2)
                        {
                            NetMessage.SendData(0x1c, -1, this.whoAmI, "", num121, (float) num122, knockBack, (float) num124, num125);
                            NetMessage.SendData(0x17, -1, -1, "", num121, 0f, 0f, 0f, 0);
                            return;
                        }
                        return;
                    }
                    if (msgType == 0x1d)
                    {
                        short num126 = BitConverter.ToInt16(this.readBuffer, startIndex);
                        startIndex += 2;
                        byte num127 = this.readBuffer[startIndex];
                        if (Main.netMode == 2)
                        {
                            num127 = (byte) this.whoAmI;
                        }
                        for (int num128 = 0; num128 < 0x3e8; num128++)
                        {
                            if (((Main.projectile[num128].owner == num127) && (Main.projectile[num128].identity == num126)) && Main.projectile[num128].active)
                            {
                                Main.projectile[num128].Kill();
                                break;
                            }
                        }
                        if (Main.netMode == 2)
                        {
                            NetMessage.SendData(0x1d, -1, this.whoAmI, "", num126, (float) num127, 0f, 0f, 0);
                        }
                        return;
                    }
                    if (msgType == 30)
                    {
                        byte num129 = this.readBuffer[startIndex];
                        if (Main.netMode == 2)
                        {
                            num129 = (byte) this.whoAmI;
                        }
                        startIndex++;
                        byte num130 = this.readBuffer[startIndex];
                        if (num130 == 1)
                        {
                            Main.player[num129].hostile = true;
                        }
                        else
                        {
                            Main.player[num129].hostile = false;
                        }
                        if (Main.netMode == 2)
                        {
                            NetMessage.SendData(30, -1, this.whoAmI, "", num129, 0f, 0f, 0f, 0);
                            string str12 = " has enabled PvP!";
                            if (num130 == 0)
                            {
                                str12 = " has disabled PvP!";
                            }
                            NetMessage.SendData(0x19, -1, -1, Main.player[num129].name + str12, 0xff, (float) Main.teamColor[Main.player[num129].team].R, (float) Main.teamColor[Main.player[num129].team].G, (float) Main.teamColor[Main.player[num129].team].B, 0);
                            return;
                        }
                        return;
                    }
                    if (msgType == 0x1f)
                    {
                        if (Main.netMode == 2)
                        {
                            int num131 = BitConverter.ToInt32(this.readBuffer, startIndex);
                            startIndex += 4;
                            int num132 = BitConverter.ToInt32(this.readBuffer, startIndex);
                            startIndex += 4;
                            int num133 = Chest.FindChest(num131, num132);
                            if ((num133 > -1) && (Chest.UsingChest(num133) == -1))
                            {
                                for (int num134 = 0; num134 < Chest.maxItems; num134++)
                                {
                                    NetMessage.SendData(0x20, this.whoAmI, -1, "", num133, (float) num134, 0f, 0f, 0);
                                }
                                NetMessage.SendData(0x21, this.whoAmI, -1, "", num133, 0f, 0f, 0f, 0);
                                Main.player[this.whoAmI].chest = num133;
                                return;
                            }
                        }
                        return;
                    }
                    if (msgType == 0x20)
                    {
                        int num135 = BitConverter.ToInt16(this.readBuffer, startIndex);
                        startIndex += 2;
                        int num136 = this.readBuffer[startIndex];
                        startIndex++;
                        int num137 = this.readBuffer[startIndex];
                        startIndex++;
                        string str13 = Encoding.ASCII.GetString(this.readBuffer, startIndex, (length - startIndex) + start);
                        if (Main.chest[num135] == null)
                        {
                            Main.chest[num135] = new Chest();
                        }
                        if (Main.chest[num135].item[num136] == null)
                        {
                            Main.chest[num135].item[num136] = new Item();
                        }
                        Main.chest[num135].item[num136].SetDefaults(str13);
                        Main.chest[num135].item[num136].stack = num137;
                        return;
                    }
                    if (msgType == 0x21)
                    {
                        int num138 = BitConverter.ToInt16(this.readBuffer, startIndex);
                        startIndex += 2;
                        int num139 = BitConverter.ToInt32(this.readBuffer, startIndex);
                        startIndex += 4;
                        int num140 = BitConverter.ToInt32(this.readBuffer, startIndex);
                        if (Main.netMode == 1)
                        {
                            if (Main.player[Main.myPlayer].chest == -1)
                            {
                                Main.playerInventory = true;
                                Main.PlaySound(10, -1, -1, 1);
                            }
                            else if ((Main.player[Main.myPlayer].chest != num138) && (num138 != -1))
                            {
                                Main.playerInventory = true;
                                Main.PlaySound(12, -1, -1, 1);
                            }
                            else if ((Main.player[Main.myPlayer].chest != -1) && (num138 == -1))
                            {
                                Main.PlaySound(11, -1, -1, 1);
                            }
                            Main.player[Main.myPlayer].chest = num138;
                            Main.player[Main.myPlayer].chestX = num139;
                            Main.player[Main.myPlayer].chestY = num140;
                            return;
                        }
                        Main.player[this.whoAmI].chest = num138;
                        return;
                    }
                    if (msgType == 0x22)
                    {
                        if (Main.netMode == 2)
                        {
                            int num141 = BitConverter.ToInt32(this.readBuffer, startIndex);
                            startIndex += 4;
                            int num142 = BitConverter.ToInt32(this.readBuffer, startIndex);
                            if (Main.tile[num141, num142].type == 0x15)
                            {
                                WorldGen.KillTile(num141, num142, false, false, false);
                                if (!Main.tile[num141, num142].active)
                                {
                                    NetMessage.SendData(0x11, -1, -1, "", 0, (float) num141, (float) num142, 0f, 0);
                                    return;
                                }
                            }
                        }
                        return;
                    }
                    if (msgType == 0x23)
                    {
                        int num143 = this.readBuffer[startIndex];
                        if (Main.netMode == 2)
                        {
                            num143 = this.whoAmI;
                        }
                        startIndex++;
                        int healAmount = BitConverter.ToInt16(this.readBuffer, startIndex);
                        startIndex += 2;
                        if (num143 != Main.myPlayer)
                        {
                            Main.player[num143].HealEffect(healAmount);
                        }
                        if (Main.netMode == 2)
                        {
                            NetMessage.SendData(0x23, -1, this.whoAmI, "", num143, (float) healAmount, 0f, 0f, 0);
                            return;
                        }
                        return;
                    }
                    if (msgType == 0x24)
                    {
                        int num145 = this.readBuffer[startIndex];
                        if (Main.netMode == 2)
                        {
                            num145 = this.whoAmI;
                        }
                        startIndex++;
                        int num146 = this.readBuffer[startIndex];
                        startIndex++;
                        int num147 = this.readBuffer[startIndex];
                        startIndex++;
                        int num148 = this.readBuffer[startIndex];
                        startIndex++;
                        int num149 = this.readBuffer[startIndex];
                        startIndex++;
                        if (num146 == 0)
                        {
                            Main.player[num145].zoneEvil = false;
                        }
                        else
                        {
                            Main.player[num145].zoneEvil = true;
                        }
                        if (num147 == 0)
                        {
                            Main.player[num145].zoneMeteor = false;
                        }
                        else
                        {
                            Main.player[num145].zoneMeteor = true;
                        }
                        if (num148 == 0)
                        {
                            Main.player[num145].zoneDungeon = false;
                        }
                        else
                        {
                            Main.player[num145].zoneDungeon = true;
                        }
                        if (num149 == 0)
                        {
                            Main.player[num145].zoneJungle = false;
                        }
                        else
                        {
                            Main.player[num145].zoneJungle = true;
                        }
                        if (Main.netMode == 2)
                        {
                            NetMessage.SendData(0x24, -1, this.whoAmI, "", num145, 0f, 0f, 0f, 0);
                            return;
                        }
                        return;
                    }
                    if (msgType == 0x25)
                    {
                        if (Main.netMode == 1)
                        {
                            if (Main.autoPass)
                            {
                                NetMessage.SendData(0x26, -1, -1, Netplay.password, 0, 0f, 0f, 0f, 0);
                                Main.autoPass = false;
                                return;
                            }
                            Netplay.password = "";
                            Main.menuMode = 0x1f;
                            return;
                        }
                        return;
                    }
                    if (msgType == 0x26)
                    {
                        if (Main.netMode == 2)
                        {
                            if (Encoding.ASCII.GetString(this.readBuffer, startIndex, (length - startIndex) + start) == Netplay.password)
                            {
                                Netplay.serverSock[this.whoAmI].state = 1;
                                NetMessage.SendData(3, this.whoAmI, -1, "", 0, 0f, 0f, 0f, 0);
                                return;
                            }
                            NetMessage.SendData(2, this.whoAmI, -1, "Incorrect password.", 0, 0f, 0f, 0f, 0);
                            return;
                        }
                        return;
                    }
                    if ((msgType == 0x27) && (Main.netMode == 1))
                    {
                        short num150 = BitConverter.ToInt16(this.readBuffer, startIndex);
                        Main.item[num150].owner = 0xff;
                        NetMessage.SendData(0x16, -1, -1, "", num150, 0f, 0f, 0f, 0);
                        return;
                    }
                    if (msgType == 40)
                    {
                        byte num151 = this.readBuffer[startIndex];
                        if (Main.netMode == 2)
                        {
                            num151 = (byte) this.whoAmI;
                        }
                        startIndex++;
                        int num152 = BitConverter.ToInt16(this.readBuffer, startIndex);
                        startIndex += 2;
                        Main.player[num151].talkNPC = num152;
                        if (Main.netMode == 2)
                        {
                            NetMessage.SendData(40, -1, this.whoAmI, "", num151, 0f, 0f, 0f, 0);
                            return;
                        }
                        return;
                    }
                    if (msgType == 0x29)
                    {
                        byte num153 = this.readBuffer[startIndex];
                        if (Main.netMode == 2)
                        {
                            num153 = (byte) this.whoAmI;
                        }
                        startIndex++;
                        float num154 = BitConverter.ToSingle(this.readBuffer, startIndex);
                        startIndex += 4;
                        int num155 = BitConverter.ToInt16(this.readBuffer, startIndex);
                        Main.player[num153].itemRotation = num154;
                        Main.player[num153].itemAnimation = num155;
                        Main.player[num153].channel = Main.player[num153].inventory[Main.player[num153].selectedItem].channel;
                        if (Main.netMode == 2)
                        {
                            NetMessage.SendData(0x29, -1, this.whoAmI, "", num153, 0f, 0f, 0f, 0);
                            return;
                        }
                        return;
                    }
                    if (msgType == 0x2a)
                    {
                        int num156 = this.readBuffer[startIndex];
                        if (Main.netMode == 2)
                        {
                            num156 = this.whoAmI;
                        }
                        startIndex++;
                        int num157 = BitConverter.ToInt16(this.readBuffer, startIndex);
                        startIndex += 2;
                        int num158 = BitConverter.ToInt16(this.readBuffer, startIndex);
                        if (Main.netMode == 2)
                        {
                            num156 = this.whoAmI;
                        }
                        Main.player[num156].statMana = num157;
                        Main.player[num156].statManaMax = num158;
                        if (Main.netMode == 2)
                        {
                            NetMessage.SendData(0x2a, -1, this.whoAmI, "", num156, 0f, 0f, 0f, 0);
                            return;
                        }
                        return;
                    }
                    if (msgType == 0x2b)
                    {
                        int num159 = this.readBuffer[startIndex];
                        if (Main.netMode == 2)
                        {
                            num159 = this.whoAmI;
                        }
                        startIndex++;
                        int manaAmount = BitConverter.ToInt16(this.readBuffer, startIndex);
                        startIndex += 2;
                        if (num159 != Main.myPlayer)
                        {
                            Main.player[num159].ManaEffect(manaAmount);
                        }
                        if (Main.netMode == 2)
                        {
                            NetMessage.SendData(0x2b, -1, this.whoAmI, "", num159, (float) manaAmount, 0f, 0f, 0);
                            return;
                        }
                        return;
                    }
                    if (msgType == 0x2c)
                    {
                        byte num161 = this.readBuffer[startIndex];
                        if (num161 != Main.myPlayer)
                        {
                            if (Main.netMode == 2)
                            {
                                num161 = (byte) this.whoAmI;
                            }
                            startIndex++;
                            int num162 = this.readBuffer[startIndex] - 1;
                            startIndex++;
                            short num163 = BitConverter.ToInt16(this.readBuffer, startIndex);
                            startIndex += 2;
                            byte num164 = this.readBuffer[startIndex];
                            startIndex++;
                            string str15 = Encoding.ASCII.GetString(this.readBuffer, startIndex, (length - startIndex) + start);
                            bool flag10 = false;
                            if (num164 != 0)
                            {
                                flag10 = true;
                            }
                            Main.player[num161].KillMe((double) num163, num162, flag10, str15);
                            if (Main.netMode == 2)
                            {
                                NetMessage.SendData(0x2c, -1, this.whoAmI, str15, num161, (float) num162, (float) num163, (float) num164, 0);
                                return;
                            }
                        }
                        return;
                    }
                    if (msgType != 0x2d)
                    {
                        switch (msgType)
                        {
                            case 0x2e:
                                if (Main.netMode == 2)
                                {
                                    int num169 = BitConverter.ToInt32(this.readBuffer, startIndex);
                                    startIndex += 4;
                                    int num170 = BitConverter.ToInt32(this.readBuffer, startIndex);
                                    startIndex += 4;
                                    int num171 = Sign.ReadSign(num169, num170);
                                    if (num171 >= 0)
                                    {
                                        NetMessage.SendData(0x2f, this.whoAmI, -1, "", num171, 0f, 0f, 0f, 0);
                                        return;
                                    }
                                }
                                return;

                            case 0x2f:
                            {
                                int num172 = BitConverter.ToInt16(this.readBuffer, startIndex);
                                startIndex += 2;
                                int num173 = BitConverter.ToInt32(this.readBuffer, startIndex);
                                startIndex += 4;
                                int num174 = BitConverter.ToInt32(this.readBuffer, startIndex);
                                startIndex += 4;
                                string str17 = Encoding.ASCII.GetString(this.readBuffer, startIndex, (length - startIndex) + start);
                                Main.sign[num172] = new Sign();
                                Main.sign[num172].x = num173;
                                Main.sign[num172].y = num174;
                                Sign.TextSign(num172, str17);
                                if (((Main.netMode == 1) && (Main.sign[num172] != null)) && (num172 != Main.player[Main.myPlayer].sign))
                                {
                                    Main.playerInventory = false;
                                    Main.player[Main.myPlayer].talkNPC = -1;
                                    Main.editSign = false;
                                    Main.PlaySound(10, -1, -1, 1);
                                    Main.player[Main.myPlayer].sign = num172;
                                    Main.npcChatText = Main.sign[num172].text;
                                    return;
                                }
                                return;
                            }
                        }
                        if (msgType == 0x30)
                        {
                            int num175 = BitConverter.ToInt32(this.readBuffer, startIndex);
                            startIndex += 4;
                            int num176 = BitConverter.ToInt32(this.readBuffer, startIndex);
                            startIndex += 4;
                            byte num177 = this.readBuffer[startIndex];
                            startIndex++;
                            byte num178 = this.readBuffer[startIndex];
                            startIndex++;
                            if ((Main.netMode == 2) && Netplay.spamCheck)
                            {
                                int num179 = this.whoAmI;
                                int num180 = ((int) Main.player[num179].position.X) + (Main.player[num179].width / 2);
                                int num181 = ((int) Main.player[num179].position.Y) + (Main.player[num179].height / 2);
                                int num182 = 10;
                                int num183 = num180 - num182;
                                int num184 = num180 + num182;
                                int num185 = num181 - num182;
                                int num186 = num181 + num182;
                                if (((num180 < num183) || (num180 > num184)) || ((num181 < num185) || (num181 > num186)))
                                {
                                    NetMessage.BootPlayer(this.whoAmI, "Cheating attempt detected: Liquid spam");
                                    return;
                                }
                            }
                            if (Main.tile[num175, num176] == null)
                            {
                                Main.tile[num175, num176] = new Tile();
                            }
                            lock (Main.tile[num175, num176])
                            {
                                Main.tile[num175, num176].liquid = num177;
                                if (num178 == 1)
                                {
                                    Main.tile[num175, num176].lava = true;
                                }
                                else
                                {
                                    Main.tile[num175, num176].lava = false;
                                }
                                if (Main.netMode == 2)
                                {
                                    WorldGen.SquareTileFrame(num175, num176, true);
                                }
                                return;
                            }
                        }
                        if (msgType == 0x31)
                        {
                            if (Netplay.clientSock.state == 6)
                            {
                                Netplay.clientSock.state = 10;
                                Main.player[Main.myPlayer].Spawn();
                                return;
                            }
                        }
                        else
                        {
                            switch (msgType)
                            {
                                case 0x34:
                                {
                                    byte num191 = this.readBuffer[startIndex];
                                    startIndex++;
                                    byte num192 = this.readBuffer[startIndex];
                                    startIndex++;
                                    int num193 = BitConverter.ToInt32(this.readBuffer, startIndex);
                                    startIndex += 4;
                                    int num194 = BitConverter.ToInt32(this.readBuffer, startIndex);
                                    startIndex += 4;
                                    if (num192 == 1)
                                    {
                                        Chest.Unlock(num193, num194);
                                        if (Main.netMode == 2)
                                        {
                                            NetMessage.SendData(0x34, -1, this.whoAmI, "", num191, (float) num192, (float) num193, (float) num194, 0);
                                            NetMessage.SendTileSquare(-1, num193, num194, 2);
                                            return;
                                        }
                                    }
                                    return;
                                }
                                case 0x35:
                                {
                                    short num195 = BitConverter.ToInt16(this.readBuffer, startIndex);
                                    startIndex += 2;
                                    byte num196 = this.readBuffer[startIndex];
                                    startIndex++;
                                    short time = BitConverter.ToInt16(this.readBuffer, startIndex);
                                    startIndex += 2;
                                    Main.npc[num195].AddBuff(num196, time, true);
                                    if (Main.netMode == 2)
                                    {
                                        NetMessage.SendData(0x36, -1, -1, "", num195, 0f, 0f, 0f, 0);
                                        return;
                                    }
                                    return;
                                }
                                case 0x36:
                                    if (Main.netMode == 1)
                                    {
                                        short num198 = BitConverter.ToInt16(this.readBuffer, startIndex);
                                        startIndex += 2;
                                        for (int num199 = 0; num199 < 5; num199++)
                                        {
                                            Main.npc[num198].buffType[num199] = this.readBuffer[startIndex];
                                            startIndex++;
                                            Main.npc[num198].buffTime[num199] = BitConverter.ToInt16(this.readBuffer, startIndex);
                                            startIndex += 2;
                                        }
                                        return;
                                    }
                                    return;

                                case 0x33:
                                {
                                    byte num189 = this.readBuffer[startIndex];
                                    startIndex++;
                                    byte num190 = this.readBuffer[startIndex];
                                    switch (num190)
                                    {
                                        case 1:
                                            NPC.SpawnSkeletron();
                                            return;

                                        case 2:
                                            if (Main.netMode != 2)
                                            {
                                                Main.PlaySound(2, (int) Main.player[num189].position.X, (int) Main.player[num189].position.Y, 1);
                                                return;
                                            }
                                            if (Main.netMode == 2)
                                            {
                                                NetMessage.SendData(0x33, -1, this.whoAmI, "", num189, (float) num190, 0f, 0f, 0);
                                                return;
                                            }
                                            break;
                                    }
                                    return;
                                }
                                case 50:
                                {
                                    int num187 = this.readBuffer[startIndex];
                                    startIndex++;
                                    if (Main.netMode == 2)
                                    {
                                        num187 = this.whoAmI;
                                    }
                                    else if (num187 == Main.myPlayer)
                                    {
                                        return;
                                    }
                                    for (int num188 = 0; num188 < 10; num188++)
                                    {
                                        Main.player[num187].buffType[num188] = this.readBuffer[startIndex];
                                        if (Main.player[num187].buffType[num188] > 0)
                                        {
                                            Main.player[num187].buffTime[num188] = 60;
                                        }
                                        else
                                        {
                                            Main.player[num187].buffTime[num188] = 0;
                                        }
                                        startIndex++;
                                    }
                                    if (Main.netMode == 2)
                                    {
                                        NetMessage.SendData(50, -1, this.whoAmI, "", num187, 0f, 0f, 0f, 0);
                                        return;
                                    }
                                    return;
                                }
                            }
                            if (msgType == 0x37)
                            {
                                byte num200 = this.readBuffer[startIndex];
                                startIndex++;
                                byte num201 = this.readBuffer[startIndex];
                                startIndex++;
                                short num202 = BitConverter.ToInt16(this.readBuffer, startIndex);
                                startIndex += 2;
                                if ((Main.netMode == 1) && (num200 == Main.myPlayer))
                                {
                                    Main.player[num200].AddBuff(num201, num202, true);
                                    return;
                                }
                                if (Main.netMode == 2)
                                {
                                    NetMessage.SendData(0x37, num200, -1, "", num200, (float) num201, (float) num202, 0f, 0);
                                }
                            }
                        }
                        return;
                    }
                    num165 = this.readBuffer[startIndex];
                    if (Main.netMode == 2)
                    {
                        num165 = this.whoAmI;
                    }
                    startIndex++;
                    num166 = this.readBuffer[startIndex];
                    startIndex++;
                    team = Main.player[num165].team;
                    Main.player[num165].team = num166;
                    if (Main.netMode != 2)
                    {
                        return;
                    }
                    NetMessage.SendData(0x2d, -1, this.whoAmI, "", num165, 0f, 0f, 0f, 0);
                    str16 = "";
                    switch (num166)
                    {
                        case 0:
                            str16 = " is no longer on a party.";
                            goto Label_3ABD;

                        case 1:
                            str16 = " has joined the red party.";
                            goto Label_3ABD;

                        case 2:
                            str16 = " has joined the green party.";
                            goto Label_3ABD;

                        case 3:
                            str16 = " has joined the blue party.";
                            goto Label_3ABD;

                        case 4:
                            str16 = " has joined the yellow party.";
                            goto Label_3ABD;
                    }
                    goto Label_3ABD;
                }
                num62 = this.readBuffer[startIndex];
                startIndex++;
                num63 = BitConverter.ToInt32(this.readBuffer, startIndex);
                startIndex += 4;
                num64 = BitConverter.ToInt32(this.readBuffer, startIndex);
                startIndex += 4;
                num65 = this.readBuffer[startIndex];
                int direction = 0;
                if (num65 == 0)
                {
                    direction = -1;
                }
                switch (num62)
                {
                    case 0:
                        WorldGen.OpenDoor(num63, num64, direction);
                        goto Label_1C96;

                    case 1:
                        WorldGen.CloseDoor(num63, num64, true);
                        goto Label_1C96;
                }
            }
            else
            {
                byte num53 = this.readBuffer[startIndex];
                startIndex++;
                int num54 = BitConverter.ToInt32(this.readBuffer, startIndex);
                startIndex += 4;
                int num55 = BitConverter.ToInt32(this.readBuffer, startIndex);
                startIndex += 4;
                byte num56 = this.readBuffer[startIndex];
                startIndex++;
                int style = this.readBuffer[startIndex];
                bool fail = false;
                if (num56 == 1)
                {
                    fail = true;
                }
                if (Main.tile[num54, num55] == null)
                {
                    Main.tile[num54, num55] = new Tile();
                }
                if (Main.netMode == 2)
                {
                    if (!fail)
                    {
                        if (((num53 == 0) || (num53 == 2)) || (num53 == 4))
                        {
                            ServerSock sock2 = Netplay.serverSock[this.whoAmI];
                            sock2.spamDelBlock++;
                        }
                        else if ((num53 == 1) || (num53 == 3))
                        {
                            ServerSock sock3 = Netplay.serverSock[this.whoAmI];
                            sock3.spamAddBlock++;
                        }
                    }
                    if (!Netplay.serverSock[this.whoAmI].tileSection[Netplay.GetSectionX(num54), Netplay.GetSectionY(num55)])
                    {
                        fail = true;
                    }
                }
                switch (num53)
                {
                    case 0:
                        WorldGen.KillTile(num54, num55, fail, false, false);
                        break;

                    case 1:
                        WorldGen.PlaceTile(num54, num55, num56, false, true, -1, style);
                        break;

                    case 2:
                        WorldGen.KillWall(num54, num55, fail);
                        break;

                    case 3:
                        WorldGen.PlaceWall(num54, num55, num56, false);
                        break;

                    case 4:
                        WorldGen.KillTile(num54, num55, fail, false, true);
                        break;
                }
                if (Main.netMode == 2)
                {
                    NetMessage.SendData(0x11, -1, this.whoAmI, "", num53, (float) num54, (float) num55, (float) num56, style);
                    if ((num53 != 1) || (num56 != 0x35))
                    {
                        return;
                    }
                    NetMessage.SendTileSquare(-1, num54, num55, 1);
                }
                return;
            }
        Label_1C96:
            if (Main.netMode == 2)
            {
                NetMessage.SendData(0x13, -1, this.whoAmI, "", num62, (float) num63, (float) num64, (float) num65, 0);
            }
            return;
        Label_3ABD:
            num168 = 0;
            while (num168 < 0xff)
            {
                if (((num168 == this.whoAmI) || ((team > 0) && (Main.player[num168].team == team))) || ((num166 > 0) && (Main.player[num168].team == num166)))
                {
                    NetMessage.SendData(0x19, num168, -1, Main.player[num165].name + str16, 0xff, (float) Main.teamColor[num166].R, (float) Main.teamColor[num166].G, (float) Main.teamColor[num166].B, 0);
                }
                num168++;
            }
        }

        public void Reset()
        {
            this.writeBuffer = new byte[0xffff];
            this.writeLocked = false;
            this.messageLength = 0;
            this.totalData = 0;
            this.spamCount = 0;
            this.broadcast = false;
            this.checkBytes = false;
        }
    }
}

