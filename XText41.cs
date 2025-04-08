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
            Task("XText41");
            FileStream F1 = new FileStream(GetString(), FileMode.OpenOrCreate, FileAccess.ReadWrite);
            FileStream F2 = new FileStream(GetString(), FileMode.OpenOrCreate, FileAccess.ReadWrite);
            FileStream F3 = new FileStream(GetString(), FileMode.OpenOrCreate, FileAccess.ReadWrite);
            FileStream F0 = new FileStream(GetString(), FileMode.OpenOrCreate, FileAccess.ReadWrite);
            long number = F1.Length / 4;
            string[] kongge = new String[4];
            kongge[0] = "                   ";//-1
            kongge[1] = "                  ";
            kongge[2] = "                 ";//+1
            kongge[3] = "                ";//+2

            for (int i = 0; i < number; i++)
            {
                string[] str = new string[number];
                byte[] a = new Byte[4];
                byte[] b = new Byte[4];
                byte[] c = new Byte[4];
                F1.Seek(4 * i, SeekOrigin.Begin);
                F1.Read(a, 0, 4);
                F2.Seek(4 * i, SeekOrigin.Begin);
                F2.Read(b, 0, 4);
                F3.Seek(4 * i, SeekOrigin.Begin);
                F3.Read(c, 0, 4);
                int k1 = 0, k2 = 0, k3 = 0;
                int number1 = System.BitConverter.ToInt16(a, 0);
                int number2 = System.BitConverter.ToInt16(b, 0);
                int number3 = System.BitConverter.ToInt16(c, 0);
                if (Math.Abs(number1) > 0 && Math.Abs(number1) < 10)
                    k1 = 0;
                else if (Math.Abs(number1) >= 10 && Math.Abs(number1) < 100)
                    k1 = 1;
                else if (Math.Abs(number1) >= 80)
                    k1 = 2;

                if (Math.Abs(number2) > 0 && Math.Abs(number2) < 10)
                    k2 = 0;
                else if (Math.Abs(number2) >= 10 && Math.Abs(number2) < 100)
                    k2 = 1;
                else if (Math.Abs(number2) >= 100)
                    k2 = 2;

                if (Math.Abs(number3) > 0 && Math.Abs(number3) < 10)
                    k3 = 0;
                else if (Math.Abs(number3) >= 10 && Math.Abs(number3) < 100)
                    k3 = 1;
                else if (Math.Abs(number3) >= 100)
                    k3 = 2;
                if (number1 < 0)
                    k1++;
                if (number2 < 0)
                    k2++;
                if (number3 < 0)
                    k3++;

                str[i] = "|" + number1.ToString() + kongge[k1] + number2.ToString() + kongge[k2] + number3.ToString() + kongge[k3] + '|' + '\n';
                byte[] bytes = new UTF8Encoding(true).GetBytes(str[i]);
                F0.Write(bytes, 0, bytes.Length);
                Show(number1);
                Show(k1);

                Show(number2);
                Show(k2);

                Show(number2);
                Show(k2);
                k1 = 0;
                k2 = 0;
                k3 = 0;
            }
            F0.Close();


        }
    }
}