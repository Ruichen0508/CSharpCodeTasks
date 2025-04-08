// File: "XText45"
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
            Task("XText45");
            string read = GetString();
            StreamReader sr = new StreamReader(File.OpenRead(read));
            int count = 0;
            double finalcount = 0;
            string turn;
            while (!sr.EndOfStream)
            {
                string str = sr.ReadLine();
                turn = str;
                foreach (char item in str)
                {
                    if (item == 46)
                    {
                        turn = turn.Trim();
                        finalcount += Convert.ToDouble(turn);
                        count++;
                        break;
                    }
                }

            }
            sr.Close();
            Put(count);
            Put(finalcount);
        }
    }
}