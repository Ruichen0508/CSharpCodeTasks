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
            Task("XFile35");
            int count = 0;
            int head = 0;
            byte[] a = new Byte[4];
            a[0] = (byte)0;
            a[1] = (byte)0;
            a[2] = (byte)0;
            a[3] = (byte)0;
            string s0 = GetString(), s1 = "dd";
            FileStream F1 = new FileStream(s0, FileMode.Open, FileAccess.ReadWrite);
            FileStream F0 = new FileStream(s1, FileMode.Create, FileAccess.ReadWrite);

            System.BitConverter.ToInt32(a, 0);
            count = (int)F1.Length / 4;
            count = 50 - count; 
            a[0] = (byte)0;
            a[1] = (byte)0;
            a[2] = (byte)0;
            a[3] = (byte)0;


            for (int i = 0; i < count; i++)
            {
                a = new Byte[4];
                F0.Write(a, 0, 4);
            }

            count = (int)F1.Length / 4;
            
            for (int i = 0; i < count; i++)
            {
                F1.Seek(head, SeekOrigin.Begin);
                F1.Read(a, 0, 4);
                head += 4;
                F0.Write(a, 0, 4);
            }

            F0.Close(); F1.Close();
            File.Delete(s0);
            File.Move(s1, s0);
        }
    }
}