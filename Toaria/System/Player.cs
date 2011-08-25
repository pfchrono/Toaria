namespace Toaria
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Input;
    using System;
    using System.IO;
    using System.Runtime.InteropServices;
    using System.Security.Cryptography;
    using System.Text;

    public class Player
    {
        public int accDepthMeter;
        public bool accFlipper;
        public int accWatch;
        public bool active;
        public float activeNPCs;
        public bool[] adjTile = new bool[0x6b];
        public bool adjWater;
        public Item[] ammo = new Item[4];
        public bool ammoCost80;
        public bool archery;
        public Item[] armor = new Item[11];
        public int attackCD;
        public Item[] bank = new Item[Chest.maxItems];
        public Item[] bank2 = new Item[Chest.maxItems];
        public bool blind;
        public int body = -1;
        public Rectangle bodyFrame;
        public double bodyFrameCounter;
        public Vector2 bodyPosition;
        public float bodyRotation;
        public Vector2 bodyVelocity;
        public bool boneArmor;
        public int breath = 200;
        public int breathCD;
        public int breathMax = 200;
        public int[] buffTime = new int[10];
        public int[] buffType = new int[10];
        public bool canRocket;
        public int changeItem = -1;
        public bool channel;
        public int chatShowTime;
        public string chatText = "";
        public int chest = -1;
        public int chestX;
        public int chestY;
        public bool controlDown;
        public bool controlHook;
        public bool controlInv;
        public bool controlJump;
        public bool controlLeft;
        public bool controlRight;
        public bool controlThrow;
        public bool controlUp;
        public bool controlUseItem;
        public bool controlUseTile;
        public bool dead;
        public static bool deadForGood = false;
        public bool delayUseItem;
        public bool detectCreature;
        public byte difficulty;
        public int direction = 1;
        public bool doubleJump;
        public bool enemySpawns;
        public Color eyeColor = new Color(0x69, 90, 0x4b);
        public int fallStart;
        public bool findTreasure;
        public bool fireWalk;
        public bool ghost;
        public int ghostFrame;
        public int ghostFrameCounter;
        public bool gills;
        public int grapCount;
        public int[] grappling = new int[20];
        public bool gravControl;
        public float gravDir = 1f;
        public int hair;
        public Color hairColor = new Color(0xd7, 90, 0x37);
        public Rectangle hairFrame;
        public bool hbLocked;
        public int head = -1;
        public Rectangle headFrame;
        public double headFrameCounter;
        public Vector2 headPosition;
        public float headRotation;
        public Vector2 headVelocity;
        public int height = 0x2a;
        public int heldProj = -1;
        public int hitTile;
        public int hitTileX;
        public int hitTileY;
        public bool hostile;
        public bool immune;
        public int immuneAlpha;
        public int immuneAlphaDirection;
        public int immuneTime;
        public Item[] inventory = new Item[0x2c];
        public bool invis;
        public int itemAnimation;
        public int itemAnimationMax;
        private static int itemGrabRange = 0x26;
        private static float itemGrabSpeed = 0.45f;
        private static float itemGrabSpeedMax = 4f;
        public int itemHeight;
        public Vector2 itemLocation;
        public float itemRotation;
        public int itemTime;
        public int itemWidth;
        public int jump;
        public bool jumpAgain;
        public bool jumpBoost;
        private static int jumpHeight = 15;
        private static float jumpSpeed = 5.01f;
        public bool killGuide;
        public bool lavaImmune;
        public bool lavaWet;
        public Rectangle legFrame;
        public double legFrameCounter;
        public Vector2 legPosition;
        public float legRotation;
        public int legs = -1;
        public Vector2 legVelocity;
        public int lifeRegen;
        public int lifeRegenCount;
        public int lifeRegenTime;
        public bool lightOrb;
        public int magicCrit = 4;
        public float magicDamage = 1f;
        public bool male = true;
        public float manaCost = 1f;
        public int manaRegen;
        public bool manaRegenBuff;
        public int manaRegenCount;
        public int manaRegenDelay;
        public const int maxBuffs = 10;
        private float maxRegenDelay;
        public int meleeCrit = 4;
        public float meleeDamage = 1f;
        public float meleeSpeed = 1f;
        public bool mouseInterface;
        public float moveSpeed = 1f;
        public string name = "";
        public static int nameLen = 20;
        public bool nightVision;
        public bool noFallDmg;
        public bool noItems;
        public bool noKnockback;
        public bool[] oldAdjTile = new bool[0x6b];
        public bool oldAdjWater;
        public Vector2 oldVelocity;
        public bool onFire;
        public Color pantsColor = new Color(0xff, 230, 0xaf);
        public bool poisoned;
        public Vector2 position;
        public int potionDelay;
        public bool pvpDeath;
        public int rangedCrit = 4;
        public float rangedDamage = 1f;
        public bool releaseHook;
        public bool releaseInventory;
        public bool releaseJump;
        public bool releaseQuickHeal;
        public bool releaseQuickMana;
        public bool releaseThrow;
        public bool releaseUseItem;
        public bool releaseUseTile;
        public int respawnTimer;
        public bool rocketBoots;
        public int rocketDelay;
        public int rocketDelay2;
        public bool rocketFrame;
        public bool rocketRelease;
        public int rocketTime;
        public int rocketTimeMax = 7;
        public int runSoundDelay;
        public int selectedItem;
        public string setBonus = "";
        public float shadow;
        public int shadowCount;
        public Vector2[] shadowPos = new Vector2[3];
        public Color shirtColor = new Color(0xaf, 0xa5, 140);
        public Color shoeColor = new Color(160, 0x69, 60);
        public bool showItemIcon;
        public int showItemIcon2;
        public int sign = -1;
        public Color skinColor = new Color(0xff, 0x7d, 90);
        public int slowCount;
        public bool slowFall;
        public bool socialShadow;
        public bool spaceGun;
        public bool spawnMax;
        public int SpawnX = -1;
        public int SpawnY = -1;
        public int[] spI = new int[200];
        public string[] spN = new string[200];
        public int[] spX = new int[200];
        public int[] spY = new int[200];
        public int statAttack;
        public int statDefense;
        public int statLife = 100;
        public int statLifeMax = 100;
        public int statMana;
        public int statManaMax;
        public int statManaMax2;
        public int step = -1;
        public int stickyBreak;
        public int swimTime;
        public int talkNPC = -1;
        public int team;
        public bool thorns;
        public static int tileRangeX = 5;
        public static int tileRangeY = 4;
        private static int tileTargetX;
        private static int tileTargetY;
        public float townNPCs;
        public Color underShirtColor = new Color(160, 180, 0xd7);
        public Vector2 velocity;
        public bool waterWalk;
        public bool wet;
        public byte wetCount;
        public int whoAmi;
        public int width = 20;
        public bool zoneDungeon;
        public bool zoneEvil;
        public bool zoneJungle;
        public bool zoneMeteor;

        public Player()
        {
            for (int i = 0; i < 0x2c; i++)
            {
                if (i < 11)
                {
                    this.armor[i] = new Item();
                    this.armor[i].name = "";
                }
                this.inventory[i] = new Item();
                this.inventory[i].name = "";
            }
            for (int j = 0; j < Chest.maxItems; j++)
            {
                this.bank[j] = new Item();
                this.bank[j].name = "";
                this.bank2[j] = new Item();
                this.bank2[j].name = "";
            }
            for (int k = 0; k < 4; k++)
            {
                this.ammo[k] = new Item();
                this.ammo[k].name = "";
            }
            this.grappling[0] = -1;
            this.inventory[0].SetDefaults("Copper Shortsword");
            this.inventory[1].SetDefaults("Copper Pickaxe");
            this.inventory[2].SetDefaults("Copper Axe");
            for (int m = 0; m < 0x6b; m++)
            {
                this.adjTile[m] = false;
                this.oldAdjTile[m] = false;
            }
        }

        public void AddBuff(int type, int time, bool quiet = true)
        {
            if (!quiet && (Main.netMode == 1))
            {
                NetMessage.SendData(0x37, -1, -1, "", this.whoAmi, (float) type, (float) time, 0f, 0);
            }
            int index = -1;
            for (int i = 0; i < 10; i++)
            {
                if (this.buffType[i] == type)
                {
                    if (this.buffTime[i] < time)
                    {
                        this.buffTime[i] = time;
                    }
                    return;
                }
            }
            while (index == -1)
            {
                int b = -1;
                for (int j = 0; j < 10; j++)
                {
                    if (!Main.debuff[this.buffType[j]])
                    {
                        b = j;
                        break;
                    }
                }
                if (b == -1)
                {
                    return;
                }
                for (int k = b; k < 10; k++)
                {
                    if (this.buffType[k] == 0)
                    {
                        index = k;
                        break;
                    }
                }
                if (index == -1)
                {
                    this.DelBuff(b);
                }
            }
            this.buffType[index] = type;
            this.buffTime[index] = time;
        }

        public void AdjTiles()
        {
            int num = 4;
            int num2 = 3;
            for (int i = 0; i < 0x6b; i++)
            {
                this.oldAdjTile[i] = this.adjTile[i];
                this.adjTile[i] = false;
            }
            this.oldAdjWater = this.adjWater;
            this.adjWater = false;
            int num4 = (int) ((this.position.X + (this.width / 2)) / 16f);
            int num5 = (int) ((this.position.Y + this.height) / 16f);
            for (int j = num4 - num; j <= (num4 + num); j++)
            {
                for (int k = num5 - num2; k < (num5 + num2); k++)
                {
                    if (Main.tile[j, k].active)
                    {
                        this.adjTile[Main.tile[j, k].type] = true;
                        if (Main.tile[j, k].type == 0x4d)
                        {
                            this.adjTile[0x11] = true;
                        }
                    }
                    if ((Main.tile[j, k].liquid > 200) && !Main.tile[j, k].lava)
                    {
                        this.adjWater = true;
                    }
                }
            }
            if (Main.playerInventory)
            {
                bool flag = false;
                for (int m = 0; m < 0x6b; m++)
                {
                    if (this.oldAdjTile[m] != this.adjTile[m])
                    {
                        flag = true;
                        break;
                    }
                }
                if (this.adjWater != this.oldAdjWater)
                {
                    flag = true;
                }
                if (flag)
                {
                    Recipe.FindRecipes();
                }
            }
        }

        public bool BuyItem(int price)
        {
            if (price == 0)
            {
                return false;
            }
            int num = 0;
            int num2 = price;
            Item[] itemArray = new Item[0x2c];
            for (int i = 0; i < 0x2c; i++)
            {
                itemArray[i] = new Item();
                itemArray[i] = (Item) this.inventory[i].Clone();
                if (this.inventory[i].type == 0x47)
                {
                    num += this.inventory[i].stack;
                }
                if (this.inventory[i].type == 0x48)
                {
                    num += this.inventory[i].stack * 100;
                }
                if (this.inventory[i].type == 0x49)
                {
                    num += this.inventory[i].stack * 0x2710;
                }
                if (this.inventory[i].type == 0x4a)
                {
                    num += this.inventory[i].stack * 0xf4240;
                }
            }
            if (num < price)
            {
                return false;
            }
            num2 = price;
            while (num2 > 0)
            {
                if (num2 >= 0xf4240)
                {
                    for (int j = 0; j < 0x2c; j++)
                    {
                        if (this.inventory[j].type == 0x4a)
                        {
                            while ((this.inventory[j].stack > 0) && (num2 >= 0xf4240))
                            {
                                num2 -= 0xf4240;
                                Item item1 = this.inventory[j];
                                item1.stack--;
                                if (this.inventory[j].stack == 0)
                                {
                                    this.inventory[j].type = 0;
                                }
                            }
                        }
                    }
                }
                if (num2 >= 0x2710)
                {
                    for (int k = 0; k < 0x2c; k++)
                    {
                        if (this.inventory[k].type == 0x49)
                        {
                            while ((this.inventory[k].stack > 0) && (num2 >= 0x2710))
                            {
                                num2 -= 0x2710;
                                Item item2 = this.inventory[k];
                                item2.stack--;
                                if (this.inventory[k].stack == 0)
                                {
                                    this.inventory[k].type = 0;
                                }
                            }
                        }
                    }
                }
                if (num2 >= 100)
                {
                    for (int m = 0; m < 0x2c; m++)
                    {
                        if (this.inventory[m].type == 0x48)
                        {
                            while ((this.inventory[m].stack > 0) && (num2 >= 100))
                            {
                                num2 -= 100;
                                Item item3 = this.inventory[m];
                                item3.stack--;
                                if (this.inventory[m].stack == 0)
                                {
                                    this.inventory[m].type = 0;
                                }
                            }
                        }
                    }
                }
                if (num2 >= 1)
                {
                    for (int n = 0; n < 0x2c; n++)
                    {
                        if (this.inventory[n].type == 0x47)
                        {
                            while ((this.inventory[n].stack > 0) && (num2 >= 1))
                            {
                                num2--;
                                Item item4 = this.inventory[n];
                                item4.stack--;
                                if (this.inventory[n].stack == 0)
                                {
                                    this.inventory[n].type = 0;
                                }
                            }
                        }
                    }
                }
                if (num2 > 0)
                {
                    int index = -1;
                    for (int num9 = 0x2b; num9 >= 0; num9--)
                    {
                        if ((this.inventory[num9].type == 0) || (this.inventory[num9].stack == 0))
                        {
                            index = num9;
                            break;
                        }
                    }
                    if (index >= 0)
                    {
                        bool flag = true;
                        if (num2 >= 0x2710)
                        {
                            for (int num10 = 0; num10 < 0x2c; num10++)
                            {
                                if ((this.inventory[num10].type == 0x4a) && (this.inventory[num10].stack >= 1))
                                {
                                    Item item5 = this.inventory[num10];
                                    item5.stack--;
                                    if (this.inventory[num10].stack == 0)
                                    {
                                        this.inventory[num10].type = 0;
                                    }
                                    this.inventory[index].SetDefaults(0x49, false);
                                    this.inventory[index].stack = 100;
                                    flag = false;
                                    break;
                                }
                            }
                        }
                        else if (num2 >= 100)
                        {
                            for (int num11 = 0; num11 < 0x2c; num11++)
                            {
                                if ((this.inventory[num11].type == 0x49) && (this.inventory[num11].stack >= 1))
                                {
                                    Item item6 = this.inventory[num11];
                                    item6.stack--;
                                    if (this.inventory[num11].stack == 0)
                                    {
                                        this.inventory[num11].type = 0;
                                    }
                                    this.inventory[index].SetDefaults(0x48, false);
                                    this.inventory[index].stack = 100;
                                    flag = false;
                                    break;
                                }
                            }
                        }
                        else if (num2 >= 1)
                        {
                            for (int num12 = 0; num12 < 0x2c; num12++)
                            {
                                if ((this.inventory[num12].type == 0x48) && (this.inventory[num12].stack >= 1))
                                {
                                    Item item7 = this.inventory[num12];
                                    item7.stack--;
                                    if (this.inventory[num12].stack == 0)
                                    {
                                        this.inventory[num12].type = 0;
                                    }
                                    this.inventory[index].SetDefaults(0x47, false);
                                    this.inventory[index].stack = 100;
                                    flag = false;
                                    break;
                                }
                            }
                        }
                        if (!flag)
                        {
                            continue;
                        }
                        if (num2 < 0x2710)
                        {
                            for (int num13 = 0; num13 < 0x2c; num13++)
                            {
                                if ((this.inventory[num13].type == 0x49) && (this.inventory[num13].stack >= 1))
                                {
                                    Item item8 = this.inventory[num13];
                                    item8.stack--;
                                    if (this.inventory[num13].stack == 0)
                                    {
                                        this.inventory[num13].type = 0;
                                    }
                                    this.inventory[index].SetDefaults(0x48, false);
                                    this.inventory[index].stack = 100;
                                    flag = false;
                                    break;
                                }
                            }
                        }
                        if (flag && (num2 < 0xf4240))
                        {
                            for (int num14 = 0; num14 < 0x2c; num14++)
                            {
                                if ((this.inventory[num14].type == 0x4a) && (this.inventory[num14].stack >= 1))
                                {
                                    Item item9 = this.inventory[num14];
                                    item9.stack--;
                                    if (this.inventory[num14].stack == 0)
                                    {
                                        this.inventory[num14].type = 0;
                                    }
                                    this.inventory[index].SetDefaults(0x49, false);
                                    this.inventory[index].stack = 100;
                                    flag = false;
                                    break;
                                }
                            }
                        }
                        continue;
                    }
                    for (int num15 = 0; num15 < 0x2c; num15++)
                    {
                        this.inventory[num15] = (Item) itemArray[num15].Clone();
                    }
                    return false;
                }
            }
            return true;
        }

        public void ChangeSpawn(int x, int y)
        {
            for (int i = 0; i < 200; i++)
            {
                if (this.spN[i] == null)
                {
                    break;
                }
                if ((this.spN[i] == Main.worldName) && (this.spI[i] == Main.worldID))
                {
                    for (int k = i; k > 0; k--)
                    {
                        this.spN[k] = this.spN[k - 1];
                        this.spI[k] = this.spI[k - 1];
                        this.spX[k] = this.spX[k - 1];
                        this.spY[k] = this.spY[k - 1];
                    }
                    this.spN[0] = Main.worldName;
                    this.spI[0] = Main.worldID;
                    this.spX[0] = x;
                    this.spY[0] = y;
                    return;
                }
            }
            for (int j = 0xc7; j > 0; j--)
            {
                if (this.spN[j - 1] != null)
                {
                    this.spN[j] = this.spN[j - 1];
                    this.spI[j] = this.spI[j - 1];
                    this.spX[j] = this.spX[j - 1];
                    this.spY[j] = this.spY[j - 1];
                }
            }
            this.spN[0] = Main.worldName;
            this.spI[0] = Main.worldID;
            this.spX[0] = x;
            this.spY[0] = y;
        }

        public void checkArmor()
        {
        }

        public static bool CheckSpawn(int x, int y)
        {
            if (((x < 10) || (x > (Main.maxTilesX - 10))) || ((y < 10) || (y > (Main.maxTilesX - 10))))
            {
                return false;
            }
            if (Main.tile[x, y - 1] == null)
            {
                return false;
            }
            if (!Main.tile[x, y - 1].active || (Main.tile[x, y - 1].type != 0x4f))
            {
                return false;
            }
            for (int i = x - 1; i <= (x + 1); i++)
            {
                for (int j = y - 3; j < y; j++)
                {
                    if (Main.tile[i, j] == null)
                    {
                        return false;
                    }
                    if ((Main.tile[i, j].active && Main.tileSolid[Main.tile[i, j].type]) && !Main.tileSolidTop[Main.tile[i, j].type])
                    {
                        return false;
                    }
                }
            }
            if (!WorldGen.StartRoomCheck(x, y - 1))
            {
                return false;
            }
            return true;
        }

        public object clientClone()
        {
            Player player = new Player {
                zoneEvil = this.zoneEvil,
                zoneMeteor = this.zoneMeteor,
                zoneDungeon = this.zoneDungeon,
                zoneJungle = this.zoneJungle,
                direction = this.direction,
                selectedItem = this.selectedItem,
                controlUp = this.controlUp,
                controlDown = this.controlDown,
                controlLeft = this.controlLeft,
                controlRight = this.controlRight,
                controlJump = this.controlJump,
                controlUseItem = this.controlUseItem,
                statLife = this.statLife,
                statLifeMax = this.statLifeMax,
                statMana = this.statMana,
                statManaMax = this.statManaMax
            };
            player.position.X = this.position.X;
            player.chest = this.chest;
            player.talkNPC = this.talkNPC;
            for (int i = 0; i < 0x2c; i++)
            {
                player.inventory[i] = (Item) this.inventory[i].Clone();
                if (i < 11)
                {
                    player.armor[i] = (Item) this.armor[i].Clone();
                }
            }
            for (int j = 0; j < 10; j++)
            {
                player.buffType[j] = this.buffType[j];
                player.buffTime[j] = this.buffTime[j];
            }
            return player;
        }

        public object Clone()
        {
            return base.MemberwiseClone();
        }

        public int countBuffs()
        {
            int index = 0;
            for (int i = 0; i < 10; i++)
            {
                if (this.buffType[index] > 0)
                {
                    index++;
                }
            }
            return index;
        }

        private static bool DecryptFile(string inputFile, string outputFile)
        {
            string s = "h3y_gUyZ";
            byte[] bytes = new UnicodeEncoding().GetBytes(s);
            FileStream stream = new FileStream(inputFile, FileMode.Open);
            RijndaelManaged managed = new RijndaelManaged();
            CryptoStream stream2 = new CryptoStream(stream, managed.CreateDecryptor(bytes, bytes), CryptoStreamMode.Read);
            FileStream stream3 = new FileStream(outputFile, FileMode.Create);
            try
            {
                int num;
                while ((num = stream2.ReadByte()) != -1)
                {
                    stream3.WriteByte((byte) num);
                }
                stream3.Close();
                stream2.Close();
                stream.Close();
            }
            catch
            {
                stream3.Close();
                stream.Close();
                File.Delete(outputFile);
                return true;
            }
            return false;
        }

        public void DelBuff(int b)
        {
            this.buffTime[b] = 0;
            this.buffType[b] = 0;
            for (int i = 0; i < 9; i++)
            {
                if ((this.buffTime[i] == 0) || (this.buffType[i] == 0))
                {
                    for (int j = i + 1; j < 10; j++)
                    {
                        this.buffTime[j - 1] = this.buffTime[j];
                        this.buffType[j - 1] = this.buffType[j];
                        this.buffTime[j] = 0;
                        this.buffType[j] = 0;
                    }
                }
            }
        }

        public void DoCoins(int i)
        {
            if ((this.inventory[i].stack == 100) && (((this.inventory[i].type == 0x47) || (this.inventory[i].type == 0x48)) || (this.inventory[i].type == 0x49)))
            {
                this.inventory[i].SetDefaults(this.inventory[i].type + 1, false);
                for (int j = 0; j < 0x2c; j++)
                {
                    if ((this.inventory[j].IsTheSameAs(this.inventory[i]) && (j != i)) && (this.inventory[j].stack < this.inventory[j].maxStack))
                    {
                        Item item1 = this.inventory[j];
                        item1.stack++;
                        this.inventory[i].SetDefaults("");
                        this.inventory[i].active = false;
                        this.inventory[i].name = "";
                        this.inventory[i].type = 0;
                        this.inventory[i].stack = 0;
                        this.DoCoins(j);
                    }
                }
            }
        }

        public void DropCoins()
        {
            for (int i = 0; i < 0x2c; i++)
            {
                if ((this.inventory[i].type >= 0x47) && (this.inventory[i].type <= 0x4a))
                {
                    int index = Item.NewItem((int) this.position.X, (int) this.position.Y, this.width, this.height, this.inventory[i].type, 1, false);
                    int num3 = this.inventory[i].stack / 2;
                    num3 = this.inventory[i].stack - num3;
                    Item item1 = this.inventory[i];
                    item1.stack -= num3;
                    if (this.inventory[i].stack <= 0)
                    {
                        this.inventory[i] = new Item();
                    }
                    Main.item[index].stack = num3;
                    Main.item[index].velocity.Y = Main.rand.Next(-20, 1) * 0.2f;
                    Main.item[index].velocity.X = Main.rand.Next(-20, 0x15) * 0.2f;
                    Main.item[index].noGrabDelay = 100;
                    if (Main.netMode == 1)
                    {
                        NetMessage.SendData(0x15, -1, -1, "", index, 0f, 0f, 0f, 0);
                    }
                }
            }
        }

        public void dropItemCheck()
        {
            if (!Main.craftGuide && (Main.guideItem.type > 0))
            {
                int index = Item.NewItem((int) this.position.X, (int) this.position.Y, this.width, this.height, Main.guideItem.type, 1, false);
                Main.guideItem.position = Main.item[index].position;
                Main.item[index] = Main.guideItem;
                Main.guideItem = new Item();
                Main.item[index].velocity.Y = -2f;
                Main.item[index].velocity.X = (4 * this.direction) + this.velocity.X;
                if (Main.netMode == 1)
                {
                    NetMessage.SendData(0x15, -1, -1, "", index, 0f, 0f, 0f, 0);
                }
            }
            if (((this.controlThrow && this.releaseThrow) && ((this.inventory[this.selectedItem].type > 0) && !Main.chatMode)) || (((((Main.mouseState.LeftButton == ButtonState.Pressed) && !this.mouseInterface) && Main.mouseLeftRelease) || !Main.playerInventory) && (Main.mouseItem.type > 0)))
            {
                Item item = new Item();
                bool flag = false;
                if (((((Main.mouseState.LeftButton == ButtonState.Pressed) && !this.mouseInterface) && Main.mouseLeftRelease) || !Main.playerInventory) && (Main.mouseItem.type > 0))
                {
                    item = this.inventory[this.selectedItem];
                    this.inventory[this.selectedItem] = Main.mouseItem;
                    this.delayUseItem = true;
                    this.controlUseItem = false;
                    flag = true;
                }
                int num2 = Item.NewItem((int) this.position.X, (int) this.position.Y, this.width, this.height, this.inventory[this.selectedItem].type, 1, false);
                if ((!flag && (this.inventory[this.selectedItem].type == 8)) && (this.inventory[this.selectedItem].stack > 1))
                {
                    Item item1 = this.inventory[this.selectedItem];
                    item1.stack--;
                }
                else
                {
                    this.inventory[this.selectedItem].position = Main.item[num2].position;
                    Main.item[num2] = this.inventory[this.selectedItem];
                    this.inventory[this.selectedItem] = new Item();
                }
                Main.item[num2].velocity.Y = -2f;
                Main.item[num2].velocity.X = (4 * this.direction) + this.velocity.X;
                if ((((Main.mouseState.LeftButton == ButtonState.Pressed) && !this.mouseInterface) || !Main.playerInventory) && (Main.mouseItem.type > 0))
                {
                    this.inventory[this.selectedItem] = item;
                    Main.mouseItem = new Item();
                }
                else
                {
                    this.itemAnimation = 10;
                    this.itemAnimationMax = 10;
                }
                Recipe.FindRecipes();
                if (Main.netMode == 1)
                {
                    NetMessage.SendData(0x15, -1, -1, "", num2, 0f, 0f, 0f, 0);
                }
            }
        }

        public void DropItems()
        {
            for (int i = 0; i < 0x2c; i++)
            {
                if (((this.inventory[i].stack > 0) && (this.inventory[i].name != "Copper Pickaxe")) && ((this.inventory[i].name != "Copper Axe") && (this.inventory[i].name != "Copper Shortsword")))
                {
                    int index = Item.NewItem((int) this.position.X, (int) this.position.Y, this.width, this.height, this.inventory[i].type, 1, false);
                    Main.item[index].SetDefaults(this.inventory[i].name);
                    Main.item[index].stack = this.inventory[i].stack;
                    Main.item[index].velocity.Y = Main.rand.Next(-20, 1) * 0.2f;
                    Main.item[index].velocity.X = Main.rand.Next(-20, 0x15) * 0.2f;
                    Main.item[index].noGrabDelay = 100;
                    if (Main.netMode == 1)
                    {
                        NetMessage.SendData(0x15, -1, -1, "", index, 0f, 0f, 0f, 0);
                    }
                }
                this.inventory[i] = new Item();
                if (i < 11)
                {
                    if (this.armor[i].stack > 0)
                    {
                        int num3 = Item.NewItem((int) this.position.X, (int) this.position.Y, this.width, this.height, this.armor[i].type, 1, false);
                        Main.item[num3].SetDefaults(this.armor[i].name);
                        Main.item[num3].stack = this.armor[i].stack;
                        Main.item[num3].velocity.Y = Main.rand.Next(-20, 1) * 0.2f;
                        Main.item[num3].velocity.X = Main.rand.Next(-20, 0x15) * 0.2f;
                        Main.item[num3].noGrabDelay = 100;
                        if (Main.netMode == 1)
                        {
                            NetMessage.SendData(0x15, -1, -1, "", num3, 0f, 0f, 0f, 0);
                        }
                    }
                    this.armor[i] = new Item();
                }
                if (i < 4)
                {
                    if (this.ammo[i].stack > 0)
                    {
                        int num4 = Item.NewItem((int) this.position.X, (int) this.position.Y, this.width, this.height, this.ammo[i].type, 1, false);
                        Main.item[num4].SetDefaults(this.ammo[i].name);
                        Main.item[num4].stack = this.ammo[i].stack;
                        Main.item[num4].velocity.Y = Main.rand.Next(-20, 1) * 0.2f;
                        Main.item[num4].velocity.X = Main.rand.Next(-20, 0x15) * 0.2f;
                        Main.item[num4].noGrabDelay = 100;
                        if (Main.netMode == 1)
                        {
                            NetMessage.SendData(0x15, -1, -1, "", num4, 0f, 0f, 0f, 0);
                        }
                    }
                    this.ammo[i] = new Item();
                }
            }
            this.inventory[0].SetDefaults("Copper Shortsword");
            this.inventory[1].SetDefaults("Copper Pickaxe");
            this.inventory[2].SetDefaults("Copper Axe");
        }

        private static void EncryptFile(string inputFile, string outputFile)
        {
            int num;
            string s = "h3y_gUyZ";
            byte[] bytes = new UnicodeEncoding().GetBytes(s);
            string path = outputFile;
            FileStream stream = new FileStream(path, FileMode.Create);
            RijndaelManaged managed = new RijndaelManaged();
            CryptoStream stream2 = new CryptoStream(stream, managed.CreateEncryptor(bytes, bytes), CryptoStreamMode.Write);
            FileStream stream3 = new FileStream(inputFile, FileMode.Open);
            while ((num = stream3.ReadByte()) != -1)
            {
                stream2.WriteByte((byte) num);
            }
            stream3.Close();
            stream2.Close();
            stream.Close();
        }

        public Item FillAmmo(int plr, Item newItem)
        {
            Item item = newItem;
            for (int i = 0; i < 4; i++)
            {
                if (((this.ammo[i].type > 0) && (this.ammo[i].stack < this.ammo[i].maxStack)) && item.IsTheSameAs(this.ammo[i]))
                {
                    Main.PlaySound(7, (int) this.position.X, (int) this.position.Y, 1);
                    if ((item.stack + this.ammo[i].stack) <= this.ammo[i].maxStack)
                    {
                        Item item1 = this.ammo[i];
                        item1.stack += item.stack;
                        ItemText.NewText(newItem, item.stack);
                        this.DoCoins(i);
                        if (plr == Main.myPlayer)
                        {
                            Recipe.FindRecipes();
                        }
                        return new Item();
                    }
                    item.stack -= this.ammo[i].maxStack - this.ammo[i].stack;
                    ItemText.NewText(newItem, this.ammo[i].maxStack - this.ammo[i].stack);
                    this.ammo[i].stack = this.ammo[i].maxStack;
                    this.DoCoins(i);
                    if (plr == Main.myPlayer)
                    {
                        Recipe.FindRecipes();
                    }
                }
            }
            if ((item.type != 0xa9) && (item.type != 0x4b))
            {
                for (int j = 0; j < 4; j++)
                {
                    if (this.ammo[j].type == 0)
                    {
                        this.ammo[j] = item;
                        ItemText.NewText(newItem, newItem.stack);
                        this.DoCoins(j);
                        Main.PlaySound(7, (int) this.position.X, (int) this.position.Y, 1);
                        if (plr == Main.myPlayer)
                        {
                            Recipe.FindRecipes();
                        }
                        return new Item();
                    }
                }
            }
            return item;
        }

        public static byte FindClosest(Vector2 Position, int Width, int Height)
        {
            byte num = 0;
            for (int i = 0; i < 0xff; i++)
            {
                if (Main.player[i].active)
                {
                    num = (byte) i;
                    break;
                }
            }
            float num3 = -1f;
            for (int j = 0; j < 0xff; j++)
            {
                if ((Main.player[j].active && !Main.player[j].dead) && ((num3 == -1f) || ((Math.Abs((float) (((Main.player[j].position.X + (Main.player[j].width / 2)) - Position.X) + (Width / 2))) + Math.Abs((float) (((Main.player[j].position.Y + (Main.player[j].height / 2)) - Position.Y) + (Height / 2)))) < num3)))
                {
                    num3 = Math.Abs((float) (((Main.player[j].position.X + (Main.player[j].width / 2)) - Position.X) + (Width / 2))) + Math.Abs((float) (((Main.player[j].position.Y + (Main.player[j].height / 2)) - Position.Y) + (Height / 2)));
                    num = (byte) j;
                }
            }
            return num;
        }

        public void FindSpawn()
        {
            for (int i = 0; i < 200; i++)
            {
                if (this.spN[i] == null)
                {
                    this.SpawnX = -1;
                    this.SpawnY = -1;
                    return;
                }
                if ((this.spN[i] == Main.worldName) && (this.spI[i] == Main.worldID))
                {
                    this.SpawnX = this.spX[i];
                    this.SpawnY = this.spY[i];
                    return;
                }
            }
        }

        public Color GetDeathAlpha(Color newColor)
        {
            int r = newColor.R + ((int) (this.immuneAlpha * 0.9));
            int g = newColor.G + ((int) (this.immuneAlpha * 0.5));
            int b = newColor.B + ((int) (this.immuneAlpha * 0.5));
            int a = newColor.A + ((int) (this.immuneAlpha * 0.4));
            if (a < 0)
            {
                a = 0;
            }
            if (a > 0xff)
            {
                a = 0xff;
            }
            return new Color(r, g, b, a);
        }

        public static string getDeathMessage(int plr = -1, int npc = -1, int proj = -1, int other = -1)
        {
            string str = "";
            int num = Main.rand.Next(11);
            string str2 = "";
            switch (num)
            {
                case 0:
                    str2 = " was slain";
                    break;

                case 1:
                    str2 = " was eviscerated";
                    break;

                case 2:
                    str2 = " was murdered";
                    break;

                case 3:
                    str2 = "'s face was torn off";
                    break;

                case 4:
                    str2 = "'s entrails were ripped out";
                    break;

                case 5:
                    str2 = " was destroyed";
                    break;

                case 6:
                    str2 = "'s skull was crushed";
                    break;

                case 7:
                    str2 = " got massacred";
                    break;

                case 8:
                    str2 = " got impaled";
                    break;

                case 9:
                    str2 = " was torn in half";
                    break;

                case 10:
                    str2 = " was decapitated";
                    break;
            }
            if ((plr >= 0) && (plr < 0xff))
            {
                if ((proj >= 0) && (Main.projectile[proj].name != ""))
                {
                    return (str2 + " by " + Main.player[plr].name + "'s " + Main.projectile[proj].name + ".");
                }
                return (str2 + " by " + Main.player[plr].name + "'s " + Main.player[plr].inventory[Main.player[plr].selectedItem].name + ".");
            }
            if ((npc >= 0) && (Main.npc[npc].name != ""))
            {
                return (str2 + " by " + Main.npc[npc].name + ".");
            }
            if ((proj >= 0) && (Main.projectile[proj].name != ""))
            {
                return (str2 + " by " + Main.projectile[proj].name + ".");
            }
            if (other >= 0)
            {
                if (other == 0)
                {
                    switch (Main.rand.Next(5))
                    {
                        case 0:
                            return " fell to their death.";

                        case 1:
                            return " faceplanted the ground.";

                        case 2:
                            return " fell victim to gravity.";

                        case 3:
                            return " left a small crater.";

                        case 4:
                            str = " didn't bounce.";
                            break;
                    }
                    return str;
                }
                if (other == 1)
                {
                    switch (Main.rand.Next(4))
                    {
                        case 0:
                            return " forgot to breathe.";

                        case 1:
                            return " is sleeping with the fish.";

                        case 2:
                            return " drowned.";

                        case 3:
                            str = " is shark food.";
                            break;
                    }
                    return str;
                }
                if (other == 2)
                {
                    switch (Main.rand.Next(4))
                    {
                        case 0:
                            return " got melted.";

                        case 1:
                            return " was incinerated.";

                        case 2:
                            return " tried to swim in lava.";

                        case 3:
                            str = " likes to play in magma.";
                            break;
                    }
                    return str;
                }
                if (other == 3)
                {
                    str = str2 + ".";
                }
            }
            return str;
        }

        public Color GetImmuneAlpha(Color newColor)
        {
            float num = ((float) (0xff - this.immuneAlpha)) / 255f;
            if (this.shadow > 0f)
            {
                num *= 1f - this.shadow;
            }
            int r = (int) (newColor.R * num);
            int g = (int) (newColor.G * num);
            int b = (int) (newColor.B * num);
            int a = (int) (newColor.A * num);
            if (a < 0)
            {
                a = 0;
            }
            if (a > 0xff)
            {
                a = 0xff;
            }
            return new Color(r, g, b, a);
        }

        public Item GetItem(int plr, Item newItem)
        {
            Item item = newItem;
            int num = 40;
            if (newItem.noGrabDelay <= 0)
            {
                int num2 = 0;
                if (((newItem.type == 0x47) || (newItem.type == 0x48)) || ((newItem.type == 0x49) || (newItem.type == 0x4a)))
                {
                    num2 = -4;
                    num = 0x2c;
                }
                if (item.ammo > 0)
                {
                    item = this.FillAmmo(plr, item);
                    if ((item.type == 0) || (item.stack == 0))
                    {
                        return new Item();
                    }
                }
                for (int i = num2; i < 40; i++)
                {
                    int index = i;
                    if (index < 0)
                    {
                        index = 0x2c + i;
                    }
                    if (((this.inventory[index].type > 0) && (this.inventory[index].stack < this.inventory[index].maxStack)) && item.IsTheSameAs(this.inventory[index]))
                    {
                        Main.PlaySound(7, (int) this.position.X, (int) this.position.Y, 1);
                        if ((item.stack + this.inventory[index].stack) <= this.inventory[index].maxStack)
                        {
                            Item item1 = this.inventory[index];
                            item1.stack += item.stack;
                            ItemText.NewText(newItem, item.stack);
                            this.DoCoins(index);
                            if (plr == Main.myPlayer)
                            {
                                Recipe.FindRecipes();
                            }
                            return new Item();
                        }
                        item.stack -= this.inventory[index].maxStack - this.inventory[index].stack;
                        ItemText.NewText(newItem, this.inventory[index].maxStack - this.inventory[index].stack);
                        this.inventory[index].stack = this.inventory[index].maxStack;
                        this.DoCoins(index);
                        if (plr == Main.myPlayer)
                        {
                            Recipe.FindRecipes();
                        }
                    }
                }
                for (int j = num - 1; j >= 0; j--)
                {
                    if (this.inventory[j].type == 0)
                    {
                        this.inventory[j] = item;
                        ItemText.NewText(newItem, newItem.stack);
                        this.DoCoins(j);
                        Main.PlaySound(7, (int) this.position.X, (int) this.position.Y, 1);
                        if (plr == Main.myPlayer)
                        {
                            Recipe.FindRecipes();
                        }
                        return new Item();
                    }
                }
            }
            return item;
        }

        public void Ghost()
        {
            this.immune = false;
            this.immuneAlpha = 0;
            this.controlUp = false;
            this.controlLeft = false;
            this.controlDown = false;
            this.controlRight = false;
            this.controlJump = false;
            if ((Main.hasFocus && !Main.chatMode) && !Main.editSign)
            {
                Keys[] pressedKeys = Main.keyState.GetPressedKeys();
                for (int i = 0; i < pressedKeys.Length; i++)
                {
                    string str = pressedKeys[i].ToString();
                    if (str == Main.cUp)
                    {
                        this.controlUp = true;
                    }
                    if (str == Main.cLeft)
                    {
                        this.controlLeft = true;
                    }
                    if (str == Main.cDown)
                    {
                        this.controlDown = true;
                    }
                    if (str == Main.cRight)
                    {
                        this.controlRight = true;
                    }
                    if (str == Main.cJump)
                    {
                        this.controlJump = true;
                    }
                }
            }
            if (this.controlUp || this.controlJump)
            {
                if (this.velocity.Y > 0f)
                {
                    this.velocity.Y *= 0.9f;
                }
                this.velocity.Y -= 0.1f;
                if (this.velocity.Y < -3f)
                {
                    this.velocity.Y = -3f;
                }
            }
            else if (this.controlDown)
            {
                if (this.velocity.Y < 0f)
                {
                    this.velocity.Y *= 0.9f;
                }
                this.velocity.Y += 0.1f;
                if (this.velocity.Y > 3f)
                {
                    this.velocity.Y = 3f;
                }
            }
            else if ((this.velocity.Y < -0.1) || (this.velocity.Y > 0.1))
            {
                this.velocity.Y *= 0.9f;
            }
            else
            {
                this.velocity.Y = 0f;
            }
            if (this.controlLeft && !this.controlRight)
            {
                if (this.velocity.X > 0f)
                {
                    this.velocity.X *= 0.9f;
                }
                this.velocity.X -= 0.1f;
                if (this.velocity.X < -3f)
                {
                    this.velocity.X = -3f;
                }
            }
            else if (this.controlRight && !this.controlLeft)
            {
                if (this.velocity.X < 0f)
                {
                    this.velocity.X *= 0.9f;
                }
                this.velocity.X += 0.1f;
                if (this.velocity.X > 3f)
                {
                    this.velocity.X = 3f;
                }
            }
            else if ((this.velocity.X < -0.1) || (this.velocity.X > 0.1))
            {
                this.velocity.X *= 0.9f;
            }
            else
            {
                this.velocity.X = 0f;
            }
            this.position += this.velocity;
            this.ghostFrameCounter++;
            if (this.velocity.X < 0f)
            {
                this.direction = -1;
            }
            else if (this.velocity.X > 0f)
            {
                this.direction = 1;
            }
            if (this.ghostFrameCounter >= 8)
            {
                this.ghostFrameCounter = 0;
                this.ghostFrame++;
                if (this.ghostFrame >= 4)
                {
                    this.ghostFrame = 0;
                }
            }
            if (this.position.X < ((Main.leftWorld + 336f) + 16f))
            {
                this.position.X = (Main.leftWorld + 336f) + 16f;
                this.velocity.X = 0f;
            }
            if ((this.position.X + this.width) > ((Main.rightWorld - 336f) - 32f))
            {
                this.position.X = ((Main.rightWorld - 336f) - 32f) - this.width;
                this.velocity.X = 0f;
            }
            if (this.position.Y < ((Main.topWorld + 336f) + 16f))
            {
                this.position.Y = (Main.topWorld + 336f) + 16f;
                if (this.velocity.Y < -0.1)
                {
                    this.velocity.Y = -0.1f;
                }
            }
            if (this.position.Y > (((Main.bottomWorld - 336f) - 32f) - this.height))
            {
                this.position.Y = ((Main.bottomWorld - 336f) - 32f) - this.height;
                this.velocity.Y = 0f;
            }
        }

        public bool HasItem(int type)
        {
            for (int i = 0; i < 0x2c; i++)
            {
                if (type == this.inventory[i].type)
                {
                    return true;
                }
            }
            return false;
        }

        public void HealEffect(int healAmount)
        {
            CombatText.NewText(new Rectangle((int)this.position.X, (int)this.position.Y, this.width, this.height), new Color(100, 0xff, 100, 0xff), healAmount.ToString(), false);
            if ((Main.netMode == 1) && (this.whoAmi == Main.myPlayer))
            {
                NetMessage.SendData(0x23, -1, -1, "", this.whoAmi, (float) healAmount, 0f, 0f, 0);
            }
        }

        public double Hurt(int Damage, int hitDirection, bool pvp = false, bool quiet = false, string deathText = " was slain...", bool Crit = false)
        {
            if (this.immune)
            {
                return 0.0;
            }
            int damage = Damage;
            if (pvp)
            {
                damage *= 2;
            }
            double dmg = Main.CalculateDamage(damage, this.statDefense);
            if (Crit)
            {
                damage *= 2;
            }
            if (dmg >= 1.0)
            {
                if (((Main.netMode == 1) && (this.whoAmi == Main.myPlayer)) && !quiet)
                {
                    int num3 = 0;
                    if (pvp)
                    {
                        num3 = 1;
                    }
                    NetMessage.SendData(13, -1, -1, "", this.whoAmi, 0f, 0f, 0f, 0);
                    NetMessage.SendData(0x10, -1, -1, "", this.whoAmi, 0f, 0f, 0f, 0);
                    NetMessage.SendData(0x1a, -1, -1, "", this.whoAmi, (float) hitDirection, (float) Damage, (float) num3, 0);
                }
                CombatText.NewText(new Rectangle((int)this.position.X, (int)this.position.Y, this.width, this.height), new Color(0xff, 80, 90, 0xff), ((int)dmg).ToString(), Crit);
                this.statLife -= (int) dmg;
                this.immune = true;
                this.immuneTime = 40;
                this.lifeRegenTime = 0;
                if (pvp)
                {
                    this.immuneTime = 8;
                }
                if (!this.noKnockback && (hitDirection != 0))
                {
                    this.velocity.X = 4.5f * hitDirection;
                    this.velocity.Y = -3.5f;
                }
                if (this.boneArmor)
                {
                    Main.PlaySound(3, (int) this.position.X, (int) this.position.Y, 2);
                }
                else if (!this.male)
                {
                    Main.PlaySound(20, (int) this.position.X, (int) this.position.Y, 1);
                }
                else
                {
                    Main.PlaySound(1, (int) this.position.X, (int) this.position.Y, 1);
                }
                if (this.statLife > 0)
                {
                    for (int i = 0; i < ((dmg / ((double) this.statLifeMax)) * 100.0); i++)
                    {
                        if (this.boneArmor)
                        {
                            Color newColor = new Color();
                            Dust.NewDust(this.position, this.width, this.height, 0x1a, (float) (2 * hitDirection), -2f, 0, newColor, 1f);
                        }
                        else
                        {
                            Color color2 = new Color();
                            Dust.NewDust(this.position, this.width, this.height, 5, (float) (2 * hitDirection), -2f, 0, color2, 1f);
                        }
                    }
                }
                else
                {
                    this.statLife = 0;
                    if (this.whoAmi == Main.myPlayer)
                    {
                        this.KillMe(dmg, hitDirection, pvp, deathText);
                    }
                }
            }
            if (pvp)
            {
                dmg = Main.CalculateDamage(damage, this.statDefense);
            }
            return dmg;
        }

        public void ItemCheck(int i)
        {
            Color color;
            int damage = this.inventory[this.selectedItem].damage;
            if (damage > 0)
            {
                if (this.inventory[this.selectedItem].melee)
                {
                    damage = (int) (damage * this.meleeDamage);
                }
                else if (this.inventory[this.selectedItem].ranged)
                {
                    damage = (int) (damage * this.rangedDamage);
                }
                else if (this.inventory[this.selectedItem].magic)
                {
                    damage = (int) (damage * this.magicDamage);
                }
            }
            if (this.inventory[this.selectedItem].autoReuse && !this.noItems)
            {
                this.releaseUseItem = true;
                if ((this.itemAnimation == 1) && (this.inventory[this.selectedItem].stack > 0))
                {
                    this.itemAnimation = 0;
                }
            }
            if ((this.controlUseItem && (this.itemAnimation == 0)) && (this.releaseUseItem && (this.inventory[this.selectedItem].useStyle > 0)))
            {
                bool flag = true;
                if (this.noItems)
                {
                    flag = false;
                }
                if (((this.inventory[this.selectedItem].shoot == 6) || (this.inventory[this.selectedItem].shoot == 0x13)) || ((this.inventory[this.selectedItem].shoot == 0x21) || (this.inventory[this.selectedItem].shoot == 0x34)))
                {
                    for (int j = 0; j < 0x3e8; j++)
                    {
                        if ((Main.projectile[j].active && (Main.projectile[j].owner == Main.myPlayer)) && (Main.projectile[j].type == this.inventory[this.selectedItem].shoot))
                        {
                            flag = false;
                        }
                    }
                }
                if ((this.inventory[this.selectedItem].shoot == 13) || (this.inventory[this.selectedItem].shoot == 0x20))
                {
                    for (int k = 0; k < 0x3e8; k++)
                    {
                        if ((Main.projectile[k].active && (Main.projectile[k].owner == Main.myPlayer)) && ((Main.projectile[k].type == this.inventory[this.selectedItem].shoot) && (Main.projectile[k].ai[0] != 2f)))
                        {
                            flag = false;
                        }
                    }
                }
                if (this.inventory[this.selectedItem].potion && flag)
                {
                    if (this.potionDelay <= 0)
                    {
                        this.potionDelay = Item.potionDelay;
                        this.AddBuff(0x15, this.potionDelay, true);
                    }
                    else
                    {
                        flag = false;
                    }
                }
                if ((this.inventory[this.selectedItem].mana > 0) && flag)
                {
                    if ((this.inventory[this.selectedItem].type != 0x7f) || !this.spaceGun)
                    {
                        if (this.statMana >= ((int) (this.inventory[this.selectedItem].mana * this.manaCost)))
                        {
                            this.statMana -= (int) (this.inventory[this.selectedItem].mana * this.manaCost);
                        }
                        else
                        {
                            flag = false;
                        }
                    }
                    if ((this.whoAmi == Main.myPlayer) && (this.inventory[this.selectedItem].buffType != 0))
                    {
                        this.AddBuff(this.inventory[this.selectedItem].buffType, this.inventory[this.selectedItem].buffTime, true);
                    }
                }
                if ((this.inventory[this.selectedItem].type == 0x2b) && Main.dayTime)
                {
                    flag = false;
                }
                if ((this.inventory[this.selectedItem].type == 70) && !this.zoneEvil)
                {
                    flag = false;
                }
                if (((this.inventory[this.selectedItem].shoot == 0x11) && flag) && (i == Main.myPlayer))
                {
                    int num4 = (Main.mouseState.X + ((int) Main.screenPosition.X)) / 0x10;
                    int num5 = (Main.mouseState.Y + ((int) Main.screenPosition.Y)) / 0x10;
                    if (Main.tile[num4, num5].active && (((Main.tile[num4, num5].type == 0) || (Main.tile[num4, num5].type == 2)) || (Main.tile[num4, num5].type == 0x17)))
                    {
                        WorldGen.KillTile(num4, num5, false, false, true);
                        if (!Main.tile[num4, num5].active)
                        {
                            if (Main.netMode == 1)
                            {
                                NetMessage.SendData(0x11, -1, -1, "", 4, (float) num4, (float) num5, 0f, 0);
                            }
                        }
                        else
                        {
                            flag = false;
                        }
                    }
                    else
                    {
                        flag = false;
                    }
                }
                if (flag && (this.inventory[this.selectedItem].useAmmo > 0))
                {
                    flag = false;
                    for (int m = 0; m < 0x2c; m++)
                    {
                        if (((m < 4) && (this.ammo[m].ammo == this.inventory[this.selectedItem].useAmmo)) && (this.ammo[m].stack > 0))
                        {
                            flag = true;
                            break;
                        }
                        if ((this.inventory[m].ammo == this.inventory[this.selectedItem].useAmmo) && (this.inventory[m].stack > 0))
                        {
                            flag = true;
                            break;
                        }
                    }
                }
                if (flag)
                {
                    if (this.grappling[0] > -1)
                    {
                        if (this.controlRight)
                        {
                            this.direction = 1;
                        }
                        else if (this.controlLeft)
                        {
                            this.direction = -1;
                        }
                    }
                    this.channel = this.inventory[this.selectedItem].channel;
                    this.attackCD = 0;
                    if (this.inventory[this.selectedItem].melee)
                    {
                        this.itemAnimation = (int) (this.inventory[this.selectedItem].useAnimation * this.meleeSpeed);
                        this.itemAnimationMax = (int) (this.inventory[this.selectedItem].useAnimation * this.meleeSpeed);
                    }
                    else
                    {
                        this.itemAnimation = this.inventory[this.selectedItem].useAnimation;
                        this.itemAnimationMax = this.inventory[this.selectedItem].useAnimation;
                    }
                    if (this.inventory[this.selectedItem].useSound > 0)
                    {
                        Main.PlaySound(2, (int) this.position.X, (int) this.position.Y, this.inventory[this.selectedItem].useSound);
                    }
                }
                if (flag && (this.inventory[this.selectedItem].shoot == 0x12))
                {
                    for (int n = 0; n < 0x3e8; n++)
                    {
                        if ((Main.projectile[n].active && (Main.projectile[n].owner == i)) && (Main.projectile[n].type == this.inventory[this.selectedItem].shoot))
                        {
                            Main.projectile[n].Kill();
                        }
                    }
                }
            }
            if (!this.controlUseItem)
            {
                bool channel = this.channel;
                this.channel = false;
            }
            if (this.itemAnimation > 0)
            {
                if (this.inventory[this.selectedItem].mana > 0)
                {
                    this.manaRegenDelay = (int) this.maxRegenDelay;
                }
                if (Main.dedServ)
                {
                    this.itemHeight = this.inventory[this.selectedItem].height;
                    this.itemWidth = this.inventory[this.selectedItem].width;
                }
                else
                {
                    this.itemHeight = Main.itemTexture[this.inventory[this.selectedItem].type].Height;
                    this.itemWidth = Main.itemTexture[this.inventory[this.selectedItem].type].Width;
                }
                this.itemAnimation--;
                if (!Main.dedServ)
                {
                    if (this.inventory[this.selectedItem].useStyle == 1)
                    {
                        if (this.itemAnimation < (this.itemAnimationMax * 0.333))
                        {
                            float num8 = 10f;
                            if (Main.itemTexture[this.inventory[this.selectedItem].type].Width > 0x20)
                            {
                                num8 = 14f;
                            }
                            this.itemLocation.X = (this.position.X + (this.width * 0.5f)) + (((Main.itemTexture[this.inventory[this.selectedItem].type].Width * 0.5f) - num8) * this.direction);
                            this.itemLocation.Y = this.position.Y + 24f;
                        }
                        else if (this.itemAnimation < (this.itemAnimationMax * 0.666))
                        {
                            float num9 = 10f;
                            if (Main.itemTexture[this.inventory[this.selectedItem].type].Width > 0x20)
                            {
                                num9 = 18f;
                            }
                            this.itemLocation.X = (this.position.X + (this.width * 0.5f)) + (((Main.itemTexture[this.inventory[this.selectedItem].type].Width * 0.5f) - num9) * this.direction);
                            num9 = 10f;
                            if (Main.itemTexture[this.inventory[this.selectedItem].type].Height > 0x20)
                            {
                                num9 = 8f;
                            }
                            this.itemLocation.Y = this.position.Y + num9;
                        }
                        else
                        {
                            float num10 = 6f;
                            if (Main.itemTexture[this.inventory[this.selectedItem].type].Width > 0x20)
                            {
                                num10 = 14f;
                            }
                            this.itemLocation.X = (this.position.X + (this.width * 0.5f)) - (((Main.itemTexture[this.inventory[this.selectedItem].type].Width * 0.5f) - num10) * this.direction);
                            num10 = 10f;
                            if (Main.itemTexture[this.inventory[this.selectedItem].type].Height > 0x20)
                            {
                                num10 = 10f;
                            }
                            this.itemLocation.Y = this.position.Y + num10;
                        }
                        this.itemRotation = ((((((float) this.itemAnimation) / ((float) this.itemAnimationMax)) - 0.5f) * -this.direction) * 3.5f) - (this.direction * 0.3f);
                        if (this.gravDir == -1f)
                        {
                            this.itemRotation = -this.itemRotation;
                            this.itemLocation.Y = (this.position.Y + this.height) + (this.position.Y - this.itemLocation.Y);
                        }
                    }
                    else if (this.inventory[this.selectedItem].useStyle == 2)
                    {
                        this.itemRotation = (((((float) this.itemAnimation) / ((float) this.itemAnimationMax)) * this.direction) * 2f) + (-1.4f * this.direction);
                        if (this.itemAnimation < (this.itemAnimationMax * 0.5))
                        {
                            this.itemLocation.X = (this.position.X + (this.width * 0.5f)) + ((((Main.itemTexture[this.inventory[this.selectedItem].type].Width * 0.5f) - 9f) - ((this.itemRotation * 12f) * this.direction)) * this.direction);
                            this.itemLocation.Y = (this.position.Y + 38f) + ((this.itemRotation * this.direction) * 4f);
                        }
                        else
                        {
                            this.itemLocation.X = (this.position.X + (this.width * 0.5f)) + ((((Main.itemTexture[this.inventory[this.selectedItem].type].Width * 0.5f) - 9f) - ((this.itemRotation * 16f) * this.direction)) * this.direction);
                            this.itemLocation.Y = (this.position.Y + 38f) + (this.itemRotation * this.direction);
                        }
                        if (this.gravDir == -1f)
                        {
                            this.itemRotation = -this.itemRotation;
                            this.itemLocation.Y = (this.position.Y + this.height) + (this.position.Y - this.itemLocation.Y);
                        }
                    }
                    else if (this.inventory[this.selectedItem].useStyle == 3)
                    {
                        if (this.itemAnimation > (this.itemAnimationMax * 0.666))
                        {
                            this.itemLocation.X = -1000f;
                            this.itemLocation.Y = -1000f;
                            this.itemRotation = -1.3f * this.direction;
                        }
                        else
                        {
                            this.itemLocation.X = (this.position.X + (this.width * 0.5f)) + (((Main.itemTexture[this.inventory[this.selectedItem].type].Width * 0.5f) - 4f) * this.direction);
                            this.itemLocation.Y = this.position.Y + 24f;
                            float num11 = (((((((float) this.itemAnimation) / ((float) this.itemAnimationMax)) * Main.itemTexture[this.inventory[this.selectedItem].type].Width) * this.direction) * this.inventory[this.selectedItem].scale) * 1.2f) - (10 * this.direction);
                            if ((num11 > -4f) && (this.direction == -1))
                            {
                                num11 = -8f;
                            }
                            if ((num11 < 4f) && (this.direction == 1))
                            {
                                num11 = 8f;
                            }
                            this.itemLocation.X -= num11;
                            this.itemRotation = 0.8f * this.direction;
                        }
                        if (this.gravDir == -1f)
                        {
                            this.itemRotation = -this.itemRotation;
                            this.itemLocation.Y = (this.position.Y + this.height) + (this.position.Y - this.itemLocation.Y);
                        }
                    }
                    else if (this.inventory[this.selectedItem].useStyle == 4)
                    {
                        this.itemRotation = 0f;
                        this.itemLocation.X = (this.position.X + (this.width * 0.5f)) + ((((Main.itemTexture[this.inventory[this.selectedItem].type].Width * 0.5f) - 9f) - ((this.itemRotation * 14f) * this.direction)) * this.direction);
                        this.itemLocation.Y = this.position.Y + (Main.itemTexture[this.inventory[this.selectedItem].type].Height * 0.5f);
                        if (this.gravDir == -1f)
                        {
                            this.itemRotation = -this.itemRotation;
                            this.itemLocation.Y = (this.position.Y + this.height) + (this.position.Y - this.itemLocation.Y);
                        }
                    }
                    else if (this.inventory[this.selectedItem].useStyle == 5)
                    {
                        this.itemLocation.X = ((this.position.X + (this.width * 0.5f)) - (Main.itemTexture[this.inventory[this.selectedItem].type].Width * 0.5f)) - (this.direction * 2);
                        this.itemLocation.Y = (this.position.Y + (this.height * 0.5f)) - (Main.itemTexture[this.inventory[this.selectedItem].type].Height * 0.5f);
                    }
                }
            }
            else if (this.inventory[this.selectedItem].holdStyle == 1)
            {
                if (Main.dedServ)
                {
                    this.itemLocation.X = (this.position.X + (this.width * 0.5f)) + (20f * this.direction);
                }
                else
                {
                    this.itemLocation.X = (this.position.X + (this.width * 0.5f)) + (((Main.itemTexture[this.inventory[this.selectedItem].type].Width * 0.5f) + 4f) * this.direction);
                    if ((this.inventory[this.selectedItem].type == 0x11a) || (this.inventory[this.selectedItem].type == 0x11e))
                    {
                        this.itemLocation.X -= this.direction * 4;
                        this.itemLocation.Y += 4f;
                    }
                }
                this.itemLocation.Y = this.position.Y + 24f;
                this.itemRotation = 0f;
                if (this.gravDir == -1f)
                {
                    this.itemRotation = -this.itemRotation;
                    this.itemLocation.Y = (this.position.Y + this.height) + (this.position.Y - this.itemLocation.Y);
                }
            }
            else if (this.inventory[this.selectedItem].holdStyle == 2)
            {
                this.itemLocation.X = (this.position.X + (this.width * 0.5f)) + (6 * this.direction);
                this.itemLocation.Y = this.position.Y + 16f;
                this.itemRotation = 0.79f * -this.direction;
                if (this.gravDir == -1f)
                {
                    this.itemRotation = -this.itemRotation;
                    this.itemLocation.Y = (this.position.Y + this.height) + (this.position.Y - this.itemLocation.Y);
                }
            }
            if ((this.inventory[this.selectedItem].type == 8) && !this.wet)
            {
                int maxValue = 20;
                if (this.itemAnimation > 0)
                {
                    maxValue = 7;
                }
                if (this.direction == -1)
                {
                    if (Main.rand.Next(maxValue) == 0)
                    {
                        color = new Color();
                        Dust.NewDust(new Vector2(this.itemLocation.X - 16f, this.itemLocation.Y - (14f * this.gravDir)), 4, 4, 6, 0f, 0f, 100, color, 1f);
                    }
                    Lighting.addLight((int) (((this.itemLocation.X - 16f) + this.velocity.X) / 16f), (int) ((this.itemLocation.Y - 14f) / 16f), 1f);
                }
                else
                {
                    if (Main.rand.Next(maxValue) == 0)
                    {
                        color = new Color();
                        Dust.NewDust(new Vector2(this.itemLocation.X + 6f, this.itemLocation.Y - (14f * this.gravDir)), 4, 4, 6, 0f, 0f, 100, color, 1f);
                    }
                    Lighting.addLight((int) (((this.itemLocation.X + 6f) + this.velocity.X) / 16f), (int) ((this.itemLocation.Y - 14f) / 16f), 1f);
                }
            }
            else if ((this.inventory[this.selectedItem].type == 0x69) && !this.wet)
            {
                int num13 = 20;
                if (this.itemAnimation > 0)
                {
                    num13 = 7;
                }
                if (this.direction == -1)
                {
                    if (Main.rand.Next(num13) == 0)
                    {
                        color = new Color();
                        Dust.NewDust(new Vector2(this.itemLocation.X - 12f, this.itemLocation.Y - (20f * this.gravDir)), 4, 4, 6, 0f, 0f, 100, color, 1f);
                    }
                    Lighting.addLight((int) (((this.itemLocation.X - 16f) + this.velocity.X) / 16f), (int) ((this.itemLocation.Y - 14f) / 16f), 1f);
                }
                else
                {
                    if (Main.rand.Next(num13) == 0)
                    {
                        color = new Color();
                        Dust.NewDust(new Vector2(this.itemLocation.X + 4f, this.itemLocation.Y - (20f * this.gravDir)), 4, 4, 6, 0f, 0f, 100, color, 1f);
                    }
                    Lighting.addLight((int) (((this.itemLocation.X + 6f) + this.velocity.X) / 16f), (int) ((this.itemLocation.Y - 14f) / 16f), 1f);
                }
            }
            else if ((this.inventory[this.selectedItem].type == 0x94) && !this.wet)
            {
                int num14 = 10;
                if (this.itemAnimation > 0)
                {
                    num14 = 7;
                }
                if (this.direction == -1)
                {
                    if (Main.rand.Next(num14) == 0)
                    {
                        color = new Color();
                        Dust.NewDust(new Vector2(this.itemLocation.X - 12f, this.itemLocation.Y - (20f * this.gravDir)), 4, 4, 0x1d, 0f, 0f, 100, color, 1f);
                    }
                    Lighting.addLight((int) (((this.itemLocation.X - 16f) + this.velocity.X) / 16f), (int) ((this.itemLocation.Y - 14f) / 16f), 1f);
                }
                else
                {
                    if (Main.rand.Next(num14) == 0)
                    {
                        color = new Color();
                        Dust.NewDust(new Vector2(this.itemLocation.X + 4f, this.itemLocation.Y - (20f * this.gravDir)), 4, 4, 0x1d, 0f, 0f, 100, color, 1f);
                    }
                    Lighting.addLight((int) (((this.itemLocation.X + 6f) + this.velocity.X) / 16f), (int) ((this.itemLocation.Y - 14f) / 16f), 1f);
                }
            }
            if ((this.inventory[this.selectedItem].type == 0x11a) || (this.inventory[this.selectedItem].type == 0x11e))
            {
                if (this.direction == -1)
                {
                    Lighting.addLight((int) (((this.itemLocation.X - 16f) + this.velocity.X) / 16f), (int) ((this.itemLocation.Y - 14f) / 16f), 1f);
                }
                else
                {
                    Lighting.addLight((int) (((this.itemLocation.X + 6f) + this.velocity.X) / 16f), (int) ((this.itemLocation.Y - 14f) / 16f), 1f);
                }
            }
            if (this.controlUseItem)
            {
                this.releaseUseItem = false;
            }
            else
            {
                this.releaseUseItem = true;
            }
            if (this.itemTime > 0)
            {
                this.itemTime--;
            }
            if (i == Main.myPlayer)
            {
                if (((this.inventory[this.selectedItem].shoot > 0) && (this.itemAnimation > 0)) && (this.itemTime == 0))
                {
                    int shoot = this.inventory[this.selectedItem].shoot;
                    float shootSpeed = this.inventory[this.selectedItem].shootSpeed;
                    if ((this.inventory[this.selectedItem].melee && (shoot != 0x19)) && ((shoot != 0x1a) && (shoot != 0x23)))
                    {
                        shootSpeed /= this.meleeSpeed;
                    }
                    bool flag2 = false;
                    int num17 = damage;
                    float knockBack = this.inventory[this.selectedItem].knockBack;
                    switch (shoot)
                    {
                        case 13:
                        case 0x20:
                            this.grappling[0] = -1;
                            this.grapCount = 0;
                            for (int num19 = 0; num19 < 0x3e8; num19++)
                            {
                                if ((Main.projectile[num19].active && (Main.projectile[num19].owner == i)) && (Main.projectile[num19].type == 13))
                                {
                                    Main.projectile[num19].Kill();
                                }
                            }
                            break;
                    }
                    if (this.inventory[this.selectedItem].useAmmo <= 0)
                    {
                        flag2 = true;
                    }
                    else
                    {
                        Item item = new Item();
                        bool flag3 = false;
                        for (int num20 = 0; num20 < 4; num20++)
                        {
                            if ((this.ammo[num20].ammo == this.inventory[this.selectedItem].useAmmo) && (this.ammo[num20].stack > 0))
                            {
                                item = this.ammo[num20];
                                flag2 = true;
                                flag3 = true;
                                break;
                            }
                        }
                        if (!flag3)
                        {
                            for (int num21 = 0; num21 < 0x2c; num21++)
                            {
                                if ((this.inventory[num21].ammo == this.inventory[this.selectedItem].useAmmo) && (this.inventory[num21].stack > 0))
                                {
                                    item = this.inventory[num21];
                                    flag2 = true;
                                    break;
                                }
                            }
                        }
                        if (flag2)
                        {
                            if (item.shoot > 0)
                            {
                                shoot = item.shoot;
                            }
                            shootSpeed += item.shootSpeed;
                            if (item.ranged)
                            {
                                num17 += (int) (item.damage * this.rangedDamage);
                            }
                            else
                            {
                                num17 += item.damage;
                            }
                            if ((this.inventory[this.selectedItem].useAmmo == 1) && this.archery)
                            {
                                if (shootSpeed < 20f)
                                {
                                    shootSpeed *= 1.2f;
                                    if (shootSpeed > 20f)
                                    {
                                        shootSpeed = 20f;
                                    }
                                }
                                num17 = (int) (num17 * 1.2);
                            }
                            knockBack += item.knockBack;
                            bool flag4 = false;
                            if ((this.inventory[this.selectedItem].type == 0x62) && (Main.rand.Next(3) == 0))
                            {
                                flag4 = true;
                            }
                            if (this.ammoCost80 && (Main.rand.Next(5) == 0))
                            {
                                flag4 = true;
                            }
                            if (!flag4)
                            {
                                item.stack--;
                                if (item.stack <= 0)
                                {
                                    item.active = false;
                                    item.name = "";
                                    item.type = 0;
                                }
                            }
                        }
                    }
                    if (!flag2)
                    {
                        if (this.inventory[this.selectedItem].useStyle == 5)
                        {
                            this.itemRotation = 0f;
                            NetMessage.SendData(0x29, -1, -1, "", this.whoAmi, 0f, 0f, 0f, 0);
                        }
                    }
                    else
                    {
                        if ((shoot == 1) && (this.inventory[this.selectedItem].type == 120))
                        {
                            shoot = 2;
                        }
                        this.itemTime = this.inventory[this.selectedItem].useTime;
                        if ((Main.mouseState.X + Main.screenPosition.X) > (this.position.X + (this.width * 0.5f)))
                        {
                            this.direction = 1;
                        }
                        else
                        {
                            this.direction = -1;
                        }
                        Vector2 vector = new Vector2(this.position.X + (this.width * 0.5f), this.position.Y + (this.height * 0.5f));
                        switch (shoot)
                        {
                            case 9:
                                vector = new Vector2((this.position.X + (this.width * 0.5f)) + (Main.rand.Next(0x259) * -this.direction), ((this.position.Y + (this.height * 0.5f)) - 300f) - Main.rand.Next(100));
                                knockBack = 0f;
                                break;

                            case 0x33:
                                vector.Y -= 6f * this.gravDir;
                                break;
                        }
                        float speedX = (Main.mouseState.X + Main.screenPosition.X) - vector.X;
                        float speedY = (Main.mouseState.Y + Main.screenPosition.Y) - vector.Y;
                        float num24 = (float) Math.Sqrt((double) ((speedX * speedX) + (speedY * speedY)));
                        num24 = shootSpeed / num24;
                        speedX *= num24;
                        speedY *= num24;
                        if (shoot == 12)
                        {
                            vector.X += speedX * 3f;
                            vector.Y += speedY * 3f;
                        }
                        if (this.inventory[this.selectedItem].useStyle == 5)
                        {
                            this.itemRotation = (float) Math.Atan2((double) (speedY * this.direction), (double) (speedX * this.direction));
                            NetMessage.SendData(13, -1, -1, "", this.whoAmi, 0f, 0f, 0f, 0);
                            NetMessage.SendData(0x29, -1, -1, "", this.whoAmi, 0f, 0f, 0f, 0);
                        }
                        if (shoot == 0x11)
                        {
                            vector.X = Main.mouseState.X + Main.screenPosition.X;
                            vector.Y = Main.mouseState.Y + Main.screenPosition.Y;
                        }
                        Projectile.NewProjectile(vector.X, vector.Y, speedX, speedY, shoot, num17, knockBack, i);
                    }
                }
                if ((((this.inventory[this.selectedItem].type >= 0xcd) && (this.inventory[this.selectedItem].type <= 0xcf)) && (((((this.position.X / 16f) - tileRangeX) - this.inventory[this.selectedItem].tileBoost) <= Player.tileTargetX) && ((((((this.position.X + this.width) / 16f) + tileRangeX) + this.inventory[this.selectedItem].tileBoost) - 1f) >= Player.tileTargetX))) && (((((this.position.Y / 16f) - tileRangeY) - this.inventory[this.selectedItem].tileBoost) <= Player.tileTargetY) && ((((((this.position.Y + this.height) / 16f) + tileRangeY) + this.inventory[this.selectedItem].tileBoost) - 2f) >= Player.tileTargetY)))
                {
                    this.showItemIcon = true;
                    if (((this.itemTime == 0) && (this.itemAnimation > 0)) && this.controlUseItem)
                    {
                        if (this.inventory[this.selectedItem].type == 0xcd)
                        {
                            bool lava = Main.tile[Player.tileTargetX, Player.tileTargetY].lava;
                            int num25 = 0;
                            for (int num26 = Player.tileTargetX - 1; num26 <= (Player.tileTargetX + 1); num26++)
                            {
                                for (int num27 = Player.tileTargetY - 1; num27 <= (Player.tileTargetY + 1); num27++)
                                {
                                    if (Main.tile[num26, num27].lava == lava)
                                    {
                                        num25 += Main.tile[num26, num27].liquid;
                                    }
                                }
                            }
                            if ((Main.tile[Player.tileTargetX, Player.tileTargetY].liquid > 0) && (num25 > 100))
                            {
                                bool flag6 = Main.tile[Player.tileTargetX, Player.tileTargetY].lava;
                                if (!Main.tile[Player.tileTargetX, Player.tileTargetY].lava)
                                {
                                    this.inventory[this.selectedItem].SetDefaults(0xce, false);
                                }
                                else
                                {
                                    this.inventory[this.selectedItem].SetDefaults(0xcf, false);
                                }
                                Main.PlaySound(0x13, (int) this.position.X, (int) this.position.Y, 1);
                                this.itemTime = this.inventory[this.selectedItem].useTime;
                                int liquid = Main.tile[Player.tileTargetX, Player.tileTargetY].liquid;
                                Main.tile[Player.tileTargetX, Player.tileTargetY].liquid = 0;
                                Main.tile[Player.tileTargetX, Player.tileTargetY].lava = false;
                                WorldGen.SquareTileFrame(Player.tileTargetX, Player.tileTargetY, false);
                                if (Main.netMode == 1)
                                {
                                    NetMessage.sendWater(Player.tileTargetX, Player.tileTargetY);
                                }
                                else
                                {
                                    Liquid.AddWater(Player.tileTargetX, Player.tileTargetY);
                                }
                                for (int num29 = Player.tileTargetX - 1; num29 <= (Player.tileTargetX + 1); num29++)
                                {
                                    for (int num30 = Player.tileTargetY - 1; num30 <= (Player.tileTargetY + 1); num30++)
                                    {
                                        if ((liquid < 0x100) && (Main.tile[num29, num30].lava == lava))
                                        {
                                            int num31 = Main.tile[num29, num30].liquid;
                                            if ((num31 + liquid) > 0xff)
                                            {
                                                num31 = 0xff - liquid;
                                            }
                                            liquid += num31;
                                            Tile tile1 = Main.tile[num29, num30];
                                            tile1.liquid = (byte) (tile1.liquid - ((byte) num31));
                                            Main.tile[num29, num30].lava = flag6;
                                            if (Main.tile[num29, num30].liquid == 0)
                                            {
                                                Main.tile[num29, num30].lava = false;
                                            }
                                            WorldGen.SquareTileFrame(num29, num30, false);
                                            if (Main.netMode == 1)
                                            {
                                                NetMessage.sendWater(num29, num30);
                                            }
                                            else
                                            {
                                                Liquid.AddWater(num29, num30);
                                            }
                                        }
                                    }
                                }
                            }
                        }
                        else if ((Main.tile[Player.tileTargetX, Player.tileTargetY].liquid < 200) && ((!Main.tile[Player.tileTargetX, Player.tileTargetY].active || !Main.tileSolid[Main.tile[Player.tileTargetX, Player.tileTargetY].type]) || Main.tileSolidTop[Main.tile[Player.tileTargetX, Player.tileTargetY].type]))
                        {
                            if (this.inventory[this.selectedItem].type == 0xcf)
                            {
                                if ((Main.tile[Player.tileTargetX, Player.tileTargetY].liquid == 0) || Main.tile[Player.tileTargetX, Player.tileTargetY].lava)
                                {
                                    Main.PlaySound(0x13, (int) this.position.X, (int) this.position.Y, 1);
                                    Main.tile[Player.tileTargetX, Player.tileTargetY].lava = true;
                                    Main.tile[Player.tileTargetX, Player.tileTargetY].liquid = 0xff;
                                    WorldGen.SquareTileFrame(Player.tileTargetX, Player.tileTargetY, true);
                                    this.inventory[this.selectedItem].SetDefaults(0xcd, false);
                                    this.itemTime = this.inventory[this.selectedItem].useTime;
                                    if (Main.netMode == 1)
                                    {
                                        NetMessage.sendWater(Player.tileTargetX, Player.tileTargetY);
                                    }
                                }
                            }
                            else if ((Main.tile[Player.tileTargetX, Player.tileTargetY].liquid == 0) || !Main.tile[Player.tileTargetX, Player.tileTargetY].lava)
                            {
                                Main.PlaySound(0x13, (int) this.position.X, (int) this.position.Y, 1);
                                Main.tile[Player.tileTargetX, Player.tileTargetY].lava = false;
                                Main.tile[Player.tileTargetX, Player.tileTargetY].liquid = 0xff;
                                WorldGen.SquareTileFrame(Player.tileTargetX, Player.tileTargetY, true);
                                this.inventory[this.selectedItem].SetDefaults(0xcd, false);
                                this.itemTime = this.inventory[this.selectedItem].useTime;
                                if (Main.netMode == 1)
                                {
                                    NetMessage.sendWater(Player.tileTargetX, Player.tileTargetY);
                                }
                            }
                        }
                    }
                }
                if ((((this.inventory[this.selectedItem].pick > 0) || (this.inventory[this.selectedItem].axe > 0)) || (this.inventory[this.selectedItem].hammer > 0)) && ((((((this.position.X / 16f) - tileRangeX) - this.inventory[this.selectedItem].tileBoost) <= Player.tileTargetX) && ((((((this.position.X + this.width) / 16f) + tileRangeX) + this.inventory[this.selectedItem].tileBoost) - 1f) >= Player.tileTargetX)) && (((((this.position.Y / 16f) - tileRangeY) - this.inventory[this.selectedItem].tileBoost) <= Player.tileTargetY) && ((((((this.position.Y + this.height) / 16f) + tileRangeY) + this.inventory[this.selectedItem].tileBoost) - 2f) >= Player.tileTargetY))))
                {
                    this.showItemIcon = true;
                    if ((Main.tile[Player.tileTargetX, Player.tileTargetY].active && (this.itemTime == 0)) && ((this.itemAnimation > 0) && this.controlUseItem))
                    {
                        if ((this.hitTileX != Player.tileTargetX) || (this.hitTileY != Player.tileTargetY))
                        {
                            this.hitTile = 0;
                            this.hitTileX = Player.tileTargetX;
                            this.hitTileY = Player.tileTargetY;
                        }
                        if (Main.tileNoFail[Main.tile[Player.tileTargetX, Player.tileTargetY].type])
                        {
                            this.hitTile = 100;
                        }
                        if (Main.tile[Player.tileTargetX, Player.tileTargetY].type != 0x1b)
                        {
                            if (((((((Main.tile[Player.tileTargetX, Player.tileTargetY].type == 4) || (Main.tile[Player.tileTargetX, Player.tileTargetY].type == 10)) || ((Main.tile[Player.tileTargetX, Player.tileTargetY].type == 11) || (Main.tile[Player.tileTargetX, Player.tileTargetY].type == 12))) || (((Main.tile[Player.tileTargetX, Player.tileTargetY].type == 13) || (Main.tile[Player.tileTargetX, Player.tileTargetY].type == 14)) || ((Main.tile[Player.tileTargetX, Player.tileTargetY].type == 15) || (Main.tile[Player.tileTargetX, Player.tileTargetY].type == 0x10)))) || ((((Main.tile[Player.tileTargetX, Player.tileTargetY].type == 0x11) || (Main.tile[Player.tileTargetX, Player.tileTargetY].type == 0x12)) || ((Main.tile[Player.tileTargetX, Player.tileTargetY].type == 0x13) || (Main.tile[Player.tileTargetX, Player.tileTargetY].type == 0x15))) || (((Main.tile[Player.tileTargetX, Player.tileTargetY].type == 0x1a) || (Main.tile[Player.tileTargetX, Player.tileTargetY].type == 0x1c)) || ((Main.tile[Player.tileTargetX, Player.tileTargetY].type == 0x1d) || (Main.tile[Player.tileTargetX, Player.tileTargetY].type == 0x1f))))) || (((((Main.tile[Player.tileTargetX, Player.tileTargetY].type == 0x21) || (Main.tile[Player.tileTargetX, Player.tileTargetY].type == 0x22)) || ((Main.tile[Player.tileTargetX, Player.tileTargetY].type == 0x23) || (Main.tile[Player.tileTargetX, Player.tileTargetY].type == 0x24))) || (((Main.tile[Player.tileTargetX, Player.tileTargetY].type == 0x2a) || (Main.tile[Player.tileTargetX, Player.tileTargetY].type == 0x30)) || ((Main.tile[Player.tileTargetX, Player.tileTargetY].type == 0x31) || (Main.tile[Player.tileTargetX, Player.tileTargetY].type == 50)))) || ((((Main.tile[Player.tileTargetX, Player.tileTargetY].type == 0x36) || (Main.tile[Player.tileTargetX, Player.tileTargetY].type == 0x37)) || ((Main.tile[Player.tileTargetX, Player.tileTargetY].type == 0x4d) || (Main.tile[Player.tileTargetX, Player.tileTargetY].type == 0x4e))) || (((Main.tile[Player.tileTargetX, Player.tileTargetY].type == 0x4f) || (Main.tile[Player.tileTargetX, Player.tileTargetY].type == 0x51)) || ((Main.tile[Player.tileTargetX, Player.tileTargetY].type == 0x55) || (Main.tile[Player.tileTargetX, Player.tileTargetY].type == 0x56)))))) || (((((Main.tile[Player.tileTargetX, Player.tileTargetY].type == 0x57) || (Main.tile[Player.tileTargetX, Player.tileTargetY].type == 0x58)) || ((Main.tile[Player.tileTargetX, Player.tileTargetY].type == 0x59) || (Main.tile[Player.tileTargetX, Player.tileTargetY].type == 90))) || (((Main.tile[Player.tileTargetX, Player.tileTargetY].type == 0x5b) || (Main.tile[Player.tileTargetX, Player.tileTargetY].type == 0x5c)) || ((Main.tile[Player.tileTargetX, Player.tileTargetY].type == 0x5d) || (Main.tile[Player.tileTargetX, Player.tileTargetY].type == 0x5e)))) || (((((Main.tile[Player.tileTargetX, Player.tileTargetY].type == 0x5f) || (Main.tile[Player.tileTargetX, Player.tileTargetY].type == 0x60)) || ((Main.tile[Player.tileTargetX, Player.tileTargetY].type == 0x61) || (Main.tile[Player.tileTargetX, Player.tileTargetY].type == 0x62))) || (((Main.tile[Player.tileTargetX, Player.tileTargetY].type == 0x63) || (Main.tile[Player.tileTargetX, Player.tileTargetY].type == 100)) || ((Main.tile[Player.tileTargetX, Player.tileTargetY].type == 0x65) || (Main.tile[Player.tileTargetX, Player.tileTargetY].type == 0x66)))) || (((Main.tile[Player.tileTargetX, Player.tileTargetY].type == 0x67) || (Main.tile[Player.tileTargetX, Player.tileTargetY].type == 0x68)) || ((Main.tile[Player.tileTargetX, Player.tileTargetY].type == 0x69) || (Main.tile[Player.tileTargetX, Player.tileTargetY].type == 0x6a))))))
                            {
                                if (Main.tile[Player.tileTargetX, Player.tileTargetY].type == 0x30)
                                {
                                    this.hitTile += this.inventory[this.selectedItem].hammer / 2;
                                }
                                else
                                {
                                    this.hitTile += this.inventory[this.selectedItem].hammer;
                                }
                                if (((Player.tileTargetY > Main.rockLayer) && (Main.tile[Player.tileTargetX, Player.tileTargetY].type == 0x4d)) && (this.inventory[this.selectedItem].hammer < 60))
                                {
                                    this.hitTile = 0;
                                }
                                if (this.inventory[this.selectedItem].hammer > 0)
                                {
                                    if (Main.tile[Player.tileTargetX, Player.tileTargetY].type == 0x1a)
                                    {
                                        this.Hurt(this.statLife / 2, -this.direction, false, false, getDeathMessage(-1, -1, -1, 4), false);
                                        WorldGen.KillTile(Player.tileTargetX, Player.tileTargetY, true, false, false);
                                        if (Main.netMode == 1)
                                        {
                                            NetMessage.SendData(0x11, -1, -1, "", 0, (float) Player.tileTargetX, (float) Player.tileTargetY, 1f, 0);
                                        }
                                    }
                                    else if (this.hitTile >= 100)
                                    {
                                        if ((Main.netMode == 1) && (Main.tile[Player.tileTargetX, Player.tileTargetY].type == 0x15))
                                        {
                                            WorldGen.KillTile(Player.tileTargetX, Player.tileTargetY, true, false, false);
                                            NetMessage.SendData(0x11, -1, -1, "", 0, (float) Player.tileTargetX, (float) Player.tileTargetY, 1f, 0);
                                            NetMessage.SendData(0x22, -1, -1, "", Player.tileTargetX, (float) Player.tileTargetY, 0f, 0f, 0);
                                        }
                                        else
                                        {
                                            this.hitTile = 0;
                                            WorldGen.KillTile(Player.tileTargetX, Player.tileTargetY, false, false, false);
                                            if (Main.netMode == 1)
                                            {
                                                NetMessage.SendData(0x11, -1, -1, "", 0, (float) Player.tileTargetX, (float) Player.tileTargetY, 0f, 0);
                                            }
                                        }
                                    }
                                    else
                                    {
                                        WorldGen.KillTile(Player.tileTargetX, Player.tileTargetY, true, false, false);
                                        if (Main.netMode == 1)
                                        {
                                            NetMessage.SendData(0x11, -1, -1, "", 0, (float) Player.tileTargetX, (float) Player.tileTargetY, 1f, 0);
                                        }
                                    }
                                    this.itemTime = this.inventory[this.selectedItem].useTime;
                                }
                            }
                            else if (((Main.tile[Player.tileTargetX, Player.tileTargetY].type == 5) || (Main.tile[Player.tileTargetX, Player.tileTargetY].type == 30)) || ((Main.tile[Player.tileTargetX, Player.tileTargetY].type == 0x48) || (Main.tile[Player.tileTargetX, Player.tileTargetY].type == 80)))
                            {
                                if (Main.tile[Player.tileTargetX, Player.tileTargetY].type == 30)
                                {
                                    this.hitTile += this.inventory[this.selectedItem].axe * 5;
                                }
                                else if (Main.tile[Player.tileTargetX, Player.tileTargetY].type == 80)
                                {
                                    this.hitTile += this.inventory[this.selectedItem].axe * 3;
                                }
                                else
                                {
                                    this.hitTile += this.inventory[this.selectedItem].axe;
                                }
                                if (this.inventory[this.selectedItem].axe > 0)
                                {
                                    if (this.hitTile >= 100)
                                    {
                                        this.hitTile = 0;
                                        WorldGen.KillTile(Player.tileTargetX, Player.tileTargetY, false, false, false);
                                        if (Main.netMode == 1)
                                        {
                                            NetMessage.SendData(0x11, -1, -1, "", 0, (float) Player.tileTargetX, (float) Player.tileTargetY, 0f, 0);
                                        }
                                    }
                                    else
                                    {
                                        WorldGen.KillTile(Player.tileTargetX, Player.tileTargetY, true, false, false);
                                        if (Main.netMode == 1)
                                        {
                                            NetMessage.SendData(0x11, -1, -1, "", 0, (float) Player.tileTargetX, (float) Player.tileTargetY, 1f, 0);
                                        }
                                    }
                                    this.itemTime = this.inventory[this.selectedItem].useTime;
                                }
                            }
                            else if (this.inventory[this.selectedItem].pick > 0)
                            {
                                if ((Main.tileDungeon[Main.tile[Player.tileTargetX, Player.tileTargetY].type] || (Main.tile[Player.tileTargetX, Player.tileTargetY].type == 0x25)) || ((Main.tile[Player.tileTargetX, Player.tileTargetY].type == 0x19) || (Main.tile[Player.tileTargetX, Player.tileTargetY].type == 0x3a)))
                                {
                                    this.hitTile += this.inventory[this.selectedItem].pick / 2;
                                }
                                else
                                {
                                    this.hitTile += this.inventory[this.selectedItem].pick;
                                }
                                if ((Main.tile[Player.tileTargetX, Player.tileTargetY].type == 0x19) && (this.inventory[this.selectedItem].pick < 0x41))
                                {
                                    this.hitTile = 0;
                                }
                                else if ((Main.tile[Player.tileTargetX, Player.tileTargetY].type == 0x25) && (this.inventory[this.selectedItem].pick < 0x37))
                                {
                                    this.hitTile = 0;
                                }
                                else if (((Main.tile[Player.tileTargetX, Player.tileTargetY].type == 0x16) && (Player.tileTargetY > Main.worldSurface)) && (this.inventory[this.selectedItem].pick < 0x37))
                                {
                                    this.hitTile = 0;
                                }
                                else if ((Main.tile[Player.tileTargetX, Player.tileTargetY].type == 0x38) && (this.inventory[this.selectedItem].pick < 0x41))
                                {
                                    this.hitTile = 0;
                                }
                                else if ((Main.tile[Player.tileTargetX, Player.tileTargetY].type == 0x3a) && (this.inventory[this.selectedItem].pick < 0x41))
                                {
                                    this.hitTile = 0;
                                }
                                else if ((Main.tileDungeon[Main.tile[Player.tileTargetX, Player.tileTargetY].type] && (this.inventory[this.selectedItem].pick < 0x41)) && ((Player.tileTargetX < (Main.maxTilesX * 0.25)) || (Player.tileTargetX > (Main.maxTilesX * 0.75))))
                                {
                                    this.hitTile = 0;
                                }
                                if (((Main.tile[Player.tileTargetX, Player.tileTargetY].type == 0) || (Main.tile[Player.tileTargetX, Player.tileTargetY].type == 40)) || (((Main.tile[Player.tileTargetX, Player.tileTargetY].type == 0x35) || (Main.tile[Player.tileTargetX, Player.tileTargetY].type == 0x39)) || (Main.tile[Player.tileTargetX, Player.tileTargetY].type == 0x3b)))
                                {
                                    this.hitTile += this.inventory[this.selectedItem].pick;
                                }
                                if (this.hitTile >= 100)
                                {
                                    this.hitTile = 0;
                                    WorldGen.KillTile(Player.tileTargetX, Player.tileTargetY, false, false, false);
                                    if (Main.netMode == 1)
                                    {
                                        NetMessage.SendData(0x11, -1, -1, "", 0, (float) Player.tileTargetX, (float) Player.tileTargetY, 0f, 0);
                                    }
                                }
                                else
                                {
                                    WorldGen.KillTile(Player.tileTargetX, Player.tileTargetY, true, false, false);
                                    if (Main.netMode == 1)
                                    {
                                        NetMessage.SendData(0x11, -1, -1, "", 0, (float) Player.tileTargetX, (float) Player.tileTargetY, 1f, 0);
                                    }
                                }
                                this.itemTime = this.inventory[this.selectedItem].useTime;
                            }
                        }
                    }
                    if ((((Main.tile[Player.tileTargetX, Player.tileTargetY].wall > 0) && (this.itemTime == 0)) && ((this.itemAnimation > 0) && this.controlUseItem)) && (this.inventory[this.selectedItem].hammer > 0))
                    {
                        bool flag7 = true;
                        if (!Main.wallHouse[Main.tile[Player.tileTargetX, Player.tileTargetY].wall])
                        {
                            flag7 = false;
                            for (int num32 = Player.tileTargetX - 1; num32 < (Player.tileTargetX + 2); num32++)
                            {
                                for (int num33 = Player.tileTargetY - 1; num33 < (Player.tileTargetY + 2); num33++)
                                {
                                    if (Main.tile[num32, num33].wall != Main.tile[Player.tileTargetX, Player.tileTargetY].wall)
                                    {
                                        flag7 = true;
                                        break;
                                    }
                                }
                            }
                        }
                        if (flag7)
                        {
                            if ((this.hitTileX != Player.tileTargetX) || (this.hitTileY != Player.tileTargetY))
                            {
                                this.hitTile = 0;
                                this.hitTileX = Player.tileTargetX;
                                this.hitTileY = Player.tileTargetY;
                            }
                            this.hitTile += (int) (this.inventory[this.selectedItem].hammer * 1.5f);
                            if (this.hitTile >= 100)
                            {
                                this.hitTile = 0;
                                WorldGen.KillWall(Player.tileTargetX, Player.tileTargetY, false);
                                if (Main.netMode == 1)
                                {
                                    NetMessage.SendData(0x11, -1, -1, "", 2, (float) Player.tileTargetX, (float) Player.tileTargetY, 0f, 0);
                                }
                            }
                            else
                            {
                                WorldGen.KillWall(Player.tileTargetX, Player.tileTargetY, true);
                                if (Main.netMode == 1)
                                {
                                    NetMessage.SendData(0x11, -1, -1, "", 2, (float) Player.tileTargetX, (float) Player.tileTargetY, 1f, 0);
                                }
                            }
                            this.itemTime = this.inventory[this.selectedItem].useTime / 2;
                        }
                    }
                }
                if (((this.inventory[this.selectedItem].type == 0x1d) && (this.itemAnimation > 0)) && ((this.statLifeMax < 400) && (this.itemTime == 0)))
                {
                    this.itemTime = this.inventory[this.selectedItem].useTime;
                    this.statLifeMax += 20;
                    this.statLife += 20;
                    if (Main.myPlayer == this.whoAmi)
                    {
                        this.HealEffect(20);
                    }
                }
                if (((this.inventory[this.selectedItem].type == 0x6d) && (this.itemAnimation > 0)) && ((this.statManaMax < 200) && (this.itemTime == 0)))
                {
                    this.itemTime = this.inventory[this.selectedItem].useTime;
                    this.statManaMax += 20;
                    this.statMana += 20;
                    if (Main.myPlayer == this.whoAmi)
                    {
                        this.ManaEffect(20);
                    }
                }
                if ((((this.inventory[this.selectedItem].createTile >= 0) && ((((this.position.X / 16f) - tileRangeX) - this.inventory[this.selectedItem].tileBoost) <= Player.tileTargetX)) && (((((((this.position.X + this.width) / 16f) + tileRangeX) + this.inventory[this.selectedItem].tileBoost) - 1f) >= Player.tileTargetX) && ((((this.position.Y / 16f) - tileRangeY) - this.inventory[this.selectedItem].tileBoost) <= Player.tileTargetY))) && ((((((this.position.Y + this.height) / 16f) + tileRangeY) + this.inventory[this.selectedItem].tileBoost) - 2f) >= Player.tileTargetY))
                {
                    this.showItemIcon = true;
                    bool flag8 = false;
                    if ((Main.tile[Player.tileTargetX, Player.tileTargetY].liquid > 0) && Main.tile[Player.tileTargetX, Player.tileTargetY].lava)
                    {
                        if (Main.tileSolid[this.inventory[this.selectedItem].createTile])
                        {
                            flag8 = true;
                        }
                        else if (Main.tileLavaDeath[this.inventory[this.selectedItem].createTile])
                        {
                            flag8 = true;
                        }
                    }
                    if (((!Main.tile[Player.tileTargetX, Player.tileTargetY].active && !flag8) || (((this.inventory[this.selectedItem].createTile == 0x17) || (this.inventory[this.selectedItem].createTile == 2)) || ((this.inventory[this.selectedItem].createTile == 60) || (this.inventory[this.selectedItem].createTile == 70)))) && (((this.itemTime == 0) && (this.itemAnimation > 0)) && this.controlUseItem))
                    {
                        bool flag9 = false;
                        if ((this.inventory[this.selectedItem].createTile == 0x17) || (this.inventory[this.selectedItem].createTile == 2))
                        {
                            if (Main.tile[Player.tileTargetX, Player.tileTargetY].active && (Main.tile[Player.tileTargetX, Player.tileTargetY].type == 0))
                            {
                                flag9 = true;
                            }
                        }
                        else if ((this.inventory[this.selectedItem].createTile == 60) || (this.inventory[this.selectedItem].createTile == 70))
                        {
                            if (Main.tile[Player.tileTargetX, Player.tileTargetY].active && (Main.tile[Player.tileTargetX, Player.tileTargetY].type == 0x3b))
                            {
                                flag9 = true;
                            }
                        }
                        else if (this.inventory[this.selectedItem].createTile == 4)
                        {
                            int type = Main.tile[Player.tileTargetX, Player.tileTargetY + 1].type;
                            int index = Main.tile[Player.tileTargetX - 1, Player.tileTargetY].type;
                            int num36 = Main.tile[Player.tileTargetX + 1, Player.tileTargetY].type;
                            int num37 = Main.tile[Player.tileTargetX - 1, Player.tileTargetY - 1].type;
                            int num38 = Main.tile[Player.tileTargetX + 1, Player.tileTargetY - 1].type;
                            int num39 = Main.tile[Player.tileTargetX - 1, Player.tileTargetY - 1].type;
                            int num40 = Main.tile[Player.tileTargetX + 1, Player.tileTargetY + 1].type;
                            if (!Main.tile[Player.tileTargetX, Player.tileTargetY + 1].active)
                            {
                                type = -1;
                            }
                            if (!Main.tile[Player.tileTargetX - 1, Player.tileTargetY].active)
                            {
                                index = -1;
                            }
                            if (!Main.tile[Player.tileTargetX + 1, Player.tileTargetY].active)
                            {
                                num36 = -1;
                            }
                            if (!Main.tile[Player.tileTargetX - 1, Player.tileTargetY - 1].active)
                            {
                                num37 = -1;
                            }
                            if (!Main.tile[Player.tileTargetX + 1, Player.tileTargetY - 1].active)
                            {
                                num38 = -1;
                            }
                            if (!Main.tile[Player.tileTargetX - 1, Player.tileTargetY + 1].active)
                            {
                                num39 = -1;
                            }
                            if (!Main.tile[Player.tileTargetX + 1, Player.tileTargetY + 1].active)
                            {
                                num40 = -1;
                            }
                            if (((type >= 0) && Main.tileSolid[type]) && !Main.tileNoAttach[type])
                            {
                                flag9 = true;
                            }
                            else if ((((index >= 0) && Main.tileSolid[index]) && !Main.tileNoAttach[index]) || (((index == 5) && (num37 == 5)) && (num39 == 5)))
                            {
                                flag9 = true;
                            }
                            else if ((((num36 >= 0) && Main.tileSolid[num36]) && !Main.tileNoAttach[num36]) || (((num36 == 5) && (num38 == 5)) && (num40 == 5)))
                            {
                                flag9 = true;
                            }
                        }
                        else if (((this.inventory[this.selectedItem].createTile == 0x4e) || (this.inventory[this.selectedItem].createTile == 0x62)) || (this.inventory[this.selectedItem].createTile == 100))
                        {
                            if (Main.tile[Player.tileTargetX, Player.tileTargetY + 1].active && (Main.tileSolid[Main.tile[Player.tileTargetX, Player.tileTargetY + 1].type] || Main.tileTable[Main.tile[Player.tileTargetX, Player.tileTargetY + 1].type]))
                            {
                                flag9 = true;
                            }
                        }
                        else if ((((this.inventory[this.selectedItem].createTile == 13) || (this.inventory[this.selectedItem].createTile == 0x1d)) || ((this.inventory[this.selectedItem].createTile == 0x21) || (this.inventory[this.selectedItem].createTile == 0x31))) || ((this.inventory[this.selectedItem].createTile == 50) || (this.inventory[this.selectedItem].createTile == 0x67)))
                        {
                            if (Main.tile[Player.tileTargetX, Player.tileTargetY + 1].active && Main.tileTable[Main.tile[Player.tileTargetX, Player.tileTargetY + 1].type])
                            {
                                flag9 = true;
                            }
                        }
                        else if (this.inventory[this.selectedItem].createTile == 0x33)
                        {
                            if (((Main.tile[Player.tileTargetX + 1, Player.tileTargetY].active || (Main.tile[Player.tileTargetX + 1, Player.tileTargetY].wall > 0)) || (Main.tile[Player.tileTargetX - 1, Player.tileTargetY].active || (Main.tile[Player.tileTargetX - 1, Player.tileTargetY].wall > 0))) || ((Main.tile[Player.tileTargetX, Player.tileTargetY + 1].active || (Main.tile[Player.tileTargetX, Player.tileTargetY + 1].wall > 0)) || (Main.tile[Player.tileTargetX, Player.tileTargetY - 1].active || (Main.tile[Player.tileTargetX, Player.tileTargetY - 1].wall > 0))))
                            {
                                flag9 = true;
                            }
                        }
                        else if (((Main.tile[Player.tileTargetX + 1, Player.tileTargetY].active && Main.tileSolid[Main.tile[Player.tileTargetX + 1, Player.tileTargetY].type]) || ((Main.tile[Player.tileTargetX + 1, Player.tileTargetY].wall > 0) || (Main.tile[Player.tileTargetX - 1, Player.tileTargetY].active && Main.tileSolid[Main.tile[Player.tileTargetX - 1, Player.tileTargetY].type]))) || ((((Main.tile[Player.tileTargetX - 1, Player.tileTargetY].wall > 0) || (Main.tile[Player.tileTargetX, Player.tileTargetY + 1].active && Main.tileSolid[Main.tile[Player.tileTargetX, Player.tileTargetY + 1].type])) || ((Main.tile[Player.tileTargetX, Player.tileTargetY + 1].wall > 0) || (Main.tile[Player.tileTargetX, Player.tileTargetY - 1].active && Main.tileSolid[Main.tile[Player.tileTargetX, Player.tileTargetY - 1].type]))) || (Main.tile[Player.tileTargetX, Player.tileTargetY - 1].wall > 0)))
                        {
                            flag9 = true;
                        }
                        if (Main.tileAlch[this.inventory[this.selectedItem].createTile])
                        {
                            flag9 = true;
                        }
                        if (flag9 && WorldGen.PlaceTile(Player.tileTargetX, Player.tileTargetY, this.inventory[this.selectedItem].createTile, false, false, this.whoAmi, this.inventory[this.selectedItem].placeStyle))
                        {
                            this.itemTime = this.inventory[this.selectedItem].useTime;
                            if (Main.netMode == 1)
                            {
                                NetMessage.SendData(0x11, -1, -1, "", 1, (float) Player.tileTargetX, (float) Player.tileTargetY, (float) this.inventory[this.selectedItem].createTile, this.inventory[this.selectedItem].placeStyle);
                            }
                            if (this.inventory[this.selectedItem].createTile == 15)
                            {
                                if (this.direction == 1)
                                {
                                    Tile tile2 = Main.tile[Player.tileTargetX, Player.tileTargetY];
                                    tile2.frameX = (short) (tile2.frameX + 0x12);
                                    Tile tile3 = Main.tile[Player.tileTargetX, Player.tileTargetY - 1];
                                    tile3.frameX = (short) (tile3.frameX + 0x12);
                                }
                                if (Main.netMode == 1)
                                {
                                    NetMessage.SendTileSquare(-1, Player.tileTargetX - 1, Player.tileTargetY - 1, 3);
                                }
                            }
                            else if (((this.inventory[this.selectedItem].createTile == 0x4f) || (this.inventory[this.selectedItem].createTile == 90)) && (Main.netMode == 1))
                            {
                                NetMessage.SendTileSquare(-1, Player.tileTargetX, Player.tileTargetY, 5);
                            }
                        }
                    }
                }
                if (this.inventory[this.selectedItem].createWall >= 0)
                {
                    Player.tileTargetX = (int) ((Main.mouseState.X + Main.screenPosition.X) / 16f);
                    Player.tileTargetY = (int) ((Main.mouseState.Y + Main.screenPosition.Y) / 16f);
                    if ((((((this.position.X / 16f) - tileRangeX) - this.inventory[this.selectedItem].tileBoost) <= Player.tileTargetX) && ((((((this.position.X + this.width) / 16f) + tileRangeX) + this.inventory[this.selectedItem].tileBoost) - 1f) >= Player.tileTargetX)) && (((((this.position.Y / 16f) - tileRangeY) - this.inventory[this.selectedItem].tileBoost) <= Player.tileTargetY) && ((((((this.position.Y + this.height) / 16f) + tileRangeY) + this.inventory[this.selectedItem].tileBoost) - 2f) >= Player.tileTargetY)))
                    {
                        this.showItemIcon = true;
                        if (((((this.itemTime == 0) && (this.itemAnimation > 0)) && this.controlUseItem) && (((Main.tile[Player.tileTargetX + 1, Player.tileTargetY].active || (Main.tile[Player.tileTargetX + 1, Player.tileTargetY].wall > 0)) || (Main.tile[Player.tileTargetX - 1, Player.tileTargetY].active || (Main.tile[Player.tileTargetX - 1, Player.tileTargetY].wall > 0))) || ((Main.tile[Player.tileTargetX, Player.tileTargetY + 1].active || (Main.tile[Player.tileTargetX, Player.tileTargetY + 1].wall > 0)) || (Main.tile[Player.tileTargetX, Player.tileTargetY - 1].active || (Main.tile[Player.tileTargetX, Player.tileTargetY - 1].wall > 0))))) && (Main.tile[Player.tileTargetX, Player.tileTargetY].wall != this.inventory[this.selectedItem].createWall))
                        {
                            WorldGen.PlaceWall(Player.tileTargetX, Player.tileTargetY, this.inventory[this.selectedItem].createWall, false);
                            if (Main.tile[Player.tileTargetX, Player.tileTargetY].wall == this.inventory[this.selectedItem].createWall)
                            {
                                this.itemTime = this.inventory[this.selectedItem].useTime;
                                if (Main.netMode == 1)
                                {
                                    NetMessage.SendData(0x11, -1, -1, "", 3, (float) Player.tileTargetX, (float) Player.tileTargetY, (float) this.inventory[this.selectedItem].createWall, 0);
                                }
                                if (this.inventory[this.selectedItem].stack > 1)
                                {
                                    int createWall = this.inventory[this.selectedItem].createWall;
                                    for (int num42 = 0; num42 < 4; num42++)
                                    {
                                        int tileTargetX = Player.tileTargetX;
                                        int tileTargetY = Player.tileTargetY;
                                        switch (num42)
                                        {
                                            case 0:
                                                tileTargetX--;
                                                break;

                                            case 1:
                                                tileTargetX++;
                                                break;

                                            case 2:
                                                tileTargetY--;
                                                break;

                                            case 3:
                                                tileTargetY++;
                                                break;
                                        }
                                        if (Main.tile[tileTargetX, tileTargetY].wall == 0)
                                        {
                                            int num45 = 0;
                                            for (int num46 = 0; num46 < 4; num46++)
                                            {
                                                int num47 = tileTargetX;
                                                int num48 = tileTargetY;
                                                switch (num46)
                                                {
                                                    case 0:
                                                        num47--;
                                                        break;

                                                    case 1:
                                                        num47++;
                                                        break;

                                                    case 2:
                                                        num48--;
                                                        break;

                                                    case 3:
                                                        num48++;
                                                        break;
                                                }
                                                if (Main.tile[num47, num48].wall == createWall)
                                                {
                                                    num45++;
                                                }
                                            }
                                            if (num45 == 4)
                                            {
                                                WorldGen.PlaceWall(tileTargetX, tileTargetY, createWall, false);
                                                if (Main.tile[tileTargetX, tileTargetY].wall == createWall)
                                                {
                                                    Item item1 = this.inventory[this.selectedItem];
                                                    item1.stack--;
                                                    if (this.inventory[this.selectedItem].stack == 0)
                                                    {
                                                        this.inventory[this.selectedItem].SetDefaults(0, false);
                                                    }
                                                    if (Main.netMode == 1)
                                                    {
                                                        NetMessage.SendData(0x11, -1, -1, "", 3, (float) tileTargetX, (float) tileTargetY, (float) createWall, 0);
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
            if (((this.inventory[this.selectedItem].damage >= 0) && (this.inventory[this.selectedItem].type > 0)) && (!this.inventory[this.selectedItem].noMelee && (this.itemAnimation > 0)))
            {
                bool flag10 = false;
                Rectangle rectangle = new Rectangle((int) this.itemLocation.X, (int) this.itemLocation.Y, 0x20, 0x20);
                if (!Main.dedServ)
                {
                    rectangle = new Rectangle((int) this.itemLocation.X, (int) this.itemLocation.Y, Main.itemTexture[this.inventory[this.selectedItem].type].Width, Main.itemTexture[this.inventory[this.selectedItem].type].Height);
                }
                rectangle.Width = (int) (rectangle.Width * this.inventory[this.selectedItem].scale);
                rectangle.Height = (int) (rectangle.Height * this.inventory[this.selectedItem].scale);
                if (this.direction == -1)
                {
                    rectangle.X -= rectangle.Width;
                }
                if (this.gravDir == 1f)
                {
                    rectangle.Y -= rectangle.Height;
                }
                if (this.inventory[this.selectedItem].useStyle == 1)
                {
                    if (this.itemAnimation < (this.itemAnimationMax * 0.333))
                    {
                        if (this.direction == -1)
                        {
                            rectangle.X -= ((int) (rectangle.Width * 1.4)) - rectangle.Width;
                        }
                        rectangle.Width = (int) (rectangle.Width * 1.4);
                        rectangle.Y += (int) ((rectangle.Height * 0.5) * this.gravDir);
                        rectangle.Height = (int) (rectangle.Height * 1.1);
                    }
                    else if (this.itemAnimation >= (this.itemAnimationMax * 0.666))
                    {
                        if (this.direction == 1)
                        {
                            rectangle.X -= (int) (rectangle.Width * 1.2);
                        }
                        rectangle.Width *= 2;
                        rectangle.Y -= (int) (((rectangle.Height * 1.4) - rectangle.Height) * this.gravDir);
                        rectangle.Height = (int) (rectangle.Height * 1.4);
                    }
                }
                else if (this.inventory[this.selectedItem].useStyle == 3)
                {
                    if (this.itemAnimation > (this.itemAnimationMax * 0.666))
                    {
                        flag10 = true;
                    }
                    else
                    {
                        if (this.direction == -1)
                        {
                            rectangle.X -= ((int) (rectangle.Width * 1.4)) - rectangle.Width;
                        }
                        rectangle.Width = (int) (rectangle.Width * 1.4);
                        rectangle.Y += (int) (rectangle.Height * 0.6);
                        rectangle.Height = (int) (rectangle.Height * 0.6);
                    }
                }
                float gravDir = this.gravDir;
                if (!flag10)
                {
                    if ((((this.inventory[this.selectedItem].type == 0x2c) || (this.inventory[this.selectedItem].type == 0x2d)) || (((this.inventory[this.selectedItem].type == 0x2e) || (this.inventory[this.selectedItem].type == 0x67)) || (this.inventory[this.selectedItem].type == 0x68))) && (Main.rand.Next(15) == 0))
                    {
                        color = new Color();
                        Dust.NewDust(new Vector2((float) rectangle.X, (float) rectangle.Y), rectangle.Width, rectangle.Height, 14, (float) (this.direction * 2), 0f, 150, color, 1.3f);
                    }
                    if (this.inventory[this.selectedItem].type == 0x111)
                    {
                        if (Main.rand.Next(5) == 0)
                        {
                            color = new Color();
                            Dust.NewDust(new Vector2((float) rectangle.X, (float) rectangle.Y), rectangle.Width, rectangle.Height, 14, (float) (this.direction * 2), 0f, 150, color, 1.4f);
                        }
                        color = new Color();
                        int num49 = Dust.NewDust(new Vector2((float) rectangle.X, (float) rectangle.Y), rectangle.Width, rectangle.Height, 0x1b, (this.velocity.X * 0.2f) + (this.direction * 3), this.velocity.Y * 0.2f, 100, color, 1.2f);
                        Main.dust[num49].noGravity = true;
                        Main.dust[num49].velocity.X /= 2f;
                        Main.dust[num49].velocity.Y /= 2f;
                    }
                    if (this.inventory[this.selectedItem].type == 0x41)
                    {
                        if (Main.rand.Next(5) == 0)
                        {
                            color = new Color();
                            Dust.NewDust(new Vector2((float) rectangle.X, (float) rectangle.Y), rectangle.Width, rectangle.Height, 15, 0f, 0f, 150, color, 1.2f);
                        }
                        if (Main.rand.Next(10) == 0)
                        {
                            Gore.NewGore(new Vector2((float) rectangle.X, (float) rectangle.Y), new Vector2(), Main.rand.Next(0x10, 0x12), 1f);
                        }
                    }
                    if ((this.inventory[this.selectedItem].type == 190) || (this.inventory[this.selectedItem].type == 0xd5))
                    {
                        color = new Color();
                        int num50 = Dust.NewDust(new Vector2((float) rectangle.X, (float) rectangle.Y), rectangle.Width, rectangle.Height, 40, (this.velocity.X * 0.2f) + (this.direction * 3), this.velocity.Y * 0.2f, 0, color, 1.2f);
                        Main.dust[num50].noGravity = true;
                    }
                    if (this.inventory[this.selectedItem].type == 0x79)
                    {
                        for (int num51 = 0; num51 < 2; num51++)
                        {
                            color = new Color();
                            int num52 = Dust.NewDust(new Vector2((float) rectangle.X, (float) rectangle.Y), rectangle.Width, rectangle.Height, 6, (this.velocity.X * 0.2f) + (this.direction * 3), this.velocity.Y * 0.2f, 100, color, 2.5f);
                            Main.dust[num52].noGravity = true;
                            Main.dust[num52].velocity.X *= 2f;
                            Main.dust[num52].velocity.Y *= 2f;
                        }
                    }
                    if ((this.inventory[this.selectedItem].type == 0x7a) || (this.inventory[this.selectedItem].type == 0xd9))
                    {
                        color = new Color();
                        int num53 = Dust.NewDust(new Vector2((float) rectangle.X, (float) rectangle.Y), rectangle.Width, rectangle.Height, 6, (this.velocity.X * 0.2f) + (this.direction * 3), this.velocity.Y * 0.2f, 100, color, 1.9f);
                        Main.dust[num53].noGravity = true;
                    }
                    if (this.inventory[this.selectedItem].type == 0x9b)
                    {
                        color = new Color();
                        int num54 = Dust.NewDust(new Vector2((float) rectangle.X, (float) rectangle.Y), rectangle.Width, rectangle.Height, 0x1d, (this.velocity.X * 0.2f) + (this.direction * 3), this.velocity.Y * 0.2f, 100, color, 2f);
                        Main.dust[num54].noGravity = true;
                        Main.dust[num54].velocity.X /= 2f;
                        Main.dust[num54].velocity.Y /= 2f;
                    }
                    if ((this.inventory[this.selectedItem].type >= 0xc6) && (this.inventory[this.selectedItem].type <= 0xcb))
                    {
                        Lighting.addLight((int) (((this.itemLocation.X + 6f) + this.velocity.X) / 16f), (int) ((this.itemLocation.Y - 14f) / 16f), 0.5f);
                    }
                    if (Main.myPlayer == i)
                    {
                        int num55 = (int) (this.inventory[this.selectedItem].damage * this.meleeDamage);
                        float num56 = this.inventory[this.selectedItem].knockBack;
                        int num57 = rectangle.X / 0x10;
                        int num58 = ((rectangle.X + rectangle.Width) / 0x10) + 1;
                        int num59 = rectangle.Y / 0x10;
                        int num60 = ((rectangle.Y + rectangle.Height) / 0x10) + 1;
                        for (int num61 = num57; num61 < num58; num61++)
                        {
                            for (int num62 = num59; num62 < num60; num62++)
                            {
                                if (((Main.tile[num61, num62] != null) && Main.tileCut[Main.tile[num61, num62].type]) && ((Main.tile[num61, num62 + 1] != null) && (Main.tile[num61, num62 + 1].type != 0x4e)))
                                {
                                    WorldGen.KillTile(num61, num62, false, false, false);
                                    if (Main.netMode == 1)
                                    {
                                        NetMessage.SendData(0x11, -1, -1, "", 0, (float) num61, (float) num62, 0f, 0);
                                    }
                                }
                            }
                        }
                        for (int num63 = 0; num63 < 0x3e8; num63++)
                        {
                            if (((Main.npc[num63].active && (Main.npc[num63].immune[i] == 0)) && ((this.attackCD == 0) && !Main.npc[num63].dontTakeDamage)) && (!Main.npc[num63].friendly || ((Main.npc[num63].type == 0x16) && this.killGuide)))
                            {
                                Rectangle rectangle2 = new Rectangle((int) Main.npc[num63].position.X, (int) Main.npc[num63].position.Y, Main.npc[num63].width, Main.npc[num63].height);
                                if (rectangle.Intersects(rectangle2) && (Main.npc[num63].noTileCollide || Collision.CanHit(this.position, this.width, this.height, Main.npc[num63].position, Main.npc[num63].width, Main.npc[num63].height)))
                                {
                                    bool crit = false;
                                    if (Main.rand.Next(1, 0x65) <= this.meleeCrit)
                                    {
                                        crit = true;
                                    }
                                    int num64 = Main.DamageVar((float) num55);
                                    this.StatusNPC(this.inventory[this.selectedItem].type, num63);
                                    Main.npc[num63].StrikeNPC(num64, num56, this.direction, crit);
                                    if (Main.netMode != 0)
                                    {
                                        if (crit)
                                        {
                                            NetMessage.SendData(0x1c, -1, -1, "", num63, (float) num64, num56, (float) this.direction, 1);
                                        }
                                        else
                                        {
                                            NetMessage.SendData(0x1c, -1, -1, "", num63, (float) num64, num56, (float) this.direction, 0);
                                        }
                                    }
                                    Main.npc[num63].immune[i] = this.itemAnimation;
                                    this.attackCD = (int) (this.itemAnimationMax * 0.33);
                                }
                            }
                        }
                        if (this.hostile)
                        {
                            for (int num65 = 0; num65 < 0xff; num65++)
                            {
                                if ((((num65 != i) && Main.player[num65].active) && (Main.player[num65].hostile && !Main.player[num65].immune)) && (!Main.player[num65].dead && ((Main.player[i].team == 0) || (Main.player[i].team != Main.player[num65].team))))
                                {
                                    Rectangle rectangle3 = new Rectangle((int) Main.player[num65].position.X, (int) Main.player[num65].position.Y, Main.player[num65].width, Main.player[num65].height);
                                    if (rectangle.Intersects(rectangle3) && Collision.CanHit(this.position, this.width, this.height, Main.player[num65].position, Main.player[num65].width, Main.player[num65].height))
                                    {
                                        bool flag12 = false;
                                        if (Main.rand.Next(1, 0x65) <= 10)
                                        {
                                            flag12 = true;
                                        }
                                        int num66 = Main.DamageVar((float) num55);
                                        this.StatusPvP(this.inventory[this.selectedItem].type, num65);
                                        Main.player[num65].Hurt(num66, this.direction, true, false, "", flag12);
                                        if (Main.netMode != 0)
                                        {
                                            if (flag12)
                                            {
                                                NetMessage.SendData(0x1a, -1, -1, getDeathMessage(this.whoAmi, -1, -1, -1), num65, (float) this.direction, (float) num66, 1f, 1);
                                            }
                                            else
                                            {
                                                NetMessage.SendData(0x1a, -1, -1, getDeathMessage(this.whoAmi, -1, -1, -1), num65, (float) this.direction, (float) num66, 1f, 0);
                                            }
                                        }
                                        this.attackCD = (int) (this.itemAnimationMax * 0.33);
                                    }
                                }
                            }
                        }
                    }
                }
            }
            if ((this.itemTime == 0) && (this.itemAnimation > 0))
            {
                if (this.inventory[this.selectedItem].healLife > 0)
                {
                    this.statLife += this.inventory[this.selectedItem].healLife;
                    this.itemTime = this.inventory[this.selectedItem].useTime;
                    if (Main.myPlayer == this.whoAmi)
                    {
                        this.HealEffect(this.inventory[this.selectedItem].healLife);
                    }
                }
                if (this.inventory[this.selectedItem].healMana > 0)
                {
                    this.statMana += this.inventory[this.selectedItem].healMana;
                    this.itemTime = this.inventory[this.selectedItem].useTime;
                    if (Main.myPlayer == this.whoAmi)
                    {
                        this.ManaEffect(this.inventory[this.selectedItem].healMana);
                    }
                }
                if (this.inventory[this.selectedItem].buffType > 0)
                {
                    if (this.whoAmi == Main.myPlayer)
                    {
                        this.AddBuff(this.inventory[this.selectedItem].buffType, this.inventory[this.selectedItem].buffTime, true);
                    }
                    this.itemTime = this.inventory[this.selectedItem].useTime;
                }
            }
            if (((this.itemTime == 0) && (this.itemAnimation > 0)) && (this.inventory[this.selectedItem].type == 0x169))
            {
                this.itemTime = this.inventory[this.selectedItem].useTime;
                Main.PlaySound(15, (int) this.position.X, (int) this.position.Y, 0);
                if ((Main.netMode != 1) && (Main.invasionType == 0))
                {
                    Main.invasionDelay = 0;
                    Main.StartInvasion();
                }
            }
            if (((this.itemTime == 0) && (this.itemAnimation > 0)) && ((this.inventory[this.selectedItem].type == 0x2b) || (this.inventory[this.selectedItem].type == 70)))
            {
                this.itemTime = this.inventory[this.selectedItem].useTime;
                bool flag13 = false;
                int num67 = 4;
                if (this.inventory[this.selectedItem].type == 0x2b)
                {
                    num67 = 4;
                }
                else if (this.inventory[this.selectedItem].type == 70)
                {
                    num67 = 13;
                }
                for (int num68 = 0; num68 < 0x3e8; num68++)
                {
                    if (Main.npc[num68].active && (Main.npc[num68].type == num67))
                    {
                        flag13 = true;
                        break;
                    }
                }
                if (flag13)
                {
                    if (Main.myPlayer == this.whoAmi)
                    {
                        this.Hurt(this.statLife * (this.statDefense + 1), -this.direction, false, false, getDeathMessage(-1, -1, -1, 3), false);
                    }
                }
                else if (this.inventory[this.selectedItem].type == 0x2b)
                {
                    if (!Main.dayTime)
                    {
                        Main.PlaySound(15, (int) this.position.X, (int) this.position.Y, 0);
                        if (Main.netMode != 1)
                        {
                            NPC.SpawnOnPlayer(i, 4);
                        }
                    }
                }
                else if ((this.inventory[this.selectedItem].type == 70) && this.zoneEvil)
                {
                    Main.PlaySound(15, (int) this.position.X, (int) this.position.Y, 0);
                    if (Main.netMode != 1)
                    {
                        NPC.SpawnOnPlayer(i, 13);
                    }
                }
            }
            if ((this.inventory[this.selectedItem].type == 50) && (this.itemAnimation > 0))
            {
                if (Main.rand.Next(2) == 0)
                {
                    color = new Color();
                    Dust.NewDust(this.position, this.width, this.height, 15, 0f, 0f, 150, color, 1.1f);
                }
                if (this.itemTime == 0)
                {
                    this.itemTime = this.inventory[this.selectedItem].useTime;
                }
                else if (this.itemTime == (this.inventory[this.selectedItem].useTime / 2))
                {
                    for (int num69 = 0; num69 < 70; num69++)
                    {
                        color = new Color();
                        Dust.NewDust(this.position, this.width, this.height, 15, this.velocity.X * 0.5f, this.velocity.Y * 0.5f, 150, color, 1.5f);
                    }
                    this.grappling[0] = -1;
                    this.grapCount = 0;
                    for (int num70 = 0; num70 < 0x3e8; num70++)
                    {
                        if ((Main.projectile[num70].active && (Main.projectile[num70].owner == i)) && (Main.projectile[num70].aiStyle == 7))
                        {
                            Main.projectile[num70].Kill();
                        }
                    }
                    this.Spawn();
                    for (int num71 = 0; num71 < 70; num71++)
                    {
                        color = new Color();
                        Dust.NewDust(this.position, this.width, this.height, 15, 0f, 0f, 150, color, 1.5f);
                    }
                }
            }
            if (i == Main.myPlayer)
            {
                if ((this.itemTime == this.inventory[this.selectedItem].useTime) && this.inventory[this.selectedItem].consumable)
                {
                    bool flag14 = true;
                    if ((this.inventory[this.selectedItem].ranged && this.ammoCost80) && (Main.rand.Next(5) == 0))
                    {
                        flag14 = false;
                    }
                    if (flag14)
                    {
                        Item item2 = this.inventory[this.selectedItem];
                        item2.stack--;
                        if (this.inventory[this.selectedItem].stack <= 0)
                        {
                            this.itemTime = this.itemAnimation;
                        }
                    }
                }
                if ((this.inventory[this.selectedItem].stack <= 0) && (this.itemAnimation == 0))
                {
                    this.inventory[this.selectedItem] = new Item();
                }
            }
        }

        public bool ItemSpace(Item newItem)
        {
            if (newItem.type == 0x3a)
            {
                return true;
            }
            if (newItem.type == 0xb8)
            {
                return true;
            }
            int num = 40;
            if (((newItem.type == 0x47) || (newItem.type == 0x48)) || ((newItem.type == 0x49) || (newItem.type == 0x4a)))
            {
                num = 0x2c;
            }
            for (int i = 0; i < num; i++)
            {
                if (this.inventory[i].type == 0)
                {
                    return true;
                }
            }
            for (int j = 0; j < num; j++)
            {
                if (((this.inventory[j].type > 0) && (this.inventory[j].stack < this.inventory[j].maxStack)) && newItem.IsTheSameAs(this.inventory[j]))
                {
                    return true;
                }
            }
            return false;
        }

        public void KillMe(double dmg, int hitDirection, bool pvp = false, string deathText = " was slain...")
        {
            if (!this.dead)
            {
                if (pvp)
                {
                    this.pvpDeath = true;
                }
                if (this.difficulty > 0)
                {
                    if (Main.netMode != 1)
                    {
                        float num = Main.rand.Next(-35, 0x24) * 0.1f;
                        while ((num < 2f) && (num > -2f))
                        {
                            num += Main.rand.Next(-30, 0x1f) * 0.1f;
                        }
                        int index = Projectile.NewProjectile(this.position.X + (this.width / 2), this.position.Y + (this.head / 2), ((Main.rand.Next(10, 30) * 0.1f) * hitDirection) + num, Main.rand.Next(-40, -20) * 0.1f, 0x2b, 50, 0f, Main.myPlayer);
                        Main.projectile[index].miscText = this.name + deathText;
                    }
                    if (Main.myPlayer == this.whoAmi)
                    {
                        if (this.difficulty == 1)
                        {
                            this.DropItems();
                        }
                        else if (this.difficulty == 2)
                        {
                            this.DropItems();
                            this.KillMeForGood();
                        }
                    }
                }
                Main.PlaySound(5, (int) this.position.X, (int) this.position.Y, 1);
                this.headVelocity.Y = Main.rand.Next(-40, -10) * 0.1f;
                this.bodyVelocity.Y = Main.rand.Next(-40, -10) * 0.1f;
                this.legVelocity.Y = Main.rand.Next(-40, -10) * 0.1f;
                this.headVelocity.X = (Main.rand.Next(-20, 0x15) * 0.1f) + (2 * hitDirection);
                this.bodyVelocity.X = (Main.rand.Next(-20, 0x15) * 0.1f) + (2 * hitDirection);
                this.legVelocity.X = (Main.rand.Next(-20, 0x15) * 0.1f) + (2 * hitDirection);
                for (int i = 0; i < (20.0 + ((dmg / ((double) this.statLifeMax)) * 100.0)); i++)
                {
                    if (this.boneArmor)
                    {
                        Color newColor = new Color();
                        Dust.NewDust(this.position, this.width, this.height, 0x1a, (float) (2 * hitDirection), -2f, 0, newColor, 1f);
                    }
                    else
                    {
                        Color color2 = new Color();
                        Dust.NewDust(this.position, this.width, this.height, 5, (float) (2 * hitDirection), -2f, 0, color2, 1f);
                    }
                }
                this.dead = true;
                this.respawnTimer = 600;
                this.immuneAlpha = 0;
                if (Main.netMode == 2)
                {
                    NetMessage.SendData(0x19, -1, -1, this.name + deathText, 0xff, 225f, 25f, 25f, 0);
                }
                if ((Main.netMode == 1) && (this.whoAmi == Main.myPlayer))
                {
                    int num4 = 0;
                    if (pvp)
                    {
                        num4 = 1;
                    }
                    NetMessage.SendData(0x2c, -1, -1, deathText, this.whoAmi, (float) hitDirection, (float) ((int) dmg), (float) num4, 0);
                }
                if ((!pvp && (this.whoAmi == Main.myPlayer)) && (this.difficulty == 0))
                {
                    this.DropCoins();
                }
                if (this.whoAmi == Main.myPlayer)
                {
                    try
                    {
                        WorldGen.saveToonWhilePlaying();
                    }
                    catch
                    {
                    }
                }
            }
        }

        public void KillMeForGood()
        {
            if (File.Exists(Main.playerPathName))
            {
                File.Delete(Main.playerPathName);
            }
            if (File.Exists(Main.playerPathName + ".bak"))
            {
                File.Delete(Main.playerPathName + ".bak");
            }
            if (File.Exists(Main.playerPathName + ".dat"))
            {
                File.Delete(Main.playerPathName + ".dat");
            }
            Main.playerPathName = "";
        }

        public static Player LoadPlayer(string playerPath)
        {
            bool flag = false;
            if (Main.rand == null)
            {
                Main.rand = new Random((int) DateTime.Now.Ticks);
            }
            Player player = new Player();
            try
            {
                string outputFile = playerPath + ".dat";
                flag = DecryptFile(playerPath, outputFile);
                if (!flag)
                {
                    using (FileStream stream = new FileStream(outputFile, FileMode.Open))
                    {
                        using (BinaryReader reader = new BinaryReader(stream))
                        {
                            int release = reader.ReadInt32();
                            player.name = reader.ReadString();
                            if (release >= 10)
                            {
                                if (release >= 0x11)
                                {
                                    player.difficulty = reader.ReadByte();
                                }
                                else if (reader.ReadBoolean())
                                {
                                    player.difficulty = 2;
                                }
                            }
                            player.hair = reader.ReadInt32();
                            if (release <= 0x11)
                            {
                                if (((player.hair == 5) || (player.hair == 6)) || ((player.hair == 9) || (player.hair == 11)))
                                {
                                    player.male = false;
                                }
                                else
                                {
                                    player.male = true;
                                }
                            }
                            else
                            {
                                player.male = reader.ReadBoolean();
                            }
                            player.statLife = reader.ReadInt32();
                            player.statLifeMax = reader.ReadInt32();
                            if (player.statLife > player.statLifeMax)
                            {
                                player.statLife = player.statLifeMax;
                            }
                            player.statMana = reader.ReadInt32();
                            player.statManaMax = reader.ReadInt32();
                            if (player.statMana > 400)
                            {
                                player.statMana = 400;
                            }
                            player.hairColor.R = reader.ReadByte();
                            player.hairColor.G = reader.ReadByte();
                            player.hairColor.B = reader.ReadByte();
                            player.skinColor.R = reader.ReadByte();
                            player.skinColor.G = reader.ReadByte();
                            player.skinColor.B = reader.ReadByte();
                            player.eyeColor.R = reader.ReadByte();
                            player.eyeColor.G = reader.ReadByte();
                            player.eyeColor.B = reader.ReadByte();
                            player.shirtColor.R = reader.ReadByte();
                            player.shirtColor.G = reader.ReadByte();
                            player.shirtColor.B = reader.ReadByte();
                            player.underShirtColor.R = reader.ReadByte();
                            player.underShirtColor.G = reader.ReadByte();
                            player.underShirtColor.B = reader.ReadByte();
                            player.pantsColor.R = reader.ReadByte();
                            player.pantsColor.G = reader.ReadByte();
                            player.pantsColor.B = reader.ReadByte();
                            player.shoeColor.R = reader.ReadByte();
                            player.shoeColor.G = reader.ReadByte();
                            player.shoeColor.B = reader.ReadByte();
                            Main.player[Main.myPlayer].shirtColor = player.shirtColor;
                            Main.player[Main.myPlayer].pantsColor = player.pantsColor;
                            Main.player[Main.myPlayer].hairColor = player.hairColor;
                            for (int i = 0; i < 8; i++)
                            {
                                player.armor[i].SetDefaults(Item.VersionName(reader.ReadString(), release));
                            }
                            if (release >= 6)
                            {
                                for (int n = 8; n < 11; n++)
                                {
                                    player.armor[n].SetDefaults(Item.VersionName(reader.ReadString(), release));
                                }
                            }
                            for (int j = 0; j < 0x2c; j++)
                            {
                                player.inventory[j].SetDefaults(Item.VersionName(reader.ReadString(), release));
                                player.inventory[j].stack = reader.ReadInt32();
                            }
                            if (release >= 15)
                            {
                                for (int num5 = 0; num5 < 4; num5++)
                                {
                                    player.ammo[num5].SetDefaults(Item.VersionName(reader.ReadString(), release));
                                    player.ammo[num5].stack = reader.ReadInt32();
                                }
                            }
                            for (int k = 0; k < Chest.maxItems; k++)
                            {
                                player.bank[k].SetDefaults(Item.VersionName(reader.ReadString(), release));
                                player.bank[k].stack = reader.ReadInt32();
                            }
                            if (release >= 20)
                            {
                                for (int num7 = 0; num7 < Chest.maxItems; num7++)
                                {
                                    player.bank2[num7].SetDefaults(Item.VersionName(reader.ReadString(), release));
                                    player.bank2[num7].stack = reader.ReadInt32();
                                }
                            }
                            if (release >= 11)
                            {
                                for (int num8 = 0; num8 < 10; num8++)
                                {
                                    player.buffType[num8] = reader.ReadInt32();
                                    player.buffTime[num8] = reader.ReadInt32();
                                }
                            }
                            for (int m = 0; m < 200; m++)
                            {
                                int num10 = reader.ReadInt32();
                                if (num10 == -1)
                                {
                                    break;
                                }
                                player.spX[m] = num10;
                                player.spY[m] = reader.ReadInt32();
                                player.spI[m] = reader.ReadInt32();
                                player.spN[m] = reader.ReadString();
                            }
                            if (release >= 0x10)
                            {
                                player.hbLocked = reader.ReadBoolean();
                            }
                            reader.Close();
                        }
                    }
                    player.PlayerFrame();
                    File.Delete(outputFile);
                    return player;
                }
            }
            catch
            {
                flag = true;
            }
            if (flag)
            {
                string path = playerPath + ".bak";
                if (File.Exists(path))
                {
                    File.Delete(playerPath);
                    File.Move(path, playerPath);
                    return LoadPlayer(playerPath);
                }
            }
            return new Player();
        }

        public void ManaEffect(int manaAmount)
        {
            CombatText.NewText(new Rectangle((int)this.position.X, (int)this.position.Y, this.width, this.height), new Color(100, 100, 0xff, 0xff), manaAmount.ToString(), false);
            if ((Main.netMode == 1) && (this.whoAmi == Main.myPlayer))
            {
                NetMessage.SendData(0x2b, -1, -1, "", this.whoAmi, (float) manaAmount, 0f, 0f, 0);
            }
        }

        public void PlayerFrame()
        {
            if (this.swimTime > 0)
            {
                this.swimTime--;
                if (!this.wet)
                {
                    this.swimTime = 0;
                }
            }
            this.head = this.armor[0].headSlot;
            this.body = this.armor[1].bodySlot;
            this.legs = this.armor[2].legSlot;
            if (!this.hostile)
            {
                if (this.armor[8].headSlot >= 0)
                {
                    this.head = this.armor[8].headSlot;
                }
                if (this.armor[9].bodySlot >= 0)
                {
                    this.body = this.armor[9].bodySlot;
                }
                if (this.armor[10].legSlot >= 0)
                {
                    this.legs = this.armor[10].legSlot;
                }
            }
            this.socialShadow = false;
            if (((this.head == 5) && (this.body == 5)) && (this.legs == 5))
            {
                this.socialShadow = true;
            }
            if (((this.head == 5) && (this.body == 5)) && ((this.legs == 5) && (Main.rand.Next(10) == 0)))
            {
                Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 14, 0f, 0f, 200, new Color(), 1.2f);
            }
            if ((((this.head == 6) && (this.body == 6)) && ((this.legs == 6) && ((Math.Abs(this.velocity.X) + Math.Abs(this.velocity.Y)) > 1f))) && !this.rocketFrame)
            {
                for (int i = 0; i < 2; i++)
                {
                    Color newColor = new Color();
                    int index = Dust.NewDust(new Vector2(this.position.X - (this.velocity.X * 2f), (this.position.Y - 2f) - (this.velocity.Y * 2f)), this.width, this.height, 6, 0f, 0f, 100, newColor, 2f);
                    Main.dust[index].noGravity = true;
                    Main.dust[index].noLight = true;
                    Main.dust[index].velocity.X -= this.velocity.X * 0.5f;
                    Main.dust[index].velocity.Y -= this.velocity.Y * 0.5f;
                }
            }
            if (((this.head == 7) && (this.body == 7)) && (this.legs == 7))
            {
                this.boneArmor = true;
            }
            if (((this.head == 8) && (this.body == 8)) && ((this.legs == 8) && ((Math.Abs(this.velocity.X) + Math.Abs(this.velocity.Y)) > 1f)))
            {
                int num3 = Dust.NewDust(new Vector2(this.position.X - (this.velocity.X * 2f), (this.position.Y - 2f) - (this.velocity.Y * 2f)), this.width, this.height, 40, 0f, 0f, 50, new Color(), 1.4f);
                Main.dust[num3].noGravity = true;
                Main.dust[num3].velocity.X = this.velocity.X * 0.25f;
                Main.dust[num3].velocity.Y = this.velocity.Y * 0.25f;
            }
            if ((((this.head == 9) && (this.body == 9)) && ((this.legs == 9) && ((Math.Abs(this.velocity.X) + Math.Abs(this.velocity.Y)) > 1f))) && !this.rocketFrame)
            {
                for (int j = 0; j < 2; j++)
                {
                    Color color4 = new Color();
                    int num5 = Dust.NewDust(new Vector2(this.position.X - (this.velocity.X * 2f), (this.position.Y - 2f) - (this.velocity.Y * 2f)), this.width, this.height, 6, 0f, 0f, 100, color4, 2f);
                    Main.dust[num5].noGravity = true;
                    Main.dust[num5].noLight = true;
                    Main.dust[num5].velocity.X -= this.velocity.X * 0.5f;
                    Main.dust[num5].velocity.Y -= this.velocity.Y * 0.5f;
                }
            }
            this.bodyFrame.Width = 40;
            this.bodyFrame.Height = 0x38;
            this.legFrame.Width = 40;
            this.legFrame.Height = 0x38;
            this.bodyFrame.X = 0;
            this.legFrame.X = 0;
            if ((this.itemAnimation > 0) && (this.inventory[this.selectedItem].useStyle != 10))
            {
                if ((this.inventory[this.selectedItem].useStyle == 1) || (this.inventory[this.selectedItem].type == 0))
                {
                    if (this.itemAnimation < (this.itemAnimationMax * 0.333))
                    {
                        this.bodyFrame.Y = this.bodyFrame.Height * 3;
                    }
                    else if (this.itemAnimation < (this.itemAnimationMax * 0.666))
                    {
                        this.bodyFrame.Y = this.bodyFrame.Height * 2;
                    }
                    else
                    {
                        this.bodyFrame.Y = this.bodyFrame.Height;
                    }
                }
                else if (this.inventory[this.selectedItem].useStyle == 2)
                {
                    if (this.itemAnimation > (this.itemAnimationMax * 0.5))
                    {
                        this.bodyFrame.Y = this.bodyFrame.Height * 3;
                    }
                    else
                    {
                        this.bodyFrame.Y = this.bodyFrame.Height * 2;
                    }
                }
                else if (this.inventory[this.selectedItem].useStyle == 3)
                {
                    if (this.itemAnimation > (this.itemAnimationMax * 0.666))
                    {
                        this.bodyFrame.Y = this.bodyFrame.Height * 3;
                    }
                    else
                    {
                        this.bodyFrame.Y = this.bodyFrame.Height * 3;
                    }
                }
                else if (this.inventory[this.selectedItem].useStyle == 4)
                {
                    this.bodyFrame.Y = this.bodyFrame.Height * 2;
                }
                else if (this.inventory[this.selectedItem].useStyle == 5)
                {
                    if (this.inventory[this.selectedItem].type == 0x119)
                    {
                        this.bodyFrame.Y = this.bodyFrame.Height * 2;
                    }
                    else
                    {
                        float num6 = this.itemRotation * this.direction;
                        this.bodyFrame.Y = this.bodyFrame.Height * 3;
                        if (num6 < -0.75)
                        {
                            this.bodyFrame.Y = this.bodyFrame.Height * 2;
                            if (this.gravDir == -1f)
                            {
                                this.bodyFrame.Y = this.bodyFrame.Height * 4;
                            }
                        }
                        if (num6 > 0.6)
                        {
                            this.bodyFrame.Y = this.bodyFrame.Height * 4;
                            if (this.gravDir == -1f)
                            {
                                this.bodyFrame.Y = this.bodyFrame.Height * 2;
                            }
                        }
                    }
                }
            }
            else if ((this.inventory[this.selectedItem].holdStyle == 1) && (!this.wet || !this.inventory[this.selectedItem].noWet))
            {
                this.bodyFrame.Y = this.bodyFrame.Height * 3;
            }
            else if ((this.inventory[this.selectedItem].holdStyle == 2) && (!this.wet || !this.inventory[this.selectedItem].noWet))
            {
                this.bodyFrame.Y = this.bodyFrame.Height * 2;
            }
            else if (this.grappling[0] >= 0)
            {
                Vector2 vector = new Vector2(this.position.X + (this.width * 0.5f), this.position.Y + (this.height * 0.5f));
                float num7 = 0f;
                float num8 = 0f;
                for (int k = 0; k < this.grapCount; k++)
                {
                    num7 += Main.projectile[this.grappling[k]].position.X + (Main.projectile[this.grappling[k]].width / 2);
                    num8 += Main.projectile[this.grappling[k]].position.Y + (Main.projectile[this.grappling[k]].height / 2);
                }
                num7 /= (float) this.grapCount;
                num8 /= (float) this.grapCount;
                num7 -= vector.X;
                num8 -= vector.Y;
                if ((num8 < 0f) && (Math.Abs(num8) > Math.Abs(num7)))
                {
                    this.bodyFrame.Y = this.bodyFrame.Height * 2;
                    if (this.gravDir == -1f)
                    {
                        this.bodyFrame.Y = this.bodyFrame.Height * 4;
                    }
                }
                else if ((num8 > 0f) && (Math.Abs(num8) > Math.Abs(num7)))
                {
                    this.bodyFrame.Y = this.bodyFrame.Height * 4;
                    if (this.gravDir == -1f)
                    {
                        this.bodyFrame.Y = this.bodyFrame.Height * 2;
                    }
                }
                else
                {
                    this.bodyFrame.Y = this.bodyFrame.Height * 3;
                }
            }
            else if (this.swimTime > 0)
            {
                if (this.swimTime > 20)
                {
                    this.bodyFrame.Y = 0;
                }
                else if (this.swimTime > 10)
                {
                    this.bodyFrame.Y = this.bodyFrame.Height * 5;
                }
                else
                {
                    this.bodyFrame.Y = 0;
                }
            }
            else if (this.velocity.Y != 0f)
            {
                this.bodyFrameCounter = 0.0;
                this.bodyFrame.Y = this.bodyFrame.Height * 5;
            }
            else if (this.velocity.X != 0f)
            {
                this.bodyFrameCounter += Math.Abs(this.velocity.X) * 1.5;
                this.bodyFrame.Y = this.legFrame.Y;
            }
            else
            {
                this.bodyFrameCounter = 0.0;
                this.bodyFrame.Y = 0;
            }
            if (this.swimTime > 0)
            {
                this.legFrameCounter += 2.0;
                while (this.legFrameCounter > 8.0)
                {
                    this.legFrameCounter -= 8.0;
                    this.legFrame.Y += this.legFrame.Height;
                }
                if (this.legFrame.Y < (this.legFrame.Height * 7))
                {
                    this.legFrame.Y = this.legFrame.Height * 0x13;
                }
                else if (this.legFrame.Y > (this.legFrame.Height * 0x13))
                {
                    this.legFrame.Y = this.legFrame.Height * 7;
                }
            }
            else if ((this.velocity.Y != 0f) || (this.grappling[0] > -1))
            {
                this.legFrameCounter = 0.0;
                this.legFrame.Y = this.legFrame.Height * 5;
            }
            else if (this.velocity.X != 0f)
            {
                this.legFrameCounter += Math.Abs(this.velocity.X) * 1.3;
                while (this.legFrameCounter > 8.0)
                {
                    this.legFrameCounter -= 8.0;
                    this.legFrame.Y += this.legFrame.Height;
                }
                if (this.legFrame.Y < (this.legFrame.Height * 7))
                {
                    this.legFrame.Y = this.legFrame.Height * 0x13;
                }
                else if (this.legFrame.Y > (this.legFrame.Height * 0x13))
                {
                    this.legFrame.Y = this.legFrame.Height * 7;
                }
            }
            else
            {
                this.legFrameCounter = 0.0;
                this.legFrame.Y = 0;
            }
        }

        public void QuickBuff()
        {
            if (!this.noItems)
            {
                int style = 0;
                for (int i = 0; i < 0x2c; i++)
                {
                    if (this.countBuffs() == 10)
                    {
                        return;
                    }
                    if (((this.inventory[i].stack > 0) && (this.inventory[i].type > 0)) && (this.inventory[i].buffType > 0))
                    {
                        bool flag = true;
                        for (int j = 0; j < 10; j++)
                        {
                            if (this.buffType[j] == this.inventory[i].buffType)
                            {
                                flag = false;
                                break;
                            }
                        }
                        if ((this.inventory[i].mana > 0) && flag)
                        {
                            if (this.statMana >= ((int) (this.inventory[i].mana * this.manaCost)))
                            {
                                this.manaRegenDelay = (int) this.maxRegenDelay;
                                this.statMana -= (int) (this.inventory[i].mana * this.manaCost);
                            }
                            else
                            {
                                flag = false;
                            }
                        }
                        if (flag)
                        {
                            style = this.inventory[i].useSound;
                            this.AddBuff(this.inventory[i].buffType, this.inventory[i].buffTime, true);
                            if (this.inventory[i].consumable)
                            {
                                Item item1 = this.inventory[i];
                                item1.stack--;
                                if (this.inventory[i].stack <= 0)
                                {
                                    this.inventory[i].type = 0;
                                    this.inventory[i].name = "";
                                }
                            }
                        }
                    }
                }
                if (style > 0)
                {
                    Main.PlaySound(2, (int) this.position.X, (int) this.position.Y, style);
                    Recipe.FindRecipes();
                }
            }
        }

        public void QuickGrapple()
        {
            if (!this.noItems)
            {
                int index = -1;
                for (int i = 0; i < 0x2c; i++)
                {
                    if ((this.inventory[i].shoot == 13) || (this.inventory[i].shoot == 0x20))
                    {
                        index = i;
                        break;
                    }
                }
                if (index >= 0)
                {
                    for (int j = 0; j < 0x3e8; j++)
                    {
                        if ((Main.projectile[j].active && (Main.projectile[j].owner == Main.myPlayer)) && ((Main.projectile[j].type == this.inventory[index].shoot) && (Main.projectile[j].ai[0] != 2f)))
                        {
                            index = -1;
                            break;
                        }
                    }
                }
                if (index >= 0)
                {
                    Main.PlaySound(2, (int) this.position.X, (int) this.position.Y, this.inventory[index].useSound);
                    if ((Main.netMode == 1) && (this.whoAmi == Main.myPlayer))
                    {
                        NetMessage.SendData(0x33, -1, -1, "", this.whoAmi, 2f, 0f, 0f, 0);
                    }
                    int shoot = this.inventory[index].shoot;
                    float shootSpeed = this.inventory[index].shootSpeed;
                    int damage = this.inventory[index].damage;
                    float knockBack = this.inventory[index].knockBack;
                    switch (shoot)
                    {
                        case 13:
                        case 0x20:
                            this.grappling[0] = -1;
                            this.grapCount = 0;
                            for (int k = 0; k < 0x3e8; k++)
                            {
                                if ((Main.projectile[k].active && (Main.projectile[k].owner == this.whoAmi)) && (Main.projectile[k].type == 13))
                                {
                                    Main.projectile[k].Kill();
                                }
                            }
                            break;
                    }
                    Vector2 vector = new Vector2(this.position.X + (this.width * 0.5f), this.position.Y + (this.height * 0.5f));
                    float speedX = (Main.mouseState.X + Main.screenPosition.X) - vector.X;
                    float speedY = (Main.mouseState.Y + Main.screenPosition.Y) - vector.Y;
                    float num11 = (float) Math.Sqrt((double) ((speedX * speedX) + (speedY * speedY)));
                    num11 = shootSpeed / num11;
                    speedX *= num11;
                    speedY *= num11;
                    Projectile.NewProjectile(vector.X, vector.Y, speedX, speedY, shoot, damage, knockBack, this.whoAmi);
                }
            }
        }

        public void QuickHeal()
        {
            if (!this.noItems && ((this.statLife != this.statLifeMax) && (this.potionDelay <= 0)))
            {
                for (int i = 0; i < 0x2c; i++)
                {
                    if (((this.inventory[i].stack > 0) && (this.inventory[i].type > 0)) && (this.inventory[i].potion && (this.inventory[i].healLife > 0)))
                    {
                        Main.PlaySound(2, (int) this.position.X, (int) this.position.Y, this.inventory[i].useSound);
                        if (this.inventory[i].potion)
                        {
                            this.potionDelay = Item.potionDelay;
                            this.AddBuff(0x15, this.potionDelay, true);
                        }
                        this.statLife += this.inventory[i].healLife;
                        this.statMana += this.inventory[i].healMana;
                        if (this.statLife > this.statLifeMax)
                        {
                            this.statLife = this.statLifeMax;
                        }
                        if (this.statMana > this.statManaMax2)
                        {
                            this.statMana = this.statManaMax2;
                        }
                        if ((this.inventory[i].healLife > 0) && (Main.myPlayer == this.whoAmi))
                        {
                            this.HealEffect(this.inventory[i].healLife);
                        }
                        if ((this.inventory[i].healMana > 0) && (Main.myPlayer == this.whoAmi))
                        {
                            this.ManaEffect(this.inventory[i].healMana);
                        }
                        Item item1 = this.inventory[i];
                        item1.stack--;
                        if (this.inventory[i].stack <= 0)
                        {
                            this.inventory[i].type = 0;
                            this.inventory[i].name = "";
                        }
                        Recipe.FindRecipes();
                        return;
                    }
                }
            }
        }

        public void QuickMana()
        {
            if (!this.noItems && (this.statMana != this.statManaMax2))
            {
                for (int i = 0; i < 0x2c; i++)
                {
                    if ((((this.inventory[i].stack > 0) && (this.inventory[i].type > 0)) && (this.inventory[i].healMana > 0)) && ((this.potionDelay == 0) || !this.inventory[i].potion))
                    {
                        Main.PlaySound(2, (int) this.position.X, (int) this.position.Y, this.inventory[i].useSound);
                        if (this.inventory[i].potion)
                        {
                            this.potionDelay = Item.potionDelay;
                            this.AddBuff(0x15, this.potionDelay, true);
                        }
                        this.statLife += this.inventory[i].healLife;
                        this.statMana += this.inventory[i].healMana;
                        if (this.statLife > this.statLifeMax)
                        {
                            this.statLife = this.statLifeMax;
                        }
                        if (this.statMana > this.statManaMax2)
                        {
                            this.statMana = this.statManaMax2;
                        }
                        if ((this.inventory[i].healLife > 0) && (Main.myPlayer == this.whoAmi))
                        {
                            this.HealEffect(this.inventory[i].healLife);
                        }
                        if ((this.inventory[i].healMana > 0) && (Main.myPlayer == this.whoAmi))
                        {
                            this.ManaEffect(this.inventory[i].healMana);
                        }
                        Item item1 = this.inventory[i];
                        item1.stack--;
                        if (this.inventory[i].stack <= 0)
                        {
                            this.inventory[i].type = 0;
                            this.inventory[i].name = "";
                        }
                        Recipe.FindRecipes();
                        return;
                    }
                }
            }
        }

        public static void SavePlayer(Player newPlayer, string playerPath)
        {
            try
            {
                Directory.CreateDirectory(Main.PlayerPath);
            }
            catch
            {
            }
            if ((playerPath != null) && (playerPath != ""))
            {
                string destFileName = playerPath + ".bak";
                if (File.Exists(playerPath))
                {
                    File.Copy(playerPath, destFileName, true);
                }
                string path = playerPath + ".dat";
                using (FileStream stream = new FileStream(path, FileMode.Create))
                {
                    using (BinaryWriter writer = new BinaryWriter(stream))
                    {
                        writer.Write(Main.curRelease);
                        writer.Write(newPlayer.name);
                        writer.Write(newPlayer.difficulty);
                        writer.Write(newPlayer.hair);
                        writer.Write(newPlayer.male);
                        writer.Write(newPlayer.statLife);
                        writer.Write(newPlayer.statLifeMax);
                        writer.Write(newPlayer.statMana);
                        writer.Write(newPlayer.statManaMax);
                        writer.Write(newPlayer.hairColor.R);
                        writer.Write(newPlayer.hairColor.G);
                        writer.Write(newPlayer.hairColor.B);
                        writer.Write(newPlayer.skinColor.R);
                        writer.Write(newPlayer.skinColor.G);
                        writer.Write(newPlayer.skinColor.B);
                        writer.Write(newPlayer.eyeColor.R);
                        writer.Write(newPlayer.eyeColor.G);
                        writer.Write(newPlayer.eyeColor.B);
                        writer.Write(newPlayer.shirtColor.R);
                        writer.Write(newPlayer.shirtColor.G);
                        writer.Write(newPlayer.shirtColor.B);
                        writer.Write(newPlayer.underShirtColor.R);
                        writer.Write(newPlayer.underShirtColor.G);
                        writer.Write(newPlayer.underShirtColor.B);
                        writer.Write(newPlayer.pantsColor.R);
                        writer.Write(newPlayer.pantsColor.G);
                        writer.Write(newPlayer.pantsColor.B);
                        writer.Write(newPlayer.shoeColor.R);
                        writer.Write(newPlayer.shoeColor.G);
                        writer.Write(newPlayer.shoeColor.B);
                        for (int i = 0; i < 11; i++)
                        {
                            if (newPlayer.armor[i].name == null)
                            {
                                newPlayer.armor[i].name = "";
                            }
                            writer.Write(newPlayer.armor[i].name);
                        }
                        for (int j = 0; j < 0x2c; j++)
                        {
                            if (newPlayer.inventory[j].name == null)
                            {
                                newPlayer.inventory[j].name = "";
                            }
                            writer.Write(newPlayer.inventory[j].name);
                            writer.Write(newPlayer.inventory[j].stack);
                        }
                        for (int k = 0; k < 4; k++)
                        {
                            if (newPlayer.ammo[k].name == null)
                            {
                                newPlayer.ammo[k].name = "";
                            }
                            writer.Write(newPlayer.ammo[k].name);
                            writer.Write(newPlayer.ammo[k].stack);
                        }
                        for (int m = 0; m < Chest.maxItems; m++)
                        {
                            if (newPlayer.bank[m].name == null)
                            {
                                newPlayer.bank[m].name = "";
                            }
                            writer.Write(newPlayer.bank[m].name);
                            writer.Write(newPlayer.bank[m].stack);
                        }
                        for (int n = 0; n < Chest.maxItems; n++)
                        {
                            if (newPlayer.bank2[n].name == null)
                            {
                                newPlayer.bank2[n].name = "";
                            }
                            writer.Write(newPlayer.bank2[n].name);
                            writer.Write(newPlayer.bank2[n].stack);
                        }
                        for (int num6 = 0; num6 < 10; num6++)
                        {
                            writer.Write(newPlayer.buffType[num6]);
                            writer.Write(newPlayer.buffTime[num6]);
                        }
                        for (int num7 = 0; num7 < 200; num7++)
                        {
                            if (newPlayer.spN[num7] == null)
                            {
                                writer.Write(-1);
                                break;
                            }
                            writer.Write(newPlayer.spX[num7]);
                            writer.Write(newPlayer.spY[num7]);
                            writer.Write(newPlayer.spI[num7]);
                            writer.Write(newPlayer.spN[num7]);
                        }
                        writer.Write(newPlayer.hbLocked);
                        writer.Close();
                    }
                }
                EncryptFile(path, playerPath);
                File.Delete(path);
            }
        }

        public bool SellItem(int price, int stack)
        {
            if (price > 0)
            {
                Item[] itemArray = new Item[0x2c];
                for (int i = 0; i < 0x2c; i++)
                {
                    itemArray[i] = new Item();
                    itemArray[i] = (Item) this.inventory[i].Clone();
                }
                int num2 = price / 5;
                num2 *= stack;
                if (num2 < 1)
                {
                    num2 = 1;
                }
                bool flag = false;
                while ((num2 >= 0xf4240) && !flag)
                {
                    int index = -1;
                    for (int k = 0x2b; k >= 0; k--)
                    {
                        if ((index == -1) && ((this.inventory[k].type == 0) || (this.inventory[k].stack == 0)))
                        {
                            index = k;
                        }
                        while (((this.inventory[k].type == 0x4a) && (this.inventory[k].stack < this.inventory[k].maxStack)) && (num2 >= 0xf4240))
                        {
                            Item item1 = this.inventory[k];
                            item1.stack++;
                            num2 -= 0xf4240;
                            this.DoCoins(k);
                            if ((this.inventory[k].stack == 0) && (index == -1))
                            {
                                index = k;
                            }
                        }
                    }
                    if (num2 >= 0xf4240)
                    {
                        if (index == -1)
                        {
                            flag = true;
                        }
                        else
                        {
                            this.inventory[index].SetDefaults(0x4a, false);
                            num2 -= 0xf4240;
                        }
                    }
                }
                while ((num2 >= 0x2710) && !flag)
                {
                    int num5 = -1;
                    for (int m = 0x2b; m >= 0; m--)
                    {
                        if ((num5 == -1) && ((this.inventory[m].type == 0) || (this.inventory[m].stack == 0)))
                        {
                            num5 = m;
                        }
                        while (((this.inventory[m].type == 0x49) && (this.inventory[m].stack < this.inventory[m].maxStack)) && (num2 >= 0x2710))
                        {
                            Item item2 = this.inventory[m];
                            item2.stack++;
                            num2 -= 0x2710;
                            this.DoCoins(m);
                            if ((this.inventory[m].stack == 0) && (num5 == -1))
                            {
                                num5 = m;
                            }
                        }
                    }
                    if (num2 >= 0x2710)
                    {
                        if (num5 == -1)
                        {
                            flag = true;
                        }
                        else
                        {
                            this.inventory[num5].SetDefaults(0x49, false);
                            num2 -= 0x2710;
                        }
                    }
                }
                while ((num2 >= 100) && !flag)
                {
                    int num7 = -1;
                    for (int n = 0x2b; n >= 0; n--)
                    {
                        if ((num7 == -1) && ((this.inventory[n].type == 0) || (this.inventory[n].stack == 0)))
                        {
                            num7 = n;
                        }
                        while (((this.inventory[n].type == 0x48) && (this.inventory[n].stack < this.inventory[n].maxStack)) && (num2 >= 100))
                        {
                            Item item3 = this.inventory[n];
                            item3.stack++;
                            num2 -= 100;
                            this.DoCoins(n);
                            if ((this.inventory[n].stack == 0) && (num7 == -1))
                            {
                                num7 = n;
                            }
                        }
                    }
                    if (num2 >= 100)
                    {
                        if (num7 == -1)
                        {
                            flag = true;
                        }
                        else
                        {
                            this.inventory[num7].SetDefaults(0x48, false);
                            num2 -= 100;
                        }
                    }
                }
                while ((num2 >= 1) && !flag)
                {
                    int num9 = -1;
                    for (int num10 = 0x2b; num10 >= 0; num10--)
                    {
                        if ((num9 == -1) && ((this.inventory[num10].type == 0) || (this.inventory[num10].stack == 0)))
                        {
                            num9 = num10;
                        }
                        while (((this.inventory[num10].type == 0x47) && (this.inventory[num10].stack < this.inventory[num10].maxStack)) && (num2 >= 1))
                        {
                            Item item4 = this.inventory[num10];
                            item4.stack++;
                            num2--;
                            this.DoCoins(num10);
                            if ((this.inventory[num10].stack == 0) && (num9 == -1))
                            {
                                num9 = num10;
                            }
                        }
                    }
                    if (num2 >= 1)
                    {
                        if (num9 == -1)
                        {
                            flag = true;
                        }
                        else
                        {
                            this.inventory[num9].SetDefaults(0x47, false);
                            num2--;
                        }
                    }
                }
                if (!flag)
                {
                    return true;
                }
                for (int j = 0; j < 0x2c; j++)
                {
                    this.inventory[j] = (Item) itemArray[j].Clone();
                }
            }
            return false;
        }

        public void Spawn()
        {
            if (this.whoAmi == Main.myPlayer)
            {
                this.FindSpawn();
                if (!CheckSpawn(this.SpawnX, this.SpawnY))
                {
                    this.SpawnX = -1;
                    this.SpawnY = -1;
                }
            }
            if ((Main.netMode == 1) && (this.whoAmi == Main.myPlayer))
            {
                NetMessage.SendData(12, -1, -1, "", Main.myPlayer, 0f, 0f, 0f, 0);
                Main.gameMenu = false;
            }
            this.headPosition = new Vector2();
            this.bodyPosition = new Vector2();
            this.legPosition = new Vector2();
            this.headRotation = 0f;
            this.bodyRotation = 0f;
            this.legRotation = 0f;
            if (this.statLife <= 0)
            {
                this.statLife = 100;
                this.breath = this.breathMax;
                if (this.spawnMax)
                {
                    this.statLife = this.statLifeMax;
                    this.statMana = this.statManaMax2;
                }
            }
            this.immune = true;
            this.dead = false;
            this.immuneTime = 0;
            this.active = true;
            if ((this.SpawnX >= 0) && (this.SpawnY >= 0))
            {
                this.position.X = ((this.SpawnX * 0x10) + 8) - (this.width / 2);
                this.position.Y = (this.SpawnY * 0x10) - this.height;
            }
            else
            {
                this.position.X = ((Main.spawnTileX * 0x10) + 8) - (this.width / 2);
                this.position.Y = (Main.spawnTileY * 0x10) - this.height;
                for (int i = Main.spawnTileX - 1; i < (Main.spawnTileX + 2); i++)
                {
                    for (int j = Main.spawnTileY - 3; j < Main.spawnTileY; j++)
                    {
                        if (Main.tileSolid[Main.tile[i, j].type] && !Main.tileSolidTop[Main.tile[i, j].type])
                        {
                            WorldGen.KillTile(i, j, false, false, false);
                        }
                        if (Main.tile[i, j].liquid > 0)
                        {
                            Main.tile[i, j].lava = false;
                            Main.tile[i, j].liquid = 0;
                            WorldGen.SquareTileFrame(i, j, true);
                        }
                    }
                }
            }
            this.wet = false;
            this.wetCount = 0;
            this.lavaWet = false;
            this.fallStart = (int) (this.position.Y / 16f);
            this.velocity.X = 0f;
            this.velocity.Y = 0f;
            this.talkNPC = -1;
            if (this.pvpDeath)
            {
                this.pvpDeath = false;
                this.immuneTime = 300;
                this.statLife = this.statLifeMax;
            }
            else
            {
                this.immuneTime = 60;
            }
            if (this.whoAmi == Main.myPlayer)
            {
                if (Main.netMode == 1)
                {
                    Netplay.newRecent();
                }
                Lighting.lightCounter = Lighting.lightSkip + 1;
                Main.screenPosition.X = (this.position.X + (this.width / 2)) - (Main.screenWidth / 2);
                Main.screenPosition.Y = (this.position.Y + (this.height / 2)) - (Main.screenHeight / 2);
            }
        }

        public void StatusNPC(int type, int i)
        {
            if (type == 0x79)
            {
                if (Main.rand.Next(2) == 0)
                {
                    Main.npc[i].AddBuff(0x18, 180, false);
                }
            }
            else if (type == 0x7a)
            {
                if (Main.rand.Next(10) == 0)
                {
                    Main.npc[i].AddBuff(0x18, 180, false);
                }
            }
            else if (type == 190)
            {
                if (Main.rand.Next(4) == 0)
                {
                    Main.npc[i].AddBuff(20, 420, false);
                }
            }
            else if ((type == 0xd9) && (Main.rand.Next(5) == 0))
            {
                Main.npc[i].AddBuff(0x18, 180, false);
            }
        }

        public void StatusPvP(int type, int i)
        {
            if (type == 0x79)
            {
                if (Main.rand.Next(2) == 0)
                {
                    Main.player[i].AddBuff(0x18, 180, false);
                }
            }
            else if (type == 0x7a)
            {
                if (Main.rand.Next(10) == 0)
                {
                    Main.player[i].AddBuff(0x18, 180, false);
                }
            }
            else if (type == 190)
            {
                if (Main.rand.Next(4) == 0)
                {
                    Main.player[i].AddBuff(20, 420, false);
                }
            }
            else if ((type == 0xd9) && (Main.rand.Next(5) == 0))
            {
                Main.player[i].AddBuff(0x18, 180, false);
            }
        }

        public void toggleInv()
        {
            if (this.talkNPC >= 0)
            {
                this.talkNPC = -1;
                Main.npcChatText = "";
                Main.PlaySound(11, -1, -1, 1);
            }
            else if (this.sign >= 0)
            {
                this.sign = -1;
                Main.editSign = false;
                Main.npcChatText = "";
                Main.PlaySound(11, -1, -1, 1);
            }
            else if (!Main.playerInventory)
            {
                Recipe.FindRecipes();
                Main.playerInventory = true;
                Main.PlaySound(10, -1, -1, 1);
            }
            else
            {
                Main.playerInventory = false;
                Main.PlaySound(11, -1, -1, 1);
            }
        }

        public void UpdatePlayer(int i)
        {
            Color color;
            float num = 10f;
            float num2 = 0.4f;
            jumpHeight = 15;
            jumpSpeed = 5.01f;
            if (this.wet)
            {
                num2 = 0.2f;
                num = 5f;
                jumpHeight = 30;
                jumpSpeed = 6.01f;
            }
            float num3 = 3f;
            float num4 = 0.08f;
            float num5 = 0.2f;
            float num6 = num3;
            this.heldProj = -1;
            if (!this.active)
            {
                return;
            }
            this.maxRegenDelay = (((1f - (((float) this.statMana) / ((float) this.statManaMax2))) * 60f) * 4f) + 45f;
            this.shadowCount++;
            if (this.shadowCount == 1)
            {
                this.shadowPos[2] = this.shadowPos[1];
            }
            else if (this.shadowCount == 2)
            {
                this.shadowPos[1] = this.shadowPos[0];
            }
            else if (this.shadowCount >= 3)
            {
                this.shadowCount = 0;
                this.shadowPos[0] = this.position;
            }
            this.whoAmi = i;
            if (this.runSoundDelay > 0)
            {
                this.runSoundDelay--;
            }
            if (this.attackCD > 0)
            {
                this.attackCD--;
            }
            if (this.itemAnimation == 0)
            {
                this.attackCD = 0;
            }
            if (this.chatShowTime > 0)
            {
                this.chatShowTime--;
            }
            if (this.potionDelay > 0)
            {
                this.potionDelay--;
            }
            if (i == Main.myPlayer)
            {
                this.zoneEvil = false;
                if (Main.evilTiles >= 500)
                {
                    this.zoneEvil = true;
                }
                this.zoneMeteor = false;
                if (Main.meteorTiles >= 50)
                {
                    this.zoneMeteor = true;
                }
                this.zoneDungeon = false;
                if ((Main.dungeonTiles >= 250) && (this.position.Y > (Main.worldSurface * 16.0)))
                {
                    int num7 = ((int) this.position.X) / 0x10;
                    int num8 = ((int) this.position.Y) / 0x10;
                    if ((Main.tile[num7, num8].wall > 0) && !Main.wallHouse[Main.tile[num7, num8].wall])
                    {
                        this.zoneDungeon = true;
                    }
                }
                this.zoneJungle = false;
                if (Main.jungleTiles >= 150)
                {
                    this.zoneJungle = true;
                }
            }
            if (this.ghost)
            {
                this.Ghost();
                return;
            }
            if (this.dead)
            {
                this.poisoned = false;
                this.onFire = false;
                this.blind = false;
                this.gravDir = 1f;
                for (int num9 = 0; num9 < 10; num9++)
                {
                    this.buffTime[num9] = 0;
                    this.buffType[num9] = 0;
                }
                if (i == Main.myPlayer)
                {
                    Main.npcChatText = "";
                    Main.editSign = false;
                }
                this.grappling[0] = -1;
                this.grappling[1] = -1;
                this.grappling[2] = -1;
                this.sign = -1;
                this.talkNPC = -1;
                this.statLife = 0;
                this.channel = false;
                this.potionDelay = 0;
                this.chest = -1;
                this.changeItem = -1;
                this.itemAnimation = 0;
                this.immuneAlpha += 2;
                if (this.immuneAlpha > 0xff)
                {
                    this.immuneAlpha = 0xff;
                }
                this.headPosition += this.headVelocity;
                this.bodyPosition += this.bodyVelocity;
                this.legPosition += this.legVelocity;
                this.headRotation += this.headVelocity.X * 0.1f;
                this.bodyRotation += this.bodyVelocity.X * 0.1f;
                this.legRotation += this.legVelocity.X * 0.1f;
                this.headVelocity.Y += 0.1f;
                this.bodyVelocity.Y += 0.1f;
                this.legVelocity.Y += 0.1f;
                this.headVelocity.X *= 0.99f;
                this.bodyVelocity.X *= 0.99f;
                this.legVelocity.X *= 0.99f;
                if (this.difficulty != 2)
                {
                    this.respawnTimer--;
                    if ((this.respawnTimer <= 0) && (Main.myPlayer == this.whoAmi))
                    {
                        this.Spawn();
                        return;
                    }
                }
                else
                {
                    if (this.respawnTimer > 0)
                    {
                        this.respawnTimer--;
                        return;
                    }
                    if ((this.whoAmi == Main.myPlayer) || (Main.netMode == 2))
                    {
                        this.ghost = true;
                        return;
                    }
                }
                return;
            }
            if (i == Main.myPlayer)
            {
                this.controlUp = false;
                this.controlLeft = false;
                this.controlDown = false;
                this.controlRight = false;
                this.controlJump = false;
                this.controlUseItem = false;
                this.controlUseTile = false;
                this.controlThrow = false;
                this.controlInv = false;
                this.controlHook = false;
                if (Main.hasFocus)
                {
                    if (!Main.chatMode && !Main.editSign)
                    {
                        Keys[] pressedKeys = Main.keyState.GetPressedKeys();
                        bool flag = false;
                        bool flag2 = false;
                        for (int num10 = 0; num10 < pressedKeys.Length; num10++)
                        {
                            string str = pressedKeys[num10].ToString();
                            if (str == Main.cUp)
                            {
                                this.controlUp = true;
                            }
                            if (str == Main.cLeft)
                            {
                                this.controlLeft = true;
                            }
                            if (str == Main.cDown)
                            {
                                this.controlDown = true;
                            }
                            if (str == Main.cRight)
                            {
                                this.controlRight = true;
                            }
                            if (str == Main.cJump)
                            {
                                this.controlJump = true;
                            }
                            if (str == Main.cThrowItem)
                            {
                                this.controlThrow = true;
                            }
                            if (str == Main.cInv)
                            {
                                this.controlInv = true;
                            }
                            if (str == Main.cBuff)
                            {
                                this.QuickBuff();
                            }
                            if (str == Main.cHeal)
                            {
                                flag2 = true;
                            }
                            if (str == Main.cMana)
                            {
                                flag = true;
                            }
                            if (str == Main.cHook)
                            {
                                this.controlHook = true;
                            }
                        }
                        if (flag2)
                        {
                            if (this.releaseQuickHeal)
                            {
                                this.QuickHeal();
                            }
                            this.releaseQuickHeal = false;
                        }
                        else
                        {
                            this.releaseQuickHeal = true;
                        }
                        if (flag)
                        {
                            if (this.releaseQuickMana)
                            {
                                this.QuickMana();
                            }
                            this.releaseQuickMana = false;
                        }
                        else
                        {
                            this.releaseQuickMana = true;
                        }
                        if (this.controlLeft && this.controlRight)
                        {
                            this.controlLeft = false;
                            this.controlRight = false;
                        }
                    }
                    if ((Main.mouseState.LeftButton == ButtonState.Pressed) && !this.mouseInterface)
                    {
                        this.controlUseItem = true;
                    }
                    if ((Main.mouseState.RightButton == ButtonState.Pressed) && !this.mouseInterface)
                    {
                        this.controlUseTile = true;
                    }
                    if (this.controlInv)
                    {
                        if (this.releaseInventory)
                        {
                            this.toggleInv();
                        }
                        this.releaseInventory = false;
                    }
                    else
                    {
                        this.releaseInventory = true;
                    }
                    if (this.delayUseItem)
                    {
                        if (!this.controlUseItem)
                        {
                            this.delayUseItem = false;
                        }
                        this.controlUseItem = false;
                    }
                    if ((this.itemAnimation == 0) && (this.itemTime == 0))
                    {
                        this.dropItemCheck();
                        int selectedItem = this.selectedItem;
                        if (!Main.chatMode)
                        {
                            if (Main.keyState.IsKeyDown(Keys.D1))
                            {
                                this.selectedItem = 0;
                            }
                            if (Main.keyState.IsKeyDown(Keys.D2))
                            {
                                this.selectedItem = 1;
                            }
                            if (Main.keyState.IsKeyDown(Keys.D3))
                            {
                                this.selectedItem = 2;
                            }
                            if (Main.keyState.IsKeyDown(Keys.D4))
                            {
                                this.selectedItem = 3;
                            }
                            if (Main.keyState.IsKeyDown(Keys.D5))
                            {
                                this.selectedItem = 4;
                            }
                            if (Main.keyState.IsKeyDown(Keys.D6))
                            {
                                this.selectedItem = 5;
                            }
                            if (Main.keyState.IsKeyDown(Keys.D7))
                            {
                                this.selectedItem = 6;
                            }
                            if (Main.keyState.IsKeyDown(Keys.D8))
                            {
                                this.selectedItem = 7;
                            }
                            if (Main.keyState.IsKeyDown(Keys.D9))
                            {
                                this.selectedItem = 8;
                            }
                            if (Main.keyState.IsKeyDown(Keys.D0))
                            {
                                this.selectedItem = 9;
                            }
                        }
                        if (selectedItem != this.selectedItem)
                        {
                            Main.PlaySound(12, -1, -1, 1);
                        }
                        if (!Main.playerInventory)
                        {
                            int num12 = (Main.mouseState.ScrollWheelValue - Main.oldMouseState.ScrollWheelValue) / 120;
                            while (num12 > 9)
                            {
                                num12 -= 10;
                            }
                            while (num12 < 0)
                            {
                                num12 += 10;
                            }
                            this.selectedItem -= num12;
                            if (num12 != 0)
                            {
                                Main.PlaySound(12, -1, -1, 1);
                            }
                            if (this.changeItem >= 0)
                            {
                                if (this.selectedItem != this.changeItem)
                                {
                                    Main.PlaySound(12, -1, -1, 1);
                                }
                                this.selectedItem = this.changeItem;
                                this.changeItem = -1;
                            }
                            while (this.selectedItem > 9)
                            {
                                this.selectedItem -= 10;
                            }
                            while (this.selectedItem < 0)
                            {
                                this.selectedItem += 10;
                            }
                        }
                        else
                        {
                            int num13 = (Main.mouseState.ScrollWheelValue - Main.oldMouseState.ScrollWheelValue) / 120;
                            Main.focusRecipe += num13;
                            if (Main.focusRecipe > (Main.numAvailableRecipes - 1))
                            {
                                Main.focusRecipe = Main.numAvailableRecipes - 1;
                            }
                            if (Main.focusRecipe < 0)
                            {
                                Main.focusRecipe = 0;
                            }
                        }
                    }
                }
                if (!this.controlThrow)
                {
                    this.releaseThrow = true;
                }
                else
                {
                    this.releaseThrow = false;
                }
                if (Main.netMode == 1)
                {
                    bool flag3 = false;
                    if ((this.statLife != Main.clientPlayer.statLife) || (this.statLifeMax != Main.clientPlayer.statLifeMax))
                    {
                        NetMessage.SendData(0x10, -1, -1, "", Main.myPlayer, 0f, 0f, 0f, 0);
                        flag3 = true;
                    }
                    if ((this.statMana != Main.clientPlayer.statMana) || (this.statManaMax != Main.clientPlayer.statManaMax))
                    {
                        NetMessage.SendData(0x2a, -1, -1, "", Main.myPlayer, 0f, 0f, 0f, 0);
                        flag3 = true;
                    }
                    if (this.controlUp != Main.clientPlayer.controlUp)
                    {
                        flag3 = true;
                    }
                    if (this.controlDown != Main.clientPlayer.controlDown)
                    {
                        flag3 = true;
                    }
                    if (this.controlLeft != Main.clientPlayer.controlLeft)
                    {
                        flag3 = true;
                    }
                    if (this.controlRight != Main.clientPlayer.controlRight)
                    {
                        flag3 = true;
                    }
                    if (this.controlJump != Main.clientPlayer.controlJump)
                    {
                        flag3 = true;
                    }
                    if (this.controlUseItem != Main.clientPlayer.controlUseItem)
                    {
                        flag3 = true;
                    }
                    if (this.selectedItem != Main.clientPlayer.selectedItem)
                    {
                        flag3 = true;
                    }
                    if (flag3)
                    {
                        NetMessage.SendData(13, -1, -1, "", Main.myPlayer, 0f, 0f, 0f, 0);
                    }
                }
                if (Main.playerInventory)
                {
                    this.AdjTiles();
                }
                if (this.chest != -1)
                {
                    int num14 = (int) ((this.position.X + (this.width * 0.5)) / 16.0);
                    int num15 = (int) ((this.position.Y + (this.height * 0.5)) / 16.0);
                    if (((num14 < (this.chestX - 5)) || (num14 > (this.chestX + 6))) || ((num15 < (this.chestY - 4)) || (num15 > (this.chestY + 5))))
                    {
                        if (this.chest != -1)
                        {
                            Main.PlaySound(11, -1, -1, 1);
                        }
                        this.chest = -1;
                    }
                    if (!Main.tile[this.chestX, this.chestY].active)
                    {
                        Main.PlaySound(11, -1, -1, 1);
                        this.chest = -1;
                    }
                }
                if (this.velocity.Y == 0f)
                {
                    int num16 = ((int) (this.position.Y / 16f)) - this.fallStart;
                    if ((((this.gravDir == 1f) && (num16 > 0x19)) || ((this.gravDir == -1f) && (num16 < -25))) && !this.noFallDmg)
                    {
                        int damage = ((int) ((num16 * this.gravDir) - 25f)) * 10;
                        this.immune = false;
                        this.Hurt(damage, 0, false, false, getDeathMessage(-1, -1, -1, 0), false);
                    }
                    this.fallStart = (int) (this.position.Y / 16f);
                }
                if (((this.jump > 0) || (this.rocketDelay > 0)) || (this.wet || this.slowFall))
                {
                    this.fallStart = (int) (this.position.Y / 16f);
                }
            }
            if (this.mouseInterface)
            {
                this.delayUseItem = true;
            }
            Player.tileTargetX = (int) ((Main.mouseState.X + Main.screenPosition.X) / 16f);
            Player.tileTargetY = (int) ((Main.mouseState.Y + Main.screenPosition.Y) / 16f);
            if (this.immune)
            {
                this.immuneTime--;
                if (this.immuneTime <= 0)
                {
                    this.immune = false;
                }
                this.immuneAlpha += this.immuneAlphaDirection * 50;
                if (this.immuneAlpha <= 50)
                {
                    this.immuneAlphaDirection = 1;
                }
                else if (this.immuneAlpha >= 0xcd)
                {
                    this.immuneAlphaDirection = -1;
                }
            }
            else
            {
                this.immuneAlpha = 0;
            }
            this.statDefense = 0;
            this.accWatch = 0;
            this.accDepthMeter = 0;
            this.lifeRegen = 0;
            this.manaCost = 1f;
            this.meleeSpeed = 1f;
            this.meleeDamage = 1f;
            this.rangedDamage = 1f;
            this.magicDamage = 1f;
            this.moveSpeed = 1f;
            this.boneArmor = false;
            this.rocketBoots = false;
            this.fireWalk = false;
            this.noKnockback = false;
            this.jumpBoost = false;
            this.noFallDmg = false;
            this.accFlipper = false;
            this.spawnMax = false;
            this.spaceGun = false;
            this.killGuide = false;
            this.lavaImmune = false;
            this.gills = false;
            this.slowFall = false;
            this.findTreasure = false;
            this.invis = false;
            this.nightVision = false;
            this.enemySpawns = false;
            this.thorns = false;
            this.waterWalk = false;
            this.detectCreature = false;
            this.gravControl = false;
            this.statManaMax2 = this.statManaMax;
            this.ammoCost80 = false;
            this.manaRegenBuff = false;
            this.meleeCrit = 4;
            this.rangedCrit = 4;
            this.magicCrit = 4;
            this.lightOrb = false;
            this.archery = false;
            this.poisoned = false;
            this.blind = false;
            this.onFire = false;
            this.noItems = false;
            for (int j = 0; j < 10; j++)
            {
                if ((this.buffType[j] <= 0) || (this.buffTime[j] <= 0))
                {
                    continue;
                }
                if (this.whoAmi == Main.myPlayer)
                {
                    this.buffTime[j]--;
                }
                if (this.buffType[j] == 1)
                {
                    this.lavaImmune = true;
                    this.fireWalk = true;
                    continue;
                }
                if (this.buffType[j] == 2)
                {
                    this.lifeRegen += 2;
                    continue;
                }
                if (this.buffType[j] == 3)
                {
                    this.moveSpeed += 0.25f;
                    continue;
                }
                if (this.buffType[j] == 4)
                {
                    this.gills = true;
                    continue;
                }
                if (this.buffType[j] == 5)
                {
                    this.statDefense += 10;
                    continue;
                }
                if (this.buffType[j] == 6)
                {
                    this.manaRegenBuff = true;
                    continue;
                }
                if (this.buffType[j] == 7)
                {
                    this.magicDamage += 0.2f;
                    continue;
                }
                if (this.buffType[j] == 8)
                {
                    this.slowFall = true;
                    continue;
                }
                if (this.buffType[j] == 9)
                {
                    this.findTreasure = true;
                    continue;
                }
                if (this.buffType[j] == 10)
                {
                    this.invis = true;
                    continue;
                }
                if (this.buffType[j] == 11)
                {
                    Lighting.addLight((((int) this.position.X) + (this.width / 2)) / 0x10, (((int) this.position.Y) + (this.height / 2)) / 0x10, 1f);
                    continue;
                }
                if (this.buffType[j] == 12)
                {
                    this.nightVision = true;
                    continue;
                }
                if (this.buffType[j] == 13)
                {
                    this.enemySpawns = true;
                    continue;
                }
                if (this.buffType[j] == 14)
                {
                    this.thorns = true;
                    continue;
                }
                if (this.buffType[j] == 15)
                {
                    this.waterWalk = true;
                    continue;
                }
                if (this.buffType[j] == 0x10)
                {
                    this.archery = true;
                    continue;
                }
                if (this.buffType[j] == 0x11)
                {
                    this.detectCreature = true;
                    continue;
                }
                if (this.buffType[j] == 0x12)
                {
                    this.gravControl = true;
                    continue;
                }
                if (this.buffType[j] == 0x13)
                {
                    this.lightOrb = true;
                    bool flag4 = true;
                    for (int num19 = 0; num19 < 0x3e8; num19++)
                    {
                        if ((Main.projectile[num19].active && (Main.projectile[num19].owner == this.whoAmi)) && (Main.projectile[num19].type == 0x12))
                        {
                            flag4 = false;
                            break;
                        }
                    }
                    if (flag4)
                    {
                        Projectile.NewProjectile(this.position.X + (this.width / 2), this.position.Y + (this.height / 2), 0f, 0f, 0x12, 0, 0f, this.whoAmi);
                    }
                    continue;
                }
                if (this.buffType[j] == 20)
                {
                    this.poisoned = true;
                }
                else if (this.buffType[j] == 0x15)
                {
                    this.potionDelay = this.buffTime[j];
                }
                else if (this.buffType[j] == 0x16)
                {
                    this.blind = true;
                }
                else if (this.buffType[j] == 0x17)
                {
                    this.noItems = true;
                }
                else if (this.buffType[j] == 0x18)
                {
                    this.onFire = true;
                }
                else if (this.buffType[j] == 0x19)
                {
                    this.statDefense -= 4;
                    this.meleeCrit += 2;
                    this.meleeDamage += 0.1f;
                    this.meleeSpeed += 0.1f;
                }
                else if (this.buffType[j] == 0x1a)
                {
                    this.statDefense++;
                    this.meleeCrit++;
                    this.meleeDamage += 0.05f;
                    this.meleeSpeed += 0.05f;
                    this.magicCrit++;
                    this.magicDamage += 0.05f;
                    this.rangedCrit++;
                    this.magicDamage += 0.05f;
                    this.moveSpeed += 0.1f;
                }
            }
            if (this.whoAmi == Main.myPlayer)
            {
                for (int num20 = 0; num20 < 10; num20++)
                {
                    if ((this.buffType[num20] > 0) && (this.buffTime[num20] <= 0))
                    {
                        this.DelBuff(num20);
                    }
                }
            }
            if ((this.manaRegenDelay > 0) && !this.channel)
            {
                this.manaRegenDelay--;
                if (((this.velocity.X == 0f) && (this.velocity.Y == 0f)) || ((this.grappling[0] >= 0) || this.manaRegenBuff))
                {
                    this.manaRegenDelay--;
                }
            }
            if (this.manaRegenBuff && (this.manaRegenDelay > 20))
            {
                this.manaRegenDelay = 20;
            }
            if (this.manaRegenDelay <= 0)
            {
                this.manaRegenDelay = 0;
                this.manaRegen = (this.statManaMax2 / 7) + 1;
                if (((this.velocity.X == 0f) && (this.velocity.Y == 0f)) || ((this.grappling[0] >= 0) || this.manaRegenBuff))
                {
                    this.manaRegen += this.statManaMax2 / 2;
                }
                float num21 = ((((float) this.statMana) / ((float) this.statManaMax2)) * 0.8f) + 0.2f;
                if (this.manaRegenBuff)
                {
                    num21 = 1f;
                }
                this.manaRegen = (int) (this.manaRegen * num21);
            }
            else
            {
                this.manaRegen = 0;
            }
            this.doubleJump = false;
            for (int k = 0; k < 8; k++)
            {
                this.statDefense += this.armor[k].defense;
                this.lifeRegen += this.armor[k].lifeRegen;
                if (this.armor[k].type == 0xc1)
                {
                    this.fireWalk = true;
                }
                if (this.armor[k].type == 0xee)
                {
                    this.magicDamage += 0.15f;
                }
                if (((this.armor[k].type == 0x7b) || (this.armor[k].type == 0x7c)) || (this.armor[k].type == 0x7d))
                {
                    this.magicDamage += 0.05f;
                }
                if (((this.armor[k].type == 0x97) || (this.armor[k].type == 0x98)) || (this.armor[k].type == 0x99))
                {
                    this.rangedDamage += 0.05f;
                }
                if (((this.armor[k].type == 0x6f) || (this.armor[k].type == 0xe4)) || ((this.armor[k].type == 0xe5) || (this.armor[k].type == 230)))
                {
                    this.statManaMax2 += 20;
                }
                if (((this.armor[k].type == 0xe4) || (this.armor[k].type == 0xe5)) || (this.armor[k].type == 230))
                {
                    this.magicCrit += 3;
                }
                if (((this.armor[k].type == 100) || (this.armor[k].type == 0x65)) || (this.armor[k].type == 0x66))
                {
                    this.meleeSpeed += 0.07f;
                }
            }
            this.head = this.armor[0].headSlot;
            this.body = this.armor[1].bodySlot;
            this.legs = this.armor[2].legSlot;
            for (int m = 3; m < 8; m++)
            {
                if ((this.armor[m].type == 15) && (this.accWatch < 1))
                {
                    this.accWatch = 1;
                }
                if ((this.armor[m].type == 0x10) && (this.accWatch < 2))
                {
                    this.accWatch = 2;
                }
                if ((this.armor[m].type == 0x11) && (this.accWatch < 3))
                {
                    this.accWatch = 3;
                }
                if ((this.armor[m].type == 0x12) && (this.accDepthMeter < 1))
                {
                    this.accDepthMeter = 1;
                }
                if (this.armor[m].type == 0x35)
                {
                    this.doubleJump = true;
                }
                if (this.armor[m].type == 0x36)
                {
                    num6 = 6f;
                }
                if (this.armor[m].type == 0x80)
                {
                    this.rocketBoots = true;
                }
                if (this.armor[m].type == 0x9c)
                {
                    this.noKnockback = true;
                }
                if (this.armor[m].type == 0x9e)
                {
                    this.noFallDmg = true;
                }
                if (this.armor[m].type == 0x9f)
                {
                    this.jumpBoost = true;
                }
                if (this.armor[m].type == 0xbb)
                {
                    this.accFlipper = true;
                }
                if (this.armor[m].type == 0xd3)
                {
                    this.meleeSpeed += 0.12f;
                }
                if (this.armor[m].type == 0xdf)
                {
                    this.manaCost -= 0.06f;
                }
                if (this.armor[m].type == 0x11d)
                {
                    this.moveSpeed += 0.05f;
                }
                if (this.armor[m].type == 0xd4)
                {
                    this.moveSpeed += 0.1f;
                }
                if (this.armor[m].type == 0x10b)
                {
                    this.killGuide = true;
                }
            }
            if (this.head == 11)
            {
                int num24 = ((((int) this.position.X) + (this.width / 2)) + (8 * this.direction)) / 0x10;
                int num25 = ((int) (this.position.Y + 2f)) / 0x10;
                Lighting.addLight(num24, num25, 0.8f);
            }
            this.setBonus = "";
            if ((((this.head == 1) && (this.body == 1)) && (this.legs == 1)) || (((this.head == 2) && (this.body == 2)) && (this.legs == 2)))
            {
                this.setBonus = "2 defense";
                this.statDefense += 2;
            }
            if ((((this.head == 3) && (this.body == 3)) && (this.legs == 3)) || (((this.head == 4) && (this.body == 4)) && (this.legs == 4)))
            {
                this.setBonus = "3 defense";
                this.statDefense += 3;
            }
            if (((this.head == 5) && (this.body == 5)) && (this.legs == 5))
            {
                this.setBonus = "15% increased movement speed";
                this.moveSpeed += 0.15f;
            }
            if (((this.head == 6) && (this.body == 6)) && (this.legs == 6))
            {
                this.setBonus = "Space Gun costs 0 mana";
                this.spaceGun = true;
            }
            if (((this.head == 7) && (this.body == 7)) && (this.legs == 7))
            {
                this.setBonus = "20% chance to not consume ammo";
                this.ammoCost80 = true;
            }
            if (((this.head == 8) && (this.body == 8)) && (this.legs == 8))
            {
                this.setBonus = "16% reduced mana usage";
                this.manaCost -= 0.16f;
            }
            if (((this.head == 9) && (this.body == 9)) && (this.legs == 9))
            {
                this.setBonus = "17% extra melee damage";
                this.meleeDamage += 0.17f;
            }
            if (this.meleeSpeed > 4f)
            {
                this.meleeSpeed = 4f;
            }
            if (this.moveSpeed > 1.4)
            {
                this.moveSpeed = 1.4f;
            }
            if (this.statManaMax2 > 400)
            {
                this.statManaMax2 = 400;
            }
            if (this.statDefense < 0)
            {
                this.statDefense = 0;
            }
            this.meleeSpeed = 1f / this.meleeSpeed;
            if (this.poisoned)
            {
                this.lifeRegenTime = 0;
                this.lifeRegen = -4;
            }
            if (this.onFire)
            {
                this.lifeRegenTime = 0;
                this.lifeRegen = -8;
            }
            this.lifeRegenTime++;
            float num26 = 0f;
            if (this.lifeRegenTime >= 300)
            {
                num26++;
            }
            if (this.lifeRegenTime >= 600)
            {
                num26++;
            }
            if (this.lifeRegenTime >= 900)
            {
                num26++;
            }
            if (this.lifeRegenTime >= 0x4b0)
            {
                num26++;
            }
            if (this.lifeRegenTime >= 0x5dc)
            {
                num26++;
            }
            if (this.lifeRegenTime >= 0x708)
            {
                num26++;
            }
            if (this.lifeRegenTime >= 0x960)
            {
                num26++;
            }
            if (this.lifeRegenTime >= 0xbb8)
            {
                num26++;
            }
            if (this.lifeRegenTime >= 0xe10)
            {
                num26++;
                this.lifeRegenTime = 0xe10;
            }
            if ((this.velocity.X == 0f) || (this.grappling[0] > 0))
            {
                num26 *= 1.25f;
            }
            else
            {
                num26 *= 0.5f;
            }
            float num27 = ((((float) this.statLifeMax) / 400f) * 0.75f) + 0.25f;
            num26 *= num27;
            this.lifeRegen += (int) Math.Round((double) num26);
            this.lifeRegenCount += this.lifeRegen;
            while (this.lifeRegenCount >= 120)
            {
                this.lifeRegenCount -= 120;
                if (this.statLife < this.statLifeMax)
                {
                    this.statLife++;
                }
                if (this.statLife > this.statLifeMax)
                {
                    this.statLife = this.statLifeMax;
                }
            }
            while (this.lifeRegenCount <= -120)
            {
                this.lifeRegenCount += 120;
                this.statLife--;
                if (this.statLife <= 0)
                {
                    if (this.poisoned)
                    {
                        this.KillMe(10.0, 0, false, " couldn't find the antidote");
                    }
                    else if (this.onFire)
                    {
                        this.KillMe(10.0, 0, false, " couldn't put the fire out");
                    }
                }
            }
            this.manaRegenCount += this.manaRegen;
            while (this.manaRegenCount >= 120)
            {
                bool flag5 = false;
                this.manaRegenCount -= 120;
                if (this.statMana < this.statManaMax2)
                {
                    this.statMana++;
                    flag5 = true;
                }
                if (this.statMana >= this.statManaMax2)
                {
                    if ((this.whoAmi == Main.myPlayer) && flag5)
                    {
                        Main.PlaySound(0x19, -1, -1, 1);
                        for (int num28 = 0; num28 < 5; num28++)
                        {
                            color = new Color();
                            int index = Dust.NewDust(this.position, this.width, this.height, 0x2d, 0f, 0f, 0xff, color, Main.rand.Next(20, 0x1a) * 0.1f);
                            Main.dust[index].noLight = true;
                            Main.dust[index].noGravity = true;
                            Dust dust1 = Main.dust[index];
                            dust1.velocity = (Vector2) (dust1.velocity * 0.5f);
                        }
                    }
                    this.statMana = this.statManaMax2;
                }
            }
            if (this.manaRegenCount < 0)
            {
                this.manaRegenCount = 0;
            }
            num4 *= this.moveSpeed;
            num3 *= this.moveSpeed;
            if (this.jumpBoost)
            {
                jumpHeight = 20;
                jumpSpeed = 6.51f;
            }
            if (!this.doubleJump)
            {
                this.jumpAgain = false;
            }
            else if (this.velocity.Y == 0f)
            {
                this.jumpAgain = true;
            }
            if (this.grappling[0] == -1)
            {
                if (this.controlLeft && (this.velocity.X > -num3))
                {
                    if (this.velocity.X > num5)
                    {
                        this.velocity.X -= num5;
                    }
                    this.velocity.X -= num4;
                    if ((this.itemAnimation == 0) || this.inventory[this.selectedItem].useTurn)
                    {
                        this.direction = -1;
                    }
                }
                else if (this.controlRight && (this.velocity.X < num3))
                {
                    if (this.velocity.X < -num5)
                    {
                        this.velocity.X += num5;
                    }
                    this.velocity.X += num4;
                    if ((this.itemAnimation == 0) || this.inventory[this.selectedItem].useTurn)
                    {
                        this.direction = 1;
                    }
                }
                else if (this.controlLeft && (this.velocity.X > -num6))
                {
                    if ((this.itemAnimation == 0) || this.inventory[this.selectedItem].useTurn)
                    {
                        this.direction = -1;
                    }
                    if (this.velocity.Y == 0f)
                    {
                        if (this.velocity.X > num5)
                        {
                            this.velocity.X -= num5;
                        }
                        this.velocity.X -= num4 * 0.2f;
                    }
                    if ((this.velocity.X < (-(num6 + num3) / 2f)) && (this.velocity.Y == 0f))
                    {
                        int num30 = 0;
                        if (this.gravDir == -1f)
                        {
                            num30 -= this.height;
                        }
                        if ((this.runSoundDelay == 0) && (this.velocity.Y == 0f))
                        {
                            Main.PlaySound(0x11, (int) this.position.X, (int) this.position.Y, 1);
                            this.runSoundDelay = 9;
                        }
                        color = new Color();
                        int num31 = Dust.NewDust(new Vector2(this.position.X - 4f, (this.position.Y + this.height) + num30), this.width + 8, 4, 0x10, -this.velocity.X * 0.5f, this.velocity.Y * 0.5f, 50, color, 1.5f);
                        Main.dust[num31].velocity.X *= 0.2f;
                        Main.dust[num31].velocity.Y *= 0.2f;
                    }
                }
                else if (this.controlRight && (this.velocity.X < num6))
                {
                    if ((this.itemAnimation == 0) || this.inventory[this.selectedItem].useTurn)
                    {
                        this.direction = 1;
                    }
                    if (this.velocity.Y == 0f)
                    {
                        if (this.velocity.X < -num5)
                        {
                            this.velocity.X += num5;
                        }
                        this.velocity.X += num4 * 0.2f;
                    }
                    if ((this.velocity.X > ((num6 + num3) / 2f)) && (this.velocity.Y == 0f))
                    {
                        int num32 = 0;
                        if (this.gravDir == -1f)
                        {
                            num32 -= this.height;
                        }
                        if ((this.runSoundDelay == 0) && (this.velocity.Y == 0f))
                        {
                            Main.PlaySound(0x11, (int) this.position.X, (int) this.position.Y, 1);
                            this.runSoundDelay = 9;
                        }
                        color = new Color();
                        int num33 = Dust.NewDust(new Vector2(this.position.X - 4f, (this.position.Y + this.height) + num32), this.width + 8, 4, 0x10, -this.velocity.X * 0.5f, this.velocity.Y * 0.5f, 50, color, 1.5f);
                        Main.dust[num33].velocity.X *= 0.2f;
                        Main.dust[num33].velocity.Y *= 0.2f;
                    }
                }
                else if (this.velocity.Y == 0f)
                {
                    if (this.velocity.X > num5)
                    {
                        this.velocity.X -= num5;
                    }
                    else if (this.velocity.X < -num5)
                    {
                        this.velocity.X += num5;
                    }
                    else
                    {
                        this.velocity.X = 0f;
                    }
                }
                else if (this.velocity.X > (num5 * 0.5))
                {
                    this.velocity.X -= num5 * 0.5f;
                }
                else if (this.velocity.X < (-num5 * 0.5))
                {
                    this.velocity.X += num5 * 0.5f;
                }
                else
                {
                    this.velocity.X = 0f;
                }
                if (this.gravControl)
                {
                    if (this.controlUp && (this.gravDir == 1f))
                    {
                        this.gravDir = -1f;
                        this.fallStart = (int) (this.position.Y / 16f);
                        this.jump = 0;
                        Main.PlaySound(2, (int) this.position.X, (int) this.position.Y, 8);
                    }
                    if (this.controlDown && (this.gravDir == -1f))
                    {
                        this.gravDir = 1f;
                        this.fallStart = (int) (this.position.Y / 16f);
                        this.jump = 0;
                        Main.PlaySound(2, (int) this.position.X, (int) this.position.Y, 8);
                    }
                }
                else
                {
                    this.gravDir = 1f;
                }
                if (this.controlJump)
                {
                    if (this.jump > 0)
                    {
                        if (this.velocity.Y == 0f)
                        {
                            this.jump = 0;
                        }
                        else
                        {
                            this.velocity.Y = -jumpSpeed * this.gravDir;
                            this.jump--;
                        }
                    }
                    else if ((((this.velocity.Y == 0f) || this.jumpAgain) || (this.wet && this.accFlipper)) && this.releaseJump)
                    {
                        bool flag6 = false;
                        if (this.wet && this.accFlipper)
                        {
                            if (this.swimTime == 0)
                            {
                                this.swimTime = 30;
                            }
                            flag6 = true;
                        }
                        this.jumpAgain = false;
                        this.canRocket = false;
                        this.rocketRelease = false;
                        if ((this.velocity.Y == 0f) && this.doubleJump)
                        {
                            this.jumpAgain = true;
                        }
                        if ((this.velocity.Y == 0f) || flag6)
                        {
                            this.velocity.Y = -jumpSpeed * this.gravDir;
                            this.jump = jumpHeight;
                        }
                        else
                        {
                            int num34 = this.height;
                            if (this.gravDir == -1f)
                            {
                                num34 = 0;
                            }
                            Main.PlaySound(0x10, (int) this.position.X, (int) this.position.Y, 1);
                            this.velocity.Y = -jumpSpeed * this.gravDir;
                            this.jump = jumpHeight / 2;
                            for (int num35 = 0; num35 < 10; num35++)
                            {
                                color = new Color();
                                int num36 = Dust.NewDust(new Vector2(this.position.X - 34f, (this.position.Y + num34) - 16f), 0x66, 0x20, 0x10, -this.velocity.X * 0.5f, this.velocity.Y * 0.5f, 100, color, 1.5f);
                                Main.dust[num36].velocity.X = (Main.dust[num36].velocity.X * 0.5f) - (this.velocity.X * 0.1f);
                                Main.dust[num36].velocity.Y = (Main.dust[num36].velocity.Y * 0.5f) - (this.velocity.Y * 0.3f);
                            }
                            int num37 = Gore.NewGore(new Vector2((this.position.X + (this.width / 2)) - 16f, (this.position.Y + num34) - 16f), new Vector2(-this.velocity.X, -this.velocity.Y), Main.rand.Next(11, 14), 1f);
                            Main.gore[num37].velocity.X = (Main.gore[num37].velocity.X * 0.1f) - (this.velocity.X * 0.1f);
                            Main.gore[num37].velocity.Y = (Main.gore[num37].velocity.Y * 0.1f) - (this.velocity.Y * 0.05f);
                            num37 = Gore.NewGore(new Vector2(this.position.X - 36f, (this.position.Y + num34) - 16f), new Vector2(-this.velocity.X, -this.velocity.Y), Main.rand.Next(11, 14), 1f);
                            Main.gore[num37].velocity.X = (Main.gore[num37].velocity.X * 0.1f) - (this.velocity.X * 0.1f);
                            Main.gore[num37].velocity.Y = (Main.gore[num37].velocity.Y * 0.1f) - (this.velocity.Y * 0.05f);
                            num37 = Gore.NewGore(new Vector2((this.position.X + this.width) + 4f, (this.position.Y + num34) - 16f), new Vector2(-this.velocity.X, -this.velocity.Y), Main.rand.Next(11, 14), 1f);
                            Main.gore[num37].velocity.X = (Main.gore[num37].velocity.X * 0.1f) - (this.velocity.X * 0.1f);
                            Main.gore[num37].velocity.Y = (Main.gore[num37].velocity.Y * 0.1f) - (this.velocity.Y * 0.05f);
                        }
                    }
                    this.releaseJump = false;
                }
                else
                {
                    this.jump = 0;
                    this.releaseJump = true;
                    this.rocketRelease = true;
                }
                if (((this.doubleJump && !this.jumpAgain) && (((this.gravDir == 1f) && (this.velocity.Y < 0f)) || ((this.gravDir == -1f) && (this.velocity.Y > 0f)))) && (!this.rocketBoots && !this.accFlipper))
                {
                    int num38 = this.height;
                    if (this.gravDir == -1f)
                    {
                        num38 = -6;
                    }
                    color = new Color();
                    int num39 = Dust.NewDust(new Vector2(this.position.X - 4f, this.position.Y + num38), this.width + 8, 4, 0x10, -this.velocity.X * 0.5f, this.velocity.Y * 0.5f, 100, color, 1.5f);
                    Main.dust[num39].velocity.X = (Main.dust[num39].velocity.X * 0.5f) - (this.velocity.X * 0.1f);
                    Main.dust[num39].velocity.Y = (Main.dust[num39].velocity.Y * 0.5f) - (this.velocity.Y * 0.3f);
                }
                if ((((this.gravDir == 1f) && (this.velocity.Y > -jumpSpeed)) || ((this.gravDir == -1f) && (this.velocity.Y < jumpSpeed))) && (this.velocity.Y != 0f))
                {
                    this.canRocket = true;
                }
                if (this.velocity.Y == 0f)
                {
                    this.rocketTime = this.rocketTimeMax;
                }
                if (((this.rocketBoots && this.controlJump) && ((this.rocketDelay == 0) && this.canRocket)) && (this.rocketRelease && !this.jumpAgain))
                {
                    if (this.rocketTime > 0)
                    {
                        this.rocketTime--;
                        this.rocketDelay = 10;
                        if (this.rocketDelay2 <= 0)
                        {
                            Main.PlaySound(2, (int) this.position.X, (int) this.position.Y, 13);
                            this.rocketDelay2 = 30;
                        }
                    }
                    else
                    {
                        this.canRocket = false;
                    }
                }
                if (this.rocketDelay2 > 0)
                {
                    this.rocketDelay2--;
                }
                if (this.rocketDelay == 0)
                {
                    this.rocketFrame = false;
                }
                if (this.rocketDelay > 0)
                {
                    int num40 = this.height;
                    if (this.gravDir == -1f)
                    {
                        num40 = 4;
                    }
                    this.rocketFrame = true;
                    for (int num41 = 0; num41 < 2; num41++)
                    {
                        int type = 6;
                        float scale = 2.5f;
                        if (this.socialShadow)
                        {
                            type = 0x1b;
                            scale = 1.5f;
                        }
                        if (num41 == 0)
                        {
                            color = new Color();
                            int num44 = Dust.NewDust(new Vector2(this.position.X - 4f, (this.position.Y + num40) - 10f), 8, 8, type, 0f, 0f, 100, color, scale);
                            Main.dust[num44].noGravity = true;
                            Main.dust[num44].velocity.X = ((Main.dust[num44].velocity.X * 1f) - 2f) - (this.velocity.X * 0.3f);
                            Main.dust[num44].velocity.Y = ((Main.dust[num44].velocity.Y * 1f) + (2f * this.gravDir)) - (this.velocity.Y * 0.3f);
                        }
                        else
                        {
                            color = new Color();
                            int num45 = Dust.NewDust(new Vector2((this.position.X + this.width) - 4f, (this.position.Y + num40) - 10f), 8, 8, type, 0f, 0f, 100, color, scale);
                            Main.dust[num45].noGravity = true;
                            Main.dust[num45].velocity.X = ((Main.dust[num45].velocity.X * 1f) + 2f) - (this.velocity.X * 0.3f);
                            Main.dust[num45].velocity.Y = ((Main.dust[num45].velocity.Y * 1f) + (2f * this.gravDir)) - (this.velocity.Y * 0.3f);
                        }
                    }
                    if (this.rocketDelay == 0)
                    {
                        this.releaseJump = true;
                    }
                    this.rocketDelay--;
                    this.velocity.Y -= 0.1f * this.gravDir;
                    if (this.gravDir == 1f)
                    {
                        if (this.velocity.Y > 0f)
                        {
                            this.velocity.Y -= 0.5f;
                        }
                        else if (this.velocity.Y > (-jumpSpeed * 0.5))
                        {
                            this.velocity.Y -= 0.1f;
                        }
                        if (this.velocity.Y < (-jumpSpeed * 1.5f))
                        {
                            this.velocity.Y = -jumpSpeed * 1.5f;
                        }
                    }
                    else
                    {
                        if (this.velocity.Y < 0f)
                        {
                            this.velocity.Y += 0.5f;
                        }
                        else if (this.velocity.Y < (jumpSpeed * 0.5))
                        {
                            this.velocity.Y += 0.1f;
                        }
                        if (this.velocity.Y > (jumpSpeed * 1.5f))
                        {
                            this.velocity.Y = jumpSpeed * 1.5f;
                        }
                    }
                }
                else if (this.slowFall && ((!this.controlDown && (this.gravDir == 1f)) || (!this.controlUp && (this.gravDir == -1f))))
                {
                    if ((this.controlUp && (this.gravDir == 1f)) || (this.controlDown && (this.gravDir == -1f)))
                    {
                        this.velocity.Y += (num2 / 10f) * this.gravDir;
                    }
                    else
                    {
                        this.velocity.Y += (num2 / 3f) * this.gravDir;
                    }
                }
                else
                {
                    this.velocity.Y += num2 * this.gravDir;
                }
                if (this.gravDir == 1f)
                {
                    if (this.velocity.Y > num)
                    {
                        this.velocity.Y = num;
                    }
                    if ((this.slowFall && (this.velocity.Y > (num / 3f))) && !this.controlDown)
                    {
                        this.velocity.Y = num / 3f;
                    }
                    if ((this.slowFall && (this.velocity.Y > (num / 5f))) && this.controlUp)
                    {
                        this.velocity.Y = num / 10f;
                    }
                }
                else
                {
                    if (this.velocity.Y < -num)
                    {
                        this.velocity.Y = -num;
                    }
                    if ((this.slowFall && (this.velocity.Y < (-num / 3f))) && !this.controlUp)
                    {
                        this.velocity.Y = -num / 3f;
                    }
                    if ((this.slowFall && (this.velocity.Y < (-num / 5f))) && this.controlDown)
                    {
                        this.velocity.Y = -num / 10f;
                    }
                }
            }
            for (int n = 0; n < 200; n++)
            {
                if ((Main.item[n].active && (Main.item[n].noGrabDelay == 0)) && (Main.item[n].owner == i))
                {
                    Rectangle rectangle6 = new Rectangle((int) this.position.X, (int) this.position.Y, this.width, this.height);
                    if (rectangle6.Intersects(new Rectangle((int) Main.item[n].position.X, (int) Main.item[n].position.Y, Main.item[n].width, Main.item[n].height)))
                    {
                        if ((i == Main.myPlayer) && ((this.inventory[this.selectedItem].type != 0) || (this.itemAnimation <= 0)))
                        {
                            if (Main.item[n].type == 0x3a)
                            {
                                Main.PlaySound(7, (int) this.position.X, (int) this.position.Y, 1);
                                this.statLife += 20;
                                if (Main.myPlayer == this.whoAmi)
                                {
                                    this.HealEffect(20);
                                }
                                if (this.statLife > this.statLifeMax)
                                {
                                    this.statLife = this.statLifeMax;
                                }
                                Main.item[n] = new Item();
                                if (Main.netMode == 1)
                                {
                                    NetMessage.SendData(0x15, -1, -1, "", n, 0f, 0f, 0f, 0);
                                }
                            }
                            else if (Main.item[n].type == 0xb8)
                            {
                                Main.PlaySound(7, (int) this.position.X, (int) this.position.Y, 1);
                                this.statMana += 100;
                                if (Main.myPlayer == this.whoAmi)
                                {
                                    this.ManaEffect(100);
                                }
                                if (this.statMana > this.statManaMax2)
                                {
                                    this.statMana = this.statManaMax2;
                                }
                                Main.item[n] = new Item();
                                if (Main.netMode == 1)
                                {
                                    NetMessage.SendData(0x15, -1, -1, "", n, 0f, 0f, 0f, 0);
                                }
                            }
                            else
                            {
                                Main.item[n] = this.GetItem(i, Main.item[n]);
                                if (Main.netMode == 1)
                                {
                                    NetMessage.SendData(0x15, -1, -1, "", n, 0f, 0f, 0f, 0);
                                }
                            }
                        }
                    }
                    else
                    {
                        rectangle6 = new Rectangle(((int) this.position.X) - itemGrabRange, ((int) this.position.Y) - itemGrabRange, this.width + (itemGrabRange * 2), this.height + (itemGrabRange * 2));
                        if (rectangle6.Intersects(new Rectangle((int) Main.item[n].position.X, (int) Main.item[n].position.Y, Main.item[n].width, Main.item[n].height)) && this.ItemSpace(Main.item[n]))
                        {
                            Main.item[n].beingGrabbed = true;
                            if ((this.position.X + (this.width * 0.5)) > (Main.item[n].position.X + (Main.item[n].width * 0.5)))
                            {
                                if (Main.item[n].velocity.X < (itemGrabSpeedMax + this.velocity.X))
                                {
                                    Main.item[n].velocity.X += itemGrabSpeed;
                                }
                                if (Main.item[n].velocity.X < 0f)
                                {
                                    Main.item[n].velocity.X += itemGrabSpeed * 0.75f;
                                }
                            }
                            else
                            {
                                if (Main.item[n].velocity.X > (-itemGrabSpeedMax + this.velocity.X))
                                {
                                    Main.item[n].velocity.X -= itemGrabSpeed;
                                }
                                if (Main.item[n].velocity.X > 0f)
                                {
                                    Main.item[n].velocity.X -= itemGrabSpeed * 0.75f;
                                }
                            }
                            if ((this.position.Y + (this.height * 0.5)) > (Main.item[n].position.Y + (Main.item[n].height * 0.5)))
                            {
                                if (Main.item[n].velocity.Y < itemGrabSpeedMax)
                                {
                                    Main.item[n].velocity.Y += itemGrabSpeed;
                                }
                                if (Main.item[n].velocity.Y < 0f)
                                {
                                    Main.item[n].velocity.Y += itemGrabSpeed * 0.75f;
                                }
                            }
                            else
                            {
                                if (Main.item[n].velocity.Y > -itemGrabSpeedMax)
                                {
                                    Main.item[n].velocity.Y -= itemGrabSpeed;
                                }
                                if (Main.item[n].velocity.Y > 0f)
                                {
                                    Main.item[n].velocity.Y -= itemGrabSpeed * 0.75f;
                                }
                            }
                        }
                    }
                }
            }
            if ((((((this.position.X / 16f) - tileRangeX) <= Player.tileTargetX) && (((((this.position.X + this.width) / 16f) + tileRangeX) - 1f) >= Player.tileTargetX)) && ((((this.position.Y / 16f) - tileRangeY) <= Player.tileTargetY) && (((((this.position.Y + this.height) / 16f) + tileRangeY) - 2f) >= Player.tileTargetY))) && Main.tile[Player.tileTargetX, Player.tileTargetY].active)
            {
                if (Main.tile[Player.tileTargetX, Player.tileTargetY].type == 0x68)
                {
                    this.showItemIcon = true;
                    this.showItemIcon2 = 0x167;
                }
                if (Main.tile[Player.tileTargetX, Player.tileTargetY].type == 0x4f)
                {
                    this.showItemIcon = true;
                    this.showItemIcon2 = 0xe0;
                }
                if (Main.tile[Player.tileTargetX, Player.tileTargetY].type == 0x15)
                {
                    this.showItemIcon = true;
                    if (Main.tile[Player.tileTargetX, Player.tileTargetY].frameX >= 0xd8)
                    {
                        this.showItemIcon2 = 0x15c;
                    }
                    else if (Main.tile[Player.tileTargetX, Player.tileTargetY].frameX >= 180)
                    {
                        this.showItemIcon2 = 0x157;
                    }
                    else if (Main.tile[Player.tileTargetX, Player.tileTargetY].frameX >= 0x90)
                    {
                        this.showItemIcon2 = 0x149;
                    }
                    else if (Main.tile[Player.tileTargetX, Player.tileTargetY].frameX >= 0x6c)
                    {
                        this.showItemIcon2 = 0x148;
                    }
                    else if (Main.tile[Player.tileTargetX, Player.tileTargetY].frameX >= 0x48)
                    {
                        this.showItemIcon2 = 0x147;
                    }
                    else if (Main.tile[Player.tileTargetX, Player.tileTargetY].frameX >= 0x24)
                    {
                        this.showItemIcon2 = 0x132;
                    }
                    else
                    {
                        this.showItemIcon2 = 0x30;
                    }
                }
                if (Main.tile[Player.tileTargetX, Player.tileTargetY].type == 4)
                {
                    this.showItemIcon = true;
                    this.showItemIcon2 = 8;
                }
                if (Main.tile[Player.tileTargetX, Player.tileTargetY].type == 13)
                {
                    this.showItemIcon = true;
                    if (Main.tile[Player.tileTargetX, Player.tileTargetY].frameX == 0x48)
                    {
                        this.showItemIcon2 = 0x15f;
                    }
                    else if (Main.tile[Player.tileTargetX, Player.tileTargetY].frameX == 0x36)
                    {
                        this.showItemIcon2 = 350;
                    }
                    else if (Main.tile[Player.tileTargetX, Player.tileTargetY].frameX == 0x12)
                    {
                        this.showItemIcon2 = 0x1c;
                    }
                    else if (Main.tile[Player.tileTargetX, Player.tileTargetY].frameX == 0x24)
                    {
                        this.showItemIcon2 = 110;
                    }
                    else
                    {
                        this.showItemIcon2 = 0x1f;
                    }
                }
                if (Main.tile[Player.tileTargetX, Player.tileTargetY].type == 0x1d)
                {
                    this.showItemIcon = true;
                    this.showItemIcon2 = 0x57;
                }
                if (Main.tile[Player.tileTargetX, Player.tileTargetY].type == 0x61)
                {
                    this.showItemIcon = true;
                    this.showItemIcon2 = 0x15a;
                }
                if (Main.tile[Player.tileTargetX, Player.tileTargetY].type == 0x21)
                {
                    this.showItemIcon = true;
                    this.showItemIcon2 = 0x69;
                }
                if (Main.tile[Player.tileTargetX, Player.tileTargetY].type == 0x31)
                {
                    this.showItemIcon = true;
                    this.showItemIcon2 = 0x94;
                }
                if ((Main.tile[Player.tileTargetX, Player.tileTargetY].type == 50) && (Main.tile[Player.tileTargetX, Player.tileTargetY].frameX == 90))
                {
                    this.showItemIcon = true;
                    this.showItemIcon2 = 0xa5;
                }
                if ((Main.tile[Player.tileTargetX, Player.tileTargetY].type == 0x37) || (Main.tile[Player.tileTargetX, Player.tileTargetY].type == 0x55))
                {
                    int num47 = Main.tile[Player.tileTargetX, Player.tileTargetY].frameX / 0x12;
                    int num48 = Main.tile[Player.tileTargetX, Player.tileTargetY].frameY / 0x12;
                    while (num47 > 1)
                    {
                        num47 -= 2;
                    }
                    int num49 = Player.tileTargetX - num47;
                    int num50 = Player.tileTargetY - num48;
                    Main.signBubble = true;
                    Main.signX = (num49 * 0x10) + 0x10;
                    Main.signY = num50 * 0x10;
                }
                if ((Main.tile[Player.tileTargetX, Player.tileTargetY].type == 10) || (Main.tile[Player.tileTargetX, Player.tileTargetY].type == 11))
                {
                    this.showItemIcon = true;
                    this.showItemIcon2 = 0x19;
                }
                if (!this.controlUseTile)
                {
                    this.releaseUseTile = true;
                }
                else
                {
                    if (this.releaseUseTile)
                    {
                        if (((Main.tile[Player.tileTargetX, Player.tileTargetY].type == 4) || (Main.tile[Player.tileTargetX, Player.tileTargetY].type == 13)) || (((Main.tile[Player.tileTargetX, Player.tileTargetY].type == 0x21) || (Main.tile[Player.tileTargetX, Player.tileTargetY].type == 0x31)) || ((Main.tile[Player.tileTargetX, Player.tileTargetY].type == 50) && (Main.tile[Player.tileTargetX, Player.tileTargetY].frameX == 90))))
                        {
                            WorldGen.KillTile(Player.tileTargetX, Player.tileTargetY, false, false, false);
                            if (Main.netMode == 1)
                            {
                                NetMessage.SendData(0x11, -1, -1, "", 0, (float) Player.tileTargetX, (float) Player.tileTargetY, 0f, 0);
                            }
                        }
                        else if (Main.tile[Player.tileTargetX, Player.tileTargetY].type == 0x4f)
                        {
                            int tileTargetX = Player.tileTargetX;
                            int tileTargetY = Player.tileTargetY;
                            tileTargetX += (Main.tile[Player.tileTargetX, Player.tileTargetY].frameX / 0x12) * -1;
                            if (Main.tile[Player.tileTargetX, Player.tileTargetY].frameX >= 0x48)
                            {
                                tileTargetX += 4;
                                tileTargetX++;
                            }
                            else
                            {
                                tileTargetX += 2;
                            }
                            tileTargetY += (Main.tile[Player.tileTargetX, Player.tileTargetY].frameY / 0x12) * -1;
                            tileTargetY += 2;
                            if (CheckSpawn(tileTargetX, tileTargetY))
                            {
                                this.ChangeSpawn(tileTargetX, tileTargetY);
                                Main.NewText("Spawn point set!", 0xff, 240, 20);
                            }
                        }
                        else if ((Main.tile[Player.tileTargetX, Player.tileTargetY].type == 0x37) || (Main.tile[Player.tileTargetX, Player.tileTargetY].type == 0x55))
                        {
                            bool flag7 = true;
                            if ((this.sign >= 0) && (Sign.ReadSign(Player.tileTargetX, Player.tileTargetY) == this.sign))
                            {
                                this.sign = -1;
                                Main.npcChatText = "";
                                Main.editSign = false;
                                Main.PlaySound(11, -1, -1, 1);
                                flag7 = false;
                            }
                            if (flag7)
                            {
                                    int num55 = Main.tile[Player.tileTargetX, Player.tileTargetY].frameX / 0x12;
                                    int num56 = Main.tile[Player.tileTargetX, Player.tileTargetY].frameY / 0x12;
                                    while (num55 > 1)
                                    {
                                        num55 -= 2;
                                    }
                                    int number = Player.tileTargetX - num55;
                                    int num58 = Player.tileTargetY - num56;
                                    if ((Main.tile[number, num58].type == 0x37) || (Main.tile[number, num58].type == 0x55))
                                    {
                                        NetMessage.SendData(0x2e, -1, -1, "", number, (float) num58, 0f, 0f, 0);
                                    }
                            }
                        }
                        else if (Main.tile[Player.tileTargetX, Player.tileTargetY].type == 0x68)
                        {
                            string str2 = "AM";
                            double time = Main.time;
                            if (!Main.dayTime)
                            {
                                time += 54000.0;
                            }
                            time = (time / 86400.0) * 24.0;
                            double num60 = 7.5;
                            time = (time - num60) - 12.0;
                            if (time < 0.0)
                            {
                                time += 24.0;
                            }
                            if (time >= 12.0)
                            {
                                str2 = "PM";
                            }
                            int num61 = (int) time;
                            double num62 = time - num61;
                            num62 = (int) (num62 * 60.0);
                            string str3 = num62.ToString();
                            if (num62 < 10.0)
                            {
                                str3 = "0" + str3;
                            }
                            if (num61 > 12)
                            {
                                num61 -= 12;
                            }
                            if (num61 == 0)
                            {
                                num61 = 12;
                            }
                            Main.NewText(string.Concat(new object[] { "Time: ", num61, ":", str3, " ", str2 }), 0xff, 240, 20);
                        }
                        else if (Main.tile[Player.tileTargetX, Player.tileTargetY].type == 10)
                        {
                            WorldGen.OpenDoor(Player.tileTargetX, Player.tileTargetY, this.direction);
                            NetMessage.SendData(0x13, -1, -1, "", 0, (float) Player.tileTargetX, (float) Player.tileTargetY, (float) this.direction, 0);
                        }
                        else if (Main.tile[Player.tileTargetX, Player.tileTargetY].type == 11)
                        {
                            if (WorldGen.CloseDoor(Player.tileTargetX, Player.tileTargetY, false))
                            {
                                NetMessage.SendData(0x13, -1, -1, "", 1, (float) Player.tileTargetX, (float) Player.tileTargetY, (float) this.direction, 0);
                            }
                        }
                        else if ((((Main.tile[Player.tileTargetX, Player.tileTargetY].type == 0x15) || (Main.tile[Player.tileTargetX, Player.tileTargetY].type == 0x1d)) || (Main.tile[Player.tileTargetX, Player.tileTargetY].type == 0x61)) && (this.talkNPC == -1))
                        {
                            int num63 = 0;
                            int num64 = Main.tile[Player.tileTargetX, Player.tileTargetY].frameX / 0x12;
                            while (num64 > 1)
                            {
                                num64 -= 2;
                            }
                            num64 = Player.tileTargetX - num64;
                            int y = Player.tileTargetY - (Main.tile[Player.tileTargetX, Player.tileTargetY].frameY / 0x12);
                            if (Main.tile[Player.tileTargetX, Player.tileTargetY].type == 0x1d)
                            {
                                num63 = 1;
                            }
                            else if (Main.tile[Player.tileTargetX, Player.tileTargetY].type == 0x61)
                            {
                                num63 = 2;
                            }
                            else if (Main.tile[Player.tileTargetX, Player.tileTargetY].frameX >= 0xd8)
                            {
                                Main.chestText = "Trash Can";
                            }
                            else if (Main.tile[Player.tileTargetX, Player.tileTargetY].frameX >= 180)
                            {
                                Main.chestText = "Barrel";
                            }
                            else
                            {
                                Main.chestText = "Chest";
                            }
                            if ((((Main.netMode == 1) && (num63 == 0)) && ((Main.tile[num64, y].frameX < 0x48) || (Main.tile[num64, y].frameX > 0x6a))) && ((Main.tile[num64, y].frameX < 0x90) || (Main.tile[num64, y].frameX > 0xb2)))
                            {
                                if (((num64 == this.chestX) && (y == this.chestY)) && (this.chest != -1))
                                {
                                    this.chest = -1;
                                    Main.PlaySound(11, -1, -1, 1);
                                }
                                else
                                {
                                    NetMessage.SendData(0x1f, -1, -1, "", num64, (float) y, 0f, 0f, 0);
                                }
                            }
                            else
                            {
                                int num66 = -1;
                                switch (num63)
                                {
                                    case 1:
                                        num66 = -2;
                                        break;

                                    case 2:
                                        num66 = -3;
                                        break;

                                    default:
                                    {
                                        bool flag8 = false;
                                        if (((Main.tile[num64, y].frameX >= 0x48) && (Main.tile[num64, y].frameX <= 0x6a)) || ((Main.tile[num64, y].frameX >= 0x90) && (Main.tile[num64, y].frameX <= 0xb2)))
                                        {
                                            int num67 = 0x147;
                                            if ((Main.tile[num64, y].frameX >= 0x90) && (Main.tile[num64, y].frameX <= 0xb2))
                                            {
                                                num67 = 0x149;
                                            }
                                            flag8 = true;
                                            for (int num68 = 0; num68 < 0x2c; num68++)
                                            {
                                                if ((this.inventory[num68].type == num67) && (this.inventory[num68].stack > 0))
                                                {
                                                    if (num67 != 0x149)
                                                    {
                                                        Item item1 = this.inventory[num68];
                                                        item1.stack--;
                                                        if (this.inventory[num68].stack <= 0)
                                                        {
                                                            this.inventory[num68] = new Item();
                                                        }
                                                    }
                                                    Chest.Unlock(num64, y);
                                                    if (Main.netMode == 1)
                                                    {
                                                        NetMessage.SendData(0x34, -1, -1, "", this.whoAmi, 1f, (float) num64, (float) y, 0);
                                                    }
                                                }
                                            }
                                        }
                                        if (!flag8)
                                        {
                                            num66 = Chest.FindChest(num64, y);
                                        }
                                        break;
                                    }
                                }
                                if (num66 != -1)
                                {
                                    if (num66 == this.chest)
                                    {
                                        this.chest = -1;
                                        Main.PlaySound(11, -1, -1, 1);
                                    }
                                    else if ((num66 != this.chest) && (this.chest == -1))
                                    {
                                        this.chest = num66;
                                        Main.playerInventory = true;
                                        Main.PlaySound(10, -1, -1, 1);
                                        this.chestX = num64;
                                        this.chestY = y;
                                    }
                                    else
                                    {
                                        this.chest = num66;
                                        Main.playerInventory = true;
                                        Main.PlaySound(12, -1, -1, 1);
                                        this.chestX = num64;
                                        this.chestY = y;
                                    }
                                }
                            }
                        }
                    }
                    this.releaseUseTile = false;
                }
            }
            if (Main.myPlayer == this.whoAmi)
            {
                if (this.controlHook)
                {
                    if (this.releaseHook)
                    {
                        this.QuickGrapple();
                    }
                    this.releaseHook = false;
                }
                else
                {
                    this.releaseHook = true;
                }
                if (this.talkNPC >= 0)
                {
                    Rectangle rectangle = new Rectangle((((int) this.position.X) + (this.width / 2)) - (tileRangeX * 0x10), (((int) this.position.Y) + (this.height / 2)) - (tileRangeY * 0x10), (tileRangeX * 0x10) * 2, (tileRangeY * 0x10) * 2);
                    Rectangle rectangle2 = new Rectangle((int) Main.npc[this.talkNPC].position.X, (int) Main.npc[this.talkNPC].position.Y, Main.npc[this.talkNPC].width, Main.npc[this.talkNPC].height);
                    if ((!rectangle.Intersects(rectangle2) || (this.chest != -1)) || !Main.npc[this.talkNPC].active)
                    {
                        if (this.chest == -1)
                        {
                            Main.PlaySound(11, -1, -1, 1);
                        }
                        this.talkNPC = -1;
                        Main.npcChatText = "";
                    }
                }
                if (this.sign >= 0)
                {
                    Rectangle rectangle3 = new Rectangle((((int) this.position.X) + (this.width / 2)) - (tileRangeX * 0x10), (((int) this.position.Y) + (this.height / 2)) - (tileRangeY * 0x10), (tileRangeX * 0x10) * 2, (tileRangeY * 0x10) * 2);
                    try
                    {
                        Rectangle rectangle4 = new Rectangle(Main.sign[this.sign].x * 0x10, Main.sign[this.sign].y * 0x10, 0x20, 0x20);
                        if (!rectangle3.Intersects(rectangle4))
                        {
                            Main.PlaySound(11, -1, -1, 1);
                            this.sign = -1;
                            Main.editSign = false;
                            Main.npcChatText = "";
                        }
                    }
                    catch
                    {
                        Main.PlaySound(11, -1, -1, 1);
                        this.sign = -1;
                        Main.editSign = false;
                        Main.npcChatText = "";
                    }
                }
                if (Main.editSign)
                {
                    if (this.sign == -1)
                    {
                        Main.editSign = false;
                    }
                    else
                    {
                        Main.npcChatText = Main.GetInputText(Main.npcChatText);
                        if (Main.inputTextEnter)
                        {
                            byte[] bytes = new byte[] { 10 };
                            Main.npcChatText = Main.npcChatText + Encoding.ASCII.GetString(bytes);
                        }
                    }
                }
                if (!this.immune)
                {
                    Rectangle rectangle5 = new Rectangle((int) this.position.X, (int) this.position.Y, this.width, this.height);
                    for (int num69 = 0; num69 < 0x3e8; num69++)
                    {
                        if ((Main.npc[num69].active && !Main.npc[num69].friendly) && ((Main.npc[num69].damage > 0) && rectangle5.Intersects(new Rectangle((int) Main.npc[num69].position.X, (int) Main.npc[num69].position.Y, Main.npc[num69].width, Main.npc[num69].height))))
                        {
                            int hitDirection = -1;
                            if ((Main.npc[num69].position.X + (Main.npc[num69].width / 2)) < (this.position.X + (this.width / 2)))
                            {
                                hitDirection = 1;
                            }
                            int num71 = Main.DamageVar((float) Main.npc[num69].damage);
                            if (((this.whoAmi == Main.myPlayer) && this.thorns) && !this.immune)
                            {
                                int num72 = num71 / 3;
                                int num73 = 10;
                                Main.npc[num69].StrikeNPC(num72, (float) num73, -hitDirection, false);
                                if (Main.netMode != 0)
                                {
                                    NetMessage.SendData(0x1c, -1, -1, "", num69, (float) num72, (float) num73, (float) -hitDirection, 0);
                                }
                            }
                            if (!this.immune)
                            {
                                if (((Main.npc[num69].type == 1) && (Main.npc[num69].name == "Black Slime")) && (Main.rand.Next(4) == 0))
                                {
                                    this.AddBuff(0x16, 900, true);
                                }
                                if (((Main.npc[num69].type == 0x17) || (Main.npc[num69].type == 0x19)) && (Main.rand.Next(3) == 0))
                                {
                                    this.AddBuff(0x18, 420, true);
                                }
                                if ((Main.npc[num69].type == 0x22) && (Main.rand.Next(3) == 0))
                                {
                                    this.AddBuff(0x17, 240, true);
                                }
                            }
                            this.Hurt(num71, hitDirection, false, false, getDeathMessage(-1, num69, -1, -1), false);
                        }
                    }
                }
                Vector2 vector = Collision.HurtTiles(this.position, this.velocity, this.width, this.height, this.fireWalk);
                if (vector.Y != 0f)
                {
                    int num74 = Main.DamageVar(vector.Y);
                    this.Hurt(num74, 0, false, false, getDeathMessage(-1, -1, -1, 3), false);
                }
            }
            if (this.grappling[0] >= 0)
            {
                this.rocketTime = this.rocketTimeMax;
                this.rocketDelay = 0;
                this.rocketFrame = false;
                this.canRocket = false;
                this.rocketRelease = false;
                this.fallStart = (int) (this.position.Y / 16f);
                float num75 = 0f;
                float num76 = 0f;
                for (int num77 = 0; num77 < this.grapCount; num77++)
                {
                    num75 += Main.projectile[this.grappling[num77]].position.X + (Main.projectile[this.grappling[num77]].width / 2);
                    num76 += Main.projectile[this.grappling[num77]].position.Y + (Main.projectile[this.grappling[num77]].height / 2);
                }
                num75 /= (float) this.grapCount;
                num76 /= (float) this.grapCount;
                Vector2 vector2 = new Vector2(this.position.X + (this.width * 0.5f), this.position.Y + (this.height * 0.5f));
                float num78 = num75 - vector2.X;
                float num79 = num76 - vector2.Y;
                float num80 = (float) Math.Sqrt((double) ((num78 * num78) + (num79 * num79)));
                float num81 = 11f;
                float num82 = num80;
                if (num80 > num81)
                {
                    num82 = num81 / num80;
                }
                else
                {
                    num82 = 1f;
                }
                num78 *= num82;
                num79 *= num82;
                this.velocity.X = num78;
                this.velocity.Y = num79;
                if (this.itemAnimation == 0)
                {
                    if (this.velocity.X > 0f)
                    {
                        this.direction = 1;
                    }
                    if (this.velocity.X < 0f)
                    {
                        this.direction = -1;
                    }
                }
                if (this.controlJump)
                {
                    if (this.releaseJump)
                    {
                        if (((this.velocity.Y == 0f) || ((this.wet && (this.velocity.Y > -0.02)) && (this.velocity.Y < 0.02))) && !this.controlDown)
                        {
                            this.velocity.Y = -jumpSpeed;
                            this.jump = jumpHeight / 2;
                            this.releaseJump = false;
                        }
                        else
                        {
                            this.velocity.Y += 0.01f;
                            this.releaseJump = false;
                        }
                        if (this.doubleJump)
                        {
                            this.jumpAgain = true;
                        }
                        this.grappling[0] = 0;
                        this.grapCount = 0;
                        for (int num83 = 0; num83 < 0x3e8; num83++)
                        {
                            if ((Main.projectile[num83].active && (Main.projectile[num83].owner == i)) && (Main.projectile[num83].aiStyle == 7))
                            {
                                Main.projectile[num83].Kill();
                            }
                        }
                    }
                }
                else
                {
                    this.releaseJump = true;
                }
            }
            int num84 = this.width / 2;
            int num85 = this.height / 2;
            new Vector2((this.position.X + (this.width / 2)) - (num84 / 2), (this.position.Y + (this.height / 2)) - (num85 / 2));
            Vector2 vector3 = Collision.StickyTiles(this.position, this.velocity, this.width, this.height);
            if ((vector3.Y != -1f) && (vector3.X != -1f))
            {
                if ((this.whoAmi == Main.myPlayer) && ((this.velocity.X != 0f) || (this.velocity.Y != 0f)))
                {
                    this.stickyBreak++;
                    if (this.stickyBreak > Main.rand.Next(20, 100))
                    {
                        this.stickyBreak = 0;
                        int x = (int) vector3.X;
                        int num87 = (int) vector3.Y;
                        WorldGen.KillTile(x, num87, false, false, false);
                        if (((Main.netMode == 1) && !Main.tile[x, num87].active) && (Main.netMode == 1))
                        {
                            NetMessage.SendData(0x11, -1, -1, "", 0, (float) x, (float) num87, 0f, 0);
                        }
                    }
                }
                this.fallStart = (int) (this.position.Y / 16f);
                this.jump = 0;
                if (this.velocity.X > 1f)
                {
                    this.velocity.X = 1f;
                }
                if (this.velocity.X < -1f)
                {
                    this.velocity.X = -1f;
                }
                if (this.velocity.Y > 1f)
                {
                    this.velocity.Y = 1f;
                }
                if (this.velocity.Y < -5f)
                {
                    this.velocity.Y = -5f;
                }
                if ((this.velocity.X > 0.75) || (this.velocity.X < -0.75))
                {
                    this.velocity.X *= 0.85f;
                }
                else
                {
                    this.velocity.X *= 0.6f;
                }
                if (this.velocity.Y < 0f)
                {
                    this.velocity.Y *= 0.96f;
                }
                else
                {
                    this.velocity.Y *= 0.3f;
                }
            }
            else
            {
                this.stickyBreak = 0;
            }
            bool flag9 = Collision.DrownCollision(this.position, this.width, this.height, this.gravDir);
            if (this.armor[0].type == 250)
            {
                flag9 = true;
            }
            if (this.inventory[this.selectedItem].type == 0xba)
            {
                try
                {
                    int num88 = (int) (((this.position.X + (this.width / 2)) + (6 * this.direction)) / 16f);
                    int num89 = 0;
                    if (this.gravDir == -1f)
                    {
                        num89 = this.height;
                    }
                    int num90 = (int) (((this.position.Y + num89) - (44f * this.gravDir)) / 16f);
                    if (Main.tile[num88, num90].liquid < 0x80)
                    {
                        if (Main.tile[num88, num90] == null)
                        {
                            Main.tile[num88, num90] = new Tile();
                        }
                        if ((!Main.tile[num88, num90].active || !Main.tileSolid[Main.tile[num88, num90].type]) || Main.tileSolidTop[Main.tile[num88, num90].type])
                        {
                            flag9 = false;
                        }
                    }
                }
                catch
                {
                }
            }
            if (this.gills)
            {
                if (flag9)
                {
                    flag9 = false;
                }
                else
                {
                    flag9 = true;
                }
            }
            if (Main.myPlayer == i)
            {
                if (flag9)
                {
                    this.breathCD++;
                    int num91 = 7;
                    if (this.inventory[this.selectedItem].type == 0xba)
                    {
                        num91 *= 2;
                    }
                    if (this.armor[0].type == 0x10c)
                    {
                        num91 *= 4;
                    }
                    if (this.breathCD >= num91)
                    {
                        this.breathCD = 0;
                        this.breath--;
                        if (this.breath == 0)
                        {
                            Main.PlaySound(0x17, -1, -1, 1);
                        }
                        if (this.breath <= 0)
                        {
                            this.lifeRegenTime = 0;
                            this.breath = 0;
                            this.statLife -= 2;
                            if (this.statLife <= 0)
                            {
                                this.statLife = 0;
                                this.KillMe(10.0, 0, false, getDeathMessage(-1, -1, -1, 1));
                            }
                        }
                    }
                }
                else
                {
                    this.breath += 3;
                    if (this.breath > this.breathMax)
                    {
                        this.breath = this.breathMax;
                    }
                    this.breathCD = 0;
                }
            }
            if ((flag9 && (Main.rand.Next(20) == 0)) && !this.lavaWet)
            {
                int num92 = 0;
                if (this.gravDir == -1f)
                {
                    num92 += this.height - 12;
                }
                if (this.inventory[this.selectedItem].type == 0xba)
                {
                    color = new Color();
                    Dust.NewDust(new Vector2((this.position.X + (10 * this.direction)) + 4f, (this.position.Y + num92) - (54f * this.gravDir)), this.width - 8, 8, 0x22, 0f, 0f, 0, color, 1.2f);
                }
                else
                {
                    color = new Color();
                    Dust.NewDust(new Vector2(this.position.X + (12 * this.direction), (this.position.Y + num92) + (4f * this.gravDir)), this.width - 8, 8, 0x22, 0f, 0f, 0, color, 1.2f);
                }
            }
            int height = this.height;
            if (this.waterWalk)
            {
                height -= 6;
            }
            bool flag10 = Collision.LavaCollision(this.position, this.width, height);
            if (flag10)
            {
                if ((!this.lavaImmune && (Main.myPlayer == i)) && !this.immune)
                {
                    this.AddBuff(0x18, 420, true);
                    this.Hurt(80, 0, false, false, getDeathMessage(-1, -1, -1, 2), false);
                }
                this.lavaWet = true;
            }
            if (Collision.WetCollision(this.position, this.width, this.height))
            {
                if (this.onFire && !this.lavaWet)
                {
                    for (int num94 = 0; num94 < 10; num94++)
                    {
                        if (this.buffType[num94] == 0x18)
                        {
                            this.DelBuff(num94);
                        }
                    }
                }
                if (!this.wet)
                {
                    if (this.wetCount == 0)
                    {
                        this.wetCount = 10;
                        if (!flag10)
                        {
                            for (int num95 = 0; num95 < 50; num95++)
                            {
                                color = new Color();
                                int num96 = Dust.NewDust(new Vector2(this.position.X - 6f, (this.position.Y + (this.height / 2)) - 8f), this.width + 12, 0x18, 0x21, 0f, 0f, 0, color, 1f);
                                Main.dust[num96].velocity.Y -= 4f;
                                Main.dust[num96].velocity.X *= 2.5f;
                                Main.dust[num96].scale = 1.3f;
                                Main.dust[num96].alpha = 100;
                                Main.dust[num96].noGravity = true;
                            }
                            Main.PlaySound(0x13, (int) this.position.X, (int) this.position.Y, 0);
                        }
                        else
                        {
                            for (int num97 = 0; num97 < 20; num97++)
                            {
                                color = new Color();
                                int num98 = Dust.NewDust(new Vector2(this.position.X - 6f, (this.position.Y + (this.height / 2)) - 8f), this.width + 12, 0x18, 0x23, 0f, 0f, 0, color, 1f);
                                Main.dust[num98].velocity.Y -= 1.5f;
                                Main.dust[num98].velocity.X *= 2.5f;
                                Main.dust[num98].scale = 1.3f;
                                Main.dust[num98].alpha = 100;
                                Main.dust[num98].noGravity = true;
                            }
                            Main.PlaySound(0x13, (int) this.position.X, (int) this.position.Y, 1);
                        }
                    }
                    this.wet = true;
                }
            }
            else if (this.wet)
            {
                this.wet = false;
                if (this.jump > (jumpHeight / 5))
                {
                    this.jump = jumpHeight / 5;
                }
                if (this.wetCount == 0)
                {
                    this.wetCount = 10;
                    if (!this.lavaWet)
                    {
                        for (int num99 = 0; num99 < 50; num99++)
                        {
                            color = new Color();
                            int num100 = Dust.NewDust(new Vector2(this.position.X - 6f, this.position.Y + (this.height / 2)), this.width + 12, 0x18, 0x21, 0f, 0f, 0, color, 1f);
                            Main.dust[num100].velocity.Y -= 4f;
                            Main.dust[num100].velocity.X *= 2.5f;
                            Main.dust[num100].scale = 1.3f;
                            Main.dust[num100].alpha = 100;
                            Main.dust[num100].noGravity = true;
                        }
                        Main.PlaySound(0x13, (int) this.position.X, (int) this.position.Y, 0);
                    }
                    else
                    {
                        for (int num101 = 0; num101 < 20; num101++)
                        {
                            color = new Color();
                            int num102 = Dust.NewDust(new Vector2(this.position.X - 6f, (this.position.Y + (this.height / 2)) - 8f), this.width + 12, 0x18, 0x23, 0f, 0f, 0, color, 1f);
                            Main.dust[num102].velocity.Y -= 1.5f;
                            Main.dust[num102].velocity.X *= 2.5f;
                            Main.dust[num102].scale = 1.3f;
                            Main.dust[num102].alpha = 100;
                            Main.dust[num102].noGravity = true;
                        }
                        Main.PlaySound(0x13, (int) this.position.X, (int) this.position.Y, 1);
                    }
                }
            }
            if (!this.wet)
            {
                this.lavaWet = false;
            }
            if (this.wetCount > 0)
            {
                this.wetCount = (byte) (this.wetCount - 1);
            }
            if (this.wet)
            {
                Vector2 velocity = this.velocity;
                this.velocity = Collision.TileCollision(this.position, this.velocity, this.width, this.height, this.controlDown, false);
                Vector2 vector5 = (Vector2) (this.velocity * 0.5f);
                if (this.velocity.X != velocity.X)
                {
                    vector5.X = this.velocity.X;
                }
                if (this.velocity.Y != velocity.Y)
                {
                    vector5.Y = this.velocity.Y;
                }
                this.position += vector5;
            }
            else
            {
                this.velocity = Collision.TileCollision(this.position, this.velocity, this.width, this.height, this.controlDown, false);
                if (this.waterWalk)
                {
                    this.velocity = Collision.WaterCollision(this.position, this.velocity, this.width, this.height, this.controlDown, false);
                }
                this.position += this.velocity;
            }
            if (this.velocity.Y == 0f)
            {
                if ((this.gravDir == 1f) && Collision.up)
                {
                    this.velocity.Y = 0.01f;
                    this.jump = 0;
                }
                else if ((this.gravDir == -1f) && Collision.down)
                {
                    this.velocity.Y = -0.01f;
                    this.jump = 0;
                }
            }
            if (this.position.X < ((Main.leftWorld + 336f) + 16f))
            {
                this.position.X = (Main.leftWorld + 336f) + 16f;
                this.velocity.X = 0f;
            }
            if ((this.position.X + this.width) > ((Main.rightWorld - 336f) - 32f))
            {
                this.position.X = ((Main.rightWorld - 336f) - 32f) - this.width;
                this.velocity.X = 0f;
            }
            if (this.position.Y < ((Main.topWorld + 336f) + 16f))
            {
                this.position.Y = (Main.topWorld + 336f) + 16f;
                if (this.velocity.Y < -0.1)
                {
                    this.velocity.Y = -0.1f;
                }
            }
            if (this.position.Y > (((Main.bottomWorld - 336f) - 32f) - this.height))
            {
                this.position.Y = ((Main.bottomWorld - 336f) - 32f) - this.height;
                this.velocity.Y = 0f;
            }
            if (Main.ignoreErrors)
            {
                try
                {
                    this.ItemCheck(i);
                    goto Label_5FF9;
                }
                catch
                {
                    goto Label_5FF9;
                }
            }
            this.ItemCheck(i);
        Label_5FF9:
            this.PlayerFrame();
            if (this.statLife > this.statLifeMax)
            {
                this.statLife = this.statLifeMax;
            }
            this.grappling[0] = -1;
            this.grapCount = 0;
        }
    }
}

