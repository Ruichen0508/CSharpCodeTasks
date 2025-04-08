    // File: "XString48"
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
            Task("XString48");
            string str1 = GetString();
            char[] final = new char[100];
            string str2 = str1;
            char know = str1[0];
            for (int i = 0; i < str1.Length; i++)
            {
                if (str1[i] == ' ' && str1[i + 1] != ' ')
                {
                    know = str1[i + 1];
                }
                if (str1[i] == know && i != 0)
                {
                    if (str1[i - 1] != ' ')
                    {
                        final[i] = '.';
                    }
                    else
                    {
                        final[i] = str1[i];
                    }
                }
                else
                {
                    final[i] = str1[i];
                }
            }
            string strIds = string.Join("", final);
            Put(strIds);
        }
    }
}

    
