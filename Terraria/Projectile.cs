namespace Terraria
{
    using Microsoft.Xna.Framework;
    using System;
    using System.Runtime.InteropServices;

    public class Projectile
    {
        public bool active;
        public float[] ai = new float[maxAI];
        public int aiStyle;
        public int alpha;
        public int damage;
        public int direction;
        public bool friendly;
        public int height;
        public bool hide;
        public bool hostile;
        public int identity;
        public bool ignoreWater;
        public float knockBack;
        public bool lavaWet;
        public float light;
        public bool magic;
        public static int maxAI = 2;
        public int maxUpdates;
        public bool melee;
        public string miscText = "";
        public string name = "";
        public bool netUpdate;
        public int numUpdates;
        public int owner = 0xff;
        public bool ownerHitCheck;
        public int penetrate = 1;
        public int[] playerImmune = new int[0xff];
        public Vector2 position;
        public bool ranged;
        public int restrikeDelay;
        public float rotation;
        public float scale = 1f;
        public int soundDelay;
        public bool tileCollide;
        public int timeLeft;
        public int type;
        public Vector2 velocity;
        public bool wet;
        public byte wetCount;
        public int whoAmI;
        public int width;

        public void AI()
        {
            Color color;
            if (this.aiStyle == 1)
            {
                if (this.type == 0x29)
                {
                    color = new Color();
                    int index = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 0x1f, 0f, 0f, 100, color, 1.6f);
                    Main.dust[index].noGravity = true;
                    index = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 6, 0f, 0f, 100, new Color(), 2f);
                    Main.dust[index].noGravity = true;
                }
                else if (this.type == 0x37)
                {
                    int num2 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 0x12, 0f, 0f, 0, new Color(), 0.9f);
                    Main.dust[num2].noGravity = true;
                }
                if (((this.type == 20) || (this.type == 14)) || (this.type == 0x24))
                {
                    if (this.alpha > 0)
                    {
                        this.alpha -= 15;
                    }
                    if (this.alpha < 0)
                    {
                        this.alpha = 0;
                    }
                }
                if ((((this.type != 5) && (this.type != 14)) && ((this.type != 20) && (this.type != 0x24))) && ((this.type != 0x26) && (this.type != 0x37)))
                {
                    this.ai[0]++;
                }
                if (this.ai[0] >= 15f)
                {
                    this.ai[0] = 15f;
                    this.velocity.Y += 0.1f;
                }
                this.rotation = ((float) Math.Atan2((double) this.velocity.Y, (double) this.velocity.X)) + 1.57f;
                if (this.velocity.Y > 16f)
                {
                    this.velocity.Y = 16f;
                }
            }
            else if (this.aiStyle == 2)
            {
                this.rotation += ((Math.Abs(this.velocity.X) + Math.Abs(this.velocity.Y)) * 0.03f) * this.direction;
                this.ai[0]++;
                if (this.ai[0] >= 20f)
                {
                    this.velocity.Y += 0.4f;
                    this.velocity.X *= 0.97f;
                }
                else if ((this.type == 0x30) || (this.type == 0x36))
                {
                    this.rotation = ((float) Math.Atan2((double) this.velocity.Y, (double) this.velocity.X)) + 1.57f;
                }
                if (this.velocity.Y > 16f)
                {
                    this.velocity.Y = 16f;
                }
                if ((this.type == 0x36) && (Main.rand.Next(20) == 0))
                {
                    Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 40, this.velocity.X * 0.1f, this.velocity.Y * 0.1f, 0, new Color(), 0.75f);
                }
            }
            else if (this.aiStyle == 3)
            {
                if (this.soundDelay == 0)
                {
                    this.soundDelay = 8;
                    Main.PlaySound(2, (int) this.position.X, (int) this.position.Y, 7);
                }
                if (this.type == 0x13)
                {
                    for (int i = 0; i < 2; i++)
                    {
                        color = new Color();
                        int num4 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 6, this.velocity.X * 0.2f, this.velocity.Y * 0.2f, 100, color, 2f);
                        Main.dust[num4].noGravity = true;
                        Main.dust[num4].velocity.X *= 0.3f;
                        Main.dust[num4].velocity.Y *= 0.3f;
                    }
                }
                else if (this.type == 0x21)
                {
                    if (Main.rand.Next(1) == 0)
                    {
                        int num5 = Dust.NewDust(this.position, this.width, this.height, 40, this.velocity.X * 0.25f, this.velocity.Y * 0.25f, 0, new Color(), 1.4f);
                        Main.dust[num5].noGravity = true;
                    }
                }
                else if ((this.type == 6) && (Main.rand.Next(5) == 0))
                {
                    Dust.NewDust(this.position, this.width, this.height, 15, this.velocity.X * 0.5f, this.velocity.Y * 0.5f, 150, new Color(), 0.9f);
                }
                if (this.ai[0] == 0f)
                {
                    this.ai[1]++;
                    if (this.ai[1] >= 30f)
                    {
                        this.ai[0] = 1f;
                        this.ai[1] = 0f;
                        this.netUpdate = true;
                    }
                }
                else
                {
                    this.tileCollide = false;
                    float num6 = 9f;
                    float num7 = 0.4f;
                    if (this.type == 0x13)
                    {
                        num6 = 13f;
                        num7 = 0.6f;
                    }
                    else if (this.type == 0x21)
                    {
                        num6 = 15f;
                        num7 = 0.8f;
                    }
                    Vector2 vector = new Vector2(this.position.X + (this.width * 0.5f), this.position.Y + (this.height * 0.5f));
                    float num8 = (Main.player[this.owner].position.X + (Main.player[this.owner].width / 2)) - vector.X;
                    float num9 = (Main.player[this.owner].position.Y + (Main.player[this.owner].height / 2)) - vector.Y;
                    float num10 = (float) Math.Sqrt((double) ((num8 * num8) + (num9 * num9)));
                    num10 = num6 / num10;
                    num8 *= num10;
                    num9 *= num10;
                    if (this.velocity.X < num8)
                    {
                        this.velocity.X += num7;
                        if ((this.velocity.X < 0f) && (num8 > 0f))
                        {
                            this.velocity.X += num7;
                        }
                    }
                    else if (this.velocity.X > num8)
                    {
                        this.velocity.X -= num7;
                        if ((this.velocity.X > 0f) && (num8 < 0f))
                        {
                            this.velocity.X -= num7;
                        }
                    }
                    if (this.velocity.Y < num9)
                    {
                        this.velocity.Y += num7;
                        if ((this.velocity.Y < 0f) && (num9 > 0f))
                        {
                            this.velocity.Y += num7;
                        }
                    }
                    else if (this.velocity.Y > num9)
                    {
                        this.velocity.Y -= num7;
                        if ((this.velocity.Y > 0f) && (num9 < 0f))
                        {
                            this.velocity.Y -= num7;
                        }
                    }
                    if (Main.myPlayer == this.owner)
                    {
                        Rectangle rectangle = new Rectangle((int) this.position.X, (int) this.position.Y, this.width, this.height);
                        Rectangle rectangle2 = new Rectangle((int) Main.player[this.owner].position.X, (int) Main.player[this.owner].position.Y, Main.player[this.owner].width, Main.player[this.owner].height);
                        if (rectangle.Intersects(rectangle2))
                        {
                            this.Kill();
                        }
                    }
                }
                this.rotation += 0.4f * this.direction;
            }
            else if (this.aiStyle == 4)
            {
                this.rotation = ((float) Math.Atan2((double) this.velocity.Y, (double) this.velocity.X)) + 1.57f;
                if (this.ai[0] != 0f)
                {
                    if ((this.alpha < 170) && ((this.alpha + 5) >= 170))
                    {
                        for (int j = 0; j < 3; j++)
                        {
                            color = new Color();
                            Dust.NewDust(this.position, this.width, this.height, 0x12, this.velocity.X * 0.025f, this.velocity.Y * 0.025f, 170, color, 1.2f);
                        }
                        Dust.NewDust(this.position, this.width, this.height, 14, 0f, 0f, 170, new Color(), 1.1f);
                    }
                    this.alpha += 5;
                    if (this.alpha >= 0xff)
                    {
                        this.Kill();
                    }
                }
                else
                {
                    this.alpha -= 50;
                    if (this.alpha <= 0)
                    {
                        this.alpha = 0;
                        this.ai[0] = 1f;
                        if (this.ai[1] == 0f)
                        {
                            this.ai[1]++;
                            this.position += (Vector2) (this.velocity * 1f);
                        }
                        if ((this.type == 7) && (Main.myPlayer == this.owner))
                        {
                            int type = this.type;
                            if (this.ai[1] >= 6f)
                            {
                                type++;
                            }
                            int num12 = NewProjectile((this.position.X + this.velocity.X) + (this.width / 2), (this.position.Y + this.velocity.Y) + (this.height / 2), this.velocity.X, this.velocity.Y, type, this.damage, this.knockBack, this.owner);
                            Main.projectile[num12].damage = this.damage;
                            Main.projectile[num12].ai[1] = this.ai[1] + 1f;
                            NetMessage.SendData(0x1b, -1, -1, "", num12, 0f, 0f, 0f, 0);
                        }
                    }
                }
            }
            else if (this.aiStyle == 5)
            {
                if ((this.ai[1] == 0f) && !Collision.SolidCollision(this.position, this.width, this.height))
                {
                    this.ai[1] = 1f;
                    this.netUpdate = true;
                }
                if (this.ai[1] != 0f)
                {
                    this.tileCollide = true;
                }
                if (this.soundDelay == 0)
                {
                    this.soundDelay = 20 + Main.rand.Next(40);
                    Main.PlaySound(2, (int) this.position.X, (int) this.position.Y, 9);
                }
                if (this.ai[0] == 0f)
                {
                    this.ai[0] = 1f;
                }
                this.alpha += (int) (25f * this.ai[0]);
                if (this.alpha > 200)
                {
                    this.alpha = 200;
                    this.ai[0] = -1f;
                }
                if (this.alpha < 0)
                {
                    this.alpha = 0;
                    this.ai[0] = 1f;
                }
                this.rotation += ((Math.Abs(this.velocity.X) + Math.Abs(this.velocity.Y)) * 0.01f) * this.direction;
                if (this.ai[1] == 1f)
                {
                    this.light = 0.9f;
                    if (Main.rand.Next(10) == 0)
                    {
                        Dust.NewDust(this.position, this.width, this.height, 15, this.velocity.X * 0.5f, this.velocity.Y * 0.5f, 150, new Color(), 1.2f);
                    }
                    if (Main.rand.Next(20) == 0)
                    {
                        Gore.NewGore(this.position, new Vector2(this.velocity.X * 0.2f, this.velocity.Y * 0.2f), Main.rand.Next(0x10, 0x12), 1f);
                    }
                }
            }
            else if (this.aiStyle == 6)
            {
                this.velocity = (Vector2) (this.velocity * 0.95f);
                this.ai[0]++;
                if (this.ai[0] == 180f)
                {
                    this.Kill();
                }
                if (this.ai[1] == 0f)
                {
                    this.ai[1] = 1f;
                    for (int k = 0; k < 30; k++)
                    {
                        color = new Color();
                        Dust.NewDust(this.position, this.width, this.height, 10 + this.type, this.velocity.X, this.velocity.Y, 50, color, 1f);
                    }
                }
                if (this.type == 10)
                {
                    int num15 = ((int) (this.position.X / 16f)) - 1;
                    int maxTilesX = ((int) ((this.position.X + this.width) / 16f)) + 2;
                    int num17 = ((int) (this.position.Y / 16f)) - 1;
                    int maxTilesY = ((int) ((this.position.Y + this.height) / 16f)) + 2;
                    if (num15 < 0)
                    {
                        num15 = 0;
                    }
                    if (maxTilesX > Main.maxTilesX)
                    {
                        maxTilesX = Main.maxTilesX;
                    }
                    if (num17 < 0)
                    {
                        num17 = 0;
                    }
                    if (maxTilesY > Main.maxTilesY)
                    {
                        maxTilesY = Main.maxTilesY;
                    }
                    for (int m = num15; m < maxTilesX; m++)
                    {
                        for (int n = num17; n < maxTilesY; n++)
                        {
                            Vector2 vector2;
                            vector2.X = m * 0x10;
                            vector2.Y = n * 0x10;
                            if (((((this.position.X + this.width) > vector2.X) && (this.position.X < (vector2.X + 16f))) && (((this.position.Y + this.height) > vector2.Y) && (this.position.Y < (vector2.Y + 16f)))) && ((Main.myPlayer == this.owner) && Main.tile[m, n].active))
                            {
                                if (Main.tile[m, n].type == 0x17)
                                {
                                    Main.tile[m, n].type = 2;
                                    WorldGen.SquareTileFrame(m, n, true);
                                    if (Main.netMode == 1)
                                    {
                                        NetMessage.SendTileSquare(-1, m - 1, n - 1, 3);
                                    }
                                }
                                if (Main.tile[m, n].type == 0x19)
                                {
                                    Main.tile[m, n].type = 1;
                                    WorldGen.SquareTileFrame(m, n, true);
                                    if (Main.netMode == 1)
                                    {
                                        NetMessage.SendTileSquare(-1, m - 1, n - 1, 3);
                                    }
                                }
                            }
                        }
                    }
                }
            }
            else if (this.aiStyle == 7)
            {
                if (Main.player[this.owner].dead)
                {
                    this.Kill();
                }
                else
                {
                    Vector2 vector3 = new Vector2(this.position.X + (this.width * 0.5f), this.position.Y + (this.height * 0.5f));
                    float num21 = (Main.player[this.owner].position.X + (Main.player[this.owner].width / 2)) - vector3.X;
                    float num22 = (Main.player[this.owner].position.Y + (Main.player[this.owner].height / 2)) - vector3.Y;
                    float num23 = (float) Math.Sqrt((double) ((num21 * num21) + (num22 * num22)));
                    this.rotation = ((float) Math.Atan2((double) num22, (double) num21)) - 1.57f;
                    if (this.ai[0] == 0f)
                    {
                        if (((num23 > 300f) && (this.type == 13)) || ((num23 > 400f) && (this.type == 0x20)))
                        {
                            this.ai[0] = 1f;
                        }
                        int num24 = ((int) (this.position.X / 16f)) - 1;
                        int num25 = ((int) ((this.position.X + this.width) / 16f)) + 2;
                        int num26 = ((int) (this.position.Y / 16f)) - 1;
                        int num27 = ((int) ((this.position.Y + this.height) / 16f)) + 2;
                        if (num24 < 0)
                        {
                            num24 = 0;
                        }
                        if (num25 > Main.maxTilesX)
                        {
                            num25 = Main.maxTilesX;
                        }
                        if (num26 < 0)
                        {
                            num26 = 0;
                        }
                        if (num27 > Main.maxTilesY)
                        {
                            num27 = Main.maxTilesY;
                        }
                        for (int num28 = num24; num28 < num25; num28++)
                        {
                            for (int num29 = num26; num29 < num27; num29++)
                            {
                                Vector2 vector4;
                                if (Main.tile[num28, num29] == null)
                                {
                                    Main.tile[num28, num29] = new Tile();
                                }
                                vector4.X = num28 * 0x10;
                                vector4.Y = num29 * 0x10;
                                if (((((this.position.X + this.width) > vector4.X) && (this.position.X < (vector4.X + 16f))) && (((this.position.Y + this.height) > vector4.Y) && (this.position.Y < (vector4.Y + 16f)))) && (Main.tile[num28, num29].active && Main.tileSolid[Main.tile[num28, num29].type]))
                                {
                                    if (Main.player[this.owner].grapCount < 10)
                                    {
                                        Main.player[this.owner].grappling[Main.player[this.owner].grapCount] = this.whoAmI;
                                        Player player1 = Main.player[this.owner];
                                        player1.grapCount++;
                                    }
                                    if (Main.myPlayer == this.owner)
                                    {
                                        int num30 = 0;
                                        int num31 = -1;
                                        int timeLeft = 0x186a0;
                                        for (int num33 = 0; num33 < 0x3e8; num33++)
                                        {
                                            if ((Main.projectile[num33].active && (Main.projectile[num33].owner == this.owner)) && (Main.projectile[num33].aiStyle == 7))
                                            {
                                                if (Main.projectile[num33].timeLeft < timeLeft)
                                                {
                                                    num31 = num33;
                                                    timeLeft = Main.projectile[num33].timeLeft;
                                                }
                                                num30++;
                                            }
                                        }
                                        if (num30 > 3)
                                        {
                                            Main.projectile[num31].Kill();
                                        }
                                    }
                                    WorldGen.KillTile(num28, num29, true, true, false);
                                    Main.PlaySound(0, num28 * 0x10, num29 * 0x10, 1);
                                    this.velocity.X = 0f;
                                    this.velocity.Y = 0f;
                                    this.ai[0] = 2f;
                                    this.position.X = ((num28 * 0x10) + 8) - (this.width / 2);
                                    this.position.Y = ((num29 * 0x10) + 8) - (this.height / 2);
                                    this.damage = 0;
                                    this.netUpdate = true;
                                    if (Main.myPlayer == this.owner)
                                    {
                                        NetMessage.SendData(13, -1, -1, "", this.owner, 0f, 0f, 0f, 0);
                                    }
                                    break;
                                }
                            }
                            if (this.ai[0] == 2f)
                            {
                                return;
                            }
                        }
                    }
                    else if (this.ai[0] == 1f)
                    {
                        float num34 = 11f;
                        if (this.type == 0x20)
                        {
                            num34 = 15f;
                        }
                        if (num23 < 24f)
                        {
                            this.Kill();
                        }
                        num23 = num34 / num23;
                        num21 *= num23;
                        num22 *= num23;
                        this.velocity.X = num21;
                        this.velocity.Y = num22;
                    }
                    else if (this.ai[0] == 2f)
                    {
                        int num35 = ((int) (this.position.X / 16f)) - 1;
                        int num36 = ((int) ((this.position.X + this.width) / 16f)) + 2;
                        int num37 = ((int) (this.position.Y / 16f)) - 1;
                        int num38 = ((int) ((this.position.Y + this.height) / 16f)) + 2;
                        if (num35 < 0)
                        {
                            num35 = 0;
                        }
                        if (num36 > Main.maxTilesX)
                        {
                            num36 = Main.maxTilesX;
                        }
                        if (num37 < 0)
                        {
                            num37 = 0;
                        }
                        if (num38 > Main.maxTilesY)
                        {
                            num38 = Main.maxTilesY;
                        }
                        bool flag = true;
                        for (int num39 = num35; num39 < num36; num39++)
                        {
                            for (int num40 = num37; num40 < num38; num40++)
                            {
                                Vector2 vector5;
                                if (Main.tile[num39, num40] == null)
                                {
                                    Main.tile[num39, num40] = new Tile();
                                }
                                vector5.X = num39 * 0x10;
                                vector5.Y = num40 * 0x10;
                                if (((((this.position.X + (this.width / 2)) > vector5.X) && ((this.position.X + (this.width / 2)) < (vector5.X + 16f))) && (((this.position.Y + (this.height / 2)) > vector5.Y) && ((this.position.Y + (this.height / 2)) < (vector5.Y + 16f)))) && (Main.tile[num39, num40].active && Main.tileSolid[Main.tile[num39, num40].type]))
                                {
                                    flag = false;
                                }
                            }
                        }
                        if (flag)
                        {
                            this.ai[0] = 1f;
                        }
                        else if (Main.player[this.owner].grapCount < 10)
                        {
                            Main.player[this.owner].grappling[Main.player[this.owner].grapCount] = this.whoAmI;
                            Player player2 = Main.player[this.owner];
                            player2.grapCount++;
                        }
                    }
                }
            }
            else if (this.aiStyle == 8)
            {
                if (this.type == 0x1b)
                {
                    color = new Color();
                    int num41 = Dust.NewDust(new Vector2(this.position.X + this.velocity.X, this.position.Y + this.velocity.Y), this.width, this.height, 0x1d, this.velocity.X, this.velocity.Y, 100, color, 3f);
                    Main.dust[num41].noGravity = true;
                    if (Main.rand.Next(10) == 0)
                    {
                        num41 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 0x1d, this.velocity.X, this.velocity.Y, 100, new Color(), 1.4f);
                    }
                }
                else
                {
                    for (int num42 = 0; num42 < 2; num42++)
                    {
                        color = new Color();
                        int num43 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 6, this.velocity.X * 0.2f, this.velocity.Y * 0.2f, 100, color, 2f);
                        Main.dust[num43].noGravity = true;
                        Main.dust[num43].velocity.X *= 0.3f;
                        Main.dust[num43].velocity.Y *= 0.3f;
                    }
                }
                if (this.type != 0x1b)
                {
                    this.ai[1]++;
                }
                if (this.ai[1] >= 20f)
                {
                    this.velocity.Y += 0.2f;
                }
                this.rotation += 0.3f * this.direction;
                if (this.velocity.Y > 16f)
                {
                    this.velocity.Y = 16f;
                }
            }
            else if (this.aiStyle == 9)
            {
                if (this.type == 0x22)
                {
                    color = new Color();
                    int num44 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 6, this.velocity.X * 0.2f, this.velocity.Y * 0.2f, 100, color, 3.5f);
                    Main.dust[num44].noGravity = true;
                    Dust dust1 = Main.dust[num44];
                    dust1.velocity = (Vector2) (dust1.velocity * 1.4f);
                    num44 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 6, this.velocity.X * 0.2f, this.velocity.Y * 0.2f, 100, new Color(), 1.5f);
                }
                else
                {
                    if ((this.soundDelay == 0) && ((Math.Abs(this.velocity.X) + Math.Abs(this.velocity.Y)) > 2f))
                    {
                        this.soundDelay = 10;
                        Main.PlaySound(2, (int) this.position.X, (int) this.position.Y, 9);
                    }
                    int num45 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 15, 0f, 0f, 100, new Color(), 2f);
                    Dust dust2 = Main.dust[num45];
                    dust2.velocity = (Vector2) (dust2.velocity * 0.3f);
                    Main.dust[num45].position.X = ((this.position.X + (this.width / 2)) + 4f) + Main.rand.Next(-4, 5);
                    Main.dust[num45].position.Y = (this.position.Y + (this.height / 2)) + Main.rand.Next(-4, 5);
                    Main.dust[num45].noGravity = true;
                }
                if ((Main.myPlayer == this.owner) && (this.ai[0] == 0f))
                {
                    if (Main.player[this.owner].channel)
                    {
                        float num46 = 12f;
                        if (this.type == 0x10)
                        {
                            num46 = 15f;
                        }
                        Vector2 vector6 = new Vector2(this.position.X + (this.width * 0.5f), this.position.Y + (this.height * 0.5f));
                        float num47 = (Main.mouseState.X + Main.screenPosition.X) - vector6.X;
                        float num48 = (Main.mouseState.Y + Main.screenPosition.Y) - vector6.Y;
                        float num49 = (float) Math.Sqrt((double) ((num47 * num47) + (num48 * num48)));
                        num49 = (float) Math.Sqrt((double) ((num47 * num47) + (num48 * num48)));
                        if (num49 > num46)
                        {
                            num49 = num46 / num49;
                            num47 *= num49;
                            num48 *= num49;
                            if ((num47 != this.velocity.X) || (num48 != this.velocity.Y))
                            {
                                this.netUpdate = true;
                            }
                            this.velocity.X = num47;
                            this.velocity.Y = num48;
                        }
                        else
                        {
                            if ((num47 != this.velocity.X) || (num48 != this.velocity.Y))
                            {
                                this.netUpdate = true;
                            }
                            this.velocity.X = num47;
                            this.velocity.Y = num48;
                        }
                    }
                    else if (this.ai[0] == 0f)
                    {
                        this.ai[0] = 1f;
                        this.netUpdate = true;
                        float num50 = 12f;
                        Vector2 vector7 = new Vector2(this.position.X + (this.width * 0.5f), this.position.Y + (this.height * 0.5f));
                        float num51 = (Main.mouseState.X + Main.screenPosition.X) - vector7.X;
                        float num52 = (Main.mouseState.Y + Main.screenPosition.Y) - vector7.Y;
                        float num53 = (float) Math.Sqrt((double) ((num51 * num51) + (num52 * num52)));
                        if (num53 == 0f)
                        {
                            vector7 = new Vector2(Main.player[this.owner].position.X + (Main.player[this.owner].width / 2), Main.player[this.owner].position.Y + (Main.player[this.owner].height / 2));
                            num51 = (this.position.X + (this.width * 0.5f)) - vector7.X;
                            num52 = (this.position.Y + (this.height * 0.5f)) - vector7.Y;
                            num53 = (float) Math.Sqrt((double) ((num51 * num51) + (num52 * num52)));
                        }
                        num53 = num50 / num53;
                        num51 *= num53;
                        num52 *= num53;
                        this.velocity.X = num51;
                        this.velocity.Y = num52;
                        if ((this.velocity.X == 0f) && (this.velocity.Y == 0f))
                        {
                            this.Kill();
                        }
                    }
                }
                if (this.type == 0x22)
                {
                    this.rotation += 0.3f * this.direction;
                }
                else if ((this.velocity.X != 0f) || (this.velocity.Y != 0f))
                {
                    this.rotation = ((float) Math.Atan2((double) this.velocity.Y, (double) this.velocity.X)) - 2.355f;
                }
                if (this.velocity.Y > 16f)
                {
                    this.velocity.Y = 16f;
                }
            }
            else if (this.aiStyle == 10)
            {
                if ((this.type == 0x1f) && (this.ai[0] != 2f))
                {
                    if (Main.rand.Next(2) == 0)
                    {
                        int num54 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 0x20, 0f, this.velocity.Y / 2f, 0, new Color(), 1f);
                        Main.dust[num54].velocity.X *= 0.4f;
                    }
                }
                else if (this.type == 0x27)
                {
                    if (Main.rand.Next(2) == 0)
                    {
                        int num55 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 0x26, 0f, this.velocity.Y / 2f, 0, new Color(), 1f);
                        Main.dust[num55].velocity.X *= 0.4f;
                    }
                }
                else if (this.type == 40)
                {
                    if (Main.rand.Next(2) == 0)
                    {
                        int num56 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 0x24, 0f, this.velocity.Y / 2f, 0, new Color(), 1f);
                        Dust dust3 = Main.dust[num56];
                        dust3.velocity = (Vector2) (dust3.velocity * 0.4f);
                    }
                }
                else if ((this.type == 0x2a) || (this.type == 0x1f))
                {
                    if (Main.rand.Next(2) == 0)
                    {
                        int num57 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 0x20, 0f, 0f, 0, new Color(), 1f);
                        Main.dust[num57].velocity.X *= 0.4f;
                    }
                }
                else if (Main.rand.Next(20) == 0)
                {
                    Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 0, 0f, 0f, 0, new Color(), 1f);
                }
                if ((Main.myPlayer == this.owner) && (this.ai[0] == 0f))
                {
                    if (Main.player[this.owner].channel)
                    {
                        float num58 = 12f;
                        Vector2 vector8 = new Vector2(this.position.X + (this.width * 0.5f), this.position.Y + (this.height * 0.5f));
                        float num59 = (Main.mouseState.X + Main.screenPosition.X) - vector8.X;
                        float num60 = (Main.mouseState.Y + Main.screenPosition.Y) - vector8.Y;
                        float num61 = (float) Math.Sqrt((double) ((num59 * num59) + (num60 * num60)));
                        num61 = (float) Math.Sqrt((double) ((num59 * num59) + (num60 * num60)));
                        if (num61 > num58)
                        {
                            num61 = num58 / num61;
                            num59 *= num61;
                            num60 *= num61;
                            if ((num59 != this.velocity.X) || (num60 != this.velocity.Y))
                            {
                                this.netUpdate = true;
                            }
                            this.velocity.X = num59;
                            this.velocity.Y = num60;
                        }
                        else
                        {
                            if ((num59 != this.velocity.X) || (num60 != this.velocity.Y))
                            {
                                this.netUpdate = true;
                            }
                            this.velocity.X = num59;
                            this.velocity.Y = num60;
                        }
                    }
                    else
                    {
                        this.ai[0] = 1f;
                        this.netUpdate = true;
                    }
                }
                if (this.ai[0] == 1f)
                {
                    if (this.type == 0x2a)
                    {
                        this.ai[1]++;
                        if (this.ai[1] >= 15f)
                        {
                            this.ai[1] = 15f;
                            this.velocity.Y += 0.2f;
                        }
                    }
                    else
                    {
                        this.velocity.Y += 0.41f;
                    }
                }
                else if (this.ai[0] == 2f)
                {
                    this.velocity.Y += 0.2f;
                    if (this.velocity.X < -0.04)
                    {
                        this.velocity.X += 0.04f;
                    }
                    else if (this.velocity.X > 0.04)
                    {
                        this.velocity.X -= 0.04f;
                    }
                    else
                    {
                        this.velocity.X = 0f;
                    }
                }
                this.rotation += 0.1f;
                if (this.velocity.Y > 10f)
                {
                    this.velocity.Y = 10f;
                }
            }
            else if (this.aiStyle == 11)
            {
                this.rotation += 0.02f;
                if (Main.myPlayer == this.owner)
                {
                    if (Main.player[Main.myPlayer].lightOrb)
                    {
                        this.timeLeft = 2;
                    }
                    if (!Main.player[this.owner].dead)
                    {
                        float num62 = 2.5f;
                        Vector2 vector9 = new Vector2(this.position.X + (this.width * 0.5f), this.position.Y + (this.height * 0.5f));
                        float num63 = (Main.player[this.owner].position.X + (Main.player[this.owner].width / 2)) - vector9.X;
                        float num64 = (Main.player[this.owner].position.Y + (Main.player[this.owner].height / 2)) - vector9.Y;
                        float num65 = (float) Math.Sqrt((double) ((num63 * num63) + (num64 * num64)));
                        num65 = (float) Math.Sqrt((double) ((num63 * num63) + (num64 * num64)));
                        if (num65 > 800f)
                        {
                            this.position.X = (Main.player[this.owner].position.X + (Main.player[this.owner].width / 2)) - (this.width / 2);
                            this.position.Y = (Main.player[this.owner].position.Y + (Main.player[this.owner].height / 2)) - (this.height / 2);
                        }
                        else if (num65 > 64f)
                        {
                            num65 = num62 / num65;
                            num63 *= num65;
                            num64 *= num65;
                            if ((num63 != this.velocity.X) || (num64 != this.velocity.Y))
                            {
                                this.netUpdate = true;
                            }
                            this.velocity.X = num63;
                            this.velocity.Y = num64;
                        }
                        else
                        {
                            if ((this.velocity.X != 0f) || (this.velocity.Y != 0f))
                            {
                                this.netUpdate = true;
                            }
                            this.velocity.X = 0f;
                            this.velocity.Y = 0f;
                        }
                    }
                    else
                    {
                        this.Kill();
                    }
                }
            }
            else if (this.aiStyle == 12)
            {
                this.scale -= 0.04f;
                if (this.scale <= 0f)
                {
                    this.Kill();
                }
                if (this.ai[0] > 4f)
                {
                    this.alpha = 150;
                    this.light = 0.8f;
                    color = new Color();
                    int num66 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 0x1d, this.velocity.X, this.velocity.Y, 100, color, 2.5f);
                    Main.dust[num66].noGravity = true;
                    Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 0x1d, this.velocity.X, this.velocity.Y, 100, new Color(), 1.5f);
                }
                else
                {
                    this.ai[0]++;
                }
                this.rotation += 0.3f * this.direction;
            }
            else if (this.aiStyle == 13)
            {
                if (Main.player[this.owner].dead)
                {
                    this.Kill();
                }
                else
                {
                    Main.player[this.owner].itemAnimation = 5;
                    Main.player[this.owner].itemTime = 5;
                    if ((this.position.X + (this.width / 2)) > (Main.player[this.owner].position.X + (Main.player[this.owner].width / 2)))
                    {
                        Main.player[this.owner].direction = 1;
                    }
                    else
                    {
                        Main.player[this.owner].direction = -1;
                    }
                    Vector2 vector10 = new Vector2(this.position.X + (this.width * 0.5f), this.position.Y + (this.height * 0.5f));
                    float num67 = (Main.player[this.owner].position.X + (Main.player[this.owner].width / 2)) - vector10.X;
                    float num68 = (Main.player[this.owner].position.Y + (Main.player[this.owner].height / 2)) - vector10.Y;
                    float num69 = (float) Math.Sqrt((double) ((num67 * num67) + (num68 * num68)));
                    if (this.ai[0] != 0f)
                    {
                        if (this.ai[0] == 1f)
                        {
                            this.tileCollide = false;
                            this.rotation = ((float) Math.Atan2((double) num68, (double) num67)) - 1.57f;
                            float num70 = 20f;
                            if (num69 < 50f)
                            {
                                this.Kill();
                            }
                            num69 = num70 / num69;
                            num67 *= num69;
                            num68 *= num69;
                            this.velocity.X = num67;
                            this.velocity.Y = num68;
                        }
                    }
                    else
                    {
                        if (num69 > 700f)
                        {
                            this.ai[0] = 1f;
                        }
                        this.rotation = ((float) Math.Atan2((double) this.velocity.Y, (double) this.velocity.X)) + 1.57f;
                        this.ai[1]++;
                        if (this.ai[1] > 2f)
                        {
                            this.alpha = 0;
                        }
                        if (this.ai[1] >= 10f)
                        {
                            this.ai[1] = 15f;
                            this.velocity.Y += 0.3f;
                        }
                    }
                }
            }
            else if (this.aiStyle == 14)
            {
                if (this.type == 0x35)
                {
                    try
                    {
                        Vector2 vector11 = Collision.TileCollision(this.position, this.velocity, this.width, this.height, false, false);
                        bool flag1 = this.velocity != vector11;
                        int num71 = ((int) (this.position.X / 16f)) - 1;
                        int num72 = ((int) ((this.position.X + this.width) / 16f)) + 2;
                        int num73 = ((int) (this.position.Y / 16f)) - 1;
                        int num74 = ((int) ((this.position.Y + this.height) / 16f)) + 2;
                        if (num71 < 0)
                        {
                            num71 = 0;
                        }
                        if (num72 > Main.maxTilesX)
                        {
                            num72 = Main.maxTilesX;
                        }
                        if (num73 < 0)
                        {
                            num73 = 0;
                        }
                        if (num74 > Main.maxTilesY)
                        {
                            num74 = Main.maxTilesY;
                        }
                        for (int num75 = num71; num75 < num72; num75++)
                        {
                            for (int num76 = num73; num76 < num74; num76++)
                            {
                                if (((Main.tile[num75, num76] != null) && Main.tile[num75, num76].active) && (Main.tileSolid[Main.tile[num75, num76].type] || (Main.tileSolidTop[Main.tile[num75, num76].type] && (Main.tile[num75, num76].frameY == 0))))
                                {
                                    Vector2 vector12;
                                    vector12.X = num75 * 0x10;
                                    vector12.Y = num76 * 0x10;
                                    if ((((this.position.X + this.width) > vector12.X) && (this.position.X < (vector12.X + 16f))) && (((this.position.Y + this.height) > vector12.Y) && (this.position.Y < (vector12.Y + 16f))))
                                    {
                                        this.velocity.X = 0f;
                                        this.velocity.Y = -0.2f;
                                    }
                                }
                            }
                        }
                    }
                    catch
                    {
                    }
                }
                this.ai[0]++;
                if (this.ai[0] > 5f)
                {
                    this.ai[0] = 5f;
                    if ((this.velocity.Y == 0f) && (this.velocity.X != 0f))
                    {
                        this.velocity.X *= 0.97f;
                        if ((this.velocity.X > -0.01) && (this.velocity.X < 0.01))
                        {
                            this.velocity.X = 0f;
                            this.netUpdate = true;
                        }
                    }
                    this.velocity.Y += 0.2f;
                }
                this.rotation += this.velocity.X * 0.1f;
            }
            else if (this.aiStyle == 15)
            {
                if (this.type == 0x19)
                {
                    if (Main.rand.Next(15) == 0)
                    {
                        Dust.NewDust(this.position, this.width, this.height, 14, 0f, 0f, 150, new Color(), 1.3f);
                    }
                }
                else if (this.type == 0x1a)
                {
                    int num77 = Dust.NewDust(this.position, this.width, this.height, 0x1d, this.velocity.X * 0.4f, this.velocity.Y * 0.4f, 100, new Color(), 2.5f);
                    Main.dust[num77].noGravity = true;
                    Main.dust[num77].velocity.X /= 2f;
                    Main.dust[num77].velocity.Y /= 2f;
                }
                else if (this.type == 0x23)
                {
                    int num78 = Dust.NewDust(this.position, this.width, this.height, 6, this.velocity.X * 0.4f, this.velocity.Y * 0.4f, 100, new Color(), 3f);
                    Main.dust[num78].noGravity = true;
                    Main.dust[num78].velocity.X *= 2f;
                    Main.dust[num78].velocity.Y *= 2f;
                }
                if (Main.player[this.owner].dead)
                {
                    this.Kill();
                }
                else
                {
                    Main.player[this.owner].itemAnimation = 10;
                    Main.player[this.owner].itemTime = 10;
                    if ((this.position.X + (this.width / 2)) > (Main.player[this.owner].position.X + (Main.player[this.owner].width / 2)))
                    {
                        Main.player[this.owner].direction = 1;
                        this.direction = 1;
                    }
                    else
                    {
                        Main.player[this.owner].direction = -1;
                        this.direction = -1;
                    }
                    Vector2 vector13 = new Vector2(this.position.X + (this.width * 0.5f), this.position.Y + (this.height * 0.5f));
                    float num79 = (Main.player[this.owner].position.X + (Main.player[this.owner].width / 2)) - vector13.X;
                    float num80 = (Main.player[this.owner].position.Y + (Main.player[this.owner].height / 2)) - vector13.Y;
                    float num81 = (float) Math.Sqrt((double) ((num79 * num79) + (num80 * num80)));
                    if (this.ai[0] == 0f)
                    {
                        this.tileCollide = true;
                        if (num81 > 160f)
                        {
                            this.ai[0] = 1f;
                            this.netUpdate = true;
                        }
                        else if (!Main.player[this.owner].channel)
                        {
                            if (this.velocity.Y < 0f)
                            {
                                this.velocity.Y *= 0.9f;
                            }
                            this.velocity.Y++;
                            this.velocity.X *= 0.9f;
                        }
                    }
                    else if (this.ai[0] == 1f)
                    {
                        float num82 = 14f / Main.player[this.owner].meleeSpeed;
                        float num83 = 0.9f / Main.player[this.owner].meleeSpeed;
                        Math.Abs(num79);
                        Math.Abs(num80);
                        if (this.ai[1] == 1f)
                        {
                            this.tileCollide = false;
                        }
                        if ((!Main.player[this.owner].channel || (num81 > 300f)) || !this.tileCollide)
                        {
                            this.ai[1] = 1f;
                            if (this.tileCollide)
                            {
                                this.netUpdate = true;
                            }
                            this.tileCollide = false;
                            if (num81 < 20f)
                            {
                                this.Kill();
                            }
                        }
                        if (!this.tileCollide)
                        {
                            num83 *= 2f;
                        }
                        if ((num81 > 60f) || !this.tileCollide)
                        {
                            num81 = num82 / num81;
                            num79 *= num81;
                            num80 *= num81;
                            new Vector2(this.velocity.X, this.velocity.Y);
                            float num84 = num79 - this.velocity.X;
                            float num85 = num80 - this.velocity.Y;
                            float num86 = (float) Math.Sqrt((double) ((num84 * num84) + (num85 * num85)));
                            num86 = num83 / num86;
                            num84 *= num86;
                            num85 *= num86;
                            this.velocity.X *= 0.98f;
                            this.velocity.Y *= 0.98f;
                            this.velocity.X += num84;
                            this.velocity.Y += num85;
                        }
                        else
                        {
                            if ((Math.Abs(this.velocity.X) + Math.Abs(this.velocity.Y)) < 6f)
                            {
                                this.velocity.X *= 0.96f;
                                this.velocity.Y += 0.2f;
                            }
                            if (Main.player[this.owner].velocity.X == 0f)
                            {
                                this.velocity.X *= 0.96f;
                            }
                        }
                    }
                    this.rotation = ((float) Math.Atan2((double) num80, (double) num79)) - (this.velocity.X * 0.1f);
                }
            }
            else if (this.aiStyle == 0x10)
            {
                if (this.type == 0x25)
                {
                    try
                    {
                        int num87 = ((int) (this.position.X / 16f)) - 1;
                        int num88 = ((int) ((this.position.X + this.width) / 16f)) + 2;
                        int num89 = ((int) (this.position.Y / 16f)) - 1;
                        int num90 = ((int) ((this.position.Y + this.height) / 16f)) + 2;
                        if (num87 < 0)
                        {
                            num87 = 0;
                        }
                        if (num88 > Main.maxTilesX)
                        {
                            num88 = Main.maxTilesX;
                        }
                        if (num89 < 0)
                        {
                            num89 = 0;
                        }
                        if (num90 > Main.maxTilesY)
                        {
                            num90 = Main.maxTilesY;
                        }
                        for (int num91 = num87; num91 < num88; num91++)
                        {
                            for (int num92 = num89; num92 < num90; num92++)
                            {
                                if (((Main.tile[num91, num92] != null) && Main.tile[num91, num92].active) && (Main.tileSolid[Main.tile[num91, num92].type] || (Main.tileSolidTop[Main.tile[num91, num92].type] && (Main.tile[num91, num92].frameY == 0))))
                                {
                                    Vector2 vector14;
                                    vector14.X = num91 * 0x10;
                                    vector14.Y = num92 * 0x10;
                                    if (((((this.position.X + this.width) - 4f) > vector14.X) && ((this.position.X + 4f) < (vector14.X + 16f))) && ((((this.position.Y + this.height) - 4f) > vector14.Y) && ((this.position.Y + 4f) < (vector14.Y + 16f))))
                                    {
                                        this.velocity.X = 0f;
                                        this.velocity.Y = -0.2f;
                                    }
                                }
                            }
                        }
                    }
                    catch
                    {
                    }
                }
                if ((this.owner == Main.myPlayer) && (this.timeLeft <= 3))
                {
                    this.ai[1] = 0f;
                    this.alpha = 0xff;
                    if ((this.type == 0x1c) || (this.type == 0x25))
                    {
                        this.position.X += this.width / 2;
                        this.position.Y += this.height / 2;
                        this.width = 0x80;
                        this.height = 0x80;
                        this.position.X -= this.width / 2;
                        this.position.Y -= this.height / 2;
                        this.damage = 100;
                        this.knockBack = 8f;
                    }
                    else if (this.type == 0x1d)
                    {
                        this.position.X += this.width / 2;
                        this.position.Y += this.height / 2;
                        this.width = 250;
                        this.height = 250;
                        this.position.X -= this.width / 2;
                        this.position.Y -= this.height / 2;
                        this.damage = 250;
                        this.knockBack = 10f;
                    }
                    else if (this.type == 30)
                    {
                        this.position.X += this.width / 2;
                        this.position.Y += this.height / 2;
                        this.width = 0x80;
                        this.height = 0x80;
                        this.position.X -= this.width / 2;
                        this.position.Y -= this.height / 2;
                        this.knockBack = 8f;
                    }
                }
                else if ((this.type != 30) && (Main.rand.Next(4) == 0))
                {
                    if (this.type != 30)
                    {
                        this.damage = 0;
                    }
                    Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 6, 0f, 0f, 100, new Color(), 1f);
                }
                this.ai[0]++;
                if (((this.type == 30) && (this.ai[0] > 10f)) || ((this.type != 30) && (this.ai[0] > 5f)))
                {
                    this.ai[0] = 10f;
                    if ((this.velocity.Y == 0f) && (this.velocity.X != 0f))
                    {
                        this.velocity.X *= 0.97f;
                        if (this.type == 0x1d)
                        {
                            this.velocity.X *= 0.99f;
                        }
                        if ((this.velocity.X > -0.01) && (this.velocity.X < 0.01))
                        {
                            this.velocity.X = 0f;
                            this.netUpdate = true;
                        }
                    }
                    this.velocity.Y += 0.2f;
                }
                this.rotation += this.velocity.X * 0.1f;
            }
            else if (this.aiStyle == 0x11)
            {
                if (this.velocity.Y == 0f)
                {
                    this.velocity.X *= 0.98f;
                }
                this.rotation += this.velocity.X * 0.1f;
                this.velocity.Y += 0.2f;
                if (this.owner == Main.myPlayer)
                {
                    int num93 = (int) ((this.position.X + this.width) / 16f);
                    int num94 = (int) ((this.position.Y + this.height) / 16f);
                    if ((Main.tile[num93, num94] != null) && !Main.tile[num93, num94].active)
                    {
                        WorldGen.PlaceTile(num93, num94, 0x55, false, false, -1, 0);
                        if (Main.tile[num93, num94].active)
                        {
                            if (Main.netMode != 0)
                            {
                                NetMessage.SendData(0x11, -1, -1, "", 1, (float) num93, (float) num94, 85f, 0);
                            }
                            int num95 = Sign.ReadSign(num93, num94);
                            if (num95 >= 0)
                            {
                                Sign.TextSign(num95, this.miscText);
                            }
                            this.Kill();
                        }
                    }
                }
            }
            else if (this.aiStyle == 0x12)
            {
                if ((this.ai[1] == 0f) && (this.type == 0x2c))
                {
                    this.ai[1] = 1f;
                    Main.PlaySound(2, (int) this.position.X, (int) this.position.Y, 8);
                }
                this.rotation += this.direction * 0.8f;
                this.ai[0]++;
                if (this.ai[0] >= 30f)
                {
                    if (this.ai[0] < 100f)
                    {
                        this.velocity = (Vector2) (this.velocity * 1.06f);
                    }
                    else
                    {
                        this.ai[0] = 200f;
                    }
                }
                for (int num96 = 0; num96 < 2; num96++)
                {
                    color = new Color();
                    int num97 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 0x1b, 0f, 0f, 100, color, 1f);
                    Main.dust[num97].noGravity = true;
                }
            }
            else if (this.aiStyle == 0x13)
            {
                this.direction = Main.player[this.owner].direction;
                Main.player[this.owner].heldProj = this.whoAmI;
                Main.player[this.owner].itemTime = Main.player[this.owner].itemAnimation;
                this.position.X = (Main.player[this.owner].position.X + (Main.player[this.owner].width / 2)) - (this.width / 2);
                this.position.Y = (Main.player[this.owner].position.Y + (Main.player[this.owner].height / 2)) - (this.height / 2);
                if (this.type == 0x2e)
                {
                    if (this.ai[0] == 0f)
                    {
                        this.ai[0] = 3f;
                        this.netUpdate = true;
                    }
                    if (Main.player[this.owner].itemAnimation < (Main.player[this.owner].itemAnimationMax / 3))
                    {
                        this.ai[0] -= 1.6f;
                    }
                    else
                    {
                        this.ai[0] += 1.4f;
                    }
                }
                else if (this.type == 0x2f)
                {
                    if (this.ai[0] == 0f)
                    {
                        this.ai[0] = 4f;
                        this.netUpdate = true;
                    }
                    if (Main.player[this.owner].itemAnimation < (Main.player[this.owner].itemAnimationMax / 3))
                    {
                        this.ai[0] -= 1.2f;
                    }
                    else
                    {
                        this.ai[0] += 0.9f;
                    }
                }
                else if (this.type == 0x31)
                {
                    if (this.ai[0] == 0f)
                    {
                        this.ai[0] = 4f;
                        this.netUpdate = true;
                    }
                    if (Main.player[this.owner].itemAnimation < (Main.player[this.owner].itemAnimationMax / 3))
                    {
                        this.ai[0] -= 1.1f;
                    }
                    else
                    {
                        this.ai[0] += 0.85f;
                    }
                }
                this.position += (Vector2) (this.velocity * this.ai[0]);
                if (Main.player[this.owner].itemAnimation == 0)
                {
                    this.Kill();
                }
                this.rotation = ((float) Math.Atan2((double) this.velocity.Y, (double) this.velocity.X)) + 2.355f;
                if (this.type == 0x2e)
                {
                    if (Main.rand.Next(5) == 0)
                    {
                        color = new Color();
                        Dust.NewDust(this.position, this.width, this.height, 14, 0f, 0f, 150, color, 1.4f);
                    }
                    color = new Color();
                    int num98 = Dust.NewDust(this.position, this.width, this.height, 0x1b, (this.velocity.X * 0.2f) + (this.direction * 3), this.velocity.Y * 0.2f, 100, color, 1.2f);
                    Main.dust[num98].noGravity = true;
                    Main.dust[num98].velocity.X /= 2f;
                    Main.dust[num98].velocity.Y /= 2f;
                    num98 = Dust.NewDust(this.position - ((Vector2) (this.velocity * 2f)), this.width, this.height, 0x1b, 0f, 0f, 150, new Color(), 1.4f);
                    Main.dust[num98].velocity.X /= 5f;
                    Main.dust[num98].velocity.Y /= 5f;
                }
            }
        }

        public void Damage()
        {
            Rectangle rectangle = new Rectangle((int) this.position.X, (int) this.position.Y, this.width, this.height);
            if (this.friendly && (this.type != 0x12))
            {
                if (this.owner == Main.myPlayer)
                {
                    if (((this.aiStyle == 0x10) || (this.type == 0x29)) && (this.timeLeft <= 1))
                    {
                        int myPlayer = Main.myPlayer;
                        if (((Main.player[myPlayer].active && !Main.player[myPlayer].dead) && !Main.player[myPlayer].immune) && (!this.ownerHitCheck || Collision.CanHit(Main.player[this.owner].position, Main.player[this.owner].width, Main.player[this.owner].height, Main.player[myPlayer].position, Main.player[myPlayer].width, Main.player[myPlayer].height)))
                        {
                            Rectangle rectangle2 = new Rectangle((int) Main.player[myPlayer].position.X, (int) Main.player[myPlayer].position.Y, Main.player[myPlayer].width, Main.player[myPlayer].height);
                            if (rectangle.Intersects(rectangle2))
                            {
                                if ((Main.player[myPlayer].position.X + (Main.player[myPlayer].width / 2)) < (this.position.X + (this.width / 2)))
                                {
                                    this.direction = -1;
                                }
                                else
                                {
                                    this.direction = 1;
                                }
                                int damage = Main.DamageVar((float) this.damage);
                                this.StatusPlayer(myPlayer);
                                Main.player[myPlayer].Hurt(damage, this.direction, true, false, Player.getDeathMessage(this.owner, -1, this.whoAmI, -1), false);
                                if (Main.netMode != 0)
                                {
                                    NetMessage.SendData(0x1a, -1, -1, Player.getDeathMessage(this.owner, -1, this.whoAmI, -1), myPlayer, (float) this.direction, (float) damage, 1f, 0);
                                }
                            }
                        }
                    }
                    int num3 = (int) (this.position.X / 16f);
                    int maxTilesX = ((int) ((this.position.X + this.width) / 16f)) + 1;
                    int num5 = (int) (this.position.Y / 16f);
                    int maxTilesY = ((int) ((this.position.Y + this.height) / 16f)) + 1;
                    if (num3 < 0)
                    {
                        num3 = 0;
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
                    for (int i = num3; i < maxTilesX; i++)
                    {
                        for (int j = num5; j < maxTilesY; j++)
                        {
                            if (((Main.tile[i, j] != null) && Main.tileCut[Main.tile[i, j].type]) && ((Main.tile[i, j + 1] != null) && (Main.tile[i, j + 1].type != 0x4e)))
                            {
                                WorldGen.KillTile(i, j, false, false, false);
                                if (Main.netMode != 0)
                                {
                                    NetMessage.SendData(0x11, -1, -1, "", 0, (float) i, (float) j, 0f, 0);
                                }
                            }
                        }
                    }
                    if (this.damage > 0)
                    {
                        for (int k = 0; k < 0x3e8; k++)
                        {
                            if (((Main.npc[k].active && !Main.npc[k].dontTakeDamage) && (!Main.npc[k].friendly || (((Main.npc[k].type == 0x16) && (this.owner < 0xff)) && Main.player[this.owner].killGuide))) && ((this.owner < 0) || (Main.npc[k].immune[this.owner] == 0)))
                            {
                                bool flag = false;
                                if ((this.type == 11) && ((Main.npc[k].type == 0x2f) || (Main.npc[k].type == 0x39)))
                                {
                                    flag = true;
                                }
                                else if ((this.type == 0x1f) && (Main.npc[k].type == 0x45))
                                {
                                    flag = true;
                                }
                                if (!flag && ((Main.npc[k].noTileCollide || !this.ownerHitCheck) || Collision.CanHit(Main.player[this.owner].position, Main.player[this.owner].width, Main.player[this.owner].height, Main.npc[k].position, Main.npc[k].width, Main.npc[k].height)))
                                {
                                    Rectangle rectangle3 = new Rectangle((int) Main.npc[k].position.X, (int) Main.npc[k].position.Y, Main.npc[k].width, Main.npc[k].height);
                                    if (rectangle.Intersects(rectangle3))
                                    {
                                        if (this.aiStyle == 3)
                                        {
                                            if (this.ai[0] == 0f)
                                            {
                                                this.velocity.X = -this.velocity.X;
                                                this.velocity.Y = -this.velocity.Y;
                                                this.netUpdate = true;
                                            }
                                            this.ai[0] = 1f;
                                        }
                                        else if (this.aiStyle == 0x10)
                                        {
                                            if (this.timeLeft > 3)
                                            {
                                                this.timeLeft = 3;
                                            }
                                            if ((Main.npc[k].position.X + (Main.npc[k].width / 2)) < (this.position.X + (this.width / 2)))
                                            {
                                                this.direction = -1;
                                            }
                                            else
                                            {
                                                this.direction = 1;
                                            }
                                        }
                                        if ((this.type == 0x29) && (this.timeLeft > 1))
                                        {
                                            this.timeLeft = 1;
                                        }
                                        bool crit = false;
                                        if (this.melee && (Main.rand.Next(1, 0x65) <= Main.player[this.owner].meleeCrit))
                                        {
                                            crit = true;
                                        }
                                        if (this.ranged && (Main.rand.Next(1, 0x65) <= Main.player[this.owner].rangedCrit))
                                        {
                                            crit = true;
                                        }
                                        if (this.magic && (Main.rand.Next(1, 0x65) <= Main.player[this.owner].magicCrit))
                                        {
                                            crit = true;
                                        }
                                        int num10 = Main.DamageVar((float) this.damage);
                                        this.StatusNPC(k);
                                        Main.npc[k].StrikeNPC(num10, this.knockBack, this.direction, crit);
                                        if (Main.netMode != 0)
                                        {
                                            if (crit)
                                            {
                                                NetMessage.SendData(0x1c, -1, -1, "", k, (float) num10, this.knockBack, (float) this.direction, 1);
                                            }
                                            else
                                            {
                                                NetMessage.SendData(0x1c, -1, -1, "", k, (float) num10, this.knockBack, (float) this.direction, 0);
                                            }
                                        }
                                        if (this.penetrate != 1)
                                        {
                                            Main.npc[k].immune[this.owner] = 10;
                                        }
                                        if (this.penetrate > 0)
                                        {
                                            this.penetrate--;
                                            if (this.penetrate == 0)
                                            {
                                                break;
                                            }
                                        }
                                        if (this.aiStyle == 7)
                                        {
                                            this.ai[0] = 1f;
                                            this.damage = 0;
                                            this.netUpdate = true;
                                        }
                                        else if (this.aiStyle == 13)
                                        {
                                            this.ai[0] = 1f;
                                            this.netUpdate = true;
                                        }
                                    }
                                }
                            }
                        }
                    }
                    if ((this.damage > 0) && Main.player[Main.myPlayer].hostile)
                    {
                        for (int m = 0; m < 0xff; m++)
                        {
                            if (((((m != this.owner) && Main.player[m].active) && (!Main.player[m].dead && !Main.player[m].immune)) && ((Main.player[m].hostile && (this.playerImmune[m] <= 0)) && ((Main.player[Main.myPlayer].team == 0) || (Main.player[Main.myPlayer].team != Main.player[m].team)))) && (!this.ownerHitCheck || Collision.CanHit(Main.player[this.owner].position, Main.player[this.owner].width, Main.player[this.owner].height, Main.player[m].position, Main.player[m].width, Main.player[m].height)))
                            {
                                Rectangle rectangle4 = new Rectangle((int) Main.player[m].position.X, (int) Main.player[m].position.Y, Main.player[m].width, Main.player[m].height);
                                if (rectangle.Intersects(rectangle4))
                                {
                                    if (this.aiStyle == 3)
                                    {
                                        if (this.ai[0] == 0f)
                                        {
                                            this.velocity.X = -this.velocity.X;
                                            this.velocity.Y = -this.velocity.Y;
                                            this.netUpdate = true;
                                        }
                                        this.ai[0] = 1f;
                                    }
                                    else if (this.aiStyle == 0x10)
                                    {
                                        if (this.timeLeft > 3)
                                        {
                                            this.timeLeft = 3;
                                        }
                                        if ((Main.player[m].position.X + (Main.player[m].width / 2)) < (this.position.X + (this.width / 2)))
                                        {
                                            this.direction = -1;
                                        }
                                        else
                                        {
                                            this.direction = 1;
                                        }
                                    }
                                    if ((this.type == 0x29) && (this.timeLeft > 1))
                                    {
                                        this.timeLeft = 1;
                                    }
                                    bool flag3 = false;
                                    if (this.melee && (Main.rand.Next(1, 0x65) <= Main.player[this.owner].meleeCrit))
                                    {
                                        flag3 = true;
                                    }
                                    int num12 = Main.DamageVar((float) this.damage);
                                    if (!Main.player[m].immune)
                                    {
                                        this.StatusPvP(m);
                                    }
                                    Main.player[m].Hurt(num12, this.direction, true, false, Player.getDeathMessage(this.owner, -1, this.whoAmI, -1), flag3);
                                    if (Main.netMode != 0)
                                    {
                                        if (flag3)
                                        {
                                            NetMessage.SendData(0x1a, -1, -1, Player.getDeathMessage(this.owner, -1, this.whoAmI, -1), m, (float) this.direction, (float) num12, 1f, 1);
                                        }
                                        else
                                        {
                                            NetMessage.SendData(0x1a, -1, -1, Player.getDeathMessage(this.owner, -1, this.whoAmI, -1), m, (float) this.direction, (float) num12, 1f, 0);
                                        }
                                    }
                                    this.playerImmune[m] = 40;
                                    if (this.penetrate > 0)
                                    {
                                        this.penetrate--;
                                        if (this.penetrate == 0)
                                        {
                                            break;
                                        }
                                    }
                                    if (this.aiStyle == 7)
                                    {
                                        this.ai[0] = 1f;
                                        this.damage = 0;
                                        this.netUpdate = true;
                                    }
                                    else if (this.aiStyle == 13)
                                    {
                                        this.ai[0] = 1f;
                                        this.netUpdate = true;
                                    }
                                }
                            }
                        }
                    }
                }
                if ((this.type == 11) && (Main.netMode != 1))
                {
                    for (int n = 0; n < 0x3e8; n++)
                    {
                        if (Main.npc[n].active)
                        {
                            if (Main.npc[n].type == 0x2e)
                            {
                                Rectangle rectangle5 = new Rectangle((int) Main.npc[n].position.X, (int) Main.npc[n].position.Y, Main.npc[n].width, Main.npc[n].height);
                                if (rectangle.Intersects(rectangle5))
                                {
                                    Main.npc[n].Transform(0x2f);
                                }
                            }
                            else if (Main.npc[n].type == 0x37)
                            {
                                Rectangle rectangle6 = new Rectangle((int) Main.npc[n].position.X, (int) Main.npc[n].position.Y, Main.npc[n].width, Main.npc[n].height);
                                if (rectangle.Intersects(rectangle6))
                                {
                                    Main.npc[n].Transform(0x39);
                                }
                            }
                        }
                    }
                }
            }
            if (((Main.netMode != 2) && this.hostile) && ((Main.myPlayer < 0xff) && (this.damage > 0)))
            {
                int index = Main.myPlayer;
                if ((Main.player[index].active && !Main.player[index].dead) && !Main.player[index].immune)
                {
                    Rectangle rectangle7 = new Rectangle((int) Main.player[index].position.X, (int) Main.player[index].position.Y, Main.player[index].width, Main.player[index].height);
                    if (rectangle.Intersects(rectangle7))
                    {
                        int direction = this.direction;
                        if ((Main.player[index].position.X + (Main.player[index].width / 2)) < (this.position.X + (this.width / 2)))
                        {
                            direction = -1;
                        }
                        else
                        {
                            direction = 1;
                        }
                        int num16 = Main.DamageVar((float) this.damage);
                        if (!Main.player[index].immune)
                        {
                            this.StatusPlayer(index);
                        }
                        Main.player[index].Hurt(num16 * 2, direction, false, false, " was slain...", false);
                    }
                }
            }
        }

        public Color GetAlpha(Color newColor)
        {
            int r;
            int g;
            int b;
            if (((this.type == 9) || (this.type == 15)) || (((this.type == 0x22) || (this.type == 50)) || (this.type == 0x35)))
            {
                r = newColor.R - (this.alpha / 3);
                g = newColor.G - (this.alpha / 3);
                b = newColor.B - (this.alpha / 3);
            }
            else if (((this.type == 0x10) || (this.type == 0x12)) || ((this.type == 0x2c) || (this.type == 0x2d)))
            {
                r = newColor.R;
                g = newColor.G;
                b = newColor.B;
            }
            else
            {
                r = newColor.R - this.alpha;
                g = newColor.G - this.alpha;
                b = newColor.B - this.alpha;
            }
            int a = newColor.A - this.alpha;
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

        public void Kill()
        {
            if (this.active)
            {
                Color color;
                this.timeLeft = 0;
                if (this.type == 1)
                {
                    Main.PlaySound(0, (int) this.position.X, (int) this.position.Y, 1);
                    for (int i = 0; i < 10; i++)
                    {
                        color = new Color();
                        Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 7, 0f, 0f, 0, color, 1f);
                    }
                }
                else if (this.type == 0x37)
                {
                    for (int j = 0; j < 5; j++)
                    {
                        color = new Color();
                        int index = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 0x12, 0f, 0f, 0, color, 1.5f);
                        Main.dust[index].noGravity = true;
                    }
                }
                else if (this.type == 0x33)
                {
                    Main.PlaySound(0, (int) this.position.X, (int) this.position.Y, 1);
                    for (int k = 0; k < 5; k++)
                    {
                        color = new Color();
                        Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 0, 0f, 0f, 0, color, 0.7f);
                    }
                }
                else if (this.type == 2)
                {
                    Main.PlaySound(0, (int) this.position.X, (int) this.position.Y, 1);
                    for (int m = 0; m < 20; m++)
                    {
                        color = new Color();
                        Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 6, 0f, 0f, 100, color, 1f);
                    }
                }
                else if (((this.type == 3) || (this.type == 0x30)) || (this.type == 0x36))
                {
                    Main.PlaySound(0, (int) this.position.X, (int) this.position.Y, 1);
                    for (int n = 0; n < 10; n++)
                    {
                        color = new Color();
                        Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 1, this.velocity.X * 0.1f, this.velocity.Y * 0.1f, 0, color, 0.75f);
                    }
                }
                else if (this.type == 4)
                {
                    Main.PlaySound(0, (int) this.position.X, (int) this.position.Y, 1);
                    for (int num7 = 0; num7 < 10; num7++)
                    {
                        color = new Color();
                        Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 14, 0f, 0f, 150, color, 1.1f);
                    }
                }
                else if (this.type == 5)
                {
                    Main.PlaySound(2, (int) this.position.X, (int) this.position.Y, 10);
                    for (int num8 = 0; num8 < 60; num8++)
                    {
                        color = new Color();
                        Dust.NewDust(this.position, this.width, this.height, 15, this.velocity.X * 0.5f, this.velocity.Y * 0.5f, 150, color, 1.5f);
                    }
                }
                else if ((this.type == 9) || (this.type == 12))
                {
                    Main.PlaySound(2, (int) this.position.X, (int) this.position.Y, 10);
                    for (int num9 = 0; num9 < 10; num9++)
                    {
                        color = new Color();
                        Dust.NewDust(this.position, this.width, this.height, 15, this.velocity.X * 0.1f, this.velocity.Y * 0.1f, 150, color, 1.2f);
                    }
                    for (int num10 = 0; num10 < 3; num10++)
                    {
                        Gore.NewGore(this.position, new Vector2(this.velocity.X * 0.05f, this.velocity.Y * 0.05f), Main.rand.Next(0x10, 0x12), 1f);
                    }
                    if ((this.type == 12) && (this.damage < 100))
                    {
                        for (int num11 = 0; num11 < 10; num11++)
                        {
                            color = new Color();
                            Dust.NewDust(this.position, this.width, this.height, 15, this.velocity.X * 0.1f, this.velocity.Y * 0.1f, 150, color, 1.2f);
                        }
                        for (int num12 = 0; num12 < 3; num12++)
                        {
                            Gore.NewGore(this.position, new Vector2(this.velocity.X * 0.05f, this.velocity.Y * 0.05f), Main.rand.Next(0x10, 0x12), 1f);
                        }
                    }
                }
                else if (((this.type == 14) || (this.type == 20)) || (this.type == 0x24))
                {
                    Collision.HitTiles(this.position, this.velocity, this.width, this.height);
                    Main.PlaySound(2, (int) this.position.X, (int) this.position.Y, 10);
                }
                else if ((this.type == 15) || (this.type == 0x22))
                {
                    Main.PlaySound(2, (int) this.position.X, (int) this.position.Y, 10);
                    for (int num13 = 0; num13 < 20; num13++)
                    {
                        color = new Color();
                        int num14 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 6, -this.velocity.X * 0.2f, -this.velocity.Y * 0.2f, 100, color, 2f);
                        Main.dust[num14].noGravity = true;
                        Dust dust1 = Main.dust[num14];
                        dust1.velocity = (Vector2) (dust1.velocity * 2f);
                        color = new Color();
                        num14 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 6, -this.velocity.X * 0.2f, -this.velocity.Y * 0.2f, 100, color, 1f);
                        Dust dust2 = Main.dust[num14];
                        dust2.velocity = (Vector2) (dust2.velocity * 2f);
                    }
                }
                else if (this.type == 0x10)
                {
                    Main.PlaySound(2, (int) this.position.X, (int) this.position.Y, 10);
                    for (int num15 = 0; num15 < 20; num15++)
                    {
                        color = new Color();
                        int num16 = Dust.NewDust(new Vector2(this.position.X - this.velocity.X, this.position.Y - this.velocity.Y), this.width, this.height, 15, 0f, 0f, 100, color, 2f);
                        Main.dust[num16].noGravity = true;
                        Dust dust3 = Main.dust[num16];
                        dust3.velocity = (Vector2) (dust3.velocity * 2f);
                        color = new Color();
                        num16 = Dust.NewDust(new Vector2(this.position.X - this.velocity.X, this.position.Y - this.velocity.Y), this.width, this.height, 15, 0f, 0f, 100, color, 1f);
                    }
                }
                else if (this.type == 0x11)
                {
                    Main.PlaySound(0, (int) this.position.X, (int) this.position.Y, 1);
                    for (int num17 = 0; num17 < 5; num17++)
                    {
                        color = new Color();
                        Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 0, 0f, 0f, 0, color, 1f);
                    }
                }
                else if ((this.type == 0x1f) || (this.type == 0x2a))
                {
                    Main.PlaySound(0, (int) this.position.X, (int) this.position.Y, 1);
                    for (int num18 = 0; num18 < 5; num18++)
                    {
                        color = new Color();
                        int num19 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 0x20, 0f, 0f, 0, color, 1f);
                        Dust dust4 = Main.dust[num19];
                        dust4.velocity = (Vector2) (dust4.velocity * 0.6f);
                    }
                }
                else if (this.type == 0x27)
                {
                    Main.PlaySound(0, (int) this.position.X, (int) this.position.Y, 1);
                    for (int num20 = 0; num20 < 5; num20++)
                    {
                        color = new Color();
                        int num21 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 0x26, 0f, 0f, 0, color, 1f);
                        Dust dust5 = Main.dust[num21];
                        dust5.velocity = (Vector2) (dust5.velocity * 0.6f);
                    }
                }
                else if (this.type == 40)
                {
                    Main.PlaySound(0, (int) this.position.X, (int) this.position.Y, 1);
                    for (int num22 = 0; num22 < 5; num22++)
                    {
                        color = new Color();
                        int num23 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 0x24, 0f, 0f, 0, color, 1f);
                        Dust dust6 = Main.dust[num23];
                        dust6.velocity = (Vector2) (dust6.velocity * 0.6f);
                    }
                }
                else if (this.type == 0x15)
                {
                    Main.PlaySound(0, (int) this.position.X, (int) this.position.Y, 1);
                    for (int num24 = 0; num24 < 10; num24++)
                    {
                        color = new Color();
                        Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 0x1a, 0f, 0f, 0, color, 0.8f);
                    }
                }
                else if (this.type == 0x18)
                {
                    for (int num25 = 0; num25 < 10; num25++)
                    {
                        color = new Color();
                        Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 1, this.velocity.X * 0.1f, this.velocity.Y * 0.1f, 0, color, 0.75f);
                    }
                }
                else if (this.type == 0x1b)
                {
                    Main.PlaySound(2, (int) this.position.X, (int) this.position.Y, 10);
                    for (int num26 = 0; num26 < 30; num26++)
                    {
                        color = new Color();
                        int num27 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 0x1d, this.velocity.X * 0.1f, this.velocity.Y * 0.1f, 100, color, 3f);
                        Main.dust[num27].noGravity = true;
                        color = new Color();
                        Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 0x1d, this.velocity.X * 0.1f, this.velocity.Y * 0.1f, 100, color, 2f);
                    }
                }
                else if (this.type == 0x26)
                {
                    for (int num28 = 0; num28 < 10; num28++)
                    {
                        color = new Color();
                        Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 0x2a, this.velocity.X * 0.1f, this.velocity.Y * 0.1f, 0, color, 1f);
                    }
                }
                else if ((this.type == 0x2c) || (this.type == 0x2d))
                {
                    Main.PlaySound(2, (int) this.position.X, (int) this.position.Y, 10);
                    for (int num29 = 0; num29 < 30; num29++)
                    {
                        color = new Color();
                        int num30 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 0x1b, this.velocity.X, this.velocity.Y, 100, color, 1.7f);
                        Main.dust[num30].noGravity = true;
                        color = new Color();
                        Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 0x1b, this.velocity.X, this.velocity.Y, 100, color, 1f);
                    }
                }
                else
                {
                    Vector2 vector;
                    if (this.type == 0x29)
                    {
                        Main.PlaySound(2, (int) this.position.X, (int) this.position.Y, 14);
                        for (int num31 = 0; num31 < 10; num31++)
                        {
                            color = new Color();
                            Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 0x1f, 0f, 0f, 100, color, 1.5f);
                        }
                        for (int num32 = 0; num32 < 5; num32++)
                        {
                            color = new Color();
                            int num33 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 6, 0f, 0f, 100, color, 2.5f);
                            Main.dust[num33].noGravity = true;
                            Dust dust7 = Main.dust[num33];
                            dust7.velocity = (Vector2) (dust7.velocity * 3f);
                            color = new Color();
                            num33 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 6, 0f, 0f, 100, color, 1.5f);
                            Dust dust8 = Main.dust[num33];
                            dust8.velocity = (Vector2) (dust8.velocity * 2f);
                        }
                        vector = new Vector2();
                        int num34 = Gore.NewGore(new Vector2(this.position.X, this.position.Y), vector, Main.rand.Next(0x3d, 0x40), 1f);
                        Gore gore1 = Main.gore[num34];
                        gore1.velocity = (Vector2) (gore1.velocity * 0.4f);
                        Main.gore[num34].velocity.X += Main.rand.Next(-10, 11) * 0.1f;
                        Main.gore[num34].velocity.Y += Main.rand.Next(-10, 11) * 0.1f;
                        num34 = Gore.NewGore(new Vector2(this.position.X, this.position.Y), new Vector2(), Main.rand.Next(0x3d, 0x40), 1f);
                        Gore gore2 = Main.gore[num34];
                        gore2.velocity = (Vector2) (gore2.velocity * 0.4f);
                        Main.gore[num34].velocity.X += Main.rand.Next(-10, 11) * 0.1f;
                        Main.gore[num34].velocity.Y += Main.rand.Next(-10, 11) * 0.1f;
                        if (this.owner == Main.myPlayer)
                        {
                            this.penetrate = -1;
                            this.position.X += this.width / 2;
                            this.position.Y += this.height / 2;
                            this.width = 0x40;
                            this.height = 0x40;
                            this.position.X -= this.width / 2;
                            this.position.Y -= this.height / 2;
                            this.Damage();
                        }
                    }
                    else if (((this.type == 0x1c) || (this.type == 30)) || (this.type == 0x25))
                    {
                        Main.PlaySound(2, (int) this.position.X, (int) this.position.Y, 14);
                        this.position.X += this.width / 2;
                        this.position.Y += this.height / 2;
                        this.width = 0x16;
                        this.height = 0x16;
                        this.position.X -= this.width / 2;
                        this.position.Y -= this.height / 2;
                        for (int num35 = 0; num35 < 20; num35++)
                        {
                            color = new Color();
                            int num36 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 0x1f, 0f, 0f, 100, color, 1.5f);
                            Dust dust9 = Main.dust[num36];
                            dust9.velocity = (Vector2) (dust9.velocity * 1.4f);
                        }
                        for (int num37 = 0; num37 < 10; num37++)
                        {
                            color = new Color();
                            int num38 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 6, 0f, 0f, 100, color, 2.5f);
                            Main.dust[num38].noGravity = true;
                            Dust dust10 = Main.dust[num38];
                            dust10.velocity = (Vector2) (dust10.velocity * 5f);
                            color = new Color();
                            num38 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 6, 0f, 0f, 100, color, 1.5f);
                            Dust dust11 = Main.dust[num38];
                            dust11.velocity = (Vector2) (dust11.velocity * 3f);
                        }
                        vector = new Vector2();
                        int num39 = Gore.NewGore(new Vector2(this.position.X, this.position.Y), vector, Main.rand.Next(0x3d, 0x40), 1f);
                        Gore gore3 = Main.gore[num39];
                        gore3.velocity = (Vector2) (gore3.velocity * 0.4f);
                        Main.gore[num39].velocity.X++;
                        Main.gore[num39].velocity.Y++;
                        vector = new Vector2();
                        num39 = Gore.NewGore(new Vector2(this.position.X, this.position.Y), vector, Main.rand.Next(0x3d, 0x40), 1f);
                        Gore gore4 = Main.gore[num39];
                        gore4.velocity = (Vector2) (gore4.velocity * 0.4f);
                        Main.gore[num39].velocity.X--;
                        Main.gore[num39].velocity.Y++;
                        vector = new Vector2();
                        num39 = Gore.NewGore(new Vector2(this.position.X, this.position.Y), vector, Main.rand.Next(0x3d, 0x40), 1f);
                        Gore gore5 = Main.gore[num39];
                        gore5.velocity = (Vector2) (gore5.velocity * 0.4f);
                        Main.gore[num39].velocity.X++;
                        Main.gore[num39].velocity.Y--;
                        num39 = Gore.NewGore(new Vector2(this.position.X, this.position.Y), new Vector2(), Main.rand.Next(0x3d, 0x40), 1f);
                        Gore gore6 = Main.gore[num39];
                        gore6.velocity = (Vector2) (gore6.velocity * 0.4f);
                        Main.gore[num39].velocity.X--;
                        Main.gore[num39].velocity.Y--;
                    }
                    else if (this.type == 0x1d)
                    {
                        Main.PlaySound(2, (int) this.position.X, (int) this.position.Y, 14);
                        this.position.X += this.width / 2;
                        this.position.Y += this.height / 2;
                        this.width = 200;
                        this.height = 200;
                        this.position.X -= this.width / 2;
                        this.position.Y -= this.height / 2;
                        for (int num40 = 0; num40 < 50; num40++)
                        {
                            color = new Color();
                            int num41 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 0x1f, 0f, 0f, 100, color, 2f);
                            Dust dust12 = Main.dust[num41];
                            dust12.velocity = (Vector2) (dust12.velocity * 1.4f);
                        }
                        for (int num42 = 0; num42 < 80; num42++)
                        {
                            color = new Color();
                            int num43 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 6, 0f, 0f, 100, color, 3f);
                            Main.dust[num43].noGravity = true;
                            Dust dust13 = Main.dust[num43];
                            dust13.velocity = (Vector2) (dust13.velocity * 5f);
                            color = new Color();
                            num43 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 6, 0f, 0f, 100, color, 2f);
                            Dust dust14 = Main.dust[num43];
                            dust14.velocity = (Vector2) (dust14.velocity * 3f);
                        }
                        for (int num45 = 0; num45 < 2; num45++)
                        {
                            vector = new Vector2();
                            int num44 = Gore.NewGore(new Vector2((this.position.X + (this.width / 2)) - 24f, (this.position.Y + (this.height / 2)) - 24f), vector, Main.rand.Next(0x3d, 0x40), 1f);
                            Main.gore[num44].scale = 1.5f;
                            Main.gore[num44].velocity.X += 1.5f;
                            Main.gore[num44].velocity.Y += 1.5f;
                            vector = new Vector2();
                            num44 = Gore.NewGore(new Vector2((this.position.X + (this.width / 2)) - 24f, (this.position.Y + (this.height / 2)) - 24f), vector, Main.rand.Next(0x3d, 0x40), 1f);
                            Main.gore[num44].scale = 1.5f;
                            Main.gore[num44].velocity.X -= 1.5f;
                            Main.gore[num44].velocity.Y += 1.5f;
                            vector = new Vector2();
                            num44 = Gore.NewGore(new Vector2((this.position.X + (this.width / 2)) - 24f, (this.position.Y + (this.height / 2)) - 24f), vector, Main.rand.Next(0x3d, 0x40), 1f);
                            Main.gore[num44].scale = 1.5f;
                            Main.gore[num44].velocity.X += 1.5f;
                            Main.gore[num44].velocity.Y -= 1.5f;
                            vector = new Vector2();
                            num44 = Gore.NewGore(new Vector2((this.position.X + (this.width / 2)) - 24f, (this.position.Y + (this.height / 2)) - 24f), vector, Main.rand.Next(0x3d, 0x40), 1f);
                            Main.gore[num44].scale = 1.5f;
                            Main.gore[num44].velocity.X -= 1.5f;
                            Main.gore[num44].velocity.Y -= 1.5f;
                        }
                        this.position.X += this.width / 2;
                        this.position.Y += this.height / 2;
                        this.width = 10;
                        this.height = 10;
                        this.position.X -= this.width / 2;
                        this.position.Y -= this.height / 2;
                    }
                }
                if (this.owner == Main.myPlayer)
                {
                    if (((this.type == 0x1c) || (this.type == 0x1d)) || (this.type == 0x25))
                    {
                        int num46 = 3;
                        if (this.type == 0x1d)
                        {
                            num46 = 7;
                        }
                        int num47 = ((int) (this.position.X / 16f)) - num46;
                        int maxTilesX = ((int) (this.position.X / 16f)) + num46;
                        int num49 = ((int) (this.position.Y / 16f)) - num46;
                        int maxTilesY = ((int) (this.position.Y / 16f)) + num46;
                        if (num47 < 0)
                        {
                            num47 = 0;
                        }
                        if (maxTilesX > Main.maxTilesX)
                        {
                            maxTilesX = Main.maxTilesX;
                        }
                        if (num49 < 0)
                        {
                            num49 = 0;
                        }
                        if (maxTilesY > Main.maxTilesY)
                        {
                            maxTilesY = Main.maxTilesY;
                        }
                        bool flag = false;
                        for (int num51 = num47; num51 <= maxTilesX; num51++)
                        {
                            for (int num52 = num49; num52 <= maxTilesY; num52++)
                            {
                                float num53 = Math.Abs((float) (num51 - (this.position.X / 16f)));
                                float num54 = Math.Abs((float) (num52 - (this.position.Y / 16f)));
                                if (((Math.Sqrt((double) ((num53 * num53) + (num54 * num54))) < num46) && (Main.tile[num51, num52] != null)) && (Main.tile[num51, num52].wall == 0))
                                {
                                    flag = true;
                                    goto Label_1DC5;
                                }
                            }
                        Label_1DC5:;
                        }
                        for (int num56 = num47; num56 <= maxTilesX; num56++)
                        {
                            for (int num57 = num49; num57 <= maxTilesY; num57++)
                            {
                                float num58 = Math.Abs((float) (num56 - (this.position.X / 16f)));
                                float num59 = Math.Abs((float) (num57 - (this.position.Y / 16f)));
                                if (Math.Sqrt((double) ((num58 * num58) + (num59 * num59))) < num46)
                                {
                                    bool flag2 = true;
                                    if ((Main.tile[num56, num57] != null) && Main.tile[num56, num57].active)
                                    {
                                        flag2 = false;
                                        if ((this.type == 0x1c) || (this.type == 0x25))
                                        {
                                            if (((((!Main.tileSolid[Main.tile[num56, num57].type] || Main.tileSolidTop[Main.tile[num56, num57].type]) || ((Main.tile[num56, num57].type == 0) || (Main.tile[num56, num57].type == 1))) || (((Main.tile[num56, num57].type == 2) || (Main.tile[num56, num57].type == 0x17)) || ((Main.tile[num56, num57].type == 30) || (Main.tile[num56, num57].type == 40)))) || ((((Main.tile[num56, num57].type == 6) || (Main.tile[num56, num57].type == 7)) || ((Main.tile[num56, num57].type == 8) || (Main.tile[num56, num57].type == 9))) || (((Main.tile[num56, num57].type == 10) || (Main.tile[num56, num57].type == 0x35)) || ((Main.tile[num56, num57].type == 0x36) || (Main.tile[num56, num57].type == 0x39))))) || ((((Main.tile[num56, num57].type == 0x3b) || (Main.tile[num56, num57].type == 60)) || ((Main.tile[num56, num57].type == 0x3f) || (Main.tile[num56, num57].type == 0x40))) || ((((Main.tile[num56, num57].type == 0x41) || (Main.tile[num56, num57].type == 0x42)) || ((Main.tile[num56, num57].type == 0x43) || (Main.tile[num56, num57].type == 0x44))) || ((Main.tile[num56, num57].type == 70) || (Main.tile[num56, num57].type == 0x25)))))
                                            {
                                                flag2 = true;
                                            }
                                        }
                                        else if (this.type == 0x1d)
                                        {
                                            flag2 = true;
                                        }
                                        if ((Main.tileDungeon[Main.tile[num56, num57].type] || (Main.tile[num56, num57].type == 0x1a)) || ((Main.tile[num56, num57].type == 0x3a) || (Main.tile[num56, num57].type == 0x15)))
                                        {
                                            flag2 = false;
                                        }
                                        if (flag2)
                                        {
                                            WorldGen.KillTile(num56, num57, false, false, false);
                                            if (!Main.tile[num56, num57].active && (Main.netMode == 1))
                                            {
                                                NetMessage.SendData(0x11, -1, -1, "", 0, (float) num56, (float) num57, 0f, 0);
                                            }
                                        }
                                    }
                                    if ((flag2 && (Main.tile[num56, num57] != null)) && ((Main.tile[num56, num57].wall > 0) && flag))
                                    {
                                        WorldGen.KillWall(num56, num57, false);
                                        if ((Main.tile[num56, num57].wall == 0) && (Main.netMode == 1))
                                        {
                                            NetMessage.SendData(0x11, -1, -1, "", 2, (float) num56, (float) num57, 0f, 0);
                                        }
                                    }
                                }
                            }
                        }
                    }
                    if (Main.netMode != 0)
                    {
                        NetMessage.SendData(0x1d, -1, -1, "", this.identity, (float) this.owner, 0f, 0f, 0);
                    }
                    int number = -1;
                    if (this.aiStyle == 10)
                    {
                        int num62 = (((int) this.position.X) + (this.width / 2)) / 0x10;
                        int num63 = (((int) this.position.Y) + (this.width / 2)) / 0x10;
                        int type = 0;
                        int num65 = 2;
                        if (this.type == 0x1f)
                        {
                            type = 0x35;
                            num65 = 0;
                        }
                        if (this.type == 0x2a)
                        {
                            type = 0x35;
                            num65 = 0;
                        }
                        else if (this.type == 0x27)
                        {
                            type = 0x3b;
                            num65 = 0xb0;
                        }
                        else if (this.type == 40)
                        {
                            type = 0x39;
                            num65 = 0xac;
                        }
                        if (!Main.tile[num62, num63].active)
                        {
                            WorldGen.PlaceTile(num62, num63, type, false, true, -1, 0);
                            if (Main.tile[num62, num63].active && (Main.tile[num62, num63].type == type))
                            {
                                NetMessage.SendData(0x11, -1, -1, "", 1, (float) num62, (float) num63, (float) type, 0);
                            }
                            else if (num65 > 0)
                            {
                                number = Item.NewItem((int) this.position.X, (int) this.position.Y, this.width, this.height, num65, 1, false);
                            }
                        }
                        else if (num65 > 0)
                        {
                            number = Item.NewItem((int) this.position.X, (int) this.position.Y, this.width, this.height, num65, 1, false);
                        }
                    }
                    if ((this.type == 1) && (Main.rand.Next(2) == 0))
                    {
                        number = Item.NewItem((int) this.position.X, (int) this.position.Y, this.width, this.height, 40, 1, false);
                    }
                    if ((this.type == 2) && (Main.rand.Next(2) == 0))
                    {
                        if (Main.rand.Next(3) == 0)
                        {
                            number = Item.NewItem((int) this.position.X, (int) this.position.Y, this.width, this.height, 0x29, 1, false);
                        }
                        else
                        {
                            number = Item.NewItem((int) this.position.X, (int) this.position.Y, this.width, this.height, 40, 1, false);
                        }
                    }
                    if ((this.type == 50) && (Main.rand.Next(3) == 0))
                    {
                        number = Item.NewItem((int) this.position.X, (int) this.position.Y, this.width, this.height, 0x11a, 1, false);
                    }
                    if ((this.type == 0x35) && (Main.rand.Next(3) == 0))
                    {
                        number = Item.NewItem((int) this.position.X, (int) this.position.Y, this.width, this.height, 0x11e, 1, false);
                    }
                    if ((this.type == 0x30) && (Main.rand.Next(2) == 0))
                    {
                        number = Item.NewItem((int) this.position.X, (int) this.position.Y, this.width, this.height, 0x117, 1, false);
                    }
                    if ((this.type == 0x36) && (Main.rand.Next(2) == 0))
                    {
                        number = Item.NewItem((int) this.position.X, (int) this.position.Y, this.width, this.height, 0x11f, 1, false);
                    }
                    if ((this.type == 3) && (Main.rand.Next(2) == 0))
                    {
                        number = Item.NewItem((int) this.position.X, (int) this.position.Y, this.width, this.height, 0x2a, 1, false);
                    }
                    if ((this.type == 4) && (Main.rand.Next(2) == 0))
                    {
                        number = Item.NewItem((int) this.position.X, (int) this.position.Y, this.width, this.height, 0x2f, 1, false);
                    }
                    if ((this.type == 12) && (this.damage > 100))
                    {
                        number = Item.NewItem((int) this.position.X, (int) this.position.Y, this.width, this.height, 0x4b, 1, false);
                    }
                    if ((this.type == 0x15) && (Main.rand.Next(2) == 0))
                    {
                        number = Item.NewItem((int) this.position.X, (int) this.position.Y, this.width, this.height, 0x9a, 1, false);
                    }
                    if ((Main.netMode == 1) && (number >= 0))
                    {
                        NetMessage.SendData(0x15, -1, -1, "", number, 0f, 0f, 0f, 0);
                    }
                }
                this.active = false;
            }
        }

        public static int NewProjectile(float X, float Y, float SpeedX, float SpeedY, int Type, int Damage, float KnockBack, int Owner = 0xff)
        {
            int index = 0x3e8;
            for (int i = 0; i < 0x3e8; i++)
            {
                if (!Main.projectile[i].active)
                {
                    index = i;
                    break;
                }
            }
            if (index != 0x3e8)
            {
                Main.projectile[index].SetDefaults(Type);
                Main.projectile[index].position.X = X - (Main.projectile[index].width * 0.5f);
                Main.projectile[index].position.Y = Y - (Main.projectile[index].height * 0.5f);
                Main.projectile[index].owner = Owner;
                Main.projectile[index].velocity.X = SpeedX;
                Main.projectile[index].velocity.Y = SpeedY;
                Main.projectile[index].damage = Damage;
                Main.projectile[index].knockBack = KnockBack;
                Main.projectile[index].identity = index;
                Main.projectile[index].wet = Collision.WetCollision(Main.projectile[index].position, Main.projectile[index].width, Main.projectile[index].height);
                if ((Main.netMode != 0) && (Owner == Main.myPlayer))
                {
                    NetMessage.SendData(0x1b, -1, -1, "", index, 0f, 0f, 0f, 0);
                }
                if (Owner != Main.myPlayer)
                {
                    return index;
                }
                if (Type == 0x1c)
                {
                    Main.projectile[index].timeLeft = 180;
                }
                if (Type == 0x1d)
                {
                    Main.projectile[index].timeLeft = 300;
                }
                if (Type == 30)
                {
                    Main.projectile[index].timeLeft = 180;
                }
                if (Type == 0x25)
                {
                    Main.projectile[index].timeLeft = 180;
                }
            }
            return index;
        }

        public void SetDefaults(int Type)
        {
            for (int i = 0; i < maxAI; i++)
            {
                this.ai[i] = 0f;
            }
            for (int j = 0; j < 0xff; j++)
            {
                this.playerImmune[j] = 0;
            }
            this.melee = false;
            this.ranged = false;
            this.magic = false;
            this.ownerHitCheck = false;
            this.hide = false;
            this.lavaWet = false;
            this.wetCount = 0;
            this.wet = false;
            this.ignoreWater = false;
            this.hostile = false;
            this.netUpdate = false;
            this.numUpdates = 0;
            this.maxUpdates = 0;
            this.identity = 0;
            this.restrikeDelay = 0;
            this.light = 0f;
            this.penetrate = 1;
            this.tileCollide = true;
            this.position = new Vector2();
            this.velocity = new Vector2();
            this.aiStyle = 0;
            this.alpha = 0;
            this.type = Type;
            this.active = true;
            this.rotation = 0f;
            this.scale = 1f;
            this.owner = 0xff;
            this.timeLeft = 0xe10;
            this.name = "";
            this.friendly = false;
            this.damage = 0;
            this.knockBack = 0f;
            this.miscText = "";
            if (this.type == 1)
            {
                this.name = "Wooden Arrow";
                this.width = 10;
                this.height = 10;
                this.aiStyle = 1;
                this.friendly = true;
                this.ranged = true;
            }
            else if (this.type == 2)
            {
                this.name = "Fire Arrow";
                this.width = 10;
                this.height = 10;
                this.aiStyle = 1;
                this.friendly = true;
                this.light = 1f;
                this.ranged = true;
            }
            else if (this.type == 3)
            {
                this.name = "Shuriken";
                this.width = 0x16;
                this.height = 0x16;
                this.aiStyle = 2;
                this.friendly = true;
                this.penetrate = 4;
                this.ranged = true;
            }
            else if (this.type == 4)
            {
                this.name = "Unholy Arrow";
                this.width = 10;
                this.height = 10;
                this.aiStyle = 1;
                this.friendly = true;
                this.light = 0.2f;
                this.penetrate = 5;
                this.ranged = true;
            }
            else if (this.type == 5)
            {
                this.name = "Jester's Arrow";
                this.width = 10;
                this.height = 10;
                this.aiStyle = 1;
                this.friendly = true;
                this.light = 0.4f;
                this.penetrate = -1;
                this.timeLeft = 40;
                this.alpha = 100;
                this.ignoreWater = true;
                this.ranged = true;
            }
            else if (this.type == 6)
            {
                this.name = "Enchanted Boomerang";
                this.width = 0x16;
                this.height = 0x16;
                this.aiStyle = 3;
                this.friendly = true;
                this.penetrate = -1;
                this.ranged = true;
            }
            else if ((this.type == 7) || (this.type == 8))
            {
                this.name = "Vilethorn";
                this.width = 0x1c;
                this.height = 0x1c;
                this.aiStyle = 4;
                this.friendly = true;
                this.penetrate = -1;
                this.tileCollide = false;
                this.alpha = 0xff;
                this.ignoreWater = true;
                this.magic = true;
            }
            else if (this.type == 9)
            {
                this.name = "Starfury";
                this.width = 0x18;
                this.height = 0x18;
                this.aiStyle = 5;
                this.friendly = true;
                this.penetrate = 2;
                this.alpha = 50;
                this.scale = 0.8f;
                this.tileCollide = false;
                this.magic = true;
            }
            else if (this.type == 10)
            {
                this.name = "Purification Powder";
                this.width = 0x40;
                this.height = 0x40;
                this.aiStyle = 6;
                this.friendly = true;
                this.tileCollide = false;
                this.penetrate = -1;
                this.alpha = 0xff;
                this.ignoreWater = true;
            }
            else if (this.type == 11)
            {
                this.name = "Vile Powder";
                this.width = 0x30;
                this.height = 0x30;
                this.aiStyle = 6;
                this.friendly = true;
                this.tileCollide = false;
                this.penetrate = -1;
                this.alpha = 0xff;
                this.ignoreWater = true;
            }
            else if (this.type == 12)
            {
                this.name = "Fallen Star";
                this.width = 0x10;
                this.height = 0x10;
                this.aiStyle = 5;
                this.friendly = true;
                this.penetrate = -1;
                this.alpha = 50;
                this.light = 1f;
            }
            else if (this.type == 13)
            {
                this.name = "Hook";
                this.width = 0x12;
                this.height = 0x12;
                this.aiStyle = 7;
                this.friendly = true;
                this.penetrate = -1;
                this.tileCollide = false;
                this.timeLeft *= 10;
            }
            else if (this.type == 14)
            {
                this.name = "Musket Ball";
                this.width = 4;
                this.height = 4;
                this.aiStyle = 1;
                this.friendly = true;
                this.penetrate = 1;
                this.light = 0.5f;
                this.alpha = 0xff;
                this.maxUpdates = 1;
                this.scale = 1.2f;
                this.timeLeft = 600;
                this.ranged = true;
            }
            else if (this.type == 15)
            {
                this.name = "Ball of Fire";
                this.width = 0x10;
                this.height = 0x10;
                this.aiStyle = 8;
                this.friendly = true;
                this.light = 0.8f;
                this.alpha = 100;
                this.magic = true;
            }
            else if (this.type == 0x10)
            {
                this.name = "Magic Missile";
                this.width = 10;
                this.height = 10;
                this.aiStyle = 9;
                this.friendly = true;
                this.light = 0.8f;
                this.alpha = 100;
                this.magic = true;
            }
            else if (this.type == 0x11)
            {
                this.name = "Dirt Ball";
                this.width = 10;
                this.height = 10;
                this.aiStyle = 10;
                this.friendly = true;
            }
            else if (this.type == 0x12)
            {
                this.name = "Orb of Light";
                this.width = 0x20;
                this.height = 0x20;
                this.aiStyle = 11;
                this.friendly = true;
                this.light = 0.65f;
                this.alpha = 150;
                this.tileCollide = false;
                this.penetrate = -1;
                this.timeLeft *= 5;
                this.ignoreWater = true;
            }
            else if (this.type == 0x13)
            {
                this.name = "Flamarang";
                this.width = 0x16;
                this.height = 0x16;
                this.aiStyle = 3;
                this.friendly = true;
                this.penetrate = -1;
                this.light = 1f;
                this.ranged = true;
            }
            else if (this.type == 20)
            {
                this.name = "Green Laser";
                this.width = 4;
                this.height = 4;
                this.aiStyle = 1;
                this.friendly = true;
                this.penetrate = 3;
                this.light = 0.75f;
                this.alpha = 0xff;
                this.maxUpdates = 2;
                this.scale = 1.4f;
                this.timeLeft = 600;
                this.magic = true;
            }
            else if (this.type == 0x15)
            {
                this.name = "Bone";
                this.width = 0x10;
                this.height = 0x10;
                this.aiStyle = 2;
                this.scale = 1.2f;
                this.friendly = true;
                this.ranged = true;
            }
            else if (this.type == 0x16)
            {
                this.name = "Water Stream";
                this.width = 0x12;
                this.height = 0x12;
                this.aiStyle = 12;
                this.friendly = true;
                this.alpha = 0xff;
                this.penetrate = -1;
                this.maxUpdates = 2;
                this.ignoreWater = true;
                this.magic = true;
            }
            else if (this.type == 0x17)
            {
                this.name = "Harpoon";
                this.width = 4;
                this.height = 4;
                this.aiStyle = 13;
                this.friendly = true;
                this.penetrate = -1;
                this.alpha = 0xff;
                this.ranged = true;
            }
            else if (this.type == 0x18)
            {
                this.name = "Spiky Ball";
                this.width = 14;
                this.height = 14;
                this.aiStyle = 14;
                this.friendly = true;
                this.penetrate = 6;
                this.ranged = true;
            }
            else if (this.type == 0x19)
            {
                this.name = "Ball 'O Hurt";
                this.width = 0x16;
                this.height = 0x16;
                this.aiStyle = 15;
                this.friendly = true;
                this.penetrate = -1;
                this.melee = true;
                this.scale = 0.8f;
            }
            else if (this.type == 0x1a)
            {
                this.name = "Blue Moon";
                this.width = 0x16;
                this.height = 0x16;
                this.aiStyle = 15;
                this.friendly = true;
                this.penetrate = -1;
                this.melee = true;
                this.scale = 0.8f;
            }
            else if (this.type == 0x1b)
            {
                this.name = "Water Bolt";
                this.width = 0x10;
                this.height = 0x10;
                this.aiStyle = 8;
                this.friendly = true;
                this.light = 0.8f;
                this.alpha = 200;
                this.timeLeft /= 2;
                this.penetrate = 10;
                this.magic = true;
            }
            else if (this.type == 0x1c)
            {
                this.name = "Bomb";
                this.width = 0x16;
                this.height = 0x16;
                this.aiStyle = 0x10;
                this.friendly = true;
                this.penetrate = -1;
            }
            else if (this.type == 0x1d)
            {
                this.name = "Dynamite";
                this.width = 10;
                this.height = 10;
                this.aiStyle = 0x10;
                this.friendly = true;
                this.penetrate = -1;
            }
            else if (this.type == 30)
            {
                this.name = "Grenade";
                this.width = 14;
                this.height = 14;
                this.aiStyle = 0x10;
                this.friendly = true;
                this.penetrate = -1;
                this.ranged = true;
            }
            else if (this.type == 0x1f)
            {
                this.name = "Sand Ball";
                this.knockBack = 6f;
                this.width = 10;
                this.height = 10;
                this.aiStyle = 10;
                this.friendly = true;
                this.hostile = true;
                this.penetrate = -1;
            }
            else if (this.type == 0x20)
            {
                this.name = "Ivy Whip";
                this.width = 0x12;
                this.height = 0x12;
                this.aiStyle = 7;
                this.friendly = true;
                this.penetrate = -1;
                this.tileCollide = false;
                this.timeLeft *= 10;
            }
            else if (this.type == 0x21)
            {
                this.name = "Thorn Chakrum";
                this.width = 0x1c;
                this.height = 0x1c;
                this.aiStyle = 3;
                this.friendly = true;
                this.scale = 0.9f;
                this.penetrate = -1;
                this.ranged = true;
            }
            else if (this.type == 0x22)
            {
                this.name = "Flamelash";
                this.width = 14;
                this.height = 14;
                this.aiStyle = 9;
                this.friendly = true;
                this.light = 0.8f;
                this.alpha = 100;
                this.penetrate = 1;
                this.magic = true;
            }
            else if (this.type == 0x23)
            {
                this.name = "Sunfury";
                this.width = 0x16;
                this.height = 0x16;
                this.aiStyle = 15;
                this.friendly = true;
                this.penetrate = -1;
                this.melee = true;
                this.scale = 0.8f;
            }
            else if (this.type == 0x24)
            {
                this.name = "Meteor Shot";
                this.width = 4;
                this.height = 4;
                this.aiStyle = 1;
                this.friendly = true;
                this.penetrate = 2;
                this.light = 0.6f;
                this.alpha = 0xff;
                this.maxUpdates = 1;
                this.scale = 1.4f;
                this.timeLeft = 600;
                this.ranged = true;
            }
            else if (this.type == 0x25)
            {
                this.name = "Sticky Bomb";
                this.width = 0x16;
                this.height = 0x16;
                this.aiStyle = 0x10;
                this.friendly = true;
                this.penetrate = -1;
                this.tileCollide = false;
            }
            else if (this.type == 0x26)
            {
                this.name = "Harpy Feather";
                this.width = 14;
                this.height = 14;
                this.aiStyle = 0;
                this.hostile = true;
                this.penetrate = -1;
                this.aiStyle = 1;
                this.tileCollide = true;
            }
            else if (this.type == 0x27)
            {
                this.name = "Mud Ball";
                this.knockBack = 6f;
                this.width = 10;
                this.height = 10;
                this.aiStyle = 10;
                this.friendly = true;
                this.hostile = true;
                this.penetrate = -1;
            }
            else if (this.type == 40)
            {
                this.name = "Ash Ball";
                this.knockBack = 6f;
                this.width = 10;
                this.height = 10;
                this.aiStyle = 10;
                this.friendly = true;
                this.hostile = true;
                this.penetrate = -1;
            }
            else if (this.type == 0x29)
            {
                this.name = "Hellfire Arrow";
                this.width = 10;
                this.height = 10;
                this.aiStyle = 1;
                this.friendly = true;
                this.penetrate = -1;
                this.ranged = true;
            }
            else if (this.type == 0x2a)
            {
                this.name = "Sand Ball";
                this.knockBack = 8f;
                this.width = 10;
                this.height = 10;
                this.aiStyle = 10;
                this.friendly = true;
                this.maxUpdates = 0;
            }
            else if (this.type == 0x2b)
            {
                this.name = "Tombstone";
                this.knockBack = 12f;
                this.width = 0x18;
                this.height = 0x18;
                this.aiStyle = 0x11;
                this.penetrate = -1;
                this.friendly = true;
            }
            else if (this.type == 0x2c)
            {
                this.name = "Demon Sickle";
                this.width = 0x30;
                this.height = 0x30;
                this.alpha = 100;
                this.light = 0.2f;
                this.aiStyle = 0x12;
                this.hostile = true;
                this.penetrate = -1;
                this.tileCollide = true;
                this.scale = 0.9f;
            }
            else if (this.type == 0x2d)
            {
                this.name = "Demon Scythe";
                this.width = 0x30;
                this.height = 0x30;
                this.alpha = 100;
                this.light = 0.2f;
                this.aiStyle = 0x12;
                this.friendly = true;
                this.penetrate = 5;
                this.tileCollide = true;
                this.scale = 0.9f;
                this.magic = true;
            }
            else if (this.type == 0x2e)
            {
                this.name = "Dark Lance";
                this.width = 20;
                this.height = 20;
                this.aiStyle = 0x13;
                this.friendly = true;
                this.penetrate = -1;
                this.tileCollide = false;
                this.scale = 1.1f;
                this.hide = true;
                this.ownerHitCheck = true;
                this.melee = true;
            }
            else if (this.type == 0x2f)
            {
                this.name = "Trident";
                this.width = 0x12;
                this.height = 0x12;
                this.aiStyle = 0x13;
                this.friendly = true;
                this.penetrate = -1;
                this.tileCollide = false;
                this.scale = 1.1f;
                this.hide = true;
                this.ownerHitCheck = true;
                this.melee = true;
            }
            else if (this.type == 0x30)
            {
                this.name = "Throwing Knife";
                this.width = 12;
                this.height = 12;
                this.aiStyle = 2;
                this.friendly = true;
                this.penetrate = 2;
                this.ranged = true;
            }
            else if (this.type == 0x31)
            {
                this.name = "Spear";
                this.width = 0x12;
                this.height = 0x12;
                this.aiStyle = 0x13;
                this.friendly = true;
                this.penetrate = -1;
                this.tileCollide = false;
                this.scale = 1.2f;
                this.hide = true;
                this.ownerHitCheck = true;
                this.melee = true;
            }
            else if (this.type == 50)
            {
                this.name = "Glowstick";
                this.width = 6;
                this.height = 6;
                this.aiStyle = 14;
                this.penetrate = -1;
                this.alpha = 0x4b;
                this.light = 1f;
                this.timeLeft *= 5;
            }
            else if (this.type == 0x33)
            {
                this.name = "Seed";
                this.width = 8;
                this.height = 8;
                this.aiStyle = 1;
                this.friendly = true;
            }
            else if (this.type == 0x34)
            {
                this.name = "Wooden Boomerang";
                this.width = 0x16;
                this.height = 0x16;
                this.aiStyle = 3;
                this.friendly = true;
                this.penetrate = -1;
                this.ranged = true;
            }
            else if (this.type == 0x35)
            {
                this.name = "Sticky Glowstick";
                this.width = 6;
                this.height = 6;
                this.aiStyle = 14;
                this.penetrate = -1;
                this.alpha = 0x4b;
                this.light = 1f;
                this.timeLeft *= 5;
                this.tileCollide = false;
            }
            else if (this.type == 0x36)
            {
                this.name = "Poisoned Knife";
                this.width = 12;
                this.height = 12;
                this.aiStyle = 2;
                this.friendly = true;
                this.penetrate = 2;
                this.ranged = true;
            }
            else if (this.type == 0x37)
            {
                this.name = "Stinger";
                this.width = 10;
                this.height = 10;
                this.aiStyle = 0;
                this.hostile = true;
                this.penetrate = -1;
                this.aiStyle = 1;
                this.tileCollide = true;
            }
            else
            {
                this.active = false;
            }
            this.width = (int) (this.width * this.scale);
            this.height = (int) (this.height * this.scale);
        }

        public void StatusNPC(int i)
        {
            if (this.type == 2)
            {
                if (Main.rand.Next(3) == 0)
                {
                    Main.npc[i].AddBuff(0x18, 180, false);
                }
            }
            else if (this.type == 15)
            {
                if (Main.rand.Next(2) == 0)
                {
                    Main.npc[i].AddBuff(0x18, 300, false);
                }
            }
            else if (this.type == 0x13)
            {
                if (Main.rand.Next(5) == 0)
                {
                    Main.npc[i].AddBuff(0x18, 180, false);
                }
            }
            else if (this.type == 0x21)
            {
                if (Main.rand.Next(5) == 0)
                {
                    Main.npc[i].AddBuff(20, 420, false);
                }
            }
            else if (this.type == 0x22)
            {
                if (Main.rand.Next(2) == 0)
                {
                    Main.npc[i].AddBuff(0x18, 240, false);
                }
            }
            else if (this.type == 0x23)
            {
                if (Main.rand.Next(4) == 0)
                {
                    Main.npc[i].AddBuff(0x18, 180, false);
                }
            }
            else if ((this.type == 0x36) && (Main.rand.Next(2) == 0))
            {
                Main.npc[i].AddBuff(20, 600, false);
            }
        }

        public void StatusPlayer(int i)
        {
            if ((this.type == 0x37) && (Main.rand.Next(3) == 0))
            {
                Main.player[i].AddBuff(20, 600, true);
            }
            if ((this.type == 0x2c) && (Main.rand.Next(3) == 0))
            {
                Main.player[i].AddBuff(0x16, 900, true);
            }
        }

        public void StatusPvP(int i)
        {
            if (this.type == 2)
            {
                if (Main.rand.Next(3) == 0)
                {
                    Main.player[i].AddBuff(0x18, 180, false);
                }
            }
            else if (this.type == 15)
            {
                if (Main.rand.Next(2) == 0)
                {
                    Main.player[i].AddBuff(0x18, 300, false);
                }
            }
            else if (this.type == 0x13)
            {
                if (Main.rand.Next(5) == 0)
                {
                    Main.player[i].AddBuff(0x18, 180, false);
                }
            }
            else if (this.type == 0x21)
            {
                if (Main.rand.Next(5) == 0)
                {
                    Main.player[i].AddBuff(20, 420, false);
                }
            }
            else if (this.type == 0x22)
            {
                if (Main.rand.Next(2) == 0)
                {
                    Main.player[i].AddBuff(0x18, 240, false);
                }
            }
            else if (this.type == 0x23)
            {
                if (Main.rand.Next(4) == 0)
                {
                    Main.player[i].AddBuff(0x18, 180, false);
                }
            }
            else if ((this.type == 0x36) && (Main.rand.Next(2) == 0))
            {
                Main.player[i].AddBuff(20, 600, false);
            }
        }

        public void Update(int i)
        {
            if (this.active)
            {
                Vector2 velocity = this.velocity;
                if (((this.position.X <= Main.leftWorld) || ((this.position.X + this.width) >= Main.rightWorld)) || ((this.position.Y <= Main.topWorld) || ((this.position.Y + this.height) >= Main.bottomWorld)))
                {
                    this.active = false;
                }
                else
                {
                    this.whoAmI = i;
                    if (this.soundDelay > 0)
                    {
                        this.soundDelay--;
                    }
                    this.netUpdate = false;
                    for (int j = 0; j < 0xff; j++)
                    {
                        if (this.playerImmune[j] > 0)
                        {
                            this.playerImmune[j]--;
                        }
                    }
                    this.AI();
                    if ((this.owner < 0xff) && !Main.player[this.owner].active)
                    {
                        this.Kill();
                    }
                    if (!this.ignoreWater)
                    {
                        bool flag;
                        bool flag2;
                        try
                        {
                            flag = Collision.LavaCollision(this.position, this.width, this.height);
                            flag2 = Collision.WetCollision(this.position, this.width, this.height);
                            if (flag)
                            {
                                this.lavaWet = true;
                            }
                        }
                        catch
                        {
                            this.active = false;
                            return;
                        }
                        if (flag2)
                        {
                            if (this.wetCount == 0)
                            {
                                this.wetCount = 10;
                                if (!this.wet)
                                {
                                    if (!flag)
                                    {
                                        for (int k = 0; k < 10; k++)
                                        {
                                            Color newColor = new Color();
                                            int index = Dust.NewDust(new Vector2(this.position.X - 6f, (this.position.Y + (this.height / 2)) - 8f), this.width + 12, 0x18, 0x21, 0f, 0f, 0, newColor, 1f);
                                            Main.dust[index].velocity.Y -= 4f;
                                            Main.dust[index].velocity.X *= 2.5f;
                                            Main.dust[index].scale = 1.3f;
                                            Main.dust[index].alpha = 100;
                                            Main.dust[index].noGravity = true;
                                        }
                                        Main.PlaySound(0x13, (int) this.position.X, (int) this.position.Y, 1);
                                    }
                                    else
                                    {
                                        for (int m = 0; m < 10; m++)
                                        {
                                            Color color2 = new Color();
                                            int num5 = Dust.NewDust(new Vector2(this.position.X - 6f, (this.position.Y + (this.height / 2)) - 8f), this.width + 12, 0x18, 0x23, 0f, 0f, 0, color2, 1f);
                                            Main.dust[num5].velocity.Y -= 1.5f;
                                            Main.dust[num5].velocity.X *= 2.5f;
                                            Main.dust[num5].scale = 1.3f;
                                            Main.dust[num5].alpha = 100;
                                            Main.dust[num5].noGravity = true;
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
                            if (this.wetCount == 0)
                            {
                                this.wetCount = 10;
                                if (!this.lavaWet)
                                {
                                    for (int n = 0; n < 10; n++)
                                    {
                                        Color color3 = new Color();
                                        int num7 = Dust.NewDust(new Vector2(this.position.X - 6f, this.position.Y + (this.height / 2)), this.width + 12, 0x18, 0x21, 0f, 0f, 0, color3, 1f);
                                        Main.dust[num7].velocity.Y -= 4f;
                                        Main.dust[num7].velocity.X *= 2.5f;
                                        Main.dust[num7].scale = 1.3f;
                                        Main.dust[num7].alpha = 100;
                                        Main.dust[num7].noGravity = true;
                                    }
                                    Main.PlaySound(0x13, (int) this.position.X, (int) this.position.Y, 1);
                                }
                                else
                                {
                                    for (int num8 = 0; num8 < 10; num8++)
                                    {
                                        Color color4 = new Color();
                                        int num9 = Dust.NewDust(new Vector2(this.position.X - 6f, (this.position.Y + (this.height / 2)) - 8f), this.width + 12, 0x18, 0x23, 0f, 0f, 0, color4, 1f);
                                        Main.dust[num9].velocity.Y -= 1.5f;
                                        Main.dust[num9].velocity.X *= 2.5f;
                                        Main.dust[num9].scale = 1.3f;
                                        Main.dust[num9].alpha = 100;
                                        Main.dust[num9].noGravity = true;
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
                    }
                    if (this.tileCollide)
                    {
                        Vector2 vector2 = this.velocity;
                        bool fallThrough = true;
                        if ((((this.type == 9) || (this.type == 12)) || ((this.type == 15) || (this.type == 13))) || (((this.type == 0x1f) || (this.type == 0x27)) || (this.type == 40)))
                        {
                            fallThrough = false;
                        }
                        if (this.aiStyle == 10)
                        {
                            if ((this.type == 0x2a) || ((this.type == 0x1f) && (this.ai[0] == 2f)))
                            {
                                this.velocity = Collision.TileCollision(this.position, this.velocity, this.width, this.height, fallThrough, fallThrough);
                            }
                            else
                            {
                                this.velocity = Collision.AnyCollision(this.position, this.velocity, this.width, this.height);
                            }
                        }
                        else if (this.aiStyle == 0x12)
                        {
                            int width = this.width - 0x24;
                            int height = this.height - 0x24;
                            Vector2 position = new Vector2((this.position.X + (this.width / 2)) - (width / 2), (this.position.Y + (this.height / 2)) - (height / 2));
                            this.velocity = Collision.TileCollision(position, this.velocity, width, height, fallThrough, fallThrough);
                        }
                        else if (this.wet)
                        {
                            Vector2 vector4 = this.velocity;
                            this.velocity = Collision.TileCollision(this.position, this.velocity, this.width, this.height, fallThrough, fallThrough);
                            velocity = (Vector2) (this.velocity * 0.5f);
                            if (this.velocity.X != vector4.X)
                            {
                                velocity.X = this.velocity.X;
                            }
                            if (this.velocity.Y != vector4.Y)
                            {
                                velocity.Y = this.velocity.Y;
                            }
                        }
                        else
                        {
                            this.velocity = Collision.TileCollision(this.position, this.velocity, this.width, this.height, fallThrough, fallThrough);
                        }
                        if (vector2 != this.velocity)
                        {
                            if (this.type == 0x24)
                            {
                                if (this.penetrate > 1)
                                {
                                    Collision.HitTiles(this.position, this.velocity, this.width, this.height);
                                    Main.PlaySound(2, (int) this.position.X, (int) this.position.Y, 10);
                                    this.penetrate--;
                                    if (this.velocity.X != vector2.X)
                                    {
                                        this.velocity.X = -vector2.X;
                                    }
                                    if (this.velocity.Y != vector2.Y)
                                    {
                                        this.velocity.Y = -vector2.Y;
                                    }
                                }
                                else
                                {
                                    this.Kill();
                                }
                            }
                            else if (this.aiStyle == 0x11)
                            {
                                if (this.velocity.X != vector2.X)
                                {
                                    this.velocity.X = vector2.X * -0.75f;
                                }
                                if ((this.velocity.Y != vector2.Y) && (vector2.Y > 1.5))
                                {
                                    this.velocity.Y = vector2.Y * -0.7f;
                                }
                            }
                            else if (this.aiStyle == 15)
                            {
                                bool flag4 = false;
                                if (vector2.X != this.velocity.X)
                                {
                                    if (Math.Abs(vector2.X) > 4f)
                                    {
                                        flag4 = true;
                                    }
                                    this.position.X += this.velocity.X;
                                    this.velocity.X = -vector2.X * 0.2f;
                                }
                                if (vector2.Y != this.velocity.Y)
                                {
                                    if (Math.Abs(vector2.Y) > 4f)
                                    {
                                        flag4 = true;
                                    }
                                    this.position.Y += this.velocity.Y;
                                    this.velocity.Y = -vector2.Y * 0.2f;
                                }
                                this.ai[0] = 1f;
                                if (flag4)
                                {
                                    this.netUpdate = true;
                                    Collision.HitTiles(this.position, this.velocity, this.width, this.height);
                                    Main.PlaySound(0, (int) this.position.X, (int) this.position.Y, 1);
                                }
                            }
                            else if ((this.aiStyle == 3) || (this.aiStyle == 13))
                            {
                                Collision.HitTiles(this.position, this.velocity, this.width, this.height);
                                if (this.type == 0x21)
                                {
                                    if (this.velocity.X != vector2.X)
                                    {
                                        this.velocity.X = -vector2.X;
                                    }
                                    if (this.velocity.Y != vector2.Y)
                                    {
                                        this.velocity.Y = -vector2.Y;
                                    }
                                }
                                else
                                {
                                    this.ai[0] = 1f;
                                    if (this.aiStyle == 3)
                                    {
                                        this.velocity.X = -vector2.X;
                                        this.velocity.Y = -vector2.Y;
                                    }
                                }
                                this.netUpdate = true;
                                Main.PlaySound(0, (int) this.position.X, (int) this.position.Y, 1);
                            }
                            else if (this.aiStyle == 8)
                            {
                                Main.PlaySound(2, (int) this.position.X, (int) this.position.Y, 10);
                                this.ai[0]++;
                                if (this.ai[0] >= 5f)
                                {
                                    this.position += this.velocity;
                                    this.Kill();
                                }
                                else
                                {
                                    if ((this.type == 15) && (this.velocity.Y > 4f))
                                    {
                                        if (this.velocity.Y != vector2.Y)
                                        {
                                            this.velocity.Y = -vector2.Y * 0.8f;
                                        }
                                    }
                                    else if (this.velocity.Y != vector2.Y)
                                    {
                                        this.velocity.Y = -vector2.Y;
                                    }
                                    if (this.velocity.X != vector2.X)
                                    {
                                        this.velocity.X = -vector2.X;
                                    }
                                }
                            }
                            else if (this.aiStyle == 14)
                            {
                                if (this.type == 50)
                                {
                                    if (this.velocity.X != vector2.X)
                                    {
                                        this.velocity.X = vector2.X * -0.2f;
                                    }
                                    if ((this.velocity.Y != vector2.Y) && (vector2.Y > 1.5))
                                    {
                                        this.velocity.Y = vector2.Y * -0.2f;
                                    }
                                }
                                else
                                {
                                    if (this.velocity.X != vector2.X)
                                    {
                                        this.velocity.X = vector2.X * -0.5f;
                                    }
                                    if ((this.velocity.Y != vector2.Y) && (vector2.Y > 1f))
                                    {
                                        this.velocity.Y = vector2.Y * -0.5f;
                                    }
                                }
                            }
                            else if (this.aiStyle == 0x10)
                            {
                                if (this.velocity.X != vector2.X)
                                {
                                    this.velocity.X = vector2.X * -0.4f;
                                    if (this.type == 0x1d)
                                    {
                                        this.velocity.X *= 0.8f;
                                    }
                                }
                                if ((this.velocity.Y != vector2.Y) && (vector2.Y > 0.7))
                                {
                                    this.velocity.Y = vector2.Y * -0.4f;
                                    if (this.type == 0x1d)
                                    {
                                        this.velocity.Y *= 0.8f;
                                    }
                                }
                            }
                            else
                            {
                                this.position += this.velocity;
                                this.Kill();
                            }
                        }
                    }
                    if ((this.type != 7) && (this.type != 8))
                    {
                        if (this.wet)
                        {
                            this.position += velocity;
                        }
                        else
                        {
                            this.position += this.velocity;
                        }
                    }
                    if (((((this.aiStyle != 3) || (this.ai[0] != 1f)) && ((this.aiStyle != 7) || (this.ai[0] != 1f))) && (((this.aiStyle != 13) || (this.ai[0] != 1f)) && ((this.aiStyle != 15) || (this.ai[0] != 1f)))) && (this.aiStyle != 15))
                    {
                        if (this.velocity.X < 0f)
                        {
                            this.direction = -1;
                        }
                        else
                        {
                            this.direction = 1;
                        }
                    }
                    if (this.active)
                    {
                        if (this.light > 0f)
                        {
                            Lighting.addLight((int) ((this.position.X + (this.width / 2)) / 16f), (int) ((this.position.Y + (this.height / 2)) / 16f), this.light);
                        }
                        if (this.type == 2)
                        {
                            Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 6, 0f, 0f, 100, new Color(), 1f);
                        }
                        else if (this.type == 4)
                        {
                            if (Main.rand.Next(5) == 0)
                            {
                                Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 14, 0f, 0f, 150, new Color(), 1.1f);
                            }
                        }
                        else if (this.type == 5)
                        {
                            Dust.NewDust(this.position, this.width, this.height, 15, this.velocity.X * 0.5f, this.velocity.Y * 0.5f, 150, new Color(), 1.2f);
                        }
                        this.Damage();
                        this.timeLeft--;
                        if (this.timeLeft <= 0)
                        {
                            this.Kill();
                        }
                        if (this.penetrate == 0)
                        {
                            this.Kill();
                        }
                        if ((this.active && this.netUpdate) && (this.owner == Main.myPlayer))
                        {
                            NetMessage.SendData(0x1b, -1, -1, "", i, 0f, 0f, 0f, 0);
                        }
                        if (this.active && (this.maxUpdates > 0))
                        {
                            this.numUpdates--;
                            if (this.numUpdates >= 0)
                            {
                                this.Update(i);
                            }
                            else
                            {
                                this.numUpdates = this.maxUpdates;
                            }
                        }
                        this.netUpdate = false;
                    }
                }
            }
        }
    }
}

