    // File: "LinqBegin23"
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
            void Sort(int[] arr)
            {
                int c, j, temp;
                bool done = false;
                j = 1;
                while ((j < arr.Length) && (!done))//�жϳ��ȡ�
                {
                    done = true;
                    for (c = 0; c < arr.Length - j; c++)
                    {
                        if (arr[c] < arr[c + 1] && arr[c] != 0 && arr[c + 1] != 0)
                        {
                            done = false;
                            temp = arr[c];
                            arr[c] = arr[c + 1];//�������ݡ�
                            arr[c + 1] = temp;
                        }
                    }
                    j++;
                }
            }
            Task("LinqBegin23");
            int k = GetInt();
            int add = 0;
            int add1 = 0;
            int[] final = new int[99];
            IEnumerable<int> i = GetEnumerableInt();
            foreach (int item in i)
            {
                if (add >= k - 1 && item % 2 != 0)
                {
                    if ((item < 100 && item > 9) || (item < -9 && item > -100))
                    {
                        final[add1] = item;
                        add1++;
                    }
                }
                add++;
            }
            //Put(add1);
            Sort(final);
            int[] final2 = new int[add1];
            for (int u = 0; u < add1; u++)
            {
                final2[u] = final[u];  
            }
            final2.Put();

        }




    }
}

    
