    // File: "OOP3Behav9"
using PT4;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PT4Tasks
{
    public class MyTask : PT
    {
        public static class OperationA
        {
            public static void ActionA()
            {
                Put("+A");
            }
            public static void UndoActionA()
            {
                Put("-A");
            }
        }

        public static class OperationB
        {
            public static void ActionB()
            {
                Put("+B");
            }
            public static void UndoActionB()
            {
                Put("-B");
            }
        }

        public static class OperationC
        {
            public static void ActionC()
            {
                Put("+C");
            }
            public static void UndoActionC()
            {
                Put("-C");
            }
        }

        public abstract class Command
        {

            public abstract void Execute();
            public abstract void Unexecute();
        }

        public class CommandA : Command
        {
            public override void Execute()
            {
                OperationA.ActionA();
            }

            public override void Unexecute()
            {
                OperationA.UndoActionA();
            }
        }
        public class CommandB : Command
        {
            public override void Execute()
            {
                OperationB.ActionB();
            }

            public override void Unexecute()
            {
                OperationB.UndoActionB();
            }
        }

        public class CommandC : Command
        {

            public override void Execute()
            {
                OperationC.ActionC();
            }

            public override void Unexecute()
            {
                OperationC.UndoActionC();
            }
        }

        public class MacroCommand : Command
        {

            List<Command> cmds = new List<Command>();

            public MacroCommand(List<Command> commands)
            {
                cmds = commands;
            }
            public override void Execute()
            {
                for (int i = 0; i < cmds.Count; i++)
                {
                    cmds[i].Execute();
                }
            }

            public override void Unexecute()
            {
                for (int i = cmds.Count - 1; i >= 0; i--)
                {
                    cmds[i].Unexecute();
                }
            }
        }

        public class Menu
        {
            Command[] availCmds = new Command[3];
            List<Command> lastCmds = new List<Command>();
            int undoIndex;
            public Menu(Command cmd1, Command cmd2)
            {
                availCmds[0] = cmd1;
                availCmds[1] = cmd2;
                List<Command> commands = new List<Command>();
                commands.Add(cmd1);
                commands.Add(cmd2);
                availCmds[2] = new MacroCommand(commands);
            }
            public void Invoke(int cmdIndex)
            {
                availCmds[cmdIndex].Execute();
                Show(availCmds[cmdIndex].ToString() + "I___");
                for (int i = 0; i < lastCmds.Count; i++)
                {
                    if (i >= undoIndex + 1)
                    {
                        Show("Delet-----undoIndex=" + lastCmds.Count + "----" + undoIndex + "--- " + i + "---- " + lastCmds[i].ToString() + "---");
                        for (int j = 0; j < lastCmds.Count; j++)
                        {
                            Show(lastCmds[j].ToString());
                        }
                        lastCmds.RemoveRange(i, lastCmds.Count - 1 - undoIndex);
                        for (int j = 0; j < i; j++)
                        {
                            Show(lastCmds[j].ToString());
                        }
                    }
                }
                lastCmds.Add(availCmds[cmdIndex]);
                Show("/Count" + lastCmds.Count + "/");
                undoIndex = lastCmds.Count - 1;
                Show("/" + undoIndex + "/");
            }
            public void Undo(int count)
            {
                int d = undoIndex - count;
                for (int i = undoIndex; i > d && i >= 0; i--)
                {
                    lastCmds[i].Unexecute();
                    Show(lastCmds[i].ToString() + "U___" + i);

                }
                if (undoIndex - count < 0)
                {
                    undoIndex = -1;
                }
                else
                {
                    undoIndex = undoIndex - count;
                    Show("/ UndoIndex " + undoIndex + "/");
                }

            }
            public void Redo(int count)
            {
                int d = undoIndex + count;
                for (int i = undoIndex + 1; d >= i && i < lastCmds.Count; i++)
                {
                    lastCmds[i].Execute();
                    Show(lastCmds[i].ToString() + "R___" + i);
                }
                if (undoIndex + count >= lastCmds.Count)
                {
                    undoIndex = lastCmds.Count - 1;
                }
                else
                {
                    undoIndex = undoIndex + count;
                    Show("/" + undoIndex + "/");

                }
            }

        }
        public static void Solve()
        {
            Task("OOP3Behav9");
            char C1, C2;
            int N;
            C1 = GetChar();
            C2 = GetChar();
            N = GetInt();
            string[] str = new string[N];
            for (int i = 0; i < N; i++)
            {
                str[i] = GetString();
            }
            Command cmd1 = new CommandA();
            Command cmd2 = new CommandA();
            switch (C1)
            {
                case 'A':
                    cmd1 = new CommandA();
                    break;
                case 'B':
                    cmd1 = new CommandB();
                    break;
                case 'C':
                    cmd1 = new CommandC();
                    break;
            }
            switch (C2)
            {
                case 'A':
                    cmd2 = new CommandA();
                    break;
                case 'B':
                    cmd2 = new CommandB();
                    break;
                case 'C':
                    cmd2 = new CommandC();
                    break;
            }
            Menu menu = new Menu(cmd1, cmd2);
            for (int i = 0; i < N; i++)
            {
                string test = str[i];
                char d = test[1];
                switch (test[0])
                {
                    case 'I':
                        menu.Invoke(int.Parse(d.ToString()));
                        break;
                    case 'U':
                        menu.Undo(int.Parse(d.ToString()));
                        break;
                    case 'R':
                        menu.Redo(int.Parse(d.ToString()));
                        break;
                }
            }

        }
    }
}
    
