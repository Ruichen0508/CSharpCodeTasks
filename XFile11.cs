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
            Task("XFile11");
            int count = 0;
            int head = 0;
            bool is2 = true;
            byte[] a = new Byte[8];
            string s0 = GetString();
            string s1 = GetString();
            string s2 = GetString();
            FileStream F0 = new FileStream(s0, FileMode.Open, FileAccess.ReadWrite);
            FileStream F1 = new FileStream(s1, FileMode.Create, FileAccess.ReadWrite);
            FileStream F2 = new FileStream(s2, FileMode.Create, FileAccess.ReadWrite);

            count = (int)F0.Length / 8;
            for (int i = 0; i < count; i++)
            {
                F0.Seek(head, SeekOrigin.Begin);
                F0.Read(a, 0, 8);
                if (is2)
                {
                    F1.Write(a, 0, 8);
                    is2 = !is2;
                }
                else
                {
                    F2.Write(a, 0, 8);
                    is2 = !is2;
                }
                head += 8;
            }

            F0.Close();
            F1.Close();
            F2.Close();
        }
    }
}