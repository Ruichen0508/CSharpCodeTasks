    using PT4;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PT4Tasks
{
    public class MyTask : PT
    {
        public abstract class Builder
        {
            public virtual void BuildStart() { }
            public virtual void BuildPartA() { }
            public virtual void BuildPartB() { }
            public virtual void BuildPartC() { }
            public abstract string GetResult();
        }
        public class the1 : Builder
        {
            public the1()
            {
                this.info = "";
            }
            public override void BuildStart()
            {
                this.info = "";
            }
            public override void BuildPartA()
            {
                this.info += "-1-";
            }
            public override void BuildPartB()
            {
                this.info += "-2-";
            }
            public override void BuildPartC()
            {
                this.info += "-3-";
            }
            public override string GetResult()
            {
                return info;
            }
            string info;
        }
        public class the2 : Builder
        {
            public the2()
            {
                this.info = "";
            }
            public override void BuildStart()
            {
                this.info = "";
            }
            public override void BuildPartA()
            {
                this.info += "=*=";
            }
            public override void BuildPartB()
            {
                this.info += "=**=";
            }
            public override void BuildPartC()
            {
                this.info += "=***=";
            }
            public override string GetResult()
            {
                return info;
            }
            string info;
        }


        public class the3
        {
            Builder b;
            public the3(Builder b)
            {
                this.b = b;
            }
            public string GetResult()
            {
                return b.GetResult();
            }
            public void Construct(string templat)
            {
                // Implement the method
                b.BuildStart();
                int i, number = templat.Length;
                for (i = 0; i < number; i++)
                {
                    if (templat[i] == 'A')
                    {
                        b.BuildPartA();
                    }
                    if (templat[i] == 'B')
                    {
                        b.BuildPartB();
                    }
                    if (templat[i] == 'C')
                    {
                        b.BuildPartC();
                    }
                }
            }
        }

        public static void Solve()
        {
            Task("OOP1Creat9");
            Builder a1 = new the1();
            Builder a2 = new the2();
            the3 b1 = new the3(a1);
            the3 b2 = new the3(a2);
            for (int j = 0; j < 5; j++)
            {
                string str = GetString();
                b1.Construct(str);
                Put(b1.GetResult());
                b2.Construct(str);
                Put(b2.GetResult());
            }

        }
    }
}

    
