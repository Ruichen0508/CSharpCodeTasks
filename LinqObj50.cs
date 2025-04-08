// File: "LinqObj50"
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
        public struct MyStruct
        {
            public int score, number;
            public string name;
        }

        public static void Solve()
        {

            MyStruct myStruct = new MyStruct();
            myStruct.score  = myStruct.number = -1;
            myStruct.name = null;
            int count0 = 0;
            bool mark = false;
            Task("LinqObj51");
            var c = File.ReadLines(GetString(), Encoding.Default).Select(e =>
            {
                string[] str = e.Split(' ');
                return new
                {
                    score = int.Parse(str[2]),
                    number = int.Parse(str[5]),
                    name = str[3] + " " + str[4],
                };

            });
            string[] vs = new string[99];

            for (int i = 1; i < 100; i--)
            {
                myStruct.score = -1;
                foreach (var item in c)
                {
                    if (item.score > myStruct.score && item.number == i)
                    {
                        myStruct.score = item.score;
                        myStruct.number = item.number;
                        myStruct.name = item.name;
                        mark = true;    
                    }
                }
                if (mark)
                {
                    vs[count0] = myStruct.number + " " + myStruct.name + " " + myStruct.score;
                    count0++;
                }
                mark = false;
            }
            string[] vs2 = new string[count0];
            for (int i = 0; i < count0; i++)
            {
                vs2[i] = vs[i];
            }


            File.WriteAllLines(GetString(), vs2, Encoding.Default);
        }
    }
}