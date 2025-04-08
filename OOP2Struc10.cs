using PT4;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PT4Tasks
{
    public class MyTask : PT
    {
        public abstract class Implementor
        {
            public abstract string DrawLine(int size);
            public abstract string DrawText(string text);
        }

        // Implement the ConcreteImplementorA
        //   and ConcreteImplementorB descendant classes
        public class ConcreteImplementorA : Implementor
        {
            public int num;
            public string s;
            public ConcreteImplementorA(int size, string text)
            {
                num = size;
                s = text;
            }
            public override string DrawLine(int size)
            {
                string s1 = null;
                for (int i = 0; i < num; i++)
                {
                    s1 = s1 + '-';
                }
                return s1;
            }
            public override string DrawText(string text)
            {
                return s.ToLower();
            }
        }

        public class ConcreteImplementorB : Implementor
        {
            public int num;
            public string s;
            public ConcreteImplementorB(int size, string text)
            {
                num = size;
                s = text;
            }
            public override string DrawLine(int size)
            {
                string s1 = null;
                for (int i = 0; i < num; i++)
                {
                    s1 = s1 + '=';
                }
                return s1;
            }
            public override string DrawText(string text)
            {
                return s.ToUpper();
            }
        }


        public class Abstraction
        {
            protected int size;
            protected Implementor imp;
            public Abstraction(Implementor imp, int size)
            {
                this.imp = imp;
                this.size = size;
            }
        // Complete the implementation of the class
            public virtual string ShowA()
            {
                return imp.DrawLine(size);
            }
            public virtual string ShowB()
            {
                return imp.DrawLine(size);
            }
            public virtual void setsize(int n)
            {
                size = n;
            }
        }

        // Implement the RefinedAbstraction descendant class
        public class RefinedAbstraction : Abstraction
        {
            public string text;
            public RefinedAbstraction(Implementor imp, int size, string text) : base(imp, size){}
            public override string ShowA()
            {
                string s;
                s = '-' + imp.DrawText(text);
                if (s.Length >= size)
                {
                    s = s.Substring(0, size);
                }
                else
                {
                    int k = size - s.Length;
                    for (int i = 0; i < k; i++)
                    {
                        s = s + '-';
                    }
                }

                return s;
            }
            public override string ShowB()
            {
                string s;
                s = '=' + imp.DrawText(text);
                if (s.Length >= size)
                {
                    s = s.Substring(0, size);
                }
                else
                {
                    int k = size - s.Length;
                    for (int i = 0; i < k; i++)
                    {
                        s = s + '=';
                    }
                }
                return s.ToUpper();
            }
        }

    //
        public static void Solve()
        {
            Task("OOP2Struc10");
            int n, Size;
            string s;
            n = GetInt();
            s = GetString();
            Implementor IMP_1 = new ConcreteImplementorA(n, s);
            Implementor IMP_2 = new ConcreteImplementorB(n, s);
            Abstraction ABS = new RefinedAbstraction(IMP_1, n, s);
            ABS.setsize(n);

            Put(IMP_1.DrawLine(n));
            Put(IMP_2.DrawLine(n));
            Put(ABS.ShowA());
            Put(ABS.ShowB());

            for (int i = 0; i < 5; i++)
            {
                Size = GetInt();
                Implementor Test_IMP_1 = new ConcreteImplementorA(Size, s);
                Implementor TEST_IMP_2 = new ConcreteImplementorB(Size, s);
                Abstraction TEST_ABS = new RefinedAbstraction(Test_IMP_1, n, s);

                TEST_ABS.setsize(Size);
                Put(Test_IMP_1.DrawLine(Size));
                Put(TEST_IMP_2.DrawLine(Size));
                Put(TEST_ABS.ShowA());
                Put(TEST_ABS.ShowB());
                ShowLine(TEST_ABS.ShowA());
            }

        }
    }
}
