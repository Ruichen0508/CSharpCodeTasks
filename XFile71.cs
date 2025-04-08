using PT4;
using System.IO;
using System;
using System.Globalization;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PT4Tasks
{
    public class MyTask : PT
    {
        static string Test(string date)
        {
            return date.Substring(6, 4) + date.Substring(3, 2) + date.Substring(0, 2);
        }
        public static void Solve()
        {
            Task("XFile71");
            BinaryReader read = new BinaryReader(File.OpenRead(GetString()));
            int sz = (int)read.BaseStream.Length / 81;
            string minre = "";
            DateTime maxtrue = DateTime.MaxValue;
            CultureInfo ci = new CultureInfo("ru-Ru");
            for (int i = 0; i < sz; i++)
            {
                string s = read.ReadString();
                DateTime d = DateTime.Parse(s, ci);
                if (d.Month >= 3 && d.Month <= 5 && maxtrue > d)
                {
                    minre = s;
                    maxtrue = d;
                }
            }
            read.Close();
            Put(minre.Trim());
        }
    }
}