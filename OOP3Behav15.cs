    using PT4;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PT4Tasks
{
    public class MyTask : PT
    {
        public abstract class Element
        {
            public abstract void Accept(Visitor v);
        }

        public class ConcreteElementA : Element
        {
            // Add required fields and methods
            public int number;
            public ConcreteElementA(int data) { number = data; }
            public int GetData() 
            { 
                return number; 
            }
            public void SetData(int newnumber) 
            {
                number = newnumber;
            }
            public override void Accept(Visitor v)
            {
                // Implement the method
                v.VisitConcreteElementA(this);
            }
        }

        public class ConcreteElementB : Element
        {
            // Add required fields and methods
            string str;
            public ConcreteElementB(string data) { str = data; }
            public string GetData() { return str; }
            public void SetData(string newstr) { str = newstr; }
            public override void Accept(Visitor v)
            {
                // Implement the method
                v.VisitConcreteElementB(this);
            }
        }

        public class ConcreteElementC : Element
        {
            // Add required fields and methods
            float f;
            public ConcreteElementC(float data) { f = data; }
            public float GetData() { return f; }
            public void SetData(float newf) { f = newf; }
            public override void Accept(Visitor v)
            {
                // Implement the method
                v.VisitConcreteElementC(this);
            }
        }

        public class ObjectStructure
        {
            Element[] struc;
            public ObjectStructure(Element[] struc)
            {
                // Implement the constructor
                this.struc = struc;
            }
            public void Accept(Visitor v)
            {
                foreach (var e in struc)
                    e.Accept(v);
            }
        }

        public abstract class Visitor
        {
            public abstract void VisitConcreteElementA(ConcreteElementA e);
            public abstract void VisitConcreteElementB(ConcreteElementB e);
            public abstract void VisitConcreteElementC(ConcreteElementC e);
        }

        // Implement the ConcreteVisitor1, ConcreteVisitor2
        //   and ConcreteVisitor3 descendant classes
        public class ConcreteVisitor1 : Visitor
        {
            public override void VisitConcreteElementA(ConcreteElementA e) 
            {
                Put(e.GetData()); 
            }
            public override void VisitConcreteElementB(ConcreteElementB e) 
            { 
                Put(e.GetData());
            }
            public override void VisitConcreteElementC(ConcreteElementC e) 
            {
                Put(e.GetData()); 
            }
        }
        public class ConcreteVisitor2 : Visitor
        {
            public override void VisitConcreteElementA(ConcreteElementA e) { e.SetData(0 - e.GetData()); }
            public override void VisitConcreteElementB(ConcreteElementB e)
            {
                string s = e.GetData();
                string r = "";
                for (int i = s.Length - 1; i >= 0; i--)
                {
                    r += s[i];
                }
                e.SetData(r);
            }
            public override void VisitConcreteElementC(ConcreteElementC e) { e.SetData(1 / e.GetData()); }
        }

        public class ConcreteVisitor3 : Visitor
        {
            public int r1 = 0;
            public string r2 = "";
            public float r3 = 1;
            public ConcreteVisitor3() { }
            public override void VisitConcreteElementA(ConcreteElementA e) { r1 = r1 + (e.GetData()); }
            public override void VisitConcreteElementB(ConcreteElementB e) { r2 = r2 + (e.GetData()); }
            public override void VisitConcreteElementC(ConcreteElementC e) { r3 = r3 * (e.GetData()); }
            public int GetResultA() { return r1; }
            public string GetResultB() { return r2; }
            public float GetResultC() { return r3; }
        }
        public static void Solve()
        {
            Task("OOP3Behav15");
            int n = GetInt();
            Element[] v = new Element[n];
            for (int i = 0; i < n; i++)
            {
                char c = GetChar();
                if (c == 'A')
                {
                    int number = GetInt();
                    v[i] = new ConcreteElementA(number);
                }
                else
                {
                    if (c == 'B')
                    {
                        string str = GetString();
                        v[i] = new ConcreteElementB(str);
                    }
                    else
                    {
                        float f = (float)GetDouble();
                        v[i] = new ConcreteElementC(f);
                    }
                }
            }
            ObjectStructure structure = new ObjectStructure(v);
            ConcreteVisitor1 v1 = new ConcreteVisitor1();
            ConcreteVisitor2 v2 = new ConcreteVisitor2();
            ConcreteVisitor3 v3 = new ConcreteVisitor3();
            structure.Accept(v1);
            structure.Accept(v2);
            structure.Accept(v1);
            structure.Accept(v3);
            Put(v3.GetResultA());
            Put(v3.GetResultB());
            Put(v3.GetResultC());
        }
    }
}

    
