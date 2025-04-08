    // File: "LinqBegin1"
using PT4;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PT4Tasks
{
    public class MyTask : PT
    {
        // When solving tasks of the LinqBegin group, the following
        // additional methods defined in the taskbook are available:
        // (*) GetEnumerableInt() - input of a numeric sequence;
        // (*) GetEnumerableString() - input of a string sequence;
        // (*) Put() (extension method) - output of a sequence;
        // (*) Show() and Show(cmt) (extension methods) - debug output
        //       of a sequence, cmt - string comment;
        // (*) Show(e => r) and Show(cmt, e => r) (extension methods) -
        //       debug output of r values, obtained from elements e
        //       of a sequence, cmt - string comment.

        public static void Solve()
        {
            Task("LinqBegin1");
            int max = 999, min = -999;
            IEnumerable<int> i = GetEnumerableInt();
            foreach (int item in i)
            {
                if (item > 0)
                {
                    max = item;
                    break;
                }
            }
            foreach (int item in i)
            {
                if (item < 0)
                {
                    min = item;
                }
            }
            Put(max);
            Put(min);
        }
    }
}

    
