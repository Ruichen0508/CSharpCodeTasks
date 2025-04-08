using PT4;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PT4Tasks
{
    public class MyTask : PT
    {
        // Implement the Client, ReceiverA and ReceiverB classes

        public abstract class Command
        {
            public abstract void Execute();
        }

        // Implement the ConcreteCommandA
        //   and ConcreteCommandB descendant classes

        public class Invoker
        {
            Command cmd;
            public Invoker(Command cmd)
            {
                this.cmd = cmd;
            }
            public void Invoke()
            {
                cmd.Execute();
            }
        }

        public static void Solve()
        {
            Task("OOP3Behav8");

        }
    }
}
