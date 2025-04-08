// File: "XString60"
using PT4;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PT4Tasks
{
    public class MyTask : PT
    {
        public static void Solve()
        {
            Task("XString60");
            string str1 = GetString();
            string[] str = str1.Split('\\');
            if (str.Length <= 2)
            {
                str[1] = '\\'+"";
            }
            Put(str[1]);
            Show(str);
        }
    }
}