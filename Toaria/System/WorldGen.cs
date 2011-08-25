namespace Toaria
{
    using Microsoft.Xna.Framework;
    using System;
    using System.Diagnostics;
    using System.IO;
    using System.Runtime.InteropServices;
    using System.Threading;
    using TerrariaAPI.Hooks;
    using System.IO.Compression;

    public class WorldGen
    {
        public static int bestX = 0;
        public static int bestY = 0;
        public static bool canSpawn;
        private static int[] DDoorPos = new int[300];
        private static int[] DDoorX = new int[300];
        private static int[] DDoorY = new int[300];
        public static int dEnteranceX = 0;
        private static bool destroyObject = false;
        private static int dMaxX;
        private static int dMaxY;
        private static int dMinX;
        private static int dMinY;
        private static int[] DPlatX = new int[300];
        private static int[] DPlatY = new int[300];
        public static int maxDRooms = 100;
        private static int[] dRoomB = new int[maxDRooms];
        private static int[] dRoomL = new int[maxDRooms];
        private static int[] dRoomR = new int[maxDRooms];
        public static int[] dRoomSize = new int[maxDRooms];
        private static int[] dRoomT = new int[maxDRooms];
        private static bool[] dRoomTreasure = new bool[maxDRooms];
        public static int[] dRoomX = new int[maxDRooms];
        public static int[] dRoomY = new int[maxDRooms];
        public static bool dSurface = false;
        public static int dungeonX;
        public static int dungeonY;
        private static double dxStrength1;
        private static double dxStrength2;
        private static double dyStrength1;
        private static double dyStrength2;
        private static int[] fihX = new int[300];
        private static int[] fihY = new int[300];
        public static bool gen = false;
        [ThreadStatic]
        public static Random genRand = new Random();
        private static int hellChest = 0;
        public static int hiScore = 0;
        private static int houseCount = 0;
        public static bool[] houseTile = new bool[0x6b];
        private static int[] JChestX = new int[100];
        private static int[] JChestY = new int[100];
        private static int JungleX = 0;
        public static Vector2 lastDungeonHall = new Vector2();
        private static int lastMaxTilesX = 0;
        private static int lastMaxTilesY = 0;
        public static int lavaLine;
        public static bool loadBackup = false;
        public static bool loadFailed = false;
        public static bool loadSuccess = false;
        public static int maxRoomTiles = 0x76c;
        private static int[] mCaveX = new int[300];
        private static int[] mCaveY = new int[300];
        private static bool mergeDown = false;
        private static bool mergeLeft = false;
        private static bool mergeRight = false;
        private static bool mergeUp = false;
        private static bool mudWall = false;
        public static bool noLiquidCheck = false;
        public static bool noTileActions = false;
        private static int numDDoors;
        private static int numDPlats;
        public static int numDRooms = 0;
        private static int numIslandHouses = 0;
        private static int numJChests = 0;
        private static int numMCaves = 0;
        public static int numRoomTiles;
        private static object padlock = new object();
        public static int[] roomX = new int[maxRoomTiles];
        public static int roomX1;
        public static int roomX2;
        public static int[] roomY = new int[maxRoomTiles];
        public static int roomY1;
        public static int roomY2;
        public static bool saveLock = false;
        public static int shadowOrbCount = 0;
        public static bool shadowOrbSmashed = false;
        public static int spawnDelay = 0;
        public static bool spawnEye = false;
        public static bool spawnMeteor = false;
        public static int spawnNPC = 0;
        public static string statusText = "";
        private static bool stopDrops = false;
        private static bool tempBloodMoon = Main.bloodMoon;
        private static bool tempDayTime = Main.dayTime;
        private static int tempMoonPhase = Main.moonPhase;
        private static double tempTime = Main.time;
        public static int waterLine;
        public static bool worldBackup = false;
        public static bool worldCleared = false;

        public static bool AddBuriedChest(int i, int j, int contain = 0, bool notNearOtherChests = false, int Style = -1)
        {
            if (genRand == null)
            {
                genRand = new Random((int) DateTime.Now.Ticks);
            }
            for (int k = j; k < Main.maxTilesY; k++)
            {
                if (!Main.tile[i, k].active || !Main.tileSolid[Main.tile[i, k].type])
                {
                    continue;
                }
                bool flag = false;
                int num2 = i;
                int num3 = k;
                int index = -1;
                int style = 0;
                if ((num3 >= (Main.worldSurface + 25.0)) || (contain > 0))
                {
                    style = 1;
                }
                if (Style >= 0)
                {
                    style = Style;
                }
                if ((num3 > (Main.maxTilesY - 0xcd)) && (contain == 0))
                {
                    if (hellChest == 0)
                    {
                        contain = 0x112;
                        style = 4;
                        flag = true;
                    }
                    else if (hellChest == 1)
                    {
                        contain = 220;
                        style = 4;
                        flag = true;
                    }
                    else if (hellChest == 2)
                    {
                        contain = 0x70;
                        style = 4;
                        flag = true;
                    }
                    else if (hellChest == 3)
                    {
                        contain = 0xda;
                        style = 4;
                        flag = true;
                        hellChest = 0;
                    }
                }
                index = PlaceChest(num2 - 1, num3 - 1, 0x15, notNearOtherChests, style);
                if (index < 0)
                {
                    return false;
                }
                if (flag)
                {
                    hellChest++;
                }
                int num6 = 0;
                while (num6 == 0)
                {
                    if (num3 < (Main.worldSurface + 25.0))
                    {
                        if (contain > 0)
                        {
                            Main.chest[index].item[num6].SetDefaults(contain, false);
                            num6++;
                        }
                        else
                        {
                            switch (genRand.Next(6))
                            {
                                case 0:
                                    Main.chest[index].item[num6].SetDefaults(280, false);
                                    break;

                                case 1:
                                    Main.chest[index].item[num6].SetDefaults(0x119, false);
                                    break;

                                case 2:
                                    Main.chest[index].item[num6].SetDefaults(0x11c, false);
                                    break;

                                case 3:
                                    Main.chest[index].item[num6].SetDefaults(0x11a, false);
                                    Main.chest[index].item[num6].stack = genRand.Next(50, 0x4b);
                                    break;

                                case 4:
                                    Main.chest[index].item[num6].SetDefaults(0x117, false);
                                    Main.chest[index].item[num6].stack = genRand.Next(0x19, 50);
                                    break;

                                case 5:
                                    Main.chest[index].item[num6].SetDefaults(0x11d, false);
                                    break;
                            }
                            num6++;
                        }
                        if (genRand.Next(3) == 0)
                        {
                            Main.chest[index].item[num6].SetDefaults(0xa8, false);
                            Main.chest[index].item[num6].stack = genRand.Next(3, 6);
                            num6++;
                        }
                        if (genRand.Next(2) == 0)
                        {
                            int num8 = genRand.Next(2);
                            int num9 = genRand.Next(8) + 3;
                            switch (num8)
                            {
                                case 0:
                                    Main.chest[index].item[num6].SetDefaults(20, false);
                                    break;

                                case 1:
                                    Main.chest[index].item[num6].SetDefaults(0x16, false);
                                    break;
                            }
                            Main.chest[index].item[num6].stack = num9;
                            num6++;
                        }
                        if (genRand.Next(2) == 0)
                        {
                            int num10 = genRand.Next(2);
                            int num11 = genRand.Next(0x1a) + 0x19;
                            switch (num10)
                            {
                                case 0:
                                    Main.chest[index].item[num6].SetDefaults(40, false);
                                    break;

                                case 1:
                                    Main.chest[index].item[num6].SetDefaults(0x2a, false);
                                    break;
                            }
                            Main.chest[index].item[num6].stack = num11;
                            num6++;
                        }
                        if (genRand.Next(2) == 0)
                        {
                            int num12 = genRand.Next(1);
                            int num13 = genRand.Next(3) + 3;
                            if (num12 == 0)
                            {
                                Main.chest[index].item[num6].SetDefaults(0x1c, false);
                            }
                            Main.chest[index].item[num6].stack = num13;
                            num6++;
                        }
                        if (genRand.Next(3) > 0)
                        {
                            int num14 = genRand.Next(4);
                            int num15 = genRand.Next(1, 3);
                            switch (num14)
                            {
                                case 0:
                                    Main.chest[index].item[num6].SetDefaults(0x124, false);
                                    break;

                                case 1:
                                    Main.chest[index].item[num6].SetDefaults(0x12a, false);
                                    break;

                                case 2:
                                    Main.chest[index].item[num6].SetDefaults(0x12b, false);
                                    break;

                                case 3:
                                    Main.chest[index].item[num6].SetDefaults(290, false);
                                    break;
                            }
                            Main.chest[index].item[num6].stack = num15;
                            num6++;
                        }
                        if (genRand.Next(2) == 0)
                        {
                            int num16 = genRand.Next(2);
                            int num17 = genRand.Next(11) + 10;
                            switch (num16)
                            {
                                case 0:
                                    Main.chest[index].item[num6].SetDefaults(8, false);
                                    break;

                                case 1:
                                    Main.chest[index].item[num6].SetDefaults(0x1f, false);
                                    break;
                            }
                            Main.chest[index].item[num6].stack = num17;
                            num6++;
                        }
                        if (genRand.Next(2) == 0)
                        {
                            Main.chest[index].item[num6].SetDefaults(0x48, false);
                            Main.chest[index].item[num6].stack = genRand.Next(10, 30);
                            num6++;
                        }
                    }
                    else
                    {
                        if (num3 < Main.rockLayer)
                        {
                            if (contain > 0)
                            {
                                Main.chest[index].item[num6].SetDefaults(contain, false);
                                num6++;
                            }
                            else
                            {
                                switch (genRand.Next(7))
                                {
                                    case 0:
                                        Main.chest[index].item[num6].SetDefaults(0x31, false);
                                        break;

                                    case 1:
                                        Main.chest[index].item[num6].SetDefaults(50, false);
                                        break;

                                    case 2:
                                        Main.chest[index].item[num6].SetDefaults(0x34, false);
                                        break;

                                    case 3:
                                        Main.chest[index].item[num6].SetDefaults(0x35, false);
                                        break;

                                    case 4:
                                        Main.chest[index].item[num6].SetDefaults(0x36, false);
                                        break;

                                    case 5:
                                        Main.chest[index].item[num6].SetDefaults(0x37, false);
                                        break;

                                    case 6:
                                        Main.chest[index].item[num6].SetDefaults(0x33, false);
                                        Main.chest[index].item[num6].stack = genRand.Next(0x1a) + 0x19;
                                        break;
                                }
                                num6++;
                            }
                            if (genRand.Next(3) == 0)
                            {
                                Main.chest[index].item[num6].SetDefaults(0xa6, false);
                                Main.chest[index].item[num6].stack = genRand.Next(10, 20);
                                num6++;
                            }
                            if (genRand.Next(2) == 0)
                            {
                                int num19 = genRand.Next(2);
                                int num20 = genRand.Next(10) + 5;
                                switch (num19)
                                {
                                    case 0:
                                        Main.chest[index].item[num6].SetDefaults(0x16, false);
                                        break;

                                    case 1:
                                        Main.chest[index].item[num6].SetDefaults(0x15, false);
                                        break;
                                }
                                Main.chest[index].item[num6].stack = num20;
                                num6++;
                            }
                            if (genRand.Next(2) == 0)
                            {
                                int num21 = genRand.Next(2);
                                int num22 = genRand.Next(0x19) + 0x19;
                                switch (num21)
                                {
                                    case 0:
                                        Main.chest[index].item[num6].SetDefaults(40, false);
                                        break;

                                    case 1:
                                        Main.chest[index].item[num6].SetDefaults(0x2a, false);
                                        break;
                                }
                                Main.chest[index].item[num6].stack = num22;
                                num6++;
                            }
                            if (genRand.Next(2) == 0)
                            {
                                int num23 = genRand.Next(1);
                                int num24 = genRand.Next(3) + 3;
                                if (num23 == 0)
                                {
                                    Main.chest[index].item[num6].SetDefaults(0x1c, false);
                                }
                                Main.chest[index].item[num6].stack = num24;
                                num6++;
                            }
                            if (genRand.Next(3) > 0)
                            {
                                int num25 = genRand.Next(7);
                                int num26 = genRand.Next(1, 3);
                                switch (num25)
                                {
                                    case 0:
                                        Main.chest[index].item[num6].SetDefaults(0x121, false);
                                        break;

                                    case 1:
                                        Main.chest[index].item[num6].SetDefaults(0x12a, false);
                                        break;

                                    case 2:
                                        Main.chest[index].item[num6].SetDefaults(0x12b, false);
                                        break;

                                    case 3:
                                        Main.chest[index].item[num6].SetDefaults(290, false);
                                        break;

                                    case 4:
                                        Main.chest[index].item[num6].SetDefaults(0x12f, false);
                                        break;

                                    case 5:
                                        Main.chest[index].item[num6].SetDefaults(0x123, false);
                                        break;

                                    case 6:
                                        Main.chest[index].item[num6].SetDefaults(0x130, false);
                                        break;
                                }
                                Main.chest[index].item[num6].stack = num26;
                                num6++;
                            }
                            if (genRand.Next(2) == 0)
                            {
                                int num27 = genRand.Next(11) + 10;
                                Main.chest[index].item[num6].SetDefaults(8, false);
                                Main.chest[index].item[num6].stack = num27;
                                num6++;
                            }
                            if (genRand.Next(2) == 0)
                            {
                                Main.chest[index].item[num6].SetDefaults(0x48, false);
                                Main.chest[index].item[num6].stack = genRand.Next(50, 90);
                                num6++;
                            }
                            continue;
                        }
                        if (num3 < (Main.maxTilesY - 250))
                        {
                            if (contain > 0)
                            {
                                Main.chest[index].item[num6].SetDefaults(contain, false);
                                num6++;
                            }
                            else
                            {
                                int num28 = genRand.Next(7);
                                if ((num28 == 2) && (genRand.Next(2) == 0))
                                {
                                    num28 = genRand.Next(7);
                                }
                                if (num28 == 0)
                                {
                                    Main.chest[index].item[num6].SetDefaults(0x31, false);
                                }
                                if (num28 == 1)
                                {
                                    Main.chest[index].item[num6].SetDefaults(50, false);
                                }
                                if (num28 == 2)
                                {
                                    Main.chest[index].item[num6].SetDefaults(0x34, false);
                                }
                                if (num28 == 3)
                                {
                                    Main.chest[index].item[num6].SetDefaults(0x35, false);
                                }
                                if (num28 == 4)
                                {
                                    Main.chest[index].item[num6].SetDefaults(0x36, false);
                                }
                                if (num28 == 5)
                                {
                                    Main.chest[index].item[num6].SetDefaults(0x37, false);
                                }
                                if (num28 == 6)
                                {
                                    Main.chest[index].item[num6].SetDefaults(0x33, false);
                                    Main.chest[index].item[num6].stack = genRand.Next(0x1a) + 0x19;
                                }
                                num6++;
                            }
                            if (genRand.Next(5) == 0)
                            {
                                Main.chest[index].item[num6].SetDefaults(0x2b, false);
                                num6++;
                            }
                            if (genRand.Next(3) == 0)
                            {
                                Main.chest[index].item[num6].SetDefaults(0xa7, false);
                                num6++;
                            }
                            if (genRand.Next(2) == 0)
                            {
                                int num29 = genRand.Next(2);
                                int num30 = genRand.Next(8) + 3;
                                switch (num29)
                                {
                                    case 0:
                                        Main.chest[index].item[num6].SetDefaults(0x13, false);
                                        break;

                                    case 1:
                                        Main.chest[index].item[num6].SetDefaults(0x15, false);
                                        break;
                                }
                                Main.chest[index].item[num6].stack = num30;
                                num6++;
                            }
                            if (genRand.Next(2) == 0)
                            {
                                int num31 = genRand.Next(2);
                                int num32 = genRand.Next(0x1a) + 0x19;
                                switch (num31)
                                {
                                    case 0:
                                        Main.chest[index].item[num6].SetDefaults(0x29, false);
                                        break;

                                    case 1:
                                        Main.chest[index].item[num6].SetDefaults(0x117, false);
                                        break;
                                }
                                Main.chest[index].item[num6].stack = num32;
                                num6++;
                            }
                            if (genRand.Next(2) == 0)
                            {
                                int num33 = genRand.Next(1);
                                int num34 = genRand.Next(3) + 3;
                                if (num33 == 0)
                                {
                                    Main.chest[index].item[num6].SetDefaults(0xbc, false);
                                }
                                Main.chest[index].item[num6].stack = num34;
                                num6++;
                            }
                            if (genRand.Next(3) > 0)
                            {
                                int num35 = genRand.Next(6);
                                int num36 = genRand.Next(1, 3);
                                switch (num35)
                                {
                                    case 0:
                                        Main.chest[index].item[num6].SetDefaults(0x128, false);
                                        break;

                                    case 1:
                                        Main.chest[index].item[num6].SetDefaults(0x127, false);
                                        break;

                                    case 2:
                                        Main.chest[index].item[num6].SetDefaults(0x12b, false);
                                        break;

                                    case 3:
                                        Main.chest[index].item[num6].SetDefaults(0x12e, false);
                                        break;

                                    case 4:
                                        Main.chest[index].item[num6].SetDefaults(0x12f, false);
                                        break;

                                    case 5:
                                        Main.chest[index].item[num6].SetDefaults(0x131, false);
                                        break;
                                }
                                Main.chest[index].item[num6].stack = num36;
                                num6++;
                            }
                            if (genRand.Next(3) > 1)
                            {
                                int num37 = genRand.Next(4);
                                int num38 = genRand.Next(1, 3);
                                switch (num37)
                                {
                                    case 0:
                                        Main.chest[index].item[num6].SetDefaults(0x12d, false);
                                        break;

                                    case 1:
                                        Main.chest[index].item[num6].SetDefaults(0x12e, false);
                                        break;

                                    case 2:
                                        Main.chest[index].item[num6].SetDefaults(0x129, false);
                                        break;

                                    case 3:
                                        Main.chest[index].item[num6].SetDefaults(0x130, false);
                                        break;
                                }
                                Main.chest[index].item[num6].stack = num38;
                                num6++;
                            }
                            if (genRand.Next(2) == 0)
                            {
                                int num39 = genRand.Next(2);
                                int num40 = genRand.Next(15) + 15;
                                switch (num39)
                                {
                                    case 0:
                                        Main.chest[index].item[num6].SetDefaults(8, false);
                                        break;

                                    case 1:
                                        Main.chest[index].item[num6].SetDefaults(0x11a, false);
                                        break;
                                }
                                Main.chest[index].item[num6].stack = num40;
                                num6++;
                            }
                            if (genRand.Next(2) == 0)
                            {
                                Main.chest[index].item[num6].SetDefaults(0x49, false);
                                Main.chest[index].item[num6].stack = genRand.Next(1, 3);
                                num6++;
                            }
                            continue;
                        }
                        if (contain > 0)
                        {
                            Main.chest[index].item[num6].SetDefaults(contain, false);
                            num6++;
                        }
                        else
                        {
                            switch (genRand.Next(4))
                            {
                                case 0:
                                    Main.chest[index].item[num6].SetDefaults(0x31, false);
                                    break;

                                case 1:
                                    Main.chest[index].item[num6].SetDefaults(50, false);
                                    break;

                                case 2:
                                    Main.chest[index].item[num6].SetDefaults(0x35, false);
                                    break;

                                case 3:
                                    Main.chest[index].item[num6].SetDefaults(0x36, false);
                                    break;
                            }
                            num6++;
                        }
                        if (genRand.Next(3) == 0)
                        {
                            Main.chest[index].item[num6].SetDefaults(0xa7, false);
                            num6++;
                        }
                        if (genRand.Next(2) == 0)
                        {
                            int num42 = genRand.Next(2);
                            int num43 = genRand.Next(15) + 15;
                            switch (num42)
                            {
                                case 0:
                                    Main.chest[index].item[num6].SetDefaults(0x75, false);
                                    break;

                                case 1:
                                    Main.chest[index].item[num6].SetDefaults(0x13, false);
                                    break;
                            }
                            Main.chest[index].item[num6].stack = num43;
                            num6++;
                        }
                        if (genRand.Next(2) == 0)
                        {
                            int num44 = genRand.Next(2);
                            int num45 = genRand.Next(0x19) + 50;
                            switch (num44)
                            {
                                case 0:
                                    Main.chest[index].item[num6].SetDefaults(0x109, false);
                                    break;

                                case 1:
                                    Main.chest[index].item[num6].SetDefaults(0x116, false);
                                    break;
                            }
                            Main.chest[index].item[num6].stack = num45;
                            num6++;
                        }
                        if (genRand.Next(2) == 0)
                        {
                            int num46 = genRand.Next(2);
                            int num47 = genRand.Next(15) + 15;
                            switch (num46)
                            {
                                case 0:
                                    Main.chest[index].item[num6].SetDefaults(0xe2, false);
                                    break;

                                case 1:
                                    Main.chest[index].item[num6].SetDefaults(0xe3, false);
                                    break;
                            }
                            Main.chest[index].item[num6].stack = num47;
                            num6++;
                        }
                        if (genRand.Next(4) > 0)
                        {
                            int num48 = genRand.Next(7);
                            int num49 = genRand.Next(1, 3);
                            switch (num48)
                            {
                                case 0:
                                    Main.chest[index].item[num6].SetDefaults(0x128, false);
                                    break;

                                case 1:
                                    Main.chest[index].item[num6].SetDefaults(0x127, false);
                                    break;

                                case 2:
                                    Main.chest[index].item[num6].SetDefaults(0x125, false);
                                    break;

                                case 3:
                                    Main.chest[index].item[num6].SetDefaults(0x120, false);
                                    break;

                                case 4:
                                    Main.chest[index].item[num6].SetDefaults(0x126, false);
                                    break;

                                case 5:
                                    Main.chest[index].item[num6].SetDefaults(0x129, false);
                                    break;

                                case 6:
                                    Main.chest[index].item[num6].SetDefaults(0x130, false);
                                    break;
                            }
                            Main.chest[index].item[num6].stack = num49;
                            num6++;
                        }
                        if (genRand.Next(3) > 0)
                        {
                            int num50 = genRand.Next(5);
                            int num51 = genRand.Next(1, 3);
                            switch (num50)
                            {
                                case 0:
                                    Main.chest[index].item[num6].SetDefaults(0x131, false);
                                    break;

                                case 1:
                                    Main.chest[index].item[num6].SetDefaults(0x12d, false);
                                    break;

                                case 2:
                                    Main.chest[index].item[num6].SetDefaults(0x12e, false);
                                    break;

                                case 3:
                                    Main.chest[index].item[num6].SetDefaults(0x120, false);
                                    break;

                                case 4:
                                    Main.chest[index].item[num6].SetDefaults(300, false);
                                    break;
                            }
                            Main.chest[index].item[num6].stack = num51;
                            num6++;
                        }
                        if (genRand.Next(2) == 0)
                        {
                            int num52 = genRand.Next(2);
                            int num53 = genRand.Next(15) + 15;
                            switch (num52)
                            {
                                case 0:
                                    Main.chest[index].item[num6].SetDefaults(8, false);
                                    break;

                                case 1:
                                    Main.chest[index].item[num6].SetDefaults(0x11a, false);
                                    break;
                            }
                            Main.chest[index].item[num6].stack = num53;
                            num6++;
                        }
                        if (genRand.Next(2) == 0)
                        {
                            Main.chest[index].item[num6].SetDefaults(0x49, false);
                            Main.chest[index].item[num6].stack = genRand.Next(2, 5);
                            num6++;
                        }
                    }
                }
                return true;
            }
            return false;
        }

        public static void AddHellHouses()
        {
            int num = (int) (Main.maxTilesX * 0.25);
            for (int i = num; i < (Main.maxTilesX - num); i++)
            {
                int j = Main.maxTilesY - 40;
                while (Main.tile[i, j].active || (Main.tile[i, j].liquid > 0))
                {
                    j--;
                }
                if (Main.tile[i, j + 1].active)
                {
                    byte type = (byte) genRand.Next(0x4b, 0x4d);
                    byte wall = 13;
                    if (genRand.Next(5) > 0)
                    {
                        type = 0x4b;
                    }
                    if (type == 0x4b)
                    {
                        wall = 14;
                    }
                    HellHouse(i, j, type, wall);
                    i += genRand.Next(15, 80);
                }
            }
        }

        public static bool AddLifeCrystal(int i, int j)
        {
            for (int k = j; k < Main.maxTilesY; k++)
            {
                if (Main.tile[i, k].active && Main.tileSolid[Main.tile[i, k].type])
                {
                    int endX = i;
                    int endY = k - 1;
                    if (Main.tile[endX, endY - 1].lava || Main.tile[endX - 1, endY - 1].lava)
                    {
                        return false;
                    }
                    if (!EmptyTileCheck(endX - 1, endX, endY - 1, endY, -1))
                    {
                        return false;
                    }
                    Main.tile[endX - 1, endY - 1].active = true;
                    Main.tile[endX - 1, endY - 1].type = 12;
                    Main.tile[endX - 1, endY - 1].frameX = 0;
                    Main.tile[endX - 1, endY - 1].frameY = 0;
                    Main.tile[endX, endY - 1].active = true;
                    Main.tile[endX, endY - 1].type = 12;
                    Main.tile[endX, endY - 1].frameX = 0x12;
                    Main.tile[endX, endY - 1].frameY = 0;
                    Main.tile[endX - 1, endY].active = true;
                    Main.tile[endX - 1, endY].type = 12;
                    Main.tile[endX - 1, endY].frameX = 0;
                    Main.tile[endX - 1, endY].frameY = 0x12;
                    Main.tile[endX, endY].active = true;
                    Main.tile[endX, endY].type = 12;
                    Main.tile[endX, endY].frameX = 0x12;
                    Main.tile[endX, endY].frameY = 0x12;
                    return true;
                }
            }
            return false;
        }

        public static void AddPlants()
        {
            for (int i = 0; i < Main.maxTilesX; i++)
            {
                for (int j = 1; j < Main.maxTilesY; j++)
                {
                    if ((Main.tile[i, j].type == 2) && Main.tile[i, j].active)
                    {
                        if (!Main.tile[i, j - 1].active)
                        {
                            PlaceTile(i, j - 1, 3, true, false, -1, 0);
                        }
                    }
                    else if (((Main.tile[i, j].type == 0x17) && Main.tile[i, j].active) && !Main.tile[i, j - 1].active)
                    {
                        PlaceTile(i, j - 1, 0x18, true, false, -1, 0);
                    }
                }
            }
        }

        public static void AddShadowOrb(int x, int y)
        {
            if (((x >= 10) && (x <= (Main.maxTilesX - 10))) && ((y >= 10) && (y <= (Main.maxTilesY - 10))))
            {
                for (int i = x - 1; i < (x + 1); i++)
                {
                    for (int j = y - 1; j < (y + 1); j++)
                    {
                        if (Main.tile[i, j].active && (Main.tile[i, j].type == 0x1f))
                        {
                            return;
                        }
                    }
                }
                Main.tile[x - 1, y - 1].active = true;
                Main.tile[x - 1, y - 1].type = 0x1f;
                Main.tile[x - 1, y - 1].frameX = 0;
                Main.tile[x - 1, y - 1].frameY = 0;
                Main.tile[x, y - 1].active = true;
                Main.tile[x, y - 1].type = 0x1f;
                Main.tile[x, y - 1].frameX = 0x12;
                Main.tile[x, y - 1].frameY = 0;
                Main.tile[x - 1, y].active = true;
                Main.tile[x - 1, y].type = 0x1f;
                Main.tile[x - 1, y].frameX = 0;
                Main.tile[x - 1, y].frameY = 0x12;
                Main.tile[x, y].active = true;
                Main.tile[x, y].type = 0x1f;
                Main.tile[x, y].frameX = 0x12;
                Main.tile[x, y].frameY = 0x12;
            }
        }

        public static void AddTrees()
        {
            for (int i = 1; i < (Main.maxTilesX - 1); i++)
            {
                for (int j = 20; j < Main.worldSurface; j++)
                {
                    GrowTree(i, j);
                }
            }
        }

        public static void CactusFrame(int i, int j)
        {
            try
            {
                int num = j;
                int num2 = i;
                if (!CheckCactus(i, j))
                {
                    goto Label_010C;
                }
                return;
            Label_0015:
                num++;
                if (!Main.tile[num2, num].active || (Main.tile[num2, num].type != 80))
                {
                    if (((Main.tile[num2 - 1, num].active && (Main.tile[num2 - 1, num].type == 80)) && (Main.tile[num2 - 1, num - 1].active && (Main.tile[num2 - 1, num - 1].type == 80))) && (num2 >= i))
                    {
                        num2--;
                    }
                    if (((Main.tile[num2 + 1, num].active && (Main.tile[num2 + 1, num].type == 80)) && (Main.tile[num2 + 1, num - 1].active && (Main.tile[num2 + 1, num - 1].type == 80))) && (num2 <= i))
                    {
                        num2++;
                    }
                }
            Label_010C:
                if (Main.tile[num2, num].active && (Main.tile[num2, num].type == 80))
                {
                    goto Label_0015;
                }
                num--;
                int num3 = i - num2;
                num2 = i;
                num = j;
                int type = Main.tile[i - 2, j].type;
                int num5 = Main.tile[i - 1, j].type;
                int num6 = Main.tile[i + 1, j].type;
                int num7 = Main.tile[i, j - 1].type;
                int index = Main.tile[i, j + 1].type;
                int num9 = Main.tile[i - 1, j + 1].type;
                int num10 = Main.tile[i + 1, j + 1].type;
                if (!Main.tile[i - 1, j].active)
                {
                    num5 = -1;
                }
                if (!Main.tile[i + 1, j].active)
                {
                    num6 = -1;
                }
                if (!Main.tile[i, j - 1].active)
                {
                    num7 = -1;
                }
                if (!Main.tile[i, j + 1].active)
                {
                    index = -1;
                }
                if (!Main.tile[i - 1, j + 1].active)
                {
                    num9 = -1;
                }
                if (!Main.tile[i + 1, j + 1].active)
                {
                    num10 = -1;
                }
                short frameX = Main.tile[i, j].frameX;
                short frameY = Main.tile[i, j].frameY;
                switch (num3)
                {
                    case 0:
                        if (num7 == 80)
                        {
                            if ((((num5 == 80) && (num6 == 80)) && ((num9 != 80) && (num10 != 80))) && (type != 80))
                            {
                                frameX = 90;
                                frameY = 0x24;
                            }
                            else if (((num5 == 80) && (num9 != 80)) && (type != 80))
                            {
                                frameX = 0x48;
                                frameY = 0x24;
                            }
                            else if ((num6 == 80) && (num10 != 80))
                            {
                                frameX = 0x12;
                                frameY = 0x24;
                            }
                            else if ((index >= 0) && Main.tileSolid[index])
                            {
                                frameX = 0;
                                frameY = 0x24;
                            }
                            else
                            {
                                frameX = 0;
                                frameY = 0x12;
                            }
                        }
                        else if ((((num5 == 80) && (num6 == 80)) && ((num9 != 80) && (num10 != 80))) && (type != 80))
                        {
                            frameX = 90;
                            frameY = 0;
                        }
                        else if (((num5 == 80) && (num9 != 80)) && (type != 80))
                        {
                            frameX = 0x48;
                            frameY = 0;
                        }
                        else if ((num6 == 80) && (num10 != 80))
                        {
                            frameX = 0x12;
                            frameY = 0;
                        }
                        else
                        {
                            frameX = 0;
                            frameY = 0;
                        }
                        break;

                    case -1:
                        if (num6 == 80)
                        {
                            if ((num7 != 80) && (index != 80))
                            {
                                frameX = 0x6c;
                                frameY = 0x24;
                            }
                            else if (index != 80)
                            {
                                frameX = 0x36;
                                frameY = 0x24;
                            }
                            else if (num7 != 80)
                            {
                                frameX = 0x36;
                                frameY = 0;
                            }
                            else
                            {
                                frameX = 0x36;
                                frameY = 0x12;
                            }
                        }
                        else if (num7 != 80)
                        {
                            frameX = 0x36;
                            frameY = 0;
                        }
                        else
                        {
                            frameX = 0x36;
                            frameY = 0x12;
                        }
                        break;

                    case 1:
                        if (num5 == 80)
                        {
                            if ((num7 != 80) && (index != 80))
                            {
                                frameX = 0x6c;
                                frameY = 0x10;
                            }
                            else if (index != 80)
                            {
                                frameX = 0x24;
                                frameY = 0x24;
                            }
                            else if (num7 != 80)
                            {
                                frameX = 0x24;
                                frameY = 0;
                            }
                            else
                            {
                                frameX = 0x24;
                                frameY = 0x12;
                            }
                        }
                        else if (num7 != 80)
                        {
                            frameX = 0x24;
                            frameY = 0;
                        }
                        else
                        {
                            frameX = 0x24;
                            frameY = 0x12;
                        }
                        break;
                }
                if ((frameX != Main.tile[i, j].frameX) || (frameY != Main.tile[i, j].frameY))
                {
                    Main.tile[i, j].frameX = frameX;
                    Main.tile[i, j].frameY = frameY;
                    SquareTileFrame(i, j, true);
                }
            }
            catch
            {
                Main.tile[i, j].frameX = 0;
                Main.tile[i, j].frameY = 0;
            }
        }

        public static void CaveOpenater(int i, int j)
        {
            Vector2 vector;
            Vector2 vector2;
            double num5 = genRand.Next(7, 12);
            double num6 = num5;
            int num7 = 1;
            if (genRand.Next(2) == 0)
            {
                num7 = -1;
            }
            vector.X = i;
            vector.Y = j;
            int num8 = 100;
            vector2.Y = 0f;
            vector2.X = num7;
            while (num8 > 0)
            {
                if (Main.tile[(int) vector.X, (int) vector.Y].wall == 0)
                {
                    num8 = 0;
                }
                num8--;
                int num = (int) (vector.X - (num5 * 0.5));
                int maxTilesX = (int) (vector.X + (num5 * 0.5));
                int num2 = (int) (vector.Y - (num5 * 0.5));
                int maxTilesY = (int) (vector.Y + (num5 * 0.5));
                if (num < 0)
                {
                    num = 0;
                }
                if (maxTilesX > Main.maxTilesX)
                {
                    maxTilesX = Main.maxTilesX;
                }
                if (num2 < 0)
                {
                    num2 = 0;
                }
                if (maxTilesY > Main.maxTilesY)
                {
                    maxTilesY = Main.maxTilesY;
                }
                num6 = (num5 * genRand.Next(80, 120)) * 0.01;
                for (int k = num; k < maxTilesX; k++)
                {
                    for (int m = num2; m < maxTilesY; m++)
                    {
                        float num11 = Math.Abs((float) (k - vector.X));
                        float num12 = Math.Abs((float) (m - vector.Y));
                        if (Math.Sqrt((double) ((num11 * num11) + (num12 * num12))) < (num6 * 0.4))
                        {
                            Main.tile[k, m].active = false;
                        }
                    }
                }
                vector += vector2;
                vector2.X += genRand.Next(-10, 11) * 0.05f;
                vector2.Y += genRand.Next(-10, 11) * 0.05f;
                if (vector2.X > (num7 + 0.5f))
                {
                    vector2.X = num7 + 0.5f;
                }
                if (vector2.X < (num7 - 0.5f))
                {
                    vector2.X = num7 - 0.5f;
                }
                if (vector2.Y > 0f)
                {
                    vector2.Y = 0f;
                }
                if (vector2.Y < -0.5)
                {
                    vector2.Y = -0.5f;
                }
            }
        }

        public static void Cavinator(int i, int j, int steps)
        {
            Vector2 vector;
            Vector2 vector2;
            double num5 = genRand.Next(7, 15);
            double num6 = num5;
            int num7 = 1;
            if (genRand.Next(2) == 0)
            {
                num7 = -1;
            }
            vector.X = i;
            vector.Y = j;
            int num8 = genRand.Next(20, 40);
            vector2.Y = genRand.Next(10, 20) * 0.01f;
            vector2.X = num7;
            while (num8 > 0)
            {
                num8--;
                int num = (int) (vector.X - (num5 * 0.5));
                int maxTilesX = (int) (vector.X + (num5 * 0.5));
                int num2 = (int) (vector.Y - (num5 * 0.5));
                int maxTilesY = (int) (vector.Y + (num5 * 0.5));
                if (num < 0)
                {
                    num = 0;
                }
                if (maxTilesX > Main.maxTilesX)
                {
                    maxTilesX = Main.maxTilesX;
                }
                if (num2 < 0)
                {
                    num2 = 0;
                }
                if (maxTilesY > Main.maxTilesY)
                {
                    maxTilesY = Main.maxTilesY;
                }
                num6 = (num5 * genRand.Next(80, 120)) * 0.01;
                for (int k = num; k < maxTilesX; k++)
                {
                    for (int m = num2; m < maxTilesY; m++)
                    {
                        float num11 = Math.Abs((float) (k - vector.X));
                        float num12 = Math.Abs((float) (m - vector.Y));
                        if (Math.Sqrt((double) ((num11 * num11) + (num12 * num12))) < (num6 * 0.4))
                        {
                            Main.tile[k, m].active = false;
                        }
                    }
                }
                vector += vector2;
                vector2.X += genRand.Next(-10, 11) * 0.05f;
                vector2.Y += genRand.Next(-10, 11) * 0.05f;
                if (vector2.X > (num7 + 0.5f))
                {
                    vector2.X = num7 + 0.5f;
                }
                if (vector2.X < (num7 - 0.5f))
                {
                    vector2.X = num7 - 0.5f;
                }
                if (vector2.Y > 2f)
                {
                    vector2.Y = 2f;
                }
                if (vector2.Y < 0f)
                {
                    vector2.Y = 0f;
                }
            }
            if ((steps > 0) && (((int) vector.Y) < (Main.rockLayer + 50.0)))
            {
                Cavinator((int) vector.X, (int) vector.Y, steps - 1);
            }
        }

        public static void ChasmRunner(int i, int j, int steps, bool makeOrb = false)
        {
            Vector2 vector;
            Vector2 vector2;
            bool flag = false;
            bool flag2 = false;
            bool flag3 = false;
            if (!makeOrb)
            {
                flag2 = true;
            }
            float num5 = steps;
            vector.X = i;
            vector.Y = j;
            vector2.X = genRand.Next(-10, 11) * 0.1f;
            vector2.Y = (genRand.Next(11) * 0.2f) + 0.5f;
            int num6 = 5;
            double num7 = genRand.Next(5) + 7;
            while (num7 > 0.0)
            {
                int num;
                int num2;
                int num3;
                int maxTilesY;
                if (num5 > 0f)
                {
                    num7 += genRand.Next(3);
                    num7 -= genRand.Next(3);
                    if (num7 < 7.0)
                    {
                        num7 = 7.0;
                    }
                    if (num7 > 20.0)
                    {
                        num7 = 20.0;
                    }
                    if ((num5 == 1f) && (num7 < 10.0))
                    {
                        num7 = 10.0;
                    }
                }
                else if (vector.Y > (Main.worldSurface + 45.0))
                {
                    num7 -= genRand.Next(4);
                }
                if ((vector.Y > Main.rockLayer) && (num5 > 0f))
                {
                    num5 = 0f;
                }
                num5--;
                if (!flag && (vector.Y > (Main.worldSurface + 20.0)))
                {
                    flag = true;
                    ChasmRunnerSideways((int) vector.X, (int) vector.Y, -1, genRand.Next(20, 40));
                    ChasmRunnerSideways((int) vector.X, (int) vector.Y, 1, genRand.Next(20, 40));
                }
                if (num5 > num6)
                {
                    num = (int) (vector.X - (num7 * 0.5));
                    num3 = (int) (vector.X + (num7 * 0.5));
                    num2 = (int) (vector.Y - (num7 * 0.5));
                    maxTilesY = (int) (vector.Y + (num7 * 0.5));
                    if (num < 0)
                    {
                        num = 0;
                    }
                    if (num3 > (Main.maxTilesX - 1))
                    {
                        num3 = Main.maxTilesX - 1;
                    }
                    if (num2 < 0)
                    {
                        num2 = 0;
                    }
                    if (maxTilesY > Main.maxTilesY)
                    {
                        maxTilesY = Main.maxTilesY;
                    }
                    for (int n = num; n < num3; n++)
                    {
                        for (int num9 = num2; num9 < maxTilesY; num9++)
                        {
                            if ((((Math.Abs((float) (n - vector.X)) + Math.Abs((float) (num9 - vector.Y))) < ((num7 * 0.5) * (1.0 + (genRand.Next(-10, 11) * 0.015)))) && (Main.tile[n, num9].type != 0x1f)) && (Main.tile[n, num9].type != 0x16))
                            {
                                Main.tile[n, num9].active = false;
                            }
                        }
                    }
                }
                if ((num5 <= 2f) && (vector.Y < (Main.worldSurface + 45.0)))
                {
                    num5 = 2f;
                }
                if (num5 <= 0f)
                {
                    if (!flag2)
                    {
                        flag2 = true;
                        AddShadowOrb((int) vector.X, (int) vector.Y);
                    }
                    else if (!flag3)
                    {
                        flag3 = false;
                        bool flag4 = false;
                        int num10 = 0;
                        while (!flag4)
                        {
                            int x = genRand.Next(((int) vector.X) - 0x19, ((int) vector.X) + 0x19);
                            int y = genRand.Next(((int) vector.Y) - 50, (int) vector.Y);
                            if (x < 5)
                            {
                                x = 5;
                            }
                            if (x > (Main.maxTilesX - 5))
                            {
                                x = Main.maxTilesX - 5;
                            }
                            if (y < 5)
                            {
                                y = 5;
                            }
                            if (y > (Main.maxTilesY - 5))
                            {
                                y = Main.maxTilesY - 5;
                            }
                            if (y > Main.worldSurface)
                            {
                                Place3x2(x, y, 0x1a);
                                if (Main.tile[x, y].type == 0x1a)
                                {
                                    flag4 = true;
                                }
                                else
                                {
                                    num10++;
                                    if (num10 >= 0x2710)
                                    {
                                        flag4 = true;
                                    }
                                }
                            }
                            else
                            {
                                flag4 = true;
                            }
                        }
                    }
                }
                vector += vector2;
                vector2.X += genRand.Next(-10, 11) * 0.01f;
                if (vector2.X > 0.3)
                {
                    vector2.X = 0.3f;
                }
                if (vector2.X < -0.3)
                {
                    vector2.X = -0.3f;
                }
                num = (int) (vector.X - (num7 * 1.1));
                num3 = (int) (vector.X + (num7 * 1.1));
                num2 = (int) (vector.Y - (num7 * 1.1));
                maxTilesY = (int) (vector.Y + (num7 * 1.1));
                if (num < 1)
                {
                    num = 1;
                }
                if (num3 > (Main.maxTilesX - 1))
                {
                    num3 = Main.maxTilesX - 1;
                }
                if (num2 < 0)
                {
                    num2 = 0;
                }
                if (maxTilesY > Main.maxTilesY)
                {
                    maxTilesY = Main.maxTilesY;
                }
                for (int k = num; k < num3; k++)
                {
                    for (int num14 = num2; num14 < maxTilesY; num14++)
                    {
                        if ((Math.Abs((float) (k - vector.X)) + Math.Abs((float) (num14 - vector.Y))) < ((num7 * 1.1) * (1.0 + (genRand.Next(-10, 11) * 0.015))))
                        {
                            if ((Main.tile[k, num14].type != 0x19) && (num14 > (j + genRand.Next(3, 20))))
                            {
                                Main.tile[k, num14].active = true;
                            }
                            if (steps <= num6)
                            {
                                Main.tile[k, num14].active = true;
                            }
                            if (Main.tile[k, num14].type != 0x1f)
                            {
                                Main.tile[k, num14].type = 0x19;
                            }
                            if (Main.tile[k, num14].wall == 2)
                            {
                                Main.tile[k, num14].wall = 0;
                            }
                        }
                    }
                }
                for (int m = num; m < num3; m++)
                {
                    for (int num16 = num2; num16 < maxTilesY; num16++)
                    {
                        if ((Math.Abs((float) (m - vector.X)) + Math.Abs((float) (num16 - vector.Y))) < ((num7 * 1.1) * (1.0 + (genRand.Next(-10, 11) * 0.015))))
                        {
                            if (Main.tile[m, num16].type != 0x1f)
                            {
                                Main.tile[m, num16].type = 0x19;
                            }
                            if (steps <= num6)
                            {
                                Main.tile[m, num16].active = true;
                            }
                            if (num16 > (j + genRand.Next(3, 20)))
                            {
                                PlaceWall(m, num16, 3, true);
                            }
                        }
                    }
                }
            }
        }

        public static void ChasmRunnerSideways(int i, int j, int direction, int steps)
        {
            Vector2 vector;
            Vector2 vector2;
            float num5 = steps;
            vector.X = i;
            vector.Y = j;
            vector2.X = (genRand.Next(10, 0x15) * 0.1f) * direction;
            vector2.Y = genRand.Next(-10, 10) * 0.01f;
            double num6 = genRand.Next(5) + 7;
            while (num6 > 0.0)
            {
                if (num5 > 0f)
                {
                    num6 += genRand.Next(3);
                    num6 -= genRand.Next(3);
                    if (num6 < 7.0)
                    {
                        num6 = 7.0;
                    }
                    if (num6 > 20.0)
                    {
                        num6 = 20.0;
                    }
                    if ((num5 == 1f) && (num6 < 10.0))
                    {
                        num6 = 10.0;
                    }
                }
                else
                {
                    num6 -= genRand.Next(4);
                }
                if ((vector.Y > Main.rockLayer) && (num5 > 0f))
                {
                    num5 = 0f;
                }
                num5--;
                int num = (int) (vector.X - (num6 * 0.5));
                int num3 = (int) (vector.X + (num6 * 0.5));
                int num2 = (int) (vector.Y - (num6 * 0.5));
                int maxTilesY = (int) (vector.Y + (num6 * 0.5));
                if (num < 0)
                {
                    num = 0;
                }
                if (num3 > (Main.maxTilesX - 1))
                {
                    num3 = Main.maxTilesX - 1;
                }
                if (num2 < 0)
                {
                    num2 = 0;
                }
                if (maxTilesY > Main.maxTilesY)
                {
                    maxTilesY = Main.maxTilesY;
                }
                for (int k = num; k < num3; k++)
                {
                    for (int num8 = num2; num8 < maxTilesY; num8++)
                    {
                        if ((((Math.Abs((float) (k - vector.X)) + Math.Abs((float) (num8 - vector.Y))) < ((num6 * 0.5) * (1.0 + (genRand.Next(-10, 11) * 0.015)))) && (Main.tile[k, num8].type != 0x1f)) && (Main.tile[k, num8].type != 0x16))
                        {
                            Main.tile[k, num8].active = false;
                        }
                    }
                }
                vector += vector2;
                vector2.Y += genRand.Next(-10, 10) * 0.1f;
                if (vector.Y < (j - 20))
                {
                    vector2.Y += genRand.Next(20) * 0.01f;
                }
                if (vector.Y > (j + 20))
                {
                    vector2.Y -= genRand.Next(20) * 0.01f;
                }
                if (vector2.Y < -0.5)
                {
                    vector2.Y = -0.5f;
                }
                if (vector2.Y > 0.5)
                {
                    vector2.Y = 0.5f;
                }
                vector2.X += genRand.Next(-10, 11) * 0.01f;
                if (direction == -1)
                {
                    if (vector2.X > -0.5)
                    {
                        vector2.X = -0.5f;
                    }
                    if (vector2.X < -2f)
                    {
                        vector2.X = -2f;
                    }
                }
                else if (direction == 1)
                {
                    if (vector2.X < 0.5)
                    {
                        vector2.X = 0.5f;
                    }
                    if (vector2.X > 2f)
                    {
                        vector2.X = 2f;
                    }
                }
                num = (int) (vector.X - (num6 * 1.1));
                num3 = (int) (vector.X + (num6 * 1.1));
                num2 = (int) (vector.Y - (num6 * 1.1));
                maxTilesY = (int) (vector.Y + (num6 * 1.1));
                if (num < 1)
                {
                    num = 1;
                }
                if (num3 > (Main.maxTilesX - 1))
                {
                    num3 = Main.maxTilesX - 1;
                }
                if (num2 < 0)
                {
                    num2 = 0;
                }
                if (maxTilesY > Main.maxTilesY)
                {
                    maxTilesY = Main.maxTilesY;
                }
                for (int m = num; m < num3; m++)
                {
                    for (int num10 = num2; num10 < maxTilesY; num10++)
                    {
                        if (((Math.Abs((float) (m - vector.X)) + Math.Abs((float) (num10 - vector.Y))) < ((num6 * 1.1) * (1.0 + (genRand.Next(-10, 11) * 0.015)))) && (Main.tile[m, num10].wall != 3))
                        {
                            if ((Main.tile[m, num10].type != 0x19) && (num10 > (j + genRand.Next(3, 20))))
                            {
                                Main.tile[m, num10].active = true;
                            }
                            Main.tile[m, num10].active = true;
                            if ((Main.tile[m, num10].type != 0x1f) && (Main.tile[m, num10].type != 0x16))
                            {
                                Main.tile[m, num10].type = 0x19;
                            }
                            if (Main.tile[m, num10].wall == 2)
                            {
                                Main.tile[m, num10].wall = 0;
                            }
                        }
                    }
                }
                for (int n = num; n < num3; n++)
                {
                    for (int num12 = num2; num12 < maxTilesY; num12++)
                    {
                        if (((Math.Abs((float) (n - vector.X)) + Math.Abs((float) (num12 - vector.Y))) < ((num6 * 1.1) * (1.0 + (genRand.Next(-10, 11) * 0.015)))) && (Main.tile[n, num12].wall != 3))
                        {
                            if ((Main.tile[n, num12].type != 0x1f) && (Main.tile[n, num12].type != 0x16))
                            {
                                Main.tile[n, num12].type = 0x19;
                            }
                            Main.tile[n, num12].active = true;
                            PlaceWall(n, num12, 3, true);
                        }
                    }
                }
            }
            if (genRand.Next(3) == 0)
            {
                int x = (int) vector.X;
                int y = (int) vector.Y;
                while (!Main.tile[x, y].active)
                {
                    y++;
                }
                TileRunner(x, y, (double) genRand.Next(2, 6), genRand.Next(3, 7), 0x16, false, 0f, 0f, false, true);
            }
        }

        public static void Check1x2(int x, int j, byte type)
        {
            if (!destroyObject)
            {
                int num = j;
                bool flag = true;
                if (Main.tile[x, num] == null)
                {
                    Main.tile[x, num] = new Tile();
                }
                if (Main.tile[x, num + 1] == null)
                {
                    Main.tile[x, num + 1] = new Tile();
                }
                int frameY = Main.tile[x, num].frameY;
                int num3 = 0;
                while (frameY >= 40)
                {
                    frameY -= 40;
                    num3++;
                }
                if (frameY == 0x12)
                {
                    num--;
                }
                if (Main.tile[x, num] == null)
                {
                    Main.tile[x, num] = new Tile();
                }
                if (((Main.tile[x, num].frameY == (40 * num3)) && (Main.tile[x, num + 1].frameY == ((40 * num3) + 0x12))) && ((Main.tile[x, num].type == type) && (Main.tile[x, num + 1].type == type)))
                {
                    flag = false;
                }
                if (Main.tile[x, num + 2] == null)
                {
                    Main.tile[x, num + 2] = new Tile();
                }
                if (!Main.tile[x, num + 2].active || !Main.tileSolid[Main.tile[x, num + 2].type])
                {
                    flag = true;
                }
                if ((Main.tile[x, num + 2].type != 2) && (Main.tile[x, num].type == 20))
                {
                    flag = true;
                }
                if (flag)
                {
                    destroyObject = true;
                    if (Main.tile[x, num].type == type)
                    {
                        KillTile(x, num, false, false, false);
                    }
                    if (Main.tile[x, num + 1].type == type)
                    {
                        KillTile(x, num + 1, false, false, false);
                    }
                    if (type == 15)
                    {
                        if (num3 == 1)
                        {
                            Item.NewItem(x * 0x10, num * 0x10, 0x20, 0x20, 0x166, 1, false);
                        }
                        else
                        {
                            Item.NewItem(x * 0x10, num * 0x10, 0x20, 0x20, 0x22, 1, false);
                        }
                    }
                    destroyObject = false;
                }
            }
        }

        public static void Check1x2Top(int x, int j, byte type)
        {
            if (!destroyObject)
            {
                int num = j;
                bool flag = true;
                if (Main.tile[x, num] == null)
                {
                    Main.tile[x, num] = new Tile();
                }
                if (Main.tile[x, num + 1] == null)
                {
                    Main.tile[x, num + 1] = new Tile();
                }
                if (Main.tile[x, num].frameY == 0x12)
                {
                    num--;
                }
                if (Main.tile[x, num] == null)
                {
                    Main.tile[x, num] = new Tile();
                }
                if (((Main.tile[x, num].frameY == 0) && (Main.tile[x, num + 1].frameY == 0x12)) && ((Main.tile[x, num].type == type) && (Main.tile[x, num + 1].type == type)))
                {
                    flag = false;
                }
                if (Main.tile[x, num - 1] == null)
                {
                    Main.tile[x, num - 1] = new Tile();
                }
                if ((!Main.tile[x, num - 1].active || !Main.tileSolid[Main.tile[x, num - 1].type]) || Main.tileSolidTop[Main.tile[x, num - 1].type])
                {
                    flag = true;
                }
                if (flag)
                {
                    destroyObject = true;
                    if (Main.tile[x, num].type == type)
                    {
                        KillTile(x, num, false, false, false);
                    }
                    if (Main.tile[x, num + 1].type == type)
                    {
                        KillTile(x, num + 1, false, false, false);
                    }
                    if (type == 0x2a)
                    {
                        Item.NewItem(x * 0x10, num * 0x10, 0x20, 0x20, 0x88, 1, false);
                    }
                    destroyObject = false;
                }
            }
        }

        public static void Check1xX(int x, int j, byte type)
        {
            if (!destroyObject)
            {
                int num = j - (Main.tile[x, j].frameY / 0x12);
                int frameX = Main.tile[x, j].frameX;
                int num3 = 3;
                if (type == 0x5c)
                {
                    num3 = 6;
                }
                bool flag = false;
                for (int i = 0; i < num3; i++)
                {
                    if (Main.tile[x, num + i] == null)
                    {
                        Main.tile[x, num + i] = new Tile();
                    }
                    if (!Main.tile[x, num + i].active)
                    {
                        flag = true;
                    }
                    else if (Main.tile[x, num + i].type != type)
                    {
                        flag = true;
                    }
                    else if (Main.tile[x, num + i].frameY != (i * 0x12))
                    {
                        flag = true;
                    }
                    else if (Main.tile[x, num + i].frameX != frameX)
                    {
                        flag = true;
                    }
                }
                if (Main.tile[x, num + num3] == null)
                {
                    Main.tile[x, num + num3] = new Tile();
                }
                if (!Main.tile[x, num + num3].active)
                {
                    flag = true;
                }
                if (!Main.tileSolid[Main.tile[x, num + num3].type])
                {
                    flag = true;
                }
                if (flag)
                {
                    destroyObject = true;
                    for (int k = 0; k < num3; k++)
                    {
                        if (Main.tile[x, num + k].type == type)
                        {
                            KillTile(x, num + k, false, false, false);
                        }
                    }
                    if (type == 0x5c)
                    {
                        Item.NewItem(x * 0x10, j * 0x10, 0x20, 0x20, 0x155, 1, false);
                    }
                    if (type == 0x5d)
                    {
                        Item.NewItem(x * 0x10, j * 0x10, 0x20, 0x20, 0x156, 1, false);
                    }
                    destroyObject = false;
                }
            }
        }

        public static void Check2x1(int i, int y, byte type)
        {
            if (!destroyObject)
            {
                int num = i;
                bool flag = true;
                if (Main.tile[num, y] == null)
                {
                    Main.tile[num, y] = new Tile();
                }
                if (Main.tile[num + 1, y] == null)
                {
                    Main.tile[num + 1, y] = new Tile();
                }
                if (Main.tile[num, y + 1] == null)
                {
                    Main.tile[num, y + 1] = new Tile();
                }
                if (Main.tile[num + 1, y + 1] == null)
                {
                    Main.tile[num + 1, y + 1] = new Tile();
                }
                if (Main.tile[num, y].frameX == 0x12)
                {
                    num--;
                }
                if (((Main.tile[num, y].frameX == 0) && (Main.tile[num + 1, y].frameX == 0x12)) && ((Main.tile[num, y].type == type) && (Main.tile[num + 1, y].type == type)))
                {
                    flag = false;
                }
                if ((type == 0x1d) || (type == 0x67))
                {
                    if (!Main.tile[num, y + 1].active || !Main.tileTable[Main.tile[num, y + 1].type])
                    {
                        flag = true;
                    }
                    if (!Main.tile[num + 1, y + 1].active || !Main.tileTable[Main.tile[num + 1, y + 1].type])
                    {
                        flag = true;
                    }
                }
                else
                {
                    if (!Main.tile[num, y + 1].active || !Main.tileSolid[Main.tile[num, y + 1].type])
                    {
                        flag = true;
                    }
                    if (!Main.tile[num + 1, y + 1].active || !Main.tileSolid[Main.tile[num + 1, y + 1].type])
                    {
                        flag = true;
                    }
                }
                if (flag)
                {
                    destroyObject = true;
                    if (Main.tile[num, y].type == type)
                    {
                        KillTile(num, y, false, false, false);
                    }
                    if (Main.tile[num + 1, y].type == type)
                    {
                        KillTile(num + 1, y, false, false, false);
                    }
                    if (type == 0x10)
                    {
                        Item.NewItem(num * 0x10, y * 0x10, 0x20, 0x20, 0x23, 1, false);
                    }
                    if (type == 0x12)
                    {
                        Item.NewItem(num * 0x10, y * 0x10, 0x20, 0x20, 0x24, 1, false);
                    }
                    if (type == 0x1d)
                    {
                        Item.NewItem(num * 0x10, y * 0x10, 0x20, 0x20, 0x57, 1, false);
                        Main.PlaySound(13, i * 0x10, y * 0x10, 1);
                    }
                    if (type == 0x67)
                    {
                        Item.NewItem(num * 0x10, y * 0x10, 0x20, 0x20, 0x164, 1, false);
                        Main.PlaySound(13, i * 0x10, y * 0x10, 1);
                    }
                    destroyObject = false;
                    SquareTileFrame(num, y, true);
                    SquareTileFrame(num + 1, y, true);
                }
            }
        }

        public static void Check2x2(int i, int j, int type)
        {
            if (!destroyObject)
            {
                bool flag = false;
                int num = i;
                int num2 = j;
                num += (Main.tile[i, j].frameX / 0x12) * -1;
                num2 += (Main.tile[i, j].frameY / 0x12) * -1;
                for (int k = num; k < (num + 2); k++)
                {
                    for (int m = num2; m < (num2 + 2); m++)
                    {
                        if (Main.tile[k, m] == null)
                        {
                            Main.tile[k, m] = new Tile();
                        }
                        if ((!Main.tile[k, m].active || (Main.tile[k, m].type != type)) || ((Main.tile[k, m].frameX != ((k - num) * 0x12)) || (Main.tile[k, m].frameY != ((m - num2) * 0x12))))
                        {
                            flag = true;
                        }
                    }
                    if (type == 0x5f)
                    {
                        if (Main.tile[k, num2 - 1] == null)
                        {
                            Main.tile[k, num2 - 1] = new Tile();
                        }
                        if ((!Main.tile[k, num2 - 1].active || !Main.tileSolid[Main.tile[k, num2 - 1].type]) || Main.tileSolidTop[Main.tile[k, num2 - 1].type])
                        {
                            flag = true;
                        }
                    }
                    else
                    {
                        if (Main.tile[k, num2 + 2] == null)
                        {
                            Main.tile[k, num2 + 2] = new Tile();
                        }
                        if (!Main.tile[k, num2 + 2].active || (!Main.tileSolid[Main.tile[k, num2 + 2].type] && !Main.tileTable[Main.tile[k, num2 + 2].type]))
                        {
                            flag = true;
                        }
                    }
                }
                if (flag)
                {
                    destroyObject = true;
                    for (int n = num; n < (num + 2); n++)
                    {
                        for (int num6 = num2; num6 < (num2 + 3); num6++)
                        {
                            if ((Main.tile[n, num6].type == type) && Main.tile[n, num6].active)
                            {
                                KillTile(n, num6, false, false, false);
                            }
                        }
                    }
                    if (type == 0x55)
                    {
                        Item.NewItem(i * 0x10, j * 0x10, 0x20, 0x20, 0x141, 1, false);
                    }
                    if (type == 0x5e)
                    {
                        Item.NewItem(i * 0x10, j * 0x10, 0x20, 0x20, 0x160, 1, false);
                    }
                    if (type == 0x5f)
                    {
                        Item.NewItem(i * 0x10, j * 0x10, 0x20, 0x20, 0x158, 1, false);
                    }
                    if (type == 0x60)
                    {
                        Item.NewItem(i * 0x10, j * 0x10, 0x20, 0x20, 0x159, 1, false);
                    }
                    if (type == 0x61)
                    {
                        Item.NewItem(i * 0x10, j * 0x10, 0x20, 0x20, 0x15a, 1, false);
                    }
                    if (type == 0x62)
                    {
                        Item.NewItem(i * 0x10, j * 0x10, 0x20, 0x20, 0x15b, 1, false);
                    }
                    if (type == 0x63)
                    {
                        Item.NewItem(i * 0x10, j * 0x10, 0x20, 0x20, 0x15c, 1, false);
                    }
                    if (type == 100)
                    {
                        Item.NewItem(i * 0x10, j * 0x10, 0x20, 0x20, 0x15d, 1, false);
                    }
                    destroyObject = false;
                    for (int num7 = num - 1; num7 < (num + 3); num7++)
                    {
                        for (int num8 = num2 - 1; num8 < (num2 + 3); num8++)
                        {
                            TileFrame(num7, num8, false, false);
                        }
                    }
                }
            }
        }

        public static void Check2xX(int i, int j, byte type)
        {
            if (!destroyObject)
            {
                int num = i;
                if (Main.tile[i, j].frameX == 0x12)
                {
                    num--;
                }
                int num2 = j - (Main.tile[num, j].frameY / 0x12);
                int frameX = Main.tile[num, num2].frameX;
                int num4 = 3;
                if (type == 0x68)
                {
                    num4 = 5;
                }
                bool flag = false;
                for (int k = 0; k < num4; k++)
                {
                    if (Main.tile[num, num2 + k] == null)
                    {
                        Main.tile[num, num2 + k] = new Tile();
                    }
                    if (!Main.tile[num, num2 + k].active)
                    {
                        flag = true;
                    }
                    else if (Main.tile[num, num2 + k].type != type)
                    {
                        flag = true;
                    }
                    else if (Main.tile[num, num2 + k].frameY != (k * 0x12))
                    {
                        flag = true;
                    }
                    else if (Main.tile[num, num2 + k].frameX != frameX)
                    {
                        flag = true;
                    }
                    if (Main.tile[num + 1, num2 + k] == null)
                    {
                        Main.tile[num + 1, num2 + k] = new Tile();
                    }
                    if (!Main.tile[num + 1, num2 + k].active)
                    {
                        flag = true;
                    }
                    else if (Main.tile[num + 1, num2 + k].type != type)
                    {
                        flag = true;
                    }
                    else if (Main.tile[num + 1, num2 + k].frameY != (k * 0x12))
                    {
                        flag = true;
                    }
                    else if (Main.tile[num + 1, num2 + k].frameX != (frameX + 0x12))
                    {
                        flag = true;
                    }
                }
                if (Main.tile[num, num2 + num4] == null)
                {
                    Main.tile[num, num2 + num4] = new Tile();
                }
                if (!Main.tile[num, num2 + num4].active)
                {
                    flag = true;
                }
                if (!Main.tileSolid[Main.tile[num, num2 + num4].type])
                {
                    flag = true;
                }
                if (Main.tile[num + 1, num2 + num4] == null)
                {
                    Main.tile[num + 1, num2 + num4] = new Tile();
                }
                if (!Main.tile[num + 1, num2 + num4].active)
                {
                    flag = true;
                }
                if (!Main.tileSolid[Main.tile[num + 1, num2 + num4].type])
                {
                    flag = true;
                }
                if (flag)
                {
                    destroyObject = true;
                    for (int m = 0; m < num4; m++)
                    {
                        if (Main.tile[num, num2 + m].type == type)
                        {
                            KillTile(num, num2 + m, false, false, false);
                        }
                        if (Main.tile[num + 1, num2 + m].type == type)
                        {
                            KillTile(num + 1, num2 + m, false, false, false);
                        }
                    }
                    if (type == 0x68)
                    {
                        Item.NewItem(num * 0x10, j * 0x10, 0x20, 0x20, 0x167, 1, false);
                    }
                    if (type == 0x69)
                    {
                        Item.NewItem(num * 0x10, j * 0x10, 0x20, 0x20, 360, 1, false);
                    }
                    destroyObject = false;
                }
            }
        }

        public static void Check3x2(int i, int j, int type)
        {
            if (!destroyObject)
            {
                bool flag = false;
                int num = i;
                int num2 = j;
                num += (Main.tile[i, j].frameX / 0x12) * -1;
                num2 += (Main.tile[i, j].frameY / 0x12) * -1;
                for (int k = num; k < (num + 3); k++)
                {
                    for (int m = num2; m < (num2 + 2); m++)
                    {
                        if (Main.tile[k, m] == null)
                        {
                            Main.tile[k, m] = new Tile();
                        }
                        if ((!Main.tile[k, m].active || (Main.tile[k, m].type != type)) || ((Main.tile[k, m].frameX != ((k - num) * 0x12)) || (Main.tile[k, m].frameY != ((m - num2) * 0x12))))
                        {
                            flag = true;
                        }
                    }
                    if (Main.tile[k, num2 + 2] == null)
                    {
                        Main.tile[k, num2 + 2] = new Tile();
                    }
                    if (!Main.tile[k, num2 + 2].active || !Main.tileSolid[Main.tile[k, num2 + 2].type])
                    {
                        flag = true;
                    }
                }
                if (flag)
                {
                    destroyObject = true;
                    for (int n = num; n < (num + 3); n++)
                    {
                        for (int num6 = num2; num6 < (num2 + 3); num6++)
                        {
                            if ((Main.tile[n, num6].type == type) && Main.tile[n, num6].active)
                            {
                                KillTile(n, num6, false, false, false);
                            }
                        }
                    }
                    if (type == 14)
                    {
                        Item.NewItem(i * 0x10, j * 0x10, 0x20, 0x20, 0x20, 1, false);
                    }
                    else if (type == 0x11)
                    {
                        Item.NewItem(i * 0x10, j * 0x10, 0x20, 0x20, 0x21, 1, false);
                    }
                    else if (type == 0x4d)
                    {
                        Item.NewItem(i * 0x10, j * 0x10, 0x20, 0x20, 0xdd, 1, false);
                    }
                    else if (type == 0x56)
                    {
                        Item.NewItem(i * 0x10, j * 0x10, 0x20, 0x20, 0x14c, 1, false);
                    }
                    else if (type == 0x57)
                    {
                        Item.NewItem(i * 0x10, j * 0x10, 0x20, 0x20, 0x14d, 1, false);
                    }
                    else if (type == 0x58)
                    {
                        Item.NewItem(i * 0x10, j * 0x10, 0x20, 0x20, 0x14e, 1, false);
                    }
                    else if (type == 0x59)
                    {
                        Item.NewItem(i * 0x10, j * 0x10, 0x20, 0x20, 0x14f, 1, false);
                    }
                    destroyObject = false;
                    for (int num7 = num - 1; num7 < (num + 4); num7++)
                    {
                        for (int num8 = num2 - 1; num8 < (num2 + 4); num8++)
                        {
                            TileFrame(num7, num8, false, false);
                        }
                    }
                }
            }
        }

        public static void Check3x3(int i, int j, int type)
        {
            if (!destroyObject)
            {
                bool flag = false;
                int num = i;
                int num2 = j;
                num += (Main.tile[i, j].frameX / 0x12) * -1;
                num2 += (Main.tile[i, j].frameY / 0x12) * -1;
                for (int k = num; k < (num + 3); k++)
                {
                    for (int m = num2; m < (num2 + 3); m++)
                    {
                        if (Main.tile[k, m] == null)
                        {
                            Main.tile[k, m] = new Tile();
                        }
                        if ((!Main.tile[k, m].active || (Main.tile[k, m].type != type)) || ((Main.tile[k, m].frameX != ((k - num) * 0x12)) || (Main.tile[k, m].frameY != ((m - num2) * 0x12))))
                        {
                            flag = true;
                        }
                    }
                }
                if (type == 0x6a)
                {
                    for (int n = num; n < (num + 3); n++)
                    {
                        if (Main.tile[n, num2 + 3] == null)
                        {
                            Main.tile[n, num2 + 3] = new Tile();
                        }
                        if (!Main.tile[n, num2 + 3].active || !Main.tileSolid[Main.tile[n, num2 + 3].type])
                        {
                            flag = true;
                            break;
                        }
                    }
                }
                else
                {
                    if (Main.tile[num + 1, num2 - 1] == null)
                    {
                        Main.tile[num + 1, num2 - 1] = new Tile();
                    }
                    if ((!Main.tile[num + 1, num2 - 1].active || !Main.tileSolid[Main.tile[num + 1, num2 - 1].type]) || Main.tileSolidTop[Main.tile[num + 1, num2 - 1].type])
                    {
                        flag = true;
                    }
                }
                if (flag)
                {
                    destroyObject = true;
                    for (int num6 = num; num6 < (num + 3); num6++)
                    {
                        for (int num7 = num2; num7 < (num2 + 3); num7++)
                        {
                            if ((Main.tile[num6, num7].type == type) && Main.tile[num6, num7].active)
                            {
                                KillTile(num6, num7, false, false, false);
                            }
                        }
                    }
                    if (type == 0x22)
                    {
                        Item.NewItem(i * 0x10, j * 0x10, 0x20, 0x20, 0x6a, 1, false);
                    }
                    else if (type == 0x23)
                    {
                        Item.NewItem(i * 0x10, j * 0x10, 0x20, 0x20, 0x6b, 1, false);
                    }
                    else if (type == 0x24)
                    {
                        Item.NewItem(i * 0x10, j * 0x10, 0x20, 0x20, 0x6c, 1, false);
                    }
                    else if (type == 0x6a)
                    {
                        Item.NewItem(i * 0x10, j * 0x10, 0x20, 0x20, 0x16b, 1, false);
                    }
                    destroyObject = false;
                    for (int num8 = num - 1; num8 < (num + 4); num8++)
                    {
                        for (int num9 = num2 - 1; num9 < (num2 + 4); num9++)
                        {
                            TileFrame(num8, num9, false, false);
                        }
                    }
                }
            }
        }

        public static void Check3x4(int i, int j, int type)
        {
            if (!destroyObject)
            {
                bool flag = false;
                int num = i;
                int num2 = j;
                num += (Main.tile[i, j].frameX / 0x12) * -1;
                num2 += (Main.tile[i, j].frameY / 0x12) * -1;
                for (int k = num; k < (num + 3); k++)
                {
                    for (int m = num2; m < (num2 + 4); m++)
                    {
                        if (Main.tile[k, m] == null)
                        {
                            Main.tile[k, m] = new Tile();
                        }
                        if ((!Main.tile[k, m].active || (Main.tile[k, m].type != type)) || ((Main.tile[k, m].frameX != ((k - num) * 0x12)) || (Main.tile[k, m].frameY != ((m - num2) * 0x12))))
                        {
                            flag = true;
                        }
                    }
                    if (Main.tile[k, num2 + 4] == null)
                    {
                        Main.tile[k, num2 + 4] = new Tile();
                    }
                    if (!Main.tile[k, num2 + 4].active || !Main.tileSolid[Main.tile[k, num2 + 4].type])
                    {
                        flag = true;
                    }
                }
                if (flag)
                {
                    destroyObject = true;
                    for (int n = num; n < (num + 3); n++)
                    {
                        for (int num6 = num2; num6 < (num2 + 4); num6++)
                        {
                            if ((Main.tile[n, num6].type == type) && Main.tile[n, num6].active)
                            {
                                KillTile(n, num6, false, false, false);
                            }
                        }
                    }
                    if (type == 0x65)
                    {
                        Item.NewItem(i * 0x10, j * 0x10, 0x20, 0x20, 0x162, 1, false);
                    }
                    else if (type == 0x66)
                    {
                        Item.NewItem(i * 0x10, j * 0x10, 0x20, 0x20, 0x163, 1, false);
                    }
                    destroyObject = false;
                    for (int num7 = num - 1; num7 < (num + 4); num7++)
                    {
                        for (int num8 = num2 - 1; num8 < (num2 + 4); num8++)
                        {
                            TileFrame(num7, num8, false, false);
                        }
                    }
                }
            }
        }

        public static void Check4x2(int i, int j, int type)
        {
            if (!destroyObject)
            {
                bool flag = false;
                int num = i;
                int num2 = j;
                num += (Main.tile[i, j].frameX / 0x12) * -1;
                if (((type == 0x4f) || (type == 90)) && (Main.tile[i, j].frameX >= 0x48))
                {
                    num += 4;
                }
                num2 += (Main.tile[i, j].frameY / 0x12) * -1;
                for (int k = num; k < (num + 4); k++)
                {
                    for (int m = num2; m < (num2 + 2); m++)
                    {
                        int num5 = (k - num) * 0x12;
                        if (((type == 0x4f) || (type == 90)) && (Main.tile[i, j].frameX >= 0x48))
                        {
                            num5 = ((k - num) + 4) * 0x12;
                        }
                        if (Main.tile[k, m] == null)
                        {
                            Main.tile[k, m] = new Tile();
                        }
                        if ((!Main.tile[k, m].active || (Main.tile[k, m].type != type)) || ((Main.tile[k, m].frameX != num5) || (Main.tile[k, m].frameY != ((m - num2) * 0x12))))
                        {
                            flag = true;
                        }
                    }
                    if (Main.tile[k, num2 + 2] == null)
                    {
                        Main.tile[k, num2 + 2] = new Tile();
                    }
                    if (!Main.tile[k, num2 + 2].active || !Main.tileSolid[Main.tile[k, num2 + 2].type])
                    {
                        flag = true;
                    }
                }
                if (flag)
                {
                    destroyObject = true;
                    for (int n = num; n < (num + 4); n++)
                    {
                        for (int num7 = num2; num7 < (num2 + 3); num7++)
                        {
                            if ((Main.tile[n, num7].type == type) && Main.tile[n, num7].active)
                            {
                                KillTile(n, num7, false, false, false);
                            }
                        }
                    }
                    if (type == 0x4f)
                    {
                        Item.NewItem(i * 0x10, j * 0x10, 0x20, 0x20, 0xe0, 1, false);
                    }
                    if (type == 90)
                    {
                        Item.NewItem(i * 0x10, j * 0x10, 0x20, 0x20, 0x150, 1, false);
                    }
                    destroyObject = false;
                    for (int num8 = num - 1; num8 < (num + 4); num8++)
                    {
                        for (int num9 = num2 - 1; num9 < (num2 + 4); num9++)
                        {
                            TileFrame(num8, num9, false, false);
                        }
                    }
                }
            }
        }

        public static void CheckAlch(int x, int y)
        {
            if (Main.tile[x, y] == null)
            {
                Main.tile[x, y] = new Tile();
            }
            if (Main.tile[x, y + 1] == null)
            {
                Main.tile[x, y + 1] = new Tile();
            }
            bool flag = false;
            if (!Main.tile[x, y + 1].active)
            {
                flag = true;
            }
            int num = Main.tile[x, y].frameX / 0x12;
            Main.tile[x, y].frameY = 0;
            if (!flag)
            {
                switch (num)
                {
                    case 0:
                        if ((Main.tile[x, y + 1].type != 2) && (Main.tile[x, y + 1].type != 0x4e))
                        {
                            flag = true;
                        }
                        if ((Main.tile[x, y].liquid > 0) && Main.tile[x, y].lava)
                        {
                            flag = true;
                        }
                        break;

                    case 1:
                        if ((Main.tile[x, y + 1].type != 60) && (Main.tile[x, y + 1].type != 0x4e))
                        {
                            flag = true;
                        }
                        if ((Main.tile[x, y].liquid > 0) && Main.tile[x, y].lava)
                        {
                            flag = true;
                        }
                        break;

                    case 2:
                        if (((Main.tile[x, y + 1].type != 0) && (Main.tile[x, y + 1].type != 0x3b)) && (Main.tile[x, y + 1].type != 0x4e))
                        {
                            flag = true;
                        }
                        if ((Main.tile[x, y].liquid > 0) && Main.tile[x, y].lava)
                        {
                            flag = true;
                        }
                        break;

                    case 3:
                        if (((Main.tile[x, y + 1].type != 0x17) && (Main.tile[x, y + 1].type != 0x19)) && (Main.tile[x, y + 1].type != 0x4e))
                        {
                            flag = true;
                        }
                        if ((Main.tile[x, y].liquid > 0) && Main.tile[x, y].lava)
                        {
                            flag = true;
                        }
                        break;

                    case 4:
                        if ((Main.tile[x, y + 1].type != 0x35) && (Main.tile[x, y + 1].type != 0x4e))
                        {
                            flag = true;
                        }
                        if ((Main.tile[x, y].liquid > 0) && Main.tile[x, y].lava)
                        {
                            flag = true;
                        }
                        if (((Main.tile[x, y].type != 0x52) && !Main.tile[x, y].lava) && (Main.netMode != 1))
                        {
                            if (Main.tile[x, y].liquid > 0x10)
                            {
                                if (Main.tile[x, y].type == 0x53)
                                {
                                    Main.tile[x, y].type = 0x54;
                                    if (Main.netMode == 2)
                                    {
                                        NetMessage.SendTileSquare(-1, x, y, 1);
                                    }
                                }
                            }
                            else if (Main.tile[x, y].type == 0x54)
                            {
                                Main.tile[x, y].type = 0x53;
                                if (Main.netMode == 2)
                                {
                                    NetMessage.SendTileSquare(-1, x, y, 1);
                                }
                            }
                        }
                        break;

                    case 5:
                        if ((Main.tile[x, y + 1].type != 0x39) && (Main.tile[x, y + 1].type != 0x4e))
                        {
                            flag = true;
                        }
                        if ((Main.tile[x, y].liquid > 0) && !Main.tile[x, y].lava)
                        {
                            flag = true;
                        }
                        if ((((Main.tile[x, y].type != 0x52) && Main.tile[x, y].lava) && ((Main.tile[x, y].type != 0x52) && Main.tile[x, y].lava)) && (Main.netMode != 1))
                        {
                            if (Main.tile[x, y].liquid > 0x10)
                            {
                                if (Main.tile[x, y].type == 0x53)
                                {
                                    Main.tile[x, y].type = 0x54;
                                    if (Main.netMode == 2)
                                    {
                                        NetMessage.SendTileSquare(-1, x, y, 1);
                                    }
                                }
                            }
                            else if (Main.tile[x, y].type == 0x54)
                            {
                                Main.tile[x, y].type = 0x53;
                                if (Main.netMode == 2)
                                {
                                    NetMessage.SendTileSquare(-1, x, y, 1);
                                }
                            }
                        }
                        break;
                }
            }
            if (flag)
            {
                KillTile(x, y, false, false, false);
            }
        }

        public static void CheckBanner(int x, int j, byte type)
        {
            if (!destroyObject)
            {
                int num = j - (Main.tile[x, j].frameY / 0x12);
                int frameX = Main.tile[x, j].frameX;
                bool flag = false;
                for (int i = 0; i < 3; i++)
                {
                    if (Main.tile[x, num + i] == null)
                    {
                        Main.tile[x, num + i] = new Tile();
                    }
                    if (!Main.tile[x, num + i].active)
                    {
                        flag = true;
                    }
                    else if (Main.tile[x, num + i].type != type)
                    {
                        flag = true;
                    }
                    else if (Main.tile[x, num + i].frameY != (i * 0x12))
                    {
                        flag = true;
                    }
                    else if (Main.tile[x, num + i].frameX != frameX)
                    {
                        flag = true;
                    }
                }
                if (Main.tile[x, num - 1] == null)
                {
                    Main.tile[x, num - 1] = new Tile();
                }
                if (!Main.tile[x, num - 1].active)
                {
                    flag = true;
                }
                if (!Main.tileSolid[Main.tile[x, num - 1].type])
                {
                    flag = true;
                }
                if (Main.tileSolidTop[Main.tile[x, num - 1].type])
                {
                    flag = true;
                }
                if (flag)
                {
                    destroyObject = true;
                    for (int k = 0; k < 3; k++)
                    {
                        if (Main.tile[x, num + k].type == type)
                        {
                            KillTile(x, num + k, false, false, false);
                        }
                    }
                    if (type == 0x5b)
                    {
                        int num5 = frameX / 0x12;
                        Item.NewItem(x * 0x10, (num + 1) * 0x10, 0x20, 0x20, 0x151 + num5, 1, false);
                    }
                    destroyObject = false;
                }
            }
        }

        public static bool CheckCactus(int i, int j)
        {
            int num = j;
            int num2 = i;
            while (Main.tile[num2, num].active && (Main.tile[num2, num].type == 80))
            {
                num++;
                if (!Main.tile[num2, num].active || (Main.tile[num2, num].type != 80))
                {
                    if (((Main.tile[num2 - 1, num].active && (Main.tile[num2 - 1, num].type == 80)) && (Main.tile[num2 - 1, num - 1].active && (Main.tile[num2 - 1, num - 1].type == 80))) && (num2 >= i))
                    {
                        num2--;
                    }
                    if (((Main.tile[num2 + 1, num].active && (Main.tile[num2 + 1, num].type == 80)) && (Main.tile[num2 + 1, num - 1].active && (Main.tile[num2 + 1, num - 1].type == 80))) && (num2 <= i))
                    {
                        num2++;
                    }
                }
            }
            if (!Main.tile[num2, num].active || (Main.tile[num2, num].type != 0x35))
            {
                KillTile(i, j, false, false, false);
                return true;
            }
            if (i != num2)
            {
                if (((!Main.tile[i, j + 1].active || (Main.tile[i, j + 1].type != 80)) && (!Main.tile[i - 1, j].active || (Main.tile[i - 1, j].type != 80))) && (!Main.tile[i + 1, j].active || (Main.tile[i + 1, j].type != 80)))
                {
                    KillTile(i, j, false, false, false);
                    return true;
                }
            }
            else if ((i == num2) && (!Main.tile[i, j + 1].active || ((Main.tile[i, j + 1].type != 80) && (Main.tile[i, j + 1].type != 0x35))))
            {
                KillTile(i, j, false, false, false);
                return true;
            }
            return false;
        }

        public static void CheckChest(int i, int j, int type)
        {
            if (!destroyObject)
            {
                bool flag = false;
                int num = 0;
                int num2 = j;
                num += Main.tile[i, j].frameX / 0x12;
                num2 += (Main.tile[i, j].frameY / 0x12) * -1;
                while (num > 1)
                {
                    num -= 2;
                }
                num *= -1;
                num += i;
                for (int k = num; k < (num + 2); k++)
                {
                    for (int m = num2; m < (num2 + 2); m++)
                    {
                        if (Main.tile[k, m] == null)
                        {
                            Main.tile[k, m] = new Tile();
                        }
                        int num5 = Main.tile[k, m].frameX / 0x12;
                        while (num5 > 1)
                        {
                            num5 -= 2;
                        }
                        if ((!Main.tile[k, m].active || (Main.tile[k, m].type != type)) || ((num5 != (k - num)) || (Main.tile[k, m].frameY != ((m - num2) * 0x12))))
                        {
                            flag = true;
                        }
                    }
                    if (Main.tile[k, num2 + 2] == null)
                    {
                        Main.tile[k, num2 + 2] = new Tile();
                    }
                    if (!Main.tile[k, num2 + 2].active || !Main.tileSolid[Main.tile[k, num2 + 2].type])
                    {
                        flag = true;
                    }
                }
                if (flag)
                {
                    int num6 = 0x30;
                    if (Main.tile[i, j].frameX >= 0xd8)
                    {
                        num6 = 0x15c;
                    }
                    else if (Main.tile[i, j].frameX >= 180)
                    {
                        num6 = 0x157;
                    }
                    else if (Main.tile[i, j].frameX >= 0x6c)
                    {
                        num6 = 0x148;
                    }
                    else if (Main.tile[i, j].frameX >= 0x24)
                    {
                        num6 = 0x132;
                    }
                    destroyObject = true;
                    for (int n = num; n < (num + 2); n++)
                    {
                        for (int num8 = num2; num8 < (num2 + 3); num8++)
                        {
                            if ((Main.tile[n, num8].type == type) && Main.tile[n, num8].active)
                            {
                                Chest.DestroyChest(n, num8);
                                KillTile(n, num8, false, false, false);
                            }
                        }
                    }
                    Item.NewItem(i * 0x10, j * 0x10, 0x20, 0x20, num6, 1, false);
                    destroyObject = false;
                }
            }
        }

        public static void CheckOnTable1x1(int x, int y, int type)
        {
            if ((Main.tile[x, y + 1] != null) && (!Main.tile[x, y + 1].active || !Main.tileTable[Main.tile[x, y + 1].type]))
            {
                if (type == 0x4e)
                {
                    if (!Main.tile[x, y + 1].active || !Main.tileSolid[Main.tile[x, y + 1].type])
                    {
                        KillTile(x, y, false, false, false);
                    }
                }
                else
                {
                    KillTile(x, y, false, false, false);
                }
            }
        }

        public static void CheckPot(int i, int j, int type = 0x1c)
        {
            if (!destroyObject)
            {
                bool flag = false;
                int num = 0;
                int num2 = j;
                num += Main.tile[i, j].frameX / 0x12;
                num2 += (Main.tile[i, j].frameY / 0x12) * -1;
                while (num > 1)
                {
                    num -= 2;
                }
                num *= -1;
                num += i;
                for (int k = num; k < (num + 2); k++)
                {
                    for (int m = num2; m < (num2 + 2); m++)
                    {
                        if (Main.tile[k, m] == null)
                        {
                            Main.tile[k, m] = new Tile();
                        }
                        int num5 = Main.tile[k, m].frameX / 0x12;
                        while (num5 > 1)
                        {
                            num5 -= 2;
                        }
                        if ((!Main.tile[k, m].active || (Main.tile[k, m].type != type)) || ((num5 != (k - num)) || (Main.tile[k, m].frameY != ((m - num2) * 0x12))))
                        {
                            flag = true;
                        }
                    }
                    if (Main.tile[k, num2 + 2] == null)
                    {
                        Main.tile[k, num2 + 2] = new Tile();
                    }
                    if (!Main.tile[k, num2 + 2].active || !Main.tileSolid[Main.tile[k, num2 + 2].type])
                    {
                        flag = true;
                    }
                }
                if (flag)
                {
                    destroyObject = true;
                    Main.PlaySound(13, i * 0x10, j * 0x10, 1);
                    for (int n = num; n < (num + 2); n++)
                    {
                        for (int num7 = num2; num7 < (num2 + 2); num7++)
                        {
                            if ((Main.tile[n, num7].type == type) && Main.tile[n, num7].active)
                            {
                                KillTile(n, num7, false, false, false);
                            }
                        }
                    }
                    Gore.NewGore(new Vector2((float) (i * 0x10), (float) (j * 0x10)), new Vector2(), 0x33, 1f);
                    Gore.NewGore(new Vector2((float) (i * 0x10), (float) (j * 0x10)), new Vector2(), 0x34, 1f);
                    Gore.NewGore(new Vector2((float) (i * 0x10), (float) (j * 0x10)), new Vector2(), 0x35, 1f);
                    if ((genRand.Next(0x2d) == 0) && (((Main.tile[num, num2].wall == 7) || (Main.tile[num, num2].wall == 8)) || (Main.tile[num, num2].wall == 9)))
                    {
                        Item.NewItem(i * 0x10, j * 0x10, 0x10, 0x10, 0x147, 1, false);
                    }
                    else if (genRand.Next(0x2d) == 0)
                    {
                        if (j < Main.worldSurface)
                        {
                            switch (genRand.Next(4))
                            {
                                case 0:
                                    Item.NewItem(i * 0x10, j * 0x10, 0x10, 0x10, 0x124, 1, false);
                                    break;

                                case 1:
                                    Item.NewItem(i * 0x10, j * 0x10, 0x10, 0x10, 0x12a, 1, false);
                                    break;

                                case 2:
                                    Item.NewItem(i * 0x10, j * 0x10, 0x10, 0x10, 0x12b, 1, false);
                                    break;

                                case 3:
                                    Item.NewItem(i * 0x10, j * 0x10, 0x10, 0x10, 290, 1, false);
                                    break;
                            }
                        }
                        else if (j < Main.rockLayer)
                        {
                            switch (genRand.Next(7))
                            {
                                case 0:
                                    Item.NewItem(i * 0x10, j * 0x10, 0x10, 0x10, 0x121, 1, false);
                                    break;

                                case 1:
                                    Item.NewItem(i * 0x10, j * 0x10, 0x10, 0x10, 0x12a, 1, false);
                                    break;

                                case 2:
                                    Item.NewItem(i * 0x10, j * 0x10, 0x10, 0x10, 0x12b, 1, false);
                                    break;

                                case 3:
                                    Item.NewItem(i * 0x10, j * 0x10, 0x10, 0x10, 290, 1, false);
                                    break;

                                case 4:
                                    Item.NewItem(i * 0x10, j * 0x10, 0x10, 0x10, 0x12f, 1, false);
                                    break;

                                case 5:
                                    Item.NewItem(i * 0x10, j * 0x10, 0x10, 0x10, 0x123, 1, false);
                                    break;

                                case 6:
                                    Item.NewItem(i * 0x10, j * 0x10, 0x10, 0x10, 0x130, 1, false);
                                    break;
                            }
                        }
                        else if (j < (Main.maxTilesY - 200))
                        {
                            switch (genRand.Next(10))
                            {
                                case 0:
                                    Item.NewItem(i * 0x10, j * 0x10, 0x10, 0x10, 0x128, 1, false);
                                    break;

                                case 1:
                                    Item.NewItem(i * 0x10, j * 0x10, 0x10, 0x10, 0x127, 1, false);
                                    break;

                                case 2:
                                    Item.NewItem(i * 0x10, j * 0x10, 0x10, 0x10, 0x12b, 1, false);
                                    break;

                                case 3:
                                    Item.NewItem(i * 0x10, j * 0x10, 0x10, 0x10, 0x12e, 1, false);
                                    break;

                                case 4:
                                    Item.NewItem(i * 0x10, j * 0x10, 0x10, 0x10, 0x12f, 1, false);
                                    break;

                                case 5:
                                    Item.NewItem(i * 0x10, j * 0x10, 0x10, 0x10, 0x131, 1, false);
                                    break;

                                case 6:
                                    Item.NewItem(i * 0x10, j * 0x10, 0x10, 0x10, 0x12d, 1, false);
                                    break;

                                case 7:
                                    Item.NewItem(i * 0x10, j * 0x10, 0x10, 0x10, 0x12e, 1, false);
                                    break;

                                case 8:
                                    Item.NewItem(i * 0x10, j * 0x10, 0x10, 0x10, 0x129, 1, false);
                                    break;

                                case 9:
                                    Item.NewItem(i * 0x10, j * 0x10, 0x10, 0x10, 0x130, 1, false);
                                    break;
                            }
                        }
                        else
                        {
                            switch (genRand.Next(12))
                            {
                                case 0:
                                    Item.NewItem(i * 0x10, j * 0x10, 0x10, 0x10, 0x128, 1, false);
                                    break;

                                case 1:
                                    Item.NewItem(i * 0x10, j * 0x10, 0x10, 0x10, 0x127, 1, false);
                                    break;

                                case 2:
                                    Item.NewItem(i * 0x10, j * 0x10, 0x10, 0x10, 0x125, 1, false);
                                    break;

                                case 3:
                                    Item.NewItem(i * 0x10, j * 0x10, 0x10, 0x10, 0x120, 1, false);
                                    break;

                                case 4:
                                    Item.NewItem(i * 0x10, j * 0x10, 0x10, 0x10, 0x126, 1, false);
                                    break;

                                case 5:
                                    Item.NewItem(i * 0x10, j * 0x10, 0x10, 0x10, 0x129, 1, false);
                                    break;

                                case 6:
                                    Item.NewItem(i * 0x10, j * 0x10, 0x10, 0x10, 0x130, 1, false);
                                    break;

                                case 7:
                                    Item.NewItem(i * 0x10, j * 0x10, 0x10, 0x10, 0x131, 1, false);
                                    break;

                                case 8:
                                    Item.NewItem(i * 0x10, j * 0x10, 0x10, 0x10, 0x12d, 1, false);
                                    break;

                                case 9:
                                    Item.NewItem(i * 0x10, j * 0x10, 0x10, 0x10, 0x12e, 1, false);
                                    break;

                                case 10:
                                    Item.NewItem(i * 0x10, j * 0x10, 0x10, 0x10, 0x120, 1, false);
                                    break;

                                case 11:
                                    Item.NewItem(i * 0x10, j * 0x10, 0x10, 0x10, 300, 1, false);
                                    break;
                            }
                        }
                    }
                    else
                    {
                        int num12 = Main.rand.Next(8);
                        if ((num12 == 0) && (Main.player[Player.FindClosest(new Vector2((float) (i * 0x10), (float) (j * 0x10)), 0x10, 0x10)].statLife < Main.player[Player.FindClosest(new Vector2((float) (i * 0x10), (float) (j * 0x10)), 0x10, 0x10)].statLifeMax))
                        {
                            Item.NewItem(i * 0x10, j * 0x10, 0x10, 0x10, 0x3a, 1, false);
                        }
                        else if ((num12 == 1) && (Main.player[Player.FindClosest(new Vector2((float) (i * 0x10), (float) (j * 0x10)), 0x10, 0x10)].statMana < Main.player[Player.FindClosest(new Vector2((float) (i * 0x10), (float) (j * 0x10)), 0x10, 0x10)].statManaMax))
                        {
                            Item.NewItem(i * 0x10, j * 0x10, 0x10, 0x10, 0xb8, 1, false);
                        }
                        else if (num12 == 2)
                        {
                            int stack = Main.rand.Next(1, 6);
                            if (Main.tile[i, j].liquid > 0)
                            {
                                Item.NewItem(i * 0x10, j * 0x10, 0x10, 0x10, 0x11a, stack, false);
                            }
                            else
                            {
                                Item.NewItem(i * 0x10, j * 0x10, 0x10, 0x10, 8, stack, false);
                            }
                        }
                        else if (num12 == 3)
                        {
                            int num14 = Main.rand.Next(8) + 3;
                            int num15 = 40;
                            if (j > (Main.maxTilesY - 200))
                            {
                                num15 = 0x109;
                            }
                            if ((j < Main.rockLayer) && (genRand.Next(2) == 0))
                            {
                                num15 = 0x2a;
                            }
                            Item.NewItem(i * 0x10, j * 0x10, 0x10, 0x10, num15, num14, false);
                        }
                        else if (num12 == 4)
                        {
                            int num16 = 0x1c;
                            if (j > (Main.maxTilesY - 200))
                            {
                                num16 = 0xbc;
                            }
                            Item.NewItem(i * 0x10, j * 0x10, 0x10, 0x10, num16, 1, false);
                        }
                        else if ((num12 == 5) && (j > Main.rockLayer))
                        {
                            int num17 = Main.rand.Next(4) + 1;
                            Item.NewItem(i * 0x10, j * 0x10, 0x10, 0x10, 0xa6, num17, false);
                        }
                        else
                        {
                            float num18 = 200 + genRand.Next(-100, 0x65);
                            if (j < Main.worldSurface)
                            {
                                num18 *= 0.5f;
                            }
                            else if (j < Main.rockLayer)
                            {
                                num18 *= 0.75f;
                            }
                            else if (j > (Main.maxTilesY - 250))
                            {
                                num18 *= 1.25f;
                            }
                            num18 *= 1f + (Main.rand.Next(-20, 0x15) * 0.01f);
                            if (Main.rand.Next(5) == 0)
                            {
                                num18 *= 1f + (Main.rand.Next(5, 11) * 0.01f);
                            }
                            if (Main.rand.Next(10) == 0)
                            {
                                num18 *= 1f + (Main.rand.Next(10, 0x15) * 0.01f);
                            }
                            if (Main.rand.Next(15) == 0)
                            {
                                num18 *= 1f + (Main.rand.Next(20, 0x29) * 0.01f);
                            }
                            if (Main.rand.Next(20) == 0)
                            {
                                num18 *= 1f + (Main.rand.Next(40, 0x51) * 0.01f);
                            }
                            if (Main.rand.Next(0x19) == 0)
                            {
                                num18 *= 1f + (Main.rand.Next(50, 0x65) * 0.01f);
                            }
                            while (((int) num18) > 0)
                            {
                                if (num18 > 1000000f)
                                {
                                    int num19 = (int) (num18 / 1000000f);
                                    if ((num19 > 50) && (Main.rand.Next(2) == 0))
                                    {
                                        num19 /= Main.rand.Next(3) + 1;
                                    }
                                    if (Main.rand.Next(2) == 0)
                                    {
                                        num19 /= Main.rand.Next(3) + 1;
                                    }
                                    num18 -= 0xf4240 * num19;
                                    Item.NewItem(i * 0x10, j * 0x10, 0x10, 0x10, 0x4a, num19, false);
                                }
                                else
                                {
                                    if (num18 > 10000f)
                                    {
                                        int num20 = (int) (num18 / 10000f);
                                        if ((num20 > 50) && (Main.rand.Next(2) == 0))
                                        {
                                            num20 /= Main.rand.Next(3) + 1;
                                        }
                                        if (Main.rand.Next(2) == 0)
                                        {
                                            num20 /= Main.rand.Next(3) + 1;
                                        }
                                        num18 -= 0x2710 * num20;
                                        Item.NewItem(i * 0x10, j * 0x10, 0x10, 0x10, 0x49, num20, false);
                                        continue;
                                    }
                                    if (num18 > 100f)
                                    {
                                        int num21 = (int) (num18 / 100f);
                                        if ((num21 > 50) && (Main.rand.Next(2) == 0))
                                        {
                                            num21 /= Main.rand.Next(3) + 1;
                                        }
                                        if (Main.rand.Next(2) == 0)
                                        {
                                            num21 /= Main.rand.Next(3) + 1;
                                        }
                                        num18 -= 100 * num21;
                                        Item.NewItem(i * 0x10, j * 0x10, 0x10, 0x10, 0x48, num21, false);
                                        continue;
                                    }
                                    int num22 = (int) num18;
                                    if ((num22 > 50) && (Main.rand.Next(2) == 0))
                                    {
                                        num22 /= Main.rand.Next(3) + 1;
                                    }
                                    if (Main.rand.Next(2) == 0)
                                    {
                                        num22 /= Main.rand.Next(4) + 1;
                                    }
                                    if (num22 < 1)
                                    {
                                        num22 = 1;
                                    }
                                    num18 -= num22;
                                    Item.NewItem(i * 0x10, j * 0x10, 0x10, 0x10, 0x47, num22, false);
                                }
                            }
                        }
                    }
                    destroyObject = false;
                }
            }
        }

        public static void CheckRoom(int x, int y)
        {
            if (canSpawn)
            {
                if (((x < 10) || (y < 10)) || ((x >= (Main.maxTilesX - 10)) || (y >= (lastMaxTilesY - 10))))
                {
                    canSpawn = false;
                }
                else
                {
                    for (int i = 0; i < numRoomTiles; i++)
                    {
                        if ((roomX[i] == x) && (roomY[i] == y))
                        {
                            return;
                        }
                    }
                    roomX[numRoomTiles] = x;
                    roomY[numRoomTiles] = y;
                    numRoomTiles++;
                    if (numRoomTiles >= maxRoomTiles)
                    {
                        canSpawn = false;
                    }
                    else
                    {
                        if (Main.tile[x, y].active)
                        {
                            houseTile[Main.tile[x, y].type] = true;
                            if (Main.tileSolid[Main.tile[x, y].type] || (Main.tile[x, y].type == 11))
                            {
                                return;
                            }
                        }
                        if (x < roomX1)
                        {
                            roomX1 = x;
                        }
                        if (x > roomX2)
                        {
                            roomX2 = x;
                        }
                        if (y < roomY1)
                        {
                            roomY1 = y;
                        }
                        if (y > roomY2)
                        {
                            roomY2 = y;
                        }
                        bool flag = false;
                        bool flag2 = false;
                        for (int j = -2; j < 3; j++)
                        {
                            if (Main.wallHouse[Main.tile[x + j, y].wall])
                            {
                                flag = true;
                            }
                            if (Main.tile[x + j, y].active && (Main.tileSolid[Main.tile[x + j, y].type] || (Main.tile[x + j, y].type == 11)))
                            {
                                flag = true;
                            }
                            if (Main.wallHouse[Main.tile[x, y + j].wall])
                            {
                                flag2 = true;
                            }
                            if (Main.tile[x, y + j].active && (Main.tileSolid[Main.tile[x, y + j].type] || (Main.tile[x, y + j].type == 11)))
                            {
                                flag2 = true;
                            }
                        }
                        if (!flag || !flag2)
                        {
                            canSpawn = false;
                        }
                        else
                        {
                            for (int k = x - 1; k < (x + 2); k++)
                            {
                                for (int m = y - 1; m < (y + 2); m++)
                                {
                                    if (((k != x) || (m != y)) && canSpawn)
                                    {
                                        CheckRoom(k, m);
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

        public static void CheckSign(int x, int y, int type)
        {
            if (!destroyObject)
            {
                int num = x - 2;
                int num2 = x + 3;
                int num3 = y - 2;
                int num4 = y + 3;
                if ((((num >= 0) && (num2 <= Main.maxTilesX)) && (num3 >= 0)) && (num4 <= Main.maxTilesY))
                {
                    bool flag = false;
                    for (int i = num; i < num2; i++)
                    {
                        for (int k = num3; k < num4; k++)
                        {
                            if (Main.tile[i, k] == null)
                            {
                                Main.tile[i, k] = new Tile();
                            }
                        }
                    }
                    int num7 = Main.tile[x, y].frameX / 0x12;
                    int num8 = Main.tile[x, y].frameY / 0x12;
                    while (num7 > 1)
                    {
                        num7 -= 2;
                    }
                    int num9 = x - num7;
                    int num10 = y - num8;
                    int num11 = (Main.tile[num9, num10].frameX / 0x12) / 2;
                    num = num9;
                    num2 = num9 + 2;
                    num3 = num10;
                    num4 = num10 + 2;
                    num7 = 0;
                    for (int j = num; j < num2; j++)
                    {
                        num8 = 0;
                        for (int m = num3; m < num4; m++)
                        {
                            if (!Main.tile[j, m].active || (Main.tile[j, m].type != type))
                            {
                                flag = true;
                                goto Label_017B;
                            }
                            if (((Main.tile[j, m].frameX / 0x12) != (num7 + (num11 * 2))) || ((Main.tile[j, m].frameY / 0x12) != num8))
                            {
                                flag = true;
                                goto Label_017B;
                            }
                            num8++;
                        }
                    Label_017B:
                        num7++;
                    }
                    if (!flag)
                    {
                        if (type == 0x55)
                        {
                            if ((Main.tile[num9, num10 + 2].active && Main.tileSolid[Main.tile[num9, num10 + 2].type]) && (Main.tile[num9 + 1, num10 + 2].active && Main.tileSolid[Main.tile[num9 + 1, num10 + 2].type]))
                            {
                                num11 = 0;
                            }
                            else
                            {
                                flag = true;
                            }
                        }
                        else if ((Main.tile[num9, num10 + 2].active && Main.tileSolid[Main.tile[num9, num10 + 2].type]) && (Main.tile[num9 + 1, num10 + 2].active && Main.tileSolid[Main.tile[num9 + 1, num10 + 2].type]))
                        {
                            num11 = 0;
                        }
                        else if (((Main.tile[num9, num10 - 1].active && Main.tileSolid[Main.tile[num9, num10 - 1].type]) && (!Main.tileSolidTop[Main.tile[num9, num10 - 1].type] && Main.tile[num9 + 1, num10 - 1].active)) && (Main.tileSolid[Main.tile[num9 + 1, num10 - 1].type] && !Main.tileSolidTop[Main.tile[num9 + 1, num10 - 1].type]))
                        {
                            num11 = 1;
                        }
                        else if (((Main.tile[num9 - 1, num10].active && Main.tileSolid[Main.tile[num9 - 1, num10].type]) && (!Main.tileSolidTop[Main.tile[num9 - 1, num10].type] && Main.tile[num9 - 1, num10 + 1].active)) && (Main.tileSolid[Main.tile[num9 - 1, num10 + 1].type] && !Main.tileSolidTop[Main.tile[num9 - 1, num10 + 1].type]))
                        {
                            num11 = 2;
                        }
                        else if (((Main.tile[num9 + 2, num10].active && Main.tileSolid[Main.tile[num9 + 2, num10].type]) && (!Main.tileSolidTop[Main.tile[num9 + 2, num10].type] && Main.tile[num9 + 2, num10 + 1].active)) && (Main.tileSolid[Main.tile[num9 + 2, num10 + 1].type] && !Main.tileSolidTop[Main.tile[num9 + 2, num10 + 1].type]))
                        {
                            num11 = 3;
                        }
                        else
                        {
                            flag = true;
                        }
                    }
                    if (flag)
                    {
                        destroyObject = true;
                        for (int n = num; n < num2; n++)
                        {
                            for (int num15 = num3; num15 < num4; num15++)
                            {
                                if (Main.tile[n, num15].type == type)
                                {
                                    KillTile(n, num15, false, false, false);
                                }
                            }
                        }
                        Sign.KillSign(num9, num10);
                        if (type == 0x55)
                        {
                            Item.NewItem(x * 0x10, y * 0x10, 0x20, 0x20, 0x141, 1, false);
                        }
                        else
                        {
                            Item.NewItem(x * 0x10, y * 0x10, 0x20, 0x20, 0xab, 1, false);
                        }
                        destroyObject = false;
                    }
                    else
                    {
                        int num16 = 0x24 * num11;
                        for (int num17 = 0; num17 < 2; num17++)
                        {
                            for (int num18 = 0; num18 < 2; num18++)
                            {
                                Main.tile[num9 + num17, num10 + num18].active = true;
                                Main.tile[num9 + num17, num10 + num18].type = (byte) type;
                                Main.tile[num9 + num17, num10 + num18].frameX = (short) (num16 + (0x12 * num17));
                                Main.tile[num9 + num17, num10 + num18].frameY = (short) (0x12 * num18);
                            }
                        }
                    }
                }
            }
        }

        public static void CheckSunflower(int i, int j, int type = 0x1b)
        {
            if (!destroyObject)
            {
                bool flag = false;
                int num = 0;
                int num2 = j;
                num += Main.tile[i, j].frameX / 0x12;
                num2 += (Main.tile[i, j].frameY / 0x12) * -1;
                while (num > 1)
                {
                    num -= 2;
                }
                num *= -1;
                num += i;
                for (int k = num; k < (num + 2); k++)
                {
                    for (int m = num2; m < (num2 + 4); m++)
                    {
                        if (Main.tile[k, m] == null)
                        {
                            Main.tile[k, m] = new Tile();
                        }
                        int num5 = Main.tile[k, m].frameX / 0x12;
                        while (num5 > 1)
                        {
                            num5 -= 2;
                        }
                        if ((!Main.tile[k, m].active || (Main.tile[k, m].type != type)) || ((num5 != (k - num)) || (Main.tile[k, m].frameY != ((m - num2) * 0x12))))
                        {
                            flag = true;
                        }
                    }
                    if (Main.tile[k, num2 + 4] == null)
                    {
                        Main.tile[k, num2 + 4] = new Tile();
                    }
                    if (!Main.tile[k, num2 + 4].active || (Main.tile[k, num2 + 4].type != 2))
                    {
                        flag = true;
                    }
                }
                if (flag)
                {
                    destroyObject = true;
                    for (int n = num; n < (num + 2); n++)
                    {
                        for (int num7 = num2; num7 < (num2 + 4); num7++)
                        {
                            if ((Main.tile[n, num7].type == type) && Main.tile[n, num7].active)
                            {
                                KillTile(n, num7, false, false, false);
                            }
                        }
                    }
                    Item.NewItem(i * 0x10, j * 0x10, 0x20, 0x20, 0x3f, 1, false);
                    destroyObject = false;
                }
            }
        }

        public static void clearWorld()
        {
            Main.trashItem = new Item();
            spawnEye = false;
            spawnNPC = 0;
            shadowOrbCount = 0;
            Main.helpText = 0;
            Main.dungeonX = 0;
            Main.dungeonY = 0;
            NPC.downedBoss1 = false;
            NPC.downedBoss2 = false;
            NPC.downedBoss3 = false;
            shadowOrbSmashed = false;
            spawnMeteor = false;
            stopDrops = false;
            Main.invasionDelay = 0;
            Main.invasionType = 0;
            Main.invasionSize = 0;
            Main.invasionWarn = 0;
            Main.invasionX = 0.0;
            noLiquidCheck = false;
            Liquid.numLiquid = 0;
            LiquidBuffer.numLiquidBuffer = 0;
            if (((Main.netMode == 1) || (lastMaxTilesX > Main.maxTilesX)) || (lastMaxTilesY > Main.maxTilesY))
            {
                for (int num = 0; num < lastMaxTilesX; num++)
                {
                    float num2 = ((float) num) / ((float) lastMaxTilesX);
                    Main.statusText = "Freeing unused resources: " + ((int) ((num2 * 100f) + 1f)) + "%";
                    for (int num3 = 0; num3 < lastMaxTilesY; num3++)
                    {
                        Main.tile[num, num3] = null;
                    }
                }
            }
            lastMaxTilesX = Main.maxTilesX;
            lastMaxTilesY = Main.maxTilesY;
            if (Main.netMode != 1)
            {
                for (int num4 = 0; num4 < Main.maxTilesX; num4++)
                {
                    float num5 = ((float) num4) / ((float) Main.maxTilesX);
                    //Main.statusText = "Resetting game objects: " + ((int) ((num5 * 100f) + 1f)) + "%";
                    for (int num6 = 0; num6 < Main.maxTilesY; num6++)
                    {
                        Main.tile[num4, num6] = new Tile();
                    }
                }
            }
            for (int i = 0; i < 0x3e8; i++)
            {
                Main.dust[i] = new Dust();
            }
            for (int j = 0; j < 200; j++)
            {
                Main.gore[j] = new Gore();
            }
            for (int k = 0; k < 200; k++)
            {
                Main.item[k] = new Item();
            }
            for (int m = 0; m < 0x3e8; m++)
            {
                Main.npc[m] = new NPC();
            }
            for (int n = 0; n < 0x3e8; n++)
            {
                Main.projectile[n] = new Projectile();
            }
            for (int num12 = 0; num12 < 0x3e8; num12++)
            {
                Main.chest[num12] = null;
            }
            for (int num13 = 0; num13 < 0x3e8; num13++)
            {
                Main.sign[num13] = null;
            }
            for (int num14 = 0; num14 < Liquid.resLiquid; num14++)
            {
                Main.liquid[num14] = new Liquid();
            }
            for (int num15 = 0; num15 < 0x2710; num15++)
            {
                Main.liquidBuffer[num15] = new LiquidBuffer();
            }
            setWorldSize();
            worldCleared = true;
        }

        public static bool CloseDoor(int i, int j, bool forced = false)
        {
            int num = 0;
            int num2 = i;
            int num3 = j;
            if (Main.tile[i, j] == null)
            {
                Main.tile[i, j] = new Tile();
            }
            int frameX = Main.tile[i, j].frameX;
            int frameY = Main.tile[i, j].frameY;
            switch (frameX)
            {
                case 0:
                    num2 = i;
                    num = 1;
                    break;

                case 0x12:
                    num2 = i - 1;
                    num = 1;
                    break;

                case 0x24:
                    num2 = i + 1;
                    num = -1;
                    break;

                case 0x36:
                    num2 = i;
                    num = -1;
                    break;
            }
            switch (frameY)
            {
                case 0:
                    num3 = j;
                    break;

                case 0x12:
                    num3 = j - 1;
                    break;

                case 0x24:
                    num3 = j - 2;
                    break;
            }
            int num6 = num2;
            if (num == -1)
            {
                num6 = num2 - 1;
            }
            if (!forced)
            {
                for (int n = num3; n < (num3 + 3); n++)
                {
                    if (!Collision.EmptyTile(num2, n, true))
                    {
                        return false;
                    }
                }
            }
            for (int k = num6; k < (num6 + 2); k++)
            {
                for (int num9 = num3; num9 < (num3 + 3); num9++)
                {
                    if (k == num2)
                    {
                        if (Main.tile[k, num9] == null)
                        {
                            Main.tile[k, num9] = new Tile();
                        }
                        Main.tile[k, num9].type = 10;
                        Main.tile[k, num9].frameX = (short) (genRand.Next(3) * 0x12);
                    }
                    else
                    {
                        if (Main.tile[k, num9] == null)
                        {
                            Main.tile[k, num9] = new Tile();
                        }
                        Main.tile[k, num9].active = false;
                    }
                }
            }
            for (int m = num2 - 1; m <= (num2 + 1); m++)
            {
                for (int num11 = num3 - 1; num11 <= (num3 + 2); num11++)
                {
                    TileFrame(m, num11, false, false);
                }
            }
            Main.PlaySound(9, i * 0x10, j * 0x10, 1);
            return true;
        }

        public static void CreateNewWorld()
        {
            ThreadPool.QueueUserWorkItem(new WaitCallback(WorldGen.worldGenCallBack), 1);
        }

        public static void dropMeteor()
        {
            bool flag = true;
            int num = 0;
            if (Main.netMode != 1)
            {
                for (int i = 0; i < 0xff; i++)
                {
                    if (Main.player[i].active)
                    {
                        flag = false;
                        break;
                    }
                }
                int num3 = 0;
                float num4 = Main.maxTilesX / 0x1068;
                int num5 = (int) (400f * num4);
                for (int j = 5; j < (Main.maxTilesX - 5); j++)
                {
                    for (int k = 5; k < Main.worldSurface; k++)
                    {
                        if (Main.tile[j, k].active && (Main.tile[j, k].type == 0x25))
                        {
                            num3++;
                            if (num3 > num5)
                            {
                                return;
                            }
                        }
                    }
                }
                while (!flag)
                {
                    float num8 = Main.maxTilesX * 0.08f;
                    int num9 = Main.rand.Next(50, Main.maxTilesX - 50);
                    while ((num9 > (Main.spawnTileX - num8)) && (num9 < (Main.spawnTileX + num8)))
                    {
                        num9 = Main.rand.Next(50, Main.maxTilesX - 50);
                    }
                    for (int m = Main.rand.Next(100); m < Main.maxTilesY; m++)
                    {
                        if (Main.tile[num9, m].active && Main.tileSolid[Main.tile[num9, m].type])
                        {
                            flag = meteor(num9, m);
                            break;
                        }
                    }
                    num++;
                    if (num >= 100)
                    {
                        return;
                    }
                }
            }
        }

        public static void DungeonEnt(int i, int j, int tileType, int wallType)
        {
            Vector2 vector;
            int num = 60;
            for (int k = i - num; k < (i + num); k++)
            {
                for (int num3 = j - num; num3 < (j + num); num3++)
                {
                    Main.tile[k, num3].liquid = 0;
                    Main.tile[k, num3].lava = false;
                }
            }
            double num8 = dxStrength1;
            double num9 = dyStrength1;
            vector.X = i;
            vector.Y = j - (((float) num9) / 2f);
            dMinY = (int) vector.Y;
            int num10 = 1;
            if (i > (Main.maxTilesX / 2))
            {
                num10 = -1;
            }
            int num4 = ((int) (vector.X - (num8 * 0.60000002384185791))) - genRand.Next(2, 5);
            int maxTilesX = ((int) (vector.X + (num8 * 0.60000002384185791))) + genRand.Next(2, 5);
            int num5 = ((int) (vector.Y - (num9 * 0.60000002384185791))) - genRand.Next(2, 5);
            int maxTilesY = ((int) (vector.Y + (num9 * 0.60000002384185791))) + genRand.Next(8, 0x10);
            if (num4 < 0)
            {
                num4 = 0;
            }
            if (maxTilesX > Main.maxTilesX)
            {
                maxTilesX = Main.maxTilesX;
            }
            if (num5 < 0)
            {
                num5 = 0;
            }
            if (maxTilesY > Main.maxTilesY)
            {
                maxTilesY = Main.maxTilesY;
            }
            for (int m = num4; m < maxTilesX; m++)
            {
                for (int num12 = num5; num12 < maxTilesY; num12++)
                {
                    Main.tile[m, num12].liquid = 0;
                    if (Main.tile[m, num12].wall != wallType)
                    {
                        Main.tile[m, num12].wall = 0;
                        if (((m > (num4 + 1)) && (m < (maxTilesX - 2))) && ((num12 > (num5 + 1)) && (num12 < (maxTilesY - 2))))
                        {
                            PlaceWall(m, num12, wallType, true);
                        }
                        Main.tile[m, num12].active = true;
                        Main.tile[m, num12].type = (byte) tileType;
                    }
                }
            }
            int num13 = num4;
            int num14 = (num4 + 5) + genRand.Next(4);
            int num15 = (num5 - 3) - genRand.Next(3);
            int num16 = num5;
            for (int n = num13; n < num14; n++)
            {
                for (int num18 = num15; num18 < num16; num18++)
                {
                    if (Main.tile[n, num18].wall != wallType)
                    {
                        Main.tile[n, num18].active = true;
                        Main.tile[n, num18].type = (byte) tileType;
                    }
                }
            }
            num13 = (maxTilesX - 5) - genRand.Next(4);
            num14 = maxTilesX;
            num15 = (num5 - 3) - genRand.Next(3);
            num16 = num5;
            for (int num19 = num13; num19 < num14; num19++)
            {
                for (int num20 = num15; num20 < num16; num20++)
                {
                    if (Main.tile[num19, num20].wall != wallType)
                    {
                        Main.tile[num19, num20].active = true;
                        Main.tile[num19, num20].type = (byte) tileType;
                    }
                }
            }
            int num21 = 1 + genRand.Next(2);
            int num22 = 2 + genRand.Next(4);
            int num23 = 0;
            for (int num24 = num4; num24 < maxTilesX; num24++)
            {
                for (int num25 = num5 - num21; num25 < num5; num25++)
                {
                    if (Main.tile[num24, num25].wall != wallType)
                    {
                        Main.tile[num24, num25].active = true;
                        Main.tile[num24, num25].type = (byte) tileType;
                    }
                }
                num23++;
                if (num23 >= num22)
                {
                    num24 += num22;
                    num23 = 0;
                }
            }
            for (int num26 = num4; num26 < maxTilesX; num26++)
            {
                for (int num27 = maxTilesY; num27 < (maxTilesY + 100); num27++)
                {
                    PlaceWall(num26, num27, 2, true);
                }
            }
            num4 = (int) (vector.X - (num8 * 0.60000002384185791));
            maxTilesX = (int) (vector.X + (num8 * 0.60000002384185791));
            num5 = (int) (vector.Y - (num9 * 0.60000002384185791));
            maxTilesY = (int) (vector.Y + (num9 * 0.60000002384185791));
            if (num4 < 0)
            {
                num4 = 0;
            }
            if (maxTilesX > Main.maxTilesX)
            {
                maxTilesX = Main.maxTilesX;
            }
            if (num5 < 0)
            {
                num5 = 0;
            }
            if (maxTilesY > Main.maxTilesY)
            {
                maxTilesY = Main.maxTilesY;
            }
            for (int num28 = num4; num28 < maxTilesX; num28++)
            {
                for (int num29 = num5; num29 < maxTilesY; num29++)
                {
                    PlaceWall(num28, num29, wallType, true);
                }
            }
            num4 = (int) ((vector.X - (num8 * 0.6)) - 1.0);
            maxTilesX = (int) ((vector.X + (num8 * 0.6)) + 1.0);
            num5 = (int) ((vector.Y - (num9 * 0.6)) - 1.0);
            maxTilesY = (int) ((vector.Y + (num9 * 0.6)) + 1.0);
            if (num4 < 0)
            {
                num4 = 0;
            }
            if (maxTilesX > Main.maxTilesX)
            {
                maxTilesX = Main.maxTilesX;
            }
            if (num5 < 0)
            {
                num5 = 0;
            }
            if (maxTilesY > Main.maxTilesY)
            {
                maxTilesY = Main.maxTilesY;
            }
            for (int num30 = num4; num30 < maxTilesX; num30++)
            {
                for (int num31 = num5; num31 < maxTilesY; num31++)
                {
                    Main.tile[num30, num31].wall = (byte) wallType;
                }
            }
            num4 = (int) (vector.X - (num8 * 0.5));
            maxTilesX = (int) (vector.X + (num8 * 0.5));
            num5 = (int) (vector.Y - (num9 * 0.5));
            maxTilesY = (int) (vector.Y + (num9 * 0.5));
            if (num4 < 0)
            {
                num4 = 0;
            }
            if (maxTilesX > Main.maxTilesX)
            {
                maxTilesX = Main.maxTilesX;
            }
            if (num5 < 0)
            {
                num5 = 0;
            }
            if (maxTilesY > Main.maxTilesY)
            {
                maxTilesY = Main.maxTilesY;
            }
            for (int num32 = num4; num32 < maxTilesX; num32++)
            {
                for (int num33 = num5; num33 < maxTilesY; num33++)
                {
                    Main.tile[num32, num33].active = false;
                    Main.tile[num32, num33].wall = (byte) wallType;
                }
            }
            DPlatX[numDPlats] = (int) vector.X;
            DPlatY[numDPlats] = maxTilesY;
            numDPlats++;
            vector.X += (((float) num8) * 0.6f) * num10;
            vector.Y += ((float) num9) * 0.5f;
            num8 = dxStrength2;
            num9 = dyStrength2;
            vector.X += (((float) num8) * 0.55f) * num10;
            vector.Y -= ((float) num9) * 0.5f;
            num4 = ((int) (vector.X - (num8 * 0.60000002384185791))) - genRand.Next(1, 3);
            maxTilesX = ((int) (vector.X + (num8 * 0.60000002384185791))) + genRand.Next(1, 3);
            num5 = ((int) (vector.Y - (num9 * 0.60000002384185791))) - genRand.Next(1, 3);
            maxTilesY = ((int) (vector.Y + (num9 * 0.60000002384185791))) + genRand.Next(6, 0x10);
            if (num4 < 0)
            {
                num4 = 0;
            }
            if (maxTilesX > Main.maxTilesX)
            {
                maxTilesX = Main.maxTilesX;
            }
            if (num5 < 0)
            {
                num5 = 0;
            }
            if (maxTilesY > Main.maxTilesY)
            {
                maxTilesY = Main.maxTilesY;
            }
            for (int num34 = num4; num34 < maxTilesX; num34++)
            {
                for (int num35 = num5; num35 < maxTilesY; num35++)
                {
                    if (Main.tile[num34, num35].wall != wallType)
                    {
                        bool flag = true;
                        if (num10 < 0)
                        {
                            if (num34 < (vector.X - (num8 * 0.5)))
                            {
                                flag = false;
                            }
                        }
                        else if (num34 > ((vector.X + (num8 * 0.5)) - 1.0))
                        {
                            flag = false;
                        }
                        if (flag)
                        {
                            Main.tile[num34, num35].wall = 0;
                            Main.tile[num34, num35].active = true;
                            Main.tile[num34, num35].type = (byte) tileType;
                        }
                    }
                }
            }
            for (int num36 = num4; num36 < maxTilesX; num36++)
            {
                for (int num37 = maxTilesY; num37 < (maxTilesY + 100); num37++)
                {
                    PlaceWall(num36, num37, 2, true);
                }
            }
            num4 = (int) (vector.X - (num8 * 0.5));
            maxTilesX = (int) (vector.X + (num8 * 0.5));
            num13 = num4;
            if (num10 < 0)
            {
                num13++;
            }
            num14 = (num13 + 5) + genRand.Next(4);
            num15 = (num5 - 3) - genRand.Next(3);
            num16 = num5;
            for (int num38 = num13; num38 < num14; num38++)
            {
                for (int num39 = num15; num39 < num16; num39++)
                {
                    if (Main.tile[num38, num39].wall != wallType)
                    {
                        Main.tile[num38, num39].active = true;
                        Main.tile[num38, num39].type = (byte) tileType;
                    }
                }
            }
            num13 = (maxTilesX - 5) - genRand.Next(4);
            num14 = maxTilesX;
            num15 = (num5 - 3) - genRand.Next(3);
            num16 = num5;
            for (int num40 = num13; num40 < num14; num40++)
            {
                for (int num41 = num15; num41 < num16; num41++)
                {
                    if (Main.tile[num40, num41].wall != wallType)
                    {
                        Main.tile[num40, num41].active = true;
                        Main.tile[num40, num41].type = (byte) tileType;
                    }
                }
            }
            num21 = 1 + genRand.Next(2);
            num22 = 2 + genRand.Next(4);
            num23 = 0;
            if (num10 < 0)
            {
                maxTilesX++;
            }
            for (int num42 = num4 + 1; num42 < (maxTilesX - 1); num42++)
            {
                for (int num43 = num5 - num21; num43 < num5; num43++)
                {
                    if (Main.tile[num42, num43].wall != wallType)
                    {
                        Main.tile[num42, num43].active = true;
                        Main.tile[num42, num43].type = (byte) tileType;
                    }
                }
                num23++;
                if (num23 >= num22)
                {
                    num42 += num22;
                    num23 = 0;
                }
            }
            num4 = (int) (vector.X - (num8 * 0.6));
            maxTilesX = (int) (vector.X + (num8 * 0.6));
            num5 = (int) (vector.Y - (num9 * 0.6));
            maxTilesY = (int) (vector.Y + (num9 * 0.6));
            if (num4 < 0)
            {
                num4 = 0;
            }
            if (maxTilesX > Main.maxTilesX)
            {
                maxTilesX = Main.maxTilesX;
            }
            if (num5 < 0)
            {
                num5 = 0;
            }
            if (maxTilesY > Main.maxTilesY)
            {
                maxTilesY = Main.maxTilesY;
            }
            for (int num44 = num4; num44 < maxTilesX; num44++)
            {
                for (int num45 = num5; num45 < maxTilesY; num45++)
                {
                    Main.tile[num44, num45].wall = 0;
                }
            }
            num4 = (int) (vector.X - (num8 * 0.5));
            maxTilesX = (int) (vector.X + (num8 * 0.5));
            num5 = (int) (vector.Y - (num9 * 0.5));
            maxTilesY = (int) (vector.Y + (num9 * 0.5));
            if (num4 < 0)
            {
                num4 = 0;
            }
            if (maxTilesX > Main.maxTilesX)
            {
                maxTilesX = Main.maxTilesX;
            }
            if (num5 < 0)
            {
                num5 = 0;
            }
            if (maxTilesY > Main.maxTilesY)
            {
                maxTilesY = Main.maxTilesY;
            }
            for (int num46 = num4; num46 < maxTilesX; num46++)
            {
                for (int num47 = num5; num47 < maxTilesY; num47++)
                {
                    Main.tile[num46, num47].active = false;
                    Main.tile[num46, num47].wall = 0;
                }
            }
            for (int num48 = num4; num48 < maxTilesX; num48++)
            {
                if (!Main.tile[num48, maxTilesY].active)
                {
                    Main.tile[num48, maxTilesY].active = true;
                    Main.tile[num48, maxTilesY].type = 0x13;
                }
            }
            Main.dungeonX = (int) vector.X;
            Main.dungeonY = maxTilesY;
            int index = NPC.NewNPC((Main.dungeonX * 0x10) + 8, Main.dungeonY * 0x10, 0x25, 0);
            Main.npc[index].homeless = false;
            Main.npc[index].homeTileX = Main.dungeonX;
            Main.npc[index].homeTileY = Main.dungeonY;
            if (num10 == 1)
            {
                int num50 = 0;
                for (int num51 = maxTilesX; num51 < (maxTilesX + 0x19); num51++)
                {
                    num50++;
                    for (int num52 = maxTilesY + num50; num52 < (maxTilesY + 0x19); num52++)
                    {
                        Main.tile[num51, num52].active = true;
                        Main.tile[num51, num52].type = (byte) tileType;
                    }
                }
            }
            else
            {
                int num53 = 0;
                for (int num54 = num4; num54 > (num4 - 0x19); num54--)
                {
                    num53++;
                    for (int num55 = maxTilesY + num53; num55 < (maxTilesY + 0x19); num55++)
                    {
                        Main.tile[num54, num55].active = true;
                        Main.tile[num54, num55].type = (byte) tileType;
                    }
                }
            }
            num21 = 1 + genRand.Next(2);
            num22 = 2 + genRand.Next(4);
            num23 = 0;
            num4 = (int) (vector.X - (num8 * 0.5));
            maxTilesX = (int) (vector.X + (num8 * 0.5));
            num4 += 2;
            maxTilesX -= 2;
            for (int num56 = num4; num56 < maxTilesX; num56++)
            {
                for (int num57 = num5; num57 < maxTilesY; num57++)
                {
                    PlaceWall(num56, num57, wallType, true);
                }
                num23++;
                if (num23 >= num22)
                {
                    num56 += num22 * 2;
                    num23 = 0;
                }
            }
            vector.X -= (((float) num8) * 0.6f) * num10;
            vector.Y += ((float) num9) * 0.5f;
            num8 = 15.0;
            num9 = 3.0;
            vector.Y -= ((float) num9) * 0.5f;
            num4 = (int) (vector.X - (num8 * 0.5));
            maxTilesX = (int) (vector.X + (num8 * 0.5));
            num5 = (int) (vector.Y - (num9 * 0.5));
            maxTilesY = (int) (vector.Y + (num9 * 0.5));
            if (num4 < 0)
            {
                num4 = 0;
            }
            if (maxTilesX > Main.maxTilesX)
            {
                maxTilesX = Main.maxTilesX;
            }
            if (num5 < 0)
            {
                num5 = 0;
            }
            if (maxTilesY > Main.maxTilesY)
            {
                maxTilesY = Main.maxTilesY;
            }
            for (int num58 = num4; num58 < maxTilesX; num58++)
            {
                for (int num59 = num5; num59 < maxTilesY; num59++)
                {
                    Main.tile[num58, num59].active = false;
                }
            }
            if (num10 < 0)
            {
                vector.X--;
            }
            PlaceTile((int) vector.X, ((int) vector.Y) + 1, 10, false, false, -1, 0);
        }

        public static void DungeonHalls(int i, int j, int tileType, int wallType, bool forceX = false)
        {
            Vector2 vector;
            Vector2 vector2 = new Vector2();
            double num5 = genRand.Next(4, 6);
            Vector2 vector3 = new Vector2();
            Vector2 vector4 = new Vector2();
            int num6 = 1;
            vector.X = i;
            vector.Y = j;
            int num7 = genRand.Next(0x23, 80);
            if (forceX)
            {
                num7 += 20;
                lastDungeonHall = new Vector2();
            }
            else if (genRand.Next(5) == 0)
            {
                num5 *= 2.0;
                num7 /= 2;
            }
            bool flag = false;
            while (!flag)
            {
                if (genRand.Next(2) == 0)
                {
                    num6 = -1;
                }
                else
                {
                    num6 = 1;
                }
                bool flag2 = false;
                if (genRand.Next(2) == 0)
                {
                    flag2 = true;
                }
                if (forceX)
                {
                    flag2 = true;
                }
                if (flag2)
                {
                    vector3.Y = 0f;
                    vector3.X = num6;
                    vector4.Y = 0f;
                    vector4.X = -num6;
                    vector2.Y = 0f;
                    vector2.X = num6;
                    if (genRand.Next(3) == 0)
                    {
                        if (genRand.Next(2) == 0)
                        {
                            vector2.Y = -0.2f;
                        }
                        else
                        {
                            vector2.Y = 0.2f;
                        }
                    }
                }
                else
                {
                    num5++;
                    vector2.Y = num6;
                    vector2.X = 0f;
                    vector3.X = 0f;
                    vector3.Y = num6;
                    vector4.X = 0f;
                    vector4.Y = -num6;
                    if (genRand.Next(2) == 0)
                    {
                        if (genRand.Next(2) == 0)
                        {
                            vector2.X = 0.3f;
                        }
                        else
                        {
                            vector2.X = -0.3f;
                        }
                    }
                    else
                    {
                        num7 /= 2;
                    }
                }
                if (lastDungeonHall != vector4)
                {
                    flag = true;
                }
            }
            if (!forceX)
            {
                if (vector.X > (lastMaxTilesX - 200))
                {
                    num6 = -1;
                    vector3.Y = 0f;
                    vector3.X = num6;
                    vector2.Y = 0f;
                    vector2.X = num6;
                    if (genRand.Next(3) == 0)
                    {
                        if (genRand.Next(2) == 0)
                        {
                            vector2.Y = -0.2f;
                        }
                        else
                        {
                            vector2.Y = 0.2f;
                        }
                    }
                }
                else if (vector.X < 200f)
                {
                    num6 = 1;
                    vector3.Y = 0f;
                    vector3.X = num6;
                    vector2.Y = 0f;
                    vector2.X = num6;
                    if (genRand.Next(3) == 0)
                    {
                        if (genRand.Next(2) == 0)
                        {
                            vector2.Y = -0.2f;
                        }
                        else
                        {
                            vector2.Y = 0.2f;
                        }
                    }
                }
                else if (vector.Y > (lastMaxTilesY - 300))
                {
                    num6 = -1;
                    num5++;
                    vector2.Y = num6;
                    vector2.X = 0f;
                    vector3.X = 0f;
                    vector3.Y = num6;
                    if (genRand.Next(2) == 0)
                    {
                        if (genRand.Next(2) == 0)
                        {
                            vector2.X = 0.3f;
                        }
                        else
                        {
                            vector2.X = -0.3f;
                        }
                    }
                }
                else if (vector.Y < Main.rockLayer)
                {
                    num6 = 1;
                    num5++;
                    vector2.Y = num6;
                    vector2.X = 0f;
                    vector3.X = 0f;
                    vector3.Y = num6;
                    if (genRand.Next(2) == 0)
                    {
                        if (genRand.Next(2) == 0)
                        {
                            vector2.X = 0.3f;
                        }
                        else
                        {
                            vector2.X = -0.3f;
                        }
                    }
                }
                else if ((vector.X < (Main.maxTilesX / 2)) && (vector.X > (Main.maxTilesX * 0.25)))
                {
                    num6 = -1;
                    vector3.Y = 0f;
                    vector3.X = num6;
                    vector2.Y = 0f;
                    vector2.X = num6;
                    if (genRand.Next(3) == 0)
                    {
                        if (genRand.Next(2) == 0)
                        {
                            vector2.Y = -0.2f;
                        }
                        else
                        {
                            vector2.Y = 0.2f;
                        }
                    }
                }
                else if ((vector.X > (Main.maxTilesX / 2)) && (vector.X < (Main.maxTilesX * 0.75)))
                {
                    num6 = 1;
                    vector3.Y = 0f;
                    vector3.X = num6;
                    vector2.Y = 0f;
                    vector2.X = num6;
                    if (genRand.Next(3) == 0)
                    {
                        if (genRand.Next(2) == 0)
                        {
                            vector2.Y = -0.2f;
                        }
                        else
                        {
                            vector2.Y = 0.2f;
                        }
                    }
                }
            }
            if (vector3.Y == 0f)
            {
                DDoorX[numDDoors] = (int) vector.X;
                DDoorY[numDDoors] = (int) vector.Y;
                DDoorPos[numDDoors] = 0;
                numDDoors++;
            }
            else
            {
                DPlatX[numDPlats] = (int) vector.X;
                DPlatY[numDPlats] = (int) vector.Y;
                numDPlats++;
            }
            lastDungeonHall = vector3;
            while (num7 > 0)
            {
                if ((vector3.X > 0f) && (vector.X > (Main.maxTilesX - 100)))
                {
                    num7 = 0;
                }
                else if ((vector3.X < 0f) && (vector.X < 100f))
                {
                    num7 = 0;
                }
                else if ((vector3.Y > 0f) && (vector.Y > (Main.maxTilesY - 100)))
                {
                    num7 = 0;
                }
                else if ((vector3.Y < 0f) && (vector.Y < (Main.rockLayer + 50.0)))
                {
                    num7 = 0;
                }
                num7--;
                int num = ((int) ((vector.X - num5) - 4.0)) - genRand.Next(6);
                int maxTilesX = ((int) ((vector.X + num5) + 4.0)) + genRand.Next(6);
                int num2 = ((int) ((vector.Y - num5) - 4.0)) - genRand.Next(6);
                int maxTilesY = ((int) ((vector.Y + num5) + 4.0)) + genRand.Next(6);
                if (num < 0)
                {
                    num = 0;
                }
                if (maxTilesX > Main.maxTilesX)
                {
                    maxTilesX = Main.maxTilesX;
                }
                if (num2 < 0)
                {
                    num2 = 0;
                }
                if (maxTilesY > Main.maxTilesY)
                {
                    maxTilesY = Main.maxTilesY;
                }
                for (int k = num; k < maxTilesX; k++)
                {
                    for (int num9 = num2; num9 < maxTilesY; num9++)
                    {
                        Main.tile[k, num9].liquid = 0;
                        if (Main.tile[k, num9].wall == 0)
                        {
                            Main.tile[k, num9].active = true;
                            Main.tile[k, num9].type = (byte) tileType;
                        }
                    }
                }
                for (int m = num + 1; m < (maxTilesX - 1); m++)
                {
                    for (int num11 = num2 + 1; num11 < (maxTilesY - 1); num11++)
                    {
                        PlaceWall(m, num11, wallType, true);
                    }
                }
                int num12 = 0;
                if ((vector2.Y == 0f) && (genRand.Next(((int) num5) + 1) == 0))
                {
                    num12 = genRand.Next(1, 3);
                }
                else if ((vector2.X == 0f) && (genRand.Next(((int) num5) - 1) == 0))
                {
                    num12 = genRand.Next(1, 3);
                }
                else if (genRand.Next(((int) num5) * 3) == 0)
                {
                    num12 = genRand.Next(1, 3);
                }
                num = ((int) (vector.X - (num5 * 0.5))) - num12;
                maxTilesX = ((int) (vector.X + (num5 * 0.5))) + num12;
                num2 = ((int) (vector.Y - (num5 * 0.5))) - num12;
                maxTilesY = ((int) (vector.Y + (num5 * 0.5))) + num12;
                if (num < 0)
                {
                    num = 0;
                }
                if (maxTilesX > Main.maxTilesX)
                {
                    maxTilesX = Main.maxTilesX;
                }
                if (num2 < 0)
                {
                    num2 = 0;
                }
                if (maxTilesY > Main.maxTilesY)
                {
                    maxTilesY = Main.maxTilesY;
                }
                for (int n = num; n < maxTilesX; n++)
                {
                    for (int num14 = num2; num14 < maxTilesY; num14++)
                    {
                        Main.tile[n, num14].active = false;
                        Main.tile[n, num14].wall = (byte) wallType;
                    }
                }
                vector += vector2;
            }
            dungeonX = (int) vector.X;
            dungeonY = (int) vector.Y;
            if (vector3.Y == 0f)
            {
                DDoorX[numDDoors] = (int) vector.X;
                DDoorY[numDDoors] = (int) vector.Y;
                DDoorPos[numDDoors] = 0;
                numDDoors++;
            }
            else
            {
                DPlatX[numDPlats] = (int) vector.X;
                DPlatY[numDPlats] = (int) vector.Y;
                numDPlats++;
            }
        }

        public static void DungeonRoom(int i, int j, int tileType, int wallType)
        {
            Vector2 vector;
            Vector2 vector2;
            double num5 = genRand.Next(15, 30);
            vector2.X = genRand.Next(-10, 11) * 0.1f;
            vector2.Y = genRand.Next(-10, 11) * 0.1f;
            vector.X = i;
            vector.Y = j - (((float) num5) / 2f);
            int num6 = genRand.Next(10, 20);
            double x = vector.X;
            double num8 = vector.X;
            double y = vector.Y;
            double num10 = vector.Y;
            while (num6 > 0)
            {
                num6--;
                int num = (int) ((vector.X - (num5 * 0.800000011920929)) - 5.0);
                int maxTilesX = (int) ((vector.X + (num5 * 0.800000011920929)) + 5.0);
                int num2 = (int) ((vector.Y - (num5 * 0.800000011920929)) - 5.0);
                int maxTilesY = (int) ((vector.Y + (num5 * 0.800000011920929)) + 5.0);
                if (num < 0)
                {
                    num = 0;
                }
                if (maxTilesX > Main.maxTilesX)
                {
                    maxTilesX = Main.maxTilesX;
                }
                if (num2 < 0)
                {
                    num2 = 0;
                }
                if (maxTilesY > Main.maxTilesY)
                {
                    maxTilesY = Main.maxTilesY;
                }
                for (int k = num; k < maxTilesX; k++)
                {
                    for (int num12 = num2; num12 < maxTilesY; num12++)
                    {
                        Main.tile[k, num12].liquid = 0;
                        if (Main.tile[k, num12].wall == 0)
                        {
                            Main.tile[k, num12].active = true;
                            Main.tile[k, num12].type = (byte) tileType;
                        }
                    }
                }
                for (int m = num + 1; m < (maxTilesX - 1); m++)
                {
                    for (int num14 = num2 + 1; num14 < (maxTilesY - 1); num14++)
                    {
                        PlaceWall(m, num14, wallType, true);
                    }
                }
                num = (int) (vector.X - (num5 * 0.5));
                maxTilesX = (int) (vector.X + (num5 * 0.5));
                num2 = (int) (vector.Y - (num5 * 0.5));
                maxTilesY = (int) (vector.Y + (num5 * 0.5));
                if (num < 0)
                {
                    num = 0;
                }
                if (maxTilesX > Main.maxTilesX)
                {
                    maxTilesX = Main.maxTilesX;
                }
                if (num2 < 0)
                {
                    num2 = 0;
                }
                if (maxTilesY > Main.maxTilesY)
                {
                    maxTilesY = Main.maxTilesY;
                }
                if (num < x)
                {
                    x = num;
                }
                if (maxTilesX > num8)
                {
                    num8 = maxTilesX;
                }
                if (num2 < y)
                {
                    y = num2;
                }
                if (maxTilesY > num10)
                {
                    num10 = maxTilesY;
                }
                for (int n = num; n < maxTilesX; n++)
                {
                    for (int num16 = num2; num16 < maxTilesY; num16++)
                    {
                        Main.tile[n, num16].active = false;
                        Main.tile[n, num16].wall = (byte) wallType;
                    }
                }
                vector += vector2;
                vector2.X += genRand.Next(-10, 11) * 0.05f;
                vector2.Y += genRand.Next(-10, 11) * 0.05f;
                if (vector2.X > 1f)
                {
                    vector2.X = 1f;
                }
                if (vector2.X < -1f)
                {
                    vector2.X = -1f;
                }
                if (vector2.Y > 1f)
                {
                    vector2.Y = 1f;
                }
                if (vector2.Y < -1f)
                {
                    vector2.Y = -1f;
                }
            }
            dRoomX[numDRooms] = (int) vector.X;
            dRoomY[numDRooms] = (int) vector.Y;
            dRoomSize[numDRooms] = (int) num5;
            dRoomL[numDRooms] = (int) x;
            dRoomR[numDRooms] = (int) num8;
            dRoomT[numDRooms] = (int) y;
            dRoomB[numDRooms] = (int) num10;
            dRoomTreasure[numDRooms] = false;
            numDRooms++;
        }

        public static void DungeonStairs(int i, int j, int tileType, int wallType)
        {
            Vector2 vector;
            Vector2 vector2 = new Vector2();
            double num5 = genRand.Next(5, 9);
            int num6 = 1;
            vector.X = i;
            vector.Y = j;
            int num7 = genRand.Next(10, 30);
            if (i > dEnteranceX)
            {
                num6 = -1;
            }
            else
            {
                num6 = 1;
            }
            if (i > (Main.maxTilesX - 400))
            {
                num6 = -1;
            }
            else if (i < 400)
            {
                num6 = 1;
            }
            vector2.Y = -1f;
            vector2.X = num6;
            if (genRand.Next(3) == 0)
            {
                vector2.X *= 0.5f;
            }
            else if (genRand.Next(3) == 0)
            {
                vector2.Y *= 2f;
            }
            while (num7 > 0)
            {
                num7--;
                int num = ((int) ((vector.X - num5) - 4.0)) - genRand.Next(6);
                int maxTilesX = ((int) ((vector.X + num5) + 4.0)) + genRand.Next(6);
                int num2 = (int) ((vector.Y - num5) - 4.0);
                int maxTilesY = ((int) ((vector.Y + num5) + 4.0)) + genRand.Next(6);
                if (num < 0)
                {
                    num = 0;
                }
                if (maxTilesX > Main.maxTilesX)
                {
                    maxTilesX = Main.maxTilesX;
                }
                if (num2 < 0)
                {
                    num2 = 0;
                }
                if (maxTilesY > Main.maxTilesY)
                {
                    maxTilesY = Main.maxTilesY;
                }
                int num8 = 1;
                if (vector.X > (Main.maxTilesX / 2))
                {
                    num8 = -1;
                }
                int num9 = (int) ((vector.X + ((((float) dxStrength1) * 0.6f) * num8)) + (((float) dxStrength2) * num8));
                int num10 = (int) (dyStrength2 * 0.5);
                if (((vector.Y < (Main.worldSurface - 5.0)) && (Main.tile[num9, ((int) ((vector.Y - num5) - 6.0)) + num10].wall == 0)) && ((Main.tile[num9, ((int) ((vector.Y - num5) - 7.0)) + num10].wall == 0) && (Main.tile[num9, ((int) ((vector.Y - num5) - 8.0)) + num10].wall == 0)))
                {
                    dSurface = true;
                    TileRunner(num9, ((int) ((vector.Y - num5) - 6.0)) + num10, (double) genRand.Next(0x19, 0x23), genRand.Next(10, 20), -1, false, 0f, -1f, false, true);
                }
                for (int k = num; k < maxTilesX; k++)
                {
                    for (int num12 = num2; num12 < maxTilesY; num12++)
                    {
                        Main.tile[k, num12].liquid = 0;
                        if (Main.tile[k, num12].wall != wallType)
                        {
                            Main.tile[k, num12].wall = 0;
                            Main.tile[k, num12].active = true;
                            Main.tile[k, num12].type = (byte) tileType;
                        }
                    }
                }
                for (int m = num + 1; m < (maxTilesX - 1); m++)
                {
                    for (int num14 = num2 + 1; num14 < (maxTilesY - 1); num14++)
                    {
                        PlaceWall(m, num14, wallType, true);
                    }
                }
                int num15 = 0;
                if (genRand.Next((int) num5) == 0)
                {
                    num15 = genRand.Next(1, 3);
                }
                num = ((int) (vector.X - (num5 * 0.5))) - num15;
                maxTilesX = ((int) (vector.X + (num5 * 0.5))) + num15;
                num2 = ((int) (vector.Y - (num5 * 0.5))) - num15;
                maxTilesY = ((int) (vector.Y + (num5 * 0.5))) + num15;
                if (num < 0)
                {
                    num = 0;
                }
                if (maxTilesX > Main.maxTilesX)
                {
                    maxTilesX = Main.maxTilesX;
                }
                if (num2 < 0)
                {
                    num2 = 0;
                }
                if (maxTilesY > Main.maxTilesY)
                {
                    maxTilesY = Main.maxTilesY;
                }
                for (int n = num; n < maxTilesX; n++)
                {
                    for (int num17 = num2; num17 < maxTilesY; num17++)
                    {
                        Main.tile[n, num17].active = false;
                        PlaceWall(n, num17, wallType, true);
                    }
                }
                if (dSurface)
                {
                    num7 = 0;
                }
                vector += vector2;
            }
            dungeonX = (int) vector.X;
            dungeonY = (int) vector.Y;
        }

        public static bool EmptyTileCheck(int startX, int endX, int startY, int endY, int ignoreStyle = -1)
        {
            if (startX < 0)
            {
                return false;
            }
            if (endX >= Main.maxTilesX)
            {
                return false;
            }
            if (startY < 0)
            {
                return false;
            }
            if (endY >= Main.maxTilesY)
            {
                return false;
            }
            for (int i = startX; i < (endX + 1); i++)
            {
                for (int j = startY; j < (endY + 1); j++)
                {
                    if (Main.tile[i, j].active)
                    {
                        if (ignoreStyle == -1)
                        {
                            return false;
                        }
                        if ((ignoreStyle == 11) && (Main.tile[i, j].type != 11))
                        {
                            return false;
                        }
                        if (((((ignoreStyle == 20) && (Main.tile[i, j].type != 20)) && ((Main.tile[i, j].type != 3) && (Main.tile[i, j].type != 0x18))) && (((Main.tile[i, j].type != 0x3d) && (Main.tile[i, j].type != 0x20)) && ((Main.tile[i, j].type != 0x45) && (Main.tile[i, j].type != 0x49)))) && (Main.tile[i, j].type != 0x4a))
                        {
                            return false;
                        }
                        if ((ignoreStyle == 0x47) && (Main.tile[i, j].type != 0x47))
                        {
                            return false;
                        }
                    }
                }
            }
            return true;
        }

        public static void EveryTileFrame()
        {
            noLiquidCheck = true;
            noTileActions = true;
            for (int i = 0; i < Main.maxTilesX; i++)
            {
                float num2 = ((float) i) / ((float) Main.maxTilesX);
                //Main.statusText = "Finding tile frames: " + ((int) ((num2 * 100f) + 1f)) + "%";
                for (int j = 0; j < Main.maxTilesY; j++)
                {
                    TileFrame(i, j, true, false);
                    WallFrame(i, j, true);
                }
            }
            noLiquidCheck = false;
            noTileActions = false;
        }

        public static void FloatingIsland(int i, int j)
        {
            Vector2 vector;
            Vector2 vector2;
            double num5 = genRand.Next(80, 120);
            double num6 = num5;
            float num7 = genRand.Next(20, 0x19);
            vector.X = i;
            vector.Y = j;
            vector2.X = genRand.Next(-20, 0x15) * 0.2f;
            while ((vector2.X > -2f) && (vector2.X < 2f))
            {
                vector2.X = genRand.Next(-20, 0x15) * 0.2f;
            }
            vector2.Y = genRand.Next(-20, -10) * 0.02f;
            while ((num5 > 0.0) && (num7 > 0f))
            {
                num5 -= genRand.Next(4);
                num7--;
                int num = (int) (vector.X - (num5 * 0.5));
                int maxTilesX = (int) (vector.X + (num5 * 0.5));
                int num2 = (int) (vector.Y - (num5 * 0.5));
                int maxTilesY = (int) (vector.Y + (num5 * 0.5));
                if (num < 0)
                {
                    num = 0;
                }
                if (maxTilesX > Main.maxTilesX)
                {
                    maxTilesX = Main.maxTilesX;
                }
                if (num2 < 0)
                {
                    num2 = 0;
                }
                if (maxTilesY > Main.maxTilesY)
                {
                    maxTilesY = Main.maxTilesY;
                }
                num6 = (num5 * genRand.Next(80, 120)) * 0.01;
                float y = vector.Y + 1f;
                for (int k = num; k < maxTilesX; k++)
                {
                    if (genRand.Next(2) == 0)
                    {
                        y += genRand.Next(-1, 2);
                    }
                    if (y < vector.Y)
                    {
                        y = vector.Y;
                    }
                    if (y > (vector.Y + 2f))
                    {
                        y = vector.Y + 2f;
                    }
                    for (int n = num2; n < maxTilesY; n++)
                    {
                        if (n > y)
                        {
                            float num11 = Math.Abs((float) (k - vector.X));
                            float num12 = Math.Abs((float) (n - vector.Y)) * 2f;
                            if (Math.Sqrt((double) ((num11 * num11) + (num12 * num12))) < (num6 * 0.4))
                            {
                                Main.tile[k, n].active = true;
                                if (Main.tile[k, n].type == 0x3b)
                                {
                                    Main.tile[k, n].type = 0;
                                }
                            }
                        }
                    }
                }
                TileRunner(genRand.Next(num + 10, maxTilesX - 10), (int) ((vector.Y + (num6 * 0.1)) + 5.0), (double) genRand.Next(5, 10), genRand.Next(10, 15), 0, true, 0f, 2f, true, true);
                num = (int) (vector.X - (num5 * 0.4));
                maxTilesX = (int) (vector.X + (num5 * 0.4));
                num2 = (int) (vector.Y - (num5 * 0.4));
                maxTilesY = (int) (vector.Y + (num5 * 0.4));
                if (num < 0)
                {
                    num = 0;
                }
                if (maxTilesX > Main.maxTilesX)
                {
                    maxTilesX = Main.maxTilesX;
                }
                if (num2 < 0)
                {
                    num2 = 0;
                }
                if (maxTilesY > Main.maxTilesY)
                {
                    maxTilesY = Main.maxTilesY;
                }
                num6 = (num5 * genRand.Next(80, 120)) * 0.01;
                for (int m = num; m < maxTilesX; m++)
                {
                    for (int num15 = num2; num15 < maxTilesY; num15++)
                    {
                        if (num15 > (vector.Y + 2f))
                        {
                            float num16 = Math.Abs((float) (m - vector.X));
                            float num17 = Math.Abs((float) (num15 - vector.Y)) * 2f;
                            if (Math.Sqrt((double) ((num16 * num16) + (num17 * num17))) < (num6 * 0.4))
                            {
                                Main.tile[m, num15].wall = 2;
                            }
                        }
                    }
                }
                vector += vector2;
                vector2.Y += genRand.Next(-10, 11) * 0.05f;
                if (vector2.X > 1f)
                {
                    vector2.X = 1f;
                }
                if (vector2.X < -1f)
                {
                    vector2.X = -1f;
                }
                if (vector2.Y > 0.2)
                {
                    vector2.Y = -0.2f;
                }
                if (vector2.Y < -0.2)
                {
                    vector2.Y = -0.2f;
                }
            }
        }

        public static void generateWorld(int seed = -1)
        {
            gen = true;
            resetGen();
            if (seed > 0)
            {
                genRand = new Random(seed);
            }
            else
            {
                genRand = new Random((int) DateTime.Now.Ticks);
            }
            Main.worldID = genRand.Next(0x7fffffff);
            int num7 = 0;
            int num8 = 0;
            double num = Main.maxTilesY * 0.3;
            num *= genRand.Next(90, 110) * 0.005;
            double num4 = num + (Main.maxTilesY * 0.2);
            num4 *= genRand.Next(90, 110) * 0.01;
            double num2 = num;
            double num3 = num;
            double num5 = num4;
            double num6 = num4;
            int num9 = 0;
            if (genRand.Next(2) == 0)
            {
                num9 = -1;
            }
            else
            {
                num9 = 1;
            }
            for (int i = 0; i < Main.maxTilesX; i++)
            {
                float num11 = ((float) i) / ((float) Main.maxTilesX);
                //Main.statusText = "Generating world terrain: " + ((int) ((num11 * 100f) + 1f)) + "%";
                if (num < num2)
                {
                    num2 = num;
                }
                if (num > num3)
                {
                    num3 = num;
                }
                if (num4 < num5)
                {
                    num5 = num4;
                }
                if (num4 > num6)
                {
                    num6 = num4;
                }
                if (num8 <= 0)
                {
                    num7 = genRand.Next(0, 5);
                    num8 = genRand.Next(5, 40);
                    if (num7 == 0)
                    {
                        num8 *= (int) (genRand.Next(5, 30) * 0.2);
                    }
                }
                num8--;
                switch (num7)
                {
                    case 0:
                        while (genRand.Next(0, 7) == 0)
                        {
                            num += genRand.Next(-1, 2);
                        }
                        break;

                    case 1:
                        while (genRand.Next(0, 4) == 0)
                        {
                            num--;
                        }
                        while (genRand.Next(0, 10) == 0)
                        {
                            num++;
                        }
                        break;

                    case 2:
                        while (genRand.Next(0, 4) == 0)
                        {
                            num++;
                        }
                        while (genRand.Next(0, 10) == 0)
                        {
                            num--;
                        }
                        break;

                    case 3:
                        while (genRand.Next(0, 2) == 0)
                        {
                            num--;
                        }
                        while (genRand.Next(0, 6) == 0)
                        {
                            num++;
                        }
                        break;

                    case 4:
                        while (genRand.Next(0, 2) == 0)
                        {
                            num++;
                        }
                        while (genRand.Next(0, 5) == 0)
                        {
                            num--;
                        }
                        break;
                }
                if (num < (Main.maxTilesY * 0.15))
                {
                    num = Main.maxTilesY * 0.15;
                    num8 = 0;
                }
                else if (num > (Main.maxTilesY * 0.3))
                {
                    num = Main.maxTilesY * 0.3;
                    num8 = 0;
                }
                if (((i < 0x113) || (i > (Main.maxTilesX - 0x113))) && (num > (Main.maxTilesY * 0.25)))
                {
                    num = Main.maxTilesY * 0.25;
                    num8 = 1;
                }
                while (genRand.Next(0, 3) == 0)
                {
                    num4 += genRand.Next(-2, 3);
                }
                if (num4 < (num + (Main.maxTilesY * 0.05)))
                {
                    num4++;
                }
                if (num4 > (num + (Main.maxTilesY * 0.35)))
                {
                    num4--;
                }
                for (int num12 = 0; num12 < num; num12++)
                {
                    Main.tile[i, num12].active = false;
                    Main.tile[i, num12].lighted = true;
                    Main.tile[i, num12].frameX = -1;
                    Main.tile[i, num12].frameY = -1;
                }
                for (int num13 = (int) num; num13 < Main.maxTilesY; num13++)
                {
                    if (num13 < num4)
                    {
                        Main.tile[i, num13].active = true;
                        Main.tile[i, num13].type = 0;
                        Main.tile[i, num13].frameX = -1;
                        Main.tile[i, num13].frameY = -1;
                    }
                    else
                    {
                        Main.tile[i, num13].active = true;
                        Main.tile[i, num13].type = 1;
                        Main.tile[i, num13].frameX = -1;
                        Main.tile[i, num13].frameY = -1;
                    }
                }
            }
            Main.worldSurface = num3 + 25.0;
            Main.rockLayer = num6;
            double num14 = ((int) ((Main.rockLayer - Main.worldSurface) / 6.0)) * 6;
            Main.rockLayer = Main.worldSurface + num14;
            waterLine = (((int) Main.rockLayer) + Main.maxTilesY) / 2;
            waterLine += genRand.Next(-100, 20);
            lavaLine = waterLine + genRand.Next(50, 80);
            int num15 = 0;
            //Main.statusText = "Adding sand...";
            int num16 = genRand.Next((int) (Main.maxTilesX * 0.0008), (int) (Main.maxTilesX * 0.0025)) + 2;
            for (int j = 0; j < num16; j++)
            {
                int num18 = genRand.Next(Main.maxTilesX);
                while ((num18 > (Main.maxTilesX * 0.4f)) && (num18 < (Main.maxTilesX * 0.6f)))
                {
                    num18 = genRand.Next(Main.maxTilesX);
                }
                int num19 = genRand.Next(0x23, 90);
                if (j == 1)
                {
                    float num20 = Main.maxTilesX / 0x1068;
                    num19 += (int) (genRand.Next(20, 40) * num20);
                }
                if (genRand.Next(3) == 0)
                {
                    num19 *= 2;
                }
                if (j == 1)
                {
                    num19 *= 2;
                }
                int num21 = num18 - num19;
                num19 = genRand.Next(0x23, 90);
                if (genRand.Next(3) == 0)
                {
                    num19 *= 2;
                }
                if (j == 1)
                {
                    num19 *= 2;
                }
                int maxTilesX = num18 + num19;
                if (num21 < 0)
                {
                    num21 = 0;
                }
                if (maxTilesX > Main.maxTilesX)
                {
                    maxTilesX = Main.maxTilesX;
                }
                switch (j)
                {
                    case 0:
                        num21 = 0;
                        maxTilesX = genRand.Next(260, 300);
                        if (num9 == 1)
                        {
                            maxTilesX += 40;
                        }
                        break;

                    case 2:
                        num21 = Main.maxTilesX - genRand.Next(260, 300);
                        maxTilesX = Main.maxTilesX;
                        if (num9 == -1)
                        {
                            num21 -= 40;
                        }
                        break;
                }
                int num23 = genRand.Next(50, 100);
                for (int num24 = num21; num24 < maxTilesX; num24++)
                {
                    if (genRand.Next(2) == 0)
                    {
                        num23 += genRand.Next(-1, 2);
                        if (num23 < 50)
                        {
                            num23 = 50;
                        }
                        if (num23 > 100)
                        {
                            num23 = 100;
                        }
                    }
                    for (int num25 = 0; num25 < Main.worldSurface; num25++)
                    {
                        if (Main.tile[num24, num25].active)
                        {
                            int num26 = num23;
                            if ((num24 - num21) < num26)
                            {
                                num26 = num24 - num21;
                            }
                            if ((maxTilesX - num24) < num26)
                            {
                                num26 = maxTilesX - num24;
                            }
                            num26 += genRand.Next(5);
                            for (int num27 = num25; num27 < (num25 + num26); num27++)
                            {
                                if ((num24 > (num21 + genRand.Next(5))) && (num24 < (maxTilesX - genRand.Next(5))))
                                {
                                    Main.tile[num24, num27].type = 0x35;
                                }
                            }
                            break;
                        }
                    }
                }
            }
            for (int k = 0; k < ((int) ((Main.maxTilesX * Main.maxTilesY) * 8E-06)); k++)
            {
                TileRunner(genRand.Next(0, Main.maxTilesX), genRand.Next((int) Main.worldSurface, (int) Main.rockLayer), (double) genRand.Next(15, 70), genRand.Next(20, 130), 0x35, false, 0f, 0f, false, true);
            }
            numMCaves = 0;
            //Main.statusText = "Generating hills...";
            for (int m = 0; m < ((int) (Main.maxTilesX * 0.0008)); m++)
            {
                int num30 = 0;
                bool flag = false;
                bool flag2 = false;
                int num31 = genRand.Next((int) (Main.maxTilesX * 0.25), (int) (Main.maxTilesX * 0.75));
                while (!flag2)
                {
                    flag2 = true;
                    while ((num31 > ((Main.maxTilesX / 2) - 100)) && (num31 < ((Main.maxTilesX / 2) + 100)))
                    {
                        num31 = genRand.Next((int) (Main.maxTilesX * 0.25), (int) (Main.maxTilesX * 0.75));
                    }
                    for (int num32 = 0; num32 < numMCaves; num32++)
                    {
                        if ((num31 > (mCaveX[num32] - 50)) && (num31 < (mCaveX[num32] + 50)))
                        {
                            num30++;
                            flag2 = false;
                            break;
                        }
                    }
                    if (num30 >= 200)
                    {
                        flag = true;
                        break;
                    }
                }
                if (!flag)
                {
                    for (int num33 = 0; num33 < Main.worldSurface; num33++)
                    {
                        if (Main.tile[num31, num33].active)
                        {
                            Mountinater(num31, num33);
                            mCaveX[numMCaves] = num31;
                            mCaveY[numMCaves] = num33;
                            numMCaves++;
                            break;
                        }
                    }
                }
            }
            for (int n = 1; n < (Main.maxTilesX - 1); n++)
            {
                float num35 = ((float) n) / ((float) Main.maxTilesX);
                //Main.statusText = "Puttin dirt behind dirt: " + ((int) ((num35 * 100f) + 1f)) + "%";
                bool flag3 = false;
                num15 += genRand.Next(-1, 2);
                if (num15 < 0)
                {
                    num15 = 0;
                }
                if (num15 > 10)
                {
                    num15 = 10;
                }
                for (int num36 = 0; num36 < (Main.worldSurface + 10.0); num36++)
                {
                    if (num36 > (Main.worldSurface + num15))
                    {
                        break;
                    }
                    if (flag3)
                    {
                        Main.tile[n, num36].wall = 2;
                    }
                    if (((Main.tile[n, num36].active && Main.tile[n - 1, num36].active) && (Main.tile[n + 1, num36].active && Main.tile[n, num36 + 1].active)) && (Main.tile[n - 1, num36 + 1].active && Main.tile[n + 1, num36 + 1].active))
                    {
                        flag3 = true;
                    }
                }
            }
            //Main.statusText = "Placing rocks in the dirt...";
            for (int num37 = 0; num37 < ((int) ((Main.maxTilesX * Main.maxTilesY) * 0.0002)); num37++)
            {
                TileRunner(genRand.Next(0, Main.maxTilesX), genRand.Next(0, ((int) num2) + 1), (double) genRand.Next(4, 15), genRand.Next(5, 40), 1, false, 0f, 0f, false, true);
            }
            for (int num38 = 0; num38 < ((int) ((Main.maxTilesX * Main.maxTilesY) * 0.0002)); num38++)
            {
                TileRunner(genRand.Next(0, Main.maxTilesX), genRand.Next((int) num2, ((int) num3) + 1), (double) genRand.Next(4, 10), genRand.Next(5, 30), 1, false, 0f, 0f, false, true);
            }
            for (int num39 = 0; num39 < ((int) ((Main.maxTilesX * Main.maxTilesY) * 0.0045)); num39++)
            {
                TileRunner(genRand.Next(0, Main.maxTilesX), genRand.Next((int) num3, ((int) num6) + 1), (double) genRand.Next(2, 7), genRand.Next(2, 0x17), 1, false, 0f, 0f, false, true);
            }
            //Main.statusText = "Placing dirt in the rocks...";
            for (int num40 = 0; num40 < ((int) ((Main.maxTilesX * Main.maxTilesY) * 0.005)); num40++)
            {
                TileRunner(genRand.Next(0, Main.maxTilesX), genRand.Next((int) num5, Main.maxTilesY), (double) genRand.Next(2, 6), genRand.Next(2, 40), 0, false, 0f, 0f, false, true);
            }
            //Main.statusText = "Adding clay...";
            for (int num41 = 0; num41 < ((int) ((Main.maxTilesX * Main.maxTilesY) * 2E-05)); num41++)
            {
                TileRunner(genRand.Next(0, Main.maxTilesX), genRand.Next(0, (int) num2), (double) genRand.Next(4, 14), genRand.Next(10, 50), 40, false, 0f, 0f, false, true);
            }
            for (int num42 = 0; num42 < ((int) ((Main.maxTilesX * Main.maxTilesY) * 5E-05)); num42++)
            {
                TileRunner(genRand.Next(0, Main.maxTilesX), genRand.Next((int) num2, ((int) num3) + 1), (double) genRand.Next(8, 14), genRand.Next(15, 0x2d), 40, false, 0f, 0f, false, true);
            }
            for (int num43 = 0; num43 < ((int) ((Main.maxTilesX * Main.maxTilesY) * 2E-05)); num43++)
            {
                TileRunner(genRand.Next(0, Main.maxTilesX), genRand.Next((int) num3, ((int) num6) + 1), (double) genRand.Next(8, 15), genRand.Next(5, 50), 40, false, 0f, 0f, false, true);
            }
            for (int num44 = 5; num44 < (Main.maxTilesX - 5); num44++)
            {
                for (int num45 = 1; num45 < (Main.worldSurface - 1.0); num45++)
                {
                    if (Main.tile[num44, num45].active)
                    {
                        for (int num46 = num45; num46 < (num45 + 5); num46++)
                        {
                            if (Main.tile[num44, num46].type == 40)
                            {
                                Main.tile[num44, num46].type = 0;
                            }
                        }
                        break;
                    }
                }
            }
            for (int num47 = 0; num47 < ((int) ((Main.maxTilesX * Main.maxTilesY) * 0.0015)); num47++)
            {
                float num48 = (float) (((double) num47) / ((Main.maxTilesX * Main.maxTilesY) * 0.0015));
                //Main.statusText = "Making random holes: " + ((int) ((num48 * 100f) + 1f)) + "%";
                int type = -1;
                if (genRand.Next(5) == 0)
                {
                    type = -2;
                }
                TileRunner(genRand.Next(0, Main.maxTilesX), genRand.Next((int) num3, Main.maxTilesY), (double) genRand.Next(2, 5), genRand.Next(2, 20), type, false, 0f, 0f, false, true);
                TileRunner(genRand.Next(0, Main.maxTilesX), genRand.Next((int) num3, Main.maxTilesY), (double) genRand.Next(8, 15), genRand.Next(7, 30), type, false, 0f, 0f, false, true);
            }
            for (int num50 = 0; num50 < ((int) ((Main.maxTilesX * Main.maxTilesY) * 3E-05)); num50++)
            {
                float num51 = (float) (((double) num50) / ((Main.maxTilesX * Main.maxTilesY) * 3E-05));
                //Main.statusText = "Generating small caves: " + ((int) ((num51 * 100f) + 1f)) + "%";
                if (num6 <= Main.maxTilesY)
                {
                    int num52 = -1;
                    if (genRand.Next(6) == 0)
                    {
                        num52 = -2;
                    }
                    TileRunner(genRand.Next(0, Main.maxTilesX), genRand.Next((int) num2, ((int) num6) + 1), (double) genRand.Next(5, 15), genRand.Next(30, 200), num52, false, 0f, 0f, false, true);
                }
            }
            for (int num53 = 0; num53 < ((int) ((Main.maxTilesX * Main.maxTilesY) * 0.00015)); num53++)
            {
                float num54 = (float) (((double) num53) / ((Main.maxTilesX * Main.maxTilesY) * 0.00015));
                //Main.statusText = "Generating large caves: " + ((int) ((num54 * 100f) + 1f)) + "%";
                if (num6 <= Main.maxTilesY)
                {
                    int num55 = -1;
                    if (genRand.Next(10) == 0)
                    {
                        num55 = -2;
                    }
                    TileRunner(genRand.Next(0, Main.maxTilesX), genRand.Next((int) num6, Main.maxTilesY), (double) genRand.Next(6, 20), genRand.Next(50, 300), num55, false, 0f, 0f, false, true);
                }
            }
            int num56 = 0;
            //Main.statusText = "Generating surface caves...";
            for (int num57 = 0; num57 < ((int) (Main.maxTilesX * 0.0025)); num57++)
            {
                num56 = genRand.Next(0, Main.maxTilesX);
                for (int num58 = 0; num58 < num3; num58++)
                {
                    if (Main.tile[num56, num58].active)
                    {
                        TileRunner(num56, num58, (double) genRand.Next(3, 6), genRand.Next(5, 50), -1, false, genRand.Next(-10, 11) * 0.1f, 1f, false, true);
                        break;
                    }
                }
            }
            for (int num59 = 0; num59 < ((int) (Main.maxTilesX * 0.0007)); num59++)
            {
                num56 = genRand.Next(0, Main.maxTilesX);
                for (int num60 = 0; num60 < num3; num60++)
                {
                    if (Main.tile[num56, num60].active)
                    {
                        TileRunner(num56, num60, (double) genRand.Next(10, 15), genRand.Next(50, 130), -1, false, genRand.Next(-10, 11) * 0.1f, 2f, false, true);
                        break;
                    }
                }
            }
            for (int num61 = 0; num61 < ((int) (Main.maxTilesX * 0.0003)); num61++)
            {
                num56 = genRand.Next(0, Main.maxTilesX);
                for (int num62 = 0; num62 < num3; num62++)
                {
                    if (Main.tile[num56, num62].active)
                    {
                        TileRunner(num56, num62, (double) genRand.Next(12, 0x19), genRand.Next(150, 500), -1, false, genRand.Next(-10, 11) * 0.1f, 4f, false, true);
                        TileRunner(num56, num62, (double) genRand.Next(8, 0x11), genRand.Next(60, 200), -1, false, genRand.Next(-10, 11) * 0.1f, 2f, false, true);
                        TileRunner(num56, num62, (double) genRand.Next(5, 13), genRand.Next(40, 170), -1, false, genRand.Next(-10, 11) * 0.1f, 2f, false, true);
                        break;
                    }
                }
            }
            for (int num63 = 0; num63 < ((int) (Main.maxTilesX * 0.0004)); num63++)
            {
                num56 = genRand.Next(0, Main.maxTilesX);
                for (int num64 = 0; num64 < num3; num64++)
                {
                    if (Main.tile[num56, num64].active)
                    {
                        TileRunner(num56, num64, (double) genRand.Next(7, 12), genRand.Next(150, 250), -1, false, 0f, 1f, true, true);
                        break;
                    }
                }
            }
            for (int num67 = 0; num67 < ((int) ((Main.maxTilesX * Main.maxTilesY) * 0.002)); num67++)
            {
                int num65 = genRand.Next(1, Main.maxTilesX - 1);
                int num66 = genRand.Next((int) num2, (int) num3);
                if (num66 >= Main.maxTilesY)
                {
                    num66 = Main.maxTilesY - 2;
                }
                if (((Main.tile[num65 - 1, num66].active && (Main.tile[num65 - 1, num66].type == 0)) && (Main.tile[num65 + 1, num66].active && (Main.tile[num65 + 1, num66].type == 0))) && ((Main.tile[num65, num66 - 1].active && (Main.tile[num65, num66 - 1].type == 0)) && (Main.tile[num65, num66 + 1].active && (Main.tile[num65, num66 + 1].type == 0))))
                {
                    Main.tile[num65, num66].active = true;
                    Main.tile[num65, num66].type = 2;
                }
                num65 = genRand.Next(1, Main.maxTilesX - 1);
                num66 = genRand.Next(0, (int) num2);
                if (num66 >= Main.maxTilesY)
                {
                    num66 = Main.maxTilesY - 2;
                }
                if (((Main.tile[num65 - 1, num66].active && (Main.tile[num65 - 1, num66].type == 0)) && (Main.tile[num65 + 1, num66].active && (Main.tile[num65 + 1, num66].type == 0))) && ((Main.tile[num65, num66 - 1].active && (Main.tile[num65, num66 - 1].type == 0)) && (Main.tile[num65, num66 + 1].active && (Main.tile[num65, num66 + 1].type == 0))))
                {
                    Main.tile[num65, num66].active = true;
                    Main.tile[num65, num66].type = 2;
                }
            }
            //Main.statusText = "Generating jungle: 0%";
            float num68 = Main.maxTilesX / 0x1068;
            num68 *= 1.5f;
            int num69 = 0;
            float num70 = genRand.Next(15, 30) * 0.01f;
            if (num9 == -1)
            {
                num70 = 1f - num70;
                num69 = (int) (Main.maxTilesX * num70);
            }
            else
            {
                num69 = (int) (Main.maxTilesX * num70);
            }
            int num71 = (Main.maxTilesY + ((int) Main.rockLayer)) / 2;
            num69 += genRand.Next((int) (-100f * num68), (int) (101f * num68));
            num71 += genRand.Next((int) (-100f * num68), (int) (101f * num68));
            int num72 = num69;
            int num75 = num71;
            TileRunner(num69, num71, (double) genRand.Next((int) (250f * num68), (int) (500f * num68)), genRand.Next(50, 150), 0x3b, false, (float) (num9 * 3), 0f, false, true);
            for (int num78 = 0; num78 < (6f * num68); num78++)
            {
                TileRunner(num69 + genRand.Next(-((int) (125f * num68)), (int) (125f * num68)), num71 + genRand.Next(-((int) (125f * num68)), (int) (125f * num68)), (double) genRand.Next(3, 7), genRand.Next(3, 8), genRand.Next(0x3f, 0x41), false, 0f, 0f, false, true);
            }
            mudWall = true;
            //Main.statusText = "Generating jungle: 15%";
            num69 += genRand.Next((int) (-250f * num68), (int) (251f * num68));
            num71 += genRand.Next((int) (-150f * num68), (int) (151f * num68));
            int num73 = num69;
            int num76 = num71;
            int num79 = num69;
            int num80 = num71;
            TileRunner(num69, num71, (double) genRand.Next((int) (250f * num68), (int) (500f * num68)), genRand.Next(50, 150), 0x3b, false, 0f, 0f, false, true);
            mudWall = false;
            for (int num81 = 0; num81 < (6f * num68); num81++)
            {
                TileRunner(num69 + genRand.Next(-((int) (125f * num68)), (int) (125f * num68)), num71 + genRand.Next(-((int) (125f * num68)), (int) (125f * num68)), (double) genRand.Next(3, 7), genRand.Next(3, 8), genRand.Next(0x41, 0x43), false, 0f, 0f, false, true);
            }
            mudWall = true;
            //Main.statusText = "Generating jungle: 30%";
            num69 += genRand.Next((int) (-400f * num68), (int) (401f * num68));
            num71 += genRand.Next((int) (-150f * num68), (int) (151f * num68));
            int num74 = num69;
            int num77 = num71;
            TileRunner(num69, num71, (double) genRand.Next((int) (250f * num68), (int) (500f * num68)), genRand.Next(50, 150), 0x3b, false, (float) (num9 * -3), 0f, false, true);
            mudWall = false;
            for (int num82 = 0; num82 < (6f * num68); num82++)
            {
                TileRunner(num69 + genRand.Next(-((int) (125f * num68)), (int) (125f * num68)), num71 + genRand.Next(-((int) (125f * num68)), (int) (125f * num68)), (double) genRand.Next(3, 7), genRand.Next(3, 8), genRand.Next(0x43, 0x45), false, 0f, 0f, false, true);
            }
            mudWall = true;
            //Main.statusText = "Generating jungle: 45%";
            num69 = ((num72 + num73) + num74) / 3;
            num71 = ((num75 + num76) + num77) / 3;
            TileRunner(num69, num71, (double) genRand.Next((int) (400f * num68), (int) (600f * num68)), 0x2710, 0x3b, false, 0f, -20f, true, true);
            JungleRunner(num69, num71);
            //Main.statusText = "Generating jungle: 60%";
            mudWall = false;
            for (int num83 = 0; num83 < (Main.maxTilesX / 10); num83++)
            {
                num69 = genRand.Next(20, Main.maxTilesX - 20);
                num71 = genRand.Next((int) Main.rockLayer, Main.maxTilesY - 200);
                while (Main.tile[num69, num71].wall != 15)
                {
                    num69 = genRand.Next(20, Main.maxTilesX - 20);
                    num71 = genRand.Next((int) Main.rockLayer, Main.maxTilesY - 200);
                }
                MudWallRunner(num69, num71);
            }
            num69 = num79;
            num71 = num80;
            for (int num84 = 0; num84 <= (20f * num68); num84++)
            {
                //Main.statusText = "Generating jungle: " + ((int) (60f + (((float) num84) / num68))) + "%";
                num69 += genRand.Next((int) (-5f * num68), (int) (6f * num68));
                num71 += genRand.Next((int) (-5f * num68), (int) (6f * num68));
                TileRunner(num69, num71, (double) genRand.Next(40, 100), genRand.Next(300, 500), 0x3b, false, 0f, 0f, false, true);
            }
            for (int num85 = 0; num85 <= (10f * num68); num85++)
            {
                //Main.statusText = "Generating jungle: " + ((int) (80f + ((((float) num85) / num68) * 2f))) + "%";
                num69 = num79 + genRand.Next((int) (-600f * num68), (int) (600f * num68));
                num71 = num80 + genRand.Next((int) (-200f * num68), (int) (200f * num68));
                while ((((num69 < 1) || (num69 >= (Main.maxTilesX - 1))) || ((num71 < 1) || (num71 >= (Main.maxTilesY - 1)))) || (Main.tile[num69, num71].type != 0x3b))
                {
                    num69 = num79 + genRand.Next((int) (-600f * num68), (int) (600f * num68));
                    num71 = num80 + genRand.Next((int) (-200f * num68), (int) (200f * num68));
                }
                for (int num86 = 0; num86 < (8f * num68); num86++)
                {
                    num69 += genRand.Next(-30, 0x1f);
                    num71 += genRand.Next(-30, 0x1f);
                    int num87 = -1;
                    if (genRand.Next(7) == 0)
                    {
                        num87 = -2;
                    }
                    TileRunner(num69, num71, (double) genRand.Next(10, 20), genRand.Next(30, 70), num87, false, 0f, 0f, false, true);
                }
            }
            for (int num88 = 0; num88 <= (300f * num68); num88++)
            {
                num69 = num79 + genRand.Next((int) (-600f * num68), (int) (600f * num68));
                num71 = num80 + genRand.Next((int) (-200f * num68), (int) (200f * num68));
                while ((((num69 < 1) || (num69 >= (Main.maxTilesX - 1))) || ((num71 < 1) || (num71 >= (Main.maxTilesY - 1)))) || (Main.tile[num69, num71].type != 0x3b))
                {
                    num69 = num79 + genRand.Next((int) (-600f * num68), (int) (600f * num68));
                    num71 = num80 + genRand.Next((int) (-200f * num68), (int) (200f * num68));
                }
                TileRunner(num69, num71, (double) genRand.Next(4, 10), genRand.Next(5, 30), 1, false, 0f, 0f, false, true);
                if (genRand.Next(4) == 0)
                {
                    int num89 = genRand.Next(0x3f, 0x45);
                    TileRunner(num69 + genRand.Next(-1, 2), num71 + genRand.Next(-1, 2), (double) genRand.Next(3, 7), genRand.Next(4, 8), num89, false, 0f, 0f, false, true);
                }
            }
            num69 = num79;
            num71 = num80;
            float num90 = genRand.Next(6, 10);
            float num91 = Main.maxTilesX / 0x1068;
            num90 *= num91;
            for (int num92 = 0; num92 < num90; num92++)
            {
                bool flag4 = true;
                while (flag4)
                {
                    num69 = genRand.Next(20, Main.maxTilesX - 20);
                    num71 = genRand.Next(((int) (Main.worldSurface + Main.rockLayer)) / 2, Main.maxTilesY - 300);
                    if (Main.tile[num69, num71].type == 0x3b)
                    {
                        flag4 = false;
                        int num93 = genRand.Next(2, 4);
                        int num94 = genRand.Next(2, 4);
                        for (int num95 = (num69 - num93) - 1; num95 <= ((num69 + num93) + 1); num95++)
                        {
                            for (int num96 = (num71 - num94) - 1; num96 <= ((num71 + num94) + 1); num96++)
                            {
                                Main.tile[num95, num96].active = true;
                                Main.tile[num95, num96].type = 0x2d;
                                Main.tile[num95, num96].liquid = 0;
                                Main.tile[num95, num96].lava = false;
                            }
                        }
                        for (int num97 = num69 - num93; num97 <= (num69 + num93); num97++)
                        {
                            for (int num98 = num71 - num94; num98 <= (num71 + num94); num98++)
                            {
                                Main.tile[num97, num98].active = false;
                            }
                        }
                        bool flag5 = false;
                        int num99 = 0;
                        while (!flag5 && (num99 < 100))
                        {
                            num99++;
                            int num100 = genRand.Next(num69 - num93, (num69 + num93) + 1);
                            int num101 = genRand.Next(num71 - num94, (num71 + num94) - 2);
                            PlaceTile(num100, num101, 4, true, false, -1, 0);
                            if (Main.tile[num100, num101].type == 4)
                            {
                                flag5 = true;
                            }
                        }
                        for (int num102 = (num69 - num93) - 1; num102 <= ((num69 + num93) + 1); num102++)
                        {
                            for (int num103 = (num71 + num94) - 2; num103 <= (num71 + num94); num103++)
                            {
                                Main.tile[num102, num103].active = false;
                            }
                        }
                        for (int num104 = (num69 - num93) - 1; num104 <= ((num69 + num93) + 1); num104++)
                        {
                            for (int num105 = (num71 + num94) - 2; num105 <= ((num71 + num94) - 1); num105++)
                            {
                                Main.tile[num104, num105].active = false;
                            }
                        }
                        for (int num106 = (num69 - num93) - 1; num106 <= ((num69 + num93) + 1); num106++)
                        {
                            int num107 = 4;
                            int num108 = (num71 + num94) + 2;
                            while ((!Main.tile[num106, num108].active && (num108 < Main.maxTilesY)) && (num107 > 0))
                            {
                                Main.tile[num106, num108].active = true;
                                Main.tile[num106, num108].type = 0x3b;
                                num108++;
                                num107--;
                            }
                        }
                        num93 -= genRand.Next(1, 3);
                        for (int num109 = (num71 - num94) - 2; num93 > -1; num109--)
                        {
                            for (int num110 = (num69 - num93) - 1; num110 <= ((num69 + num93) + 1); num110++)
                            {
                                Main.tile[num110, num109].active = true;
                                Main.tile[num110, num109].type = 0x2d;
                            }
                            num93 -= genRand.Next(1, 3);
                        }
                        JChestX[numJChests] = num69;
                        JChestY[numJChests] = num71;
                        numJChests++;
                    }
                }
            }
            for (int num111 = 0; num111 < Main.maxTilesX; num111++)
            {
                for (int num112 = 0; num112 < Main.maxTilesY; num112++)
                {
                    if (Main.tile[num111, num112].active)
                    {
                        SpreadGrass(num111, num112, 0x3b, 60, true);
                    }
                }
            }
            numIslandHouses = 0;
            houseCount = 0;
            //Main.statusText = "Generating floating islands...";
            for (int num113 = 0; num113 < ((int) (Main.maxTilesX * 0.0008)); num113++)
            {
                int num114 = 0;
                bool flag6 = false;
                int num115 = genRand.Next((int) (Main.maxTilesX * 0.1), (int) (Main.maxTilesX * 0.9));
                bool flag7 = false;
                while (!flag7)
                {
                    flag7 = true;
                    while ((num115 > ((Main.maxTilesX / 2) - 80)) && (num115 < ((Main.maxTilesX / 2) + 80)))
                    {
                        num115 = genRand.Next((int) (Main.maxTilesX * 0.1), (int) (Main.maxTilesX * 0.9));
                    }
                    for (int num116 = 0; num116 < numIslandHouses; num116++)
                    {
                        if ((num115 > (fihX[num116] - 80)) && (num115 < (fihX[num116] + 80)))
                        {
                            num114++;
                            flag7 = false;
                            break;
                        }
                    }
                    if (num114 >= 200)
                    {
                        flag6 = true;
                        break;
                    }
                }
                if (!flag6)
                {
                    for (int num117 = 200; num117 < Main.worldSurface; num117++)
                    {
                        if (Main.tile[num115, num117].active)
                        {
                            int num118 = num115;
                            int num119 = genRand.Next(90, num117 - 100);
                            while (num119 > (num2 - 50.0))
                            {
                                num119--;
                            }
                            FloatingIsland(num118, num119);
                            fihX[numIslandHouses] = num118;
                            fihY[numIslandHouses] = num119;
                            numIslandHouses++;
                            break;
                        }
                    }
                }
            }
            //Main.statusText = "Adding mushroom patches...";
            for (int num120 = 0; num120 < (Main.maxTilesX / 300); num120++)
            {
                int num121 = genRand.Next((int) (Main.maxTilesX * 0.3), (int) (Main.maxTilesX * 0.7));
                int num122 = genRand.Next((int) Main.rockLayer, Main.maxTilesY - 300);
                ShroomPatch(num121, num122);
            }
            for (int num123 = 0; num123 < Main.maxTilesX; num123++)
            {
                for (int num124 = (int) Main.worldSurface; num124 < Main.maxTilesY; num124++)
                {
                    if (Main.tile[num123, num124].active)
                    {
                        SpreadGrass(num123, num124, 0x3b, 70, false);
                    }
                }
            }
            //Main.statusText = "Placing mud in the dirt...";
            for (int num125 = 0; num125 < ((int) ((Main.maxTilesX * Main.maxTilesY) * 0.001)); num125++)
            {
                TileRunner(genRand.Next(0, Main.maxTilesX), genRand.Next((int) num5, Main.maxTilesY), (double) genRand.Next(2, 6), genRand.Next(2, 40), 0x3b, false, 0f, 0f, false, true);
            }
            //Main.statusText = "Adding shinies...";
            for (int num126 = 0; num126 < ((int) ((Main.maxTilesX * Main.maxTilesY) * 6E-05)); num126++)
            {
                TileRunner(genRand.Next(0, Main.maxTilesX), genRand.Next((int) num2, (int) num3), (double) genRand.Next(3, 6), genRand.Next(2, 6), 7, false, 0f, 0f, false, true);
            }
            for (int num127 = 0; num127 < ((int) ((Main.maxTilesX * Main.maxTilesY) * 8E-05)); num127++)
            {
                TileRunner(genRand.Next(0, Main.maxTilesX), genRand.Next((int) num3, (int) num6), (double) genRand.Next(3, 7), genRand.Next(3, 7), 7, false, 0f, 0f, false, true);
            }
            for (int num128 = 0; num128 < ((int) ((Main.maxTilesX * Main.maxTilesY) * 0.0002)); num128++)
            {
                TileRunner(genRand.Next(0, Main.maxTilesX), genRand.Next((int) num5, Main.maxTilesY), (double) genRand.Next(4, 9), genRand.Next(4, 8), 7, false, 0f, 0f, false, true);
            }
            for (int num129 = 0; num129 < ((int) ((Main.maxTilesX * Main.maxTilesY) * 3E-05)); num129++)
            {
                TileRunner(genRand.Next(0, Main.maxTilesX), genRand.Next((int) num2, (int) num3), (double) genRand.Next(3, 7), genRand.Next(2, 5), 6, false, 0f, 0f, false, true);
            }
            for (int num130 = 0; num130 < ((int) ((Main.maxTilesX * Main.maxTilesY) * 8E-05)); num130++)
            {
                TileRunner(genRand.Next(0, Main.maxTilesX), genRand.Next((int) num3, (int) num6), (double) genRand.Next(3, 6), genRand.Next(3, 6), 6, false, 0f, 0f, false, true);
            }
            for (int num131 = 0; num131 < ((int) ((Main.maxTilesX * Main.maxTilesY) * 0.0002)); num131++)
            {
                TileRunner(genRand.Next(0, Main.maxTilesX), genRand.Next((int) num5, Main.maxTilesY), (double) genRand.Next(4, 9), genRand.Next(4, 8), 6, false, 0f, 0f, false, true);
            }
            for (int num132 = 0; num132 < ((int) ((Main.maxTilesX * Main.maxTilesY) * 3E-05)); num132++)
            {
                TileRunner(genRand.Next(0, Main.maxTilesX), genRand.Next((int) num3, (int) num6), (double) genRand.Next(3, 6), genRand.Next(3, 6), 9, false, 0f, 0f, false, true);
            }
            for (int num133 = 0; num133 < ((int) ((Main.maxTilesX * Main.maxTilesY) * 0.00017)); num133++)
            {
                TileRunner(genRand.Next(0, Main.maxTilesX), genRand.Next((int) num5, Main.maxTilesY), (double) genRand.Next(4, 9), genRand.Next(4, 8), 9, false, 0f, 0f, false, true);
            }
            for (int num134 = 0; num134 < ((int) ((Main.maxTilesX * Main.maxTilesY) * 0.00017)); num134++)
            {
                TileRunner(genRand.Next(0, Main.maxTilesX), genRand.Next(0, (int) num2), (double) genRand.Next(4, 9), genRand.Next(4, 8), 9, false, 0f, 0f, false, true);
            }
            for (int num135 = 0; num135 < ((int) ((Main.maxTilesX * Main.maxTilesY) * 0.00012)); num135++)
            {
                TileRunner(genRand.Next(0, Main.maxTilesX), genRand.Next((int) num5, Main.maxTilesY), (double) genRand.Next(4, 8), genRand.Next(4, 8), 8, false, 0f, 0f, false, true);
            }
            for (int num136 = 0; num136 < ((int) ((Main.maxTilesX * Main.maxTilesY) * 0.00012)); num136++)
            {
                TileRunner(genRand.Next(0, Main.maxTilesX), genRand.Next(0, ((int) num2) - 20), (double) genRand.Next(4, 8), genRand.Next(4, 8), 8, false, 0f, 0f, false, true);
            }
            for (int num137 = 0; num137 < ((int) ((Main.maxTilesX * Main.maxTilesY) * 2E-05)); num137++)
            {
                TileRunner(genRand.Next(0, Main.maxTilesX), genRand.Next((int) num5, Main.maxTilesY), (double) genRand.Next(2, 4), genRand.Next(3, 6), 0x16, false, 0f, 0f, false, true);
            }
            //Main.statusText = "Adding webs...";
            for (int num138 = 0; num138 < ((int) ((Main.maxTilesX * Main.maxTilesY) * 0.001)); num138++)
            {
                int num139 = genRand.Next(20, Main.maxTilesX - 20);
                int num140 = genRand.Next((int) num2, Main.maxTilesY - 20);
                if (num138 < numMCaves)
                {
                    num139 = mCaveX[num138];
                    num140 = mCaveY[num138];
                }
                if (!Main.tile[num139, num140].active && ((num140 > Main.worldSurface) || (Main.tile[num139, num140].wall > 0)))
                {
                    while (!Main.tile[num139, num140].active && (num140 > ((int) num2)))
                    {
                        num140--;
                    }
                    num140++;
                    int num141 = 1;
                    if (genRand.Next(2) == 0)
                    {
                        num141 = -1;
                    }
                    while ((!Main.tile[num139, num140].active && (num139 > 10)) && (num139 < (Main.maxTilesX - 10)))
                    {
                        num139 += num141;
                    }
                    num139 -= num141;
                    if ((num140 > Main.worldSurface) || (Main.tile[num139, num140].wall > 0))
                    {
                        TileRunner(num139, num140, (double) genRand.Next(4, 13), genRand.Next(2, 5), 0x33, true, (float) num141, -1f, false, false);
                    }
                }
            }
            //Main.statusText = "Creating underworld: 0%";
            int num142 = Main.maxTilesY - genRand.Next(150, 190);
            for (int num143 = 0; num143 < Main.maxTilesX; num143++)
            {
                num142 += genRand.Next(-3, 4);
                if (num142 < (Main.maxTilesY - 190))
                {
                    num142 = Main.maxTilesY - 190;
                }
                if (num142 > (Main.maxTilesY - 160))
                {
                    num142 = Main.maxTilesY - 160;
                }
                for (int num144 = (num142 - 20) - genRand.Next(3); num144 < Main.maxTilesY; num144++)
                {
                    if (num144 >= num142)
                    {
                        Main.tile[num143, num144].active = false;
                        Main.tile[num143, num144].lava = false;
                        Main.tile[num143, num144].liquid = 0;
                    }
                    else
                    {
                        Main.tile[num143, num144].type = 0x39;
                    }
                }
            }
            int num145 = Main.maxTilesY - genRand.Next(40, 70);
            for (int num146 = 10; num146 < (Main.maxTilesX - 10); num146++)
            {
                num145 += genRand.Next(-10, 11);
                if (num145 > (Main.maxTilesY - 60))
                {
                    num145 = Main.maxTilesY - 60;
                }
                if (num145 < (Main.maxTilesY - 100))
                {
                    num145 = Main.maxTilesY - 120;
                }
                for (int num147 = num145; num147 < (Main.maxTilesY - 10); num147++)
                {
                    if (!Main.tile[num146, num147].active)
                    {
                        Main.tile[num146, num147].lava = true;
                        Main.tile[num146, num147].liquid = 0xff;
                    }
                }
            }
            for (int num148 = 0; num148 < Main.maxTilesX; num148++)
            {
                if (genRand.Next(50) == 0)
                {
                    int num149 = Main.maxTilesY - 0x41;
                    while (!Main.tile[num148, num149].active && (num149 > (Main.maxTilesY - 0x87)))
                    {
                        num149--;
                    }
                    TileRunner(genRand.Next(0, Main.maxTilesX), num149 + genRand.Next(20, 50), (double) genRand.Next(15, 20), 0x3e8, 0x39, true, 0f, (float) genRand.Next(1, 3), true, true);
                }
            }
            Liquid.QuickWater(-2, -1, -1);
            for (int num150 = 0; num150 < Main.maxTilesX; num150++)
            {
                float num151 = ((float) num150) / ((float) (Main.maxTilesX - 1));
                //Main.statusText = "Creating underworld: " + ((int) (((num151 * 100f) / 2f) + 50f)) + "%";
                if (genRand.Next(13) == 0)
                {
                    int num152 = Main.maxTilesY - 0x41;
                    while (((Main.tile[num150, num152].liquid > 0) || Main.tile[num150, num152].active) && (num152 > (Main.maxTilesY - 140)))
                    {
                        num152--;
                    }
                    TileRunner(num150, num152 - genRand.Next(2, 5), (double) genRand.Next(5, 30), 0x3e8, 0x39, true, 0f, (float) genRand.Next(1, 3), true, true);
                    float num153 = genRand.Next(1, 3);
                    if (genRand.Next(3) == 0)
                    {
                        num153 *= 0.5f;
                    }
                    if (genRand.Next(2) == 0)
                    {
                        TileRunner(num150, num152 - genRand.Next(2, 5), (double) ((int) (genRand.Next(5, 15) * num153)), (int) (genRand.Next(10, 15) * num153), 0x39, true, 1f, 0.3f, false, true);
                    }
                    if (genRand.Next(2) == 0)
                    {
                        num153 = genRand.Next(1, 3);
                        TileRunner(num150, num152 - genRand.Next(2, 5), (double) ((int) (genRand.Next(5, 15) * num153)), (int) (genRand.Next(10, 15) * num153), 0x39, true, -1f, 0.3f, false, true);
                    }
                    TileRunner(num150 + genRand.Next(-10, 10), num152 + genRand.Next(-10, 10), (double) genRand.Next(5, 15), genRand.Next(5, 10), -2, false, (float) genRand.Next(-1, 3), (float) genRand.Next(-1, 3), false, true);
                    if (genRand.Next(3) == 0)
                    {
                        TileRunner(num150 + genRand.Next(-10, 10), num152 + genRand.Next(-10, 10), (double) genRand.Next(10, 30), genRand.Next(10, 20), -2, false, (float) genRand.Next(-1, 3), (float) genRand.Next(-1, 3), false, true);
                    }
                    if (genRand.Next(5) == 0)
                    {
                        TileRunner(num150 + genRand.Next(-15, 15), num152 + genRand.Next(-15, 10), (double) genRand.Next(15, 30), genRand.Next(5, 20), -2, false, (float) genRand.Next(-1, 3), (float) genRand.Next(-1, 3), false, true);
                    }
                }
            }
            for (int num154 = 0; num154 < Main.maxTilesX; num154++)
            {
                TileRunner(genRand.Next(20, Main.maxTilesX - 20), genRand.Next(Main.maxTilesY - 180, Main.maxTilesY - 10), (double) genRand.Next(2, 7), genRand.Next(2, 7), -2, false, 0f, 0f, false, true);
            }
            for (int num155 = 0; num155 < Main.maxTilesX; num155++)
            {
                if (!Main.tile[num155, Main.maxTilesY - 0x91].active)
                {
                    Main.tile[num155, Main.maxTilesY - 0x91].liquid = 0xff;
                    Main.tile[num155, Main.maxTilesY - 0x91].lava = true;
                }
                if (!Main.tile[num155, Main.maxTilesY - 0x90].active)
                {
                    Main.tile[num155, Main.maxTilesY - 0x90].liquid = 0xff;
                    Main.tile[num155, Main.maxTilesY - 0x90].lava = true;
                }
            }
            for (int num156 = 0; num156 < ((int) ((Main.maxTilesX * Main.maxTilesY) * 0.0008)); num156++)
            {
                TileRunner(genRand.Next(0, Main.maxTilesX), genRand.Next(Main.maxTilesY - 140, Main.maxTilesY), (double) genRand.Next(2, 7), genRand.Next(3, 7), 0x3a, false, 0f, 0f, false, true);
            }
            AddHellHouses();
            int num157 = genRand.Next(2, (int) (Main.maxTilesX * 0.005));
            for (int num158 = 0; num158 < num157; num158++)
            {
                float num159 = ((float) num158) / ((float) num157);
                //Main.statusText = "Adding water bodies: " + ((int) (num159 * 100f)) + "%";
                int num160 = genRand.Next(300, Main.maxTilesX - 300);
                while ((num160 > ((Main.maxTilesX / 2) - 50)) && (num160 < ((Main.maxTilesX / 2) + 50)))
                {
                    num160 = genRand.Next(300, Main.maxTilesX - 300);
                }
                int num161 = ((int) num2) - 20;
                while (!Main.tile[num160, num161].active)
                {
                    num161++;
                }
                Lakinater(num160, num161);
            }
            int x = 0;
            if (num9 == -1)
            {
                x = genRand.Next((int) (Main.maxTilesX * 0.05), (int) (Main.maxTilesX * 0.2));
                num9 = -1;
            }
            else
            {
                x = genRand.Next((int) (Main.maxTilesX * 0.8), (int) (Main.maxTilesX * 0.95));
                num9 = 1;
            }
            int y = ((int) ((Main.rockLayer + Main.maxTilesY) / 2.0)) + genRand.Next(-200, 200);
            MakeDungeon(x, y, 0x29, 7);
            for (int num164 = 0; num164 < (Main.maxTilesX * 0.00045); num164++)
            {
                float num165 = (float) (((double) num164) / (Main.maxTilesX * 0.00045));
                //Main.statusText = "Making the world evil: " + ((int) (num165 * 100f)) + "%";
                bool flag8 = false;
                int num166 = 0;
                int num167 = 0;
                int num168 = 0;
                while (!flag8)
                {
                    int num169 = 0;
                    flag8 = true;
                    int num170 = Main.maxTilesX / 2;
                    int num171 = 200;
                    num166 = genRand.Next(320, Main.maxTilesX - 320);
                    num167 = (num166 - genRand.Next(200)) - 100;
                    num168 = (num166 + genRand.Next(200)) + 100;
                    if (num167 < 0x11d)
                    {
                        num167 = 0x11d;
                    }
                    if (num168 > (Main.maxTilesX - 0x11d))
                    {
                        num168 = Main.maxTilesX - 0x11d;
                    }
                    if ((num166 > (num170 - num171)) && (num166 < (num170 + num171)))
                    {
                        flag8 = false;
                    }
                    if ((num167 > (num170 - num171)) && (num167 < (num170 + num171)))
                    {
                        flag8 = false;
                    }
                    if ((num168 > (num170 - num171)) && (num168 < (num170 + num171)))
                    {
                        flag8 = false;
                    }
                    for (int num172 = num167; num172 < num168; num172++)
                    {
                        for (int num173 = 0; num173 < ((int) Main.worldSurface); num173 += 5)
                        {
                            if (Main.tile[num172, num173].active && Main.tileDungeon[Main.tile[num172, num173].type])
                            {
                                flag8 = false;
                                break;
                            }
                            if (!flag8)
                            {
                                break;
                            }
                        }
                    }
                    if (((num169 < 200) && (JungleX > num167)) && (JungleX < num168))
                    {
                        num169++;
                        flag8 = false;
                    }
                }
                int num174 = 0;
                for (int num175 = num167; num175 < num168; num175++)
                {
                    if (num174 > 0)
                    {
                        num174--;
                    }
                    if ((num175 == num166) || (num174 == 0))
                    {
                        for (int num176 = (int) num2; num176 < (Main.worldSurface - 1.0); num176++)
                        {
                            if (Main.tile[num175, num176].active || (Main.tile[num175, num176].wall > 0))
                            {
                                if (num175 == num166)
                                {
                                    num174 = 20;
                                    ChasmRunner(num175, num176, genRand.Next(150) + 150, true);
                                }
                                else if ((genRand.Next(0x23) == 0) && (num174 == 0))
                                {
                                    num174 = 30;
                                    bool makeOrb = true;
                                    ChasmRunner(num175, num176, genRand.Next(50) + 50, makeOrb);
                                }
                                break;
                            }
                        }
                    }
                    for (int num177 = (int) num2; num177 < (Main.worldSurface - 1.0); num177++)
                    {
                        if (Main.tile[num175, num177].active)
                        {
                            int num178 = num177 + genRand.Next(10, 14);
                            for (int num179 = num177; num179 < num178; num179++)
                            {
                                if (((Main.tile[num175, num179].type == 0x3b) || (Main.tile[num175, num179].type == 60)) && ((num175 >= (num167 + genRand.Next(5))) && (num175 < (num168 - genRand.Next(5)))))
                                {
                                    Main.tile[num175, num179].type = 0;
                                }
                            }
                            break;
                        }
                    }
                }
                double num180 = Main.worldSurface + 40.0;
                for (int num181 = num167; num181 < num168; num181++)
                {
                    num180 += genRand.Next(-2, 3);
                    if (num180 < (Main.worldSurface + 30.0))
                    {
                        num180 = Main.worldSurface + 30.0;
                    }
                    if (num180 > (Main.worldSurface + 50.0))
                    {
                        num180 = Main.worldSurface + 50.0;
                    }
                    num56 = num181;
                    bool flag10 = false;
                    for (int num182 = (int) num2; num182 < num180; num182++)
                    {
                        if (Main.tile[num56, num182].active)
                        {
                            if (((Main.tile[num56, num182].type == 0x35) && (num56 >= (num167 + genRand.Next(5)))) && (num56 <= (num168 - genRand.Next(5))))
                            {
                                Main.tile[num56, num182].type = 0;
                            }
                            if (((Main.tile[num56, num182].type == 0) && (num182 < (Main.worldSurface - 1.0))) && !flag10)
                            {
                                SpreadGrass(num56, num182, 0, 0x17, true);
                            }
                            flag10 = true;
                            if (((Main.tile[num56, num182].type == 1) && (num56 >= (num167 + genRand.Next(5)))) && (num56 <= (num168 - genRand.Next(5))))
                            {
                                Main.tile[num56, num182].type = 0x19;
                            }
                            if (Main.tile[num56, num182].type == 2)
                            {
                                Main.tile[num56, num182].type = 0x17;
                            }
                        }
                    }
                }
                for (int num183 = num167; num183 < num168; num183++)
                {
                    for (int num184 = 0; num184 < (Main.maxTilesY - 50); num184++)
                    {
                        if (Main.tile[num183, num184].active && (Main.tile[num183, num184].type == 0x1f))
                        {
                            int num185 = num183 - 13;
                            int num186 = num183 + 13;
                            int num187 = num184 - 13;
                            int num188 = num184 + 13;
                            for (int num189 = num185; num189 < num186; num189++)
                            {
                                if ((num189 > 10) && (num189 < (Main.maxTilesX - 10)))
                                {
                                    for (int num190 = num187; num190 < num188; num190++)
                                    {
                                        if ((((Math.Abs((int) (num189 - num183)) + Math.Abs((int) (num190 - num184))) < (9 + genRand.Next(11))) && (genRand.Next(3) != 0)) && (Main.tile[num189, num190].type != 0x1f))
                                        {
                                            Main.tile[num189, num190].active = true;
                                            Main.tile[num189, num190].type = 0x19;
                                            if ((Math.Abs((int) (num189 - num183)) <= 1) && (Math.Abs((int) (num190 - num184)) <= 1))
                                            {
                                                Main.tile[num189, num190].active = false;
                                            }
                                        }
                                        if (((Main.tile[num189, num190].type != 0x1f) && (Math.Abs((int) (num189 - num183)) <= (2 + genRand.Next(3)))) && (Math.Abs((int) (num190 - num184)) <= (2 + genRand.Next(3))))
                                        {
                                            Main.tile[num189, num190].active = false;
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
            //Main.statusText = "Generating mountain caves...";
            for (int num191 = 0; num191 < numMCaves; num191++)
            {
                int num192 = mCaveX[num191];
                int num193 = mCaveY[num191];
                CaveOpenater(num192, num193);
                Cavinator(num192, num193, genRand.Next(40, 50));
            }
            int num194 = 0;
            int num195 = 0;
            int num196 = 20;
            int num197 = Main.maxTilesX - 20;
            //Main.statusText = "Creating beaches...";
            for (int num198 = 0; num198 < 2; num198++)
            {
                int num199 = 0;
                int num200 = 0;
                if (num198 == 0)
                {
                    num199 = 0;
                    num200 = genRand.Next(0x7d, 200) + 50;
                    if (num9 == 1)
                    {
                        num200 = 0x113;
                    }
                    int num201 = 0;
                    float num202 = 1f;
                    int num203 = 0;
                    while (!Main.tile[num200 - 1, num203].active)
                    {
                        num203++;
                    }
                    num194 = num203;
                    num203 += genRand.Next(1, 5);
                    for (int num204 = num200 - 1; num204 >= num199; num204--)
                    {
                        num201++;
                        if (num201 < 3)
                        {
                            num202 += genRand.Next(10, 20) * 0.2f;
                        }
                        else if (num201 < 6)
                        {
                            num202 += genRand.Next(10, 20) * 0.15f;
                        }
                        else if (num201 < 9)
                        {
                            num202 += genRand.Next(10, 20) * 0.1f;
                        }
                        else if (num201 < 15)
                        {
                            num202 += genRand.Next(10, 20) * 0.07f;
                        }
                        else if (num201 < 50)
                        {
                            num202 += genRand.Next(10, 20) * 0.05f;
                        }
                        else if (num201 < 0x4b)
                        {
                            num202 += genRand.Next(10, 20) * 0.04f;
                        }
                        else if (num201 < 100)
                        {
                            num202 += genRand.Next(10, 20) * 0.03f;
                        }
                        else if (num201 < 0x7d)
                        {
                            num202 += genRand.Next(10, 20) * 0.02f;
                        }
                        else if (num201 < 150)
                        {
                            num202 += genRand.Next(10, 20) * 0.01f;
                        }
                        else if (num201 < 0xaf)
                        {
                            num202 += genRand.Next(10, 20) * 0.005f;
                        }
                        else if (num201 < 200)
                        {
                            num202 += genRand.Next(10, 20) * 0.001f;
                        }
                        else if (num201 < 230)
                        {
                            num202 += genRand.Next(10, 20) * 0.01f;
                        }
                        else if (num201 < 0xeb)
                        {
                            num202 += genRand.Next(10, 20) * 0.05f;
                        }
                        else if (num201 < 240)
                        {
                            num202 += genRand.Next(10, 20) * 0.1f;
                        }
                        else if (num201 < 0xf5)
                        {
                            num202 += genRand.Next(10, 20) * 0.05f;
                        }
                        else if (num201 < 0xff)
                        {
                            num202 += genRand.Next(10, 20) * 0.01f;
                        }
                        if (num201 == 0xeb)
                        {
                            num197 = num204;
                        }
                        if (num201 == 0xeb)
                        {
                            num196 = num204;
                        }
                        int num205 = genRand.Next(15, 20);
                        for (int num206 = 0; num206 < ((num203 + num202) + num205); num206++)
                        {
                            if (num206 < ((num203 + (num202 * 0.75f)) - 3f))
                            {
                                Main.tile[num204, num206].active = false;
                                if (num206 > num203)
                                {
                                    Main.tile[num204, num206].liquid = 0xff;
                                }
                                else if (num206 == num203)
                                {
                                    Main.tile[num204, num206].liquid = 0x7f;
                                }
                            }
                            else if (num206 > num203)
                            {
                                Main.tile[num204, num206].type = 0x35;
                                Main.tile[num204, num206].active = true;
                            }
                            Main.tile[num204, num206].wall = 0;
                        }
                    }
                }
                else
                {
                    num199 = (Main.maxTilesX - genRand.Next(0x7d, 200)) - 50;
                    num200 = Main.maxTilesX;
                    if (num9 == -1)
                    {
                        num199 = Main.maxTilesX - 0x113;
                    }
                    float num207 = 1f;
                    int num208 = 0;
                    int num209 = 0;
                    while (!Main.tile[num199, num209].active)
                    {
                        num209++;
                    }
                    num195 = num209;
                    num209 += genRand.Next(1, 5);
                    for (int num210 = num199; num210 < num200; num210++)
                    {
                        num208++;
                        if (num208 < 3)
                        {
                            num207 += genRand.Next(10, 20) * 0.2f;
                        }
                        else if (num208 < 6)
                        {
                            num207 += genRand.Next(10, 20) * 0.15f;
                        }
                        else if (num208 < 9)
                        {
                            num207 += genRand.Next(10, 20) * 0.1f;
                        }
                        else if (num208 < 15)
                        {
                            num207 += genRand.Next(10, 20) * 0.07f;
                        }
                        else if (num208 < 50)
                        {
                            num207 += genRand.Next(10, 20) * 0.05f;
                        }
                        else if (num208 < 0x4b)
                        {
                            num207 += genRand.Next(10, 20) * 0.04f;
                        }
                        else if (num208 < 100)
                        {
                            num207 += genRand.Next(10, 20) * 0.03f;
                        }
                        else if (num208 < 0x7d)
                        {
                            num207 += genRand.Next(10, 20) * 0.02f;
                        }
                        else if (num208 < 150)
                        {
                            num207 += genRand.Next(10, 20) * 0.01f;
                        }
                        else if (num208 < 0xaf)
                        {
                            num207 += genRand.Next(10, 20) * 0.005f;
                        }
                        else if (num208 < 200)
                        {
                            num207 += genRand.Next(10, 20) * 0.001f;
                        }
                        else if (num208 < 230)
                        {
                            num207 += genRand.Next(10, 20) * 0.01f;
                        }
                        else if (num208 < 0xeb)
                        {
                            num207 += genRand.Next(10, 20) * 0.05f;
                        }
                        else if (num208 < 240)
                        {
                            num207 += genRand.Next(10, 20) * 0.1f;
                        }
                        else if (num208 < 0xf5)
                        {
                            num207 += genRand.Next(10, 20) * 0.05f;
                        }
                        else if (num208 < 0xff)
                        {
                            num207 += genRand.Next(10, 20) * 0.01f;
                        }
                        if (num208 == 0xeb)
                        {
                            num197 = num210;
                        }
                        int num211 = genRand.Next(15, 20);
                        for (int num212 = 0; num212 < ((num209 + num207) + num211); num212++)
                        {
                            if ((num212 < ((num209 + (num207 * 0.75f)) - 3f)) && (num212 < (Main.worldSurface - 2.0)))
                            {
                                Main.tile[num210, num212].active = false;
                                if (num212 > num209)
                                {
                                    Main.tile[num210, num212].liquid = 0xff;
                                }
                                else if (num212 == num209)
                                {
                                    Main.tile[num210, num212].liquid = 0x7f;
                                }
                            }
                            else if (num212 > num209)
                            {
                                Main.tile[num210, num212].type = 0x35;
                                Main.tile[num210, num212].active = true;
                            }
                            Main.tile[num210, num212].wall = 0;
                        }
                    }
                }
            }
            while (!Main.tile[num196, num194].active)
            {
                num194++;
            }
            num194++;
            while (!Main.tile[num197, num195].active)
            {
                num195++;
            }
            num195++;
            //Main.statusText = "Adding gems...";
            for (int num213 = 0x3f; num213 <= 0x44; num213++)
            {
                float num214 = 0f;
                switch (num213)
                {
                    case 0x43:
                        num214 = Main.maxTilesX * 0.5f;
                        break;

                    case 0x42:
                        num214 = Main.maxTilesX * 0.45f;
                        break;

                    case 0x3f:
                        num214 = Main.maxTilesX * 0.3f;
                        break;

                    case 0x41:
                        num214 = Main.maxTilesX * 0.25f;
                        break;

                    case 0x40:
                        num214 = Main.maxTilesX * 0.1f;
                        break;

                    case 0x44:
                        num214 = Main.maxTilesX * 0.05f;
                        break;
                }
                num214 *= 0.2f;
                for (int num215 = 0; num215 < num214; num215++)
                {
                    int num216 = genRand.Next(0, Main.maxTilesX);
                    int num217 = genRand.Next((int) Main.worldSurface, Main.maxTilesY);
                    while (Main.tile[num216, num217].type != 1)
                    {
                        num216 = genRand.Next(0, Main.maxTilesX);
                        num217 = genRand.Next((int) Main.worldSurface, Main.maxTilesY);
                    }
                    TileRunner(num216, num217, (double) genRand.Next(2, 6), genRand.Next(3, 7), num213, false, 0f, 0f, false, true);
                }
            }
            for (int num218 = 0; num218 < Main.maxTilesX; num218++)
            {
                float num219 = ((float) num218) / ((float) (Main.maxTilesX - 1));
                //Main.statusText = "Gravitating sand: " + ((int) (num219 * 100f)) + "%";
                for (int num220 = Main.maxTilesY - 5; num220 > 0; num220--)
                {
                    if (Main.tile[num218, num220].active && (Main.tile[num218, num220].type == 0x35))
                    {
                        for (int num221 = num220; !Main.tile[num218, num221 + 1].active && (num221 < (Main.maxTilesY - 5)); num221++)
                        {
                            Main.tile[num218, num221 + 1].active = true;
                            Main.tile[num218, num221 + 1].type = 0x35;
                        }
                    }
                }
            }
            for (int num222 = 3; num222 < (Main.maxTilesX - 3); num222++)
            {
                float num223 = ((float) num222) / ((float) Main.maxTilesX);
                //Main.statusText = "Cleaning up dirt backgrounds: " + ((int) ((num223 * 100f) + 1f)) + "%";
                bool flag11 = true;
                for (int num224 = 0; num224 < Main.worldSurface; num224++)
                {
                    if (flag11)
                    {
                        if (Main.tile[num222, num224].wall == 2)
                        {
                            Main.tile[num222, num224].wall = 0;
                        }
                        if (Main.tile[num222, num224].type != 0x35)
                        {
                            if (Main.tile[num222 - 1, num224].wall == 2)
                            {
                                Main.tile[num222 - 1, num224].wall = 0;
                            }
                            if ((Main.tile[num222 - 2, num224].wall == 2) && (genRand.Next(2) == 0))
                            {
                                Main.tile[num222 - 2, num224].wall = 0;
                            }
                            if ((Main.tile[num222 - 3, num224].wall == 2) && (genRand.Next(2) == 0))
                            {
                                Main.tile[num222 - 3, num224].wall = 0;
                            }
                            if (Main.tile[num222 + 1, num224].wall == 2)
                            {
                                Main.tile[num222 + 1, num224].wall = 0;
                            }
                            if ((Main.tile[num222 + 2, num224].wall == 2) && (genRand.Next(2) == 0))
                            {
                                Main.tile[num222 + 2, num224].wall = 0;
                            }
                            if ((Main.tile[num222 + 3, num224].wall == 2) && (genRand.Next(2) == 0))
                            {
                                Main.tile[num222 + 3, num224].wall = 0;
                            }
                            if (Main.tile[num222, num224].active)
                            {
                                flag11 = false;
                            }
                        }
                    }
                    else if (((((Main.tile[num222, num224].wall == 0) && (Main.tile[num222, num224 + 1].wall == 0)) && ((Main.tile[num222, num224 + 2].wall == 0) && (Main.tile[num222, num224 + 3].wall == 0))) && (((Main.tile[num222, num224 + 4].wall == 0) && (Main.tile[num222 - 1, num224].wall == 0)) && ((Main.tile[num222 + 1, num224].wall == 0) && (Main.tile[num222 - 2, num224].wall == 0)))) && ((((Main.tile[num222 + 2, num224].wall == 0) && !Main.tile[num222, num224].active) && (!Main.tile[num222, num224 + 1].active && !Main.tile[num222, num224 + 2].active)) && !Main.tile[num222, num224 + 3].active))
                    {
                        flag11 = true;
                    }
                }
            }
            for (int num225 = 0; num225 < ((int) ((Main.maxTilesX * Main.maxTilesY) * 2E-05)); num225++)
            {
                float num226 = (float) (((double) num225) / ((Main.maxTilesX * Main.maxTilesY) * 2E-05));
                //Main.statusText = "Placing altars: " + ((int) ((num226 * 100f) + 1f)) + "%";
                bool flag12 = false;
                int num227 = 0;
                while (!flag12)
                {
                    int num228 = genRand.Next(1, Main.maxTilesX);
                    int num229 = (int) (num3 + 20.0);
                    Place3x2(num228, num229, 0x1a);
                    if (Main.tile[num228, num229].type == 0x1a)
                    {
                        flag12 = true;
                    }
                    else
                    {
                        num227++;
                        if (num227 >= 0x2710)
                        {
                            flag12 = true;
                        }
                    }
                }
            }
            for (int num230 = 0; num230 < Main.maxTilesX; num230++)
            {
                num56 = num230;
                for (int num231 = (int) num2; num231 < (Main.worldSurface - 1.0); num231++)
                {
                    if (Main.tile[num56, num231].active)
                    {
                        if (Main.tile[num56, num231].type == 60)
                        {
                            Main.tile[num56, num231 - 1].liquid = 0xff;
                            Main.tile[num56, num231 - 2].liquid = 0xff;
                        }
                        break;
                    }
                }
            }
            for (int num232 = 400; num232 < (Main.maxTilesX - 400); num232++)
            {
                num56 = num232;
                for (int num233 = (int) num2; num233 < (Main.worldSurface - 1.0); num233++)
                {
                    if (Main.tile[num56, num233].active)
                    {
                        if (Main.tile[num56, num233].type == 0x35)
                        {
                            int num234 = num233;
                            while (num234 > num2)
                            {
                                num234--;
                                Main.tile[num56, num234].liquid = 0;
                            }
                        }
                        break;
                    }
                }
            }
            Liquid.QuickWater(3, -1, -1);
            WaterCheck();
            int num235 = 0;
            Liquid.quickSettle = true;
            while (num235 < 10)
            {
                int num236 = Liquid.numLiquid + LiquidBuffer.numLiquidBuffer;
                num235++;
                float num237 = 0f;
                while (Liquid.numLiquid > 0)
                {
                    float num238 = ((float) (num236 - (Liquid.numLiquid + LiquidBuffer.numLiquidBuffer))) / ((float) num236);
                    if ((Liquid.numLiquid + LiquidBuffer.numLiquidBuffer) > num236)
                    {
                        num236 = Liquid.numLiquid + LiquidBuffer.numLiquidBuffer;
                    }
                    if (num238 > num237)
                    {
                        num237 = num238;
                    }
                    else
                    {
                        num238 = num237;
                    }
                    if (num235 == 1)
                    {
                        //Main.statusText = "Settling liquids: " + ((int) (((num238 * 100f) / 3f) + 33f)) + "%";
                    }
                    int num239 = 10;
                    if (num235 > num239)
                    {
                        num239 = num235;
                    }
                    Liquid.UpdateLiquid();
                }
                WaterCheck();
                //Main.statusText = "Settling liquids: " + ((int) (((num235 * 10f) / 3f) + 66f)) + "%";
            }
            Liquid.quickSettle = false;
            float num240 = Main.maxTilesX / 0x1068;
            for (int num241 = 0; num241 < ((int) ((Main.maxTilesX * Main.maxTilesY) * 2E-05)); num241++)
            {
                float num242 = (float) (((double) num241) / ((Main.maxTilesX * Main.maxTilesY) * 2E-05));
                //Main.statusText = "Placing life crystals: " + ((int) ((num242 * 100f) + 1f)) + "%";
                bool flag13 = false;
                int num243 = 0;
                while (!flag13)
                {
                    if (AddLifeCrystal(genRand.Next(1, Main.maxTilesX), genRand.Next((int) (num3 + 20.0), Main.maxTilesY)))
                    {
                        flag13 = true;
                    }
                    else
                    {
                        num243++;
                        if (num243 >= 0x2710)
                        {
                            flag13 = true;
                        }
                    }
                }
            }
            for (int num244 = 0; num244 < ((int) ((Main.maxTilesX * Main.maxTilesY) * 1.6E-05)); num244++)
            {
                float num245 = (float) (((double) num244) / ((Main.maxTilesX * Main.maxTilesY) * 1.6E-05));
                //Main.statusText = "Hiding treasure: " + ((int) ((num245 * 100f) + 1f)) + "%";
                bool flag14 = false;
                int num246 = 0;
                while (!flag14)
                {
                    int num247 = genRand.Next(20, Main.maxTilesX - 20);
                    int num248 = genRand.Next((int) (num3 + 20.0), Main.maxTilesY - 230);
                    if (num244 <= (3f * num240))
                    {
                        num248 = genRand.Next(Main.maxTilesY - 200, Main.maxTilesY - 50);
                    }
                    while (((Main.tile[num247, num248].wall == 7) || (Main.tile[num247, num248].wall == 8)) || (Main.tile[num247, num248].wall == 9))
                    {
                        num247 = genRand.Next(1, Main.maxTilesX);
                        num248 = genRand.Next((int) (num3 + 20.0), Main.maxTilesY - 230);
                        if (num244 <= 3)
                        {
                            num248 = genRand.Next(Main.maxTilesY - 200, Main.maxTilesY - 50);
                        }
                    }
                    if (AddBuriedChest(num247, num248, 0, false, -1))
                    {
                        flag14 = true;
                    }
                    else
                    {
                        num246++;
                        if (num246 >= 0x1388)
                        {
                            flag14 = true;
                        }
                    }
                }
            }
            for (int num249 = 0; num249 < ((int) (Main.maxTilesX * 0.005)); num249++)
            {
                float num250 = (float) (((double) num249) / (Main.maxTilesX * 0.005));
                //Main.statusText = "Hiding more treasure: " + ((int) ((num250 * 100f) + 1f)) + "%";
                bool flag15 = false;
                int num251 = 0;
                while (!flag15)
                {
                    int num252 = genRand.Next(300, Main.maxTilesX - 300);
                    int num253 = genRand.Next((int) num2, (int) Main.worldSurface);
                    bool flag16 = false;
                    if ((Main.tile[num252, num253].wall == 2) && !Main.tile[num252, num253].active)
                    {
                        flag16 = true;
                    }
                    if (flag16 && AddBuriedChest(num252, num253, 0, true, -1))
                    {
                        flag15 = true;
                    }
                    else
                    {
                        num251++;
                        if (num251 >= 0x7d0)
                        {
                            flag15 = true;
                        }
                    }
                }
            }
            int num254 = 0;
            for (int num255 = 0; num255 < numJChests; num255++)
            {
                float num256 = num255 / numJChests;
                //Main.statusText = "Hiding jungle treasure: " + ((int) ((num256 * 100f) + 1f)) + "%";
                num254++;
                int contain = 0xd3;
                switch (num254)
                {
                    case 1:
                        contain = 0xd3;
                        break;

                    case 2:
                        contain = 0xd4;
                        break;

                    case 3:
                        contain = 0xd5;
                        break;
                }
                if (num254 > 3)
                {
                    num254 = 0;
                }
                if (!AddBuriedChest(JChestX[num255] + genRand.Next(2), JChestY[num255], contain, false, -1))
                {
                    for (int num258 = JChestX[num255]; num258 <= (JChestX[num255] + 1); num258++)
                    {
                        for (int num259 = JChestY[num255]; num259 <= (JChestY[num255] + 1); num259++)
                        {
                            KillTile(num258, num259, false, false, false);
                        }
                    }
                    AddBuriedChest(JChestX[num255], JChestY[num255], contain, false, -1);
                }
            }
            int num260 = 0;
            for (int num261 = 0; num261 < (9f * num240); num261++)
            {
                int num264;
                int num265;
                float num262 = ((float) num261) / (9f * num240);
                //Main.statusText = "Hiding water treasure: " + ((int) ((num262 * 100f) + 1f)) + "%";
                int num263 = 0;
                num260++;
                switch (num260)
                {
                    case 1:
                        num263 = 0xba;
                        break;

                    case 2:
                        num263 = 0x115;
                        break;

                    default:
                        num263 = 0xbb;
                        num260 = 0;
                        break;
                }
                for (bool flag17 = false; !flag17; flag17 = AddBuriedChest(num264, num265, num263, false, -1))
                {
                    num264 = genRand.Next(1, Main.maxTilesX);
                    for (num265 = genRand.Next(1, Main.maxTilesY - 200); (Main.tile[num264, num265].liquid < 200) || Main.tile[num264, num265].lava; num265 = genRand.Next(1, Main.maxTilesY - 200))
                    {
                        num264 = genRand.Next(1, Main.maxTilesX);
                    }
                }
            }
            for (int num266 = 0; num266 < numIslandHouses; num266++)
            {
                IslandHouse(fihX[num266], fihY[num266]);
            }
            for (int num267 = 0; num267 < ((int) ((Main.maxTilesX * Main.maxTilesY) * 0.0008)); num267++)
            {
                float num268 = (float) (((double) num267) / ((Main.maxTilesX * Main.maxTilesY) * 0.0008));
                //Main.statusText = "Placing breakables: " + ((int) ((num268 * 100f) + 1f)) + "%";
                bool flag18 = false;
                int num269 = 0;
            Label_5883:
                while (!flag18)
                {
                    int num270 = genRand.Next((int) num3, Main.maxTilesY - 10);
                    if (num268 > 0.93)
                    {
                        num270 = Main.maxTilesY - 150;
                    }
                    else if (num268 > 0.75)
                    {
                        num270 = (int) num2;
                    }
                    int num271 = genRand.Next(1, Main.maxTilesX);
                    bool flag19 = false;
                    for (int num272 = num270; num272 < Main.maxTilesY; num272++)
                    {
                        if (!flag19)
                        {
                            if ((Main.tile[num271, num272].active && Main.tileSolid[Main.tile[num271, num272].type]) && !Main.tile[num271, num272 - 1].lava)
                            {
                                flag19 = true;
                            }
                        }
                        else
                        {
                            if (PlacePot(num271, num272, 0x1c))
                            {
                                flag18 = true;
                                goto Label_5883;
                            }
                            num269++;
                            if (num269 >= 0x2710)
                            {
                                flag18 = true;
                                goto Label_5883;
                            }
                        }
                    }
                }
            }
            for (int num273 = 0; num273 < (Main.maxTilesX / 200); num273++)
            {
                float num274 = num273 / (Main.maxTilesX / 200);
                //Main.statusText = "Placing hellforges: " + ((int) ((num274 * 100f) + 1f)) + "%";
                bool flag20 = false;
                int num275 = 0;
                while (!flag20)
                {
                    int num276 = genRand.Next(1, Main.maxTilesX);
                    int num277 = genRand.Next(Main.maxTilesY - 250, Main.maxTilesY - 5);
                    try
                    {
                        if ((Main.tile[num276, num277].wall == 13) || (Main.tile[num276, num277].wall == 14))
                        {
                            while (!Main.tile[num276, num277].active)
                            {
                                num277++;
                            }
                            num277--;
                            PlaceTile(num276, num277, 0x4d, false, false, -1, 0);
                            if (Main.tile[num276, num277].type == 0x4d)
                            {
                                flag20 = true;
                            }
                            else
                            {
                                num275++;
                                if (num275 >= 0x2710)
                                {
                                    flag20 = true;
                                }
                            }
                        }
                        continue;
                    }
                    catch
                    {
                        continue;
                    }
                }
            }
            //Main.statusText = "Spreading grass...";
            for (int num278 = 0; num278 < Main.maxTilesX; num278++)
            {
                num56 = num278;
                bool flag21 = true;
                for (int num279 = 0; num279 < (Main.worldSurface - 1.0); num279++)
                {
                    if (Main.tile[num56, num279].active)
                    {
                        if (flag21 && (Main.tile[num56, num279].type == 0))
                        {
                            SpreadGrass(num56, num279, 0, 2, true);
                        }
                        if (num279 > num3)
                        {
                            break;
                        }
                        flag21 = false;
                    }
                    else if (Main.tile[num56, num279].wall == 0)
                    {
                        flag21 = true;
                    }
                }
            }
            //Main.statusText = "Growing cacti...";
            for (int num280 = 5; num280 < (Main.maxTilesX - 5); num280++)
            {
                if (genRand.Next(8) == 0)
                {
                    for (int num281 = 0; num281 < (Main.worldSurface - 1.0); num281++)
                    {
                        if ((Main.tile[num280, num281].active && (Main.tile[num280, num281].type == 0x35)) && (!Main.tile[num280, num281 - 1].active && (Main.tile[num280, num281 - 1].wall == 0)))
                        {
                            if ((num280 < 250) || (num280 > (Main.maxTilesX - 250)))
                            {
                                if (((Main.tile[num280, num281 - 2].liquid == 0xff) && (Main.tile[num280, num281 - 3].liquid == 0xff)) && (Main.tile[num280, num281 - 4].liquid == 0xff))
                                {
                                    PlaceTile(num280, num281 - 1, 0x51, true, false, -1, 0);
                                }
                            }
                            else if ((num280 > 400) && (num280 < (Main.maxTilesX - 400)))
                            {
                                PlantCactus(num280, num281);
                            }
                        }
                    }
                }
            }
            int num282 = 5;
            bool flag22 = true;
            while (flag22)
            {
                int num283 = (Main.maxTilesX / 2) + genRand.Next(-num282, num282 + 1);
                for (int num284 = 0; num284 < Main.maxTilesY; num284++)
                {
                    if (Main.tile[num283, num284].active)
                    {
                        Main.spawnTileX = num283;
                        Main.spawnTileY = num284;
                        Main.tile[num283, num284 - 1].lighted = true;
                        break;
                    }
                }
                flag22 = false;
                num282++;
                if (Main.spawnTileY > Main.worldSurface)
                {
                    flag22 = true;
                }
                if (Main.tile[Main.spawnTileX, Main.spawnTileY - 1].liquid > 0)
                {
                    flag22 = true;
                }
            }
            for (int num285 = 10; Main.spawnTileY > Main.worldSurface; num285++)
            {
                int num286 = genRand.Next((Main.maxTilesX / 2) - num285, (Main.maxTilesX / 2) + num285);
                for (int num287 = 0; num287 < Main.maxTilesY; num287++)
                {
                    if (Main.tile[num286, num287].active)
                    {
                        Main.spawnTileX = num286;
                        Main.spawnTileY = num287;
                        Main.tile[num286, num287 - 1].lighted = true;
                        break;
                    }
                }
            }
            int index = NPC.NewNPC(Main.spawnTileX * 0x10, Main.spawnTileY * 0x10, 0x16, 0);
            Main.npc[index].homeTileX = Main.spawnTileX;
            Main.npc[index].homeTileY = Main.spawnTileY;
            Main.npc[index].direction = 1;
            Main.npc[index].homeless = true;
            //Main.statusText = "Planting sunflowers...";
            for (int num289 = 0; num289 < (Main.maxTilesX * 0.002); num289++)
            {
                int num290 = 0;
                int num291 = 0;
                int num292 = 0;
                int num1 = Main.maxTilesX / 2;
                num290 = genRand.Next(Main.maxTilesX);
                num291 = (num290 - genRand.Next(10)) - 7;
                num292 = (num290 + genRand.Next(10)) + 7;
                if (num291 < 0)
                {
                    num291 = 0;
                }
                if (num292 > (Main.maxTilesX - 1))
                {
                    num292 = Main.maxTilesX - 1;
                }
                for (int num293 = num291; num293 < num292; num293++)
                {
                    for (int num294 = 1; num294 < (Main.worldSurface - 1.0); num294++)
                    {
                        if (((Main.tile[num293, num294].type == 2) && Main.tile[num293, num294].active) && !Main.tile[num293, num294 - 1].active)
                        {
                            PlaceTile(num293, num294 - 1, 0x1b, true, false, -1, 0);
                        }
                        if (Main.tile[num293, num294].active)
                        {
                            break;
                        }
                    }
                }
            }
            //Main.statusText = "Planting trees...";
            for (int num295 = 0; num295 < (Main.maxTilesX * 0.003); num295++)
            {
                int num296 = genRand.Next(50, Main.maxTilesX - 50);
                int num297 = genRand.Next(0x19, 50);
                for (int num298 = num296 - num297; num298 < (num296 + num297); num298++)
                {
                    for (int num299 = 20; num299 < Main.worldSurface; num299++)
                    {
                        GrowEpicTree(num298, num299);
                    }
                }
            }
            AddTrees();
            //Main.statusText = "Planting herbs...";
            for (int num300 = 0; num300 < (Main.maxTilesX * 1.7); num300++)
            {
                PlantAlch();
            }
            //Main.statusText = "Planting weeds...";
            AddPlants();
            for (int num301 = 0; num301 < Main.maxTilesX; num301++)
            {
                for (int num302 = 0; num302 < Main.maxTilesY; num302++)
                {
                    if (Main.tile[num301, num302].active)
                    {
                        if (((num302 >= ((int) Main.worldSurface)) && (Main.tile[num301, num302].type == 70)) && !Main.tile[num301, num302 - 1].active)
                        {
                            GrowShroom(num301, num302);
                            if (!Main.tile[num301, num302 - 1].active)
                            {
                                PlaceTile(num301, num302 - 1, 0x47, true, false, -1, 0);
                            }
                        }
                        if ((Main.tile[num301, num302].type == 60) && !Main.tile[num301, num302 - 1].active)
                        {
                            PlaceTile(num301, num302 - 1, 0x3d, true, false, -1, 0);
                        }
                    }
                }
            }
            //Main.statusText = "Growing vines...";
            for (int num303 = 0; num303 < Main.maxTilesX; num303++)
            {
                int num304 = 0;
                for (int num305 = 0; num305 < Main.worldSurface; num305++)
                {
                    if ((num304 > 0) && !Main.tile[num303, num305].active)
                    {
                        Main.tile[num303, num305].active = true;
                        Main.tile[num303, num305].type = 0x34;
                        num304--;
                    }
                    else
                    {
                        num304 = 0;
                    }
                    if ((Main.tile[num303, num305].active && (Main.tile[num303, num305].type == 2)) && (genRand.Next(5) < 3))
                    {
                        num304 = genRand.Next(1, 10);
                    }
                }
                num304 = 0;
                for (int num306 = 0; num306 < Main.maxTilesY; num306++)
                {
                    if ((num304 > 0) && !Main.tile[num303, num306].active)
                    {
                        Main.tile[num303, num306].active = true;
                        Main.tile[num303, num306].type = 0x3e;
                        num304--;
                    }
                    else
                    {
                        num304 = 0;
                    }
                    if ((Main.tile[num303, num306].active && (Main.tile[num303, num306].type == 60)) && (genRand.Next(5) < 3))
                    {
                        num304 = genRand.Next(1, 10);
                    }
                }
            }
            //Main.statusText = "Planting flowers...";
            for (int num307 = 0; num307 < (Main.maxTilesX * 0.005); num307++)
            {
                int num308 = genRand.Next(20, Main.maxTilesX - 20);
                int num309 = genRand.Next(5, 15);
                int num310 = genRand.Next(15, 30);
                for (int num311 = 1; num311 < (Main.worldSurface - 1.0); num311++)
                {
                    if (Main.tile[num308, num311].active)
                    {
                        for (int num312 = num308 - num309; num312 < (num308 + num309); num312++)
                        {
                            for (int num313 = num311 - num310; num313 < (num311 + num310); num313++)
                            {
                                if ((Main.tile[num312, num313].type == 3) || (Main.tile[num312, num313].type == 0x18))
                                {
                                    Main.tile[num312, num313].frameX = (short) (genRand.Next(6, 8) * 0x12);
                                }
                            }
                        }
                        break;
                    }
                }
            }
            //Main.statusText = "Planting mushrooms...";
            for (int num314 = 0; num314 < (Main.maxTilesX * 0.002); num314++)
            {
                int num315 = genRand.Next(20, Main.maxTilesX - 20);
                int num316 = genRand.Next(4, 10);
                int num317 = genRand.Next(15, 30);
                for (int num318 = 1; num318 < (Main.worldSurface - 1.0); num318++)
                {
                    if (Main.tile[num315, num318].active)
                    {
                        for (int num319 = num315 - num316; num319 < (num315 + num316); num319++)
                        {
                            for (int num320 = num318 - num317; num320 < (num318 + num317); num320++)
                            {
                                if ((Main.tile[num319, num320].type == 3) || (Main.tile[num319, num320].type == 0x18))
                                {
                                    Main.tile[num319, num320].frameX = 0x90;
                                }
                            }
                        }
                        break;
                    }
                }
            }
            gen = false;
        }

        public static void GrowAlch(int x, int y)
        {
            if (Main.tile[x, y].active)
            {
                if ((Main.tile[x, y].type == 0x52) && (genRand.Next(50) == 0))
                {
                    Main.tile[x, y].type = 0x53;
                    if (Main.netMode == 2)
                    {
                        NetMessage.SendTileSquare(-1, x, y, 1);
                    }
                    SquareTileFrame(x, y, true);
                }
                else if (Main.tile[x, y].frameX == 0x24)
                {
                    if (Main.tile[x, y].type == 0x53)
                    {
                        Main.tile[x, y].type = 0x54;
                    }
                    else
                    {
                        Main.tile[x, y].type = 0x53;
                    }
                    if (Main.netMode == 2)
                    {
                        NetMessage.SendTileSquare(-1, x, y, 1);
                    }
                }
            }
        }

        public static void GrowCactus(int i, int j)
        {
            int num = j;
            int num2 = i;
            if ((Main.tile[i, j].active && (Main.tile[i, j - 1].liquid <= 0)) && ((Main.tile[i, j].type == 0x35) || (Main.tile[i, j].type == 80)))
            {
                if (Main.tile[i, j].type == 0x35)
                {
                    if ((!Main.tile[i, j - 1].active && !Main.tile[i - 1, j - 1].active) && !Main.tile[i + 1, j - 1].active)
                    {
                        int num3 = 0;
                        int num4 = 0;
                        for (int k = i - 6; k <= (i + 6); k++)
                        {
                            for (int m = j - 3; m <= (j + 1); m++)
                            {
                                try
                                {
                                    if (Main.tile[k, m].active)
                                    {
                                        if (Main.tile[k, m].type == 80)
                                        {
                                            num3++;
                                            if (num3 >= 4)
                                            {
                                                return;
                                            }
                                        }
                                        if (Main.tile[k, m].type == 0x35)
                                        {
                                            num4++;
                                        }
                                    }
                                }
                                catch
                                {
                                }
                            }
                        }
                        if (num4 > 10)
                        {
                            Main.tile[i, j - 1].active = true;
                            Main.tile[i, j - 1].type = 80;
                            if (Main.netMode == 2)
                            {
                                NetMessage.SendTileSquare(-1, i, j - 1, 1);
                            }
                            SquareTileFrame(num2, num - 1, true);
                        }
                    }
                }
                else if (Main.tile[i, j].type == 80)
                {
                    while (Main.tile[num2, num].active && (Main.tile[num2, num].type == 80))
                    {
                        num++;
                        if (!Main.tile[num2, num].active || (Main.tile[num2, num].type != 80))
                        {
                            if (((Main.tile[num2 - 1, num].active && (Main.tile[num2 - 1, num].type == 80)) && (Main.tile[num2 - 1, num - 1].active && (Main.tile[num2 - 1, num - 1].type == 80))) && (num2 >= i))
                            {
                                num2--;
                            }
                            if (((Main.tile[num2 + 1, num].active && (Main.tile[num2 + 1, num].type == 80)) && (Main.tile[num2 + 1, num - 1].active && (Main.tile[num2 + 1, num - 1].type == 80))) && (num2 <= i))
                            {
                                num2++;
                            }
                        }
                    }
                    num--;
                    int num7 = num - j;
                    int num8 = i - num2;
                    num2 = i - num8;
                    num = j;
                    int num9 = 11 - num7;
                    int num10 = 0;
                    for (int n = num2 - 2; n <= (num2 + 2); n++)
                    {
                        for (int num12 = num - num9; num12 <= (num + num7); num12++)
                        {
                            if (Main.tile[n, num12].active && (Main.tile[n, num12].type == 80))
                            {
                                num10++;
                            }
                        }
                    }
                    if (num10 < genRand.Next(11, 13))
                    {
                        num2 = i;
                        num = j;
                        if (num8 == 0)
                        {
                            if (num7 != 0)
                            {
                                bool flag = false;
                                bool flag2 = false;
                                if (Main.tile[num2, num - 1].active && (Main.tile[num2, num - 1].type == 80))
                                {
                                    if (((!Main.tile[num2 - 1, num].active && !Main.tile[num2 - 2, num + 1].active) && (!Main.tile[num2 - 1, num - 1].active && !Main.tile[num2 - 1, num + 1].active)) && !Main.tile[num2 - 2, num].active)
                                    {
                                        flag = true;
                                    }
                                    if (((!Main.tile[num2 + 1, num].active && !Main.tile[num2 + 2, num + 1].active) && (!Main.tile[num2 + 1, num - 1].active && !Main.tile[num2 + 1, num + 1].active)) && !Main.tile[num2 + 2, num].active)
                                    {
                                        flag2 = true;
                                    }
                                }
                                int num13 = genRand.Next(3);
                                if ((num13 != 0) || !flag)
                                {
                                    if ((num13 != 1) || !flag2)
                                    {
                                        if (num7 < genRand.Next(2, 8))
                                        {
                                            if (Main.tile[num2 - 1, num - 1].active)
                                            {
                                                byte type = Main.tile[num2 - 1, num - 1].type;
                                            }
                                            if ((!Main.tile[num2 + 1, num - 1].active || (Main.tile[num2 + 1, num - 1].type != 80)) && !Main.tile[num2, num - 1].active)
                                            {
                                                Main.tile[num2, num - 1].active = true;
                                                Main.tile[num2, num - 1].type = 80;
                                                SquareTileFrame(num2, num - 1, true);
                                                if (Main.netMode == 2)
                                                {
                                                    NetMessage.SendTileSquare(-1, num2, num - 1, 1);
                                                }
                                            }
                                        }
                                    }
                                    else
                                    {
                                        Main.tile[num2 + 1, num].active = true;
                                        Main.tile[num2 + 1, num].type = 80;
                                        SquareTileFrame(num2 + 1, num, true);
                                        if (Main.netMode == 2)
                                        {
                                            NetMessage.SendTileSquare(-1, num2 + 1, num, 1);
                                        }
                                    }
                                }
                                else
                                {
                                    Main.tile[num2 - 1, num].active = true;
                                    Main.tile[num2 - 1, num].type = 80;
                                    SquareTileFrame(num2 - 1, num, true);
                                    if (Main.netMode == 2)
                                    {
                                        NetMessage.SendTileSquare(-1, num2 - 1, num, 1);
                                    }
                                }
                            }
                            else if (!Main.tile[num2, num - 1].active)
                            {
                                Main.tile[num2, num - 1].active = true;
                                Main.tile[num2, num - 1].type = 80;
                                SquareTileFrame(num2, num - 1, true);
                                if (Main.netMode == 2)
                                {
                                    NetMessage.SendTileSquare(-1, num2, num - 1, 1);
                                }
                            }
                        }
                        else if (((!Main.tile[num2, num - 1].active && !Main.tile[num2, num - 2].active) && (!Main.tile[num2 + num8, num - 1].active && Main.tile[num2 - num8, num - 1].active)) && (Main.tile[num2 - num8, num - 1].type == 80))
                        {
                            Main.tile[num2, num - 1].active = true;
                            Main.tile[num2, num - 1].type = 80;
                            SquareTileFrame(num2, num - 1, true);
                            if (Main.netMode == 2)
                            {
                                NetMessage.SendTileSquare(-1, num2, num - 1, 1);
                            }
                        }
                    }
                }
            }
        }

        public static bool GrowEpicTree(int i, int y)
        {
            int num3;
            int num = y;
            while (Main.tile[i, num].type == 20)
            {
                num++;
            }
            if (((!Main.tile[i, num].active || (Main.tile[i, num].type != 2)) || ((Main.tile[i, num - 1].wall != 0) || (Main.tile[i, num - 1].liquid != 0))) || ((!Main.tile[i - 1, num].active || (Main.tile[i - 1, num].type != 2)) || (!Main.tile[i + 1, num].active || (Main.tile[i + 1, num].type != 2))))
            {
                goto Label_0E9C;
            }
            int num2 = 2;
            if (!EmptyTileCheck(i - num2, i + num2, num - 0x37, num - 1, 20))
            {
                goto Label_0E9C;
            }
            bool flag = false;
            bool flag2 = false;
            int num5 = genRand.Next(20, 30);
            for (int j = num - num5; j < num; j++)
            {
                Main.tile[i, j].frameNumber = (byte) genRand.Next(3);
                Main.tile[i, j].active = true;
                Main.tile[i, j].type = 5;
                num3 = genRand.Next(3);
                int num4 = genRand.Next(10);
                if ((j == (num - 1)) || (j == (num - num5)))
                {
                    num4 = 0;
                }
                while ((((num4 == 5) || (num4 == 7)) && flag) || (((num4 == 6) || (num4 == 7)) && flag2))
                {
                    num4 = genRand.Next(10);
                }
                flag = false;
                flag2 = false;
                if ((num4 == 5) || (num4 == 7))
                {
                    flag = true;
                }
                if ((num4 == 6) || (num4 == 7))
                {
                    flag2 = true;
                }
                if (num4 == 1)
                {
                    switch (num3)
                    {
                        case 0:
                            Main.tile[i, j].frameX = 0;
                            Main.tile[i, j].frameY = 0x42;
                            break;

                        case 1:
                            Main.tile[i, j].frameX = 0;
                            Main.tile[i, j].frameY = 0x58;
                            break;

                        case 2:
                            Main.tile[i, j].frameX = 0;
                            Main.tile[i, j].frameY = 110;
                            break;
                    }
                }
                else if (num4 == 2)
                {
                    switch (num3)
                    {
                        case 0:
                            Main.tile[i, j].frameX = 0x16;
                            Main.tile[i, j].frameY = 0;
                            break;

                        case 1:
                            Main.tile[i, j].frameX = 0x16;
                            Main.tile[i, j].frameY = 0x16;
                            break;

                        case 2:
                            Main.tile[i, j].frameX = 0x16;
                            Main.tile[i, j].frameY = 0x2c;
                            break;
                    }
                }
                else if (num4 == 3)
                {
                    switch (num3)
                    {
                        case 0:
                            Main.tile[i, j].frameX = 0x2c;
                            Main.tile[i, j].frameY = 0x42;
                            break;

                        case 1:
                            Main.tile[i, j].frameX = 0x2c;
                            Main.tile[i, j].frameY = 0x58;
                            break;

                        case 2:
                            Main.tile[i, j].frameX = 0x2c;
                            Main.tile[i, j].frameY = 110;
                            break;
                    }
                }
                else if (num4 == 4)
                {
                    switch (num3)
                    {
                        case 0:
                            Main.tile[i, j].frameX = 0x16;
                            Main.tile[i, j].frameY = 0x42;
                            break;

                        case 1:
                            Main.tile[i, j].frameX = 0x16;
                            Main.tile[i, j].frameY = 0x58;
                            break;

                        case 2:
                            Main.tile[i, j].frameX = 0x16;
                            Main.tile[i, j].frameY = 110;
                            break;
                    }
                }
                else if (num4 == 5)
                {
                    switch (num3)
                    {
                        case 0:
                            Main.tile[i, j].frameX = 0x58;
                            Main.tile[i, j].frameY = 0;
                            break;

                        case 1:
                            Main.tile[i, j].frameX = 0x58;
                            Main.tile[i, j].frameY = 0x16;
                            break;

                        case 2:
                            Main.tile[i, j].frameX = 0x58;
                            Main.tile[i, j].frameY = 0x2c;
                            break;
                    }
                }
                else if (num4 == 6)
                {
                    switch (num3)
                    {
                        case 0:
                            Main.tile[i, j].frameX = 0x42;
                            Main.tile[i, j].frameY = 0x42;
                            break;

                        case 1:
                            Main.tile[i, j].frameX = 0x42;
                            Main.tile[i, j].frameY = 0x58;
                            break;

                        case 2:
                            Main.tile[i, j].frameX = 0x42;
                            Main.tile[i, j].frameY = 110;
                            break;
                    }
                }
                else if (num4 == 7)
                {
                    switch (num3)
                    {
                        case 0:
                            Main.tile[i, j].frameX = 110;
                            Main.tile[i, j].frameY = 0x42;
                            break;

                        case 1:
                            Main.tile[i, j].frameX = 110;
                            Main.tile[i, j].frameY = 0x58;
                            break;

                        case 2:
                            Main.tile[i, j].frameX = 110;
                            Main.tile[i, j].frameY = 110;
                            break;
                    }
                }
                else
                {
                    switch (num3)
                    {
                        case 0:
                            Main.tile[i, j].frameX = 0;
                            Main.tile[i, j].frameY = 0;
                            break;

                        case 1:
                            Main.tile[i, j].frameX = 0;
                            Main.tile[i, j].frameY = 0x16;
                            break;

                        case 2:
                            Main.tile[i, j].frameX = 0;
                            Main.tile[i, j].frameY = 0x2c;
                            break;
                    }
                }
                if ((num4 == 5) || (num4 == 7))
                {
                    Main.tile[i - 1, j].active = true;
                    Main.tile[i - 1, j].type = 5;
                    num3 = genRand.Next(3);
                    if (genRand.Next(3) < 2)
                    {
                        switch (num3)
                        {
                            case 0:
                                Main.tile[i - 1, j].frameX = 0x2c;
                                Main.tile[i - 1, j].frameY = 0xc6;
                                break;

                            case 1:
                                Main.tile[i - 1, j].frameX = 0x2c;
                                Main.tile[i - 1, j].frameY = 220;
                                break;

                            case 2:
                                Main.tile[i - 1, j].frameX = 0x2c;
                                Main.tile[i - 1, j].frameY = 0xf2;
                                break;
                        }
                    }
                    else
                    {
                        switch (num3)
                        {
                            case 0:
                                Main.tile[i - 1, j].frameX = 0x42;
                                Main.tile[i - 1, j].frameY = 0;
                                break;

                            case 1:
                                Main.tile[i - 1, j].frameX = 0x42;
                                Main.tile[i - 1, j].frameY = 0x16;
                                break;

                            case 2:
                                Main.tile[i - 1, j].frameX = 0x42;
                                Main.tile[i - 1, j].frameY = 0x2c;
                                break;
                        }
                    }
                }
                if ((num4 == 6) || (num4 == 7))
                {
                    Main.tile[i + 1, j].active = true;
                    Main.tile[i + 1, j].type = 5;
                    num3 = genRand.Next(3);
                    if (genRand.Next(3) < 2)
                    {
                        switch (num3)
                        {
                            case 0:
                                Main.tile[i + 1, j].frameX = 0x42;
                                Main.tile[i + 1, j].frameY = 0xc6;
                                break;

                            case 1:
                                Main.tile[i + 1, j].frameX = 0x42;
                                Main.tile[i + 1, j].frameY = 220;
                                break;

                            case 2:
                                Main.tile[i + 1, j].frameX = 0x42;
                                Main.tile[i + 1, j].frameY = 0xf2;
                                break;
                        }
                    }
                    else
                    {
                        switch (num3)
                        {
                            case 0:
                                Main.tile[i + 1, j].frameX = 0x58;
                                Main.tile[i + 1, j].frameY = 0x42;
                                break;

                            case 1:
                                Main.tile[i + 1, j].frameX = 0x58;
                                Main.tile[i + 1, j].frameY = 0x58;
                                break;

                            case 2:
                                Main.tile[i + 1, j].frameX = 0x58;
                                Main.tile[i + 1, j].frameY = 110;
                                break;
                        }
                    }
                }
            }
            int num7 = genRand.Next(3);
            if ((num7 == 0) || (num7 == 1))
            {
                Main.tile[i + 1, num - 1].active = true;
                Main.tile[i + 1, num - 1].type = 5;
                switch (genRand.Next(3))
                {
                    case 0:
                        Main.tile[i + 1, num - 1].frameX = 0x16;
                        Main.tile[i + 1, num - 1].frameY = 0x84;
                        break;

                    case 1:
                        Main.tile[i + 1, num - 1].frameX = 0x16;
                        Main.tile[i + 1, num - 1].frameY = 0x9a;
                        break;

                    case 2:
                        Main.tile[i + 1, num - 1].frameX = 0x16;
                        Main.tile[i + 1, num - 1].frameY = 0xb0;
                        goto Label_0A3C;
                }
            }
        Label_0A3C:
            if ((num7 == 0) || (num7 == 2))
            {
                Main.tile[i - 1, num - 1].active = true;
                Main.tile[i - 1, num - 1].type = 5;
                switch (genRand.Next(3))
                {
                    case 0:
                        Main.tile[i - 1, num - 1].frameX = 0x2c;
                        Main.tile[i - 1, num - 1].frameY = 0x84;
                        break;

                    case 1:
                        Main.tile[i - 1, num - 1].frameX = 0x2c;
                        Main.tile[i - 1, num - 1].frameY = 0x9a;
                        break;

                    case 2:
                        Main.tile[i - 1, num - 1].frameX = 0x2c;
                        Main.tile[i - 1, num - 1].frameY = 0xb0;
                        break;
                }
            }
            num3 = genRand.Next(3);
            if (num7 == 0)
            {
                switch (num3)
                {
                    case 0:
                        Main.tile[i, num - 1].frameX = 0x58;
                        Main.tile[i, num - 1].frameY = 0x84;
                        break;

                    case 1:
                        Main.tile[i, num - 1].frameX = 0x58;
                        Main.tile[i, num - 1].frameY = 0x9a;
                        break;

                    case 2:
                        Main.tile[i, num - 1].frameX = 0x58;
                        Main.tile[i, num - 1].frameY = 0xb0;
                        break;
                }
            }
            else if (num7 == 1)
            {
                switch (num3)
                {
                    case 0:
                        Main.tile[i, num - 1].frameX = 0;
                        Main.tile[i, num - 1].frameY = 0x84;
                        break;

                    case 1:
                        Main.tile[i, num - 1].frameX = 0;
                        Main.tile[i, num - 1].frameY = 0x9a;
                        break;

                    case 2:
                        Main.tile[i, num - 1].frameX = 0;
                        Main.tile[i, num - 1].frameY = 0xb0;
                        break;
                }
            }
            else if (num7 == 2)
            {
                switch (num3)
                {
                    case 0:
                        Main.tile[i, num - 1].frameX = 0x42;
                        Main.tile[i, num - 1].frameY = 0x84;
                        break;

                    case 1:
                        Main.tile[i, num - 1].frameX = 0x42;
                        Main.tile[i, num - 1].frameY = 0x9a;
                        break;

                    case 2:
                        Main.tile[i, num - 1].frameX = 0x42;
                        Main.tile[i, num - 1].frameY = 0xb0;
                        break;
                }
            }
            if (genRand.Next(3) < 2)
            {
                switch (genRand.Next(3))
                {
                    case 0:
                        Main.tile[i, num - num5].frameX = 0x16;
                        Main.tile[i, num - num5].frameY = 0xc6;
                        break;

                    case 1:
                        Main.tile[i, num - num5].frameX = 0x16;
                        Main.tile[i, num - num5].frameY = 220;
                        break;

                    case 2:
                        Main.tile[i, num - num5].frameX = 0x16;
                        Main.tile[i, num - num5].frameY = 0xf2;
                        break;
                }
            }
            else
            {
                switch (genRand.Next(3))
                {
                    case 0:
                        Main.tile[i, num - num5].frameX = 0;
                        Main.tile[i, num - num5].frameY = 0xc6;
                        break;

                    case 1:
                        Main.tile[i, num - num5].frameX = 0;
                        Main.tile[i, num - num5].frameY = 220;
                        break;

                    case 2:
                        Main.tile[i, num - num5].frameX = 0;
                        Main.tile[i, num - num5].frameY = 0xf2;
                        break;
                }
            }
            RangeFrame(i - 2, (num - num5) - 1, i + 2, num + 1);
            if (Main.netMode == 2)
            {
                NetMessage.SendTileSquare(-1, i, num - ((int) (num5 * 0.5)), num5 + 1);
            }
            return true;
        Label_0E9C:
            return false;
        }

        public static void GrowShroom(int i, int y)
        {
            int num = y;
            if (((!Main.tile[i - 1, num - 1].lava && !Main.tile[i - 1, num - 1].lava) && !Main.tile[i + 1, num - 1].lava) && (((Main.tile[i, num].active && (Main.tile[i, num].type == 70)) && ((Main.tile[i, num - 1].wall == 0) && Main.tile[i - 1, num].active)) && (((Main.tile[i - 1, num].type == 70) && Main.tile[i + 1, num].active) && ((Main.tile[i + 1, num].type == 70) && EmptyTileCheck(i - 2, i + 2, num - 13, num - 1, 0x47)))))
            {
                int num3 = genRand.Next(4, 11);
                for (int j = num - num3; j < num; j++)
                {
                    Main.tile[i, j].frameNumber = (byte) genRand.Next(3);
                    Main.tile[i, j].active = true;
                    Main.tile[i, j].type = 0x48;
                    switch (genRand.Next(3))
                    {
                        case 0:
                            Main.tile[i, j].frameX = 0;
                            Main.tile[i, j].frameY = 0;
                            break;

                        case 1:
                            Main.tile[i, j].frameX = 0;
                            Main.tile[i, j].frameY = 0x12;
                            break;

                        case 2:
                            Main.tile[i, j].frameX = 0;
                            Main.tile[i, j].frameY = 0x24;
                            break;
                    }
                }
                switch (genRand.Next(3))
                {
                    case 0:
                        Main.tile[i, num - num3].frameX = 0x24;
                        Main.tile[i, num - num3].frameY = 0;
                        break;

                    case 1:
                        Main.tile[i, num - num3].frameX = 0x24;
                        Main.tile[i, num - num3].frameY = 0x12;
                        break;

                    case 2:
                        Main.tile[i, num - num3].frameX = 0x24;
                        Main.tile[i, num - num3].frameY = 0x24;
                        break;
                }
                RangeFrame(i - 2, (num - num3) - 1, i + 2, num + 1);
                if (Main.netMode == 2)
                {
                    NetMessage.SendTileSquare(-1, i, num - ((int) (num3 * 0.5)), num3 + 1);
                }
            }
        }

        public static void GrowTree(int i, int y)
        {
            int num3;
            int num = y;
            while (Main.tile[i, num].type == 20)
            {
                num++;
            }
            if ((((Main.tile[i - 1, num - 1].liquid != 0) || (Main.tile[i - 1, num - 1].liquid != 0)) || (Main.tile[i + 1, num - 1].liquid != 0)) && (Main.tile[i, num].type != 60))
            {
                return;
            }
            if (((!Main.tile[i, num].active || (((Main.tile[i, num].type != 2) && (Main.tile[i, num].type != 0x17)) && (Main.tile[i, num].type != 60))) || (((Main.tile[i, num - 1].wall != 0) || !Main.tile[i - 1, num].active) || (((Main.tile[i - 1, num].type != 2) && (Main.tile[i - 1, num].type != 0x17)) && (Main.tile[i - 1, num].type != 60)))) || (!Main.tile[i + 1, num].active || (((Main.tile[i + 1, num].type != 2) && (Main.tile[i + 1, num].type != 0x17)) && (Main.tile[i + 1, num].type != 60))))
            {
                return;
            }
            int num2 = 2;
            if (!EmptyTileCheck(i - num2, i + num2, num - 14, num - 1, 20))
            {
                return;
            }
            bool flag = false;
            bool flag2 = false;
            int num5 = genRand.Next(5, 15);
            for (int j = num - num5; j < num; j++)
            {
                Main.tile[i, j].frameNumber = (byte) genRand.Next(3);
                Main.tile[i, j].active = true;
                Main.tile[i, j].type = 5;
                num3 = genRand.Next(3);
                int num4 = genRand.Next(10);
                if ((j == (num - 1)) || (j == (num - num5)))
                {
                    num4 = 0;
                }
                while ((((num4 == 5) || (num4 == 7)) && flag) || (((num4 == 6) || (num4 == 7)) && flag2))
                {
                    num4 = genRand.Next(10);
                }
                flag = false;
                flag2 = false;
                if ((num4 == 5) || (num4 == 7))
                {
                    flag = true;
                }
                if ((num4 == 6) || (num4 == 7))
                {
                    flag2 = true;
                }
                if (num4 == 1)
                {
                    switch (num3)
                    {
                        case 0:
                            Main.tile[i, j].frameX = 0;
                            Main.tile[i, j].frameY = 0x42;
                            break;

                        case 1:
                            Main.tile[i, j].frameX = 0;
                            Main.tile[i, j].frameY = 0x58;
                            break;

                        case 2:
                            Main.tile[i, j].frameX = 0;
                            Main.tile[i, j].frameY = 110;
                            break;
                    }
                }
                else if (num4 == 2)
                {
                    switch (num3)
                    {
                        case 0:
                            Main.tile[i, j].frameX = 0x16;
                            Main.tile[i, j].frameY = 0;
                            break;

                        case 1:
                            Main.tile[i, j].frameX = 0x16;
                            Main.tile[i, j].frameY = 0x16;
                            break;

                        case 2:
                            Main.tile[i, j].frameX = 0x16;
                            Main.tile[i, j].frameY = 0x2c;
                            break;
                    }
                }
                else if (num4 == 3)
                {
                    switch (num3)
                    {
                        case 0:
                            Main.tile[i, j].frameX = 0x2c;
                            Main.tile[i, j].frameY = 0x42;
                            break;

                        case 1:
                            Main.tile[i, j].frameX = 0x2c;
                            Main.tile[i, j].frameY = 0x58;
                            break;

                        case 2:
                            Main.tile[i, j].frameX = 0x2c;
                            Main.tile[i, j].frameY = 110;
                            break;
                    }
                }
                else if (num4 == 4)
                {
                    switch (num3)
                    {
                        case 0:
                            Main.tile[i, j].frameX = 0x16;
                            Main.tile[i, j].frameY = 0x42;
                            break;

                        case 1:
                            Main.tile[i, j].frameX = 0x16;
                            Main.tile[i, j].frameY = 0x58;
                            break;

                        case 2:
                            Main.tile[i, j].frameX = 0x16;
                            Main.tile[i, j].frameY = 110;
                            break;
                    }
                }
                else if (num4 == 5)
                {
                    switch (num3)
                    {
                        case 0:
                            Main.tile[i, j].frameX = 0x58;
                            Main.tile[i, j].frameY = 0;
                            break;

                        case 1:
                            Main.tile[i, j].frameX = 0x58;
                            Main.tile[i, j].frameY = 0x16;
                            break;

                        case 2:
                            Main.tile[i, j].frameX = 0x58;
                            Main.tile[i, j].frameY = 0x2c;
                            break;
                    }
                }
                else if (num4 == 6)
                {
                    switch (num3)
                    {
                        case 0:
                            Main.tile[i, j].frameX = 0x42;
                            Main.tile[i, j].frameY = 0x42;
                            break;

                        case 1:
                            Main.tile[i, j].frameX = 0x42;
                            Main.tile[i, j].frameY = 0x58;
                            break;

                        case 2:
                            Main.tile[i, j].frameX = 0x42;
                            Main.tile[i, j].frameY = 110;
                            break;
                    }
                }
                else if (num4 == 7)
                {
                    switch (num3)
                    {
                        case 0:
                            Main.tile[i, j].frameX = 110;
                            Main.tile[i, j].frameY = 0x42;
                            break;

                        case 1:
                            Main.tile[i, j].frameX = 110;
                            Main.tile[i, j].frameY = 0x58;
                            break;

                        case 2:
                            Main.tile[i, j].frameX = 110;
                            Main.tile[i, j].frameY = 110;
                            break;
                    }
                }
                else
                {
                    switch (num3)
                    {
                        case 0:
                            Main.tile[i, j].frameX = 0;
                            Main.tile[i, j].frameY = 0;
                            break;

                        case 1:
                            Main.tile[i, j].frameX = 0;
                            Main.tile[i, j].frameY = 0x16;
                            break;

                        case 2:
                            Main.tile[i, j].frameX = 0;
                            Main.tile[i, j].frameY = 0x2c;
                            break;
                    }
                }
                if ((num4 == 5) || (num4 == 7))
                {
                    Main.tile[i - 1, j].active = true;
                    Main.tile[i - 1, j].type = 5;
                    num3 = genRand.Next(3);
                    if (genRand.Next(3) < 2)
                    {
                        switch (num3)
                        {
                            case 0:
                                Main.tile[i - 1, j].frameX = 0x2c;
                                Main.tile[i - 1, j].frameY = 0xc6;
                                break;

                            case 1:
                                Main.tile[i - 1, j].frameX = 0x2c;
                                Main.tile[i - 1, j].frameY = 220;
                                break;

                            case 2:
                                Main.tile[i - 1, j].frameX = 0x2c;
                                Main.tile[i - 1, j].frameY = 0xf2;
                                break;
                        }
                    }
                    else
                    {
                        switch (num3)
                        {
                            case 0:
                                Main.tile[i - 1, j].frameX = 0x42;
                                Main.tile[i - 1, j].frameY = 0;
                                break;

                            case 1:
                                Main.tile[i - 1, j].frameX = 0x42;
                                Main.tile[i - 1, j].frameY = 0x16;
                                break;

                            case 2:
                                Main.tile[i - 1, j].frameX = 0x42;
                                Main.tile[i - 1, j].frameY = 0x2c;
                                break;
                        }
                    }
                }
                if ((num4 == 6) || (num4 == 7))
                {
                    Main.tile[i + 1, j].active = true;
                    Main.tile[i + 1, j].type = 5;
                    num3 = genRand.Next(3);
                    if (genRand.Next(3) < 2)
                    {
                        switch (num3)
                        {
                            case 0:
                                Main.tile[i + 1, j].frameX = 0x42;
                                Main.tile[i + 1, j].frameY = 0xc6;
                                break;

                            case 1:
                                Main.tile[i + 1, j].frameX = 0x42;
                                Main.tile[i + 1, j].frameY = 220;
                                break;

                            case 2:
                                Main.tile[i + 1, j].frameX = 0x42;
                                Main.tile[i + 1, j].frameY = 0xf2;
                                break;
                        }
                    }
                    else
                    {
                        switch (num3)
                        {
                            case 0:
                                Main.tile[i + 1, j].frameX = 0x58;
                                Main.tile[i + 1, j].frameY = 0x42;
                                break;

                            case 1:
                                Main.tile[i + 1, j].frameX = 0x58;
                                Main.tile[i + 1, j].frameY = 0x58;
                                break;

                            case 2:
                                Main.tile[i + 1, j].frameX = 0x58;
                                Main.tile[i + 1, j].frameY = 110;
                                break;
                        }
                    }
                }
            }
            int num7 = genRand.Next(3);
            if ((num7 == 0) || (num7 == 1))
            {
                Main.tile[i + 1, num - 1].active = true;
                Main.tile[i + 1, num - 1].type = 5;
                switch (genRand.Next(3))
                {
                    case 0:
                        Main.tile[i + 1, num - 1].frameX = 0x16;
                        Main.tile[i + 1, num - 1].frameY = 0x84;
                        break;

                    case 1:
                        Main.tile[i + 1, num - 1].frameX = 0x16;
                        Main.tile[i + 1, num - 1].frameY = 0x9a;
                        break;

                    case 2:
                        Main.tile[i + 1, num - 1].frameX = 0x16;
                        Main.tile[i + 1, num - 1].frameY = 0xb0;
                        goto Label_0B04;
                }
            }
        Label_0B04:
            if ((num7 == 0) || (num7 == 2))
            {
                Main.tile[i - 1, num - 1].active = true;
                Main.tile[i - 1, num - 1].type = 5;
                switch (genRand.Next(3))
                {
                    case 0:
                        Main.tile[i - 1, num - 1].frameX = 0x2c;
                        Main.tile[i - 1, num - 1].frameY = 0x84;
                        break;

                    case 1:
                        Main.tile[i - 1, num - 1].frameX = 0x2c;
                        Main.tile[i - 1, num - 1].frameY = 0x9a;
                        break;

                    case 2:
                        Main.tile[i - 1, num - 1].frameX = 0x2c;
                        Main.tile[i - 1, num - 1].frameY = 0xb0;
                        break;
                }
            }
            num3 = genRand.Next(3);
            if (num7 == 0)
            {
                switch (num3)
                {
                    case 0:
                        Main.tile[i, num - 1].frameX = 0x58;
                        Main.tile[i, num - 1].frameY = 0x84;
                        break;

                    case 1:
                        Main.tile[i, num - 1].frameX = 0x58;
                        Main.tile[i, num - 1].frameY = 0x9a;
                        break;

                    case 2:
                        Main.tile[i, num - 1].frameX = 0x58;
                        Main.tile[i, num - 1].frameY = 0xb0;
                        break;
                }
            }
            else if (num7 == 1)
            {
                switch (num3)
                {
                    case 0:
                        Main.tile[i, num - 1].frameX = 0;
                        Main.tile[i, num - 1].frameY = 0x84;
                        break;

                    case 1:
                        Main.tile[i, num - 1].frameX = 0;
                        Main.tile[i, num - 1].frameY = 0x9a;
                        break;

                    case 2:
                        Main.tile[i, num - 1].frameX = 0;
                        Main.tile[i, num - 1].frameY = 0xb0;
                        break;
                }
            }
            else if (num7 == 2)
            {
                switch (num3)
                {
                    case 0:
                        Main.tile[i, num - 1].frameX = 0x42;
                        Main.tile[i, num - 1].frameY = 0x84;
                        break;

                    case 1:
                        Main.tile[i, num - 1].frameX = 0x42;
                        Main.tile[i, num - 1].frameY = 0x9a;
                        break;

                    case 2:
                        Main.tile[i, num - 1].frameX = 0x42;
                        Main.tile[i, num - 1].frameY = 0xb0;
                        break;
                }
            }
            if (genRand.Next(3) < 2)
            {
                switch (genRand.Next(3))
                {
                    case 0:
                        Main.tile[i, num - num5].frameX = 0x16;
                        Main.tile[i, num - num5].frameY = 0xc6;
                        break;

                    case 1:
                        Main.tile[i, num - num5].frameX = 0x16;
                        Main.tile[i, num - num5].frameY = 220;
                        break;

                    case 2:
                        Main.tile[i, num - num5].frameX = 0x16;
                        Main.tile[i, num - num5].frameY = 0xf2;
                        break;
                }
            }
            else
            {
                switch (genRand.Next(3))
                {
                    case 0:
                        Main.tile[i, num - num5].frameX = 0;
                        Main.tile[i, num - num5].frameY = 0xc6;
                        break;

                    case 1:
                        Main.tile[i, num - num5].frameX = 0;
                        Main.tile[i, num - num5].frameY = 220;
                        break;

                    case 2:
                        Main.tile[i, num - num5].frameX = 0;
                        Main.tile[i, num - num5].frameY = 0xf2;
                        break;
                }
            }
            RangeFrame(i - 2, (num - num5) - 1, i + 2, num + 1);
            if (Main.netMode == 2)
            {
                NetMessage.SendTileSquare(-1, i, num - ((int) (num5 * 0.5)), num5 + 1);
            }
        }

        public static void HellHouse(int i, int j, byte type = 0x4c, byte wall = 13)
        {
            int width = genRand.Next(8, 20);
            int num2 = genRand.Next(1, 3);
            int num3 = genRand.Next(4, 13);
            int num4 = i;
            int num5 = j;
            for (int k = 0; k < num2; k++)
            {
                int height = genRand.Next(5, 9);
                HellRoom(num4, num5, width, height, type, wall);
                num5 -= height;
            }
            num5 = j;
            for (int m = 0; m < num3; m++)
            {
                int num9 = genRand.Next(5, 9);
                num5 += num9;
                HellRoom(num4, num5, width, num9, type, wall);
            }
            for (int n = i - (width / 2); n <= (i + (width / 2)); n++)
            {
                num5 = j;
                while ((num5 < Main.maxTilesY) && ((Main.tile[n, num5].active && ((Main.tile[n, num5].type == 0x4c) || (Main.tile[n, num5].type == 0x4b))) || ((Main.tile[i, num5].wall == 13) || (Main.tile[i, num5].wall == 14))))
                {
                    num5++;
                }
                int num11 = 6 + genRand.Next(3);
                while ((num5 < Main.maxTilesY) && !Main.tile[n, num5].active)
                {
                    num11--;
                    Main.tile[n, num5].active = true;
                    Main.tile[n, num5].type = 0x39;
                    num5++;
                    if (num11 <= 0)
                    {
                        break;
                    }
                }
            }
            int minValue = 0;
            int maxValue = 0;
            num5 = j;
            while ((num5 < Main.maxTilesY) && ((Main.tile[i, num5].active && ((Main.tile[i, num5].type == 0x4c) || (Main.tile[i, num5].type == 0x4b))) || ((Main.tile[i, num5].wall == 13) || (Main.tile[i, num5].wall == 14))))
            {
                num5++;
            }
            num5--;
            maxValue = num5;
            while ((Main.tile[i, num5].active && ((Main.tile[i, num5].type == 0x4c) || (Main.tile[i, num5].type == 0x4b))) || ((Main.tile[i, num5].wall == 13) || (Main.tile[i, num5].wall == 14)))
            {
                num5--;
                if (Main.tile[i, num5].active && ((Main.tile[i, num5].type == 0x4c) || (Main.tile[i, num5].type == 0x4b)))
                {
                    int num14 = genRand.Next((i - (width / 2)) + 1, (i + (width / 2)) - 1);
                    int num15 = genRand.Next((i - (width / 2)) + 1, (i + (width / 2)) - 1);
                    if (num14 > num15)
                    {
                        int num16 = num14;
                        num14 = num15;
                        num15 = num16;
                    }
                    if (num14 == num15)
                    {
                        if (num14 < i)
                        {
                            num15++;
                        }
                        else
                        {
                            num14--;
                        }
                    }
                    for (int num17 = num14; num17 <= num15; num17++)
                    {
                        if (Main.tile[num17, num5 - 1].wall == 13)
                        {
                            Main.tile[num17, num5].wall = 13;
                        }
                        if (Main.tile[num17, num5 - 1].wall == 14)
                        {
                            Main.tile[num17, num5].wall = 14;
                        }
                        Main.tile[num17, num5].type = 0x13;
                        Main.tile[num17, num5].active = true;
                    }
                    num5--;
                }
            }
            minValue = num5;
            float num18 = (maxValue - minValue) * width;
            float num19 = num18 * 0.02f;
            for (int num20 = 0; num20 < num19; num20++)
            {
                int num21 = genRand.Next(i - (width / 2), (i + (width / 2)) + 1);
                int num22 = genRand.Next(minValue, maxValue);
                int num23 = genRand.Next(3, 8);
                for (int num24 = num21 - num23; num24 <= (num21 + num23); num24++)
                {
                    for (int num25 = num22 - num23; num25 <= (num22 + num23); num25++)
                    {
                        float num26 = Math.Abs((int) (num24 - num21));
                        float num27 = Math.Abs((int) (num25 - num22));
                        if (Math.Sqrt((double) ((num26 * num26) + (num27 * num27))) < (num23 * 0.4))
                        {
                            try
                            {
                                if ((Main.tile[num24, num25].type == 0x4c) || (Main.tile[num24, num25].type == 0x13))
                                {
                                    Main.tile[num24, num25].active = false;
                                }
                                Main.tile[num24, num25].wall = 0;
                            }
                            catch
                            {
                            }
                        }
                    }
                }
            }
        }

        public static void HellRoom(int i, int j, int width, int height, byte type = 0x4c, byte wall = 13)
        {
            if (j <= (Main.maxTilesY - 40))
            {
                for (int k = i - (width / 2); k <= (i + (width / 2)); k++)
                {
                    for (int n = j - height; n <= j; n++)
                    {
                        try
                        {
                            Main.tile[k, n].active = true;
                            Main.tile[k, n].type = type;
                            Main.tile[k, n].liquid = 0;
                            Main.tile[k, n].lava = false;
                        }
                        catch
                        {
                        }
                    }
                }
                for (int m = (i - (width / 2)) + 1; m <= ((i + (width / 2)) - 1); m++)
                {
                    for (int num4 = (j - height) + 1; num4 <= (j - 1); num4++)
                    {
                        try
                        {
                            Main.tile[m, num4].active = false;
                            Main.tile[m, num4].wall = wall;
                            Main.tile[m, num4].liquid = 0;
                            Main.tile[m, num4].lava = false;
                        }
                        catch
                        {
                        }
                    }
                }
            }
        }

        public static void IslandHouse(int i, int j)
        {
            byte num = (byte) genRand.Next(0x2d, 0x30);
            byte num2 = (byte) genRand.Next(10, 13);
            Vector2 vector = new Vector2((float) i, (float) j);
            int num7 = 1;
            if (genRand.Next(2) == 0)
            {
                num7 = -1;
            }
            int num8 = genRand.Next(7, 12);
            int num9 = genRand.Next(5, 7);
            vector.X = i + ((num8 + 2) * num7);
            for (int k = j - 15; k < (j + 30); k++)
            {
                if (Main.tile[(int) vector.X, k].active)
                {
                    vector.Y = k - 1;
                    break;
                }
            }
            vector.X = i;
            int num3 = (int) ((vector.X - num8) - 2f);
            int maxTilesX = (int) ((vector.X + num8) + 2f);
            int num4 = (int) ((vector.Y - num9) - 2f);
            int maxTilesY = ((int) (vector.Y + 2f)) + genRand.Next(3, 5);
            if (num3 < 0)
            {
                num3 = 0;
            }
            if (maxTilesX > Main.maxTilesX)
            {
                maxTilesX = Main.maxTilesX;
            }
            if (num4 < 0)
            {
                num4 = 0;
            }
            if (maxTilesY > Main.maxTilesY)
            {
                maxTilesY = Main.maxTilesY;
            }
            for (int m = num3; m <= maxTilesX; m++)
            {
                for (int num12 = num4; num12 < maxTilesY; num12++)
                {
                    Main.tile[m, num12].active = true;
                    Main.tile[m, num12].type = num;
                    Main.tile[m, num12].wall = 0;
                }
            }
            num3 = ((int) vector.X) - num8;
            maxTilesX = ((int) vector.X) + num8;
            num4 = ((int) vector.Y) - num9;
            maxTilesY = (int) (vector.Y + 1f);
            if (num3 < 0)
            {
                num3 = 0;
            }
            if (maxTilesX > Main.maxTilesX)
            {
                maxTilesX = Main.maxTilesX;
            }
            if (num4 < 0)
            {
                num4 = 0;
            }
            if (maxTilesY > Main.maxTilesY)
            {
                maxTilesY = Main.maxTilesY;
            }
            for (int n = num3; n <= maxTilesX; n++)
            {
                for (int num14 = num4; num14 < maxTilesY; num14++)
                {
                    if (Main.tile[n, num14].wall == 0)
                    {
                        Main.tile[n, num14].active = false;
                        Main.tile[n, num14].wall = num2;
                    }
                }
            }
            int num15 = i + ((num8 + 1) * num7);
            int y = (int) vector.Y;
            for (int num17 = num15 - 2; num17 <= (num15 + 2); num17++)
            {
                Main.tile[num17, y].active = false;
                Main.tile[num17, y - 1].active = false;
                Main.tile[num17, y - 2].active = false;
            }
            PlaceTile(num15, y, 10, true, false, -1, 0);
            int contain = 0;
            int houseCount = WorldGen.houseCount;
            if (houseCount > 2)
            {
                houseCount = genRand.Next(3);
            }
            switch (houseCount)
            {
                case 0:
                    contain = 0x9f;
                    break;

                case 1:
                    contain = 0x41;
                    break;

                case 2:
                    contain = 0x9e;
                    break;
            }
            AddBuriedChest(i, y - 3, contain, false, 2);
            WorldGen.houseCount++;
        }

        public static void JungleRunner(int i, int j)
        {
            Vector2 vector;
            Vector2 vector2;
            double num5 = genRand.Next(5, 11);
            vector.X = i;
            vector.Y = j;
            vector2.X = genRand.Next(-10, 11) * 0.1f;
            vector2.Y = genRand.Next(10, 20) * 0.1f;
            int num6 = 0;
            bool flag = true;
            while (flag)
            {
                if (vector.Y < Main.worldSurface)
                {
                    int x = (int) vector.X;
                    int y = (int) vector.Y;
                    if (((((Main.tile[x, y].wall == 0) && !Main.tile[x, y].active) && ((Main.tile[x, y - 3].wall == 0) && !Main.tile[x, y - 3].active)) && (((Main.tile[x, y - 1].wall == 0) && !Main.tile[x, y - 1].active) && ((Main.tile[x, y - 4].wall == 0) && !Main.tile[x, y - 4].active))) && (((Main.tile[x, y - 2].wall == 0) && !Main.tile[x, y - 2].active) && ((Main.tile[x, y - 5].wall == 0) && !Main.tile[x, y - 5].active)))
                    {
                        flag = false;
                    }
                }
                JungleX = (int) vector.X;
                num5 += genRand.Next(-20, 0x15) * 0.1f;
                if (num5 < 5.0)
                {
                    num5 = 5.0;
                }
                if (num5 > 10.0)
                {
                    num5 = 10.0;
                }
                int num = (int) (vector.X - (num5 * 0.5));
                int maxTilesX = (int) (vector.X + (num5 * 0.5));
                int num2 = (int) (vector.Y - (num5 * 0.5));
                int maxTilesY = (int) (vector.Y + (num5 * 0.5));
                if (num < 0)
                {
                    num = 0;
                }
                if (maxTilesX > Main.maxTilesX)
                {
                    maxTilesX = Main.maxTilesX;
                }
                if (num2 < 0)
                {
                    num2 = 0;
                }
                if (maxTilesY > Main.maxTilesY)
                {
                    maxTilesY = Main.maxTilesY;
                }
                for (int k = num; k < maxTilesX; k++)
                {
                    for (int m = num2; m < maxTilesY; m++)
                    {
                        if ((Math.Abs((float) (k - vector.X)) + Math.Abs((float) (m - vector.Y))) < ((num5 * 0.5) * (1.0 + (genRand.Next(-10, 11) * 0.015))))
                        {
                            KillTile(k, m, false, false, false);
                        }
                    }
                }
                num6++;
                if ((num6 > 10) && (genRand.Next(50) < num6))
                {
                    num6 = 0;
                    int num11 = -2;
                    if (genRand.Next(2) == 0)
                    {
                        num11 = 2;
                    }
                    TileRunner((int) vector.X, (int) vector.Y, (double) genRand.Next(3, 20), genRand.Next(10, 100), -1, false, (float) num11, 0f, false, true);
                }
                vector += vector2;
                vector2.Y += genRand.Next(-10, 11) * 0.01f;
                if (vector2.Y > 0f)
                {
                    vector2.Y = 0f;
                }
                if (vector2.Y < -2f)
                {
                    vector2.Y = -2f;
                }
                vector2.X += genRand.Next(-10, 11) * 0.1f;
                if (vector.X < (i - 200))
                {
                    vector2.X += genRand.Next(5, 0x15) * 0.1f;
                }
                if (vector.X > (i + 200))
                {
                    vector2.X -= genRand.Next(5, 0x15) * 0.1f;
                }
                if (vector2.X > 1.5)
                {
                    vector2.X = 1.5f;
                }
                if (vector2.X < -1.5)
                {
                    vector2.X = -1.5f;
                }
            }
        }

        public static void KillTile(int i, int j, bool fail = false, bool effectOnly = false, bool noItem = false)
        {
            if (((i >= 0) && (j >= 0)) && ((i < Main.maxTilesX) && (j < Main.maxTilesY)))
            {
                if (Main.tile[i, j] == null)
                {
                    Main.tile[i, j] = new Tile();
                }
                if (Main.tile[i, j].active)
                {
                    if ((j >= 1) && (Main.tile[i, j - 1] == null))
                    {
                        Main.tile[i, j - 1] = new Tile();
                    }
                    if ((((j < 1) || !Main.tile[i, j - 1].active) || ((((Main.tile[i, j - 1].type != 5) || (Main.tile[i, j].type == 5)) && ((Main.tile[i, j - 1].type != 0x15) || (Main.tile[i, j].type == 0x15))) && ((((Main.tile[i, j - 1].type != 0x1a) || (Main.tile[i, j].type == 0x1a)) && ((Main.tile[i, j - 1].type != 0x48) || (Main.tile[i, j].type == 0x48))) && ((Main.tile[i, j - 1].type != 12) || (Main.tile[i, j].type == 12))))) || ((Main.tile[i, j - 1].type == 5) && (((((Main.tile[i, j - 1].frameX == 0x42) && (Main.tile[i, j - 1].frameY >= 0)) && (Main.tile[i, j - 1].frameY <= 0x2c)) || (((Main.tile[i, j - 1].frameX == 0x58) && (Main.tile[i, j - 1].frameY >= 0x42)) && (Main.tile[i, j - 1].frameY <= 110))) || (Main.tile[i, j - 1].frameY >= 0xc6))))
                    {
                        if (!effectOnly && !stopDrops)
                        {
                            if (Main.tile[i, j].type == 3)
                            {
                                Main.PlaySound(6, i * 0x10, j * 0x10, 1);
                                if (Main.tile[i, j].frameX == 0x90)
                                {
                                    Item.NewItem(i * 0x10, j * 0x10, 0x10, 0x10, 5, 1, false);
                                }
                            }
                            else if (Main.tile[i, j].type == 0x18)
                            {
                                Main.PlaySound(6, i * 0x10, j * 0x10, 1);
                                if (Main.tile[i, j].frameX == 0x90)
                                {
                                    Item.NewItem(i * 0x10, j * 0x10, 0x10, 0x10, 60, 1, false);
                                }
                            }
                            else if (((Main.tileAlch[Main.tile[i, j].type] || (Main.tile[i, j].type == 0x20)) || ((Main.tile[i, j].type == 0x33) || (Main.tile[i, j].type == 0x34))) || ((((Main.tile[i, j].type == 0x3d) || (Main.tile[i, j].type == 0x3e)) || ((Main.tile[i, j].type == 0x45) || (Main.tile[i, j].type == 0x47))) || ((Main.tile[i, j].type == 0x49) || (Main.tile[i, j].type == 0x4a))))
                            {
                                Main.PlaySound(6, i * 0x10, j * 0x10, 1);
                            }
                            else if ((((((Main.tile[i, j].type == 1) || (Main.tile[i, j].type == 6)) || ((Main.tile[i, j].type == 7) || (Main.tile[i, j].type == 8))) || (((Main.tile[i, j].type == 9) || (Main.tile[i, j].type == 0x16)) || ((Main.tile[i, j].type == 0x19) || (Main.tile[i, j].type == 0x25)))) || ((((Main.tile[i, j].type == 0x26) || (Main.tile[i, j].type == 0x27)) || ((Main.tile[i, j].type == 0x29) || (Main.tile[i, j].type == 0x2b))) || (((Main.tile[i, j].type == 0x2c) || (Main.tile[i, j].type == 0x2d)) || ((Main.tile[i, j].type == 0x2e) || (Main.tile[i, j].type == 0x2f))))) || ((((Main.tile[i, j].type == 0x30) || (Main.tile[i, j].type == 0x38)) || ((Main.tile[i, j].type == 0x3a) || (Main.tile[i, j].type == 0x3f))) || ((((Main.tile[i, j].type == 0x40) || (Main.tile[i, j].type == 0x41)) || ((Main.tile[i, j].type == 0x42) || (Main.tile[i, j].type == 0x43))) || (((Main.tile[i, j].type == 0x44) || (Main.tile[i, j].type == 0x4b)) || (Main.tile[i, j].type == 0x4c)))))
                            {
                                Main.PlaySound(0x15, i * 0x10, j * 0x10, 1);
                            }
                            else
                            {
                                Main.PlaySound(0, i * 0x10, j * 0x10, 1);
                            }
                        }
                        int num = 10;
                        if (fail)
                        {
                            num = 3;
                        }
                        for (int k = 0; k < num; k++)
                        {
                            int type = 0;
                            if (Main.tile[i, j].type == 0)
                            {
                                type = 0;
                            }
                            if (((((Main.tile[i, j].type == 1) || (Main.tile[i, j].type == 0x10)) || ((Main.tile[i, j].type == 0x11) || (Main.tile[i, j].type == 0x26))) || (((Main.tile[i, j].type == 0x27) || (Main.tile[i, j].type == 0x29)) || ((Main.tile[i, j].type == 0x2b) || (Main.tile[i, j].type == 0x2c)))) || ((((Main.tile[i, j].type == 0x30) || Main.tileStone[Main.tile[i, j].type]) || ((Main.tile[i, j].type == 0x55) || (Main.tile[i, j].type == 90))) || (((Main.tile[i, j].type == 0x5c) || (Main.tile[i, j].type == 0x60)) || (((Main.tile[i, j].type == 0x61) || (Main.tile[i, j].type == 0x63)) || (Main.tile[i, j].type == 0x69)))))
                            {
                                type = 1;
                            }
                            if (((Main.tile[i, j].type == 4) || (Main.tile[i, j].type == 0x21)) || (((Main.tile[i, j].type == 0x5f) || (Main.tile[i, j].type == 0x62)) || (Main.tile[i, j].type == 100)))
                            {
                                type = 6;
                            }
                            if (((((Main.tile[i, j].type == 5) || (Main.tile[i, j].type == 10)) || ((Main.tile[i, j].type == 11) || (Main.tile[i, j].type == 14))) || (((Main.tile[i, j].type == 15) || (Main.tile[i, j].type == 0x13)) || ((Main.tile[i, j].type == 30) || (Main.tile[i, j].type == 0x56)))) || ((((Main.tile[i, j].type == 0x57) || (Main.tile[i, j].type == 0x58)) || ((Main.tile[i, j].type == 0x59) || (Main.tile[i, j].type == 0x5d))) || (((Main.tile[i, j].type == 0x5e) || (Main.tile[i, j].type == 0x68)) || (Main.tile[i, j].type == 0x6a))))
                            {
                                type = 7;
                            }
                            if (Main.tile[i, j].type == 0x15)
                            {
                                if (Main.tile[i, j].frameX >= 0x6c)
                                {
                                    type = 0x25;
                                }
                                else if (Main.tile[i, j].frameX >= 0x24)
                                {
                                    type = 10;
                                }
                                else
                                {
                                    type = 7;
                                }
                            }
                            if (Main.tile[i, j].type == 2)
                            {
                                if (genRand.Next(2) == 0)
                                {
                                    type = 0;
                                }
                                else
                                {
                                    type = 2;
                                }
                            }
                            if (Main.tile[i, j].type == 0x5b)
                            {
                                type = -1;
                            }
                            if ((Main.tile[i, j].type == 6) || (Main.tile[i, j].type == 0x1a))
                            {
                                type = 8;
                            }
                            if (((Main.tile[i, j].type == 7) || (Main.tile[i, j].type == 0x22)) || (Main.tile[i, j].type == 0x2f))
                            {
                                type = 9;
                            }
                            if (((Main.tile[i, j].type == 8) || (Main.tile[i, j].type == 0x24)) || ((Main.tile[i, j].type == 0x2d) || (Main.tile[i, j].type == 0x66)))
                            {
                                type = 10;
                            }
                            if (((Main.tile[i, j].type == 9) || (Main.tile[i, j].type == 0x23)) || ((Main.tile[i, j].type == 0x2a) || (Main.tile[i, j].type == 0x2e)))
                            {
                                type = 11;
                            }
                            if (Main.tile[i, j].type == 12)
                            {
                                type = 12;
                            }
                            if ((Main.tile[i, j].type == 3) || (Main.tile[i, j].type == 0x49))
                            {
                                type = 3;
                            }
                            if ((Main.tile[i, j].type == 13) || (Main.tile[i, j].type == 0x36))
                            {
                                type = 13;
                            }
                            if (Main.tile[i, j].type == 0x16)
                            {
                                type = 14;
                            }
                            if ((Main.tile[i, j].type == 0x1c) || (Main.tile[i, j].type == 0x4e))
                            {
                                type = 0x16;
                            }
                            if (Main.tile[i, j].type == 0x1d)
                            {
                                type = 0x17;
                            }
                            if ((Main.tile[i, j].type == 40) || (Main.tile[i, j].type == 0x67))
                            {
                                type = 0x1c;
                            }
                            if (Main.tile[i, j].type == 0x31)
                            {
                                type = 0x1d;
                            }
                            if (Main.tile[i, j].type == 50)
                            {
                                type = 0x16;
                            }
                            if (Main.tile[i, j].type == 0x33)
                            {
                                type = 30;
                            }
                            if (Main.tile[i, j].type == 0x34)
                            {
                                type = 3;
                            }
                            if ((Main.tile[i, j].type == 0x35) || (Main.tile[i, j].type == 0x51))
                            {
                                type = 0x20;
                            }
                            if ((Main.tile[i, j].type == 0x38) || (Main.tile[i, j].type == 0x4b))
                            {
                                type = 0x25;
                            }
                            if (Main.tile[i, j].type == 0x39)
                            {
                                type = 0x24;
                            }
                            if (Main.tile[i, j].type == 0x3b)
                            {
                                type = 0x26;
                            }
                            if (((Main.tile[i, j].type == 0x3d) || (Main.tile[i, j].type == 0x3e)) || ((Main.tile[i, j].type == 0x4a) || (Main.tile[i, j].type == 80)))
                            {
                                type = 40;
                            }
                            if (Main.tile[i, j].type == 0x45)
                            {
                                type = 7;
                            }
                            if ((Main.tile[i, j].type == 0x47) || (Main.tile[i, j].type == 0x48))
                            {
                                type = 0x1a;
                            }
                            if (Main.tile[i, j].type == 70)
                            {
                                type = 0x11;
                            }
                            if (Main.tileAlch[Main.tile[i, j].type])
                            {
                                switch ((Main.tile[i, j].frameX / 0x12))
                                {
                                    case 0:
                                        type = 3;
                                        break;

                                    case 1:
                                        type = 3;
                                        break;

                                    case 2:
                                        type = 7;
                                        break;

                                    case 3:
                                        type = 0x11;
                                        break;

                                    case 4:
                                        type = 3;
                                        break;

                                    case 5:
                                        type = 6;
                                        goto Label_0E7D;
                                }
                            }
                        Label_0E7D:
                            if (Main.tile[i, j].type == 0x3d)
                            {
                                if (genRand.Next(2) == 0)
                                {
                                    type = 0x26;
                                }
                                else
                                {
                                    type = 0x27;
                                }
                            }
                            if (((Main.tile[i, j].type == 0x3a) || (Main.tile[i, j].type == 0x4c)) || (Main.tile[i, j].type == 0x4d))
                            {
                                if (genRand.Next(2) == 0)
                                {
                                    type = 6;
                                }
                                else
                                {
                                    type = 0x19;
                                }
                            }
                            if (Main.tile[i, j].type == 0x25)
                            {
                                if (genRand.Next(2) == 0)
                                {
                                    type = 6;
                                }
                                else
                                {
                                    type = 0x17;
                                }
                            }
                            if (Main.tile[i, j].type == 0x20)
                            {
                                if (genRand.Next(2) == 0)
                                {
                                    type = 14;
                                }
                                else
                                {
                                    type = 0x18;
                                }
                            }
                            if ((Main.tile[i, j].type == 0x17) || (Main.tile[i, j].type == 0x18))
                            {
                                if (genRand.Next(2) == 0)
                                {
                                    type = 14;
                                }
                                else
                                {
                                    type = 0x11;
                                }
                            }
                            if ((Main.tile[i, j].type == 0x19) || (Main.tile[i, j].type == 0x1f))
                            {
                                if (genRand.Next(2) == 0)
                                {
                                    type = 14;
                                }
                                else
                                {
                                    type = 1;
                                }
                            }
                            if (Main.tile[i, j].type == 20)
                            {
                                if (genRand.Next(2) == 0)
                                {
                                    type = 7;
                                }
                                else
                                {
                                    type = 2;
                                }
                            }
                            if (Main.tile[i, j].type == 0x1b)
                            {
                                if (genRand.Next(2) == 0)
                                {
                                    type = 3;
                                }
                                else
                                {
                                    type = 0x13;
                                }
                            }
                            if ((((Main.tile[i, j].type == 0x22) || (Main.tile[i, j].type == 0x23)) || ((Main.tile[i, j].type == 0x24) || (Main.tile[i, j].type == 0x2a))) && (Main.rand.Next(2) == 0))
                            {
                                type = 6;
                            }
                            if (type >= 0)
                            {
                                Color newColor = new Color();
                                Dust.NewDust(new Vector2((float) (i * 0x10), (float) (j * 0x10)), 0x10, 0x10, type, 0f, 0f, 0, newColor, 1f);
                            }
                        }
                        if (!effectOnly)
                        {
                            if (fail)
                            {
                                if ((Main.tile[i, j].type == 2) || (Main.tile[i, j].type == 0x17))
                                {
                                    Main.tile[i, j].type = 0;
                                }
                                if ((Main.tile[i, j].type == 60) || (Main.tile[i, j].type == 70))
                                {
                                    Main.tile[i, j].type = 0x3b;
                                }
                                SquareTileFrame(i, j, true);
                            }
                            else
                            {
                                if ((Main.tile[i, j].type == 0x15) && (Main.netMode != 1))
                                {
                                    int x = Main.tile[i, j].frameX / 0x12;
                                    int y = j - (Main.tile[i, j].frameY / 0x12);
                                    while (x > 1)
                                    {
                                        x -= 2;
                                    }
                                    x = i - x;
                                    if (!Chest.DestroyChest(x, y))
                                    {
                                        return;
                                    }
                                }
                                if ((!noItem && !stopDrops) && (Main.netMode != 1))
                                {
                                    int num7 = 0;
                                    if ((Main.tile[i, j].type == 0) || (Main.tile[i, j].type == 2))
                                    {
                                        num7 = 2;
                                    }
                                    else if (Main.tile[i, j].type == 1)
                                    {
                                        num7 = 3;
                                    }
                                    else if ((Main.tile[i, j].type == 3) || (Main.tile[i, j].type == 0x49))
                                    {
                                        if ((Main.rand.Next(2) == 0) && Main.player[Player.FindClosest(new Vector2((float) (i * 0x10), (float) (j * 0x10)), 0x10, 0x10)].HasItem(0x119))
                                        {
                                            num7 = 0x11b;
                                        }
                                    }
                                    else if (Main.tile[i, j].type == 4)
                                    {
                                        num7 = 8;
                                    }
                                    else if (Main.tile[i, j].type == 5)
                                    {
                                        if ((Main.tile[i, j].frameX >= 0x16) && (Main.tile[i, j].frameY >= 0xc6))
                                        {
                                            if (Main.netMode != 1)
                                            {
                                                if (genRand.Next(2) == 0)
                                                {
                                                    int num8 = j;
                                                    while ((Main.tile[i, num8] != null) && ((!Main.tile[i, num8].active || !Main.tileSolid[Main.tile[i, num8].type]) || Main.tileSolidTop[Main.tile[i, num8].type]))
                                                    {
                                                        num8++;
                                                    }
                                                    if (Main.tile[i, num8] != null)
                                                    {
                                                        if (Main.tile[i, num8].type == 2)
                                                        {
                                                            num7 = 0x1b;
                                                        }
                                                        else
                                                        {
                                                            num7 = 9;
                                                        }
                                                    }
                                                }
                                                else
                                                {
                                                    num7 = 9;
                                                }
                                            }
                                        }
                                        else
                                        {
                                            num7 = 9;
                                        }
                                    }
                                    else if (Main.tile[i, j].type == 6)
                                    {
                                        num7 = 11;
                                    }
                                    else if (Main.tile[i, j].type == 7)
                                    {
                                        num7 = 12;
                                    }
                                    else if (Main.tile[i, j].type == 8)
                                    {
                                        num7 = 13;
                                    }
                                    else if (Main.tile[i, j].type == 9)
                                    {
                                        num7 = 14;
                                    }
                                    else if (Main.tile[i, j].type == 13)
                                    {
                                        Main.PlaySound(13, i * 0x10, j * 0x10, 1);
                                        if (Main.tile[i, j].frameX == 0x12)
                                        {
                                            num7 = 0x1c;
                                        }
                                        else if (Main.tile[i, j].frameX == 0x24)
                                        {
                                            num7 = 110;
                                        }
                                        else if (Main.tile[i, j].frameX == 0x36)
                                        {
                                            num7 = 350;
                                        }
                                        else if (Main.tile[i, j].frameX == 0x48)
                                        {
                                            num7 = 0x15f;
                                        }
                                        else
                                        {
                                            num7 = 0x1f;
                                        }
                                    }
                                    else if (Main.tile[i, j].type == 0x13)
                                    {
                                        num7 = 0x5e;
                                    }
                                    else if (Main.tile[i, j].type == 0x16)
                                    {
                                        num7 = 0x38;
                                    }
                                    else if (Main.tile[i, j].type == 0x17)
                                    {
                                        num7 = 2;
                                    }
                                    else if (Main.tile[i, j].type == 0x19)
                                    {
                                        num7 = 0x3d;
                                    }
                                    else if (Main.tile[i, j].type == 30)
                                    {
                                        num7 = 9;
                                    }
                                    else if (Main.tile[i, j].type == 0x21)
                                    {
                                        num7 = 0x69;
                                    }
                                    else if (Main.tile[i, j].type == 0x25)
                                    {
                                        num7 = 0x74;
                                    }
                                    else if (Main.tile[i, j].type == 0x26)
                                    {
                                        num7 = 0x81;
                                    }
                                    else if (Main.tile[i, j].type == 0x27)
                                    {
                                        num7 = 0x83;
                                    }
                                    else if (Main.tile[i, j].type == 40)
                                    {
                                        num7 = 0x85;
                                    }
                                    else if (Main.tile[i, j].type == 0x29)
                                    {
                                        num7 = 0x86;
                                    }
                                    else if (Main.tile[i, j].type == 0x2b)
                                    {
                                        num7 = 0x89;
                                    }
                                    else if (Main.tile[i, j].type == 0x2c)
                                    {
                                        num7 = 0x8b;
                                    }
                                    else if (Main.tile[i, j].type == 0x2d)
                                    {
                                        num7 = 0x8d;
                                    }
                                    else if (Main.tile[i, j].type == 0x2e)
                                    {
                                        num7 = 0x8f;
                                    }
                                    else if (Main.tile[i, j].type == 0x2f)
                                    {
                                        num7 = 0x91;
                                    }
                                    else if (Main.tile[i, j].type == 0x30)
                                    {
                                        num7 = 0x93;
                                    }
                                    else if (Main.tile[i, j].type == 0x31)
                                    {
                                        num7 = 0x94;
                                    }
                                    else if (Main.tile[i, j].type == 0x33)
                                    {
                                        num7 = 150;
                                    }
                                    else if (Main.tile[i, j].type == 0x35)
                                    {
                                        num7 = 0xa9;
                                    }
                                    else if (Main.tile[i, j].type == 0x36)
                                    {
                                        Main.PlaySound(13, i * 0x10, j * 0x10, 1);
                                    }
                                    else if (Main.tile[i, j].type == 0x38)
                                    {
                                        num7 = 0xad;
                                    }
                                    else if (Main.tile[i, j].type == 0x39)
                                    {
                                        num7 = 0xac;
                                    }
                                    else if (Main.tile[i, j].type == 0x3a)
                                    {
                                        num7 = 0xae;
                                    }
                                    else if (Main.tile[i, j].type == 60)
                                    {
                                        num7 = 0xb0;
                                    }
                                    else if (Main.tile[i, j].type == 70)
                                    {
                                        num7 = 0xb0;
                                    }
                                    else if (Main.tile[i, j].type == 0x4b)
                                    {
                                        num7 = 0xc0;
                                    }
                                    else if (Main.tile[i, j].type == 0x4c)
                                    {
                                        num7 = 0xd6;
                                    }
                                    else if (Main.tile[i, j].type == 0x4e)
                                    {
                                        num7 = 0xde;
                                    }
                                    else if (Main.tile[i, j].type == 0x51)
                                    {
                                        num7 = 0x113;
                                    }
                                    else if (Main.tile[i, j].type == 80)
                                    {
                                        num7 = 0x114;
                                    }
                                    else if ((Main.tile[i, j].type == 0x3d) || (Main.tile[i, j].type == 0x4a))
                                    {
                                        if (Main.tile[i, j].frameX == 0x90)
                                        {
                                            Item.NewItem(i * 0x10, j * 0x10, 0x10, 0x10, 0x14b, genRand.Next(1, 3), false);
                                        }
                                        else if (Main.tile[i, j].frameX == 0xa2)
                                        {
                                            num7 = 0xdf;
                                        }
                                        else if (((Main.tile[i, j].frameX >= 0x6c) && (Main.tile[i, j].frameX <= 0x7e)) && (genRand.Next(100) == 0))
                                        {
                                            num7 = 0xd0;
                                        }
                                        else if (genRand.Next(100) == 0)
                                        {
                                            num7 = 0xc3;
                                        }
                                    }
                                    else if ((Main.tile[i, j].type == 0x3b) || (Main.tile[i, j].type == 60))
                                    {
                                        num7 = 0xb0;
                                    }
                                    else if ((Main.tile[i, j].type == 0x47) || (Main.tile[i, j].type == 0x48))
                                    {
                                        if (genRand.Next(50) == 0)
                                        {
                                            num7 = 0xc2;
                                        }
                                        else if (genRand.Next(2) == 0)
                                        {
                                            num7 = 0xb7;
                                        }
                                    }
                                    else if ((Main.tile[i, j].type >= 0x3f) && (Main.tile[i, j].type <= 0x44))
                                    {
                                        num7 = (Main.tile[i, j].type - 0x3f) + 0xb1;
                                    }
                                    else if (Main.tile[i, j].type == 50)
                                    {
                                        if (Main.tile[i, j].frameX == 90)
                                        {
                                            num7 = 0xa5;
                                        }
                                        else
                                        {
                                            num7 = 0x95;
                                        }
                                    }
                                    else if (Main.tileAlch[Main.tile[i, j].type] && (Main.tile[i, j].type > 0x52))
                                    {
                                        int num9 = Main.tile[i, j].frameX / 0x12;
                                        bool flag = false;
                                        if (Main.tile[i, j].type == 0x54)
                                        {
                                            flag = true;
                                        }
                                        if ((num9 == 0) && Main.dayTime)
                                        {
                                            flag = true;
                                        }
                                        if ((num9 == 1) && !Main.dayTime)
                                        {
                                            flag = true;
                                        }
                                        if ((num9 == 3) && Main.bloodMoon)
                                        {
                                            flag = true;
                                        }
                                        num7 = 0x139 + num9;
                                        if (flag)
                                        {
                                            Item.NewItem(i * 0x10, j * 0x10, 0x10, 0x10, 0x133 + num9, genRand.Next(1, 4), false);
                                        }
                                    }
                                    if (num7 > 0)
                                    {
                                        Item.NewItem(i * 0x10, j * 0x10, 0x10, 0x10, num7, 1, false);
                                    }
                                }
                                Main.tile[i, j].active = false;
                                if (Main.tileSolid[Main.tile[i, j].type])
                                {
                                    Main.tile[i, j].lighted = false;
                                }
                                Main.tile[i, j].frameX = -1;
                                Main.tile[i, j].frameY = -1;
                                Main.tile[i, j].frameNumber = 0;
                                if ((Main.tile[i, j].type == 0x3a) && (j > (Main.maxTilesY - 200)))
                                {
                                    Main.tile[i, j].lava = true;
                                    Main.tile[i, j].liquid = 0x80;
                                }
                                Main.tile[i, j].type = 0;
                                SquareTileFrame(i, j, true);
                            }
                        }
                    }
                }
            }
        }

        public static void KillWall(int i, int j, bool fail = false)
        {
            if (((i >= 0) && (j >= 0)) && ((i < Main.maxTilesX) && (j < Main.maxTilesY)))
            {
                if (Main.tile[i, j] == null)
                {
                    Main.tile[i, j] = new Tile();
                }
                if (Main.tile[i, j].wall > 0)
                {
                    genRand.Next(3);
                    Main.PlaySound(0, i * 0x10, j * 0x10, 1);
                    int num = 10;
                    if (fail)
                    {
                        num = 3;
                    }
                    for (int k = 0; k < num; k++)
                    {
                        int type = 0;
                        if ((((Main.tile[i, j].wall == 1) || (Main.tile[i, j].wall == 5)) || ((Main.tile[i, j].wall == 6) || (Main.tile[i, j].wall == 7))) || ((Main.tile[i, j].wall == 8) || (Main.tile[i, j].wall == 9)))
                        {
                            type = 1;
                        }
                        if (Main.tile[i, j].wall == 3)
                        {
                            if (genRand.Next(2) == 0)
                            {
                                type = 14;
                            }
                            else
                            {
                                type = 1;
                            }
                        }
                        if (Main.tile[i, j].wall == 4)
                        {
                            type = 7;
                        }
                        if (Main.tile[i, j].wall == 12)
                        {
                            type = 9;
                        }
                        if (Main.tile[i, j].wall == 10)
                        {
                            type = 10;
                        }
                        if (Main.tile[i, j].wall == 11)
                        {
                            type = 11;
                        }
                        Color newColor = new Color();
                        Dust.NewDust(new Vector2((float) (i * 0x10), (float) (j * 0x10)), 0x10, 0x10, type, 0f, 0f, 0, newColor, 1f);
                    }
                    if (fail)
                    {
                        SquareWallFrame(i, j, true);
                    }
                    else
                    {
                        int num4 = 0;
                        if (Main.tile[i, j].wall == 1)
                        {
                            num4 = 0x1a;
                        }
                        if (Main.tile[i, j].wall == 4)
                        {
                            num4 = 0x5d;
                        }
                        if (Main.tile[i, j].wall == 5)
                        {
                            num4 = 130;
                        }
                        if (Main.tile[i, j].wall == 6)
                        {
                            num4 = 0x84;
                        }
                        if (Main.tile[i, j].wall == 7)
                        {
                            num4 = 0x87;
                        }
                        if (Main.tile[i, j].wall == 8)
                        {
                            num4 = 0x8a;
                        }
                        if (Main.tile[i, j].wall == 9)
                        {
                            num4 = 140;
                        }
                        if (Main.tile[i, j].wall == 10)
                        {
                            num4 = 0x8e;
                        }
                        if (Main.tile[i, j].wall == 11)
                        {
                            num4 = 0x90;
                        }
                        if (Main.tile[i, j].wall == 12)
                        {
                            num4 = 0x92;
                        }
                        if (Main.tile[i, j].wall == 14)
                        {
                            num4 = 330;
                        }
                        if (Main.tile[i, j].wall == 0x10)
                        {
                            num4 = 30;
                        }
                        if (Main.tile[i, j].wall == 0x11)
                        {
                            num4 = 0x87;
                        }
                        if (Main.tile[i, j].wall == 0x12)
                        {
                            num4 = 0x8a;
                        }
                        if (Main.tile[i, j].wall == 0x13)
                        {
                            num4 = 140;
                        }
                        if (Main.tile[i, j].wall == 20)
                        {
                            num4 = 330;
                        }
                        if (num4 > 0)
                        {
                            Item.NewItem(i * 0x10, j * 0x10, 0x10, 0x10, num4, 1, false);
                        }
                        Main.tile[i, j].wall = 0;
                        SquareWallFrame(i, j, true);
                    }
                }
            }
        }

        public static void Lakinater(int i, int j)
        {
            Vector2 vector;
            Vector2 vector2;
            double num5 = genRand.Next(0x19, 50);
            double num6 = num5;
            float num7 = genRand.Next(30, 80);
            if (genRand.Next(5) == 0)
            {
                num5 *= 1.5;
                num6 *= 1.5;
                num7 *= 1.2f;
            }
            vector.X = i;
            vector.Y = j - (num7 * 0.3f);
            vector2.X = genRand.Next(-10, 11) * 0.1f;
            vector2.Y = genRand.Next(-20, -10) * 0.1f;
            while ((num5 > 0.0) && (num7 > 0f))
            {
                if ((vector.Y + (num6 * 0.5)) > Main.worldSurface)
                {
                    num7 = 0f;
                }
                num5 -= genRand.Next(3);
                num7--;
                int num = (int) (vector.X - (num5 * 0.5));
                int maxTilesX = (int) (vector.X + (num5 * 0.5));
                int num2 = (int) (vector.Y - (num5 * 0.5));
                int maxTilesY = (int) (vector.Y + (num5 * 0.5));
                if (num < 0)
                {
                    num = 0;
                }
                if (maxTilesX > Main.maxTilesX)
                {
                    maxTilesX = Main.maxTilesX;
                }
                if (num2 < 0)
                {
                    num2 = 0;
                }
                if (maxTilesY > Main.maxTilesY)
                {
                    maxTilesY = Main.maxTilesY;
                }
                num6 = (num5 * genRand.Next(80, 120)) * 0.01;
                for (int k = num; k < maxTilesX; k++)
                {
                    for (int m = num2; m < maxTilesY; m++)
                    {
                        float num10 = Math.Abs((float) (k - vector.X));
                        float num11 = Math.Abs((float) (m - vector.Y));
                        if (Math.Sqrt((double) ((num10 * num10) + (num11 * num11))) < (num6 * 0.4))
                        {
                            if (Main.tile[k, m].active)
                            {
                                Main.tile[k, m].liquid = 0xff;
                            }
                            Main.tile[k, m].active = false;
                        }
                    }
                }
                vector += vector2;
                vector2.X += genRand.Next(-10, 11) * 0.05f;
                vector2.Y += genRand.Next(-10, 11) * 0.05f;
                if (vector2.X > 0.5)
                {
                    vector2.X = 0.5f;
                }
                if (vector2.X < -0.5)
                {
                    vector2.X = -0.5f;
                }
                if (vector2.Y > 1.5)
                {
                    vector2.Y = 1.5f;
                }
                if (vector2.Y < 0.5)
                {
                    vector2.Y = 0.5f;
                }
            }
        }

        public static void loadWorld()
        {
            DirectoryInfo di = new DirectoryInfo(Main.WorldPath);
            foreach (FileInfo fi in di.GetFiles("*.gz"))
            {
                Decompress(fi);

            }
            if (!File.Exists(Main.worldPathName) && Main.autoGen)
            {
                for (int i = Main.worldPathName.Length - 1; i >= 0; i--)
                {
                    if (Main.worldPathName.Substring(i, 1) == @"\")
                    {
                        Directory.CreateDirectory(Main.worldPathName.Substring(0, i));
                        break;
                    }
                }
                clearWorld();
                generateWorld(-1);
                saveWorld(false);
            }
            if (genRand == null)
            {
                genRand = new Random((int) DateTime.Now.Ticks);
            }
            using (FileStream stream = new FileStream(Main.worldPathName, FileMode.Open))
            {
                using (BinaryReader reader = new BinaryReader(stream))
                {
                    try
                    {
                        loadFailed = false;
                        loadSuccess = false;
                        int release = reader.ReadInt32();
                        if (release > Main.curRelease)
                        {
                            loadFailed = true;
                            loadSuccess = false;
                            try
                            {
                                reader.Close();
                                stream.Close();
                            }
                            catch
                            {
                            }
                        }
                        else
                        {
                            Main.worldName = reader.ReadString();
                            Main.worldID = reader.ReadInt32();
                            Main.leftWorld = reader.ReadInt32();
                            Main.rightWorld = reader.ReadInt32();
                            Main.topWorld = reader.ReadInt32();
                            Main.bottomWorld = reader.ReadInt32();
                            Main.maxTilesY = reader.ReadInt32();
                            Main.maxTilesX = reader.ReadInt32();
                            clearWorld();
                            Main.spawnTileX = reader.ReadInt32();
                            Main.spawnTileY = reader.ReadInt32();
                            Main.worldSurface = reader.ReadDouble();
                            Main.rockLayer = reader.ReadDouble();
                            tempTime = reader.ReadDouble();
                            tempDayTime = reader.ReadBoolean();
                            tempMoonPhase = reader.ReadInt32();
                            tempBloodMoon = reader.ReadBoolean();
                            Main.dungeonX = reader.ReadInt32();
                            Main.dungeonY = reader.ReadInt32();
                            NPC.downedBoss1 = reader.ReadBoolean();
                            NPC.downedBoss2 = reader.ReadBoolean();
                            NPC.downedBoss3 = reader.ReadBoolean();
                            shadowOrbSmashed = reader.ReadBoolean();
                            spawnMeteor = reader.ReadBoolean();
                            shadowOrbCount = reader.ReadByte();
                            Main.invasionDelay = reader.ReadInt32();
                            Main.invasionSize = reader.ReadInt32();
                            Main.invasionType = reader.ReadInt32();
                            Main.invasionX = reader.ReadDouble();
                            for (int j = 0; j < Main.maxTilesX; j++)
                            {
                                float num4 = ((float) j) / ((float) Main.maxTilesX);
                                Main.statusText = "Loading world: " + ((int) ((num4 * 100f) + 1f)) + "%";
                                for (int num5 = 0; num5 < Main.maxTilesY; num5++)
                                {
                                    Main.tile[j, num5].active = reader.ReadBoolean();
                                    if (Main.tile[j, num5].active)
                                    {
                                        Main.tile[j, num5].type = reader.ReadByte();
                                        if (Main.tileFrameImportant[Main.tile[j, num5].type])
                                        {
                                            Main.tile[j, num5].frameX = reader.ReadInt16();
                                            Main.tile[j, num5].frameY = reader.ReadInt16();
                                        }
                                        else
                                        {
                                            Main.tile[j, num5].frameX = -1;
                                            Main.tile[j, num5].frameY = -1;
                                        }
                                    }
                                    Main.tile[j, num5].lighted = reader.ReadBoolean();
                                    if (reader.ReadBoolean())
                                    {
                                        Main.tile[j, num5].wall = reader.ReadByte();
                                    }
                                    if (reader.ReadBoolean())
                                    {
                                        Main.tile[j, num5].liquid = reader.ReadByte();
                                        Main.tile[j, num5].lava = reader.ReadBoolean();
                                    }
                                }
                            }
                            for (int k = 0; k < 0x3e8; k++)
                            {
                                if (reader.ReadBoolean())
                                {
                                    Main.chest[k] = new Chest();
                                    Main.chest[k].x = reader.ReadInt32();
                                    Main.chest[k].y = reader.ReadInt32();
                                    for (int num7 = 0; num7 < Chest.maxItems; num7++)
                                    {
                                        Main.chest[k].item[num7] = new Item();
                                        byte num8 = reader.ReadByte();
                                        if (num8 > 0)
                                        {
                                            string itemName = Item.VersionName(reader.ReadString(), release);
                                            Main.chest[k].item[num7].SetDefaults(itemName);
                                            Main.chest[k].item[num7].stack = num8;
                                        }
                                    }
                                }
                            }
                            for (int m = 0; m < 0x3e8; m++)
                            {
                                if (reader.ReadBoolean())
                                {
                                    string str3 = reader.ReadString();
                                    int num10 = reader.ReadInt32();
                                    int num11 = reader.ReadInt32();
                                    if (Main.tile[num10, num11].active && ((Main.tile[num10, num11].type == 0x37) || (Main.tile[num10, num11].type == 0x55)))
                                    {
                                        Main.sign[m] = new Sign();
                                        Main.sign[m].x = num10;
                                        Main.sign[m].y = num11;
                                        Main.sign[m].text = str3;
                                    }
                                }
                            }
                            bool flag = reader.ReadBoolean();
                            for (int n = 0; flag; n++)
                            {
                                Main.npc[n].SetDefaults(reader.ReadString());
                                Main.npc[n].position.X = reader.ReadSingle();
                                Main.npc[n].position.Y = reader.ReadSingle();
                                Main.npc[n].homeless = reader.ReadBoolean();
                                Main.npc[n].homeTileX = reader.ReadInt32();
                                Main.npc[n].homeTileY = reader.ReadInt32();
                                flag = reader.ReadBoolean();
                            }
                            if (release >= 7)
                            {
                                bool flag2 = reader.ReadBoolean();
                                string str4 = reader.ReadString();
                                int num13 = reader.ReadInt32();
                                if ((!flag2 || (str4 != Main.worldName)) || (num13 != Main.worldID))
                                {
                                    loadSuccess = false;
                                    loadFailed = true;
                                    reader.Close();
                                    stream.Close();
                                    return;
                                }
                                loadSuccess = true;
                            }
                            else
                            {
                                loadSuccess = true;
                            }
                            reader.Close();
                            stream.Close();
                            if (!loadFailed && loadSuccess)
                            {
                                gen = true;
                                waterLine = Main.maxTilesY;
                                Liquid.QuickWater(2, -1, -1);
                                WaterCheck();
                                int num14 = 0;
                                Liquid.quickSettle = true;
                                int num15 = Liquid.numLiquid + LiquidBuffer.numLiquidBuffer;
                                float num16 = 0f;
                                while ((Liquid.numLiquid > 0) && (num14 < 0x186a0))
                                {
                                    num14++;
                                    float num17 = ((float) (num15 - (Liquid.numLiquid + LiquidBuffer.numLiquidBuffer))) / ((float) num15);
                                    if ((Liquid.numLiquid + LiquidBuffer.numLiquidBuffer) > num15)
                                    {
                                        num15 = Liquid.numLiquid + LiquidBuffer.numLiquidBuffer;
                                    }
                                    if (num17 > num16)
                                    {
                                        num16 = num17;
                                    }
                                    else
                                    {
                                        num17 = num16;
                                    }
                                    //Main.statusText = "Settling liquids: " + ((int) (((num17 * 100f) / 2f) + 50f)) + "%";
                                    Liquid.UpdateLiquid();
                                }
                                Liquid.quickSettle = false;
                                WaterCheck();
                                gen = false;
                            }
                        }
                    }
                    catch
                    {
                        loadFailed = true;
                        loadSuccess = false;
                        try
                        {
                            reader.Close();
                            stream.Close();
                        }
                        catch
                        {
                        }
                    }
                }
            }
        }

        public static void MakeDungeon(int x, int y, int tileType = 0x29, int wallType = 7)
        {
            int num = genRand.Next(3);
            int num2 = genRand.Next(3);
            switch (num)
            {
                case 1:
                    tileType = 0x2b;
                    break;

                case 2:
                    tileType = 0x2c;
                    break;
            }
            switch (num2)
            {
                case 1:
                    wallType = 8;
                    break;

                case 2:
                    wallType = 9;
                    break;
            }
            numDDoors = 0;
            numDPlats = 0;
            numDRooms = 0;
            WorldGen.dungeonX = x;
            WorldGen.dungeonY = y;
            dMinX = x;
            dMaxX = x;
            dMinY = y;
            dMaxY = y;
            dxStrength1 = genRand.Next(0x19, 30);
            dyStrength1 = genRand.Next(20, 0x19);
            dxStrength2 = genRand.Next(0x23, 50);
            dyStrength2 = genRand.Next(10, 15);
            float num3 = Main.maxTilesX / 60;
            num3 += genRand.Next(0, (int) (num3 / 3f));
            float num4 = num3;
            int num5 = 5;
            DungeonRoom(WorldGen.dungeonX, WorldGen.dungeonY, tileType, wallType);
            while (num3 > 0f)
            {
                if (WorldGen.dungeonX < dMinX)
                {
                    dMinX = WorldGen.dungeonX;
                }
                if (WorldGen.dungeonX > dMaxX)
                {
                    dMaxX = WorldGen.dungeonX;
                }
                if (WorldGen.dungeonY > dMaxY)
                {
                    dMaxY = WorldGen.dungeonY;
                }
                num3--;
                //Main.statusText = "Creating dungeon: " + ((int) (((num4 - num3) / num4) * 60f)) + "%";
                if (num5 > 0)
                {
                    num5--;
                }
                if ((num5 == 0) & (genRand.Next(3) == 0))
                {
                    num5 = 5;
                    if (genRand.Next(2) == 0)
                    {
                        int dungeonX = WorldGen.dungeonX;
                        int dungeonY = WorldGen.dungeonY;
                        DungeonHalls(WorldGen.dungeonX, WorldGen.dungeonY, tileType, wallType, false);
                        if (genRand.Next(2) == 0)
                        {
                            DungeonHalls(WorldGen.dungeonX, WorldGen.dungeonY, tileType, wallType, false);
                        }
                        DungeonRoom(WorldGen.dungeonX, WorldGen.dungeonY, tileType, wallType);
                        WorldGen.dungeonX = dungeonX;
                        WorldGen.dungeonY = dungeonY;
                    }
                    else
                    {
                        DungeonRoom(WorldGen.dungeonX, WorldGen.dungeonY, tileType, wallType);
                    }
                }
                else
                {
                    DungeonHalls(WorldGen.dungeonX, WorldGen.dungeonY, tileType, wallType, false);
                }
            }
            DungeonRoom(WorldGen.dungeonX, WorldGen.dungeonY, tileType, wallType);
            int num8 = dRoomX[0];
            int num9 = dRoomY[0];
            for (int i = 0; i < numDRooms; i++)
            {
                if (dRoomY[i] < num9)
                {
                    num8 = dRoomX[i];
                    num9 = dRoomY[i];
                }
            }
            WorldGen.dungeonX = num8;
            WorldGen.dungeonY = num9;
            dEnteranceX = num8;
            dSurface = false;
            num5 = 5;
            while (!dSurface)
            {
                if (num5 > 0)
                {
                    num5--;
                }
                if (((num5 == 0) & (genRand.Next(5) == 0)) && (WorldGen.dungeonY > (Main.worldSurface + 50.0)))
                {
                    num5 = 10;
                    int num11 = WorldGen.dungeonX;
                    int num12 = WorldGen.dungeonY;
                    DungeonHalls(WorldGen.dungeonX, WorldGen.dungeonY, tileType, wallType, true);
                    DungeonRoom(WorldGen.dungeonX, WorldGen.dungeonY, tileType, wallType);
                    WorldGen.dungeonX = num11;
                    WorldGen.dungeonY = num12;
                }
                DungeonStairs(WorldGen.dungeonX, WorldGen.dungeonY, tileType, wallType);
            }
            DungeonEnt(WorldGen.dungeonX, WorldGen.dungeonY, tileType, wallType);
            //Main.statusText = "Creating dungeon: 65%";
            for (int j = 0; j < numDRooms; j++)
            {
                for (int num14 = dRoomL[j]; num14 <= dRoomR[j]; num14++)
                {
                    if (!Main.tile[num14, dRoomT[j] - 1].active)
                    {
                        DPlatX[numDPlats] = num14;
                        DPlatY[numDPlats] = dRoomT[j] - 1;
                        numDPlats++;
                        break;
                    }
                }
                for (int num15 = dRoomL[j]; num15 <= dRoomR[j]; num15++)
                {
                    if (!Main.tile[num15, dRoomB[j] + 1].active)
                    {
                        DPlatX[numDPlats] = num15;
                        DPlatY[numDPlats] = dRoomB[j] + 1;
                        numDPlats++;
                        break;
                    }
                }
                for (int num16 = dRoomT[j]; num16 <= dRoomB[j]; num16++)
                {
                    if (!Main.tile[dRoomL[j] - 1, num16].active)
                    {
                        DDoorX[numDDoors] = dRoomL[j] - 1;
                        DDoorY[numDDoors] = num16;
                        DDoorPos[numDDoors] = -1;
                        numDDoors++;
                        break;
                    }
                }
                for (int num17 = dRoomT[j]; num17 <= dRoomB[j]; num17++)
                {
                    if (!Main.tile[dRoomR[j] + 1, num17].active)
                    {
                        DDoorX[numDDoors] = dRoomR[j] + 1;
                        DDoorY[numDDoors] = num17;
                        DDoorPos[numDDoors] = 1;
                        numDDoors++;
                        break;
                    }
                }
            }
            //Main.statusText = "Creating dungeon: 70%";
            int num18 = 0;
            int num19 = 0x3e8;
            int num20 = 0;
            while (num20 < (Main.maxTilesX / 100))
            {
                num18++;
                int num21 = genRand.Next(dMinX, dMaxX);
                int num22 = genRand.Next(((int) Main.worldSurface) + 0x19, dMaxY);
                int num23 = num21;
                if ((Main.tile[num21, num22].wall == wallType) && !Main.tile[num21, num22].active)
                {
                    int num24 = 1;
                    if (genRand.Next(2) == 0)
                    {
                        num24 = -1;
                    }
                    while (!Main.tile[num21, num22].active)
                    {
                        num22 += num24;
                    }
                    if ((Main.tile[num21 - 1, num22].active && Main.tile[num21 + 1, num22].active) && (!Main.tile[num21 - 1, num22 - num24].active && !Main.tile[num21 + 1, num22 - num24].active))
                    {
                        num20++;
                        int num25 = genRand.Next(5, 13);
                        while ((Main.tile[num21 - 1, num22].active && Main.tile[num21, num22 + num24].active) && ((Main.tile[num21, num22].active && !Main.tile[num21, num22 - num24].active) && (num25 > 0)))
                        {
                            Main.tile[num21, num22].type = 0x30;
                            if (!Main.tile[num21 - 1, num22 - num24].active && !Main.tile[num21 + 1, num22 - num24].active)
                            {
                                Main.tile[num21, num22 - num24].type = 0x30;
                                Main.tile[num21, num22 - num24].active = true;
                            }
                            num21--;
                            num25--;
                        }
                        num25 = genRand.Next(5, 13);
                        num21 = num23 + 1;
                        while ((Main.tile[num21 + 1, num22].active && Main.tile[num21, num22 + num24].active) && ((Main.tile[num21, num22].active && !Main.tile[num21, num22 - num24].active) && (num25 > 0)))
                        {
                            Main.tile[num21, num22].type = 0x30;
                            if (!Main.tile[num21 - 1, num22 - num24].active && !Main.tile[num21 + 1, num22 - num24].active)
                            {
                                Main.tile[num21, num22 - num24].type = 0x30;
                                Main.tile[num21, num22 - num24].active = true;
                            }
                            num21++;
                            num25--;
                        }
                    }
                }
                if (num18 > num19)
                {
                    num18 = 0;
                    num20++;
                }
            }
            num18 = 0;
            num19 = 0x3e8;
            num20 = 0;
            //Main.statusText = "Creating dungeon: 75%";
            while (num20 < (Main.maxTilesX / 100))
            {
                num18++;
                int num26 = genRand.Next(dMinX, dMaxX);
                int num27 = genRand.Next(((int) Main.worldSurface) + 0x19, dMaxY);
                int num28 = num27;
                if ((Main.tile[num26, num27].wall == wallType) && !Main.tile[num26, num27].active)
                {
                    int num29 = 1;
                    if (genRand.Next(2) == 0)
                    {
                        num29 = -1;
                    }
                    while (((num26 > 5) && (num26 < (Main.maxTilesX - 5))) && !Main.tile[num26, num27].active)
                    {
                        num26 += num29;
                    }
                    if ((Main.tile[num26, num27 - 1].active && Main.tile[num26, num27 + 1].active) && (!Main.tile[num26 - num29, num27 - 1].active && !Main.tile[num26 - num29, num27 + 1].active))
                    {
                        num20++;
                        int num30 = genRand.Next(5, 13);
                        while ((Main.tile[num26, num27 - 1].active && Main.tile[num26 + num29, num27].active) && ((Main.tile[num26, num27].active && !Main.tile[num26 - num29, num27].active) && (num30 > 0)))
                        {
                            Main.tile[num26, num27].type = 0x30;
                            if (!Main.tile[num26 - num29, num27 - 1].active && !Main.tile[num26 - num29, num27 + 1].active)
                            {
                                Main.tile[num26 - num29, num27].type = 0x30;
                                Main.tile[num26 - num29, num27].active = true;
                            }
                            num27--;
                            num30--;
                        }
                        num30 = genRand.Next(5, 13);
                        num27 = num28 + 1;
                        while ((Main.tile[num26, num27 + 1].active && Main.tile[num26 + num29, num27].active) && ((Main.tile[num26, num27].active && !Main.tile[num26 - num29, num27].active) && (num30 > 0)))
                        {
                            Main.tile[num26, num27].type = 0x30;
                            if (!Main.tile[num26 - num29, num27 - 1].active && !Main.tile[num26 - num29, num27 + 1].active)
                            {
                                Main.tile[num26 - num29, num27].type = 0x30;
                                Main.tile[num26 - num29, num27].active = true;
                            }
                            num27++;
                            num30--;
                        }
                    }
                }
                if (num18 > num19)
                {
                    num18 = 0;
                    num20++;
                }
            }
            //Main.statusText = "Creating dungeon: 80%";
            for (int k = 0; k < numDDoors; k++)
            {
                int num32 = DDoorX[k] - 10;
                int num33 = DDoorX[k] + 10;
                int num34 = 100;
                int num35 = 0;
                int num36 = 0;
                int num37 = 0;
                for (int num38 = num32; num38 < num33; num38++)
                {
                    bool flag = true;
                    int num39 = DDoorY[k];
                    while (!Main.tile[num38, num39].active)
                    {
                        num39--;
                    }
                    if (!Main.tileDungeon[Main.tile[num38, num39].type])
                    {
                        flag = false;
                    }
                    num36 = num39;
                    num39 = DDoorY[k];
                    while (!Main.tile[num38, num39].active)
                    {
                        num39++;
                    }
                    if (!Main.tileDungeon[Main.tile[num38, num39].type])
                    {
                        flag = false;
                    }
                    num37 = num39;
                    if ((num37 - num36) >= 3)
                    {
                        int num40 = num38 - 20;
                        int num41 = num38 + 20;
                        int num42 = num37 - 10;
                        int num43 = num37 + 10;
                        for (int num44 = num40; num44 < num41; num44++)
                        {
                            for (int num45 = num42; num45 < num43; num45++)
                            {
                                if (Main.tile[num44, num45].active && (Main.tile[num44, num45].type == 10))
                                {
                                    flag = false;
                                    break;
                                }
                            }
                        }
                        if (flag)
                        {
                            for (int num46 = num37 - 3; num46 < num37; num46++)
                            {
                                for (int num47 = num38 - 3; num47 <= (num38 + 3); num47++)
                                {
                                    if (Main.tile[num47, num46].active)
                                    {
                                        flag = false;
                                        break;
                                    }
                                }
                            }
                        }
                        if (flag && ((num37 - num36) < 20))
                        {
                            bool flag2 = false;
                            if ((DDoorPos[k] == 0) && ((num37 - num36) < num34))
                            {
                                flag2 = true;
                            }
                            if ((DDoorPos[k] == -1) && (num38 > num35))
                            {
                                flag2 = true;
                            }
                            if ((DDoorPos[k] == 1) && ((num38 < num35) || (num35 == 0)))
                            {
                                flag2 = true;
                            }
                            if (flag2)
                            {
                                num35 = num38;
                                num34 = num37 - num36;
                            }
                        }
                    }
                }
                if (num34 < 20)
                {
                    int num48 = num35;
                    int num49 = DDoorY[k];
                    int num50 = num49;
                    while (!Main.tile[num48, num49].active)
                    {
                        Main.tile[num48, num49].active = false;
                        num49++;
                    }
                    while (!Main.tile[num48, num50].active)
                    {
                        num50--;
                    }
                    num49--;
                    num50++;
                    for (int num51 = num50; num51 < (num49 - 2); num51++)
                    {
                        Main.tile[num48, num51].active = true;
                        Main.tile[num48, num51].type = (byte) tileType;
                    }
                    PlaceTile(num48, num49, 10, true, false, -1, 0);
                    num48--;
                    int num52 = num49 - 3;
                    while (!Main.tile[num48, num52].active)
                    {
                        num52--;
                    }
                    if (((num49 - num52) < ((num49 - num50) + 5)) && Main.tileDungeon[Main.tile[num48, num52].type])
                    {
                        for (int num53 = (num49 - 4) - genRand.Next(3); num53 > num52; num53--)
                        {
                            Main.tile[num48, num53].active = true;
                            Main.tile[num48, num53].type = (byte) tileType;
                        }
                    }
                    num48 += 2;
                    num52 = num49 - 3;
                    while (!Main.tile[num48, num52].active)
                    {
                        num52--;
                    }
                    if (((num49 - num52) < ((num49 - num50) + 5)) && Main.tileDungeon[Main.tile[num48, num52].type])
                    {
                        for (int num54 = (num49 - 4) - genRand.Next(3); num54 > num52; num54--)
                        {
                            Main.tile[num48, num54].active = true;
                            Main.tile[num48, num54].type = (byte) tileType;
                        }
                    }
                    num49++;
                    num48--;
                    Main.tile[num48 - 1, num49].active = true;
                    Main.tile[num48 - 1, num49].type = (byte) tileType;
                    Main.tile[num48 + 1, num49].active = true;
                    Main.tile[num48 + 1, num49].type = (byte) tileType;
                }
            }
            //Main.statusText = "Creating dungeon: 85%";
            for (int m = 0; m < numDPlats; m++)
            {
                int num56 = DPlatX[m];
                int num57 = DPlatY[m];
                int maxTilesX = Main.maxTilesX;
                int num59 = 10;
                for (int num60 = num57 - 5; num60 <= (num57 + 5); num60++)
                {
                    int num61 = num56;
                    int num62 = num56;
                    bool flag3 = false;
                    if (!Main.tile[num61, num60].active)
                    {
                        goto Label_10D9;
                    }
                    flag3 = true;
                    goto Label_1129;
                Label_10B5:
                    num61--;
                    if (!Main.tileDungeon[Main.tile[num61, num60].type])
                    {
                        flag3 = true;
                    }
                Label_10D9:
                    if (!Main.tile[num61, num60].active)
                    {
                        goto Label_10B5;
                    }
                    while (!Main.tile[num62, num60].active)
                    {
                        num62++;
                        if (!Main.tileDungeon[Main.tile[num62, num60].type])
                        {
                            flag3 = true;
                        }
                    }
                Label_1129:
                    if (!flag3 && ((num62 - num61) <= num59))
                    {
                        bool flag4 = true;
                        int num63 = (num56 - (num59 / 2)) - 2;
                        int num64 = (num56 + (num59 / 2)) + 2;
                        int num65 = num60 - 5;
                        int num66 = num60 + 5;
                        for (int num67 = num63; num67 <= num64; num67++)
                        {
                            for (int num68 = num65; num68 <= num66; num68++)
                            {
                                if (Main.tile[num67, num68].active && (Main.tile[num67, num68].type == 0x13))
                                {
                                    flag4 = false;
                                    break;
                                }
                            }
                        }
                        for (int num69 = num60 + 3; num69 >= (num60 - 5); num69--)
                        {
                            if (Main.tile[num56, num69].active)
                            {
                                flag4 = false;
                                break;
                            }
                        }
                        if (flag4)
                        {
                            maxTilesX = num60;
                            break;
                        }
                    }
                }
                if ((maxTilesX > (num57 - 10)) && (maxTilesX < (num57 + 10)))
                {
                    int num70 = num56;
                    int num71 = maxTilesX;
                    int num72 = num56 + 1;
                    while (!Main.tile[num70, num71].active)
                    {
                        Main.tile[num70, num71].active = true;
                        Main.tile[num70, num71].type = 0x13;
                        num70--;
                    }
                    while (!Main.tile[num72, num71].active)
                    {
                        Main.tile[num72, num71].active = true;
                        Main.tile[num72, num71].type = 0x13;
                        num72++;
                    }
                }
            }
            //Main.statusText = "Creating dungeon: 90%";
            num18 = 0;
            num19 = 0x3e8;
            num20 = 0;
            while (num20 < (Main.maxTilesX / 20))
            {
                num18++;
                int num73 = genRand.Next(dMinX, dMaxX);
                int num74 = genRand.Next(dMinY, dMaxY);
                bool flag5 = true;
                if ((Main.tile[num73, num74].wall == wallType) && !Main.tile[num73, num74].active)
                {
                    int num75 = 1;
                    if (genRand.Next(2) == 0)
                    {
                        num75 = -1;
                    }
                    while (flag5 && !Main.tile[num73, num74].active)
                    {
                        num73 -= num75;
                        if ((num73 < 5) || (num73 > (Main.maxTilesX - 5)))
                        {
                            flag5 = false;
                        }
                        else if (Main.tile[num73, num74].active && !Main.tileDungeon[Main.tile[num73, num74].type])
                        {
                            flag5 = false;
                        }
                    }
                    if (((flag5 && Main.tile[num73, num74].active) && (Main.tileDungeon[Main.tile[num73, num74].type] && Main.tile[num73, num74 - 1].active)) && ((Main.tileDungeon[Main.tile[num73, num74 - 1].type] && Main.tile[num73, num74 + 1].active) && Main.tileDungeon[Main.tile[num73, num74 + 1].type]))
                    {
                        num73 += num75;
                        for (int num76 = num73 - 3; num76 <= (num73 + 3); num76++)
                        {
                            for (int num77 = num74 - 3; num77 <= (num74 + 3); num77++)
                            {
                                if (Main.tile[num76, num77].active && (Main.tile[num76, num77].type == 0x13))
                                {
                                    flag5 = false;
                                    break;
                                }
                            }
                        }
                        if (flag5 && ((!Main.tile[num73, num74 - 1].active & !Main.tile[num73, num74 - 2].active) & !Main.tile[num73, num74 - 3].active))
                        {
                            int num78 = num73;
                            int num79 = num73;
                            while (((num78 > dMinX) && (num78 < dMaxX)) && ((!Main.tile[num78, num74].active && !Main.tile[num78, num74 - 1].active) && !Main.tile[num78, num74 + 1].active))
                            {
                                num78 += num75;
                            }
                            num78 = Math.Abs((int) (num73 - num78));
                            bool flag6 = false;
                            if (genRand.Next(2) == 0)
                            {
                                flag6 = true;
                            }
                            if (num78 > 5)
                            {
                                for (int num80 = genRand.Next(1, 4); num80 > 0; num80--)
                                {
                                    Main.tile[num73, num74].active = true;
                                    Main.tile[num73, num74].type = 0x13;
                                    if (flag6)
                                    {
                                        PlaceTile(num73, num74 - 1, 50, true, false, -1, 0);
                                        if ((genRand.Next(50) == 0) && (Main.tile[num73, num74 - 1].type == 50))
                                        {
                                            Main.tile[num73, num74 - 1].frameX = 90;
                                        }
                                    }
                                    num73 += num75;
                                }
                                num18 = 0;
                                num20++;
                                if (!flag6 && (genRand.Next(2) == 0))
                                {
                                    num73 = num79;
                                    num74--;
                                    int type = 0;
                                    if (genRand.Next(4) == 0)
                                    {
                                        type = 1;
                                    }
                                    if (type == 0)
                                    {
                                        type = 13;
                                    }
                                    else if (type == 1)
                                    {
                                        type = 0x31;
                                    }
                                    PlaceTile(num73, num74, type, true, false, -1, 0);
                                    if (Main.tile[num73, num74].type == 13)
                                    {
                                        if (genRand.Next(2) == 0)
                                        {
                                            Main.tile[num73, num74].frameX = 0x12;
                                        }
                                        else
                                        {
                                            Main.tile[num73, num74].frameX = 0x24;
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                if (num18 > num19)
                {
                    num18 = 0;
                    num20++;
                }
            }
            //Main.statusText = "Creating dungeon: 95%";
            int num82 = 0;
            for (int n = 0; n < numDRooms; n++)
            {
                int num84 = 0;
                while (num84 < 0x3e8)
                {
                    int num85 = (int) (dRoomSize[n] * 0.4);
                    int num86 = dRoomX[n] + genRand.Next(-num85, num85 + 1);
                    int num87 = dRoomY[n] + genRand.Next(-num85, num85 + 1);
                    int contain = 0;
                    num82++;
                    int style = 2;
                    switch (num82)
                    {
                        case 1:
                            contain = 0x149;
                            break;

                        case 2:
                            contain = 0x9b;
                            break;

                        case 3:
                            contain = 0x9c;
                            break;

                        case 4:
                            contain = 0x9d;
                            break;

                        case 5:
                            contain = 0xa3;
                            break;

                        case 6:
                            contain = 0x71;
                            break;

                        case 7:
                            contain = 0x147;
                            style = 0;
                            break;

                        default:
                            contain = 0xa4;
                            num82 = 0;
                            break;
                    }
                    if (num87 < (Main.worldSurface + 50.0))
                    {
                        contain = 0x147;
                        style = 0;
                    }
                    if ((contain == 0) && (genRand.Next(2) == 0))
                    {
                        num84 = 0x3e8;
                    }
                    else
                    {
                        if (AddBuriedChest(num86, num87, contain, false, style))
                        {
                            num84 += 0x3e8;
                        }
                        num84++;
                    }
                }
            }
            dMinX -= 0x19;
            dMaxX += 0x19;
            dMinY -= 0x19;
            dMaxY += 0x19;
            if (dMinX < 0)
            {
                dMinX = 0;
            }
            if (dMaxX > Main.maxTilesX)
            {
                dMaxX = Main.maxTilesX;
            }
            if (dMinY < 0)
            {
                dMinY = 0;
            }
            if (dMaxY > Main.maxTilesY)
            {
                dMaxY = Main.maxTilesY;
            }
            num18 = 0;
            num19 = 0x3e8;
            num20 = 0;
            while (num20 < (Main.maxTilesX / 200))
            {
                num18++;
                int num90 = genRand.Next(dMinX, dMaxX);
                int num91 = genRand.Next(dMinY, dMaxY);
                if (Main.tile[num90, num91].wall == wallType)
                {
                    for (int num92 = num91; num92 > dMinY; num92--)
                    {
                        if (Main.tile[num90, num92 - 1].active && (Main.tile[num90, num92 - 1].type == tileType))
                        {
                            bool flag7 = false;
                            for (int num93 = num90 - 15; num93 < (num90 + 15); num93++)
                            {
                                for (int num94 = num92 - 15; num94 < (num92 + 15); num94++)
                                {
                                    if ((((num93 > 0) && (num93 < Main.maxTilesX)) && ((num94 > 0) && (num94 < Main.maxTilesY))) && (Main.tile[num93, num94].type == 0x2a))
                                    {
                                        flag7 = true;
                                        break;
                                    }
                                }
                            }
                            if ((Main.tile[num90 - 1, num92].active || Main.tile[num90 + 1, num92].active) || ((Main.tile[num90 - 1, num92 + 1].active || Main.tile[num90 + 1, num92 + 1].active) || Main.tile[num90, num92 + 2].active))
                            {
                                flag7 = true;
                            }
                            if (!flag7)
                            {
                                Place1x2Top(num90, num92, 0x2a);
                                if (Main.tile[num90, num92].type == 0x2a)
                                {
                                    num18 = 0;
                                    num20++;
                                }
                            }
                            break;
                        }
                    }
                }
                if (num18 > num19)
                {
                    num20++;
                    num18 = 0;
                }
            }
        }

        public static bool meteor(int i, int j)
        {
            if ((i < 50) || (i > (Main.maxTilesX - 50)))
            {
                return false;
            }
            if ((j < 50) || (j > (Main.maxTilesY - 50)))
            {
                return false;
            }
            int num = 0x19;
            Rectangle rectangle = new Rectangle((i - num) * 0x10, (j - num) * 0x10, (num * 2) * 0x10, (num * 2) * 0x10);
            for (int k = 0; k < 0xff; k++)
            {
                if (Main.player[k].active)
                {
                    Rectangle rectangle2 = new Rectangle(((((int) Main.player[k].position.X) + (Main.player[k].width / 2)) - (NPC.sWidth / 2)) - NPC.safeRangeX, ((((int) Main.player[k].position.Y) + (Main.player[k].height / 2)) - (NPC.sHeight / 2)) - NPC.safeRangeY, NPC.sWidth + (NPC.safeRangeX * 2), NPC.sHeight + (NPC.safeRangeY * 2));
                    if (rectangle.Intersects(rectangle2))
                    {
                        return false;
                    }
                }
            }
            for (int m = 0; m < 0x3e8; m++)
            {
                if (Main.npc[m].active)
                {
                    Rectangle rectangle3 = new Rectangle((int) Main.npc[m].position.X, (int) Main.npc[m].position.Y, Main.npc[m].width, Main.npc[m].height);
                    if (rectangle.Intersects(rectangle3))
                    {
                        return false;
                    }
                }
            }
            for (int n = i - num; n < (i + num); n++)
            {
                for (int num5 = j - num; num5 < (j + num); num5++)
                {
                    if (Main.tile[n, num5].active && (Main.tile[n, num5].type == 0x15))
                    {
                        return false;
                    }
                }
            }
            stopDrops = true;
            num = 15;
            for (int num6 = i - num; num6 < (i + num); num6++)
            {
                for (int num7 = j - num; num7 < (j + num); num7++)
                {
                    if ((num7 > ((j + Main.rand.Next(-2, 3)) - 5)) && ((Math.Abs((int) (i - num6)) + Math.Abs((int) (j - num7))) < ((num * 1.5) + Main.rand.Next(-5, 5))))
                    {
                        if (!Main.tileSolid[Main.tile[num6, num7].type])
                        {
                            Main.tile[num6, num7].active = false;
                        }
                        Main.tile[num6, num7].type = 0x25;
                    }
                }
            }
            num = 10;
            for (int num8 = i - num; num8 < (i + num); num8++)
            {
                for (int num9 = j - num; num9 < (j + num); num9++)
                {
                    if ((num9 > ((j + Main.rand.Next(-2, 3)) - 5)) && ((Math.Abs((int) (i - num8)) + Math.Abs((int) (j - num9))) < (num + Main.rand.Next(-3, 4))))
                    {
                        Main.tile[num8, num9].active = false;
                    }
                }
            }
            num = 0x10;
            for (int num10 = i - num; num10 < (i + num); num10++)
            {
                for (int num11 = j - num; num11 < (j + num); num11++)
                {
                    if ((Main.tile[num10, num11].type == 5) || (Main.tile[num10, num11].type == 0x20))
                    {
                        KillTile(num10, num11, false, false, false);
                    }
                    SquareTileFrame(num10, num11, true);
                    SquareWallFrame(num10, num11, true);
                }
            }
            num = 0x17;
            for (int num12 = i - num; num12 < (i + num); num12++)
            {
                for (int num13 = j - num; num13 < (j + num); num13++)
                {
                    if ((Main.tile[num12, num13].active && (Main.rand.Next(10) == 0)) && ((Math.Abs((int) (i - num12)) + Math.Abs((int) (j - num13))) < (num * 1.3)))
                    {
                        if ((Main.tile[num12, num13].type == 5) || (Main.tile[num12, num13].type == 0x20))
                        {
                            KillTile(num12, num13, false, false, false);
                        }
                        Main.tile[num12, num13].type = 0x25;
                        SquareTileFrame(num12, num13, true);
                    }
                }
            }
            stopDrops = false;
            if (Main.netMode == 2)
            {
                NetMessage.SendData(0x19, -1, -1, "A meteorite has landed!", 0xff, 50f, 255f, 130f, 0);
            }
            if (Main.netMode != 1)
            {
                NetMessage.SendTileSquare(-1, i, j, 30);
            }
            return true;
        }

        public static void Mountinater(int i, int j)
        {
            Vector2 vector;
            Vector2 vector2;
            double num5 = genRand.Next(80, 120);
            double num6 = num5;
            float num7 = genRand.Next(40, 0x37);
            vector.X = i;
            vector.Y = j + (num7 / 2f);
            vector2.X = genRand.Next(-10, 11) * 0.1f;
            vector2.Y = genRand.Next(-20, -10) * 0.1f;
            while ((num5 > 0.0) && (num7 > 0f))
            {
                num5 -= genRand.Next(4);
                num7--;
                int num = (int) (vector.X - (num5 * 0.5));
                int maxTilesX = (int) (vector.X + (num5 * 0.5));
                int num2 = (int) (vector.Y - (num5 * 0.5));
                int maxTilesY = (int) (vector.Y + (num5 * 0.5));
                if (num < 0)
                {
                    num = 0;
                }
                if (maxTilesX > Main.maxTilesX)
                {
                    maxTilesX = Main.maxTilesX;
                }
                if (num2 < 0)
                {
                    num2 = 0;
                }
                if (maxTilesY > Main.maxTilesY)
                {
                    maxTilesY = Main.maxTilesY;
                }
                num6 = (num5 * genRand.Next(80, 120)) * 0.01;
                for (int k = num; k < maxTilesX; k++)
                {
                    for (int m = num2; m < maxTilesY; m++)
                    {
                        float num10 = Math.Abs((float) (k - vector.X));
                        float num11 = Math.Abs((float) (m - vector.Y));
                        if ((Math.Sqrt((double) ((num10 * num10) + (num11 * num11))) < (num6 * 0.4)) && !Main.tile[k, m].active)
                        {
                            Main.tile[k, m].active = true;
                            Main.tile[k, m].type = 0;
                        }
                    }
                }
                vector += vector2;
                vector2.X += genRand.Next(-10, 11) * 0.05f;
                vector2.Y += genRand.Next(-10, 11) * 0.05f;
                if (vector2.X > 0.5)
                {
                    vector2.X = 0.5f;
                }
                if (vector2.X < -0.5)
                {
                    vector2.X = -0.5f;
                }
                if (vector2.Y > -0.5)
                {
                    vector2.Y = -0.5f;
                }
                if (vector2.Y < -1.5)
                {
                    vector2.Y = -1.5f;
                }
            }
        }

        public static void MudWallRunner(int i, int j)
        {
            Vector2 vector;
            Vector2 vector2;
            double num5 = genRand.Next(5, 15);
            float num6 = genRand.Next(5, 20);
            float num7 = num6;
            vector.X = i;
            vector.Y = j;
            vector2.X = genRand.Next(-10, 11) * 0.1f;
            vector2.Y = genRand.Next(-10, 11) * 0.1f;
            while ((num5 > 0.0) && (num7 > 0f))
            {
                double num8 = num5 * (num7 / num6);
                num7--;
                int num = (int) (vector.X - (num8 * 0.5));
                int maxTilesX = (int) (vector.X + (num8 * 0.5));
                int num2 = (int) (vector.Y - (num8 * 0.5));
                int maxTilesY = (int) (vector.Y + (num8 * 0.5));
                if (num < 0)
                {
                    num = 0;
                }
                if (maxTilesX > Main.maxTilesX)
                {
                    maxTilesX = Main.maxTilesX;
                }
                if (num2 < 0)
                {
                    num2 = 0;
                }
                if (maxTilesY > Main.maxTilesY)
                {
                    maxTilesY = Main.maxTilesY;
                }
                for (int k = num; k < maxTilesX; k++)
                {
                    for (int m = num2; m < maxTilesY; m++)
                    {
                        if ((Math.Abs((float) (k - vector.X)) + Math.Abs((float) (m - vector.Y))) < ((num5 * 0.5) * (1.0 + (genRand.Next(-10, 11) * 0.015))))
                        {
                            Main.tile[k, m].wall = 0;
                        }
                    }
                }
                vector += vector2;
                vector2.X += genRand.Next(-10, 11) * 0.05f;
                if (vector2.X > 1f)
                {
                    vector2.X = 1f;
                }
                if (vector2.X < -1f)
                {
                    vector2.X = -1f;
                }
                vector2.Y += genRand.Next(-10, 11) * 0.05f;
                if (vector2.Y > 1f)
                {
                    vector2.Y = 1f;
                }
                if (vector2.Y < -1f)
                {
                    vector2.Y = -1f;
                }
            }
        }

        public static bool OpenDoor(int i, int j, int direction)
        {
            int num3;
            int num = 0;
            if (Main.tile[i, j - 1] == null)
            {
                Main.tile[i, j - 1] = new Tile();
            }
            if (Main.tile[i, j - 2] == null)
            {
                Main.tile[i, j - 2] = new Tile();
            }
            if (Main.tile[i, j + 1] == null)
            {
                Main.tile[i, j + 1] = new Tile();
            }
            if (Main.tile[i, j] == null)
            {
                Main.tile[i, j] = new Tile();
            }
            if ((Main.tile[i, j - 1].frameY == 0) && (Main.tile[i, j - 1].type == Main.tile[i, j].type))
            {
                num = j - 1;
            }
            else if ((Main.tile[i, j - 2].frameY == 0) && (Main.tile[i, j - 2].type == Main.tile[i, j].type))
            {
                num = j - 2;
            }
            else if ((Main.tile[i, j + 1].frameY == 0) && (Main.tile[i, j + 1].type == Main.tile[i, j].type))
            {
                num = j + 1;
            }
            else
            {
                num = j;
            }
            int num2 = i;
            short num4 = 0;
            if (direction == -1)
            {
                num2 = i - 1;
                num4 = 0x24;
                num3 = i - 1;
            }
            else
            {
                num2 = i;
                num3 = i + 1;
            }
            bool flag = true;
            for (int k = num; k < (num + 3); k++)
            {
                if (Main.tile[num3, k] == null)
                {
                    Main.tile[num3, k] = new Tile();
                }
                if (Main.tile[num3, k].active)
                {
                    if ((((Main.tile[num3, k].type == 3) || (Main.tile[num3, k].type == 0x18)) || ((Main.tile[num3, k].type == 0x34) || (Main.tile[num3, k].type == 0x3d))) || (((Main.tile[num3, k].type == 0x3e) || (Main.tile[num3, k].type == 0x45)) || (((Main.tile[num3, k].type == 0x47) || (Main.tile[num3, k].type == 0x49)) || (Main.tile[num3, k].type == 0x4a))))
                    {
                        KillTile(num3, k, false, false, false);
                    }
                    else
                    {
                        flag = false;
                        break;
                    }
                }
            }
            if (flag)
            {
                Main.PlaySound(8, i * 0x10, j * 0x10, 1);
                Main.tile[num2, num].active = true;
                Main.tile[num2, num].type = 11;
                Main.tile[num2, num].frameY = 0;
                Main.tile[num2, num].frameX = num4;
                if (Main.tile[num2 + 1, num] == null)
                {
                    Main.tile[num2 + 1, num] = new Tile();
                }
                Main.tile[num2 + 1, num].active = true;
                Main.tile[num2 + 1, num].type = 11;
                Main.tile[num2 + 1, num].frameY = 0;
                Main.tile[num2 + 1, num].frameX = (short) (num4 + 0x12);
                if (Main.tile[num2, num + 1] == null)
                {
                    Main.tile[num2, num + 1] = new Tile();
                }
                Main.tile[num2, num + 1].active = true;
                Main.tile[num2, num + 1].type = 11;
                Main.tile[num2, num + 1].frameY = 0x12;
                Main.tile[num2, num + 1].frameX = num4;
                if (Main.tile[num2 + 1, num + 1] == null)
                {
                    Main.tile[num2 + 1, num + 1] = new Tile();
                }
                Main.tile[num2 + 1, num + 1].active = true;
                Main.tile[num2 + 1, num + 1].type = 11;
                Main.tile[num2 + 1, num + 1].frameY = 0x12;
                Main.tile[num2 + 1, num + 1].frameX = (short) (num4 + 0x12);
                if (Main.tile[num2, num + 2] == null)
                {
                    Main.tile[num2, num + 2] = new Tile();
                }
                Main.tile[num2, num + 2].active = true;
                Main.tile[num2, num + 2].type = 11;
                Main.tile[num2, num + 2].frameY = 0x24;
                Main.tile[num2, num + 2].frameX = num4;
                if (Main.tile[num2 + 1, num + 2] == null)
                {
                    Main.tile[num2 + 1, num + 2] = new Tile();
                }
                Main.tile[num2 + 1, num + 2].active = true;
                Main.tile[num2 + 1, num + 2].type = 11;
                Main.tile[num2 + 1, num + 2].frameY = 0x24;
                Main.tile[num2 + 1, num + 2].frameX = (short) (num4 + 0x12);
                for (int m = num2 - 1; m <= (num2 + 2); m++)
                {
                    for (int n = num - 1; n <= (num + 2); n++)
                    {
                        TileFrame(m, n, false, false);
                    }
                }
            }
            return flag;
        }

        public static void Place1x2(int x, int y, int type, int style)
        {
            short num = 0;
            if (type == 20)
            {
                num = (short) (genRand.Next(3) * 0x12);
            }
            if (Main.tile[x, y - 1] == null)
            {
                Main.tile[x, y - 1] = new Tile();
            }
            if (Main.tile[x, y + 1] == null)
            {
                Main.tile[x, y + 1] = new Tile();
            }
            if ((Main.tile[x, y + 1].active && Main.tileSolid[Main.tile[x, y + 1].type]) && !Main.tile[x, y - 1].active)
            {
                short num2 = (short) (style * 40);
                Main.tile[x, y - 1].active = true;
                Main.tile[x, y - 1].frameY = num2;
                Main.tile[x, y - 1].frameX = num;
                Main.tile[x, y - 1].type = (byte) type;
                Main.tile[x, y].active = true;
                Main.tile[x, y].frameY = (short) (num2 + 0x12);
                Main.tile[x, y].frameX = num;
                Main.tile[x, y].type = (byte) type;
            }
        }

        public static void Place1x2Top(int x, int y, int type)
        {
            short num = 0;
            if (Main.tile[x, y - 1] == null)
            {
                Main.tile[x, y - 1] = new Tile();
            }
            if (Main.tile[x, y + 1] == null)
            {
                Main.tile[x, y + 1] = new Tile();
            }
            if ((Main.tile[x, y - 1].active && Main.tileSolid[Main.tile[x, y - 1].type]) && (!Main.tileSolidTop[Main.tile[x, y - 1].type] && !Main.tile[x, y + 1].active))
            {
                Main.tile[x, y].active = true;
                Main.tile[x, y].frameY = 0;
                Main.tile[x, y].frameX = num;
                Main.tile[x, y].type = (byte) type;
                Main.tile[x, y + 1].active = true;
                Main.tile[x, y + 1].frameY = 0x12;
                Main.tile[x, y + 1].frameX = num;
                Main.tile[x, y + 1].type = (byte) type;
            }
        }

        public static void Place1xX(int x, int y, int type, int style = 0)
        {
            int num = style * 0x12;
            int num2 = 3;
            if (type == 0x5c)
            {
                num2 = 6;
            }
            bool flag = true;
            for (int i = (y - num2) + 1; i < (y + 1); i++)
            {
                if (Main.tile[x, i] == null)
                {
                    Main.tile[x, i] = new Tile();
                }
                if (Main.tile[x, i].active)
                {
                    flag = false;
                }
                if ((type == 0x5d) && (Main.tile[x, i].liquid > 0))
                {
                    flag = false;
                }
            }
            if ((flag && Main.tile[x, y + 1].active) && Main.tileSolid[Main.tile[x, y + 1].type])
            {
                for (int j = 0; j < num2; j++)
                {
                    Main.tile[x, ((y - num2) + 1) + j].active = true;
                    Main.tile[x, ((y - num2) + 1) + j].frameY = (short) (j * 0x12);
                    Main.tile[x, ((y - num2) + 1) + j].frameX = (short) num;
                    Main.tile[x, ((y - num2) + 1) + j].type = (byte) type;
                }
            }
        }

        public static void Place2x1(int x, int y, int type)
        {
            if (Main.tile[x, y] == null)
            {
                Main.tile[x, y] = new Tile();
            }
            if (Main.tile[x + 1, y] == null)
            {
                Main.tile[x + 1, y] = new Tile();
            }
            if (Main.tile[x, y + 1] == null)
            {
                Main.tile[x, y + 1] = new Tile();
            }
            if (Main.tile[x + 1, y + 1] == null)
            {
                Main.tile[x + 1, y + 1] = new Tile();
            }
            bool flag = false;
            if ((((type != 0x1d) && (type != 0x67)) && (Main.tile[x, y + 1].active && Main.tile[x + 1, y + 1].active)) && ((Main.tileSolid[Main.tile[x, y + 1].type] && Main.tileSolid[Main.tile[x + 1, y + 1].type]) && (!Main.tile[x, y].active && !Main.tile[x + 1, y].active)))
            {
                flag = true;
            }
            else if (((type == 0x1d) || (type == 0x67)) && (((Main.tile[x, y + 1].active && Main.tile[x + 1, y + 1].active) && (Main.tileTable[Main.tile[x, y + 1].type] && Main.tileTable[Main.tile[x + 1, y + 1].type])) && (!Main.tile[x, y].active && !Main.tile[x + 1, y].active)))
            {
                flag = true;
            }
            if (flag)
            {
                Main.tile[x, y].active = true;
                Main.tile[x, y].frameY = 0;
                Main.tile[x, y].frameX = 0;
                Main.tile[x, y].type = (byte) type;
                Main.tile[x + 1, y].active = true;
                Main.tile[x + 1, y].frameY = 0;
                Main.tile[x + 1, y].frameX = 0x12;
                Main.tile[x + 1, y].type = (byte) type;
            }
        }

        public static void Place2x2(int x, int superY, int type)
        {
            int num = superY;
            if (type == 0x5f)
            {
                num++;
            }
            if (((x >= 5) && (x <= (Main.maxTilesX - 5))) && ((num >= 5) && (num <= (Main.maxTilesY - 5))))
            {
                bool flag = true;
                for (int i = x - 1; i < (x + 1); i++)
                {
                    for (int j = num - 1; j < (num + 1); j++)
                    {
                        if (Main.tile[i, j] == null)
                        {
                            Main.tile[i, j] = new Tile();
                        }
                        if (Main.tile[i, j].active)
                        {
                            flag = false;
                        }
                        if ((type == 0x62) && (Main.tile[i, j].liquid > 0))
                        {
                            flag = false;
                        }
                    }
                    if (type == 0x5f)
                    {
                        if (Main.tile[i, num - 2] == null)
                        {
                            Main.tile[i, num - 2] = new Tile();
                        }
                        if ((!Main.tile[i, num - 2].active || !Main.tileSolid[Main.tile[i, num - 2].type]) || Main.tileSolidTop[Main.tile[i, num - 2].type])
                        {
                            flag = false;
                        }
                    }
                    else
                    {
                        if (Main.tile[i, num + 1] == null)
                        {
                            Main.tile[i, num + 1] = new Tile();
                        }
                        if (!Main.tile[i, num + 1].active || (!Main.tileSolid[Main.tile[i, num + 1].type] && !Main.tileTable[Main.tile[i, num + 1].type]))
                        {
                            flag = false;
                        }
                    }
                }
                if (flag)
                {
                    Main.tile[x - 1, num - 1].active = true;
                    Main.tile[x - 1, num - 1].frameY = 0;
                    Main.tile[x - 1, num - 1].frameX = 0;
                    Main.tile[x - 1, num - 1].type = (byte) type;
                    Main.tile[x, num - 1].active = true;
                    Main.tile[x, num - 1].frameY = 0;
                    Main.tile[x, num - 1].frameX = 0x12;
                    Main.tile[x, num - 1].type = (byte) type;
                    Main.tile[x - 1, num].active = true;
                    Main.tile[x - 1, num].frameY = 0x12;
                    Main.tile[x - 1, num].frameX = 0;
                    Main.tile[x - 1, num].type = (byte) type;
                    Main.tile[x, num].active = true;
                    Main.tile[x, num].frameY = 0x12;
                    Main.tile[x, num].frameX = 0x12;
                    Main.tile[x, num].type = (byte) type;
                }
            }
        }

        public static void Place2xX(int x, int y, int type, int style = 0)
        {
            int num = style * 0x12;
            int num2 = 3;
            if (type == 0x68)
            {
                num2 = 5;
            }
            bool flag = true;
            for (int i = (y - num2) + 1; i < (y + 1); i++)
            {
                if (Main.tile[x, i] == null)
                {
                    Main.tile[x, i] = new Tile();
                }
                if (Main.tile[x, i].active)
                {
                    flag = false;
                }
                if (Main.tile[x + 1, i] == null)
                {
                    Main.tile[x + 1, i] = new Tile();
                }
                if (Main.tile[x + 1, i].active)
                {
                    flag = false;
                }
            }
            if (((flag && Main.tile[x, y + 1].active) && (Main.tileSolid[Main.tile[x, y + 1].type] && Main.tile[x + 1, y + 1].active)) && Main.tileSolid[Main.tile[x + 1, y + 1].type])
            {
                for (int j = 0; j < num2; j++)
                {
                    Main.tile[x, ((y - num2) + 1) + j].active = true;
                    Main.tile[x, ((y - num2) + 1) + j].frameY = (short) (j * 0x12);
                    Main.tile[x, ((y - num2) + 1) + j].frameX = (short) num;
                    Main.tile[x, ((y - num2) + 1) + j].type = (byte) type;
                    Main.tile[x + 1, ((y - num2) + 1) + j].active = true;
                    Main.tile[x + 1, ((y - num2) + 1) + j].frameY = (short) (j * 0x12);
                    Main.tile[x + 1, ((y - num2) + 1) + j].frameX = (short) (num + 0x12);
                    Main.tile[x + 1, ((y - num2) + 1) + j].type = (byte) type;
                }
            }
        }

        public static void Place3x2(int x, int y, int type)
        {
            if (((x >= 5) && (x <= (Main.maxTilesX - 5))) && ((y >= 5) && (y <= (Main.maxTilesY - 5))))
            {
                bool flag = true;
                for (int i = x - 1; i < (x + 2); i++)
                {
                    for (int j = y - 1; j < (y + 1); j++)
                    {
                        if (Main.tile[i, j] == null)
                        {
                            Main.tile[i, j] = new Tile();
                        }
                        if (Main.tile[i, j].active)
                        {
                            flag = false;
                        }
                    }
                    if (Main.tile[i, y + 1] == null)
                    {
                        Main.tile[i, y + 1] = new Tile();
                    }
                    if (!Main.tile[i, y + 1].active || !Main.tileSolid[Main.tile[i, y + 1].type])
                    {
                        flag = false;
                    }
                }
                if (flag)
                {
                    Main.tile[x - 1, y - 1].active = true;
                    Main.tile[x - 1, y - 1].frameY = 0;
                    Main.tile[x - 1, y - 1].frameX = 0;
                    Main.tile[x - 1, y - 1].type = (byte) type;
                    Main.tile[x, y - 1].active = true;
                    Main.tile[x, y - 1].frameY = 0;
                    Main.tile[x, y - 1].frameX = 0x12;
                    Main.tile[x, y - 1].type = (byte) type;
                    Main.tile[x + 1, y - 1].active = true;
                    Main.tile[x + 1, y - 1].frameY = 0;
                    Main.tile[x + 1, y - 1].frameX = 0x24;
                    Main.tile[x + 1, y - 1].type = (byte) type;
                    Main.tile[x - 1, y].active = true;
                    Main.tile[x - 1, y].frameY = 0x12;
                    Main.tile[x - 1, y].frameX = 0;
                    Main.tile[x - 1, y].type = (byte) type;
                    Main.tile[x, y].active = true;
                    Main.tile[x, y].frameY = 0x12;
                    Main.tile[x, y].frameX = 0x12;
                    Main.tile[x, y].type = (byte) type;
                    Main.tile[x + 1, y].active = true;
                    Main.tile[x + 1, y].frameY = 0x12;
                    Main.tile[x + 1, y].frameX = 0x24;
                    Main.tile[x + 1, y].type = (byte) type;
                }
            }
        }

        public static void Place3x3(int x, int y, int type)
        {
            bool flag = true;
            int num = 0;
            if (type == 0x6a)
            {
                num = -2;
                for (int i = x - 1; i < (x + 2); i++)
                {
                    for (int k = y - 2; k < (y + 1); k++)
                    {
                        if (Main.tile[i, k] == null)
                        {
                            Main.tile[i, k] = new Tile();
                        }
                        if (Main.tile[i, k].active)
                        {
                            flag = false;
                        }
                    }
                }
                for (int j = x - 1; j < (x + 2); j++)
                {
                    if (Main.tile[j, y + 1] == null)
                    {
                        Main.tile[j, y + 1] = new Tile();
                    }
                    if (!Main.tile[j, y + 1].active || !Main.tileSolid[Main.tile[j, y + 1].type])
                    {
                        flag = false;
                        break;
                    }
                }
            }
            else
            {
                for (int m = x - 1; m < (x + 2); m++)
                {
                    for (int n = y; n < (y + 3); n++)
                    {
                        if (Main.tile[m, n] == null)
                        {
                            Main.tile[m, n] = new Tile();
                        }
                        if (Main.tile[m, n].active)
                        {
                            flag = false;
                        }
                    }
                }
                if (Main.tile[x, y - 1] == null)
                {
                    Main.tile[x, y - 1] = new Tile();
                }
                if ((!Main.tile[x, y - 1].active || !Main.tileSolid[Main.tile[x, y - 1].type]) || Main.tileSolidTop[Main.tile[x, y - 1].type])
                {
                    flag = false;
                }
            }
            if (flag)
            {
                Main.tile[x - 1, y + num].active = true;
                Main.tile[x - 1, y + num].frameY = 0;
                Main.tile[x - 1, y + num].frameX = 0;
                Main.tile[x - 1, y + num].type = (byte) type;
                Main.tile[x, y + num].active = true;
                Main.tile[x, y + num].frameY = 0;
                Main.tile[x, y + num].frameX = 0x12;
                Main.tile[x, y + num].type = (byte) type;
                Main.tile[x + 1, y + num].active = true;
                Main.tile[x + 1, y + num].frameY = 0;
                Main.tile[x + 1, y + num].frameX = 0x24;
                Main.tile[x + 1, y + num].type = (byte) type;
                Main.tile[x - 1, (y + 1) + num].active = true;
                Main.tile[x - 1, (y + 1) + num].frameY = 0x12;
                Main.tile[x - 1, (y + 1) + num].frameX = 0;
                Main.tile[x - 1, (y + 1) + num].type = (byte) type;
                Main.tile[x, (y + 1) + num].active = true;
                Main.tile[x, (y + 1) + num].frameY = 0x12;
                Main.tile[x, (y + 1) + num].frameX = 0x12;
                Main.tile[x, (y + 1) + num].type = (byte) type;
                Main.tile[x + 1, (y + 1) + num].active = true;
                Main.tile[x + 1, (y + 1) + num].frameY = 0x12;
                Main.tile[x + 1, (y + 1) + num].frameX = 0x24;
                Main.tile[x + 1, (y + 1) + num].type = (byte) type;
                Main.tile[x - 1, (y + 2) + num].active = true;
                Main.tile[x - 1, (y + 2) + num].frameY = 0x24;
                Main.tile[x - 1, (y + 2) + num].frameX = 0;
                Main.tile[x - 1, (y + 2) + num].type = (byte) type;
                Main.tile[x, (y + 2) + num].active = true;
                Main.tile[x, (y + 2) + num].frameY = 0x24;
                Main.tile[x, (y + 2) + num].frameX = 0x12;
                Main.tile[x, (y + 2) + num].type = (byte) type;
                Main.tile[x + 1, (y + 2) + num].active = true;
                Main.tile[x + 1, (y + 2) + num].frameY = 0x24;
                Main.tile[x + 1, (y + 2) + num].frameX = 0x24;
                Main.tile[x + 1, (y + 2) + num].type = (byte) type;
            }
        }

        public static void Place3x4(int x, int y, int type)
        {
            if (((x >= 5) && (x <= (Main.maxTilesX - 5))) && ((y >= 5) && (y <= (Main.maxTilesY - 5))))
            {
                bool flag = true;
                for (int i = x - 1; i < (x + 2); i++)
                {
                    for (int j = y - 3; j < (y + 1); j++)
                    {
                        if (Main.tile[i, j] == null)
                        {
                            Main.tile[i, j] = new Tile();
                        }
                        if (Main.tile[i, j].active)
                        {
                            flag = false;
                        }
                    }
                    if (Main.tile[i, y + 1] == null)
                    {
                        Main.tile[i, y + 1] = new Tile();
                    }
                    if (!Main.tile[i, y + 1].active || !Main.tileSolid[Main.tile[i, y + 1].type])
                    {
                        flag = false;
                    }
                }
                if (flag)
                {
                    for (int k = -3; k <= 0; k++)
                    {
                        short num4 = (short) ((3 + k) * 0x12);
                        Main.tile[x - 1, y + k].active = true;
                        Main.tile[x - 1, y + k].frameY = num4;
                        Main.tile[x - 1, y + k].frameX = 0;
                        Main.tile[x - 1, y + k].type = (byte) type;
                        Main.tile[x, y + k].active = true;
                        Main.tile[x, y + k].frameY = num4;
                        Main.tile[x, y + k].frameX = 0x12;
                        Main.tile[x, y + k].type = (byte) type;
                        Main.tile[x + 1, y + k].active = true;
                        Main.tile[x + 1, y + k].frameY = num4;
                        Main.tile[x + 1, y + k].frameX = 0x24;
                        Main.tile[x + 1, y + k].type = (byte) type;
                    }
                }
            }
        }

        public static void Place4x2(int x, int y, int type, int direction = -1)
        {
            if (((x >= 5) && (x <= (Main.maxTilesX - 5))) && ((y >= 5) && (y <= (Main.maxTilesY - 5))))
            {
                bool flag = true;
                for (int i = x - 1; i < (x + 3); i++)
                {
                    for (int j = y - 1; j < (y + 1); j++)
                    {
                        if (Main.tile[i, j] == null)
                        {
                            Main.tile[i, j] = new Tile();
                        }
                        if (Main.tile[i, j].active)
                        {
                            flag = false;
                        }
                    }
                    if (Main.tile[i, y + 1] == null)
                    {
                        Main.tile[i, y + 1] = new Tile();
                    }
                    if (!Main.tile[i, y + 1].active || !Main.tileSolid[Main.tile[i, y + 1].type])
                    {
                        flag = false;
                    }
                }
                short num3 = 0;
                if (direction == 1)
                {
                    num3 = 0x48;
                }
                if (flag)
                {
                    Main.tile[x - 1, y - 1].active = true;
                    Main.tile[x - 1, y - 1].frameY = 0;
                    Main.tile[x - 1, y - 1].frameX = num3;
                    Main.tile[x - 1, y - 1].type = (byte) type;
                    Main.tile[x, y - 1].active = true;
                    Main.tile[x, y - 1].frameY = 0;
                    Main.tile[x, y - 1].frameX = (short) (0x12 + num3);
                    Main.tile[x, y - 1].type = (byte) type;
                    Main.tile[x + 1, y - 1].active = true;
                    Main.tile[x + 1, y - 1].frameY = 0;
                    Main.tile[x + 1, y - 1].frameX = (short) (0x24 + num3);
                    Main.tile[x + 1, y - 1].type = (byte) type;
                    Main.tile[x + 2, y - 1].active = true;
                    Main.tile[x + 2, y - 1].frameY = 0;
                    Main.tile[x + 2, y - 1].frameX = (short) (0x36 + num3);
                    Main.tile[x + 2, y - 1].type = (byte) type;
                    Main.tile[x - 1, y].active = true;
                    Main.tile[x - 1, y].frameY = 0x12;
                    Main.tile[x - 1, y].frameX = num3;
                    Main.tile[x - 1, y].type = (byte) type;
                    Main.tile[x, y].active = true;
                    Main.tile[x, y].frameY = 0x12;
                    Main.tile[x, y].frameX = (short) (0x12 + num3);
                    Main.tile[x, y].type = (byte) type;
                    Main.tile[x + 1, y].active = true;
                    Main.tile[x + 1, y].frameY = 0x12;
                    Main.tile[x + 1, y].frameX = (short) (0x24 + num3);
                    Main.tile[x + 1, y].type = (byte) type;
                    Main.tile[x + 2, y].active = true;
                    Main.tile[x + 2, y].frameY = 0x12;
                    Main.tile[x + 2, y].frameX = (short) (0x36 + num3);
                    Main.tile[x + 2, y].type = (byte) type;
                }
            }
        }

        public static bool PlaceAlch(int x, int y, int style)
        {
            if (Main.tile[x, y] == null)
            {
                Main.tile[x, y] = new Tile();
            }
            if (Main.tile[x, y + 1] == null)
            {
                Main.tile[x, y + 1] = new Tile();
            }
            if (!Main.tile[x, y].active && Main.tile[x, y + 1].active)
            {
                bool flag = false;
                if (style == 0)
                {
                    if ((Main.tile[x, y + 1].type != 2) && (Main.tile[x, y + 1].type != 0x4e))
                    {
                        flag = true;
                    }
                    if (Main.tile[x, y].liquid > 0)
                    {
                        flag = true;
                    }
                }
                else if (style == 1)
                {
                    if ((Main.tile[x, y + 1].type != 60) && (Main.tile[x, y + 1].type != 0x4e))
                    {
                        flag = true;
                    }
                    if (Main.tile[x, y].liquid > 0)
                    {
                        flag = true;
                    }
                }
                else if (style == 2)
                {
                    if (((Main.tile[x, y + 1].type != 0) && (Main.tile[x, y + 1].type != 0x3b)) && (Main.tile[x, y + 1].type != 0x4e))
                    {
                        flag = true;
                    }
                    if (Main.tile[x, y].liquid > 0)
                    {
                        flag = true;
                    }
                }
                else if (style == 3)
                {
                    if (((Main.tile[x, y + 1].type != 0x17) && (Main.tile[x, y + 1].type != 0x19)) && (Main.tile[x, y + 1].type != 0x4e))
                    {
                        flag = true;
                    }
                    if (Main.tile[x, y].liquid > 0)
                    {
                        flag = true;
                    }
                }
                else if (style == 4)
                {
                    if ((Main.tile[x, y + 1].type != 0x35) && (Main.tile[x, y + 1].type != 0x4e))
                    {
                        flag = true;
                    }
                    if ((Main.tile[x, y].liquid > 0) && Main.tile[x, y].lava)
                    {
                        flag = true;
                    }
                }
                else if (style == 5)
                {
                    if ((Main.tile[x, y + 1].type != 0x39) && (Main.tile[x, y + 1].type != 0x4e))
                    {
                        flag = true;
                    }
                    if ((Main.tile[x, y].liquid > 0) && !Main.tile[x, y].lava)
                    {
                        flag = true;
                    }
                }
                if (!flag)
                {
                    Main.tile[x, y].active = true;
                    Main.tile[x, y].type = 0x52;
                    Main.tile[x, y].frameX = (short) (0x12 * style);
                    Main.tile[x, y].frameY = 0;
                    return true;
                }
            }
            return false;
        }

        public static void PlaceBanner(int x, int y, int type, int style = 0)
        {
            int num = style * 0x12;
            if (Main.tile[x, y - 1] == null)
            {
                Main.tile[x, y - 1] = new Tile();
            }
            if (Main.tile[x, y] == null)
            {
                Main.tile[x, y] = new Tile();
            }
            if (Main.tile[x, y + 1] == null)
            {
                Main.tile[x, y + 1] = new Tile();
            }
            if (Main.tile[x, y + 2] == null)
            {
                Main.tile[x, y + 2] = new Tile();
            }
            if (((Main.tile[x, y - 1].active && Main.tileSolid[Main.tile[x, y - 1].type]) && (!Main.tileSolidTop[Main.tile[x, y - 1].type] && !Main.tile[x, y].active)) && (!Main.tile[x, y + 1].active && !Main.tile[x, y + 2].active))
            {
                Main.tile[x, y].active = true;
                Main.tile[x, y].frameY = 0;
                Main.tile[x, y].frameX = (short) num;
                Main.tile[x, y].type = (byte) type;
                Main.tile[x, y + 1].active = true;
                Main.tile[x, y + 1].frameY = 0x12;
                Main.tile[x, y + 1].frameX = (short) num;
                Main.tile[x, y + 1].type = (byte) type;
                Main.tile[x, y + 2].active = true;
                Main.tile[x, y + 2].frameY = 0x24;
                Main.tile[x, y + 2].frameX = (short) num;
                Main.tile[x, y + 2].type = (byte) type;
            }
        }

        public static int PlaceChest(int x, int y, int type = 0x15, bool notNearOtherChests = false, int style = 0)
        {
            bool flag = true;
            int num = -1;
            for (int i = x; i < (x + 2); i++)
            {
                for (int j = y - 1; j < (y + 1); j++)
                {
                    if (Main.tile[i, j] == null)
                    {
                        Main.tile[i, j] = new Tile();
                    }
                    if (Main.tile[i, j].active)
                    {
                        flag = false;
                    }
                    if (Main.tile[i, j].lava)
                    {
                        flag = false;
                    }
                }
                if (Main.tile[i, y + 1] == null)
                {
                    Main.tile[i, y + 1] = new Tile();
                }
                if (!Main.tile[i, y + 1].active || !Main.tileSolid[Main.tile[i, y + 1].type])
                {
                    flag = false;
                }
            }
            if (flag && notNearOtherChests)
            {
                for (int k = x - 0x19; k < (x + 0x19); k++)
                {
                    for (int m = y - 8; m < (y + 8); m++)
                    {
                        try
                        {
                            if (Main.tile[k, m].active && (Main.tile[k, m].type == 0x15))
                            {
                                flag = false;
                                return -1;
                            }
                        }
                        catch
                        {
                        }
                    }
                }
            }
            if (flag)
            {
                num = Chest.CreateChest(x, y - 1);
                if (num == -1)
                {
                    flag = false;
                }
            }
            if (flag)
            {
                Main.tile[x, y - 1].active = true;
                Main.tile[x, y - 1].frameY = 0;
                Main.tile[x, y - 1].frameX = (short) (0x24 * style);
                Main.tile[x, y - 1].type = (byte) type;
                Main.tile[x + 1, y - 1].active = true;
                Main.tile[x + 1, y - 1].frameY = 0;
                Main.tile[x + 1, y - 1].frameX = (short) (0x12 + (0x24 * style));
                Main.tile[x + 1, y - 1].type = (byte) type;
                Main.tile[x, y].active = true;
                Main.tile[x, y].frameY = 0x12;
                Main.tile[x, y].frameX = (short) (0x24 * style);
                Main.tile[x, y].type = (byte) type;
                Main.tile[x + 1, y].active = true;
                Main.tile[x + 1, y].frameY = 0x12;
                Main.tile[x + 1, y].frameX = (short) (0x12 + (0x24 * style));
                Main.tile[x + 1, y].type = (byte) type;
            }
            return num;
        }

        public static bool PlaceDoor(int i, int j, int type)
        {
            try
            {
                if ((Main.tile[i, j - 2].active && Main.tileSolid[Main.tile[i, j - 2].type]) && (Main.tile[i, j + 2].active && Main.tileSolid[Main.tile[i, j + 2].type]))
                {
                    Main.tile[i, j - 1].active = true;
                    Main.tile[i, j - 1].type = 10;
                    Main.tile[i, j - 1].frameY = 0;
                    Main.tile[i, j - 1].frameX = (short) (genRand.Next(3) * 0x12);
                    Main.tile[i, j].active = true;
                    Main.tile[i, j].type = 10;
                    Main.tile[i, j].frameY = 0x12;
                    Main.tile[i, j].frameX = (short) (genRand.Next(3) * 0x12);
                    Main.tile[i, j + 1].active = true;
                    Main.tile[i, j + 1].type = 10;
                    Main.tile[i, j + 1].frameY = 0x24;
                    Main.tile[i, j + 1].frameX = (short) (genRand.Next(3) * 0x12);
                    return true;
                }
                return false;
            }
            catch
            {
                return false;
            }
        }

        public static void PlaceOnTable1x1(int x, int y, int type, int style = 0)
        {
            bool flag = false;
            if (Main.tile[x, y] == null)
            {
                Main.tile[x, y] = new Tile();
            }
            if (Main.tile[x, y + 1] == null)
            {
                Main.tile[x, y + 1] = new Tile();
            }
            if ((!Main.tile[x, y].active && Main.tile[x, y + 1].active) && Main.tileTable[Main.tile[x, y + 1].type])
            {
                flag = true;
            }
            if (((type == 0x4e) && !Main.tile[x, y].active) && (Main.tile[x, y + 1].active && Main.tileSolid[Main.tile[x, y + 1].type]))
            {
                flag = true;
            }
            if (flag)
            {
                Main.tile[x, y].active = true;
                Main.tile[x, y].frameX = (short) (style * 0x12);
                Main.tile[x, y].frameY = 0;
                Main.tile[x, y].type = (byte) type;
                if (type == 50)
                {
                    Main.tile[x, y].frameX = (short) (0x12 * genRand.Next(5));
                }
            }
        }

        public static bool PlacePot(int x, int y, int type = 0x1c)
        {
            bool flag = true;
            for (int i = x; i < (x + 2); i++)
            {
                for (int k = y - 1; k < (y + 1); k++)
                {
                    if (Main.tile[i, k] == null)
                    {
                        Main.tile[i, k] = new Tile();
                    }
                    if (Main.tile[i, k].active)
                    {
                        flag = false;
                    }
                }
                if (Main.tile[i, y + 1] == null)
                {
                    Main.tile[i, y + 1] = new Tile();
                }
                if (!Main.tile[i, y + 1].active || !Main.tileSolid[Main.tile[i, y + 1].type])
                {
                    flag = false;
                }
            }
            if (!flag)
            {
                return false;
            }
            for (int j = 0; j < 2; j++)
            {
                for (int m = -1; m < 1; m++)
                {
                    int num5 = (j * 0x12) + (genRand.Next(3) * 0x24);
                    int num6 = (m + 1) * 0x12;
                    Main.tile[x + j, y + m].active = true;
                    Main.tile[x + j, y + m].frameX = (short) num5;
                    Main.tile[x + j, y + m].frameY = (short) num6;
                    Main.tile[x + j, y + m].type = (byte) type;
                }
            }
            return true;
        }

        public static bool PlaceSign(int x, int y, int type)
        {
            int num = x - 2;
            int num2 = x + 3;
            int num3 = y - 2;
            int num4 = y + 3;
            if (num < 0)
            {
                return false;
            }
            if (num2 > Main.maxTilesX)
            {
                return false;
            }
            if (num3 < 0)
            {
                return false;
            }
            if (num4 > Main.maxTilesY)
            {
                return false;
            }
            for (int i = num; i < num2; i++)
            {
                for (int k = num3; k < num4; k++)
                {
                    if (Main.tile[i, k] == null)
                    {
                        Main.tile[i, k] = new Tile();
                    }
                }
            }
            int num7 = x;
            int num8 = y;
            int num9 = 0;
            if (type == 0x37)
            {
                if ((!Main.tile[x, y + 1].active || !Main.tileSolid[Main.tile[x, y + 1].type]) || (!Main.tile[x + 1, y + 1].active || !Main.tileSolid[Main.tile[x + 1, y + 1].type]))
                {
                    if (((!Main.tile[x, y - 1].active || !Main.tileSolid[Main.tile[x, y - 1].type]) || (Main.tileSolidTop[Main.tile[x, y - 1].type] || !Main.tile[x + 1, y - 1].active)) || (!Main.tileSolid[Main.tile[x + 1, y - 1].type] || Main.tileSolidTop[Main.tile[x + 1, y - 1].type]))
                    {
                        if (((!Main.tile[x - 1, y].active || !Main.tileSolid[Main.tile[x - 1, y].type]) || (Main.tileSolidTop[Main.tile[x - 1, y].type] || !Main.tile[x - 1, y + 1].active)) || (!Main.tileSolid[Main.tile[x - 1, y + 1].type] || Main.tileSolidTop[Main.tile[x - 1, y + 1].type]))
                        {
                            if (((!Main.tile[x + 1, y].active || !Main.tileSolid[Main.tile[x + 1, y].type]) || (Main.tileSolidTop[Main.tile[x + 1, y].type] || !Main.tile[x + 1, y + 1].active)) || (!Main.tileSolid[Main.tile[x + 1, y + 1].type] || Main.tileSolidTop[Main.tile[x + 1, y + 1].type]))
                            {
                                return false;
                            }
                            num7--;
                            num9 = 3;
                        }
                        else
                        {
                            num9 = 2;
                        }
                    }
                    else
                    {
                        num9 = 1;
                    }
                }
                else
                {
                    num8--;
                    num9 = 0;
                }
            }
            else if (type == 0x55)
            {
                if ((!Main.tile[x, y + 1].active || !Main.tileSolid[Main.tile[x, y + 1].type]) || (!Main.tile[x + 1, y + 1].active || !Main.tileSolid[Main.tile[x + 1, y + 1].type]))
                {
                    return false;
                }
                num8--;
                num9 = 0;
            }
            if ((Main.tile[num7, num8].active || Main.tile[num7 + 1, num8].active) || (Main.tile[num7, num8 + 1].active || Main.tile[num7 + 1, num8 + 1].active))
            {
                return false;
            }
            int num10 = 0x24 * num9;
            for (int j = 0; j < 2; j++)
            {
                for (int m = 0; m < 2; m++)
                {
                    Main.tile[num7 + j, num8 + m].active = true;
                    Main.tile[num7 + j, num8 + m].type = (byte) type;
                    Main.tile[num7 + j, num8 + m].frameX = (short) (num10 + (0x12 * j));
                    Main.tile[num7 + j, num8 + m].frameY = (short) (0x12 * m);
                }
            }
            return true;
        }

        public static void PlaceSunflower(int x, int y, int type = 0x1b)
        {
            if (y <= (Main.worldSurface - 1.0))
            {
                bool flag = true;
                for (int i = x; i < (x + 2); i++)
                {
                    for (int j = y - 3; j < (y + 1); j++)
                    {
                        if (Main.tile[i, j] == null)
                        {
                            Main.tile[i, j] = new Tile();
                        }
                        if (Main.tile[i, j].active || (Main.tile[i, j].wall > 0))
                        {
                            flag = false;
                        }
                    }
                    if (Main.tile[i, y + 1] == null)
                    {
                        Main.tile[i, y + 1] = new Tile();
                    }
                    if (!Main.tile[i, y + 1].active || (Main.tile[i, y + 1].type != 2))
                    {
                        flag = false;
                    }
                }
                if (flag)
                {
                    for (int k = 0; k < 2; k++)
                    {
                        for (int m = -3; m < 1; m++)
                        {
                            int num5 = (k * 0x12) + (genRand.Next(3) * 0x24);
                            int num6 = (m + 3) * 0x12;
                            Main.tile[x + k, y + m].active = true;
                            Main.tile[x + k, y + m].frameX = (short) num5;
                            Main.tile[x + k, y + m].frameY = (short) num6;
                            Main.tile[x + k, y + m].type = (byte) type;
                        }
                    }
                }
            }
        }

        public static bool PlaceTile(int i, int j, int type, bool mute = false, bool forced = false, int plr = -1, int style = 0)
        {
            if (type >= 0x6b)
            {
                return false;
            }
            bool flag = false;
            if (((i >= 0) && (j >= 0)) && ((i < Main.maxTilesX) && (j < Main.maxTilesY)))
            {
                if (Main.tile[i, j] == null)
                {
                    Main.tile[i, j] = new Tile();
                }
                if (((((!forced && !Collision.EmptyTile(i, j, false)) && Main.tileSolid[type]) && (((type != 0x17) || (Main.tile[i, j].type != 0)) || !Main.tile[i, j].active)) && (((type != 2) || (Main.tile[i, j].type != 0)) || !Main.tile[i, j].active)) && ((((type != 60) || (Main.tile[i, j].type != 0x3b)) || !Main.tile[i, j].active) && (((type != 70) || (Main.tile[i, j].type != 0x3b)) || !Main.tile[i, j].active)))
                {
                    return flag;
                }
                if ((type == 0x17) && ((Main.tile[i, j].type != 0) || !Main.tile[i, j].active))
                {
                    return false;
                }
                if ((type == 2) && ((Main.tile[i, j].type != 0) || !Main.tile[i, j].active))
                {
                    return false;
                }
                if ((type == 60) && ((Main.tile[i, j].type != 0x3b) || !Main.tile[i, j].active))
                {
                    return false;
                }
                if (type == 0x51)
                {
                    if (Main.tile[i - 1, j] == null)
                    {
                        Main.tile[i - 1, j] = new Tile();
                    }
                    if (Main.tile[i + 1, j] == null)
                    {
                        Main.tile[i + 1, j] = new Tile();
                    }
                    if (Main.tile[i, j - 1] == null)
                    {
                        Main.tile[i, j - 1] = new Tile();
                    }
                    if (Main.tile[i, j + 1] == null)
                    {
                        Main.tile[i, j + 1] = new Tile();
                    }
                    if ((Main.tile[i - 1, j].active || Main.tile[i + 1, j].active) || Main.tile[i, j - 1].active)
                    {
                        return false;
                    }
                    if (!Main.tile[i, j + 1].active || !Main.tileSolid[Main.tile[i, j + 1].type])
                    {
                        return false;
                    }
                }
                if ((Main.tile[i, j].liquid > 0) && ((((type == 3) || (type == 4)) || ((type == 20) || (type == 0x18))) || (((type == 0x1b) || (type == 0x20)) || (((type == 0x33) || (type == 0x45)) || (type == 0x48)))))
                {
                    return false;
                }
                Main.tile[i, j].frameY = 0;
                Main.tile[i, j].frameX = 0;
                if ((type == 3) || (type == 0x18))
                {
                    if ((((j + 1) < Main.maxTilesY) && Main.tile[i, j + 1].active) && ((((Main.tile[i, j + 1].type == 2) && (type == 3)) || ((Main.tile[i, j + 1].type == 0x17) && (type == 0x18))) || ((Main.tile[i, j + 1].type == 0x4e) && (type == 3))))
                    {
                        if ((type == 0x18) && (genRand.Next(13) == 0))
                        {
                            Main.tile[i, j].active = true;
                            Main.tile[i, j].type = 0x20;
                            SquareTileFrame(i, j, true);
                        }
                        else if (Main.tile[i, j + 1].type == 0x4e)
                        {
                            Main.tile[i, j].active = true;
                            Main.tile[i, j].type = (byte) type;
                            Main.tile[i, j].frameX = (short) ((genRand.Next(2) * 0x12) + 0x6c);
                        }
                        else if ((Main.tile[i, j].wall == 0) && (Main.tile[i, j + 1].wall == 0))
                        {
                            if ((genRand.Next(50) == 0) || ((type == 0x18) && (genRand.Next(40) == 0)))
                            {
                                Main.tile[i, j].active = true;
                                Main.tile[i, j].type = (byte) type;
                                Main.tile[i, j].frameX = 0x90;
                            }
                            else if (genRand.Next(0x23) == 0)
                            {
                                Main.tile[i, j].active = true;
                                Main.tile[i, j].type = (byte) type;
                                Main.tile[i, j].frameX = (short) ((genRand.Next(2) * 0x12) + 0x6c);
                            }
                            else
                            {
                                Main.tile[i, j].active = true;
                                Main.tile[i, j].type = (byte) type;
                                Main.tile[i, j].frameX = (short) (genRand.Next(6) * 0x12);
                            }
                        }
                    }
                }
                else if (type == 0x3d)
                {
                    if ((((j + 1) < Main.maxTilesY) && Main.tile[i, j + 1].active) && (Main.tile[i, j + 1].type == 60))
                    {
                        if ((genRand.Next(0x10) == 0) && (j > Main.worldSurface))
                        {
                            Main.tile[i, j].active = true;
                            Main.tile[i, j].type = 0x45;
                            SquareTileFrame(i, j, true);
                        }
                        else if ((genRand.Next(60) == 0) && (j > Main.rockLayer))
                        {
                            Main.tile[i, j].active = true;
                            Main.tile[i, j].type = (byte) type;
                            Main.tile[i, j].frameX = 0x90;
                        }
                        else if ((genRand.Next(0x3e8) == 0) && (j > Main.rockLayer))
                        {
                            Main.tile[i, j].active = true;
                            Main.tile[i, j].type = (byte) type;
                            Main.tile[i, j].frameX = 0xa2;
                        }
                        else if (genRand.Next(15) == 0)
                        {
                            Main.tile[i, j].active = true;
                            Main.tile[i, j].type = (byte) type;
                            Main.tile[i, j].frameX = (short) ((genRand.Next(2) * 0x12) + 0x6c);
                        }
                        else
                        {
                            Main.tile[i, j].active = true;
                            Main.tile[i, j].type = (byte) type;
                            Main.tile[i, j].frameX = (short) (genRand.Next(6) * 0x12);
                        }
                    }
                }
                else if (type == 0x47)
                {
                    if ((((j + 1) < Main.maxTilesY) && Main.tile[i, j + 1].active) && (Main.tile[i, j + 1].type == 70))
                    {
                        Main.tile[i, j].active = true;
                        Main.tile[i, j].type = (byte) type;
                        Main.tile[i, j].frameX = (short) (genRand.Next(5) * 0x12);
                    }
                }
                else if (type == 4)
                {
                    if (Main.tile[i - 1, j] == null)
                    {
                        Main.tile[i - 1, j] = new Tile();
                    }
                    if (Main.tile[i + 1, j] == null)
                    {
                        Main.tile[i + 1, j] = new Tile();
                    }
                    if (Main.tile[i, j + 1] == null)
                    {
                        Main.tile[i, j + 1] = new Tile();
                    }
                    if (((Main.tile[i - 1, j].active && (Main.tileSolid[Main.tile[i - 1, j].type] || (((Main.tile[i - 1, j].type == 5) && (Main.tile[i - 1, j - 1].type == 5)) && (Main.tile[i - 1, j + 1].type == 5)))) || (Main.tile[i + 1, j].active && (Main.tileSolid[Main.tile[i + 1, j].type] || (((Main.tile[i + 1, j].type == 5) && (Main.tile[i + 1, j - 1].type == 5)) && (Main.tile[i + 1, j + 1].type == 5))))) || (Main.tile[i, j + 1].active && Main.tileSolid[Main.tile[i, j + 1].type]))
                    {
                        Main.tile[i, j].active = true;
                        Main.tile[i, j].type = (byte) type;
                        SquareTileFrame(i, j, true);
                    }
                }
                else if (type == 10)
                {
                    if (Main.tile[i, j - 1] == null)
                    {
                        Main.tile[i, j - 1] = new Tile();
                    }
                    if (Main.tile[i, j - 2] == null)
                    {
                        Main.tile[i, j - 2] = new Tile();
                    }
                    if (Main.tile[i, j - 3] == null)
                    {
                        Main.tile[i, j - 3] = new Tile();
                    }
                    if (Main.tile[i, j + 1] == null)
                    {
                        Main.tile[i, j + 1] = new Tile();
                    }
                    if (Main.tile[i, j + 2] == null)
                    {
                        Main.tile[i, j + 2] = new Tile();
                    }
                    if (Main.tile[i, j + 3] == null)
                    {
                        Main.tile[i, j + 3] = new Tile();
                    }
                    if ((Main.tile[i, j - 1].active || Main.tile[i, j - 2].active) || (!Main.tile[i, j - 3].active || !Main.tileSolid[Main.tile[i, j - 3].type]))
                    {
                        if ((Main.tile[i, j + 1].active || Main.tile[i, j + 2].active) || (!Main.tile[i, j + 3].active || !Main.tileSolid[Main.tile[i, j + 3].type]))
                        {
                            return false;
                        }
                        PlaceDoor(i, j + 1, type);
                        SquareTileFrame(i, j, true);
                    }
                    else
                    {
                        PlaceDoor(i, j - 1, type);
                        SquareTileFrame(i, j, true);
                    }
                }
                else if (((type == 0x22) || (type == 0x23)) || ((type == 0x24) || (type == 0x6a)))
                {
                    Place3x3(i, j, type);
                    SquareTileFrame(i, j, true);
                }
                else if (((type == 13) || (type == 0x21)) || (((type == 0x31) || (type == 50)) || (type == 0x4e)))
                {
                    PlaceOnTable1x1(i, j, type, style);
                    SquareTileFrame(i, j, true);
                }
                else if ((((type == 14) || (type == 0x1a)) || ((type == 0x56) || (type == 0x57))) || ((type == 0x58) || (type == 0x59)))
                {
                    Place3x2(i, j, type);
                    SquareTileFrame(i, j, true);
                }
                else if (type == 20)
                {
                    if (Main.tile[i, j + 1] == null)
                    {
                        Main.tile[i, j + 1] = new Tile();
                    }
                    if (Main.tile[i, j + 1].active && (Main.tile[i, j + 1].type == 2))
                    {
                        Place1x2(i, j, type, style);
                        SquareTileFrame(i, j, true);
                    }
                }
                else if (type == 15)
                {
                    if (Main.tile[i, j - 1] == null)
                    {
                        Main.tile[i, j - 1] = new Tile();
                    }
                    if (Main.tile[i, j] == null)
                    {
                        Main.tile[i, j] = new Tile();
                    }
                    Place1x2(i, j, type, style);
                    SquareTileFrame(i, j, true);
                }
                else if (((type == 0x10) || (type == 0x12)) || ((type == 0x1d) || (type == 0x67)))
                {
                    Place2x1(i, j, type);
                    SquareTileFrame(i, j, true);
                }
                else if ((type == 0x5c) || (type == 0x5d))
                {
                    Place1xX(i, j, type, 0);
                    SquareTileFrame(i, j, true);
                }
                else if ((type == 0x68) || (type == 0x69))
                {
                    Place2xX(i, j, type, 0);
                    SquareTileFrame(i, j, true);
                }
                else if ((type == 0x11) || (type == 0x4d))
                {
                    Place3x2(i, j, type);
                    SquareTileFrame(i, j, true);
                }
                else if (type == 0x15)
                {
                    PlaceChest(i, j, type, false, style);
                    SquareTileFrame(i, j, true);
                }
                else if (type == 0x5b)
                {
                    PlaceBanner(i, j, type, style);
                    SquareTileFrame(i, j, true);
                }
                else if ((type == 0x65) || (type == 0x66))
                {
                    Place3x4(i, j, type);
                    SquareTileFrame(i, j, true);
                }
                else if (type == 0x1b)
                {
                    PlaceSunflower(i, j, 0x1b);
                    SquareTileFrame(i, j, true);
                }
                else if (type == 0x1c)
                {
                    PlacePot(i, j, 0x1c);
                    SquareTileFrame(i, j, true);
                }
                else if (type == 0x2a)
                {
                    Place1x2Top(i, j, type);
                    SquareTileFrame(i, j, true);
                }
                else if ((type == 0x37) || (type == 0x55))
                {
                    PlaceSign(i, j, type);
                }
                else if (Main.tileAlch[type])
                {
                    PlaceAlch(i, j, style);
                }
                else if ((((type == 0x5e) || (type == 0x5f)) || ((type == 0x60) || (type == 0x61))) || (((type == 0x62) || (type == 0x63)) || (type == 100)))
                {
                    Place2x2(i, j, type);
                }
                else if ((type == 0x4f) || (type == 90))
                {
                    int direction = 1;
                    if (plr > -1)
                    {
                        direction = Main.player[plr].direction;
                    }
                    Place4x2(i, j, type, direction);
                }
                else if (type == 0x51)
                {
                    Main.tile[i, j].frameX = (short) (0x1a * genRand.Next(6));
                    Main.tile[i, j].active = true;
                    Main.tile[i, j].type = (byte) type;
                }
                else
                {
                    Main.tile[i, j].active = true;
                    Main.tile[i, j].type = (byte) type;
                }
                if (Main.tile[i, j].active && !mute)
                {
                    SquareTileFrame(i, j, true);
                    flag = true;
                    Main.PlaySound(0, i * 0x10, j * 0x10, 1);
                    if (type != 0x16)
                    {
                        return flag;
                    }
                    for (int k = 0; k < 3; k++)
                    {
                        Color newColor = new Color();
                        Dust.NewDust(new Vector2((float) (i * 0x10), (float) (j * 0x10)), 0x10, 0x10, 14, 0f, 0f, 0, newColor, 1f);
                    }
                }
            }
            return flag;
        }

        public static void PlaceWall(int i, int j, int type, bool mute = false)
        {
            if (((i > 1) && (j > 1)) && ((i < (Main.maxTilesX - 2)) && (j < (Main.maxTilesY - 2))))
            {
                if (Main.tile[i, j] == null)
                {
                    Main.tile[i, j] = new Tile();
                }
                if (Main.tile[i, j].wall != type)
                {
                    for (int k = i - 1; k < (i + 2); k++)
                    {
                        for (int m = j - 1; m < (j + 2); m++)
                        {
                            if (Main.tile[k, m] == null)
                            {
                                Main.tile[k, m] = new Tile();
                            }
                            if ((Main.tile[k, m].wall > 0) && (Main.tile[k, m].wall != type))
                            {
                                bool flag = false;
                                if (((Main.tile[i, j].wall == 0) && ((type == 2) || (type == 0x10))) && ((Main.tile[k, m].wall == 2) || (Main.tile[k, m].wall == 0x10)))
                                {
                                    flag = true;
                                }
                                if (!flag)
                                {
                                    return;
                                }
                            }
                        }
                    }
                    Main.tile[i, j].wall = (byte) type;
                    SquareWallFrame(i, j, true);
                    if (!mute)
                    {
                        Main.PlaySound(0, i * 0x10, j * 0x10, 1);
                    }
                }
            }
        }

        public static void PlantAlch()
        {
            int x = genRand.Next(20, Main.maxTilesX - 20);
            int num2 = 0;
            if (genRand.Next(40) == 0)
            {
                num2 = genRand.Next((((int) Main.rockLayer) + Main.maxTilesY) / 2, Main.maxTilesY - 20);
            }
            else if (genRand.Next(10) == 0)
            {
                num2 = genRand.Next(0, Main.maxTilesY - 20);
            }
            else
            {
                num2 = genRand.Next((int) Main.worldSurface, Main.maxTilesY - 20);
            }
            while ((num2 < (Main.maxTilesY - 20)) && !Main.tile[x, num2].active)
            {
                num2++;
            }
            if ((Main.tile[x, num2].active && !Main.tile[x, num2 - 1].active) && (Main.tile[x, num2 - 1].liquid == 0))
            {
                if (Main.tile[x, num2].type == 2)
                {
                    PlaceAlch(x, num2 - 1, 0);
                }
                if (Main.tile[x, num2].type == 60)
                {
                    PlaceAlch(x, num2 - 1, 1);
                }
                if ((Main.tile[x, num2].type == 0) || (Main.tile[x, num2].type == 0x3b))
                {
                    PlaceAlch(x, num2 - 1, 2);
                }
                if ((Main.tile[x, num2].type == 0x17) || (Main.tile[x, num2].type == 0x19))
                {
                    PlaceAlch(x, num2 - 1, 3);
                }
                if (Main.tile[x, num2].type == 0x35)
                {
                    PlaceAlch(x, num2 - 1, 4);
                }
                if (Main.tile[x, num2].type == 0x39)
                {
                    PlaceAlch(x, num2 - 1, 5);
                }
                if (Main.tile[x, num2 - 1].active && (Main.netMode == 2))
                {
                    NetMessage.SendTileSquare(-1, x, num2 - 1, 1);
                }
            }
        }

        public static void PlantCactus(int i, int j)
        {
            GrowCactus(i, j);
            for (int k = 0; k < 150; k++)
            {
                int num2 = genRand.Next(i - 1, i + 2);
                int num3 = genRand.Next(j - 10, j + 2);
                GrowCactus(num2, num3);
            }
        }

        public static void PlantCheck(int i, int j)
        {
            int num = -1;
            int type = Main.tile[i, j].type;
            int num1 = i - 1;
            int maxTilesX = Main.maxTilesX;
            int num4 = i + 1;
            int num5 = j - 1;
            if ((j + 1) >= Main.maxTilesY)
            {
                num = type;
            }
            if ((((i - 1) >= 0) && (Main.tile[i - 1, j] != null)) && Main.tile[i - 1, j].active)
            {
                byte num6 = Main.tile[i - 1, j].type;
            }
            if ((((i + 1) < Main.maxTilesX) && (Main.tile[i + 1, j] != null)) && Main.tile[i + 1, j].active)
            {
                byte num7 = Main.tile[i + 1, j].type;
            }
            if ((((j - 1) >= 0) && (Main.tile[i, j - 1] != null)) && Main.tile[i, j - 1].active)
            {
                byte num8 = Main.tile[i, j - 1].type;
            }
            if ((((j + 1) < Main.maxTilesY) && (Main.tile[i, j + 1] != null)) && Main.tile[i, j + 1].active)
            {
                num = Main.tile[i, j + 1].type;
            }
            if ((((i - 1) >= 0) && ((j - 1) >= 0)) && ((Main.tile[i - 1, j - 1] != null) && Main.tile[i - 1, j - 1].active))
            {
                byte num9 = Main.tile[i - 1, j - 1].type;
            }
            if ((((i + 1) < Main.maxTilesX) && ((j - 1) >= 0)) && ((Main.tile[i + 1, j - 1] != null) && Main.tile[i + 1, j - 1].active))
            {
                byte num10 = Main.tile[i + 1, j - 1].type;
            }
            if ((((i - 1) >= 0) && ((j + 1) < Main.maxTilesY)) && ((Main.tile[i - 1, j + 1] != null) && Main.tile[i - 1, j + 1].active))
            {
                byte num11 = Main.tile[i - 1, j + 1].type;
            }
            if ((((i + 1) < Main.maxTilesX) && ((j + 1) < Main.maxTilesY)) && ((Main.tile[i + 1, j + 1] != null) && Main.tile[i + 1, j + 1].active))
            {
                byte num12 = Main.tile[i + 1, j + 1].type;
            }
            if ((((((type == 3) && (num != 2)) && (num != 0x4e)) || ((type == 0x18) && (num != 0x17))) || (((type == 0x3d) && (num != 60)) || ((type == 0x47) && (num != 70)))) || ((((type == 0x49) && (num != 2)) && (num != 0x4e)) || ((type == 0x4a) && (num != 60))))
            {
                KillTile(i, j, false, false, false);
            }
        }

        public static bool PlayerLOS(int x, int y)
        {
            Rectangle rectangle = new Rectangle(x * 0x10, y * 0x10, 0x10, 0x10);
            for (int i = 0; i < 0xff; i++)
            {
                if (Main.player[i].active)
                {
                    Rectangle rectangle2 = new Rectangle((int) ((Main.player[i].position.X + (Main.player[i].width * 0.5)) - (NPC.sWidth * 0.6)), (int) ((Main.player[i].position.Y + (Main.player[i].height * 0.5)) - (NPC.sHeight * 0.6)), (int) (NPC.sWidth * 1.2), (int) (NPC.sHeight * 1.2));
                    if (rectangle.Intersects(rectangle2))
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public static void playWorld()
        {
            ThreadPool.QueueUserWorkItem(new WaitCallback(WorldGen.playWorldCallBack), 1);
        }

        public static void playWorldCallBack(object threadContext)
        {
            if (Main.rand == null)
            {
                Main.rand = new Random((int) DateTime.Now.Ticks);
            }
            for (int i = 0; i < 0xff; i++)
            {
                if (i != Main.myPlayer)
                {
                    Main.player[i].active = false;
                }
            }
            loadWorld();
            if (loadFailed || !loadSuccess)
            {
                loadWorld();
                if (loadFailed || !loadSuccess)
                {
                    if (File.Exists(Main.worldPathName + ".bak"))
                    {
                        worldBackup = true;
                    }
                    else
                    {
                        worldBackup = false;
                    }
                    if (!Main.dedServ)
                    {
                        if (worldBackup)
                        {
                            Main.menuMode = 200;
                            return;
                        }
                        Main.menuMode = 0xc9;
                        return;
                    }
                    if (worldBackup)
                    {
                        File.Copy(Main.worldPathName + ".bak", Main.worldPathName, true);
                        File.Delete(Main.worldPathName + ".bak");
                        loadWorld();
                        if (loadFailed || !loadSuccess)
                        {
                            loadWorld();
                            if (loadFailed || !loadSuccess)
                            {
                                Console.WriteLine("Load failed!");
                                return;
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("Load failed!  No backup found.");
                        return;
                    }
                }
            }
            EveryTileFrame();
            if (Main.gameMenu)
            {
                Main.gameMenu = false;
            }
            Main.player[Main.myPlayer].Spawn();
            Main.player[Main.myPlayer].UpdatePlayer(Main.myPlayer);
            Main.dayTime = tempDayTime;
            Main.time = tempTime;
            Main.moonPhase = tempMoonPhase;
            Main.bloodMoon = tempBloodMoon;
            Main.PlaySound(11, -1, -1, 1);
            Main.resetClouds = true;
        }

        public static void QuickFindHome(int npc)
        {
            if (((Main.npc[npc].homeTileX > 10) && (Main.npc[npc].homeTileY > 10)) && ((Main.npc[npc].homeTileX < (Main.maxTilesX - 10)) && (Main.npc[npc].homeTileY < Main.maxTilesY)))
            {
                canSpawn = false;
                StartRoomCheck(Main.npc[npc].homeTileX, Main.npc[npc].homeTileY - 1);
                if (!canSpawn)
                {
                    for (int i = Main.npc[npc].homeTileX - 1; i < (Main.npc[npc].homeTileX + 2); i++)
                    {
                        for (int j = Main.npc[npc].homeTileY - 1; j < (Main.npc[npc].homeTileY + 2); j++)
                        {
                            if (StartRoomCheck(i, j))
                            {
                                break;
                            }
                        }
                    }
                }
                if (!canSpawn)
                {
                    int num3 = 10;
                    for (int k = Main.npc[npc].homeTileX - num3; k <= (Main.npc[npc].homeTileX + num3); k += 2)
                    {
                        for (int m = Main.npc[npc].homeTileY - num3; m <= (Main.npc[npc].homeTileY + num3); m += 2)
                        {
                            if (StartRoomCheck(k, m))
                            {
                                break;
                            }
                        }
                    }
                }
                if (canSpawn)
                {
                    RoomNeeds(Main.npc[npc].type);
                    if (canSpawn)
                    {
                        ScoreRoom(npc);
                    }
                    if (canSpawn && (hiScore > 0))
                    {
                        Main.npc[npc].homeTileX = bestX;
                        Main.npc[npc].homeTileY = bestY;
                        Main.npc[npc].homeless = false;
                        canSpawn = false;
                    }
                    else
                    {
                        Main.npc[npc].homeless = true;
                    }
                }
                else
                {
                    Main.npc[npc].homeless = true;
                }
            }
        }

        public static void RangeFrame(int startX, int startY, int endX, int endY)
        {
            int num = startX;
            int num2 = endX + 1;
            int num3 = startY;
            int num4 = endY + 1;
            for (int i = num - 1; i < (num2 + 1); i++)
            {
                for (int j = num3 - 1; j < (num4 + 1); j++)
                {
                    TileFrame(i, j, false, false);
                    WallFrame(i, j, false);
                }
            }
        }

        public static void RealsaveWorld(bool resetTime = false)
        {
            if (Main.worldName == "")
            {
                Main.worldName = "World";
            }
            if (!saveLock)
            {
                saveLock = true;
                lock (padlock)
                {
                    try
                    {
                        Directory.CreateDirectory(Main.WorldPath);
                    }
                    catch
                    {
                    }
                    if (!Main.skipMenu)
                    {
                        bool dayTime = Main.dayTime;
                        tempTime = Main.time;
                        tempMoonPhase = Main.moonPhase;
                        tempBloodMoon = Main.bloodMoon;
                        if (resetTime)
                        {
                            dayTime = true;
                            tempTime = 13500.0;
                            tempMoonPhase = 0;
                            tempBloodMoon = false;
                        }
                        if (Main.worldPathName != null)
                        {
                            new Stopwatch().Start();
                            string path = Main.worldPathName + ".sav";
                            string[] wldList = Directory.GetFiles(Main.WorldPath, "*.wld");
                            string[] bakList = Directory.GetFiles(Main.WorldPath, "*.bak");
                            using (FileStream stream = new FileStream(path, FileMode.Create))
                            {
                                    using (BinaryWriter writer = new BinaryWriter(stream))
                                    {
                                        writer.Write(Main.curRelease);
                                        writer.Write(Main.worldName);
                                        writer.Write(Main.worldID);
                                        writer.Write((int)Main.leftWorld);
                                        writer.Write((int)Main.rightWorld);
                                        writer.Write((int)Main.topWorld);
                                        writer.Write((int)Main.bottomWorld);
                                        writer.Write(Main.maxTilesY);
                                        writer.Write(Main.maxTilesX);
                                        writer.Write(Main.spawnTileX);
                                        writer.Write(Main.spawnTileY);
                                        writer.Write(Main.worldSurface);
                                        writer.Write(Main.rockLayer);
                                        writer.Write(tempTime);
                                        writer.Write(dayTime);
                                        writer.Write(tempMoonPhase);
                                        writer.Write(tempBloodMoon);
                                        writer.Write(Main.dungeonX);
                                        writer.Write(Main.dungeonY);
                                        writer.Write(NPC.downedBoss1);
                                        writer.Write(NPC.downedBoss2);
                                        writer.Write(NPC.downedBoss3);
                                        writer.Write(shadowOrbSmashed);
                                        writer.Write(spawnMeteor);
                                        writer.Write((byte)shadowOrbCount);
                                        writer.Write(Main.invasionDelay);
                                        writer.Write(Main.invasionSize);
                                        writer.Write(Main.invasionType);
                                        writer.Write(Main.invasionX);
                                        Main.statusText = "Saving world data.";
                                        for (int i = 0; i < Main.maxTilesX; i++)
                                        {
                                            float num2 = ((float)i) / ((float)Main.maxTilesX);
                                            for (int n = 0; n < Main.maxTilesY; n++)
                                            {
                                                Tile tile = (Tile)Main.tile[i, n].Clone();
                                                writer.Write(tile.active);
                                                if (tile.active)
                                                {
                                                    writer.Write(tile.type);
                                                    if (Main.tileFrameImportant[tile.type])
                                                    {
                                                        writer.Write(tile.frameX);
                                                        writer.Write(tile.frameY);
                                                    }
                                                }
                                                writer.Write(tile.lighted);
                                                if (Main.tile[i, n].wall > 0)
                                                {
                                                    writer.Write(true);
                                                    writer.Write(tile.wall);
                                                }
                                                else
                                                {
                                                    writer.Write(false);
                                                }
                                                if (tile.liquid > 0)
                                                {
                                                    writer.Write(true);
                                                    writer.Write(tile.liquid);
                                                    writer.Write(tile.lava);
                                                }
                                                else
                                                {
                                                    writer.Write(false);
                                                }
                                            }
                                        }
                                        for (int j = 0; j < 0x3e8; j++)
                                        {
                                            if (Main.chest[j] == null)
                                            {
                                                writer.Write(false);
                                            }
                                            else
                                            {
                                                Chest chest = (Chest)Main.chest[j].Clone();
                                                writer.Write(true);
                                                writer.Write(chest.x);
                                                writer.Write(chest.y);
                                                for (int num5 = 0; num5 < Chest.maxItems; num5++)
                                                {
                                                    if (chest.item[num5].type == 0)
                                                    {
                                                        chest.item[num5].stack = 0;
                                                    }
                                                    writer.Write((byte)chest.item[num5].stack);
                                                    if (chest.item[num5].stack > 0)
                                                    {
                                                        writer.Write(chest.item[num5].name);
                                                    }
                                                }
                                            }
                                        }
                                        for (int k = 0; k < 0x3e8; k++)
                                        {
                                            if ((Main.sign[k] == null) || (Main.sign[k].text == null))
                                            {
                                                writer.Write(false);
                                            }
                                            else
                                            {
                                                Sign sign = (Sign)Main.sign[k].Clone();
                                                writer.Write(true);
                                                writer.Write(sign.text);
                                                writer.Write(sign.x);
                                                writer.Write(sign.y);
                                            }
                                        }
                                        for (int m = 0; m < 0x3e8; m++)
                                        {
                                            NPC npc = (NPC)Main.npc[m].Clone();
                                            if (npc.active && npc.townNPC)
                                            {
                                                writer.Write(true);
                                                writer.Write(npc.name);
                                                writer.Write(npc.position.X);
                                                writer.Write(npc.position.Y);
                                                writer.Write(npc.homeless);
                                                writer.Write(npc.homeTileX);
                                                writer.Write(npc.homeTileY);
                                            }
                                        }
                                        writer.Write(false);
                                        writer.Write(true);
                                        writer.Write(Main.worldName);
                                        writer.Write(Main.worldID);
                                        writer.Close();
                                        stream.Close();
                                        DirectoryInfo di = new DirectoryInfo(Main.WorldPath);
                                        if (File.Exists(Main.worldPathName))
                                        {
                                            Main.statusText = "Backing up world file...";
                                            string destFileName = Main.worldPathName + ".bak";
                                            File.Copy(Main.worldPathName, destFileName, true);
                                            foreach (FileInfo fi in di.GetFiles(destFileName + ".bak"))
                                            {
                                                WorldGen.Compress(fi);
                                            }
                                        }
                                        File.Copy(path, Main.worldPathName, true);
                                        File.Delete(path);
                                        foreach (FileInfo fi in di.GetFiles("*.wld"))
                                        {
                                            WorldGen.Compress(fi);

                                        }
                                    }
                            }
                            saveLock = false;
                            foreach (string f in wldList)
                                File.Delete(f);
                            foreach (string g in bakList)
                                File.Delete(g);
                        }
                    }
                }
            }
        }
        public static void Compress(FileInfo fi)
        {
            // Get the stream of the source file.
            using (FileStream inFile = fi.OpenRead())
            {
                // Prevent compressing hidden and 
                // already compressed files.
                if ((File.GetAttributes(fi.FullName)
                    & FileAttributes.Hidden)
                    != FileAttributes.Hidden & fi.Extension != ".gz")
                {
                    // Create the compressed file.
                    using (FileStream outFile =
                                File.Create(fi.FullName + ".gz"))
                    {
                        using (GZipStream Compress =
                            new GZipStream(outFile,
                            CompressionMode.Compress))
                        {
                            // Copy the source file into 
                            // the compression stream.
                            inFile.CopyTo(Compress);

                            //Console.WriteLine("Compressed {0} from {1} to {2} bytes.", fi.Name, fi.Length.ToString(), outFile.Length.ToString());
                        }
                    }
                }
            }
        }

        public static void Decompress(FileInfo fi)
        {
            // Get the stream of the source file.
            using (FileStream inFile = fi.OpenRead())
            {
                // Get original file extension, for example
                // "doc" from report.doc.gz.
                string curFile = fi.FullName;
                string origName = curFile.Remove(curFile.Length -
                        fi.Extension.Length);

                //Create the decompressed file.
                using (FileStream outFile = File.Create(origName))
                {
                    using (GZipStream Decompress = new GZipStream(inFile,
                            CompressionMode.Decompress))
                    {
                        // Copy the decompression stream 
                        // into the output file.
                        Decompress.CopyTo(outFile);

                        //Console.WriteLine("Decompressed: {0}", fi.Name);

                    }
                }
            }
        }

        private static void resetGen()
        {
            mudWall = false;
            hellChest = 0;
            JungleX = 0;
            numMCaves = 0;
            numIslandHouses = 0;
            houseCount = 0;
            dEnteranceX = 0;
            numDRooms = 0;
            numDDoors = 0;
            numDPlats = 0;
            numJChests = 0;
        }

        public static bool RoomNeeds(int npcType)
        {
            if ((((houseTile[15] || houseTile[0x4f]) || (houseTile[0x59] || houseTile[0x66])) && (((houseTile[14] || houseTile[0x12]) || (houseTile[0x57] || houseTile[0x58])) || (houseTile[90] || houseTile[0x65]))) && ((((houseTile[4] || houseTile[0x21]) || (houseTile[0x22] || houseTile[0x23])) || (((houseTile[0x24] || houseTile[0x2a]) || (houseTile[0x31] || houseTile[0x5d])) || ((houseTile[0x5f] || houseTile[0x62]) || houseTile[100]))) && ((houseTile[10] || houseTile[11]) || houseTile[0x13])))
            {
                canSpawn = true;
            }
            else
            {
                canSpawn = false;
            }
            return canSpawn;
        }

        public static void saveAndPlay()
        {
            ThreadPool.QueueUserWorkItem(new WaitCallback(WorldGen.saveAndPlayCallBack), 1);
        }

        public static void saveAndPlayCallBack(object threadContext)
        {
            saveWorld(false);
        }

        public static void SaveAndQuit()
        {
            Main.PlaySound(11, -1, -1, 1);
            ThreadPool.QueueUserWorkItem(new WaitCallback(WorldGen.SaveAndQuitCallBack), 1);
        }

        public static void SaveAndQuitCallBack(object threadContext)
        {
            Main.menuMode = 10;
            Main.gameMenu = true;
            Player.SavePlayer(Main.player[Main.myPlayer], Main.playerPathName);            
            Netplay.disconnect = true;
            Main.netMode = 0;
            Main.menuMode = 0;
        }

        public static void saveToonWhilePlaying()
        {
            ThreadPool.QueueUserWorkItem(new WaitCallback(WorldGen.saveToonWhilePlayingCallBack), 1);
        }

        public static void saveToonWhilePlayingCallBack(object threadContext)
        {
            Player.SavePlayer(Main.player[Main.myPlayer], Main.playerPathName);
        }

        public static void saveWorld(bool resetTime = false)
        {
            if (!WorldHooks.OnSaveWorld(resetTime))
            {
                RealsaveWorld(resetTime);
            }
        }

        public static void ScoreRoom(int ignoreNPC = -1)
        {
            for (int i = 0; i < 0x3e8; i++)
            {
                if ((Main.npc[i].active && Main.npc[i].townNPC) && ((ignoreNPC != i) && !Main.npc[i].homeless))
                {
                    for (int k = 0; k < numRoomTiles; k++)
                    {
                        if ((Main.npc[i].homeTileX == roomX[k]) && (Main.npc[i].homeTileY == roomY[k]))
                        {
                            bool flag = false;
                            for (int m = 0; m < numRoomTiles; m++)
                            {
                                if ((Main.npc[i].homeTileX == roomX[m]) && ((Main.npc[i].homeTileY - 1) == roomY[m]))
                                {
                                    flag = true;
                                    break;
                                }
                            }
                            if (flag)
                            {
                                hiScore = -1;
                                return;
                            }
                        }
                    }
                }
            }
            hiScore = 0;
            int num4 = 0;
            int num5 = 0;
            int num6 = 0;
            int num7 = ((roomX1 - ((NPC.sWidth / 2) / 0x10)) - 1) - 0x15;
            int num8 = ((roomX2 + ((NPC.sWidth / 2) / 0x10)) + 1) + 0x15;
            int num9 = ((roomY1 - ((NPC.sHeight / 2) / 0x10)) - 1) - 0x15;
            int maxTilesX = ((roomY2 + ((NPC.sHeight / 2) / 0x10)) + 1) + 0x15;
            if (num7 < 0)
            {
                num7 = 0;
            }
            if (num8 >= Main.maxTilesX)
            {
                num8 = Main.maxTilesX - 1;
            }
            if (num9 < 0)
            {
                num9 = 0;
            }
            if (maxTilesX > Main.maxTilesX)
            {
                maxTilesX = Main.maxTilesX;
            }
            for (int j = num7 + 1; j < num8; j++)
            {
                for (int n = num9 + 2; n < (maxTilesX + 2); n++)
                {
                    if (Main.tile[j, n].active)
                    {
                        if (((Main.tile[j, n].type == 0x17) || (Main.tile[j, n].type == 0x18)) || ((Main.tile[j, n].type == 0x19) || (Main.tile[j, n].type == 0x20)))
                        {
                            Main.evilTiles++;
                        }
                        else if (Main.tile[j, n].type == 0x1b)
                        {
                            Main.evilTiles -= 5;
                        }
                    }
                }
            }
            if (num6 < 50)
            {
                num6 = 0;
            }
            num5 = -num6;
            if (num5 <= -250)
            {
                hiScore = num5;
            }
            else
            {
                num7 = roomX1;
                num8 = roomX2;
                num9 = roomY1;
                maxTilesX = roomY2;
                for (int num13 = num7 + 1; num13 < num8; num13++)
                {
                    for (int num14 = num9 + 2; num14 < (maxTilesX + 2); num14++)
                    {
                        if (!Main.tile[num13, num14].active)
                        {
                            continue;
                        }
                        num4 = num5;
                        if (((Main.tileSolid[Main.tile[num13, num14].type] && !Main.tileSolidTop[Main.tile[num13, num14].type]) && (!Collision.SolidTiles(num13 - 1, num13 + 1, num14 - 3, num14 - 1) && Main.tile[num13 - 1, num14].active)) && ((Main.tileSolid[Main.tile[num13 - 1, num14].type] && Main.tile[num13 + 1, num14].active) && Main.tileSolid[Main.tile[num13 + 1, num14].type]))
                        {
                            for (int num15 = num13 - 2; num15 < (num13 + 3); num15++)
                            {
                                for (int num16 = num14 - 4; num16 < num14; num16++)
                                {
                                    if (Main.tile[num15, num16].active)
                                    {
                                        if (num15 == num13)
                                        {
                                            num4 -= 15;
                                        }
                                        else if ((Main.tile[num15, num16].type == 10) || (Main.tile[num15, num16].type == 11))
                                        {
                                            num4 -= 20;
                                        }
                                        else if (Main.tileSolid[Main.tile[num15, num16].type])
                                        {
                                            num4 -= 5;
                                        }
                                        else
                                        {
                                            num4 += 5;
                                        }
                                    }
                                }
                            }
                            if (num4 > hiScore)
                            {
                                bool flag2 = false;
                                for (int num17 = 0; num17 < numRoomTiles; num17++)
                                {
                                    if ((roomX[num17] == num13) && (roomY[num17] == num14))
                                    {
                                        flag2 = true;
                                        break;
                                    }
                                }
                                if (flag2)
                                {
                                    hiScore = num4;
                                    bestX = num13;
                                    bestY = num14;
                                }
                            }
                        }
                    }
                }
            }
        }

        public static void SectionTileFrame(int startX, int startY, int endX, int endY)
        {
            int num = startX * 200;
            int num2 = (endX + 1) * 200;
            int num3 = startY * 150;
            int num4 = (endY + 1) * 150;
            if (num < 1)
            {
                num = 1;
            }
            if (num3 < 1)
            {
                num3 = 1;
            }
            if (num > (Main.maxTilesX - 2))
            {
                num = Main.maxTilesX - 2;
            }
            if (num3 > (Main.maxTilesY - 2))
            {
                num3 = Main.maxTilesY - 2;
            }
            for (int i = num - 1; i < (num2 + 1); i++)
            {
                for (int j = num3 - 1; j < (num4 + 1); j++)
                {
                    if (Main.tile[i, j] == null)
                    {
                        Main.tile[i, j] = new Tile();
                    }
                    TileFrame(i, j, true, true);
                    WallFrame(i, j, true);
                }
            }
        }

        public static void serverLoadWorld()
        {
            ThreadPool.QueueUserWorkItem(new WaitCallback(WorldGen.serverLoadWorldCallBack), 1);
        }

        public static void serverLoadWorldCallBack(object threadContext)
        {
            loadWorld();
            if (loadFailed || !loadSuccess)
            {
                loadWorld();
                if (loadFailed || !loadSuccess)
                {
                    if (File.Exists(Main.worldPathName + ".bak"))
                    {
                        worldBackup = true;
                    }
                    else
                    {
                        worldBackup = false;
                    }
                    if (!Main.dedServ)
                    {
                        if (worldBackup)
                        {
                            Main.menuMode = 200;
                            return;
                        }
                        Main.menuMode = 0xc9;
                        return;
                    }
                    if (worldBackup)
                    {
                        File.Copy(Main.worldPathName + ".bak", Main.worldPathName, true);
                        File.Delete(Main.worldPathName + ".bak");
                        loadWorld();
                        if (loadFailed || !loadSuccess)
                        {
                            loadWorld();
                            if (loadFailed || !loadSuccess)
                            {
                                Console.WriteLine("Load failed!");
                                return;
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("Load failed!  No backup found.");
                        return;
                    }
                }
            }
            Main.PlaySound(10, -1, -1, 1);
            Netplay.StartServer();
            Main.dayTime = tempDayTime;
            Main.time = tempTime;
            Main.moonPhase = tempMoonPhase;
            Main.bloodMoon = tempBloodMoon;
        }

        public static void setWorldSize()
        {
            Main.bottomWorld = Main.maxTilesY * 0x10;
            Main.rightWorld = Main.maxTilesX * 0x10;
            Main.maxSectionsX = Main.maxTilesX / 200;
            Main.maxSectionsY = Main.maxTilesY / 150;
        }

        public static void ShroomPatch(int i, int j)
        {
            Vector2 vector;
            Vector2 vector2;
            double num5 = genRand.Next(40, 70);
            double num6 = num5;
            float num7 = genRand.Next(10, 20);
            if (genRand.Next(5) == 0)
            {
                num5 *= 1.5;
                num6 *= 1.5;
                num7 *= 1.2f;
            }
            vector.X = i;
            vector.Y = j - (num7 * 0.3f);
            vector2.X = genRand.Next(-10, 11) * 0.1f;
            vector2.Y = genRand.Next(-20, -10) * 0.1f;
            while ((num5 > 0.0) && (num7 > 0f))
            {
                num5 -= genRand.Next(3);
                num7--;
                int num = (int) (vector.X - (num5 * 0.5));
                int maxTilesX = (int) (vector.X + (num5 * 0.5));
                int num2 = (int) (vector.Y - (num5 * 0.5));
                int maxTilesY = (int) (vector.Y + (num5 * 0.5));
                if (num < 0)
                {
                    num = 0;
                }
                if (maxTilesX > Main.maxTilesX)
                {
                    maxTilesX = Main.maxTilesX;
                }
                if (num2 < 0)
                {
                    num2 = 0;
                }
                if (maxTilesY > Main.maxTilesY)
                {
                    maxTilesY = Main.maxTilesY;
                }
                num6 = (num5 * genRand.Next(80, 120)) * 0.01;
                for (int k = num; k < maxTilesX; k++)
                {
                    for (int m = num2; m < maxTilesY; m++)
                    {
                        float num10 = Math.Abs((float) (k - vector.X));
                        float num11 = Math.Abs((float) ((m - vector.Y) * 2.3f));
                        if (Math.Sqrt((double) ((num10 * num10) + (num11 * num11))) < (num6 * 0.4))
                        {
                            if (m < (vector.Y + (num6 * 0.05)))
                            {
                                if (Main.tile[k, m].type != 0x3b)
                                {
                                    Main.tile[k, m].active = false;
                                }
                            }
                            else
                            {
                                Main.tile[k, m].type = 0x3b;
                            }
                            Main.tile[k, m].liquid = 0;
                            Main.tile[k, m].lava = false;
                        }
                    }
                }
                vector += vector2;
                vector2.X += genRand.Next(-10, 11) * 0.05f;
                vector2.Y += genRand.Next(-10, 11) * 0.05f;
                if (vector2.X > 1f)
                {
                    vector2.X = 0.1f;
                }
                if (vector2.X < -1f)
                {
                    vector2.X = -1f;
                }
                if (vector2.Y > 1f)
                {
                    vector2.Y = 1f;
                }
                if (vector2.Y < -1f)
                {
                    vector2.Y = -1f;
                }
            }
        }

        public static void SpawnNPC(int x, int y)
        {
            if (Main.wallHouse[Main.tile[x, y].wall])
            {
                canSpawn = true;
            }
            if ((canSpawn && StartRoomCheck(x, y)) && RoomNeeds(spawnNPC))
            {
                ScoreRoom(-1);
                if (hiScore > 0)
                {
                    int index = -1;
                    for (int i = 0; i < 0x3e8; i++)
                    {
                        if ((Main.npc[i].active && Main.npc[i].homeless) && (Main.npc[i].type == spawnNPC))
                        {
                            index = i;
                            break;
                        }
                    }
                    if (index != -1)
                    {
                        spawnNPC = 0;
                        Main.npc[index].homeTileX = WorldGen.bestX;
                        Main.npc[index].homeTileY = WorldGen.bestY;
                        Main.npc[index].homeless = false;
                    }
                    else
                    {
                        int bestX = WorldGen.bestX;
                        int bestY = WorldGen.bestY;
                        bool flag = false;
                        if (!flag)
                        {
                            flag = true;
                            Rectangle rectangle = new Rectangle((((bestX * 0x10) + 8) - (NPC.sWidth / 2)) - NPC.safeRangeX, (((bestY * 0x10) + 8) - (NPC.sHeight / 2)) - NPC.safeRangeY, NPC.sWidth + (NPC.safeRangeX * 2), NPC.sHeight + (NPC.safeRangeY * 2));
                            for (int j = 0; j < 0xff; j++)
                            {
                                if (Main.player[j].active)
                                {
                                    Rectangle rectangle2 = new Rectangle((int) Main.player[j].position.X, (int) Main.player[j].position.Y, Main.player[j].width, Main.player[j].height);
                                    if (rectangle2.Intersects(rectangle))
                                    {
                                        flag = false;
                                        break;
                                    }
                                }
                            }
                        }
                        if (!flag)
                        {
                            for (int k = 1; k < 500; k++)
                            {
                                for (int m = 0; m < 2; m++)
                                {
                                    if (m == 0)
                                    {
                                        bestX = WorldGen.bestX + k;
                                    }
                                    else
                                    {
                                        bestX = WorldGen.bestX - k;
                                    }
                                    if ((bestX > 10) && (bestX < (Main.maxTilesX - 10)))
                                    {
                                        int num8 = WorldGen.bestY - k;
                                        double worldSurface = WorldGen.bestY + k;
                                        if (num8 < 10)
                                        {
                                            num8 = 10;
                                        }
                                        if (worldSurface > Main.worldSurface)
                                        {
                                            worldSurface = Main.worldSurface;
                                        }
                                        for (int n = num8; n < worldSurface; n++)
                                        {
                                            bestY = n;
                                            if (Main.tile[bestX, bestY].active && Main.tileSolid[Main.tile[bestX, bestY].type])
                                            {
                                                if (!Collision.SolidTiles(bestX - 1, bestX + 1, bestY - 3, bestY - 1))
                                                {
                                                    flag = true;
                                                    Rectangle rectangle3 = new Rectangle((((bestX * 0x10) + 8) - (NPC.sWidth / 2)) - NPC.safeRangeX, (((bestY * 0x10) + 8) - (NPC.sHeight / 2)) - NPC.safeRangeY, NPC.sWidth + (NPC.safeRangeX * 2), NPC.sHeight + (NPC.safeRangeY * 2));
                                                    for (int num11 = 0; num11 < 0xff; num11++)
                                                    {
                                                        if (Main.player[num11].active)
                                                        {
                                                            Rectangle rectangle4 = new Rectangle((int) Main.player[num11].position.X, (int) Main.player[num11].position.Y, Main.player[num11].width, Main.player[num11].height);
                                                            if (rectangle4.Intersects(rectangle3))
                                                            {
                                                                flag = false;
                                                                break;
                                                            }
                                                        }
                                                    }
                                                }
                                                break;
                                            }
                                        }
                                    }
                                    if (flag)
                                    {
                                        break;
                                    }
                                }
                                if (flag)
                                {
                                    break;
                                }
                            }
                        }
                        int num12 = NPC.NewNPC(bestX * 0x10, bestY * 0x10, spawnNPC, 1);
                        Main.npc[num12].homeTileX = WorldGen.bestX;
                        Main.npc[num12].homeTileY = WorldGen.bestY;
                        if (bestX < WorldGen.bestX)
                        {
                            Main.npc[num12].direction = 1;
                        }
                        else if (bestX > WorldGen.bestX)
                        {
                            Main.npc[num12].direction = -1;
                        }
                        Main.npc[num12].netUpdate = true;
                        if (Main.netMode == 2)
                        {
                            NetMessage.SendData(0x19, -1, -1, Main.npc[num12].name + " has arrived!", 0xff, 50f, 125f, 255f, 0);
                        }
                    }
                    spawnNPC = 0;
                }
            }
        }

        public static void SpreadGrass(int i, int j, int dirt = 0, int grass = 2, bool repeat = true)
        {
            if ((((Main.tile[i, j].type == dirt) && Main.tile[i, j].active) && ((j >= Main.worldSurface) || (grass != 70))) && ((j < Main.worldSurface) || (dirt != 0)))
            {
                int num = i - 1;
                int maxTilesX = i + 2;
                int num3 = j - 1;
                int maxTilesY = j + 2;
                if (num < 0)
                {
                    num = 0;
                }
                if (maxTilesX > Main.maxTilesX)
                {
                    maxTilesX = Main.maxTilesX;
                }
                if (num3 < 0)
                {
                    num3 = 0;
                }
                if (maxTilesY > Main.maxTilesY)
                {
                    maxTilesY = Main.maxTilesY;
                }
                bool flag = true;
                for (int k = num; k < maxTilesX; k++)
                {
                    for (int m = num3; m < maxTilesY; m++)
                    {
                        if (!Main.tile[k, m].active || !Main.tileSolid[Main.tile[k, m].type])
                        {
                            flag = false;
                            goto Label_00C7;
                        }
                    }
                Label_00C7:;
                }
                if (!flag && ((grass != 0x17) || (Main.tile[i, j - 1].type != 0x1b)))
                {
                    Main.tile[i, j].type = (byte) grass;
                    for (int n = num; n < maxTilesX; n++)
                    {
                        for (int num8 = num3; num8 < maxTilesY; num8++)
                        {
                            if ((Main.tile[n, num8].active && (Main.tile[n, num8].type == dirt)) && repeat)
                            {
                                SpreadGrass(n, num8, dirt, grass, true);
                            }
                        }
                    }
                }
            }
        }

        public static void SquareTileFrame(int i, int j, bool resetFrame = true)
        {
            TileFrame(i - 1, j - 1, false, false);
            TileFrame(i - 1, j, false, false);
            TileFrame(i - 1, j + 1, false, false);
            TileFrame(i, j - 1, false, false);
            TileFrame(i, j, resetFrame, false);
            TileFrame(i, j + 1, false, false);
            TileFrame(i + 1, j - 1, false, false);
            TileFrame(i + 1, j, false, false);
            TileFrame(i + 1, j + 1, false, false);
        }

        public static void SquareWallFrame(int i, int j, bool resetFrame = true)
        {
            WallFrame(i - 1, j - 1, false);
            WallFrame(i - 1, j, false);
            WallFrame(i - 1, j + 1, false);
            WallFrame(i, j - 1, false);
            WallFrame(i, j, resetFrame);
            WallFrame(i, j + 1, false);
            WallFrame(i + 1, j - 1, false);
            WallFrame(i + 1, j, false);
            WallFrame(i + 1, j + 1, false);
        }

        public static bool StartRoomCheck(int x, int y)
        {
            roomX1 = x;
            roomX2 = x;
            roomY1 = y;
            roomY2 = y;
            numRoomTiles = 0;
            for (int i = 0; i < 0x6b; i++)
            {
                houseTile[i] = false;
            }
            canSpawn = true;
            if (Main.tile[x, y].active && Main.tileSolid[Main.tile[x, y].type])
            {
                canSpawn = false;
            }
            CheckRoom(x, y);
            if (numRoomTiles < 60)
            {
                canSpawn = false;
            }
            return canSpawn;
        }

        public static void TileFrame(int i, int j, bool resetFrame = false, bool noBreak = false)
        {
            if ((((i > 5) && (j > 5)) && ((i < (Main.maxTilesX - 5)) && (j < (Main.maxTilesY - 5)))) && (Main.tile[i, j] != null))
            {
                if (((Main.tile[i, j].liquid > 0) && (Main.netMode != 1)) && !noLiquidCheck)
                {
                    Liquid.AddWater(i, j);
                }
                if (Main.tile[i, j].active && (!noBreak || !Main.tileFrameImportant[Main.tile[i, j].type]))
                {
                    Rectangle rectangle;
                    int index = -1;
                    int num2 = -1;
                    int num3 = -1;
                    int num4 = -1;
                    int num5 = -1;
                    int num6 = -1;
                    int num7 = -1;
                    int num8 = -1;
                    int type = Main.tile[i, j].type;
                    if (Main.tileStone[type])
                    {
                        type = 1;
                    }
                    int frameX = Main.tile[i, j].frameX;
                    int frameY = Main.tile[i, j].frameY;
                    rectangle.X = -1;
                    rectangle.Y = -1;
                    WorldGen.mergeUp = false;
                    WorldGen.mergeDown = false;
                    WorldGen.mergeLeft = false;
                    WorldGen.mergeRight = false;
                    if ((Main.tile[i - 1, j] != null) && Main.tile[i - 1, j].active)
                    {
                        num4 = Main.tile[i - 1, j].type;
                    }
                    if ((Main.tile[i + 1, j] != null) && Main.tile[i + 1, j].active)
                    {
                        num5 = Main.tile[i + 1, j].type;
                    }
                    if ((Main.tile[i, j - 1] != null) && Main.tile[i, j - 1].active)
                    {
                        num2 = Main.tile[i, j - 1].type;
                    }
                    if ((Main.tile[i, j + 1] != null) && Main.tile[i, j + 1].active)
                    {
                        num7 = Main.tile[i, j + 1].type;
                    }
                    if ((Main.tile[i - 1, j - 1] != null) && Main.tile[i - 1, j - 1].active)
                    {
                        index = Main.tile[i - 1, j - 1].type;
                    }
                    if ((Main.tile[i + 1, j - 1] != null) && Main.tile[i + 1, j - 1].active)
                    {
                        num3 = Main.tile[i + 1, j - 1].type;
                    }
                    if ((Main.tile[i - 1, j + 1] != null) && Main.tile[i - 1, j + 1].active)
                    {
                        num6 = Main.tile[i - 1, j + 1].type;
                    }
                    if ((Main.tile[i + 1, j + 1] != null) && Main.tile[i + 1, j + 1].active)
                    {
                        num8 = Main.tile[i + 1, j + 1].type;
                    }
                    if ((num4 >= 0) && Main.tileStone[num4])
                    {
                        num4 = 1;
                    }
                    if ((num5 >= 0) && Main.tileStone[num5])
                    {
                        num5 = 1;
                    }
                    if ((num2 >= 0) && Main.tileStone[num2])
                    {
                        num2 = 1;
                    }
                    if ((num7 >= 0) && Main.tileStone[num7])
                    {
                        num7 = 1;
                    }
                    if ((index >= 0) && Main.tileStone[index])
                    {
                        index = 1;
                    }
                    if ((num3 >= 0) && Main.tileStone[num3])
                    {
                        num3 = 1;
                    }
                    if ((num6 >= 0) && Main.tileStone[num6])
                    {
                        num6 = 1;
                    }
                    if ((num8 >= 0) && Main.tileStone[num8])
                    {
                        num8 = 1;
                    }
                    switch (type)
                    {
                        case 0:
                        case 1:
                            break;

                        default:
                            if ((((type == 3) || (type == 0x18)) || ((type == 0x3d) || (type == 0x47))) || ((type == 0x49) || (type == 0x4a)))
                            {
                                PlantCheck(i, j);
                                return;
                            }
                            if (type == 4)
                            {
                                if (((num7 >= 0) && Main.tileSolid[num7]) && !Main.tileNoAttach[num7])
                                {
                                    Main.tile[i, j].frameX = 0;
                                    return;
                                }
                                if ((((num4 >= 0) && Main.tileSolid[num4]) && !Main.tileNoAttach[num4]) || (((num4 == 5) && (index == 5)) && (num6 == 5)))
                                {
                                    Main.tile[i, j].frameX = 0x16;
                                    return;
                                }
                                if ((((num5 >= 0) && Main.tileSolid[num5]) && !Main.tileNoAttach[num5]) || (((num5 == 5) && (num3 == 5)) && (num8 == 5)))
                                {
                                    Main.tile[i, j].frameX = 0x2c;
                                    return;
                                }
                                KillTile(i, j, false, false, false);
                                return;
                            }
                            if (type == 80)
                            {
                                CactusFrame(i, j);
                                return;
                            }
                            if ((type == 12) || (type == 0x1f))
                            {
                                if (!destroyObject)
                                {
                                    int num12 = i;
                                    int num13 = j;
                                    if (Main.tile[i, j].frameX == 0)
                                    {
                                        num12 = i;
                                    }
                                    else
                                    {
                                        num12 = i - 1;
                                    }
                                    if (Main.tile[i, j].frameY == 0)
                                    {
                                        num13 = j;
                                    }
                                    else
                                    {
                                        num13 = j - 1;
                                    }
                                    if ((((Main.tile[num12, num13] != null) && (Main.tile[num12 + 1, num13] != null)) && ((Main.tile[num12, num13 + 1] != null) && (Main.tile[num12 + 1, num13 + 1] != null))) && (((!Main.tile[num12, num13].active || (Main.tile[num12, num13].type != type)) || (!Main.tile[num12 + 1, num13].active || (Main.tile[num12 + 1, num13].type != type))) || ((!Main.tile[num12, num13 + 1].active || (Main.tile[num12, num13 + 1].type != type)) || (!Main.tile[num12 + 1, num13 + 1].active || (Main.tile[num12 + 1, num13 + 1].type != type)))))
                                    {
                                        destroyObject = true;
                                        if (Main.tile[num12, num13].type == type)
                                        {
                                            KillTile(num12, num13, false, false, false);
                                        }
                                        if (Main.tile[num12 + 1, num13].type == type)
                                        {
                                            KillTile(num12 + 1, num13, false, false, false);
                                        }
                                        if (Main.tile[num12, num13 + 1].type == type)
                                        {
                                            KillTile(num12, num13 + 1, false, false, false);
                                        }
                                        if (Main.tile[num12 + 1, num13 + 1].type == type)
                                        {
                                            KillTile(num12 + 1, num13 + 1, false, false, false);
                                        }
                                        if ((Main.netMode != 1) && !noTileActions)
                                        {
                                            if (type == 12)
                                            {
                                                Item.NewItem(num12 * 0x10, num13 * 0x10, 0x20, 0x20, 0x1d, 1, false);
                                            }
                                            else if (type == 0x1f)
                                            {
                                                if (genRand.Next(2) == 0)
                                                {
                                                    spawnMeteor = true;
                                                }
                                                int num14 = Main.rand.Next(5);
                                                if (!shadowOrbSmashed)
                                                {
                                                    num14 = 0;
                                                }
                                                if (num14 == 0)
                                                {
                                                    Item.NewItem(num12 * 0x10, num13 * 0x10, 0x20, 0x20, 0x60, 1, false);
                                                    int stack = genRand.Next(0x19, 0x33);
                                                    Item.NewItem(num12 * 0x10, num13 * 0x10, 0x20, 0x20, 0x61, stack, false);
                                                }
                                                else if (num14 == 1)
                                                {
                                                    Item.NewItem(num12 * 0x10, num13 * 0x10, 0x20, 0x20, 0x40, 1, false);
                                                }
                                                else if (num14 == 2)
                                                {
                                                    Item.NewItem(num12 * 0x10, num13 * 0x10, 0x20, 0x20, 0xa2, 1, false);
                                                }
                                                else if (num14 == 3)
                                                {
                                                    Item.NewItem(num12 * 0x10, num13 * 0x10, 0x20, 0x20, 0x73, 1, false);
                                                }
                                                else if (num14 == 4)
                                                {
                                                    Item.NewItem(num12 * 0x10, num13 * 0x10, 0x20, 0x20, 0x6f, 1, false);
                                                }
                                                shadowOrbSmashed = true;
                                                shadowOrbCount++;
                                                if (shadowOrbCount >= 3)
                                                {
                                                    shadowOrbCount = 0;
                                                    float num16 = num12 * 0x10;
                                                    float num17 = num13 * 0x10;
                                                    float num18 = -1f;
                                                    int plr = 0;
                                                    for (int k = 0; k < 0xff; k++)
                                                    {
                                                        float num21 = Math.Abs((float) (Main.player[k].position.X - num16)) + Math.Abs((float) (Main.player[k].position.Y - num17));
                                                        if ((num21 < num18) || (num18 == -1f))
                                                        {
                                                            plr = 0;
                                                            num18 = num21;
                                                        }
                                                    }
                                                    NPC.SpawnOnPlayer(plr, 13);
                                                }
                                                else
                                                {
                                                    string newText = "A horrible chill goes down your spine...";
                                                    if (shadowOrbCount == 2)
                                                    {
                                                        newText = "Screams echo around you...";
                                                    }
                                                    if (Main.netMode == 2)
                                                    {
                                                        NetMessage.SendData(0x19, -1, -1, newText, 0xff, 50f, 255f, 130f, 0);
                                                    }
                                                }
                                            }
                                        }
                                        Main.PlaySound(13, i * 0x10, j * 0x10, 1);
                                        destroyObject = false;
                                    }
                                }
                                return;
                            }
                            if (type == 0x13)
                            {
                                if ((num4 == type) && (num5 == type))
                                {
                                    if (Main.tile[i, j].frameNumber == 0)
                                    {
                                        rectangle.X = 0;
                                        rectangle.Y = 0;
                                    }
                                    if (Main.tile[i, j].frameNumber == 1)
                                    {
                                        rectangle.X = 0;
                                        rectangle.Y = 0x12;
                                    }
                                    if (Main.tile[i, j].frameNumber == 2)
                                    {
                                        rectangle.X = 0;
                                        rectangle.Y = 0x24;
                                    }
                                }
                                else if ((num4 == type) && (num5 == -1))
                                {
                                    if (Main.tile[i, j].frameNumber == 0)
                                    {
                                        rectangle.X = 0x12;
                                        rectangle.Y = 0;
                                    }
                                    if (Main.tile[i, j].frameNumber == 1)
                                    {
                                        rectangle.X = 0x12;
                                        rectangle.Y = 0x12;
                                    }
                                    if (Main.tile[i, j].frameNumber == 2)
                                    {
                                        rectangle.X = 0x12;
                                        rectangle.Y = 0x24;
                                    }
                                }
                                else if ((num4 == -1) && (num5 == type))
                                {
                                    if (Main.tile[i, j].frameNumber == 0)
                                    {
                                        rectangle.X = 0x24;
                                        rectangle.Y = 0;
                                    }
                                    if (Main.tile[i, j].frameNumber == 1)
                                    {
                                        rectangle.X = 0x24;
                                        rectangle.Y = 0x12;
                                    }
                                    if (Main.tile[i, j].frameNumber == 2)
                                    {
                                        rectangle.X = 0x24;
                                        rectangle.Y = 0x24;
                                    }
                                }
                                else if ((num4 != type) && (num5 == type))
                                {
                                    if (Main.tile[i, j].frameNumber == 0)
                                    {
                                        rectangle.X = 0x36;
                                        rectangle.Y = 0;
                                    }
                                    if (Main.tile[i, j].frameNumber == 1)
                                    {
                                        rectangle.X = 0x36;
                                        rectangle.Y = 0x12;
                                    }
                                    if (Main.tile[i, j].frameNumber == 2)
                                    {
                                        rectangle.X = 0x36;
                                        rectangle.Y = 0x24;
                                    }
                                }
                                else if ((num4 == type) && (num5 != type))
                                {
                                    if (Main.tile[i, j].frameNumber == 0)
                                    {
                                        rectangle.X = 0x48;
                                        rectangle.Y = 0;
                                    }
                                    if (Main.tile[i, j].frameNumber == 1)
                                    {
                                        rectangle.X = 0x48;
                                        rectangle.Y = 0x12;
                                    }
                                    if (Main.tile[i, j].frameNumber == 2)
                                    {
                                        rectangle.X = 0x48;
                                        rectangle.Y = 0x24;
                                    }
                                }
                                else if (((num4 != type) && (num4 != -1)) && (num5 == -1))
                                {
                                    if (Main.tile[i, j].frameNumber == 0)
                                    {
                                        rectangle.X = 0x6c;
                                        rectangle.Y = 0;
                                    }
                                    if (Main.tile[i, j].frameNumber == 1)
                                    {
                                        rectangle.X = 0x6c;
                                        rectangle.Y = 0x12;
                                    }
                                    if (Main.tile[i, j].frameNumber == 2)
                                    {
                                        rectangle.X = 0x6c;
                                        rectangle.Y = 0x24;
                                    }
                                }
                                else if (((num4 == -1) && (num5 != type)) && (num5 != -1))
                                {
                                    if (Main.tile[i, j].frameNumber == 0)
                                    {
                                        rectangle.X = 0x7e;
                                        rectangle.Y = 0;
                                    }
                                    if (Main.tile[i, j].frameNumber == 1)
                                    {
                                        rectangle.X = 0x7e;
                                        rectangle.Y = 0x12;
                                    }
                                    if (Main.tile[i, j].frameNumber == 2)
                                    {
                                        rectangle.X = 0x7e;
                                        rectangle.Y = 0x24;
                                    }
                                }
                                else
                                {
                                    if (Main.tile[i, j].frameNumber == 0)
                                    {
                                        rectangle.X = 90;
                                        rectangle.Y = 0;
                                    }
                                    if (Main.tile[i, j].frameNumber == 1)
                                    {
                                        rectangle.X = 90;
                                        rectangle.Y = 0x12;
                                    }
                                    if (Main.tile[i, j].frameNumber == 2)
                                    {
                                        rectangle.X = 90;
                                        rectangle.Y = 0x24;
                                    }
                                }
                            }
                            else
                            {
                                if (type == 10)
                                {
                                    if (!destroyObject)
                                    {
                                        int num22 = Main.tile[i, j].frameY;
                                        int num23 = j;
                                        bool flag = false;
                                        switch (num22)
                                        {
                                            case 0:
                                                num23 = j;
                                                break;

                                            case 0x12:
                                                num23 = j - 1;
                                                break;

                                            case 0x24:
                                                num23 = j - 2;
                                                break;
                                        }
                                        if (Main.tile[i, num23 - 1] == null)
                                        {
                                            Main.tile[i, num23 - 1] = new Tile();
                                        }
                                        if (Main.tile[i, num23 + 3] == null)
                                        {
                                            Main.tile[i, num23 + 3] = new Tile();
                                        }
                                        if (Main.tile[i, num23 + 2] == null)
                                        {
                                            Main.tile[i, num23 + 2] = new Tile();
                                        }
                                        if (Main.tile[i, num23 + 1] == null)
                                        {
                                            Main.tile[i, num23 + 1] = new Tile();
                                        }
                                        if (Main.tile[i, num23] == null)
                                        {
                                            Main.tile[i, num23] = new Tile();
                                        }
                                        if (!Main.tile[i, num23 - 1].active || !Main.tileSolid[Main.tile[i, num23 - 1].type])
                                        {
                                            flag = true;
                                        }
                                        if (!Main.tile[i, num23 + 3].active || !Main.tileSolid[Main.tile[i, num23 + 3].type])
                                        {
                                            flag = true;
                                        }
                                        if (!Main.tile[i, num23].active || (Main.tile[i, num23].type != type))
                                        {
                                            flag = true;
                                        }
                                        if (!Main.tile[i, num23 + 1].active || (Main.tile[i, num23 + 1].type != type))
                                        {
                                            flag = true;
                                        }
                                        if (!Main.tile[i, num23 + 2].active || (Main.tile[i, num23 + 2].type != type))
                                        {
                                            flag = true;
                                        }
                                        if (flag)
                                        {
                                            destroyObject = true;
                                            KillTile(i, num23, false, false, false);
                                            KillTile(i, num23 + 1, false, false, false);
                                            KillTile(i, num23 + 2, false, false, false);
                                            Item.NewItem(i * 0x10, j * 0x10, 0x10, 0x10, 0x19, 1, false);
                                        }
                                        destroyObject = false;
                                    }
                                    return;
                                }
                                if (type == 11)
                                {
                                    if (!destroyObject)
                                    {
                                        int num24 = 0;
                                        int num25 = i;
                                        int num26 = j;
                                        int num27 = Main.tile[i, j].frameX;
                                        int num28 = Main.tile[i, j].frameY;
                                        bool flag2 = false;
                                        switch (num27)
                                        {
                                            case 0:
                                                num25 = i;
                                                num24 = 1;
                                                break;

                                            case 0x12:
                                                num25 = i - 1;
                                                num24 = 1;
                                                break;

                                            case 0x24:
                                                num25 = i + 1;
                                                num24 = -1;
                                                break;

                                            case 0x36:
                                                num25 = i;
                                                num24 = -1;
                                                break;
                                        }
                                        if (num28 == 0)
                                        {
                                            num26 = j;
                                        }
                                        else if (num28 == 0x12)
                                        {
                                            num26 = j - 1;
                                        }
                                        else if (num28 == 0x24)
                                        {
                                            num26 = j - 2;
                                        }
                                        if (Main.tile[num25, num26 + 3] == null)
                                        {
                                            Main.tile[num25, num26 + 3] = new Tile();
                                        }
                                        if (Main.tile[num25, num26 - 1] == null)
                                        {
                                            Main.tile[num25, num26 - 1] = new Tile();
                                        }
                                        if ((!Main.tile[num25, num26 - 1].active || !Main.tileSolid[Main.tile[num25, num26 - 1].type]) || (!Main.tile[num25, num26 + 3].active || !Main.tileSolid[Main.tile[num25, num26 + 3].type]))
                                        {
                                            flag2 = true;
                                            destroyObject = true;
                                            Item.NewItem(i * 0x10, j * 0x10, 0x10, 0x10, 0x19, 1, false);
                                        }
                                        int num29 = num25;
                                        if (num24 == -1)
                                        {
                                            num29 = num25 - 1;
                                        }
                                        for (int m = num29; m < (num29 + 2); m++)
                                        {
                                            for (int n = num26; n < (num26 + 3); n++)
                                            {
                                                if (!flag2 && ((Main.tile[m, n].type != 11) || !Main.tile[m, n].active))
                                                {
                                                    destroyObject = true;
                                                    Item.NewItem(i * 0x10, j * 0x10, 0x10, 0x10, 0x19, 1, false);
                                                    flag2 = true;
                                                    m = num29;
                                                    n = num26;
                                                }
                                                if (flag2)
                                                {
                                                    KillTile(m, n, false, false, false);
                                                }
                                            }
                                        }
                                        destroyObject = false;
                                    }
                                    return;
                                }
                                if (((type == 0x22) || (type == 0x23)) || ((type == 0x24) || (type == 0x6a)))
                                {
                                    Check3x3(i, j, (byte) type);
                                    return;
                                }
                                if ((type == 15) || (type == 20))
                                {
                                    Check1x2(i, j, (byte) type);
                                    return;
                                }
                                if ((((type == 14) || (type == 0x11)) || ((type == 0x1a) || (type == 0x4d))) || (((type == 0x56) || (type == 0x57)) || ((type == 0x58) || (type == 0x59))))
                                {
                                    Check3x2(i, j, (byte) type);
                                    return;
                                }
                                if (((type == 0x10) || (type == 0x12)) || ((type == 0x1d) || (type == 0x67)))
                                {
                                    Check2x1(i, j, (byte) type);
                                    return;
                                }
                                if (((type == 13) || (type == 0x21)) || (((type == 0x31) || (type == 50)) || (type == 0x4e)))
                                {
                                    CheckOnTable1x1(i, j, (byte) type);
                                    return;
                                }
                                if (type == 0x15)
                                {
                                    CheckChest(i, j, (byte) type);
                                    return;
                                }
                                if (type == 0x1b)
                                {
                                    CheckSunflower(i, j, 0x1b);
                                    return;
                                }
                                if (type == 0x1c)
                                {
                                    CheckPot(i, j, 0x1c);
                                    return;
                                }
                                if (type == 0x5b)
                                {
                                    CheckBanner(i, j, (byte) type);
                                    return;
                                }
                                if ((type == 0x5c) || (type == 0x5d))
                                {
                                    Check1xX(i, j, (byte) type);
                                    return;
                                }
                                if ((type == 0x68) || (type == 0x69))
                                {
                                    Check2xX(i, j, (byte) type);
                                }
                                else
                                {
                                    if ((type == 0x65) || (type == 0x66))
                                    {
                                        Check3x4(i, j, (byte) type);
                                        return;
                                    }
                                    if (type == 0x2a)
                                    {
                                        Check1x2Top(i, j, (byte) type);
                                        return;
                                    }
                                    if ((type == 0x37) || (type == 0x55))
                                    {
                                        CheckSign(i, j, type);
                                        return;
                                    }
                                    if ((type == 0x4f) || (type == 90))
                                    {
                                        Check4x2(i, j, type);
                                        return;
                                    }
                                    if ((((type == 0x55) || (type == 0x5e)) || ((type == 0x5f) || (type == 0x60))) || (((type == 0x61) || (type == 0x62)) || ((type == 0x63) || (type == 100))))
                                    {
                                        Check2x2(i, j, type);
                                        return;
                                    }
                                    if (type == 0x51)
                                    {
                                        if (((num4 != -1) || (num2 != -1)) || (num5 != -1))
                                        {
                                            KillTile(i, j, false, false, false);
                                            return;
                                        }
                                        if ((num7 < 0) || !Main.tileSolid[num7])
                                        {
                                            KillTile(i, j, false, false, false);
                                        }
                                        return;
                                    }
                                    if (Main.tileAlch[type])
                                    {
                                        CheckAlch(i, j);
                                        return;
                                    }
                                    if (type == 0x48)
                                    {
                                        if ((num7 != type) && (num7 != 70))
                                        {
                                            KillTile(i, j, false, false, false);
                                        }
                                        else if ((num2 != type) && (Main.tile[i, j].frameX == 0))
                                        {
                                            Main.tile[i, j].frameNumber = (byte) genRand.Next(3);
                                            if (Main.tile[i, j].frameNumber == 0)
                                            {
                                                Main.tile[i, j].frameX = 0x12;
                                                Main.tile[i, j].frameY = 0;
                                            }
                                            if (Main.tile[i, j].frameNumber == 1)
                                            {
                                                Main.tile[i, j].frameX = 0x12;
                                                Main.tile[i, j].frameY = 0x12;
                                            }
                                            if (Main.tile[i, j].frameNumber == 2)
                                            {
                                                Main.tile[i, j].frameX = 0x12;
                                                Main.tile[i, j].frameY = 0x24;
                                            }
                                        }
                                    }
                                    else if (type == 5)
                                    {
                                        switch (num7)
                                        {
                                            case 0x17:
                                                num7 = 2;
                                                break;

                                            case 60:
                                                num7 = 2;
                                                break;
                                        }
                                        if (((Main.tile[i, j].frameX >= 0x16) && (Main.tile[i, j].frameX <= 0x2c)) && ((Main.tile[i, j].frameY >= 0x84) && (Main.tile[i, j].frameY <= 0xb0)))
                                        {
                                            if (((num4 != type) && (num5 != type)) || (num7 != 2))
                                            {
                                                KillTile(i, j, false, false, false);
                                            }
                                        }
                                        else if (((((Main.tile[i, j].frameX == 0x58) && (Main.tile[i, j].frameY >= 0)) && (Main.tile[i, j].frameY <= 0x2c)) || (((Main.tile[i, j].frameX == 0x42) && (Main.tile[i, j].frameY >= 0x42)) && (Main.tile[i, j].frameY <= 130))) || ((((Main.tile[i, j].frameX == 110) && (Main.tile[i, j].frameY >= 0x42)) && (Main.tile[i, j].frameY <= 110)) || (((Main.tile[i, j].frameX == 0x84) && (Main.tile[i, j].frameY >= 0)) && (Main.tile[i, j].frameY <= 0xb0))))
                                        {
                                            if ((num4 == type) && (num5 == type))
                                            {
                                                if (Main.tile[i, j].frameNumber == 0)
                                                {
                                                    Main.tile[i, j].frameX = 110;
                                                    Main.tile[i, j].frameY = 0x42;
                                                }
                                                if (Main.tile[i, j].frameNumber == 1)
                                                {
                                                    Main.tile[i, j].frameX = 110;
                                                    Main.tile[i, j].frameY = 0x58;
                                                }
                                                if (Main.tile[i, j].frameNumber == 2)
                                                {
                                                    Main.tile[i, j].frameX = 110;
                                                    Main.tile[i, j].frameY = 110;
                                                }
                                            }
                                            else if (num4 == type)
                                            {
                                                if (Main.tile[i, j].frameNumber == 0)
                                                {
                                                    Main.tile[i, j].frameX = 0x58;
                                                    Main.tile[i, j].frameY = 0;
                                                }
                                                if (Main.tile[i, j].frameNumber == 1)
                                                {
                                                    Main.tile[i, j].frameX = 0x58;
                                                    Main.tile[i, j].frameY = 0x16;
                                                }
                                                if (Main.tile[i, j].frameNumber == 2)
                                                {
                                                    Main.tile[i, j].frameX = 0x58;
                                                    Main.tile[i, j].frameY = 0x2c;
                                                }
                                            }
                                            else if (num5 == type)
                                            {
                                                if (Main.tile[i, j].frameNumber == 0)
                                                {
                                                    Main.tile[i, j].frameX = 0x42;
                                                    Main.tile[i, j].frameY = 0x42;
                                                }
                                                if (Main.tile[i, j].frameNumber == 1)
                                                {
                                                    Main.tile[i, j].frameX = 0x42;
                                                    Main.tile[i, j].frameY = 0x58;
                                                }
                                                if (Main.tile[i, j].frameNumber == 2)
                                                {
                                                    Main.tile[i, j].frameX = 0x42;
                                                    Main.tile[i, j].frameY = 110;
                                                }
                                            }
                                            else
                                            {
                                                if (Main.tile[i, j].frameNumber == 0)
                                                {
                                                    Main.tile[i, j].frameX = 0;
                                                    Main.tile[i, j].frameY = 0;
                                                }
                                                if (Main.tile[i, j].frameNumber == 1)
                                                {
                                                    Main.tile[i, j].frameX = 0;
                                                    Main.tile[i, j].frameY = 0x16;
                                                }
                                                if (Main.tile[i, j].frameNumber == 2)
                                                {
                                                    Main.tile[i, j].frameX = 0;
                                                    Main.tile[i, j].frameY = 0x2c;
                                                }
                                            }
                                        }
                                        if (((Main.tile[i, j].frameY >= 0x84) && (Main.tile[i, j].frameY <= 0xb0)) && (((Main.tile[i, j].frameX == 0) || (Main.tile[i, j].frameX == 0x42)) || (Main.tile[i, j].frameX == 0x58)))
                                        {
                                            if (num7 != 2)
                                            {
                                                KillTile(i, j, false, false, false);
                                            }
                                            if ((num4 != type) && (num5 != type))
                                            {
                                                if (Main.tile[i, j].frameNumber == 0)
                                                {
                                                    Main.tile[i, j].frameX = 0;
                                                    Main.tile[i, j].frameY = 0;
                                                }
                                                if (Main.tile[i, j].frameNumber == 1)
                                                {
                                                    Main.tile[i, j].frameX = 0;
                                                    Main.tile[i, j].frameY = 0x16;
                                                }
                                                if (Main.tile[i, j].frameNumber == 2)
                                                {
                                                    Main.tile[i, j].frameX = 0;
                                                    Main.tile[i, j].frameY = 0x2c;
                                                }
                                            }
                                            else if (num4 != type)
                                            {
                                                if (Main.tile[i, j].frameNumber == 0)
                                                {
                                                    Main.tile[i, j].frameX = 0;
                                                    Main.tile[i, j].frameY = 0x84;
                                                }
                                                if (Main.tile[i, j].frameNumber == 1)
                                                {
                                                    Main.tile[i, j].frameX = 0;
                                                    Main.tile[i, j].frameY = 0x9a;
                                                }
                                                if (Main.tile[i, j].frameNumber == 2)
                                                {
                                                    Main.tile[i, j].frameX = 0;
                                                    Main.tile[i, j].frameY = 0xb0;
                                                }
                                            }
                                            else if (num5 != type)
                                            {
                                                if (Main.tile[i, j].frameNumber == 0)
                                                {
                                                    Main.tile[i, j].frameX = 0x42;
                                                    Main.tile[i, j].frameY = 0x84;
                                                }
                                                if (Main.tile[i, j].frameNumber == 1)
                                                {
                                                    Main.tile[i, j].frameX = 0x42;
                                                    Main.tile[i, j].frameY = 0x9a;
                                                }
                                                if (Main.tile[i, j].frameNumber == 2)
                                                {
                                                    Main.tile[i, j].frameX = 0x42;
                                                    Main.tile[i, j].frameY = 0xb0;
                                                }
                                            }
                                            else
                                            {
                                                if (Main.tile[i, j].frameNumber == 0)
                                                {
                                                    Main.tile[i, j].frameX = 0x58;
                                                    Main.tile[i, j].frameY = 0x84;
                                                }
                                                if (Main.tile[i, j].frameNumber == 1)
                                                {
                                                    Main.tile[i, j].frameX = 0x58;
                                                    Main.tile[i, j].frameY = 0x9a;
                                                }
                                                if (Main.tile[i, j].frameNumber == 2)
                                                {
                                                    Main.tile[i, j].frameX = 0x58;
                                                    Main.tile[i, j].frameY = 0xb0;
                                                }
                                            }
                                        }
                                        if ((((Main.tile[i, j].frameX == 0x42) && (((Main.tile[i, j].frameY == 0) || (Main.tile[i, j].frameY == 0x16)) || (Main.tile[i, j].frameY == 0x2c))) || ((Main.tile[i, j].frameX == 0x58) && (((Main.tile[i, j].frameY == 0x42) || (Main.tile[i, j].frameY == 0x58)) || (Main.tile[i, j].frameY == 110)))) || (((Main.tile[i, j].frameX == 0x2c) && (((Main.tile[i, j].frameY == 0xc6) || (Main.tile[i, j].frameY == 220)) || (Main.tile[i, j].frameY == 0xf2))) || ((Main.tile[i, j].frameX == 0x42) && (((Main.tile[i, j].frameY == 0xc6) || (Main.tile[i, j].frameY == 220)) || (Main.tile[i, j].frameY == 0xf2)))))
                                        {
                                            if ((num4 != type) && (num5 != type))
                                            {
                                                KillTile(i, j, false, false, false);
                                            }
                                        }
                                        else if ((num7 == -1) || (num7 == 0x17))
                                        {
                                            KillTile(i, j, false, false, false);
                                        }
                                        else if (((num2 != type) && (Main.tile[i, j].frameY < 0xc6)) && (((Main.tile[i, j].frameX != 0x16) && (Main.tile[i, j].frameX != 0x2c)) || (Main.tile[i, j].frameY < 0x84)))
                                        {
                                            if ((num4 == type) || (num5 == type))
                                            {
                                                if (num7 == type)
                                                {
                                                    if ((num4 == type) && (num5 == type))
                                                    {
                                                        if (Main.tile[i, j].frameNumber == 0)
                                                        {
                                                            Main.tile[i, j].frameX = 0x84;
                                                            Main.tile[i, j].frameY = 0x84;
                                                        }
                                                        if (Main.tile[i, j].frameNumber == 1)
                                                        {
                                                            Main.tile[i, j].frameX = 0x84;
                                                            Main.tile[i, j].frameY = 0x9a;
                                                        }
                                                        if (Main.tile[i, j].frameNumber == 2)
                                                        {
                                                            Main.tile[i, j].frameX = 0x84;
                                                            Main.tile[i, j].frameY = 0xb0;
                                                        }
                                                    }
                                                    else if (num4 == type)
                                                    {
                                                        if (Main.tile[i, j].frameNumber == 0)
                                                        {
                                                            Main.tile[i, j].frameX = 0x84;
                                                            Main.tile[i, j].frameY = 0;
                                                        }
                                                        if (Main.tile[i, j].frameNumber == 1)
                                                        {
                                                            Main.tile[i, j].frameX = 0x84;
                                                            Main.tile[i, j].frameY = 0x16;
                                                        }
                                                        if (Main.tile[i, j].frameNumber == 2)
                                                        {
                                                            Main.tile[i, j].frameX = 0x84;
                                                            Main.tile[i, j].frameY = 0x2c;
                                                        }
                                                    }
                                                    else if (num5 == type)
                                                    {
                                                        if (Main.tile[i, j].frameNumber == 0)
                                                        {
                                                            Main.tile[i, j].frameX = 0x84;
                                                            Main.tile[i, j].frameY = 0x42;
                                                        }
                                                        if (Main.tile[i, j].frameNumber == 1)
                                                        {
                                                            Main.tile[i, j].frameX = 0x84;
                                                            Main.tile[i, j].frameY = 0x58;
                                                        }
                                                        if (Main.tile[i, j].frameNumber == 2)
                                                        {
                                                            Main.tile[i, j].frameX = 0x84;
                                                            Main.tile[i, j].frameY = 110;
                                                        }
                                                    }
                                                }
                                                else if ((num4 == type) && (num5 == type))
                                                {
                                                    if (Main.tile[i, j].frameNumber == 0)
                                                    {
                                                        Main.tile[i, j].frameX = 0x9a;
                                                        Main.tile[i, j].frameY = 0x84;
                                                    }
                                                    if (Main.tile[i, j].frameNumber == 1)
                                                    {
                                                        Main.tile[i, j].frameX = 0x9a;
                                                        Main.tile[i, j].frameY = 0x9a;
                                                    }
                                                    if (Main.tile[i, j].frameNumber == 2)
                                                    {
                                                        Main.tile[i, j].frameX = 0x9a;
                                                        Main.tile[i, j].frameY = 0xb0;
                                                    }
                                                }
                                                else if (num4 == type)
                                                {
                                                    if (Main.tile[i, j].frameNumber == 0)
                                                    {
                                                        Main.tile[i, j].frameX = 0x9a;
                                                        Main.tile[i, j].frameY = 0;
                                                    }
                                                    if (Main.tile[i, j].frameNumber == 1)
                                                    {
                                                        Main.tile[i, j].frameX = 0x9a;
                                                        Main.tile[i, j].frameY = 0x16;
                                                    }
                                                    if (Main.tile[i, j].frameNumber == 2)
                                                    {
                                                        Main.tile[i, j].frameX = 0x9a;
                                                        Main.tile[i, j].frameY = 0x2c;
                                                    }
                                                }
                                                else if (num5 == type)
                                                {
                                                    if (Main.tile[i, j].frameNumber == 0)
                                                    {
                                                        Main.tile[i, j].frameX = 0x9a;
                                                        Main.tile[i, j].frameY = 0x42;
                                                    }
                                                    if (Main.tile[i, j].frameNumber == 1)
                                                    {
                                                        Main.tile[i, j].frameX = 0x9a;
                                                        Main.tile[i, j].frameY = 0x58;
                                                    }
                                                    if (Main.tile[i, j].frameNumber == 2)
                                                    {
                                                        Main.tile[i, j].frameX = 0x9a;
                                                        Main.tile[i, j].frameY = 110;
                                                    }
                                                }
                                            }
                                            else
                                            {
                                                if (Main.tile[i, j].frameNumber == 0)
                                                {
                                                    Main.tile[i, j].frameX = 110;
                                                    Main.tile[i, j].frameY = 0;
                                                }
                                                if (Main.tile[i, j].frameNumber == 1)
                                                {
                                                    Main.tile[i, j].frameX = 110;
                                                    Main.tile[i, j].frameY = 0x16;
                                                }
                                                if (Main.tile[i, j].frameNumber == 2)
                                                {
                                                    Main.tile[i, j].frameX = 110;
                                                    Main.tile[i, j].frameY = 0x2c;
                                                }
                                            }
                                        }
                                        rectangle.X = Main.tile[i, j].frameX;
                                        rectangle.Y = Main.tile[i, j].frameY;
                                    }
                                }
                            }
                            break;
                    }
                    if (!Main.tileFrameImportant[Main.tile[i, j].type])
                    {
                        int frameNumber = 0;
                        if (resetFrame)
                        {
                            frameNumber = genRand.Next(0, 3);
                            Main.tile[i, j].frameNumber = (byte) frameNumber;
                        }
                        else
                        {
                            frameNumber = Main.tile[i, j].frameNumber;
                        }
                        if (type == 0)
                        {
                            if ((num2 >= 0) && Main.tileMergeDirt[num2])
                            {
                                TileFrame(i, j - 1, false, false);
                                if (WorldGen.mergeDown)
                                {
                                    num2 = type;
                                }
                            }
                            if ((num7 >= 0) && Main.tileMergeDirt[num7])
                            {
                                TileFrame(i, j + 1, false, false);
                                if (WorldGen.mergeUp)
                                {
                                    num7 = type;
                                }
                            }
                            if ((num4 >= 0) && Main.tileMergeDirt[num4])
                            {
                                TileFrame(i - 1, j, false, false);
                                if (WorldGen.mergeRight)
                                {
                                    num4 = type;
                                }
                            }
                            if ((num5 >= 0) && Main.tileMergeDirt[num5])
                            {
                                TileFrame(i + 1, j, false, false);
                                if (WorldGen.mergeLeft)
                                {
                                    num5 = type;
                                }
                            }
                            if ((index >= 0) && Main.tileMergeDirt[index])
                            {
                                index = type;
                            }
                            if ((num3 >= 0) && Main.tileMergeDirt[num3])
                            {
                                num3 = type;
                            }
                            if ((num6 >= 0) && Main.tileMergeDirt[num6])
                            {
                                num6 = type;
                            }
                            if ((num8 >= 0) && Main.tileMergeDirt[num8])
                            {
                                num8 = type;
                            }
                            if (num2 == 2)
                            {
                                num2 = type;
                            }
                            if (num7 == 2)
                            {
                                num7 = type;
                            }
                            if (num4 == 2)
                            {
                                num4 = type;
                            }
                            if (num5 == 2)
                            {
                                num5 = type;
                            }
                            if (index == 2)
                            {
                                index = type;
                            }
                            if (num3 == 2)
                            {
                                num3 = type;
                            }
                            if (num6 == 2)
                            {
                                num6 = type;
                            }
                            if (num8 == 2)
                            {
                                num8 = type;
                            }
                            if (num2 == 0x17)
                            {
                                num2 = type;
                            }
                            if (num7 == 0x17)
                            {
                                num7 = type;
                            }
                            if (num4 == 0x17)
                            {
                                num4 = type;
                            }
                            if (num5 == 0x17)
                            {
                                num5 = type;
                            }
                            if (index == 0x17)
                            {
                                index = type;
                            }
                            if (num3 == 0x17)
                            {
                                num3 = type;
                            }
                            if (num6 == 0x17)
                            {
                                num6 = type;
                            }
                            if (num8 == 0x17)
                            {
                                num8 = type;
                            }
                        }
                        else if (type == 0x39)
                        {
                            if (num2 == 0x3a)
                            {
                                TileFrame(i, j - 1, false, false);
                                if (WorldGen.mergeDown)
                                {
                                    num2 = type;
                                }
                            }
                            if (num7 == 0x3a)
                            {
                                TileFrame(i, j + 1, false, false);
                                if (WorldGen.mergeUp)
                                {
                                    num7 = type;
                                }
                            }
                            if (num4 == 0x3a)
                            {
                                TileFrame(i - 1, j, false, false);
                                if (WorldGen.mergeRight)
                                {
                                    num4 = type;
                                }
                            }
                            if (num5 == 0x3a)
                            {
                                TileFrame(i + 1, j, false, false);
                                if (WorldGen.mergeLeft)
                                {
                                    num5 = type;
                                }
                            }
                            if (index == 0x3a)
                            {
                                index = type;
                            }
                            if (num3 == 0x3a)
                            {
                                num3 = type;
                            }
                            if (num6 == 0x3a)
                            {
                                num6 = type;
                            }
                            if (num8 == 0x3a)
                            {
                                num8 = type;
                            }
                        }
                        else if (type == 0x3b)
                        {
                            if (num2 == 60)
                            {
                                num2 = type;
                            }
                            if (num7 == 60)
                            {
                                num7 = type;
                            }
                            if (num4 == 60)
                            {
                                num4 = type;
                            }
                            if (num5 == 60)
                            {
                                num5 = type;
                            }
                            if (index == 60)
                            {
                                index = type;
                            }
                            if (num3 == 60)
                            {
                                num3 = type;
                            }
                            if (num6 == 60)
                            {
                                num6 = type;
                            }
                            if (num8 == 60)
                            {
                                num8 = type;
                            }
                            if (num2 == 70)
                            {
                                num2 = type;
                            }
                            if (num7 == 70)
                            {
                                num7 = type;
                            }
                            if (num4 == 70)
                            {
                                num4 = type;
                            }
                            if (num5 == 70)
                            {
                                num5 = type;
                            }
                            if (index == 70)
                            {
                                index = type;
                            }
                            if (num3 == 70)
                            {
                                num3 = type;
                            }
                            if (num6 == 70)
                            {
                                num6 = type;
                            }
                            if (num8 == 70)
                            {
                                num8 = type;
                            }
                        }
                        if (Main.tileMergeDirt[type])
                        {
                            if (num2 == 0)
                            {
                                num2 = -2;
                            }
                            if (num7 == 0)
                            {
                                num7 = -2;
                            }
                            if (num4 == 0)
                            {
                                num4 = -2;
                            }
                            if (num5 == 0)
                            {
                                num5 = -2;
                            }
                            if (index == 0)
                            {
                                index = -2;
                            }
                            if (num3 == 0)
                            {
                                num3 = -2;
                            }
                            if (num6 == 0)
                            {
                                num6 = -2;
                            }
                            if (num8 == 0)
                            {
                                num8 = -2;
                            }
                        }
                        else if (type == 0x3a)
                        {
                            if (num2 == 0x39)
                            {
                                num2 = -2;
                            }
                            if (num7 == 0x39)
                            {
                                num7 = -2;
                            }
                            if (num4 == 0x39)
                            {
                                num4 = -2;
                            }
                            if (num5 == 0x39)
                            {
                                num5 = -2;
                            }
                            if (index == 0x39)
                            {
                                index = -2;
                            }
                            if (num3 == 0x39)
                            {
                                num3 = -2;
                            }
                            if (num6 == 0x39)
                            {
                                num6 = -2;
                            }
                            if (num8 == 0x39)
                            {
                                num8 = -2;
                            }
                        }
                        else if (type == 0x3b)
                        {
                            if (num2 == 1)
                            {
                                num2 = -2;
                            }
                            if (num7 == 1)
                            {
                                num7 = -2;
                            }
                            if (num4 == 1)
                            {
                                num4 = -2;
                            }
                            if (num5 == 1)
                            {
                                num5 = -2;
                            }
                            if (index == 1)
                            {
                                index = -2;
                            }
                            if (num3 == 1)
                            {
                                num3 = -2;
                            }
                            if (num6 == 1)
                            {
                                num6 = -2;
                            }
                            if (num8 == 1)
                            {
                                num8 = -2;
                            }
                        }
                        if (type == 0x20)
                        {
                            if (num7 == 0x17)
                            {
                                num7 = type;
                            }
                        }
                        else if (type == 0x45)
                        {
                            if (num7 == 60)
                            {
                                num7 = type;
                            }
                        }
                        else if (type == 0x33)
                        {
                            if ((num2 > -1) && !Main.tileNoAttach[num2])
                            {
                                num2 = type;
                            }
                            if ((num7 > -1) && !Main.tileNoAttach[num7])
                            {
                                num7 = type;
                            }
                            if ((num4 > -1) && !Main.tileNoAttach[num4])
                            {
                                num4 = type;
                            }
                            if ((num5 > -1) && !Main.tileNoAttach[num5])
                            {
                                num5 = type;
                            }
                            if ((index > -1) && !Main.tileNoAttach[index])
                            {
                                index = type;
                            }
                            if ((num3 > -1) && !Main.tileNoAttach[num3])
                            {
                                num3 = type;
                            }
                            if ((num6 > -1) && !Main.tileNoAttach[num6])
                            {
                                num6 = type;
                            }
                            if ((num8 > -1) && !Main.tileNoAttach[num8])
                            {
                                num8 = type;
                            }
                        }
                        if (((num2 > -1) && !Main.tileSolid[num2]) && (num2 != type))
                        {
                            num2 = -1;
                        }
                        if (((num7 > -1) && !Main.tileSolid[num7]) && (num7 != type))
                        {
                            num7 = -1;
                        }
                        if (((num4 > -1) && !Main.tileSolid[num4]) && (num4 != type))
                        {
                            num4 = -1;
                        }
                        if (((num5 > -1) && !Main.tileSolid[num5]) && (num5 != type))
                        {
                            num5 = -1;
                        }
                        if (((index > -1) && !Main.tileSolid[index]) && (index != type))
                        {
                            index = -1;
                        }
                        if (((num3 > -1) && !Main.tileSolid[num3]) && (num3 != type))
                        {
                            num3 = -1;
                        }
                        if (((num6 > -1) && !Main.tileSolid[num6]) && (num6 != type))
                        {
                            num6 = -1;
                        }
                        if (((num8 > -1) && !Main.tileSolid[num8]) && (num8 != type))
                        {
                            num8 = -1;
                        }
                        if (((type == 2) || (type == 0x17)) || ((type == 60) || (type == 70)))
                        {
                            int num33 = 0;
                            if ((type == 60) || (type == 70))
                            {
                                num33 = 0x3b;
                            }
                            else if (type == 2)
                            {
                                if (num2 == 0x17)
                                {
                                    num2 = num33;
                                }
                                if (num7 == 0x17)
                                {
                                    num7 = num33;
                                }
                                if (num4 == 0x17)
                                {
                                    num4 = num33;
                                }
                                if (num5 == 0x17)
                                {
                                    num5 = num33;
                                }
                                if (index == 0x17)
                                {
                                    index = num33;
                                }
                                if (num3 == 0x17)
                                {
                                    num3 = num33;
                                }
                                if (num6 == 0x17)
                                {
                                    num6 = num33;
                                }
                                if (num8 == 0x17)
                                {
                                    num8 = num33;
                                }
                            }
                            else if (type == 0x17)
                            {
                                if (num2 == 2)
                                {
                                    num2 = num33;
                                }
                                if (num7 == 2)
                                {
                                    num7 = num33;
                                }
                                if (num4 == 2)
                                {
                                    num4 = num33;
                                }
                                if (num5 == 2)
                                {
                                    num5 = num33;
                                }
                                if (index == 2)
                                {
                                    index = num33;
                                }
                                if (num3 == 2)
                                {
                                    num3 = num33;
                                }
                                if (num6 == 2)
                                {
                                    num6 = num33;
                                }
                                if (num8 == 2)
                                {
                                    num8 = num33;
                                }
                            }
                            if (((num2 != type) && (num2 != num33)) && ((num7 == type) || (num7 == num33)))
                            {
                                if ((num4 == num33) && (num5 == type))
                                {
                                    switch (frameNumber)
                                    {
                                        case 0:
                                            rectangle.X = 0;
                                            rectangle.Y = 0xc6;
                                            break;

                                        case 1:
                                            rectangle.X = 0x12;
                                            rectangle.Y = 0xc6;
                                            break;

                                        case 2:
                                            rectangle.X = 0x24;
                                            rectangle.Y = 0xc6;
                                            break;
                                    }
                                }
                                else if ((num4 == type) && (num5 == num33))
                                {
                                    switch (frameNumber)
                                    {
                                        case 0:
                                            rectangle.X = 0x36;
                                            rectangle.Y = 0xc6;
                                            break;

                                        case 1:
                                            rectangle.X = 0x48;
                                            rectangle.Y = 0xc6;
                                            break;

                                        case 2:
                                            rectangle.X = 90;
                                            rectangle.Y = 0xc6;
                                            break;
                                    }
                                }
                            }
                            else if (((num7 != type) && (num7 != num33)) && ((num2 == type) || (num2 == num33)))
                            {
                                if ((num4 == num33) && (num5 == type))
                                {
                                    switch (frameNumber)
                                    {
                                        case 0:
                                            rectangle.X = 0;
                                            rectangle.Y = 0xd8;
                                            break;

                                        case 1:
                                            rectangle.X = 0x12;
                                            rectangle.Y = 0xd8;
                                            break;

                                        case 2:
                                            rectangle.X = 0x24;
                                            rectangle.Y = 0xd8;
                                            break;
                                    }
                                }
                                else if ((num4 == type) && (num5 == num33))
                                {
                                    switch (frameNumber)
                                    {
                                        case 0:
                                            rectangle.X = 0x36;
                                            rectangle.Y = 0xd8;
                                            break;

                                        case 1:
                                            rectangle.X = 0x48;
                                            rectangle.Y = 0xd8;
                                            break;

                                        case 2:
                                            rectangle.X = 90;
                                            rectangle.Y = 0xd8;
                                            break;
                                    }
                                }
                            }
                            else if (((num4 != type) && (num4 != num33)) && ((num5 == type) || (num5 == num33)))
                            {
                                if ((num2 == num33) && (num7 == type))
                                {
                                    switch (frameNumber)
                                    {
                                        case 0:
                                            rectangle.X = 0x48;
                                            rectangle.Y = 0x90;
                                            break;

                                        case 1:
                                            rectangle.X = 0x48;
                                            rectangle.Y = 0xa2;
                                            break;

                                        case 2:
                                            rectangle.X = 0x48;
                                            rectangle.Y = 180;
                                            break;
                                    }
                                }
                                else if ((num7 == type) && (num5 == num2))
                                {
                                    switch (frameNumber)
                                    {
                                        case 0:
                                            rectangle.X = 0x48;
                                            rectangle.Y = 90;
                                            break;

                                        case 1:
                                            rectangle.X = 0x48;
                                            rectangle.Y = 0x6c;
                                            break;

                                        case 2:
                                            rectangle.X = 0x48;
                                            rectangle.Y = 0x7e;
                                            break;
                                    }
                                }
                            }
                            else if (((num5 != type) && (num5 != num33)) && ((num4 == type) || (num4 == num33)))
                            {
                                if ((num2 == num33) && (num7 == type))
                                {
                                    switch (frameNumber)
                                    {
                                        case 0:
                                            rectangle.X = 90;
                                            rectangle.Y = 0x90;
                                            break;

                                        case 1:
                                            rectangle.X = 90;
                                            rectangle.Y = 0xa2;
                                            break;

                                        case 2:
                                            rectangle.X = 90;
                                            rectangle.Y = 180;
                                            break;
                                    }
                                }
                                else if ((num7 == type) && (num5 == num2))
                                {
                                    switch (frameNumber)
                                    {
                                        case 0:
                                            rectangle.X = 90;
                                            rectangle.Y = 90;
                                            break;

                                        case 1:
                                            rectangle.X = 90;
                                            rectangle.Y = 0x6c;
                                            break;

                                        case 2:
                                            rectangle.X = 90;
                                            rectangle.Y = 0x7e;
                                            break;
                                    }
                                }
                            }
                            else if (((num2 == type) && (num7 == type)) && ((num4 == type) && (num5 == type)))
                            {
                                if (((index != type) && (num3 != type)) && ((num6 != type) && (num8 != type)))
                                {
                                    if (num8 == num33)
                                    {
                                        switch (frameNumber)
                                        {
                                            case 0:
                                                rectangle.X = 0x6c;
                                                rectangle.Y = 0x144;
                                                break;

                                            case 1:
                                                rectangle.X = 0x7e;
                                                rectangle.Y = 0x144;
                                                break;

                                            case 2:
                                                rectangle.X = 0x90;
                                                rectangle.Y = 0x144;
                                                break;
                                        }
                                    }
                                    else if (num3 == num33)
                                    {
                                        switch (frameNumber)
                                        {
                                            case 0:
                                                rectangle.X = 0x6c;
                                                rectangle.Y = 0x156;
                                                break;

                                            case 1:
                                                rectangle.X = 0x7e;
                                                rectangle.Y = 0x156;
                                                break;

                                            case 2:
                                                rectangle.X = 0x90;
                                                rectangle.Y = 0x156;
                                                break;
                                        }
                                    }
                                    else if (num6 == num33)
                                    {
                                        switch (frameNumber)
                                        {
                                            case 0:
                                                rectangle.X = 0x6c;
                                                rectangle.Y = 360;
                                                break;

                                            case 1:
                                                rectangle.X = 0x7e;
                                                rectangle.Y = 360;
                                                break;

                                            case 2:
                                                rectangle.X = 0x90;
                                                rectangle.Y = 360;
                                                break;
                                        }
                                    }
                                    else if (index == num33)
                                    {
                                        switch (frameNumber)
                                        {
                                            case 0:
                                                rectangle.X = 0x6c;
                                                rectangle.Y = 0x17a;
                                                break;

                                            case 1:
                                                rectangle.X = 0x7e;
                                                rectangle.Y = 0x17a;
                                                break;

                                            case 2:
                                                rectangle.X = 0x90;
                                                rectangle.Y = 0x17a;
                                                break;
                                        }
                                    }
                                    else
                                    {
                                        switch (frameNumber)
                                        {
                                            case 0:
                                                rectangle.X = 0x90;
                                                rectangle.Y = 0xea;
                                                break;

                                            case 1:
                                                rectangle.X = 0xc6;
                                                rectangle.Y = 0xea;
                                                break;

                                            case 2:
                                                rectangle.X = 0xfc;
                                                rectangle.Y = 0xea;
                                                break;
                                        }
                                    }
                                }
                                else if ((index != type) && (num8 != type))
                                {
                                    switch (frameNumber)
                                    {
                                        case 0:
                                            rectangle.X = 0x24;
                                            rectangle.Y = 0x132;
                                            break;

                                        case 1:
                                            rectangle.X = 0x36;
                                            rectangle.Y = 0x132;
                                            break;

                                        case 2:
                                            rectangle.X = 0x48;
                                            rectangle.Y = 0x132;
                                            break;
                                    }
                                }
                                else if ((num3 != type) && (num6 != type))
                                {
                                    switch (frameNumber)
                                    {
                                        case 0:
                                            rectangle.X = 90;
                                            rectangle.Y = 0x132;
                                            break;

                                        case 1:
                                            rectangle.X = 0x6c;
                                            rectangle.Y = 0x132;
                                            break;

                                        case 2:
                                            rectangle.X = 0x7e;
                                            rectangle.Y = 0x132;
                                            break;
                                    }
                                }
                                else if (((index != type) && (num3 == type)) && ((num6 == type) && (num8 == type)))
                                {
                                    switch (frameNumber)
                                    {
                                        case 0:
                                            rectangle.X = 0x36;
                                            rectangle.Y = 0x6c;
                                            break;

                                        case 1:
                                            rectangle.X = 0x36;
                                            rectangle.Y = 0x90;
                                            break;

                                        case 2:
                                            rectangle.X = 0x36;
                                            rectangle.Y = 180;
                                            break;
                                    }
                                }
                                else if (((index == type) && (num3 != type)) && ((num6 == type) && (num8 == type)))
                                {
                                    switch (frameNumber)
                                    {
                                        case 0:
                                            rectangle.X = 0x24;
                                            rectangle.Y = 0x6c;
                                            break;

                                        case 1:
                                            rectangle.X = 0x24;
                                            rectangle.Y = 0x90;
                                            break;

                                        case 2:
                                            rectangle.X = 0x24;
                                            rectangle.Y = 180;
                                            break;
                                    }
                                }
                                else if (((index == type) && (num3 == type)) && ((num6 != type) && (num8 == type)))
                                {
                                    switch (frameNumber)
                                    {
                                        case 0:
                                            rectangle.X = 0x36;
                                            rectangle.Y = 90;
                                            break;

                                        case 1:
                                            rectangle.X = 0x36;
                                            rectangle.Y = 0x7e;
                                            break;

                                        case 2:
                                            rectangle.X = 0x36;
                                            rectangle.Y = 0xa2;
                                            break;
                                    }
                                }
                                else if (((index == type) && (num3 == type)) && ((num6 == type) && (num8 != type)))
                                {
                                    switch (frameNumber)
                                    {
                                        case 0:
                                            rectangle.X = 0x24;
                                            rectangle.Y = 90;
                                            break;

                                        case 1:
                                            rectangle.X = 0x24;
                                            rectangle.Y = 0x7e;
                                            break;

                                        case 2:
                                            rectangle.X = 0x24;
                                            rectangle.Y = 0xa2;
                                            break;
                                    }
                                }
                            }
                            else if ((((num2 == type) && (num7 == num33)) && ((num4 == type) && (num5 == type))) && ((index == -1) && (num3 == -1)))
                            {
                                switch (frameNumber)
                                {
                                    case 0:
                                        rectangle.X = 0x6c;
                                        rectangle.Y = 0x12;
                                        break;

                                    case 1:
                                        rectangle.X = 0x7e;
                                        rectangle.Y = 0x12;
                                        break;

                                    case 2:
                                        rectangle.X = 0x90;
                                        rectangle.Y = 0x12;
                                        break;
                                }
                            }
                            else if ((((num2 == num33) && (num7 == type)) && ((num4 == type) && (num5 == type))) && ((num6 == -1) && (num8 == -1)))
                            {
                                switch (frameNumber)
                                {
                                    case 0:
                                        rectangle.X = 0x6c;
                                        rectangle.Y = 0x24;
                                        break;

                                    case 1:
                                        rectangle.X = 0x7e;
                                        rectangle.Y = 0x24;
                                        break;

                                    case 2:
                                        rectangle.X = 0x90;
                                        rectangle.Y = 0x24;
                                        break;
                                }
                            }
                            else if ((((num2 == type) && (num7 == type)) && ((num4 == num33) && (num5 == type))) && ((num3 == -1) && (num8 == -1)))
                            {
                                switch (frameNumber)
                                {
                                    case 0:
                                        rectangle.X = 0xc6;
                                        rectangle.Y = 0;
                                        break;

                                    case 1:
                                        rectangle.X = 0xc6;
                                        rectangle.Y = 0x12;
                                        break;

                                    case 2:
                                        rectangle.X = 0xc6;
                                        rectangle.Y = 0x24;
                                        break;
                                }
                            }
                            else if ((((num2 == type) && (num7 == type)) && ((num4 == type) && (num5 == num33))) && ((index == -1) && (num6 == -1)))
                            {
                                switch (frameNumber)
                                {
                                    case 0:
                                        rectangle.X = 180;
                                        rectangle.Y = 0;
                                        break;

                                    case 1:
                                        rectangle.X = 180;
                                        rectangle.Y = 0x12;
                                        break;

                                    case 2:
                                        rectangle.X = 180;
                                        rectangle.Y = 0x24;
                                        break;
                                }
                            }
                            else if (((num2 == type) && (num7 == num33)) && ((num4 == type) && (num5 == type)))
                            {
                                if (num3 == -1)
                                {
                                    if (index != -1)
                                    {
                                        switch (frameNumber)
                                        {
                                            case 0:
                                                rectangle.X = 0x24;
                                                rectangle.Y = 0x6c;
                                                break;

                                            case 1:
                                                rectangle.X = 0x24;
                                                rectangle.Y = 0x90;
                                                break;

                                            case 2:
                                                rectangle.X = 0x24;
                                                rectangle.Y = 180;
                                                break;
                                        }
                                    }
                                }
                                else
                                {
                                    switch (frameNumber)
                                    {
                                        case 0:
                                            rectangle.X = 0x36;
                                            rectangle.Y = 0x6c;
                                            break;

                                        case 1:
                                            rectangle.X = 0x36;
                                            rectangle.Y = 0x90;
                                            break;

                                        case 2:
                                            rectangle.X = 0x36;
                                            rectangle.Y = 180;
                                            break;
                                    }
                                }
                            }
                            else if (((num2 == num33) && (num7 == type)) && ((num4 == type) && (num5 == type)))
                            {
                                if (num8 == -1)
                                {
                                    if (num6 != -1)
                                    {
                                        switch (frameNumber)
                                        {
                                            case 0:
                                                rectangle.X = 0x24;
                                                rectangle.Y = 90;
                                                break;

                                            case 1:
                                                rectangle.X = 0x24;
                                                rectangle.Y = 0x7e;
                                                break;

                                            case 2:
                                                rectangle.X = 0x24;
                                                rectangle.Y = 0xa2;
                                                break;
                                        }
                                    }
                                }
                                else
                                {
                                    switch (frameNumber)
                                    {
                                        case 0:
                                            rectangle.X = 0x36;
                                            rectangle.Y = 90;
                                            break;

                                        case 1:
                                            rectangle.X = 0x36;
                                            rectangle.Y = 0x7e;
                                            break;

                                        case 2:
                                            rectangle.X = 0x36;
                                            rectangle.Y = 0xa2;
                                            break;
                                    }
                                }
                            }
                            else if (((num2 == type) && (num7 == type)) && ((num4 == type) && (num5 == num33)))
                            {
                                if (index == -1)
                                {
                                    if (num6 != -1)
                                    {
                                        switch (frameNumber)
                                        {
                                            case 0:
                                                rectangle.X = 0x36;
                                                rectangle.Y = 0x6c;
                                                break;

                                            case 1:
                                                rectangle.X = 0x36;
                                                rectangle.Y = 0x90;
                                                break;

                                            case 2:
                                                rectangle.X = 0x36;
                                                rectangle.Y = 180;
                                                break;
                                        }
                                    }
                                }
                                else
                                {
                                    switch (frameNumber)
                                    {
                                        case 0:
                                            rectangle.X = 0x36;
                                            rectangle.Y = 90;
                                            break;

                                        case 1:
                                            rectangle.X = 0x36;
                                            rectangle.Y = 0x7e;
                                            break;

                                        case 2:
                                            rectangle.X = 0x36;
                                            rectangle.Y = 0xa2;
                                            break;
                                    }
                                }
                            }
                            else if (((num2 == type) && (num7 == type)) && ((num4 == num33) && (num5 == type)))
                            {
                                if (num3 == -1)
                                {
                                    if (num8 != -1)
                                    {
                                        switch (frameNumber)
                                        {
                                            case 0:
                                                rectangle.X = 0x24;
                                                rectangle.Y = 0x6c;
                                                break;

                                            case 1:
                                                rectangle.X = 0x24;
                                                rectangle.Y = 0x90;
                                                break;

                                            case 2:
                                                rectangle.X = 0x24;
                                                rectangle.Y = 180;
                                                break;
                                        }
                                    }
                                }
                                else
                                {
                                    switch (frameNumber)
                                    {
                                        case 0:
                                            rectangle.X = 0x24;
                                            rectangle.Y = 90;
                                            break;

                                        case 1:
                                            rectangle.X = 0x24;
                                            rectangle.Y = 0x7e;
                                            break;

                                        case 2:
                                            rectangle.X = 0x24;
                                            rectangle.Y = 0xa2;
                                            break;
                                    }
                                }
                            }
                            else if (((((num2 == num33) && (num7 == type)) && ((num4 == type) && (num5 == type))) || (((num2 == type) && (num7 == num33)) && ((num4 == type) && (num5 == type)))) || ((((num2 == type) && (num7 == type)) && ((num4 == num33) && (num5 == type))) || (((num2 == type) && (num7 == type)) && ((num4 == type) && (num5 == num33)))))
                            {
                                switch (frameNumber)
                                {
                                    case 0:
                                        rectangle.X = 0x12;
                                        rectangle.Y = 0x12;
                                        break;

                                    case 1:
                                        rectangle.X = 0x24;
                                        rectangle.Y = 0x12;
                                        break;

                                    case 2:
                                        rectangle.X = 0x36;
                                        rectangle.Y = 0x12;
                                        break;
                                }
                            }
                            if ((((num2 == type) || (num2 == num33)) && ((num7 == type) || (num7 == num33))) && (((num4 == type) || (num4 == num33)) && ((num5 == type) || (num5 == num33))))
                            {
                                if (((((index != type) && (index != num33)) && ((num3 == type) || (num3 == num33))) && ((num6 == type) || (num6 == num33))) && ((num8 == type) || (num8 == num33)))
                                {
                                    switch (frameNumber)
                                    {
                                        case 0:
                                            rectangle.X = 0x36;
                                            rectangle.Y = 0x6c;
                                            break;

                                        case 1:
                                            rectangle.X = 0x36;
                                            rectangle.Y = 0x90;
                                            break;

                                        case 2:
                                            rectangle.X = 0x36;
                                            rectangle.Y = 180;
                                            break;
                                    }
                                }
                                else if (((((num3 != type) && (num3 != num33)) && ((index == type) || (index == num33))) && ((num6 == type) || (num6 == num33))) && ((num8 == type) || (num8 == num33)))
                                {
                                    switch (frameNumber)
                                    {
                                        case 0:
                                            rectangle.X = 0x24;
                                            rectangle.Y = 0x6c;
                                            break;

                                        case 1:
                                            rectangle.X = 0x24;
                                            rectangle.Y = 0x90;
                                            break;

                                        case 2:
                                            rectangle.X = 0x24;
                                            rectangle.Y = 180;
                                            break;
                                    }
                                }
                                else if (((((num6 != type) && (num6 != num33)) && ((index == type) || (index == num33))) && ((num3 == type) || (num3 == num33))) && ((num8 == type) || (num8 == num33)))
                                {
                                    switch (frameNumber)
                                    {
                                        case 0:
                                            rectangle.X = 0x36;
                                            rectangle.Y = 90;
                                            break;

                                        case 1:
                                            rectangle.X = 0x36;
                                            rectangle.Y = 0x7e;
                                            break;

                                        case 2:
                                            rectangle.X = 0x36;
                                            rectangle.Y = 0xa2;
                                            break;
                                    }
                                }
                                else if (((((num8 != type) && (num8 != num33)) && ((index == type) || (index == num33))) && ((num6 == type) || (num6 == num33))) && ((num3 == type) || (num3 == num33)))
                                {
                                    switch (frameNumber)
                                    {
                                        case 0:
                                            rectangle.X = 0x24;
                                            rectangle.Y = 90;
                                            break;

                                        case 1:
                                            rectangle.X = 0x24;
                                            rectangle.Y = 0x7e;
                                            break;

                                        case 2:
                                            rectangle.X = 0x24;
                                            rectangle.Y = 0xa2;
                                            break;
                                    }
                                }
                            }
                            if ((((num2 != num33) && (num2 != type)) && ((num7 == type) && (num4 != num33))) && (((num4 != type) && (num5 == type)) && ((num8 != num33) && (num8 != type))))
                            {
                                switch (frameNumber)
                                {
                                    case 0:
                                        rectangle.X = 90;
                                        rectangle.Y = 270;
                                        break;

                                    case 1:
                                        rectangle.X = 0x6c;
                                        rectangle.Y = 270;
                                        break;

                                    case 2:
                                        rectangle.X = 0x7e;
                                        rectangle.Y = 270;
                                        break;
                                }
                            }
                            else if ((((num2 != num33) && (num2 != type)) && ((num7 == type) && (num4 == type))) && (((num5 != num33) && (num5 != type)) && ((num6 != num33) && (num6 != type))))
                            {
                                switch (frameNumber)
                                {
                                    case 0:
                                        rectangle.X = 0x90;
                                        rectangle.Y = 270;
                                        break;

                                    case 1:
                                        rectangle.X = 0xa2;
                                        rectangle.Y = 270;
                                        break;

                                    case 2:
                                        rectangle.X = 180;
                                        rectangle.Y = 270;
                                        break;
                                }
                            }
                            else if ((((num7 != num33) && (num7 != type)) && ((num2 == type) && (num4 != num33))) && (((num4 != type) && (num5 == type)) && ((num3 != num33) && (num3 != type))))
                            {
                                switch (frameNumber)
                                {
                                    case 0:
                                        rectangle.X = 90;
                                        rectangle.Y = 0x120;
                                        break;

                                    case 1:
                                        rectangle.X = 0x6c;
                                        rectangle.Y = 0x120;
                                        break;

                                    case 2:
                                        rectangle.X = 0x7e;
                                        rectangle.Y = 0x120;
                                        break;
                                }
                            }
                            else if ((((num7 != num33) && (num7 != type)) && ((num2 == type) && (num4 == type))) && (((num5 != num33) && (num5 != type)) && ((index != num33) && (index != type))))
                            {
                                switch (frameNumber)
                                {
                                    case 0:
                                        rectangle.X = 0x90;
                                        rectangle.Y = 0x120;
                                        break;

                                    case 1:
                                        rectangle.X = 0xa2;
                                        rectangle.Y = 0x120;
                                        break;

                                    case 2:
                                        rectangle.X = 180;
                                        rectangle.Y = 0x120;
                                        break;
                                }
                            }
                            else if (((((num2 != type) && (num2 != num33)) && ((num7 == type) && (num4 == type))) && (((num5 == type) && (num6 != type)) && ((num6 != num33) && (num8 != type)))) && (num8 != num33))
                            {
                                switch (frameNumber)
                                {
                                    case 0:
                                        rectangle.X = 0x90;
                                        rectangle.Y = 0xd8;
                                        break;

                                    case 1:
                                        rectangle.X = 0xc6;
                                        rectangle.Y = 0xd8;
                                        break;

                                    case 2:
                                        rectangle.X = 0xfc;
                                        rectangle.Y = 0xd8;
                                        break;
                                }
                            }
                            else if (((((num7 != type) && (num7 != num33)) && ((num2 == type) && (num4 == type))) && (((num5 == type) && (index != type)) && ((index != num33) && (num3 != type)))) && (num3 != num33))
                            {
                                switch (frameNumber)
                                {
                                    case 0:
                                        rectangle.X = 0x90;
                                        rectangle.Y = 0xfc;
                                        break;

                                    case 1:
                                        rectangle.X = 0xc6;
                                        rectangle.Y = 0xfc;
                                        break;

                                    case 2:
                                        rectangle.X = 0xfc;
                                        rectangle.Y = 0xfc;
                                        break;
                                }
                            }
                            else if (((((num4 != type) && (num4 != num33)) && ((num7 == type) && (num2 == type))) && (((num5 == type) && (num3 != type)) && ((num3 != num33) && (num8 != type)))) && (num8 != num33))
                            {
                                switch (frameNumber)
                                {
                                    case 0:
                                        rectangle.X = 0x7e;
                                        rectangle.Y = 0xea;
                                        break;

                                    case 1:
                                        rectangle.X = 180;
                                        rectangle.Y = 0xea;
                                        break;

                                    case 2:
                                        rectangle.X = 0xea;
                                        rectangle.Y = 0xea;
                                        break;
                                }
                            }
                            else if (((((num5 != type) && (num5 != num33)) && ((num7 == type) && (num2 == type))) && (((num4 == type) && (index != type)) && ((index != num33) && (num6 != type)))) && (num6 != num33))
                            {
                                switch (frameNumber)
                                {
                                    case 0:
                                        rectangle.X = 0xa2;
                                        rectangle.Y = 0xea;
                                        break;

                                    case 1:
                                        rectangle.X = 0xd8;
                                        rectangle.Y = 0xea;
                                        break;

                                    case 2:
                                        rectangle.X = 270;
                                        rectangle.Y = 0xea;
                                        break;
                                }
                            }
                            else if ((((num2 != num33) && (num2 != type)) && ((num7 == num33) || (num7 == type))) && ((num4 == num33) && (num5 == num33)))
                            {
                                switch (frameNumber)
                                {
                                    case 0:
                                        rectangle.X = 0x24;
                                        rectangle.Y = 270;
                                        break;

                                    case 1:
                                        rectangle.X = 0x36;
                                        rectangle.Y = 270;
                                        break;

                                    case 2:
                                        rectangle.X = 0x48;
                                        rectangle.Y = 270;
                                        break;
                                }
                            }
                            else if ((((num7 != num33) && (num7 != type)) && ((num2 == num33) || (num2 == type))) && ((num4 == num33) && (num5 == num33)))
                            {
                                switch (frameNumber)
                                {
                                    case 0:
                                        rectangle.X = 0x24;
                                        rectangle.Y = 0x120;
                                        break;

                                    case 1:
                                        rectangle.X = 0x36;
                                        rectangle.Y = 0x120;
                                        break;

                                    case 2:
                                        rectangle.X = 0x48;
                                        rectangle.Y = 0x120;
                                        break;
                                }
                            }
                            else if ((((num4 != num33) && (num4 != type)) && ((num5 == num33) || (num5 == type))) && ((num2 == num33) && (num7 == num33)))
                            {
                                switch (frameNumber)
                                {
                                    case 0:
                                        rectangle.X = 0;
                                        rectangle.Y = 270;
                                        break;

                                    case 1:
                                        rectangle.X = 0;
                                        rectangle.Y = 0x120;
                                        break;

                                    case 2:
                                        rectangle.X = 0;
                                        rectangle.Y = 0x132;
                                        break;
                                }
                            }
                            else if ((((num5 != num33) && (num5 != type)) && ((num4 == num33) || (num4 == type))) && ((num2 == num33) && (num7 == num33)))
                            {
                                switch (frameNumber)
                                {
                                    case 0:
                                        rectangle.X = 0x12;
                                        rectangle.Y = 270;
                                        break;

                                    case 1:
                                        rectangle.X = 0x12;
                                        rectangle.Y = 0x120;
                                        break;

                                    case 2:
                                        rectangle.X = 0x12;
                                        rectangle.Y = 0x132;
                                        break;
                                }
                            }
                            else if (((num2 == type) && (num7 == num33)) && ((num4 == num33) && (num5 == num33)))
                            {
                                switch (frameNumber)
                                {
                                    case 0:
                                        rectangle.X = 0xc6;
                                        rectangle.Y = 0x120;
                                        break;

                                    case 1:
                                        rectangle.X = 0xd8;
                                        rectangle.Y = 0x120;
                                        break;

                                    case 2:
                                        rectangle.X = 0xea;
                                        rectangle.Y = 0x120;
                                        break;
                                }
                            }
                            else if (((num2 == num33) && (num7 == type)) && ((num4 == num33) && (num5 == num33)))
                            {
                                switch (frameNumber)
                                {
                                    case 0:
                                        rectangle.X = 0xc6;
                                        rectangle.Y = 270;
                                        break;

                                    case 1:
                                        rectangle.X = 0xd8;
                                        rectangle.Y = 270;
                                        break;

                                    case 2:
                                        rectangle.X = 0xea;
                                        rectangle.Y = 270;
                                        break;
                                }
                            }
                            else if (((num2 == num33) && (num7 == num33)) && ((num4 == type) && (num5 == num33)))
                            {
                                switch (frameNumber)
                                {
                                    case 0:
                                        rectangle.X = 0xc6;
                                        rectangle.Y = 0x132;
                                        break;

                                    case 1:
                                        rectangle.X = 0xd8;
                                        rectangle.Y = 0x132;
                                        break;

                                    case 2:
                                        rectangle.X = 0xea;
                                        rectangle.Y = 0x132;
                                        break;
                                }
                            }
                            else if (((num2 == num33) && (num7 == num33)) && ((num4 == num33) && (num5 == type)))
                            {
                                switch (frameNumber)
                                {
                                    case 0:
                                        rectangle.X = 0x90;
                                        rectangle.Y = 0x132;
                                        break;

                                    case 1:
                                        rectangle.X = 0xa2;
                                        rectangle.Y = 0x132;
                                        break;

                                    case 2:
                                        rectangle.X = 180;
                                        rectangle.Y = 0x132;
                                        break;
                                }
                            }
                            if ((((num2 != type) && (num2 != num33)) && ((num7 == type) && (num4 == type))) && (num5 == type))
                            {
                                if (((num6 == num33) || (num6 == type)) && ((num8 != num33) && (num8 != type)))
                                {
                                    switch (frameNumber)
                                    {
                                        case 0:
                                            rectangle.X = 0;
                                            rectangle.Y = 0x144;
                                            break;

                                        case 1:
                                            rectangle.X = 0x12;
                                            rectangle.Y = 0x144;
                                            break;

                                        case 2:
                                            rectangle.X = 0x24;
                                            rectangle.Y = 0x144;
                                            break;
                                    }
                                }
                                else if (((num8 == num33) || (num8 == type)) && ((num6 != num33) && (num6 != type)))
                                {
                                    switch (frameNumber)
                                    {
                                        case 0:
                                            rectangle.X = 0x36;
                                            rectangle.Y = 0x144;
                                            break;

                                        case 1:
                                            rectangle.X = 0x48;
                                            rectangle.Y = 0x144;
                                            break;

                                        case 2:
                                            rectangle.X = 90;
                                            rectangle.Y = 0x144;
                                            break;
                                    }
                                }
                            }
                            else if ((((num7 != type) && (num7 != num33)) && ((num2 == type) && (num4 == type))) && (num5 == type))
                            {
                                if (((index == num33) || (index == type)) && ((num3 != num33) && (num3 != type)))
                                {
                                    switch (frameNumber)
                                    {
                                        case 0:
                                            rectangle.X = 0;
                                            rectangle.Y = 0x156;
                                            break;

                                        case 1:
                                            rectangle.X = 0x12;
                                            rectangle.Y = 0x156;
                                            break;

                                        case 2:
                                            rectangle.X = 0x24;
                                            rectangle.Y = 0x156;
                                            break;
                                    }
                                }
                                else if (((num3 == num33) || (num3 == type)) && ((index != num33) && (index != type)))
                                {
                                    switch (frameNumber)
                                    {
                                        case 0:
                                            rectangle.X = 0x36;
                                            rectangle.Y = 0x156;
                                            break;

                                        case 1:
                                            rectangle.X = 0x48;
                                            rectangle.Y = 0x156;
                                            break;

                                        case 2:
                                            rectangle.X = 90;
                                            rectangle.Y = 0x156;
                                            break;
                                    }
                                }
                            }
                            else if ((((num4 != type) && (num4 != num33)) && ((num2 == type) && (num7 == type))) && (num5 == type))
                            {
                                if (((num3 == num33) || (num3 == type)) && ((num8 != num33) && (num8 != type)))
                                {
                                    switch (frameNumber)
                                    {
                                        case 0:
                                            rectangle.X = 0x36;
                                            rectangle.Y = 360;
                                            break;

                                        case 1:
                                            rectangle.X = 0x48;
                                            rectangle.Y = 360;
                                            break;

                                        case 2:
                                            rectangle.X = 90;
                                            rectangle.Y = 360;
                                            break;
                                    }
                                }
                                else if (((num8 == num33) || (num8 == type)) && ((num3 != num33) && (num3 != type)))
                                {
                                    switch (frameNumber)
                                    {
                                        case 0:
                                            rectangle.X = 0;
                                            rectangle.Y = 360;
                                            break;

                                        case 1:
                                            rectangle.X = 0x12;
                                            rectangle.Y = 360;
                                            break;

                                        case 2:
                                            rectangle.X = 0x24;
                                            rectangle.Y = 360;
                                            break;
                                    }
                                }
                            }
                            else if ((((num5 != type) && (num5 != num33)) && ((num2 == type) && (num7 == type))) && (num4 == type))
                            {
                                if (((index == num33) || (index == type)) && ((num6 != num33) && (num6 != type)))
                                {
                                    switch (frameNumber)
                                    {
                                        case 0:
                                            rectangle.X = 0;
                                            rectangle.Y = 0x17a;
                                            break;

                                        case 1:
                                            rectangle.X = 0x12;
                                            rectangle.Y = 0x17a;
                                            break;

                                        case 2:
                                            rectangle.X = 0x24;
                                            rectangle.Y = 0x17a;
                                            break;
                                    }
                                }
                                else if (((num6 == num33) || (num6 == type)) && ((index != num33) && (index != type)))
                                {
                                    switch (frameNumber)
                                    {
                                        case 0:
                                            rectangle.X = 0x36;
                                            rectangle.Y = 0x17a;
                                            break;

                                        case 1:
                                            rectangle.X = 0x48;
                                            rectangle.Y = 0x17a;
                                            break;

                                        case 2:
                                            rectangle.X = 90;
                                            rectangle.Y = 0x17a;
                                            break;
                                    }
                                }
                            }
                            if (((((num2 == type) || (num2 == num33)) && ((num7 == type) || (num7 == num33))) && (((num4 == type) || (num4 == num33)) && ((num5 == type) || (num5 == num33)))) && (((index != -1) && (num3 != -1)) && ((num6 != -1) && (num8 != -1))))
                            {
                                switch (frameNumber)
                                {
                                    case 0:
                                        rectangle.X = 0x12;
                                        rectangle.Y = 0x12;
                                        break;

                                    case 1:
                                        rectangle.X = 0x24;
                                        rectangle.Y = 0x12;
                                        break;

                                    case 2:
                                        rectangle.X = 0x36;
                                        rectangle.Y = 0x12;
                                        break;
                                }
                            }
                            if (num2 == num33)
                            {
                                num2 = -2;
                            }
                            if (num7 == num33)
                            {
                                num7 = -2;
                            }
                            if (num4 == num33)
                            {
                                num4 = -2;
                            }
                            if (num5 == num33)
                            {
                                num5 = -2;
                            }
                            if (index == num33)
                            {
                                index = -2;
                            }
                            if (num3 == num33)
                            {
                                num3 = -2;
                            }
                            if (num6 == num33)
                            {
                                num6 = -2;
                            }
                            if (num8 == num33)
                            {
                                num8 = -2;
                            }
                        }
                        if ((((((type == 1) || (type == 2)) || ((type == 6) || (type == 7))) || (((type == 8) || (type == 9)) || ((type == 0x16) || (type == 0x17)))) || ((((type == 0x19) || (type == 0x25)) || ((type == 40) || (type == 0x35))) || (((type == 0x38) || (type == 0x3a)) || (((type == 0x3b) || (type == 60)) || (type == 70))))) && ((rectangle.X == -1) && (rectangle.Y == -1)))
                        {
                            if ((num2 >= 0) && (num2 != type))
                            {
                                num2 = -1;
                            }
                            if ((num7 >= 0) && (num7 != type))
                            {
                                num7 = -1;
                            }
                            if ((num4 >= 0) && (num4 != type))
                            {
                                num4 = -1;
                            }
                            if ((num5 >= 0) && (num5 != type))
                            {
                                num5 = -1;
                            }
                            if (((num2 != -1) && (num7 != -1)) && ((num4 != -1) && (num5 != -1)))
                            {
                                if (((num2 == -2) && (num7 == type)) && ((num4 == type) && (num5 == type)))
                                {
                                    switch (frameNumber)
                                    {
                                        case 0:
                                            rectangle.X = 0x90;
                                            rectangle.Y = 0x6c;
                                            break;

                                        case 1:
                                            rectangle.X = 0xa2;
                                            rectangle.Y = 0x6c;
                                            break;

                                        case 2:
                                            rectangle.X = 180;
                                            rectangle.Y = 0x6c;
                                            break;
                                    }
                                    WorldGen.mergeUp = true;
                                }
                                else if (((num2 == type) && (num7 == -2)) && ((num4 == type) && (num5 == type)))
                                {
                                    switch (frameNumber)
                                    {
                                        case 0:
                                            rectangle.X = 0x90;
                                            rectangle.Y = 90;
                                            break;

                                        case 1:
                                            rectangle.X = 0xa2;
                                            rectangle.Y = 90;
                                            break;

                                        case 2:
                                            rectangle.X = 180;
                                            rectangle.Y = 90;
                                            break;
                                    }
                                    WorldGen.mergeDown = true;
                                }
                                else if (((num2 == type) && (num7 == type)) && ((num4 == -2) && (num5 == type)))
                                {
                                    switch (frameNumber)
                                    {
                                        case 0:
                                            rectangle.X = 0xa2;
                                            rectangle.Y = 0x7e;
                                            break;

                                        case 1:
                                            rectangle.X = 0xa2;
                                            rectangle.Y = 0x90;
                                            break;

                                        case 2:
                                            rectangle.X = 0xa2;
                                            rectangle.Y = 0xa2;
                                            break;
                                    }
                                    WorldGen.mergeLeft = true;
                                }
                                else if (((num2 == type) && (num7 == type)) && ((num4 == type) && (num5 == -2)))
                                {
                                    switch (frameNumber)
                                    {
                                        case 0:
                                            rectangle.X = 0x90;
                                            rectangle.Y = 0x7e;
                                            break;

                                        case 1:
                                            rectangle.X = 0x90;
                                            rectangle.Y = 0x90;
                                            break;

                                        case 2:
                                            rectangle.X = 0x90;
                                            rectangle.Y = 0xa2;
                                            break;
                                    }
                                    WorldGen.mergeRight = true;
                                }
                                else if (((num2 == -2) && (num7 == type)) && ((num4 == -2) && (num5 == type)))
                                {
                                    switch (frameNumber)
                                    {
                                        case 0:
                                            rectangle.X = 0x24;
                                            rectangle.Y = 90;
                                            break;

                                        case 1:
                                            rectangle.X = 0x24;
                                            rectangle.Y = 0x7e;
                                            break;

                                        case 2:
                                            rectangle.X = 0x24;
                                            rectangle.Y = 0xa2;
                                            break;
                                    }
                                    WorldGen.mergeUp = true;
                                    WorldGen.mergeLeft = true;
                                }
                                else if (((num2 == -2) && (num7 == type)) && ((num4 == type) && (num5 == -2)))
                                {
                                    switch (frameNumber)
                                    {
                                        case 0:
                                            rectangle.X = 0x36;
                                            rectangle.Y = 90;
                                            break;

                                        case 1:
                                            rectangle.X = 0x36;
                                            rectangle.Y = 0x7e;
                                            break;

                                        case 2:
                                            rectangle.X = 0x36;
                                            rectangle.Y = 0xa2;
                                            break;
                                    }
                                    WorldGen.mergeUp = true;
                                    WorldGen.mergeRight = true;
                                }
                                else if (((num2 == type) && (num7 == -2)) && ((num4 == -2) && (num5 == type)))
                                {
                                    switch (frameNumber)
                                    {
                                        case 0:
                                            rectangle.X = 0x24;
                                            rectangle.Y = 0x6c;
                                            break;

                                        case 1:
                                            rectangle.X = 0x24;
                                            rectangle.Y = 0x90;
                                            break;

                                        case 2:
                                            rectangle.X = 0x24;
                                            rectangle.Y = 180;
                                            break;
                                    }
                                    WorldGen.mergeDown = true;
                                    WorldGen.mergeLeft = true;
                                }
                                else if (((num2 == type) && (num7 == -2)) && ((num4 == type) && (num5 == -2)))
                                {
                                    switch (frameNumber)
                                    {
                                        case 0:
                                            rectangle.X = 0x36;
                                            rectangle.Y = 0x6c;
                                            break;

                                        case 1:
                                            rectangle.X = 0x36;
                                            rectangle.Y = 0x90;
                                            break;

                                        case 2:
                                            rectangle.X = 0x36;
                                            rectangle.Y = 180;
                                            break;
                                    }
                                    WorldGen.mergeDown = true;
                                    WorldGen.mergeRight = true;
                                }
                                else if (((num2 == type) && (num7 == type)) && ((num4 == -2) && (num5 == -2)))
                                {
                                    switch (frameNumber)
                                    {
                                        case 0:
                                            rectangle.X = 180;
                                            rectangle.Y = 0x7e;
                                            break;

                                        case 1:
                                            rectangle.X = 180;
                                            rectangle.Y = 0x90;
                                            break;

                                        case 2:
                                            rectangle.X = 180;
                                            rectangle.Y = 0xa2;
                                            break;
                                    }
                                    WorldGen.mergeLeft = true;
                                    WorldGen.mergeRight = true;
                                }
                                else if (((num2 == -2) && (num7 == -2)) && ((num4 == type) && (num5 == type)))
                                {
                                    switch (frameNumber)
                                    {
                                        case 0:
                                            rectangle.X = 0x90;
                                            rectangle.Y = 180;
                                            break;

                                        case 1:
                                            rectangle.X = 0xa2;
                                            rectangle.Y = 180;
                                            break;

                                        case 2:
                                            rectangle.X = 180;
                                            rectangle.Y = 180;
                                            break;
                                    }
                                    WorldGen.mergeUp = true;
                                    WorldGen.mergeDown = true;
                                }
                                else if (((num2 == -2) && (num7 == type)) && ((num4 == -2) && (num5 == -2)))
                                {
                                    switch (frameNumber)
                                    {
                                        case 0:
                                            rectangle.X = 0xc6;
                                            rectangle.Y = 90;
                                            break;

                                        case 1:
                                            rectangle.X = 0xc6;
                                            rectangle.Y = 0x6c;
                                            break;

                                        case 2:
                                            rectangle.X = 0xc6;
                                            rectangle.Y = 0x7e;
                                            break;
                                    }
                                    WorldGen.mergeUp = true;
                                    WorldGen.mergeLeft = true;
                                    WorldGen.mergeRight = true;
                                }
                                else if (((num2 == type) && (num7 == -2)) && ((num4 == -2) && (num5 == -2)))
                                {
                                    switch (frameNumber)
                                    {
                                        case 0:
                                            rectangle.X = 0xc6;
                                            rectangle.Y = 0x90;
                                            break;

                                        case 1:
                                            rectangle.X = 0xc6;
                                            rectangle.Y = 0xa2;
                                            break;

                                        case 2:
                                            rectangle.X = 0xc6;
                                            rectangle.Y = 180;
                                            break;
                                    }
                                    WorldGen.mergeDown = true;
                                    WorldGen.mergeLeft = true;
                                    WorldGen.mergeRight = true;
                                }
                                else if (((num2 == -2) && (num7 == -2)) && ((num4 == type) && (num5 == -2)))
                                {
                                    switch (frameNumber)
                                    {
                                        case 0:
                                            rectangle.X = 0xd8;
                                            rectangle.Y = 0x90;
                                            break;

                                        case 1:
                                            rectangle.X = 0xd8;
                                            rectangle.Y = 0xa2;
                                            break;

                                        case 2:
                                            rectangle.X = 0xd8;
                                            rectangle.Y = 180;
                                            break;
                                    }
                                    WorldGen.mergeUp = true;
                                    WorldGen.mergeDown = true;
                                    WorldGen.mergeRight = true;
                                }
                                else if (((num2 == -2) && (num7 == -2)) && ((num4 == -2) && (num5 == type)))
                                {
                                    switch (frameNumber)
                                    {
                                        case 0:
                                            rectangle.X = 0xd8;
                                            rectangle.Y = 90;
                                            break;

                                        case 1:
                                            rectangle.X = 0xd8;
                                            rectangle.Y = 0x6c;
                                            break;

                                        case 2:
                                            rectangle.X = 0xd8;
                                            rectangle.Y = 0x7e;
                                            break;
                                    }
                                    WorldGen.mergeUp = true;
                                    WorldGen.mergeDown = true;
                                    WorldGen.mergeLeft = true;
                                }
                                else if (((num2 == -2) && (num7 == -2)) && ((num4 == -2) && (num5 == -2)))
                                {
                                    switch (frameNumber)
                                    {
                                        case 0:
                                            rectangle.X = 0x6c;
                                            rectangle.Y = 0xc6;
                                            break;

                                        case 1:
                                            rectangle.X = 0x7e;
                                            rectangle.Y = 0xc6;
                                            break;

                                        case 2:
                                            rectangle.X = 0x90;
                                            rectangle.Y = 0xc6;
                                            break;
                                    }
                                    WorldGen.mergeUp = true;
                                    WorldGen.mergeDown = true;
                                    WorldGen.mergeLeft = true;
                                    WorldGen.mergeRight = true;
                                }
                                else if (((num2 == type) && (num7 == type)) && ((num4 == type) && (num5 == type)))
                                {
                                    if (index == -2)
                                    {
                                        switch (frameNumber)
                                        {
                                            case 0:
                                                rectangle.X = 0x12;
                                                rectangle.Y = 0x6c;
                                                break;

                                            case 1:
                                                rectangle.X = 0x12;
                                                rectangle.Y = 0x90;
                                                break;

                                            case 2:
                                                rectangle.X = 0x12;
                                                rectangle.Y = 180;
                                                break;
                                        }
                                    }
                                    if (num3 == -2)
                                    {
                                        switch (frameNumber)
                                        {
                                            case 0:
                                                rectangle.X = 0;
                                                rectangle.Y = 0x6c;
                                                break;

                                            case 1:
                                                rectangle.X = 0;
                                                rectangle.Y = 0x90;
                                                break;

                                            case 2:
                                                rectangle.X = 0;
                                                rectangle.Y = 180;
                                                break;
                                        }
                                    }
                                    if (num6 == -2)
                                    {
                                        switch (frameNumber)
                                        {
                                            case 0:
                                                rectangle.X = 0x12;
                                                rectangle.Y = 90;
                                                break;

                                            case 1:
                                                rectangle.X = 0x12;
                                                rectangle.Y = 0x7e;
                                                break;

                                            case 2:
                                                rectangle.X = 0x12;
                                                rectangle.Y = 0xa2;
                                                break;
                                        }
                                    }
                                    if (num8 == -2)
                                    {
                                        switch (frameNumber)
                                        {
                                            case 0:
                                                rectangle.X = 0;
                                                rectangle.Y = 90;
                                                break;

                                            case 1:
                                                rectangle.X = 0;
                                                rectangle.Y = 0x7e;
                                                break;

                                            case 2:
                                                rectangle.X = 0;
                                                rectangle.Y = 0xa2;
                                                break;
                                        }
                                    }
                                }
                            }
                            else
                            {
                                if (((type != 2) && (type != 0x17)) && ((type != 60) && (type != 70)))
                                {
                                    if (((num2 == -1) && (num7 == -2)) && ((num4 == type) && (num5 == type)))
                                    {
                                        switch (frameNumber)
                                        {
                                            case 0:
                                                rectangle.X = 0xea;
                                                rectangle.Y = 0;
                                                break;

                                            case 1:
                                                rectangle.X = 0xfc;
                                                rectangle.Y = 0;
                                                break;

                                            case 2:
                                                rectangle.X = 270;
                                                rectangle.Y = 0;
                                                break;
                                        }
                                        WorldGen.mergeDown = true;
                                    }
                                    else if (((num2 == -2) && (num7 == -1)) && ((num4 == type) && (num5 == type)))
                                    {
                                        switch (frameNumber)
                                        {
                                            case 0:
                                                rectangle.X = 0xea;
                                                rectangle.Y = 0x12;
                                                break;

                                            case 1:
                                                rectangle.X = 0xfc;
                                                rectangle.Y = 0x12;
                                                break;

                                            case 2:
                                                rectangle.X = 270;
                                                rectangle.Y = 0x12;
                                                break;
                                        }
                                        WorldGen.mergeUp = true;
                                    }
                                    else if (((num2 == type) && (num7 == type)) && ((num4 == -1) && (num5 == -2)))
                                    {
                                        switch (frameNumber)
                                        {
                                            case 0:
                                                rectangle.X = 0xea;
                                                rectangle.Y = 0x24;
                                                break;

                                            case 1:
                                                rectangle.X = 0xfc;
                                                rectangle.Y = 0x24;
                                                break;

                                            case 2:
                                                rectangle.X = 270;
                                                rectangle.Y = 0x24;
                                                break;
                                        }
                                        WorldGen.mergeRight = true;
                                    }
                                    else if (((num2 == type) && (num7 == type)) && ((num4 == -2) && (num5 == -1)))
                                    {
                                        switch (frameNumber)
                                        {
                                            case 0:
                                                rectangle.X = 0xea;
                                                rectangle.Y = 0x36;
                                                break;

                                            case 1:
                                                rectangle.X = 0xfc;
                                                rectangle.Y = 0x36;
                                                break;

                                            case 2:
                                                rectangle.X = 270;
                                                rectangle.Y = 0x36;
                                                break;
                                        }
                                        WorldGen.mergeLeft = true;
                                    }
                                }
                                if (((num2 != -1) && (num7 != -1)) && ((num4 == -1) && (num5 == type)))
                                {
                                    if ((num2 == -2) && (num7 == type))
                                    {
                                        switch (frameNumber)
                                        {
                                            case 0:
                                                rectangle.X = 0x48;
                                                rectangle.Y = 0x90;
                                                break;

                                            case 1:
                                                rectangle.X = 0x48;
                                                rectangle.Y = 0xa2;
                                                break;

                                            case 2:
                                                rectangle.X = 0x48;
                                                rectangle.Y = 180;
                                                break;
                                        }
                                        WorldGen.mergeUp = true;
                                    }
                                    else if ((num7 == -2) && (num2 == type))
                                    {
                                        switch (frameNumber)
                                        {
                                            case 0:
                                                rectangle.X = 0x48;
                                                rectangle.Y = 90;
                                                break;

                                            case 1:
                                                rectangle.X = 0x48;
                                                rectangle.Y = 0x6c;
                                                break;

                                            case 2:
                                                rectangle.X = 0x48;
                                                rectangle.Y = 0x7e;
                                                break;
                                        }
                                        WorldGen.mergeDown = true;
                                    }
                                }
                                else if (((num2 != -1) && (num7 != -1)) && ((num4 == type) && (num5 == -1)))
                                {
                                    if ((num2 == -2) && (num7 == type))
                                    {
                                        switch (frameNumber)
                                        {
                                            case 0:
                                                rectangle.X = 90;
                                                rectangle.Y = 0x90;
                                                break;

                                            case 1:
                                                rectangle.X = 90;
                                                rectangle.Y = 0xa2;
                                                break;

                                            case 2:
                                                rectangle.X = 90;
                                                rectangle.Y = 180;
                                                break;
                                        }
                                        WorldGen.mergeUp = true;
                                    }
                                    else if ((num7 == -2) && (num2 == type))
                                    {
                                        switch (frameNumber)
                                        {
                                            case 0:
                                                rectangle.X = 90;
                                                rectangle.Y = 90;
                                                break;

                                            case 1:
                                                rectangle.X = 90;
                                                rectangle.Y = 0x6c;
                                                break;

                                            case 2:
                                                rectangle.X = 90;
                                                rectangle.Y = 0x7e;
                                                break;
                                        }
                                        WorldGen.mergeDown = true;
                                    }
                                }
                                else if (((num2 == -1) && (num7 == type)) && ((num4 != -1) && (num5 != -1)))
                                {
                                    if ((num4 == -2) && (num5 == type))
                                    {
                                        switch (frameNumber)
                                        {
                                            case 0:
                                                rectangle.X = 0;
                                                rectangle.Y = 0xc6;
                                                break;

                                            case 1:
                                                rectangle.X = 0x12;
                                                rectangle.Y = 0xc6;
                                                break;

                                            case 2:
                                                rectangle.X = 0x24;
                                                rectangle.Y = 0xc6;
                                                break;
                                        }
                                        WorldGen.mergeLeft = true;
                                    }
                                    else if ((num5 == -2) && (num4 == type))
                                    {
                                        switch (frameNumber)
                                        {
                                            case 0:
                                                rectangle.X = 0x36;
                                                rectangle.Y = 0xc6;
                                                break;

                                            case 1:
                                                rectangle.X = 0x48;
                                                rectangle.Y = 0xc6;
                                                break;

                                            case 2:
                                                rectangle.X = 90;
                                                rectangle.Y = 0xc6;
                                                break;
                                        }
                                        WorldGen.mergeRight = true;
                                    }
                                }
                                else if (((num2 == type) && (num7 == -1)) && ((num4 != -1) && (num5 != -1)))
                                {
                                    if ((num4 == -2) && (num5 == type))
                                    {
                                        switch (frameNumber)
                                        {
                                            case 0:
                                                rectangle.X = 0;
                                                rectangle.Y = 0xd8;
                                                break;

                                            case 1:
                                                rectangle.X = 0x12;
                                                rectangle.Y = 0xd8;
                                                break;

                                            case 2:
                                                rectangle.X = 0x24;
                                                rectangle.Y = 0xd8;
                                                break;
                                        }
                                        WorldGen.mergeLeft = true;
                                    }
                                    else if ((num5 == -2) && (num4 == type))
                                    {
                                        switch (frameNumber)
                                        {
                                            case 0:
                                                rectangle.X = 0x36;
                                                rectangle.Y = 0xd8;
                                                break;

                                            case 1:
                                                rectangle.X = 0x48;
                                                rectangle.Y = 0xd8;
                                                break;

                                            case 2:
                                                rectangle.X = 90;
                                                rectangle.Y = 0xd8;
                                                break;
                                        }
                                        WorldGen.mergeRight = true;
                                    }
                                }
                                else if (((num2 != -1) && (num7 != -1)) && ((num4 == -1) && (num5 == -1)))
                                {
                                    if ((num2 == -2) && (num7 == -2))
                                    {
                                        switch (frameNumber)
                                        {
                                            case 0:
                                                rectangle.X = 0x6c;
                                                rectangle.Y = 0xd8;
                                                break;

                                            case 1:
                                                rectangle.X = 0x6c;
                                                rectangle.Y = 0xea;
                                                break;

                                            case 2:
                                                rectangle.X = 0x6c;
                                                rectangle.Y = 0xfc;
                                                break;
                                        }
                                        WorldGen.mergeUp = true;
                                        WorldGen.mergeDown = true;
                                    }
                                    else if (num2 == -2)
                                    {
                                        switch (frameNumber)
                                        {
                                            case 0:
                                                rectangle.X = 0x7e;
                                                rectangle.Y = 0x90;
                                                break;

                                            case 1:
                                                rectangle.X = 0x7e;
                                                rectangle.Y = 0xa2;
                                                break;

                                            case 2:
                                                rectangle.X = 0x7e;
                                                rectangle.Y = 180;
                                                break;
                                        }
                                        WorldGen.mergeUp = true;
                                    }
                                    else if (num7 == -2)
                                    {
                                        switch (frameNumber)
                                        {
                                            case 0:
                                                rectangle.X = 0x7e;
                                                rectangle.Y = 90;
                                                break;

                                            case 1:
                                                rectangle.X = 0x7e;
                                                rectangle.Y = 0x6c;
                                                break;

                                            case 2:
                                                rectangle.X = 0x7e;
                                                rectangle.Y = 0x7e;
                                                break;
                                        }
                                        WorldGen.mergeDown = true;
                                    }
                                }
                                else if (((num2 == -1) && (num7 == -1)) && ((num4 != -1) && (num5 != -1)))
                                {
                                    if ((num4 == -2) && (num5 == -2))
                                    {
                                        switch (frameNumber)
                                        {
                                            case 0:
                                                rectangle.X = 0xa2;
                                                rectangle.Y = 0xc6;
                                                break;

                                            case 1:
                                                rectangle.X = 180;
                                                rectangle.Y = 0xc6;
                                                break;

                                            case 2:
                                                rectangle.X = 0xc6;
                                                rectangle.Y = 0xc6;
                                                break;
                                        }
                                        WorldGen.mergeLeft = true;
                                        WorldGen.mergeRight = true;
                                    }
                                    else if (num4 == -2)
                                    {
                                        switch (frameNumber)
                                        {
                                            case 0:
                                                rectangle.X = 0;
                                                rectangle.Y = 0xfc;
                                                break;

                                            case 1:
                                                rectangle.X = 0x12;
                                                rectangle.Y = 0xfc;
                                                break;

                                            case 2:
                                                rectangle.X = 0x24;
                                                rectangle.Y = 0xfc;
                                                break;
                                        }
                                        WorldGen.mergeLeft = true;
                                    }
                                    else if (num5 == -2)
                                    {
                                        switch (frameNumber)
                                        {
                                            case 0:
                                                rectangle.X = 0x36;
                                                rectangle.Y = 0xfc;
                                                break;

                                            case 1:
                                                rectangle.X = 0x48;
                                                rectangle.Y = 0xfc;
                                                break;

                                            case 2:
                                                rectangle.X = 90;
                                                rectangle.Y = 0xfc;
                                                break;
                                        }
                                        WorldGen.mergeRight = true;
                                    }
                                }
                                else if (((num2 == -2) && (num7 == -1)) && ((num4 == -1) && (num5 == -1)))
                                {
                                    switch (frameNumber)
                                    {
                                        case 0:
                                            rectangle.X = 0x6c;
                                            rectangle.Y = 0x90;
                                            break;

                                        case 1:
                                            rectangle.X = 0x6c;
                                            rectangle.Y = 0xa2;
                                            break;

                                        case 2:
                                            rectangle.X = 0x6c;
                                            rectangle.Y = 180;
                                            break;
                                    }
                                    WorldGen.mergeUp = true;
                                }
                                else if (((num2 == -1) && (num7 == -2)) && ((num4 == -1) && (num5 == -1)))
                                {
                                    switch (frameNumber)
                                    {
                                        case 0:
                                            rectangle.X = 0x6c;
                                            rectangle.Y = 90;
                                            break;

                                        case 1:
                                            rectangle.X = 0x6c;
                                            rectangle.Y = 0x6c;
                                            break;

                                        case 2:
                                            rectangle.X = 0x6c;
                                            rectangle.Y = 0x7e;
                                            break;
                                    }
                                    WorldGen.mergeDown = true;
                                }
                                else if (((num2 == -1) && (num7 == -1)) && ((num4 == -2) && (num5 == -1)))
                                {
                                    switch (frameNumber)
                                    {
                                        case 0:
                                            rectangle.X = 0;
                                            rectangle.Y = 0xea;
                                            break;

                                        case 1:
                                            rectangle.X = 0x12;
                                            rectangle.Y = 0xea;
                                            break;

                                        case 2:
                                            rectangle.X = 0x24;
                                            rectangle.Y = 0xea;
                                            break;
                                    }
                                    WorldGen.mergeLeft = true;
                                }
                                else if (((num2 == -1) && (num7 == -1)) && ((num4 == -1) && (num5 == -2)))
                                {
                                    switch (frameNumber)
                                    {
                                        case 0:
                                            rectangle.X = 0x36;
                                            rectangle.Y = 0xea;
                                            break;

                                        case 1:
                                            rectangle.X = 0x48;
                                            rectangle.Y = 0xea;
                                            break;

                                        case 2:
                                            rectangle.X = 90;
                                            rectangle.Y = 0xea;
                                            break;
                                    }
                                    WorldGen.mergeRight = true;
                                }
                            }
                        }
                        if ((rectangle.X < 0) || (rectangle.Y < 0))
                        {
                            if (((type == 2) || (type == 0x17)) || ((type == 60) || (type == 70)))
                            {
                                if (num2 == -2)
                                {
                                    num2 = type;
                                }
                                if (num7 == -2)
                                {
                                    num7 = type;
                                }
                                if (num4 == -2)
                                {
                                    num4 = type;
                                }
                                if (num5 == -2)
                                {
                                    num5 = type;
                                }
                                if (index == -2)
                                {
                                    index = type;
                                }
                                if (num3 == -2)
                                {
                                    num3 = type;
                                }
                                if (num6 == -2)
                                {
                                    num6 = type;
                                }
                                if (num8 == -2)
                                {
                                    num8 = type;
                                }
                            }
                            if (((num2 == type) && (num7 == type)) && ((num4 == type) & (num5 == type)))
                            {
                                if ((index != type) && (num3 != type))
                                {
                                    switch (frameNumber)
                                    {
                                        case 0:
                                            rectangle.X = 0x6c;
                                            rectangle.Y = 0x12;
                                            break;

                                        case 1:
                                            rectangle.X = 0x7e;
                                            rectangle.Y = 0x12;
                                            break;

                                        case 2:
                                            rectangle.X = 0x90;
                                            rectangle.Y = 0x12;
                                            break;
                                    }
                                }
                                else if ((num6 != type) && (num8 != type))
                                {
                                    switch (frameNumber)
                                    {
                                        case 0:
                                            rectangle.X = 0x6c;
                                            rectangle.Y = 0x24;
                                            break;

                                        case 1:
                                            rectangle.X = 0x7e;
                                            rectangle.Y = 0x24;
                                            break;

                                        case 2:
                                            rectangle.X = 0x90;
                                            rectangle.Y = 0x24;
                                            break;
                                    }
                                }
                                else if ((index != type) && (num6 != type))
                                {
                                    switch (frameNumber)
                                    {
                                        case 0:
                                            rectangle.X = 180;
                                            rectangle.Y = 0;
                                            break;

                                        case 1:
                                            rectangle.X = 180;
                                            rectangle.Y = 0x12;
                                            break;

                                        case 2:
                                            rectangle.X = 180;
                                            rectangle.Y = 0x24;
                                            break;
                                    }
                                }
                                else if ((num3 != type) && (num8 != type))
                                {
                                    switch (frameNumber)
                                    {
                                        case 0:
                                            rectangle.X = 0xc6;
                                            rectangle.Y = 0;
                                            break;

                                        case 1:
                                            rectangle.X = 0xc6;
                                            rectangle.Y = 0x12;
                                            break;

                                        case 2:
                                            rectangle.X = 0xc6;
                                            rectangle.Y = 0x24;
                                            break;
                                    }
                                }
                                else
                                {
                                    switch (frameNumber)
                                    {
                                        case 0:
                                            rectangle.X = 0x12;
                                            rectangle.Y = 0x12;
                                            break;

                                        case 1:
                                            rectangle.X = 0x24;
                                            rectangle.Y = 0x12;
                                            break;

                                        case 2:
                                            rectangle.X = 0x36;
                                            rectangle.Y = 0x12;
                                            break;
                                    }
                                }
                            }
                            else if (((num2 != type) && (num7 == type)) && ((num4 == type) & (num5 == type)))
                            {
                                switch (frameNumber)
                                {
                                    case 0:
                                        rectangle.X = 0x12;
                                        rectangle.Y = 0;
                                        break;

                                    case 1:
                                        rectangle.X = 0x24;
                                        rectangle.Y = 0;
                                        break;

                                    case 2:
                                        rectangle.X = 0x36;
                                        rectangle.Y = 0;
                                        break;
                                }
                            }
                            else if (((num2 == type) && (num7 != type)) && ((num4 == type) & (num5 == type)))
                            {
                                switch (frameNumber)
                                {
                                    case 0:
                                        rectangle.X = 0x12;
                                        rectangle.Y = 0x24;
                                        break;

                                    case 1:
                                        rectangle.X = 0x24;
                                        rectangle.Y = 0x24;
                                        break;

                                    case 2:
                                        rectangle.X = 0x36;
                                        rectangle.Y = 0x24;
                                        break;
                                }
                            }
                            else if (((num2 == type) && (num7 == type)) && ((num4 != type) & (num5 == type)))
                            {
                                switch (frameNumber)
                                {
                                    case 0:
                                        rectangle.X = 0;
                                        rectangle.Y = 0;
                                        break;

                                    case 1:
                                        rectangle.X = 0;
                                        rectangle.Y = 0x12;
                                        break;

                                    case 2:
                                        rectangle.X = 0;
                                        rectangle.Y = 0x24;
                                        break;
                                }
                            }
                            else if (((num2 == type) && (num7 == type)) && ((num4 == type) & (num5 != type)))
                            {
                                switch (frameNumber)
                                {
                                    case 0:
                                        rectangle.X = 0x48;
                                        rectangle.Y = 0;
                                        break;

                                    case 1:
                                        rectangle.X = 0x48;
                                        rectangle.Y = 0x12;
                                        break;

                                    case 2:
                                        rectangle.X = 0x48;
                                        rectangle.Y = 0x24;
                                        break;
                                }
                            }
                            else if (((num2 != type) && (num7 == type)) && ((num4 != type) & (num5 == type)))
                            {
                                switch (frameNumber)
                                {
                                    case 0:
                                        rectangle.X = 0;
                                        rectangle.Y = 0x36;
                                        break;

                                    case 1:
                                        rectangle.X = 0x24;
                                        rectangle.Y = 0x36;
                                        break;

                                    case 2:
                                        rectangle.X = 0x48;
                                        rectangle.Y = 0x36;
                                        break;
                                }
                            }
                            else if (((num2 != type) && (num7 == type)) && ((num4 == type) & (num5 != type)))
                            {
                                switch (frameNumber)
                                {
                                    case 0:
                                        rectangle.X = 0x12;
                                        rectangle.Y = 0x36;
                                        break;

                                    case 1:
                                        rectangle.X = 0x36;
                                        rectangle.Y = 0x36;
                                        break;

                                    case 2:
                                        rectangle.X = 90;
                                        rectangle.Y = 0x36;
                                        break;
                                }
                            }
                            else if (((num2 == type) && (num7 != type)) && ((num4 != type) & (num5 == type)))
                            {
                                switch (frameNumber)
                                {
                                    case 0:
                                        rectangle.X = 0;
                                        rectangle.Y = 0x48;
                                        break;

                                    case 1:
                                        rectangle.X = 0x24;
                                        rectangle.Y = 0x48;
                                        break;

                                    case 2:
                                        rectangle.X = 0x48;
                                        rectangle.Y = 0x48;
                                        break;
                                }
                            }
                            else if (((num2 == type) && (num7 != type)) && ((num4 == type) & (num5 != type)))
                            {
                                switch (frameNumber)
                                {
                                    case 0:
                                        rectangle.X = 0x12;
                                        rectangle.Y = 0x48;
                                        break;

                                    case 1:
                                        rectangle.X = 0x36;
                                        rectangle.Y = 0x48;
                                        break;

                                    case 2:
                                        rectangle.X = 90;
                                        rectangle.Y = 0x48;
                                        break;
                                }
                            }
                            else if (((num2 == type) && (num7 == type)) && ((num4 != type) & (num5 != type)))
                            {
                                switch (frameNumber)
                                {
                                    case 0:
                                        rectangle.X = 90;
                                        rectangle.Y = 0;
                                        break;

                                    case 1:
                                        rectangle.X = 90;
                                        rectangle.Y = 0x12;
                                        break;

                                    case 2:
                                        rectangle.X = 90;
                                        rectangle.Y = 0x24;
                                        break;
                                }
                            }
                            else if (((num2 != type) && (num7 != type)) && ((num4 == type) & (num5 == type)))
                            {
                                switch (frameNumber)
                                {
                                    case 0:
                                        rectangle.X = 0x6c;
                                        rectangle.Y = 0x48;
                                        break;

                                    case 1:
                                        rectangle.X = 0x7e;
                                        rectangle.Y = 0x48;
                                        break;

                                    case 2:
                                        rectangle.X = 0x90;
                                        rectangle.Y = 0x48;
                                        break;
                                }
                            }
                            else if (((num2 != type) && (num7 == type)) && ((num4 != type) & (num5 != type)))
                            {
                                switch (frameNumber)
                                {
                                    case 0:
                                        rectangle.X = 0x6c;
                                        rectangle.Y = 0;
                                        break;

                                    case 1:
                                        rectangle.X = 0x7e;
                                        rectangle.Y = 0;
                                        break;

                                    case 2:
                                        rectangle.X = 0x90;
                                        rectangle.Y = 0;
                                        break;
                                }
                            }
                            else if (((num2 == type) && (num7 != type)) && ((num4 != type) & (num5 != type)))
                            {
                                switch (frameNumber)
                                {
                                    case 0:
                                        rectangle.X = 0x6c;
                                        rectangle.Y = 0x36;
                                        break;

                                    case 1:
                                        rectangle.X = 0x7e;
                                        rectangle.Y = 0x36;
                                        break;

                                    case 2:
                                        rectangle.X = 0x90;
                                        rectangle.Y = 0x36;
                                        break;
                                }
                            }
                            else if (((num2 != type) && (num7 != type)) && ((num4 != type) & (num5 == type)))
                            {
                                switch (frameNumber)
                                {
                                    case 0:
                                        rectangle.X = 0xa2;
                                        rectangle.Y = 0;
                                        break;

                                    case 1:
                                        rectangle.X = 0xa2;
                                        rectangle.Y = 0x12;
                                        break;

                                    case 2:
                                        rectangle.X = 0xa2;
                                        rectangle.Y = 0x24;
                                        break;
                                }
                            }
                            else if (((num2 != type) && (num7 != type)) && ((num4 == type) & (num5 != type)))
                            {
                                switch (frameNumber)
                                {
                                    case 0:
                                        rectangle.X = 0xd8;
                                        rectangle.Y = 0;
                                        break;

                                    case 1:
                                        rectangle.X = 0xd8;
                                        rectangle.Y = 0x12;
                                        break;

                                    case 2:
                                        rectangle.X = 0xd8;
                                        rectangle.Y = 0x24;
                                        break;
                                }
                            }
                            else if (((num2 != type) && (num7 != type)) && ((num4 != type) & (num5 != type)))
                            {
                                switch (frameNumber)
                                {
                                    case 0:
                                        rectangle.X = 0xa2;
                                        rectangle.Y = 0x36;
                                        break;

                                    case 1:
                                        rectangle.X = 180;
                                        rectangle.Y = 0x36;
                                        break;

                                    case 2:
                                        rectangle.X = 0xc6;
                                        rectangle.Y = 0x36;
                                        break;
                                }
                            }
                        }
                        if ((rectangle.X <= -1) || (rectangle.Y <= -1))
                        {
                            if (frameNumber <= 0)
                            {
                                rectangle.X = 0x12;
                                rectangle.Y = 0x12;
                            }
                            if (frameNumber == 1)
                            {
                                rectangle.X = 0x24;
                                rectangle.Y = 0x12;
                            }
                            if (frameNumber >= 2)
                            {
                                rectangle.X = 0x36;
                                rectangle.Y = 0x12;
                            }
                        }
                        Main.tile[i, j].frameX = (short) rectangle.X;
                        Main.tile[i, j].frameY = (short) rectangle.Y;
                        if ((type == 0x34) || (type == 0x3e))
                        {
                            if (Main.tile[i, j - 1] != null)
                            {
                                if (!Main.tile[i, j - 1].active)
                                {
                                    num2 = -1;
                                }
                                else
                                {
                                    num2 = Main.tile[i, j - 1].type;
                                }
                            }
                            else
                            {
                                num2 = type;
                            }
                            if (((num2 != type) && (num2 != 2)) && (num2 != 60))
                            {
                                KillTile(i, j, false, false, false);
                            }
                        }
                        if (!noTileActions && (type == 0x35))
                        {
                            if (((Main.netMode == 2) && (Main.tile[i, j + 1] != null)) && !Main.tile[i, j + 1].active)
                            {
                                bool flag4 = true;
                                if (Main.tile[i, j - 1].active && (Main.tile[i, j - 1].type == 0x15))
                                {
                                    flag4 = false;
                                }
                                if (flag4)
                                {
                                    int num36 = 0x1f;
                                    switch (type)
                                    {
                                        case 0x3b:
                                            num36 = 0x27;
                                            break;

                                        case 0x39:
                                            num36 = 40;
                                            break;
                                    }
                                    Main.tile[i, j].active = false;
                                    int num37 = Projectile.NewProjectile((float) ((i * 0x10) + 8), (float) ((j * 0x10) + 8), 0f, 0.41f, num36, 10, 0f, Main.myPlayer);
                                    Main.projectile[num37].velocity.Y = 0.5f;
                                    Main.projectile[num37].position.Y += 2f;
                                    Main.projectile[num37].ai[0] = 1f;
                                    NetMessage.SendTileSquare(-1, i, j, 1);
                                    SquareTileFrame(i, j, true);
                                }
                            }
                        }
                        if (((rectangle.X != frameX) && (rectangle.Y != frameY)) && ((frameX >= 0) && (frameY >= 0)))
                        {
                            bool mergeUp = WorldGen.mergeUp;
                            bool mergeDown = WorldGen.mergeDown;
                            bool mergeLeft = WorldGen.mergeLeft;
                            bool mergeRight = WorldGen.mergeRight;
                            TileFrame(i - 1, j, false, false);
                            TileFrame(i + 1, j, false, false);
                            TileFrame(i, j - 1, false, false);
                            TileFrame(i, j + 1, false, false);
                            WorldGen.mergeUp = mergeUp;
                            WorldGen.mergeDown = mergeDown;
                            WorldGen.mergeLeft = mergeLeft;
                            WorldGen.mergeRight = mergeRight;
                        }
                    }
                }
            }
        }

        public static void TileRunner(int i, int j, double strength, int steps, int type, bool addTile = false, float speedX = 0f, float speedY = 0f, bool noYChange = false, bool overRide = true)
        {
            Vector2 vector;
            Vector2 vector2;
            double num5 = strength;
            float num6 = steps;
            vector.X = i;
            vector.Y = j;
            vector2.X = genRand.Next(-10, 11) * 0.1f;
            vector2.Y = genRand.Next(-10, 11) * 0.1f;
            if ((speedX != 0f) || (speedY != 0f))
            {
                vector2.X = speedX;
                vector2.Y = speedY;
            }
            while ((num5 > 0.0) && (num6 > 0f))
            {
                if (((vector.Y < 0f) && (num6 > 0f)) && (type == 0x3b))
                {
                    num6 = 0f;
                }
                num5 = strength * (num6 / ((float) steps));
                num6--;
                int num = (int) (vector.X - (num5 * 0.5));
                int maxTilesX = (int) (vector.X + (num5 * 0.5));
                int num2 = (int) (vector.Y - (num5 * 0.5));
                int maxTilesY = (int) (vector.Y + (num5 * 0.5));
                if (num < 0)
                {
                    num = 0;
                }
                if (maxTilesX > Main.maxTilesX)
                {
                    maxTilesX = Main.maxTilesX;
                }
                if (num2 < 0)
                {
                    num2 = 0;
                }
                if (maxTilesY > Main.maxTilesY)
                {
                    maxTilesY = Main.maxTilesY;
                }
                for (int k = num; k < maxTilesX; k++)
                {
                    for (int m = num2; m < maxTilesY; m++)
                    {
                        if ((Math.Abs((float) (k - vector.X)) + Math.Abs((float) (m - vector.Y))) < ((strength * 0.5) * (1.0 + (genRand.Next(-10, 11) * 0.015))))
                        {
                            if ((mudWall && (m > Main.worldSurface)) && (m < ((Main.maxTilesY - 210) - genRand.Next(3))))
                            {
                                PlaceWall(k, m, 15, true);
                            }
                            if (type < 0)
                            {
                                if (((type == -2) && Main.tile[k, m].active) && ((m < waterLine) || (m > lavaLine)))
                                {
                                    Main.tile[k, m].liquid = 0xff;
                                    if (m > lavaLine)
                                    {
                                        Main.tile[k, m].lava = true;
                                    }
                                }
                                Main.tile[k, m].active = false;
                            }
                            else
                            {
                                if (((overRide || !Main.tile[k, m].active) && ((type != 40) || (Main.tile[k, m].type != 0x35))) && ((!Main.tileStone[type] || (Main.tile[k, m].type == 1)) && ((Main.tile[k, m].type != 0x2d) && (((Main.tile[k, m].type != 1) || (type != 0x3b)) || (m >= (Main.worldSurface + genRand.Next(-50, 50)))))))
                                {
                                    if ((Main.tile[k, m].type != 0x35) || (m >= Main.worldSurface))
                                    {
                                        Main.tile[k, m].type = (byte) type;
                                    }
                                    else if (type == 0x3b)
                                    {
                                        Main.tile[k, m].type = (byte) type;
                                    }
                                }
                                if (addTile)
                                {
                                    Main.tile[k, m].active = true;
                                    Main.tile[k, m].liquid = 0;
                                    Main.tile[k, m].lava = false;
                                }
                                if ((noYChange && (m < Main.worldSurface)) && (type != 0x3b))
                                {
                                    Main.tile[k, m].wall = 2;
                                }
                                if (((type == 0x3b) && (m > waterLine)) && (Main.tile[k, m].liquid > 0))
                                {
                                    Main.tile[k, m].lava = false;
                                    Main.tile[k, m].liquid = 0;
                                }
                            }
                        }
                    }
                }
                vector += vector2;
                if (num5 > 50.0)
                {
                    vector += vector2;
                    num6--;
                    vector2.Y += genRand.Next(-10, 11) * 0.05f;
                    vector2.X += genRand.Next(-10, 11) * 0.05f;
                    if (num5 > 100.0)
                    {
                        vector += vector2;
                        num6--;
                        vector2.Y += genRand.Next(-10, 11) * 0.05f;
                        vector2.X += genRand.Next(-10, 11) * 0.05f;
                        if (num5 > 150.0)
                        {
                            vector += vector2;
                            num6--;
                            vector2.Y += genRand.Next(-10, 11) * 0.05f;
                            vector2.X += genRand.Next(-10, 11) * 0.05f;
                            if (num5 > 200.0)
                            {
                                vector += vector2;
                                num6--;
                                vector2.Y += genRand.Next(-10, 11) * 0.05f;
                                vector2.X += genRand.Next(-10, 11) * 0.05f;
                                if (num5 > 250.0)
                                {
                                    vector += vector2;
                                    num6--;
                                    vector2.Y += genRand.Next(-10, 11) * 0.05f;
                                    vector2.X += genRand.Next(-10, 11) * 0.05f;
                                    if (num5 > 300.0)
                                    {
                                        vector += vector2;
                                        num6--;
                                        vector2.Y += genRand.Next(-10, 11) * 0.05f;
                                        vector2.X += genRand.Next(-10, 11) * 0.05f;
                                        if (num5 > 400.0)
                                        {
                                            vector += vector2;
                                            num6--;
                                            vector2.Y += genRand.Next(-10, 11) * 0.05f;
                                            vector2.X += genRand.Next(-10, 11) * 0.05f;
                                            if (num5 > 500.0)
                                            {
                                                vector += vector2;
                                                num6--;
                                                vector2.Y += genRand.Next(-10, 11) * 0.05f;
                                                vector2.X += genRand.Next(-10, 11) * 0.05f;
                                                if (num5 > 600.0)
                                                {
                                                    vector += vector2;
                                                    num6--;
                                                    vector2.Y += genRand.Next(-10, 11) * 0.05f;
                                                    vector2.X += genRand.Next(-10, 11) * 0.05f;
                                                    if (num5 > 700.0)
                                                    {
                                                        vector += vector2;
                                                        num6--;
                                                        vector2.Y += genRand.Next(-10, 11) * 0.05f;
                                                        vector2.X += genRand.Next(-10, 11) * 0.05f;
                                                        if (num5 > 800.0)
                                                        {
                                                            vector += vector2;
                                                            num6--;
                                                            vector2.Y += genRand.Next(-10, 11) * 0.05f;
                                                            vector2.X += genRand.Next(-10, 11) * 0.05f;
                                                            if (num5 > 900.0)
                                                            {
                                                                vector += vector2;
                                                                num6--;
                                                                vector2.Y += genRand.Next(-10, 11) * 0.05f;
                                                                vector2.X += genRand.Next(-10, 11) * 0.05f;
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                vector2.X += genRand.Next(-10, 11) * 0.05f;
                if (vector2.X > 1f)
                {
                    vector2.X = 1f;
                }
                if (vector2.X < -1f)
                {
                    vector2.X = -1f;
                }
                if (!noYChange)
                {
                    vector2.Y += genRand.Next(-10, 11) * 0.05f;
                    if (vector2.Y > 1f)
                    {
                        vector2.Y = 1f;
                    }
                    if (vector2.Y < -1f)
                    {
                        vector2.Y = -1f;
                    }
                }
                else if ((type != 0x3b) && (num5 < 3.0))
                {
                    if (vector2.Y > 1f)
                    {
                        vector2.Y = 1f;
                    }
                    if (vector2.Y < -1f)
                    {
                        vector2.Y = -1f;
                    }
                }
                if ((type == 0x3b) && !noYChange)
                {
                    if (vector2.Y > 0.5)
                    {
                        vector2.Y = 0.5f;
                    }
                    if (vector2.Y < -0.5)
                    {
                        vector2.Y = -0.5f;
                    }
                    if (vector.Y < (Main.rockLayer + 100.0))
                    {
                        vector2.Y = 1f;
                    }
                    if (vector.Y > (Main.maxTilesY - 300))
                    {
                        vector2.Y = -1f;
                    }
                }
            }
        }

        public static void UpdateWorld()
        {
            Liquid.skipCount++;
            if (Liquid.skipCount > 1)
            {
                Liquid.UpdateLiquid();
                Liquid.skipCount = 0;
            }
            float num = 3E-05f;
            float num2 = 1.5E-05f;
            bool flag = false;
            spawnDelay++;
            if (Main.invasionType > 0)
            {
                spawnDelay = 0;
            }
            if (spawnDelay >= 20)
            {
                flag = true;
                spawnDelay = 0;
                if (spawnNPC != 0x25)
                {
                    for (int k = 0; k < 0x3e8; k++)
                    {
                        if ((Main.npc[k].active && Main.npc[k].homeless) && Main.npc[k].townNPC)
                        {
                            spawnNPC = Main.npc[k].type;
                            break;
                        }
                    }
                }
            }
            for (int i = 0; i < ((Main.maxTilesX * Main.maxTilesY) * num); i++)
            {
                int x = genRand.Next(10, Main.maxTilesX - 10);
                int y = genRand.Next(10, ((int) Main.worldSurface) - 1);
                int num7 = x - 1;
                int num8 = x + 2;
                int num9 = y - 1;
                int num10 = y + 2;
                if (num7 < 10)
                {
                    num7 = 10;
                }
                if (num8 > (Main.maxTilesX - 10))
                {
                    num8 = Main.maxTilesX - 10;
                }
                if (num9 < 10)
                {
                    num9 = 10;
                }
                if (num10 > (Main.maxTilesY - 10))
                {
                    num10 = Main.maxTilesY - 10;
                }
                if (Main.tile[x, y] != null)
                {
                    if (Main.tileAlch[Main.tile[x, y].type])
                    {
                        GrowAlch(x, y);
                    }
                    if (Main.tile[x, y].liquid > 0x20)
                    {
                        if (Main.tile[x, y].active && (((Main.tile[x, y].type == 3) || (Main.tile[x, y].type == 20)) || (((Main.tile[x, y].type == 0x18) || (Main.tile[x, y].type == 0x1b)) || (Main.tile[x, y].type == 0x49))))
                        {
                            KillTile(x, y, false, false, false);
                            if (Main.netMode == 2)
                            {
                                NetMessage.SendData(0x11, -1, -1, "", 0, (float) x, (float) y, 0f, 0);
                            }
                        }
                    }
                    else if (Main.tile[x, y].active)
                    {
                        if (Main.tile[x, y].type == 80)
                        {
                            if (genRand.Next(15) == 0)
                            {
                                GrowCactus(x, y);
                            }
                        }
                        else if (Main.tile[x, y].type == 0x35)
                        {
                            if (!Main.tile[x, num9].active)
                            {
                                if ((x < 250) || (x > (Main.maxTilesX - 250)))
                                {
                                    if ((((genRand.Next(500) == 0) && (Main.tile[x, num9].liquid == 0xff)) && ((Main.tile[x, num9 - 1].liquid == 0xff) && (Main.tile[x, num9 - 2].liquid == 0xff))) && ((Main.tile[x, num9 - 3].liquid == 0xff) && (Main.tile[x, num9 - 4].liquid == 0xff)))
                                    {
                                        PlaceTile(x, num9, 0x51, true, false, -1, 0);
                                        if ((Main.netMode == 2) && Main.tile[x, num9].active)
                                        {
                                            NetMessage.SendTileSquare(-1, x, num9, 1);
                                        }
                                    }
                                }
                                else if (((x > 400) && (x < (Main.maxTilesX - 400))) && (genRand.Next(300) == 0))
                                {
                                    GrowCactus(x, y);
                                }
                            }
                        }
                        else if (Main.tile[x, y].type == 0x4e)
                        {
                            if (!Main.tile[x, num9].active)
                            {
                                PlaceTile(x, num9, 3, true, false, -1, 0);
                                if ((Main.netMode == 2) && Main.tile[x, num9].active)
                                {
                                    NetMessage.SendTileSquare(-1, x, num9, 1);
                                }
                            }
                        }
                        else if (((Main.tile[x, y].type == 2) || (Main.tile[x, y].type == 0x17)) || (Main.tile[x, y].type == 0x20))
                        {
                            int type = Main.tile[x, y].type;
                            if ((!Main.tile[x, num9].active && (genRand.Next(12) == 0)) && (type == 2))
                            {
                                PlaceTile(x, num9, 3, true, false, -1, 0);
                                if ((Main.netMode == 2) && Main.tile[x, num9].active)
                                {
                                    NetMessage.SendTileSquare(-1, x, num9, 1);
                                }
                            }
                            if ((!Main.tile[x, num9].active && (genRand.Next(10) == 0)) && (type == 0x17))
                            {
                                PlaceTile(x, num9, 0x18, true, false, -1, 0);
                                if ((Main.netMode == 2) && Main.tile[x, num9].active)
                                {
                                    NetMessage.SendTileSquare(-1, x, num9, 1);
                                }
                            }
                            bool flag2 = false;
                            for (int m = num7; m < num8; m++)
                            {
                                for (int n = num9; n < num10; n++)
                                {
                                    if (((x != m) || (y != n)) && Main.tile[m, n].active)
                                    {
                                        if (type == 0x20)
                                        {
                                            type = 0x17;
                                        }
                                        if ((Main.tile[m, n].type == 0) || ((type == 0x17) && (Main.tile[m, n].type == 2)))
                                        {
                                            SpreadGrass(m, n, 0, type, false);
                                            if (type == 0x17)
                                            {
                                                SpreadGrass(m, n, 2, type, false);
                                            }
                                            if (Main.tile[m, n].type == type)
                                            {
                                                SquareTileFrame(m, n, true);
                                                flag2 = true;
                                            }
                                        }
                                    }
                                }
                            }
                            if ((Main.netMode == 2) && flag2)
                            {
                                NetMessage.SendTileSquare(-1, x, y, 3);
                            }
                        }
                        else if (((Main.tile[x, y].type == 20) && (genRand.Next(20) == 0)) && !PlayerLOS(x, y))
                        {
                            GrowTree(x, y);
                        }
                        if (((Main.tile[x, y].type == 3) && (genRand.Next(20) == 0)) && (Main.tile[x, y].frameX < 0x90))
                        {
                            Main.tile[x, y].type = 0x49;
                            if (Main.netMode == 2)
                            {
                                NetMessage.SendTileSquare(-1, x, y, 3);
                            }
                        }
                        if ((Main.tile[x, y].type == 0x20) && (genRand.Next(3) == 0))
                        {
                            int num14 = x;
                            int num15 = y;
                            int num16 = 0;
                            if (Main.tile[num14 + 1, num15].active && (Main.tile[num14 + 1, num15].type == 0x20))
                            {
                                num16++;
                            }
                            if (Main.tile[num14 - 1, num15].active && (Main.tile[num14 - 1, num15].type == 0x20))
                            {
                                num16++;
                            }
                            if (Main.tile[num14, num15 + 1].active && (Main.tile[num14, num15 + 1].type == 0x20))
                            {
                                num16++;
                            }
                            if (Main.tile[num14, num15 - 1].active && (Main.tile[num14, num15 - 1].type == 0x20))
                            {
                                num16++;
                            }
                            if ((num16 < 3) || (Main.tile[x, y].type == 0x17))
                            {
                                switch (genRand.Next(4))
                                {
                                    case 0:
                                        num15--;
                                        break;

                                    case 1:
                                        num15++;
                                        break;

                                    case 2:
                                        num14--;
                                        break;

                                    case 3:
                                        num14++;
                                        break;
                                }
                                if (!Main.tile[num14, num15].active)
                                {
                                    num16 = 0;
                                    if (Main.tile[num14 + 1, num15].active && (Main.tile[num14 + 1, num15].type == 0x20))
                                    {
                                        num16++;
                                    }
                                    if (Main.tile[num14 - 1, num15].active && (Main.tile[num14 - 1, num15].type == 0x20))
                                    {
                                        num16++;
                                    }
                                    if (Main.tile[num14, num15 + 1].active && (Main.tile[num14, num15 + 1].type == 0x20))
                                    {
                                        num16++;
                                    }
                                    if (Main.tile[num14, num15 - 1].active && (Main.tile[num14, num15 - 1].type == 0x20))
                                    {
                                        num16++;
                                    }
                                    if (num16 < 2)
                                    {
                                        int num18 = 7;
                                        int num19 = num14 - num18;
                                        int num20 = num14 + num18;
                                        int num21 = num15 - num18;
                                        int num22 = num15 + num18;
                                        bool flag3 = false;
                                        for (int num23 = num19; num23 < num20; num23++)
                                        {
                                            for (int num24 = num21; num24 < num22; num24++)
                                            {
                                                if ((((((Math.Abs((int) (num23 - num14)) * 2) + Math.Abs((int) (num24 - num15))) < 9) && Main.tile[num23, num24].active) && ((Main.tile[num23, num24].type == 0x17) && Main.tile[num23, num24 - 1].active)) && ((Main.tile[num23, num24 - 1].type == 0x20) && (Main.tile[num23, num24 - 1].liquid == 0)))
                                                {
                                                    flag3 = true;
                                                    break;
                                                }
                                            }
                                        }
                                        if (flag3)
                                        {
                                            Main.tile[num14, num15].type = 0x20;
                                            Main.tile[num14, num15].active = true;
                                            SquareTileFrame(num14, num15, true);
                                            if (Main.netMode == 2)
                                            {
                                                NetMessage.SendTileSquare(-1, num14, num15, 3);
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                    else if (flag && (spawnNPC > 0))
                    {
                        SpawnNPC(x, y);
                    }
                    if (Main.tile[x, y].active)
                    {
                        if (((Main.tile[x, y].type == 2) || (Main.tile[x, y].type == 0x34)) && (((genRand.Next(40) == 0) && !Main.tile[x, y + 1].active) && !Main.tile[x, y + 1].lava))
                        {
                            bool flag4 = false;
                            for (int num25 = y; num25 > (y - 10); num25--)
                            {
                                if (Main.tile[x, num25].active && (Main.tile[x, num25].type == 2))
                                {
                                    flag4 = true;
                                    break;
                                }
                            }
                            if (flag4)
                            {
                                int num26 = x;
                                int num27 = y + 1;
                                Main.tile[num26, num27].type = 0x34;
                                Main.tile[num26, num27].active = true;
                                SquareTileFrame(num26, num27, true);
                                if (Main.netMode == 2)
                                {
                                    NetMessage.SendTileSquare(-1, num26, num27, 3);
                                }
                            }
                        }
                        if (Main.tile[x, y].type == 60)
                        {
                            int grass = Main.tile[x, y].type;
                            if (!Main.tile[x, num9].active && (genRand.Next(7) == 0))
                            {
                                PlaceTile(x, num9, 0x3d, true, false, -1, 0);
                                if ((Main.netMode == 2) && Main.tile[x, num9].active)
                                {
                                    NetMessage.SendTileSquare(-1, x, num9, 1);
                                }
                            }
                            else if (((genRand.Next(500) == 0) && ((!Main.tile[x, num9].active || (Main.tile[x, num9].type == 0x3d)) || ((Main.tile[x, num9].type == 0x4a) || (Main.tile[x, num9].type == 0x45)))) && !PlayerLOS(x, y))
                            {
                                GrowTree(x, y);
                            }
                            bool flag5 = false;
                            for (int num29 = num7; num29 < num8; num29++)
                            {
                                for (int num30 = num9; num30 < num10; num30++)
                                {
                                    if (((x != num29) || (y != num30)) && (Main.tile[num29, num30].active && (Main.tile[num29, num30].type == 0x3b)))
                                    {
                                        SpreadGrass(num29, num30, 0x3b, grass, false);
                                        if (Main.tile[num29, num30].type == grass)
                                        {
                                            SquareTileFrame(num29, num30, true);
                                            flag5 = true;
                                        }
                                    }
                                }
                            }
                            if ((Main.netMode == 2) && flag5)
                            {
                                NetMessage.SendTileSquare(-1, x, y, 3);
                            }
                        }
                        if (((Main.tile[x, y].type == 0x3d) && (genRand.Next(3) == 0)) && (Main.tile[x, y].frameX < 0x90))
                        {
                            Main.tile[x, y].type = 0x4a;
                            if (Main.netMode == 2)
                            {
                                NetMessage.SendTileSquare(-1, x, y, 3);
                            }
                        }
                        if (((Main.tile[x, y].type == 60) || (Main.tile[x, y].type == 0x3e)) && (((genRand.Next(15) == 0) && !Main.tile[x, y + 1].active) && !Main.tile[x, y + 1].lava))
                        {
                            bool flag6 = false;
                            for (int num31 = y; num31 > (y - 10); num31--)
                            {
                                if (Main.tile[x, num31].active && (Main.tile[x, num31].type == 60))
                                {
                                    flag6 = true;
                                    break;
                                }
                            }
                            if (flag6)
                            {
                                int num32 = x;
                                int num33 = y + 1;
                                Main.tile[num32, num33].type = 0x3e;
                                Main.tile[num32, num33].active = true;
                                SquareTileFrame(num32, num33, true);
                                if (Main.netMode == 2)
                                {
                                    NetMessage.SendTileSquare(-1, num32, num33, 3);
                                }
                            }
                        }
                    }
                }
            }
            for (int j = 0; j < ((Main.maxTilesX * Main.maxTilesY) * num2); j++)
            {
                int num35 = genRand.Next(10, Main.maxTilesX - 10);
                int num36 = genRand.Next(((int) Main.worldSurface) + 2, Main.maxTilesY - 20);
                int num37 = num35 - 1;
                int num38 = num35 + 2;
                int num39 = num36 - 1;
                int num40 = num36 + 2;
                if (num37 < 10)
                {
                    num37 = 10;
                }
                if (num38 > (Main.maxTilesX - 10))
                {
                    num38 = Main.maxTilesX - 10;
                }
                if (num39 < 10)
                {
                    num39 = 10;
                }
                if (num40 > (Main.maxTilesY - 10))
                {
                    num40 = Main.maxTilesY - 10;
                }
                if (Main.tile[num35, num36] != null)
                {
                    if (Main.tileAlch[Main.tile[num35, num36].type])
                    {
                        GrowAlch(num35, num36);
                    }
                    if (Main.tile[num35, num36].liquid <= 0x20)
                    {
                        if (Main.tile[num35, num36].active)
                        {
                            if (Main.tile[num35, num36].type == 60)
                            {
                                int num41 = Main.tile[num35, num36].type;
                                if (!Main.tile[num35, num39].active && (genRand.Next(10) == 0))
                                {
                                    PlaceTile(num35, num39, 0x3d, true, false, -1, 0);
                                    if ((Main.netMode == 2) && Main.tile[num35, num39].active)
                                    {
                                        NetMessage.SendTileSquare(-1, num35, num39, 1);
                                    }
                                }
                                bool flag7 = false;
                                for (int num42 = num37; num42 < num38; num42++)
                                {
                                    for (int num43 = num39; num43 < num40; num43++)
                                    {
                                        if (((num35 != num42) || (num36 != num43)) && (Main.tile[num42, num43].active && (Main.tile[num42, num43].type == 0x3b)))
                                        {
                                            SpreadGrass(num42, num43, 0x3b, num41, false);
                                            if (Main.tile[num42, num43].type == num41)
                                            {
                                                SquareTileFrame(num42, num43, true);
                                                flag7 = true;
                                            }
                                        }
                                    }
                                }
                                if ((Main.netMode == 2) && flag7)
                                {
                                    NetMessage.SendTileSquare(-1, num35, num36, 3);
                                }
                            }
                            if (((Main.tile[num35, num36].type == 0x3d) && (genRand.Next(3) == 0)) && (Main.tile[num35, num36].frameX < 0x90))
                            {
                                Main.tile[num35, num36].type = 0x4a;
                                if (Main.netMode == 2)
                                {
                                    NetMessage.SendTileSquare(-1, num35, num36, 3);
                                }
                            }
                            if (((Main.tile[num35, num36].type == 60) || (Main.tile[num35, num36].type == 0x3e)) && (((genRand.Next(5) == 0) && !Main.tile[num35, num36 + 1].active) && !Main.tile[num35, num36 + 1].lava))
                            {
                                bool flag8 = false;
                                for (int num44 = num36; num44 > (num36 - 10); num44--)
                                {
                                    if (Main.tile[num35, num44].active && (Main.tile[num35, num44].type == 60))
                                    {
                                        flag8 = true;
                                        break;
                                    }
                                }
                                if (flag8)
                                {
                                    int num45 = num35;
                                    int num46 = num36 + 1;
                                    Main.tile[num45, num46].type = 0x3e;
                                    Main.tile[num45, num46].active = true;
                                    SquareTileFrame(num45, num46, true);
                                    if (Main.netMode == 2)
                                    {
                                        NetMessage.SendTileSquare(-1, num45, num46, 3);
                                    }
                                }
                            }
                            if ((Main.tile[num35, num36].type == 0x45) && (genRand.Next(3) == 0))
                            {
                                int num47 = num35;
                                int num48 = num36;
                                int num49 = 0;
                                if (Main.tile[num47 + 1, num48].active && (Main.tile[num47 + 1, num48].type == 0x45))
                                {
                                    num49++;
                                }
                                if (Main.tile[num47 - 1, num48].active && (Main.tile[num47 - 1, num48].type == 0x45))
                                {
                                    num49++;
                                }
                                if (Main.tile[num47, num48 + 1].active && (Main.tile[num47, num48 + 1].type == 0x45))
                                {
                                    num49++;
                                }
                                if (Main.tile[num47, num48 - 1].active && (Main.tile[num47, num48 - 1].type == 0x45))
                                {
                                    num49++;
                                }
                                if ((num49 < 3) || (Main.tile[num35, num36].type == 60))
                                {
                                    switch (genRand.Next(4))
                                    {
                                        case 0:
                                            num48--;
                                            break;

                                        case 1:
                                            num48++;
                                            break;

                                        case 2:
                                            num47--;
                                            break;

                                        case 3:
                                            num47++;
                                            break;
                                    }
                                    if (!Main.tile[num47, num48].active)
                                    {
                                        num49 = 0;
                                        if (Main.tile[num47 + 1, num48].active && (Main.tile[num47 + 1, num48].type == 0x45))
                                        {
                                            num49++;
                                        }
                                        if (Main.tile[num47 - 1, num48].active && (Main.tile[num47 - 1, num48].type == 0x45))
                                        {
                                            num49++;
                                        }
                                        if (Main.tile[num47, num48 + 1].active && (Main.tile[num47, num48 + 1].type == 0x45))
                                        {
                                            num49++;
                                        }
                                        if (Main.tile[num47, num48 - 1].active && (Main.tile[num47, num48 - 1].type == 0x45))
                                        {
                                            num49++;
                                        }
                                        if (num49 < 2)
                                        {
                                            int num51 = 7;
                                            int num52 = num47 - num51;
                                            int num53 = num47 + num51;
                                            int num54 = num48 - num51;
                                            int num55 = num48 + num51;
                                            bool flag9 = false;
                                            for (int num56 = num52; num56 < num53; num56++)
                                            {
                                                for (int num57 = num54; num57 < num55; num57++)
                                                {
                                                    if ((((((Math.Abs((int) (num56 - num47)) * 2) + Math.Abs((int) (num57 - num48))) < 9) && Main.tile[num56, num57].active) && ((Main.tile[num56, num57].type == 60) && Main.tile[num56, num57 - 1].active)) && ((Main.tile[num56, num57 - 1].type == 0x45) && (Main.tile[num56, num57 - 1].liquid == 0)))
                                                    {
                                                        flag9 = true;
                                                        break;
                                                    }
                                                }
                                            }
                                            if (flag9)
                                            {
                                                Main.tile[num47, num48].type = 0x45;
                                                Main.tile[num47, num48].active = true;
                                                SquareTileFrame(num47, num48, true);
                                                if (Main.netMode == 2)
                                                {
                                                    NetMessage.SendTileSquare(-1, num47, num48, 3);
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                            if (Main.tile[num35, num36].type == 70)
                            {
                                int num58 = Main.tile[num35, num36].type;
                                if (!Main.tile[num35, num39].active && (genRand.Next(10) == 0))
                                {
                                    PlaceTile(num35, num39, 0x47, true, false, -1, 0);
                                    if ((Main.netMode == 2) && Main.tile[num35, num39].active)
                                    {
                                        NetMessage.SendTileSquare(-1, num35, num39, 1);
                                    }
                                }
                                if ((genRand.Next(200) == 0) && !PlayerLOS(num35, num36))
                                {
                                    GrowShroom(num35, num36);
                                }
                                bool flag10 = false;
                                for (int num59 = num37; num59 < num38; num59++)
                                {
                                    for (int num60 = num39; num60 < num40; num60++)
                                    {
                                        if (((num35 != num59) || (num36 != num60)) && (Main.tile[num59, num60].active && (Main.tile[num59, num60].type == 0x3b)))
                                        {
                                            SpreadGrass(num59, num60, 0x3b, num58, false);
                                            if (Main.tile[num59, num60].type == num58)
                                            {
                                                SquareTileFrame(num59, num60, true);
                                                flag10 = true;
                                            }
                                        }
                                    }
                                }
                                if ((Main.netMode == 2) && flag10)
                                {
                                    NetMessage.SendTileSquare(-1, num35, num36, 3);
                                }
                            }
                            continue;
                        }
                        if (flag && (spawnNPC > 0))
                        {
                            SpawnNPC(num35, num36);
                        }
                    }
                }
            }
            if (Main.rand.Next(100) == 0)
            {
                PlantAlch();
            }
            if (!Main.dayTime)
            {
                float num61 = Main.maxTilesX / 0x1068;
                if (Main.rand.Next(0x1f40) < (10f * num61))
                {
                    int num62 = 12;
                    int num63 = Main.rand.Next(Main.maxTilesX - 50) + 100;
                    num63 *= 0x10;
                    int num64 = Main.rand.Next((int) (Main.maxTilesY * 0.05)) * 0x10;
                    Vector2 vector = new Vector2((float) num63, (float) num64);
                    float speedX = Main.rand.Next(-100, 0x65);
                    float speedY = Main.rand.Next(200) + 100;
                    float num67 = (float) Math.Sqrt((double) ((speedX * speedX) + (speedY * speedY)));
                    num67 = ((float) num62) / num67;
                    speedX *= num67;
                    speedY *= num67;
                    Projectile.NewProjectile(vector.X, vector.Y, speedX, speedY, 12, 0x3e8, 10f, Main.myPlayer);
                }
            }
        }

        public static void WallFrame(int i, int j, bool resetFrame = false)
        {
            if ((((i >= 0) && (j >= 0)) && ((i < Main.maxTilesX) && (j < Main.maxTilesY))) && ((Main.tile[i, j] != null) && (Main.tile[i, j].wall > 0)))
            {
                int num = -1;
                int num2 = -1;
                int num3 = -1;
                int num4 = -1;
                int num5 = -1;
                int num6 = -1;
                int num7 = -1;
                int num8 = -1;
                int wall = Main.tile[i, j].wall;
                if (wall != 0)
                {
                    Rectangle rectangle;
                    byte wallFrameX = Main.tile[i, j].wallFrameX;
                    byte wallFrameY = Main.tile[i, j].wallFrameY;
                    rectangle.X = -1;
                    rectangle.Y = -1;
                    if ((i - 1) < 0)
                    {
                        num = wall;
                        num4 = wall;
                        num6 = wall;
                    }
                    if ((i + 1) >= Main.maxTilesX)
                    {
                        num3 = wall;
                        num5 = wall;
                        num8 = wall;
                    }
                    if ((j - 1) < 0)
                    {
                        num = wall;
                        num2 = wall;
                        num3 = wall;
                    }
                    if ((j + 1) >= Main.maxTilesY)
                    {
                        num6 = wall;
                        num7 = wall;
                        num8 = wall;
                    }
                    if (((i - 1) >= 0) && (Main.tile[i - 1, j] != null))
                    {
                        num4 = Main.tile[i - 1, j].wall;
                    }
                    if (((i + 1) < Main.maxTilesX) && (Main.tile[i + 1, j] != null))
                    {
                        num5 = Main.tile[i + 1, j].wall;
                    }
                    if (((j - 1) >= 0) && (Main.tile[i, j - 1] != null))
                    {
                        num2 = Main.tile[i, j - 1].wall;
                    }
                    if (((j + 1) < Main.maxTilesY) && (Main.tile[i, j + 1] != null))
                    {
                        num7 = Main.tile[i, j + 1].wall;
                    }
                    if ((((i - 1) >= 0) && ((j - 1) >= 0)) && (Main.tile[i - 1, j - 1] != null))
                    {
                        num = Main.tile[i - 1, j - 1].wall;
                    }
                    if ((((i + 1) < Main.maxTilesX) && ((j - 1) >= 0)) && (Main.tile[i + 1, j - 1] != null))
                    {
                        num3 = Main.tile[i + 1, j - 1].wall;
                    }
                    if ((((i - 1) >= 0) && ((j + 1) < Main.maxTilesY)) && (Main.tile[i - 1, j + 1] != null))
                    {
                        num6 = Main.tile[i - 1, j + 1].wall;
                    }
                    if ((((i + 1) < Main.maxTilesX) && ((j + 1) < Main.maxTilesY)) && (Main.tile[i + 1, j + 1] != null))
                    {
                        num8 = Main.tile[i + 1, j + 1].wall;
                    }
                    if (wall == 2)
                    {
                        if (j == ((int) Main.worldSurface))
                        {
                            num7 = wall;
                            num6 = wall;
                            num8 = wall;
                        }
                        else if (j >= ((int) Main.worldSurface))
                        {
                            num7 = wall;
                            num6 = wall;
                            num8 = wall;
                            num2 = wall;
                            num = wall;
                            num3 = wall;
                            num4 = wall;
                            num5 = wall;
                        }
                    }
                    if (num7 > 0)
                    {
                        num7 = wall;
                    }
                    if (num6 > 0)
                    {
                        num6 = wall;
                    }
                    if (num8 > 0)
                    {
                        num8 = wall;
                    }
                    if (num2 > 0)
                    {
                        num2 = wall;
                    }
                    if (num > 0)
                    {
                        num = wall;
                    }
                    if (num3 > 0)
                    {
                        num3 = wall;
                    }
                    if (num4 > 0)
                    {
                        num4 = wall;
                    }
                    if (num5 > 0)
                    {
                        num5 = wall;
                    }
                    int wallFrameNumber = 0;
                    if (resetFrame)
                    {
                        wallFrameNumber = genRand.Next(0, 3);
                        Main.tile[i, j].wallFrameNumber = (byte) wallFrameNumber;
                    }
                    else
                    {
                        wallFrameNumber = Main.tile[i, j].wallFrameNumber;
                    }
                    if ((rectangle.X < 0) || (rectangle.Y < 0))
                    {
                        if (((num2 == wall) && (num7 == wall)) && ((num4 == wall) & (num5 == wall)))
                        {
                            if ((num != wall) && (num3 != wall))
                            {
                                switch (wallFrameNumber)
                                {
                                    case 0:
                                        rectangle.X = 0x6c;
                                        rectangle.Y = 0x12;
                                        break;

                                    case 1:
                                        rectangle.X = 0x7e;
                                        rectangle.Y = 0x12;
                                        break;

                                    case 2:
                                        rectangle.X = 0x90;
                                        rectangle.Y = 0x12;
                                        break;
                                }
                            }
                            else if ((num6 != wall) && (num8 != wall))
                            {
                                switch (wallFrameNumber)
                                {
                                    case 0:
                                        rectangle.X = 0x6c;
                                        rectangle.Y = 0x24;
                                        break;

                                    case 1:
                                        rectangle.X = 0x7e;
                                        rectangle.Y = 0x24;
                                        break;

                                    case 2:
                                        rectangle.X = 0x90;
                                        rectangle.Y = 0x24;
                                        break;
                                }
                            }
                            else if ((num != wall) && (num6 != wall))
                            {
                                switch (wallFrameNumber)
                                {
                                    case 0:
                                        rectangle.X = 180;
                                        rectangle.Y = 0;
                                        break;

                                    case 1:
                                        rectangle.X = 180;
                                        rectangle.Y = 0x12;
                                        break;

                                    case 2:
                                        rectangle.X = 180;
                                        rectangle.Y = 0x24;
                                        break;
                                }
                            }
                            else if ((num3 != wall) && (num8 != wall))
                            {
                                switch (wallFrameNumber)
                                {
                                    case 0:
                                        rectangle.X = 0xc6;
                                        rectangle.Y = 0;
                                        break;

                                    case 1:
                                        rectangle.X = 0xc6;
                                        rectangle.Y = 0x12;
                                        break;

                                    case 2:
                                        rectangle.X = 0xc6;
                                        rectangle.Y = 0x24;
                                        break;
                                }
                            }
                            else
                            {
                                switch (wallFrameNumber)
                                {
                                    case 0:
                                        rectangle.X = 0x12;
                                        rectangle.Y = 0x12;
                                        break;

                                    case 1:
                                        rectangle.X = 0x24;
                                        rectangle.Y = 0x12;
                                        break;

                                    case 2:
                                        rectangle.X = 0x36;
                                        rectangle.Y = 0x12;
                                        break;
                                }
                            }
                        }
                        else if (((num2 != wall) && (num7 == wall)) && ((num4 == wall) & (num5 == wall)))
                        {
                            switch (wallFrameNumber)
                            {
                                case 0:
                                    rectangle.X = 0x12;
                                    rectangle.Y = 0;
                                    break;

                                case 1:
                                    rectangle.X = 0x24;
                                    rectangle.Y = 0;
                                    break;

                                case 2:
                                    rectangle.X = 0x36;
                                    rectangle.Y = 0;
                                    break;
                            }
                        }
                        else if (((num2 == wall) && (num7 != wall)) && ((num4 == wall) & (num5 == wall)))
                        {
                            switch (wallFrameNumber)
                            {
                                case 0:
                                    rectangle.X = 0x12;
                                    rectangle.Y = 0x24;
                                    break;

                                case 1:
                                    rectangle.X = 0x24;
                                    rectangle.Y = 0x24;
                                    break;

                                case 2:
                                    rectangle.X = 0x36;
                                    rectangle.Y = 0x24;
                                    break;
                            }
                        }
                        else if (((num2 == wall) && (num7 == wall)) && ((num4 != wall) & (num5 == wall)))
                        {
                            switch (wallFrameNumber)
                            {
                                case 0:
                                    rectangle.X = 0;
                                    rectangle.Y = 0;
                                    break;

                                case 1:
                                    rectangle.X = 0;
                                    rectangle.Y = 0x12;
                                    break;

                                case 2:
                                    rectangle.X = 0;
                                    rectangle.Y = 0x24;
                                    break;
                            }
                        }
                        else if (((num2 == wall) && (num7 == wall)) && ((num4 == wall) & (num5 != wall)))
                        {
                            switch (wallFrameNumber)
                            {
                                case 0:
                                    rectangle.X = 0x48;
                                    rectangle.Y = 0;
                                    break;

                                case 1:
                                    rectangle.X = 0x48;
                                    rectangle.Y = 0x12;
                                    break;

                                case 2:
                                    rectangle.X = 0x48;
                                    rectangle.Y = 0x24;
                                    break;
                            }
                        }
                        else if (((num2 != wall) && (num7 == wall)) && ((num4 != wall) & (num5 == wall)))
                        {
                            switch (wallFrameNumber)
                            {
                                case 0:
                                    rectangle.X = 0;
                                    rectangle.Y = 0x36;
                                    break;

                                case 1:
                                    rectangle.X = 0x24;
                                    rectangle.Y = 0x36;
                                    break;

                                case 2:
                                    rectangle.X = 0x48;
                                    rectangle.Y = 0x36;
                                    break;
                            }
                        }
                        else if (((num2 != wall) && (num7 == wall)) && ((num4 == wall) & (num5 != wall)))
                        {
                            switch (wallFrameNumber)
                            {
                                case 0:
                                    rectangle.X = 0x12;
                                    rectangle.Y = 0x36;
                                    break;

                                case 1:
                                    rectangle.X = 0x36;
                                    rectangle.Y = 0x36;
                                    break;

                                case 2:
                                    rectangle.X = 90;
                                    rectangle.Y = 0x36;
                                    break;
                            }
                        }
                        else if (((num2 == wall) && (num7 != wall)) && ((num4 != wall) & (num5 == wall)))
                        {
                            switch (wallFrameNumber)
                            {
                                case 0:
                                    rectangle.X = 0;
                                    rectangle.Y = 0x48;
                                    break;

                                case 1:
                                    rectangle.X = 0x24;
                                    rectangle.Y = 0x48;
                                    break;

                                case 2:
                                    rectangle.X = 0x48;
                                    rectangle.Y = 0x48;
                                    break;
                            }
                        }
                        else if (((num2 == wall) && (num7 != wall)) && ((num4 == wall) & (num5 != wall)))
                        {
                            switch (wallFrameNumber)
                            {
                                case 0:
                                    rectangle.X = 0x12;
                                    rectangle.Y = 0x48;
                                    break;

                                case 1:
                                    rectangle.X = 0x36;
                                    rectangle.Y = 0x48;
                                    break;

                                case 2:
                                    rectangle.X = 90;
                                    rectangle.Y = 0x48;
                                    break;
                            }
                        }
                        else if (((num2 == wall) && (num7 == wall)) && ((num4 != wall) & (num5 != wall)))
                        {
                            switch (wallFrameNumber)
                            {
                                case 0:
                                    rectangle.X = 90;
                                    rectangle.Y = 0;
                                    break;

                                case 1:
                                    rectangle.X = 90;
                                    rectangle.Y = 0x12;
                                    break;

                                case 2:
                                    rectangle.X = 90;
                                    rectangle.Y = 0x24;
                                    break;
                            }
                        }
                        else if (((num2 != wall) && (num7 != wall)) && ((num4 == wall) & (num5 == wall)))
                        {
                            switch (wallFrameNumber)
                            {
                                case 0:
                                    rectangle.X = 0x6c;
                                    rectangle.Y = 0x48;
                                    break;

                                case 1:
                                    rectangle.X = 0x7e;
                                    rectangle.Y = 0x48;
                                    break;

                                case 2:
                                    rectangle.X = 0x90;
                                    rectangle.Y = 0x48;
                                    break;
                            }
                        }
                        else if (((num2 != wall) && (num7 == wall)) && ((num4 != wall) & (num5 != wall)))
                        {
                            switch (wallFrameNumber)
                            {
                                case 0:
                                    rectangle.X = 0x6c;
                                    rectangle.Y = 0;
                                    break;

                                case 1:
                                    rectangle.X = 0x7e;
                                    rectangle.Y = 0;
                                    break;

                                case 2:
                                    rectangle.X = 0x90;
                                    rectangle.Y = 0;
                                    break;
                            }
                        }
                        else if (((num2 == wall) && (num7 != wall)) && ((num4 != wall) & (num5 != wall)))
                        {
                            switch (wallFrameNumber)
                            {
                                case 0:
                                    rectangle.X = 0x6c;
                                    rectangle.Y = 0x36;
                                    break;

                                case 1:
                                    rectangle.X = 0x7e;
                                    rectangle.Y = 0x36;
                                    break;

                                case 2:
                                    rectangle.X = 0x90;
                                    rectangle.Y = 0x36;
                                    break;
                            }
                        }
                        else if (((num2 != wall) && (num7 != wall)) && ((num4 != wall) & (num5 == wall)))
                        {
                            switch (wallFrameNumber)
                            {
                                case 0:
                                    rectangle.X = 0xa2;
                                    rectangle.Y = 0;
                                    break;

                                case 1:
                                    rectangle.X = 0xa2;
                                    rectangle.Y = 0x12;
                                    break;

                                case 2:
                                    rectangle.X = 0xa2;
                                    rectangle.Y = 0x24;
                                    break;
                            }
                        }
                        else if (((num2 != wall) && (num7 != wall)) && ((num4 == wall) & (num5 != wall)))
                        {
                            switch (wallFrameNumber)
                            {
                                case 0:
                                    rectangle.X = 0xd8;
                                    rectangle.Y = 0;
                                    break;

                                case 1:
                                    rectangle.X = 0xd8;
                                    rectangle.Y = 0x12;
                                    break;

                                case 2:
                                    rectangle.X = 0xd8;
                                    rectangle.Y = 0x24;
                                    break;
                            }
                        }
                        else if (((num2 != wall) && (num7 != wall)) && ((num4 != wall) & (num5 != wall)))
                        {
                            switch (wallFrameNumber)
                            {
                                case 0:
                                    rectangle.X = 0xa2;
                                    rectangle.Y = 0x36;
                                    break;

                                case 1:
                                    rectangle.X = 180;
                                    rectangle.Y = 0x36;
                                    break;

                                case 2:
                                    rectangle.X = 0xc6;
                                    rectangle.Y = 0x36;
                                    break;
                            }
                        }
                    }
                    if ((rectangle.X <= -1) || (rectangle.Y <= -1))
                    {
                        if (wallFrameNumber <= 0)
                        {
                            rectangle.X = 0x12;
                            rectangle.Y = 0x12;
                        }
                        if (wallFrameNumber == 1)
                        {
                            rectangle.X = 0x24;
                            rectangle.Y = 0x12;
                        }
                        if (wallFrameNumber >= 2)
                        {
                            rectangle.X = 0x36;
                            rectangle.Y = 0x12;
                        }
                    }
                    Main.tile[i, j].wallFrameX = (byte) rectangle.X;
                    Main.tile[i, j].wallFrameY = (byte) rectangle.Y;
                }
            }
        }

        public static void WaterCheck()
        {
            Liquid.numLiquid = 0;
            LiquidBuffer.numLiquidBuffer = 0;
            for (int i = 1; i < (Main.maxTilesX - 1); i++)
            {
                for (int j = Main.maxTilesY - 2; j > 0; j--)
                {
                    Main.tile[i, j].checkingLiquid = false;
                    if (((Main.tile[i, j].liquid > 0) && Main.tile[i, j].active) && (Main.tileSolid[Main.tile[i, j].type] && !Main.tileSolidTop[Main.tile[i, j].type]))
                    {
                        Main.tile[i, j].liquid = 0;
                    }
                    else if (Main.tile[i, j].liquid > 0)
                    {
                        if (Main.tile[i, j].active)
                        {
                            if (Main.tileWaterDeath[Main.tile[i, j].type])
                            {
                                KillTile(i, j, false, false, false);
                            }
                            if (Main.tile[i, j].lava && Main.tileLavaDeath[Main.tile[i, j].type])
                            {
                                KillTile(i, j, false, false, false);
                            }
                        }
                        if (((!Main.tile[i, j + 1].active || !Main.tileSolid[Main.tile[i, j + 1].type]) || Main.tileSolidTop[Main.tile[i, j + 1].type]) && (Main.tile[i, j + 1].liquid < 0xff))
                        {
                            if (Main.tile[i, j + 1].liquid > 250)
                            {
                                Main.tile[i, j + 1].liquid = 0xff;
                            }
                            else
                            {
                                Liquid.AddWater(i, j);
                            }
                        }
                        if (((!Main.tile[i - 1, j].active || !Main.tileSolid[Main.tile[i - 1, j].type]) || Main.tileSolidTop[Main.tile[i - 1, j].type]) && (Main.tile[i - 1, j].liquid != Main.tile[i, j].liquid))
                        {
                            Liquid.AddWater(i, j);
                        }
                        else if (((!Main.tile[i + 1, j].active || !Main.tileSolid[Main.tile[i + 1, j].type]) || Main.tileSolidTop[Main.tile[i + 1, j].type]) && (Main.tile[i + 1, j].liquid != Main.tile[i, j].liquid))
                        {
                            Liquid.AddWater(i, j);
                        }
                        if (Main.tile[i, j].lava)
                        {
                            if ((Main.tile[i - 1, j].liquid > 0) && !Main.tile[i - 1, j].lava)
                            {
                                Liquid.AddWater(i, j);
                            }
                            else if ((Main.tile[i + 1, j].liquid > 0) && !Main.tile[i + 1, j].lava)
                            {
                                Liquid.AddWater(i, j);
                            }
                            else if ((Main.tile[i, j - 1].liquid > 0) && !Main.tile[i, j - 1].lava)
                            {
                                Liquid.AddWater(i, j);
                            }
                            else if ((Main.tile[i, j + 1].liquid > 0) && !Main.tile[i, j + 1].lava)
                            {
                                Liquid.AddWater(i, j);
                            }
                        }
                    }
                }
            }
        }

        public static void worldGenCallBack(object threadContext)
        {
            Main.PlaySound(10, -1, -1, 1);
            clearWorld();
            generateWorld(-1);
            saveWorld(true);
            Main.LoadWorlds();
            if (Main.menuMode == 10)
            {
                Main.menuMode = 6;
            }
            Main.PlaySound(10, -1, -1, 1);
        }
    }
}

