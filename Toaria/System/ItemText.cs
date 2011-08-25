namespace Terraria
{
    using Microsoft.Xna.Framework;
    using System;

    public class ItemText
    {
        public bool active;
        public static int activeTime = 60;
        public float alpha;
        public int alphaDir = 1;
        public Color color;
        public int lifeTime;
        public string name;
        public static int numActive;
        public Vector2 position;
        public float rotation;
        public float scale = 1f;
        public int stack;
        public Vector2 velocity;

        public static void NewText(Item newItem, int stack)
        {
            if ((Main.showItemText && ((newItem.name != null) && newItem.active)) && (Main.netMode != 2))
            {
                for (int i = 0; i < 100; i++)
                {
                    if (Main.itemText[i].active && (Main.itemText[i].name == newItem.name))
                    {
                        string text = string.Concat(new object[] { newItem.name, " (", Main.itemText[i].stack + stack, ")" });
                        string name = newItem.name;
                        if (Main.itemText[i].stack > 1)
                        {
                            object obj2 = name;
                            name = string.Concat(new object[] { obj2, " (", Main.itemText[i].stack, ")" });
                        }
                        Vector2 vector = Main.fontMouseText.MeasureString(name);
                        vector = Main.fontMouseText.MeasureString(text);
                        if (Main.itemText[i].lifeTime < 0)
                        {
                            Main.itemText[i].scale = 1f;
                        }
                        Main.itemText[i].lifeTime = 60;
                        ItemText text1 = Main.itemText[i];
                        text1.stack += stack;
                        Main.itemText[i].scale = 0f;
                        Main.itemText[i].rotation = 0f;
                        Main.itemText[i].position.X = (newItem.position.X + (newItem.width * 0.5f)) - (vector.X * 0.5f);
                        Main.itemText[i].position.Y = (newItem.position.Y + (newItem.height * 0.25f)) - (vector.Y * 0.5f);
                        Main.itemText[i].velocity.Y = -7f;
                        return;
                    }
                }
                for (int j = 0; j < 100; j++)
                {
                    if (!Main.itemText[j].active)
                    {
                        string str3 = newItem.name;
                        if (stack > 1)
                        {
                            object obj3 = str3;
                            str3 = string.Concat(new object[] { obj3, " (", stack, ")" });
                        }
                        Vector2 vector2 = Main.fontMouseText.MeasureString(str3);
                        Main.itemText[j].alpha = 1f;
                        Main.itemText[j].alphaDir = -1;
                        Main.itemText[j].active = true;
                        Main.itemText[j].scale = 0f;
                        Main.itemText[j].rotation = 0f;
                        Main.itemText[j].position.X = (newItem.position.X + (newItem.width * 0.5f)) - (vector2.X * 0.5f);
                        Main.itemText[j].position.Y = (newItem.position.Y + (newItem.height * 0.25f)) - (vector2.Y * 0.5f);
                        Main.itemText[j].color = Color.White;
                        if (newItem.rare == 1)
                        {
                            Main.itemText[j].color = new Color(150, 150, 0xff);
                        }
                        else if (newItem.rare == 2)
                        {
                            Main.itemText[j].color = new Color(150, 0xff, 150);
                        }
                        else if (newItem.rare == 3)
                        {
                            Main.itemText[j].color = new Color(0xff, 200, 150);
                        }
                        else if (newItem.rare == 4)
                        {
                            Main.itemText[j].color = new Color(0xff, 150, 150);
                        }
                        Main.itemText[j].name = newItem.name;
                        Main.itemText[j].stack = stack;
                        Main.itemText[j].velocity.Y = -7f;
                        Main.itemText[j].lifeTime = 60;
                        return;
                    }
                }
            }
        }

        public void Update(int whoAmI)
        {
            if (this.active)
            {
                this.alpha += this.alphaDir * 0.01f;
                if (this.alpha <= 0.7)
                {
                    this.alpha = 0.7f;
                    this.alphaDir = 1;
                }
                if (this.alpha >= 1f)
                {
                    this.alpha = 1f;
                    this.alphaDir = -1;
                }
                bool flag = false;
                string name = this.name;
                if (this.stack > 1)
                {
                    object obj2 = name;
                    name = string.Concat(new object[] { obj2, " (", this.stack, ")" });
                }
                Vector2 vector = (Vector2) (Main.fontMouseText.MeasureString(name) * this.scale);
                vector.Y *= 0.8f;
                Rectangle rectangle = new Rectangle((int) (this.position.X - (vector.X / 2f)), (int) (this.position.Y - (vector.Y / 2f)), (int) vector.X, (int) vector.Y);
                for (int i = 0; i < 100; i++)
                {
                    if (Main.itemText[i].active && (i != whoAmI))
                    {
                        string text = Main.itemText[i].name;
                        if (Main.itemText[i].stack > 1)
                        {
                            object obj3 = text;
                            text = string.Concat(new object[] { obj3, " (", Main.itemText[i].stack, ")" });
                        }
                        Vector2 vector2 = (Vector2) (Main.fontMouseText.MeasureString(text) * Main.itemText[i].scale);
                        vector2.Y *= 0.8f;
                        Rectangle rectangle2 = new Rectangle((int) (Main.itemText[i].position.X - (vector2.X / 2f)), (int) (Main.itemText[i].position.Y - (vector2.Y / 2f)), (int) vector2.X, (int) vector2.Y);
                        if (rectangle.Intersects(rectangle2) && ((this.position.Y < Main.itemText[i].position.Y) || ((this.position.Y == Main.itemText[i].position.Y) && (whoAmI < i))))
                        {
                            flag = true;
                            Main.itemText[i].lifeTime = activeTime + (15 * numActive);
                            this.lifeTime = activeTime + (15 * numActive);
                        }
                    }
                }
                if (!flag)
                {
                    this.velocity.Y *= 0.86f;
                    if (this.scale == 1f)
                    {
                        this.velocity.Y *= 0.4f;
                    }
                }
                else if (this.velocity.Y > -6f)
                {
                    this.velocity.Y -= 0.2f;
                }
                else
                {
                    this.velocity.Y *= 0.86f;
                }
                this.velocity.X *= 0.93f;
                this.position += this.velocity;
                this.lifeTime--;
                if (this.lifeTime <= 0)
                {
                    this.scale -= 0.03f;
                    if (this.scale < 0.1)
                    {
                        this.active = false;
                    }
                    this.lifeTime = 0;
                }
                else
                {
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

