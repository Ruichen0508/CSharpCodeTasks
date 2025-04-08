    // File: "XString29"
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
            Task("XString29");
            char char0 = GetChar();
            char[] final = new char[100];
            int count = 0;
            int char0ascii = (int)char0;
            string str2 = GetString();
            string str3 = GetString();
            //string str4 = str3 + char0;
            //Put(str4);
            foreach (char eachchar in str2)
            {
                int eachcharint = (int)eachchar;
                if (eachcharint == char0ascii)
                {
                    foreach (char eachchar2 in str3)
                    {
                        final[count] = eachchar2;
                        count++;
                    }
                }
                final[count] = eachchar;
                count++;
            }
            string strIds = string.Join("", final);
            Put(strIds);
            //string str4 = str2 + str1 + str3;
            //Put(str4);
        }
    }
}

    
