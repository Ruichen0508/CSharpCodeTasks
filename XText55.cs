// File: "XText55"
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
            Task("XText55");
            string read = GetString();
            StreamReader sr = new StreamReader(File.OpenRead(read));
            string out0 = GetString();
            StreamWriter sw = new StreamWriter(File.Create(out0));
            bool[] select = new bool[200];
            for (int i = 0; i < 200; i++)
            {
                select[i] = false;
            }
            while (!sr.EndOfStream)
            {
                string str = sr.ReadLine();
                foreach (char item in str)
                {
                    select[item] = true;
                }

            }
            for (int i = 0; i < 200; i++)
            {
                if (select[i])
                {
                    sw.Write((char)i);
                }
            }
            sr.Close();
            sw.Close();
        }
    }
}