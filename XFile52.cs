// File: "XFile52"
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
            Task("XFile52");
            int count = 0;
            int head = 0;
            byte[] a = new Byte[4];
            string s0 = GetString();
            FileStream F0 = new FileStream(s0, FileMode.Create, FileAccess.ReadWrite);
            int N = GetInt();
            FileStream[] fileStreams = new FileStream[N];
            for (int i = 0; i < N; i++)
            {
                fileStreams[i] = new FileStream(GetString(), FileMode.Open, FileAccess.ReadWrite);
            }

            a[0] = (byte)N;
            a[1] = (byte)0;
            a[2] = (byte)0;
            a[3] = (byte)0;
            F0.Write(a, 0, 4);
            for (int i = 0; i < N; i++)
            {
                count = (int)fileStreams[i].Length / 4;
                a[0] = (byte)count;
                a[1] = (byte)0;
                a[2] = (byte)0;
                a[3] = (byte)0;
                F0.Write(a, 0, 4);
            }


            for (int qq = 0; qq < N; qq++)
            {
                head = 0;
                for (int i = 0; i < fileStreams[qq].Length / 4; i++)
                {
                    fileStreams[qq].Seek(head, SeekOrigin.Begin);
                    head += 4;
                    fileStreams[qq].Read(a, 0, 4);
                    F0.Write(a, 0, 4);
                }
            }

            F0.Close();
            for (int i = 0; i < N; i++)
            {
                fileStreams[i].Close();
            }
        }
    }
}