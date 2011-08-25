namespace Toaria
{
    using Microsoft.Xna.Framework;
    using System;
    using System.Runtime.InteropServices;

    public class Dust
    {
        public bool active;
        public int alpha;
        public Color color;
        public float fadeIn;
        public Rectangle frame;
        public static int lavaBubbles;
        public bool noGravity;
        public bool noLight;
        public Vector2 position;
        public float rotation;
        public float scale;
        public int type;
        public Vector2 velocity;

        public Color GetAlpha(Color newColor)
        {
            int num;
            int num2;
            int num3;
            if ((((this.type == 15) || (this.type == 20)) || ((this.type == 0x15) || (this.type == 0x1d))) || (((this.type == 0x23) || (this.type == 0x29)) || (((this.type == 0x2c) || (this.type == 0x1b)) || (this.type == 0x2d))))
            {
                num = newColor.R - (this.alpha / 3);
                num2 = newColor.G - (this.alpha / 3);
                num3 = newColor.B - (this.alpha / 3);
            }
            else if (this.type == 0x2b)
            {
                num = newColor.R - (this.alpha / 10);
                num2 = newColor.G - (this.alpha / 10);
                num3 = newColor.B - (this.alpha / 10);
            }
            else
            {
                num = newColor.R - this.alpha;
                num2 = newColor.G - this.alpha;
                num3 = newColor.B - this.alpha;
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
            return new Color(num, num2, num3, a);
        }

        public Color GetColor(Color newColor)
        {
            int r = this.color.R - (0xff - newColor.R);
            int g = this.color.G - (0xff - newColor.G);
            int b = this.color.B - (0xff - newColor.B);
            int a = this.color.A - (0xff - newColor.A);
            if (r < 0)
            {
                r = 0;
            }
            if (r > 0xff)
            {
                r = 0xff;
            }
            if (g < 0)
            {
                g = 0;
            }
            if (g > 0xff)
            {
                g = 0xff;
            }
            if (b < 0)
            {
                b = 0;
            }
            if (b > 0xff)
            {
                b = 0xff;
            }
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

        public static int NewDust(Vector2 Position, int Width, int Height, int Type, float SpeedX = 0f, float SpeedY = 0f, int Alpha = 0, Color newColor = new Color(), float Scale = 1f)
        {
            if (Main.gamePaused)
            {
                return 0;
            }
            if (WorldGen.gen)
            {
                return 0;
            }
            if (Main.netMode == 2)
            {
                return 0;
            }
            Rectangle rectangle = new Rectangle((int) ((Main.player[Main.myPlayer].position.X - (Main.screenWidth / 2)) - 100f), (int) ((Main.player[Main.myPlayer].position.Y - (Main.screenHeight / 2)) - 100f), Main.screenWidth + 200, Main.screenHeight + 200);
            Rectangle rectangle2 = new Rectangle((int) Position.X, (int) Position.Y, 10, 10);
            if (!rectangle.Intersects(rectangle2))
            {
                return 0x3e8;
            }
            int num = 0x3e8;
            for (int i = 0; i < 0x3e8; i++)
            {
                if (!Main.dust[i].active)
                {
                    int num3 = Width;
                    int num4 = Height;
                    if (num3 < 5)
                    {
                        num3 = 5;
                    }
                    if (num4 < 5)
                    {
                        num4 = 5;
                    }
                    num = i;
                    Main.dust[i].fadeIn = 0f;
                    Main.dust[i].active = true;
                    Main.dust[i].type = Type;
                    Main.dust[i].noGravity = false;
                    Main.dust[i].color = newColor;
                    Main.dust[i].alpha = Alpha;
                    Main.dust[i].position.X = (Position.X + Main.rand.Next(num3 - 4)) + 4f;
                    Main.dust[i].position.Y = (Position.Y + Main.rand.Next(num4 - 4)) + 4f;
                    Main.dust[i].velocity.X = (Main.rand.Next(-20, 0x15) * 0.1f) + SpeedX;
                    Main.dust[i].velocity.Y = (Main.rand.Next(-20, 0x15) * 0.1f) + SpeedY;
                    Main.dust[i].frame.X = 10 * Type;
                    Main.dust[i].frame.Y = 10 * Main.rand.Next(3);
                    Main.dust[i].frame.Width = 8;
                    Main.dust[i].frame.Height = 8;
                    Main.dust[i].rotation = 0f;
                    Main.dust[i].scale = 1f + (Main.rand.Next(-20, 0x15) * 0.01f);
                    Dust dust1 = Main.dust[i];
                    dust1.scale *= Scale;
                    Main.dust[i].noLight = false;
                    if ((Main.dust[i].type == 6) || (Main.dust[i].type == 0x1d))
                    {
                        Main.dust[i].velocity.Y = Main.rand.Next(-10, 6) * 0.1f;
                        Main.dust[i].velocity.X *= 0.3f;
                        Dust dust2 = Main.dust[i];
                        dust2.scale *= 0.7f;
                    }
                    if (Main.dust[i].type == 0x21)
                    {
                        Main.dust[i].alpha = 170;
                        Dust dust3 = Main.dust[i];
                        dust3.velocity = (Vector2) (dust3.velocity * 0.5f);
                        Main.dust[i].velocity.Y++;
                    }
                    if (Main.dust[i].type == 0x29)
                    {
                        Dust dust4 = Main.dust[i];
                        dust4.velocity = (Vector2) (dust4.velocity * 0f);
                    }
                    if ((Main.dust[i].type == 0x22) || (Main.dust[i].type == 0x23))
                    {
                        Dust dust5 = Main.dust[i];
                        dust5.velocity = (Vector2) (dust5.velocity * 0.1f);
                        Main.dust[i].velocity.Y = -0.5f;
                        if ((Main.dust[i].type == 0x22) && !Collision.WetCollision(new Vector2(Main.dust[i].position.X, Main.dust[i].position.Y - 8f), 4, 4))
                        {
                            Main.dust[i].active = false;
                        }
                    }
                    return num;
                }
            }
            return num;
        }
    }
}

