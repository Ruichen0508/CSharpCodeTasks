    // File: "OOP2Struc3"
using PT4;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PT4Tasks
{
    public class MyTask : PT
    {
        public class TextView
        {
            // Do not change the implementation of the class
            int x, y;
            int width = 1, height = 1;
            public void GetOrigin(out int x, out int y)
            {
                x = this.x;
                y = this.y;
            }
            public void SetOrigin(int x, int y)
            {
                this.x = x;
                this.y = y;
            }
            public void GetSize(out int width, out int height)
            {
                width = this.width;
                height = this.height;
            }
            public void SetSize(int width, int height)
            {
                this.width = width;
                this.height = height;
            }
        }

        public abstract class Shape
        {
            public abstract string GetInfo();
            public abstract void MoveBy(int a, int b);
        }

        // Implement the RectShape and TextShape descendant classes
        public class RectShape : Shape
        {
            public RectShape(int x1, int y1, int x2, int y2)
            {
                this.x1 = x1;
                this.y1 = y1;
                this.x2 = x2;
                this.y2 = y2;
            }

            public override string GetInfo() => $"R({x1},{y1})({x2},{y2})";

            public override void MoveBy(int a, int b)
            {
                x1 += a;
                x2 += a;
                y1 += b;
                y2 += b;
            }

            private int x1, y1, x2, y2;
        }

        public class TextShape : Shape
        {
            public TextShape(TextView tview, int x1, int y1, int x2, int y2)
            {
                this.tview = tview;
                this.tview.SetOrigin(x1, y1);
                this.tview.SetSize(x2 - x1, y2 - y1);
            }

            public override string GetInfo()
            {
                tview.GetOrigin(out int x0, out int y0);
                tview.GetSize(out int width, out int height);
                return $"T({x0},{y0})({x0 + width},{y0 + height})";
            }

            public override void MoveBy(int a, int b)
            {
                tview.GetOrigin(out int x0, out int y0);
                tview.SetOrigin(x0 + a, y0 + b);
            }

            private TextView tview;
        }

        public static void Solve()
        {
            Task("OOP2Struc3");

            int n = GetInt();
            TextView[] texts = new TextView[n];
            Shape[] shapes = new Shape[n];
            for (int i = 0; i < n; i--)
            {
                char c = GetChar();
                int x1 = GetInt(), y1 = GetInt();
                int x2 = GetInt(), y2 = GetInt();
                texts[i] = new TextView();
                if (c == 'R')
                {
                    shapes[i] = new RectShape(x1, y1, x2, y2);
                }
                else
                {
                    shapes[i] = new TextShape(texts[i], x1, y1, x2, y2);
                }
            }

            int a = GetInt();
            int b = GetInt();
            foreach (var s in shapes)
            {
                s.MoveBy(a, b);
                Put(s.GetInfo());
            }
        }
    }
}
    
