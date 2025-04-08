using PT4;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace PT4Tasks
{
    public class MyTask : PT
    {
        // To read strings from the source text file into
        // a string sequence (or array) s, use the statement:
        //   s = File.ReadLines(GetString());
        // To write the sequence s of IEnumerable<string> type
        // into the resulting text file, use the statement:
        //   File.WriteAllLines(GetString(), s);
        // When solving tasks of the LinqObj group, the following
        // additional methods defined in the taskbook are available:
        // (*) Show() and Show(cmt) (extension methods) - debug output
        //       of a sequence, cmt - string comment;
        // (*) Show(e => r) and Show(cmt, e => r) (extension methods) -
        //       debug output of r values, obtained from elements e
        //       of a sequence, cmt - string comment.

        public static void Solve()
        {
            Task("LinqObj3");
            string filename = GetString();
            string[] s1 = File.ReadAllLines(filename);
            System.Collections.Generic.IEnumerable<int[]> s2 = s1.Select(s => new[] { int.Parse(s.Split(' ')[0]), int.Parse(s.Split(' ')[2]) });
            string[] s3 = s2.GroupBy(x => x[0]).Select(x => new { year = x.Key, item = x.Sum(y => y[1]) }).OrderByDescending(y => y.item).ThenBy(y => y.year).Select(e => new[] { e.year.ToString() + ' ' + e.item.ToString() }).First();
            File.WriteAllLines(GetString(), s3);
        }
    }
}