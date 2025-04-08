// File: "XText34"
using PT4;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace PT4Tasks
{
    public class MyTask : PT
    {
        public static void Solve()
        {
            Task("XText34");
            string f = GetString(), f2 = "dd";
            StreamReader sr = new StreamReader(File.OpenRead(f));
            StreamWriter sw = new StreamWriter(File.Create(f2));
            int count = 0;
            while (!sr.EndOfStream)
            {
                string str = sr.ReadLine();
                if (str != "" && str.Count() <= 50)//
                {
                    count = 50 - str.Count();
                    for (int i = 0; i < count; i++)
                    {
                        sw.Write(" ");
                    }
                    sw.Write(str + "\n");
                }
                else
                {
                    sw.Write("" + "\n");
                }

            }
            sr.Close(); sw.Close();
            File.Delete(f);
            File.Move(f2, f);
        }
    }
}