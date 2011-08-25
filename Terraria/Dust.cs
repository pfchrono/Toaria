namespace Terraria
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

        public static void UpdateDust()
        {
            lavaBubbles = 0;
            for (int i = 0; i < 0x3e8; i++)
            {
                if (i < Main.numDust)
                {
                    if (Main.dust[i].active)
                    {
                        if (Main.dust[i].type == 0x23)
                        {
                            lavaBubbles++;
                        }
                        Dust dust1 = Main.dust[i];
                        dust1.position += Main.dust[i].velocity;
                        if ((Main.dust[i].type == 6) || (Main.dust[i].type == 0x1d))
                        {
                            if (!Main.dust[i].noGravity)
                            {
                                Main.dust[i].velocity.Y += 0.05f;
                            }
                            if (!Main.dust[i].noLight)
                            {
                                float lightness = Main.dust[i].scale * 1.6f;
                                if (Main.dust[i].type == 0x1d)
                                {
                                    lightness *= 0.2f;
                                }
                                if (lightness > 1f)
                                {
                                    lightness = 1f;
                                }
                                Lighting.addLight((int) (Main.dust[i].position.X / 16f), (int) (Main.dust[i].position.Y / 16f), lightness);
                            }
                        }
                        else if (((Main.dust[i].type == 14) || (Main.dust[i].type == 0x10)) || ((Main.dust[i].type == 0x1f) || (Main.dust[i].type == 0x2e)))
                        {
                            Main.dust[i].velocity.Y *= 0.98f;
                            Main.dust[i].velocity.X *= 0.98f;
                        }
                        else if (Main.dust[i].type == 0x20)
                        {
                            Dust dust2 = Main.dust[i];
                            dust2.scale -= 0.01f;
                            Main.dust[i].velocity.X *= 0.96f;
                            Main.dust[i].velocity.Y += 0.1f;
                        }
                        else if (Main.dust[i].type == 0x2b)
                        {
                            Dust dust3 = Main.dust[i];
                            dust3.rotation += 0.1f * Main.dust[i].scale;
                            float r = Lighting.GetColor((int) (Main.dust[i].position.X / 16f), (int) (Main.dust[i].position.Y / 16f)).R;
                            r = ((r / 256f) * Main.dust[i].scale) * 1.09f;
                            if (r > 1f)
                            {
                                r = 1f;
                            }
                            if (Main.dust[i].alpha < 0xff)
                            {
                                Dust dust4 = Main.dust[i];
                                dust4.scale += 0.09f;
                                if (Main.dust[i].scale >= 1f)
                                {
                                    Main.dust[i].scale = 1f;
                                    Main.dust[i].alpha = 0xff;
                                }
                            }
                            else
                            {
                                if (Main.dust[i].scale < 0.8)
                                {
                                    Dust dust5 = Main.dust[i];
                                    dust5.scale -= 0.01f;
                                }
                                if (Main.dust[i].scale < 0.5)
                                {
                                    Dust dust6 = Main.dust[i];
                                    dust6.scale -= 0.01f;
                                }
                            }
                            if (r == 0f)
                            {
                                Main.dust[i].active = false;
                            }
                            else
                            {
                                Lighting.addLight((int) (Main.dust[i].position.X / 16f), (int) (Main.dust[i].position.Y / 16f), r);
                            }
                        }
                        else if (Main.dust[i].type == 15)
                        {
                            Main.dust[i].velocity.Y *= 0.98f;
                            Main.dust[i].velocity.X *= 0.98f;
                            float scale = Main.dust[i].scale;
                            if (Main.dust[i].noLight)
                            {
                                scale = 0f;
                                Dust dust7 = Main.dust[i];
                                dust7.scale -= 0.1f;
                            }
                            if (scale > 1f)
                            {
                                scale = 1f;
                            }
                            if (Main.dust[i].noLight)
                            {
                                scale *= 0.5f;
                            }
                            Lighting.addLight((int) (Main.dust[i].position.X / 16f), (int) (Main.dust[i].position.Y / 16f), scale);
                        }
                        else if ((Main.dust[i].type == 20) || (Main.dust[i].type == 0x15))
                        {
                            Dust dust8 = Main.dust[i];
                            dust8.scale += 0.005f;
                            Main.dust[i].velocity.Y *= 0.94f;
                            Main.dust[i].velocity.X *= 0.94f;
                            float num5 = Main.dust[i].scale * 0.8f;
                            if (Main.dust[i].type == 0x15)
                            {
                                num5 = Main.dust[i].scale * 0.4f;
                            }
                            if (num5 > 1f)
                            {
                                num5 = 1f;
                            }
                            Lighting.addLight((int) (Main.dust[i].position.X / 16f), (int) (Main.dust[i].position.Y / 16f), num5);
                        }
                        else if ((Main.dust[i].type == 0x1b) || (Main.dust[i].type == 0x2d))
                        {
                            Dust dust9 = Main.dust[i];
                            dust9.velocity = (Vector2) (dust9.velocity * 0.94f);
                            Dust dust10 = Main.dust[i];
                            dust10.scale += 0.002f;
                            float num6 = Main.dust[i].scale;
                            if (Main.dust[i].noLight)
                            {
                                num6 *= 0.1f;
                                Dust dust11 = Main.dust[i];
                                dust11.scale -= 0.06f;
                                if (Main.dust[i].scale < 1f)
                                {
                                    Dust dust12 = Main.dust[i];
                                    dust12.scale -= 0.06f;
                                }
                                if (Main.player[Main.myPlayer].wet)
                                {
                                    Dust dust13 = Main.dust[i];
                                    dust13.position += (Vector2) (Main.player[Main.myPlayer].velocity * 0.5f);
                                }
                                else
                                {
                                    Dust dust14 = Main.dust[i];
                                    dust14.position += Main.player[Main.myPlayer].velocity;
                                }
                            }
                            if (num6 > 1f)
                            {
                                num6 = 1f;
                            }
                            Lighting.addLight((int) (Main.dust[i].position.X / 16f), (int) (Main.dust[i].position.Y / 16f), num6);
                        }
                        else if ((!Main.dust[i].noGravity && (Main.dust[i].type != 0x29)) && (Main.dust[i].type != 0x2c))
                        {
                            Main.dust[i].velocity.Y += 0.1f;
                        }
                        if ((Main.dust[i].type == 5) && Main.dust[i].noGravity)
                        {
                            Dust dust15 = Main.dust[i];
                            dust15.scale -= 0.04f;
                        }
                        if (Main.dust[i].type == 0x21)
                        {
                            if (Collision.WetCollision(new Vector2(Main.dust[i].position.X, Main.dust[i].position.Y), 4, 4))
                            {
                                Dust dust16 = Main.dust[i];
                                dust16.alpha += 20;
                                Dust dust17 = Main.dust[i];
                                dust17.scale -= 0.1f;
                            }
                            Dust dust18 = Main.dust[i];
                            dust18.alpha += 2;
                            Dust dust19 = Main.dust[i];
                            dust19.scale -= 0.005f;
                            if (Main.dust[i].alpha > 0xff)
                            {
                                Main.dust[i].scale = 0f;
                            }
                            Main.dust[i].velocity.X *= 0.93f;
                            if (Main.dust[i].velocity.Y > 4f)
                            {
                                Main.dust[i].velocity.Y = 4f;
                            }
                            if (Main.dust[i].noGravity)
                            {
                                if (Main.dust[i].velocity.X < 0f)
                                {
                                    Dust dust20 = Main.dust[i];
                                    dust20.rotation -= 0.2f;
                                }
                                else
                                {
                                    Dust dust21 = Main.dust[i];
                                    dust21.rotation += 0.2f;
                                }
                                Dust dust22 = Main.dust[i];
                                dust22.scale += 0.03f;
                                Main.dust[i].velocity.X *= 1.05f;
                                Main.dust[i].velocity.Y += 0.15f;
                            }
                        }
                        if ((Main.dust[i].type == 0x23) && Main.dust[i].noGravity)
                        {
                            Dust dust23 = Main.dust[i];
                            dust23.scale += 0.03f;
                            if (Main.dust[i].scale < 1f)
                            {
                                Main.dust[i].velocity.Y += 0.075f;
                            }
                            Main.dust[i].velocity.X *= 1.08f;
                            if (Main.dust[i].velocity.X > 0f)
                            {
                                Dust dust24 = Main.dust[i];
                                dust24.rotation += 0.01f;
                            }
                            else
                            {
                                Dust dust25 = Main.dust[i];
                                dust25.rotation -= 0.01f;
                            }
                        }
                        else if ((Main.dust[i].type == 0x22) || (Main.dust[i].type == 0x23))
                        {
                            if (!Collision.WetCollision(new Vector2(Main.dust[i].position.X, Main.dust[i].position.Y - 8f), 4, 4))
                            {
                                Main.dust[i].scale = 0f;
                            }
                            else
                            {
                                Dust dust26 = Main.dust[i];
                                dust26.alpha += Main.rand.Next(2);
                                if (Main.dust[i].alpha > 0xff)
                                {
                                    Main.dust[i].scale = 0f;
                                }
                                Main.dust[i].velocity.Y = -0.5f;
                                if (Main.dust[i].type == 0x22)
                                {
                                    Dust dust27 = Main.dust[i];
                                    dust27.scale += 0.005f;
                                }
                                else
                                {
                                    Dust dust28 = Main.dust[i];
                                    dust28.alpha++;
                                    Dust dust29 = Main.dust[i];
                                    dust29.scale -= 0.01f;
                                    Main.dust[i].velocity.Y = -0.2f;
                                }
                                Main.dust[i].velocity.X += Main.rand.Next(-10, 10) * 0.002f;
                                if (Main.dust[i].velocity.X < -0.25)
                                {
                                    Main.dust[i].velocity.X = -0.25f;
                                }
                                if (Main.dust[i].velocity.X > 0.25)
                                {
                                    Main.dust[i].velocity.X = 0.25f;
                                }
                            }
                            if (Main.dust[i].type == 0x23)
                            {
                                float num7 = (Main.dust[i].scale * 0.2f) + 0.5f;
                                if (num7 > 1f)
                                {
                                    num7 = 1f;
                                }
                                Lighting.addLight((int) (Main.dust[i].position.X / 16f), (int) (Main.dust[i].position.Y / 16f), num7);
                            }
                        }
                        if (Main.dust[i].type == 0x29)
                        {
                            Main.dust[i].velocity.X += Main.rand.Next(-10, 11) * 0.01f;
                            Main.dust[i].velocity.Y += Main.rand.Next(-10, 11) * 0.01f;
                            if (Main.dust[i].velocity.X > 0.75)
                            {
                                Main.dust[i].velocity.X = 0.75f;
                            }
                            if (Main.dust[i].velocity.X < -0.75)
                            {
                                Main.dust[i].velocity.X = -0.75f;
                            }
                            if (Main.dust[i].velocity.Y > 0.75)
                            {
                                Main.dust[i].velocity.Y = 0.75f;
                            }
                            if (Main.dust[i].velocity.Y < -0.75)
                            {
                                Main.dust[i].velocity.Y = -0.75f;
                            }
                            Dust dust30 = Main.dust[i];
                            dust30.scale += 0.007f;
                            float num8 = Main.dust[i].scale * 0.7f;
                            if (num8 > 1f)
                            {
                                num8 = 1f;
                            }
                            Lighting.addLight((int) (Main.dust[i].position.X / 16f), (int) (Main.dust[i].position.Y / 16f), num8);
                        }
                        else if (Main.dust[i].type == 0x2c)
                        {
                            Main.dust[i].velocity.X += Main.rand.Next(-10, 11) * 0.003f;
                            Main.dust[i].velocity.Y += Main.rand.Next(-10, 11) * 0.003f;
                            if (Main.dust[i].velocity.X > 0.35)
                            {
                                Main.dust[i].velocity.X = 0.35f;
                            }
                            if (Main.dust[i].velocity.X < -0.35)
                            {
                                Main.dust[i].velocity.X = -0.35f;
                            }
                            if (Main.dust[i].velocity.Y > 0.35)
                            {
                                Main.dust[i].velocity.Y = 0.35f;
                            }
                            if (Main.dust[i].velocity.Y < -0.35)
                            {
                                Main.dust[i].velocity.Y = -0.35f;
                            }
                            Dust dust31 = Main.dust[i];
                            dust31.scale += 0.0085f;
                            float num9 = Main.dust[i].scale * 0.7f;
                            if (num9 > 1f)
                            {
                                num9 = 1f;
                            }
                            Lighting.addLight((int) (Main.dust[i].position.X / 16f), (int) (Main.dust[i].position.Y / 16f), num9);
                        }
                        else
                        {
                            Main.dust[i].velocity.X *= 0.99f;
                        }
                        Dust dust32 = Main.dust[i];
                        dust32.rotation += Main.dust[i].velocity.X * 0.5f;
                        if (Main.dust[i].fadeIn > 0f)
                        {
                            if (Main.dust[i].type == 0x2e)
                            {
                                Dust dust33 = Main.dust[i];
                                dust33.scale += 0.1f;
                            }
                            else
                            {
                                Dust dust34 = Main.dust[i];
                                dust34.scale += 0.03f;
                            }
                            if (Main.dust[i].scale > Main.dust[i].fadeIn)
                            {
                                Main.dust[i].fadeIn = 0f;
                            }
                        }
                        else
                        {
                            Dust dust35 = Main.dust[i];
                            dust35.scale -= 0.01f;
                        }
                        if (Main.dust[i].noGravity)
                        {
                            Dust dust36 = Main.dust[i];
                            dust36.velocity = (Vector2) (dust36.velocity * 0.92f);
                            if (Main.dust[i].fadeIn == 0f)
                            {
                                Dust dust37 = Main.dust[i];
                                dust37.scale -= 0.04f;
                            }
                        }
                        if (Main.dust[i].position.Y > (Main.screenPosition.Y + Main.screenHeight))
                        {
                            Main.dust[i].active = false;
                        }
                        if (Main.dust[i].scale < 0.1)
                        {
                            Main.dust[i].active = false;
                        }
                    }
                }
                else
                {
                    Main.dust[i].active = false;
                }
            }
        }
    }
}

