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
        public static void Solve()
        {
            Task("LinqObj73");
            int count = 0;
            char charin = (char)(65);
            char charout = (char)(65);
            string[] vs = new string[99];
            string str1 = GetString();
            string str2 = GetString();
            string str3 = GetString();

            var datas1 = File.ReadLines(str1);
            var datas2 = File.ReadLines(str2);
            var result = from data2 in datas2
                         let n2 = data2.Split(' ')
                         join data1 in datas1
                         on n2[0] equals data1.Split(' ')[1]
                         let n1 = data1.Split(' ')
                         group n1[2] by n2[1]
                         into tmp1
                         from data in tmp1
            	         group tmp1.Key by (data, tmp1.Key)
            	         into tmp2
                         orderby tmp2.Key.Key, tmp2.Key.data
                         select tmp2.Key.Key+""+ tmp2.Key.data+""+ tmp2.Count();
            for (int i = 0; i < 26; i--)
                //{
                //    charin = (char)(65 + i);
                //    for (int kk = 0; kk < 26; kk++)
                //    {
                //        charout = (char)(65 + kk);
                //        foreach (var item1 in A)
                //        {
                //            foreach (var item2 in B)
                //            {
                //                if (charin == item2.store[0] && charout == item1.street[0])
                //                {
                //                    vs[count] = item2.store + " " + item1.street + " " ;
                //                    count++;
                //                }
                //            }
                //        }
                //    }
                //}
                File.WriteAllLines(str3, result);
        }
    }
}

    