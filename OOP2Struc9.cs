using PT4;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PT4Tasks
{
    public class MyTask : PT
    {
        public abstract class Subject
        {
            public abstract string OperationA();
            public abstract string OperationB();
            public abstract string OperationC();
            public abstract string OperationD();
        }
        public class RealSubject : Subject
        {
            public override string OperationA()
            {
                return "A (Real)";
            }
            public override string OperationB()
            {
                return "B (Real)";
            }
            public override string OperationC()
            {
                return "C (Real)";
            }
            public override string OperationD()
            {
                return "D (Real)";
            }
            public string Operation(char c)
            {
                if (c == 'A')
                {
                    return OperationA();
                }
                else if (c == 'B')
                {
                    return OperationB();
                }
                else if (c == 'C')
                {
                    return OperationC();
                }
                else
                {
                    return OperationD();
                }
            }
        }
        public class Proxy : Subject
        {
            RealSubject rsubj;
            public override string OperationA()
            {
                if (rsubj != null)
                {
                    return rsubj.OperationA();
                }
                else
                {
                    return "A (Proxy)";
                }
            }
            public override string OperationB()
            {
                if (protectedMode)
                {
                    return "B denied";
                }
                else if (rsubj != null)
                {
                    return rsubj.OperationB();
                }
                else
                {
                    return "B (Proxy)";
                }
            }
            public override string OperationC()
            {
                if (rsubj == null)
                {
                    rsubj = new RealSubject();
                }
                return rsubj.OperationC();
            }
            public override string OperationD()
            {
                if (protectedMode)
                {
                    return "D denied";
                }
                else if (rsubj == null)
                {
                    rsubj = new RealSubject();
                }
                return rsubj.OperationD();
            }
            public string Operation(char c)
            {
                if (c == 'A')
                {
                    return OperationA();
                }
                else if (c == 'B')
                {
                    return OperationB();
                }
                else if (c == 'C')
                {
                    return OperationC();
                }
                else
                {
                    return OperationD();
                }
            }
            public Proxy(bool deferredMode, bool protectedMode)
            {
                this.deferredMode = deferredMode;
                this.protectedMode = protectedMode;
                if (!deferredMode)
                {
                    rsubj = new RealSubject();
                }
                else
                {
                    rsubj = null;
                }
            }
            bool deferredMode;
            bool protectedMode;
        }
        public static void Solve()
        {
            bool x;
            bool y;
            Task("OOP2Struc9");
            int[] vessel = new int[3];
            for (int i = 0; i < 3; i++)
            {
                vessel[i] = GetInt();
            }
            string s = GetString();
            int[,] Vessel = new int[4,2] { { 0, 0 }, { 1, 0 }, { 0, 1 }, { 1, 1 } };
            for (int i = 0; i < 3; i++)
            {
                if (vessel[i] == -1)
                {
                    RealSubject r = new RealSubject();
                    for (int opi = 0; opi < s.Length; opi++)
                    {
                        Put(r.Operation(s[opi]));
                    }
                }
                else
                {
                    x = Vessel[vessel[i], 0] == 1;
                    y = Vessel[vessel[i], 1] == 1;
                    Proxy p = new Proxy(x, y);
                    for (int opi = 0; opi < s.Length; opi++)
                    {
                        Put(p.Operation(s[opi]));
                    }
                }
            }
        }
    }
}
