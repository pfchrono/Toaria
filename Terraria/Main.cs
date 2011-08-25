namespace Terraria
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

    public class Main : Game
    {
        private static int accSlotCount = 0;
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
        private int bgScroll;
        public static Texture2D blackTileTexture;
        public static bool bloodMoon = false;
        public static Texture2D boneArmTexture;
        public static float bottomWorld = 38400f;
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
        public static Cloud[] cloud = new Cloud[100];
        public static int cloudLimit = 100;
        public static Texture2D[] cloudTexture = new Texture2D[4];
        public static string cMana = "M";
        private int colorDelay;
        public static CombatText[] combatText = new CombatText[100];
        public static bool craftGuide = false;
        public static float craftingAlpha = 1f;
        public static bool craftingHide = false;
        public static string cRight = "D";
        public static string cThrowItem = "Q";
        public static string cUp = "W";
        public int curMusic;
        public static int curRelease = 20;
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
        private static float exitScale = 0.8f;
        public static int fadeCounter = 0;
        public static Texture2D fadeTexture;
        public static bool fixedTiming = false;
        private int focusColor;
        private int focusMenu = -1;
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
        private GraphicsDeviceManager graphics;
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
        private static float inventoryScale = 0.75f;
        public static float iS = 1f;
        public static Item[] item = new Item[0xc9];
        public static string[] itemName = new string[0x16b];
        public static ItemText[] itemText = new ItemText[100];
        public static Texture2D[] itemTexture = new Texture2D[0x16b];
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
        private float logoRotation;
        private float logoRotationDirection = 1f;
        private float logoRotationSpeed = 1f;
        private float logoScale = 1f;
        private float logoScaleDirection = 1f;
        private float logoScaleSpeed = 1f;
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
        public const int maxItemTypes = 0x16b;
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
        public const int maxTileSets = 0x6a;
        public static float rightWorld = 134400f;
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
        private static bool mouseExit = false;
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
        private int numDisplayModes;
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
        private int selectedMenu = -1;
        private int selectedMenu2 = -1;
        private int selectedPlayer;
        private int selectedWorld;
        public static bool serverStarting = false;
        private int setKey = -1;
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
        private int splashCounter;
        public static Texture2D splashTexture;
        private SpriteBatch spriteBatch;
        public static int stackCounter = 0;
        public static int stackDelay = 7;
        public static int stackSplit;
        public static Star[] star = new Star[130];
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
        private int textBlinkerCount;
        private int textBlinkerState;
        public static Tile[,] tile = new Tile[maxTilesX, maxTilesY];
        public static bool[] tileAlch = new bool[0x6a];
        public static bool[] tileBlockLight = new bool[0x6a];
        public static Color tileColor;
        public static bool[] tileCut = new bool[0x6a];
        public static bool[] tileDungeon = new bool[0x6a];
        public static bool[] tileFrameImportant = new bool[0x6a];
        public static bool[] tileLavaDeath = new bool[0x6a];
        public static bool[] tileMergeDirt = new bool[0x6a];
        public static string[] tileName = new string[0x6a];
        public static bool[] tileNoAttach = new bool[0x6a];
        public static bool[] tileNoFail = new bool[0x6a];
        public static int[] tileShine = new int[0x6a];
        public static bool tilesLoaded = false;
        public static bool[] tileSolid = new bool[0x6a];
        public static bool[] tileSolidTop = new bool[0x6a];
        public static bool[] tileStone = new bool[0x6a];
        public static bool[] tileTable = new bool[0x6a];
        public static Texture2D[] tileTexture = new Texture2D[0x6a];
        public static bool[] tileWaterDeath = new bool[0x6a];
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
        public static string versionNumber = "v1.0.6";
        public static string versionNumber2 = "v1.0.6";
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
            this.graphics = new GraphicsDeviceManager(this);
            base.Content.RootDirectory = "Content";
        }

        private static bool AccCheck(Item newItem)
        {
            for (int i = 0; i < player[myPlayer].armor.Length; i++)
            {
                if (newItem.IsTheSameAs(player[myPlayer].armor[i]))
                {
                    return true;
                }
            }
            return false;
        }

        public static Item armorSwap(Item newItem)
        {
            if (((newItem.headSlot == -1) && (newItem.bodySlot == -1)) && ((newItem.legSlot == -1) && !newItem.accessory))
            {
                return newItem;
            }
            Item item = newItem;
            if (newItem.headSlot != -1)
            {
                item = (Item) player[myPlayer].armor[0].Clone();
                player[myPlayer].armor[0] = (Item) newItem.Clone();
            }
            else if (newItem.bodySlot != -1)
            {
                item = (Item) player[myPlayer].armor[1].Clone();
                player[myPlayer].armor[1] = (Item) newItem.Clone();
            }
            else if (newItem.legSlot != -1)
            {
                item = (Item) player[myPlayer].armor[2].Clone();
                player[myPlayer].armor[2] = (Item) newItem.Clone();
            }
            else if (newItem.accessory)
            {
                if (AccCheck(newItem))
                {
                    return item;
                }
                for (int i = 3; i < 8; i++)
                {
                    if (player[myPlayer].armor[i].type == 0)
                    {
                        accSlotCount = i - 3;
                        break;
                    }
                }
                item = (Item) player[myPlayer].armor[3 + accSlotCount].Clone();
                player[myPlayer].armor[3 + accSlotCount] = (Item) newItem.Clone();
                accSlotCount++;
                if (accSlotCount >= 5)
                {
                    accSlotCount = 0;
                }
            }
            PlaySound(7, -1, -1, 1);
            Recipe.FindRecipes();
            return item;
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

        public void AutoHost()
        {
            menuMultiplayer = true;
            menuServer = true;
            menuMode = 1;
        }

        public void AutoJoin(string IP)
        {
            defaultIP = IP;
            getIP = IP;
            Netplay.SetIP(defaultIP);
            autoJoin = true;
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

        private static Color buffColor(Color newColor, float R, float G, float B, float A)
        {
            newColor.R = (byte) (newColor.R * R);
            newColor.G = (byte) (newColor.G * G);
            newColor.B = (byte) (newColor.B * B);
            newColor.A = (byte) (newColor.A * A);
            return newColor;
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

        public static void CursorColor()
        {
            cursorAlpha += cursorColorDirection * 0.015f;
            if (cursorAlpha >= 1f)
            {
                cursorAlpha = 1f;
                cursorColorDirection = -1;
            }
            if (cursorAlpha <= 0.6)
            {
                cursorAlpha = 0.6f;
                cursorColorDirection = 1;
            }
            float num = (cursorAlpha * 0.3f) + 0.7f;
            byte r = (byte) (mouseColor.R * cursorAlpha);
            byte g = (byte) (mouseColor.G * cursorAlpha);
            byte b = (byte) (mouseColor.B * cursorAlpha);
            byte a = (byte) (255f * num);
            cursorColor = new Color(r, g, b, a);
            cursorScale = ((cursorAlpha * 0.3f) + 0.7f) + 0.1f;
        }

        public static int DamageVar(float dmg)
        {
            float num = dmg * (1f + (rand.Next(-15, 0x10) * 0.01f));
            return (int) Math.Round((double) num);
        }

        public void DedServ()
        {
            rand = new Random();
            if (autoShutdown)
            {
                string lpWindowName = "terraria" + rand.Next(0x7fffffff);
                Console.Title = lpWindowName;
                IntPtr hWnd = FindWindow(null, lpWindowName);
                if (hWnd != IntPtr.Zero)
                {
                    ShowWindow(hWnd, 0);
                }
            }
            else
            {
                Console.Title = "Terraria Server " + versionNumber2;
            }
            dedServ = true;
            showSplash = false;
            this.Initialize();
            while ((worldPathName == null) || (worldPathName == ""))
            {
                LoadWorlds();
                bool flag = true;
                while (flag)
                {
                    Console.WriteLine("Terraria Server " + versionNumber2);
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
                                Console.WriteLine("Terraria Server " + versionNumber2);
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
                            Console.WriteLine("Terraria Server " + versionNumber2);
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
                                        goto Label_034C;

                                    case 2:
                                        maxTilesX = 0x189c;
                                        maxTilesY = 0x708;
                                        flag2 = false;
                                        goto Label_034C;

                                    case 3:
                                        maxTilesX = 0x20d0;
                                        maxTilesY = 0x960;
                                        flag2 = false;
                                        goto Label_034C;
                                }
                            }
                            catch
                            {
                            }
                        Label_034C:
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
                            Console.WriteLine("Terraria Server " + versionNumber2);
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
                            Console.WriteLine("Terraria Server " + versionNumber2);
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
                            Console.WriteLine("Terraria Server " + versionNumber2);
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
                        Console.WriteLine("Terraria Server " + versionNumber2);
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
            Console.WriteLine("Terraria Server " + versionNumber);
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
            Console.WriteLine("Terraria Server " + versionNumber);
            Console.WriteLine("");
            Console.WriteLine("Listening on port " + Netplay.serverPort);
            Console.WriteLine("Type 'help' for a list of commands.");
            Console.WriteLine("");
            Console.Title = "Terraria Server: " + worldName;
            Stopwatch stopwatch = new Stopwatch();
            if (!autoShutdown)
            {
                startDedInput();
            }
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
                        this.Update(new GameTime());
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

        protected override void Draw(GameTime gameTime)
        {
            if (!dedServ)
            {
                if (((screenWidth != base.GraphicsDevice.Viewport.Width) || (screenHeight != base.GraphicsDevice.Viewport.Height)) && gamePaused)
                {
                    Lighting.resize = true;
                }
                screenWidth = base.GraphicsDevice.Viewport.Width;
                screenHeight = base.GraphicsDevice.Viewport.Height;
                bool flag = false;
                if (screenWidth > maxScreenW)
                {
                    screenWidth = maxScreenW;
                    flag = true;
                }
                if (screenHeight > maxScreenH)
                {
                    screenHeight = maxScreenH;
                    flag = true;
                }
                if (screenWidth < minScreenW)
                {
                    screenWidth = minScreenW;
                    flag = true;
                }
                if (screenHeight < minScreenH)
                {
                    screenHeight = minScreenH;
                    flag = true;
                }
                if (flag)
                {
                    this.graphics.PreferredBackBufferWidth = screenWidth;
                    this.graphics.PreferredBackBufferHeight = screenHeight;
                    this.graphics.ApplyChanges();
                }
            }
            CursorColor();
            drawTime++;
            screenLastPosition = screenPosition;
            if (stackSplit == 0)
            {
                stackCounter = 0;
                stackDelay = 7;
            }
            else
            {
                stackCounter++;
                if (stackCounter >= 30)
                {
                    stackDelay--;
                    if (stackDelay < 2)
                    {
                        stackDelay = 2;
                    }
                    stackCounter = 0;
                }
            }
            mouseTextColor = (byte) (mouseTextColor + ((byte) mouseTextColorChange));
            if (mouseTextColor >= 250)
            {
                mouseTextColorChange = -4;
            }
            if (mouseTextColor <= 0xaf)
            {
                mouseTextColorChange = 4;
            }
            if (myPlayer >= 0)
            {
                player[myPlayer].mouseInterface = false;
            }
            toolTip = new Item();
            if (!gameMenu && (netMode != 2))
            {
                int x = mouseState.X;
                int y = mouseState.Y;
                if (x < 0)
                {
                    x = 0;
                }
                if (x > screenWidth)
                {
                    x = screenWidth;
                }
                if (y < 0)
                {
                    y = 0;
                }
                if (y > screenHeight)
                {
                    y = screenHeight;
                }
                screenPosition.X = (player[myPlayer].position.X + (player[myPlayer].width * 0.5f)) - (screenWidth * 0.5f);
                screenPosition.Y = (player[myPlayer].position.Y + (player[myPlayer].height * 0.5f)) - (screenHeight * 0.5f);
                screenPosition.X = (int) screenPosition.X;
                screenPosition.Y = (int) screenPosition.Y;
            }
            if (!gameMenu && (netMode != 2))
            {
                if (screenPosition.X < ((leftWorld + 336f) + 16f))
                {
                    screenPosition.X = (leftWorld + 336f) + 16f;
                }
                else if ((screenPosition.X + screenWidth) > ((rightWorld - 336f) - 32f))
                {
                    screenPosition.X = ((rightWorld - screenWidth) - 336f) - 32f;
                }
                if (screenPosition.Y < ((topWorld + 336f) + 16f))
                {
                    screenPosition.Y = (topWorld + 336f) + 16f;
                }
                else if ((screenPosition.Y + screenHeight) > ((bottomWorld - 336f) - 32f))
                {
                    screenPosition.Y = ((bottomWorld - screenHeight) - 336f) - 32f;
                }
            }
            if (showSplash)
            {
                this.DrawSplash(gameTime);
            }
            else
            {
                Rectangle rectangle;
                base.GraphicsDevice.Clear(Color.Black);
                base.Draw(gameTime);
                this.spriteBatch.Begin();
                double caveParrallax = 0.5;
                int num4 = ((int) -Math.IEEERemainder(screenPosition.X * caveParrallax, (double) backgroundWidth[background])) - (backgroundWidth[background] / 2);
                int num5 = (screenWidth / backgroundWidth[background]) + 2;
                int num6 = 0;
                int num7 = 0;
                int num8 = (int) ((((double) -screenPosition.Y) / ((worldSurface * 16.0) - 600.0)) * 200.0);
                if (gameMenu || (netMode == 2))
                {
                    num8 = -200;
                }
                Color white = Color.White;
                int num9 = ((int) ((time / 54000.0) * (screenWidth + (sunTexture.Width * 2)))) - sunTexture.Width;
                int num10 = 0;
                Color color = Color.White;
                float scale = 1f;
                float rotation = (((float) (time / 54000.0)) * 2f) - 7.3f;
                int num14 = ((int) ((time / 32400.0) * (screenWidth + (moonTexture.Width * 2)))) - moonTexture.Width;
                int num15 = 0;
                Color color3 = Color.White;
                float num16 = 1f;
                float num17 = (((float) (time / 32400.0)) * 2f) - 7.3f;
                float num19 = 0f;
                if (dayTime)
                {
                    double num13;
                    if (time < 27000.0)
                    {
                        num13 = Math.Pow(1.0 - ((time / 54000.0) * 2.0), 2.0);
                        num10 = (int) ((num8 + (num13 * 250.0)) + 180.0);
                    }
                    else
                    {
                        num13 = Math.Pow(((time / 54000.0) - 0.5) * 2.0, 2.0);
                        num10 = (int) ((num8 + (num13 * 250.0)) + 180.0);
                    }
                    scale = (float) (1.2 - (num13 * 0.4));
                }
                else
                {
                    double num18;
                    if (time < 16200.0)
                    {
                        num18 = Math.Pow(1.0 - ((time / 32400.0) * 2.0), 2.0);
                        num15 = (int) ((num8 + (num18 * 250.0)) + 180.0);
                    }
                    else
                    {
                        num18 = Math.Pow(((time / 32400.0) - 0.5) * 2.0, 2.0);
                        num15 = (int) ((num8 + (num18 * 250.0)) + 180.0);
                    }
                    num16 = (float) (1.2 - (num18 * 0.4));
                }
                if (dayTime)
                {
                    if (time < 13500.0)
                    {
                        num19 = (float) (time / 13500.0);
                        color.R = (byte) ((num19 * 200f) + 55f);
                        color.G = (byte) ((num19 * 180f) + 75f);
                        color.B = (byte) ((num19 * 250f) + 5f);
                        white.R = (byte) ((num19 * 200f) + 55f);
                        white.G = (byte) ((num19 * 200f) + 55f);
                        white.B = (byte) ((num19 * 200f) + 55f);
                    }
                    if (time > 45900.0)
                    {
                        num19 = (float) (1.0 - (((time / 54000.0) - 0.85) * 6.666666666666667));
                        color.R = (byte) ((num19 * 120f) + 55f);
                        color.G = (byte) ((num19 * 100f) + 25f);
                        color.B = (byte) ((num19 * 120f) + 55f);
                        white.R = (byte) ((num19 * 200f) + 55f);
                        white.G = (byte) ((num19 * 85f) + 55f);
                        white.B = (byte) ((num19 * 135f) + 55f);
                    }
                    else if (time > 37800.0)
                    {
                        num19 = (float) (1.0 - (((time / 54000.0) - 0.7) * 6.666666666666667));
                        color.R = (byte) ((num19 * 80f) + 175f);
                        color.G = (byte) ((num19 * 130f) + 125f);
                        color.B = (byte) ((num19 * 100f) + 155f);
                        white.R = (byte) ((num19 * 0f) + 255f);
                        white.G = (byte) ((num19 * 115f) + 140f);
                        white.B = (byte) ((num19 * 75f) + 180f);
                    }
                }
                if (!dayTime)
                {
                    if (bloodMoon)
                    {
                        if (time < 16200.0)
                        {
                            num19 = (float) (1.0 - (time / 16200.0));
                            color3.R = (byte) ((num19 * 10f) + 205f);
                            color3.G = (byte) ((num19 * 170f) + 55f);
                            color3.B = (byte) ((num19 * 200f) + 55f);
                            white.R = (byte) ((60f - (num19 * 60f)) + 55f);
                            white.G = (byte) ((num19 * 40f) + 15f);
                            white.B = (byte) ((num19 * 40f) + 15f);
                        }
                        else if (time >= 16200.0)
                        {
                            num19 = (float) (((time / 32400.0) - 0.5) * 2.0);
                            color3.R = (byte) ((num19 * 50f) + 205f);
                            color3.G = (byte) ((num19 * 100f) + 155f);
                            color3.B = (byte) ((num19 * 100f) + 155f);
                            color3.R = (byte) ((num19 * 10f) + 205f);
                            color3.G = (byte) ((num19 * 170f) + 55f);
                            color3.B = (byte) ((num19 * 200f) + 55f);
                            white.R = (byte) ((60f - (num19 * 60f)) + 55f);
                            white.G = (byte) ((num19 * 40f) + 15f);
                            white.B = (byte) ((num19 * 40f) + 15f);
                        }
                    }
                    else if (time < 16200.0)
                    {
                        num19 = (float) (1.0 - (time / 16200.0));
                        color3.R = (byte) ((num19 * 10f) + 205f);
                        color3.G = (byte) ((num19 * 70f) + 155f);
                        color3.B = (byte) ((num19 * 100f) + 155f);
                        white.R = (byte) ((num19 * 40f) + 15f);
                        white.G = (byte) ((num19 * 40f) + 15f);
                        white.B = (byte) ((num19 * 40f) + 15f);
                    }
                    else if (time >= 16200.0)
                    {
                        num19 = (float) (((time / 32400.0) - 0.5) * 2.0);
                        color3.R = (byte) ((num19 * 50f) + 205f);
                        color3.G = (byte) ((num19 * 100f) + 155f);
                        color3.B = (byte) ((num19 * 100f) + 155f);
                        white.R = (byte) ((num19 * 40f) + 15f);
                        white.G = (byte) ((num19 * 40f) + 15f);
                        white.B = (byte) ((num19 * 40f) + 15f);
                    }
                }
                if (gameMenu || (netMode == 2))
                {
                    num8 = 0;
                    if (!dayTime)
                    {
                        white.R = 0x37;
                        white.G = 0x37;
                        white.B = 0x37;
                    }
                }
                if (evilTiles > 0)
                {
                    float num20 = ((float) evilTiles) / 500f;
                    if (num20 > 1f)
                    {
                        num20 = 1f;
                    }
                    int r = white.R;
                    int g = white.G;
                    int b = white.B;
                    r += (int) (10f * num20);
                    g -= (int) ((90f * num20) * (((float) white.G) / 255f));
                    b -= (int) ((190f * num20) * (((float) white.B) / 255f));
                    if (r > 0xff)
                    {
                        r = 0xff;
                    }
                    if (g < 15)
                    {
                        g = 15;
                    }
                    if (b < 15)
                    {
                        b = 15;
                    }
                    white.R = (byte) r;
                    white.G = (byte) g;
                    white.B = (byte) b;
                    r = color.R;
                    g = color.G;
                    b = color.B;
                    r -= (int) ((100f * num20) * (((float) color.R) / 255f));
                    g -= (int) ((160f * num20) * (((float) color.G) / 255f));
                    b -= (int) ((170f * num20) * (((float) color.B) / 255f));
                    if (r < 15)
                    {
                        r = 15;
                    }
                    if (g < 15)
                    {
                        g = 15;
                    }
                    if (b < 15)
                    {
                        b = 15;
                    }
                    color.R = (byte) r;
                    color.G = (byte) g;
                    color.B = (byte) b;
                    r = color3.R;
                    g = color3.G;
                    b = color3.B;
                    r -= (int) ((140f * num20) * (((float) color3.R) / 255f));
                    g -= (int) ((170f * num20) * (((float) color3.G) / 255f));
                    b -= (int) ((190f * num20) * (((float) color3.B) / 255f));
                    if (r < 15)
                    {
                        r = 15;
                    }
                    if (g < 15)
                    {
                        g = 15;
                    }
                    if (b < 15)
                    {
                        b = 15;
                    }
                    color3.R = (byte) r;
                    color3.G = (byte) g;
                    color3.B = (byte) b;
                }
                if (jungleTiles > 0)
                {
                    float num24 = ((float) jungleTiles) / 200f;
                    if (num24 > 1f)
                    {
                        num24 = 1f;
                    }
                    int num25 = white.R;
                    int num26 = white.G;
                    int num27 = white.B;
                    num25 -= (int) ((20f * num24) * (((float) white.R) / 255f));
                    num27 -= (int) ((120f * num24) * (((float) white.B) / 255f));
                    if (num26 > 0xff)
                    {
                        num26 = 0xff;
                    }
                    if (num26 < 15)
                    {
                        num26 = 15;
                    }
                    if (num25 > 0xff)
                    {
                        num25 = 0xff;
                    }
                    if (num25 < 15)
                    {
                        num25 = 15;
                    }
                    if (num27 < 15)
                    {
                        num27 = 15;
                    }
                    white.R = (byte) num25;
                    white.G = (byte) num26;
                    white.B = (byte) num27;
                    num25 = color.R;
                    num26 = color.G;
                    num27 = color.B;
                    num26 -= (int) ((10f * num24) * (((float) color.G) / 255f));
                    num25 -= (int) ((50f * num24) * (((float) color.R) / 255f));
                    num27 -= (int) ((10f * num24) * (((float) color.B) / 255f));
                    if (num25 < 15)
                    {
                        num25 = 15;
                    }
                    if (num26 < 15)
                    {
                        num26 = 15;
                    }
                    if (num27 < 15)
                    {
                        num27 = 15;
                    }
                    color.R = (byte) num25;
                    color.G = (byte) num26;
                    color.B = (byte) num27;
                    num25 = color3.R;
                    num26 = color3.G;
                    num27 = color3.B;
                    num26 -= (int) ((140f * num24) * (((float) color3.R) / 255f));
                    num25 -= (int) ((170f * num24) * (((float) color3.G) / 255f));
                    num27 -= (int) ((190f * num24) * (((float) color3.B) / 255f));
                    if (num25 < 15)
                    {
                        num25 = 15;
                    }
                    if (num26 < 15)
                    {
                        num26 = 15;
                    }
                    if (num27 < 15)
                    {
                        num27 = 15;
                    }
                    color3.R = (byte) num25;
                    color3.G = (byte) num26;
                    color3.B = (byte) num27;
                }
                tileColor.A = 0xff;
                tileColor.R = (byte) (((white.R + white.B) + white.G) / 3);
                tileColor.G = (byte) (((white.R + white.B) + white.G) / 3);
                tileColor.B = (byte) (((white.R + white.B) + white.G) / 3);
                if (screenPosition.Y < ((worldSurface * 16.0) + 16.0))
                {
                    for (int i = 0; i < num5; i++)
                    {
                        this.spriteBatch.Draw(backgroundTexture[background], new Rectangle(num4 + (backgroundWidth[background] * i), num8, backgroundWidth[background], backgroundHeight[background]), white);
                    }
                }
                if (((screenPosition.Y < ((worldSurface * 16.0) + 16.0)) && (((0xff - tileColor.R) - 100) > 0)) && (netMode != 2))
                {
                    for (int j = 0; j < numStars; j++)
                    {
                        Color color4 = new Color();
                        float num30 = ((float) evilTiles) / 500f;
                        if (num30 > 1f)
                        {
                            num30 = 1f;
                        }
                        num30 = 1f - (num30 * 0.5f);
                        if (evilTiles <= 0)
                        {
                            num30 = 1f;
                        }
                        int num31 = (int) ((((0xff - tileColor.R) - 100) * star[j].twinkle) * num30);
                        int num32 = (int) ((((0xff - tileColor.G) - 100) * star[j].twinkle) * num30);
                        int num33 = (int) ((((0xff - tileColor.B) - 100) * star[j].twinkle) * num30);
                        if (num31 < 0)
                        {
                            num31 = 0;
                        }
                        if (num32 < 0)
                        {
                            num32 = 0;
                        }
                        if (num33 < 0)
                        {
                            num33 = 0;
                        }
                        color4.R = (byte) num31;
                        color4.G = (byte) (num32 * num30);
                        color4.B = (byte) (num33 * num30);
                        float num34 = star[j].position.X * (((float) screenWidth) / 800f);
                        float num35 = star[j].position.Y * (((float) screenHeight) / 600f);
                        this.spriteBatch.Draw(starTexture[star[j].type], new Vector2(num34 + (starTexture[star[j].type].Width * 0.5f), (num35 + (starTexture[star[j].type].Height * 0.5f)) + num8), new Rectangle(0, 0, starTexture[star[j].type].Width, starTexture[star[j].type].Height), color4, star[j].rotation, new Vector2(starTexture[star[j].type].Width * 0.5f, starTexture[star[j].type].Height * 0.5f), (float) (star[j].scale * star[j].twinkle), SpriteEffects.None, 0f);
                    }
                }
                if (dayTime)
                {
                    if (!gameMenu && (player[myPlayer].head == 12))
                    {
                        this.spriteBatch.Draw(sun2Texture, new Vector2((float) num9, (float) (num10 + sunModY)), new Rectangle(0, 0, sunTexture.Width, sunTexture.Height), color, rotation, new Vector2((float) (sunTexture.Width / 2), (float) (sunTexture.Height / 2)), scale, SpriteEffects.None, 0f);
                    }
                    else
                    {
                        this.spriteBatch.Draw(sunTexture, new Vector2((float) num9, (float) (num10 + sunModY)), new Rectangle(0, 0, sunTexture.Width, sunTexture.Height), color, rotation, new Vector2((float) (sunTexture.Width / 2), (float) (sunTexture.Height / 2)), scale, SpriteEffects.None, 0f);
                    }
                }
                if (!dayTime)
                {
                    this.spriteBatch.Draw(moonTexture, new Vector2((float) num14, (float) (num15 + moonModY)), new Rectangle(0, moonTexture.Width * moonPhase, moonTexture.Width, moonTexture.Width), color3, num17, new Vector2((float) (moonTexture.Width / 2), (float) (moonTexture.Width / 2)), num16, SpriteEffects.None, 0f);
                }
                if (dayTime)
                {
                    rectangle = new Rectangle(num9 - ((int) ((sunTexture.Width * 0.5) * scale)), (int) ((num10 - ((sunTexture.Height * 0.5) * scale)) + sunModY), (int) (sunTexture.Width * scale), (int) (sunTexture.Width * scale));
                }
                else
                {
                    rectangle = new Rectangle(num14 - ((int) ((moonTexture.Width * 0.5) * num16)), (int) ((num15 - ((moonTexture.Width * 0.5) * num16)) + moonModY), (int) (moonTexture.Width * num16), (int) (moonTexture.Width * num16));
                }
                Rectangle rectangle2 = new Rectangle(mouseState.X, mouseState.Y, 1, 1);
                sunModY = (short) (sunModY * 0.999);
                moonModY = (short) (moonModY * 0.999);
                if (gameMenu && (netMode != 1))
                {
                    if ((mouseState.LeftButton == ButtonState.Pressed) && hasFocus)
                    {
                        if (rectangle2.Intersects(rectangle) || grabSky)
                        {
                            if (dayTime)
                            {
                                time = 54000.0 * (((float) (mouseState.X + sunTexture.Width)) / (screenWidth + (sunTexture.Width * 2)));
                                sunModY = (short) (mouseState.Y - num10);
                                if (time > 53990.0)
                                {
                                    time = 53990.0;
                                }
                            }
                            else
                            {
                                time = 32400.0 * (((float) (mouseState.X + moonTexture.Width)) / (screenWidth + (moonTexture.Width * 2)));
                                moonModY = (short) (mouseState.Y - num15);
                                if (time > 32390.0)
                                {
                                    time = 32390.0;
                                }
                            }
                            if (time < 10.0)
                            {
                                time = 10.0;
                            }
                            if (netMode != 0)
                            {
                                NetMessage.SendData(0x12, -1, -1, "", 0, 0f, 0f, 0f, 0);
                            }
                            grabSky = true;
                        }
                    }
                    else
                    {
                        grabSky = false;
                    }
                }
                if (resetClouds)
                {
                    Cloud.resetClouds();
                    resetClouds = false;
                }
                if (base.IsActive || (netMode != 0))
                {
                    windSpeedSpeed += rand.Next(-10, 11) * 0.0001f;
                    if (windSpeedSpeed < -0.002)
                    {
                        windSpeedSpeed = -0.002f;
                    }
                    if (windSpeedSpeed > 0.002)
                    {
                        windSpeedSpeed = 0.002f;
                    }
                    windSpeed += windSpeedSpeed;
                    if (windSpeed < -0.3)
                    {
                        windSpeed = -0.3f;
                    }
                    if (windSpeed > 0.3)
                    {
                        windSpeed = 0.3f;
                    }
                    numClouds += rand.Next(-1, 2);
                    if (numClouds < 0)
                    {
                        numClouds = 0;
                    }
                    if (numClouds > cloudLimit)
                    {
                        numClouds = cloudLimit;
                    }
                }
                if (screenPosition.Y < ((worldSurface * 16.0) + 16.0))
                {
                    for (int k = 0; k < 100; k++)
                    {
                        if (cloud[k].active)
                        {
                            int num37 = (int) (40f * (2f - cloud[k].scale));
                            int num38 = 0;
                            Color color5 = new Color();
                            num38 = white.R - num37;
                            if (num38 <= 0)
                            {
                                num38 = 0;
                            }
                            color5.R = (byte) num38;
                            num38 = white.G - num37;
                            if (num38 <= 0)
                            {
                                num38 = 0;
                            }
                            color5.G = (byte) num38;
                            num38 = white.B - num37;
                            if (num38 <= 0)
                            {
                                num38 = 0;
                            }
                            color5.B = (byte) num38;
                            color5.A = (byte) (0xff - num37);
                            float num39 = cloud[k].position.Y * (((float) screenHeight) / 600f);
                            this.spriteBatch.Draw(cloudTexture[cloud[k].type], new Vector2(cloud[k].position.X + (cloudTexture[cloud[k].type].Width * 0.5f), (num39 + (cloudTexture[cloud[k].type].Height * 0.5f)) + num8), new Rectangle(0, 0, cloudTexture[cloud[k].type].Width, cloudTexture[cloud[k].type].Height), color5, cloud[k].rotation, new Vector2(cloudTexture[cloud[k].type].Width * 0.5f, cloudTexture[cloud[k].type].Height * 0.5f), cloud[k].scale, SpriteEffects.None, 0f);
                        }
                    }
                }
                if (gameMenu || (netMode == 2))
                {
                    this.DrawMenu();
                }
                else
                {
                    Vector2 vector9;
                    Color color12;
                    int firstX = (int) ((screenPosition.X / 16f) - 1f);
                    int lastX = ((int) ((screenPosition.X + screenWidth) / 16f)) + 2;
                    int firstY = (int) ((screenPosition.Y / 16f) - 1f);
                    int lastY = ((int) ((screenPosition.Y + screenHeight) / 16f)) + 2;
                    if (firstX < 0)
                    {
                        firstX = 0;
                    }
                    if (lastX > maxTilesX)
                    {
                        lastX = maxTilesX;
                    }
                    if (firstY < 0)
                    {
                        firstY = 0;
                    }
                    if (lastY > maxTilesY)
                    {
                        lastY = maxTilesY;
                    }
                    Lighting.LightTiles(firstX, lastX, firstY, lastY);
                    Color color1 = Color.White;
                    this.DrawWater(true);
                    caveParrallax = Main.caveParrallax;
                    num4 = ((int) -Math.IEEERemainder(screenPosition.X * caveParrallax, (double) backgroundWidth[1])) - (backgroundWidth[1] / 2);
                    num5 = (screenWidth / backgroundWidth[1]) + 2;
                    num8 = (int) ((((((int) worldSurface) * 0x10) - backgroundHeight[1]) - screenPosition.Y) + 16f);
                    for (int m = 0; m < num5; m++)
                    {
                        for (int num45 = 0; num45 < 6; num45++)
                        {
                            int num46 = ((num4 + (backgroundWidth[1] * m)) + (num45 * 0x10)) / 0x10;
                            int num47 = num8 / 0x10;
                            Color color6 = Lighting.GetColor(num46 + ((int) (screenPosition.X / 16f)), num47 + ((int) (screenPosition.Y / 16f)));
                            this.spriteBatch.Draw(backgroundTexture[1], new Vector2((float) ((num4 + (backgroundWidth[1] * m)) + (0x10 * num45)), (float) num8), new Rectangle(0x10 * num45, 0, 0x10, 0x10), color6);
                        }
                    }
                    double num48 = maxTilesY - 230;
                    double num49 = ((int) ((num48 - worldSurface) / 6.0)) * 6;
                    num48 = (worldSurface + num49) - 5.0;
                    bool flag2 = false;
                    bool flag3 = false;
                    num8 = (int) (((((int) worldSurface) * 0x10) - screenPosition.Y) + 16f);
                    if ((worldSurface * 16.0) <= (screenPosition.Y + screenHeight))
                    {
                        caveParrallax = Main.caveParrallax;
                        num4 = ((int) -Math.IEEERemainder(100.0 + (screenPosition.X * caveParrallax), (double) backgroundWidth[2])) - (backgroundWidth[2] / 2);
                        num5 = (screenWidth / backgroundWidth[2]) + 2;
                        if ((worldSurface * 16.0) < (screenPosition.Y - 16f))
                        {
                            num6 = ((int) Math.IEEERemainder((double) num8, (double) backgroundHeight[2])) - backgroundHeight[2];
                            num7 = ((screenHeight - num6) / backgroundHeight[2]) + 1;
                        }
                        else
                        {
                            num6 = num8;
                            num7 = ((screenHeight - num8) / backgroundHeight[2]) + 1;
                        }
                        if ((rockLayer * 16.0) < (screenPosition.Y + 600f))
                        {
                            num7 = (((int) (((rockLayer * 16.0) - screenPosition.Y) + 600.0)) - num6) / backgroundHeight[2];
                            flag3 = true;
                        }
                        for (int num50 = 0; num50 < num5; num50++)
                        {
                            for (int num51 = 0; num51 < num7; num51++)
                            {
                                this.spriteBatch.Draw(backgroundTexture[2], new Rectangle(num4 + (backgroundWidth[2] * num50), num6 + (backgroundHeight[2] * num51), backgroundWidth[2], backgroundHeight[2]), Color.White);
                            }
                        }
                        if (flag3)
                        {
                            caveParrallax = Main.caveParrallax;
                            num4 = ((int) -Math.IEEERemainder(screenPosition.X * caveParrallax, (double) backgroundWidth[1])) - (backgroundWidth[1] / 2);
                            num5 = (screenWidth / backgroundWidth[1]) + 2;
                            num8 = num6 + (num7 * backgroundHeight[2]);
                            for (int num52 = 0; num52 < num5; num52++)
                            {
                                for (int num53 = 0; num53 < 6; num53++)
                                {
                                    int num1 = ((num4 + (backgroundWidth[4] * num52)) + (num53 * 0x10)) / 0x10;
                                    int num93 = num8 / 0x10;
                                    this.spriteBatch.Draw(backgroundTexture[4], new Vector2((float) ((num4 + (backgroundWidth[4] * num52)) + (0x10 * num53)), (float) num8), new Rectangle(0x10 * num53, 0, 0x10, 0x18), Color.White);
                                }
                            }
                        }
                    }
                    num8 = (int) ((((((int) rockLayer) * 0x10) - screenPosition.Y) + 16f) + 600f);
                    if ((rockLayer * 16.0) <= (screenPosition.Y + 600f))
                    {
                        caveParrallax = Main.caveParrallax;
                        num4 = ((int) -Math.IEEERemainder(100.0 + (screenPosition.X * caveParrallax), (double) backgroundWidth[3])) - (backgroundWidth[3] / 2);
                        num5 = (screenWidth / backgroundWidth[3]) + 2;
                        if (((rockLayer * 16.0) + screenHeight) < (screenPosition.Y - 16f))
                        {
                            num6 = ((int) Math.IEEERemainder((double) num8, (double) backgroundHeight[3])) - backgroundHeight[3];
                            num7 = ((screenHeight - num6) / backgroundHeight[3]) + 1;
                        }
                        else
                        {
                            num6 = num8;
                            num7 = ((screenHeight - num8) / backgroundHeight[3]) + 1;
                        }
                        if ((num48 * 16.0) < (screenPosition.Y + 600f))
                        {
                            num7 = (((int) (((num48 * 16.0) - screenPosition.Y) + 600.0)) - num6) / backgroundHeight[2];
                            flag2 = true;
                        }
                        for (int num54 = 0; num54 < num5; num54++)
                        {
                            for (int num55 = 0; num55 < num7; num55++)
                            {
                                this.spriteBatch.Draw(backgroundTexture[3], new Rectangle(num4 + (backgroundWidth[2] * num54), num6 + (backgroundHeight[2] * num55), backgroundWidth[2], backgroundHeight[2]), Color.White);
                            }
                        }
                        if (flag2)
                        {
                            caveParrallax = Main.caveParrallax;
                            num4 = (int) ((-Math.IEEERemainder(screenPosition.X * caveParrallax, (double) backgroundWidth[1]) - (backgroundWidth[1] / 2)) - 4.0);
                            num5 = (screenWidth / backgroundWidth[1]) + 2;
                            num8 = num6 + (num7 * backgroundHeight[2]);
                            for (int num56 = 0; num56 < num5; num56++)
                            {
                                for (int num57 = 0; num57 < 6; num57++)
                                {
                                    int num58 = ((num4 + (backgroundWidth[1] * num56)) + (num57 * 0x10)) / 0x10;
                                    int num59 = num8 / 0x10;
                                    Lighting.GetColor(num58 + ((int) (screenPosition.X / 16f)), num59 + ((int) (screenPosition.Y / 16f)));
                                    this.spriteBatch.Draw(backgroundTexture[6], new Vector2((float) ((num4 + (backgroundWidth[1] * num56)) + (0x10 * num57)), (float) num8), new Rectangle(0x10 * num57, magmaBGFrame * 0x18, 0x10, 0x18), Color.White);
                                }
                            }
                        }
                    }
                    num8 = ((int) ((((((int) num48) * 0x10) - screenPosition.Y) + 16f) + 600f)) + 8;
                    if ((num48 * 16.0) <= (screenPosition.Y + 600f))
                    {
                        num4 = ((int) -Math.IEEERemainder(100.0 + (screenPosition.X * caveParrallax), (double) backgroundWidth[3])) - (backgroundWidth[3] / 2);
                        num5 = (screenWidth / backgroundWidth[3]) + 2;
                        if (((num48 * 16.0) + screenHeight) < (screenPosition.Y - 16f))
                        {
                            num6 = ((int) Math.IEEERemainder((double) num8, (double) backgroundHeight[3])) - backgroundHeight[3];
                            num7 = ((screenHeight - num6) / backgroundHeight[3]) + 1;
                        }
                        else
                        {
                            num6 = num8;
                            num7 = ((screenHeight - num8) / backgroundHeight[3]) + 1;
                        }
                        for (int num60 = 0; num60 < num5; num60++)
                        {
                            for (int num61 = 0; num61 < num7; num61++)
                            {
                                vector9 = new Vector2();
                                this.spriteBatch.Draw(backgroundTexture[5], new Vector2((float) (num4 + (backgroundWidth[2] * num60)), (float) (num6 + (backgroundHeight[2] * num61))), new Rectangle(0, backgroundHeight[2] * magmaBGFrame, backgroundWidth[2], backgroundHeight[2]), Color.White, 0f, vector9, (float) 1f, SpriteEffects.None, 0f);
                            }
                        }
                    }
                    magmaBGFrameCounter++;
                    if (magmaBGFrameCounter >= 8)
                    {
                        magmaBGFrameCounter = 0;
                        magmaBGFrame++;
                        if (magmaBGFrame >= 3)
                        {
                            magmaBGFrame = 0;
                        }
                    }
                    try
                    {
                        for (int num62 = firstY; num62 < (lastY + 4); num62++)
                        {
                            for (int num63 = firstX - 2; num63 < (lastX + 2); num63++)
                            {
                                if (tile[num63, num62] == null)
                                {
                                    tile[num63, num62] = new Tile();
                                }
                                if (((Lighting.Brightness(num63, num62) * 255f) < (tileColor.R - 12)) || (num62 > worldSurface))
                                {
                                    vector9 = new Vector2();
                                    this.spriteBatch.Draw(blackTileTexture, new Vector2((float) ((num63 * 0x10) - ((int) screenPosition.X)), (float) ((num62 * 0x10) - ((int) screenPosition.Y))), new Rectangle(tile[num63, num62].frameX, tile[num63, num62].frameY, 0x10, 0x10), Lighting.GetBlackness(num63, num62), 0f, vector9, (float) 1f, SpriteEffects.None, 0f);
                                }
                            }
                        }
                        for (int num64 = firstY; num64 < (lastY + 4); num64++)
                        {
                            for (int num65 = firstX - 2; num65 < (lastX + 2); num65++)
                            {
                                if ((tile[num65, num64].wall > 0) && (Lighting.Brightness(num65, num64) > 0f))
                                {
                                    if ((tile[num65, num64].wallFrameY == 0x12) && (tile[num65, num64].wallFrameX >= 0x12))
                                    {
                                        byte wallFrameY = tile[num65, num64].wallFrameY;
                                    }
                                    Rectangle rectangle3 = new Rectangle(tile[num65, num64].wallFrameX * 2, tile[num65, num64].wallFrameY * 2, 0x20, 0x20);
                                    vector9 = new Vector2();
                                    this.spriteBatch.Draw(wallTexture[tile[num65, num64].wall], new Vector2((float) (((num65 * 0x10) - ((int) screenPosition.X)) - 8), (float) (((num64 * 0x10) - ((int) screenPosition.Y)) - 8)), new Rectangle?(rectangle3), Lighting.GetColor(num65, num64), 0f, vector9, (float) 1f, SpriteEffects.None, 0f);
                                }
                            }
                        }
                        if (player[myPlayer].detectCreature)
                        {
                            this.DrawTiles(false);
                            this.DrawTiles(true);
                            this.DrawGore();
                            this.DrawNPCs(true);
                            this.DrawNPCs(false);
                        }
                        else
                        {
                            this.DrawTiles(false);
                            this.DrawNPCs(true);
                            this.DrawTiles(true);
                            this.DrawGore();
                            this.DrawNPCs(false);
                        }
                    }
                    catch
                    {
                    }
                    for (int n = 0; n < 0x3e8; n++)
                    {
                        if ((projectile[n].active && (projectile[n].type > 0)) && !projectile[n].hide)
                        {
                            this.DrawProj(n);
                        }
                    }
                    for (int num67 = 0; num67 < 0xff; num67++)
                    {
                        if (player[num67].active)
                        {
                            if (player[num67].ghost)
                            {
                                Vector2 position = player[num67].position;
                                player[num67].position = player[num67].shadowPos[0];
                                player[num67].shadow = 0.5f;
                                this.DrawGhost(player[num67]);
                                player[num67].position = player[num67].shadowPos[1];
                                player[num67].shadow = 0.7f;
                                this.DrawGhost(player[num67]);
                                player[num67].position = player[num67].shadowPos[2];
                                player[num67].shadow = 0.9f;
                                this.DrawGhost(player[num67]);
                                player[num67].position = position;
                                player[num67].shadow = 0f;
                                this.DrawGhost(player[num67]);
                            }
                            else
                            {
                                if (((((player[num67].head == 5) && (player[num67].body == 5)) && (player[num67].legs == 5)) || (((player[num67].head == 7) && (player[num67].body == 7)) && (player[num67].legs == 7))) || (((player[num67].head == 0x16) && (player[num67].body == 14)) && (player[num67].legs == 14)))
                                {
                                    Vector2 vector2 = player[num67].position;
                                    player[num67].position = player[num67].shadowPos[0];
                                    player[num67].shadow = 0.5f;
                                    this.DrawPlayer(player[num67]);
                                    player[num67].position = player[num67].shadowPos[1];
                                    player[num67].shadow = 0.7f;
                                    this.DrawPlayer(player[num67]);
                                    player[num67].position = player[num67].shadowPos[2];
                                    player[num67].shadow = 0.9f;
                                    this.DrawPlayer(player[num67]);
                                    player[num67].position = vector2;
                                    player[num67].shadow = 0f;
                                }
                                this.DrawPlayer(player[num67]);
                            }
                        }
                    }
                    for (int num68 = 0; num68 < 200; num68++)
                    {
                        if (item[num68].active && (item[num68].type > 0))
                        {
                            int num95 = ((int) (item[num68].position.X + (item[num68].width * 0.5))) / 0x10;
                            int num96 = ((int) (item[num68].position.Y + (item[num68].height * 0.5))) / 0x10;
                            Color newColor = Lighting.GetColor(((int) (item[num68].position.X + (item[num68].width * 0.5))) / 0x10, ((int) (item[num68].position.Y + (item[num68].height * 0.5))) / 0x10);
                            if (((!gamePaused && base.IsActive) && (((item[num68].type >= 0x47) && (item[num68].type <= 0x4a)) || ((item[num68].type == 0x3a) || (item[num68].type == 0x6d)))) && (newColor.R > 60))
                            {
                                float num69 = rand.Next(500) - ((Math.Abs(item[num68].velocity.X) + Math.Abs(item[num68].velocity.Y)) * 10f);
                                if (num69 < (newColor.R / 50))
                                {
                                    color12 = new Color();
                                    int index = Dust.NewDust(item[num68].position, item[num68].width, item[num68].height, 0x2b, 0f, 0f, 0xfe, color12, 0.5f);
                                    Dust dust1 = dust[index];
                                    dust1.velocity = (Vector2) (dust1.velocity * 0f);
                                }
                            }
                            vector9 = new Vector2();
                            this.spriteBatch.Draw(itemTexture[item[num68].type], new Vector2(((item[num68].position.X - screenPosition.X) + (item[num68].width / 2)) - (itemTexture[item[num68].type].Width / 2), ((item[num68].position.Y - screenPosition.Y) + (item[num68].height / 2)) - (itemTexture[item[num68].type].Height / 2)), new Rectangle(0, 0, itemTexture[item[num68].type].Width, itemTexture[item[num68].type].Height), item[num68].GetAlpha(newColor), 0f, vector9, (float) 1f, SpriteEffects.None, 0f);
                            color12 = new Color();
                            if (item[num68].color != color12)
                            {
                                vector9 = new Vector2();
                                this.spriteBatch.Draw(itemTexture[item[num68].type], new Vector2(((item[num68].position.X - screenPosition.X) + (item[num68].width / 2)) - (itemTexture[item[num68].type].Width / 2), ((item[num68].position.Y - screenPosition.Y) + (item[num68].height / 2)) - (itemTexture[item[num68].type].Height / 2)), new Rectangle(0, 0, itemTexture[item[num68].type].Width, itemTexture[item[num68].type].Height), item[num68].GetColor(newColor), 0f, vector9, (float) 1f, SpriteEffects.None, 0f);
                            }
                        }
                    }
                    Rectangle rectangle4 = new Rectangle(((int) screenPosition.X) - 50, ((int) screenPosition.Y) - 50, screenWidth + 100, screenHeight + 100);
                    for (int num71 = 0; num71 < numDust; num71++)
                    {
                        if (dust[num71].active)
                        {
                            Rectangle rectangle5 = new Rectangle((int) dust[num71].position.X, (int) dust[num71].position.Y, 4, 4);
                            if (rectangle5.Intersects(rectangle4))
                            {
                                Color alpha = Lighting.GetColor(((int) (dust[num71].position.X + 4.0)) / 0x10, ((int) (dust[num71].position.Y + 4.0)) / 0x10);
                                if (((dust[num71].type == 6) || (dust[num71].type == 15)) || dust[num71].noLight)
                                {
                                    alpha = Color.White;
                                }
                                alpha = dust[num71].GetAlpha(alpha);
                                this.spriteBatch.Draw(dustTexture, dust[num71].position - screenPosition, new Rectangle?(dust[num71].frame), alpha, dust[num71].rotation, new Vector2(4f, 4f), dust[num71].scale, SpriteEffects.None, 0f);
                                color12 = new Color();
                                if (dust[num71].color != color12)
                                {
                                    this.spriteBatch.Draw(dustTexture, dust[num71].position - screenPosition, new Rectangle?(dust[num71].frame), dust[num71].GetColor(alpha), dust[num71].rotation, new Vector2(4f, 4f), dust[num71].scale, SpriteEffects.None, 0f);
                                }
                                if (alpha == Color.Black)
                                {
                                    dust[num71].active = false;
                                }
                            }
                            else
                            {
                                dust[num71].active = false;
                            }
                        }
                    }
                    this.DrawWater(false);
                    if (!hideUI)
                    {
                        for (int num72 = 0; num72 < 0xff; num72++)
                        {
                            if ((player[num72].active && (player[num72].chatShowTime > 0)) && ((num72 != myPlayer) && !player[num72].dead))
                            {
                                Vector2 vector3;
                                Vector2 vector4 = fontMouseText.MeasureString(player[num72].chatText);
                                vector3.X = (player[num72].position.X + (player[num72].width / 2)) - (vector4.X / 2f);
                                vector3.Y = (player[num72].position.Y - vector4.Y) - 2f;
                                for (int num73 = 0; num73 < 5; num73++)
                                {
                                    int num74 = 0;
                                    int num75 = 0;
                                    Color black = Color.Black;
                                    switch (num73)
                                    {
                                        case 0:
                                            num74 = -2;
                                            break;

                                        case 1:
                                            num74 = 2;
                                            break;

                                        case 2:
                                            num75 = -2;
                                            break;

                                        case 3:
                                            num75 = 2;
                                            break;

                                        case 4:
                                            black = new Color((int) mouseTextColor, (int) mouseTextColor, (int) mouseTextColor, (int) mouseTextColor);
                                            break;
                                    }
                                    vector9 = new Vector2();
                                    this.spriteBatch.DrawString(fontMouseText, player[num72].chatText, new Vector2((vector3.X + num74) - screenPosition.X, (vector3.Y + num75) - screenPosition.Y), black, 0f, vector9, (float) 1f, SpriteEffects.None, 0f);
                                }
                            }
                        }
                        for (int num76 = 0; num76 < 100; num76++)
                        {
                            if (combatText[num76].active)
                            {
                                int num77 = 0;
                                if (combatText[num76].crit)
                                {
                                    num77 = 1;
                                }
                                Vector2 vector5 = fontCombatText[num77].MeasureString(combatText[num76].text);
                                Vector2 origin = new Vector2(vector5.X * 0.5f, vector5.Y * 0.5f);
                                float single1 = combatText[num76].scale;
                                float num78 = combatText[num76].color.R;
                                float num79 = combatText[num76].color.G;
                                float num80 = combatText[num76].color.B;
                                float a = combatText[num76].color.A;
                                num78 *= (combatText[num76].scale * combatText[num76].alpha) * 0.3f;
                                num80 *= (combatText[num76].scale * combatText[num76].alpha) * 0.3f;
                                num79 *= (combatText[num76].scale * combatText[num76].alpha) * 0.3f;
                                a *= combatText[num76].scale * combatText[num76].alpha;
                                Color color10 = new Color((int) num78, (int) num79, (int) num80, (int) a);
                                for (int num82 = 0; num82 < 5; num82++)
                                {
                                    int num83 = 0;
                                    int num84 = 0;
                                    switch (num82)
                                    {
                                        case 0:
                                            num83--;
                                            break;

                                        case 1:
                                            num83++;
                                            break;

                                        case 2:
                                            num84--;
                                            break;

                                        case 3:
                                            num84++;
                                            break;

                                        default:
                                            num78 = (combatText[num76].color.R * combatText[num76].scale) * combatText[num76].alpha;
                                            num80 = (combatText[num76].color.B * combatText[num76].scale) * combatText[num76].alpha;
                                            num79 = (combatText[num76].color.G * combatText[num76].scale) * combatText[num76].alpha;
                                            a = (combatText[num76].color.A * combatText[num76].scale) * combatText[num76].alpha;
                                            color10 = new Color((int) num78, (int) num79, (int) num80, (int) a);
                                            break;
                                    }
                                    this.spriteBatch.DrawString(fontCombatText[num77], combatText[num76].text, new Vector2(((combatText[num76].position.X - screenPosition.X) + num83) + origin.X, ((combatText[num76].position.Y - screenPosition.Y) + num84) + origin.Y), color10, combatText[num76].rotation, origin, combatText[num76].scale, SpriteEffects.None, 0f);
                                }
                            }
                        }
                        for (int num85 = 0; num85 < 100; num85++)
                        {
                            if (itemText[num85].active)
                            {
                                string name = itemText[num85].name;
                                if (itemText[num85].stack > 1)
                                {
                                    name = string.Concat(new object[] { name, " (", itemText[num85].stack, ")" });
                                }
                                Vector2 vector7 = fontMouseText.MeasureString(name);
                                Vector2 vector8 = new Vector2(vector7.X * 0.5f, vector7.Y * 0.5f);
                                float single2 = itemText[num85].scale;
                                float num86 = itemText[num85].color.R;
                                float num87 = itemText[num85].color.G;
                                float num88 = itemText[num85].color.B;
                                float num89 = itemText[num85].color.A;
                                num86 *= (itemText[num85].scale * itemText[num85].alpha) * 0.3f;
                                num88 *= (itemText[num85].scale * itemText[num85].alpha) * 0.3f;
                                num87 *= (itemText[num85].scale * itemText[num85].alpha) * 0.3f;
                                num89 *= itemText[num85].scale * itemText[num85].alpha;
                                Color color11 = new Color((int) num86, (int) num87, (int) num88, (int) num89);
                                for (int num90 = 0; num90 < 5; num90++)
                                {
                                    int num91 = 0;
                                    int num92 = 0;
                                    switch (num90)
                                    {
                                        case 0:
                                            num91 -= 2;
                                            break;

                                        case 1:
                                            num91 += 2;
                                            break;

                                        case 2:
                                            num92 -= 2;
                                            break;

                                        case 3:
                                            num92 += 2;
                                            break;

                                        default:
                                            num86 = (itemText[num85].color.R * itemText[num85].scale) * itemText[num85].alpha;
                                            num88 = (itemText[num85].color.B * itemText[num85].scale) * itemText[num85].alpha;
                                            num87 = (itemText[num85].color.G * itemText[num85].scale) * itemText[num85].alpha;
                                            num89 = (itemText[num85].color.A * itemText[num85].scale) * itemText[num85].alpha;
                                            color11 = new Color((int) num86, (int) num87, (int) num88, (int) num89);
                                            break;
                                    }
                                    if (num90 < 4)
                                    {
                                        num89 = (itemText[num85].color.A * itemText[num85].scale) * itemText[num85].alpha;
                                        color11 = new Color(0, 0, 0, (int) num89);
                                    }
                                    this.spriteBatch.DrawString(fontMouseText, name, new Vector2(((itemText[num85].position.X - screenPosition.X) + num91) + vector8.X, ((itemText[num85].position.Y - screenPosition.Y) + num92) + vector8.Y), color11, itemText[num85].rotation, vector8, itemText[num85].scale, SpriteEffects.None, 0f);
                                }
                            }
                        }
                        if (((netMode == 1) && (Netplay.clientSock.statusText != "")) && (Netplay.clientSock.statusText != null))
                        {
                            string text = string.Concat(new object[] { Netplay.clientSock.statusText, ": ", (int) ((((float) Netplay.clientSock.statusCount) / ((float) Netplay.clientSock.statusMax)) * 100f), "%" });
                            this.spriteBatch.DrawString(fontMouseText, text, new Vector2((628f - (fontMouseText.MeasureString(text).X * 0.5f)) + (screenWidth - 800), 84f), new Color(mouseTextColor, mouseTextColor, mouseTextColor, mouseTextColor), 0f, new Vector2(), (float) 1f, SpriteEffects.None, 0f);
                        }
                        this.DrawFPS();
                        this.DrawInterface();
                    }
                    this.spriteBatch.End();
                    if (mouseState.LeftButton == ButtonState.Pressed)
                    {
                        mouseLeftRelease = false;
                    }
                    else
                    {
                        mouseLeftRelease = true;
                    }
                    if (mouseState.RightButton == ButtonState.Pressed)
                    {
                        mouseRightRelease = false;
                    }
                    else
                    {
                        mouseRightRelease = true;
                    }
                    if (mouseState.RightButton != ButtonState.Pressed)
                    {
                        stackSplit = 0;
                    }
                    if (stackSplit > 0)
                    {
                        stackSplit--;
                    }
                }
            }
        }

        protected void DrawChat()
        {
            if ((player[myPlayer].talkNPC < 0) && (player[myPlayer].sign == -1))
            {
                npcChatText = "";
            }
            else
            {
                Color color = new Color(200, 200, 200, 200);
                int r = ((mouseTextColor * 2) + 0xff) / 3;
                Color color2 = new Color(r, r, r, r);
                int num2 = 10;
                int index = 0;
                string[] strArray = new string[num2];
                int startIndex = 0;
                int num5 = 0;
                if (npcChatText == null)
                {
                    npcChatText = "";
                }
                for (int i = 0; i < npcChatText.Length; i++)
                {
                    if (Encoding.ASCII.GetBytes(npcChatText.Substring(i, 1))[0] == 10)
                    {
                        strArray[index] = npcChatText.Substring(startIndex, i - startIndex);
                        index++;
                        startIndex = i + 1;
                        num5 = i + 1;
                    }
                    else if ((npcChatText.Substring(i, 1) == " ") || (i == (npcChatText.Length - 1)))
                    {
                        if (fontMouseText.MeasureString(npcChatText.Substring(startIndex, i - startIndex)).X > 470f)
                        {
                            strArray[index] = npcChatText.Substring(startIndex, num5 - startIndex);
                            index++;
                            startIndex = num5 + 1;
                        }
                        num5 = i;
                    }
                    if (index == 10)
                    {
                        npcChatText = npcChatText.Substring(0, i - 1);
                        startIndex = i - 1;
                        index = 9;
                        break;
                    }
                }
                if (index < 10)
                {
                    strArray[index] = npcChatText.Substring(startIndex, npcChatText.Length - startIndex);
                }
                if (editSign)
                {
                    this.textBlinkerCount++;
                    if (this.textBlinkerCount >= 20)
                    {
                        if (this.textBlinkerState == 0)
                        {
                            this.textBlinkerState = 1;
                        }
                        else
                        {
                            this.textBlinkerState = 0;
                        }
                        this.textBlinkerCount = 0;
                    }
                    if (this.textBlinkerState == 1)
                    {
                        string[] strArray2;
                        IntPtr ptr;
                        (strArray2 = strArray)[(int) (ptr = (IntPtr) index)] = strArray2[(int) ptr] + "|";
                    }
                }
                index++;
                this.spriteBatch.Draw(chatBackTexture, new Vector2((float) ((screenWidth / 2) - (chatBackTexture.Width / 2)), 100f), new Rectangle(0, 0, chatBackTexture.Width, (index + 1) * 30), color, 0f, new Vector2(), (float) 1f, SpriteEffects.None, 0f);
                this.spriteBatch.Draw(chatBackTexture, new Vector2((float) ((screenWidth / 2) - (chatBackTexture.Width / 2)), (float) (100 + ((index + 1) * 30))), new Rectangle(0, chatBackTexture.Height - 30, chatBackTexture.Width, 30), color, 0f, new Vector2(), (float) 1f, SpriteEffects.None, 0f);
                for (int j = 0; j < index; j++)
                {
                    for (int n = 0; n < 5; n++)
                    {
                        Color black = Color.Black;
                        int num9 = 170 + ((screenWidth - 800) / 2);
                        int num10 = 120 + (j * 30);
                        switch (n)
                        {
                            case 0:
                                num9 -= 2;
                                break;

                            case 1:
                                num9 += 2;
                                break;

                            case 2:
                                num10 -= 2;
                                break;

                            case 3:
                                num10 += 2;
                                break;

                            case 4:
                                black = color2;
                                break;
                        }
                        Vector2 origin = new Vector2();
                        this.spriteBatch.DrawString(fontMouseText, strArray[j], new Vector2((float) num9, (float) num10), black, 0f, origin, (float) 1f, SpriteEffects.None, 0f);
                    }
                }
                r = mouseTextColor;
                color2 = new Color(r, (int) (((double) r) / 1.1), r / 2, r);
                string text = "";
                string str2 = "";
                int price = player[myPlayer].statLifeMax - player[myPlayer].statLife;
                if (player[myPlayer].sign > -1)
                {
                    if (editSign)
                    {
                        text = "Save";
                    }
                    else
                    {
                        text = "Edit";
                    }
                }
                else if (((npc[player[myPlayer].talkNPC].type == 0x11) || (npc[player[myPlayer].talkNPC].type == 0x13)) || (((npc[player[myPlayer].talkNPC].type == 20) || (npc[player[myPlayer].talkNPC].type == 0x26)) || (npc[player[myPlayer].talkNPC].type == 0x36)))
                {
                    text = "Shop";
                }
                else if (npc[player[myPlayer].talkNPC].type == 0x25)
                {
                    if (!dayTime)
                    {
                        text = "Curse";
                    }
                }
                else if (npc[player[myPlayer].talkNPC].type == 0x16)
                {
                    text = "Help";
                    str2 = "Crafting";
                }
                else if (npc[player[myPlayer].talkNPC].type == 0x12)
                {
                    string str3 = "";
                    int num12 = 0;
                    int num13 = 0;
                    int num14 = 0;
                    int num15 = 0;
                    int num16 = price;
                    if (num16 > 0)
                    {
                        num16 = (int) (num16 * 0.75);
                        if (num16 < 1)
                        {
                            num16 = 1;
                        }
                    }
                    if (num16 < 0)
                    {
                        num16 = 0;
                    }
                    price = num16;
                    if (num16 >= 0xf4240)
                    {
                        num12 = num16 / 0xf4240;
                        num16 -= num12 * 0xf4240;
                    }
                    if (num16 >= 0x2710)
                    {
                        num13 = num16 / 0x2710;
                        num16 -= num13 * 0x2710;
                    }
                    if (num16 >= 100)
                    {
                        num14 = num16 / 100;
                        num16 -= num14 * 100;
                    }
                    if (num16 >= 1)
                    {
                        num15 = num16;
                    }
                    if (num12 > 0)
                    {
                        str3 = str3 + num12 + " platinum ";
                    }
                    if (num13 > 0)
                    {
                        str3 = str3 + num13 + " gold ";
                    }
                    if (num14 > 0)
                    {
                        str3 = str3 + num14 + " silver ";
                    }
                    if (num15 > 0)
                    {
                        str3 = str3 + num15 + " copper ";
                    }
                    float num17 = ((float) mouseTextColor) / 255f;
                    if (num12 > 0)
                    {
                        color2 = new Color((int) ((byte) (220f * num17)), (int) ((byte) (220f * num17)), (int) ((byte) (198f * num17)), (int) mouseTextColor);
                    }
                    else if (num13 > 0)
                    {
                        color2 = new Color((int) ((byte) (224f * num17)), (int) ((byte) (201f * num17)), (int) ((byte) (92f * num17)), (int) mouseTextColor);
                    }
                    else if (num14 > 0)
                    {
                        color2 = new Color((int) ((byte) (181f * num17)), (int) ((byte) (192f * num17)), (int) ((byte) (193f * num17)), (int) mouseTextColor);
                    }
                    else if (num15 > 0)
                    {
                        color2 = new Color((int) ((byte) (246f * num17)), (int) ((byte) (138f * num17)), (int) ((byte) (96f * num17)), (int) mouseTextColor);
                    }
                    text = "Heal (" + str3 + ")";
                    if (num16 == 0)
                    {
                        text = "Heal";
                    }
                }
                int num18 = 180 + ((screenWidth - 800) / 2);
                int num19 = 130 + (index * 30);
                float scale = 0.9f;
                if (((mouseState.X > num18) && (mouseState.X < (num18 + fontMouseText.MeasureString(text).X))) && ((mouseState.Y > num19) && (mouseState.Y < (num19 + fontMouseText.MeasureString(text).Y))))
                {
                    player[myPlayer].mouseInterface = true;
                    scale = 1.1f;
                    if (!npcChatFocus2)
                    {
                        PlaySound(12, -1, -1, 1);
                    }
                    npcChatFocus2 = true;
                    player[myPlayer].releaseUseItem = false;
                }
                else
                {
                    if (npcChatFocus2)
                    {
                        PlaySound(12, -1, -1, 1);
                    }
                    npcChatFocus2 = false;
                }
                for (int k = 0; k < 5; k++)
                {
                    int num22 = num18;
                    int num23 = num19;
                    Color color4 = Color.Black;
                    switch (k)
                    {
                        case 0:
                            num22 -= 2;
                            break;

                        case 1:
                            num22 += 2;
                            break;

                        case 2:
                            num23 -= 2;
                            break;

                        case 3:
                            num23 += 2;
                            break;

                        case 4:
                            color4 = color2;
                            break;
                    }
                    Vector2 vector = (Vector2) (fontMouseText.MeasureString(text) * 0.5f);
                    this.spriteBatch.DrawString(fontMouseText, text, new Vector2(num22 + vector.X, num23 + vector.Y), color4, 0f, vector, scale, SpriteEffects.None, 0f);
                }
                color2 = new Color(r, (int) (((double) r) / 1.1), r / 2, r);
                num18 = (num18 + ((int) fontMouseText.MeasureString(text).X)) + 20;
                num19 = 130 + (index * 30);
                scale = 0.9f;
                if (((mouseState.X > num18) && (mouseState.X < (num18 + fontMouseText.MeasureString("Close").X))) && ((mouseState.Y > num19) && (mouseState.Y < (num19 + fontMouseText.MeasureString("Close").Y))))
                {
                    scale = 1.1f;
                    if (!npcChatFocus1)
                    {
                        PlaySound(12, -1, -1, 1);
                    }
                    npcChatFocus1 = true;
                    player[myPlayer].releaseUseItem = false;
                    player[myPlayer].controlUseItem = false;
                }
                else
                {
                    if (npcChatFocus1)
                    {
                        PlaySound(12, -1, -1, 1);
                    }
                    npcChatFocus1 = false;
                }
                for (int m = 0; m < 5; m++)
                {
                    int num25 = num18;
                    int num26 = num19;
                    Color color5 = Color.Black;
                    switch (m)
                    {
                        case 0:
                            num25 -= 2;
                            break;

                        case 1:
                            num25 += 2;
                            break;

                        case 2:
                            num26 -= 2;
                            break;

                        case 3:
                            num26 += 2;
                            break;

                        case 4:
                            color5 = color2;
                            break;
                    }
                    Vector2 vector2 = (Vector2) (fontMouseText.MeasureString("Close") * 0.5f);
                    this.spriteBatch.DrawString(fontMouseText, "Close", new Vector2(num25 + vector2.X, num26 + vector2.Y), color5, 0f, vector2, scale, SpriteEffects.None, 0f);
                }
                if (str2 != "")
                {
                    num18 = 0x128 + ((screenWidth - 800) / 2);
                    num19 = 130 + (index * 30);
                    scale = 0.9f;
                    if (((mouseState.X > num18) && (mouseState.X < (num18 + fontMouseText.MeasureString(str2).X))) && ((mouseState.Y > num19) && (mouseState.Y < (num19 + fontMouseText.MeasureString(str2).Y))))
                    {
                        player[myPlayer].mouseInterface = true;
                        scale = 1.1f;
                        if (!npcChatFocus3)
                        {
                            PlaySound(12, -1, -1, 1);
                        }
                        npcChatFocus3 = true;
                        player[myPlayer].releaseUseItem = false;
                    }
                    else
                    {
                        if (npcChatFocus3)
                        {
                            PlaySound(12, -1, -1, 1);
                        }
                        npcChatFocus3 = false;
                    }
                    for (int num27 = 0; num27 < 5; num27++)
                    {
                        int num28 = num18;
                        int num29 = num19;
                        Color color6 = Color.Black;
                        switch (num27)
                        {
                            case 0:
                                num28 -= 2;
                                break;

                            case 1:
                                num28 += 2;
                                break;

                            case 2:
                                num29 -= 2;
                                break;

                            case 3:
                                num29 += 2;
                                break;

                            case 4:
                                color6 = color2;
                                break;
                        }
                        Vector2 vector3 = (Vector2) (fontMouseText.MeasureString(text) * 0.5f);
                        this.spriteBatch.DrawString(fontMouseText, str2, new Vector2(num28 + vector3.X, num29 + vector3.Y), color6, 0f, vector3, scale, SpriteEffects.None, 0f);
                    }
                }
                if ((mouseState.LeftButton == ButtonState.Pressed) && mouseLeftRelease)
                {
                    mouseLeftRelease = false;
                    player[myPlayer].releaseUseItem = false;
                    player[myPlayer].mouseInterface = true;
                    if (npcChatFocus1)
                    {
                        player[myPlayer].talkNPC = -1;
                        player[myPlayer].sign = -1;
                        editSign = false;
                        npcChatText = "";
                        PlaySound(11, -1, -1, 1);
                    }
                    else if (npcChatFocus2)
                    {
                        if (player[myPlayer].sign == -1)
                        {
                            if (npc[player[myPlayer].talkNPC].type == 0x11)
                            {
                                playerInventory = true;
                                npcChatText = "";
                                npcShop = 1;
                                this.shop[npcShop].SetupShop(npcShop);
                                PlaySound(12, -1, -1, 1);
                            }
                            else if (npc[player[myPlayer].talkNPC].type == 0x13)
                            {
                                playerInventory = true;
                                npcChatText = "";
                                npcShop = 2;
                                this.shop[npcShop].SetupShop(npcShop);
                                PlaySound(12, -1, -1, 1);
                            }
                            else if (npc[player[myPlayer].talkNPC].type == 0x25)
                            {
                                if (netMode == 0)
                                {
                                    NPC.SpawnSkeletron();
                                }
                                else
                                {
                                    NetMessage.SendData(0x33, -1, -1, "", myPlayer, 1f, 0f, 0f, 0);
                                }
                                npcChatText = "";
                            }
                            else if (npc[player[myPlayer].talkNPC].type == 20)
                            {
                                playerInventory = true;
                                npcChatText = "";
                                npcShop = 3;
                                this.shop[npcShop].SetupShop(npcShop);
                                PlaySound(12, -1, -1, 1);
                            }
                            else if (npc[player[myPlayer].talkNPC].type == 0x26)
                            {
                                playerInventory = true;
                                npcChatText = "";
                                npcShop = 4;
                                this.shop[npcShop].SetupShop(npcShop);
                                PlaySound(12, -1, -1, 1);
                            }
                            else if (npc[player[myPlayer].talkNPC].type == 0x36)
                            {
                                playerInventory = true;
                                npcChatText = "";
                                npcShop = 5;
                                this.shop[npcShop].SetupShop(npcShop);
                                PlaySound(12, -1, -1, 1);
                            }
                            else if (npc[player[myPlayer].talkNPC].type == 0x16)
                            {
                                PlaySound(12, -1, -1, 1);
                                HelpText();
                            }
                            else if (npc[player[myPlayer].talkNPC].type == 0x12)
                            {
                                PlaySound(12, -1, -1, 1);
                                if (price <= 0)
                                {
                                    switch (rand.Next(3))
                                    {
                                        case 0:
                                            npcChatText = "I don't give happy endings.";
                                            break;

                                        case 1:
                                            npcChatText = "I can't do anymore for you without plastic surgery.";
                                            break;

                                        case 2:
                                            npcChatText = "Quit wasting my time.";
                                            return;
                                    }
                                }
                                else if (player[myPlayer].BuyItem(price))
                                {
                                    PlaySound(2, -1, -1, 4);
                                    player[myPlayer].HealEffect(player[myPlayer].statLifeMax - player[myPlayer].statLife);
                                    if (player[myPlayer].statLife < (player[myPlayer].statLifeMax * 0.25))
                                    {
                                        npcChatText = "I managed to sew your face back on. Be more careful next time.";
                                    }
                                    else if (player[myPlayer].statLife < (player[myPlayer].statLifeMax * 0.5))
                                    {
                                        npcChatText = "That's probably going to leave a scar.";
                                    }
                                    else if (player[myPlayer].statLife < (player[myPlayer].statLifeMax * 0.75))
                                    {
                                        npcChatText = "All better. I don't want to see you jumping off anymore cliffs.";
                                    }
                                    else
                                    {
                                        npcChatText = "That didn't hurt too bad, now did it?";
                                    }
                                    player[myPlayer].statLife = player[myPlayer].statLifeMax;
                                }
                                else
                                {
                                    switch (rand.Next(3))
                                    {
                                        case 0:
                                            npcChatText = "I'm sorry, but you can't afford me.";
                                            break;

                                        case 1:
                                            npcChatText = "I'm gonna need more gold than that.";
                                            break;

                                        case 2:
                                            npcChatText = "I don't work for free you know.";
                                            return;
                                    }
                                }
                            }
                        }
                        else if (!editSign)
                        {
                            PlaySound(12, -1, -1, 1);
                            editSign = true;
                        }
                        else
                        {
                            PlaySound(12, -1, -1, 1);
                            int sign = player[myPlayer].sign;
                            Sign.TextSign(sign, npcChatText);
                            editSign = false;
                            if (netMode == 1)
                            {
                                NetMessage.SendData(0x2f, -1, -1, "", sign, 0f, 0f, 0f, 0);
                            }
                        }
                    }
                    else if ((npcChatFocus3 && (player[myPlayer].talkNPC >= 0)) && (npc[player[myPlayer].talkNPC].type == 0x16))
                    {
                        playerInventory = true;
                        npcChatText = "";
                        PlaySound(12, -1, -1, 1);
                        craftGuide = true;
                    }
                }
            }
        }

        protected void DrawFPS()
        {
            if (showFrameRate)
            {
                object obj2 = frameRate;
                string text = string.Concat(new object[] { obj2, " (", Liquid.numLiquid + LiquidBuffer.numLiquidBuffer, ")" });
                this.spriteBatch.DrawString(fontMouseText, text, new Vector2(4f, (float) (screenHeight - 0x18)), new Color(mouseTextColor, mouseTextColor, mouseTextColor, mouseTextColor), 0f, new Vector2(), (float) 1f, SpriteEffects.None, 0f);
            }
        }

        protected void DrawGhost(Player drawPlayer)
        {
            SpriteEffects none = SpriteEffects.None;
            if (drawPlayer.direction == 1)
            {
                none = SpriteEffects.None;
            }
            else
            {
                none = SpriteEffects.FlipHorizontally;
            }
            Color immuneAlpha = drawPlayer.GetImmuneAlpha(Lighting.GetColor(((int) (drawPlayer.position.X + (drawPlayer.width * 0.5))) / 0x10, ((int) (drawPlayer.position.Y + (drawPlayer.height * 0.5))) / 0x10, new Color((mouseTextColor / 2) + 100, (mouseTextColor / 2) + 100, (mouseTextColor / 2) + 100, (mouseTextColor / 2) + 100)));
            Rectangle rectangle = new Rectangle(0, (ghostTexture.Height / 4) * drawPlayer.ghostFrame, ghostTexture.Width, ghostTexture.Height / 4);
            Vector2 origin = new Vector2(rectangle.Width * 0.5f, rectangle.Height * 0.5f);
            this.spriteBatch.Draw(ghostTexture, new Vector2((float) (((int) (drawPlayer.position.X - screenPosition.X)) + (rectangle.Width / 2)), (float) (((int) (drawPlayer.position.Y - screenPosition.Y)) + (rectangle.Height / 2))), new Rectangle?(rectangle), immuneAlpha, 0f, origin, (float) 1f, none, 0f);
        }

        protected void DrawGore()
        {
            for (int i = 0; i < 200; i++)
            {
                if (gore[i].active && (gore[i].type > 0))
                {
                    Color alpha = gore[i].GetAlpha(Lighting.GetColor(((int) (gore[i].position.X + (goreTexture[gore[i].type].Width * 0.5))) / 0x10, (int) ((gore[i].position.Y + (goreTexture[gore[i].type].Height * 0.5)) / 16.0)));
                    this.spriteBatch.Draw(goreTexture[gore[i].type], new Vector2((gore[i].position.X - screenPosition.X) + (goreTexture[gore[i].type].Width / 2), (gore[i].position.Y - screenPosition.Y) + (goreTexture[gore[i].type].Height / 2)), new Rectangle(0, 0, goreTexture[gore[i].type].Width, goreTexture[gore[i].type].Height), alpha, gore[i].rotation, new Vector2((float) (goreTexture[gore[i].type].Width / 2), (float) (goreTexture[gore[i].type].Height / 2)), gore[i].scale, SpriteEffects.None, 0f);
                }
            }
        }

        protected void DrawInterface()
        {
            mouseHC = false;
            if (!hideUI)
            {
                Vector2 vector10;
                object obj2;
                Color color30;
                if (signBubble)
                {
                    int num = signX - ((int) screenPosition.X);
                    int num2 = signY - ((int) screenPosition.Y);
                    SpriteEffects none = SpriteEffects.None;
                    if (signX > (player[myPlayer].position.X + player[myPlayer].width))
                    {
                        none = SpriteEffects.FlipHorizontally;
                        num += -8 - chat2Texture.Width;
                    }
                    else
                    {
                        num += 8;
                    }
                    num2 -= 0x16;
                    vector10 = new Vector2();
                    this.spriteBatch.Draw(chat2Texture, new Vector2((float) num, (float) num2), new Rectangle(0, 0, chat2Texture.Width, chat2Texture.Height), new Color(mouseTextColor, mouseTextColor, mouseTextColor, mouseTextColor), 0f, vector10, (float) 1f, none, 0f);
                    signBubble = false;
                }
                for (int i = 0; i < 0xff; i++)
                {
                    if ((player[i].active && (myPlayer != i)) && !player[i].dead)
                    {
                        new Rectangle((int) ((player[i].position.X + (player[i].width * 0.5)) - 16.0), (int) ((player[i].position.Y + player[i].height) - 48f), 0x20, 0x30);
                        if ((player[myPlayer].team > 0) && (player[myPlayer].team == player[i].team))
                        {
                            new Rectangle((int) screenPosition.X, (int) screenPosition.Y, screenWidth, Main.screenHeight);
                            string name = player[i].name;
                            if (player[i].statLife < player[i].statLifeMax)
                            {
                                obj2 = name;
                                name = string.Concat(new object[] { obj2, ": ", player[i].statLife, "/", player[i].statLifeMax });
                            }
                            Vector2 position = fontMouseText.MeasureString(name);
                            float num4 = 0f;
                            if (player[i].chatShowTime > 0)
                            {
                                num4 = -position.Y;
                            }
                            float num5 = 0f;
                            float num6 = ((float) mouseTextColor) / 255f;
                            Color color = new Color((int) ((byte) (teamColor[player[i].team].R * num6)), (int) ((byte) (teamColor[player[i].team].G * num6)), (int) ((byte) (teamColor[player[i].team].B * num6)), (int) mouseTextColor);
                            Vector2 vector2 = new Vector2((screenWidth / 2) + screenPosition.X, (Main.screenHeight / 2) + screenPosition.Y);
                            float num7 = (player[i].position.X + (player[i].width / 2)) - vector2.X;
                            float num8 = (((player[i].position.Y - position.Y) - 2f) + num4) - vector2.Y;
                            float num9 = (float) Math.Sqrt((double) ((num7 * num7) + (num8 * num8)));
                            int screenHeight = Main.screenHeight;
                            if (Main.screenHeight > screenWidth)
                            {
                                screenHeight = screenWidth;
                            }
                            screenHeight = (screenHeight / 2) - 30;
                            if (screenHeight < 100)
                            {
                                screenHeight = 100;
                            }
                            if (num9 < screenHeight)
                            {
                                position.X = ((player[i].position.X + (player[i].width / 2)) - (position.X / 2f)) - screenPosition.X;
                                position.Y = (((player[i].position.Y - position.Y) - 2f) + num4) - screenPosition.Y;
                            }
                            else
                            {
                                num5 = num9;
                                num9 = ((float) screenHeight) / num9;
                                position.X = ((screenWidth / 2) + (num7 * num9)) - (position.X / 2f);
                                position.Y = (Main.screenHeight / 2) + (num8 * num9);
                            }
                            if (num5 > 0f)
                            {
                                string str2 = "(" + ((int) ((num5 / 16f) * 2f)) + " ft)";
                                Vector2 vector3 = fontMouseText.MeasureString(str2);
                                vector3.X = (position.X + (fontMouseText.MeasureString(name).X / 2f)) - (vector3.X / 2f);
                                vector3.Y = ((position.Y + (fontMouseText.MeasureString(name).Y / 2f)) - (vector3.Y / 2f)) - 20f;
                                vector10 = new Vector2();
                                this.spriteBatch.DrawString(fontMouseText, str2, new Vector2(vector3.X - 2f, vector3.Y), Color.Black, 0f, vector10, (float) 1f, SpriteEffects.None, 0f);
                                vector10 = new Vector2();
                                this.spriteBatch.DrawString(fontMouseText, str2, new Vector2(vector3.X + 2f, vector3.Y), Color.Black, 0f, vector10, (float) 1f, SpriteEffects.None, 0f);
                                vector10 = new Vector2();
                                this.spriteBatch.DrawString(fontMouseText, str2, new Vector2(vector3.X, vector3.Y - 2f), Color.Black, 0f, vector10, (float) 1f, SpriteEffects.None, 0f);
                                vector10 = new Vector2();
                                this.spriteBatch.DrawString(fontMouseText, str2, new Vector2(vector3.X, vector3.Y + 2f), Color.Black, 0f, vector10, (float) 1f, SpriteEffects.None, 0f);
                                vector10 = new Vector2();
                                this.spriteBatch.DrawString(fontMouseText, str2, vector3, color, 0f, vector10, (float) 1f, SpriteEffects.None, 0f);
                            }
                            vector10 = new Vector2();
                            this.spriteBatch.DrawString(fontMouseText, name, new Vector2(position.X - 2f, position.Y), Color.Black, 0f, vector10, (float) 1f, SpriteEffects.None, 0f);
                            vector10 = new Vector2();
                            this.spriteBatch.DrawString(fontMouseText, name, new Vector2(position.X + 2f, position.Y), Color.Black, 0f, vector10, (float) 1f, SpriteEffects.None, 0f);
                            vector10 = new Vector2();
                            this.spriteBatch.DrawString(fontMouseText, name, new Vector2(position.X, position.Y - 2f), Color.Black, 0f, vector10, (float) 1f, SpriteEffects.None, 0f);
                            vector10 = new Vector2();
                            this.spriteBatch.DrawString(fontMouseText, name, new Vector2(position.X, position.Y + 2f), Color.Black, 0f, vector10, (float) 1f, SpriteEffects.None, 0f);
                            vector10 = new Vector2();
                            this.spriteBatch.DrawString(fontMouseText, name, position, color, 0f, vector10, (float) 1f, SpriteEffects.None, 0f);
                        }
                    }
                }
                if (playerInventory)
                {
                    npcChatText = "";
                    player[myPlayer].sign = -1;
                }
                if (ignoreErrors)
                {
                    try
                    {
                        if ((npcChatText != "") || (player[myPlayer].sign != -1))
                        {
                            this.DrawChat();
                        }
                    }
                    catch
                    {
                    }
                }
                else if ((npcChatText != "") || (player[myPlayer].sign != -1))
                {
                    this.DrawChat();
                }
                Color color2 = new Color(220, 220, 220, 220);
                invAlpha += invDir * 0.2f;
                if (invAlpha > 240f)
                {
                    invAlpha = 240f;
                    invDir = -1f;
                }
                if (invAlpha < 180f)
                {
                    invAlpha = 180f;
                    invDir = 1f;
                }
                color2 = new Color((int) ((byte) invAlpha), (int) ((byte) invAlpha), (int) ((byte) invAlpha), (int) ((byte) invAlpha));
                bool flag = false;
                int rare = 0;
                int num12 = screenWidth - 800;
                int num13 = player[myPlayer].statLifeMax / 20;
                if (num13 >= 10)
                {
                    num13 = 10;
                }
                string text = string.Concat(new object[] { "Life: ", player[myPlayer].statLifeMax, "/", player[myPlayer].statLifeMax });
                Vector2 vector4 = fontMouseText.MeasureString(text);
                if (!player[myPlayer].ghost)
                {
                    vector10 = new Vector2();
                    this.spriteBatch.DrawString(fontMouseText, "Life: ", new Vector2(((500 + (13 * num13)) - (vector4.X * 0.5f)) + num12, 6f), new Color(mouseTextColor, mouseTextColor, mouseTextColor, mouseTextColor), 0f, vector10, (float) 1f, SpriteEffects.None, 0f);
                    this.spriteBatch.DrawString(fontMouseText, player[myPlayer].statLife + "/" + player[myPlayer].statLifeMax, new Vector2(((500 + (13 * num13)) + (vector4.X * 0.5f)) + num12, 6f), new Color(mouseTextColor, mouseTextColor, mouseTextColor, mouseTextColor), 0f, new Vector2(fontMouseText.MeasureString(player[myPlayer].statLife + "/" + player[myPlayer].statLifeMax).X, 0f), (float) 1f, SpriteEffects.None, 0f);
                }
                int num14 = 20;
                for (int j = 1; j < ((player[myPlayer].statLifeMax / num14) + 1); j++)
                {
                    int r = 0xff;
                    float scale = 1f;
                    bool flag2 = false;
                    if (player[myPlayer].statLife >= (j * num14))
                    {
                        r = 0xff;
                        if (player[myPlayer].statLife == (j * num14))
                        {
                            flag2 = true;
                        }
                    }
                    else
                    {
                        float num18 = ((float) (player[myPlayer].statLife - ((j - 1) * num14))) / ((float) num14);
                        r = (int) (30f + (225f * num18));
                        if (r < 30)
                        {
                            r = 30;
                        }
                        scale = (num18 / 4f) + 0.75f;
                        if (scale < 0.75)
                        {
                            scale = 0.75f;
                        }
                        if (num18 > 0f)
                        {
                            flag2 = true;
                        }
                    }
                    if (flag2)
                    {
                        scale += cursorScale - 1f;
                    }
                    int num19 = 0;
                    int num20 = 0;
                    if (j > 10)
                    {
                        num19 -= 260;
                        num20 += 0x1a;
                    }
                    int a = (int) (r * 0.9);
                    if (!player[myPlayer].ghost)
                    {
                        this.spriteBatch.Draw(heartTexture, new Vector2((float) ((((500 + (0x1a * (j - 1))) + num19) + num12) + (heartTexture.Width / 2)), ((32f + ((heartTexture.Height - (heartTexture.Height * scale)) / 2f)) + num20) + (heartTexture.Height / 2)), new Rectangle(0, 0, heartTexture.Width, heartTexture.Height), new Color(r, r, r, a), 0f, new Vector2((float) (heartTexture.Width / 2), (float) (heartTexture.Height / 2)), scale, SpriteEffects.None, 0f);
                    }
                }
                int num22 = 20;
                if (player[myPlayer].statManaMax2 > 0)
                {
                    int num1 = player[myPlayer].statManaMax2 / 20;
                    vector10 = new Vector2();
                    this.spriteBatch.DrawString(fontMouseText, "Mana", new Vector2((float) (750 + num12), 6f), new Color(mouseTextColor, mouseTextColor, mouseTextColor, mouseTextColor), 0f, vector10, (float) 1f, SpriteEffects.None, 0f);
                    for (int n = 1; n < ((player[myPlayer].statManaMax2 / num22) + 1); n++)
                    {
                        int num24 = 0xff;
                        bool flag3 = false;
                        float num25 = 1f;
                        if (player[myPlayer].statMana >= (n * num22))
                        {
                            num24 = 0xff;
                            if (player[myPlayer].statMana == (n * num22))
                            {
                                flag3 = true;
                            }
                        }
                        else
                        {
                            float num26 = ((float) (player[myPlayer].statMana - ((n - 1) * num22))) / ((float) num22);
                            num24 = (int) (30f + (225f * num26));
                            if (num24 < 30)
                            {
                                num24 = 30;
                            }
                            num25 = (num26 / 4f) + 0.75f;
                            if (num25 < 0.75)
                            {
                                num25 = 0.75f;
                            }
                            if (num26 > 0f)
                            {
                                flag3 = true;
                            }
                        }
                        if (flag3)
                        {
                            num25 += cursorScale - 1f;
                        }
                        int num27 = (int) (num24 * 0.9);
                        this.spriteBatch.Draw(manaTexture, new Vector2((float) (0x307 + num12), ((30 + (manaTexture.Height / 2)) + ((manaTexture.Height - (manaTexture.Height * num25)) / 2f)) + (0x1c * (n - 1))), new Rectangle(0, 0, manaTexture.Width, manaTexture.Height), new Color(num24, num24, num24, num27), 0f, new Vector2((float) (manaTexture.Width / 2), (float) (manaTexture.Height / 2)), num25, SpriteEffects.None, 0f);
                    }
                }
                if ((player[myPlayer].breath < player[myPlayer].breathMax) && !player[myPlayer].ghost)
                {
                    int num28 = 0x4c;
                    int num203 = player[myPlayer].breathMax / 20;
                    vector10 = new Vector2();
                    this.spriteBatch.DrawString(fontMouseText, "Breath", new Vector2(((500 + (13 * num13)) - (fontMouseText.MeasureString("Breath").X * 0.5f)) + num12, (float) (6 + num28)), new Color(mouseTextColor, mouseTextColor, mouseTextColor, mouseTextColor), 0f, vector10, (float) 1f, SpriteEffects.None, 0f);
                    int num29 = 20;
                    for (int num30 = 1; num30 < ((player[myPlayer].breathMax / num29) + 1); num30++)
                    {
                        int num31 = 0xff;
                        float num32 = 1f;
                        if (player[myPlayer].breath >= (num30 * num29))
                        {
                            num31 = 0xff;
                        }
                        else
                        {
                            float num33 = ((float) (player[myPlayer].breath - ((num30 - 1) * num29))) / ((float) num29);
                            num31 = (int) (30f + (225f * num33));
                            if (num31 < 30)
                            {
                                num31 = 30;
                            }
                            num32 = (num33 / 4f) + 0.75f;
                            if (num32 < 0.75)
                            {
                                num32 = 0.75f;
                            }
                        }
                        int num34 = 0;
                        int num35 = 0;
                        if (num30 > 10)
                        {
                            num34 -= 260;
                            num35 += 0x1a;
                        }
                        vector10 = new Vector2();
                        this.spriteBatch.Draw(bubbleTexture, new Vector2((float) (((500 + (0x1a * (num30 - 1))) + num34) + num12), ((32f + ((bubbleTexture.Height - (bubbleTexture.Height * num32)) / 2f)) + num35) + num28), new Rectangle(0, 0, bubbleTexture.Width, bubbleTexture.Height), new Color(num31, num31, num31, num31), 0f, vector10, num32, SpriteEffects.None, 0f);
                    }
                }
                buffString = "";
                if (!playerInventory)
                {
                    int index = -1;
                    for (int num37 = 0; num37 < 10; num37++)
                    {
                        if (player[myPlayer].buffType[num37] > 0)
                        {
                            int num38 = player[myPlayer].buffType[num37];
                            int num39 = 0x20 + (num37 * 0x26);
                            int num40 = 0x4c;
                            Color color3 = new Color(buffAlpha[num37], buffAlpha[num37], buffAlpha[num37], buffAlpha[num37]);
                            vector10 = new Vector2();
                            this.spriteBatch.Draw(buffTexture[num38], new Vector2((float) num39, (float) num40), new Rectangle(0, 0, buffTexture[num38].Width, buffTexture[num38].Height), color3, 0f, vector10, (float) 1f, SpriteEffects.None, 0f);
                            string str4 = "0 s";
                            if ((player[myPlayer].buffTime[num37] / 60) >= 60)
                            {
                                str4 = Math.Round((double) (((double) (player[myPlayer].buffTime[num37] / 60)) / 60.0)) + " m";
                            }
                            else
                            {
                                str4 = Math.Round((double) (((double) player[myPlayer].buffTime[num37]) / 60.0)) + " s";
                            }
                            vector10 = new Vector2();
                            this.spriteBatch.DrawString(fontItemStack, str4, new Vector2((float) num39, (float) (num40 + buffTexture[num38].Height)), color3, 0f, vector10, (float) 0.8f, SpriteEffects.None, 0f);
                            if (((mouseState.X < (num39 + buffTexture[num38].Width)) && (mouseState.Y < (num40 + buffTexture[num38].Height))) && ((mouseState.X > num39) && (mouseState.Y > num40)))
                            {
                                index = num37;
                                buffAlpha[num37] += 0.1f;
                                if (((mouseState.RightButton == ButtonState.Pressed) && mouseRightRelease) && !debuff[num38])
                                {
                                    PlaySound(12, -1, -1, 1);
                                    player[myPlayer].DelBuff(num37);
                                }
                            }
                            else
                            {
                                buffAlpha[num37] -= 0.05f;
                            }
                            if (buffAlpha[num37] > 1f)
                            {
                                buffAlpha[num37] = 1f;
                            }
                            else if (buffAlpha[num37] < 0.4)
                            {
                                buffAlpha[num37] = 0.4f;
                            }
                        }
                        else
                        {
                            buffAlpha[num37] = 0.4f;
                        }
                    }
                    if (index >= 0)
                    {
                        int num41 = player[myPlayer].buffType[index];
                        if (num41 > 0)
                        {
                            buffString = buffTip[num41];
                            this.MouseText(buffName[num41], 0, 0);
                        }
                    }
                }
                if (player[myPlayer].dead)
                {
                    playerInventory = false;
                }
                if (!playerInventory)
                {
                    player[myPlayer].chest = -1;
                    craftGuide = false;
                }
                string cursorText = "";
                if (!playerInventory)
                {
                    bool flag5 = false;
                    bool flag6 = false;
                    for (int num156 = 0; num156 < 3; num156++)
                    {
                        string str11 = "";
                        if ((player[myPlayer].accDepthMeter > 0) && !flag6)
                        {
                            int num157 = (int) ((((player[myPlayer].position.Y + player[myPlayer].height) * 2f) / 16f) - (worldSurface * 2.0));
                            if (num157 > 0)
                            {
                                str11 = "Depth: " + num157 + " feet below";
                                if (num157 == 1)
                                {
                                    str11 = "Depth: " + num157 + " foot below";
                                }
                            }
                            else if (num157 < 0)
                            {
                                num157 *= -1;
                                str11 = "Depth: " + num157 + " feet above";
                                if (num157 == 1)
                                {
                                    str11 = "Depth: " + num157 + " foot above";
                                }
                            }
                            else
                            {
                                str11 = "Depth: Level";
                            }
                            flag6 = true;
                        }
                        else if ((player[myPlayer].accWatch > 0) && !flag5)
                        {
                            string str12 = "AM";
                            double time = Main.time;
                            if (!dayTime)
                            {
                                time += 54000.0;
                            }
                            time = (time / 86400.0) * 24.0;
                            double num159 = 7.5;
                            time = (time - num159) - 12.0;
                            if (time < 0.0)
                            {
                                time += 24.0;
                            }
                            if (time >= 12.0)
                            {
                                str12 = "PM";
                            }
                            int num160 = (int) time;
                            double num161 = time - num160;
                            num161 = (int) (num161 * 60.0);
                            string str13 = num161.ToString();
                            if (num161 < 10.0)
                            {
                                str13 = "0" + str13;
                            }
                            if (num160 > 12)
                            {
                                num160 -= 12;
                            }
                            if (num160 == 0)
                            {
                                num160 = 12;
                            }
                            if (player[myPlayer].accWatch == 1)
                            {
                                str13 = "00";
                            }
                            else if (player[myPlayer].accWatch == 2)
                            {
                                if (num161 < 30.0)
                                {
                                    str13 = "00";
                                }
                                else
                                {
                                    str13 = "30";
                                }
                            }
                            str11 = string.Concat(new object[] { "Time: ", num160, ":", str13, " ", str12 });
                            flag5 = true;
                        }
                        if (str11 != "")
                        {
                            for (int num162 = 0; num162 < 5; num162++)
                            {
                                int num163 = 0;
                                int num164 = 0;
                                Color black = Color.Black;
                                switch (num162)
                                {
                                    case 0:
                                        num163 = -2;
                                        break;

                                    case 1:
                                        num163 = 2;
                                        break;

                                    case 2:
                                        num164 = -2;
                                        break;

                                    case 3:
                                        num164 = 2;
                                        break;

                                    case 4:
                                        black = new Color((int) mouseTextColor, (int) mouseTextColor, (int) mouseTextColor, (int) mouseTextColor);
                                        break;
                                }
                                vector10 = new Vector2();
                                this.spriteBatch.DrawString(fontMouseText, str11, new Vector2((float) (0x16 + num163), (float) (((0x4a + (0x16 * num156)) + num164) + 0x30)), black, 0f, vector10, (float) 1f, SpriteEffects.None, 0f);
                            }
                        }
                    }
                }
                else
                {
                    if (netMode == 1)
                    {
                        int num42 = (0x2a3 + screenWidth) - 800;
                        int y = 0x72;
                        if (player[myPlayer].hostile)
                        {
                            vector10 = new Vector2();
                            this.spriteBatch.Draw(itemTexture[4], new Vector2((float) (num42 - 2), (float) y), new Rectangle(0, 0, itemTexture[4].Width, itemTexture[4].Height), teamColor[player[myPlayer].team], 0f, vector10, (float) 1f, SpriteEffects.None, 0f);
                            vector10 = new Vector2();
                            this.spriteBatch.Draw(itemTexture[4], new Vector2((float) (num42 + 2), (float) y), new Rectangle(0, 0, itemTexture[4].Width, itemTexture[4].Height), teamColor[player[myPlayer].team], 0f, vector10, (float) 1f, SpriteEffects.FlipHorizontally, 0f);
                        }
                        else
                        {
                            vector10 = new Vector2();
                            this.spriteBatch.Draw(itemTexture[4], new Vector2((float) (num42 - 0x10), (float) (y + 14)), new Rectangle(0, 0, itemTexture[4].Width, itemTexture[4].Height), teamColor[player[myPlayer].team], -0.785f, vector10, (float) 1f, SpriteEffects.None, 0f);
                            vector10 = new Vector2();
                            this.spriteBatch.Draw(itemTexture[4], new Vector2((float) (num42 + 2), (float) (y + 14)), new Rectangle(0, 0, itemTexture[4].Width, itemTexture[4].Height), teamColor[player[myPlayer].team], -0.785f, vector10, (float) 1f, SpriteEffects.None, 0f);
                        }
                        if (((mouseState.X > num42) && (mouseState.X < (num42 + 0x22))) && ((mouseState.Y > (y - 2)) && (mouseState.Y < (y + 0x22))))
                        {
                            player[myPlayer].mouseInterface = true;
                            if ((mouseState.LeftButton == ButtonState.Pressed) && mouseLeftRelease)
                            {
                                if (teamCooldown == 0)
                                {
                                    teamCooldown = teamCooldownLen;
                                    PlaySound(12, -1, -1, 1);
                                    if (player[myPlayer].hostile)
                                    {
                                        player[myPlayer].hostile = false;
                                    }
                                    else
                                    {
                                        player[myPlayer].hostile = true;
                                    }
                                    NetMessage.SendData(30, -1, -1, "", myPlayer, 0f, 0f, 0f, 0);
                                }
                                else
                                {
                                    NewText("You must wait " + ((teamCooldown / 60) + 1) + " seconds.", 0xff, 0, 0);
                                }
                            }
                        }
                        num42 -= 3;
                        Rectangle rectangle = new Rectangle(mouseState.X, mouseState.Y, 1, 1);
                        int width = teamTexture.Width;
                        int height = teamTexture.Height;
                        for (int num46 = 0; num46 < 5; num46++)
                        {
                            Rectangle rectangle2 = new Rectangle();
                            switch (num46)
                            {
                                case 0:
                                    rectangle2 = new Rectangle(num42 + 50, y - 20, width, height);
                                    break;

                                case 1:
                                    rectangle2 = new Rectangle(num42 + 40, y, width, height);
                                    break;

                                case 2:
                                    rectangle2 = new Rectangle(num42 + 60, y, width, height);
                                    break;

                                case 3:
                                    rectangle2 = new Rectangle(num42 + 40, y + 20, width, height);
                                    break;

                                case 4:
                                    rectangle2 = new Rectangle(num42 + 60, y + 20, width, height);
                                    break;
                            }
                            if (rectangle2.Intersects(rectangle))
                            {
                                player[myPlayer].mouseInterface = true;
                                if (((mouseState.LeftButton == ButtonState.Pressed) && mouseLeftRelease) && (player[myPlayer].team != num46))
                                {
                                    if (teamCooldown == 0)
                                    {
                                        teamCooldown = teamCooldownLen;
                                        PlaySound(12, -1, -1, 1);
                                        player[myPlayer].team = num46;
                                        NetMessage.SendData(0x2d, -1, -1, "", myPlayer, 0f, 0f, 0f, 0);
                                    }
                                    else
                                    {
                                        NewText("You must wait " + ((teamCooldown / 60) + 1) + " seconds.", 0xff, 0, 0);
                                    }
                                }
                            }
                        }
                        vector10 = new Vector2();
                        this.spriteBatch.Draw(teamTexture, new Vector2((float) (num42 + 50), (float) (y - 20)), new Rectangle(0, 0, teamTexture.Width, teamTexture.Height), teamColor[0], 0f, vector10, (float) 1f, SpriteEffects.None, 0f);
                        vector10 = new Vector2();
                        this.spriteBatch.Draw(teamTexture, new Vector2((float) (num42 + 40), (float) y), new Rectangle(0, 0, teamTexture.Width, teamTexture.Height), teamColor[1], 0f, vector10, (float) 1f, SpriteEffects.None, 0f);
                        vector10 = new Vector2();
                        this.spriteBatch.Draw(teamTexture, new Vector2((float) (num42 + 60), (float) y), new Rectangle(0, 0, teamTexture.Width, teamTexture.Height), teamColor[2], 0f, vector10, (float) 1f, SpriteEffects.None, 0f);
                        vector10 = new Vector2();
                        this.spriteBatch.Draw(teamTexture, new Vector2((float) (num42 + 40), (float) (y + 20)), new Rectangle(0, 0, teamTexture.Width, teamTexture.Height), teamColor[3], 0f, vector10, (float) 1f, SpriteEffects.None, 0f);
                        vector10 = new Vector2();
                        this.spriteBatch.Draw(teamTexture, new Vector2((float) (num42 + 60), (float) (y + 20)), new Rectangle(0, 0, teamTexture.Width, teamTexture.Height), teamColor[4], 0f, vector10, (float) 1f, SpriteEffects.None, 0f);
                    }
                    bool flag4 = false;
                    if (keyState.IsKeyDown(Keys.LeftShift))
                    {
                        flag4 = true;
                    }
                    Main.inventoryScale = 0.85f;
                    int num47 = 0x1c0;
                    int num48 = 210;
                    Color white = new Color(150, 150, 150, 150);
                    if (((mouseState.X >= num47) && (mouseState.X <= (num47 + (inventoryBackTexture.Width * Main.inventoryScale)))) && ((mouseState.Y >= num48) && (mouseState.Y <= (num48 + (inventoryBackTexture.Height * Main.inventoryScale)))))
                    {
                        player[myPlayer].mouseInterface = true;
                        if (mouseLeftRelease && (mouseState.LeftButton == ButtonState.Pressed))
                        {
                            if (Main.mouseItem.type != 0)
                            {
                                trashItem.SetDefaults(0, false);
                            }
                            Item mouseItem = Main.mouseItem;
                            Main.mouseItem = trashItem;
                            trashItem = mouseItem;
                            if ((trashItem.type == 0) || (trashItem.stack < 1))
                            {
                                trashItem = new Item();
                            }
                            if ((Main.mouseItem.IsTheSameAs(trashItem) && (trashItem.stack != trashItem.maxStack)) && (Main.mouseItem.stack != Main.mouseItem.maxStack))
                            {
                                if ((Main.mouseItem.stack + trashItem.stack) <= Main.mouseItem.maxStack)
                                {
                                    trashItem.stack += Main.mouseItem.stack;
                                    Main.mouseItem.stack = 0;
                                }
                                else
                                {
                                    int num49 = Main.mouseItem.maxStack - trashItem.stack;
                                    trashItem.stack += num49;
                                    Main.mouseItem.stack -= num49;
                                }
                            }
                            if ((Main.mouseItem.type == 0) || (Main.mouseItem.stack < 1))
                            {
                                Main.mouseItem = new Item();
                            }
                            if ((Main.mouseItem.type > 0) || (trashItem.type > 0))
                            {
                                PlaySound(7, -1, -1, 1);
                            }
                        }
                        if (!flag4)
                        {
                            cursorText = trashItem.name;
                            if (trashItem.stack > 1)
                            {
                                obj2 = cursorText;
                                cursorText = string.Concat(new object[] { obj2, " (", trashItem.stack, ")" });
                            }
                            toolTip = (Item) trashItem.Clone();
                            if (cursorText == null)
                            {
                                cursorText = "Trash Can";
                            }
                        }
                        else
                        {
                            cursorText = "Trash Can";
                        }
                    }
                    vector10 = new Vector2();
                    this.spriteBatch.Draw(inventoryBack7Texture, new Vector2((float) num47, (float) num48), new Rectangle(0, 0, inventoryBackTexture.Width, inventoryBackTexture.Height), color2, 0f, vector10, Main.inventoryScale, SpriteEffects.None, 0f);
                    white = Color.White;
                    if (((trashItem.type == 0) || (trashItem.stack == 0)) || flag4)
                    {
                        white = new Color(100, 100, 100, 100);
                        float inventoryScale = Main.inventoryScale;
                        vector10 = new Vector2();
                        this.spriteBatch.Draw(trashTexture, new Vector2((num47 + (26f * Main.inventoryScale)) - ((trashTexture.Width * 0.5f) * inventoryScale), (num48 + (26f * Main.inventoryScale)) - ((trashTexture.Height * 0.5f) * inventoryScale)), new Rectangle(0, 0, trashTexture.Width, trashTexture.Height), white, 0f, vector10, inventoryScale, SpriteEffects.None, 0f);
                    }
                    else
                    {
                        float num51 = 1f;
                        if ((itemTexture[trashItem.type].Width > 0x20) || (itemTexture[trashItem.type].Height > 0x20))
                        {
                            if (itemTexture[trashItem.type].Width > itemTexture[trashItem.type].Height)
                            {
                                num51 = 32f / ((float) itemTexture[trashItem.type].Width);
                            }
                            else
                            {
                                num51 = 32f / ((float) itemTexture[trashItem.type].Height);
                            }
                        }
                        num51 *= Main.inventoryScale;
                        vector10 = new Vector2();
                        this.spriteBatch.Draw(itemTexture[trashItem.type], new Vector2((num47 + (26f * Main.inventoryScale)) - ((itemTexture[trashItem.type].Width * 0.5f) * num51), (num48 + (26f * Main.inventoryScale)) - ((itemTexture[trashItem.type].Height * 0.5f) * num51)), new Rectangle(0, 0, itemTexture[trashItem.type].Width, itemTexture[trashItem.type].Height), trashItem.GetAlpha(white), 0f, vector10, num51, SpriteEffects.None, 0f);
                        color30 = new Color();
                        if (trashItem.color != color30)
                        {
                            vector10 = new Vector2();
                            this.spriteBatch.Draw(itemTexture[trashItem.type], new Vector2((num47 + (26f * Main.inventoryScale)) - ((itemTexture[trashItem.type].Width * 0.5f) * num51), (num48 + (26f * Main.inventoryScale)) - ((itemTexture[trashItem.type].Height * 0.5f) * num51)), new Rectangle(0, 0, itemTexture[trashItem.type].Width, itemTexture[trashItem.type].Height), trashItem.GetColor(white), 0f, vector10, num51, SpriteEffects.None, 0f);
                        }
                        if (trashItem.stack > 1)
                        {
                            vector10 = new Vector2();
                            this.spriteBatch.DrawString(fontItemStack, (trashItem.stack).ToString(), new Vector2(num47 + (10f * Main.inventoryScale), num48 + (26f * Main.inventoryScale)), white, 0f, vector10, num51, SpriteEffects.None, 0f);
                        }
                    }
                    vector10 = new Vector2();
                    this.spriteBatch.DrawString(fontMouseText, "Inventory", new Vector2(40f, 0f), new Color(mouseTextColor, mouseTextColor, mouseTextColor, mouseTextColor), 0f, vector10, (float) 1f, SpriteEffects.None, 0f);
                    Main.inventoryScale = 0.85f;
                    if (((mouseState.X > 20) && (mouseState.X < ((int) (20f + (560f * Main.inventoryScale))))) && ((mouseState.Y > 20) && (mouseState.Y < ((int) (20f + (224f * Main.inventoryScale))))))
                    {
                        player[myPlayer].mouseInterface = true;
                    }
                    for (int num52 = 0; num52 < 10; num52++)
                    {
                        for (int num53 = 0; num53 < 4; num53++)
                        {
                            int num54 = (int) (20f + ((num52 * 0x38) * Main.inventoryScale));
                            int num55 = (int) (20f + ((num53 * 0x38) * Main.inventoryScale));
                            int num56 = num52 + (num53 * 10);
                            Color newColor = new Color(100, 100, 100, 100);
                            if (((mouseState.X >= num54) && (mouseState.X <= (num54 + (inventoryBackTexture.Width * Main.inventoryScale)))) && ((mouseState.Y >= num55) && (mouseState.Y <= (num55 + (inventoryBackTexture.Height * Main.inventoryScale)))))
                            {
                                player[myPlayer].mouseInterface = true;
                                if (mouseLeftRelease && (mouseState.LeftButton == ButtonState.Pressed))
                                {
                                    if (keyState.IsKeyDown(Keys.LeftShift))
                                    {
                                        if (player[myPlayer].inventory[num56].type > 0)
                                        {
                                            if (npcShop > 0)
                                            {
                                                if (player[myPlayer].SellItem(player[myPlayer].inventory[num56].value * player[myPlayer].inventory[num56].stack))
                                                {
                                                    this.shop[npcShop].AddShop(player[myPlayer].inventory[num56]);
                                                    player[myPlayer].inventory[num56].SetDefaults(0, false);
                                                    PlaySound(0x12, -1, -1, 1);
                                                }
                                                else if (Main.mouseItem.value == 0)
                                                {
                                                    this.shop[npcShop].AddShop(player[myPlayer].inventory[num56]);
                                                    player[myPlayer].inventory[num56].SetDefaults(0, false);
                                                    PlaySound(7, -1, -1, 1);
                                                }
                                            }
                                            else
                                            {
                                                Recipe.FindRecipes();
                                                PlaySound(7, -1, -1, 1);
                                                trashItem = (Item) player[myPlayer].inventory[num56].Clone();
                                                player[myPlayer].inventory[num56].SetDefaults(0, false);
                                            }
                                        }
                                    }
                                    else if ((player[myPlayer].selectedItem != num56) || (player[myPlayer].itemAnimation <= 0))
                                    {
                                        Item item2 = Main.mouseItem;
                                        Main.mouseItem = player[myPlayer].inventory[num56];
                                        player[myPlayer].inventory[num56] = item2;
                                        if ((player[myPlayer].inventory[num56].type == 0) || (player[myPlayer].inventory[num56].stack < 1))
                                        {
                                            player[myPlayer].inventory[num56] = new Item();
                                        }
                                        if ((Main.mouseItem.IsTheSameAs(player[myPlayer].inventory[num56]) && (player[myPlayer].inventory[num56].stack != player[myPlayer].inventory[num56].maxStack)) && (Main.mouseItem.stack != Main.mouseItem.maxStack))
                                        {
                                            if ((Main.mouseItem.stack + player[myPlayer].inventory[num56].stack) <= Main.mouseItem.maxStack)
                                            {
                                                Item item1 = player[myPlayer].inventory[num56];
                                                item1.stack += Main.mouseItem.stack;
                                                Main.mouseItem.stack = 0;
                                            }
                                            else
                                            {
                                                int num57 = Main.mouseItem.maxStack - player[myPlayer].inventory[num56].stack;
                                                Item item11 = player[myPlayer].inventory[num56];
                                                item11.stack += num57;
                                                Main.mouseItem.stack -= num57;
                                            }
                                        }
                                        if ((Main.mouseItem.type == 0) || (Main.mouseItem.stack < 1))
                                        {
                                            Main.mouseItem = new Item();
                                        }
                                        if ((Main.mouseItem.type > 0) || (player[myPlayer].inventory[num56].type > 0))
                                        {
                                            Recipe.FindRecipes();
                                            PlaySound(7, -1, -1, 1);
                                        }
                                    }
                                }
                                else if (((mouseState.RightButton == ButtonState.Pressed) && mouseRightRelease) && (player[myPlayer].inventory[num56].maxStack == 1))
                                {
                                    player[myPlayer].inventory[num56] = armorSwap(player[myPlayer].inventory[num56]);
                                }
                                else if (((((stackSplit <= 1) && (mouseState.RightButton == ButtonState.Pressed)) && ((player[myPlayer].inventory[num56].maxStack > 1) && (player[myPlayer].inventory[num56].type > 0))) && (Main.mouseItem.IsTheSameAs(player[myPlayer].inventory[num56]) || (Main.mouseItem.type == 0))) && ((Main.mouseItem.stack < Main.mouseItem.maxStack) || (Main.mouseItem.type == 0)))
                                {
                                    if (Main.mouseItem.type == 0)
                                    {
                                        Main.mouseItem = (Item) player[myPlayer].inventory[num56].Clone();
                                        Main.mouseItem.stack = 0;
                                    }
                                    Main.mouseItem.stack++;
                                    Item item12 = player[myPlayer].inventory[num56];
                                    item12.stack--;
                                    if (player[myPlayer].inventory[num56].stack <= 0)
                                    {
                                        player[myPlayer].inventory[num56] = new Item();
                                    }
                                    Recipe.FindRecipes();
                                    soundInstanceMenuTick.Stop();
                                    soundInstanceMenuTick = soundMenuTick.CreateInstance();
                                    PlaySound(12, -1, -1, 1);
                                    if (stackSplit == 0)
                                    {
                                        stackSplit = 15;
                                    }
                                    else
                                    {
                                        stackSplit = stackDelay;
                                    }
                                }
                                cursorText = player[myPlayer].inventory[num56].name;
                                toolTip = (Item) player[myPlayer].inventory[num56].Clone();
                                if (player[myPlayer].inventory[num56].stack > 1)
                                {
                                    obj2 = cursorText;
                                    cursorText = string.Concat(new object[] { obj2, " (", player[myPlayer].inventory[num56].stack, ")" });
                                }
                            }
                            if (num53 != 0)
                            {
                                vector10 = new Vector2();
                                this.spriteBatch.Draw(inventoryBackTexture, new Vector2((float) num54, (float) num55), new Rectangle(0, 0, inventoryBackTexture.Width, inventoryBackTexture.Height), color2, 0f, vector10, Main.inventoryScale, SpriteEffects.None, 0f);
                            }
                            else
                            {
                                vector10 = new Vector2();
                                this.spriteBatch.Draw(inventoryBack9Texture, new Vector2((float) num54, (float) num55), new Rectangle(0, 0, inventoryBackTexture.Width, inventoryBackTexture.Height), color2, 0f, vector10, Main.inventoryScale, SpriteEffects.None, 0f);
                            }
                            newColor = Color.White;
                            if ((player[myPlayer].inventory[num56].type > 0) && (player[myPlayer].inventory[num56].stack > 0))
                            {
                                float num58 = 1f;
                                if ((itemTexture[player[myPlayer].inventory[num56].type].Width > 0x20) || (itemTexture[player[myPlayer].inventory[num56].type].Height > 0x20))
                                {
                                    if (itemTexture[player[myPlayer].inventory[num56].type].Width > itemTexture[player[myPlayer].inventory[num56].type].Height)
                                    {
                                        num58 = 32f / ((float) itemTexture[player[myPlayer].inventory[num56].type].Width);
                                    }
                                    else
                                    {
                                        num58 = 32f / ((float) itemTexture[player[myPlayer].inventory[num56].type].Height);
                                    }
                                }
                                num58 *= Main.inventoryScale;
                                vector10 = new Vector2();
                                this.spriteBatch.Draw(itemTexture[player[myPlayer].inventory[num56].type], new Vector2((num54 + (26f * Main.inventoryScale)) - ((itemTexture[player[myPlayer].inventory[num56].type].Width * 0.5f) * num58), (num55 + (26f * Main.inventoryScale)) - ((itemTexture[player[myPlayer].inventory[num56].type].Height * 0.5f) * num58)), new Rectangle(0, 0, itemTexture[player[myPlayer].inventory[num56].type].Width, itemTexture[player[myPlayer].inventory[num56].type].Height), player[myPlayer].inventory[num56].GetAlpha(newColor), 0f, vector10, num58, SpriteEffects.None, 0f);
                                color30 = new Color();
                                if (player[myPlayer].inventory[num56].color != color30)
                                {
                                    vector10 = new Vector2();
                                    this.spriteBatch.Draw(itemTexture[player[myPlayer].inventory[num56].type], new Vector2((num54 + (26f * Main.inventoryScale)) - ((itemTexture[player[myPlayer].inventory[num56].type].Width * 0.5f) * num58), (num55 + (26f * Main.inventoryScale)) - ((itemTexture[player[myPlayer].inventory[num56].type].Height * 0.5f) * num58)), new Rectangle(0, 0, itemTexture[player[myPlayer].inventory[num56].type].Width, itemTexture[player[myPlayer].inventory[num56].type].Height), player[myPlayer].inventory[num56].GetColor(newColor), 0f, vector10, num58, SpriteEffects.None, 0f);
                                }
                                if (player[myPlayer].inventory[num56].stack > 1)
                                {
                                    vector10 = new Vector2();
                                    this.spriteBatch.DrawString(fontItemStack, (player[myPlayer].inventory[num56].stack).ToString(), new Vector2(num54 + (10f * Main.inventoryScale), num55 + (26f * Main.inventoryScale)), newColor, 0f, vector10, num58, SpriteEffects.None, 0f);
                                }
                            }
                            if (num53 == 0)
                            {
                                string str6 = (num56.ToString() + 1);
                                if (str6 == "10")
                                {
                                    str6 = "0";
                                }
                                vector10 = new Vector2();
                                this.spriteBatch.DrawString(fontItemStack, str6, new Vector2((float) (num54 + 6), (float) (num55 + 4)), color2, 0f, vector10, (float) (Main.inventoryScale * 0.8f), SpriteEffects.None, 0f);
                            }
                        }
                    }
                    int num59 = 0;
                    int num60 = 2;
                    int num61 = 0x20;
                    if (!player[myPlayer].hbLocked)
                    {
                        num59 = 1;
                    }
                    vector10 = new Vector2();
                    this.spriteBatch.Draw(HBLockTexture[num59], new Vector2((float) num60, (float) num61), new Rectangle(0, 0, HBLockTexture[num59].Width, HBLockTexture[num59].Height), color2, 0f, vector10, (float) 0.9f, SpriteEffects.None, 0f);
                    if (((mouseState.X > num60) && (mouseState.X < (num60 + (HBLockTexture[num59].Width * 0.9f)))) && ((mouseState.Y > num61) && (mouseState.Y < (num61 + (HBLockTexture[num59].Height * 0.9f)))))
                    {
                        player[myPlayer].mouseInterface = true;
                        if (!player[myPlayer].hbLocked)
                        {
                            this.MouseText("Hotbar unlocked", 0, 0);
                            flag = true;
                        }
                        else
                        {
                            this.MouseText("Hotbar locked", 0, 0);
                            flag = true;
                        }
                        if ((mouseState.LeftButton == ButtonState.Pressed) && mouseLeftRelease)
                        {
                            PlaySound(0x16, -1, -1, 1);
                            if (!player[myPlayer].hbLocked)
                            {
                                player[myPlayer].hbLocked = true;
                            }
                            else
                            {
                                player[myPlayer].hbLocked = false;
                            }
                        }
                    }
                    if (armorHide)
                    {
                        armorAlpha -= 0.1f;
                        if (armorAlpha < 0f)
                        {
                            armorAlpha = 0f;
                        }
                    }
                    else
                    {
                        armorAlpha += 0.025f;
                        if (armorAlpha > 1f)
                        {
                            armorAlpha = 1f;
                        }
                    }
                    Color color6 = new Color((int) ((byte) (mouseTextColor * armorAlpha)), (int) ((byte) (mouseTextColor * armorAlpha)), (int) ((byte) (mouseTextColor * armorAlpha)), (int) ((byte) (mouseTextColor * armorAlpha)));
                    armorHide = false;
                    vector10 = new Vector2();
                    this.spriteBatch.DrawString(fontMouseText, "Equip", new Vector2((float) (((screenWidth - 0x40) - 0x1c) + 4), 152f), new Color(mouseTextColor, mouseTextColor, mouseTextColor, mouseTextColor), 0f, vector10, (float) 0.8f, SpriteEffects.None, 0f);
                    if (((mouseState.X > ((screenWidth - 0x40) - 0x1c)) && (mouseState.X < (((screenWidth - 0x40) - 0x1c) + ((int) (56f * Main.inventoryScale))))) && ((mouseState.Y > 0xae) && (mouseState.Y < ((int) (174f + (448f * Main.inventoryScale))))))
                    {
                        player[myPlayer].mouseInterface = true;
                    }
                    for (int num62 = 0; num62 < 8; num62++)
                    {
                        int num63 = (screenWidth - 0x40) - 0x1c;
                        int num64 = (int) (174f + ((num62 * 0x38) * Main.inventoryScale));
                        Color color7 = new Color(100, 100, 100, 100);
                        string str7 = "";
                        switch (num62)
                        {
                            case 3:
                                str7 = "Accessories";
                                break;

                            case 7:
                                str7 = player[myPlayer].statDefense + " Defense";
                                break;
                        }
                        Vector2 vector5 = fontMouseText.MeasureString(str7);
                        vector10 = new Vector2();
                        this.spriteBatch.DrawString(fontMouseText, str7, new Vector2((num63 - vector5.X) - 10f, (num64 + (inventoryBackTexture.Height * 0.5f)) - (vector5.Y * 0.5f)), color6, 0f, vector10, (float) 1f, SpriteEffects.None, 0f);
                        if (((mouseState.X >= num63) && (mouseState.X <= (num63 + (inventoryBackTexture.Width * Main.inventoryScale)))) && ((mouseState.Y >= num64) && (mouseState.Y <= (num64 + (inventoryBackTexture.Height * Main.inventoryScale)))))
                        {
                            armorHide = true;
                            player[myPlayer].mouseInterface = true;
                            if ((mouseLeftRelease && (mouseState.LeftButton == ButtonState.Pressed)) && ((((Main.mouseItem.type == 0) || ((Main.mouseItem.headSlot > -1) && (num62 == 0))) || ((Main.mouseItem.bodySlot > -1) && (num62 == 1))) || (((Main.mouseItem.legSlot > -1) && (num62 == 2)) || ((Main.mouseItem.accessory && (num62 > 2)) && !AccCheck(Main.mouseItem)))))
                            {
                                Item item3 = Main.mouseItem;
                                Main.mouseItem = player[myPlayer].armor[num62];
                                player[myPlayer].armor[num62] = item3;
                                if ((player[myPlayer].armor[num62].type == 0) || (player[myPlayer].armor[num62].stack < 1))
                                {
                                    player[myPlayer].armor[num62] = new Item();
                                }
                                if ((Main.mouseItem.type == 0) || (Main.mouseItem.stack < 1))
                                {
                                    Main.mouseItem = new Item();
                                }
                                if ((Main.mouseItem.type > 0) || (player[myPlayer].armor[num62].type > 0))
                                {
                                    Recipe.FindRecipes();
                                    PlaySound(7, -1, -1, 1);
                                }
                            }
                            cursorText = player[myPlayer].armor[num62].name;
                            toolTip = (Item) player[myPlayer].armor[num62].Clone();
                            if (num62 <= 2)
                            {
                                toolTip.wornArmor = true;
                            }
                            if (player[myPlayer].armor[num62].stack > 1)
                            {
                                obj2 = cursorText;
                                cursorText = string.Concat(new object[] { obj2, " (", player[myPlayer].armor[num62].stack, ")" });
                            }
                        }
                        vector10 = new Vector2();
                        this.spriteBatch.Draw(inventoryBack3Texture, new Vector2((float) num63, (float) num64), new Rectangle(0, 0, inventoryBackTexture.Width, inventoryBackTexture.Height), color2, 0f, vector10, Main.inventoryScale, SpriteEffects.None, 0f);
                        color7 = Color.White;
                        if ((player[myPlayer].armor[num62].type > 0) && (player[myPlayer].armor[num62].stack > 0))
                        {
                            float num65 = 1f;
                            if ((itemTexture[player[myPlayer].armor[num62].type].Width > 0x20) || (itemTexture[player[myPlayer].armor[num62].type].Height > 0x20))
                            {
                                if (itemTexture[player[myPlayer].armor[num62].type].Width > itemTexture[player[myPlayer].armor[num62].type].Height)
                                {
                                    num65 = 32f / ((float) itemTexture[player[myPlayer].armor[num62].type].Width);
                                }
                                else
                                {
                                    num65 = 32f / ((float) itemTexture[player[myPlayer].armor[num62].type].Height);
                                }
                            }
                            num65 *= Main.inventoryScale;
                            vector10 = new Vector2();
                            this.spriteBatch.Draw(itemTexture[player[myPlayer].armor[num62].type], new Vector2((num63 + (26f * Main.inventoryScale)) - ((itemTexture[player[myPlayer].armor[num62].type].Width * 0.5f) * num65), (num64 + (26f * Main.inventoryScale)) - ((itemTexture[player[myPlayer].armor[num62].type].Height * 0.5f) * num65)), new Rectangle(0, 0, itemTexture[player[myPlayer].armor[num62].type].Width, itemTexture[player[myPlayer].armor[num62].type].Height), player[myPlayer].armor[num62].GetAlpha(color7), 0f, vector10, num65, SpriteEffects.None, 0f);
                            color30 = new Color();
                            if (player[myPlayer].armor[num62].color != color30)
                            {
                                vector10 = new Vector2();
                                this.spriteBatch.Draw(itemTexture[player[myPlayer].armor[num62].type], new Vector2((num63 + (26f * Main.inventoryScale)) - ((itemTexture[player[myPlayer].armor[num62].type].Width * 0.5f) * num65), (num64 + (26f * Main.inventoryScale)) - ((itemTexture[player[myPlayer].armor[num62].type].Height * 0.5f) * num65)), new Rectangle(0, 0, itemTexture[player[myPlayer].armor[num62].type].Width, itemTexture[player[myPlayer].armor[num62].type].Height), player[myPlayer].armor[num62].GetColor(color7), 0f, vector10, num65, SpriteEffects.None, 0f);
                            }
                            if (player[myPlayer].armor[num62].stack > 1)
                            {
                                vector10 = new Vector2();
                                this.spriteBatch.DrawString(fontItemStack, (player[myPlayer].armor[num62].stack).ToString(), new Vector2(num63 + (10f * Main.inventoryScale), num64 + (26f * Main.inventoryScale)), color7, 0f, vector10, num65, SpriteEffects.None, 0f);
                            }
                        }
                    }
                    vector10 = new Vector2();
                    this.spriteBatch.DrawString(fontMouseText, "Social", new Vector2((float) (((screenWidth - 0x40) - 0x1c) - 0x2c), 152f), new Color(mouseTextColor, mouseTextColor, mouseTextColor, mouseTextColor), 0f, vector10, (float) 0.8f, SpriteEffects.None, 0f);
                    if (((mouseState.X > (((screenWidth - 0x40) - 0x1c) - 0x2f)) && (mouseState.X < ((((screenWidth - 0x40) - 20) - 0x2f) + ((int) (56f * Main.inventoryScale))))) && ((mouseState.Y > 0xae) && (mouseState.Y < ((int) (174f + (168f * Main.inventoryScale))))))
                    {
                        player[myPlayer].mouseInterface = true;
                    }
                    for (int num66 = 8; num66 < 11; num66++)
                    {
                        int num67 = ((screenWidth - 0x40) - 0x1c) - 0x2f;
                        int num68 = (int) (174f + (((num66 - 8) * 0x38) * Main.inventoryScale));
                        Color color8 = new Color(100, 100, 100, 100);
                        string str8 = "";
                        switch (num66)
                        {
                            case 8:
                                str8 = "Helmet";
                                break;

                            case 9:
                                str8 = "Shirt";
                                break;

                            case 10:
                                str8 = "Pants";
                                break;
                        }
                        Vector2 vector6 = fontMouseText.MeasureString(str8);
                        vector10 = new Vector2();
                        this.spriteBatch.DrawString(fontMouseText, str8, new Vector2((num67 - vector6.X) - 10f, (num68 + (inventoryBackTexture.Height * 0.5f)) - (vector6.Y * 0.5f)), color6, 0f, vector10, (float) 1f, SpriteEffects.None, 0f);
                        if (((mouseState.X >= num67) && (mouseState.X <= (num67 + (inventoryBackTexture.Width * Main.inventoryScale)))) && ((mouseState.Y >= num68) && (mouseState.Y <= (num68 + (inventoryBackTexture.Height * Main.inventoryScale)))))
                        {
                            player[myPlayer].mouseInterface = true;
                            armorHide = true;
                            if (mouseLeftRelease && (mouseState.LeftButton == ButtonState.Pressed))
                            {
                                if ((((Main.mouseItem.type == 0) || ((Main.mouseItem.headSlot > -1) && (num66 == 8))) || ((Main.mouseItem.bodySlot > -1) && (num66 == 9))) || ((Main.mouseItem.legSlot > -1) && (num66 == 10)))
                                {
                                    Item item4 = Main.mouseItem;
                                    Main.mouseItem = player[myPlayer].armor[num66];
                                    player[myPlayer].armor[num66] = item4;
                                    if ((player[myPlayer].armor[num66].type == 0) || (player[myPlayer].armor[num66].stack < 1))
                                    {
                                        player[myPlayer].armor[num66] = new Item();
                                    }
                                    if ((Main.mouseItem.type == 0) || (Main.mouseItem.stack < 1))
                                    {
                                        Main.mouseItem = new Item();
                                    }
                                    if ((Main.mouseItem.type > 0) || (player[myPlayer].armor[num66].type > 0))
                                    {
                                        Recipe.FindRecipes();
                                        PlaySound(7, -1, -1, 1);
                                    }
                                }
                            }
                            else if (((mouseState.RightButton == ButtonState.Pressed) && mouseRightRelease) && (player[myPlayer].armor[num66].maxStack == 1))
                            {
                                player[myPlayer].armor[num66] = armorSwap(player[myPlayer].armor[num66]);
                            }
                            cursorText = player[myPlayer].armor[num66].name;
                            toolTip = (Item) player[myPlayer].armor[num66].Clone();
                            toolTip.social = true;
                            if (num66 <= 2)
                            {
                                toolTip.wornArmor = true;
                            }
                            if (player[myPlayer].armor[num66].stack > 1)
                            {
                                obj2 = cursorText;
                                cursorText = string.Concat(new object[] { obj2, " (", player[myPlayer].armor[num66].stack, ")" });
                            }
                        }
                        vector10 = new Vector2();
                        this.spriteBatch.Draw(inventoryBack8Texture, new Vector2((float) num67, (float) num68), new Rectangle(0, 0, inventoryBackTexture.Width, inventoryBackTexture.Height), color2, 0f, vector10, Main.inventoryScale, SpriteEffects.None, 0f);
                        color8 = Color.White;
                        if ((player[myPlayer].armor[num66].type > 0) && (player[myPlayer].armor[num66].stack > 0))
                        {
                            float num69 = 1f;
                            if ((itemTexture[player[myPlayer].armor[num66].type].Width > 0x20) || (itemTexture[player[myPlayer].armor[num66].type].Height > 0x20))
                            {
                                if (itemTexture[player[myPlayer].armor[num66].type].Width > itemTexture[player[myPlayer].armor[num66].type].Height)
                                {
                                    num69 = 32f / ((float) itemTexture[player[myPlayer].armor[num66].type].Width);
                                }
                                else
                                {
                                    num69 = 32f / ((float) itemTexture[player[myPlayer].armor[num66].type].Height);
                                }
                            }
                            num69 *= Main.inventoryScale;
                            vector10 = new Vector2();
                            this.spriteBatch.Draw(itemTexture[player[myPlayer].armor[num66].type], new Vector2((num67 + (26f * Main.inventoryScale)) - ((itemTexture[player[myPlayer].armor[num66].type].Width * 0.5f) * num69), (num68 + (26f * Main.inventoryScale)) - ((itemTexture[player[myPlayer].armor[num66].type].Height * 0.5f) * num69)), new Rectangle(0, 0, itemTexture[player[myPlayer].armor[num66].type].Width, itemTexture[player[myPlayer].armor[num66].type].Height), player[myPlayer].armor[num66].GetAlpha(color8), 0f, vector10, num69, SpriteEffects.None, 0f);
                            color30 = new Color();
                            if (player[myPlayer].armor[num66].color != color30)
                            {
                                vector10 = new Vector2();
                                this.spriteBatch.Draw(itemTexture[player[myPlayer].armor[num66].type], new Vector2((num67 + (26f * Main.inventoryScale)) - ((itemTexture[player[myPlayer].armor[num66].type].Width * 0.5f) * num69), (num68 + (26f * Main.inventoryScale)) - ((itemTexture[player[myPlayer].armor[num66].type].Height * 0.5f) * num69)), new Rectangle(0, 0, itemTexture[player[myPlayer].armor[num66].type].Width, itemTexture[player[myPlayer].armor[num66].type].Height), player[myPlayer].armor[num66].GetColor(color8), 0f, vector10, num69, SpriteEffects.None, 0f);
                            }
                            if (player[myPlayer].armor[num66].stack > 1)
                            {
                                vector10 = new Vector2();
                                this.spriteBatch.DrawString(fontItemStack, (player[myPlayer].armor[num66].stack).ToString(), new Vector2(num67 + (10f * Main.inventoryScale), num68 + (26f * Main.inventoryScale)), color8, 0f, vector10, num69, SpriteEffects.None, 0f);
                            }
                        }
                    }
                    if (craftingHide)
                    {
                        craftingAlpha -= 0.1f;
                        if (craftingAlpha < 0f)
                        {
                            craftingAlpha = 0f;
                        }
                    }
                    else
                    {
                        craftingAlpha += 0.025f;
                        if (craftingAlpha > 1f)
                        {
                            craftingAlpha = 1f;
                        }
                    }
                    Color color9 = new Color((int) ((byte) (mouseTextColor * craftingAlpha)), (int) ((byte) (mouseTextColor * craftingAlpha)), (int) ((byte) (mouseTextColor * craftingAlpha)), (int) ((byte) (mouseTextColor * craftingAlpha)));
                    craftingHide = false;
                    if (craftGuide)
                    {
                        if (((player[myPlayer].chest != -1) || (npcShop != 0)) || (player[myPlayer].talkNPC == -1))
                        {
                            craftGuide = false;
                            player[myPlayer].dropItemCheck();
                            Recipe.FindRecipes();
                        }
                        else
                        {
                            string str9;
                            int num70 = 0x49;
                            int num71 = 0x14b;
                            if (guideItem.type <= 0)
                            {
                                str9 = "Place a material here to show recipes";
                            }
                            else
                            {
                                str9 = "Showing recipes that use " + guideItem.name;
                                vector10 = new Vector2();
                                this.spriteBatch.DrawString(fontMouseText, "Required objects:", new Vector2((float) num70, (float) (num71 + 0x76)), color9, 0f, vector10, (float) 1f, SpriteEffects.None, 0f);
                                int focusRecipe = Main.focusRecipe;
                                int num73 = 0;
                                for (int num74 = 0; num74 < Recipe.maxRequirements; num74++)
                                {
                                    int num75 = (num74 + 1) * 0x1a;
                                    if (recipe[availableRecipe[focusRecipe]].requiredTile[num74] == -1)
                                    {
                                        if ((num74 == 0) && !recipe[availableRecipe[focusRecipe]].needWater)
                                        {
                                            vector10 = new Vector2();
                                            this.spriteBatch.DrawString(fontMouseText, "None", new Vector2((float) num70, (float) ((num71 + 0x76) + num75)), color9, 0f, vector10, (float) 1f, SpriteEffects.None, 0f);
                                        }
                                        break;
                                    }
                                    num73++;
                                    vector10 = new Vector2();
                                    this.spriteBatch.DrawString(fontMouseText, tileName[recipe[availableRecipe[focusRecipe]].requiredTile[num74]], new Vector2((float) num70, (float) ((num71 + 0x76) + num75)), color9, 0f, vector10, (float) 1f, SpriteEffects.None, 0f);
                                }
                                if (recipe[availableRecipe[focusRecipe]].needWater)
                                {
                                    int num76 = (num73 + 1) * 0x1a;
                                    vector10 = new Vector2();
                                    this.spriteBatch.DrawString(fontMouseText, "Water", new Vector2((float) num70, (float) ((num71 + 0x76) + num76)), color9, 0f, vector10, (float) 1f, SpriteEffects.None, 0f);
                                }
                            }
                            vector10 = new Vector2();
                            this.spriteBatch.DrawString(fontMouseText, str9, new Vector2((float) (num70 + 50), (float) (num71 + 12)), new Color(mouseTextColor, mouseTextColor, mouseTextColor, mouseTextColor), 0f, vector10, (float) 1f, SpriteEffects.None, 0f);
                            Color color10 = new Color(100, 100, 100, 100);
                            if (((mouseState.X >= num70) && (mouseState.X <= (num70 + (inventoryBackTexture.Width * Main.inventoryScale)))) && ((mouseState.Y >= num71) && (mouseState.Y <= (num71 + (inventoryBackTexture.Height * Main.inventoryScale)))))
                            {
                                player[myPlayer].mouseInterface = true;
                                craftingHide = true;
                                if (Main.mouseItem.material || (Main.mouseItem.type == 0))
                                {
                                    if (mouseLeftRelease && (mouseState.LeftButton == ButtonState.Pressed))
                                    {
                                        Item item5 = Main.mouseItem;
                                        Main.mouseItem = guideItem;
                                        guideItem = item5;
                                        if ((guideItem.type == 0) || (guideItem.stack < 1))
                                        {
                                            guideItem = new Item();
                                        }
                                        if ((Main.mouseItem.IsTheSameAs(guideItem) && (guideItem.stack != guideItem.maxStack)) && (Main.mouseItem.stack != Main.mouseItem.maxStack))
                                        {
                                            if ((Main.mouseItem.stack + guideItem.stack) <= Main.mouseItem.maxStack)
                                            {
                                                guideItem.stack += Main.mouseItem.stack;
                                                Main.mouseItem.stack = 0;
                                            }
                                            else
                                            {
                                                int num77 = Main.mouseItem.maxStack - guideItem.stack;
                                                guideItem.stack += num77;
                                                Main.mouseItem.stack -= num77;
                                            }
                                        }
                                        if ((Main.mouseItem.type == 0) || (Main.mouseItem.stack < 1))
                                        {
                                            Main.mouseItem = new Item();
                                        }
                                        if ((Main.mouseItem.type > 0) || (guideItem.type > 0))
                                        {
                                            Recipe.FindRecipes();
                                            PlaySound(7, -1, -1, 1);
                                        }
                                    }
                                    else if ((((stackSplit <= 1) && (mouseState.RightButton == ButtonState.Pressed)) && (Main.mouseItem.IsTheSameAs(guideItem) || (Main.mouseItem.type == 0))) && ((Main.mouseItem.stack < Main.mouseItem.maxStack) || (Main.mouseItem.type == 0)))
                                    {
                                        if (Main.mouseItem.type == 0)
                                        {
                                            Main.mouseItem = (Item) guideItem.Clone();
                                            Main.mouseItem.stack = 0;
                                        }
                                        Main.mouseItem.stack++;
                                        guideItem.stack--;
                                        if (guideItem.stack <= 0)
                                        {
                                            guideItem = new Item();
                                        }
                                        Recipe.FindRecipes();
                                        soundInstanceMenuTick.Stop();
                                        soundInstanceMenuTick = soundMenuTick.CreateInstance();
                                        PlaySound(12, -1, -1, 1);
                                        if (stackSplit == 0)
                                        {
                                            stackSplit = 15;
                                        }
                                        else
                                        {
                                            stackSplit = stackDelay;
                                        }
                                    }
                                }
                                cursorText = guideItem.name;
                                toolTip = (Item) guideItem.Clone();
                                if (guideItem.stack > 1)
                                {
                                    obj2 = cursorText;
                                    cursorText = string.Concat(new object[] { obj2, " (", guideItem.stack, ")" });
                                }
                            }
                            vector10 = new Vector2();
                            this.spriteBatch.Draw(inventoryBack4Texture, new Vector2((float) num70, (float) num71), new Rectangle(0, 0, inventoryBackTexture.Width, inventoryBackTexture.Height), color2, 0f, vector10, Main.inventoryScale, SpriteEffects.None, 0f);
                            color10 = Color.White;
                            if ((guideItem.type > 0) && (guideItem.stack > 0))
                            {
                                float num78 = 1f;
                                if ((itemTexture[guideItem.type].Width > 0x20) || (itemTexture[guideItem.type].Height > 0x20))
                                {
                                    if (itemTexture[guideItem.type].Width > itemTexture[guideItem.type].Height)
                                    {
                                        num78 = 32f / ((float) itemTexture[guideItem.type].Width);
                                    }
                                    else
                                    {
                                        num78 = 32f / ((float) itemTexture[guideItem.type].Height);
                                    }
                                }
                                num78 *= Main.inventoryScale;
                                vector10 = new Vector2();
                                this.spriteBatch.Draw(itemTexture[guideItem.type], new Vector2((num70 + (26f * Main.inventoryScale)) - ((itemTexture[guideItem.type].Width * 0.5f) * num78), (num71 + (26f * Main.inventoryScale)) - ((itemTexture[guideItem.type].Height * 0.5f) * num78)), new Rectangle(0, 0, itemTexture[guideItem.type].Width, itemTexture[guideItem.type].Height), guideItem.GetAlpha(color10), 0f, vector10, num78, SpriteEffects.None, 0f);
                                color30 = new Color();
                                if (guideItem.color != color30)
                                {
                                    vector10 = new Vector2();
                                    this.spriteBatch.Draw(itemTexture[guideItem.type], new Vector2((num70 + (26f * Main.inventoryScale)) - ((itemTexture[guideItem.type].Width * 0.5f) * num78), (num71 + (26f * Main.inventoryScale)) - ((itemTexture[guideItem.type].Height * 0.5f) * num78)), new Rectangle(0, 0, itemTexture[guideItem.type].Width, itemTexture[guideItem.type].Height), guideItem.GetColor(color10), 0f, vector10, num78, SpriteEffects.None, 0f);
                                }
                                if (guideItem.stack > 1)
                                {
                                    vector10 = new Vector2();
                                    this.spriteBatch.DrawString(fontItemStack, (guideItem.stack).ToString(), new Vector2(num70 + (10f * Main.inventoryScale), num71 + (26f * Main.inventoryScale)), color10, 0f, vector10, num78, SpriteEffects.None, 0f);
                                }
                            }
                        }
                    }
                    if (numAvailableRecipes > 0)
                    {
                        vector10 = new Vector2();
                        this.spriteBatch.DrawString(fontMouseText, "Crafting", new Vector2(76f, 414f), color9, 0f, vector10, (float) 1f, SpriteEffects.None, 0f);
                    }
                    for (int num79 = 0; num79 < Recipe.maxRecipes; num79++)
                    {
                        Main.inventoryScale = 100f / (Math.Abs(availableRecipeY[num79]) + 100f);
                        if (Main.inventoryScale < 0.75)
                        {
                            Main.inventoryScale = 0.75f;
                        }
                        if (availableRecipeY[num79] < ((num79 - Main.focusRecipe) * 0x41))
                        {
                            if (availableRecipeY[num79] == 0f)
                            {
                                PlaySound(12, -1, -1, 1);
                            }
                            availableRecipeY[num79] += 6.5f;
                        }
                        else if (availableRecipeY[num79] > ((num79 - Main.focusRecipe) * 0x41))
                        {
                            if (availableRecipeY[num79] == 0f)
                            {
                                PlaySound(12, -1, -1, 1);
                            }
                            availableRecipeY[num79] -= 6.5f;
                        }
                        if ((num79 < numAvailableRecipes) && (Math.Abs(availableRecipeY[num79]) <= 250f))
                        {
                            int num80 = (int) (46f - (26f * Main.inventoryScale));
                            int num81 = (int) ((410f + (availableRecipeY[num79] * Main.inventoryScale)) - (30f * Main.inventoryScale));
                            double num82 = color2.A + 50;
                            double num83 = 255.0;
                            if (Math.Abs(availableRecipeY[num79]) > 150f)
                            {
                                num82 = (150f * (100f - (Math.Abs(availableRecipeY[num79]) - 150f))) * 0.01;
                                num83 = (255f * (100f - (Math.Abs(availableRecipeY[num79]) - 150f))) * 0.01;
                            }
                            new Color((byte) num82, (byte) num82, (byte) num82, (byte) num82);
                            Color color11 = new Color((int) ((byte) num83), (int) ((byte) num83), (int) ((byte) num83), (int) ((byte) num83));
                            if (((mouseState.X >= num80) && (mouseState.X <= (num80 + (inventoryBackTexture.Width * Main.inventoryScale)))) && ((mouseState.Y >= num81) && (mouseState.Y <= (num81 + (inventoryBackTexture.Height * Main.inventoryScale)))))
                            {
                                player[myPlayer].mouseInterface = true;
                                if ((Main.focusRecipe == num79) && (guideItem.type == 0))
                                {
                                    if ((Main.mouseItem.type == 0) || (Main.mouseItem.IsTheSameAs(recipe[availableRecipe[num79]].createItem) && ((Main.mouseItem.stack + recipe[availableRecipe[num79]].createItem.stack) <= Main.mouseItem.maxStack)))
                                    {
                                        if (mouseLeftRelease && (mouseState.LeftButton == ButtonState.Pressed))
                                        {
                                            int stack = Main.mouseItem.stack;
                                            Main.mouseItem = (Item) recipe[availableRecipe[num79]].createItem.Clone();
                                            Main.mouseItem.stack += stack;
                                            recipe[availableRecipe[num79]].Create();
                                            if ((Main.mouseItem.type > 0) || (recipe[availableRecipe[num79]].createItem.type > 0))
                                            {
                                                PlaySound(7, -1, -1, 1);
                                            }
                                        }
                                        else if (((stackSplit <= 1) && (mouseState.RightButton == ButtonState.Pressed)) && ((Main.mouseItem.stack < Main.mouseItem.maxStack) || (Main.mouseItem.type == 0)))
                                        {
                                            if (stackSplit == 0)
                                            {
                                                stackSplit = 15;
                                            }
                                            else
                                            {
                                                stackSplit = stackDelay;
                                            }
                                            int num85 = Main.mouseItem.stack;
                                            Main.mouseItem = (Item) recipe[availableRecipe[num79]].createItem.Clone();
                                            Main.mouseItem.stack += num85;
                                            recipe[availableRecipe[num79]].Create();
                                            if ((Main.mouseItem.type > 0) || (recipe[availableRecipe[num79]].createItem.type > 0))
                                            {
                                                PlaySound(7, -1, -1, 1);
                                            }
                                        }
                                    }
                                }
                                else if (mouseLeftRelease && (mouseState.LeftButton == ButtonState.Pressed))
                                {
                                    Main.focusRecipe = num79;
                                }
                                craftingHide = true;
                                cursorText = recipe[availableRecipe[num79]].createItem.name;
                                toolTip = (Item) recipe[availableRecipe[num79]].createItem.Clone();
                                if (recipe[availableRecipe[num79]].createItem.stack > 1)
                                {
                                    obj2 = cursorText;
                                    cursorText = string.Concat(new object[] { obj2, " (", recipe[availableRecipe[num79]].createItem.stack, ")" });
                                }
                            }
                            if (numAvailableRecipes > 0)
                            {
                                num82 -= 50.0;
                                if (num82 < 0.0)
                                {
                                    num82 = 0.0;
                                }
                                vector10 = new Vector2();
                                this.spriteBatch.Draw(inventoryBack4Texture, new Vector2((float) num80, (float) num81), new Rectangle(0, 0, inventoryBackTexture.Width, inventoryBackTexture.Height), new Color((byte) num82, (byte) num82, (byte) num82, (byte) num82), 0f, vector10, Main.inventoryScale, SpriteEffects.None, 0f);
                                if ((recipe[availableRecipe[num79]].createItem.type > 0) && (recipe[availableRecipe[num79]].createItem.stack > 0))
                                {
                                    float num86 = 1f;
                                    if ((itemTexture[recipe[availableRecipe[num79]].createItem.type].Width > 0x20) || (itemTexture[recipe[availableRecipe[num79]].createItem.type].Height > 0x20))
                                    {
                                        if (itemTexture[recipe[availableRecipe[num79]].createItem.type].Width > itemTexture[recipe[availableRecipe[num79]].createItem.type].Height)
                                        {
                                            num86 = 32f / ((float) itemTexture[recipe[availableRecipe[num79]].createItem.type].Width);
                                        }
                                        else
                                        {
                                            num86 = 32f / ((float) itemTexture[recipe[availableRecipe[num79]].createItem.type].Height);
                                        }
                                    }
                                    num86 *= Main.inventoryScale;
                                    vector10 = new Vector2();
                                    this.spriteBatch.Draw(itemTexture[recipe[availableRecipe[num79]].createItem.type], new Vector2((num80 + (26f * Main.inventoryScale)) - ((itemTexture[recipe[availableRecipe[num79]].createItem.type].Width * 0.5f) * num86), (num81 + (26f * Main.inventoryScale)) - ((itemTexture[recipe[availableRecipe[num79]].createItem.type].Height * 0.5f) * num86)), new Rectangle(0, 0, itemTexture[recipe[availableRecipe[num79]].createItem.type].Width, itemTexture[recipe[availableRecipe[num79]].createItem.type].Height), recipe[availableRecipe[num79]].createItem.GetAlpha(color11), 0f, vector10, num86, SpriteEffects.None, 0f);
                                    color30 = new Color();
                                    if (recipe[availableRecipe[num79]].createItem.color != color30)
                                    {
                                        vector10 = new Vector2();
                                        this.spriteBatch.Draw(itemTexture[recipe[availableRecipe[num79]].createItem.type], new Vector2((num80 + (26f * Main.inventoryScale)) - ((itemTexture[recipe[availableRecipe[num79]].createItem.type].Width * 0.5f) * num86), (num81 + (26f * Main.inventoryScale)) - ((itemTexture[recipe[availableRecipe[num79]].createItem.type].Height * 0.5f) * num86)), new Rectangle(0, 0, itemTexture[recipe[availableRecipe[num79]].createItem.type].Width, itemTexture[recipe[availableRecipe[num79]].createItem.type].Height), recipe[availableRecipe[num79]].createItem.GetColor(color11), 0f, vector10, num86, SpriteEffects.None, 0f);
                                    }
                                    if (recipe[availableRecipe[num79]].createItem.stack > 1)
                                    {
                                        vector10 = new Vector2();
                                        this.spriteBatch.DrawString(fontItemStack, (recipe[availableRecipe[num79]].createItem.stack).ToString(), new Vector2(num80 + (10f * Main.inventoryScale), num81 + (26f * Main.inventoryScale)), color11, 0f, vector10, num86, SpriteEffects.None, 0f);
                                    }
                                }
                            }
                        }
                    }
                    if (numAvailableRecipes > 0)
                    {
                        for (int num87 = 0; num87 < Recipe.maxRequirements; num87++)
                        {
                            if (recipe[availableRecipe[Main.focusRecipe]].requiredItem[num87].type == 0)
                            {
                                break;
                            }
                            int num88 = 80 + (num87 * 40);
                            int num89 = 380;
                            double num90 = color2.A + 50;
                            double num91 = 255.0;
                            Color color12 = Color.White;
                            Color color13 = Color.White;
                            num90 = (color2.A + 50) - (Math.Abs(availableRecipeY[Main.focusRecipe]) * 2f);
                            num91 = 255f - (Math.Abs(availableRecipeY[Main.focusRecipe]) * 2f);
                            if (num90 < 0.0)
                            {
                                num90 = 0.0;
                            }
                            if (num91 < 0.0)
                            {
                                num91 = 0.0;
                            }
                            color12.R = (byte) num90;
                            color12.G = (byte) num90;
                            color12.B = (byte) num90;
                            color12.A = (byte) num90;
                            color13.R = (byte) num91;
                            color13.G = (byte) num91;
                            color13.B = (byte) num91;
                            color13.A = (byte) num91;
                            Main.inventoryScale = 0.6f;
                            if (num90 == 0.0)
                            {
                                break;
                            }
                            if (((mouseState.X >= num88) && (mouseState.X <= (num88 + (inventoryBackTexture.Width * Main.inventoryScale)))) && ((mouseState.Y >= num89) && (mouseState.Y <= (num89 + (inventoryBackTexture.Height * Main.inventoryScale)))))
                            {
                                craftingHide = true;
                                player[myPlayer].mouseInterface = true;
                                cursorText = recipe[availableRecipe[Main.focusRecipe]].requiredItem[num87].name;
                                toolTip = (Item) recipe[availableRecipe[Main.focusRecipe]].requiredItem[num87].Clone();
                                if (recipe[availableRecipe[Main.focusRecipe]].requiredItem[num87].stack > 1)
                                {
                                    obj2 = cursorText;
                                    cursorText = string.Concat(new object[] { obj2, " (", recipe[availableRecipe[Main.focusRecipe]].requiredItem[num87].stack, ")" });
                                }
                            }
                            num90 -= 50.0;
                            if (num90 < 0.0)
                            {
                                num90 = 0.0;
                            }
                            vector10 = new Vector2();
                            this.spriteBatch.Draw(inventoryBack4Texture, new Vector2((float) num88, (float) num89), new Rectangle(0, 0, inventoryBackTexture.Width, inventoryBackTexture.Height), new Color((byte) num90, (byte) num90, (byte) num90, (byte) num90), 0f, vector10, Main.inventoryScale, SpriteEffects.None, 0f);
                            if ((recipe[availableRecipe[Main.focusRecipe]].requiredItem[num87].type > 0) && (recipe[availableRecipe[Main.focusRecipe]].requiredItem[num87].stack > 0))
                            {
                                float num92 = 1f;
                                if ((itemTexture[recipe[availableRecipe[Main.focusRecipe]].requiredItem[num87].type].Width > 0x20) || (itemTexture[recipe[availableRecipe[Main.focusRecipe]].requiredItem[num87].type].Height > 0x20))
                                {
                                    if (itemTexture[recipe[availableRecipe[Main.focusRecipe]].requiredItem[num87].type].Width > itemTexture[recipe[availableRecipe[Main.focusRecipe]].requiredItem[num87].type].Height)
                                    {
                                        num92 = 32f / ((float) itemTexture[recipe[availableRecipe[Main.focusRecipe]].requiredItem[num87].type].Width);
                                    }
                                    else
                                    {
                                        num92 = 32f / ((float) itemTexture[recipe[availableRecipe[Main.focusRecipe]].requiredItem[num87].type].Height);
                                    }
                                }
                                num92 *= Main.inventoryScale;
                                vector10 = new Vector2();
                                this.spriteBatch.Draw(itemTexture[recipe[availableRecipe[Main.focusRecipe]].requiredItem[num87].type], new Vector2((num88 + (26f * Main.inventoryScale)) - ((itemTexture[recipe[availableRecipe[Main.focusRecipe]].requiredItem[num87].type].Width * 0.5f) * num92), (num89 + (26f * Main.inventoryScale)) - ((itemTexture[recipe[availableRecipe[Main.focusRecipe]].requiredItem[num87].type].Height * 0.5f) * num92)), new Rectangle(0, 0, itemTexture[recipe[availableRecipe[Main.focusRecipe]].requiredItem[num87].type].Width, itemTexture[recipe[availableRecipe[Main.focusRecipe]].requiredItem[num87].type].Height), recipe[availableRecipe[Main.focusRecipe]].requiredItem[num87].GetAlpha(color13), 0f, vector10, num92, SpriteEffects.None, 0f);
                                color30 = new Color();
                                if (recipe[availableRecipe[Main.focusRecipe]].requiredItem[num87].color != color30)
                                {
                                    vector10 = new Vector2();
                                    this.spriteBatch.Draw(itemTexture[recipe[availableRecipe[Main.focusRecipe]].requiredItem[num87].type], new Vector2((num88 + (26f * Main.inventoryScale)) - ((itemTexture[recipe[availableRecipe[Main.focusRecipe]].requiredItem[num87].type].Width * 0.5f) * num92), (num89 + (26f * Main.inventoryScale)) - ((itemTexture[recipe[availableRecipe[Main.focusRecipe]].requiredItem[num87].type].Height * 0.5f) * num92)), new Rectangle(0, 0, itemTexture[recipe[availableRecipe[Main.focusRecipe]].requiredItem[num87].type].Width, itemTexture[recipe[availableRecipe[Main.focusRecipe]].requiredItem[num87].type].Height), recipe[availableRecipe[Main.focusRecipe]].requiredItem[num87].GetColor(color13), 0f, vector10, num92, SpriteEffects.None, 0f);
                                }
                                if (recipe[availableRecipe[Main.focusRecipe]].requiredItem[num87].stack > 1)
                                {
                                    vector10 = new Vector2();
                                    this.spriteBatch.DrawString(fontItemStack, (recipe[availableRecipe[Main.focusRecipe]].requiredItem[num87].stack).ToString(), new Vector2(num88 + (10f * Main.inventoryScale), num89 + (26f * Main.inventoryScale)), color13, 0f, vector10, num92, SpriteEffects.None, 0f);
                                }
                            }
                        }
                    }
                    vector10 = new Vector2();
                    this.spriteBatch.DrawString(fontMouseText, "Coins", new Vector2(496f, 84f), new Color(mouseTextColor, mouseTextColor, mouseTextColor, mouseTextColor), 0f, vector10, (float) 0.75f, SpriteEffects.None, 0f);
                    Main.inventoryScale = 0.6f;
                    for (int num93 = 0; num93 < 4; num93++)
                    {
                        int num94 = 0x1f1;
                        int num95 = (int) ((85f + ((num93 * 0x38) * Main.inventoryScale)) + 20f);
                        int num96 = num93 + 40;
                        Color color14 = new Color(100, 100, 100, 100);
                        if (((mouseState.X >= num94) && (mouseState.X <= (num94 + (inventoryBackTexture.Width * Main.inventoryScale)))) && ((mouseState.Y >= num95) && (mouseState.Y <= (num95 + (inventoryBackTexture.Height * Main.inventoryScale)))))
                        {
                            player[myPlayer].mouseInterface = true;
                            if (mouseLeftRelease && (mouseState.LeftButton == ButtonState.Pressed))
                            {
                                if (((player[myPlayer].selectedItem != num96) || (player[myPlayer].itemAnimation <= 0)) && (((Main.mouseItem.type == 0) || (Main.mouseItem.type == 0x47)) || (((Main.mouseItem.type == 0x48) || (Main.mouseItem.type == 0x49)) || (Main.mouseItem.type == 0x4a))))
                                {
                                    Item item6 = Main.mouseItem;
                                    Main.mouseItem = player[myPlayer].inventory[num96];
                                    player[myPlayer].inventory[num96] = item6;
                                    if ((player[myPlayer].inventory[num96].type == 0) || (player[myPlayer].inventory[num96].stack < 1))
                                    {
                                        player[myPlayer].inventory[num96] = new Item();
                                    }
                                    if ((Main.mouseItem.IsTheSameAs(player[myPlayer].inventory[num96]) && (player[myPlayer].inventory[num96].stack != player[myPlayer].inventory[num96].maxStack)) && (Main.mouseItem.stack != Main.mouseItem.maxStack))
                                    {
                                        if ((Main.mouseItem.stack + player[myPlayer].inventory[num96].stack) <= Main.mouseItem.maxStack)
                                        {
                                            Item item13 = player[myPlayer].inventory[num96];
                                            item13.stack += Main.mouseItem.stack;
                                            Main.mouseItem.stack = 0;
                                        }
                                        else
                                        {
                                            int num97 = Main.mouseItem.maxStack - player[myPlayer].inventory[num96].stack;
                                            Item item14 = player[myPlayer].inventory[num96];
                                            item14.stack += num97;
                                            Main.mouseItem.stack -= num97;
                                        }
                                    }
                                    if ((Main.mouseItem.type == 0) || (Main.mouseItem.stack < 1))
                                    {
                                        Main.mouseItem = new Item();
                                    }
                                    if ((Main.mouseItem.type > 0) || (player[myPlayer].inventory[num96].type > 0))
                                    {
                                        PlaySound(7, -1, -1, 1);
                                    }
                                    Recipe.FindRecipes();
                                }
                            }
                            else if ((((stackSplit <= 1) && (mouseState.RightButton == ButtonState.Pressed)) && (Main.mouseItem.IsTheSameAs(player[myPlayer].inventory[num96]) || (Main.mouseItem.type == 0))) && ((Main.mouseItem.stack < Main.mouseItem.maxStack) || (Main.mouseItem.type == 0)))
                            {
                                if (Main.mouseItem.type == 0)
                                {
                                    Main.mouseItem = (Item) player[myPlayer].inventory[num96].Clone();
                                    Main.mouseItem.stack = 0;
                                }
                                Main.mouseItem.stack++;
                                Item item15 = player[myPlayer].inventory[num96];
                                item15.stack--;
                                if (player[myPlayer].inventory[num96].stack <= 0)
                                {
                                    player[myPlayer].inventory[num96] = new Item();
                                }
                                Recipe.FindRecipes();
                                soundInstanceMenuTick.Stop();
                                soundInstanceMenuTick = soundMenuTick.CreateInstance();
                                PlaySound(12, -1, -1, 1);
                                if (stackSplit == 0)
                                {
                                    stackSplit = 15;
                                }
                                else
                                {
                                    stackSplit = stackDelay;
                                }
                            }
                            cursorText = player[myPlayer].inventory[num96].name;
                            toolTip = (Item) player[myPlayer].inventory[num96].Clone();
                            if (player[myPlayer].inventory[num96].stack > 1)
                            {
                                obj2 = cursorText;
                                cursorText = string.Concat(new object[] { obj2, " (", player[myPlayer].inventory[num96].stack, ")" });
                            }
                        }
                        vector10 = new Vector2();
                        this.spriteBatch.Draw(inventoryBackTexture, new Vector2((float) num94, (float) num95), new Rectangle(0, 0, inventoryBackTexture.Width, inventoryBackTexture.Height), color2, 0f, vector10, Main.inventoryScale, SpriteEffects.None, 0f);
                        color14 = Color.White;
                        if ((player[myPlayer].inventory[num96].type > 0) && (player[myPlayer].inventory[num96].stack > 0))
                        {
                            float num98 = 1f;
                            if ((itemTexture[player[myPlayer].inventory[num96].type].Width > 0x20) || (itemTexture[player[myPlayer].inventory[num96].type].Height > 0x20))
                            {
                                if (itemTexture[player[myPlayer].inventory[num96].type].Width > itemTexture[player[myPlayer].inventory[num96].type].Height)
                                {
                                    num98 = 32f / ((float) itemTexture[player[myPlayer].inventory[num96].type].Width);
                                }
                                else
                                {
                                    num98 = 32f / ((float) itemTexture[player[myPlayer].inventory[num96].type].Height);
                                }
                            }
                            num98 *= Main.inventoryScale;
                            vector10 = new Vector2();
                            this.spriteBatch.Draw(itemTexture[player[myPlayer].inventory[num96].type], new Vector2((num94 + (26f * Main.inventoryScale)) - ((itemTexture[player[myPlayer].inventory[num96].type].Width * 0.5f) * num98), (num95 + (26f * Main.inventoryScale)) - ((itemTexture[player[myPlayer].inventory[num96].type].Height * 0.5f) * num98)), new Rectangle(0, 0, itemTexture[player[myPlayer].inventory[num96].type].Width, itemTexture[player[myPlayer].inventory[num96].type].Height), player[myPlayer].inventory[num96].GetAlpha(color14), 0f, vector10, num98, SpriteEffects.None, 0f);
                            color30 = new Color();
                            if (player[myPlayer].inventory[num96].color != color30)
                            {
                                vector10 = new Vector2();
                                this.spriteBatch.Draw(itemTexture[player[myPlayer].inventory[num96].type], new Vector2((num94 + (26f * Main.inventoryScale)) - ((itemTexture[player[myPlayer].inventory[num96].type].Width * 0.5f) * num98), (num95 + (26f * Main.inventoryScale)) - ((itemTexture[player[myPlayer].inventory[num96].type].Height * 0.5f) * num98)), new Rectangle(0, 0, itemTexture[player[myPlayer].inventory[num96].type].Width, itemTexture[player[myPlayer].inventory[num96].type].Height), player[myPlayer].inventory[num96].GetColor(color14), 0f, vector10, num98, SpriteEffects.None, 0f);
                            }
                            if (player[myPlayer].inventory[num96].stack > 1)
                            {
                                vector10 = new Vector2();
                                this.spriteBatch.DrawString(fontItemStack, (player[myPlayer].inventory[num96].stack).ToString(), new Vector2(num94 + (10f * Main.inventoryScale), num95 + (26f * Main.inventoryScale)), color14, 0f, vector10, num98, SpriteEffects.None, 0f);
                            }
                        }
                    }
                    vector10 = new Vector2();
                    this.spriteBatch.DrawString(fontMouseText, "Ammo", new Vector2(532f, 84f), new Color(mouseTextColor, mouseTextColor, mouseTextColor, mouseTextColor), 0f, vector10, (float) 0.75f, SpriteEffects.None, 0f);
                    Main.inventoryScale = 0.6f;
                    for (int num99 = 0; num99 < 4; num99++)
                    {
                        int num100 = 0x216;
                        int num101 = (int) ((85f + ((num99 * 0x38) * Main.inventoryScale)) + 20f);
                        int num102 = num99;
                        Color color15 = new Color(100, 100, 100, 100);
                        if (((mouseState.X >= num100) && (mouseState.X <= (num100 + (inventoryBackTexture.Width * Main.inventoryScale)))) && ((mouseState.Y >= num101) && (mouseState.Y <= (num101 + (inventoryBackTexture.Height * Main.inventoryScale)))))
                        {
                            player[myPlayer].mouseInterface = true;
                            if (mouseLeftRelease && (mouseState.LeftButton == ButtonState.Pressed))
                            {
                                if (((player[myPlayer].selectedItem != num102) || (player[myPlayer].itemAnimation <= 0)) && ((Main.mouseItem.type == 0) || (Main.mouseItem.ammo > 0)))
                                {
                                    Item item7 = Main.mouseItem;
                                    Main.mouseItem = player[myPlayer].ammo[num102];
                                    player[myPlayer].ammo[num102] = item7;
                                    if ((player[myPlayer].ammo[num102].type == 0) || (player[myPlayer].ammo[num102].stack < 1))
                                    {
                                        player[myPlayer].ammo[num102] = new Item();
                                    }
                                    if ((Main.mouseItem.IsTheSameAs(player[myPlayer].ammo[num102]) && (player[myPlayer].ammo[num102].stack != player[myPlayer].ammo[num102].maxStack)) && (Main.mouseItem.stack != Main.mouseItem.maxStack))
                                    {
                                        if ((Main.mouseItem.stack + player[myPlayer].ammo[num102].stack) <= Main.mouseItem.maxStack)
                                        {
                                            Item item16 = player[myPlayer].ammo[num102];
                                            item16.stack += Main.mouseItem.stack;
                                            Main.mouseItem.stack = 0;
                                        }
                                        else
                                        {
                                            int num103 = Main.mouseItem.maxStack - player[myPlayer].ammo[num102].stack;
                                            Item item17 = player[myPlayer].ammo[num102];
                                            item17.stack += num103;
                                            Main.mouseItem.stack -= num103;
                                        }
                                    }
                                    if ((Main.mouseItem.type == 0) || (Main.mouseItem.stack < 1))
                                    {
                                        Main.mouseItem = new Item();
                                    }
                                    if ((Main.mouseItem.type > 0) || (player[myPlayer].ammo[num102].type > 0))
                                    {
                                        PlaySound(7, -1, -1, 1);
                                    }
                                    Recipe.FindRecipes();
                                }
                            }
                            else if ((((stackSplit <= 1) && (mouseState.RightButton == ButtonState.Pressed)) && (Main.mouseItem.IsTheSameAs(player[myPlayer].ammo[num102]) || (Main.mouseItem.type == 0))) && ((Main.mouseItem.stack < Main.mouseItem.maxStack) || (Main.mouseItem.type == 0)))
                            {
                                if (Main.mouseItem.type == 0)
                                {
                                    Main.mouseItem = (Item) player[myPlayer].ammo[num102].Clone();
                                    Main.mouseItem.stack = 0;
                                }
                                Main.mouseItem.stack++;
                                Item item18 = player[myPlayer].ammo[num102];
                                item18.stack--;
                                if (player[myPlayer].ammo[num102].stack <= 0)
                                {
                                    player[myPlayer].ammo[num102] = new Item();
                                }
                                Recipe.FindRecipes();
                                soundInstanceMenuTick.Stop();
                                soundInstanceMenuTick = soundMenuTick.CreateInstance();
                                PlaySound(12, -1, -1, 1);
                                if (stackSplit == 0)
                                {
                                    stackSplit = 15;
                                }
                                else
                                {
                                    stackSplit = stackDelay;
                                }
                            }
                            cursorText = player[myPlayer].ammo[num102].name;
                            toolTip = (Item) player[myPlayer].ammo[num102].Clone();
                            if (player[myPlayer].ammo[num102].stack > 1)
                            {
                                obj2 = cursorText;
                                cursorText = string.Concat(new object[] { obj2, " (", player[myPlayer].ammo[num102].stack, ")" });
                            }
                        }
                        vector10 = new Vector2();
                        this.spriteBatch.Draw(inventoryBackTexture, new Vector2((float) num100, (float) num101), new Rectangle(0, 0, inventoryBackTexture.Width, inventoryBackTexture.Height), color2, 0f, vector10, Main.inventoryScale, SpriteEffects.None, 0f);
                        color15 = Color.White;
                        if ((player[myPlayer].ammo[num102].type > 0) && (player[myPlayer].ammo[num102].stack > 0))
                        {
                            float num104 = 1f;
                            if ((itemTexture[player[myPlayer].ammo[num102].type].Width > 0x20) || (itemTexture[player[myPlayer].ammo[num102].type].Height > 0x20))
                            {
                                if (itemTexture[player[myPlayer].ammo[num102].type].Width > itemTexture[player[myPlayer].ammo[num102].type].Height)
                                {
                                    num104 = 32f / ((float) itemTexture[player[myPlayer].ammo[num102].type].Width);
                                }
                                else
                                {
                                    num104 = 32f / ((float) itemTexture[player[myPlayer].ammo[num102].type].Height);
                                }
                            }
                            num104 *= Main.inventoryScale;
                            vector10 = new Vector2();
                            this.spriteBatch.Draw(itemTexture[player[myPlayer].ammo[num102].type], new Vector2((num100 + (26f * Main.inventoryScale)) - ((itemTexture[player[myPlayer].ammo[num102].type].Width * 0.5f) * num104), (num101 + (26f * Main.inventoryScale)) - ((itemTexture[player[myPlayer].ammo[num102].type].Height * 0.5f) * num104)), new Rectangle(0, 0, itemTexture[player[myPlayer].ammo[num102].type].Width, itemTexture[player[myPlayer].ammo[num102].type].Height), player[myPlayer].ammo[num102].GetAlpha(color15), 0f, vector10, num104, SpriteEffects.None, 0f);
                            color30 = new Color();
                            if (player[myPlayer].ammo[num102].color != color30)
                            {
                                vector10 = new Vector2();
                                this.spriteBatch.Draw(itemTexture[player[myPlayer].ammo[num102].type], new Vector2((num100 + (26f * Main.inventoryScale)) - ((itemTexture[player[myPlayer].ammo[num102].type].Width * 0.5f) * num104), (num101 + (26f * Main.inventoryScale)) - ((itemTexture[player[myPlayer].ammo[num102].type].Height * 0.5f) * num104)), new Rectangle(0, 0, itemTexture[player[myPlayer].ammo[num102].type].Width, itemTexture[player[myPlayer].ammo[num102].type].Height), player[myPlayer].ammo[num102].GetColor(color15), 0f, vector10, num104, SpriteEffects.None, 0f);
                            }
                            if (player[myPlayer].ammo[num102].stack > 1)
                            {
                                vector10 = new Vector2();
                                this.spriteBatch.DrawString(fontItemStack, (player[myPlayer].ammo[num102].stack).ToString(), new Vector2(num100 + (10f * Main.inventoryScale), num101 + (26f * Main.inventoryScale)), color15, 0f, vector10, num104, SpriteEffects.None, 0f);
                            }
                        }
                    }
                    if ((npcShop > 0) && (!playerInventory || (player[myPlayer].talkNPC == -1)))
                    {
                        npcShop = 0;
                    }
                    if (npcShop > 0)
                    {
                        vector10 = new Vector2();
                        this.spriteBatch.DrawString(fontMouseText, "Shop", new Vector2(284f, 210f), new Color(mouseTextColor, mouseTextColor, mouseTextColor, mouseTextColor), 0f, vector10, (float) 1f, SpriteEffects.None, 0f);
                        Main.inventoryScale = 0.75f;
                        if (((mouseState.X > 0x49) && (mouseState.X < ((int) (73f + (280f * Main.inventoryScale))))) && ((mouseState.Y > 210) && (mouseState.Y < ((int) (210f + (224f * Main.inventoryScale))))))
                        {
                            player[myPlayer].mouseInterface = true;
                        }
                        for (int num105 = 0; num105 < 5; num105++)
                        {
                            for (int num106 = 0; num106 < 4; num106++)
                            {
                                int num107 = (int) (73f + ((num105 * 0x38) * Main.inventoryScale));
                                int num108 = (int) (210f + ((num106 * 0x38) * Main.inventoryScale));
                                int num109 = num105 + (num106 * 5);
                                Color color16 = new Color(100, 100, 100, 100);
                                if (((mouseState.X >= num107) && (mouseState.X <= (num107 + (inventoryBackTexture.Width * Main.inventoryScale)))) && ((mouseState.Y >= num108) && (mouseState.Y <= (num108 + (inventoryBackTexture.Height * Main.inventoryScale)))))
                                {
                                    player[myPlayer].mouseInterface = true;
                                    if (mouseLeftRelease && (mouseState.LeftButton == ButtonState.Pressed))
                                    {
                                        if (Main.mouseItem.type == 0)
                                        {
                                            if (((player[myPlayer].selectedItem != num109) || (player[myPlayer].itemAnimation <= 0)) && player[myPlayer].BuyItem(this.shop[npcShop].item[num109].value))
                                            {
                                                Main.mouseItem.SetDefaults(this.shop[npcShop].item[num109].name);
                                                if (this.shop[npcShop].item[num109].buyOnce)
                                                {
                                                    Item item19 = this.shop[npcShop].item[num109];
                                                    item19.stack--;
                                                    if (this.shop[npcShop].item[num109].stack <= 0)
                                                    {
                                                        this.shop[npcShop].item[num109].SetDefaults(0, false);
                                                    }
                                                }
                                                PlaySound(0x12, -1, -1, 1);
                                            }
                                        }
                                        else if (this.shop[npcShop].item[num109].type == 0)
                                        {
                                            if (player[myPlayer].SellItem(Main.mouseItem.value * Main.mouseItem.stack))
                                            {
                                                this.shop[npcShop].AddShop(Main.mouseItem);
                                                Main.mouseItem.stack = 0;
                                                Main.mouseItem.type = 0;
                                                PlaySound(0x12, -1, -1, 1);
                                            }
                                            else if (Main.mouseItem.value == 0)
                                            {
                                                this.shop[npcShop].AddShop(Main.mouseItem);
                                                Main.mouseItem.stack = 0;
                                                Main.mouseItem.type = 0;
                                                PlaySound(7, -1, -1, 1);
                                            }
                                        }
                                    }
                                    else if (((((stackSplit <= 1) && (mouseState.RightButton == ButtonState.Pressed)) && (Main.mouseItem.IsTheSameAs(this.shop[npcShop].item[num109]) || (Main.mouseItem.type == 0))) && ((Main.mouseItem.stack < Main.mouseItem.maxStack) || (Main.mouseItem.type == 0))) && player[myPlayer].BuyItem(this.shop[npcShop].item[num109].value))
                                    {
                                        PlaySound(0x12, -1, -1, 1);
                                        if (Main.mouseItem.type == 0)
                                        {
                                            Main.mouseItem.SetDefaults(this.shop[npcShop].item[num109].name);
                                            Main.mouseItem.stack = 0;
                                        }
                                        Main.mouseItem.stack++;
                                        if (stackSplit == 0)
                                        {
                                            stackSplit = 15;
                                        }
                                        else
                                        {
                                            stackSplit = stackDelay;
                                        }
                                        if (this.shop[npcShop].item[num109].buyOnce)
                                        {
                                            Item item20 = this.shop[npcShop].item[num109];
                                            item20.stack--;
                                            if (this.shop[npcShop].item[num109].stack <= 0)
                                            {
                                                this.shop[npcShop].item[num109].SetDefaults(0, false);
                                            }
                                        }
                                    }
                                    cursorText = this.shop[npcShop].item[num109].name;
                                    toolTip = (Item) this.shop[npcShop].item[num109].Clone();
                                    toolTip.buy = true;
                                    if (this.shop[npcShop].item[num109].stack > 1)
                                    {
                                        obj2 = cursorText;
                                        cursorText = string.Concat(new object[] { obj2, " (", this.shop[npcShop].item[num109].stack, ")" });
                                    }
                                }
                                vector10 = new Vector2();
                                this.spriteBatch.Draw(inventoryBack6Texture, new Vector2((float) num107, (float) num108), new Rectangle(0, 0, inventoryBackTexture.Width, inventoryBackTexture.Height), color2, 0f, vector10, Main.inventoryScale, SpriteEffects.None, 0f);
                                color16 = Color.White;
                                if ((this.shop[npcShop].item[num109].type > 0) && (this.shop[npcShop].item[num109].stack > 0))
                                {
                                    float num110 = 1f;
                                    if ((itemTexture[this.shop[npcShop].item[num109].type].Width > 0x20) || (itemTexture[this.shop[npcShop].item[num109].type].Height > 0x20))
                                    {
                                        if (itemTexture[this.shop[npcShop].item[num109].type].Width > itemTexture[this.shop[npcShop].item[num109].type].Height)
                                        {
                                            num110 = 32f / ((float) itemTexture[this.shop[npcShop].item[num109].type].Width);
                                        }
                                        else
                                        {
                                            num110 = 32f / ((float) itemTexture[this.shop[npcShop].item[num109].type].Height);
                                        }
                                    }
                                    num110 *= Main.inventoryScale;
                                    vector10 = new Vector2();
                                    this.spriteBatch.Draw(itemTexture[this.shop[npcShop].item[num109].type], new Vector2((num107 + (26f * Main.inventoryScale)) - ((itemTexture[this.shop[npcShop].item[num109].type].Width * 0.5f) * num110), (num108 + (26f * Main.inventoryScale)) - ((itemTexture[this.shop[npcShop].item[num109].type].Height * 0.5f) * num110)), new Rectangle(0, 0, itemTexture[this.shop[npcShop].item[num109].type].Width, itemTexture[this.shop[npcShop].item[num109].type].Height), this.shop[npcShop].item[num109].GetAlpha(color16), 0f, vector10, num110, SpriteEffects.None, 0f);
                                    color30 = new Color();
                                    if (this.shop[npcShop].item[num109].color != color30)
                                    {
                                        vector10 = new Vector2();
                                        this.spriteBatch.Draw(itemTexture[this.shop[npcShop].item[num109].type], new Vector2((num107 + (26f * Main.inventoryScale)) - ((itemTexture[this.shop[npcShop].item[num109].type].Width * 0.5f) * num110), (num108 + (26f * Main.inventoryScale)) - ((itemTexture[this.shop[npcShop].item[num109].type].Height * 0.5f) * num110)), new Rectangle(0, 0, itemTexture[this.shop[npcShop].item[num109].type].Width, itemTexture[this.shop[npcShop].item[num109].type].Height), this.shop[npcShop].item[num109].GetColor(color16), 0f, vector10, num110, SpriteEffects.None, 0f);
                                    }
                                    if (this.shop[npcShop].item[num109].stack > 1)
                                    {
                                        vector10 = new Vector2();
                                        this.spriteBatch.DrawString(fontItemStack, (this.shop[npcShop].item[num109].stack).ToString(), new Vector2(num107 + (10f * Main.inventoryScale), num108 + (26f * Main.inventoryScale)), color16, 0f, vector10, num110, SpriteEffects.None, 0f);
                                    }
                                }
                            }
                        }
                    }
                    if ((player[myPlayer].chest > -1) && (tile[player[myPlayer].chestX, player[myPlayer].chestY].type != 0x15))
                    {
                        player[myPlayer].chest = -1;
                    }
                    if (player[myPlayer].chest != -1)
                    {
                        Main.inventoryScale = 0.75f;
                        if (((mouseState.X > 0x49) && (mouseState.X < ((int) (73f + (280f * Main.inventoryScale))))) && ((mouseState.Y > 210) && (mouseState.Y < ((int) (210f + (224f * Main.inventoryScale))))))
                        {
                            player[myPlayer].mouseInterface = true;
                        }
                        for (int num111 = 0; num111 < 3; num111++)
                        {
                            int num112 = 0x11e;
                            int num113 = 250;
                            float chestLootScale = this.chestLootScale;
                            string str10 = "Loot All";
                            switch (num111)
                            {
                                case 1:
                                    num113 += 0x1a;
                                    chestLootScale = this.chestDepositScale;
                                    str10 = "Deposit All";
                                    break;

                                case 2:
                                    num113 += 0x34;
                                    chestLootScale = this.chestStackScale;
                                    str10 = "Quick Stack";
                                    break;
                            }
                            Vector2 origin = (Vector2) (fontMouseText.MeasureString(str10) / 2f);
                            Color color17 = new Color((int) ((byte) (mouseTextColor * chestLootScale)), (int) ((byte) (mouseTextColor * chestLootScale)), (int) ((byte) (mouseTextColor * chestLootScale)), (int) ((byte) (mouseTextColor * chestLootScale)));
                            num112 += (int) (origin.X * chestLootScale);
                            this.spriteBatch.DrawString(fontMouseText, str10, new Vector2((float) num112, (float) num113), color17, 0f, origin, chestLootScale, SpriteEffects.None, 0f);
                            origin = (Vector2) (origin * chestLootScale);
                            if (((mouseState.X > (num112 - origin.X)) && (mouseState.X < (num112 + origin.X))) && ((mouseState.Y > (num113 - origin.Y)) && (mouseState.Y < (num113 + origin.Y))))
                            {
                                switch (num111)
                                {
                                    case 0:
                                        if (!this.chestLootHover)
                                        {
                                            PlaySound(12, -1, -1, 1);
                                        }
                                        this.chestLootHover = true;
                                        break;

                                    case 1:
                                        if (!this.chestDepositHover)
                                        {
                                            PlaySound(12, -1, -1, 1);
                                        }
                                        this.chestDepositHover = true;
                                        break;

                                    default:
                                        if (!this.chestStackHover)
                                        {
                                            PlaySound(12, -1, -1, 1);
                                        }
                                        this.chestStackHover = true;
                                        break;
                                }
                                player[myPlayer].mouseInterface = true;
                                chestLootScale += 0.05f;
                                if ((mouseState.LeftButton == ButtonState.Pressed) && mouseLeftRelease)
                                {
                                    if (num111 == 0)
                                    {
                                        if (player[myPlayer].chest > -1)
                                        {
                                            for (int num115 = 0; num115 < 20; num115++)
                                            {
                                                if (chest[player[myPlayer].chest].item[num115].type > 0)
                                                {
                                                    chest[player[myPlayer].chest].item[num115] = player[myPlayer].GetItem(myPlayer, chest[player[myPlayer].chest].item[num115]);
                                                    if (netMode == 1)
                                                    {
                                                        NetMessage.SendData(0x20, -1, -1, "", player[myPlayer].chest, (float) num115, 0f, 0f, 0);
                                                    }
                                                }
                                            }
                                        }
                                        else if (player[myPlayer].chest == -3)
                                        {
                                            for (int num116 = 0; num116 < 20; num116++)
                                            {
                                                if (player[myPlayer].bank2[num116].type > 0)
                                                {
                                                    player[myPlayer].bank2[num116] = player[myPlayer].GetItem(myPlayer, player[myPlayer].bank2[num116]);
                                                }
                                            }
                                        }
                                        else
                                        {
                                            for (int num117 = 0; num117 < 20; num117++)
                                            {
                                                if (player[myPlayer].bank[num117].type > 0)
                                                {
                                                    player[myPlayer].bank[num117] = player[myPlayer].GetItem(myPlayer, player[myPlayer].bank[num117]);
                                                }
                                            }
                                        }
                                    }
                                    else if (num111 == 1)
                                    {
                                        for (int num118 = 40; num118 >= 10; num118--)
                                        {
                                            if ((player[myPlayer].inventory[num118].stack > 0) && (player[myPlayer].inventory[num118].type > 0))
                                            {
                                                if (player[myPlayer].inventory[num118].maxStack > 1)
                                                {
                                                    for (int num119 = 0; num119 < 20; num119++)
                                                    {
                                                        if (player[myPlayer].chest > -1)
                                                        {
                                                            if ((chest[player[myPlayer].chest].item[num119].stack < chest[player[myPlayer].chest].item[num119].maxStack) && player[myPlayer].inventory[num118].IsTheSameAs(chest[player[myPlayer].chest].item[num119]))
                                                            {
                                                                int num120 = player[myPlayer].inventory[num118].stack;
                                                                if ((player[myPlayer].inventory[num118].stack + chest[player[myPlayer].chest].item[num119].stack) > chest[player[myPlayer].chest].item[num119].maxStack)
                                                                {
                                                                    num120 = chest[player[myPlayer].chest].item[num119].maxStack - chest[player[myPlayer].chest].item[num119].stack;
                                                                }
                                                                Item item21 = player[myPlayer].inventory[num118];
                                                                item21.stack -= num120;
                                                                Item item22 = chest[player[myPlayer].chest].item[num119];
                                                                item22.stack += num120;
                                                                ChestCoins();
                                                                PlaySound(7, -1, -1, 1);
                                                                if (player[myPlayer].inventory[num118].stack <= 0)
                                                                {
                                                                    player[myPlayer].inventory[num118].SetDefaults(0, false);
                                                                    if (netMode == 1)
                                                                    {
                                                                        NetMessage.SendData(0x20, -1, -1, "", player[myPlayer].chest, (float) num119, 0f, 0f, 0);
                                                                    }
                                                                    break;
                                                                }
                                                                if (chest[player[myPlayer].chest].item[num119].type == 0)
                                                                {
                                                                    chest[player[myPlayer].chest].item[num119] = (Item) player[myPlayer].inventory[num118].Clone();
                                                                    player[myPlayer].inventory[num118].SetDefaults(0, false);
                                                                }
                                                                if (netMode == 1)
                                                                {
                                                                    NetMessage.SendData(0x20, -1, -1, "", player[myPlayer].chest, (float) num119, 0f, 0f, 0);
                                                                }
                                                            }
                                                        }
                                                        else if (player[myPlayer].chest == -3)
                                                        {
                                                            if ((player[myPlayer].bank2[num119].stack < player[myPlayer].bank2[num119].maxStack) && player[myPlayer].inventory[num118].IsTheSameAs(player[myPlayer].bank2[num119]))
                                                            {
                                                                int num121 = player[myPlayer].inventory[num118].stack;
                                                                if ((player[myPlayer].inventory[num118].stack + player[myPlayer].bank2[num119].stack) > player[myPlayer].bank2[num119].maxStack)
                                                                {
                                                                    num121 = player[myPlayer].bank2[num119].maxStack - player[myPlayer].bank2[num119].stack;
                                                                }
                                                                Item item23 = player[myPlayer].inventory[num118];
                                                                item23.stack -= num121;
                                                                Item item24 = player[myPlayer].bank2[num119];
                                                                item24.stack += num121;
                                                                PlaySound(7, -1, -1, 1);
                                                                BankCoins();
                                                                if (player[myPlayer].inventory[num118].stack <= 0)
                                                                {
                                                                    player[myPlayer].inventory[num118].SetDefaults(0, false);
                                                                    break;
                                                                }
                                                                if (player[myPlayer].bank2[num119].type == 0)
                                                                {
                                                                    player[myPlayer].bank2[num119] = (Item) player[myPlayer].inventory[num118].Clone();
                                                                    player[myPlayer].inventory[num118].SetDefaults(0, false);
                                                                }
                                                            }
                                                        }
                                                        else if ((player[myPlayer].bank[num119].stack < player[myPlayer].bank[num119].maxStack) && player[myPlayer].inventory[num118].IsTheSameAs(player[myPlayer].bank[num119]))
                                                        {
                                                            int num122 = player[myPlayer].inventory[num118].stack;
                                                            if ((player[myPlayer].inventory[num118].stack + player[myPlayer].bank[num119].stack) > player[myPlayer].bank[num119].maxStack)
                                                            {
                                                                num122 = player[myPlayer].bank[num119].maxStack - player[myPlayer].bank[num119].stack;
                                                            }
                                                            Item item25 = player[myPlayer].inventory[num118];
                                                            item25.stack -= num122;
                                                            Item item26 = player[myPlayer].bank[num119];
                                                            item26.stack += num122;
                                                            PlaySound(7, -1, -1, 1);
                                                            BankCoins();
                                                            if (player[myPlayer].inventory[num118].stack <= 0)
                                                            {
                                                                player[myPlayer].inventory[num118].SetDefaults(0, false);
                                                                break;
                                                            }
                                                            if (player[myPlayer].bank[num119].type == 0)
                                                            {
                                                                player[myPlayer].bank[num119] = (Item) player[myPlayer].inventory[num118].Clone();
                                                                player[myPlayer].inventory[num118].SetDefaults(0, false);
                                                            }
                                                        }
                                                    }
                                                }
                                                if (player[myPlayer].inventory[num118].stack > 0)
                                                {
                                                    if (player[myPlayer].chest > -1)
                                                    {
                                                        for (int num123 = 0; num123 < 20; num123++)
                                                        {
                                                            if (chest[player[myPlayer].chest].item[num123].stack == 0)
                                                            {
                                                                PlaySound(7, -1, -1, 1);
                                                                chest[player[myPlayer].chest].item[num123] = (Item) player[myPlayer].inventory[num118].Clone();
                                                                player[myPlayer].inventory[num118].SetDefaults(0, false);
                                                                if (netMode == 1)
                                                                {
                                                                    NetMessage.SendData(0x20, -1, -1, "", player[myPlayer].chest, (float) num123, 0f, 0f, 0);
                                                                }
                                                                break;
                                                            }
                                                        }
                                                    }
                                                    else if (player[myPlayer].chest == -3)
                                                    {
                                                        for (int num124 = 0; num124 < 20; num124++)
                                                        {
                                                            if (player[myPlayer].bank2[num124].stack == 0)
                                                            {
                                                                PlaySound(7, -1, -1, 1);
                                                                player[myPlayer].bank2[num124] = (Item) player[myPlayer].inventory[num118].Clone();
                                                                player[myPlayer].inventory[num118].SetDefaults(0, false);
                                                                break;
                                                            }
                                                        }
                                                    }
                                                    else
                                                    {
                                                        for (int num125 = 0; num125 < 20; num125++)
                                                        {
                                                            if (player[myPlayer].bank[num125].stack == 0)
                                                            {
                                                                PlaySound(7, -1, -1, 1);
                                                                player[myPlayer].bank[num125] = (Item) player[myPlayer].inventory[num118].Clone();
                                                                player[myPlayer].inventory[num118].SetDefaults(0, false);
                                                                break;
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                    else if (player[myPlayer].chest > -1)
                                    {
                                        for (int num126 = 0; num126 < 20; num126++)
                                        {
                                            if ((chest[player[myPlayer].chest].item[num126].type > 0) && (chest[player[myPlayer].chest].item[num126].stack < chest[player[myPlayer].chest].item[num126].maxStack))
                                            {
                                                for (int num127 = 0; num127 < 0x2c; num127++)
                                                {
                                                    if (chest[player[myPlayer].chest].item[num126].IsTheSameAs(player[myPlayer].inventory[num127]))
                                                    {
                                                        int num128 = player[myPlayer].inventory[num127].stack;
                                                        if ((chest[player[myPlayer].chest].item[num126].stack + num128) > chest[player[myPlayer].chest].item[num126].maxStack)
                                                        {
                                                            num128 = chest[player[myPlayer].chest].item[num126].maxStack - chest[player[myPlayer].chest].item[num126].stack;
                                                        }
                                                        PlaySound(7, -1, -1, 1);
                                                        Item item27 = chest[player[myPlayer].chest].item[num126];
                                                        item27.stack += num128;
                                                        Item item28 = player[myPlayer].inventory[num127];
                                                        item28.stack -= num128;
                                                        ChestCoins();
                                                        if (player[myPlayer].inventory[num127].stack == 0)
                                                        {
                                                            player[myPlayer].inventory[num127].SetDefaults(0, false);
                                                        }
                                                        else if (chest[player[myPlayer].chest].item[num126].type == 0)
                                                        {
                                                            chest[player[myPlayer].chest].item[num126] = (Item) player[myPlayer].inventory[num127].Clone();
                                                            player[myPlayer].inventory[num127].SetDefaults(0, false);
                                                        }
                                                        if (netMode == 1)
                                                        {
                                                            NetMessage.SendData(0x20, -1, -1, "", player[myPlayer].chest, (float) num126, 0f, 0f, 0);
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                    else if (player[myPlayer].chest == -3)
                                    {
                                        for (int num129 = 0; num129 < 20; num129++)
                                        {
                                            if ((player[myPlayer].bank2[num129].type > 0) && (player[myPlayer].bank2[num129].stack < player[myPlayer].bank2[num129].maxStack))
                                            {
                                                for (int num130 = 0; num130 < 0x2c; num130++)
                                                {
                                                    if (player[myPlayer].bank2[num129].IsTheSameAs(player[myPlayer].inventory[num130]))
                                                    {
                                                        int num131 = player[myPlayer].inventory[num130].stack;
                                                        if ((player[myPlayer].bank2[num129].stack + num131) > player[myPlayer].bank2[num129].maxStack)
                                                        {
                                                            num131 = player[myPlayer].bank2[num129].maxStack - player[myPlayer].bank2[num129].stack;
                                                        }
                                                        PlaySound(7, -1, -1, 1);
                                                        Item item29 = player[myPlayer].bank2[num129];
                                                        item29.stack += num131;
                                                        Item item30 = player[myPlayer].inventory[num130];
                                                        item30.stack -= num131;
                                                        BankCoins();
                                                        if (player[myPlayer].inventory[num130].stack == 0)
                                                        {
                                                            player[myPlayer].inventory[num130].SetDefaults(0, false);
                                                        }
                                                        else if (player[myPlayer].bank2[num129].type == 0)
                                                        {
                                                            player[myPlayer].bank2[num129] = (Item) player[myPlayer].inventory[num130].Clone();
                                                            player[myPlayer].inventory[num130].SetDefaults(0, false);
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                    else
                                    {
                                        for (int num132 = 0; num132 < 20; num132++)
                                        {
                                            if ((player[myPlayer].bank[num132].type > 0) && (player[myPlayer].bank[num132].stack < player[myPlayer].bank[num132].maxStack))
                                            {
                                                for (int num133 = 0; num133 < 0x2c; num133++)
                                                {
                                                    if (player[myPlayer].bank[num132].IsTheSameAs(player[myPlayer].inventory[num133]))
                                                    {
                                                        int num134 = player[myPlayer].inventory[num133].stack;
                                                        if ((player[myPlayer].bank[num132].stack + num134) > player[myPlayer].bank[num132].maxStack)
                                                        {
                                                            num134 = player[myPlayer].bank[num132].maxStack - player[myPlayer].bank[num132].stack;
                                                        }
                                                        PlaySound(7, -1, -1, 1);
                                                        Item item31 = player[myPlayer].bank[num132];
                                                        item31.stack += num134;
                                                        Item item32 = player[myPlayer].inventory[num133];
                                                        item32.stack -= num134;
                                                        BankCoins();
                                                        if (player[myPlayer].inventory[num133].stack == 0)
                                                        {
                                                            player[myPlayer].inventory[num133].SetDefaults(0, false);
                                                        }
                                                        else if (player[myPlayer].bank[num132].type == 0)
                                                        {
                                                            player[myPlayer].bank[num132] = (Item) player[myPlayer].inventory[num133].Clone();
                                                            player[myPlayer].inventory[num133].SetDefaults(0, false);
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                            else
                            {
                                chestLootScale -= 0.05f;
                                switch (num111)
                                {
                                    case 0:
                                        this.chestLootHover = false;
                                        goto Label_98A5;

                                    case 1:
                                        this.chestDepositHover = false;
                                        goto Label_98A5;

                                    default:
                                        this.chestStackHover = false;
                                        goto Label_98A5;
                                }
                            }
                        Label_98A5:
                            if (chestLootScale < 0.75)
                            {
                                chestLootScale = 0.75f;
                            }
                            if (chestLootScale > 1f)
                            {
                                chestLootScale = 1f;
                            }
                            switch (num111)
                            {
                                case 0:
                                    this.chestLootScale = chestLootScale;
                                    break;

                                case 1:
                                    this.chestDepositScale = chestLootScale;
                                    break;

                                default:
                                    this.chestStackScale = chestLootScale;
                                    break;
                            }
                        }
                    }
                    else
                    {
                        this.chestLootScale = 0.75f;
                        this.chestDepositScale = 0.75f;
                        this.chestStackScale = 0.75f;
                        this.chestLootHover = false;
                        this.chestDepositHover = false;
                        this.chestStackHover = false;
                    }
                    if (player[myPlayer].chest > -1)
                    {
                        vector10 = new Vector2();
                        this.spriteBatch.DrawString(fontMouseText, chestText, new Vector2(284f, 210f), new Color(mouseTextColor, mouseTextColor, mouseTextColor, mouseTextColor), 0f, vector10, (float) 1f, SpriteEffects.None, 0f);
                        Main.inventoryScale = 0.75f;
                        if (((mouseState.X > 0x49) && (mouseState.X < ((int) (73f + (280f * Main.inventoryScale))))) && ((mouseState.Y > 210) && (mouseState.Y < ((int) (210f + (224f * Main.inventoryScale))))))
                        {
                            player[myPlayer].mouseInterface = true;
                        }
                        for (int num135 = 0; num135 < 5; num135++)
                        {
                            for (int num136 = 0; num136 < 4; num136++)
                            {
                                int num137 = (int) (73f + ((num135 * 0x38) * Main.inventoryScale));
                                int num138 = (int) (210f + ((num136 * 0x38) * Main.inventoryScale));
                                int num139 = num135 + (num136 * 5);
                                Color color18 = new Color(100, 100, 100, 100);
                                if (((mouseState.X >= num137) && (mouseState.X <= (num137 + (inventoryBackTexture.Width * Main.inventoryScale)))) && ((mouseState.Y >= num138) && (mouseState.Y <= (num138 + (inventoryBackTexture.Height * Main.inventoryScale)))))
                                {
                                    player[myPlayer].mouseInterface = true;
                                    if (mouseLeftRelease && (mouseState.LeftButton == ButtonState.Pressed))
                                    {
                                        if ((player[myPlayer].selectedItem != num139) || (player[myPlayer].itemAnimation <= 0))
                                        {
                                            Item item8 = Main.mouseItem;
                                            Main.mouseItem = chest[player[myPlayer].chest].item[num139];
                                            chest[player[myPlayer].chest].item[num139] = item8;
                                            if ((chest[player[myPlayer].chest].item[num139].type == 0) || (chest[player[myPlayer].chest].item[num139].stack < 1))
                                            {
                                                chest[player[myPlayer].chest].item[num139] = new Item();
                                            }
                                            if ((Main.mouseItem.IsTheSameAs(chest[player[myPlayer].chest].item[num139]) && (chest[player[myPlayer].chest].item[num139].stack != chest[player[myPlayer].chest].item[num139].maxStack)) && (Main.mouseItem.stack != Main.mouseItem.maxStack))
                                            {
                                                if ((Main.mouseItem.stack + chest[player[myPlayer].chest].item[num139].stack) <= Main.mouseItem.maxStack)
                                                {
                                                    Item item33 = chest[player[myPlayer].chest].item[num139];
                                                    item33.stack += Main.mouseItem.stack;
                                                    Main.mouseItem.stack = 0;
                                                }
                                                else
                                                {
                                                    int num140 = Main.mouseItem.maxStack - chest[player[myPlayer].chest].item[num139].stack;
                                                    Item item34 = chest[player[myPlayer].chest].item[num139];
                                                    item34.stack += num140;
                                                    Main.mouseItem.stack -= num140;
                                                }
                                            }
                                            if ((Main.mouseItem.type == 0) || (Main.mouseItem.stack < 1))
                                            {
                                                Main.mouseItem = new Item();
                                            }
                                            if ((Main.mouseItem.type > 0) || (chest[player[myPlayer].chest].item[num139].type > 0))
                                            {
                                                Recipe.FindRecipes();
                                                PlaySound(7, -1, -1, 1);
                                            }
                                            if (netMode == 1)
                                            {
                                                NetMessage.SendData(0x20, -1, -1, "", player[myPlayer].chest, (float) num139, 0f, 0f, 0);
                                            }
                                        }
                                    }
                                    else if (((mouseState.RightButton == ButtonState.Pressed) && mouseRightRelease) && (chest[player[myPlayer].chest].item[num139].maxStack == 1))
                                    {
                                        chest[player[myPlayer].chest].item[num139] = armorSwap(chest[player[myPlayer].chest].item[num139]);
                                        if (netMode == 1)
                                        {
                                            NetMessage.SendData(0x20, -1, -1, "", player[myPlayer].chest, (float) num139, 0f, 0f, 0);
                                        }
                                    }
                                    else if (((((stackSplit <= 1) && (mouseState.RightButton == ButtonState.Pressed)) && (chest[player[myPlayer].chest].item[num139].maxStack > 1)) && (Main.mouseItem.IsTheSameAs(chest[player[myPlayer].chest].item[num139]) || (Main.mouseItem.type == 0))) && ((Main.mouseItem.stack < Main.mouseItem.maxStack) || (Main.mouseItem.type == 0)))
                                    {
                                        if (Main.mouseItem.type == 0)
                                        {
                                            Main.mouseItem = (Item) chest[player[myPlayer].chest].item[num139].Clone();
                                            Main.mouseItem.stack = 0;
                                        }
                                        Main.mouseItem.stack++;
                                        Item item35 = chest[player[myPlayer].chest].item[num139];
                                        item35.stack--;
                                        if (chest[player[myPlayer].chest].item[num139].stack <= 0)
                                        {
                                            chest[player[myPlayer].chest].item[num139] = new Item();
                                        }
                                        Recipe.FindRecipes();
                                        soundInstanceMenuTick.Stop();
                                        soundInstanceMenuTick = soundMenuTick.CreateInstance();
                                        PlaySound(12, -1, -1, 1);
                                        if (stackSplit == 0)
                                        {
                                            stackSplit = 15;
                                        }
                                        else
                                        {
                                            stackSplit = stackDelay;
                                        }
                                        if (netMode == 1)
                                        {
                                            NetMessage.SendData(0x20, -1, -1, "", player[myPlayer].chest, (float) num139, 0f, 0f, 0);
                                        }
                                    }
                                    cursorText = chest[player[myPlayer].chest].item[num139].name;
                                    toolTip = (Item) chest[player[myPlayer].chest].item[num139].Clone();
                                    if (chest[player[myPlayer].chest].item[num139].stack > 1)
                                    {
                                        obj2 = cursorText;
                                        cursorText = string.Concat(new object[] { obj2, " (", chest[player[myPlayer].chest].item[num139].stack, ")" });
                                    }
                                }
                                vector10 = new Vector2();
                                this.spriteBatch.Draw(inventoryBack5Texture, new Vector2((float) num137, (float) num138), new Rectangle(0, 0, inventoryBackTexture.Width, inventoryBackTexture.Height), color2, 0f, vector10, Main.inventoryScale, SpriteEffects.None, 0f);
                                color18 = Color.White;
                                if ((chest[player[myPlayer].chest].item[num139].type > 0) && (chest[player[myPlayer].chest].item[num139].stack > 0))
                                {
                                    float num141 = 1f;
                                    if ((itemTexture[chest[player[myPlayer].chest].item[num139].type].Width > 0x20) || (itemTexture[chest[player[myPlayer].chest].item[num139].type].Height > 0x20))
                                    {
                                        if (itemTexture[chest[player[myPlayer].chest].item[num139].type].Width > itemTexture[chest[player[myPlayer].chest].item[num139].type].Height)
                                        {
                                            num141 = 32f / ((float) itemTexture[chest[player[myPlayer].chest].item[num139].type].Width);
                                        }
                                        else
                                        {
                                            num141 = 32f / ((float) itemTexture[chest[player[myPlayer].chest].item[num139].type].Height);
                                        }
                                    }
                                    num141 *= Main.inventoryScale;
                                    vector10 = new Vector2();
                                    this.spriteBatch.Draw(itemTexture[chest[player[myPlayer].chest].item[num139].type], new Vector2((num137 + (26f * Main.inventoryScale)) - ((itemTexture[chest[player[myPlayer].chest].item[num139].type].Width * 0.5f) * num141), (num138 + (26f * Main.inventoryScale)) - ((itemTexture[chest[player[myPlayer].chest].item[num139].type].Height * 0.5f) * num141)), new Rectangle(0, 0, itemTexture[chest[player[myPlayer].chest].item[num139].type].Width, itemTexture[chest[player[myPlayer].chest].item[num139].type].Height), chest[player[myPlayer].chest].item[num139].GetAlpha(color18), 0f, vector10, num141, SpriteEffects.None, 0f);
                                    color30 = new Color();
                                    if (chest[player[myPlayer].chest].item[num139].color != color30)
                                    {
                                        vector10 = new Vector2();
                                        this.spriteBatch.Draw(itemTexture[chest[player[myPlayer].chest].item[num139].type], new Vector2((num137 + (26f * Main.inventoryScale)) - ((itemTexture[chest[player[myPlayer].chest].item[num139].type].Width * 0.5f) * num141), (num138 + (26f * Main.inventoryScale)) - ((itemTexture[chest[player[myPlayer].chest].item[num139].type].Height * 0.5f) * num141)), new Rectangle(0, 0, itemTexture[chest[player[myPlayer].chest].item[num139].type].Width, itemTexture[chest[player[myPlayer].chest].item[num139].type].Height), chest[player[myPlayer].chest].item[num139].GetColor(color18), 0f, vector10, num141, SpriteEffects.None, 0f);
                                    }
                                    if (chest[player[myPlayer].chest].item[num139].stack > 1)
                                    {
                                        vector10 = new Vector2();
                                        this.spriteBatch.DrawString(fontItemStack, (chest[player[myPlayer].chest].item[num139].stack).ToString(), new Vector2(num137 + (10f * Main.inventoryScale), num138 + (26f * Main.inventoryScale)), color18, 0f, vector10, num141, SpriteEffects.None, 0f);
                                    }
                                }
                            }
                        }
                    }
                    if (player[myPlayer].chest == -2)
                    {
                        vector10 = new Vector2();
                        this.spriteBatch.DrawString(fontMouseText, "Piggy Bank", new Vector2(284f, 210f), new Color(mouseTextColor, mouseTextColor, mouseTextColor, mouseTextColor), 0f, vector10, (float) 1f, SpriteEffects.None, 0f);
                        Main.inventoryScale = 0.75f;
                        if (((mouseState.X > 0x49) && (mouseState.X < ((int) (73f + (280f * Main.inventoryScale))))) && ((mouseState.Y > 210) && (mouseState.Y < ((int) (210f + (224f * Main.inventoryScale))))))
                        {
                            player[myPlayer].mouseInterface = true;
                        }
                        for (int num142 = 0; num142 < 5; num142++)
                        {
                            for (int num143 = 0; num143 < 4; num143++)
                            {
                                int num144 = (int) (73f + ((num142 * 0x38) * Main.inventoryScale));
                                int num145 = (int) (210f + ((num143 * 0x38) * Main.inventoryScale));
                                int num146 = num142 + (num143 * 5);
                                Color color19 = new Color(100, 100, 100, 100);
                                if (((mouseState.X >= num144) && (mouseState.X <= (num144 + (inventoryBackTexture.Width * Main.inventoryScale)))) && ((mouseState.Y >= num145) && (mouseState.Y <= (num145 + (inventoryBackTexture.Height * Main.inventoryScale)))))
                                {
                                    player[myPlayer].mouseInterface = true;
                                    if (mouseLeftRelease && (mouseState.LeftButton == ButtonState.Pressed))
                                    {
                                        if ((player[myPlayer].selectedItem != num146) || (player[myPlayer].itemAnimation <= 0))
                                        {
                                            Item item9 = Main.mouseItem;
                                            Main.mouseItem = player[myPlayer].bank[num146];
                                            player[myPlayer].bank[num146] = item9;
                                            if ((player[myPlayer].bank[num146].type == 0) || (player[myPlayer].bank[num146].stack < 1))
                                            {
                                                player[myPlayer].bank[num146] = new Item();
                                            }
                                            if ((Main.mouseItem.IsTheSameAs(player[myPlayer].bank[num146]) && (player[myPlayer].bank[num146].stack != player[myPlayer].bank[num146].maxStack)) && (Main.mouseItem.stack != Main.mouseItem.maxStack))
                                            {
                                                if ((Main.mouseItem.stack + player[myPlayer].bank[num146].stack) <= Main.mouseItem.maxStack)
                                                {
                                                    Item item36 = player[myPlayer].bank[num146];
                                                    item36.stack += Main.mouseItem.stack;
                                                    Main.mouseItem.stack = 0;
                                                }
                                                else
                                                {
                                                    int num147 = Main.mouseItem.maxStack - player[myPlayer].bank[num146].stack;
                                                    Item item37 = player[myPlayer].bank[num146];
                                                    item37.stack += num147;
                                                    Main.mouseItem.stack -= num147;
                                                }
                                            }
                                            if ((Main.mouseItem.type == 0) || (Main.mouseItem.stack < 1))
                                            {
                                                Main.mouseItem = new Item();
                                            }
                                            if ((Main.mouseItem.type > 0) || (player[myPlayer].bank[num146].type > 0))
                                            {
                                                Recipe.FindRecipes();
                                                PlaySound(7, -1, -1, 1);
                                            }
                                        }
                                    }
                                    else if (((mouseState.RightButton == ButtonState.Pressed) && mouseRightRelease) && (player[myPlayer].bank[num146].maxStack == 1))
                                    {
                                        player[myPlayer].bank[num146] = armorSwap(player[myPlayer].bank[num146]);
                                    }
                                    else if (((((stackSplit <= 1) && (mouseState.RightButton == ButtonState.Pressed)) && (player[myPlayer].bank[num146].maxStack > 1)) && (Main.mouseItem.IsTheSameAs(player[myPlayer].bank[num146]) || (Main.mouseItem.type == 0))) && ((Main.mouseItem.stack < Main.mouseItem.maxStack) || (Main.mouseItem.type == 0)))
                                    {
                                        if (Main.mouseItem.type == 0)
                                        {
                                            Main.mouseItem = (Item) player[myPlayer].bank[num146].Clone();
                                            Main.mouseItem.stack = 0;
                                        }
                                        Main.mouseItem.stack++;
                                        Item item38 = player[myPlayer].bank[num146];
                                        item38.stack--;
                                        if (player[myPlayer].bank[num146].stack <= 0)
                                        {
                                            player[myPlayer].bank[num146] = new Item();
                                        }
                                        Recipe.FindRecipes();
                                        soundInstanceMenuTick.Stop();
                                        soundInstanceMenuTick = soundMenuTick.CreateInstance();
                                        PlaySound(12, -1, -1, 1);
                                        if (stackSplit == 0)
                                        {
                                            stackSplit = 15;
                                        }
                                        else
                                        {
                                            stackSplit = stackDelay;
                                        }
                                    }
                                    cursorText = player[myPlayer].bank[num146].name;
                                    toolTip = (Item) player[myPlayer].bank[num146].Clone();
                                    if (player[myPlayer].bank[num146].stack > 1)
                                    {
                                        obj2 = cursorText;
                                        cursorText = string.Concat(new object[] { obj2, " (", player[myPlayer].bank[num146].stack, ")" });
                                    }
                                }
                                vector10 = new Vector2();
                                this.spriteBatch.Draw(inventoryBack2Texture, new Vector2((float) num144, (float) num145), new Rectangle(0, 0, inventoryBackTexture.Width, inventoryBackTexture.Height), color2, 0f, vector10, Main.inventoryScale, SpriteEffects.None, 0f);
                                color19 = Color.White;
                                if ((player[myPlayer].bank[num146].type > 0) && (player[myPlayer].bank[num146].stack > 0))
                                {
                                    float num148 = 1f;
                                    if ((itemTexture[player[myPlayer].bank[num146].type].Width > 0x20) || (itemTexture[player[myPlayer].bank[num146].type].Height > 0x20))
                                    {
                                        if (itemTexture[player[myPlayer].bank[num146].type].Width > itemTexture[player[myPlayer].bank[num146].type].Height)
                                        {
                                            num148 = 32f / ((float) itemTexture[player[myPlayer].bank[num146].type].Width);
                                        }
                                        else
                                        {
                                            num148 = 32f / ((float) itemTexture[player[myPlayer].bank[num146].type].Height);
                                        }
                                    }
                                    num148 *= Main.inventoryScale;
                                    vector10 = new Vector2();
                                    this.spriteBatch.Draw(itemTexture[player[myPlayer].bank[num146].type], new Vector2((num144 + (26f * Main.inventoryScale)) - ((itemTexture[player[myPlayer].bank[num146].type].Width * 0.5f) * num148), (num145 + (26f * Main.inventoryScale)) - ((itemTexture[player[myPlayer].bank[num146].type].Height * 0.5f) * num148)), new Rectangle(0, 0, itemTexture[player[myPlayer].bank[num146].type].Width, itemTexture[player[myPlayer].bank[num146].type].Height), player[myPlayer].bank[num146].GetAlpha(color19), 0f, vector10, num148, SpriteEffects.None, 0f);
                                    color30 = new Color();
                                    if (player[myPlayer].bank[num146].color != color30)
                                    {
                                        vector10 = new Vector2();
                                        this.spriteBatch.Draw(itemTexture[player[myPlayer].bank[num146].type], new Vector2((num144 + (26f * Main.inventoryScale)) - ((itemTexture[player[myPlayer].bank[num146].type].Width * 0.5f) * num148), (num145 + (26f * Main.inventoryScale)) - ((itemTexture[player[myPlayer].bank[num146].type].Height * 0.5f) * num148)), new Rectangle(0, 0, itemTexture[player[myPlayer].bank[num146].type].Width, itemTexture[player[myPlayer].bank[num146].type].Height), player[myPlayer].bank[num146].GetColor(color19), 0f, vector10, num148, SpriteEffects.None, 0f);
                                    }
                                    if (player[myPlayer].bank[num146].stack > 1)
                                    {
                                        vector10 = new Vector2();
                                        this.spriteBatch.DrawString(fontItemStack, (player[myPlayer].bank[num146].stack).ToString(), new Vector2(num144 + (10f * Main.inventoryScale), num145 + (26f * Main.inventoryScale)), color19, 0f, vector10, num148, SpriteEffects.None, 0f);
                                    }
                                }
                            }
                        }
                    }
                    if (player[myPlayer].chest == -3)
                    {
                        vector10 = new Vector2();
                        this.spriteBatch.DrawString(fontMouseText, "Safe", new Vector2(284f, 210f), new Color(mouseTextColor, mouseTextColor, mouseTextColor, mouseTextColor), 0f, vector10, (float) 1f, SpriteEffects.None, 0f);
                        Main.inventoryScale = 0.75f;
                        if (((mouseState.X > 0x49) && (mouseState.X < ((int) (73f + (280f * Main.inventoryScale))))) && ((mouseState.Y > 210) && (mouseState.Y < ((int) (210f + (224f * Main.inventoryScale))))))
                        {
                            player[myPlayer].mouseInterface = true;
                        }
                        for (int num149 = 0; num149 < 5; num149++)
                        {
                            for (int num150 = 0; num150 < 4; num150++)
                            {
                                int num151 = (int) (73f + ((num149 * 0x38) * Main.inventoryScale));
                                int num152 = (int) (210f + ((num150 * 0x38) * Main.inventoryScale));
                                int num153 = num149 + (num150 * 5);
                                Color color20 = new Color(100, 100, 100, 100);
                                if (((mouseState.X >= num151) && (mouseState.X <= (num151 + (inventoryBackTexture.Width * Main.inventoryScale)))) && ((mouseState.Y >= num152) && (mouseState.Y <= (num152 + (inventoryBackTexture.Height * Main.inventoryScale)))))
                                {
                                    player[myPlayer].mouseInterface = true;
                                    if (mouseLeftRelease && (mouseState.LeftButton == ButtonState.Pressed))
                                    {
                                        if ((player[myPlayer].selectedItem != num153) || (player[myPlayer].itemAnimation <= 0))
                                        {
                                            Item item10 = Main.mouseItem;
                                            Main.mouseItem = player[myPlayer].bank2[num153];
                                            player[myPlayer].bank2[num153] = item10;
                                            if ((player[myPlayer].bank2[num153].type == 0) || (player[myPlayer].bank2[num153].stack < 1))
                                            {
                                                player[myPlayer].bank2[num153] = new Item();
                                            }
                                            if ((Main.mouseItem.IsTheSameAs(player[myPlayer].bank2[num153]) && (player[myPlayer].bank2[num153].stack != player[myPlayer].bank2[num153].maxStack)) && (Main.mouseItem.stack != Main.mouseItem.maxStack))
                                            {
                                                if ((Main.mouseItem.stack + player[myPlayer].bank2[num153].stack) <= Main.mouseItem.maxStack)
                                                {
                                                    Item item39 = player[myPlayer].bank2[num153];
                                                    item39.stack += Main.mouseItem.stack;
                                                    Main.mouseItem.stack = 0;
                                                }
                                                else
                                                {
                                                    int num154 = Main.mouseItem.maxStack - player[myPlayer].bank2[num153].stack;
                                                    Item item40 = player[myPlayer].bank2[num153];
                                                    item40.stack += num154;
                                                    Main.mouseItem.stack -= num154;
                                                }
                                            }
                                            if ((Main.mouseItem.type == 0) || (Main.mouseItem.stack < 1))
                                            {
                                                Main.mouseItem = new Item();
                                            }
                                            if ((Main.mouseItem.type > 0) || (player[myPlayer].bank2[num153].type > 0))
                                            {
                                                Recipe.FindRecipes();
                                                PlaySound(7, -1, -1, 1);
                                            }
                                        }
                                    }
                                    else if (((mouseState.RightButton == ButtonState.Pressed) && mouseRightRelease) && (player[myPlayer].bank2[num153].maxStack == 1))
                                    {
                                        player[myPlayer].bank2[num153] = armorSwap(player[myPlayer].bank2[num153]);
                                    }
                                    else if (((((stackSplit <= 1) && (mouseState.RightButton == ButtonState.Pressed)) && (player[myPlayer].bank2[num153].maxStack > 1)) && (Main.mouseItem.IsTheSameAs(player[myPlayer].bank2[num153]) || (Main.mouseItem.type == 0))) && ((Main.mouseItem.stack < Main.mouseItem.maxStack) || (Main.mouseItem.type == 0)))
                                    {
                                        if (Main.mouseItem.type == 0)
                                        {
                                            Main.mouseItem = (Item) player[myPlayer].bank2[num153].Clone();
                                            Main.mouseItem.stack = 0;
                                        }
                                        Main.mouseItem.stack++;
                                        Item item41 = player[myPlayer].bank2[num153];
                                        item41.stack--;
                                        if (player[myPlayer].bank2[num153].stack <= 0)
                                        {
                                            player[myPlayer].bank2[num153] = new Item();
                                        }
                                        Recipe.FindRecipes();
                                        soundInstanceMenuTick.Stop();
                                        soundInstanceMenuTick = soundMenuTick.CreateInstance();
                                        PlaySound(12, -1, -1, 1);
                                        if (stackSplit == 0)
                                        {
                                            stackSplit = 15;
                                        }
                                        else
                                        {
                                            stackSplit = stackDelay;
                                        }
                                    }
                                    cursorText = player[myPlayer].bank2[num153].name;
                                    toolTip = (Item) player[myPlayer].bank2[num153].Clone();
                                    if (player[myPlayer].bank2[num153].stack > 1)
                                    {
                                        obj2 = cursorText;
                                        cursorText = string.Concat(new object[] { obj2, " (", player[myPlayer].bank2[num153].stack, ")" });
                                    }
                                }
                                vector10 = new Vector2();
                                this.spriteBatch.Draw(inventoryBack2Texture, new Vector2((float) num151, (float) num152), new Rectangle(0, 0, inventoryBackTexture.Width, inventoryBackTexture.Height), color2, 0f, vector10, Main.inventoryScale, SpriteEffects.None, 0f);
                                color20 = Color.White;
                                if ((player[myPlayer].bank2[num153].type > 0) && (player[myPlayer].bank2[num153].stack > 0))
                                {
                                    float num155 = 1f;
                                    if ((itemTexture[player[myPlayer].bank2[num153].type].Width > 0x20) || (itemTexture[player[myPlayer].bank2[num153].type].Height > 0x20))
                                    {
                                        if (itemTexture[player[myPlayer].bank2[num153].type].Width > itemTexture[player[myPlayer].bank2[num153].type].Height)
                                        {
                                            num155 = 32f / ((float) itemTexture[player[myPlayer].bank2[num153].type].Width);
                                        }
                                        else
                                        {
                                            num155 = 32f / ((float) itemTexture[player[myPlayer].bank2[num153].type].Height);
                                        }
                                    }
                                    num155 *= Main.inventoryScale;
                                    vector10 = new Vector2();
                                    this.spriteBatch.Draw(itemTexture[player[myPlayer].bank2[num153].type], new Vector2((num151 + (26f * Main.inventoryScale)) - ((itemTexture[player[myPlayer].bank2[num153].type].Width * 0.5f) * num155), (num152 + (26f * Main.inventoryScale)) - ((itemTexture[player[myPlayer].bank2[num153].type].Height * 0.5f) * num155)), new Rectangle(0, 0, itemTexture[player[myPlayer].bank2[num153].type].Width, itemTexture[player[myPlayer].bank2[num153].type].Height), player[myPlayer].bank2[num153].GetAlpha(color20), 0f, vector10, num155, SpriteEffects.None, 0f);
                                    color30 = new Color();
                                    if (player[myPlayer].bank2[num153].color != color30)
                                    {
                                        vector10 = new Vector2();
                                        this.spriteBatch.Draw(itemTexture[player[myPlayer].bank2[num153].type], new Vector2((num151 + (26f * Main.inventoryScale)) - ((itemTexture[player[myPlayer].bank2[num153].type].Width * 0.5f) * num155), (num152 + (26f * Main.inventoryScale)) - ((itemTexture[player[myPlayer].bank2[num153].type].Height * 0.5f) * num155)), new Rectangle(0, 0, itemTexture[player[myPlayer].bank2[num153].type].Width, itemTexture[player[myPlayer].bank2[num153].type].Height), player[myPlayer].bank2[num153].GetColor(color20), 0f, vector10, num155, SpriteEffects.None, 0f);
                                    }
                                    if (player[myPlayer].bank2[num153].stack > 1)
                                    {
                                        vector10 = new Vector2();
                                        this.spriteBatch.DrawString(fontItemStack, (player[myPlayer].bank2[num153].stack).ToString(), new Vector2(num151 + (10f * Main.inventoryScale), num152 + (26f * Main.inventoryScale)), color20, 0f, vector10, num155, SpriteEffects.None, 0f);
                                    }
                                }
                            }
                        }
                    }
                }
                if (playerInventory || player[myPlayer].ghost)
                {
                    string str14 = "Save & Exit";
                    if (netMode != 0)
                    {
                        str14 = "Disconnect";
                    }
                    Vector2 vector8 = fontDeathText.MeasureString(str14);
                    int num165 = screenWidth - 110;
                    int num166 = Main.screenHeight - 20;
                    if (mouseExit)
                    {
                        if (exitScale < 1f)
                        {
                            exitScale += 0.02f;
                        }
                    }
                    else if (exitScale > 0.8)
                    {
                        exitScale -= 0.02f;
                    }
                    for (int num167 = 0; num167 < 5; num167++)
                    {
                        int num168 = 0;
                        int num169 = 0;
                        Color color22 = Color.Black;
                        switch (num167)
                        {
                            case 0:
                                num168 = -2;
                                break;

                            case 1:
                                num168 = 2;
                                break;

                            case 2:
                                num169 = -2;
                                break;

                            case 3:
                                num169 = 2;
                                break;

                            case 4:
                                color22 = Color.White;
                                break;
                        }
                        this.spriteBatch.DrawString(fontDeathText, str14, new Vector2((float) (num165 + num168), (float) (num166 + num169)), color22, 0f, new Vector2(vector8.X / 2f, vector8.Y / 2f), (float) (exitScale - 0.2f), SpriteEffects.None, 0f);
                    }
                    if (((mouseState.X > (num165 - (vector8.X / 2f))) && (mouseState.X < (num165 + (vector8.X / 2f)))) && ((mouseState.Y > (num166 - (vector8.Y / 2f))) && (mouseState.Y < ((num166 + (vector8.Y / 2f)) - 10f))))
                    {
                        if (!mouseExit)
                        {
                            PlaySound(12, -1, -1, 1);
                        }
                        mouseExit = true;
                        player[myPlayer].mouseInterface = true;
                        if (mouseLeftRelease && (mouseState.LeftButton == ButtonState.Pressed))
                        {
                            menuMode = 10;
                            WorldGen.SaveAndQuit();
                        }
                    }
                    else
                    {
                        mouseExit = false;
                    }
                }
                if (!playerInventory && !player[myPlayer].ghost)
                {
                    string str15 = "Items";
                    if ((player[myPlayer].inventory[player[myPlayer].selectedItem].name != "") && (player[myPlayer].inventory[player[myPlayer].selectedItem].name != null))
                    {
                        str15 = player[myPlayer].inventory[player[myPlayer].selectedItem].name;
                    }
                    Vector2 vector9 = (Vector2) (fontMouseText.MeasureString(str15) / 2f);
                    vector10 = new Vector2();
                    this.spriteBatch.DrawString(fontMouseText, str15, new Vector2(236f - vector9.X, 0f), new Color(mouseTextColor, mouseTextColor, mouseTextColor, mouseTextColor), 0f, vector10, (float) 1f, SpriteEffects.None, 0f);
                    int num170 = 20;
                    float num171 = 1f;
                    for (int num172 = 0; num172 < 10; num172++)
                    {
                        if (num172 == player[myPlayer].selectedItem)
                        {
                            if (hotbarScale[num172] < 1f)
                            {
                                hotbarScale[num172] += 0.05f;
                            }
                        }
                        else if (hotbarScale[num172] > 0.75)
                        {
                            hotbarScale[num172] -= 0.05f;
                        }
                        float num173 = hotbarScale[num172];
                        int num174 = (int) (20f + (22f * (1f - num173)));
                        int num175 = (int) (75f + (150f * num173));
                        Color color23 = new Color(0xff, 0xff, 0xff, num175);
                        vector10 = new Vector2();
                        this.spriteBatch.Draw(inventoryBackTexture, new Vector2((float) num170, (float) num174), new Rectangle(0, 0, inventoryBackTexture.Width, inventoryBackTexture.Height), new Color(100, 100, 100, 100), 0f, vector10, num173, SpriteEffects.None, 0f);
                        if ((((mouseState.X >= num170) && (mouseState.X <= (num170 + (inventoryBackTexture.Width * hotbarScale[num172])))) && ((mouseState.Y >= num174) && (mouseState.Y <= (num174 + (inventoryBackTexture.Height * hotbarScale[num172]))))) && !player[myPlayer].channel)
                        {
                            if (!player[myPlayer].hbLocked)
                            {
                                player[myPlayer].mouseInterface = true;
                            }
                            if ((mouseState.LeftButton == ButtonState.Pressed) && !player[myPlayer].hbLocked)
                            {
                                player[myPlayer].changeItem = num172;
                            }
                            player[myPlayer].showItemIcon = false;
                            cursorText = player[myPlayer].inventory[num172].name;
                            if (player[myPlayer].inventory[num172].stack > 1)
                            {
                                obj2 = cursorText;
                                cursorText = string.Concat(new object[] { obj2, " (", player[myPlayer].inventory[num172].stack, ")" });
                            }
                            rare = player[myPlayer].inventory[num172].rare;
                        }
                        if ((player[myPlayer].inventory[num172].type > 0) && (player[myPlayer].inventory[num172].stack > 0))
                        {
                            num171 = 1f;
                            if ((itemTexture[player[myPlayer].inventory[num172].type].Width > 0x20) || (itemTexture[player[myPlayer].inventory[num172].type].Height > 0x20))
                            {
                                if (itemTexture[player[myPlayer].inventory[num172].type].Width > itemTexture[player[myPlayer].inventory[num172].type].Height)
                                {
                                    num171 = 32f / ((float) itemTexture[player[myPlayer].inventory[num172].type].Width);
                                }
                                else
                                {
                                    num171 = 32f / ((float) itemTexture[player[myPlayer].inventory[num172].type].Height);
                                }
                            }
                            num171 *= num173;
                            vector10 = new Vector2();
                            this.spriteBatch.Draw(itemTexture[player[myPlayer].inventory[num172].type], new Vector2((num170 + (26f * num173)) - ((itemTexture[player[myPlayer].inventory[num172].type].Width * 0.5f) * num171), (num174 + (26f * num173)) - ((itemTexture[player[myPlayer].inventory[num172].type].Height * 0.5f) * num171)), new Rectangle(0, 0, itemTexture[player[myPlayer].inventory[num172].type].Width, itemTexture[player[myPlayer].inventory[num172].type].Height), player[myPlayer].inventory[num172].GetAlpha(color23), 0f, vector10, num171, SpriteEffects.None, 0f);
                            color30 = new Color();
                            if (player[myPlayer].inventory[num172].color != color30)
                            {
                                vector10 = new Vector2();
                                this.spriteBatch.Draw(itemTexture[player[myPlayer].inventory[num172].type], new Vector2((num170 + (26f * num173)) - ((itemTexture[player[myPlayer].inventory[num172].type].Width * 0.5f) * num171), (num174 + (26f * num173)) - ((itemTexture[player[myPlayer].inventory[num172].type].Height * 0.5f) * num171)), new Rectangle(0, 0, itemTexture[player[myPlayer].inventory[num172].type].Width, itemTexture[player[myPlayer].inventory[num172].type].Height), player[myPlayer].inventory[num172].GetColor(color23), 0f, vector10, num171, SpriteEffects.None, 0f);
                            }
                            if (player[myPlayer].inventory[num172].stack > 1)
                            {
                                vector10 = new Vector2();
                                this.spriteBatch.DrawString(fontItemStack, (player[myPlayer].inventory[num172].stack).ToString(), new Vector2(num170 + (10f * num173), num174 + (26f * num173)), color23, 0f, vector10, num171, SpriteEffects.None, 0f);
                            }
                            if (player[myPlayer].inventory[num172].useAmmo > 0)
                            {
                                int useAmmo = player[myPlayer].inventory[num172].useAmmo;
                                int num177 = 0;
                                for (int num178 = 0; num178 < 40; num178++)
                                {
                                    if ((num178 < 4) && (player[myPlayer].ammo[num178].ammo == useAmmo))
                                    {
                                        num177 += player[myPlayer].ammo[num178].stack;
                                    }
                                    if (player[myPlayer].inventory[num178].ammo == useAmmo)
                                    {
                                        num177 += player[myPlayer].inventory[num178].stack;
                                    }
                                }
                                vector10 = new Vector2();
                                this.spriteBatch.DrawString(fontItemStack, num177.ToString(), new Vector2(num170 + (8f * num173), num174 + (30f * num173)), color23, 0f, vector10, (float) (num173 * 0.8f), SpriteEffects.None, 0f);
                            }
                            string str16 = (num172.ToString() + 1);
                            if (str16 == "10")
                            {
                                str16 = "0";
                            }
                            vector10 = new Vector2();
                            this.spriteBatch.DrawString(fontItemStack, str16, new Vector2(num170 + (8f * hotbarScale[num172]), num174 + (4f * hotbarScale[num172])), new Color(color23.R / 2, color23.G / 2, color23.B / 2, color23.A / 2), 0f, vector10, num171, SpriteEffects.None, 0f);
                            if (player[myPlayer].inventory[num172].potion)
                            {
                                Color alpha = player[myPlayer].inventory[num172].GetAlpha(color23);
                                float num179 = ((float) player[myPlayer].potionDelay) / ((float) Item.potionDelay);
                                float num180 = alpha.R * num179;
                                float num181 = alpha.G * num179;
                                float num182 = alpha.B * num179;
                                float num183 = alpha.A * num179;
                                alpha = new Color((int) ((byte) num180), (int) ((byte) num181), (int) ((byte) num182), (int) ((byte) num183));
                                vector10 = new Vector2();
                                this.spriteBatch.Draw(cdTexture, new Vector2((num170 + (26f * hotbarScale[num172])) - ((cdTexture.Width * 0.5f) * num171), (num174 + (26f * hotbarScale[num172])) - ((cdTexture.Height * 0.5f) * num171)), new Rectangle(0, 0, cdTexture.Width, cdTexture.Height), alpha, 0f, vector10, num171, SpriteEffects.None, 0f);
                            }
                        }
                        num170 += ((int) (inventoryBackTexture.Width * hotbarScale[num172])) + 4;
                    }
                }
                if (((cursorText != null) && (cursorText != "")) && (Main.mouseItem.type == 0))
                {
                    player[myPlayer].showItemIcon = false;
                    this.MouseText(cursorText, rare, 0);
                    flag = true;
                }
                if (chatMode)
                {
                    this.textBlinkerCount++;
                    if (this.textBlinkerCount >= 20)
                    {
                        if (this.textBlinkerState == 0)
                        {
                            this.textBlinkerState = 1;
                        }
                        else
                        {
                            this.textBlinkerState = 0;
                        }
                        this.textBlinkerCount = 0;
                    }
                    string chatText = Main.chatText;
                    if (this.textBlinkerState == 1)
                    {
                        chatText = chatText + "|";
                    }
                    vector10 = new Vector2();
                    this.spriteBatch.Draw(textBackTexture, new Vector2(78f, (float) (Main.screenHeight - 0x24)), new Rectangle(0, 0, textBackTexture.Width, textBackTexture.Height), new Color(100, 100, 100, 100), 0f, vector10, (float) 1f, SpriteEffects.None, 0f);
                    for (int num184 = 0; num184 < 5; num184++)
                    {
                        int num185 = 0;
                        int num186 = 0;
                        Color color25 = Color.Black;
                        switch (num184)
                        {
                            case 0:
                                num185 = -2;
                                break;

                            case 1:
                                num185 = 2;
                                break;

                            case 2:
                                num186 = -2;
                                break;

                            case 3:
                                num186 = 2;
                                break;

                            case 4:
                                color25 = new Color((int) mouseTextColor, (int) mouseTextColor, (int) mouseTextColor, (int) mouseTextColor);
                                break;
                        }
                        vector10 = new Vector2();
                        this.spriteBatch.DrawString(fontMouseText, chatText, new Vector2((float) (0x58 + num185), (float) ((Main.screenHeight - 30) + num186)), color25, 0f, vector10, (float) 1f, SpriteEffects.None, 0f);
                    }
                }
                for (int k = 0; k < numChatLines; k++)
                {
                    if (chatMode || (chatLine[k].showTime > 0))
                    {
                        float num188 = ((float) mouseTextColor) / 255f;
                        for (int num189 = 0; num189 < 5; num189++)
                        {
                            int num190 = 0;
                            int num191 = 0;
                            Color color26 = Color.Black;
                            switch (num189)
                            {
                                case 0:
                                    num190 = -2;
                                    break;

                                case 1:
                                    num190 = 2;
                                    break;

                                case 2:
                                    num191 = -2;
                                    break;

                                case 3:
                                    num191 = 2;
                                    break;

                                case 4:
                                    color26 = new Color((int) ((byte) (chatLine[k].color.R * num188)), (int) ((byte) (chatLine[k].color.G * num188)), (int) ((byte) (chatLine[k].color.B * num188)), (int) mouseTextColor);
                                    break;
                            }
                            vector10 = new Vector2();
                            this.spriteBatch.DrawString(fontMouseText, chatLine[k].text, new Vector2((float) (0x58 + num190), (float) ((((Main.screenHeight - 30) + num191) - 0x1c) - (k * 0x15))), color26, 0f, vector10, (float) 1f, SpriteEffects.None, 0f);
                        }
                    }
                }
                if (player[myPlayer].dead)
                {
                    string str18 = "You were slain...";
                    vector10 = new Vector2();
                    this.spriteBatch.DrawString(fontDeathText, str18, new Vector2((float) ((screenWidth / 2) - (str18.Length * 10)), (float) ((Main.screenHeight / 2) - 20)), player[myPlayer].GetDeathAlpha(new Color(0, 0, 0, 0)), 0f, vector10, (float) 1f, SpriteEffects.None, 0f);
                }
                vector10 = new Vector2();
                this.spriteBatch.Draw(cursorTexture, new Vector2((float) (mouseState.X + 1), (float) (mouseState.Y + 1)), new Rectangle(0, 0, cursorTexture.Width, cursorTexture.Height), new Color((int) (cursorColor.R * 0.2f), (int) (cursorColor.G * 0.2f), (int) (cursorColor.B * 0.2f), (int) (cursorColor.A * 0.5f)), 0f, vector10, (float) (cursorScale * 1.1f), SpriteEffects.None, 0f);
                vector10 = new Vector2();
                this.spriteBatch.Draw(cursorTexture, new Vector2((float) mouseState.X, (float) mouseState.Y), new Rectangle(0, 0, cursorTexture.Width, cursorTexture.Height), cursorColor, 0f, vector10, cursorScale, SpriteEffects.None, 0f);
                if ((Main.mouseItem.type > 0) && (Main.mouseItem.stack > 0))
                {
                    player[myPlayer].showItemIcon = false;
                    player[myPlayer].showItemIcon2 = 0;
                    flag = true;
                    float num192 = 1f;
                    if ((itemTexture[Main.mouseItem.type].Width > 0x20) || (itemTexture[Main.mouseItem.type].Height > 0x20))
                    {
                        if (itemTexture[Main.mouseItem.type].Width > itemTexture[Main.mouseItem.type].Height)
                        {
                            num192 = 32f / ((float) itemTexture[Main.mouseItem.type].Width);
                        }
                        else
                        {
                            num192 = 32f / ((float) itemTexture[Main.mouseItem.type].Height);
                        }
                    }
                    float num193 = 1f;
                    Color color27 = Color.White;
                    num192 *= num193;
                    vector10 = new Vector2();
                    this.spriteBatch.Draw(itemTexture[Main.mouseItem.type], new Vector2((mouseState.X + (26f * num193)) - ((itemTexture[Main.mouseItem.type].Width * 0.5f) * num192), (mouseState.Y + (26f * num193)) - ((itemTexture[Main.mouseItem.type].Height * 0.5f) * num192)), new Rectangle(0, 0, itemTexture[Main.mouseItem.type].Width, itemTexture[Main.mouseItem.type].Height), Main.mouseItem.GetAlpha(color27), 0f, vector10, num192, SpriteEffects.None, 0f);
                    color30 = new Color();
                    if (Main.mouseItem.color != color30)
                    {
                        vector10 = new Vector2();
                        this.spriteBatch.Draw(itemTexture[Main.mouseItem.type], new Vector2((mouseState.X + (26f * num193)) - ((itemTexture[Main.mouseItem.type].Width * 0.5f) * num192), (mouseState.Y + (26f * num193)) - ((itemTexture[Main.mouseItem.type].Height * 0.5f) * num192)), new Rectangle(0, 0, itemTexture[Main.mouseItem.type].Width, itemTexture[Main.mouseItem.type].Height), Main.mouseItem.GetColor(color27), 0f, vector10, num192, SpriteEffects.None, 0f);
                    }
                    if (Main.mouseItem.stack > 1)
                    {
                        vector10 = new Vector2();
                        this.spriteBatch.DrawString(fontItemStack, (Main.mouseItem.stack).ToString(), new Vector2(mouseState.X + (10f * num193), mouseState.Y + (26f * num193)), color27, 0f, vector10, num192, SpriteEffects.None, 0f);
                    }
                }
                Rectangle rectangle3 = new Rectangle(mouseState.X + ((int) screenPosition.X), mouseState.Y + ((int) screenPosition.Y), 1, 1);
                if (!flag)
                {
                    int num194 = (0x1a * player[myPlayer].statLifeMax) / num14;
                    int num195 = 0;
                    if (player[myPlayer].statLifeMax > 200)
                    {
                        num194 = 260;
                        num195 += 0x1a;
                    }
                    if (((mouseState.X > (500 + num12)) && (mouseState.X < ((500 + num194) + num12))) && ((mouseState.Y > 0x20) && (mouseState.Y < ((0x20 + heartTexture.Height) + num195))))
                    {
                        player[myPlayer].showItemIcon = false;
                        string str19 = player[myPlayer].statLife + "/" + player[myPlayer].statLifeMax;
                        this.MouseText(str19, 0, 0);
                        flag = true;
                    }
                }
                if (!flag)
                {
                    int num196 = 0x18;
                    int num197 = (0x1c * player[myPlayer].statManaMax2) / num22;
                    if (((mouseState.X > (0x2fa + num12)) && (mouseState.X < ((0x2fa + num196) + num12))) && ((mouseState.Y > 30) && (mouseState.Y < (30 + num197))))
                    {
                        player[myPlayer].showItemIcon = false;
                        string str20 = player[myPlayer].statMana + "/" + player[myPlayer].statManaMax2;
                        this.MouseText(str20, 0, 0);
                        flag = true;
                    }
                }
                if (!flag)
                {
                    for (int num198 = 0; num198 < 200; num198++)
                    {
                        if (item[num198].active)
                        {
                            Rectangle rectangle4 = new Rectangle((int) ((item[num198].position.X + (item[num198].width * 0.5)) - (itemTexture[item[num198].type].Width * 0.5)), (((int) item[num198].position.Y) + item[num198].height) - itemTexture[item[num198].type].Height, itemTexture[item[num198].type].Width, itemTexture[item[num198].type].Height);
                            if (rectangle3.Intersects(rectangle4))
                            {
                                player[myPlayer].showItemIcon = false;
                                string str21 = item[num198].name;
                                if (item[num198].stack > 1)
                                {
                                    obj2 = str21;
                                    str21 = string.Concat(new object[] { obj2, " (", item[num198].stack, ")" });
                                }
                                if ((item[num198].owner < 0xff) && showItemOwner)
                                {
                                    str21 = str21 + " <" + player[item[num198].owner].name + ">";
                                }
                                rare = item[num198].rare;
                                this.MouseText(str21, rare, 0);
                                flag = true;
                                break;
                            }
                        }
                    }
                }
                for (int m = 0; m < 0xff; m++)
                {
                    if ((player[m].active && (myPlayer != m)) && !player[m].dead)
                    {
                        Rectangle rectangle5 = new Rectangle((int) ((player[m].position.X + (player[m].width * 0.5)) - 16.0), (int) ((player[m].position.Y + player[m].height) - 48f), 0x20, 0x30);
                        if (!flag && rectangle3.Intersects(rectangle5))
                        {
                            player[myPlayer].showItemIcon = false;
                            string str22 = string.Concat(new object[] { player[m].name, ": ", player[m].statLife, "/", player[m].statLifeMax });
                            if (player[m].hostile)
                            {
                                str22 = str22 + " (PvP)";
                            }
                            this.MouseText(str22, -1, player[m].difficulty);
                        }
                    }
                }
                if (!flag)
                {
                    for (int num200 = 0; num200 < 0x3e8; num200++)
                    {
                        if (npc[num200].active)
                        {
                            Rectangle rectangle6 = new Rectangle((int) ((npc[num200].position.X + (npc[num200].width * 0.5)) - (npcTexture[npc[num200].type].Width * 0.5)), (((int) npc[num200].position.Y) + npc[num200].height) - (npcTexture[npc[num200].type].Height / npcFrameCount[npc[num200].type]), npcTexture[npc[num200].type].Width, npcTexture[npc[num200].type].Height / npcFrameCount[npc[num200].type]);
                            if (rectangle3.Intersects(rectangle6))
                            {
                                bool flag7 = false;
                                if (npc[num200].townNPC)
                                {
                                    Rectangle rectangle7 = new Rectangle((((int) player[myPlayer].position.X) + (player[myPlayer].width / 2)) - (Player.tileRangeX * 0x10), (((int) player[myPlayer].position.Y) + (player[myPlayer].height / 2)) - (Player.tileRangeY * 0x10), (Player.tileRangeX * 0x10) * 2, (Player.tileRangeY * 0x10) * 2);
                                    Rectangle rectangle8 = new Rectangle((int) npc[num200].position.X, (int) npc[num200].position.Y, npc[num200].width, npc[num200].height);
                                    if (rectangle7.Intersects(rectangle8))
                                    {
                                        flag7 = true;
                                    }
                                }
                                if (flag7 && !player[myPlayer].dead)
                                {
                                    int num201 = -((npc[num200].width / 2) + 8);
                                    SpriteEffects effects = SpriteEffects.None;
                                    if (npc[num200].spriteDirection == -1)
                                    {
                                        effects = SpriteEffects.FlipHorizontally;
                                        num201 = (npc[num200].width / 2) + 8;
                                    }
                                    vector10 = new Vector2();
                                    this.spriteBatch.Draw(chatTexture, new Vector2((((npc[num200].position.X + (npc[num200].width / 2)) - screenPosition.X) - (chatTexture.Width / 2)) - num201, (npc[num200].position.Y - chatTexture.Height) - screenPosition.Y), new Rectangle(0, 0, chatTexture.Width, chatTexture.Height), new Color(mouseTextColor, mouseTextColor, mouseTextColor, mouseTextColor), 0f, vector10, (float) 1f, effects, 0f);
                                    if ((mouseState.RightButton == ButtonState.Pressed) && npcChatRelease)
                                    {
                                        npcChatRelease = false;
                                        if (player[myPlayer].talkNPC != num200)
                                        {
                                            player[myPlayer].sign = -1;
                                            editSign = false;
                                            player[myPlayer].talkNPC = num200;
                                            playerInventory = false;
                                            player[myPlayer].chest = -1;
                                            npcChatText = npc[num200].GetChat();
                                            PlaySound(0x18, -1, -1, 1);
                                        }
                                    }
                                }
                                player[myPlayer].showItemIcon = false;
                                string str23 = npc[num200].name;
                                if ((npc[num200].lifeMax > 1) && !npc[num200].dontTakeDamage)
                                {
                                    obj2 = str23;
                                    str23 = string.Concat(new object[] { obj2, ": ", npc[num200].life, "/", npc[num200].lifeMax });
                                }
                                this.MouseText(str23, 0, 0);
                                break;
                            }
                        }
                    }
                }
                if (mouseState.RightButton == ButtonState.Pressed)
                {
                    npcChatRelease = false;
                }
                else
                {
                    npcChatRelease = true;
                }
                if (player[myPlayer].showItemIcon && ((player[myPlayer].inventory[player[myPlayer].selectedItem].type > 0) || (player[myPlayer].showItemIcon2 > 0)))
                {
                    int type = player[myPlayer].inventory[player[myPlayer].selectedItem].type;
                    Color color28 = player[myPlayer].inventory[player[myPlayer].selectedItem].GetAlpha(Color.White);
                    Color color29 = player[myPlayer].inventory[player[myPlayer].selectedItem].GetColor(Color.White);
                    if (player[myPlayer].showItemIcon2 > 0)
                    {
                        type = player[myPlayer].showItemIcon2;
                        color28 = Color.White;
                        color29 = new Color();
                    }
                    vector10 = new Vector2();
                    this.spriteBatch.Draw(itemTexture[type], new Vector2((float) (mouseState.X + 10), (float) (mouseState.Y + 10)), new Rectangle(0, 0, itemTexture[type].Width, itemTexture[type].Height), color28, 0f, vector10, (float) 1f, SpriteEffects.None, 0f);
                    if ((player[myPlayer].showItemIcon2 == 0) && (player[myPlayer].inventory[player[myPlayer].selectedItem].color != new Color()))
                    {
                        this.spriteBatch.Draw(itemTexture[player[myPlayer].inventory[player[myPlayer].selectedItem].type], new Vector2((float) (mouseState.X + 10), (float) (mouseState.Y + 10)), new Rectangle(0, 0, itemTexture[player[myPlayer].inventory[player[myPlayer].selectedItem].type].Width, itemTexture[player[myPlayer].inventory[player[myPlayer].selectedItem].type].Height), color29, 0f, new Vector2(), (float) 1f, SpriteEffects.None, 0f);
                    }
                }
                player[myPlayer].showItemIcon = false;
                player[myPlayer].showItemIcon2 = 0;
            }
        }

        protected void DrawMenu()
        {
            string[] strArray3 = new string[1];
            Vector2 vector9;
            Star.UpdateStars();
            Cloud.UpdateClouds();
            evilTiles = 0;
            jungleTiles = 0;
            chatMode = false;
            for (int i = 0; i < numChatLines; i++)
            {
                chatLine[i] = new ChatLine();
            }
            this.DrawFPS();
            screenPosition.Y = (float) ((worldSurface * 16.0) - screenHeight);
            background = 0;
            byte r = (byte) ((0xff + (tileColor.R * 2)) / 3);
            Color color = new Color(r, r, r, 0xff);
            this.logoRotation += this.logoRotationSpeed * 3E-05f;
            if (this.logoRotation > 0.1)
            {
                this.logoRotationDirection = -1f;
            }
            else if (this.logoRotation < -0.1)
            {
                this.logoRotationDirection = 1f;
            }
            if ((this.logoRotationSpeed < 20f) & (this.logoRotationDirection == 1f))
            {
                this.logoRotationSpeed++;
            }
            else if ((this.logoRotationSpeed > -20f) & (this.logoRotationDirection == -1f))
            {
                this.logoRotationSpeed--;
            }
            this.logoScale += this.logoScaleSpeed * 1E-05f;
            if (this.logoScale > 1.1)
            {
                this.logoScaleDirection = -1f;
            }
            else if (this.logoScale < 0.9)
            {
                this.logoScaleDirection = 1f;
            }
            if ((this.logoScaleSpeed < 50f) & (this.logoScaleDirection == 1f))
            {
                this.logoScaleSpeed++;
            }
            else if ((this.logoScaleSpeed > -50f) & (this.logoScaleDirection == -1f))
            {
                this.logoScaleSpeed--;
            }
            this.spriteBatch.Draw(logoTexture, new Vector2((float) (screenWidth / 2), 100f), new Rectangle(0, 0, logoTexture.Width, logoTexture.Height), color, this.logoRotation, new Vector2((float) (logoTexture.Width / 2), (float) (logoTexture.Height / 2)), this.logoScale, SpriteEffects.None, 0f);
            int num3 = 250;
            int num4 = screenWidth / 2;
            int num5 = 80;
            int num6 = 0;
            int menuMode = Main.menuMode;
            int index = -1;
            int num9 = 0;
            int num10 = 0;
            bool flag = false;
            bool flag2 = false;
            bool flag3 = false;
            int num11 = 0;
            bool[] flagArray = new bool[maxMenuItems];
            bool[] flagArray2 = new bool[maxMenuItems];
            int[] numArray = new int[maxMenuItems];
            int[] numArray2 = new int[maxMenuItems];
            byte[] buffer = new byte[maxMenuItems];
            float[] numArray3 = new float[maxMenuItems];
            bool[] flagArray3 = new bool[maxMenuItems];
            for (int j = 0; j < maxMenuItems; j++)
            {
                flagArray[j] = false;
                flagArray2[j] = false;
                numArray[j] = 0;
                numArray2[j] = 0;
                numArray3[j] = 1f;
            }
            string[] strArray = new string[maxMenuItems];
            if (Main.menuMode == -1)
            {
                Main.menuMode = 0;
            }
            if (netMode == 2)
            {
                bool flag4 = true;
                for (int num13 = 0; num13 < 8; num13++)
                {
                    if (num13 < 0xff)
                    {
                        try
                        {
                            strArray[num13] = Netplay.serverSock[num13].statusText;
                            if (Netplay.serverSock[num13].active && showSpam)
                            {
                                IntPtr ptr = new IntPtr();
                                object obj2 = strArray3[(int) ptr];
                                (strArray3 = strArray)[(int) (ptr = (IntPtr) num13)] = string.Concat(new object[] { obj2, " (", NetMessage.buffer[num13].spamCount, ")" });
                            }
                        }
                        catch
                        {
                            strArray[num13] = "";
                        }
                        flagArray[num13] = true;
                        if ((strArray[num13] != "") && (strArray[num13] != null))
                        {
                            flag4 = false;
                        }
                    }
                }
                if (flag4)
                {
                    strArray[0] = "Start a new instance of Terraria to join!";
                    strArray[1] = "Running on port " + Netplay.serverPort + ".";
                }
                num6 = 11;
                strArray[9] = statusText;
                flagArray[9] = true;
                num3 = 170;
                num5 = 30;
                numArray[10] = 20;
                numArray[10] = 40;
                strArray[10] = "Disconnect";
                if (this.selectedMenu == 10)
                {
                    Netplay.disconnect = true;
                    PlaySound(11, -1, -1, 1);
                }
            }
            else if (Main.menuMode == 0x1f)
            {
                string password = Netplay.password;
                Netplay.password = GetInputText(Netplay.password);
                if (password != Netplay.password)
                {
                    PlaySound(12, -1, -1, 1);
                }
                strArray[0] = "Server Requires Password:";
                this.textBlinkerCount++;
                if (this.textBlinkerCount >= 20)
                {
                    if (this.textBlinkerState == 0)
                    {
                        this.textBlinkerState = 1;
                    }
                    else
                    {
                        this.textBlinkerState = 0;
                    }
                    this.textBlinkerCount = 0;
                }
                strArray[1] = Netplay.password;
                if (this.textBlinkerState == 1)
                {
                    (strArray3 = strArray)[1] = strArray3[1] + "|";
                    numArray2[1] = 1;
                }
                else
                {
                    (strArray3 = strArray)[1] = strArray3[1] + " ";
                }
                flagArray[0] = true;
                flagArray[1] = true;
                numArray[1] = -20;
                numArray[2] = 20;
                strArray[2] = "Accept";
                strArray[3] = "Back";
                num6 = 4;
                if (this.selectedMenu == 3)
                {
                    PlaySound(11, -1, -1, 1);
                    Main.menuMode = 0;
                    Netplay.disconnect = true;
                    Netplay.password = "";
                }
                else if ((this.selectedMenu == 2) || inputTextEnter)
                {
                    NetMessage.SendData(0x26, -1, -1, Netplay.password, 0, 0f, 0f, 0f, 0);
                    Main.menuMode = 14;
                }
            }
            else if ((netMode == 1) || (Main.menuMode == 14))
            {
                num6 = 2;
                strArray[0] = statusText;
                flagArray[0] = true;
                num3 = 300;
                strArray[1] = "Cancel";
                if (this.selectedMenu == 1)
                {
                    Netplay.disconnect = true;
                    Netplay.clientSock.tcpClient.Close();
                    PlaySound(11, -1, -1, 1);
                    Main.menuMode = 0;
                    netMode = 0;
                    try
                    {
                        this.tServer.Kill();
                    }
                    catch
                    {
                    }
                }
            }
            else if (Main.menuMode == 30)
            {
                string str2 = Netplay.password;
                Netplay.password = GetInputText(Netplay.password);
                if (str2 != Netplay.password)
                {
                    PlaySound(12, -1, -1, 1);
                }
                strArray[0] = "Enter Server Password:";
                this.textBlinkerCount++;
                if (this.textBlinkerCount >= 20)
                {
                    if (this.textBlinkerState == 0)
                    {
                        this.textBlinkerState = 1;
                    }
                    else
                    {
                        this.textBlinkerState = 0;
                    }
                    this.textBlinkerCount = 0;
                }
                strArray[1] = Netplay.password;
                if (this.textBlinkerState == 1)
                {
                    (strArray3 = strArray)[1] = strArray3[1] + "|";
                    numArray2[1] = 1;
                }
                else
                {
                    (strArray3 = strArray)[1] = strArray3[1] + " ";
                }
                flagArray[0] = true;
                flagArray[1] = true;
                numArray[1] = -20;
                numArray[2] = 20;
                strArray[2] = "Accept";
                strArray[3] = "Back";
                num6 = 4;
                if (this.selectedMenu == 3)
                {
                    PlaySound(11, -1, -1, 1);
                    Main.menuMode = 6;
                    Netplay.password = "";
                }
                else if (((this.selectedMenu == 2) || inputTextEnter) || autoPass)
                {
                    this.tServer.StartInfo.FileName = "TerrariaServer.exe";
                    this.tServer.StartInfo.Arguments = "-autoshutdown -world \"" + worldPathName + "\" -password \"" + Netplay.password + "\"";
                    if (libPath != "")
                    {
                        ProcessStartInfo startInfo = this.tServer.StartInfo;
                        startInfo.Arguments = startInfo.Arguments + " -loadlib " + libPath;
                    }
                    this.tServer.StartInfo.UseShellExecute = false;
                    this.tServer.StartInfo.CreateNoWindow = true;
                    this.tServer.Start();
                    Netplay.SetIP("127.0.0.1");
                    autoPass = true;
                    statusText = "Starting server...";
                    Netplay.StartClient();
                    Main.menuMode = 10;
                }
            }
            else if (Main.menuMode == 15)
            {
                num6 = 2;
                strArray[0] = statusText;
                flagArray[0] = true;
                num3 = 80;
                num5 = 400;
                strArray[1] = "Back";
                if (this.selectedMenu == 1)
                {
                    Netplay.disconnect = true;
                    PlaySound(11, -1, -1, 1);
                    Main.menuMode = 0;
                    netMode = 0;
                }
            }
            else if (Main.menuMode == 200)
            {
                num6 = 3;
                strArray[0] = "Load failed!";
                flagArray[0] = true;
                num3 -= 30;
                numArray[1] = 70;
                numArray[2] = 50;
                strArray[1] = "Load Backup";
                strArray[2] = "Cancel";
                if (this.selectedMenu == 1)
                {
                    if (File.Exists(worldPathName + ".bak"))
                    {
                        File.Copy(worldPathName + ".bak", worldPathName, true);
                        File.Delete(worldPathName + ".bak");
                        PlaySound(10, -1, -1, 1);
                        WorldGen.playWorld();
                        Main.menuMode = 10;
                    }
                    else
                    {
                        PlaySound(11, -1, -1, 1);
                        Main.menuMode = 0;
                        netMode = 0;
                    }
                }
                if (this.selectedMenu == 2)
                {
                    PlaySound(11, -1, -1, 1);
                    Main.menuMode = 0;
                    netMode = 0;
                }
            }
            else if (Main.menuMode == 0xc9)
            {
                num6 = 3;
                strArray[0] = "Load failed!";
                flagArray[0] = true;
                flagArray[1] = true;
                num3 -= 30;
                numArray[1] = -30;
                numArray[2] = 50;
                strArray[1] = "No backup found";
                strArray[2] = "Back";
                if (this.selectedMenu == 2)
                {
                    PlaySound(11, -1, -1, 1);
                    Main.menuMode = 0;
                    netMode = 0;
                }
            }
            else if (Main.menuMode == 10)
            {
                num6 = 1;
                strArray[0] = statusText;
                flagArray[0] = true;
                num3 = 300;
            }
            else if (Main.menuMode == 100)
            {
                num6 = 1;
                strArray[0] = statusText;
                flagArray[0] = true;
                num3 = 300;
            }
            else if (Main.menuMode == 0)
            {
                menuMultiplayer = false;
                menuServer = false;
                netMode = 0;
                strArray[0] = "Single Player";
                strArray[1] = "Multiplayer";
                strArray[2] = "Settings";
                strArray[3] = "Exit";
                num6 = 4;
                if (this.selectedMenu == 3)
                {
                    this.QuitGame();
                }
                if (this.selectedMenu == 1)
                {
                    PlaySound(10, -1, -1, 1);
                    Main.menuMode = 12;
                }
                if (this.selectedMenu == 2)
                {
                    PlaySound(10, -1, -1, 1);
                    Main.menuMode = 11;
                }
                if (this.selectedMenu == 0)
                {
                    PlaySound(10, -1, -1, 1);
                    Main.menuMode = 1;
                    LoadPlayers();
                }
            }
            else if (Main.menuMode == 1)
            {
                myPlayer = 0;
                num3 = 190;
                num5 = 50;
                strArray[5] = "Create Character";
                strArray[6] = "Delete";
                if (numLoadPlayers == 5)
                {
                    flagArray2[5] = true;
                    strArray[5] = "";
                }
                else if (numLoadPlayers == 0)
                {
                    flagArray2[6] = true;
                    strArray[6] = "";
                }
                strArray[7] = "Back";
                for (int num14 = 0; num14 < 5; num14++)
                {
                    if (num14 < numLoadPlayers)
                    {
                        strArray[num14] = loadPlayer[num14].name;
                        buffer[num14] = loadPlayer[num14].difficulty;
                    }
                    else
                    {
                        strArray[num14] = null;
                    }
                }
                num6 = 8;
                if ((this.focusMenu >= 0) && (this.focusMenu < numLoadPlayers))
                {
                    index = this.focusMenu;
                    Vector2 vector = fontDeathText.MeasureString(strArray[index]);
                    num9 = (int) (((screenWidth / 2) + (vector.X * 0.5)) + 10.0);
                    num10 = (num3 + (num5 * this.focusMenu)) + 4;
                }
                if (this.selectedMenu == 7)
                {
                    autoJoin = false;
                    autoPass = false;
                    PlaySound(11, -1, -1, 1);
                    if (menuMultiplayer)
                    {
                        Main.menuMode = 12;
                        menuMultiplayer = false;
                        menuServer = false;
                    }
                    else
                    {
                        Main.menuMode = 0;
                    }
                }
                else if (this.selectedMenu == 5)
                {
                    loadPlayer[numLoadPlayers] = new Player();
                    PlaySound(10, -1, -1, 1);
                    Main.menuMode = 2;
                }
                else if (this.selectedMenu == 6)
                {
                    PlaySound(10, -1, -1, 1);
                    Main.menuMode = 4;
                }
                else if (this.selectedMenu >= 0)
                {
                    if (menuMultiplayer)
                    {
                        this.selectedPlayer = this.selectedMenu;
                        player[myPlayer] = (Player) loadPlayer[this.selectedPlayer].Clone();
                        playerPathName = loadPlayerPath[this.selectedPlayer];
                        PlaySound(10, -1, -1, 1);
                        if (autoJoin)
                        {
                            if (Netplay.SetIP(Main.getIP))
                            {
                                Main.menuMode = 10;
                                Netplay.StartClient();
                            }
                            else if (Netplay.SetIP2(Main.getIP))
                            {
                                Main.menuMode = 10;
                                Netplay.StartClient();
                            }
                            autoJoin = false;
                        }
                        else if (menuServer)
                        {
                            LoadWorlds();
                            Main.menuMode = 6;
                        }
                        else
                        {
                            Main.menuMode = 13;
                        }
                    }
                    else
                    {
                        myPlayer = 0;
                        this.selectedPlayer = this.selectedMenu;
                        player[myPlayer] = (Player) loadPlayer[this.selectedPlayer].Clone();
                        playerPathName = loadPlayerPath[this.selectedPlayer];
                        LoadWorlds();
                        PlaySound(10, -1, -1, 1);
                        Main.menuMode = 6;
                    }
                }
            }
            else if (Main.menuMode == 2)
            {
                if (this.selectedMenu == 0)
                {
                    Main.menuMode = 0x11;
                    PlaySound(10, -1, -1, 1);
                    this.selColor = loadPlayer[numLoadPlayers].hairColor;
                }
                if (this.selectedMenu == 1)
                {
                    Main.menuMode = 0x12;
                    PlaySound(10, -1, -1, 1);
                    this.selColor = loadPlayer[numLoadPlayers].eyeColor;
                }
                if (this.selectedMenu == 2)
                {
                    Main.menuMode = 0x13;
                    PlaySound(10, -1, -1, 1);
                    this.selColor = loadPlayer[numLoadPlayers].skinColor;
                }
                if (this.selectedMenu == 3)
                {
                    Main.menuMode = 20;
                    PlaySound(10, -1, -1, 1);
                }
                strArray[0] = "Hair";
                strArray[1] = "Eyes";
                strArray[2] = "Skin";
                strArray[3] = "Clothes";
                num3 = 0xf6;
                for (int num15 = 0; num15 < 6; num15++)
                {
                    numArray3[num15] = 0.8f;
                }
                num5 = 40;
                numArray[6] = 0x10;
                numArray[7] = 0x19;
                index = numLoadPlayers;
                num9 = (screenWidth / 2) - 0x10;
                num10 = 200;
                if (loadPlayer[index].male)
                {
                    strArray[4] = "Male";
                }
                else
                {
                    strArray[4] = "Female";
                }
                if (this.selectedMenu == 4)
                {
                    if (loadPlayer[index].male)
                    {
                        PlaySound(20, -1, -1, 1);
                        loadPlayer[index].male = false;
                    }
                    else
                    {
                        PlaySound(1, -1, -1, 1);
                        loadPlayer[index].male = true;
                    }
                }
                if (loadPlayer[index].difficulty == 2)
                {
                    strArray[5] = "Hardcore";
                    buffer[5] = loadPlayer[index].difficulty;
                }
                else if (loadPlayer[index].difficulty == 1)
                {
                    strArray[5] = "Mediumcore";
                    buffer[5] = loadPlayer[index].difficulty;
                }
                else
                {
                    strArray[5] = "Softcore";
                }
                if (this.selectedMenu == 5)
                {
                    PlaySound(10, -1, -1, 1);
                    Main.menuMode = 0xde;
                }
                strArray[6] = "Create";
                strArray[7] = "Back";
                num6 = 8;
                if (this.selectedMenu == 7)
                {
                    PlaySound(11, -1, -1, 1);
                    Main.menuMode = 1;
                }
                else if (this.selectedMenu == 6)
                {
                    PlaySound(10, -1, -1, 1);
                    loadPlayer[numLoadPlayers].name = "";
                    Main.menuMode = 3;
                }
            }
            else if (Main.menuMode == 0xde)
            {
                if (this.focusMenu == 3)
                {
                    strArray[0] = "Hardcore characters die for good";
                }
                else if (this.focusMenu == 2)
                {
                    strArray[0] = "Mediumcore characters drop items on death";
                }
                else if (this.focusMenu == 1)
                {
                    strArray[0] = "Softcore characters drop money on death";
                }
                else
                {
                    strArray[0] = "Select difficulty";
                }
                num5 = 50;
                numArray[1] = 0x19;
                numArray[2] = 0x19;
                numArray[3] = 0x19;
                flagArray[0] = true;
                strArray[1] = "Softcore";
                strArray[2] = "Mediumcore";
                buffer[2] = 1;
                strArray[3] = "Hardcore";
                buffer[3] = 2;
                num6 = 4;
                if (this.selectedMenu == 1)
                {
                    loadPlayer[numLoadPlayers].difficulty = 0;
                    Main.menuMode = 2;
                }
                else if (this.selectedMenu == 2)
                {
                    Main.menuMode = 2;
                    loadPlayer[numLoadPlayers].difficulty = 1;
                }
                else if (this.selectedMenu == 3)
                {
                    loadPlayer[numLoadPlayers].difficulty = 2;
                    Main.menuMode = 2;
                }
            }
            else if (Main.menuMode == 20)
            {
                if (this.selectedMenu == 0)
                {
                    Main.menuMode = 0x15;
                    PlaySound(10, -1, -1, 1);
                    this.selColor = loadPlayer[numLoadPlayers].shirtColor;
                }
                if (this.selectedMenu == 1)
                {
                    Main.menuMode = 0x16;
                    PlaySound(10, -1, -1, 1);
                    this.selColor = loadPlayer[numLoadPlayers].underShirtColor;
                }
                if (this.selectedMenu == 2)
                {
                    Main.menuMode = 0x17;
                    PlaySound(10, -1, -1, 1);
                    this.selColor = loadPlayer[numLoadPlayers].pantsColor;
                }
                if (this.selectedMenu == 3)
                {
                    this.selColor = loadPlayer[numLoadPlayers].shoeColor;
                    Main.menuMode = 0x18;
                    PlaySound(10, -1, -1, 1);
                }
                strArray[0] = "Shirt";
                strArray[1] = "Undershirt";
                strArray[2] = "Pants";
                strArray[3] = "Shoes";
                num3 = 260;
                num5 = 50;
                numArray[5] = 20;
                strArray[5] = "Back";
                num6 = 6;
                index = numLoadPlayers;
                num9 = (screenWidth / 2) - 0x10;
                num10 = 210;
                if (this.selectedMenu == 5)
                {
                    PlaySound(11, -1, -1, 1);
                    Main.menuMode = 2;
                }
            }
            else if (Main.menuMode == 0x11)
            {
                index = numLoadPlayers;
                num9 = (screenWidth / 2) - 0x10;
                num10 = 210;
                flag = true;
                num11 = 390;
                num3 = 260;
                num5 = 60;
                loadPlayer[index].hairColor = this.selColor;
                num6 = 3;
                strArray[0] = "Hair " + (loadPlayer[index].hair + 1);
                strArray[1] = "Hair Color";
                flagArray[1] = true;
                numArray[2] = 150;
                numArray[1] = 10;
                strArray[2] = "Back";
                if (this.selectedMenu == 0)
                {
                    PlaySound(12, -1, -1, 1);
                    Player player1 = loadPlayer[index];
                    player1.hair++;
                    if (loadPlayer[index].hair >= 0x24)
                    {
                        loadPlayer[index].hair = 0;
                    }
                }
                else if (this.selectedMenu2 == 0)
                {
                    PlaySound(12, -1, -1, 1);
                    Player player2 = loadPlayer[index];
                    player2.hair--;
                    if (loadPlayer[index].hair < 0)
                    {
                        loadPlayer[index].hair = 0x23;
                    }
                }
                if (this.selectedMenu == 2)
                {
                    Main.menuMode = 2;
                    PlaySound(11, -1, -1, 1);
                }
            }
            else if (Main.menuMode == 0x12)
            {
                index = numLoadPlayers;
                num9 = (screenWidth / 2) - 0x10;
                num10 = 210;
                flag = true;
                num11 = 370;
                num3 = 240;
                num5 = 60;
                loadPlayer[index].eyeColor = this.selColor;
                num6 = 3;
                strArray[0] = "";
                strArray[1] = "Eye Color";
                flagArray[1] = true;
                numArray[2] = 170;
                numArray[1] = 10;
                strArray[2] = "Back";
                if (this.selectedMenu == 2)
                {
                    Main.menuMode = 2;
                    PlaySound(11, -1, -1, 1);
                }
            }
            else if (Main.menuMode == 0x13)
            {
                index = numLoadPlayers;
                num9 = (screenWidth / 2) - 0x10;
                num10 = 210;
                flag = true;
                num11 = 370;
                num3 = 240;
                num5 = 60;
                loadPlayer[index].skinColor = this.selColor;
                num6 = 3;
                strArray[0] = "";
                strArray[1] = "Skin Color";
                flagArray[1] = true;
                numArray[2] = 170;
                numArray[1] = 10;
                strArray[2] = "Back";
                if (this.selectedMenu == 2)
                {
                    Main.menuMode = 2;
                    PlaySound(11, -1, -1, 1);
                }
            }
            else if (Main.menuMode == 0x15)
            {
                index = numLoadPlayers;
                num9 = (screenWidth / 2) - 0x10;
                num10 = 210;
                flag = true;
                num11 = 370;
                num3 = 240;
                num5 = 60;
                loadPlayer[index].shirtColor = this.selColor;
                num6 = 3;
                strArray[0] = "";
                strArray[1] = "Shirt Color";
                flagArray[1] = true;
                numArray[2] = 170;
                numArray[1] = 10;
                strArray[2] = "Back";
                if (this.selectedMenu == 2)
                {
                    Main.menuMode = 20;
                    PlaySound(11, -1, -1, 1);
                }
            }
            else if (Main.menuMode == 0x16)
            {
                index = numLoadPlayers;
                num9 = (screenWidth / 2) - 0x10;
                num10 = 210;
                flag = true;
                num11 = 370;
                num3 = 240;
                num5 = 60;
                loadPlayer[index].underShirtColor = this.selColor;
                num6 = 3;
                strArray[0] = "";
                strArray[1] = "Undershirt Color";
                flagArray[1] = true;
                numArray[2] = 170;
                numArray[1] = 10;
                strArray[2] = "Back";
                if (this.selectedMenu == 2)
                {
                    Main.menuMode = 20;
                    PlaySound(11, -1, -1, 1);
                }
            }
            else if (Main.menuMode == 0x17)
            {
                index = numLoadPlayers;
                num9 = (screenWidth / 2) - 0x10;
                num10 = 210;
                flag = true;
                num11 = 370;
                num3 = 240;
                num5 = 60;
                loadPlayer[index].pantsColor = this.selColor;
                num6 = 3;
                strArray[0] = "";
                strArray[1] = "Pants Color";
                flagArray[1] = true;
                numArray[2] = 170;
                numArray[1] = 10;
                strArray[2] = "Back";
                if (this.selectedMenu == 2)
                {
                    Main.menuMode = 20;
                    PlaySound(11, -1, -1, 1);
                }
            }
            else if (Main.menuMode == 0x18)
            {
                index = numLoadPlayers;
                num9 = (screenWidth / 2) - 0x10;
                num10 = 210;
                flag = true;
                num11 = 370;
                num3 = 240;
                num5 = 60;
                loadPlayer[index].shoeColor = this.selColor;
                num6 = 3;
                strArray[0] = "";
                strArray[1] = "Misc Color";
                flagArray[1] = true;
                numArray[2] = 170;
                numArray[1] = 10;
                strArray[2] = "Back";
                if (this.selectedMenu == 2)
                {
                    Main.menuMode = 20;
                    PlaySound(11, -1, -1, 1);
                }
            }
            else if (Main.menuMode == 3)
            {
                string name = loadPlayer[numLoadPlayers].name;
                loadPlayer[numLoadPlayers].name = GetInputText(loadPlayer[numLoadPlayers].name);
                if (loadPlayer[numLoadPlayers].name.Length > Player.nameLen)
                {
                    loadPlayer[numLoadPlayers].name = loadPlayer[numLoadPlayers].name.Substring(0, Player.nameLen);
                }
                if (name != loadPlayer[numLoadPlayers].name)
                {
                    PlaySound(12, -1, -1, 1);
                }
                strArray[0] = "Enter Character Name:";
                flagArray2[2] = true;
                if (loadPlayer[numLoadPlayers].name != "")
                {
                    if (loadPlayer[numLoadPlayers].name.Substring(0, 1) == " ")
                    {
                        loadPlayer[numLoadPlayers].name = "";
                    }
                    for (int num16 = 0; num16 < loadPlayer[numLoadPlayers].name.Length; num16++)
                    {
                        if (loadPlayer[numLoadPlayers].name.Substring(num16, 1) != " ")
                        {
                            flagArray2[2] = false;
                        }
                    }
                }
                this.textBlinkerCount++;
                if (this.textBlinkerCount >= 20)
                {
                    if (this.textBlinkerState == 0)
                    {
                        this.textBlinkerState = 1;
                    }
                    else
                    {
                        this.textBlinkerState = 0;
                    }
                    this.textBlinkerCount = 0;
                }
                strArray[1] = loadPlayer[numLoadPlayers].name;
                if (this.textBlinkerState == 1)
                {
                    (strArray3 = strArray)[1] = strArray3[1] + "|";
                    numArray2[1] = 1;
                }
                else
                {
                    (strArray3 = strArray)[1] = strArray3[1] + " ";
                }
                flagArray[0] = true;
                flagArray[1] = true;
                numArray[1] = -20;
                numArray[2] = 20;
                strArray[2] = "Accept";
                strArray[3] = "Back";
                num6 = 4;
                if (this.selectedMenu == 3)
                {
                    PlaySound(11, -1, -1, 1);
                    Main.menuMode = 2;
                }
                if ((this.selectedMenu == 2) || (!flagArray2[2] && inputTextEnter))
                {
                    loadPlayer[numLoadPlayers].name.Trim();
                    loadPlayerPath[numLoadPlayers] = nextLoadPlayer();
                    Player.SavePlayer(loadPlayer[numLoadPlayers], loadPlayerPath[numLoadPlayers]);
                    LoadPlayers();
                    PlaySound(10, -1, -1, 1);
                    Main.menuMode = 1;
                }
            }
            else if (Main.menuMode == 4)
            {
                num3 = 220;
                num5 = 60;
                strArray[5] = "Back";
                for (int num17 = 0; num17 < 5; num17++)
                {
                    if (num17 < numLoadPlayers)
                    {
                        strArray[num17] = loadPlayer[num17].name;
                        buffer[num17] = loadPlayer[num17].difficulty;
                    }
                    else
                    {
                        strArray[num17] = null;
                    }
                }
                num6 = 6;
                if ((this.focusMenu >= 0) && (this.focusMenu < numLoadPlayers))
                {
                    index = this.focusMenu;
                    Vector2 vector2 = fontDeathText.MeasureString(strArray[index]);
                    num9 = (int) (((screenWidth / 2) + (vector2.X * 0.5)) + 10.0);
                    num10 = (num3 + (num5 * this.focusMenu)) + 4;
                }
                if (this.selectedMenu == 5)
                {
                    PlaySound(11, -1, -1, 1);
                    Main.menuMode = 1;
                }
                else if (this.selectedMenu >= 0)
                {
                    this.selectedPlayer = this.selectedMenu;
                    PlaySound(10, -1, -1, 1);
                    Main.menuMode = 5;
                }
            }
            else if (Main.menuMode == 5)
            {
                strArray[0] = "Delete " + loadPlayer[this.selectedPlayer].name + "?";
                flagArray[0] = true;
                strArray[1] = "Yes";
                strArray[2] = "No";
                num6 = 3;
                if (this.selectedMenu == 1)
                {
                    ErasePlayer(this.selectedPlayer);
                    PlaySound(10, -1, -1, 1);
                    Main.menuMode = 1;
                }
                else if (this.selectedMenu == 2)
                {
                    PlaySound(11, -1, -1, 1);
                    Main.menuMode = 1;
                }
            }
            else if (Main.menuMode == 6)
            {
                num3 = 190;
                num5 = 50;
                strArray[5] = "Create World";
                strArray[6] = "Delete";
                if (numLoadWorlds == 5)
                {
                    flagArray2[5] = true;
                    strArray[5] = "";
                }
                else if (numLoadWorlds == 0)
                {
                    flagArray2[6] = true;
                    strArray[6] = "";
                }
                strArray[7] = "Back";
                for (int num18 = 0; num18 < 5; num18++)
                {
                    if (num18 < numLoadWorlds)
                    {
                        strArray[num18] = loadWorld[num18];
                    }
                    else
                    {
                        strArray[num18] = null;
                    }
                }
                num6 = 8;
                if (this.selectedMenu == 7)
                {
                    if (menuMultiplayer)
                    {
                        Main.menuMode = 12;
                    }
                    else
                    {
                        Main.menuMode = 1;
                    }
                    PlaySound(11, -1, -1, 1);
                }
                else if (this.selectedMenu == 5)
                {
                    PlaySound(10, -1, -1, 1);
                    Main.menuMode = 0x10;
                    Main.newWorldName = "World " + (numLoadWorlds + 1);
                }
                else if (this.selectedMenu == 6)
                {
                    PlaySound(10, -1, -1, 1);
                    Main.menuMode = 8;
                }
                else if (this.selectedMenu >= 0)
                {
                    if (menuMultiplayer)
                    {
                        PlaySound(10, -1, -1, 1);
                        worldPathName = loadWorldPath[this.selectedMenu];
                        Main.menuMode = 30;
                    }
                    else
                    {
                        PlaySound(10, -1, -1, 1);
                        worldPathName = loadWorldPath[this.selectedMenu];
                        WorldGen.playWorld();
                        Main.menuMode = 10;
                    }
                }
            }
            else if (Main.menuMode == 7)
            {
                string newWorldName = Main.newWorldName;
                Main.newWorldName = GetInputText(Main.newWorldName);
                if (Main.newWorldName.Length > 20)
                {
                    Main.newWorldName = Main.newWorldName.Substring(0, 20);
                }
                if (newWorldName != Main.newWorldName)
                {
                    PlaySound(12, -1, -1, 1);
                }
                strArray[0] = "Enter World Name:";
                flagArray2[2] = true;
                if (Main.newWorldName != "")
                {
                    if (Main.newWorldName.Substring(0, 1) == " ")
                    {
                        Main.newWorldName = "";
                    }
                    for (int num19 = 0; num19 < Main.newWorldName.Length; num19++)
                    {
                        if (Main.newWorldName != " ")
                        {
                            flagArray2[2] = false;
                        }
                    }
                }
                this.textBlinkerCount++;
                if (this.textBlinkerCount >= 20)
                {
                    if (this.textBlinkerState == 0)
                    {
                        this.textBlinkerState = 1;
                    }
                    else
                    {
                        this.textBlinkerState = 0;
                    }
                    this.textBlinkerCount = 0;
                }
                strArray[1] = Main.newWorldName;
                if (this.textBlinkerState == 1)
                {
                    (strArray3 = strArray)[1] = strArray3[1] + "|";
                    numArray2[1] = 1;
                }
                else
                {
                    (strArray3 = strArray)[1] = strArray3[1] + " ";
                }
                flagArray[0] = true;
                flagArray[1] = true;
                numArray[1] = -20;
                numArray[2] = 20;
                strArray[2] = "Accept";
                strArray[3] = "Back";
                num6 = 4;
                if (this.selectedMenu == 3)
                {
                    PlaySound(11, -1, -1, 1);
                    Main.menuMode = 0x10;
                }
                if ((this.selectedMenu == 2) || (!flagArray2[2] && inputTextEnter))
                {
                    Main.menuMode = 10;
                    worldName = Main.newWorldName;
                    worldPathName = nextLoadWorld();
                    WorldGen.CreateNewWorld();
                }
            }
            else if (Main.menuMode == 8)
            {
                num3 = 220;
                num5 = 60;
                strArray[5] = "Back";
                for (int num20 = 0; num20 < 5; num20++)
                {
                    if (num20 < numLoadWorlds)
                    {
                        strArray[num20] = loadWorld[num20];
                    }
                    else
                    {
                        strArray[num20] = null;
                    }
                }
                num6 = 6;
                if (this.selectedMenu == 5)
                {
                    PlaySound(11, -1, -1, 1);
                    Main.menuMode = 1;
                }
                else if (this.selectedMenu >= 0)
                {
                    this.selectedWorld = this.selectedMenu;
                    PlaySound(10, -1, -1, 1);
                    Main.menuMode = 9;
                }
            }
            else if (Main.menuMode == 9)
            {
                strArray[0] = "Delete " + loadWorld[this.selectedWorld] + "?";
                flagArray[0] = true;
                strArray[1] = "Yes";
                strArray[2] = "No";
                num6 = 3;
                if (this.selectedMenu == 1)
                {
                    EraseWorld(this.selectedWorld);
                    PlaySound(10, -1, -1, 1);
                    Main.menuMode = 6;
                }
                else if (this.selectedMenu == 2)
                {
                    PlaySound(11, -1, -1, 1);
                    Main.menuMode = 6;
                }
            }
            else if (Main.menuMode == 0x457)
            {
                num5 = 60;
                numArray[4] = 10;
                num6 = 8;
                if (this.graphics.IsFullScreen)
                {
                    strArray[0] = "Go Windowed";
                }
                else
                {
                    strArray[0] = "Go Fullscreen";
                }
                this.bgScroll = (int) Math.Round((double) ((1f - caveParrallax) * 500f));
                strArray[1] = "Resolution";
                strArray[2] = "Parallax";
                if (fixedTiming)
                {
                    strArray[3] = "Frame Skip Off";
                }
                else
                {
                    strArray[3] = "Frame Skip On";
                }
                strArray[4] = "Back";
                if (this.selectedMenu == 4)
                {
                    PlaySound(11, -1, -1, 1);
                    this.SaveSettings();
                    Main.menuMode = 11;
                }
                if (this.selectedMenu == 3)
                {
                    PlaySound(12, -1, -1, 1);
                    if (fixedTiming)
                    {
                        fixedTiming = false;
                    }
                    else
                    {
                        fixedTiming = true;
                    }
                }
                if (this.selectedMenu == 2)
                {
                    PlaySound(11, -1, -1, 1);
                    Main.menuMode = 0x1c;
                }
                if (this.selectedMenu == 1)
                {
                    PlaySound(10, -1, -1, 1);
                    Main.menuMode = 0x6f;
                }
                if (this.selectedMenu == 0)
                {
                    this.graphics.ToggleFullScreen();
                }
            }
            else if (Main.menuMode == 11)
            {
                num3 = 180;
                num5 = 0x30;
                numArray[7] = 10;
                num6 = 8;
                strArray[0] = "Video";
                strArray[1] = "Cursor Color";
                strArray[2] = "Volume";
                strArray[3] = "Controls";
                if (autoSave)
                {
                    strArray[4] = "Autosave On";
                }
                else
                {
                    strArray[4] = "Autosave Off";
                }
                if (autoPause)
                {
                    strArray[5] = "Autopause On";
                }
                else
                {
                    strArray[5] = "Autopause Off";
                }
                if (showItemText)
                {
                    strArray[6] = "Pickup Text On";
                }
                else
                {
                    strArray[6] = "Pickup Text Off";
                }
                strArray[7] = "Back";
                if (this.selectedMenu == 7)
                {
                    PlaySound(11, -1, -1, 1);
                    this.SaveSettings();
                    Main.menuMode = 0;
                }
                if (this.selectedMenu == 6)
                {
                    PlaySound(12, -1, -1, 1);
                    if (showItemText)
                    {
                        showItemText = false;
                    }
                    else
                    {
                        showItemText = true;
                    }
                }
                if (this.selectedMenu == 5)
                {
                    PlaySound(12, -1, -1, 1);
                    if (autoPause)
                    {
                        autoPause = false;
                    }
                    else
                    {
                        autoPause = true;
                    }
                }
                if (this.selectedMenu == 4)
                {
                    PlaySound(12, -1, -1, 1);
                    if (autoSave)
                    {
                        autoSave = false;
                    }
                    else
                    {
                        autoSave = true;
                    }
                }
                if (this.selectedMenu == 3)
                {
                    PlaySound(11, -1, -1, 1);
                    Main.menuMode = 0x1b;
                }
                if (this.selectedMenu == 2)
                {
                    PlaySound(11, -1, -1, 1);
                    Main.menuMode = 0x1a;
                }
                if (this.selectedMenu == 1)
                {
                    PlaySound(10, -1, -1, 1);
                    this.selColor = mouseColor;
                    Main.menuMode = 0x19;
                }
                if (this.selectedMenu == 0)
                {
                    PlaySound(10, -1, -1, 1);
                    Main.menuMode = 0x457;
                }
            }
            else if (Main.menuMode != 0x6f)
            {
                if (Main.menuMode == 0x19)
                {
                    flag = true;
                    num11 = 370;
                    num3 = 240;
                    num5 = 60;
                    mouseColor = this.selColor;
                    num6 = 3;
                    strArray[0] = "";
                    strArray[1] = "Cursor Color";
                    flagArray[1] = true;
                    numArray[2] = 170;
                    numArray[1] = 10;
                    strArray[2] = "Back";
                    if (this.selectedMenu == 2)
                    {
                        Main.menuMode = 11;
                        PlaySound(11, -1, -1, 1);
                    }
                }
                else if (Main.menuMode == 0x1a)
                {
                    flag2 = true;
                    num3 = 240;
                    num5 = 60;
                    num6 = 3;
                    strArray[0] = "";
                    strArray[1] = "Volume";
                    flagArray[1] = true;
                    numArray[2] = 170;
                    numArray[1] = 10;
                    strArray[2] = "Back";
                    if (this.selectedMenu == 2)
                    {
                        Main.menuMode = 11;
                        PlaySound(11, -1, -1, 1);
                    }
                }
                else if (Main.menuMode == 0x1c)
                {
                    caveParrallax = 1f - (((float) this.bgScroll) / 500f);
                    flag3 = true;
                    num3 = 240;
                    num5 = 60;
                    num6 = 3;
                    strArray[0] = "";
                    strArray[1] = "Parallax";
                    flagArray[1] = true;
                    numArray[2] = 170;
                    numArray[1] = 10;
                    strArray[2] = "Back";
                    if (this.selectedMenu == 2)
                    {
                        Main.menuMode = 0x457;
                        PlaySound(11, -1, -1, 1);
                    }
                }
                else if (Main.menuMode == 0x1b)
                {
                    num3 = 0xb0;
                    num5 = 30;
                    num6 = 13;
                    string[] strArray2 = new string[] { cUp, cDown, cLeft, cRight, cJump, cThrowItem, cInv, cHeal, cMana, cBuff, cHook };
                    if (this.setKey >= 0)
                    {
                        strArray2[this.setKey] = "_";
                    }
                    strArray[0] = "Up             " + strArray2[0];
                    strArray[1] = "Down          " + strArray2[1];
                    strArray[2] = "Left            " + strArray2[2];
                    strArray[3] = "Right          " + strArray2[3];
                    strArray[4] = "Jump          " + strArray2[4];
                    strArray[5] = "Throw         " + strArray2[5];
                    strArray[6] = "Inventory      " + strArray2[6];
                    strArray[7] = "Quick Heal    " + strArray2[7];
                    strArray[8] = "Quick Mana   " + strArray2[8];
                    strArray[9] = "Quick Buff    " + strArray2[9];
                    strArray[10] = "Grapple        " + strArray2[10];
                    for (int num23 = 0; num23 < 11; num23++)
                    {
                        flagArray3[num23] = true;
                        numArray3[num23] = 0.55f;
                        numArray2[num23] = -80;
                    }
                    numArray3[11] = 0.8f;
                    numArray3[12] = 0.8f;
                    numArray[11] = 6;
                    strArray[11] = "Reset to Default";
                    numArray[12] = 0x10;
                    strArray[12] = "Back";
                    if (this.selectedMenu == 12)
                    {
                        Main.menuMode = 11;
                        PlaySound(11, -1, -1, 1);
                    }
                    else if (this.selectedMenu == 11)
                    {
                        cUp = "W";
                        cDown = "S";
                        cLeft = "A";
                        cRight = "D";
                        cJump = "Space";
                        cThrowItem = "Q";
                        cInv = "Escape";
                        cHeal = "H";
                        cMana = "M";
                        cBuff = "B";
                        cHook = "E";
                        this.setKey = -1;
                        PlaySound(11, -1, -1, 1);
                    }
                    else if (this.selectedMenu >= 0)
                    {
                        this.setKey = this.selectedMenu;
                    }
                    if (this.setKey >= 0)
                    {
                        Keys[] pressedKeys = keyState.GetPressedKeys();
                        if (pressedKeys.Length > 0)
                        {
                            string str5 = (pressedKeys[0]).ToString();
                            if (this.setKey == 0)
                            {
                                cUp = str5;
                            }
                            if (this.setKey == 1)
                            {
                                cDown = str5;
                            }
                            if (this.setKey == 2)
                            {
                                cLeft = str5;
                            }
                            if (this.setKey == 3)
                            {
                                cRight = str5;
                            }
                            if (this.setKey == 4)
                            {
                                cJump = str5;
                            }
                            if (this.setKey == 5)
                            {
                                cThrowItem = str5;
                            }
                            if (this.setKey == 6)
                            {
                                cInv = str5;
                            }
                            if (this.setKey == 7)
                            {
                                cHeal = str5;
                            }
                            if (this.setKey == 8)
                            {
                                cMana = str5;
                            }
                            if (this.setKey == 9)
                            {
                                cBuff = str5;
                            }
                            if (this.setKey == 10)
                            {
                                cHook = str5;
                            }
                            this.setKey = -1;
                        }
                    }
                }
                else if (Main.menuMode == 12)
                {
                    menuServer = false;
                    strArray[0] = "Join";
                    strArray[1] = "Host & Play";
                    strArray[2] = "Back";
                    if (this.selectedMenu == 0)
                    {
                        LoadPlayers();
                        menuMultiplayer = true;
                        PlaySound(10, -1, -1, 1);
                        Main.menuMode = 1;
                    }
                    else if (this.selectedMenu == 1)
                    {
                        LoadPlayers();
                        PlaySound(10, -1, -1, 1);
                        Main.menuMode = 1;
                        menuMultiplayer = true;
                        menuServer = true;
                    }
                    if (this.selectedMenu == 2)
                    {
                        PlaySound(11, -1, -1, 1);
                        Main.menuMode = 0;
                    }
                    num6 = 3;
                }
                else if (Main.menuMode == 13)
                {
                    string getIP = Main.getIP;
                    Main.getIP = GetInputText(Main.getIP);
                    if (getIP != Main.getIP)
                    {
                        PlaySound(12, -1, -1, 1);
                    }
                    strArray[0] = "Enter Server IP Address:";
                    flagArray2[9] = true;
                    if (Main.getIP != "")
                    {
                        if (Main.getIP.Substring(0, 1) == " ")
                        {
                            Main.getIP = "";
                        }
                        for (int num24 = 0; num24 < Main.getIP.Length; num24++)
                        {
                            if (Main.getIP != " ")
                            {
                                flagArray2[9] = false;
                            }
                        }
                    }
                    this.textBlinkerCount++;
                    if (this.textBlinkerCount >= 20)
                    {
                        if (this.textBlinkerState == 0)
                        {
                            this.textBlinkerState = 1;
                        }
                        else
                        {
                            this.textBlinkerState = 0;
                        }
                        this.textBlinkerCount = 0;
                    }
                    strArray[1] = Main.getIP;
                    if (this.textBlinkerState == 1)
                    {
                        (strArray3 = strArray)[1] = strArray3[1] + "|";
                        numArray2[1] = 1;
                    }
                    else
                    {
                        (strArray3 = strArray)[1] = strArray3[1] + " ";
                    }
                    flagArray[0] = true;
                    flagArray[1] = true;
                    numArray[9] = 0x2c;
                    numArray[10] = 0x40;
                    strArray[9] = "Accept";
                    strArray[10] = "Back";
                    num6 = 11;
                    num3 = 180;
                    num5 = 30;
                    numArray[1] = 0x13;
                    for (int num25 = 2; num25 < 9; num25++)
                    {
                        int num26 = num25 - 2;
                        if ((recentWorld[num26] != null) && (recentWorld[num26] != ""))
                        {
                            strArray[num25] = string.Concat(new object[] { recentWorld[num26], " (", recentIP[num26], ":", recentPort[num26], ")" });
                        }
                        else
                        {
                            strArray[num25] = "";
                            flagArray[num25] = true;
                        }
                        numArray3[num25] = 0.6f;
                        numArray[num25] = 40;
                    }
                    if ((this.selectedMenu >= 2) && (this.selectedMenu < 9))
                    {
                        autoPass = false;
                        int num27 = this.selectedMenu - 2;
                        Netplay.serverPort = recentPort[num27];
                        Main.getIP = recentIP[num27];
                        if (Netplay.SetIP(Main.getIP))
                        {
                            Main.menuMode = 10;
                            Netplay.StartClient();
                        }
                        else if (Netplay.SetIP2(Main.getIP))
                        {
                            Main.menuMode = 10;
                            Netplay.StartClient();
                        }
                    }
                    if (this.selectedMenu == 10)
                    {
                        PlaySound(11, -1, -1, 1);
                        Main.menuMode = 1;
                    }
                    if ((this.selectedMenu == 9) || (!flagArray2[2] && inputTextEnter))
                    {
                        PlaySound(12, -1, -1, 1);
                        Main.menuMode = 0x83;
                    }
                }
                else if (Main.menuMode == 0x83)
                {
                    int num28 = 0x1e61;
                    string getPort = Main.getPort;
                    Main.getPort = GetInputText(Main.getPort);
                    if (getPort != Main.getPort)
                    {
                        PlaySound(12, -1, -1, 1);
                    }
                    strArray[0] = "Enter Server Port:";
                    flagArray2[2] = true;
                    if (Main.getPort != "")
                    {
                        bool flag5 = false;
                        try
                        {
                            num28 = Convert.ToInt32(Main.getPort);
                            if ((num28 > 0) && (num28 <= 0xffff))
                            {
                                flag5 = true;
                            }
                        }
                        catch
                        {
                        }
                        if (flag5)
                        {
                            flagArray2[2] = false;
                        }
                    }
                    this.textBlinkerCount++;
                    if (this.textBlinkerCount >= 20)
                    {
                        if (this.textBlinkerState == 0)
                        {
                            this.textBlinkerState = 1;
                        }
                        else
                        {
                            this.textBlinkerState = 0;
                        }
                        this.textBlinkerCount = 0;
                    }
                    strArray[1] = Main.getPort;
                    if (this.textBlinkerState == 1)
                    {
                        (strArray3 = strArray)[1] = strArray3[1] + "|";
                        numArray2[1] = 1;
                    }
                    else
                    {
                        (strArray3 = strArray)[1] = strArray3[1] + " ";
                    }
                    flagArray[0] = true;
                    flagArray[1] = true;
                    numArray[1] = -20;
                    numArray[2] = 20;
                    strArray[2] = "Accept";
                    strArray[3] = "Back";
                    num6 = 4;
                    if (this.selectedMenu == 3)
                    {
                        PlaySound(11, -1, -1, 1);
                        Main.menuMode = 1;
                    }
                    if ((this.selectedMenu == 2) || (!flagArray2[2] && inputTextEnter))
                    {
                        Netplay.serverPort = num28;
                        autoPass = false;
                        if (Netplay.SetIP(Main.getIP))
                        {
                            Main.menuMode = 10;
                            Netplay.StartClient();
                        }
                        else if (Netplay.SetIP2(Main.getIP))
                        {
                            Main.menuMode = 10;
                            Netplay.StartClient();
                        }
                    }
                }
                else if (Main.menuMode == 0x10)
                {
                    num3 = 200;
                    num5 = 60;
                    numArray[1] = 30;
                    numArray[2] = 30;
                    numArray[3] = 30;
                    numArray[4] = 70;
                    strArray[0] = "Choose world size:";
                    flagArray[0] = true;
                    strArray[1] = "Small";
                    strArray[2] = "Medium";
                    strArray[3] = "Large";
                    strArray[4] = "Back";
                    num6 = 5;
                    if (this.selectedMenu == 4)
                    {
                        Main.menuMode = 6;
                        PlaySound(11, -1, -1, 1);
                    }
                    else if (this.selectedMenu > 0)
                    {
                        if (this.selectedMenu == 1)
                        {
                            maxTilesX = 0x1068;
                            maxTilesY = 0x4b0;
                        }
                        else if (this.selectedMenu == 2)
                        {
                            maxTilesX = 0x189c;
                            maxTilesY = 0x708;
                        }
                        else
                        {
                            maxTilesX = 0x20d0;
                            maxTilesY = 0x960;
                        }
                        Main.menuMode = 7;
                        PlaySound(10, -1, -1, 1);
                        WorldGen.setWorldSize();
                    }
                }
            }
            else
            {
                num3 = 240;
                num5 = 60;
                num6 = 3;
                strArray[0] = "Fullscreen Resolution";
                strArray[1] = this.graphics.PreferredBackBufferWidth + "x" + this.graphics.PreferredBackBufferHeight;
                flagArray[0] = true;
                numArray[2] = 170;
                numArray[1] = 10;
                strArray[2] = "Back";
                if (this.selectedMenu == 1)
                {
                    PlaySound(12, -1, -1, 1);
                    int num21 = 0;
                    for (int num22 = 0; num22 < this.numDisplayModes; num22++)
                    {
                        if ((this.displayWidth[num22] == this.graphics.PreferredBackBufferWidth) && (this.displayHeight[num22] == this.graphics.PreferredBackBufferHeight))
                        {
                            num21 = num22;
                            break;
                        }
                    }
                    num21++;
                    if (num21 >= this.numDisplayModes)
                    {
                        num21 = 0;
                    }
                    this.graphics.PreferredBackBufferWidth = this.displayWidth[num21];
                    this.graphics.PreferredBackBufferHeight = this.displayHeight[num21];
                }
                if (this.selectedMenu == 2)
                {
                    if (this.graphics.IsFullScreen)
                    {
                        this.graphics.ApplyChanges();
                    }
                    Main.menuMode = 0x457;
                    PlaySound(11, -1, -1, 1);
                }
            }
            if (Main.menuMode != menuMode)
            {
                num6 = 0;
                for (int num29 = 0; num29 < maxMenuItems; num29++)
                {
                    this.menuItemScale[num29] = 0.8f;
                }
            }
            int focusMenu = this.focusMenu;
            this.selectedMenu = -1;
            this.selectedMenu2 = -1;
            this.focusMenu = -1;
            for (int k = 0; k < num6; k++)
            {
                if (strArray[k] != null)
                {
                    if (flag)
                    {
                        string text = "";
                        for (int num32 = 0; num32 < 6; num32++)
                        {
                            int num33 = num11;
                            int num34 = (370 + (screenWidth / 2)) - 400;
                            switch (num32)
                            {
                                case 0:
                                    text = "Red:";
                                    break;

                                case 1:
                                    text = "Green:";
                                    num33 += 30;
                                    break;

                                case 2:
                                    text = "Blue:";
                                    num33 += 60;
                                    break;

                                case 3:
                                    text = (this.selColor.R).ToString();
                                    num34 += 90;
                                    break;

                                case 4:
                                    text = (this.selColor.G).ToString();
                                    num34 += 90;
                                    num33 += 30;
                                    break;

                                case 5:
                                    text = (this.selColor.B).ToString();
                                    num34 += 90;
                                    num33 += 60;
                                    break;
                            }
                            for (int num35 = 0; num35 < 5; num35++)
                            {
                                Color black = Color.Black;
                                if (num35 == 4)
                                {
                                    black = color;
                                    black.R = (byte) ((0xff + black.R) / 2);
                                    black.G = (byte) ((0xff + black.R) / 2);
                                    black.B = (byte) ((0xff + black.R) / 2);
                                }
                                int num36 = 0xff;
                                int num37 = black.R - (0xff - num36);
                                if (num37 < 0)
                                {
                                    num37 = 0;
                                }
                                black = new Color((int) ((byte) num37), (int) ((byte) num37), (int) ((byte) num37), (int) ((byte) num36));
                                int num38 = 0;
                                int num39 = 0;
                                switch (num35)
                                {
                                    case 0:
                                        num38 = -2;
                                        break;

                                    case 1:
                                        num38 = 2;
                                        break;

                                    case 2:
                                        num39 = -2;
                                        break;

                                    case 3:
                                        num39 = 2;
                                        break;
                                }
                                vector9 = new Vector2();
                                this.spriteBatch.DrawString(fontDeathText, text, new Vector2((float) (num34 + num38), (float) (num33 + num39)), black, 0f, vector9, (float) 0.5f, SpriteEffects.None, 0f);
                            }
                        }
                        bool flag6 = false;
                        for (int num40 = 0; num40 < 2; num40++)
                        {
                            for (int num41 = 0; num41 < 3; num41++)
                            {
                                int num42 = (num11 + (num41 * 30)) - 12;
                                int num43 = (360 + (screenWidth / 2)) - 400;
                                float scale = 0.9f;
                                if (num40 == 0)
                                {
                                    num43 -= 70;
                                    num42 += 2;
                                }
                                else
                                {
                                    num43 -= 40;
                                }
                                text = "-";
                                if (num40 == 1)
                                {
                                    text = "+";
                                }
                                Vector2 vector3 = new Vector2(24f, 24f);
                                int num45 = 0x8e;
                                if (((mouseState.X > num43) && (mouseState.X < (num43 + vector3.X))) && ((mouseState.Y > (num42 + 13)) && (mouseState.Y < ((num42 + 13) + vector3.Y))))
                                {
                                    if (this.focusColor != ((num40 + 1) * (num41 + 10)))
                                    {
                                        PlaySound(12, -1, -1, 1);
                                    }
                                    this.focusColor = (num40 + 1) * (num41 + 10);
                                    flag6 = true;
                                    num45 = 0xff;
                                    if (mouseState.LeftButton == ButtonState.Pressed)
                                    {
                                        if (this.colorDelay <= 1)
                                        {
                                            if (this.colorDelay == 0)
                                            {
                                                this.colorDelay = 40;
                                            }
                                            else
                                            {
                                                this.colorDelay = 3;
                                            }
                                            int num46 = num40;
                                            if (num40 == 0)
                                            {
                                                num46 = -1;
                                                if (((this.selColor.R + this.selColor.G) + this.selColor.B) < 0xff)
                                                {
                                                    num46 = 0;
                                                }
                                            }
                                            if (((num41 == 0) && ((this.selColor.R + num46) >= 0)) && ((this.selColor.R + num46) <= 0xff))
                                            {
                                                this.selColor.R = (byte) (this.selColor.R + num46);
                                            }
                                            if (((num41 == 1) && ((this.selColor.G + num46) >= 0)) && ((this.selColor.G + num46) <= 0xff))
                                            {
                                                this.selColor.G = (byte) (this.selColor.G + num46);
                                            }
                                            if (((num41 == 2) && ((this.selColor.B + num46) >= 0)) && ((this.selColor.B + num46) <= 0xff))
                                            {
                                                this.selColor.B = (byte) (this.selColor.B + num46);
                                            }
                                        }
                                        this.colorDelay--;
                                    }
                                    else
                                    {
                                        this.colorDelay = 0;
                                    }
                                }
                                for (int num47 = 0; num47 < 5; num47++)
                                {
                                    Color color3 = Color.Black;
                                    if (num47 == 4)
                                    {
                                        color3 = color;
                                        color3.R = (byte) ((0xff + color3.R) / 2);
                                        color3.G = (byte) ((0xff + color3.R) / 2);
                                        color3.B = (byte) ((0xff + color3.R) / 2);
                                    }
                                    int num48 = color3.R - (0xff - num45);
                                    if (num48 < 0)
                                    {
                                        num48 = 0;
                                    }
                                    color3 = new Color((int) ((byte) num48), (int) ((byte) num48), (int) ((byte) num48), (int) ((byte) num45));
                                    int num49 = 0;
                                    int num50 = 0;
                                    switch (num47)
                                    {
                                        case 0:
                                            num49 = -2;
                                            break;

                                        case 1:
                                            num49 = 2;
                                            break;

                                        case 2:
                                            num50 = -2;
                                            break;

                                        case 3:
                                            num50 = 2;
                                            break;
                                    }
                                    vector9 = new Vector2();
                                    this.spriteBatch.DrawString(fontDeathText, text, new Vector2((float) (num43 + num49), (float) (num42 + num50)), color3, 0f, vector9, scale, SpriteEffects.None, 0f);
                                }
                            }
                        }
                        if (!flag6)
                        {
                            this.focusColor = 0;
                            this.colorDelay = 0;
                        }
                    }
                    if (flag3)
                    {
                        int num51 = 400;
                        string str9 = "";
                        for (int num52 = 0; num52 < 4; num52++)
                        {
                            int num53 = num51;
                            int num54 = (370 + (screenWidth / 2)) - 400;
                            if (num52 == 0)
                            {
                                str9 = "Parallax: " + this.bgScroll;
                            }
                            for (int num55 = 0; num55 < 5; num55++)
                            {
                                Color color4 = Color.Black;
                                if (num55 == 4)
                                {
                                    color4 = color;
                                    color4.R = (byte) ((0xff + color4.R) / 2);
                                    color4.G = (byte) ((0xff + color4.R) / 2);
                                    color4.B = (byte) ((0xff + color4.R) / 2);
                                }
                                int num56 = 0xff;
                                int num57 = color4.R - (0xff - num56);
                                if (num57 < 0)
                                {
                                    num57 = 0;
                                }
                                color4 = new Color((int) ((byte) num57), (int) ((byte) num57), (int) ((byte) num57), (int) ((byte) num56));
                                int num58 = 0;
                                int num59 = 0;
                                switch (num55)
                                {
                                    case 0:
                                        num58 = -2;
                                        break;

                                    case 1:
                                        num58 = 2;
                                        break;

                                    case 2:
                                        num59 = -2;
                                        break;

                                    case 3:
                                        num59 = 2;
                                        break;
                                }
                                vector9 = new Vector2();
                                this.spriteBatch.DrawString(fontDeathText, str9, new Vector2((float) (num54 + num58), (float) (num53 + num59)), color4, 0f, vector9, (float) 0.5f, SpriteEffects.None, 0f);
                            }
                        }
                        bool flag7 = false;
                        for (int num60 = 0; num60 < 2; num60++)
                        {
                            for (int num61 = 0; num61 < 1; num61++)
                            {
                                int num62 = (num51 + (num61 * 30)) - 12;
                                int num63 = (360 + (screenWidth / 2)) - 400;
                                float num64 = 0.9f;
                                if (num60 == 0)
                                {
                                    num63 -= 70;
                                    num62 += 2;
                                }
                                else
                                {
                                    num63 -= 40;
                                }
                                str9 = "-";
                                if (num60 == 1)
                                {
                                    str9 = "+";
                                }
                                Vector2 vector4 = new Vector2(24f, 24f);
                                int num65 = 0x8e;
                                if (((mouseState.X > num63) && (mouseState.X < (num63 + vector4.X))) && ((mouseState.Y > (num62 + 13)) && (mouseState.Y < ((num62 + 13) + vector4.Y))))
                                {
                                    if (this.focusColor != ((num60 + 1) * (num61 + 10)))
                                    {
                                        PlaySound(12, -1, -1, 1);
                                    }
                                    this.focusColor = (num60 + 1) * (num61 + 10);
                                    flag7 = true;
                                    num65 = 0xff;
                                    if (mouseState.LeftButton == ButtonState.Pressed)
                                    {
                                        if (this.colorDelay <= 1)
                                        {
                                            if (this.colorDelay == 0)
                                            {
                                                this.colorDelay = 40;
                                            }
                                            else
                                            {
                                                this.colorDelay = 3;
                                            }
                                            int num66 = num60;
                                            if (num60 == 0)
                                            {
                                                num66 = -1;
                                            }
                                            if (num61 == 0)
                                            {
                                                this.bgScroll += num66;
                                                if (this.bgScroll > 100)
                                                {
                                                    this.bgScroll = 100;
                                                }
                                                if (this.bgScroll < 0)
                                                {
                                                    this.bgScroll = 0;
                                                }
                                            }
                                        }
                                        this.colorDelay--;
                                    }
                                    else
                                    {
                                        this.colorDelay = 0;
                                    }
                                }
                                for (int num67 = 0; num67 < 5; num67++)
                                {
                                    Color color5 = Color.Black;
                                    if (num67 == 4)
                                    {
                                        color5 = color;
                                        color5.R = (byte) ((0xff + color5.R) / 2);
                                        color5.G = (byte) ((0xff + color5.R) / 2);
                                        color5.B = (byte) ((0xff + color5.R) / 2);
                                    }
                                    int num68 = color5.R - (0xff - num65);
                                    if (num68 < 0)
                                    {
                                        num68 = 0;
                                    }
                                    color5 = new Color((int) ((byte) num68), (int) ((byte) num68), (int) ((byte) num68), (int) ((byte) num65));
                                    int num69 = 0;
                                    int num70 = 0;
                                    switch (num67)
                                    {
                                        case 0:
                                            num69 = -2;
                                            break;

                                        case 1:
                                            num69 = 2;
                                            break;

                                        case 2:
                                            num70 = -2;
                                            break;

                                        case 3:
                                            num70 = 2;
                                            break;
                                    }
                                    vector9 = new Vector2();
                                    this.spriteBatch.DrawString(fontDeathText, str9, new Vector2((float) (num63 + num69), (float) (num62 + num70)), color5, 0f, vector9, num64, SpriteEffects.None, 0f);
                                }
                            }
                        }
                        if (!flag7)
                        {
                            this.focusColor = 0;
                            this.colorDelay = 0;
                        }
                    }
                    if (flag2)
                    {
                        int num71 = 400;
                        string str10 = "";
                        for (int num72 = 0; num72 < 4; num72++)
                        {
                            int num73 = num71;
                            int num74 = (370 + (screenWidth / 2)) - 400;
                            switch (num72)
                            {
                                case 0:
                                    str10 = "Sound:";
                                    break;

                                case 1:
                                    str10 = "Music:";
                                    num73 += 30;
                                    break;

                                case 2:
                                    str10 = Math.Round((double) (soundVolume * 100f)) + "%";
                                    num74 += 90;
                                    break;

                                case 3:
                                    str10 = Math.Round((double) (musicVolume * 100f)) + "%";
                                    num74 += 90;
                                    num73 += 30;
                                    break;
                            }
                            for (int num75 = 0; num75 < 5; num75++)
                            {
                                Color color6 = Color.Black;
                                if (num75 == 4)
                                {
                                    color6 = color;
                                    color6.R = (byte) ((0xff + color6.R) / 2);
                                    color6.G = (byte) ((0xff + color6.R) / 2);
                                    color6.B = (byte) ((0xff + color6.R) / 2);
                                }
                                int num76 = 0xff;
                                int num77 = color6.R - (0xff - num76);
                                if (num77 < 0)
                                {
                                    num77 = 0;
                                }
                                color6 = new Color((int) ((byte) num77), (int) ((byte) num77), (int) ((byte) num77), (int) ((byte) num76));
                                int num78 = 0;
                                int num79 = 0;
                                switch (num75)
                                {
                                    case 0:
                                        num78 = -2;
                                        break;

                                    case 1:
                                        num78 = 2;
                                        break;

                                    case 2:
                                        num79 = -2;
                                        break;

                                    case 3:
                                        num79 = 2;
                                        break;
                                }
                                vector9 = new Vector2();
                                this.spriteBatch.DrawString(fontDeathText, str10, new Vector2((float) (num74 + num78), (float) (num73 + num79)), color6, 0f, vector9, (float) 0.5f, SpriteEffects.None, 0f);
                            }
                        }
                        bool flag8 = false;
                        for (int num80 = 0; num80 < 2; num80++)
                        {
                            for (int num81 = 0; num81 < 2; num81++)
                            {
                                int num87;
                                int num82 = (num71 + (num81 * 30)) - 12;
                                int num83 = (360 + (screenWidth / 2)) - 400;
                                float num84 = 0.9f;
                                if (num80 == 0)
                                {
                                    num83 -= 70;
                                    num82 += 2;
                                }
                                else
                                {
                                    num83 -= 40;
                                }
                                str10 = "-";
                                if (num80 == 1)
                                {
                                    str10 = "+";
                                }
                                Vector2 vector5 = new Vector2(24f, 24f);
                                int num85 = 0x8e;
                                if (((mouseState.X <= num83) || (mouseState.X >= (num83 + vector5.X))) || ((mouseState.Y <= (num82 + 13)) || (mouseState.Y >= ((num82 + 13) + vector5.Y))))
                                {
                                    goto Label_3D46;
                                }
                                if (this.focusColor != ((num80 + 1) * (num81 + 10)))
                                {
                                    PlaySound(12, -1, -1, 1);
                                }
                                this.focusColor = (num80 + 1) * (num81 + 10);
                                flag8 = true;
                                num85 = 0xff;
                                if (mouseState.LeftButton != ButtonState.Pressed)
                                {
                                    goto Label_3D3F;
                                }
                                if (this.colorDelay <= 1)
                                {
                                    if (this.colorDelay == 0)
                                    {
                                        this.colorDelay = 40;
                                    }
                                    else
                                    {
                                        this.colorDelay = 3;
                                    }
                                    int num86 = num80;
                                    if (num80 == 0)
                                    {
                                        num86 = -1;
                                    }
                                    switch (num81)
                                    {
                                        case 0:
                                            soundVolume += num86 * 0.01f;
                                            if (soundVolume > 1f)
                                            {
                                                soundVolume = 1f;
                                            }
                                            if (soundVolume < 0f)
                                            {
                                                soundVolume = 0f;
                                            }
                                            break;

                                        case 1:
                                            musicVolume += num86 * 0.01f;
                                            if (musicVolume > 1f)
                                            {
                                                musicVolume = 1f;
                                            }
                                            if (musicVolume < 0f)
                                            {
                                                musicVolume = 0f;
                                            }
                                            goto Label_3D2F;
                                    }
                                }
                            Label_3D2F:
                                this.colorDelay--;
                                goto Label_3D46;
                            Label_3D3F:
                                this.colorDelay = 0;
                            Label_3D46:
                                num87 = 0;
                                while (num87 < 5)
                                {
                                    Color color7 = Color.Black;
                                    if (num87 == 4)
                                    {
                                        color7 = color;
                                        color7.R = (byte) ((0xff + color7.R) / 2);
                                        color7.G = (byte) ((0xff + color7.R) / 2);
                                        color7.B = (byte) ((0xff + color7.R) / 2);
                                    }
                                    int num88 = color7.R - (0xff - num85);
                                    if (num88 < 0)
                                    {
                                        num88 = 0;
                                    }
                                    color7 = new Color((int) ((byte) num88), (int) ((byte) num88), (int) ((byte) num88), (int) ((byte) num85));
                                    int num89 = 0;
                                    int num90 = 0;
                                    switch (num87)
                                    {
                                        case 0:
                                            num89 = -2;
                                            break;

                                        case 1:
                                            num89 = 2;
                                            break;

                                        case 2:
                                            num90 = -2;
                                            break;

                                        case 3:
                                            num90 = 2;
                                            break;
                                    }
                                    vector9 = new Vector2();
                                    this.spriteBatch.DrawString(fontDeathText, str10, new Vector2((float) (num83 + num89), (float) (num82 + num90)), color7, 0f, vector9, num84, SpriteEffects.None, 0f);
                                    num87++;
                                }
                            }
                        }
                        if (!flag8)
                        {
                            this.focusColor = 0;
                            this.colorDelay = 0;
                        }
                    }
                    for (int num91 = 0; num91 < 5; num91++)
                    {
                        Color hcColor = Color.Black;
                        if (num91 == 4)
                        {
                            hcColor = color;
                            if (buffer[k] == 2)
                            {
                                hcColor = Main.hcColor;
                            }
                            else if (buffer[k] == 1)
                            {
                                hcColor = mcColor;
                            }
                            hcColor.R = (byte) ((0xff + hcColor.R) / 2);
                            hcColor.G = (byte) ((0xff + hcColor.G) / 2);
                            hcColor.B = (byte) ((0xff + hcColor.B) / 2);
                        }
                        int num92 = (int) (255f * ((this.menuItemScale[k] * 2f) - 1f));
                        if (flagArray[k])
                        {
                            num92 = 0xff;
                        }
                        int num93 = hcColor.R - (0xff - num92);
                        if (num93 < 0)
                        {
                            num93 = 0;
                        }
                        int num94 = hcColor.G - (0xff - num92);
                        if (num94 < 0)
                        {
                            num94 = 0;
                        }
                        int num95 = hcColor.B - (0xff - num92);
                        if (num95 < 0)
                        {
                            num95 = 0;
                        }
                        hcColor = new Color((int) ((byte) num93), (int) ((byte) num94), (int) ((byte) num95), (int) ((byte) num92));
                        int num96 = 0;
                        int num97 = 0;
                        switch (num91)
                        {
                            case 0:
                                num96 = -2;
                                break;

                            case 1:
                                num96 = 2;
                                break;

                            case 2:
                                num97 = -2;
                                break;

                            case 3:
                                num97 = 2;
                                break;
                        }
                        Vector2 origin = fontDeathText.MeasureString(strArray[k]);
                        origin.X *= 0.5f;
                        origin.Y *= 0.5f;
                        float num98 = this.menuItemScale[k];
                        if ((Main.menuMode == 15) && (k == 0))
                        {
                            num98 *= 0.35f;
                        }
                        else if (netMode == 2)
                        {
                            num98 *= 0.5f;
                        }
                        num98 *= numArray3[k];
                        if (!flagArray3[k])
                        {
                            this.spriteBatch.DrawString(fontDeathText, strArray[k], new Vector2((float) ((num4 + num96) + numArray2[k]), (((num3 + (num5 * k)) + num97) + (origin.Y * numArray3[k])) + numArray[k]), hcColor, 0f, origin, num98, SpriteEffects.None, 0f);
                        }
                        else
                        {
                            this.spriteBatch.DrawString(fontDeathText, strArray[k], new Vector2((float) ((num4 + num96) + numArray2[k]), (((num3 + (num5 * k)) + num97) + (origin.Y * numArray3[k])) + numArray[k]), hcColor, 0f, new Vector2(0f, origin.Y), num98, SpriteEffects.None, 0f);
                        }
                    }
                    if (!flagArray3[k])
                    {
                        if ((((mouseState.X > ((num4 - ((strArray[k].Length * 10) * numArray3[k])) + numArray2[k])) && (mouseState.X < ((num4 + ((strArray[k].Length * 10) * numArray3[k])) + numArray2[k]))) && ((mouseState.Y > ((num3 + (num5 * k)) + numArray[k])) && (mouseState.Y < (((num3 + (num5 * k)) + numArray[k]) + (50f * numArray3[k]))))) && hasFocus)
                        {
                            this.focusMenu = k;
                            if (flagArray[k] || flagArray2[k])
                            {
                                this.focusMenu = -1;
                            }
                            else
                            {
                                if (focusMenu != this.focusMenu)
                                {
                                    PlaySound(12, -1, -1, 1);
                                }
                                if (mouseLeftRelease && (mouseState.LeftButton == ButtonState.Pressed))
                                {
                                    this.selectedMenu = k;
                                }
                                if (mouseRightRelease && (mouseState.RightButton == ButtonState.Pressed))
                                {
                                    this.selectedMenu2 = k;
                                }
                            }
                        }
                    }
                    else if ((((mouseState.X > (num4 + numArray2[k])) && (mouseState.X < ((num4 + ((strArray[k].Length * 20) * numArray3[k])) + numArray2[k]))) && ((mouseState.Y > ((num3 + (num5 * k)) + numArray[k])) && (mouseState.Y < (((num3 + (num5 * k)) + numArray[k]) + (50f * numArray3[k]))))) && hasFocus)
                    {
                        this.focusMenu = k;
                        if (flagArray[k] || flagArray2[k])
                        {
                            this.focusMenu = -1;
                        }
                        else
                        {
                            if (focusMenu != this.focusMenu)
                            {
                                PlaySound(12, -1, -1, 1);
                            }
                            if (mouseLeftRelease && (mouseState.LeftButton == ButtonState.Pressed))
                            {
                                this.selectedMenu = k;
                            }
                            if (mouseRightRelease && (mouseState.RightButton == ButtonState.Pressed))
                            {
                                this.selectedMenu2 = k;
                            }
                        }
                    }
                }
            }
            for (int m = 0; m < maxMenuItems; m++)
            {
                if (m == this.focusMenu)
                {
                    if (this.menuItemScale[m] < 1f)
                    {
                        this.menuItemScale[m] += 0.02f;
                    }
                    if (this.menuItemScale[m] > 1f)
                    {
                        this.menuItemScale[m] = 1f;
                    }
                }
                else if (this.menuItemScale[m] > 0.8)
                {
                    this.menuItemScale[m] -= 0.02f;
                }
            }
            if (index >= 0)
            {
                loadPlayer[index].PlayerFrame();
                loadPlayer[index].position.X = num9 + screenPosition.X;
                loadPlayer[index].position.Y = num10 + screenPosition.Y;
                this.DrawPlayer(loadPlayer[index]);
            }
            for (int n = 0; n < 5; n++)
            {
                Color color9 = Color.Black;
                if (n == 4)
                {
                    color9 = color;
                    color9.R = (byte) ((0xff + color9.R) / 2);
                    color9.G = (byte) ((0xff + color9.R) / 2);
                    color9.B = (byte) ((0xff + color9.R) / 2);
                }
                color9.A = (byte) (color9.A * 0.3f);
                int num101 = 0;
                int num102 = 0;
                switch (n)
                {
                    case 0:
                        num101 = -2;
                        break;

                    case 1:
                        num101 = 2;
                        break;

                    case 2:
                        num102 = -2;
                        break;

                    case 3:
                        num102 = 2;
                        break;
                }
                string str11 = "Copyright \x00a9 2011 Re-Logic";
                Vector2 vector7 = fontMouseText.MeasureString(str11);
                vector7.X *= 0.5f;
                vector7.Y *= 0.5f;
                this.spriteBatch.DrawString(fontMouseText, str11, new Vector2(((screenWidth - vector7.X) + num101) - 10f, ((screenHeight - vector7.Y) + num102) - 2f), color9, 0f, vector7, (float) 1f, SpriteEffects.None, 0f);
            }
            for (int num103 = 0; num103 < 5; num103++)
            {
                Color color10 = Color.Black;
                if (num103 == 4)
                {
                    color10 = color;
                    color10.R = (byte) ((0xff + color10.R) / 2);
                    color10.G = (byte) ((0xff + color10.R) / 2);
                    color10.B = (byte) ((0xff + color10.R) / 2);
                }
                color10.A = (byte) (color10.A * 0.3f);
                int num104 = 0;
                int num105 = 0;
                switch (num103)
                {
                    case 0:
                        num104 = -2;
                        break;

                    case 1:
                        num104 = 2;
                        break;

                    case 2:
                        num105 = -2;
                        break;

                    case 3:
                        num105 = 2;
                        break;
                }
                Vector2 vector8 = fontMouseText.MeasureString(versionNumber);
                vector8.X *= 0.5f;
                vector8.Y *= 0.5f;
                this.spriteBatch.DrawString(fontMouseText, versionNumber, new Vector2((vector8.X + num104) + 10f, ((screenHeight - vector8.Y) + num105) - 2f), color10, 0f, vector8, (float) 1f, SpriteEffects.None, 0f);
            }
            vector9 = new Vector2();
            this.spriteBatch.Draw(cursorTexture, new Vector2((float) (mouseState.X + 1), (float) (mouseState.Y + 1)), new Rectangle(0, 0, cursorTexture.Width, cursorTexture.Height), new Color((int) (cursorColor.R * 0.2f), (int) (cursorColor.G * 0.2f), (int) (cursorColor.B * 0.2f), (int) (cursorColor.A * 0.5f)), 0f, vector9, (float) (cursorScale * 1.1f), SpriteEffects.None, 0f);
            this.spriteBatch.Draw(cursorTexture, new Vector2((float) mouseState.X, (float) mouseState.Y), new Rectangle(0, 0, cursorTexture.Width, cursorTexture.Height), cursorColor, 0f, new Vector2(), cursorScale, SpriteEffects.None, 0f);
            if (fadeCounter > 0)
            {
                Color white = Color.White;
                byte num106 = 0;
                fadeCounter--;
                float num107 = (((float) fadeCounter) / 75f) * 255f;
                num106 = (byte) num107;
                white = new Color((int) num106, (int) num106, (int) num106, (int) num106);
                this.spriteBatch.Draw(fadeTexture, new Rectangle(0, 0, screenWidth, screenHeight), white);
            }
            this.spriteBatch.End();
            if (mouseState.LeftButton == ButtonState.Pressed)
            {
                mouseLeftRelease = false;
            }
            else
            {
                mouseLeftRelease = true;
            }
            if (mouseState.RightButton == ButtonState.Pressed)
            {
                mouseRightRelease = false;
            }
            else
            {
                mouseRightRelease = true;
            }
        }

        protected void DrawNPCs(bool behindTiles = false)
        {
            Rectangle rectangle = new Rectangle(((int) screenPosition.X) - 300, ((int) screenPosition.Y) - 300, screenWidth + 600, screenHeight + 600);
            for (int i = 0x3e7; i >= 0; i--)
            {
                if ((npc[i].active && (npc[i].type > 0)) && ((npc[i].behindTiles == behindTiles) && rectangle.Intersects(new Rectangle((int) npc[i].position.X, (int) npc[i].position.Y, npc[i].width, npc[i].height))))
                {
                    if (npc[i].aiStyle == 13)
                    {
                        Vector2 vector = new Vector2(npc[i].position.X + (npc[i].width / 2), npc[i].position.Y + (npc[i].height / 2));
                        float num2 = ((npc[i].ai[0] * 16f) + 8f) - vector.X;
                        float num3 = ((npc[i].ai[1] * 16f) + 8f) - vector.Y;
                        float rotation = ((float) Math.Atan2((double) num3, (double) num2)) - 1.57f;
                        bool flag = true;
                        while (flag)
                        {
                            int height = 0x1c;
                            float num6 = (float) Math.Sqrt((double) ((num2 * num2) + (num3 * num3)));
                            if (num6 < 40f)
                            {
                                height = (((int) num6) - 40) + 0x1c;
                                flag = false;
                            }
                            num6 = 28f / num6;
                            num2 *= num6;
                            num3 *= num6;
                            vector.X += num2;
                            vector.Y += num3;
                            num2 = ((npc[i].ai[0] * 16f) + 8f) - vector.X;
                            num3 = ((npc[i].ai[1] * 16f) + 8f) - vector.Y;
                            Color color = Lighting.GetColor(((int) vector.X) / 0x10, (int) (vector.Y / 16f));
                            if (npc[i].type == 0x38)
                            {
                                this.spriteBatch.Draw(chain5Texture, new Vector2(vector.X - screenPosition.X, vector.Y - screenPosition.Y), new Rectangle(0, 0, chain4Texture.Width, height), color, rotation, new Vector2(chain4Texture.Width * 0.5f, chain4Texture.Height * 0.5f), (float) 1f, SpriteEffects.None, 0f);
                            }
                            else
                            {
                                this.spriteBatch.Draw(chain4Texture, new Vector2(vector.X - screenPosition.X, vector.Y - screenPosition.Y), new Rectangle(0, 0, chain4Texture.Width, height), color, rotation, new Vector2(chain4Texture.Width * 0.5f, chain4Texture.Height * 0.5f), (float) 1f, SpriteEffects.None, 0f);
                            }
                        }
                    }
                    if (npc[i].type == 0x24)
                    {
                        Vector2 vector2 = new Vector2((npc[i].position.X + (npc[i].width * 0.5f)) - (5f * npc[i].ai[0]), npc[i].position.Y + 20f);
                        for (int j = 0; j < 2; j++)
                        {
                            float num8 = (npc[(int) npc[i].ai[1]].position.X + (npc[(int) npc[i].ai[1]].width / 2)) - vector2.X;
                            float num9 = (npc[(int) npc[i].ai[1]].position.Y + (npc[(int) npc[i].ai[1]].height / 2)) - vector2.Y;
                            float num10 = 0f;
                            if (j == 0)
                            {
                                num8 -= 200f * npc[i].ai[0];
                                num9 += 130f;
                                num10 = (float) Math.Sqrt((double) ((num8 * num8) + (num9 * num9)));
                                num10 = 92f / num10;
                                vector2.X += num8 * num10;
                                vector2.Y += num9 * num10;
                            }
                            else
                            {
                                num8 -= 50f * npc[i].ai[0];
                                num9 += 80f;
                                num10 = (float) Math.Sqrt((double) ((num8 * num8) + (num9 * num9)));
                                num10 = 60f / num10;
                                vector2.X += num8 * num10;
                                vector2.Y += num9 * num10;
                            }
                            float num11 = ((float) Math.Atan2((double) num9, (double) num8)) - 1.57f;
                            Color color2 = Lighting.GetColor(((int) vector2.X) / 0x10, (int) (vector2.Y / 16f));
                            this.spriteBatch.Draw(boneArmTexture, new Vector2(vector2.X - screenPosition.X, vector2.Y - screenPosition.Y), new Rectangle(0, 0, boneArmTexture.Width, boneArmTexture.Height), color2, num11, new Vector2(boneArmTexture.Width * 0.5f, boneArmTexture.Height * 0.5f), (float) 1f, SpriteEffects.None, 0f);
                            if (j == 0)
                            {
                                vector2.X += (num8 * num10) / 2f;
                                vector2.Y += (num9 * num10) / 2f;
                            }
                            else if (base.IsActive)
                            {
                                vector2.X += (num8 * num10) - 16f;
                                vector2.Y += (num9 * num10) - 6f;
                                Color color5 = new Color();
                                int index = Dust.NewDust(new Vector2(vector2.X, vector2.Y), 30, 10, 5, num8 * 0.02f, num9 * 0.02f, 0, color5, 2f);
                                dust[index].noGravity = true;
                            }
                        }
                    }
                    if (npc[i].aiStyle == 20)
                    {
                        Vector2 vector3 = new Vector2(npc[i].position.X + (npc[i].width / 2), npc[i].position.Y + (npc[i].height / 2));
                        float num13 = npc[i].ai[1] - vector3.X;
                        float num14 = npc[i].ai[2] - vector3.Y;
                        float num15 = ((float) Math.Atan2((double) num14, (double) num13)) - 1.57f;
                        npc[i].rotation = num15;
                        bool flag2 = true;
                        while (flag2)
                        {
                            int num16 = 12;
                            float num17 = (float) Math.Sqrt((double) ((num13 * num13) + (num14 * num14)));
                            if (num17 < 20f)
                            {
                                num16 = (((int) num17) - 20) + 12;
                                flag2 = false;
                            }
                            num17 = 12f / num17;
                            num13 *= num17;
                            num14 *= num17;
                            vector3.X += num13;
                            vector3.Y += num14;
                            num13 = npc[i].ai[1] - vector3.X;
                            num14 = npc[i].ai[2] - vector3.Y;
                            Color color3 = Lighting.GetColor(((int) vector3.X) / 0x10, (int) (vector3.Y / 16f));
                            this.spriteBatch.Draw(chainTexture, new Vector2(vector3.X - screenPosition.X, vector3.Y - screenPosition.Y), new Rectangle(0, 0, chainTexture.Width, num16), color3, num15, new Vector2(chainTexture.Width * 0.5f, chainTexture.Height * 0.5f), (float) 1f, SpriteEffects.None, 0f);
                        }
                        this.spriteBatch.Draw(spikeBaseTexture, new Vector2(npc[i].ai[1] - screenPosition.X, npc[i].ai[2] - screenPosition.Y), new Rectangle(0, 0, spikeBaseTexture.Width, spikeBaseTexture.Height), Lighting.GetColor(((int) npc[i].ai[1]) / 0x10, (int) (npc[i].ai[2] / 16f)), num15 - 0.75f, new Vector2(spikeBaseTexture.Width * 0.5f, spikeBaseTexture.Height * 0.5f), (float) 1f, SpriteEffects.None, 0f);
                    }
                    Color newColor = Lighting.GetColor(((int) (npc[i].position.X + (npc[i].width * 0.5))) / 0x10, (int) ((npc[i].position.Y + (npc[i].height * 0.5)) / 16.0));
                    float r = 1f;
                    float g = 1f;
                    float b = 1f;
                    float a = 1f;
                    if (npc[i].poisoned)
                    {
                        if (rand.Next(30) == 0)
                        {
                            Color color6 = new Color();
                            int num22 = Dust.NewDust(npc[i].position, npc[i].width, npc[i].height, 0x2e, 0f, 0f, 120, color6, 0.2f);
                            dust[num22].noGravity = true;
                            dust[num22].fadeIn = 1.9f;
                        }
                        r *= 0.65f;
                        b *= 0.75f;
                    }
                    if (npc[i].onFire)
                    {
                        if (rand.Next(4) < 3)
                        {
                            Color color7 = new Color();
                            int num23 = Dust.NewDust(new Vector2(npc[i].position.X - 2f, npc[i].position.Y - 2f), npc[i].width + 4, npc[i].height + 4, 6, npc[i].velocity.X * 0.4f, npc[i].velocity.Y * 0.4f, 100, color7, 2.5f);
                            dust[num23].noGravity = true;
                            Dust dust1 = dust[num23];
                            dust1.velocity = (Vector2) (dust1.velocity * 1.8f);
                            dust[num23].velocity.Y -= 0.5f;
                        }
                        b *= 0.6f;
                        g *= 0.7f;
                    }
                    if (((r != 1f) || (g != 1f)) || ((b != 1f) || (a != 1f)))
                    {
                        newColor = buffColor(newColor, r, g, b, a);
                    }
                    if (player[myPlayer].detectCreature && (npc[i].lifeMax > 1))
                    {
                        if (newColor.R < 150)
                        {
                            newColor.A = mouseTextColor;
                        }
                        if (newColor.R < 50)
                        {
                            newColor.R = 50;
                        }
                        if (newColor.G < 200)
                        {
                            newColor.G = 200;
                        }
                        if (newColor.B < 100)
                        {
                            newColor.B = 100;
                        }
                        if ((!gamePaused && base.IsActive) && (rand.Next(50) == 0))
                        {
                            Color color8 = new Color();
                            int num24 = Dust.NewDust(new Vector2(npc[i].position.X, npc[i].position.Y), npc[i].width, npc[i].height, 15, 0f, 0f, 150, color8, 0.8f);
                            Dust dust2 = dust[num24];
                            dust2.velocity = (Vector2) (dust2.velocity * 0.1f);
                            dust[num24].noLight = true;
                        }
                    }
                    if (npc[i].type == 50)
                    {
                        Vector2 vector4 = new Vector2();
                        float num25 = 0f;
                        vector4.Y -= npc[i].velocity.Y;
                        vector4.X -= npc[i].velocity.X * 2f;
                        num25 += npc[i].velocity.X * 0.05f;
                        if (npc[i].frame.Y == 120)
                        {
                            vector4.Y += 2f;
                        }
                        if (npc[i].frame.Y == 360)
                        {
                            vector4.Y -= 2f;
                        }
                        if (npc[i].frame.Y == 480)
                        {
                            vector4.Y -= 6f;
                        }
                        this.spriteBatch.Draw(ninjaTexture, new Vector2(((npc[i].position.X - screenPosition.X) + (npc[i].width / 2)) + vector4.X, ((npc[i].position.Y - screenPosition.Y) + (npc[i].height / 2)) + vector4.Y), new Rectangle(0, 0, ninjaTexture.Width, ninjaTexture.Height), newColor, num25, new Vector2((float) (ninjaTexture.Width / 2), (float) (ninjaTexture.Height / 2)), (float) 1f, SpriteEffects.None, 0f);
                    }
                    if (npc[i].type == 0x47)
                    {
                        Vector2 vector5 = new Vector2();
                        float num26 = 0f;
                        vector5.Y -= npc[i].velocity.Y * 0.3f;
                        vector5.X -= npc[i].velocity.X * 0.6f;
                        num26 += npc[i].velocity.X * 0.09f;
                        if (npc[i].frame.Y == 120)
                        {
                            vector5.Y += 2f;
                        }
                        if (npc[i].frame.Y == 360)
                        {
                            vector5.Y -= 2f;
                        }
                        if (npc[i].frame.Y == 480)
                        {
                            vector5.Y -= 6f;
                        }
                        this.spriteBatch.Draw(itemTexture[0x147], new Vector2(((npc[i].position.X - screenPosition.X) + (npc[i].width / 2)) + vector5.X, ((npc[i].position.Y - screenPosition.Y) + (npc[i].height / 2)) + vector5.Y), new Rectangle(0, 0, itemTexture[0x147].Width, itemTexture[0x147].Height), newColor, num26, new Vector2((float) (itemTexture[0x147].Width / 2), (float) (itemTexture[0x147].Height / 2)), (float) 1f, SpriteEffects.None, 0f);
                    }
                    if (npc[i].type == 0x45)
                    {
                        this.spriteBatch.Draw(antLionTexture, new Vector2((npc[i].position.X - screenPosition.X) + (npc[i].width / 2), ((npc[i].position.Y - screenPosition.Y) + npc[i].height) + 14f), new Rectangle(0, 0, antLionTexture.Width, antLionTexture.Height), newColor, -npc[i].rotation * 0.3f, new Vector2((float) (antLionTexture.Width / 2), (float) (antLionTexture.Height / 2)), (float) 1f, SpriteEffects.None, 0f);
                    }
                    float num27 = 0f;
                    Vector2 origin = new Vector2((float) (npcTexture[npc[i].type].Width / 2), (float) ((npcTexture[npc[i].type].Height / npcFrameCount[npc[i].type]) / 2));
                    if (npc[i].type == 4)
                    {
                        origin = new Vector2(55f, 107f);
                    }
                    else if (npc[i].type == 6)
                    {
                        num27 = 26f;
                    }
                    else if (((npc[i].type == 7) || (npc[i].type == 8)) || (npc[i].type == 9))
                    {
                        num27 = 13f;
                    }
                    else if (((npc[i].type == 10) || (npc[i].type == 11)) || (npc[i].type == 12))
                    {
                        num27 = 8f;
                    }
                    else if (((npc[i].type == 13) || (npc[i].type == 14)) || (npc[i].type == 15))
                    {
                        num27 = 26f;
                    }
                    else if (npc[i].type == 0x30)
                    {
                        num27 = 32f;
                    }
                    else if ((npc[i].type == 0x31) || (npc[i].type == 0x33))
                    {
                        num27 = 4f;
                    }
                    else if (npc[i].type == 60)
                    {
                        num27 = 10f;
                    }
                    else if ((npc[i].type == 0x3e) || (npc[i].type == 0x42))
                    {
                        num27 = 14f;
                    }
                    else if ((npc[i].type == 0x3f) || (npc[i].type == 0x40))
                    {
                        num27 = 4f;
                    }
                    else if (npc[i].type == 0x41)
                    {
                        num27 = 14f;
                    }
                    else if (npc[i].type == 0x45)
                    {
                        num27 = 4f;
                        origin.Y += 8f;
                    }
                    else if (npc[i].type == 70)
                    {
                        num27 = -4f;
                    }
                    else if (npc[i].type == 0x48)
                    {
                        num27 = -2f;
                    }
                    else if (((npc[i].type == 0x27) || (npc[i].type == 40)) || (npc[i].type == 0x29))
                    {
                        num27 = 26f;
                    }
                    num27 *= npc[i].scale;
                    if ((npc[i].aiStyle == 10) || (npc[i].type == 0x48))
                    {
                        newColor = Color.White;
                    }
                    SpriteEffects none = SpriteEffects.None;
                    if (npc[i].spriteDirection == 1)
                    {
                        none = SpriteEffects.FlipHorizontally;
                    }
                    this.spriteBatch.Draw(npcTexture[npc[i].type], new Vector2((((npc[i].position.X - screenPosition.X) + (npc[i].width / 2)) - ((npcTexture[npc[i].type].Width * npc[i].scale) / 2f)) + (origin.X * npc[i].scale), (((((npc[i].position.Y - screenPosition.Y) + npc[i].height) - ((npcTexture[npc[i].type].Height * npc[i].scale) / ((float) npcFrameCount[npc[i].type]))) + 4f) + (origin.Y * npc[i].scale)) + num27), new Rectangle?(npc[i].frame), npc[i].GetAlpha(newColor), npc[i].rotation, origin, npc[i].scale, none, 0f);
                    Color color9 = new Color();
                    if (npc[i].color != color9)
                    {
                        this.spriteBatch.Draw(npcTexture[npc[i].type], new Vector2((((npc[i].position.X - screenPosition.X) + (npc[i].width / 2)) - ((npcTexture[npc[i].type].Width * npc[i].scale) / 2f)) + (origin.X * npc[i].scale), (((((npc[i].position.Y - screenPosition.Y) + npc[i].height) - ((npcTexture[npc[i].type].Height * npc[i].scale) / ((float) npcFrameCount[npc[i].type]))) + 4f) + (origin.Y * npc[i].scale)) + num27), new Rectangle?(npc[i].frame), npc[i].GetColor(newColor), npc[i].rotation, origin, npc[i].scale, none, 0f);
                    }
                }
            }
        }

        protected void DrawPlayer(Player drawPlayer)
        {
            SpriteEffects none = SpriteEffects.None;
            SpriteEffects flipHorizontally = SpriteEffects.FlipHorizontally;
            Color immuneAlpha = drawPlayer.GetImmuneAlpha(Lighting.GetColor(((int) (drawPlayer.position.X + (drawPlayer.width * 0.5))) / 0x10, (int) ((drawPlayer.position.Y + (drawPlayer.height * 0.25)) / 16.0), Color.White));
            Color newColor = drawPlayer.GetImmuneAlpha(Lighting.GetColor(((int) (drawPlayer.position.X + (drawPlayer.width * 0.5))) / 0x10, (int) ((drawPlayer.position.Y + (drawPlayer.height * 0.25)) / 16.0), drawPlayer.eyeColor));
            Color color3 = drawPlayer.GetImmuneAlpha(Lighting.GetColor(((int) (drawPlayer.position.X + (drawPlayer.width * 0.5))) / 0x10, (int) ((drawPlayer.position.Y + (drawPlayer.height * 0.25)) / 16.0), drawPlayer.hairColor));
            Color color4 = drawPlayer.GetImmuneAlpha(Lighting.GetColor(((int) (drawPlayer.position.X + (drawPlayer.width * 0.5))) / 0x10, (int) ((drawPlayer.position.Y + (drawPlayer.height * 0.25)) / 16.0), drawPlayer.skinColor));
            Color color5 = drawPlayer.GetImmuneAlpha(Lighting.GetColor(((int) (drawPlayer.position.X + (drawPlayer.width * 0.5))) / 0x10, (int) ((drawPlayer.position.Y + (drawPlayer.height * 0.5)) / 16.0), drawPlayer.skinColor));
            Color color6 = drawPlayer.GetImmuneAlpha(Lighting.GetColor(((int) (drawPlayer.position.X + (drawPlayer.width * 0.5))) / 0x10, (int) ((drawPlayer.position.Y + (drawPlayer.height * 0.5)) / 16.0), drawPlayer.shirtColor));
            Color color7 = drawPlayer.GetImmuneAlpha(Lighting.GetColor(((int) (drawPlayer.position.X + (drawPlayer.width * 0.5))) / 0x10, (int) ((drawPlayer.position.Y + (drawPlayer.height * 0.5)) / 16.0), drawPlayer.underShirtColor));
            Color color8 = drawPlayer.GetImmuneAlpha(Lighting.GetColor(((int) (drawPlayer.position.X + (drawPlayer.width * 0.5))) / 0x10, (int) ((drawPlayer.position.Y + (drawPlayer.height * 0.75)) / 16.0), drawPlayer.pantsColor));
            Color color9 = drawPlayer.GetImmuneAlpha(Lighting.GetColor(((int) (drawPlayer.position.X + (drawPlayer.width * 0.5))) / 0x10, (int) ((drawPlayer.position.Y + (drawPlayer.height * 0.75)) / 16.0), drawPlayer.shoeColor));
            Color color10 = drawPlayer.GetImmuneAlpha(Lighting.GetColor(((int) (drawPlayer.position.X + (drawPlayer.width * 0.5))) / 0x10, ((int) (drawPlayer.position.Y + (drawPlayer.height * 0.75))) / 0x10, Color.White));
            Color color11 = drawPlayer.GetImmuneAlpha(Lighting.GetColor(((int) (drawPlayer.position.X + (drawPlayer.width * 0.5))) / 0x10, ((int) (drawPlayer.position.Y + (drawPlayer.height * 0.5))) / 0x10, Color.White));
            Color color12 = drawPlayer.GetImmuneAlpha(Lighting.GetColor(((int) (drawPlayer.position.X + (drawPlayer.width * 0.5))) / 0x10, ((int) (drawPlayer.position.Y + (drawPlayer.height * 0.25))) / 0x10, Color.White));
            float r = 1f;
            float g = 1f;
            float b = 1f;
            float a = 1f;
            if (drawPlayer.poisoned)
            {
                if (rand.Next(50) == 0)
                {
                    int index = Dust.NewDust(drawPlayer.position, drawPlayer.width, drawPlayer.height, 0x2e, 0f, 0f, 150, new Color(), 0.2f);
                    dust[index].noGravity = true;
                    dust[index].fadeIn = 1.9f;
                }
                r *= 0.65f;
                b *= 0.75f;
            }
            if (drawPlayer.onFire)
            {
                if (rand.Next(4) == 0)
                {
                    int num6 = Dust.NewDust(new Vector2(drawPlayer.position.X - 2f, drawPlayer.position.Y - 2f), drawPlayer.width + 4, drawPlayer.height + 4, 6, drawPlayer.velocity.X * 0.4f, drawPlayer.velocity.Y * 0.4f, 100, new Color(), 2.5f);
                    dust[num6].noGravity = true;
                    Dust dust1 = dust[num6];
                    dust1.velocity = (Vector2) (dust1.velocity * 1.8f);
                    dust[num6].velocity.Y -= 0.5f;
                }
                b *= 0.6f;
                g *= 0.7f;
            }
            if (drawPlayer.noItems)
            {
                g *= 0.8f;
                r *= 0.65f;
            }
            if (drawPlayer.blind)
            {
                g *= 0.65f;
                r *= 0.7f;
            }
            if (((r != 1f) || (g != 1f)) || ((b != 1f) || (a != 1f)))
            {
                immuneAlpha = buffColor(immuneAlpha, r, g, b, a);
                newColor = buffColor(newColor, r, g, b, a);
                color3 = buffColor(color3, r, g, b, a);
                color4 = buffColor(color4, r, g, b, a);
                color5 = buffColor(color5, r, g, b, a);
                color6 = buffColor(color6, r, g, b, a);
                color7 = buffColor(color7, r, g, b, a);
                color8 = buffColor(color8, r, g, b, a);
                color9 = buffColor(color9, r, g, b, a);
                color10 = buffColor(color10, r, g, b, a);
                color11 = buffColor(color11, r, g, b, a);
                color12 = buffColor(color12, r, g, b, a);
            }
            if (drawPlayer.gravDir == 1f)
            {
                if (drawPlayer.direction == 1)
                {
                    none = SpriteEffects.None;
                    flipHorizontally = SpriteEffects.None;
                }
                else
                {
                    none = SpriteEffects.FlipHorizontally;
                    flipHorizontally = SpriteEffects.FlipHorizontally;
                }
                if (!drawPlayer.dead)
                {
                    drawPlayer.legPosition.Y = 0f;
                    drawPlayer.headPosition.Y = 0f;
                    drawPlayer.bodyPosition.Y = 0f;
                }
            }
            else
            {
                if (drawPlayer.direction == 1)
                {
                    none = SpriteEffects.FlipVertically;
                    flipHorizontally = SpriteEffects.FlipVertically;
                }
                else
                {
                    none = SpriteEffects.FlipVertically | SpriteEffects.FlipHorizontally;
                    flipHorizontally = SpriteEffects.FlipVertically | SpriteEffects.FlipHorizontally;
                }
                if (!drawPlayer.dead)
                {
                    drawPlayer.legPosition.Y = 6f;
                    drawPlayer.headPosition.Y = 6f;
                    drawPlayer.bodyPosition.Y = 6f;
                }
            }
            Vector2 origin = new Vector2(drawPlayer.legFrame.Width * 0.5f, drawPlayer.legFrame.Height * 0.75f);
            Vector2 vector2 = new Vector2(drawPlayer.legFrame.Width * 0.5f, drawPlayer.legFrame.Height * 0.5f);
            Vector2 vector3 = new Vector2(drawPlayer.legFrame.Width * 0.5f, drawPlayer.legFrame.Height * 0.25f);
            if ((drawPlayer.legs > 0) && (drawPlayer.legs < 0x10))
            {
                this.spriteBatch.Draw(armorLegTexture[drawPlayer.legs], (new Vector2((float) ((((int) (drawPlayer.position.X - screenPosition.X)) - (drawPlayer.legFrame.Width / 2)) + (drawPlayer.width / 2)), (float) ((int) ((((drawPlayer.position.Y - screenPosition.Y) + drawPlayer.height) - drawPlayer.legFrame.Height) + 4f))) + drawPlayer.legPosition) + origin, new Rectangle?(drawPlayer.legFrame), color12, drawPlayer.legRotation, origin, (float) 1f, none, 0f);
            }
            else if (!drawPlayer.invis)
            {
                this.spriteBatch.Draw(playerPantsTexture, (new Vector2((float) ((((int) (drawPlayer.position.X - screenPosition.X)) - (drawPlayer.legFrame.Width / 2)) + (drawPlayer.width / 2)), (float) ((int) ((((drawPlayer.position.Y - screenPosition.Y) + drawPlayer.height) - drawPlayer.legFrame.Height) + 4f))) + drawPlayer.legPosition) + origin, new Rectangle?(drawPlayer.legFrame), color8, drawPlayer.legRotation, origin, (float) 1f, none, 0f);
                this.spriteBatch.Draw(playerShoesTexture, (new Vector2((float) ((((int) (drawPlayer.position.X - screenPosition.X)) - (drawPlayer.legFrame.Width / 2)) + (drawPlayer.width / 2)), (float) ((int) ((((drawPlayer.position.Y - screenPosition.Y) + drawPlayer.height) - drawPlayer.legFrame.Height) + 4f))) + drawPlayer.legPosition) + origin, new Rectangle?(drawPlayer.legFrame), color9, drawPlayer.legRotation, origin, (float) 1f, none, 0f);
            }
            if ((drawPlayer.body > 0) && (drawPlayer.body < 0x11))
            {
                this.spriteBatch.Draw(armorBodyTexture[drawPlayer.body], (new Vector2((float) ((((int) (drawPlayer.position.X - screenPosition.X)) - (drawPlayer.bodyFrame.Width / 2)) + (drawPlayer.width / 2)), (float) ((int) ((((drawPlayer.position.Y - screenPosition.Y) + drawPlayer.height) - drawPlayer.bodyFrame.Height) + 4f))) + drawPlayer.bodyPosition) + new Vector2((float) (drawPlayer.bodyFrame.Width / 2), (float) (drawPlayer.bodyFrame.Height / 2)), new Rectangle?(drawPlayer.bodyFrame), color11, drawPlayer.bodyRotation, vector2, (float) 1f, none, 0f);
                if (((((drawPlayer.body == 10) || (drawPlayer.body == 11)) || ((drawPlayer.body == 12) || (drawPlayer.body == 13))) || (((drawPlayer.body == 14) || (drawPlayer.body == 15)) || (drawPlayer.body == 0x10))) && !drawPlayer.invis)
                {
                    this.spriteBatch.Draw(playerHandsTexture, (new Vector2((float) ((((int) (drawPlayer.position.X - screenPosition.X)) - (drawPlayer.bodyFrame.Width / 2)) + (drawPlayer.width / 2)), (float) ((int) ((((drawPlayer.position.Y - screenPosition.Y) + drawPlayer.height) - drawPlayer.bodyFrame.Height) + 4f))) + drawPlayer.bodyPosition) + new Vector2((float) (drawPlayer.bodyFrame.Width / 2), (float) (drawPlayer.bodyFrame.Height / 2)), new Rectangle?(drawPlayer.bodyFrame), color5, drawPlayer.bodyRotation, vector2, (float) 1f, none, 0f);
                }
            }
            else if (!drawPlayer.invis)
            {
                this.spriteBatch.Draw(playerUnderShirtTexture, (new Vector2((float) ((((int) (drawPlayer.position.X - screenPosition.X)) - (drawPlayer.bodyFrame.Width / 2)) + (drawPlayer.width / 2)), (float) ((int) ((((drawPlayer.position.Y - screenPosition.Y) + drawPlayer.height) - drawPlayer.bodyFrame.Height) + 4f))) + drawPlayer.bodyPosition) + new Vector2((float) (drawPlayer.bodyFrame.Width / 2), (float) (drawPlayer.bodyFrame.Height / 2)), new Rectangle?(drawPlayer.bodyFrame), color7, drawPlayer.bodyRotation, vector2, (float) 1f, none, 0f);
                this.spriteBatch.Draw(playerShirtTexture, (new Vector2((float) ((((int) (drawPlayer.position.X - screenPosition.X)) - (drawPlayer.bodyFrame.Width / 2)) + (drawPlayer.width / 2)), (float) ((int) ((((drawPlayer.position.Y - screenPosition.Y) + drawPlayer.height) - drawPlayer.bodyFrame.Height) + 4f))) + drawPlayer.bodyPosition) + new Vector2((float) (drawPlayer.bodyFrame.Width / 2), (float) (drawPlayer.bodyFrame.Height / 2)), new Rectangle?(drawPlayer.bodyFrame), color6, drawPlayer.bodyRotation, vector2, (float) 1f, none, 0f);
                this.spriteBatch.Draw(playerHandsTexture, (new Vector2((float) ((((int) (drawPlayer.position.X - screenPosition.X)) - (drawPlayer.bodyFrame.Width / 2)) + (drawPlayer.width / 2)), (float) ((int) ((((drawPlayer.position.Y - screenPosition.Y) + drawPlayer.height) - drawPlayer.bodyFrame.Height) + 4f))) + drawPlayer.bodyPosition) + new Vector2((float) (drawPlayer.bodyFrame.Width / 2), (float) (drawPlayer.bodyFrame.Height / 2)), new Rectangle?(drawPlayer.bodyFrame), color5, drawPlayer.bodyRotation, vector2, (float) 1f, none, 0f);
            }
            if (!drawPlayer.invis)
            {
                this.spriteBatch.Draw(playerHeadTexture, (new Vector2((float) ((((int) (drawPlayer.position.X - screenPosition.X)) - (drawPlayer.bodyFrame.Width / 2)) + (drawPlayer.width / 2)), (float) ((int) ((((drawPlayer.position.Y - screenPosition.Y) + drawPlayer.height) - drawPlayer.bodyFrame.Height) + 4f))) + drawPlayer.headPosition) + vector3, new Rectangle?(drawPlayer.bodyFrame), color4, drawPlayer.headRotation, vector3, (float) 1f, none, 0f);
                this.spriteBatch.Draw(playerEyeWhitesTexture, (new Vector2((float) ((((int) (drawPlayer.position.X - screenPosition.X)) - (drawPlayer.bodyFrame.Width / 2)) + (drawPlayer.width / 2)), (float) ((int) ((((drawPlayer.position.Y - screenPosition.Y) + drawPlayer.height) - drawPlayer.bodyFrame.Height) + 4f))) + drawPlayer.headPosition) + vector3, new Rectangle?(drawPlayer.bodyFrame), immuneAlpha, drawPlayer.headRotation, vector3, (float) 1f, none, 0f);
                this.spriteBatch.Draw(playerEyesTexture, (new Vector2((float) ((((int) (drawPlayer.position.X - screenPosition.X)) - (drawPlayer.bodyFrame.Width / 2)) + (drawPlayer.width / 2)), (float) ((int) ((((drawPlayer.position.Y - screenPosition.Y) + drawPlayer.height) - drawPlayer.bodyFrame.Height) + 4f))) + drawPlayer.headPosition) + vector3, new Rectangle?(drawPlayer.bodyFrame), newColor, drawPlayer.headRotation, vector3, (float) 1f, none, 0f);
            }
            if (((drawPlayer.head == 10) || (drawPlayer.head == 12)) || (drawPlayer.head == 0x1c))
            {
                this.spriteBatch.Draw(armorHeadTexture[drawPlayer.head], (new Vector2((float) ((((int) (drawPlayer.position.X - screenPosition.X)) - (drawPlayer.bodyFrame.Width / 2)) + (drawPlayer.width / 2)), (float) ((int) ((((drawPlayer.position.Y - screenPosition.Y) + drawPlayer.height) - drawPlayer.bodyFrame.Height) + 4f))) + drawPlayer.headPosition) + vector3, new Rectangle?(drawPlayer.bodyFrame), color10, drawPlayer.headRotation, vector3, (float) 1f, none, 0f);
                if (!drawPlayer.invis)
                {
                    Rectangle bodyFrame = drawPlayer.bodyFrame;
                    bodyFrame.Y -= 0x150;
                    if (bodyFrame.Y < 0)
                    {
                        bodyFrame.Y = 0;
                    }
                    this.spriteBatch.Draw(playerHairTexture[drawPlayer.hair], (new Vector2((float) ((((int) (drawPlayer.position.X - screenPosition.X)) - (drawPlayer.bodyFrame.Width / 2)) + (drawPlayer.width / 2)), (float) ((int) ((((drawPlayer.position.Y - screenPosition.Y) + drawPlayer.height) - drawPlayer.bodyFrame.Height) + 4f))) + drawPlayer.headPosition) + vector3, new Rectangle?(bodyFrame), color3, drawPlayer.headRotation, vector3, (float) 1f, none, 0f);
                }
            }
            if (drawPlayer.head == 0x17)
            {
                Rectangle rectangle2 = drawPlayer.bodyFrame;
                rectangle2.Y -= 0x150;
                if (rectangle2.Y < 0)
                {
                    rectangle2.Y = 0;
                }
                if (!drawPlayer.invis)
                {
                    this.spriteBatch.Draw(playerHairTexture[drawPlayer.hair], (new Vector2((float) ((((int) (drawPlayer.position.X - screenPosition.X)) - (drawPlayer.bodyFrame.Width / 2)) + (drawPlayer.width / 2)), (float) ((int) ((((drawPlayer.position.Y - screenPosition.Y) + drawPlayer.height) - drawPlayer.bodyFrame.Height) + 4f))) + drawPlayer.headPosition) + vector3, new Rectangle?(rectangle2), color3, drawPlayer.headRotation, vector3, (float) 1f, none, 0f);
                }
                this.spriteBatch.Draw(armorHeadTexture[drawPlayer.head], (new Vector2((float) ((((int) (drawPlayer.position.X - screenPosition.X)) - (drawPlayer.bodyFrame.Width / 2)) + (drawPlayer.width / 2)), (float) ((int) ((((drawPlayer.position.Y - screenPosition.Y) + drawPlayer.height) - drawPlayer.bodyFrame.Height) + 4f))) + drawPlayer.headPosition) + vector3, new Rectangle?(drawPlayer.bodyFrame), color10, drawPlayer.headRotation, vector3, (float) 1f, none, 0f);
            }
            else if (drawPlayer.head == 14)
            {
                Rectangle rectangle3 = drawPlayer.bodyFrame;
                int num7 = 0;
                if (rectangle3.Y == (rectangle3.Height * 6))
                {
                    rectangle3.Height -= 2;
                }
                else if (rectangle3.Y == (rectangle3.Height * 7))
                {
                    num7 = -2;
                }
                else if (rectangle3.Y == (rectangle3.Height * 8))
                {
                    num7 = -2;
                }
                else if (rectangle3.Y == (rectangle3.Height * 9))
                {
                    num7 = -2;
                }
                else if (rectangle3.Y == (rectangle3.Height * 10))
                {
                    num7 = -2;
                }
                else if (rectangle3.Y == (rectangle3.Height * 13))
                {
                    rectangle3.Height -= 2;
                }
                else if (rectangle3.Y == (rectangle3.Height * 14))
                {
                    num7 = -2;
                }
                else if (rectangle3.Y == (rectangle3.Height * 15))
                {
                    num7 = -2;
                }
                else if (rectangle3.Y == (rectangle3.Height * 0x10))
                {
                    num7 = -2;
                }
                rectangle3.Y += num7;
                this.spriteBatch.Draw(armorHeadTexture[drawPlayer.head], (new Vector2((float) ((((int) (drawPlayer.position.X - screenPosition.X)) - (drawPlayer.bodyFrame.Width / 2)) + (drawPlayer.width / 2)), (float) (((int) ((((drawPlayer.position.Y - screenPosition.Y) + drawPlayer.height) - drawPlayer.bodyFrame.Height) + 4f)) + num7)) + drawPlayer.headPosition) + vector3, new Rectangle?(rectangle3), color10, drawPlayer.headRotation, vector3, (float) 1f, none, 0f);
            }
            else if (((drawPlayer.head > 0) && (drawPlayer.head < 0x1d)) && (drawPlayer.head != 0x1c))
            {
                this.spriteBatch.Draw(armorHeadTexture[drawPlayer.head], (new Vector2((float) ((((int) (drawPlayer.position.X - screenPosition.X)) - (drawPlayer.bodyFrame.Width / 2)) + (drawPlayer.width / 2)), (float) ((int) ((((drawPlayer.position.Y - screenPosition.Y) + drawPlayer.height) - drawPlayer.bodyFrame.Height) + 4f))) + drawPlayer.headPosition) + vector3, new Rectangle?(drawPlayer.bodyFrame), color10, drawPlayer.headRotation, vector3, (float) 1f, none, 0f);
            }
            else if (!drawPlayer.invis)
            {
                Rectangle rectangle4 = drawPlayer.bodyFrame;
                rectangle4.Y -= 0x150;
                if (rectangle4.Y < 0)
                {
                    rectangle4.Y = 0;
                }
                this.spriteBatch.Draw(playerHairTexture[drawPlayer.hair], (new Vector2((float) ((((int) (drawPlayer.position.X - screenPosition.X)) - (drawPlayer.bodyFrame.Width / 2)) + (drawPlayer.width / 2)), (float) ((int) ((((drawPlayer.position.Y - screenPosition.Y) + drawPlayer.height) - drawPlayer.bodyFrame.Height) + 4f))) + drawPlayer.headPosition) + vector3, new Rectangle?(rectangle4), color3, drawPlayer.headRotation, vector3, (float) 1f, none, 0f);
            }
            if (drawPlayer.heldProj >= 0)
            {
                this.DrawProj(drawPlayer.heldProj);
            }
            Color color = Lighting.GetColor(((int) (drawPlayer.position.X + (drawPlayer.width * 0.5))) / 0x10, (int) ((drawPlayer.position.Y + (drawPlayer.height * 0.5)) / 16.0));
            if (((drawPlayer.itemAnimation > 0) || (drawPlayer.inventory[drawPlayer.selectedItem].holdStyle > 0)) && ((((drawPlayer.inventory[drawPlayer.selectedItem].type > 0) && !drawPlayer.dead) && !drawPlayer.inventory[drawPlayer.selectedItem].noUseGraphic) && (!drawPlayer.wet || !drawPlayer.inventory[drawPlayer.selectedItem].noWet)))
            {
                if (drawPlayer.inventory[drawPlayer.selectedItem].useStyle == 5)
                {
                    int num8 = 10;
                    Vector2 vector4 = new Vector2((float) (itemTexture[drawPlayer.inventory[drawPlayer.selectedItem].type].Width / 2), (float) (itemTexture[drawPlayer.inventory[drawPlayer.selectedItem].type].Height / 2));
                    if (drawPlayer.inventory[drawPlayer.selectedItem].type == 0x5f)
                    {
                        num8 = 10;
                        vector4.Y += 2f * drawPlayer.gravDir;
                    }
                    else if (drawPlayer.inventory[drawPlayer.selectedItem].type == 0x60)
                    {
                        num8 = -5;
                    }
                    else if (drawPlayer.inventory[drawPlayer.selectedItem].type == 0x62)
                    {
                        num8 = -5;
                        vector4.Y -= 2f * drawPlayer.gravDir;
                    }
                    else if (drawPlayer.inventory[drawPlayer.selectedItem].type == 0xc5)
                    {
                        num8 = -5;
                        vector4.Y += 4f * drawPlayer.gravDir;
                    }
                    else if (drawPlayer.inventory[drawPlayer.selectedItem].type == 0x7e)
                    {
                        num8 = 4;
                        vector4.Y += 4f * drawPlayer.gravDir;
                    }
                    else if (drawPlayer.inventory[drawPlayer.selectedItem].type == 0x7f)
                    {
                        num8 = 4;
                        vector4.Y += 2f * drawPlayer.gravDir;
                    }
                    else if (drawPlayer.inventory[drawPlayer.selectedItem].type == 0x9d)
                    {
                        num8 = 6;
                        vector4.Y += 2f * drawPlayer.gravDir;
                    }
                    else if (drawPlayer.inventory[drawPlayer.selectedItem].type == 160)
                    {
                        num8 = -8;
                    }
                    else if ((drawPlayer.inventory[drawPlayer.selectedItem].type == 0xa4) || (drawPlayer.inventory[drawPlayer.selectedItem].type == 0xdb))
                    {
                        num8 = 2;
                        vector4.Y += 4f * drawPlayer.gravDir;
                    }
                    else if ((drawPlayer.inventory[drawPlayer.selectedItem].type == 0xa5) || (drawPlayer.inventory[drawPlayer.selectedItem].type == 0x110))
                    {
                        num8 = 4;
                        vector4.Y += 4f * drawPlayer.gravDir;
                    }
                    else if (drawPlayer.inventory[drawPlayer.selectedItem].type == 0x10a)
                    {
                        num8 = 0;
                        vector4.Y += 2f * drawPlayer.gravDir;
                    }
                    else if (drawPlayer.inventory[drawPlayer.selectedItem].type == 0x119)
                    {
                        num8 = 6;
                        vector4.Y -= 6f * drawPlayer.gravDir;
                    }
                    Vector2 vector5 = new Vector2((float) -num8, (float) (itemTexture[drawPlayer.inventory[drawPlayer.selectedItem].type].Height / 2));
                    if (drawPlayer.direction == -1)
                    {
                        vector5 = new Vector2((float) (itemTexture[drawPlayer.inventory[drawPlayer.selectedItem].type].Width + num8), (float) (itemTexture[drawPlayer.inventory[drawPlayer.selectedItem].type].Height / 2));
                    }
                    this.spriteBatch.Draw(itemTexture[drawPlayer.inventory[drawPlayer.selectedItem].type], new Vector2((float) ((int) ((drawPlayer.itemLocation.X - screenPosition.X) + vector4.X)), (float) ((int) ((drawPlayer.itemLocation.Y - screenPosition.Y) + vector4.Y))), new Rectangle(0, 0, itemTexture[drawPlayer.inventory[drawPlayer.selectedItem].type].Width, itemTexture[drawPlayer.inventory[drawPlayer.selectedItem].type].Height), drawPlayer.inventory[drawPlayer.selectedItem].GetAlpha(color), drawPlayer.itemRotation, vector5, drawPlayer.inventory[drawPlayer.selectedItem].scale, flipHorizontally, 0f);
                    if (drawPlayer.inventory[drawPlayer.selectedItem].color != new Color())
                    {
                        this.spriteBatch.Draw(itemTexture[drawPlayer.inventory[drawPlayer.selectedItem].type], new Vector2((float) ((int) ((drawPlayer.itemLocation.X - screenPosition.X) + vector4.X)), (float) ((int) ((drawPlayer.itemLocation.Y - screenPosition.Y) + vector4.Y))), new Rectangle(0, 0, itemTexture[drawPlayer.inventory[drawPlayer.selectedItem].type].Width, itemTexture[drawPlayer.inventory[drawPlayer.selectedItem].type].Height), drawPlayer.inventory[drawPlayer.selectedItem].GetColor(color), drawPlayer.itemRotation, vector5, drawPlayer.inventory[drawPlayer.selectedItem].scale, flipHorizontally, 0f);
                    }
                }
                else if (drawPlayer.gravDir == -1f)
                {
                    this.spriteBatch.Draw(itemTexture[drawPlayer.inventory[drawPlayer.selectedItem].type], new Vector2((float) ((int) (drawPlayer.itemLocation.X - screenPosition.X)), (float) ((int) (drawPlayer.itemLocation.Y - screenPosition.Y))), new Rectangle(0, 0, itemTexture[drawPlayer.inventory[drawPlayer.selectedItem].type].Width, itemTexture[drawPlayer.inventory[drawPlayer.selectedItem].type].Height), drawPlayer.inventory[drawPlayer.selectedItem].GetAlpha(color), drawPlayer.itemRotation, new Vector2((itemTexture[drawPlayer.inventory[drawPlayer.selectedItem].type].Width * 0.5f) - ((itemTexture[drawPlayer.inventory[drawPlayer.selectedItem].type].Width * 0.5f) * drawPlayer.direction), 0f), drawPlayer.inventory[drawPlayer.selectedItem].scale, flipHorizontally, 0f);
                    if (drawPlayer.inventory[drawPlayer.selectedItem].color != new Color())
                    {
                        this.spriteBatch.Draw(itemTexture[drawPlayer.inventory[drawPlayer.selectedItem].type], new Vector2((float) ((int) (drawPlayer.itemLocation.X - screenPosition.X)), (float) ((int) (drawPlayer.itemLocation.Y - screenPosition.Y))), new Rectangle(0, 0, itemTexture[drawPlayer.inventory[drawPlayer.selectedItem].type].Width, itemTexture[drawPlayer.inventory[drawPlayer.selectedItem].type].Height), drawPlayer.inventory[drawPlayer.selectedItem].GetColor(color), drawPlayer.itemRotation, new Vector2((itemTexture[drawPlayer.inventory[drawPlayer.selectedItem].type].Width * 0.5f) - ((itemTexture[drawPlayer.inventory[drawPlayer.selectedItem].type].Width * 0.5f) * drawPlayer.direction), 0f), drawPlayer.inventory[drawPlayer.selectedItem].scale, flipHorizontally, 0f);
                    }
                }
                else
                {
                    this.spriteBatch.Draw(itemTexture[drawPlayer.inventory[drawPlayer.selectedItem].type], new Vector2((float) ((int) (drawPlayer.itemLocation.X - screenPosition.X)), (float) ((int) (drawPlayer.itemLocation.Y - screenPosition.Y))), new Rectangle(0, 0, itemTexture[drawPlayer.inventory[drawPlayer.selectedItem].type].Width, itemTexture[drawPlayer.inventory[drawPlayer.selectedItem].type].Height), drawPlayer.inventory[drawPlayer.selectedItem].GetAlpha(color), drawPlayer.itemRotation, new Vector2((itemTexture[drawPlayer.inventory[drawPlayer.selectedItem].type].Width * 0.5f) - ((itemTexture[drawPlayer.inventory[drawPlayer.selectedItem].type].Width * 0.5f) * drawPlayer.direction), (float) itemTexture[drawPlayer.inventory[drawPlayer.selectedItem].type].Height), drawPlayer.inventory[drawPlayer.selectedItem].scale, flipHorizontally, 0f);
                    if (drawPlayer.inventory[drawPlayer.selectedItem].color != new Color())
                    {
                        this.spriteBatch.Draw(itemTexture[drawPlayer.inventory[drawPlayer.selectedItem].type], new Vector2((float) ((int) (drawPlayer.itemLocation.X - screenPosition.X)), (float) ((int) (drawPlayer.itemLocation.Y - screenPosition.Y))), new Rectangle(0, 0, itemTexture[drawPlayer.inventory[drawPlayer.selectedItem].type].Width, itemTexture[drawPlayer.inventory[drawPlayer.selectedItem].type].Height), drawPlayer.inventory[drawPlayer.selectedItem].GetColor(color), drawPlayer.itemRotation, new Vector2((itemTexture[drawPlayer.inventory[drawPlayer.selectedItem].type].Width * 0.5f) - ((itemTexture[drawPlayer.inventory[drawPlayer.selectedItem].type].Width * 0.5f) * drawPlayer.direction), (float) itemTexture[drawPlayer.inventory[drawPlayer.selectedItem].type].Height), drawPlayer.inventory[drawPlayer.selectedItem].scale, flipHorizontally, 0f);
                    }
                }
            }
            if ((drawPlayer.body > 0) && (drawPlayer.body < 0x11))
            {
                this.spriteBatch.Draw(armorArmTexture[drawPlayer.body], (new Vector2((float) ((((int) (drawPlayer.position.X - screenPosition.X)) - (drawPlayer.bodyFrame.Width / 2)) + (drawPlayer.width / 2)), (float) ((int) ((((drawPlayer.position.Y - screenPosition.Y) + drawPlayer.height) - drawPlayer.bodyFrame.Height) + 4f))) + drawPlayer.bodyPosition) + new Vector2((float) (drawPlayer.bodyFrame.Width / 2), (float) (drawPlayer.bodyFrame.Height / 2)), new Rectangle?(drawPlayer.bodyFrame), color11, drawPlayer.bodyRotation, vector2, (float) 1f, none, 0f);
                if (((((drawPlayer.body == 10) || (drawPlayer.body == 11)) || ((drawPlayer.body == 12) || (drawPlayer.body == 13))) || (((drawPlayer.body == 14) || (drawPlayer.body == 15)) || (drawPlayer.body == 0x10))) && !drawPlayer.invis)
                {
                    this.spriteBatch.Draw(playerHands2Texture, (new Vector2((float) ((((int) (drawPlayer.position.X - screenPosition.X)) - (drawPlayer.bodyFrame.Width / 2)) + (drawPlayer.width / 2)), (float) ((int) ((((drawPlayer.position.Y - screenPosition.Y) + drawPlayer.height) - drawPlayer.bodyFrame.Height) + 4f))) + drawPlayer.bodyPosition) + new Vector2((float) (drawPlayer.bodyFrame.Width / 2), (float) (drawPlayer.bodyFrame.Height / 2)), new Rectangle?(drawPlayer.bodyFrame), color5, drawPlayer.bodyRotation, vector2, (float) 1f, none, 0f);
                }
            }
            else if (!drawPlayer.invis)
            {
                this.spriteBatch.Draw(playerUnderShirt2Texture, (new Vector2((float) ((((int) (drawPlayer.position.X - screenPosition.X)) - (drawPlayer.bodyFrame.Width / 2)) + (drawPlayer.width / 2)), (float) ((int) ((((drawPlayer.position.Y - screenPosition.Y) + drawPlayer.height) - drawPlayer.bodyFrame.Height) + 4f))) + drawPlayer.bodyPosition) + new Vector2((float) (drawPlayer.bodyFrame.Width / 2), (float) (drawPlayer.bodyFrame.Height / 2)), new Rectangle?(drawPlayer.bodyFrame), color7, drawPlayer.bodyRotation, vector2, (float) 1f, none, 0f);
                this.spriteBatch.Draw(playerHands2Texture, (new Vector2((float) ((((int) (drawPlayer.position.X - screenPosition.X)) - (drawPlayer.bodyFrame.Width / 2)) + (drawPlayer.width / 2)), (float) ((int) ((((drawPlayer.position.Y - screenPosition.Y) + drawPlayer.height) - drawPlayer.bodyFrame.Height) + 4f))) + drawPlayer.bodyPosition) + new Vector2((float) (drawPlayer.bodyFrame.Width / 2), (float) (drawPlayer.bodyFrame.Height / 2)), new Rectangle?(drawPlayer.bodyFrame), color5, drawPlayer.bodyRotation, vector2, (float) 1f, none, 0f);
            }
        }

        protected void DrawProj(int i)
        {
            if (projectile[i].type == 0x20)
            {
                Vector2 vector = new Vector2(projectile[i].position.X + (projectile[i].width * 0.5f), projectile[i].position.Y + (projectile[i].height * 0.5f));
                float num = (player[projectile[i].owner].position.X + (player[projectile[i].owner].width / 2)) - vector.X;
                float num2 = (player[projectile[i].owner].position.Y + (player[projectile[i].owner].height / 2)) - vector.Y;
                float rotation = ((float) Math.Atan2((double) num2, (double) num)) - 1.57f;
                bool flag = true;
                if ((num == 0f) && (num2 == 0f))
                {
                    flag = false;
                }
                else
                {
                    float num4 = (float) Math.Sqrt((double) ((num * num) + (num2 * num2)));
                    num4 = 8f / num4;
                    num *= num4;
                    num2 *= num4;
                    vector.X -= num;
                    vector.Y -= num2;
                    num = (player[projectile[i].owner].position.X + (player[projectile[i].owner].width / 2)) - vector.X;
                    num2 = (player[projectile[i].owner].position.Y + (player[projectile[i].owner].height / 2)) - vector.Y;
                }
                while (flag)
                {
                    float num5 = (float) Math.Sqrt((double) ((num * num) + (num2 * num2)));
                    if (num5 < 28f)
                    {
                        flag = false;
                    }
                    else
                    {
                        num5 = 28f / num5;
                        num *= num5;
                        num2 *= num5;
                        vector.X += num;
                        vector.Y += num2;
                        num = (player[projectile[i].owner].position.X + (player[projectile[i].owner].width / 2)) - vector.X;
                        num2 = (player[projectile[i].owner].position.Y + (player[projectile[i].owner].height / 2)) - vector.Y;
                        Color color = Lighting.GetColor(((int) vector.X) / 0x10, (int) (vector.Y / 16f));
                        this.spriteBatch.Draw(chain5Texture, new Vector2(vector.X - screenPosition.X, vector.Y - screenPosition.Y), new Rectangle(0, 0, chain5Texture.Width, chain5Texture.Height), color, rotation, new Vector2(chain5Texture.Width * 0.5f, chain5Texture.Height * 0.5f), (float) 1f, SpriteEffects.None, 0f);
                    }
                }
            }
            else if (projectile[i].aiStyle == 7)
            {
                Vector2 vector2 = new Vector2(projectile[i].position.X + (projectile[i].width * 0.5f), projectile[i].position.Y + (projectile[i].height * 0.5f));
                float num6 = (player[projectile[i].owner].position.X + (player[projectile[i].owner].width / 2)) - vector2.X;
                float num7 = (player[projectile[i].owner].position.Y + (player[projectile[i].owner].height / 2)) - vector2.Y;
                float num8 = ((float) Math.Atan2((double) num7, (double) num6)) - 1.57f;
                bool flag2 = true;
                while (flag2)
                {
                    float num9 = (float) Math.Sqrt((double) ((num6 * num6) + (num7 * num7)));
                    if (num9 < 25f)
                    {
                        flag2 = false;
                    }
                    else
                    {
                        num9 = 12f / num9;
                        num6 *= num9;
                        num7 *= num9;
                        vector2.X += num6;
                        vector2.Y += num7;
                        num6 = (player[projectile[i].owner].position.X + (player[projectile[i].owner].width / 2)) - vector2.X;
                        num7 = (player[projectile[i].owner].position.Y + (player[projectile[i].owner].height / 2)) - vector2.Y;
                        Color color2 = Lighting.GetColor(((int) vector2.X) / 0x10, (int) (vector2.Y / 16f));
                        this.spriteBatch.Draw(chainTexture, new Vector2(vector2.X - screenPosition.X, vector2.Y - screenPosition.Y), new Rectangle(0, 0, chainTexture.Width, chainTexture.Height), color2, num8, new Vector2(chainTexture.Width * 0.5f, chainTexture.Height * 0.5f), (float) 1f, SpriteEffects.None, 0f);
                    }
                }
            }
            else if (projectile[i].aiStyle == 13)
            {
                float num10 = projectile[i].position.X + 8f;
                float y = projectile[i].position.Y + 2f;
                float num12 = projectile[i].velocity.X;
                float num13 = projectile[i].velocity.Y;
                float num14 = (float) Math.Sqrt((double) ((num12 * num12) + (num13 * num13)));
                num14 = 20f / num14;
                if (projectile[i].ai[0] == 0f)
                {
                    num10 -= projectile[i].velocity.X * num14;
                    y -= projectile[i].velocity.Y * num14;
                }
                else
                {
                    num10 += projectile[i].velocity.X * num14;
                    y += projectile[i].velocity.Y * num14;
                }
                Vector2 vector3 = new Vector2(num10, y);
                num12 = (player[projectile[i].owner].position.X + (player[projectile[i].owner].width / 2)) - vector3.X;
                num13 = (player[projectile[i].owner].position.Y + (player[projectile[i].owner].height / 2)) - vector3.Y;
                float num15 = ((float) Math.Atan2((double) num13, (double) num12)) - 1.57f;
                if (projectile[i].alpha == 0)
                {
                    int num16 = -1;
                    if ((projectile[i].position.X + (projectile[i].width / 2)) < (player[projectile[i].owner].position.X + (player[projectile[i].owner].width / 2)))
                    {
                        num16 = 1;
                    }
                    if (player[projectile[i].owner].direction == 1)
                    {
                        player[projectile[i].owner].itemRotation = (float) Math.Atan2((double) (num13 * num16), (double) (num12 * num16));
                    }
                    else
                    {
                        player[projectile[i].owner].itemRotation = (float) Math.Atan2((double) (num13 * num16), (double) (num12 * num16));
                    }
                }
                bool flag3 = true;
                while (flag3)
                {
                    float num17 = (float) Math.Sqrt((double) ((num12 * num12) + (num13 * num13)));
                    if (num17 < 25f)
                    {
                        flag3 = false;
                    }
                    else
                    {
                        num17 = 12f / num17;
                        num12 *= num17;
                        num13 *= num17;
                        vector3.X += num12;
                        vector3.Y += num13;
                        num12 = (player[projectile[i].owner].position.X + (player[projectile[i].owner].width / 2)) - vector3.X;
                        num13 = (player[projectile[i].owner].position.Y + (player[projectile[i].owner].height / 2)) - vector3.Y;
                        Color color3 = Lighting.GetColor(((int) vector3.X) / 0x10, (int) (vector3.Y / 16f));
                        this.spriteBatch.Draw(chainTexture, new Vector2(vector3.X - screenPosition.X, vector3.Y - screenPosition.Y), new Rectangle(0, 0, chainTexture.Width, chainTexture.Height), color3, num15, new Vector2(chainTexture.Width * 0.5f, chainTexture.Height * 0.5f), (float) 1f, SpriteEffects.None, 0f);
                    }
                }
            }
            else if (projectile[i].aiStyle == 15)
            {
                Vector2 vector4 = new Vector2(projectile[i].position.X + (projectile[i].width * 0.5f), projectile[i].position.Y + (projectile[i].height * 0.5f));
                float num18 = (player[projectile[i].owner].position.X + (player[projectile[i].owner].width / 2)) - vector4.X;
                float num19 = (player[projectile[i].owner].position.Y + (player[projectile[i].owner].height / 2)) - vector4.Y;
                float num20 = ((float) Math.Atan2((double) num19, (double) num18)) - 1.57f;
                if (projectile[i].alpha == 0)
                {
                    int num21 = -1;
                    if ((projectile[i].position.X + (projectile[i].width / 2)) < (player[projectile[i].owner].position.X + (player[projectile[i].owner].width / 2)))
                    {
                        num21 = 1;
                    }
                    if (player[projectile[i].owner].direction == 1)
                    {
                        player[projectile[i].owner].itemRotation = (float) Math.Atan2((double) (num19 * num21), (double) (num18 * num21));
                    }
                    else
                    {
                        player[projectile[i].owner].itemRotation = (float) Math.Atan2((double) (num19 * num21), (double) (num18 * num21));
                    }
                }
                bool flag4 = true;
                while (flag4)
                {
                    float num22 = (float) Math.Sqrt((double) ((num18 * num18) + (num19 * num19)));
                    if (num22 < 25f)
                    {
                        flag4 = false;
                    }
                    else
                    {
                        num22 = 12f / num22;
                        num18 *= num22;
                        num19 *= num22;
                        vector4.X += num18;
                        vector4.Y += num19;
                        num18 = (player[projectile[i].owner].position.X + (player[projectile[i].owner].width / 2)) - vector4.X;
                        num19 = (player[projectile[i].owner].position.Y + (player[projectile[i].owner].height / 2)) - vector4.Y;
                        Color color4 = Lighting.GetColor(((int) vector4.X) / 0x10, (int) (vector4.Y / 16f));
                        if (projectile[i].type == 0x19)
                        {
                            this.spriteBatch.Draw(chain2Texture, new Vector2(vector4.X - screenPosition.X, vector4.Y - screenPosition.Y), new Rectangle(0, 0, chain2Texture.Width, chain2Texture.Height), color4, num20, new Vector2(chain2Texture.Width * 0.5f, chain2Texture.Height * 0.5f), (float) 1f, SpriteEffects.None, 0f);
                            continue;
                        }
                        if (projectile[i].type == 0x23)
                        {
                            this.spriteBatch.Draw(chain6Texture, new Vector2(vector4.X - screenPosition.X, vector4.Y - screenPosition.Y), new Rectangle(0, 0, chain6Texture.Width, chain6Texture.Height), color4, num20, new Vector2(chain6Texture.Width * 0.5f, chain6Texture.Height * 0.5f), (float) 1f, SpriteEffects.None, 0f);
                            continue;
                        }
                        this.spriteBatch.Draw(chain3Texture, new Vector2(vector4.X - screenPosition.X, vector4.Y - screenPosition.Y), new Rectangle(0, 0, chain3Texture.Width, chain3Texture.Height), color4, num20, new Vector2(chain3Texture.Width * 0.5f, chain3Texture.Height * 0.5f), (float) 1f, SpriteEffects.None, 0f);
                    }
                }
            }
            Color newColor = Lighting.GetColor(((int) (projectile[i].position.X + (projectile[i].width * 0.5))) / 0x10, (int) ((projectile[i].position.Y + (projectile[i].height * 0.5)) / 16.0));
            if (projectile[i].hide)
            {
                newColor = Lighting.GetColor(((int) (player[projectile[i].owner].position.X + (player[projectile[i].owner].width * 0.5))) / 0x10, (int) ((player[projectile[i].owner].position.Y + (player[projectile[i].owner].height * 0.5)) / 16.0));
            }
            if (projectile[i].type == 14)
            {
                newColor = Color.White;
            }
            int num23 = 0;
            int num24 = 0;
            if (projectile[i].type == 0x10)
            {
                num23 = 6;
            }
            if ((projectile[i].type == 0x11) || (projectile[i].type == 0x1f))
            {
                num23 = 2;
            }
            if (((projectile[i].type == 0x19) || (projectile[i].type == 0x1a)) || (projectile[i].type == 0x23))
            {
                num23 = 6;
                num24 -= 6;
            }
            if ((projectile[i].type == 0x1c) || (projectile[i].type == 0x25))
            {
                num23 = 8;
            }
            if (projectile[i].type == 0x1d)
            {
                num23 = 11;
            }
            if (projectile[i].type == 0x2b)
            {
                num23 = 4;
            }
            float x = ((projectileTexture[projectile[i].type].Width - projectile[i].width) * 0.5f) + (projectile[i].width * 0.5f);
            if ((projectile[i].type == 50) || (projectile[i].type == 0x35))
            {
                num24 = -8;
            }
            if (projectile[i].aiStyle == 0x13)
            {
                this.spriteBatch.Draw(projectileTexture[projectile[i].type], new Vector2((projectile[i].position.X - screenPosition.X) + (projectile[i].width / 2), (projectile[i].position.Y - screenPosition.Y) + (projectile[i].height / 2)), new Rectangle(0, 0, projectileTexture[projectile[i].type].Width, projectileTexture[projectile[i].type].Height), projectile[i].GetAlpha(newColor), projectile[i].rotation, new Vector2(), projectile[i].scale, SpriteEffects.None, 0f);
            }
            else
            {
                this.spriteBatch.Draw(projectileTexture[projectile[i].type], new Vector2(((projectile[i].position.X - screenPosition.X) + x) + num24, (projectile[i].position.Y - screenPosition.Y) + (projectile[i].height / 2)), new Rectangle(0, 0, projectileTexture[projectile[i].type].Width, projectileTexture[projectile[i].type].Height), projectile[i].GetAlpha(newColor), projectile[i].rotation, new Vector2(x, (float) ((projectile[i].height / 2) + num23)), projectile[i].scale, SpriteEffects.None, 0f);
            }
        }

        protected void DrawSplash(GameTime gameTime)
        {
            base.GraphicsDevice.Clear(Color.Black);
            base.Draw(gameTime);
            this.spriteBatch.Begin();
            this.splashCounter++;
            Color white = Color.White;
            byte num = 0;
            if (this.splashCounter <= 0x4b)
            {
                float num2 = (((float) this.splashCounter) / 75f) * 255f;
                num = (byte) num2;
            }
            else if (this.splashCounter <= 200)
            {
                num = 0xff;
            }
            else if (this.splashCounter <= 0x113)
            {
                int num3 = 0x113 - this.splashCounter;
                float num4 = (((float) num3) / 75f) * 255f;
                num = (byte) num4;
            }
            else
            {
                showSplash = false;
                fadeCounter = 0x4b;
            }
            white = new Color((int) num, (int) num, (int) num, (int) num);
            this.spriteBatch.Draw(splashTexture, new Rectangle(0, 0, screenWidth, screenHeight), white);
            this.spriteBatch.End();
        }

        protected void DrawTiles(bool solidOnly = true)
        {
            int num = (int) ((screenPosition.X / 16f) - 1f);
            int maxTilesX = ((int) ((screenPosition.X + screenWidth) / 16f)) + 2;
            int num3 = (int) ((screenPosition.Y / 16f) - 1f);
            int maxTilesY = ((int) ((screenPosition.Y + screenHeight) / 16f)) + 2;
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
            int height = 0x10;
            int width = 0x10;
            for (int i = num3; i < (maxTilesY + 4); i++)
            {
                for (int j = num - 2; j < (maxTilesX + 2); j++)
                {
                    Color color4;
                    Vector2 vector2;
                    if (!tile[j, i].active || (tileSolid[tile[j, i].type] != solidOnly))
                    {
                        continue;
                    }
                    Color color = Lighting.GetColor(j, i);
                    int num9 = 0;
                    if ((tile[j, i].type == 0x4e) || (tile[j, i].type == 0x55))
                    {
                        num9 = 2;
                    }
                    if ((tile[j, i].type == 0x21) || (tile[j, i].type == 0x31))
                    {
                        num9 = -4;
                    }
                    if ((((tile[j, i].type == 3) || (tile[j, i].type == 4)) || ((tile[j, i].type == 5) || (tile[j, i].type == 0x18))) || (((tile[j, i].type == 0x21) || (tile[j, i].type == 0x31)) || ((tile[j, i].type == 0x3d) || (tile[j, i].type == 0x47))))
                    {
                        height = 20;
                    }
                    else if (((((tile[j, i].type == 15) || (tile[j, i].type == 14)) || ((tile[j, i].type == 0x10) || (tile[j, i].type == 0x11))) || (((tile[j, i].type == 0x12) || (tile[j, i].type == 20)) || ((tile[j, i].type == 0x15) || (tile[j, i].type == 0x1a)))) || ((((tile[j, i].type == 0x1b) || (tile[j, i].type == 0x20)) || ((tile[j, i].type == 0x45) || (tile[j, i].type == 0x48))) || ((tile[j, i].type == 0x4d) || (tile[j, i].type == 80))))
                    {
                        height = 0x12;
                    }
                    else
                    {
                        height = 0x10;
                    }
                    if ((tile[j, i].type == 4) || (tile[j, i].type == 5))
                    {
                        width = 20;
                    }
                    else
                    {
                        width = 0x10;
                    }
                    if ((tile[j, i].type == 0x49) || (tile[j, i].type == 0x4a))
                    {
                        num9 -= 12;
                        height = 0x20;
                    }
                    if (tile[j, i].type == 0x51)
                    {
                        num9 -= 8;
                        height = 0x1a;
                        width = 0x18;
                    }
                    if (player[myPlayer].findTreasure && ((((((tile[j, i].type == 6) || (tile[j, i].type == 7)) || ((tile[j, i].type == 8) || (tile[j, i].type == 9))) || (((tile[j, i].type == 12) || (tile[j, i].type == 0x15)) || ((tile[j, i].type == 0x16) || (tile[j, i].type == 0x1c)))) || ((tile[j, i].type >= 0x3f) && (tile[j, i].type <= 0x44))) || tileAlch[tile[j, i].type]))
                    {
                        if (color.R < (mouseTextColor / 2))
                        {
                            color.R = (byte) (mouseTextColor / 2);
                        }
                        if (color.G < 70)
                        {
                            color.G = 70;
                        }
                        if (color.B < 210)
                        {
                            color.B = 210;
                        }
                        color.A = mouseTextColor;
                        if ((!gamePaused && base.IsActive) && (rand.Next(150) == 0))
                        {
                            color4 = new Color();
                            int index = Dust.NewDust(new Vector2((float) (j * 0x10), (float) (i * 0x10)), 0x10, 0x10, 15, 0f, 0f, 150, color4, 0.8f);
                            Dust dust1 = dust[index];
                            dust1.velocity = (Vector2) (dust1.velocity * 0.1f);
                            dust[index].noLight = true;
                        }
                    }
                    if (!gamePaused && base.IsActive)
                    {
                        if ((tile[j, i].type == 4) && (rand.Next(40) == 0))
                        {
                            if (tile[j, i].frameX == 0x16)
                            {
                                Color newColor = new Color();
                                Dust.NewDust(new Vector2((float) ((j * 0x10) + 6), (float) (i * 0x10)), 4, 4, 6, 0f, 0f, 100, newColor, 1f);
                            }
                            if (tile[j, i].frameX == 0x2c)
                            {
                                Color color6 = new Color();
                                Dust.NewDust(new Vector2((float) ((j * 0x10) + 2), (float) (i * 0x10)), 4, 4, 6, 0f, 0f, 100, color6, 1f);
                            }
                            else
                            {
                                Color color7 = new Color();
                                Dust.NewDust(new Vector2((float) ((j * 0x10) + 4), (float) (i * 0x10)), 4, 4, 6, 0f, 0f, 100, color7, 1f);
                            }
                        }
                        if ((tile[j, i].type == 0x21) && (rand.Next(40) == 0))
                        {
                            Color color8 = new Color();
                            Dust.NewDust(new Vector2((float) ((j * 0x10) + 4), (float) ((i * 0x10) - 4)), 4, 4, 6, 0f, 0f, 100, color8, 1f);
                        }
                        if (((tile[j, i].type == 0x5d) && (rand.Next(40) == 0)) && (tile[j, i].frameY == 0))
                        {
                            Color color9 = new Color();
                            Dust.NewDust(new Vector2((float) ((j * 0x10) + 4), (float) ((i * 0x10) + 2)), 4, 4, 6, 0f, 0f, 100, color9, 1f);
                        }
                        if (((tile[j, i].type == 100) && (rand.Next(40) == 0)) && (tile[j, i].frameY == 0))
                        {
                            if (tile[j, i].frameX == 0)
                            {
                                if (rand.Next(3) == 0)
                                {
                                    color4 = new Color();
                                    Dust.NewDust(new Vector2((float) ((j * 0x10) + 4), (float) ((i * 0x10) + 2)), 4, 4, 6, 0f, 0f, 100, color4, 1f);
                                }
                                else
                                {
                                    color4 = new Color();
                                    Dust.NewDust(new Vector2((float) ((j * 0x10) + 14), (float) ((i * 0x10) + 2)), 4, 4, 6, 0f, 0f, 100, color4, 1f);
                                }
                            }
                            else if (rand.Next(3) == 0)
                            {
                                color4 = new Color();
                                Dust.NewDust(new Vector2((float) ((j * 0x10) + 6), (float) ((i * 0x10) + 2)), 4, 4, 6, 0f, 0f, 100, color4, 1f);
                            }
                            else
                            {
                                color4 = new Color();
                                Dust.NewDust(new Vector2((float) (j * 0x10), (float) ((i * 0x10) + 2)), 4, 4, 6, 0f, 0f, 100, color4, 1f);
                            }
                        }
                        if (((tile[j, i].type == 0x62) && (rand.Next(40) == 0)) && ((tile[j, i].frameY == 0) && (tile[j, i].frameX == 0)))
                        {
                            color4 = new Color();
                            Dust.NewDust(new Vector2((float) ((j * 0x10) + 12), (float) ((i * 0x10) + 2)), 4, 4, 6, 0f, 0f, 100, color4, 1f);
                        }
                        if ((tile[j, i].type == 0x31) && (rand.Next(20) == 0))
                        {
                            color4 = new Color();
                            Dust.NewDust(new Vector2((float) ((j * 0x10) + 4), (float) ((i * 0x10) - 4)), 4, 4, 0x1d, 0f, 0f, 100, color4, 1f);
                        }
                        if ((((tile[j, i].type == 0x22) || (tile[j, i].type == 0x23)) || (tile[j, i].type == 0x24)) && (((rand.Next(40) == 0) && (tile[j, i].frameY == 0x12)) && ((tile[j, i].frameX == 0) || (tile[j, i].frameX == 0x24))))
                        {
                            color4 = new Color();
                            Dust.NewDust(new Vector2((float) (j * 0x10), (float) ((i * 0x10) + 2)), 14, 6, 6, 0f, 0f, 100, color4, 1f);
                        }
                        if ((tile[j, i].type == 0x16) && (rand.Next(400) == 0))
                        {
                            color4 = new Color();
                            Dust.NewDust(new Vector2((float) (j * 0x10), (float) (i * 0x10)), 0x10, 0x10, 14, 0f, 0f, 0, color4, 1f);
                        }
                        else if ((((tile[j, i].type == 0x17) || (tile[j, i].type == 0x18)) || (tile[j, i].type == 0x20)) && (rand.Next(500) == 0))
                        {
                            color4 = new Color();
                            Dust.NewDust(new Vector2((float) (j * 0x10), (float) (i * 0x10)), 0x10, 0x10, 14, 0f, 0f, 0, color4, 1f);
                        }
                        else if ((tile[j, i].type == 0x19) && (rand.Next(700) == 0))
                        {
                            color4 = new Color();
                            Dust.NewDust(new Vector2((float) (j * 0x10), (float) (i * 0x10)), 0x10, 0x10, 14, 0f, 0f, 0, color4, 1f);
                        }
                        else if ((tile[j, i].type == 0x1f) && (rand.Next(20) == 0))
                        {
                            color4 = new Color();
                            Dust.NewDust(new Vector2((float) (j * 0x10), (float) (i * 0x10)), 0x10, 0x10, 14, 0f, 0f, 100, color4, 1f);
                        }
                        else if ((tile[j, i].type == 0x1a) && (rand.Next(20) == 0))
                        {
                            color4 = new Color();
                            Dust.NewDust(new Vector2((float) (j * 0x10), (float) (i * 0x10)), 0x10, 0x10, 14, 0f, 0f, 100, color4, 1f);
                        }
                        else if (((tile[j, i].type == 0x47) || (tile[j, i].type == 0x48)) && (rand.Next(500) == 0))
                        {
                            color4 = new Color();
                            Dust.NewDust(new Vector2((float) (j * 0x10), (float) (i * 0x10)), 0x10, 0x10, 0x29, 0f, 0f, 250, color4, 0.8f);
                        }
                        else if (((tile[j, i].type == 0x11) || (tile[j, i].type == 0x4d)) && (rand.Next(40) == 0))
                        {
                            if ((tile[j, i].frameX == 0x12) & (tile[j, i].frameY == 0x12))
                            {
                                color4 = new Color();
                                Dust.NewDust(new Vector2((float) ((j * 0x10) + 2), (float) (i * 0x10)), 8, 6, 6, 0f, 0f, 100, color4, 1f);
                            }
                        }
                        else if ((tile[j, i].type == 0x25) && (rand.Next(250) == 0))
                        {
                            color4 = new Color();
                            int num11 = Dust.NewDust(new Vector2((float) (j * 0x10), (float) (i * 0x10)), 0x10, 0x10, 6, 0f, 0f, 0, color4, (float) rand.Next(3));
                            if (dust[num11].scale > 1f)
                            {
                                dust[num11].noGravity = true;
                            }
                        }
                        else if (((tile[j, i].type == 0x3a) || (tile[j, i].type == 0x4c)) && (rand.Next(250) == 0))
                        {
                            color4 = new Color();
                            int num12 = Dust.NewDust(new Vector2((float) (j * 0x10), (float) (i * 0x10)), 0x10, 0x10, 6, 0f, 0f, 0, color4, (float) rand.Next(3));
                            if (dust[num12].scale > 1f)
                            {
                                dust[num12].noGravity = true;
                            }
                            dust[num12].noLight = true;
                        }
                        else if (tile[j, i].type == 0x3d)
                        {
                            if (tile[j, i].frameX == 0x90)
                            {
                                if (rand.Next(60) == 0)
                                {
                                    color4 = new Color();
                                    int num13 = Dust.NewDust(new Vector2((float) (j * 0x10), (float) (i * 0x10)), 0x10, 0x10, 0x2c, 0f, 0f, 250, color4, 0.4f);
                                    dust[num13].fadeIn = 0.7f;
                                }
                                color.A = (byte) (245f - (mouseTextColor * 1.5f));
                                color.R = (byte) (245f - (mouseTextColor * 1.5f));
                                color.B = (byte) (245f - (mouseTextColor * 1.5f));
                                color.G = (byte) (245f - (mouseTextColor * 1.5f));
                            }
                        }
                        else if ((((tileShine[tile[j, i].type] > 0) && (color.R > 60)) && (rand.Next(tileShine[tile[j, i].type]) < (color.R / 50))) && ((tile[j, i].type != 0x15) || ((tile[j, i].frameX >= 0x24) && (tile[j, i].frameX < 180))))
                        {
                            color4 = new Color();
                            int num14 = Dust.NewDust(new Vector2((float) (j * 0x10), (float) (i * 0x10)), 0x10, 0x10, 0x2b, 0f, 0f, 0xfe, color4, 0.5f);
                            Dust dust2 = dust[num14];
                            dust2.velocity = (Vector2) (dust2.velocity * 0f);
                        }
                    }
                    if (((tile[j, i].type == 5) && (tile[j, i].frameY >= 0xc6)) && (tile[j, i].frameX >= 0x16))
                    {
                        int num15 = 0;
                        if (tile[j, i].frameX == 0x16)
                        {
                            if (tile[j, i].frameY == 220)
                            {
                                num15 = 1;
                            }
                            else if (tile[j, i].frameY == 0xf2)
                            {
                                num15 = 2;
                            }
                            int num16 = 0;
                            int num17 = 80;
                            int num18 = 80;
                            int num19 = 0x20;
                            for (int k = i; k < (i + 100); k++)
                            {
                                if (tile[j, k].type == 2)
                                {
                                    num16 = 0;
                                    break;
                                }
                                if (tile[j, k].type == 0x17)
                                {
                                    num16 = 1;
                                    break;
                                }
                                if (tile[j, k].type == 60)
                                {
                                    num16 = 2;
                                    num17 = 0x72;
                                    num18 = 0x60;
                                    num19 = 0x30;
                                    break;
                                }
                            }
                            vector2 = new Vector2();
                            this.spriteBatch.Draw(treeTopTexture[num16], new Vector2((float) (((j * 0x10) - ((int) screenPosition.X)) - num19), (float) ((((i * 0x10) - ((int) screenPosition.Y)) - num18) + 0x10)), new Rectangle(num15 * (num17 + 2), 0, num17, num18), Lighting.GetColor(j, i), 0f, vector2, (float) 1f, SpriteEffects.None, 0f);
                        }
                        else if (tile[j, i].frameX == 0x2c)
                        {
                            if (tile[j, i].frameY == 220)
                            {
                                num15 = 1;
                            }
                            else if (tile[j, i].frameY == 0xf2)
                            {
                                num15 = 2;
                            }
                            int num21 = 0;
                            for (int m = i; m < (i + 100); m++)
                            {
                                if (tile[j + 1, m].type == 2)
                                {
                                    num21 = 0;
                                    break;
                                }
                                if (tile[j + 1, m].type == 0x17)
                                {
                                    num21 = 1;
                                    break;
                                }
                                if (tile[j + 1, m].type == 60)
                                {
                                    num21 = 2;
                                    break;
                                }
                            }
                            vector2 = new Vector2();
                            this.spriteBatch.Draw(treeBranchTexture[num21], new Vector2((float) (((j * 0x10) - ((int) screenPosition.X)) - 0x18), (float) (((i * 0x10) - ((int) screenPosition.Y)) - 12)), new Rectangle(0, num15 * 0x2a, 40, 40), Lighting.GetColor(j, i), 0f, vector2, (float) 1f, SpriteEffects.None, 0f);
                        }
                        else if (tile[j, i].frameX == 0x42)
                        {
                            if (tile[j, i].frameY == 220)
                            {
                                num15 = 1;
                            }
                            else if (tile[j, i].frameY == 0xf2)
                            {
                                num15 = 2;
                            }
                            int num23 = 0;
                            for (int n = i; n < (i + 100); n++)
                            {
                                if (tile[j - 1, n].type == 2)
                                {
                                    num23 = 0;
                                    break;
                                }
                                if (tile[j - 1, n].type == 0x17)
                                {
                                    num23 = 1;
                                    break;
                                }
                                if (tile[j - 1, n].type == 60)
                                {
                                    num23 = 2;
                                    break;
                                }
                            }
                            vector2 = new Vector2();
                            this.spriteBatch.Draw(treeBranchTexture[num23], new Vector2((float) ((j * 0x10) - ((int) screenPosition.X)), (float) (((i * 0x10) - ((int) screenPosition.Y)) - 12)), new Rectangle(0x2a, num15 * 0x2a, 40, 40), Lighting.GetColor(j, i), 0f, vector2, (float) 1f, SpriteEffects.None, 0f);
                        }
                    }
                    if ((tile[j, i].type == 0x48) && (tile[j, i].frameX >= 0x24))
                    {
                        int num25 = 0;
                        if (tile[j, i].frameY == 0x12)
                        {
                            num25 = 1;
                        }
                        else if (tile[j, i].frameY == 0x24)
                        {
                            num25 = 2;
                        }
                        vector2 = new Vector2();
                        this.spriteBatch.Draw(shroomCapTexture, new Vector2((float) (((j * 0x10) - ((int) screenPosition.X)) - 0x16), (float) (((i * 0x10) - ((int) screenPosition.Y)) - 0x1a)), new Rectangle(num25 * 0x3e, 0, 60, 0x2a), Lighting.GetColor(j, i), 0f, vector2, (float) 1f, SpriteEffects.None, 0f);
                    }
                    if (color.R > 0)
                    {
                        if (((solidOnly && tileSolid[tile[j, i].type]) && !tileSolidTop[tile[j, i].type]) && (((tile[j - 1, i].liquid > 0) || (tile[j + 1, i].liquid > 0)) || ((tile[j, i - 1].liquid > 0) || (tile[j, i + 1].liquid > 0))))
                        {
                            Color color2 = Lighting.GetColor(j, i);
                            int liquid = 0;
                            bool flag = false;
                            bool flag2 = false;
                            bool flag3 = false;
                            bool flag4 = false;
                            int num27 = 0;
                            bool flag5 = false;
                            if (tile[j - 1, i].liquid > liquid)
                            {
                                liquid = tile[j - 1, i].liquid;
                                flag = true;
                            }
                            else if (tile[j - 1, i].liquid > 0)
                            {
                                flag = true;
                            }
                            if (tile[j + 1, i].liquid > liquid)
                            {
                                liquid = tile[j + 1, i].liquid;
                                flag2 = true;
                            }
                            else if (tile[j + 1, i].liquid > 0)
                            {
                                liquid = tile[j + 1, i].liquid;
                                flag2 = true;
                            }
                            if (tile[j, i - 1].liquid > 0)
                            {
                                flag3 = true;
                            }
                            if (tile[j, i + 1].liquid > 240)
                            {
                                flag4 = true;
                            }
                            if (tile[j - 1, i].liquid > 0)
                            {
                                if (tile[j - 1, i].lava)
                                {
                                    num27 = 1;
                                }
                                else
                                {
                                    flag5 = true;
                                }
                            }
                            if (tile[j + 1, i].liquid > 0)
                            {
                                if (tile[j + 1, i].lava)
                                {
                                    num27 = 1;
                                }
                                else
                                {
                                    flag5 = true;
                                }
                            }
                            if (tile[j, i - 1].liquid > 0)
                            {
                                if (tile[j, i - 1].lava)
                                {
                                    num27 = 1;
                                }
                                else
                                {
                                    flag5 = true;
                                }
                            }
                            if (tile[j, i + 1].liquid > 0)
                            {
                                if (tile[j, i + 1].lava)
                                {
                                    num27 = 1;
                                }
                                else
                                {
                                    flag5 = true;
                                }
                            }
                            if (!flag5 || (num27 != 1))
                            {
                                float num28 = 0f;
                                Vector2 vector = new Vector2((float) (j * 0x10), (float) (i * 0x10));
                                Rectangle rectangle = new Rectangle(0, 4, 0x10, 0x10);
                                if (flag4 && (flag || flag2))
                                {
                                    flag = true;
                                    flag2 = true;
                                }
                                if ((!flag3 || (!flag && !flag2)) && (!flag4 || !flag3))
                                {
                                    if (flag3)
                                    {
                                        rectangle = new Rectangle(0, 4, 0x10, 4);
                                    }
                                    else if ((flag4 && !flag) && !flag2)
                                    {
                                        vector = new Vector2((float) (j * 0x10), (float) ((i * 0x10) + 12));
                                        rectangle = new Rectangle(0, 4, 0x10, 4);
                                    }
                                    else
                                    {
                                        num28 = 0x100 - liquid;
                                        num28 /= 32f;
                                        if (flag && flag2)
                                        {
                                            vector = new Vector2((float) (j * 0x10), (float) ((i * 0x10) + (((int) num28) * 2)));
                                            rectangle = new Rectangle(0, 4, 0x10, 0x10 - (((int) num28) * 2));
                                        }
                                        else if (flag)
                                        {
                                            vector = new Vector2((float) (j * 0x10), (float) ((i * 0x10) + (((int) num28) * 2)));
                                            rectangle = new Rectangle(0, 4, 4, 0x10 - (((int) num28) * 2));
                                        }
                                        else
                                        {
                                            vector = new Vector2((float) ((j * 0x10) + 12), (float) ((i * 0x10) + (((int) num28) * 2)));
                                            rectangle = new Rectangle(0, 4, 4, 0x10 - (((int) num28) * 2));
                                        }
                                    }
                                }
                                float num29 = 0.5f;
                                if (num27 == 1)
                                {
                                    num29 *= 1.6f;
                                }
                                if ((i < worldSurface) || (num29 > 1f))
                                {
                                    num29 = 1f;
                                }
                                float num30 = color2.R * num29;
                                float num31 = color2.G * num29;
                                float num32 = color2.B * num29;
                                float num33 = color2.A * num29;
                                color2 = new Color((int) ((byte) num30), (int) ((byte) num31), (int) ((byte) num32), (int) ((byte) num33));
                                vector2 = new Vector2();
                                this.spriteBatch.Draw(liquidTexture[num27], vector - screenPosition, new Rectangle?(rectangle), color2, 0f, vector2, (float) 1f, SpriteEffects.None, 0f);
                            }
                        }
                        if (tile[j, i].type == 0x33)
                        {
                            Color color3 = Lighting.GetColor(j, i);
                            float num34 = 0.5f;
                            float num35 = color3.R * num34;
                            float num36 = color3.G * num34;
                            float num37 = color3.B * num34;
                            float num38 = color3.A * num34;
                            color3 = new Color((int) ((byte) num35), (int) ((byte) num36), (int) ((byte) num37), (int) ((byte) num38));
                            vector2 = new Vector2();
                            this.spriteBatch.Draw(tileTexture[tile[j, i].type], new Vector2(((j * 0x10) - ((int) screenPosition.X)) - ((width - 16f) / 2f), (float) (((i * 0x10) - ((int) screenPosition.Y)) + num9)), new Rectangle(tile[j, i].frameX, tile[j, i].frameY, width, height), color3, 0f, vector2, (float) 1f, SpriteEffects.None, 0f);
                        }
                        else if (tileAlch[tile[j, i].type])
                        {
                            height = 20;
                            num9 = -1;
                            int type = tile[j, i].type;
                            int num40 = tile[j, i].frameX / 0x12;
                            if (type > 0x52)
                            {
                                if ((num40 == 0) && dayTime)
                                {
                                    type = 0x54;
                                }
                                if ((num40 == 1) && !dayTime)
                                {
                                    type = 0x54;
                                }
                                if ((num40 == 3) && bloodMoon)
                                {
                                    type = 0x54;
                                }
                            }
                            if (type == 0x54)
                            {
                                if ((num40 == 0) && (rand.Next(100) == 0))
                                {
                                    color4 = new Color();
                                    int num41 = Dust.NewDust(new Vector2((float) (j * 0x10), (float) ((i * 0x10) - 4)), 0x10, 0x10, 0x13, 0f, 0f, 160, color4, 0.1f);
                                    dust[num41].velocity.X /= 2f;
                                    dust[num41].velocity.Y /= 2f;
                                    dust[num41].noGravity = true;
                                    dust[num41].fadeIn = 1f;
                                }
                                if ((num40 == 1) && (rand.Next(100) == 0))
                                {
                                    color4 = new Color();
                                    Dust.NewDust(new Vector2((float) (j * 0x10), (float) (i * 0x10)), 0x10, 0x10, 0x29, 0f, 0f, 250, color4, 0.8f);
                                }
                                if (num40 == 3)
                                {
                                    if (rand.Next(200) == 0)
                                    {
                                        color4 = new Color();
                                        int num42 = Dust.NewDust(new Vector2((float) (j * 0x10), (float) (i * 0x10)), 0x10, 0x10, 14, 0f, 0f, 100, color4, 0.2f);
                                        dust[num42].fadeIn = 1.2f;
                                    }
                                    if (rand.Next(0x4b) == 0)
                                    {
                                        color4 = new Color();
                                        int num43 = Dust.NewDust(new Vector2((float) (j * 0x10), (float) (i * 0x10)), 0x10, 0x10, 0x1b, 0f, 0f, 100, color4, 1f);
                                        dust[num43].velocity.X /= 2f;
                                        dust[num43].velocity.Y /= 2f;
                                    }
                                }
                                if ((num40 == 4) && (rand.Next(150) == 0))
                                {
                                    color4 = new Color();
                                    int num44 = Dust.NewDust(new Vector2((float) (j * 0x10), (float) (i * 0x10)), 0x10, 8, 0x10, 0f, 0f, 0, color4, 1f);
                                    dust[num44].velocity.X /= 3f;
                                    dust[num44].velocity.Y /= 3f;
                                    dust[num44].velocity.Y -= 0.7f;
                                    dust[num44].alpha = 50;
                                    Dust dust3 = dust[num44];
                                    dust3.scale *= 0.1f;
                                    dust[num44].fadeIn = 0.9f;
                                    dust[num44].noGravity = true;
                                }
                                if (num40 == 5)
                                {
                                    if (rand.Next(40) == 0)
                                    {
                                        color4 = new Color();
                                        int num45 = Dust.NewDust(new Vector2((float) (j * 0x10), (float) ((i * 0x10) - 6)), 0x10, 0x10, 6, 0f, 0f, 0, color4, 1.5f);
                                        dust[num45].velocity.Y -= 2f;
                                        dust[num45].noGravity = true;
                                    }
                                    color.A = (byte) (mouseTextColor / 2);
                                    color.G = mouseTextColor;
                                    color.B = mouseTextColor;
                                }
                            }
                            vector2 = new Vector2();
                            this.spriteBatch.Draw(tileTexture[type], new Vector2(((j * 0x10) - ((int) screenPosition.X)) - ((width - 16f) / 2f), (float) (((i * 0x10) - ((int) screenPosition.Y)) + num9)), new Rectangle(tile[j, i].frameX, tile[j, i].frameY, width, height), color, 0f, vector2, (float) 1f, SpriteEffects.None, 0f);
                        }
                        else
                        {
                            vector2 = new Vector2();
                            this.spriteBatch.Draw(tileTexture[tile[j, i].type], new Vector2(((j * 0x10) - ((int) screenPosition.X)) - ((width - 16f) / 2f), (float) (((i * 0x10) - ((int) screenPosition.Y)) + num9)), new Rectangle(tile[j, i].frameX, tile[j, i].frameY, width, height), color, 0f, vector2, (float) 1f, SpriteEffects.None, 0f);
                        }
                    }
                }
            }
        }

        protected void DrawWater(bool bg = false)
        {
            int num = (int) ((screenPosition.X / 16f) - 1f);
            int maxTilesX = ((int) ((screenPosition.X + screenWidth) / 16f)) + 2;
            int num3 = (int) ((screenPosition.Y / 16f) - 1f);
            int maxTilesY = ((int) ((screenPosition.Y + screenHeight) / 16f)) + 2;
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
            for (int i = num3; i < (maxTilesY + 4); i++)
            {
                for (int j = num - 2; j < (maxTilesX + 2); j++)
                {
                    if ((tile[j, i].liquid <= 0) || (Lighting.Brightness(j, i) <= 0f))
                    {
                        continue;
                    }
                    Color color = Lighting.GetColor(j, i);
                    float num7 = 0x100 - tile[j, i].liquid;
                    num7 /= 32f;
                    int index = 0;
                    if (tile[j, i].lava)
                    {
                        index = 1;
                    }
                    float num9 = 0.5f;
                    if (bg)
                    {
                        num9 = 1f;
                    }
                    Vector2 vector = new Vector2((float) (j * 0x10), (float) ((i * 0x10) + (((int) num7) * 2)));
                    Rectangle rectangle = new Rectangle(0, 0, 0x10, 0x10 - (((int) num7) * 2));
                    if ((tile[j, i + 1].liquid < 0xf5) && ((!tile[j, i + 1].active || !tileSolid[tile[j, i + 1].type]) || tileSolidTop[tile[j, i + 1].type]))
                    {
                        float num10 = 0x100 - tile[j, i + 1].liquid;
                        num10 /= 32f;
                        num9 = (0.5f * (8f - num7)) / 4f;
                        if (num9 > 0.55)
                        {
                            num9 = 0.55f;
                        }
                        if (num9 < 0.35)
                        {
                            num9 = 0.35f;
                        }
                        float num11 = num7 / 2f;
                        if (tile[j, i + 1].liquid < 200)
                        {
                            if (bg)
                            {
                                continue;
                            }
                            if ((tile[j, i - 1].liquid > 0) && (tile[j, i - 1].liquid > 0))
                            {
                                rectangle = new Rectangle(0, 4, 0x10, 0x10);
                                num9 = 0.5f;
                            }
                            else if (tile[j, i - 1].liquid > 0)
                            {
                                vector = new Vector2((float) (j * 0x10), (float) ((i * 0x10) + 4));
                                rectangle = new Rectangle(0, 4, 0x10, 12);
                                num9 = 0.5f;
                            }
                            else if (tile[j, i + 1].liquid > 0)
                            {
                                vector = new Vector2((float) (j * 0x10), (float) (((i * 0x10) + (((int) num7) * 2)) + (((int) num10) * 2)));
                                rectangle = new Rectangle(0, 4, 0x10, 0x10 - (((int) num7) * 2));
                            }
                            else
                            {
                                vector = new Vector2((float) ((j * 0x10) + ((int) num11)), (float) (((i * 0x10) + (((int) num11) * 2)) + (((int) num10) * 2)));
                                rectangle = new Rectangle(0, 4, 0x10 - (((int) num11) * 2), 0x10 - (((int) num11) * 2));
                            }
                        }
                        else
                        {
                            num9 = 0.5f;
                            rectangle = new Rectangle(0, 4, 0x10, (0x10 - (((int) num7) * 2)) + (((int) num10) * 2));
                        }
                    }
                    else if (tile[j, i - 1].liquid > 0x20)
                    {
                        rectangle = new Rectangle(0, 4, rectangle.Width, rectangle.Height);
                    }
                    else if (((num7 < 1f) && tile[j, i - 1].active) && (tileSolid[tile[j, i - 1].type] && !tileSolidTop[tile[j, i - 1].type]))
                    {
                        vector = new Vector2((float) (j * 0x10), (float) (i * 0x10));
                        rectangle = new Rectangle(0, 4, 0x10, 0x10);
                    }
                    else
                    {
                        bool flag = true;
                        for (int k = i + 1; k < (i + 6); k++)
                        {
                            if ((tile[j, k].active && tileSolid[tile[j, k].type]) && !tileSolidTop[tile[j, k].type])
                            {
                                break;
                            }
                            if (tile[j, k].liquid < 200)
                            {
                                flag = false;
                                break;
                            }
                        }
                        if (!flag)
                        {
                            num9 = 0.5f;
                            rectangle = new Rectangle(0, 4, 0x10, 0x10);
                        }
                        else if (tile[j, i - 1].liquid > 0)
                        {
                            rectangle = new Rectangle(0, 2, rectangle.Width, rectangle.Height);
                        }
                    }
                    if (tile[j, i].lava)
                    {
                        num9 *= 1.8f;
                        if (num9 > 1f)
                        {
                            num9 = 1f;
                        }
                        if ((base.IsActive && !gamePaused) && (Dust.lavaBubbles < 200))
                        {
                            if ((tile[j, i].liquid > 200) && (rand.Next(700) == 0))
                            {
                                Color newColor = new Color();
                                Dust.NewDust(new Vector2((float) (j * 0x10), (float) (i * 0x10)), 0x10, 0x10, 0x23, 0f, 0f, 0, newColor, 1f);
                            }
                            if ((rectangle.Y == 0) && (rand.Next(350) == 0))
                            {
                                Color color3 = new Color();
                                int num13 = Dust.NewDust(new Vector2((float) (j * 0x10), ((i * 0x10) + (num7 * 2f)) - 8f), 0x10, 8, 0x23, 0f, 0f, 50, color3, 1.5f);
                                Dust dust1 = dust[num13];
                                dust1.velocity = (Vector2) (dust1.velocity * 0.8f);
                                dust[num13].velocity.X *= 2f;
                                dust[num13].velocity.Y -= rand.Next(1, 7) * 0.1f;
                                if (rand.Next(10) == 0)
                                {
                                    dust[num13].velocity.Y *= rand.Next(2, 5);
                                }
                                dust[num13].noGravity = true;
                            }
                        }
                    }
                    float num14 = color.R * num9;
                    float num15 = color.G * num9;
                    float num16 = color.B * num9;
                    float num17 = color.A * num9;
                    color = new Color((int) ((byte) num14), (int) ((byte) num15), (int) ((byte) num16), (int) ((byte) num17));
                    Vector2 origin = new Vector2();
                    this.spriteBatch.Draw(liquidTexture[index], vector - screenPosition, new Rectangle?(rectangle), color, 0f, origin, (float) 1f, SpriteEffects.None, 0f);
                }
            }
        }

        private static void ErasePlayer(int i)
        {
            try
            {
                File.Delete(loadPlayerPath[i]);
                File.Delete(loadPlayerPath[i] + ".bak");
                LoadPlayers();
            }
            catch
            {
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
                string str2 = (pressedKeys[i]).ToString();
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
        private static void HelpText()
        {
            bool flag = false;
            if (player[myPlayer].statLifeMax > 100)
            {
                flag = true;
            }
            bool flag2 = false;
            if (player[myPlayer].statManaMax > 0)
            {
                flag2 = true;
            }
            bool flag3 = true;
            bool flag4 = false;
            bool flag5 = false;
            bool flag6 = false;
            bool flag7 = false;
            bool flag8 = false;
            bool flag9 = false;
            bool flag10 = false;
            for (int i = 0; i < 0x2c; i++)
            {
                if ((player[myPlayer].inventory[i].pick > 0) && (player[myPlayer].inventory[i].name != "Copper Pickaxe"))
                {
                    flag3 = false;
                }
                if ((player[myPlayer].inventory[i].axe > 0) && (player[myPlayer].inventory[i].name != "Copper Axe"))
                {
                    flag3 = false;
                }
                if (player[myPlayer].inventory[i].hammer > 0)
                {
                    flag3 = false;
                }
                if (((player[myPlayer].inventory[i].type == 11) || (player[myPlayer].inventory[i].type == 12)) || ((player[myPlayer].inventory[i].type == 13) || (player[myPlayer].inventory[i].type == 14)))
                {
                    flag4 = true;
                }
                if (((player[myPlayer].inventory[i].type == 0x13) || (player[myPlayer].inventory[i].type == 20)) || ((player[myPlayer].inventory[i].type == 0x15) || (player[myPlayer].inventory[i].type == 0x16)))
                {
                    flag5 = true;
                }
                if (player[myPlayer].inventory[i].type == 0x4b)
                {
                    flag6 = true;
                }
                if (player[myPlayer].inventory[i].type == 0x4b)
                {
                    flag8 = true;
                }
                if ((player[myPlayer].inventory[i].type == 0x44) || (player[myPlayer].inventory[i].type == 70))
                {
                    flag9 = true;
                }
                if (player[myPlayer].inventory[i].type == 0x54)
                {
                    flag10 = true;
                }
                if (player[myPlayer].inventory[i].type == 0x75)
                {
                    flag7 = true;
                }
            }
            bool flag11 = false;
            bool flag12 = false;
            bool flag13 = false;
            bool flag14 = false;
            for (int j = 0; j < 0x3e8; j++)
            {
                if (npc[j].active)
                {
                    if (npc[j].type == 0x11)
                    {
                        flag11 = true;
                    }
                    if (npc[j].type == 0x12)
                    {
                        flag12 = true;
                    }
                    if (npc[j].type == 0x13)
                    {
                        flag14 = true;
                    }
                    if (npc[j].type == 20)
                    {
                        flag13 = true;
                    }
                }
            }
        Label_0316:
            helpText++;
            if (flag3)
            {
                if (helpText == 1)
                {
                    npcChatText = "You can use your pickaxe to dig through dirt, and your axe to chop down trees. Just place your cursor over the tile and click!";
                    return;
                }
                if (helpText == 2)
                {
                    npcChatText = "If you want to survive, you will need to create weapons and shelter. Start by chopping down trees and gathering wood.";
                    return;
                }
                if (helpText == 3)
                {
                    npcChatText = "Press ESC to access your crafting menu. When you have enough wood, create a workbench. This will allow you to create more complicated things, as long as you are standing close to it.";
                    return;
                }
                if (helpText == 4)
                {
                    npcChatText = "You can build a shelter by placing wood or other blocks in the world. Don't forget to create and place walls.";
                    return;
                }
                if (helpText == 5)
                {
                    npcChatText = "Once you have a wooden sword, you might try to gather some gel from the slimes. Combine wood and gel to make a torch!";
                    return;
                }
                if (helpText == 6)
                {
                    npcChatText = "To interact with backgrounds and placed objects, use a hammer!";
                    return;
                }
            }
            if ((flag3 && !flag4) && (!flag5 && (helpText == 11)))
            {
                npcChatText = "You should do some mining to find metal ore. You can craft very useful things with it.";
            }
            else
            {
                if ((flag3 && flag4) && !flag5)
                {
                    if (helpText == 0x15)
                    {
                        npcChatText = "Now that you have some ore, you will need to turn it into a bar in order to make items with it. This requires a furnace!";
                        return;
                    }
                    if (helpText == 0x16)
                    {
                        npcChatText = "You can create a furnace out of torches, wood, and stone. Make sure you are standing near a work bench.";
                        return;
                    }
                }
                if (flag3 && flag5)
                {
                    if (helpText == 0x1f)
                    {
                        npcChatText = "You will need an anvil to make most things out of metal bars.";
                        return;
                    }
                    if (helpText == 0x20)
                    {
                        npcChatText = "Anvils can be crafted out of iron, or purchased from a merchant.";
                        return;
                    }
                }
                if (!flag && (helpText == 0x29))
                {
                    npcChatText = "Underground are crystal hearts that can be used to increase your max life. You will need a hammer to obtain them.";
                }
                else if (!flag2 && (helpText == 0x2a))
                {
                    npcChatText = "If you gather 10 fallen stars, they can be combined to create an item that will increase your magic capacity.";
                }
                else if ((!flag2 && !flag6) && (helpText == 0x2b))
                {
                    npcChatText = "Stars fall all over the world at night. They can be used for all sorts of usefull things. If you see one, be sure to grab it because they disappear after sunrise.";
                }
                else
                {
                    if (!flag11 && !flag12)
                    {
                        if (helpText == 0x33)
                        {
                            npcChatText = "There are many different ways you can attract people to move in to our town. They will of course need a home to live in.";
                            return;
                        }
                        if (helpText == 0x34)
                        {
                            npcChatText = "In order for a room to be considered a home, it needs to have a door, chair, table, and a light source.  Make sure the house has walls as well.";
                            return;
                        }
                        if (helpText == 0x35)
                        {
                            npcChatText = "Two people will not live in the same home. Also, if their home is destroyed, they will look for a new place to live.";
                            return;
                        }
                    }
                    if (!flag11 && (helpText == 0x3d))
                    {
                        npcChatText = "If you want a merchant to move in, you will need to gather plenty of money. 50 silver coins should do the trick!";
                    }
                    else if (!flag12 && (helpText == 0x3e))
                    {
                        npcChatText = "For a nurse to move in, you might want to increase your maximum life.";
                    }
                    else if (!flag14 && (helpText == 0x3f))
                    {
                        npcChatText = "If you had a gun, I bet an arms dealer might show up to sell you some ammo!";
                    }
                    else if (!flag13 && (helpText == 0x40))
                    {
                        npcChatText = "You should prove yourself by defeating a strong monster. That will get the attention of a dryad.";
                    }
                    else if (flag8 && (helpText == 0x47))
                    {
                        npcChatText = "If you combine lenses at a demon altar, you might be able to find a way to summon a powerful monster. You will want to wait until night before using it, though.";
                    }
                    else if (flag9 && (helpText == 0x48))
                    {
                        npcChatText = "You can create worm bait with rotten chunks and vile powder. Make sure you are in a corrupt area before using it.";
                    }
                    else if ((flag8 || flag9) && (helpText == 80))
                    {
                        npcChatText = "Demonic altars can usually be found in the corruption. You will need to be near them to craft some items.";
                    }
                    else if (!flag10 && (helpText == 0xc9))
                    {
                        npcChatText = "You can make a grappling hook from a hook and 3 chains. Skeletons found deep underground usually carry hooks, and chains can be made from iron bars.";
                    }
                    else if (flag7 && (helpText == 0xca))
                    {
                        npcChatText = "You can craft a space gun using a flintlock pistol, 10 fallen stars, and 30 meteorite bars.";
                    }
                    else if (helpText == 0x3e8)
                    {
                        npcChatText = "If you see a pot, be sure to smash it open. They contain all sorts of useful supplies.";
                    }
                    else if (helpText == 0x3e9)
                    {
                        npcChatText = "There is treasure hidden all over the world. Some amazing things can be found deep underground!";
                    }
                    else if (helpText == 0x3ea)
                    {
                        npcChatText = "Smashing a shadow orb will cause a meteor to fall out of the sky. Shadow orbs can usually be found in the chasms around corrupt areas.";
                    }
                    else
                    {
                        if (helpText > 0x44c)
                        {
                            helpText = 0;
                        }
                        goto Label_0316;
                    }
                }
            }
        }

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
            for (int j = 0; j < 0x6a; j++)
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
            for (int num11 = 0; num11 < 100; num11++)
            {
                cloud[num11] = new Cloud();
            }
            for (int num12 = 0; num12 < 100; num12++)
            {
                combatText[num12] = new CombatText();
            }
            for (int num13 = 0; num13 < 100; num13++)
            {
                itemText[num13] = new ItemText();
            }
            for (int num14 = 0; num14 < 0x16b; num14++)
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
            if (!dedServ)
            {
                this.graphics.PreferredBackBufferWidth = screenWidth;
                this.graphics.PreferredBackBufferHeight = screenHeight;
                this.graphics.ApplyChanges();
                base.Initialize();
                base.Window.AllowUserResizing = true;
                this.OpenSettings();
                this.OpenRecent();
                Star.SpawnStars();
                foreach (DisplayMode mode in GraphicsAdapter.DefaultAdapter.SupportedDisplayModes)
                {
                    if (((mode.Width < minScreenW) || (mode.Height < minScreenH)) || ((mode.Width > maxScreenW) || (mode.Height > maxScreenH)))
                    {
                        continue;
                    }
                    bool flag = true;
                    for (int num20 = 0; num20 < this.numDisplayModes; num20++)
                    {
                        if ((mode.Width == this.displayWidth[num20]) && (mode.Height == this.displayHeight[num20]))
                        {
                            flag = false;
                            break;
                        }
                    }
                    if (flag)
                    {
                        this.displayHeight[this.numDisplayModes] = mode.Height;
                        this.displayWidth[this.numDisplayModes] = mode.Width;
                        this.numDisplayModes++;
                    }
                }
                if (autoJoin)
                {
                    LoadPlayers();
                    menuMode = 1;
                    menuMultiplayer = true;
                }
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
                if (netMode == 0)
                {
                    NewText(newText, 0xaf, 0x4b, 0xff);
                }
                else if (netMode == 2)
                {
                    NetMessage.SendData(0x19, -1, -1, newText, 0xff, 175f, 75f, 255f, 0);
                }
            }
        }

        protected override void LoadContent()
        {
            try
            {
                engine = new AudioEngine(@"Content\TerrariaMusic.xgs");
                soundBank = new Microsoft.Xna.Framework.Audio.SoundBank(engine, @"Content\Sound Bank.xsb");
                waveBank = new Microsoft.Xna.Framework.Audio.WaveBank(engine, @"Content\Wave Bank.xwb");
                for (int num = 1; num < 9; num++)
                {
                    music[num] = soundBank.GetCue("Music_" + num);
                }
                soundGrab = base.Content.Load<SoundEffect>(@"Sounds\Grab");
                soundInstanceGrab = soundGrab.CreateInstance();
                soundDig[0] = base.Content.Load<SoundEffect>(@"Sounds\Dig_0");
                soundInstanceDig[0] = soundDig[0].CreateInstance();
                soundDig[1] = base.Content.Load<SoundEffect>(@"Sounds\Dig_1");
                soundInstanceDig[1] = soundDig[1].CreateInstance();
                soundDig[2] = base.Content.Load<SoundEffect>(@"Sounds\Dig_2");
                soundInstanceDig[2] = soundDig[2].CreateInstance();
                soundTink[0] = base.Content.Load<SoundEffect>(@"Sounds\Tink_0");
                soundInstanceTink[0] = soundTink[0].CreateInstance();
                soundTink[1] = base.Content.Load<SoundEffect>(@"Sounds\Tink_1");
                soundInstanceTink[1] = soundTink[1].CreateInstance();
                soundTink[2] = base.Content.Load<SoundEffect>(@"Sounds\Tink_2");
                soundInstanceTink[2] = soundTink[2].CreateInstance();
                soundPlayerHit[0] = base.Content.Load<SoundEffect>(@"Sounds\Player_Hit_0");
                soundInstancePlayerHit[0] = soundPlayerHit[0].CreateInstance();
                soundPlayerHit[1] = base.Content.Load<SoundEffect>(@"Sounds\Player_Hit_1");
                soundInstancePlayerHit[1] = soundPlayerHit[1].CreateInstance();
                soundPlayerHit[2] = base.Content.Load<SoundEffect>(@"Sounds\Player_Hit_2");
                soundInstancePlayerHit[2] = soundPlayerHit[2].CreateInstance();
                soundFemaleHit[0] = base.Content.Load<SoundEffect>(@"Sounds\Female_Hit_0");
                soundInstanceFemaleHit[0] = soundFemaleHit[0].CreateInstance();
                soundFemaleHit[1] = base.Content.Load<SoundEffect>(@"Sounds\Female_Hit_1");
                soundInstanceFemaleHit[1] = soundFemaleHit[1].CreateInstance();
                soundFemaleHit[2] = base.Content.Load<SoundEffect>(@"Sounds\Female_Hit_2");
                soundInstanceFemaleHit[2] = soundFemaleHit[2].CreateInstance();
                soundPlayerKilled = base.Content.Load<SoundEffect>(@"Sounds\Player_Killed");
                soundInstancePlayerKilled = soundPlayerKilled.CreateInstance();
                soundChat = base.Content.Load<SoundEffect>(@"Sounds\Chat");
                soundInstanceChat = soundChat.CreateInstance();
                soundGrass = base.Content.Load<SoundEffect>(@"Sounds\Grass");
                soundInstanceGrass = soundGrass.CreateInstance();
                soundDoorOpen = base.Content.Load<SoundEffect>(@"Sounds\Door_Opened");
                soundInstanceDoorOpen = soundDoorOpen.CreateInstance();
                soundDoorClosed = base.Content.Load<SoundEffect>(@"Sounds\Door_Closed");
                soundInstanceDoorClosed = soundDoorClosed.CreateInstance();
                soundMenuTick = base.Content.Load<SoundEffect>(@"Sounds\Menu_Tick");
                soundInstanceMenuTick = soundMenuTick.CreateInstance();
                soundMenuOpen = base.Content.Load<SoundEffect>(@"Sounds\Menu_Open");
                soundInstanceMenuOpen = soundMenuOpen.CreateInstance();
                soundMenuClose = base.Content.Load<SoundEffect>(@"Sounds\Menu_Close");
                soundInstanceMenuClose = soundMenuClose.CreateInstance();
                soundShatter = base.Content.Load<SoundEffect>(@"Sounds\Shatter");
                soundInstanceShatter = soundShatter.CreateInstance();
                soundZombie[0] = base.Content.Load<SoundEffect>(@"Sounds\Zombie_0");
                soundInstanceZombie[0] = soundZombie[0].CreateInstance();
                soundZombie[1] = base.Content.Load<SoundEffect>(@"Sounds\Zombie_1");
                soundInstanceZombie[1] = soundZombie[1].CreateInstance();
                soundZombie[2] = base.Content.Load<SoundEffect>(@"Sounds\Zombie_2");
                soundInstanceZombie[2] = soundZombie[2].CreateInstance();
                soundRoar[0] = base.Content.Load<SoundEffect>(@"Sounds\Roar_0");
                soundInstanceRoar[0] = soundRoar[0].CreateInstance();
                soundRoar[1] = base.Content.Load<SoundEffect>(@"Sounds\Roar_1");
                soundInstanceRoar[1] = soundRoar[1].CreateInstance();
                soundSplash[0] = base.Content.Load<SoundEffect>(@"Sounds\Splash_0");
                soundInstanceSplash[0] = soundRoar[0].CreateInstance();
                soundSplash[1] = base.Content.Load<SoundEffect>(@"Sounds\Splash_1");
                soundInstanceSplash[1] = soundSplash[1].CreateInstance();
                soundDoubleJump = base.Content.Load<SoundEffect>(@"Sounds\Double_Jump");
                soundInstanceDoubleJump = soundRoar[0].CreateInstance();
                soundRun = base.Content.Load<SoundEffect>(@"Sounds\Run");
                soundInstanceRun = soundRun.CreateInstance();
                soundCoins = base.Content.Load<SoundEffect>(@"Sounds\Coins");
                soundInstanceCoins = soundCoins.CreateInstance();
                soundUnlock = base.Content.Load<SoundEffect>(@"Sounds\Unlock");
                soundInstanceUnlock = soundUnlock.CreateInstance();
                soundMaxMana = base.Content.Load<SoundEffect>(@"Sounds\MaxMana");
                soundInstanceMaxMana = soundMaxMana.CreateInstance();
                soundDrown = base.Content.Load<SoundEffect>(@"Sounds\Drown");
                soundInstanceDrown = soundDrown.CreateInstance();
                for (int num2 = 1; num2 < 0x16; num2++)
                {
                    soundItem[num2] = base.Content.Load<SoundEffect>(@"Sounds\Item_" + num2);
                    soundInstanceItem[num2] = soundItem[num2].CreateInstance();
                }
                for (int num3 = 1; num3 < 4; num3++)
                {
                    soundNPCHit[num3] = base.Content.Load<SoundEffect>(@"Sounds\NPC_Hit_" + num3);
                    soundInstanceNPCHit[num3] = soundNPCHit[num3].CreateInstance();
                }
                for (int num4 = 1; num4 < 6; num4++)
                {
                    soundNPCKilled[num4] = base.Content.Load<SoundEffect>(@"Sounds\NPC_Killed_" + num4);
                    soundInstanceNPCKilled[num4] = soundNPCKilled[num4].CreateInstance();
                }
            }
            catch
            {
                musicVolume = 0f;
                soundVolume = 0f;
            }
            raTexture = base.Content.Load<Texture2D>(@"Images\ra-logo");
            reTexture = base.Content.Load<Texture2D>(@"Images\re-logo");
            splashTexture = base.Content.Load<Texture2D>(@"Images\splash");
            fadeTexture = base.Content.Load<Texture2D>(@"Images\fade-out");
            ghostTexture = base.Content.Load<Texture2D>(@"Images\Ghost");
            this.spriteBatch = new SpriteBatch(base.GraphicsDevice);
            for (int i = 0; i < 0x6a; i++)
            {
                tileTexture[i] = base.Content.Load<Texture2D>(@"Images\Tiles_" + i);
            }
            for (int j = 1; j < 0x15; j++)
            {
                wallTexture[j] = base.Content.Load<Texture2D>(@"Images\Wall_" + j);
            }
            for (int k = 1; k < 0x1b; k++)
            {
                buffTexture[k] = base.Content.Load<Texture2D>(@"Images\Buff_" + k);
            }
            for (int m = 0; m < 7; m++)
            {
                backgroundTexture[m] = base.Content.Load<Texture2D>(@"Images\Background_" + m);
                backgroundWidth[m] = backgroundTexture[m].Width;
                backgroundHeight[m] = backgroundTexture[m].Height;
            }
            for (int n = 0; n < 0x16b; n++)
            {
                itemTexture[n] = base.Content.Load<Texture2D>(@"Images\Item_" + n);
            }
            for (int num10 = 0; num10 < 0x4a; num10++)
            {
                npcTexture[num10] = base.Content.Load<Texture2D>(@"Images\NPC_" + num10);
            }
            for (int num11 = 0; num11 < 0x38; num11++)
            {
                projectileTexture[num11] = base.Content.Load<Texture2D>(@"Images\Projectile_" + num11);
            }
            for (int num12 = 1; num12 < 0x63; num12++)
            {
                goreTexture[num12] = base.Content.Load<Texture2D>(@"Images\Gore_" + num12);
            }
            for (int num13 = 0; num13 < 4; num13++)
            {
                cloudTexture[num13] = base.Content.Load<Texture2D>(@"Images\Cloud_" + num13);
            }
            for (int num14 = 0; num14 < 5; num14++)
            {
                starTexture[num14] = base.Content.Load<Texture2D>(@"Images\Star_" + num14);
            }
            for (int num15 = 0; num15 < 2; num15++)
            {
                liquidTexture[num15] = base.Content.Load<Texture2D>(@"Images\Liquid_" + num15);
            }
            HBLockTexture[0] = base.Content.Load<Texture2D>(@"Images\Lock_0");
            HBLockTexture[1] = base.Content.Load<Texture2D>(@"Images\Lock_1");
            trashTexture = base.Content.Load<Texture2D>(@"Images\Trash");
            cdTexture = base.Content.Load<Texture2D>(@"Images\CoolDown");
            logoTexture = base.Content.Load<Texture2D>(@"Images\Logo");
            dustTexture = base.Content.Load<Texture2D>(@"Images\Dust");
            sunTexture = base.Content.Load<Texture2D>(@"Images\Sun");
            sun2Texture = base.Content.Load<Texture2D>(@"Images\Sun2");
            moonTexture = base.Content.Load<Texture2D>(@"Images\Moon");
            blackTileTexture = base.Content.Load<Texture2D>(@"Images\Black_Tile");
            heartTexture = base.Content.Load<Texture2D>(@"Images\Heart");
            bubbleTexture = base.Content.Load<Texture2D>(@"Images\Bubble");
            manaTexture = base.Content.Load<Texture2D>(@"Images\Mana");
            cursorTexture = base.Content.Load<Texture2D>(@"Images\Cursor");
            ninjaTexture = base.Content.Load<Texture2D>(@"Images\Ninja");
            antLionTexture = base.Content.Load<Texture2D>(@"Images\AntlionBody");
            spikeBaseTexture = base.Content.Load<Texture2D>(@"Images\Spike_Base");
            treeTopTexture[0] = base.Content.Load<Texture2D>(@"Images\Tree_Tops_0");
            treeBranchTexture[0] = base.Content.Load<Texture2D>(@"Images\Tree_Branches_0");
            treeTopTexture[1] = base.Content.Load<Texture2D>(@"Images\Tree_Tops_1");
            treeBranchTexture[1] = base.Content.Load<Texture2D>(@"Images\Tree_Branches_1");
            treeTopTexture[2] = base.Content.Load<Texture2D>(@"Images\Tree_Tops_2");
            treeBranchTexture[2] = base.Content.Load<Texture2D>(@"Images\Tree_Branches_2");
            shroomCapTexture = base.Content.Load<Texture2D>(@"Images\Shroom_Tops");
            inventoryBackTexture = base.Content.Load<Texture2D>(@"Images\Inventory_Back");
            inventoryBack2Texture = base.Content.Load<Texture2D>(@"Images\Inventory_Back2");
            inventoryBack3Texture = base.Content.Load<Texture2D>(@"Images\Inventory_Back3");
            inventoryBack4Texture = base.Content.Load<Texture2D>(@"Images\Inventory_Back4");
            inventoryBack5Texture = base.Content.Load<Texture2D>(@"Images\Inventory_Back5");
            inventoryBack6Texture = base.Content.Load<Texture2D>(@"Images\Inventory_Back6");
            inventoryBack7Texture = base.Content.Load<Texture2D>(@"Images\Inventory_Back7");
            inventoryBack8Texture = base.Content.Load<Texture2D>(@"Images\Inventory_Back8");
            inventoryBack9Texture = base.Content.Load<Texture2D>(@"Images\Inventory_Back9");
            inventoryBack10Texture = base.Content.Load<Texture2D>(@"Images\Inventory_Back10");
            textBackTexture = base.Content.Load<Texture2D>(@"Images\Text_Back");
            chatTexture = base.Content.Load<Texture2D>(@"Images\Chat");
            chat2Texture = base.Content.Load<Texture2D>(@"Images\Chat2");
            chatBackTexture = base.Content.Load<Texture2D>(@"Images\Chat_Back");
            teamTexture = base.Content.Load<Texture2D>(@"Images\Team");
            for (int num16 = 1; num16 < 0x11; num16++)
            {
                armorBodyTexture[num16] = base.Content.Load<Texture2D>(@"Images\Armor_Body_" + num16);
                armorArmTexture[num16] = base.Content.Load<Texture2D>(@"Images\Armor_Arm_" + num16);
            }
            for (int num17 = 1; num17 < 0x1d; num17++)
            {
                armorHeadTexture[num17] = base.Content.Load<Texture2D>(@"Images\Armor_Head_" + num17);
            }
            for (int num18 = 1; num18 < 0x10; num18++)
            {
                armorLegTexture[num18] = base.Content.Load<Texture2D>(@"Images\Armor_Legs_" + num18);
            }
            for (int num19 = 0; num19 < 0x24; num19++)
            {
                playerHairTexture[num19] = base.Content.Load<Texture2D>(@"Images\Player_Hair_" + (num19 + 1));
            }
            playerEyeWhitesTexture = base.Content.Load<Texture2D>(@"Images\Player_Eye_Whites");
            playerEyesTexture = base.Content.Load<Texture2D>(@"Images\Player_Eyes");
            playerHandsTexture = base.Content.Load<Texture2D>(@"Images\Player_Hands");
            playerHands2Texture = base.Content.Load<Texture2D>(@"Images\Player_Hands2");
            playerHeadTexture = base.Content.Load<Texture2D>(@"Images\Player_Head");
            playerPantsTexture = base.Content.Load<Texture2D>(@"Images\Player_Pants");
            playerShirtTexture = base.Content.Load<Texture2D>(@"Images\Player_Shirt");
            playerShoesTexture = base.Content.Load<Texture2D>(@"Images\Player_Shoes");
            playerUnderShirtTexture = base.Content.Load<Texture2D>(@"Images\Player_Undershirt");
            playerUnderShirt2Texture = base.Content.Load<Texture2D>(@"Images\Player_Undershirt2");
            chainTexture = base.Content.Load<Texture2D>(@"Images\Chain");
            chain2Texture = base.Content.Load<Texture2D>(@"Images\Chain2");
            chain3Texture = base.Content.Load<Texture2D>(@"Images\Chain3");
            chain4Texture = base.Content.Load<Texture2D>(@"Images\Chain4");
            chain5Texture = base.Content.Load<Texture2D>(@"Images\Chain5");
            chain6Texture = base.Content.Load<Texture2D>(@"Images\Chain6");
            boneArmTexture = base.Content.Load<Texture2D>(@"Images\Arm_Bone");
            fontItemStack = base.Content.Load<SpriteFont>(@"Fonts\Item_Stack");
            fontMouseText = base.Content.Load<SpriteFont>(@"Fonts\Mouse_Text");
            fontDeathText = base.Content.Load<SpriteFont>(@"Fonts\Death_Text");
            fontCombatText[0] = base.Content.Load<SpriteFont>(@"Fonts\Combat_Text");
            fontCombatText[1] = base.Content.Load<SpriteFont>(@"Fonts\Combat_Crit");
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

        protected void MouseText(string cursorText, int rare = 0, byte diff = 0)
        {
            if (cursorText != null)
            {
                float num3;
                int num = mouseState.X + 10;
                int num2 = mouseState.Y + 10;
                Color color = new Color((int) mouseTextColor, (int) mouseTextColor, (int) mouseTextColor, (int) mouseTextColor);
                if (toolTip.type > 0)
                {
                    rare = toolTip.rare;
                    int num4 = 20;
                    int index = 1;
                    string[] strArray = new string[num4];
                    strArray[0] = toolTip.name;
                    if (toolTip.stack > 1)
                    {
                        string[] strArray2 = new string[1];
                        object obj2 = strArray2[0];
                        strArray[0] = string.Concat(new object[] { strArray[0], " (", toolTip.stack, ")" });
                    }
                    if (toolTip.social)
                    {
                        strArray[index] = "Equipped in social slot";
                        index++;
                        strArray[index] = "No stats will be gained";
                        index++;
                    }
                    else
                    {
                        if (toolTip.damage > 0)
                        {
                            string[] strArray6;
                            IntPtr ptr4;
                            int damage = toolTip.damage;
                            if (toolTip.melee)
                            {
                                string[] strArray3;
                                IntPtr ptr;
                                strArray[index] = ((int) (player[myPlayer].meleeDamage * damage)).ToString();
                                (strArray3 = strArray)[(int) (ptr = (IntPtr) index)] = strArray3[(int) ptr] + " melee";
                            }
                            else if (toolTip.ranged)
                            {
                                string[] strArray4;
                                IntPtr ptr2;
                                strArray[index] = ((int) (player[myPlayer].rangedDamage * damage)).ToString();
                                (strArray4 = strArray)[(int) (ptr2 = (IntPtr) index)] = strArray4[(int) ptr2] + " ranged";
                            }
                            else if (toolTip.magic)
                            {
                                string[] strArray5;
                                IntPtr ptr3;
                                strArray[index] = ((int) (player[myPlayer].magicDamage * damage)).ToString();
                                (strArray5 = strArray)[(int) (ptr3 = (IntPtr) index)] = strArray5[(int) ptr3] + " magic";
                            }
                            else
                            {
                                strArray[index] = damage.ToString();
                            }
                            (strArray6 = strArray)[(int) (ptr4 = (IntPtr) index)] = strArray6[(int) ptr4] + " damage";
                            index++;
                            if (toolTip.useStyle > 0)
                            {
                                string[] strArray7;
                                IntPtr ptr5;
                                if (toolTip.useAnimation <= 8)
                                {
                                    strArray[index] = "Insanely fast";
                                }
                                else if (toolTip.useAnimation <= 20)
                                {
                                    strArray[index] = "Very fast";
                                }
                                else if (toolTip.useAnimation <= 0x19)
                                {
                                    strArray[index] = "Fast";
                                }
                                else if (toolTip.useAnimation <= 30)
                                {
                                    strArray[index] = "Average";
                                }
                                else if (toolTip.useAnimation <= 0x23)
                                {
                                    strArray[index] = "Slow";
                                }
                                else if (toolTip.useAnimation <= 0x2d)
                                {
                                    strArray[index] = "Very slow";
                                }
                                else if (toolTip.useAnimation <= 0x37)
                                {
                                    strArray[index] = "Extremely slow";
                                }
                                else
                                {
                                    strArray[index] = "Snail";
                                }
                                (strArray7 = strArray)[(int) (ptr5 = (IntPtr) index)] = strArray7[(int) ptr5] + " speed";
                                index++;
                            }
                        }
                        if (((toolTip.headSlot > 0) || (toolTip.bodySlot > 0)) || ((toolTip.legSlot > 0) || toolTip.accessory))
                        {
                            strArray[index] = "Equipable";
                            index++;
                        }
                        if (toolTip.vanity)
                        {
                            strArray[index] = "Vanity Item";
                            index++;
                        }
                        if (toolTip.defense > 0)
                        {
                            strArray[index] = toolTip.defense + " defense";
                            index++;
                        }
                        if (toolTip.pick > 0)
                        {
                            strArray[index] = toolTip.pick + "% pickaxe power";
                            index++;
                        }
                        if (toolTip.axe > 0)
                        {
                            strArray[index] = (toolTip.axe * 5) + "% axe power";
                            index++;
                        }
                        if (toolTip.hammer > 0)
                        {
                            strArray[index] = toolTip.hammer + "% hammer power";
                            index++;
                        }
                        if (toolTip.healLife > 0)
                        {
                            strArray[index] = "Restores " + toolTip.healLife + " life";
                            index++;
                        }
                        if (toolTip.healMana > 0)
                        {
                            strArray[index] = "Restores " + toolTip.healMana + " mana";
                            index++;
                        }
                        if ((toolTip.mana > 0) && ((toolTip.type != 0x7f) || !player[myPlayer].spaceGun))
                        {
                            strArray[index] = "Uses " + ((int) (toolTip.mana * player[myPlayer].manaCost)) + " mana";
                            index++;
                        }
                        if ((toolTip.createWall > 0) || (toolTip.createTile > -1))
                        {
                            if (toolTip.type != 0xd5)
                            {
                                strArray[index] = "Can be placed";
                                index++;
                            }
                        }
                        else if (toolTip.ammo > 0)
                        {
                            strArray[index] = "Ammo";
                            index++;
                        }
                        else if (toolTip.consumable)
                        {
                            strArray[index] = "Consumable";
                            index++;
                        }
                        if (toolTip.material)
                        {
                            strArray[index] = "Material";
                            index++;
                        }
                        if (toolTip.toolTip != null)
                        {
                            strArray[index] = toolTip.toolTip;
                            index++;
                        }
                        if (toolTip.toolTip2 != null)
                        {
                            strArray[index] = toolTip.toolTip2;
                            index++;
                        }
                        if (toolTip.buffTime > 0)
                        {
                            string str = "0 s";
                            if ((toolTip.buffTime / 60) >= 60)
                            {
                                str = Math.Round((double) (((double) (toolTip.buffTime / 60)) / 60.0)) + " minute duration";
                            }
                            else
                            {
                                str = Math.Round((double) (((double) toolTip.buffTime) / 60.0)) + " second duration";
                            }
                            strArray[index] = str;
                            index++;
                        }
                        if (toolTip.wornArmor && (player[myPlayer].setBonus != ""))
                        {
                            strArray[index] = "Set bonus: " + player[myPlayer].setBonus;
                            index++;
                        }
                    }
                    if (npcShop > 0)
                    {
                        if (toolTip.value > 0)
                        {
                            string str2 = "";
                            int num7 = 0;
                            int num8 = 0;
                            int num9 = 0;
                            int num10 = 0;
                            int num11 = toolTip.value * toolTip.stack;
                            if (!toolTip.buy)
                            {
                                num11 /= 5;
                            }
                            if (num11 < 1)
                            {
                                num11 = 1;
                            }
                            if (num11 >= 0xf4240)
                            {
                                num7 = num11 / 0xf4240;
                                num11 -= num7 * 0xf4240;
                            }
                            if (num11 >= 0x2710)
                            {
                                num8 = num11 / 0x2710;
                                num11 -= num8 * 0x2710;
                            }
                            if (num11 >= 100)
                            {
                                num9 = num11 / 100;
                                num11 -= num9 * 100;
                            }
                            if (num11 >= 1)
                            {
                                num10 = num11;
                            }
                            if (num7 > 0)
                            {
                                str2 = str2 + num7 + " platinum ";
                            }
                            if (num8 > 0)
                            {
                                str2 = str2 + num8 + " gold ";
                            }
                            if (num9 > 0)
                            {
                                str2 = str2 + num9 + " silver ";
                            }
                            if (num10 > 0)
                            {
                                str2 = str2 + num10 + " copper ";
                            }
                            if (!toolTip.buy)
                            {
                                strArray[index] = "Sell price: " + str2;
                            }
                            else
                            {
                                strArray[index] = "Buy price: " + str2;
                            }
                            index++;
                            num3 = ((float) mouseTextColor) / 255f;
                            if (num7 > 0)
                            {
                                color = new Color((int) ((byte) (220f * num3)), (int) ((byte) (220f * num3)), (int) ((byte) (198f * num3)), (int) mouseTextColor);
                            }
                            else if (num8 > 0)
                            {
                                color = new Color((int) ((byte) (224f * num3)), (int) ((byte) (201f * num3)), (int) ((byte) (92f * num3)), (int) mouseTextColor);
                            }
                            else if (num9 > 0)
                            {
                                color = new Color((int) ((byte) (181f * num3)), (int) ((byte) (192f * num3)), (int) ((byte) (193f * num3)), (int) mouseTextColor);
                            }
                            else if (num10 > 0)
                            {
                                color = new Color((int) ((byte) (246f * num3)), (int) ((byte) (138f * num3)), (int) ((byte) (96f * num3)), (int) mouseTextColor);
                            }
                        }
                        else
                        {
                            num3 = ((float) mouseTextColor) / 255f;
                            strArray[index] = "No value";
                            index++;
                            color = new Color((int) ((byte) (120f * num3)), (int) ((byte) (120f * num3)), (int) ((byte) (120f * num3)), (int) mouseTextColor);
                        }
                    }
                    Vector2 vector = new Vector2();
                    int num12 = 0;
                    for (int i = 0; i < index; i++)
                    {
                        Vector2 vector2 = fontMouseText.MeasureString(strArray[i]);
                        if (vector2.X > vector.X)
                        {
                            vector.X = vector2.X;
                        }
                        vector.Y += vector2.Y + num12;
                    }
                    if (((num + vector.X) + 4f) > screenWidth)
                    {
                        num = (int) ((screenWidth - vector.X) - 4f);
                    }
                    if (((num2 + vector.Y) + 4f) > screenHeight)
                    {
                        num2 = (int) ((screenHeight - vector.Y) - 4f);
                    }
                    int num14 = 0;
                    num3 = ((float) mouseTextColor) / 255f;
                    for (int j = 0; j < index; j++)
                    {
                        for (int k = 0; k < 5; k++)
                        {
                            int num17 = num;
                            int num18 = num2 + num14;
                            Color black = Color.Black;
                            switch (k)
                            {
                                case 0:
                                    num17 -= 2;
                                    break;

                                case 1:
                                    num17 += 2;
                                    break;

                                case 2:
                                    num18 -= 2;
                                    break;

                                case 3:
                                    num18 += 2;
                                    break;

                                default:
                                    black = new Color((int) mouseTextColor, (int) mouseTextColor, (int) mouseTextColor, (int) mouseTextColor);
                                    if (j == 0)
                                    {
                                        if (rare == 1)
                                        {
                                            black = new Color((int) ((byte) (150f * num3)), (int) ((byte) (150f * num3)), (int) ((byte) (255f * num3)), (int) mouseTextColor);
                                        }
                                        if (rare == 2)
                                        {
                                            black = new Color((int) ((byte) (150f * num3)), (int) ((byte) (255f * num3)), (int) ((byte) (150f * num3)), (int) mouseTextColor);
                                        }
                                        if (rare == 3)
                                        {
                                            black = new Color((int) ((byte) (255f * num3)), (int) ((byte) (200f * num3)), (int) ((byte) (150f * num3)), (int) mouseTextColor);
                                        }
                                        if (rare == 4)
                                        {
                                            black = new Color((int) ((byte) (255f * num3)), (int) ((byte) (150f * num3)), (int) ((byte) (150f * num3)), (int) mouseTextColor);
                                        }
                                        if (diff == 1)
                                        {
                                            black = new Color((int) ((byte) (mcColor.R * num3)), (int) ((byte) (mcColor.G * num3)), (int) ((byte) (mcColor.B * num3)), (int) mouseTextColor);
                                        }
                                        if (diff == 2)
                                        {
                                            black = new Color((int) ((byte) (hcColor.R * num3)), (int) ((byte) (hcColor.G * num3)), (int) ((byte) (hcColor.B * num3)), (int) mouseTextColor);
                                        }
                                    }
                                    else if (j == (index - 1))
                                    {
                                        black = color;
                                    }
                                    break;
                            }
                            Vector2 origin = new Vector2();
                            this.spriteBatch.DrawString(fontMouseText, strArray[j], new Vector2((float) num17, (float) num18), black, 0f, origin, (float) 1f, SpriteEffects.None, 0f);
                        }
                        num14 += ((int) fontMouseText.MeasureString(strArray[j]).Y) + num12;
                    }
                }
                else
                {
                    if ((buffString != "") && (buffString != null))
                    {
                        for (int m = 0; m < 5; m++)
                        {
                            int num20 = num;
                            int num21 = num2 + ((int) fontMouseText.MeasureString(buffString).Y);
                            Color color3 = Color.Black;
                            switch (m)
                            {
                                case 0:
                                    num20 -= 2;
                                    break;

                                case 1:
                                    num20 += 2;
                                    break;

                                case 2:
                                    num21 -= 2;
                                    break;

                                case 3:
                                    num21 += 2;
                                    break;

                                default:
                                    color3 = new Color((int) mouseTextColor, (int) mouseTextColor, (int) mouseTextColor, (int) mouseTextColor);
                                    break;
                            }
                            Vector2 vector5 = new Vector2();
                            this.spriteBatch.DrawString(fontMouseText, buffString, new Vector2((float) num20, (float) num21), color3, 0f, vector5, (float) 1f, SpriteEffects.None, 0f);
                        }
                    }
                    Vector2 vector3 = fontMouseText.MeasureString(cursorText);
                    if (((num + vector3.X) + 4f) > screenWidth)
                    {
                        num = (int) ((screenWidth - vector3.X) - 4f);
                    }
                    if (((num2 + vector3.Y) + 4f) > screenHeight)
                    {
                        num2 = (int) ((screenHeight - vector3.Y) - 4f);
                    }
                    this.spriteBatch.DrawString(fontMouseText, cursorText, new Vector2((float) num, (float) (num2 - 2)), Color.Black, 0f, new Vector2(), (float) 1f, SpriteEffects.None, 0f);
                    this.spriteBatch.DrawString(fontMouseText, cursorText, new Vector2((float) num, (float) (num2 + 2)), Color.Black, 0f, new Vector2(), (float) 1f, SpriteEffects.None, 0f);
                    this.spriteBatch.DrawString(fontMouseText, cursorText, new Vector2((float) (num - 2), (float) num2), Color.Black, 0f, new Vector2(), (float) 1f, SpriteEffects.None, 0f);
                    this.spriteBatch.DrawString(fontMouseText, cursorText, new Vector2((float) (num + 2), (float) num2), Color.Black, 0f, new Vector2(), (float) 1f, SpriteEffects.None, 0f);
                    num3 = ((float) mouseTextColor) / 255f;
                    Color color4 = new Color((int) mouseTextColor, (int) mouseTextColor, (int) mouseTextColor, (int) mouseTextColor);
                    if (rare == 1)
                    {
                        color4 = new Color((int) ((byte) (150f * num3)), (int) ((byte) (150f * num3)), (int) ((byte) (255f * num3)), (int) mouseTextColor);
                    }
                    if (rare == 2)
                    {
                        color4 = new Color((int) ((byte) (150f * num3)), (int) ((byte) (255f * num3)), (int) ((byte) (150f * num3)), (int) mouseTextColor);
                    }
                    if (rare == 3)
                    {
                        color4 = new Color((int) ((byte) (255f * num3)), (int) ((byte) (200f * num3)), (int) ((byte) (150f * num3)), (int) mouseTextColor);
                    }
                    if (rare == 4)
                    {
                        color4 = new Color((int) ((byte) (255f * num3)), (int) ((byte) (150f * num3)), (int) ((byte) (150f * num3)), (int) mouseTextColor);
                    }
                    if (diff == 1)
                    {
                        color4 = new Color((int) ((byte) (mcColor.R * num3)), (int) ((byte) (mcColor.G * num3)), (int) ((byte) (mcColor.B * num3)), (int) mouseTextColor);
                    }
                    if (diff == 2)
                    {
                        color4 = new Color((int) ((byte) (hcColor.R * num3)), (int) ((byte) (hcColor.G * num3)), (int) ((byte) (hcColor.B * num3)), (int) mouseTextColor);
                    }
                    this.spriteBatch.DrawString(fontMouseText, cursorText, new Vector2((float) num, (float) num2), color4, 0f, new Vector2(), (float) 1f, SpriteEffects.None, 0f);
                }
            }
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
            try
            {
                if (File.Exists(SavePath + @"\config.dat"))
                {
                    using (FileStream stream = new FileStream(SavePath + @"\config.dat", FileMode.Open))
                    {
                        using (BinaryReader reader = new BinaryReader(stream))
                        {
                            int num = reader.ReadInt32();
                            bool flag = reader.ReadBoolean();
                            mouseColor.R = reader.ReadByte();
                            mouseColor.G = reader.ReadByte();
                            mouseColor.B = reader.ReadByte();
                            soundVolume = reader.ReadSingle();
                            musicVolume = reader.ReadSingle();
                            cUp = reader.ReadString();
                            cDown = reader.ReadString();
                            cLeft = reader.ReadString();
                            cRight = reader.ReadString();
                            cJump = reader.ReadString();
                            cThrowItem = reader.ReadString();
                            if (num >= 1)
                            {
                                cInv = reader.ReadString();
                            }
                            if (num >= 12)
                            {
                                cHeal = reader.ReadString();
                                cMana = reader.ReadString();
                                cBuff = reader.ReadString();
                            }
                            if (num >= 13)
                            {
                                cHook = reader.ReadString();
                            }
                            caveParrallax = reader.ReadSingle();
                            if (num >= 2)
                            {
                                fixedTiming = reader.ReadBoolean();
                            }
                            if (num >= 4)
                            {
                                this.graphics.PreferredBackBufferWidth = reader.ReadInt32();
                                this.graphics.PreferredBackBufferHeight = reader.ReadInt32();
                            }
                            if (num >= 8)
                            {
                                autoSave = reader.ReadBoolean();
                            }
                            if (num >= 9)
                            {
                                autoPause = reader.ReadBoolean();
                            }
                            if (num >= 0x13)
                            {
                                showItemText = reader.ReadBoolean();
                            }
                            reader.Close();
                            if (flag && !this.graphics.IsFullScreen)
                            {
                                this.graphics.ToggleFullScreen();
                            }
                        }
                    }
                }
            }
            catch
            {
            }
        }

        public static void PlaySound(int type, int x = -1, int y = -1, int Style = 1)
        {
            int index = Style;
            try
            {
                if (dedServ || (soundVolume == 0f))
                {
                    return;
                }
                bool flag = false;
                float num2 = 1f;
                float num3 = 0f;
                if ((x == -1) || (y == -1))
                {
                    flag = true;
                }
                else
                {
                    if (WorldGen.gen || (netMode == 2))
                    {
                        return;
                    }
                    Rectangle rectangle = new Rectangle(((int) screenPosition.X) - (screenWidth * 2), ((int) screenPosition.Y) - (screenHeight * 2), screenWidth * 5, screenHeight * 5);
                    Rectangle rectangle2 = new Rectangle(x, y, 1, 1);
                    Vector2 vector = new Vector2(screenPosition.X + (screenWidth * 0.5f), screenPosition.Y + (screenHeight * 0.5f));
                    if (rectangle2.Intersects(rectangle))
                    {
                        flag = true;
                    }
                    if (flag)
                    {
                        num3 = (x - vector.X) / (screenWidth * 0.5f);
                        float num4 = Math.Abs((float) (x - vector.X));
                        float num5 = Math.Abs((float) (y - vector.Y));
                        float num6 = (float) Math.Sqrt((double) ((num4 * num4) + (num5 * num5)));
                        num2 = 1f - (num6 / (screenWidth * 1.5f));
                    }
                }
                if (num3 < -1f)
                {
                    num3 = -1f;
                }
                if (num3 > 1f)
                {
                    num3 = 1f;
                }
                if (num2 > 1f)
                {
                    num2 = 1f;
                }
                if ((num2 <= 0f) || !flag)
                {
                    return;
                }
                num2 *= soundVolume;
                if (type == 0)
                {
                    int num7 = rand.Next(3);
                    soundInstanceDig[num7].Stop();
                    soundInstanceDig[num7] = soundDig[num7].CreateInstance();
                    soundInstanceDig[num7].Volume = num2;
                    soundInstanceDig[num7].Pan = num3;
                    soundInstanceDig[num7].Pitch = rand.Next(-10, 11) * 0.01f;
                    soundInstanceDig[num7].Play();
                    return;
                }
                if (type == 1)
                {
                    int num8 = rand.Next(3);
                    soundInstancePlayerHit[num8].Stop();
                    soundInstancePlayerHit[num8] = soundPlayerHit[num8].CreateInstance();
                    soundInstancePlayerHit[num8].Volume = num2;
                    soundInstancePlayerHit[num8].Pan = num3;
                    soundInstancePlayerHit[num8].Play();
                    return;
                }
                if (type != 2)
                {
                    goto Label_030A;
                }
                if (index == 1)
                {
                    switch (rand.Next(3))
                    {
                        case 1:
                            index = 0x12;
                            break;

                        case 2:
                            index = 0x13;
                            goto Label_0296;
                    }
                }
            Label_0296:
                if ((index != 9) && (index != 10))
                {
                    soundInstanceItem[index].Stop();
                }
                soundInstanceItem[index] = soundItem[index].CreateInstance();
                soundInstanceItem[index].Volume = num2;
                soundInstanceItem[index].Pan = num3;
                soundInstanceItem[index].Pitch = rand.Next(-6, 7) * 0.01f;
                soundInstanceItem[index].Play();
                return;
            Label_030A:
                if (type == 3)
                {
                    soundInstanceNPCHit[index].Stop();
                    soundInstanceNPCHit[index] = soundNPCHit[index].CreateInstance();
                    soundInstanceNPCHit[index].Volume = num2;
                    soundInstanceNPCHit[index].Pan = num3;
                    soundInstanceNPCHit[index].Pitch = rand.Next(-10, 11) * 0.01f;
                    soundInstanceNPCHit[index].Play();
                }
                else if (type == 4)
                {
                    soundInstanceNPCKilled[index] = soundNPCKilled[index].CreateInstance();
                    soundInstanceNPCKilled[index].Volume = num2;
                    soundInstanceNPCKilled[index].Pan = num3;
                    soundInstanceNPCKilled[index].Pitch = rand.Next(-10, 11) * 0.01f;
                    soundInstanceNPCKilled[index].Play();
                }
                else if (type == 5)
                {
                    soundInstancePlayerKilled.Stop();
                    soundInstancePlayerKilled = soundPlayerKilled.CreateInstance();
                    soundInstancePlayerKilled.Volume = num2;
                    soundInstancePlayerKilled.Pan = num3;
                    soundInstancePlayerKilled.Play();
                }
                else if (type == 6)
                {
                    soundInstanceGrass.Stop();
                    soundInstanceGrass = soundGrass.CreateInstance();
                    soundInstanceGrass.Volume = num2;
                    soundInstanceGrass.Pan = num3;
                    soundInstanceGrass.Pitch = rand.Next(-30, 0x1f) * 0.01f;
                    soundInstanceGrass.Play();
                }
                else if (type == 7)
                {
                    soundInstanceGrab.Stop();
                    soundInstanceGrab = soundGrab.CreateInstance();
                    soundInstanceGrab.Volume = num2;
                    soundInstanceGrab.Pan = num3;
                    soundInstanceGrab.Pitch = rand.Next(-10, 11) * 0.01f;
                    soundInstanceGrab.Play();
                }
                else if (type == 8)
                {
                    soundInstanceDoorOpen.Stop();
                    soundInstanceDoorOpen = soundDoorOpen.CreateInstance();
                    soundInstanceDoorOpen.Volume = num2;
                    soundInstanceDoorOpen.Pan = num3;
                    soundInstanceDoorOpen.Pitch = rand.Next(-20, 0x15) * 0.01f;
                    soundInstanceDoorOpen.Play();
                }
                else if (type == 9)
                {
                    soundInstanceDoorClosed.Stop();
                    soundInstanceDoorClosed = soundDoorClosed.CreateInstance();
                    soundInstanceDoorClosed.Volume = num2;
                    soundInstanceDoorClosed.Pan = num3;
                    soundInstanceDoorOpen.Pitch = rand.Next(-20, 0x15) * 0.01f;
                    soundInstanceDoorClosed.Play();
                }
                else if (type == 10)
                {
                    soundInstanceMenuOpen.Stop();
                    soundInstanceMenuOpen = soundMenuOpen.CreateInstance();
                    soundInstanceMenuOpen.Volume = num2;
                    soundInstanceMenuOpen.Pan = num3;
                    soundInstanceMenuOpen.Play();
                }
                else if (type == 11)
                {
                    soundInstanceMenuClose.Stop();
                    soundInstanceMenuClose = soundMenuClose.CreateInstance();
                    soundInstanceMenuClose.Volume = num2;
                    soundInstanceMenuClose.Pan = num3;
                    soundInstanceMenuClose.Play();
                }
                else if (type == 12)
                {
                    soundInstanceMenuTick.Stop();
                    soundInstanceMenuTick = soundMenuTick.CreateInstance();
                    soundInstanceMenuTick.Volume = num2;
                    soundInstanceMenuTick.Pan = num3;
                    soundInstanceMenuTick.Play();
                }
                else if (type == 13)
                {
                    soundInstanceShatter.Stop();
                    soundInstanceShatter = soundShatter.CreateInstance();
                    soundInstanceShatter.Volume = num2;
                    soundInstanceShatter.Pan = num3;
                    soundInstanceShatter.Play();
                }
                else if (type == 14)
                {
                    int num10 = rand.Next(3);
                    soundInstanceZombie[num10] = soundZombie[num10].CreateInstance();
                    soundInstanceZombie[num10].Volume = num2 * 0.4f;
                    soundInstanceZombie[num10].Pan = num3;
                    soundInstanceZombie[num10].Play();
                }
                else if (type == 15)
                {
                    if (soundInstanceRoar[index].State == SoundState.Stopped)
                    {
                        soundInstanceRoar[index] = soundRoar[index].CreateInstance();
                        soundInstanceRoar[index].Volume = num2;
                        soundInstanceRoar[index].Pan = num3;
                        soundInstanceRoar[index].Play();
                    }
                }
                else if (type == 0x10)
                {
                    soundInstanceDoubleJump.Stop();
                    soundInstanceDoubleJump = soundDoubleJump.CreateInstance();
                    soundInstanceDoubleJump.Volume = num2;
                    soundInstanceDoubleJump.Pan = num3;
                    soundInstanceDoubleJump.Pitch = rand.Next(-10, 11) * 0.01f;
                    soundInstanceDoubleJump.Play();
                }
                else if (type == 0x11)
                {
                    soundInstanceRun.Stop();
                    soundInstanceRun = soundRun.CreateInstance();
                    soundInstanceRun.Volume = num2;
                    soundInstanceRun.Pan = num3;
                    soundInstanceRun.Pitch = rand.Next(-10, 11) * 0.01f;
                    soundInstanceRun.Play();
                }
                else if (type == 0x12)
                {
                    soundInstanceCoins = soundCoins.CreateInstance();
                    soundInstanceCoins.Volume = num2;
                    soundInstanceCoins.Pan = num3;
                    soundInstanceCoins.Play();
                }
                else if (type == 0x13)
                {
                    if (soundInstanceSplash[index].State == SoundState.Stopped)
                    {
                        soundInstanceSplash[index] = soundSplash[index].CreateInstance();
                        soundInstanceSplash[index].Volume = num2;
                        soundInstanceSplash[index].Pan = num3;
                        soundInstanceSplash[index].Pitch = rand.Next(-10, 11) * 0.01f;
                        soundInstanceSplash[index].Play();
                    }
                }
                else if (type == 20)
                {
                    int num11 = rand.Next(3);
                    soundInstanceFemaleHit[num11].Stop();
                    soundInstanceFemaleHit[num11] = soundFemaleHit[num11].CreateInstance();
                    soundInstanceFemaleHit[num11].Volume = num2;
                    soundInstanceFemaleHit[num11].Pan = num3;
                    soundInstanceFemaleHit[num11].Play();
                }
                else if (type == 0x15)
                {
                    int num12 = rand.Next(3);
                    soundInstanceTink[num12].Stop();
                    soundInstanceTink[num12] = soundTink[num12].CreateInstance();
                    soundInstanceTink[num12].Volume = num2;
                    soundInstanceTink[num12].Pan = num3;
                    soundInstanceTink[num12].Play();
                }
                else if (type == 0x16)
                {
                    soundInstanceUnlock.Stop();
                    soundInstanceUnlock = soundUnlock.CreateInstance();
                    soundInstanceUnlock.Volume = num2;
                    soundInstanceUnlock.Pan = num3;
                    soundInstanceUnlock.Play();
                }
                else if (type == 0x17)
                {
                    soundInstanceDrown.Stop();
                    soundInstanceDrown = soundDrown.CreateInstance();
                    soundInstanceDrown.Volume = num2;
                    soundInstanceDrown.Pan = num3;
                    soundInstanceDrown.Play();
                }
                else if (type == 0x18)
                {
                    soundInstanceChat = soundChat.CreateInstance();
                    soundInstanceChat.Volume = num2;
                    soundInstanceChat.Pan = num3;
                    soundInstanceChat.Play();
                }
                else if (type == 0x19)
                {
                    soundInstanceMaxMana = soundMaxMana.CreateInstance();
                    soundInstanceMaxMana.Volume = num2;
                    soundInstanceMaxMana.Pan = num3;
                    soundInstanceMaxMana.Play();
                }
            }
            catch
            {
            }
        }

        protected void QuitGame()
        {
            Steam.Kill();
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

        protected void SaveSettings()
        {
            Directory.CreateDirectory(SavePath);
            try
            {
                File.SetAttributes(SavePath + @"\config.dat", FileAttributes.Normal);
            }
            catch
            {
            }
            try
            {
                using (FileStream stream = new FileStream(SavePath + @"\config.dat", FileMode.Create))
                {
                    using (BinaryWriter writer = new BinaryWriter(stream))
                    {
                        writer.Write(curRelease);
                        writer.Write(this.graphics.IsFullScreen);
                        writer.Write(mouseColor.R);
                        writer.Write(mouseColor.G);
                        writer.Write(mouseColor.B);
                        writer.Write(soundVolume);
                        writer.Write(musicVolume);
                        writer.Write(cUp);
                        writer.Write(cDown);
                        writer.Write(cLeft);
                        writer.Write(cRight);
                        writer.Write(cJump);
                        writer.Write(cThrowItem);
                        writer.Write(cInv);
                        writer.Write(cHeal);
                        writer.Write(cMana);
                        writer.Write(cBuff);
                        writer.Write(cHook);
                        writer.Write(caveParrallax);
                        writer.Write(fixedTiming);
                        writer.Write(this.graphics.PreferredBackBufferWidth);
                        writer.Write(this.graphics.PreferredBackBufferHeight);
                        writer.Write(autoSave);
                        writer.Write(autoPause);
                        writer.Write(showItemText);
                        writer.Close();
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
                string str = Console.ReadLine();
                string str2 = str;
                str = str.ToLower();
                try
                {
                    switch (str)
                    {
                        case "help":
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
                            continue;
                        }
                        case "settle":
                        {
                            if (!Liquid.panicMode)
                            {
                                Liquid.StartPanic();
                            }
                            else
                            {
                                Console.WriteLine("Water is already settling");
                            }
                            continue;
                        }
                        case "dawn":
                        {
                            dayTime = true;
                            Main.time = 0.0;
                            NetMessage.SendData(7, -1, -1, "", 0, 0f, 0f, 0f, 0);
                            continue;
                        }
                        case "dusk":
                        {
                            dayTime = false;
                            Main.time = 0.0;
                            NetMessage.SendData(7, -1, -1, "", 0, 0f, 0f, 0f, 0);
                            continue;
                        }
                        case "noon":
                        {
                            dayTime = true;
                            Main.time = 27000.0;
                            NetMessage.SendData(7, -1, -1, "", 0, 0f, 0f, 0f, 0);
                            continue;
                        }
                        case "midnight":
                        {
                            dayTime = false;
                            Main.time = 16200.0;
                            NetMessage.SendData(7, -1, -1, "", 0, 0f, 0f, 0f, 0);
                            continue;
                        }
                        case "exit-nosave":
                        {
                            Netplay.disconnect = true;
                            continue;
                        }
                        case "exit":
                        {
                            WorldGen.saveWorld(false);
                            Netplay.disconnect = true;
                            continue;
                        }
                        case "save":
                        {
                            WorldGen.saveWorld(false);
                            continue;
                        }
                        case "time":
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
                            continue;
                        }
                        case "maxplayers":
                        {
                            Console.WriteLine("Player limit: " + maxNetPlayers);
                            continue;
                        }
                        case "port":
                        {
                            Console.WriteLine("Port: " + Netplay.serverPort);
                            continue;
                        }
                        case "version":
                        {
                            Console.WriteLine("Terraria Server " + versionNumber);
                            continue;
                        }
                        case "clear":
                        {
                            try
                            {
                                Console.Clear();
                            }
                            catch
                            {
                            }
                            continue;
                        }
                        case "playing":
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
                            continue;
                        }
                        case "":
                        {
                            continue;
                        }
                        case "motd":
                        {
                            if (motd == "")
                            {
                                Console.WriteLine("Welcome to " + worldName + "!");
                            }
                            else
                            {
                                Console.WriteLine("MOTD: " + motd);
                            }
                            continue;
                        }
                    }
                    if ((str.Length >= 5) && (str.Substring(0, 5) == "motd "))
                    {
                        motd = str2.Substring(5);
                    }
                    else if ((str.Length == 8) && (str.Substring(0, 8) == "password"))
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
                    else if ((str.Length >= 9) && (str.Substring(0, 9) == "password "))
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
                    else if (str == "say")
                    {
                        Console.WriteLine("Usage: say <words>");
                    }
                    else if ((str.Length >= 4) && (str.Substring(0, 4) == "say "))
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
                    else if ((str.Length == 4) && (str.Substring(0, 4) == "kick"))
                    {
                        Console.WriteLine("Usage: kick <player>");
                    }
                    else if ((str.Length >= 5) && (str.Substring(0, 5) == "kick "))
                    {
                        string str8 = str.Substring(5).ToLower();
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
                    else if ((str.Length == 3) && (str.Substring(0, 3) == "ban"))
                    {
                        Console.WriteLine("Usage: ban <player>");
                    }
                    else if ((str.Length >= 4) && (str.Substring(0, 4) == "ban "))
                    {
                        string str9 = str.Substring(4).ToLower();
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
                    continue;
                }
                catch
                {
                    Console.WriteLine("Invalid command.");
                    continue;
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

        protected override void UnloadContent()
        {
        }

        protected override void Update(GameTime gameTime)
        {
            if (!dedServ)
            {
                if (fixedTiming)
                {
                    if (base.IsActive)
                    {
                        base.IsFixedTimeStep = false;
                        this.graphics.SynchronizeWithVerticalRetrace = true;
                    }
                    else
                    {
                        base.IsFixedTimeStep = true;
                    }
                }
                else
                {
                    base.IsFixedTimeStep = true;
                }
                this.UpdateMusic();
                if (showSplash)
                {
                    return;
                }
                if (!gameMenu && (Main.netMode == 1))
                {
                    if (!saveTime.IsRunning)
                    {
                        saveTime.Start();
                    }
                    if (saveTime.ElapsedMilliseconds > 0x493e0)
                    {
                        saveTime.Reset();
                        WorldGen.saveToonWhilePlaying();
                    }
                }
                else if (!gameMenu && autoSave)
                {
                    if (!saveTime.IsRunning)
                    {
                        saveTime.Start();
                    }
                    if (saveTime.ElapsedMilliseconds > 0x927c0)
                    {
                        saveTime.Reset();
                        WorldGen.saveToonWhilePlaying();
                        WorldGen.saveAndPlay();
                    }
                }
                else if (saveTime.IsRunning)
                {
                    saveTime.Stop();
                }
                if (teamCooldown > 0)
                {
                    teamCooldown--;
                }
                updateTime++;
                if (updateTime >= 60)
                {
                    frameRate = drawTime;
                    updateTime = 0;
                    drawTime = 0;
                    if (frameRate == 60)
                    {
                        Lighting.lightPasses = 2;
                        Lighting.lightSkip = 2;
                        cloudLimit = 100;
                        Gore.goreTime = 0x4b0;
                        numDust = 0x3e8;
                    }
                    else if (frameRate >= 0x3a)
                    {
                        Lighting.lightPasses = 2;
                        Lighting.lightSkip = 2;
                        cloudLimit = 100;
                        Gore.goreTime = 600;
                        numDust = 0x3e8;
                    }
                    else if (frameRate >= 0x2b)
                    {
                        Lighting.lightPasses = 2;
                        Lighting.lightSkip = 3;
                        cloudLimit = 0x4b;
                        Gore.goreTime = 300;
                        numDust = 700;
                    }
                    else if (frameRate >= 0x1c)
                    {
                        if (!gameMenu)
                        {
                            Liquid.maxLiquid = 0xbb8;
                            Liquid.cycles = 6;
                        }
                        Lighting.lightPasses = 2;
                        Lighting.lightSkip = 4;
                        cloudLimit = 50;
                        Gore.goreTime = 180;
                        numDust = 500;
                    }
                    else
                    {
                        Lighting.lightPasses = 2;
                        Lighting.lightSkip = 5;
                        cloudLimit = 0;
                        Gore.goreTime = 0;
                        numDust = 200;
                    }
                    if (Liquid.quickSettle)
                    {
                        Liquid.maxLiquid = Liquid.resLiquid;
                        Liquid.cycles = 1;
                    }
                    else if (frameRate == 60)
                    {
                        Liquid.maxLiquid = 0x1388;
                        Liquid.cycles = 7;
                    }
                    else if (frameRate >= 0x3a)
                    {
                        Liquid.maxLiquid = 0x1388;
                        Liquid.cycles = 12;
                    }
                    else if (frameRate >= 0x2b)
                    {
                        Liquid.maxLiquid = 0xfa0;
                        Liquid.cycles = 13;
                    }
                    else if (frameRate >= 0x1c)
                    {
                        Liquid.maxLiquid = 0xdac;
                        Liquid.cycles = 15;
                    }
                    else
                    {
                        Liquid.maxLiquid = 0xbb8;
                        Liquid.cycles = 0x11;
                    }
                    if (Main.netMode == 2)
                    {
                        cloudLimit = 0;
                    }
                }
                if (!base.IsActive)
                {
                    hasFocus = false;
                }
                else
                {
                    hasFocus = true;
                }
                if (!base.IsActive && (Main.netMode == 0))
                {
                    base.IsMouseVisible = true;
                    if ((Main.netMode != 2) && (myPlayer >= 0))
                    {
                        player[myPlayer].delayUseItem = true;
                    }
                    mouseLeftRelease = false;
                    mouseRightRelease = false;
                    if (gameMenu)
                    {
                        UpdateMenu();
                    }
                    gamePaused = true;
                    return;
                }
                base.IsMouseVisible = false;
                if ((keyState.IsKeyDown(Keys.F10) && !chatMode) && !editSign)
                {
                    if (frameRelease)
                    {
                        PlaySound(12, -1, -1, 1);
                        if (showFrameRate)
                        {
                            showFrameRate = false;
                        }
                        else
                        {
                            showFrameRate = true;
                        }
                    }
                    frameRelease = false;
                }
                else
                {
                    frameRelease = true;
                }
                if (keyState.IsKeyDown(Keys.F11))
                {
                    if (releaseUI)
                    {
                        if (hideUI)
                        {
                            hideUI = false;
                        }
                        else
                        {
                            hideUI = true;
                        }
                    }
                    releaseUI = false;
                }
                else
                {
                    releaseUI = true;
                }
                if ((keyState.IsKeyDown(Keys.LeftAlt) || keyState.IsKeyDown(Keys.RightAlt)) && keyState.IsKeyDown(Keys.Enter))
                {
                    if (this.toggleFullscreen)
                    {
                        this.graphics.ToggleFullScreen();
                        chatRelease = false;
                    }
                    this.toggleFullscreen = false;
                }
                else
                {
                    this.toggleFullscreen = true;
                }
                oldMouseState = mouseState;
                mouseState = Mouse.GetState();
                keyState = Keyboard.GetState();
                if (editSign)
                {
                    chatMode = false;
                }
                if (chatMode)
                {
                    if (keyState.IsKeyDown(Keys.Escape))
                    {
                        chatMode = false;
                    }
                    string chatText = Main.chatText;
                    Main.chatText = GetInputText(Main.chatText);
                    while (fontMouseText.MeasureString(Main.chatText).X > 470f)
                    {
                        Main.chatText = Main.chatText.Substring(0, Main.chatText.Length - 1);
                    }
                    if (chatText != Main.chatText)
                    {
                        PlaySound(12, -1, -1, 1);
                    }
                    if (inputTextEnter && chatRelease)
                    {
                        if (Main.chatText != "")
                        {
                            NetMessage.SendData(0x19, -1, -1, Main.chatText, myPlayer, 0f, 0f, 0f, 0);
                        }
                        Main.chatText = "";
                        chatMode = false;
                        chatRelease = false;
                        player[myPlayer].releaseHook = false;
                        player[myPlayer].releaseThrow = false;
                        PlaySound(11, -1, -1, 1);
                    }
                }
                if ((keyState.IsKeyDown(Keys.Enter) && (Main.netMode == 1)) && (!keyState.IsKeyDown(Keys.LeftAlt) && !keyState.IsKeyDown(Keys.RightAlt)))
                {
                    if ((chatRelease && !chatMode) && (!editSign && !keyState.IsKeyDown(Keys.Escape)))
                    {
                        PlaySound(10, -1, -1, 1);
                        chatMode = true;
                        Main.chatText = "";
                    }
                    chatRelease = false;
                }
                else
                {
                    chatRelease = true;
                }
                if (gameMenu)
                {
                    UpdateMenu();
                    if (Main.netMode != 2)
                    {
                        return;
                    }
                    gamePaused = false;
                }
            }
            if (Main.netMode == 1)
            {
                for (int i = 0; i < 0x2c; i++)
                {
                    if (player[myPlayer].inventory[i].IsNotTheSameAs(clientPlayer.inventory[i]))
                    {
                        NetMessage.SendData(5, -1, -1, player[myPlayer].inventory[i].name, myPlayer, (float) i, 0f, 0f, 0);
                    }
                }
                if (player[myPlayer].armor[0].IsNotTheSameAs(clientPlayer.armor[0]))
                {
                    NetMessage.SendData(5, -1, -1, player[myPlayer].armor[0].name, myPlayer, 44f, 0f, 0f, 0);
                }
                if (player[myPlayer].armor[1].IsNotTheSameAs(clientPlayer.armor[1]))
                {
                    NetMessage.SendData(5, -1, -1, player[myPlayer].armor[1].name, myPlayer, 45f, 0f, 0f, 0);
                }
                if (player[myPlayer].armor[2].IsNotTheSameAs(clientPlayer.armor[2]))
                {
                    NetMessage.SendData(5, -1, -1, player[myPlayer].armor[2].name, myPlayer, 46f, 0f, 0f, 0);
                }
                if (player[myPlayer].armor[3].IsNotTheSameAs(clientPlayer.armor[3]))
                {
                    NetMessage.SendData(5, -1, -1, player[myPlayer].armor[3].name, myPlayer, 47f, 0f, 0f, 0);
                }
                if (player[myPlayer].armor[4].IsNotTheSameAs(clientPlayer.armor[4]))
                {
                    NetMessage.SendData(5, -1, -1, player[myPlayer].armor[4].name, myPlayer, 48f, 0f, 0f, 0);
                }
                if (player[myPlayer].armor[5].IsNotTheSameAs(clientPlayer.armor[5]))
                {
                    NetMessage.SendData(5, -1, -1, player[myPlayer].armor[5].name, myPlayer, 49f, 0f, 0f, 0);
                }
                if (player[myPlayer].armor[6].IsNotTheSameAs(clientPlayer.armor[6]))
                {
                    NetMessage.SendData(5, -1, -1, player[myPlayer].armor[6].name, myPlayer, 50f, 0f, 0f, 0);
                }
                if (player[myPlayer].armor[7].IsNotTheSameAs(clientPlayer.armor[7]))
                {
                    NetMessage.SendData(5, -1, -1, player[myPlayer].armor[7].name, myPlayer, 51f, 0f, 0f, 0);
                }
                if (player[myPlayer].armor[8].IsNotTheSameAs(clientPlayer.armor[8]))
                {
                    NetMessage.SendData(5, -1, -1, player[myPlayer].armor[8].name, myPlayer, 52f, 0f, 0f, 0);
                }
                if (player[myPlayer].armor[9].IsNotTheSameAs(clientPlayer.armor[9]))
                {
                    NetMessage.SendData(5, -1, -1, player[myPlayer].armor[9].name, myPlayer, 53f, 0f, 0f, 0);
                }
                if (player[myPlayer].armor[10].IsNotTheSameAs(clientPlayer.armor[10]))
                {
                    NetMessage.SendData(5, -1, -1, player[myPlayer].armor[10].name, myPlayer, 54f, 0f, 0f, 0);
                }
                if (player[myPlayer].chest != clientPlayer.chest)
                {
                    NetMessage.SendData(0x21, -1, -1, "", player[myPlayer].chest, 0f, 0f, 0f, 0);
                }
                if (player[myPlayer].talkNPC != clientPlayer.talkNPC)
                {
                    NetMessage.SendData(40, -1, -1, "", myPlayer, 0f, 0f, 0f, 0);
                }
                if (player[myPlayer].zoneEvil != clientPlayer.zoneEvil)
                {
                    NetMessage.SendData(0x24, -1, -1, "", myPlayer, 0f, 0f, 0f, 0);
                }
                if (player[myPlayer].zoneMeteor != clientPlayer.zoneMeteor)
                {
                    NetMessage.SendData(0x24, -1, -1, "", myPlayer, 0f, 0f, 0f, 0);
                }
                if (player[myPlayer].zoneDungeon != clientPlayer.zoneDungeon)
                {
                    NetMessage.SendData(0x24, -1, -1, "", myPlayer, 0f, 0f, 0f, 0);
                }
                if (player[myPlayer].zoneJungle != clientPlayer.zoneJungle)
                {
                    NetMessage.SendData(0x24, -1, -1, "", myPlayer, 0f, 0f, 0f, 0);
                }
                bool flag = false;
                for (int j = 0; j < 10; j++)
                {
                    if (player[myPlayer].buffType[j] != clientPlayer.buffType[j])
                    {
                        flag = true;
                    }
                }
                if (flag)
                {
                    NetMessage.SendData(50, -1, -1, "", myPlayer, 0f, 0f, 0f, 0);
                    NetMessage.SendData(13, -1, -1, "", myPlayer, 0f, 0f, 0f, 0);
                }
            }
            if (Main.netMode == 1)
            {
                clientPlayer = (Player) player[myPlayer].clientClone();
            }
            if (((Main.netMode == 0) && ((playerInventory || (npcChatText != "")) || (player[myPlayer].sign >= 0))) && autoPause)
            {
                Keys[] pressedKeys = keyState.GetPressedKeys();
                player[myPlayer].controlInv = false;
                for (int k = 0; k < pressedKeys.Length; k++)
                {
                    if ((pressedKeys[k]).ToString() == cInv)
                    {
                        player[myPlayer].controlInv = true;
                    }
                }
                if (player[myPlayer].controlInv)
                {
                    if (player[myPlayer].releaseInventory)
                    {
                        player[myPlayer].toggleInv();
                    }
                    player[myPlayer].releaseInventory = false;
                }
                else
                {
                    player[myPlayer].releaseInventory = true;
                }
                if (playerInventory)
                {
                    int num4 = (mouseState.ScrollWheelValue - oldMouseState.ScrollWheelValue) / 120;
                    focusRecipe += num4;
                    if (focusRecipe > (numAvailableRecipes - 1))
                    {
                        focusRecipe = numAvailableRecipes - 1;
                    }
                    if (focusRecipe < 0)
                    {
                        focusRecipe = 0;
                    }
                    player[myPlayer].dropItemCheck();
                }
                player[myPlayer].head = player[myPlayer].armor[0].headSlot;
                player[myPlayer].body = player[myPlayer].armor[1].bodySlot;
                player[myPlayer].legs = player[myPlayer].armor[2].legSlot;
                if (!player[myPlayer].hostile)
                {
                    if (player[myPlayer].armor[8].headSlot >= 0)
                    {
                        player[myPlayer].head = player[myPlayer].armor[8].headSlot;
                    }
                    if (player[myPlayer].armor[9].bodySlot >= 0)
                    {
                        player[myPlayer].body = player[myPlayer].armor[9].bodySlot;
                    }
                    if (player[myPlayer].armor[10].legSlot >= 0)
                    {
                        player[myPlayer].legs = player[myPlayer].armor[10].legSlot;
                    }
                }
                if (editSign)
                {
                    if (player[myPlayer].sign == -1)
                    {
                        editSign = false;
                    }
                    else
                    {
                        npcChatText = GetInputText(npcChatText);
                        if (inputTextEnter)
                        {
                            byte[] bytes = new byte[] { 10 };
                            npcChatText = npcChatText + Encoding.ASCII.GetString(bytes);
                        }
                    }
                }
                gamePaused = true;
            }
            else
            {
                gamePaused = false;
                if ((!dedServ && (screenPosition.Y < ((worldSurface * 16.0) + 16.0))) && ((((0xff - tileColor.R) - 100) > 0) && (Main.netMode != 2)))
                {
                    Star.UpdateStars();
                    Cloud.UpdateClouds();
                }
                for (int m = 0; m < 0xff; m++)
                {
                    if (ignoreErrors)
                    {
                        try
                        {
                            player[m].UpdatePlayer(m);
                        }
                        catch
                        {
                        }
                    }
                    else
                    {
                        player[m].UpdatePlayer(m);
                    }
                }
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
                        Dust.UpdateDust();
                    }
                    catch
                    {
                        for (int num11 = 0; num11 < 0x3e8; num11++)
                        {
                            dust[num11] = new Dust();
                        }
                    }
                }
                else
                {
                    Dust.UpdateDust();
                }
                if (Main.netMode != 2)
                {
                    CombatText.UpdateCombatText();
                    ItemText.UpdateItemText();
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
                        if (Main.netMode == 1)
                        {
                            UpdateClient();
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
                    if (Main.netMode == 1)
                    {
                        UpdateClient();
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

        private static void UpdateClient()
        {
            if (myPlayer == 0xff)
            {
                Netplay.disconnect = true;
            }
            netPlayCounter++;
            if (netPlayCounter > 0xe10)
            {
                netPlayCounter = 0;
            }
            if (Math.IEEERemainder((double) netPlayCounter, 300.0) == 0.0)
            {
                NetMessage.SendData(13, -1, -1, "", myPlayer, 0f, 0f, 0f, 0);
                NetMessage.SendData(0x24, -1, -1, "", myPlayer, 0f, 0f, 0f, 0);
            }
            if (Math.IEEERemainder((double) netPlayCounter, 600.0) == 0.0)
            {
                NetMessage.SendData(0x10, -1, -1, "", myPlayer, 0f, 0f, 0f, 0);
                NetMessage.SendData(40, -1, -1, "", myPlayer, 0f, 0f, 0f, 0);
            }
            if (Netplay.clientSock.active)
            {
                Netplay.clientSock.timeOut++;
                if (!stopTimeOuts && (Netplay.clientSock.timeOut > (60 * timeOut)))
                {
                    statusText = "Connection timed out";
                    Netplay.disconnect = true;
                }
            }
            for (int i = 0; i < 200; i++)
            {
                if (item[i].active && (item[i].owner == myPlayer))
                {
                    item[i].FindOwner(i);
                }
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
            exitScale = 0.8f;
            if (netMode == 0)
            {
                if (!grabSky)
                {
                    time += 86.4;
                    if (dayTime)
                    {
                        if (time > 54000.0)
                        {
                            time = 0.0;
                            dayTime = false;
                        }
                    }
                    else if (time > 32400.0)
                    {
                        bloodMoon = false;
                        time = 0.0;
                        dayTime = true;
                        moonPhase++;
                        if (moonPhase >= 8)
                        {
                            moonPhase = 0;
                        }
                    }
                }
            }
            else if (netMode == 1)
            {
                UpdateTime();
            }
        }

        protected void UpdateMusic()
        {
            try
            {
                if (!dedServ)
                {
                    if (this.curMusic > 0)
                    {
                        if (!base.IsActive)
                        {
                            if (!music[this.curMusic].IsPaused && music[this.curMusic].IsPlaying)
                            {
                                try
                                {
                                    music[this.curMusic].Pause();
                                }
                                catch
                                {
                                }
                            }
                            return;
                        }
                        if (music[this.curMusic].IsPaused)
                        {
                            music[this.curMusic].Resume();
                        }
                    }
                    bool flag = false;
                    Rectangle rectangle = new Rectangle((int) screenPosition.X, (int) screenPosition.Y, screenWidth, screenHeight);
                    int num = 0x1388;
                    for (int i = 0; i < 0x3e8; i++)
                    {
                        if (npc[i].active && (((npc[i].boss || (npc[i].type == 13)) || ((npc[i].type == 14) || (npc[i].type == 15))) || (((npc[i].type == 0x1a) || (npc[i].type == 0x1b)) || ((npc[i].type == 0x1c) || (npc[i].type == 0x1d)))))
                        {
                            Rectangle rectangle2 = new Rectangle((((int) npc[i].position.X) + (npc[i].width / 2)) - num, (((int) npc[i].position.Y) + (npc[i].height / 2)) - num, num * 2, num * 2);
                            if (rectangle.Intersects(rectangle2))
                            {
                                flag = true;
                                break;
                            }
                        }
                    }
                    if (musicVolume == 0f)
                    {
                        this.newMusic = 0;
                    }
                    else if (gameMenu)
                    {
                        if (netMode != 2)
                        {
                            this.newMusic = 6;
                        }
                        else
                        {
                            this.newMusic = 0;
                        }
                    }
                    else if (flag)
                    {
                        this.newMusic = 5;
                    }
                    else if (player[myPlayer].position.Y > ((maxTilesY - 200) * 0x10))
                    {
                        this.newMusic = 2;
                    }
                    else if (player[myPlayer].zoneEvil)
                    {
                        this.newMusic = 8;
                    }
                    else if (player[myPlayer].zoneMeteor || player[myPlayer].zoneDungeon)
                    {
                        this.newMusic = 2;
                    }
                    else if (player[myPlayer].zoneJungle)
                    {
                        this.newMusic = 7;
                    }
                    else if (player[myPlayer].position.Y > ((worldSurface * 16.0) + screenHeight))
                    {
                        this.newMusic = 4;
                    }
                    else if (dayTime)
                    {
                        this.newMusic = 1;
                    }
                    else if (!dayTime)
                    {
                        if (bloodMoon)
                        {
                            this.newMusic = 2;
                        }
                        else
                        {
                            this.newMusic = 3;
                        }
                    }
                    this.curMusic = this.newMusic;
                    for (int j = 1; j < 9; j++)
                    {
                        if (j == this.curMusic)
                        {
                            if (!music[j].IsPlaying)
                            {
                                music[j] = soundBank.GetCue("Music_" + j);
                                music[j].Play();
                                music[j].SetVariable("Volume", musicFade[j] * musicVolume);
                            }
                            else
                            {
                                musicFade[j] += 0.005f;
                                if (musicFade[j] > 1f)
                                {
                                    musicFade[j] = 1f;
                                }
                                music[j].SetVariable("Volume", musicFade[j] * musicVolume);
                            }
                        }
                        else if (music[j].IsPlaying)
                        {
                            if (musicFade[this.curMusic] > 0.25f)
                            {
                                musicFade[j] -= 0.005f;
                            }
                            else if (this.curMusic == 0)
                            {
                                musicFade[j] = 0f;
                            }
                            if (musicFade[j] <= 0f)
                            {
                                musicFade[j] -= 0f;
                                music[j].Stop(AudioStopOptions.Immediate);
                            }
                            else
                            {
                                music[j].SetVariable("Volume", musicFade[j] * musicVolume);
                            }
                        }
                        else
                        {
                            musicFade[j] = 0f;
                        }
                    }
                }
            }
            catch
            {
                musicVolume = 0f;
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
                    if (netMode == 0)
                    {
                        NewText("You feel an evil presence watching you...", 50, 0xff, 130);
                    }
                    else if (netMode == 2)
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
                    if (netMode == 0)
                    {
                        NewText("The Blood Moon is rising...", 50, 0xff, 130);
                    }
                    else if (netMode == 2)
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

