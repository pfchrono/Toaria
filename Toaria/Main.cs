namespace Toaria
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Audio;
    using Microsoft.Xna.Framework.Graphics;
    using Microsoft.Xna.Framework.Input;
    using System;
    using System.Diagnostics;
    using System.IO;
    using System.Runtime.InteropServices;
    using System.Text;
    using System.Threading;
    using TerrariaAPI.Hooks;
    using System.IO.Compression;

    public class Main : Game
    {
        public static Texture2D antLionTexture;
        public static float armorAlpha = 1f;
        public static Texture2D[] armorArmTexture = new Texture2D[0x11];
        public static Texture2D[] armorBodyTexture = new Texture2D[0x11];
        public static Texture2D[] armorHeadTexture = new Texture2D[0x1d];
        public static bool armorHide = false;
        public static Texture2D[] armorLegTexture = new Texture2D[0x10];
        public static bool autoGen = false;
        public static bool autoJoin = false;
        public static bool autoPass = false;
        public static bool autoPause = false;
        public static bool autoSave = true;
        public static bool autoShutdown = false;
        public static int[] availableRecipe = new int[Recipe.maxRecipes];
        public static float[] availableRecipeY = new float[Recipe.maxRecipes];
        public static int background = 0;
        public static int[] backgroundHeight = new int[7];
        public static Texture2D[] backgroundTexture = new Texture2D[7];
        public static int[] backgroundWidth = new int[7];
        private static int backSpaceCount = 0;
        public static Texture2D blackTileTexture;
        public static bool bloodMoon = false;
        public static Texture2D boneArmTexture;
        public static Texture2D bubbleTexture;
        public static float[] buffAlpha = new float[0x1b];
        public static string[] buffName = new string[0x1b];
        public static string buffString = "";
        public static Texture2D[] buffTexture = new Texture2D[0x1b];
        public static string[] buffTip = new string[0x1b];
        public static float caveParrallax = 1f;
        public static string cBuff = "B";
        public static string cDown = "S";
        public static Texture2D cdTexture;
        public static Texture2D chain2Texture;
        public static Texture2D chain3Texture;
        public static Texture2D chain4Texture;
        public static Texture2D chain5Texture;
        public static Texture2D chain6Texture;
        public static Texture2D chainTexture;
        public static Texture2D chat2Texture;
        public static Texture2D chatBackTexture;
        public static int chatLength = 600;
        public static int numChatLines = 7;
        public static ChatLine[] chatLine = new ChatLine[numChatLines];
        public static bool chatMode = false;
        public static bool chatRelease = false;
        public static string chatText = "";
        public static Texture2D chatTexture;
        public static string cHeal = "H";
        public static int checkForSpawns = 0;
        public static Chest[] chest = new Chest[0x3e8];
        public bool chestDepositHover;
        public float chestDepositScale = 1f;
        public bool chestLootHover;
        public float chestLootScale = 1f;
        public bool chestStackHover;
        public float chestStackScale = 1f;
        public static string chestText = "Chest";
        public static string cHook = "E";
        public static string cInv = "Escape";
        public static string cJump = "Space";
        public static string cLeft = "A";
        public static Player clientPlayer = new Player();
        public static int cloudLimit = 100;
        public static Texture2D[] cloudTexture = new Texture2D[4];
        public static string cMana = "M";
        public static CombatText[] combatText = new CombatText[100];
        public static bool craftGuide = false;
        public static float craftingAlpha = 1f;
        public static bool craftingHide = false;
        public static string cRight = "D";
        public static string cThrowItem = "Q";
        public static string cUp = "W";
        public int curMusic;
        public static int curRelease = 0x16;
        public static float cursorAlpha = 0f;
        public static Color cursorColor = Color.White;
        public static int cursorColorDirection = 1;
        public static float cursorScale = 0f;
        public static Texture2D cursorTexture;
        public const double dayLength = 54000.0;
        public static bool dayTime = true;
        public static bool[] debuff = new bool[0x1b];
        public static bool dedServ = false;
        public static string defaultIP = "";
        private int[] displayHeight = new int[0x63];
        private int[] displayWidth = new int[0x63];
        public static int drawTime = 0;
        public static int dungeonTiles;
        public static int dungeonX;
        public static int dungeonY;
        public static Dust[] dust = new Dust[0x3e9];
        public static Texture2D dustTexture;
        public static bool editSign = false;
        public static AudioEngine engine;
        public static int evilTiles;
        public static int fadeCounter = 0;
        public static Texture2D fadeTexture;
        public static bool fixedTiming = false;
        public static int focusRecipe;
        public static SpriteFont[] fontCombatText = new SpriteFont[2];
        public static SpriteFont fontDeathText;
        public static SpriteFont fontItemStack;
        public static SpriteFont fontMouseText;
        public static int frameRate = 0;
        public static bool frameRelease = false;
        public static bool gameMenu = true;
        public static bool gamePaused = false;
        public static string getIP = defaultIP;
        public static string getPort = Convert.ToString(Netplay.serverPort);
        public static Texture2D ghostTexture;
        public static Gore[] gore = new Gore[0xc9];
        public static Texture2D[] goreTexture = new Texture2D[0x63];
        public static bool grabSky = false;
        public static Item guideItem = new Item();
        public static bool hasFocus = true;
        public static Texture2D[] HBLockTexture = new Texture2D[2];
        public static Color hcColor = new Color(200, 0x7d, 0xff);
        public static Texture2D heartTexture;
        public static int helpText = 0;
        public static bool hideUI = false;
        public static float[] hotbarScale = new float[] { 1f, 0.75f, 0.75f, 0.75f, 0.75f, 0.75f, 0.75f, 0.75f, 0.75f, 0.75f };
        public static bool ignoreErrors = true;
        private static KeyboardState inputText;
        public static bool inputTextEnter = false;
        public static float invAlpha = 1f;
        public static int invasionDelay = 0;
        public static int invasionSize = 0;
        public static int invasionType = 0;
        public static int invasionWarn = 0;
        public static double invasionX = 0.0;
        public static float invDir = 1f;
        public static Texture2D inventoryBack10Texture;
        public static Texture2D inventoryBack2Texture;
        public static Texture2D inventoryBack3Texture;
        public static Texture2D inventoryBack4Texture;
        public static Texture2D inventoryBack5Texture;
        public static Texture2D inventoryBack6Texture;
        public static Texture2D inventoryBack7Texture;
        public static Texture2D inventoryBack8Texture;
        public static Texture2D inventoryBack9Texture;
        public static Texture2D inventoryBackTexture;
        public static float iS = 1f;
        public static Item[] item = new Item[0xc9];
        public static string[] itemName = new string[0x16c];
        public static ItemText[] itemText = new ItemText[100];
        public static Texture2D[] itemTexture = new Texture2D[0x16c];
        public static int jungleTiles;
        public static KeyboardState keyState = Keyboard.GetState();
        public static int lastItemUpdate;
        public static int lastNPCUpdate;
        public static float leftWorld = 0f;
        public static string libPath = "";
        public static Liquid[] liquid = new Liquid[Liquid.resLiquid];
        public static LiquidBuffer[] liquidBuffer = new LiquidBuffer[0x2710];
        public static Texture2D[] liquidTexture = new Texture2D[2];
        public static Player[] loadPlayer = new Player[5];
        public static string[] loadPlayerPath = new string[5];
        public static string[] loadWorld = new string[0x3e7];
        public static string[] loadWorldPath = new string[0x3e7];
        public static Texture2D logoTexture;
        public static int magmaBGFrame = 0;
        public static int magmaBGFrameCounter = 0;
        public static Texture2D manaTexture;
        public const int maxBackgrounds = 7;
        public const int maxBuffs = 0x1b;
        public const int maxChests = 0x3e8;
        public const int maxClouds = 100;
        public const int maxCloudTypes = 4;
        public const int maxCombatText = 100;
        public const int maxDust = 0x3e8;
        public const int maxGore = 200;
        public const int maxGoreTypes = 0x63;
        public const int maxHair = 0x24;
        public const int maxInventory = 0x2c;
        public const int maxItems = 200;
        public const int maxItemSounds = 0x15;
        public const int maxItemText = 100;
        public const int maxItemTypes = 0x16c;
        public static int maxItemUpdates = 10;
        public const int maxLiquidTypes = 2;
        private static int maxMenuItems = 14;
        public static int maxMP = 10;
        public const int maxMusic = 9;
        public static int maxNetPlayers = 0xff;
        public const int maxNPCHitSounds = 3;
        public const int maxNPCKilledSounds = 5;
        public const int maxNPCs = 0x3e8;
        public const int maxNPCTypes = 0x4a;
        public static int maxNPCUpdates = 15;
        public const int maxPlayers = 0xff;
        public const int maxProjectiles = 0x3e8;
        public const int maxProjectileTypes = 0x38;
        public static int maxScreenH = 0x4b0;
        public static int maxScreenW = 0x780;
        public static int maxSectionsX = (maxTilesX / 200);
        public static int maxSectionsY = (maxTilesY / 150);
        public const int maxStars = 130;
        public const int maxStarTypes = 5;
        public const int maxTileSets = 0x6b;
        public static float rightWorld = 134400f;
        public static float bottomWorld = 38400f;
        public static int maxTilesX = ((((int) rightWorld) / 0x10) + 1);
        public static int maxTilesY = ((((int) bottomWorld) / 0x10) + 1);
        public const int maxWallTypes = 0x15;
        public static Color mcColor = new Color(0x7d, 0x7d, 0xff);
        public static int menuFocus = 0;
        private float[] menuItemScale = new float[maxMenuItems];
        public static int menuMode = 0;
        public static bool menuMultiplayer = false;
        public static bool menuServer = false;
        public static int meteorTiles;
        private const int MF_BYPOSITION = 0x400;
        public static int minScreenH = 600;
        public static int minScreenW = 800;
        public static short moonModY = 0;
        public static int moonPhase = 0;
        public static Texture2D moonTexture;
        public static string motd = "";
        public static Color mouseColor = new Color(0xff, 50, 0x5f);
        public static bool mouseHC = false;
        public static Item mouseItem = new Item();
        public static bool mouseLeftRelease = false;
        public static bool mouseRightRelease = false;
        public static MouseState mouseState = Mouse.GetState();
        public static byte mouseTextColor = 0;
        public static int mouseTextColorChange = 1;
        public static Microsoft.Xna.Framework.Audio.Cue[] music = new Microsoft.Xna.Framework.Audio.Cue[9];
        public static float[] musicFade = new float[9];
        public static float musicVolume = 0.75f;
        public static int myPlayer = 0;
        public static int netMode = 0;
        public static int netPlayCounter;
        public int newMusic;
        public static string newWorldName = "";
        public const double nightLength = 32400.0;
        public static Texture2D ninjaTexture;
        public static NPC[] npc = new NPC[0x3e9];
        public static bool npcChatFocus1 = false;
        public static bool npcChatFocus2 = false;
        public static bool npcChatFocus3 = false;
        public static bool npcChatRelease = false;
        public static string npcChatText = "";
        public static int[] npcFrameCount = new int[] { 
            1, 2, 2, 3, 6, 2, 2, 1, 1, 1, 1, 1, 1, 1, 1, 1, 
            2, 0x10, 14, 0x10, 14, 15, 0x10, 2, 10, 1, 0x10, 0x10, 0x10, 3, 1, 15, 
            3, 1, 3, 1, 1, 0x10, 0x10, 1, 1, 1, 3, 3, 15, 3, 7, 7, 
            4, 5, 5, 5, 3, 3, 0x10, 6, 3, 6, 6, 2, 5, 3, 2, 7, 
            7, 4, 2, 8, 1, 5, 1, 2, 4, 0x10
         };
        public static int npcShop = 0;
        public static Texture2D[] npcTexture = new Texture2D[0x4a];
        public const int numArmorBody = 0x11;
        public const int numArmorHead = 0x1d;
        public const int numArmorLegs = 0x10;
        public static int numAvailableRecipes;
        public static int numClouds = cloudLimit;
        public static int numDust = 0x3e8;
        private static int numLoadPlayers = 0;
        private static int numLoadWorlds = 0;
        public static int numStars;
        private static KeyboardState oldInputText;
        public static MouseState oldMouseState = Mouse.GetState();
        public static string oldStatusText = "";
        public static Player[] player = new Player[0x100];
        public static Texture2D playerBeltTexture;
        public static Texture2D playerEyesTexture;
        public static Texture2D playerEyeWhitesTexture;
        public static Texture2D[] playerHairTexture = new Texture2D[0x24];
        public static Texture2D playerHands2Texture;
        public static Texture2D playerHandsTexture;
        public static Texture2D playerHeadTexture;
        public static bool playerInventory = false;
        public static Texture2D playerPantsTexture;
        public static string SavePath = (Environment.GetFolderPath(Environment.SpecialFolder.Personal) + @"\My Games\Terraria");
        public static string PlayerPath = (SavePath + @"\Players");
        public static string playerPathName;
        public static Texture2D playerShirtTexture;
        public static Texture2D playerShoesTexture;
        public static Texture2D playerUnderShirt2Texture;
        public static Texture2D playerUnderShirtTexture;
        public static Projectile[] projectile = new Projectile[0x3e9];
        public static Texture2D[] projectileTexture = new Texture2D[0x38];
        [ThreadStatic]
        public static Random rand;
        public static Texture2D raTexture;
        public static string[] recentIP = new string[maxMP];
        public static int[] recentPort = new int[maxMP];
        public static string[] recentWorld = new string[maxMP];
        public static Recipe[] recipe = new Recipe[Recipe.maxRecipes];
        public static bool releaseUI = false;
        public static bool resetClouds = true;
        public static Texture2D reTexture;
        public static double rockLayer;
        private static Stopwatch saveTime = new Stopwatch();
        public static int saveTimer = 0;
        public static int screenHeight = 600;
        public static Vector2 screenLastPosition;
        public static Vector2 screenPosition;
        public static int screenWidth = 800;
        public const int sectionHeight = 150;
        public const int sectionWidth = 200;
        private Color selColor = Color.White;
        public static bool serverStarting = false;
        public Chest[] shop = new Chest[6];
        public static bool showFrameRate = false;
        public static bool showItemOwner = false;
        public static bool showItemText = true;
        public static bool showSpam = false;
        public static bool showSplash = true;
        public static Texture2D shroomCapTexture;
        public static Sign[] sign = new Sign[0x3e8];
        public static bool signBubble = false;
        public static string signText = "";
        public static int signX = 0;
        public static int signY = 0;
        public static bool skipMenu = false;
        public static Microsoft.Xna.Framework.Audio.SoundBank soundBank;
        public static SoundEffect soundChat;
        public static SoundEffect soundCoins;
        public static SoundEffect[] soundDig = new SoundEffect[3];
        public static SoundEffect soundDoorClosed;
        public static SoundEffect soundDoorOpen;
        public static SoundEffect soundDoubleJump;
        public static SoundEffect soundDrown;
        public static SoundEffect[] soundFemaleHit = new SoundEffect[3];
        public static SoundEffect soundGrab;
        public static SoundEffect soundGrass;
        public static SoundEffectInstance soundInstanceChat;
        public static SoundEffectInstance soundInstanceCoins;
        public static SoundEffectInstance[] soundInstanceDig = new SoundEffectInstance[3];
        public static SoundEffectInstance soundInstanceDoorClosed;
        public static SoundEffectInstance soundInstanceDoorOpen;
        public static SoundEffectInstance soundInstanceDoubleJump;
        public static SoundEffectInstance soundInstanceDrown;
        public static SoundEffectInstance[] soundInstanceFemaleHit = new SoundEffectInstance[3];
        public static SoundEffectInstance soundInstanceGrab;
        public static SoundEffectInstance soundInstanceGrass;
        public static SoundEffectInstance[] soundInstanceItem = new SoundEffectInstance[0x16];
        public static SoundEffectInstance soundInstanceMaxMana;
        public static SoundEffectInstance soundInstanceMenuClose;
        public static SoundEffectInstance soundInstanceMenuOpen;
        public static SoundEffectInstance soundInstanceMenuTick;
        public static SoundEffectInstance[] soundInstanceNPCHit = new SoundEffectInstance[4];
        public static SoundEffectInstance[] soundInstanceNPCKilled = new SoundEffectInstance[6];
        public static SoundEffectInstance[] soundInstancePlayerHit = new SoundEffectInstance[3];
        public static SoundEffectInstance soundInstancePlayerKilled;
        public static SoundEffectInstance[] soundInstanceRoar = new SoundEffectInstance[2];
        public static SoundEffectInstance soundInstanceRun;
        public static SoundEffectInstance soundInstanceShatter;
        public static SoundEffectInstance[] soundInstanceSplash = new SoundEffectInstance[2];
        public static SoundEffectInstance[] soundInstanceTink = new SoundEffectInstance[3];
        public static SoundEffectInstance soundInstanceUnlock;
        public static SoundEffectInstance[] soundInstanceZombie = new SoundEffectInstance[3];
        public static SoundEffect[] soundItem = new SoundEffect[0x16];
        public static SoundEffect soundMaxMana;
        public static SoundEffect soundMenuClose;
        public static SoundEffect soundMenuOpen;
        public static SoundEffect soundMenuTick;
        public static SoundEffect[] soundNPCHit = new SoundEffect[4];
        public static SoundEffect[] soundNPCKilled = new SoundEffect[6];
        public static SoundEffect[] soundPlayerHit = new SoundEffect[3];
        public static SoundEffect soundPlayerKilled;
        public static SoundEffect[] soundRoar = new SoundEffect[2];
        public static SoundEffect soundRun;
        public static SoundEffect soundShatter;
        public static SoundEffect[] soundSplash = new SoundEffect[2];
        public static SoundEffect[] soundTink = new SoundEffect[3];
        public static SoundEffect soundUnlock;
        public static float soundVolume = 1f;
        public static SoundEffect[] soundZombie = new SoundEffect[3];
        public static int spamCount = 0;
        public static int spawnTileX;
        public static int spawnTileY;
        public static Texture2D spikeBaseTexture;
        public static Texture2D splashTexture;
        public static int stackCounter = 0;
        public static int stackDelay = 7;
        public static int stackSplit;
        public static Texture2D[] starTexture = new Texture2D[5];
        public static string statusText = "";
        public static bool stopTimeOuts = false;
        public static Texture2D sun2Texture;
        public static short sunModY = 0;
        public static Texture2D sunTexture;
        public static Color[] teamColor = new Color[5];
        public static int teamCooldown = 0;
        public static int teamCooldownLen = 300;
        public static Texture2D teamTexture;
        public static Texture2D textBackTexture;
        public static Tile[,] tile = new Tile[maxTilesX, maxTilesY];
        public static bool[] tileAlch = new bool[0x6b];
        public static bool[] tileBlockLight = new bool[0x6b];
        public static Color tileColor;
        public static bool[] tileCut = new bool[0x6b];
        public static bool[] tileDungeon = new bool[0x6b];
        public static bool[] tileFrameImportant = new bool[0x6b];
        public static bool[] tileLavaDeath = new bool[0x6b];
        public static bool[] tileMergeDirt = new bool[0x6b];
        public static string[] tileName = new string[0x6b];
        public static bool[] tileNoAttach = new bool[0x6b];
        public static bool[] tileNoFail = new bool[0x6b];
        public static int[] tileShine = new int[0x6b];
        public static bool tilesLoaded = false;
        public static bool[] tileSolid = new bool[0x6b];
        public static bool[] tileSolidTop = new bool[0x6b];
        public static bool[] tileStone = new bool[0x6b];
        public static bool[] tileTable = new bool[0x6b];
        public static Texture2D[] tileTexture = new Texture2D[0x6b];
        public static bool[] tileWaterDeath = new bool[0x6b];
        public static double time = 13500.0;
        public static int timeOut = 120;
        public bool toggleFullscreen;
        private static Item toolTip = new Item();
        public static float topWorld = 0f;
        public static Item trashItem = new Item();
        public static Texture2D trashTexture;
        public static Texture2D[] treeBranchTexture = new Texture2D[3];
        public static Texture2D[] treeTopTexture = new Texture2D[3];
        private Process tServer = new Process();
        public static int updateTime = 0;
        public static bool verboseNetplay = false;
        public static string versionNumber = "v1.0.6.1";
        public static string versionNumber2 = "v1.0.6.1";
        public static bool[] wallHouse = new bool[0x15];
        public static Texture2D[] wallTexture = new Texture2D[0x15];
        public static Microsoft.Xna.Framework.Audio.WaveBank waveBank;
        public static float windSpeed = 0f;
        public static float windSpeedSpeed = 0f;
        public static int worldID;
        public static string worldName = "";
        public static string WorldPath = (SavePath + @"\Worlds");
        public static string worldPathName;
        public static double worldSurface;

        public Main()
        {
            //this.graphics = new GraphicsDeviceManager(this);
            base.Content.RootDirectory = "Content";
        }

        public void autoCreate(string newOpt)
        {
            if (newOpt == "0")
            {
                autoGen = false;
            }
            else if (newOpt == "1")
            {
                maxTilesX = 0x1068;
                maxTilesY = 0x4b0;
                autoGen = true;
            }
            else if (newOpt == "2")
            {
                maxTilesX = 0x189c;
                maxTilesY = 0x708;
                autoGen = true;
            }
            else if (newOpt == "3")
            {
                maxTilesX = 0x20d0;
                maxTilesY = 0x960;
                autoGen = true;
            }
        }

        public void AutoPass()
        {
            autoPass = true;
        }

        public void autoShut()
        {
            autoShutdown = true;
        }

        public static void BankCoins()
        {
            for (int i = 0; i < 20; i++)
            {
                if (((player[myPlayer].bank[i].type >= 0x47) && (player[myPlayer].bank[i].type <= 0x49)) && (player[myPlayer].bank[i].stack == player[myPlayer].bank[i].maxStack))
                {
                    player[myPlayer].bank[i].SetDefaults(player[myPlayer].bank[i].type + 1, false);
                    for (int j = 0; j < 20; j++)
                    {
                        if (((j != i) && (player[myPlayer].bank[j].type == player[myPlayer].bank[i].type)) && (player[myPlayer].bank[j].stack < player[myPlayer].bank[j].maxStack))
                        {
                            Item item1 = player[myPlayer].bank[j];
                            item1.stack++;
                            player[myPlayer].bank[i].SetDefaults(0, false);
                            BankCoins();
                        }
                    }
                }
            }
        }

        public static double CalculateDamage(int Damage, int Defense)
        {
            double num = Damage - (Defense * 0.5);
            if (num < 1.0)
            {
                num = 1.0;
            }
            return num;
        }

        public static void ChestCoins()
        {
            for (int i = 0; i < 20; i++)
            {
                if (((chest[player[myPlayer].chest].item[i].type >= 0x47) && (chest[player[myPlayer].chest].item[i].type <= 0x49)) && (chest[player[myPlayer].chest].item[i].stack == chest[player[myPlayer].chest].item[i].maxStack))
                {
                    chest[player[myPlayer].chest].item[i].SetDefaults(chest[player[myPlayer].chest].item[i].type + 1, false);
                    for (int j = 0; j < 20; j++)
                    {
                        if (((j != i) && (chest[player[myPlayer].chest].item[j].type == chest[player[myPlayer].chest].item[i].type)) && (chest[player[myPlayer].chest].item[j].stack < chest[player[myPlayer].chest].item[j].maxStack))
                        {
                            Item item1 = chest[player[myPlayer].chest].item[j];
                            item1.stack++;
                            chest[player[myPlayer].chest].item[i].SetDefaults(0, false);
                            ChestCoins();
                        }
                    }
                }
            }
        }

        public static int DamageVar(float dmg)
        {
            float num = dmg * (1f + (rand.Next(-15, 0x10) * 0.01f));
            return (int) Math.Round((double) num);
        }

        public void DedServ()
        {
            GameHooks.OnInitialize(true);
            rand = new Random();
            if (autoShutdown)
            {
                string lpWindowName = "Toaria" + rand.Next(0x7fffffff);
                Console.Title = lpWindowName;
                IntPtr hWnd = FindWindow(null, lpWindowName);
                if (hWnd != IntPtr.Zero)
                {
                    ShowWindow(hWnd, 0);
                }
            }
            else
            {
                Console.Title = "Toaria " + versionNumber2;
            }
            dedServ = true;
            showSplash = false;
            this.Initialize();
            DirectoryInfo di = new DirectoryInfo(WorldPath);
            while ((worldPathName == null) || (worldPathName == ""))
            {
                foreach (FileInfo fi in di.GetFiles("*.gz"))
                {
                    WorldGen.Decompress(fi);

                }
                LoadWorlds();
                bool flag = true;
                while (flag)
                {
                    Console.WriteLine("Toaria " + versionNumber2);
                    Console.WriteLine("");
                    for (int i = 0; i < numLoadWorlds; i++)
                    {
                        Console.WriteLine(string.Concat(new object[] { i + 1, '\t', '\t', loadWorld[i] }));
                    }
                    Console.WriteLine(string.Concat(new object[] { "n", '\t', '\t', "New World" }));
                    Console.WriteLine("d <number>" + '\t' + "Delete World");
                    Console.WriteLine("");
                    Console.Write("Choose World: ");
                    string str2 = Console.ReadLine();
                    try
                    {
                        Console.Clear();
                    }
                    catch
                    {
                    }
                    if ((str2.Length >= 2) && (str2.Substring(0, 2).ToLower() == "d "))
                    {
                        try
                        {
                            int index = Convert.ToInt32(str2.Substring(2)) - 1;
                            if (index < numLoadWorlds)
                            {
                                Console.WriteLine("Toaria " + versionNumber2);
                                Console.WriteLine("");
                                Console.WriteLine("Really delete " + loadWorld[index] + "?");
                                Console.Write("(y/n): ");
                                if (Console.ReadLine().ToLower() == "y")
                                {
                                    EraseWorld(index);
                                }
                            }
                        }
                        catch
                        {
                        }
                        try
                        {
                            Console.Clear();
                            continue;
                        }
                        catch
                        {
                            continue;
                        }
                    }
                    if ((str2 == "n") || (str2 == "N"))
                    {
                        bool flag2 = true;
                        while (flag2)
                        {
                            Console.WriteLine("Toaria " + versionNumber2);
                            Console.WriteLine("");
                            Console.WriteLine("1" + '\t' + "Small");
                            Console.WriteLine("2" + '\t' + "Medium");
                            Console.WriteLine("3" + '\t' + "Large");
                            Console.WriteLine("");
                            Console.Write("Choose size: ");
                            string str4 = Console.ReadLine();
                            try
                            {
                                switch (Convert.ToInt32(str4))
                                {
                                    case 1:
                                        maxTilesX = 0x1068;
                                        maxTilesY = 0x4b0;
                                        flag2 = false;
                                        goto Label_0352;

                                    case 2:
                                        maxTilesX = 0x189c;
                                        maxTilesY = 0x708;
                                        flag2 = false;
                                        goto Label_0352;

                                    case 3:
                                        maxTilesX = 0x20d0;
                                        maxTilesY = 0x960;
                                        flag2 = false;
                                        goto Label_0352;
                                }
                            }
                            catch
                            {
                            }
                        Label_0352:
                            try
                            {
                                Console.Clear();
                                continue;
                            }
                            catch
                            {
                                continue;
                            }
                        }
                        flag2 = true;
                        while (flag2)
                        {
                            Console.WriteLine("Toaria " + versionNumber2);
                            Console.WriteLine("");
                            Console.Write("Enter world name: ");
                            newWorldName = Console.ReadLine();
                            if (((newWorldName != "") && (newWorldName != " ")) && (newWorldName != null))
                            {
                                flag2 = false;
                            }
                            try
                            {
                                Console.Clear();
                                continue;
                            }
                            catch
                            {
                                continue;
                            }
                        }
                        worldName = newWorldName;
                        worldPathName = nextLoadWorld();
                        menuMode = 10;
                        WorldGen.CreateNewWorld();
                        flag2 = false;
                        while (menuMode == 10)
                        {
                            if (oldStatusText != statusText)
                            {
                                oldStatusText = statusText;
                                Console.WriteLine(statusText);
                            }
                        }
                        try
                        {
                            Console.Clear();
                            continue;
                        }
                        catch
                        {
                            continue;
                        }
                    }
                    try
                    {
                        int num4 = Convert.ToInt32(str2) - 1;
                        if ((num4 < 0) || (num4 >= numLoadWorlds))
                        {
                            continue;
                        }
                        bool flag3 = true;
                        while (flag3)
                        {
                            Console.WriteLine("Toaria " + versionNumber2);
                            Console.WriteLine("");
                            Console.Write("Max players (press enter for 8): ");
                            string str5 = Console.ReadLine();
                            try
                            {
                                if (str5 == "")
                                {
                                    str5 = "8";
                                }
                                int num5 = Convert.ToInt32(str5);
                                if ((num5 <= 0xff) && (num5 >= 1))
                                {
                                    maxNetPlayers = num5;
                                    flag3 = false;
                                }
                                flag3 = false;
                            }
                            catch
                            {
                            }
                            try
                            {
                                Console.Clear();
                                continue;
                            }
                            catch
                            {
                                continue;
                            }
                        }
                        flag3 = true;
                        while (flag3)
                        {
                            Console.WriteLine("Toaria " + versionNumber2);
                            Console.WriteLine("");
                            Console.Write("Server port (press enter for 7777): ");
                            string str6 = Console.ReadLine();
                            try
                            {
                                if (str6 == "")
                                {
                                    str6 = "7777";
                                }
                                int num6 = Convert.ToInt32(str6);
                                if (num6 <= 0xffff)
                                {
                                    Netplay.serverPort = num6;
                                    flag3 = false;
                                }
                            }
                            catch
                            {
                            }
                            try
                            {
                                Console.Clear();
                                continue;
                            }
                            catch
                            {
                                continue;
                            }
                        }
                        Console.WriteLine("Toaria " + versionNumber2);
                        Console.WriteLine("");
                        Console.Write("Server password (press enter for none): ");
                        Netplay.password = Console.ReadLine();
                        worldPathName = loadWorldPath[num4];
                        flag = false;
                        try
                        {
                            Console.Clear();
                        }
                        catch
                        {
                        }
                        continue;
                    }
                    catch
                    {
                        continue;
                    }
                }
            }
            try
            {
                Console.Clear();
            }
            catch
            {
            }
            WorldGen.serverLoadWorld();
            Console.WriteLine("Toaria " + versionNumber);
            Console.WriteLine("");
            while (!Netplay.ServerUp)
            {
                if (oldStatusText != statusText)
                {
                    oldStatusText = statusText;
                    Console.WriteLine(statusText);
                }
            }
            try
            {
                Console.Clear();
            }
            catch
            {
            }
            Console.WriteLine("Toaria " + versionNumber);
            Console.WriteLine("");
            Console.WriteLine("Listening on port " + Netplay.serverPort);
            Console.WriteLine("Type 'help' for a list of commands.");
            Console.WriteLine("");
            Console.Title = "Toaria: " + worldName;
            Stopwatch stopwatch = new Stopwatch();
            if (!autoShutdown)
            {
                startDedInput();
            }
            GameHooks.OnInitialize(false);
            stopwatch.Start();
            double num7 = 16.666666666666668;
            double num8 = 0.0;
            while (!Netplay.disconnect)
            {
                double elapsedMilliseconds = stopwatch.ElapsedMilliseconds;
                if ((elapsedMilliseconds + num8) >= num7)
                {
                    num8 += elapsedMilliseconds - num7;
                    stopwatch.Reset();
                    stopwatch.Start();
                    if (oldStatusText != statusText)
                    {
                        oldStatusText = statusText;
                        Console.WriteLine(statusText);
                    }
                    if (num8 > 1000.0)
                    {
                        num8 = 1000.0;
                    }
                    if (Netplay.anyClients)
                    {
                        GameTime time = new GameTime();
                        GameHooks.OnUpdate(true, time);
                        this.Update(time);
                        GameHooks.OnUpdate(false, time);
                    }
                    double num10 = stopwatch.ElapsedMilliseconds + num8;
                    if (num10 < num7)
                    {
                        int millisecondsTimeout = ((int) (num7 - num10)) - 1;
                        if (millisecondsTimeout > 1)
                        {
                            Thread.Sleep(millisecondsTimeout);
                            if (!Netplay.anyClients)
                            {
                                num8 = 0.0;
                                Thread.Sleep(10);
                            }
                        }
                    }
                }
                Thread.Sleep(0);
            }
        }

        private static void EraseWorld(int i)
        {
            try
            {
                File.Delete(loadWorldPath[i]);
                File.Delete(loadWorldPath[i] + ".bak");
                LoadWorlds();
            }
            catch
            {
            }
        }

        [DllImport("user32.dll")]
        public static extern IntPtr FindWindow(string lpClassName, string lpWindowName);
        public static string GetInputText(string oldString)
        {
            if (!hasFocus)
            {
                return oldString;
            }
            inputTextEnter = false;
            string str = oldString;
            if (str == null)
            {
                str = "";
            }
            oldInputText = inputText;
            inputText = Keyboard.GetState();
            bool flag = (((ushort) GetKeyState(20)) & 0xffff) != 0;
            bool flag2 = false;
            if (inputText.IsKeyDown(Keys.LeftShift) || inputText.IsKeyDown(Keys.RightShift))
            {
                flag2 = true;
            }
            Keys[] pressedKeys = inputText.GetPressedKeys();
            Keys[] keysArray2 = oldInputText.GetPressedKeys();
            bool flag3 = false;
            if (inputText.IsKeyDown(Keys.Back) && oldInputText.IsKeyDown(Keys.Back))
            {
                if (backSpaceCount == 0)
                {
                    backSpaceCount = 7;
                    flag3 = true;
                }
                backSpaceCount--;
            }
            else
            {
                backSpaceCount = 15;
            }
            for (int i = 0; i < pressedKeys.Length; i++)
            {
                bool flag4 = true;
                for (int j = 0; j < keysArray2.Length; j++)
                {
                    if (pressedKeys[i] == keysArray2[j])
                    {
                        flag4 = false;
                    }
                }
                string str2 = pressedKeys[i].ToString();
                if ((str2 == "Back") && (flag4 || flag3))
                {
                    if (str.Length > 0)
                    {
                        str = str.Substring(0, str.Length - 1);
                    }
                }
                else if (flag4)
                {
                    if (str2 == "Space")
                    {
                        str2 = " ";
                    }
                    else if (str2.Length == 1)
                    {
                        int num3 = Convert.ToInt32(Convert.ToChar(str2));
                        if (((num3 >= 0x41) && (num3 <= 90)) && ((!flag2 && !flag) || (flag2 && flag)))
                        {
                            num3 += 0x20;
                            str2 = Convert.ToChar(num3).ToString();
                        }
                    }
                    else if ((str2.Length == 2) && (str2.Substring(0, 1) == "D"))
                    {
                        str2 = str2.Substring(1, 1);
                        if (flag2)
                        {
                            switch (str2)
                            {
                                case "1":
                                    str2 = "!";
                                    break;

                                case "2":
                                    str2 = "@";
                                    break;

                                case "3":
                                    str2 = "#";
                                    break;

                                case "4":
                                    str2 = "$";
                                    break;

                                case "5":
                                    str2 = "%";
                                    break;

                                case "6":
                                    str2 = "^";
                                    break;

                                case "7":
                                    str2 = "&";
                                    break;

                                case "8":
                                    str2 = "*";
                                    break;

                                case "9":
                                    str2 = "(";
                                    break;

                                case "0":
                                    str2 = ")";
                                    break;
                            }
                        }
                    }
                    else if ((str2.Length == 7) && (str2.Substring(0, 6) == "NumPad"))
                    {
                        str2 = str2.Substring(6, 1);
                    }
                    else if (str2 == "Divide")
                    {
                        str2 = "/";
                    }
                    else if (str2 == "Multiply")
                    {
                        str2 = "*";
                    }
                    else if (str2 == "Subtract")
                    {
                        str2 = "-";
                    }
                    else if (str2 == "Add")
                    {
                        str2 = "+";
                    }
                    else if (str2 == "Decimal")
                    {
                        str2 = ".";
                    }
                    else
                    {
                        if (str2 == "OemSemicolon")
                        {
                            str2 = ";";
                        }
                        else if (str2 == "OemPlus")
                        {
                            str2 = "=";
                        }
                        else if (str2 == "OemComma")
                        {
                            str2 = ",";
                        }
                        else if (str2 == "OemMinus")
                        {
                            str2 = "-";
                        }
                        else if (str2 == "OemPeriod")
                        {
                            str2 = ".";
                        }
                        else if (str2 == "OemQuestion")
                        {
                            str2 = "/";
                        }
                        else if (str2 == "OemTilde")
                        {
                            str2 = "`";
                        }
                        else if (str2 == "OemOpenBrackets")
                        {
                            str2 = "[";
                        }
                        else if (str2 == "OemPipe")
                        {
                            str2 = @"\";
                        }
                        else if (str2 == "OemCloseBrackets")
                        {
                            str2 = "]";
                        }
                        else if (str2 == "OemQuotes")
                        {
                            str2 = "'";
                        }
                        else if (str2 == "OemBackslash")
                        {
                            str2 = @"\";
                        }
                        if (flag2)
                        {
                            if (str2 == ";")
                            {
                                str2 = ":";
                            }
                            else if (str2 == "=")
                            {
                                str2 = "+";
                            }
                            else if (str2 == ",")
                            {
                                str2 = "<";
                            }
                            else if (str2 == "-")
                            {
                                str2 = "_";
                            }
                            else if (str2 == ".")
                            {
                                str2 = ">";
                            }
                            else if (str2 == "/")
                            {
                                str2 = "?";
                            }
                            else if (str2 == "`")
                            {
                                str2 = "~";
                            }
                            else if (str2 == "[")
                            {
                                str2 = "{";
                            }
                            else if (str2 == @"\")
                            {
                                str2 = "|";
                            }
                            else if (str2 == "]")
                            {
                                str2 = "}";
                            }
                            else if (str2 == "'")
                            {
                                str2 = "\"";
                            }
                        }
                    }
                    if (str2 == "Enter")
                    {
                        inputTextEnter = true;
                    }
                    if (str2.Length == 1)
                    {
                        str = str + str2;
                    }
                }
            }
            return str;
        }

        [DllImport("user32.dll", CharSet=CharSet.Auto, ExactSpelling=true)]
        public static extern short GetKeyState(int keyCode);
        [DllImport("User32")]
        private static extern int GetMenuItemCount(IntPtr hWnd);
        [DllImport("User32")]
        private static extern IntPtr GetSystemMenu(IntPtr hWnd, bool bRevert);

        protected override void Initialize()
        {
            debuff[20] = true;
            debuff[0x15] = true;
            debuff[0x16] = true;
            debuff[0x17] = true;
            debuff[0x18] = true;
            debuff[0x19] = true;
            buffName[1] = "Obsidian Skin";
            buffTip[1] = "Immune to lava";
            buffName[2] = "Regeneration";
            buffTip[2] = "Provides life regeneration";
            buffName[3] = "Swiftness";
            buffTip[3] = "%25 increased movement speed";
            buffName[4] = "Gills";
            buffTip[4] = "Breathe water instead of air";
            buffName[5] = "Ironskin";
            buffTip[5] = "Increase defense by 8";
            buffName[6] = "Mana Regeneration";
            buffTip[6] = "Increased mana regeneration";
            buffName[7] = "Magic Power";
            buffTip[7] = "20% increased magic damage";
            buffName[8] = "Featherfall";
            buffTip[8] = "Press UP or DOWN to control speed of descent";
            buffName[9] = "Spelunker";
            buffTip[9] = "Shows the location of treasure and ore";
            buffName[10] = "Invisibility";
            buffTip[10] = "Grants invisibility";
            buffName[11] = "Shine";
            buffTip[11] = "Emitting light";
            buffName[12] = "Night Owl";
            buffTip[12] = "Increased night vision";
            buffName[13] = "Battle";
            buffTip[13] = "Increased enemy spawn rate";
            buffName[14] = "Thorns";
            buffTip[14] = "Attackers also take damage";
            buffName[15] = "Water Walking";
            buffTip[15] = "Press DOWN to enter water";
            buffName[0x10] = "Archery";
            buffTip[0x10] = "20% increased arrow damage and speed";
            buffName[0x11] = "Hunter";
            buffTip[0x11] = "Shows the location of enemies";
            buffName[0x12] = "Gravitation";
            buffTip[0x12] = "Press UP or DOWN to reverse gravity";
            buffName[0x13] = "Orb of Light";
            buffTip[0x13] = "A magical orb that provides light";
            buffName[20] = "Poisoned";
            buffTip[20] = "Slowly losing life";
            buffName[0x15] = "Potion Sickness";
            buffTip[0x15] = "Cannot consume anymore healing items";
            buffName[0x16] = "Darkness";
            buffTip[0x16] = "Decreased light vision";
            buffName[0x17] = "Cursed";
            buffTip[0x17] = "Cannot use any items";
            buffName[0x18] = "On Fire!";
            buffTip[0x18] = "Slowly losing life";
            buffName[0x19] = "Tipsy";
            buffTip[0x19] = "Increased melee abilities, lowered defense";
            buffName[0x1a] = "Well Fed";
            buffTip[0x1a] = "Minor improvements to all stats";
            for (int i = 0; i < 10; i++)
            {
                recentWorld[i] = "";
                recentIP[i] = "";
                recentPort[i] = 0;
            }
            if (rand == null)
            {
                rand = new Random((int) DateTime.Now.Ticks);
            }
            if (WorldGen.genRand == null)
            {
                WorldGen.genRand = new Random((int) DateTime.Now.Ticks);
            }
            switch (rand.Next(15))
            {
                case 0:
                    base.Window.Title = "Terraria: Dig Peon, Dig!";
                    break;

                case 1:
                    base.Window.Title = "Terraria: Epic Dirt";
                    break;

                case 2:
                    base.Window.Title = "Terraria: Hey Guys!";
                    break;

                case 3:
                    base.Window.Title = "Terraria: Sand is Overpowered";
                    break;

                case 4:
                    base.Window.Title = "Terraria Part 3: The Return of the Guide";
                    break;

                case 5:
                    base.Window.Title = "Terraria: A Bunnies Tale";
                    break;

                case 6:
                    base.Window.Title = "Terraria: Dr. Bones and The Temple of Blood Moon";
                    break;

                case 7:
                    base.Window.Title = "Terraria: Slimeassic Park";
                    break;

                case 8:
                    base.Window.Title = "Terraria: The Grass is Greener on This Side";
                    break;

                case 9:
                    base.Window.Title = "Terraria: Small Blocks, Not for Children Under the Age of 5";
                    break;

                case 10:
                    base.Window.Title = "Terraria: Digger T' Blocks";
                    break;

                case 11:
                    base.Window.Title = "Terraria: There is No Cow Layer";
                    break;

                case 12:
                    base.Window.Title = "Terraria: Suspicous Looking Eyeballs";
                    break;

                case 13:
                    base.Window.Title = "Terraria: Purple Grass!";
                    break;

                case 14:
                    base.Window.Title = "Terraria: Noone Dug Behind!";
                    break;

                default:
                    base.Window.Title = "Terraria: Shut Up and Dig Gaiden!";
                    break;
            }
            tileShine[0x16] = 0x47e;
            tileShine[6] = 0x47e;
            tileShine[7] = 0x44c;
            tileShine[8] = 0x3e8;
            tileShine[9] = 0x41a;
            tileShine[12] = 0x3e8;
            tileShine[0x15] = 0x3e8;
            tileShine[0x3f] = 900;
            tileShine[0x40] = 900;
            tileShine[0x41] = 900;
            tileShine[0x42] = 900;
            tileShine[0x43] = 900;
            tileShine[0x44] = 900;
            tileShine[0x2d] = 0x76c;
            tileShine[0x2e] = 0x7d0;
            tileShine[0x2f] = 0x834;
            tileMergeDirt[1] = true;
            tileMergeDirt[6] = true;
            tileMergeDirt[7] = true;
            tileMergeDirt[8] = true;
            tileMergeDirt[9] = true;
            tileMergeDirt[0x16] = true;
            tileMergeDirt[0x19] = true;
            tileMergeDirt[0x25] = true;
            tileMergeDirt[40] = true;
            tileMergeDirt[0x35] = true;
            tileMergeDirt[0x38] = true;
            tileMergeDirt[0x3b] = true;
            tileCut[3] = true;
            tileCut[0x18] = true;
            tileCut[0x1c] = true;
            tileCut[0x20] = true;
            tileCut[0x33] = true;
            tileCut[0x34] = true;
            tileCut[0x3d] = true;
            tileCut[0x3e] = true;
            tileCut[0x45] = true;
            tileCut[0x47] = true;
            tileCut[0x49] = true;
            tileCut[0x4a] = true;
            tileCut[0x52] = true;
            tileCut[0x53] = true;
            tileCut[0x54] = true;
            tileAlch[0x52] = true;
            tileAlch[0x53] = true;
            tileAlch[0x54] = true;
            tileFrameImportant[0x52] = true;
            tileFrameImportant[0x53] = true;
            tileFrameImportant[0x54] = true;
            tileFrameImportant[0x55] = true;
            tileFrameImportant[100] = true;
            tileFrameImportant[0x68] = true;
            tileFrameImportant[0x69] = true;
            tileLavaDeath[0x68] = true;
            tileLavaDeath[0x69] = true;
            tileSolid[0] = true;
            tileBlockLight[0] = true;
            tileSolid[1] = true;
            tileBlockLight[1] = true;
            tileSolid[2] = true;
            tileBlockLight[2] = true;
            tileSolid[3] = false;
            tileNoAttach[3] = true;
            tileNoFail[3] = true;
            tileSolid[4] = false;
            tileNoAttach[4] = true;
            tileNoFail[4] = true;
            tileNoFail[0x18] = true;
            tileSolid[5] = false;
            tileSolid[6] = true;
            tileBlockLight[6] = true;
            tileSolid[7] = true;
            tileBlockLight[7] = true;
            tileSolid[8] = true;
            tileBlockLight[8] = true;
            tileSolid[9] = true;
            tileBlockLight[9] = true;
            tileBlockLight[10] = true;
            tileSolid[10] = true;
            tileNoAttach[10] = true;
            tileBlockLight[10] = true;
            tileSolid[11] = false;
            tileSolidTop[0x13] = true;
            tileSolid[0x13] = true;
            tileSolid[0x16] = true;
            tileSolid[0x17] = true;
            tileSolid[0x19] = true;
            tileSolid[30] = true;
            tileNoFail[0x20] = true;
            tileBlockLight[0x20] = true;
            tileSolid[0x25] = true;
            tileBlockLight[0x25] = true;
            tileSolid[0x26] = true;
            tileBlockLight[0x26] = true;
            tileSolid[0x27] = true;
            tileBlockLight[0x27] = true;
            tileSolid[40] = true;
            tileBlockLight[40] = true;
            tileSolid[0x29] = true;
            tileBlockLight[0x29] = true;
            tileSolid[0x2b] = true;
            tileBlockLight[0x2b] = true;
            tileSolid[0x2c] = true;
            tileBlockLight[0x2c] = true;
            tileSolid[0x2d] = true;
            tileBlockLight[0x2d] = true;
            tileSolid[0x2e] = true;
            tileBlockLight[0x2e] = true;
            tileSolid[0x2f] = true;
            tileBlockLight[0x2f] = true;
            tileSolid[0x30] = true;
            tileBlockLight[0x30] = true;
            tileSolid[0x35] = true;
            tileBlockLight[0x35] = true;
            tileSolid[0x36] = true;
            tileBlockLight[0x34] = true;
            tileSolid[0x38] = true;
            tileBlockLight[0x38] = true;
            tileSolid[0x39] = true;
            tileBlockLight[0x39] = true;
            tileSolid[0x3a] = true;
            tileBlockLight[0x3a] = true;
            tileSolid[0x3b] = true;
            tileBlockLight[0x3b] = true;
            tileSolid[60] = true;
            tileBlockLight[60] = true;
            tileSolid[0x3f] = true;
            tileBlockLight[0x3f] = true;
            tileStone[0x3f] = true;
            tileSolid[0x40] = true;
            tileBlockLight[0x40] = true;
            tileStone[0x40] = true;
            tileSolid[0x41] = true;
            tileBlockLight[0x41] = true;
            tileStone[0x41] = true;
            tileSolid[0x42] = true;
            tileBlockLight[0x42] = true;
            tileStone[0x42] = true;
            tileSolid[0x43] = true;
            tileBlockLight[0x43] = true;
            tileStone[0x43] = true;
            tileSolid[0x44] = true;
            tileBlockLight[0x44] = true;
            tileStone[0x44] = true;
            tileSolid[0x4b] = true;
            tileBlockLight[0x4b] = true;
            tileSolid[0x4c] = true;
            tileBlockLight[0x4c] = true;
            tileSolid[70] = true;
            tileBlockLight[70] = true;
            tileBlockLight[0x33] = true;
            tileNoFail[50] = true;
            tileNoAttach[50] = true;
            tileDungeon[0x29] = true;
            tileDungeon[0x2b] = true;
            tileDungeon[0x2c] = true;
            tileBlockLight[30] = true;
            tileBlockLight[0x19] = true;
            tileBlockLight[0x17] = true;
            tileBlockLight[0x16] = true;
            tileBlockLight[0x3e] = true;
            tileSolidTop[0x12] = true;
            tileSolidTop[14] = true;
            tileSolidTop[0x10] = true;
            tileNoAttach[20] = true;
            tileNoAttach[0x13] = true;
            tileNoAttach[13] = true;
            tileNoAttach[14] = true;
            tileNoAttach[15] = true;
            tileNoAttach[0x10] = true;
            tileNoAttach[0x11] = true;
            tileNoAttach[0x12] = true;
            tileNoAttach[0x13] = true;
            tileNoAttach[0x15] = true;
            tileNoAttach[0x1b] = true;
            tileFrameImportant[3] = true;
            tileFrameImportant[5] = true;
            tileFrameImportant[10] = true;
            tileFrameImportant[11] = true;
            tileFrameImportant[12] = true;
            tileFrameImportant[13] = true;
            tileFrameImportant[14] = true;
            tileFrameImportant[15] = true;
            tileFrameImportant[0x10] = true;
            tileFrameImportant[0x11] = true;
            tileFrameImportant[0x12] = true;
            tileFrameImportant[20] = true;
            tileFrameImportant[0x15] = true;
            tileFrameImportant[0x18] = true;
            tileFrameImportant[0x1a] = true;
            tileFrameImportant[0x1b] = true;
            tileFrameImportant[0x1c] = true;
            tileFrameImportant[0x1d] = true;
            tileFrameImportant[0x1f] = true;
            tileFrameImportant[0x21] = true;
            tileFrameImportant[0x22] = true;
            tileFrameImportant[0x23] = true;
            tileFrameImportant[0x24] = true;
            tileFrameImportant[0x2a] = true;
            tileFrameImportant[50] = true;
            tileFrameImportant[0x37] = true;
            tileFrameImportant[0x3d] = true;
            tileFrameImportant[0x47] = true;
            tileFrameImportant[0x48] = true;
            tileFrameImportant[0x49] = true;
            tileFrameImportant[0x4a] = true;
            tileFrameImportant[0x4d] = true;
            tileFrameImportant[0x4e] = true;
            tileFrameImportant[0x4f] = true;
            tileFrameImportant[0x51] = true;
            tileFrameImportant[0x67] = true;
            tileTable[14] = true;
            tileTable[0x12] = true;
            tileTable[0x13] = true;
            tileNoAttach[0x56] = true;
            tileNoAttach[0x57] = true;
            tileNoAttach[0x58] = true;
            tileNoAttach[0x59] = true;
            tileNoAttach[90] = true;
            tileFrameImportant[0x56] = true;
            tileFrameImportant[0x57] = true;
            tileFrameImportant[0x58] = true;
            tileFrameImportant[0x59] = true;
            tileFrameImportant[90] = true;
            tileLavaDeath[0x56] = true;
            tileLavaDeath[0x57] = true;
            tileLavaDeath[0x58] = true;
            tileLavaDeath[0x59] = true;
            tileFrameImportant[0x65] = true;
            tileLavaDeath[0x65] = true;
            tileTable[0x65] = true;
            tileNoAttach[0x65] = true;
            tileFrameImportant[0x66] = true;
            tileLavaDeath[0x66] = true;
            tileNoAttach[0x66] = true;
            tileNoAttach[0x5e] = true;
            tileNoAttach[0x5f] = true;
            tileNoAttach[0x60] = true;
            tileNoAttach[0x61] = true;
            tileNoAttach[0x62] = true;
            tileNoAttach[0x63] = true;
            tileFrameImportant[0x5e] = true;
            tileFrameImportant[0x5f] = true;
            tileFrameImportant[0x60] = true;
            tileFrameImportant[0x61] = true;
            tileFrameImportant[0x62] = true;
            tileFrameImportant[0x63] = true;
            tileFrameImportant[0x6a] = true;
            tileLavaDeath[0x5e] = true;
            tileLavaDeath[0x5f] = true;
            tileLavaDeath[0x60] = true;
            tileLavaDeath[0x61] = true;
            tileLavaDeath[0x62] = true;
            tileLavaDeath[0x63] = true;
            tileLavaDeath[100] = true;
            tileLavaDeath[0x67] = true;
            tileTable[0x57] = true;
            tileTable[0x58] = true;
            tileSolidTop[0x57] = true;
            tileSolidTop[0x58] = true;
            tileSolidTop[0x65] = true;
            tileNoAttach[0x5b] = true;
            tileFrameImportant[0x5b] = true;
            tileLavaDeath[0x5b] = true;
            tileNoAttach[0x5c] = true;
            tileFrameImportant[0x5c] = true;
            tileLavaDeath[0x5c] = true;
            tileNoAttach[0x5d] = true;
            tileFrameImportant[0x5d] = true;
            tileLavaDeath[0x5d] = true;
            tileWaterDeath[4] = true;
            tileWaterDeath[0x33] = true;
            tileWaterDeath[0x5d] = true;
            tileWaterDeath[0x62] = true;
            tileLavaDeath[3] = true;
            tileLavaDeath[5] = true;
            tileLavaDeath[10] = true;
            tileLavaDeath[11] = true;
            tileLavaDeath[12] = true;
            tileLavaDeath[13] = true;
            tileLavaDeath[14] = true;
            tileLavaDeath[15] = true;
            tileLavaDeath[0x10] = true;
            tileLavaDeath[0x11] = true;
            tileLavaDeath[0x12] = true;
            tileLavaDeath[0x13] = true;
            tileLavaDeath[20] = true;
            tileLavaDeath[0x1b] = true;
            tileLavaDeath[0x1c] = true;
            tileLavaDeath[0x1d] = true;
            tileLavaDeath[0x20] = true;
            tileLavaDeath[0x21] = true;
            tileLavaDeath[0x22] = true;
            tileLavaDeath[0x23] = true;
            tileLavaDeath[0x24] = true;
            tileLavaDeath[0x2a] = true;
            tileLavaDeath[0x31] = true;
            tileLavaDeath[50] = true;
            tileLavaDeath[0x34] = true;
            tileLavaDeath[0x37] = true;
            tileLavaDeath[0x3d] = true;
            tileLavaDeath[0x3e] = true;
            tileLavaDeath[0x45] = true;
            tileLavaDeath[0x47] = true;
            tileLavaDeath[0x48] = true;
            tileLavaDeath[0x49] = true;
            tileLavaDeath[0x4a] = true;
            tileLavaDeath[0x4f] = true;
            tileLavaDeath[80] = true;
            tileLavaDeath[0x51] = true;
            tileLavaDeath[0x6a] = true;
            wallHouse[1] = true;
            wallHouse[4] = true;
            wallHouse[5] = true;
            wallHouse[6] = true;
            wallHouse[10] = true;
            wallHouse[11] = true;
            wallHouse[12] = true;
            wallHouse[0x10] = true;
            wallHouse[0x11] = true;
            wallHouse[0x12] = true;
            wallHouse[0x13] = true;
            wallHouse[20] = true;
            tileNoFail[0x20] = true;
            tileNoFail[0x3d] = true;
            tileNoFail[0x45] = true;
            tileNoFail[0x49] = true;
            tileNoFail[0x4a] = true;
            tileNoFail[0x52] = true;
            tileNoFail[0x53] = true;
            tileNoFail[0x54] = true;
            for (int j = 0; j < 0x6b; j++)
            {
                tileName[j] = "";
            }
            tileName[13] = "Bottle";
            tileName[14] = "Table";
            tileName[15] = "Chair";
            tileName[0x10] = "Anvil";
            tileName[0x11] = "Furnace";
            tileName[0x12] = "Workbench";
            tileName[0x1a] = "Demon Altar";
            tileName[0x4d] = "Hellforge";
            tileName[0x56] = "Loom";
            tileName[0x5e] = "Keg";
            tileName[0x60] = "Cooking Pot";
            tileName[0x6a] = "Sawmill";
            for (int k = 0; k < maxMenuItems; k++)
            {
                this.menuItemScale[k] = 0.8f;
            }
            for (int m = 0; m < 0x3e9; m++)
            {
                dust[m] = new Dust();
            }
            for (int n = 0; n < 0xc9; n++)
            {
                Main.item[n] = new Item();
            }
            for (int num7 = 0; num7 < 0x3e9; num7++)
            {
                npc[num7] = new NPC();
                npc[num7].whoAmI = num7;
            }
            for (int num8 = 0; num8 < 0x100; num8++)
            {
                player[num8] = new Player();
            }
            for (int num9 = 0; num9 < 0x3e9; num9++)
            {
                projectile[num9] = new Projectile();
            }
            for (int num10 = 0; num10 < 0xc9; num10++)
            {
                gore[num10] = new Gore();
            }
            for (int num12 = 0; num12 < 100; num12++)
            {
                combatText[num12] = new CombatText();
            }
            for (int num13 = 0; num13 < 100; num13++)
            {
                itemText[num13] = new ItemText();
            }
            for (int num14 = 0; num14 < 0x16c; num14++)
            {
                Item item = new Item();
                item.SetDefaults(num14, false);
                itemName[num14] = item.name;
            }
            for (int num15 = 0; num15 < Recipe.maxRecipes; num15++)
            {
                recipe[num15] = new Recipe();
                availableRecipeY[num15] = 0x41 * num15;
            }
            Recipe.SetupRecipes();
            for (int num16 = 0; num16 < numChatLines; num16++)
            {
                chatLine[num16] = new ChatLine();
            }
            for (int num17 = 0; num17 < Liquid.resLiquid; num17++)
            {
                liquid[num17] = new Liquid();
            }
            for (int num18 = 0; num18 < 0x2710; num18++)
            {
                liquidBuffer[num18] = new LiquidBuffer();
            }
            this.shop[0] = new Chest();
            this.shop[1] = new Chest();
            this.shop[1].SetupShop(1);
            this.shop[2] = new Chest();
            this.shop[2].SetupShop(2);
            this.shop[3] = new Chest();
            this.shop[3].SetupShop(3);
            this.shop[4] = new Chest();
            this.shop[4].SetupShop(4);
            this.shop[5] = new Chest();
            this.shop[5].SetupShop(5);
            teamColor[0] = Color.White;
            teamColor[1] = new Color(230, 40, 20);
            teamColor[2] = new Color(20, 200, 30);
            teamColor[3] = new Color(0x4b, 90, 0xff);
            teamColor[4] = new Color(200, 180, 0);
            if (menuMode == 1)
            {
                LoadPlayers();
            }
            Netplay.Init();
            if (skipMenu)
            {
                WorldGen.clearWorld();
                gameMenu = false;
                LoadPlayers();
                player[myPlayer] = (Player) loadPlayer[0].Clone();
                PlayerPath = loadPlayerPath[0];
                LoadWorlds();
                WorldGen.generateWorld(-1);
                WorldGen.EveryTileFrame();
                player[myPlayer].Spawn();
            }
            else
            {
                IntPtr systemMenu = GetSystemMenu(base.Window.Handle, false);
                int menuItemCount = GetMenuItemCount(systemMenu);
                RemoveMenu(systemMenu, menuItemCount - 1, 0x400);
            }
        }

        private static void InvasionWarning()
        {
            if (invasionType != 0)
            {
                string newText = "";
                if (invasionSize <= 0)
                {
                    newText = "The goblin army has been defeated!";
                }
                else if (invasionX < spawnTileX)
                {
                    newText = "A goblin army is approaching from the west!";
                }
                else if (invasionX > spawnTileX)
                {
                    newText = "A goblin army is approaching from the east!";
                }
                else
                {
                    newText = "The goblin army has arrived!";
                }
                if (netMode == 2)
                {
                    NetMessage.SendData(0x19, -1, -1, newText, 0xff, 175f, 75f, 255f, 0);
                }
            }
        }

        public void LoadDedConfig(string configPath)
        {
            if (File.Exists(configPath))
            {
                using (StreamReader reader = new StreamReader(configPath))
                {
                    string str;
                    while ((str = reader.ReadLine()) != null)
                    {
                        try
                        {
                            if ((str.Length > 6) && (str.Substring(0, 6).ToLower() == "world="))
                            {
                                worldPathName = str.Substring(6);
                            }
                            if ((str.Length > 5) && (str.Substring(0, 5).ToLower() == "port="))
                            {
                                string str3 = str.Substring(5);
                                try
                                {
                                    Netplay.serverPort = Convert.ToInt32(str3);
                                }
                                catch
                                {
                                }
                            }
                            if ((str.Length > 11) && (str.Substring(0, 11).ToLower() == "maxplayers="))
                            {
                                string str4 = str.Substring(11);
                                try
                                {
                                    maxNetPlayers = Convert.ToInt32(str4);
                                }
                                catch
                                {
                                }
                            }
                            if ((str.Length > 9) && (str.Substring(0, 9).ToLower() == "password="))
                            {
                                Netplay.password = str.Substring(9);
                            }
                            if ((str.Length > 5) && (str.Substring(0, 5).ToLower() == "motd="))
                            {
                                motd = str.Substring(5);
                            }
                            if ((str.Length >= 10) && (str.Substring(0, 10).ToLower() == "worldpath="))
                            {
                                WorldPath = str.Substring(10);
                            }
                            if ((str.Length >= 10) && (str.Substring(0, 10).ToLower() == "worldname="))
                            {
                                worldName = str.Substring(10);
                            }
                            if ((str.Length > 8) && (str.Substring(0, 8).ToLower() == "banlist="))
                            {
                                Netplay.banFile = str.Substring(8);
                            }
                            if ((str.Length > 11) && (str.Substring(0, 11).ToLower() == "autocreate="))
                            {
                                switch (str.Substring(11))
                                {
                                    case "0":
                                        autoGen = false;
                                        goto Label_0291;

                                    case "1":
                                        maxTilesX = 0x1068;
                                        maxTilesY = 0x4b0;
                                        autoGen = true;
                                        goto Label_0291;

                                    case "2":
                                        maxTilesX = 0x189c;
                                        maxTilesY = 0x708;
                                        autoGen = true;
                                        break;

                                    case "3":
                                        maxTilesX = 0x20d0;
                                        maxTilesY = 0x960;
                                        autoGen = true;
                                        break;
                                }
                            }
                        Label_0291:
                            if (((str.Length > 7) && (str.Substring(0, 7).ToLower() == "secure=")) && (str.Substring(7) == "1"))
                            {
                                Netplay.spamCheck = true;
                            }
                            continue;
                        }
                        catch
                        {
                            continue;
                        }
                    }
                }
            }
        }

        public void loadLib(string path)
        {
            libPath = path;
            LoadLibrary(libPath);
        }

        [DllImport("kernel32.dll")]
        public static extern IntPtr LoadLibrary(string dllToLoad);
        private static void LoadPlayers()
        {
            Directory.CreateDirectory(PlayerPath);
            string[] files = Directory.GetFiles(PlayerPath, "*.plr");
            int length = files.Length;
            if (length > 5)
            {
                length = 5;
            }
            for (int i = 0; i < 5; i++)
            {
                loadPlayer[i] = new Player();
                if (i < length)
                {
                    loadPlayerPath[i] = files[i];
                    loadPlayer[i] = Player.LoadPlayer(loadPlayerPath[i]);
                }
            }
            numLoadPlayers = length;
        }

        public static void LoadWorlds()
        {
            Directory.CreateDirectory(WorldPath);
            string[] files = Directory.GetFiles(WorldPath, "*.wld");
            int length = files.Length;
            if (!dedServ && (length > 5))
            {
                length = 5;
            }
            for (int i = 0; i < length; i++)
            {
                loadWorldPath[i] = files[i];
                try
                {
                    using (FileStream stream = new FileStream(loadWorldPath[i], FileMode.Open))
                    {
                            using (BinaryReader reader = new BinaryReader(stream))
                            {
                                reader.ReadInt32();
                                loadWorld[i] = reader.ReadString();
                                reader.Close();
                            }
                    }
                }
                catch
                {
                    loadWorld[i] = loadWorldPath[i];
                }
            }
            numLoadWorlds = length;
        }

        public void NewMOTD(string newMOTD)
        {
            motd = newMOTD;
        }

        public static void NewText(string newText, byte R = 0xff, byte G = 0xff, byte B = 0xff)
        {
            for (int i = numChatLines - 1; i > 0; i--)
            {
                chatLine[i].text = chatLine[i - 1].text;
                chatLine[i].showTime = chatLine[i - 1].showTime;
                chatLine[i].color = chatLine[i - 1].color;
            }
            if (((R == 0) && (G == 0)) && (B == 0))
            {
                chatLine[0].color = Color.White;
            }
            else
            {
                chatLine[0].color = new Color(R, G, B);
            }
            chatLine[0].text = newText;
            chatLine[0].showTime = chatLength;
            PlaySound(12, -1, -1, 1);
        }

        private static string nextLoadPlayer()
        {
            int num = 1;
        Label_0008:;
            if (File.Exists(string.Concat(new object[] { PlayerPath, @"\player", num, ".plr" })))
            {
                num++;
                goto Label_0008;
            }
            return string.Concat(new object[] { PlayerPath, @"\player", num, ".plr" });
        }

        private static string nextLoadWorld()
        {
            int num = 1;
        Label_0008:;
            if (File.Exists(string.Concat(new object[] { WorldPath, @"\world", num, ".wld" })))
            {
                num++;
                goto Label_0008;
            }
            return string.Concat(new object[] { WorldPath, @"\world", num, ".wld" });
        }

        protected void OpenRecent()
        {
            try
            {
                if (File.Exists(SavePath + @"\servers.dat"))
                {
                    using (FileStream stream = new FileStream(SavePath + @"\servers.dat", FileMode.Open))
                    {
                        using (BinaryReader reader = new BinaryReader(stream))
                        {
                            reader.ReadInt32();
                            for (int i = 0; i < 10; i++)
                            {
                                recentWorld[i] = reader.ReadString();
                                recentIP[i] = reader.ReadString();
                                recentPort[i] = reader.ReadInt32();
                            }
                        }
                    }
                }
            }
            catch
            {
            }
        }

        protected void OpenSettings()
        {
        }

        public static void PlaySound(int type, int x = -1, int y = -1, int Style = 1)
        {
            if (dedServ || (soundVolume == 0f))
            {
                return;
            }
        }

        protected void QuitGame()
        {
            base.Exit();
        }

        [DllImport("User32")]
        private static extern int RemoveMenu(IntPtr hMenu, int nPosition, int wFlags);
        public static void SaveRecent()
        {
            Directory.CreateDirectory(SavePath);
            try
            {
                File.SetAttributes(SavePath + @"\servers.dat", FileAttributes.Normal);
            }
            catch
            {
            }
            try
            {
                using (FileStream stream = new FileStream(SavePath + @"\servers.dat", FileMode.Create))
                {
                    using (BinaryWriter writer = new BinaryWriter(stream))
                    {
                        writer.Write(curRelease);
                        for (int i = 0; i < 10; i++)
                        {
                            writer.Write(recentWorld[i]);
                            writer.Write(recentIP[i]);
                            writer.Write(recentPort[i]);
                        }
                    }
                }
            }
            catch
            {
            }
        }

        public void SetNetPlayers(int mPlayers)
        {
            maxNetPlayers = mPlayers;
        }

        public void SetWorld(string wrold)
        {
            worldPathName = wrold;
        }

        public void SetWorldName(string wrold)
        {
            worldName = wrold;
        }

        [DllImport("user32.dll")]
        private static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);
        public static void startDedInput()
        {
            ThreadPool.QueueUserWorkItem(new WaitCallback(Main.startDedInputCallBack), 1);
        }

        public static void startDedInputCallBack(object threadContext)
        {
            while (!Netplay.disconnect)
            {
                Console.Write(": ");
                string cmd = Console.ReadLine();
                if (!ServerHooks.OnCommand(cmd))
                {
                    string str2 = cmd;
                    cmd = cmd.ToLower();
                    try
                    {
                        if (cmd == "help")
                        {
                            Console.WriteLine("Available commands:");
                            Console.WriteLine("");
                            Console.WriteLine(string.Concat(new object[] { "help ", '\t', '\t', " Displays a list of commands." }));
                            Console.WriteLine("playing " + '\t' + " Shows the list of players");
                            Console.WriteLine(string.Concat(new object[] { "clear ", '\t', '\t', " Clear the console window." }));
                            Console.WriteLine(string.Concat(new object[] { "exit ", '\t', '\t', " Shutdown the server and save." }));
                            Console.WriteLine("exit-nosave " + '\t' + " Shutdown the server without saving.");
                            Console.WriteLine(string.Concat(new object[] { "save ", '\t', '\t', " Save the game world." }));
                            Console.WriteLine("kick <player> " + '\t' + " Kicks a player from the server.");
                            Console.WriteLine("ban <player> " + '\t' + " Bans a player from the server.");
                            Console.WriteLine("password" + '\t' + " Show password.");
                            Console.WriteLine("password <pass>" + '\t' + " Change password.");
                            Console.WriteLine(string.Concat(new object[] { "version", '\t', '\t', " Print version number." }));
                            Console.WriteLine(string.Concat(new object[] { "time", '\t', '\t', " Display game time." }));
                            Console.WriteLine(string.Concat(new object[] { "port", '\t', '\t', " Print the listening port." }));
                            Console.WriteLine("maxplayers" + '\t' + " Print the max number of players.");
                            Console.WriteLine("say <words>" + '\t' + " Send a message.");
                            Console.WriteLine(string.Concat(new object[] { "motd", '\t', '\t', " Print MOTD." }));
                            Console.WriteLine("motd <words>" + '\t' + " Change MOTD.");
                            Console.WriteLine(string.Concat(new object[] { "dawn", '\t', '\t', " Change time to dawn." }));
                            Console.WriteLine(string.Concat(new object[] { "noon", '\t', '\t', " Change time to noon." }));
                            Console.WriteLine(string.Concat(new object[] { "dusk", '\t', '\t', " Change time to dusk." }));
                            Console.WriteLine("midnight" + '\t' + " Change time to midnight.");
                            Console.WriteLine(string.Concat(new object[] { "settle", '\t', '\t', " Settle all water." }));
                        }
                        else if (cmd == "settle")
                        {
                            if (!Liquid.panicMode)
                            {
                                Liquid.StartPanic();
                            }
                            else
                            {
                                Console.WriteLine("Water is already settling");
                            }
                        }
                        else if (cmd == "dawn")
                        {
                            dayTime = true;
                            Main.time = 0.0;
                            NetMessage.SendData(7, -1, -1, "", 0, 0f, 0f, 0f, 0);
                        }
                        else if (cmd == "dusk")
                        {
                            dayTime = false;
                            Main.time = 0.0;
                            NetMessage.SendData(7, -1, -1, "", 0, 0f, 0f, 0f, 0);
                        }
                        else if (cmd == "noon")
                        {
                            dayTime = true;
                            Main.time = 27000.0;
                            NetMessage.SendData(7, -1, -1, "", 0, 0f, 0f, 0f, 0);
                        }
                        else if (cmd == "midnight")
                        {
                            dayTime = false;
                            Main.time = 16200.0;
                            NetMessage.SendData(7, -1, -1, "", 0, 0f, 0f, 0f, 0);
                        }
                        else if (cmd == "exit-nosave")
                        {
                            Netplay.disconnect = true;
                        }
                        else if (cmd == "exit")
                        {
                            WorldGen.saveWorld(false);
                            Netplay.disconnect = true;
                        }
                        else if (cmd == "save")
                        {
                            WorldGen.saveWorld(false);
                        }
                        else if (cmd == "time")
                        {
                            string str3 = "AM";
                            double time = Main.time;
                            if (!dayTime)
                            {
                                time += 54000.0;
                            }
                            time = (time / 86400.0) * 24.0;
                            double num2 = 7.5;
                            time = (time - num2) - 12.0;
                            if (time < 0.0)
                            {
                                time += 24.0;
                            }
                            if (time >= 12.0)
                            {
                                str3 = "PM";
                            }
                            int num3 = (int) time;
                            double num4 = time - num3;
                            num4 = (int) (num4 * 60.0);
                            string str4 = num4.ToString();
                            if (num4 < 10.0)
                            {
                                str4 = "0" + str4;
                            }
                            if (num3 > 12)
                            {
                                num3 -= 12;
                            }
                            if (num3 == 0)
                            {
                                num3 = 12;
                            }
                            Console.WriteLine(string.Concat(new object[] { "Time: ", num3, ":", str4, " ", str3 }));
                        }
                        else if (cmd == "maxplayers")
                        {
                            Console.WriteLine("Player limit: " + maxNetPlayers);
                        }
                        else if (cmd == "port")
                        {
                            Console.WriteLine("Port: " + Netplay.serverPort);
                        }
                        else if (cmd == "version")
                        {
                            Console.WriteLine("Toaria, Terraria " + versionNumber);
                        }
                        else if (cmd == "clear")
                        {
                            try
                            {
                                Console.Clear();
                            }
                            catch
                            {
                            }
                        }
                        else if (cmd == "playing")
                        {
                            int num5 = 0;
                            for (int i = 0; i < 0xff; i++)
                            {
                                if (player[i].active)
                                {
                                    num5++;
                                    Console.WriteLine(string.Concat(new object[] { player[i].name, " (", Netplay.serverSock[i].tcpClient.Client.RemoteEndPoint, ")" }));
                                }
                            }
                            switch (num5)
                            {
                                case 0:
                                {
                                    Console.WriteLine("No players connected.");
                                    continue;
                                }
                                case 1:
                                {
                                    Console.WriteLine("1 player connected.");
                                    continue;
                                }
                            }
                            Console.WriteLine(num5 + " players connected.");
                        }
                        else if (cmd != "")
                        {
                            if (cmd == "motd")
                            {
                                if (motd == "")
                                {
                                    Console.WriteLine("Welcome to " + worldName + "!");
                                }
                                else
                                {
                                    Console.WriteLine("MOTD: " + motd);
                                }
                            }
                            else if ((cmd.Length >= 5) && (cmd.Substring(0, 5) == "motd "))
                            {
                                motd = str2.Substring(5);
                            }
                            else if ((cmd.Length == 8) && (cmd.Substring(0, 8) == "password"))
                            {
                                if (Netplay.password == "")
                                {
                                    Console.WriteLine("No password set.");
                                }
                                else
                                {
                                    Console.WriteLine("Password: " + Netplay.password);
                                }
                            }
                            else if ((cmd.Length >= 9) && (cmd.Substring(0, 9) == "password "))
                            {
                                string str6 = str2.Substring(9);
                                if (str6 == "")
                                {
                                    Netplay.password = "";
                                    Console.WriteLine("Password disabled.");
                                }
                                else
                                {
                                    Netplay.password = str6;
                                    Console.WriteLine("Password: " + Netplay.password);
                                }
                            }
                            else if (cmd == "say")
                            {
                                Console.WriteLine("Usage: say <words>");
                            }
                            else if ((cmd.Length >= 4) && (cmd.Substring(0, 4) == "say "))
                            {
                                string str7 = str2.Substring(4);
                                if (str7 == "")
                                {
                                    Console.WriteLine("Usage: say <words>");
                                }
                                else
                                {
                                    Console.WriteLine("<Server> " + str7);
                                    NetMessage.SendData(0x19, -1, -1, "<Server> " + str7, 0xff, 255f, 240f, 20f, 0);
                                }
                            }
                            else if ((cmd.Length == 4) && (cmd.Substring(0, 4) == "kick"))
                            {
                                Console.WriteLine("Usage: kick <player>");
                            }
                            else if ((cmd.Length >= 5) && (cmd.Substring(0, 5) == "kick "))
                            {
                                string str8 = cmd.Substring(5).ToLower();
                                if (str8 == "")
                                {
                                    Console.WriteLine("Usage: kick <player>");
                                }
                                else
                                {
                                    for (int j = 0; j < 0xff; j++)
                                    {
                                        if (player[j].active && (player[j].name.ToLower() == str8))
                                        {
                                            NetMessage.SendData(2, j, -1, "Kicked from server.", 0, 0f, 0f, 0f, 0);
                                        }
                                    }
                                }
                            }
                            else if ((cmd.Length == 3) && (cmd.Substring(0, 3) == "ban"))
                            {
                                Console.WriteLine("Usage: ban <player>");
                            }
                            else if ((cmd.Length >= 4) && (cmd.Substring(0, 4) == "ban "))
                            {
                                string str9 = cmd.Substring(4).ToLower();
                                if (str9 == "")
                                {
                                    Console.WriteLine("Usage: ban <player>");
                                }
                                else
                                {
                                    for (int k = 0; k < 0xff; k++)
                                    {
                                        if (player[k].active && (player[k].name.ToLower() == str9))
                                        {
                                            Netplay.AddBan(k);
                                            NetMessage.SendData(2, k, -1, "Banned from server.", 0, 0f, 0f, 0f, 0);
                                        }
                                    }
                                }
                            }
                            else
                            {
                                Console.WriteLine("Invalid command.");
                            }
                        }
                        continue;
                    }
                    catch
                    {
                        Console.WriteLine("Invalid command.");
                        continue;
                    }
                }
            }
        }

        public static void StartInvasion()
        {
            if ((invasionType == 0) && (invasionDelay == 0))
            {
                int num = 0;
                for (int i = 0; i < 0xff; i++)
                {
                    if (player[i].active && (player[i].statLifeMax >= 200))
                    {
                        num++;
                    }
                }
                if (num > 0)
                {
                    invasionType = 1;
                    invasionSize = 100 + (50 * num);
                    invasionWarn = 0;
                    if (rand.Next(2) == 0)
                    {
                        invasionX = 0.0;
                    }
                    else
                    {
                        invasionX = maxTilesX;
                    }
                }
            }
        }

        protected override void Update(GameTime gameTime)
        {
            if (Main.netMode != 1)
            {
                if (Main.netMode != 1)
                {
                    NPC.SpawnNPC();
                }
                for (int n = 0; n < 0xff; n++)
                {
                    player[n].activeNPCs = 0f;
                    player[n].townNPCs = 0f;
                }
                for (int num7 = 0; num7 < 0x3e8; num7++)
                {
                    if (ignoreErrors)
                    {
                        try
                        {
                            npc[num7].UpdateNPC(num7);
                        }
                        catch (Exception)
                        {
                            npc[num7] = new NPC();
                        }
                    }
                    else
                    {
                        npc[num7].UpdateNPC(num7);
                    }
                }
                for (int num8 = 0; num8 < 200; num8++)
                {
                    if (ignoreErrors)
                    {
                        try
                        {
                            gore[num8].Update();
                        }
                        catch
                        {
                            gore[num8] = new Gore();
                        }
                    }
                    else
                    {
                        gore[num8].Update();
                    }
                }
                for (int num9 = 0; num9 < 0x3e8; num9++)
                {
                    if (ignoreErrors)
                    {
                        try
                        {
                            projectile[num9].Update(num9);
                        }
                        catch
                        {
                            projectile[num9] = new Projectile();
                        }
                    }
                    else
                    {
                        projectile[num9].Update(num9);
                    }
                }
                for (int num10 = 0; num10 < 200; num10++)
                {
                    if (ignoreErrors)
                    {
                        try
                        {
                            item[num10].UpdateItem(num10);
                        }
                        catch
                        {
                            item[num10] = new Item();
                        }
                    }
                    else
                    {
                        item[num10].UpdateItem(num10);
                    }
                }
                if (ignoreErrors)
                {
                    try
                    {
                        UpdateTime();
                    }
                    catch
                    {
                        checkForSpawns = 0;
                    }
                }
                else
                {
                    UpdateTime();
                }
                if (Main.netMode != 1)
                {
                    if (ignoreErrors)
                    {
                        try
                        {
                            WorldGen.UpdateWorld();
                            UpdateInvasion();
                        }
                        catch
                        {
                        }
                    }
                    else
                    {
                        WorldGen.UpdateWorld();
                        UpdateInvasion();
                    }
                }
                if (ignoreErrors)
                {
                    try
                    {
                        if (Main.netMode == 2)
                        {
                            UpdateServer();
                        }
                    }
                    catch
                    {
                        int netMode = Main.netMode;
                    }
                }
                else
                {
                    if (Main.netMode == 2)
                    {
                        UpdateServer();
                    }
                }
                if (ignoreErrors)
                {
                    try
                    {
                        for (int num12 = 0; num12 < numChatLines; num12++)
                        {
                            if (chatLine[num12].showTime > 0)
                            {
                                ChatLine line1 = chatLine[num12];
                                line1.showTime--;
                            }
                        }
                    }
                    catch
                    {
                        for (int num13 = 0; num13 < numChatLines; num13++)
                        {
                            chatLine[num13] = new ChatLine();
                        }
                    }
                }
                else
                {
                    for (int num14 = 0; num14 < numChatLines; num14++)
                    {
                        if (chatLine[num14].showTime > 0)
                        {
                            ChatLine line2 = chatLine[num14];
                            line2.showTime--;
                        }
                    }
                }
                base.Update(gameTime);
            }
        }

        private static void UpdateInvasion()
        {
            if (invasionType > 0)
            {
                if (invasionSize <= 0)
                {
                    InvasionWarning();
                    invasionType = 0;
                    invasionDelay = 7;
                }
                if (invasionX != spawnTileX)
                {
                    float num = 0.2f;
                    if (invasionX > spawnTileX)
                    {
                        invasionX -= num;
                        if (invasionX <= spawnTileX)
                        {
                            invasionX = spawnTileX;
                            InvasionWarning();
                        }
                        else
                        {
                            invasionWarn--;
                        }
                    }
                    else if (invasionX < spawnTileX)
                    {
                        invasionX += num;
                        if (invasionX >= spawnTileX)
                        {
                            invasionX = spawnTileX;
                            InvasionWarning();
                        }
                        else
                        {
                            invasionWarn--;
                        }
                    }
                    if (invasionWarn <= 0)
                    {
                        invasionWarn = 0xe10;
                        InvasionWarning();
                    }
                }
            }
        }

        private static void UpdateMenu()
        {
            playerInventory = false;
            if (netMode == 1)
            {
                UpdateTime();
            }
        }

        private static void UpdateServer()
        {
            netPlayCounter++;
            if (netPlayCounter > 0xe10)
            {
                NetMessage.SendData(7, -1, -1, "", 0, 0f, 0f, 0f, 0);
                NetMessage.syncPlayers();
                netPlayCounter = 0;
            }
            for (int i = 0; i < maxNetPlayers; i++)
            {
                if (player[i].active && Netplay.serverSock[i].active)
                {
                    Netplay.serverSock[i].SpamUpdate();
                }
            }
            Math.IEEERemainder((double) netPlayCounter, 60.0);
            if (Math.IEEERemainder((double) netPlayCounter, 360.0) == 0.0)
            {
                bool flag2 = true;
                int lastItemUpdate = Main.lastItemUpdate;
                int num5 = 0;
                while (flag2)
                {
                    lastItemUpdate++;
                    if (lastItemUpdate >= 200)
                    {
                        lastItemUpdate = 0;
                    }
                    num5++;
                    if (!item[lastItemUpdate].active || (item[lastItemUpdate].owner == 0xff))
                    {
                        NetMessage.SendData(0x15, -1, -1, "", lastItemUpdate, 0f, 0f, 0f, 0);
                    }
                    if ((num5 >= maxItemUpdates) || (lastItemUpdate == Main.lastItemUpdate))
                    {
                        flag2 = false;
                    }
                }
                Main.lastItemUpdate = lastItemUpdate;
            }
            for (int j = 0; j < 200; j++)
            {
                if (item[j].active && ((item[j].owner == 0xff) || !player[item[j].owner].active))
                {
                    item[j].FindOwner(j);
                }
            }
            for (int k = 0; k < 0xff; k++)
            {
                if (Netplay.serverSock[k].active)
                {
                    ServerSock sock1 = Netplay.serverSock[k];
                    sock1.timeOut++;
                    if (!stopTimeOuts && (Netplay.serverSock[k].timeOut > (60 * timeOut)))
                    {
                        Netplay.serverSock[k].kill = true;
                    }
                }
                if (player[k].active)
                {
                    int sectionX = Netplay.GetSectionX((int) (player[k].position.X / 16f));
                    int sectionY = Netplay.GetSectionY((int) (player[k].position.Y / 16f));
                    int num10 = 0;
                    for (int m = sectionX - 1; m < (sectionX + 2); m++)
                    {
                        for (int n = sectionY - 1; n < (sectionY + 2); n++)
                        {
                            if ((((m >= 0) && (m < maxSectionsX)) && ((n >= 0) && (n < maxSectionsY))) && !Netplay.serverSock[k].tileSection[m, n])
                            {
                                num10++;
                            }
                        }
                    }
                    if (num10 > 0)
                    {
                        int number = num10 * 150;
                        NetMessage.SendData(9, k, -1, "Receiving tile data", number, 0f, 0f, 0f, 0);
                        Netplay.serverSock[k].statusText2 = "is receiving tile data";
                        ServerSock sock2 = Netplay.serverSock[k];
                        sock2.statusMax += number;
                        for (int num14 = sectionX - 1; num14 < (sectionX + 2); num14++)
                        {
                            for (int num15 = sectionY - 1; num15 < (sectionY + 2); num15++)
                            {
                                if ((((num14 >= 0) && (num14 < maxSectionsX)) && ((num15 >= 0) && (num15 < maxSectionsY))) && !Netplay.serverSock[k].tileSection[num14, num15])
                                {
                                    NetMessage.SendSection(k, num14, num15);
                                    NetMessage.SendData(11, k, -1, "", num14, (float) num15, (float) num14, (float) num15, 0);
                                }
                            }
                        }
                    }
                }
            }
        }

        private static void UpdateTime()
        {
            bool flag;
            time++;
            if (dayTime)
            {
                bloodMoon = false;
                if (time <= 54000.0)
                {
                    goto Label_03B5;
                }
                WorldGen.spawnNPC = 0;
                checkForSpawns = 0;
                if (((rand.Next(50) == 0) && (netMode != 1)) && WorldGen.shadowOrbSmashed)
                {
                    WorldGen.spawnMeteor = true;
                }
                if (NPC.downedBoss1 || (netMode == 1))
                {
                    goto Label_02BE;
                }
                flag = false;
                for (int i = 0; i < 0xff; i++)
                {
                    if ((player[i].active && (player[i].statLifeMax >= 200)) && (player[i].statDefense > 10))
                    {
                        flag = true;
                        break;
                    }
                }
            }
            else
            {
                if ((WorldGen.spawnEye && (netMode != 1)) && (time > 4860.0))
                {
                    for (int j = 0; j < 0xff; j++)
                    {
                        if ((player[j].active && !player[j].dead) && (player[j].position.Y < (worldSurface * 16.0)))
                        {
                            NPC.SpawnOnPlayer(j, 4);
                            WorldGen.spawnEye = false;
                            break;
                        }
                    }
                }
                if (time > 32400.0)
                {
                    if (invasionDelay > 0)
                    {
                        invasionDelay--;
                    }
                    WorldGen.spawnNPC = 0;
                    checkForSpawns = 0;
                    time = 0.0;
                    bloodMoon = false;
                    dayTime = true;
                    moonPhase++;
                    if (moonPhase >= 8)
                    {
                        moonPhase = 0;
                    }
                    if (netMode == 2)
                    {
                        NetMessage.SendData(7, -1, -1, "", 0, 0f, 0f, 0f, 0);
                        WorldGen.saveAndPlay();
                    }
                    if (((netMode != 1) && WorldGen.shadowOrbSmashed) && (rand.Next(15) == 0))
                    {
                        StartInvasion();
                    }
                }
                if ((time > 16200.0) && WorldGen.spawnMeteor)
                {
                    WorldGen.spawnMeteor = false;
                    WorldGen.dropMeteor();
                }
                return;
            }
            if (flag && (rand.Next(3) == 0))
            {
                int num3 = 0;
                for (int k = 0; k < 0x3e8; k++)
                {
                    if (npc[k].active && npc[k].townNPC)
                    {
                        num3++;
                    }
                }
                if (num3 >= 4)
                {
                    WorldGen.spawnEye = true;
                    if (netMode == 2)
                    {
                        NetMessage.SendData(0x19, -1, -1, "You feel an evil presence watching you...", 0xff, 50f, 255f, 130f, 0);
                    }
                }
            }
        Label_02BE:
            if ((!WorldGen.spawnEye && (moonPhase != 4)) && ((rand.Next(7) == 0) && (netMode != 1)))
            {
                for (int m = 0; m < 0xff; m++)
                {
                    if (player[m].active && (player[m].statLifeMax > 120))
                    {
                        bloodMoon = true;
                        break;
                    }
                }
                if (bloodMoon)
                {
                    if (netMode == 2)
                    {
                        NetMessage.SendData(0x19, -1, -1, "The Blood Moon is rising...", 0xff, 50f, 255f, 130f, 0);
                    }
                }
            }
            time = 0.0;
            dayTime = false;
            if (netMode == 2)
            {
                NetMessage.SendData(7, -1, -1, "", 0, 0f, 0f, 0f, 0);
            }
        Label_03B5:
            if (netMode != 1)
            {
                checkForSpawns++;
                if (checkForSpawns >= 0x1c20)
                {
                    int num6 = 0;
                    for (int n = 0; n < 0xff; n++)
                    {
                        if (player[n].active)
                        {
                            num6++;
                        }
                    }
                    checkForSpawns = 0;
                    WorldGen.spawnNPC = 0;
                    int num8 = 0;
                    int num9 = 0;
                    int num10 = 0;
                    int num11 = 0;
                    int num12 = 0;
                    int num13 = 0;
                    int num14 = 0;
                    int num15 = 0;
                    int num16 = 0;
                    for (int num17 = 0; num17 < 0x3e8; num17++)
                    {
                        if (npc[num17].active && npc[num17].townNPC)
                        {
                            if ((npc[num17].type != 0x25) && !npc[num17].homeless)
                            {
                                WorldGen.QuickFindHome(num17);
                            }
                            if (npc[num17].type == 0x25)
                            {
                                num13++;
                            }
                            if (npc[num17].type == 0x11)
                            {
                                num8++;
                            }
                            if (npc[num17].type == 0x12)
                            {
                                num9++;
                            }
                            if (npc[num17].type == 0x13)
                            {
                                num11++;
                            }
                            if (npc[num17].type == 20)
                            {
                                num10++;
                            }
                            if (npc[num17].type == 0x16)
                            {
                                num12++;
                            }
                            if (npc[num17].type == 0x26)
                            {
                                num14++;
                            }
                            if (npc[num17].type == 0x36)
                            {
                                num15++;
                            }
                            num16++;
                        }
                    }
                    if (WorldGen.spawnNPC == 0)
                    {
                        int num18 = 0;
                        bool flag2 = false;
                        int num19 = 0;
                        bool flag3 = false;
                        bool flag4 = false;
                        for (int num20 = 0; num20 < 0xff; num20++)
                        {
                            if (player[num20].active)
                            {
                                for (int num21 = 0; num21 < 0x2c; num21++)
                                {
                                    if ((player[num20].inventory[num21] != null) & (player[num20].inventory[num21].stack > 0))
                                    {
                                        if (player[num20].inventory[num21].type == 0x47)
                                        {
                                            num18 += player[num20].inventory[num21].stack;
                                        }
                                        if (player[num20].inventory[num21].type == 0x48)
                                        {
                                            num18 += player[num20].inventory[num21].stack * 100;
                                        }
                                        if (player[num20].inventory[num21].type == 0x49)
                                        {
                                            num18 += player[num20].inventory[num21].stack * 0x2710;
                                        }
                                        if (player[num20].inventory[num21].type == 0x4a)
                                        {
                                            num18 += player[num20].inventory[num21].stack * 0xf4240;
                                        }
                                        if ((player[num20].inventory[num21].ammo == 14) || (player[num20].inventory[num21].useAmmo == 14))
                                        {
                                            flag3 = true;
                                        }
                                        if (((player[num20].inventory[num21].type == 0xa6) || (player[num20].inventory[num21].type == 0xa7)) || ((player[num20].inventory[num21].type == 0xa8) || (player[num20].inventory[num21].type == 0xeb)))
                                        {
                                            flag4 = true;
                                        }
                                    }
                                }
                                int num22 = player[num20].statLifeMax / 20;
                                if (num22 > 5)
                                {
                                    flag2 = true;
                                }
                                num19 += num22;
                            }
                        }
                        if (!NPC.downedBoss3 && (num13 == 0))
                        {
                            int index = NPC.NewNPC((dungeonX * 0x10) + 8, dungeonY * 0x10, 0x25, 0);
                            npc[index].homeless = false;
                            npc[index].homeTileX = dungeonX;
                            npc[index].homeTileY = dungeonY;
                        }
                        if ((WorldGen.spawnNPC == 0) && (num12 < 1))
                        {
                            WorldGen.spawnNPC = 0x16;
                        }
                        if (((WorldGen.spawnNPC == 0) && (num18 > 5000.0)) && (num8 < 1))
                        {
                            WorldGen.spawnNPC = 0x11;
                        }
                        if (((WorldGen.spawnNPC == 0) && flag2) && (num9 < 1))
                        {
                            WorldGen.spawnNPC = 0x12;
                        }
                        if (((WorldGen.spawnNPC == 0) && flag3) && (num11 < 1))
                        {
                            WorldGen.spawnNPC = 0x13;
                        }
                        if (((WorldGen.spawnNPC == 0) && ((NPC.downedBoss1 || NPC.downedBoss2) || NPC.downedBoss3)) && (num10 < 1))
                        {
                            WorldGen.spawnNPC = 20;
                        }
                        if (((WorldGen.spawnNPC == 0) && flag4) && ((num8 > 0) && (num14 < 1)))
                        {
                            WorldGen.spawnNPC = 0x26;
                        }
                        if (((WorldGen.spawnNPC == 0) && NPC.downedBoss3) && (num15 < 1))
                        {
                            WorldGen.spawnNPC = 0x36;
                        }
                        if (((WorldGen.spawnNPC == 0) && (num18 > 0x186a0)) && ((num8 < 2) && (num6 > 2)))
                        {
                            WorldGen.spawnNPC = 0x11;
                        }
                        if (((WorldGen.spawnNPC == 0) && (num19 >= 20)) && ((num9 < 2) && (num6 > 2)))
                        {
                            WorldGen.spawnNPC = 0x12;
                        }
                        if (((WorldGen.spawnNPC == 0) && (num18 > 0x4c4b40)) && ((num8 < 3) && (num6 > 4)))
                        {
                            WorldGen.spawnNPC = 0x11;
                        }
                    }
                }
            }
        }
    }
}

