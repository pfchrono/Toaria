namespace Toaria
{
    using Microsoft.Xna.Framework;
    using System;
    using System.Runtime.InteropServices;

    public class CombatText
    {
        public bool active;
        public float alpha;
        public int alphaDir = 1;
        public Color color;
        public bool crit;
        public int lifeTime;
        public Vector2 position;
        public float rotation;
        public float scale = 1f;
        public string text;
        public Vector2 velocity;

        public static void NewText(Rectangle location, Color color, string text, bool Crit = false)
        {
            if (Main.netMode != 2)
            {
                for (int i = 0; i < 100; i++)
                {
                    if (!Main.combatText[i].active)
                    {
                        int index = 0;
                        if (Crit)
                        {
                            index = 1;
                        }
                        Vector2 vector = Main.fontCombatText[index].MeasureString(text);
                        Main.combatText[i].alpha = 1f;
                        Main.combatText[i].alphaDir = -1;
                        Main.combatText[i].active = true;
                        Main.combatText[i].scale = 0f;
                        Main.combatText[i].rotation = 0f;
                        Main.combatText[i].position.X = (location.X + (location.Width * 0.5f)) - (vector.X * 0.5f);
                        Main.combatText[i].position.Y = (location.Y + (location.Height * 0.25f)) - (vector.Y * 0.5f);
                        Main.combatText[i].position.X += Main.rand.Next(-((int) (location.Width * 0.5)), ((int) (location.Width * 0.5)) + 1);
                        Main.combatText[i].position.Y += Main.rand.Next(-((int) (location.Height * 0.5)), ((int) (location.Height * 0.5)) + 1);
                        Main.combatText[i].color = color;
                        Main.combatText[i].text = text;
                        Main.combatText[i].velocity.Y = -7f;
                        Main.combatText[i].lifeTime = 60;
                        Main.combatText[i].crit = Crit;
                        if (Crit)
                        {
                            Main.combatText[i].text = text;
                            Main.combatText[i].color = new Color(0xff, 100, 30, 0xff);
                            CombatText text1 = Main.combatText[i];
                            text1.lifeTime *= 2;
                            Main.combatText[i].velocity.Y *= 2f;
                            Main.combatText[i].velocity.X = Main.rand.Next(-25, 0x1a) * 0.05f;
                            Main.combatText[i].rotation = (Main.combatText[i].lifeTime / 2) * 0.002f;
                            if (Main.combatText[i].velocity.X < 0f)
                            {
                                CombatText text2 = Main.combatText[i];
                                text2.rotation *= -1f;
                                return;
                            }
                        }
                        break;
                    }
                }
            }
        }

        public void Update()
        {
            if (this.active)
            {
                this.alpha += this.alphaDir * 0.05f;
                if (this.alpha <= 0.6)
                {
                    this.alphaDir = 1;
                }
                if (this.alpha >= 1f)
                {
                    this.alpha = 1f;
                    this.alphaDir = -1;
                }
                this.velocity.Y *= 0.92f;
                if (this.crit)
                {
                    this.velocity.Y *= 0.92f;
                }
                this.velocity.X *= 0.93f;
                this.position += this.velocity;
                this.lifeTime--;
                if (this.lifeTime <= 0)
                {
                    this.scale -= 0.1f;
                    if (this.scale < 0.1)
                    {
                        this.active = false;
                    }
                    this.lifeTime = 0;
                    if (this.crit)
                    {
                        this.alphaDir = -1;
                        this.scale += 0.07f;
                    }
                }
                else
                {
                    if (this.crit)
                    {
                        if (this.velocity.X < 0f)
                        {
                            this.rotation += 0.001f;
                        }
                        else
                        {
                            this.rotation -= 0.001f;
                        }
                    }
                    if (this.scale < 1f)
                    {
                        this.scale += 0.1f;
                    }
                    if (this.scale > 1f)
                    {
                        this.scale = 1f;
                    }
                }
            }
        }
    }
}

