// File: "OOP2Struc7"
using PT4;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PT4Tasks
{
    public class MyTask : PT
    {
        public abstract class Component
        {
            public abstract string Show();
        }

        // Implement the ConcreteComponent descendant class
        public class ConcreteComponent : Component
        {
            string text;
            public ConcreteComponent(string text) 
            { 
                this.text = text;
            }
            public override string Show() 
            { 
                return text;
            }
        }

        public abstract class Decorator : Component
        {
            protected Component comp;
        }

        // Implement the ConcreteDecoratorA
        //   and ConcreteDecoratorB descendant classes
        public class ConcreteDecoratorA : Decorator
        {
            public ConcreteDecoratorA(Component p) 
            { 
                this.comp = p;
            }
            public override string Show() 
            { 
                return "==" + comp.Show() + "==";
            }
        }
        public class ConcreteDecoratorB : Decorator
        {
            public ConcreteDecoratorB(Component p) 
            { 
                this.comp = p;
            }
            public override string Show() 
            {
                return "(" + comp.Show() + ")"; 
            }
        }
        
        public static void Solve()
        {
            Task("OOP2Struc7");
            int N;
            N = GetInt();
            Component[] comp = new Component[N];
            for (int i = 0; i < N; i++)
            {
                string S = GetString();
                string D = GetString();
                foreach (var c in D)
                {
                    ConcreteComponent temp = new ConcreteComponent(S);
                    ConcreteDecoratorA A = new ConcreteDecoratorA(temp);
                    ConcreteDecoratorB B = new ConcreteDecoratorB(temp);
                    if (c == 'A')
                    {
                        S = A.Show();
                    }
                    if (c == 'B')
                    {
                        S = B.Show();
                    }
                }
                comp[i] = new ConcreteComponent(S);
            }
            for (int i = N - 1; i >= 0; i--)
            {
                Put(comp[i].Show());
            }
        }
    }
}