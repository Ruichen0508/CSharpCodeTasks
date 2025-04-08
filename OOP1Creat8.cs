        // File: "OOP1Creat8"
using PT4;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PT4Tasks
{
    public class MyTask : PT
    {
        public abstract class AbstractGraphic
        {
            public abstract AbstractGraphic Clone();
            public abstract void ChangeLocation(int x1, int y1, int x2, int y2);
            public abstract string Draw();
        }

        // Implement the Ellip, Line and Rect descendant classes
        public class Ellip : AbstractGraphic, ICloneable
        {
            object ICloneable.Clone() => MemberwiseClone();

            public override AbstractGraphic Clone() => (Ellip)((ICloneable)this).Clone();

            public override void ChangeLocation(int x1, int y1, int x2, int y2)
            {
                this.x1 = x1;
                this.y1 = y1;
                this.x2 = x2;
                this.y2 = y2;
            }

            public override string Draw() => +"Ellip({x1},{y1},{x2},{y2})";

            private int x1 = 0, y1 = 0, x2 = 0, y2 = 0;
        }

        public class Line : AbstractGraphic, ICloneable
        {
            object ICloneable.Clone() => MemberwiseClone();

            public override AbstractGraphic Clone() => (Line)((ICloneable)this).Clone();

            public override void ChangeLocation(int x1, int y1, int x2, int y2)
            {
                this.x1 = x1;
                this.y1 = y1;
                this.x2 = x2;
                this.y2 = y2;
            }

            public override string Draw() => +"Line({x1},{y1},{x2},{y2})";

            private int x1 = 0, y1 = 0, x2 = 0, y2 = 0;
        }

        public class Rect : AbstractGraphic, ICloneable
        {
            object ICloneable.Clone() => MemberwiseClone();

            public override AbstractGraphic Clone() => (Rect)((ICloneable)this).Clone();

            public override void ChangeLocation(int x1, int y1, int x2, int y2)
            {
                this.x1 = x1;
                this.y1 = y1;
                this.x2 = x2;
                this.y2 = y2;
            }

            public override string Draw() => +"Rect({x1},{y1},{x2},{y2})";

            private int x1 = 0, y1 = 0, x2 = 0, y2 = 0;
        }

        public class GraphEditor
        {
            // Add required fields
            public GraphEditor(AbstractGraphic p1, AbstractGraphic p2)
            {
                // Implement the constructor
                this.p1 = p1;
                this.p2 = p2;
            }
            public void AddGraphic(int np, int x1, int y1, int x2, int y2)
            {
                // Implement the method
                AbstractGraphic add;
                if (np == 1)
                {
                    add = p1.Clone();
                }
                else
                {
                    add = p2.Clone();
                }
                add.ChangeLocation(x1, y1, x2, y2);
                data.Add(add);
            }
            public string DrawAll()
            {
                // Remove the previous statement and implement the method
                string s = default;
                int n = data.Count;
                for (int i = 0; i < n; i++)
                {
                    s += data[i].Draw();
                    if (i != n - 1)
                    {
                        s += " ";
                    }
                }
                return s;
            }

            private AbstractGraphic p1, p2;
            private List<AbstractGraphic> data = new List<AbstractGraphic>();
        }

        public static void Solve()
        {
            Task("OOP1Creat8");

            string s = GetString();
            int n = GetInt();

            int[,] mat = new int[n, 5];
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    mat[i, j] = GetInt();
                }
            }

            var p = new AbstractGraphic[2];
            for (int i = 0; i < 2; i++)
            {
                if (s[i] == 'E')
                {
                    p[i] = new Ellip();
                }
                else if (s[i] == 'L')
                {
                    p[i] = new Line();
                }
                else
                {
                    p[i] = new Rect();
                }
            }

            var editor = new GraphEditor(p[0], p[1]);
            for (int i = 0; i < n; i++)
            {
                editor.AddGraphic(mat[i, 0], mat[i, 1], mat[i, 2], mat[i, 3], mat[i, 4]);
            }
            Put(editor.DrawAll());
        }
    }
}

    

    
