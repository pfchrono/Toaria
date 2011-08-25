namespace Toaria
{
    using Microsoft.Xna.Framework;
    using System;

    public class Chest
    {
        public Item[] item = new Item[maxItems];
        public static int maxItems = 20;
        public int x;
        public int y;

        public void AddShop(Item newItem)
        {
            for (int i = 0; i < 0x13; i++)
            {
                if ((this.item[i] == null) || (this.item[i].type == 0))
                {
                    this.item[i] = (Item) newItem.Clone();
                    this.item[i].buyOnce = true;
                    this.item[i].value /= 5;
                    if (this.item[i].value < 1)
                    {
                        this.item[i].value = 1;
                        return;
                    }
                    break;
                }
            }
        }

        public object Clone()
        {
            return base.MemberwiseClone();
        }

        public static int CreateChest(int X, int Y)
        {
            for (int i = 0; i < 0x3e8; i++)
            {
                if (((Main.chest[i] != null) && (Main.chest[i].x == X)) && (Main.chest[i].y == Y))
                {
                    return -1;
                }
            }
            for (int j = 0; j < 0x3e8; j++)
            {
                if (Main.chest[j] == null)
                {
                    Main.chest[j] = new Chest();
                    Main.chest[j].x = X;
                    Main.chest[j].y = Y;
                    for (int k = 0; k < maxItems; k++)
                    {
                        Main.chest[j].item[k] = new Item();
                    }
                    return j;
                }
            }
            return -1;
        }

        public static bool DestroyChest(int X, int Y)
        {
            for (int i = 0; i < 0x3e8; i++)
            {
                if (((Main.chest[i] != null) && (Main.chest[i].x == X)) && (Main.chest[i].y == Y))
                {
                    for (int j = 0; j < maxItems; j++)
                    {
                        if ((Main.chest[i].item[j].type > 0) && (Main.chest[i].item[j].stack > 0))
                        {
                            return false;
                        }
                    }
                    Main.chest[i] = null;
                    return true;
                }
            }
            return true;
        }

        public static int FindChest(int X, int Y)
        {
            for (int i = 0; i < 0x3e8; i++)
            {
                if (((Main.chest[i] != null) && (Main.chest[i].x == X)) && (Main.chest[i].y == Y))
                {
                    return i;
                }
            }
            return -1;
        }

        public void SetupShop(int type)
        {
            for (int i = 0; i < maxItems; i++)
            {
                this.item[i] = new Item();
            }
            if (type == 1)
            {
                int index = 0;
                this.item[index].SetDefaults("Mining Helmet");
                index++;
                this.item[index].SetDefaults("Piggy Bank");
                index++;
                this.item[index].SetDefaults("Iron Anvil");
                index++;
                this.item[index].SetDefaults("Copper Pickaxe");
                index++;
                this.item[index].SetDefaults("Copper Axe");
                index++;
                this.item[index].SetDefaults("Torch");
                index++;
                this.item[index].SetDefaults("Lesser Healing Potion");
                index++;
                if (Main.player[Main.myPlayer].statManaMax == 200)
                {
                    this.item[index].SetDefaults("Lesser Mana Potion");
                    index++;
                }
                this.item[index].SetDefaults("Wooden Arrow");
                index++;
                this.item[index].SetDefaults("Shuriken");
                index++;
                if (Main.bloodMoon)
                {
                    this.item[index].SetDefaults("Throwing Knife");
                    index++;
                }
                if (!Main.dayTime)
                {
                    this.item[index].SetDefaults("Glowstick");
                    index++;
                }
                if (NPC.downedBoss3)
                {
                    this.item[index].SetDefaults("Safe");
                    index++;
                }
            }
            else if (type == 2)
            {
                int num3 = 0;
                this.item[num3].SetDefaults("Musket Ball");
                num3++;
                if (Main.bloodMoon)
                {
                    this.item[num3].SetDefaults("Silver Bullet");
                    num3++;
                }
                if (NPC.downedBoss2 && !Main.dayTime)
                {
                    this.item[num3].SetDefaults(0x2f, false);
                    num3++;
                }
                this.item[num3].SetDefaults("Flintlock Pistol");
                num3++;
                this.item[num3].SetDefaults("Minishark");
                num3++;
                if (Main.moonPhase == 4)
                {
                    this.item[num3].SetDefaults(0x144, false);
                    num3++;
                }
            }
            else if (type == 3)
            {
                int num4 = 0;
                if (Main.bloodMoon)
                {
                    this.item[num4].SetDefaults(0x43, false);
                    num4++;
                    this.item[num4].SetDefaults(0x3b, false);
                    num4++;
                }
                else
                {
                    this.item[num4].SetDefaults("Purification Powder");
                    num4++;
                    this.item[num4].SetDefaults("Grass Seeds");
                    num4++;
                    this.item[num4].SetDefaults("Sunflower");
                    num4++;
                }
                this.item[num4].SetDefaults("Acorn");
                num4++;
                this.item[num4].SetDefaults(0x72, false);
                num4++;
            }
            else if (type == 4)
            {
                int num5 = 0;
                this.item[num5].SetDefaults("Grenade");
                num5++;
                this.item[num5].SetDefaults("Bomb");
                num5++;
                this.item[num5].SetDefaults("Dynamite");
                num5++;
            }
            else if (type == 5)
            {
                int num6 = 0;
                this.item[num6].SetDefaults(0xfe, false);
                num6++;
                if (Main.dayTime)
                {
                    this.item[num6].SetDefaults(0xf2, false);
                    num6++;
                }
                if (Main.moonPhase == 0)
                {
                    this.item[num6].SetDefaults(0xf5, false);
                    num6++;
                    this.item[num6].SetDefaults(0xf6, false);
                    num6++;
                }
                else if (Main.moonPhase == 1)
                {
                    this.item[num6].SetDefaults(0x145, false);
                    num6++;
                    this.item[num6].SetDefaults(0x146, false);
                    num6++;
                }
                this.item[num6].SetDefaults(0x10d, false);
                num6++;
                this.item[num6].SetDefaults(270, false);
                num6++;
                this.item[num6].SetDefaults(0x10f, false);
                num6++;
                if (Main.bloodMoon)
                {
                    this.item[num6].SetDefaults(0x142, false);
                    num6++;
                }
            }
        }

        public static void Unlock(int X, int Y)
        {
            Main.PlaySound(0x16, X * 0x10, Y * 0x10, 1);
            for (int i = X; i <= (X + 1); i++)
            {
                for (int j = Y; j <= (Y + 1); j++)
                {
                    if (Main.tile[i, j] == null)
                    {
                        Main.tile[i, j] = new Tile();
                    }
                    if (((Main.tile[i, j].frameX >= 0x48) && (Main.tile[i, j].frameX <= 0x6a)) || ((Main.tile[i, j].frameX >= 0x90) && (Main.tile[i, j].frameX <= 0xb2)))
                    {
                        Tile tile1 = Main.tile[i, j];
                        tile1.frameX = (short) (tile1.frameX - 0x24);
                        for (int k = 0; k < 4; k++)
                        {
                            Color newColor = new Color();
                            Dust.NewDust(new Vector2((float) (i * 0x10), (float) (j * 0x10)), 0x10, 0x10, 11, 0f, 0f, 0, newColor, 1f);
                        }
                    }
                }
            }
        }

        public static int UsingChest(int i)
        {
            if (Main.chest[i] != null)
            {
                for (int j = 0; j < 0xff; j++)
                {
                    if (Main.player[j].active && (Main.player[j].chest == i))
                    {
                        return j;
                    }
                }
            }
            return -1;
        }
    }
}

