    // File: "LinqBegin53"
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
                        if (arr[c] > arr[c + 1] && arr[c] != 0 && arr[c + 1] != 0)
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
            Task("LinqBegin53");
            int[] select = new int[99];
            int[] final = new int[999];
            final[0] = -1;
            bool judge = true;
            int count = 0;
            IEnumerable<int> i0 = GetEnumerableInt();
            IEnumerable<int> i1 = GetEnumerableInt();
            foreach (int item in i0)
            {
                foreach (int item2 in i1)
                {
                    for (int i = 0; i < count; i++)
                    {
                        if (final[i] == (item + item2))
                        {
                            judge = false;
                            break;
                        }
                    }
                    if (judge)
                    {
                        final[count] = (item + item2);
                        count++;
                    }
                    else
                    {
                        judge = true;
                    }
                }
            }
            int[] final1 = new int[count];
            for (int i = 0; i < count; i++)
            {
                final1[i] = final[i];
            }
            Sort(final1);
            final1.Put();
            //final.Put();
        }
    }
}

    
