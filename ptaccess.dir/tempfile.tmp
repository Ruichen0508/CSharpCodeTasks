    // File: "OOP1Creat6"
using PT4;
using System.Collections;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace PT4Tasks
{
    public class MyTask : PT
    {
        public abstract class BaseClass
        {
            int data;
            public void IncData(int increment)
            {
                data += increment;
            }
            public int GetData()
            {
                return data;
            }
        }

        public class Singleton : BaseClass
        {
            static Singleton uniqueInstance = null;
            static int cnt = 0;
            Singleton() { cnt++; }
            public static void Reset()
            {
                uniqueInstance = null;
                cnt = 0;
            }
            // Complete the implementation of the class
            public static Singleton instance()
            {
                if (uniqueInstance == null)
                {
                    uniqueInstance = new Singleton();
                }
                return uniqueInstance;
            }
            

            public static int GetCount()
            {
                return cnt;
            }
        }

        public class Doubleton : BaseClass
        {
            static Doubleton[] instances = new Doubleton[2];
            static int cnt = 0;
            Doubleton() { cnt++; }
            public static void Reset()
            {
                instances[0] = instances[1] = null;
                cnt = 0;
            }
            // Complete the implementation of the class
            public static Doubleton instance(int index)
            {
                if(instances[index] == null)
                {
                    instances[index] = new Doubleton();
                }
                return instances[index];    
            }
            public static int GetCount()
            {
                return cnt;
            }
        }

        public class Tenton : BaseClass
        {
            static Tenton[] instances = new Tenton[10];
            static int cnt = 0;
            Tenton() { cnt++; }
            public static void Reset()
            {
                for (int i = 0; i < instances.Length; i++)
                    instances[i] = null;
                cnt = 0;
            }
            // Complete the implementation of the class
            public static Tenton instance(int index)
            {
                if(instances[index]==null)
                {
                    instances[index]=new Tenton();
                }
                return instances[index]; 
            }
            public static int GetCount()
            {
                return cnt;
            }

        }

        public static void Solve()
        {
            Task("OOP1Creat6");
            ArrayList ab = new ArrayList();
            int N=GetInt();
            string s;
            for(int i = 0; i < N; i++)
            {
                s = GetString();
                BaseClass item = null;
                if (s[0] == 'S')
                {
                    item = Singleton.instance();
                }
                else if (s[0] =='D')
                {
                    item = Doubleton.instance(s[1] - '1');
                }
                else if (s[0] =='T')
                {
                    item = Tenton.instance(s[1] - '0');
                }
                ab.Add(item);
            }
            int K = GetInt();
            for (int i = 0; i < K; i++)
            {
                int a = GetInt(), b = GetInt();
                ((BaseClass)ab[a]).IncData(b);
            }
          
            Put(Singleton.GetCount(), Doubleton.GetCount(), Tenton.GetCount());
            foreach(BaseClass e in ab)
            {
                Put(e.GetData());
            }
            Singleton.Reset();
            Doubleton.Reset();
            Tenton.Reset();
        }
    }
}

    
