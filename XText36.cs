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
            Task("XText36");
            string a=GetString();
            string []str=File.ReadAllLines(a);
            StreamWriter w1=new StreamWriter(a);
            long number=str.Length;
            for(int i=0;i<number;i++)
            {
             if(str[i].Length==0)
             {
              w1.WriteLine(str[i]);
              continue;
             }
             for(int j=0;j<str[i].Length;j++)
             {
              if(str[i][j]!=' ')
              {
               if(j%2==0)
                w1.WriteLine(str[i].Substring(j/2));
               else
                w1.WriteLine(str[i].Substring(j/2+1));
               break;
              }
              
             }
             
            }
            w1.Close();
        }
    }
}