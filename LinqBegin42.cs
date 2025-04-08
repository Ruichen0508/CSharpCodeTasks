    // File: "LinqBegin42"
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
            Task("LinqBegin42");
            IEnumerable<string> i = GetEnumerableString();
            string[] select = new string[99];
            //char[] select2 = new char[5] { '5', 'f', 'f', 's', 's' };
            //char[] testselect = new char[5] { select[0][0], 'f', 'f', 's', 's' };
            char[] final = new char[99];
            int count = 0;
            int count1 = 0;
            foreach (string item in i)
            {
                select[count] = item;
                count++;
            }
            for (int t = 0; t < count; t++)
            {
                foreach (char item in select[t])
                {
                    if ((t + 1) % 2 == 0)//ż��Сд
                    {
                        if (97 <= item && item <= 122)
                        {
                            final[count1] = item;
                            count1++;
                        }
                    }
                    else//������д
                    {
                        if (65 <= item && item <= 90)
                        {
                            final[count1] = item;
                            count1++;
                        }
                    }
                }
            }
            char[] final1 = new char[count1];
            for (int r = 0; r < count1; r++)
            {
                final1[r] = final[r];
            }
            final1.Put();
            //final1.Put();
        }
    }
}

    
