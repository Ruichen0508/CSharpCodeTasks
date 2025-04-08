    // File: "LinqBegin35"
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
            Task("LinqBegin35");
            //int k = GetInt();
            int count = 0;
            int count1 = 0;
            int[] select0 = new int[99];
            IEnumerable<int> i = GetEnumerableInt();
            foreach (int item in i)
            {
                select0[count] = item;
                count++;
            }
            int[] select = new int[count];
            for (int t = 0; t < count; t++)
            {
                select[t] = select0[t] * (t + 1);
            }
            //select.Put();  
            for (int t = 0; t < count; t++)
            {
                if ((select[t] < 100 && select[t] > 9) || (select[t] < -9 && select[t] > -100))
                {
                    count1++;
                }
                else
                {
                    select[t] = 0;
                }
            }
            int[] final = new int[count1];
            for (int r = 0; r < count; r++)
            {
                if (select[r] != 0)
                {
                    final[count1 - 1] = select[r];
                    count1--;
                }
            }
            final.Put();
        }
    }
}

    
