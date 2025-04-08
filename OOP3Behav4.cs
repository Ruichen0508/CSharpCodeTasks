using PT4;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PT4Tasks
{
    public class MyTask : PT
    {
        public class Validator
        {
            public virtual string Validate(string s)
            {
                return "";
            }
        }

        // Implement the EmptyValidator, NumberValidator
        //   and RangeValidator descendant classes
        public class EmptyValidator : Validator
        {
            public override string Validate(string s)
            {
                if (s.Length == 0)
                {
                    return "!Empty text";
                }
                return "";
            }
        }
        public class NumberValidator : Validator
        {

            public override string Validate(string s)
            {
                int num;
                bool isNum = int.TryParse(s, out num);
                if (isNum)
                {
                    return "";
                }
                return "!'" + s + "': not a number";
            }
        }
        public class RangeValidator : Validator
        {
            int min, max;
            public RangeValidator(int x, int y)
            {
                if (x < y)
                {
                    min = x; max = y;
                }
                else
                {
                    min = y; max = x;
                }
            }
            public override string Validate(string s)
            {
                int num;
                bool isNum = int.TryParse(s, out num);
                if (isNum && num >= min && num <= max)
                {
                    return "";
                }
                return "!'" + s + "': not in range " + min + ".." + max;
            }
        }
        // Implement the TextBox and TextForm classes

        public class TextBox
        {
            string text;
            Validator v;
            public TextBox()
            {
                v = new Validator();
                text = "";
            }
            public void SetText(string text)
            {
                this.text = text;
            }
            public void SetValidator(Validator v)
            {
                this.v = v;
            }
            public string Validate()
            {
                return v.Validate(text);
            }
        }

        public class TextForm
        {
            TextBox[] tb;

            public TextForm(int N)
            {
                tb = new TextBox[N];
                for (int i = 0; i < N; i++)
                {
                    tb[i] = new TextBox();
                }
                    
            }
            public void SetText(int ind, string text)
            {
                tb[ind].SetText(text);
            }
            public void SetValidator(int ind, Validator v)
            {
                tb[ind].SetValidator(v);
            }
            public string Validate()
            {
                string str = "";
                for (int i = 0; i < tb.Length; i++)
                {
                    str += tb[i].Validate();
                }
                return str;
            }
        }
        public static void Solve()
        {
            Task("OOP3Behav4");
            int n = GetInt(),a = GetInt(), b = GetInt(), n1 = GetInt();
            int[] arri = new int[n1];
            char[] c = new char[n1];

            for (int i = 0; i < n1; i++)
            {
                arri[i] = GetInt();
                c[i] = GetChar();
            }

            string[] s1 = new string[n];
            for (int i = 0; i < n; i++)
            {
                s1[i] = GetString();
            }

            string[] s2 = new string[n];
            for (int i = 0; i < n; i++)
            {
                s2[i] = GetString();
            }

            string[] s3 = new string[n];
            for (int i = 0; i < n; i++)
            {
                s3[i] = GetString();
            }

            string[] s4 = new string[n];
            for (int i = 0; i < n; i++)
            {
                s4[i] = GetString();
            }

            string[] s5 = new string[n];
            for (int i = 0; i < n; i++)
            {
                s5[i] = GetString();
            }

            TextForm tf = new TextForm(n);

            for (int i = 0; i < n1; i++)
            {
                if (c[i] == 'E')
                {
                    tf.SetValidator(arri[i], new EmptyValidator());
                }
                else if (c[i] == 'R')
                {
                    tf.SetValidator(arri[i], new RangeValidator(a, b));
                }
                else
                {
                    tf.SetValidator(arri[i], new NumberValidator());
                }
            }

            for (int i = 0; i < n; i++)
            {
                tf.SetText(i, s1[i]);
            }
            Put(tf.Validate());
            for (int i = 0; i < n; i++)
            {
                tf.SetText(i, s2[i]);
            }
            Put(tf.Validate());

            for (int i = 0; i < n; i++)
            {
                tf.SetText(i, s3[i]);
            }
            Put(tf.Validate());
            for (int i = 0; i < n; i++)
            {
                tf.SetText(i, s4[i]);
            }
            Put(tf.Validate());
            for (int i = 0; i < n; i++)
            {
                tf.SetText(i, s5[i]);
            }
            Put(tf.Validate());

        }
    }
}
