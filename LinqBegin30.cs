    // File: "LinqBegin30"
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
            Task("LinqBegin30");
            int k = GetInt();
            int add = 0;
            int add1 = 0;
            int add2 = 0;
            int add3 = 0;
            int add4 = 0;
            int add5 = 0;
            int[] select = new int[99];
            int[] select1 = new int[99];
            IEnumerable<int> i = GetEnumerableInt();
            foreach (int item in i)
            {
                if (item % 2 == 0)
                {
                    select[add1] = item;
                    add1++;
                }
                if (add >= k)
                {
                    select1[add2] = item;
                    add2++;
                }
                add++;
            }
            for (int t = 0; t < 99; t++)
            {
                for (int f = 0; f < 99; f++)
                {
                    if (select[t] == select1[f])
                    {
                        select[t] = 0;
                    }
                }
            }
            //select.Put();
            for (int v = 0; v < 99; v++)
            {
                for (int l = 0; l < 99; l++)
                {
                    if (select[v] == select[l] && v != l)
                    {
                        select[v] = 0;
                    }
                }
            }
            foreach (int item in select)
            {
                if (item != 0)
                {
                    add4++;
                }
            }
            //Put(add4);
            int[] final = new int[add4];
            foreach (int item in select)
            {
                if (item != 0)
                {
                    final[add4-1] = item;
                    add4--;
                }
            }
            
            final.Put();

        }
    }
}

    
