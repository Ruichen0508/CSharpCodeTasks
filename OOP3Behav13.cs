using PT4;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PT4Tasks
{
    public class MyTask : PT
    {
        public abstract class Handler
        {
            public abstract void HandleRequest(int req);
        }

        // Implement the ConcreteHandler1
        //   and ConcreteHandler2 descendant classes

        public class Client
        {
            Handler h;
            public Client(Handler h)
            {
                this.h = h;
            }
            public void SendRequest(int req)
            {
                h.HandleRequest(req);
            }
        }

        public static void Solve()
        {
            Task("OOP3Behav13");

        }
    }
}
