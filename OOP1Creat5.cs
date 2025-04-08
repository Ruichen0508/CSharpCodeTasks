    // File: "OOP1Creat5"
using PT4;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PT4Tasks
{
    public class MyTask : PT
    {
        public abstract class AbstractButton
        {
            public abstract string GetControl();
        }

        // Implement the Button1 and Button2 descendant classes
        public class Button1 : AbstractButton
        {
            string text;
            public Button1(string t)
            {
                text = t;
            }
            public override string GetControl()
            {
                string temp="";
                temp+="[";
                string t;
                t = this.text;
                t = t.ToUpper();
                temp += t;
                temp+="]";
                return temp;
            }
        }
        public class Button2 : AbstractButton
        {
            string text;
            public Button2(string t)
            {
                text = t;
            }
            public override string GetControl()
            {
                string temp = "";
                temp += "<";
                string t;
                t = this.text;
                t = t.ToLower();
                temp += t;
                temp += ">";
                return temp;
            }
        }
        public abstract class AbstractLabel
        {
            public abstract string GetControl();
        }

        // Implement the Label1 and Label2 descendant classes
        public class Label1 : AbstractLabel
        {
            string text;
            public Label1(string t)
            {
                text = t;
            }
            public override string GetControl()
            {
                string temp = "";
                temp += "=";
                string t;
                t = this.text;
                t = t.ToUpper();
                temp += t;
                temp += "=";
                return temp;
            }
        }
        public class Label2 : AbstractLabel
        {
            string text;
            public Label2(string t)
            {
                text = t;
            }
            public override string GetControl()
            {
                string temp = "";
                temp += "\"";
                string t;
                t = this.text;
                t = t.ToLower();
                temp += t;
                temp += "\"";
                return temp;
            }
        }
        public abstract class ControlFactory
        {
            public abstract AbstractButton CreateButton(string text);
            public abstract AbstractLabel CreateLabel(string text);
        }

        // Implement the Factory1 and Factory2 descendant classes
        public class Factory1 : ControlFactory
        {
            public override AbstractButton CreateButton(string text)
            {
                return new Button1(text);

            }
            public override AbstractLabel CreateLabel(string text)
            {
                return new Label1(text);
            }
        }
        public class Factory2 : ControlFactory
        {
            public override AbstractButton CreateButton(string text)
            {
                return new Button2(text);

            }
            public override AbstractLabel CreateLabel(string text)
            {
                return new Label2(text);
            }
        }
        public class Client
        {
            // Add required fields
            ControlFactory cf;
            string totalcontrol;
            public Client(ControlFactory f)
            {
                // Implement the constructor
                this.cf = f;
            }
            public void AddButton(string text)
            {
                // Implement the method
                this.totalcontrol+=this.cf.CreateButton(text).GetControl();
                this.totalcontrol+=" ";

            }
            public void AddLabel(string text)
            {
                // Implement the method
                this.totalcontrol+=this.cf.CreateLabel(text).GetControl();
                this.totalcontrol+=" ";
            }
            public string GetControls()
            {
                return this.totalcontrol.Substring(0, this.totalcontrol.Length - 1);
                // Remove the previous statement and implement the method
            }
        }

        public static void Solve()
        {
            Task("OOP1Creat5");
            int N = GetInt();
            ControlFactory cf1 = new Factory1();
            ControlFactory cf2 = new Factory2();
            Client c1 = new Client(cf1);
            Client c2 = new Client(cf2);
            for (int i = 0; i < N; i++)
            {
                string a = GetString();
                if (a[0] == 'B')
                {
                    string t = a.Substring(2, a.Length - 2);
                    c1.AddButton(t);
                    c2.AddButton(t);
                }
                else if (a[0] == 'L')
                {
                    string t = a.Substring(2, a.Length - 2);
                    c1.AddLabel(t);
                    c2.AddLabel(t);
                }
            }
            Put(c1.GetControls(), c2.GetControls());

        }
    }
}

    
