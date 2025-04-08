    // File: "LinqBegin58"
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
            Task("LinqBegin58");
            IEnumerable<string> i0 = GetEnumerableString();
            int count = 0;
            int count1 = 0;//����ԭ������
            int count2 = 0;//������������
            bool renew = false;
            //string previous = null;
            string[] final = new string[99];
            for (int i = 48; i <= 90; i++)
            {
                foreach (string item in i0)
                {
                    if (item[0] == i)
                    {
                        foreach (char item2 in item)
                        {
                            count2++;
                        }
                        if (count1 < count2)
                        {
                            final[count] = item;
                            count1 = count2;
                            renew = true;
                        }
                        count2 = 0;
                    }
                }
                if (renew)//�и��¾�ǰ��
                {
                    count++;
                }
                renew = false;
                count1 = 0;
            }
            string[] final1 = new string[count];
            for (int r = 0; r < count; r++)
            {
                final1[r] = final[r];
            }

            final1.Put();
        }
    }
}

    
