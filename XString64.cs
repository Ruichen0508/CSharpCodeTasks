    // File: "XString64"
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
            Task("XString64");
            string str1 = GetString();
            char[] final = new char[str1.Length];
            //int a = Convert.ToInt32(str1);
            int i = GetInt();
            int i2;
            for (int j = 0; j < str1.Length; j++)
            {
                if (str1[j] <= 64 || (str1[j] >= 91 && str1[j] <= 96) || str1[j] >= 123)
                {
                    final[j] = str1[j];
                }
                else
                {
                    if (str1[j] - i < 97 && str1[j] >= 97)
                    {
                        //i2 = 123 - (97 - (str1[j] - i));
                        i2 = 26 + str1[j] - i;
                    }
                    else if (str1[j] - i < 65 && str1[j] >= 65)
                    {
                        //i2 = 123 - (97 - (str1[j] - i));
                        i2 = 26 + str1[j] - i;
                    }
                    else
                    {
                        i2 = str1[j] - i;
                    }
                    final[j] = (char)(i2);
                }//65 <= str1[j] && str1[j] <= 90 && 97 <= str1[j] && str1[j] <= 122
            }
            string strIds = string.Join("", final);
            Put(strIds);
        }
    }
}

    
