using PT4;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PT4Tasks
{
    public class MyTask : PT
    {
        public abstract class State
        {
            public abstract string GetNextToken();
        }

        class ConcreteStateNormal : State
        {
            Context ctr;
            int ind;
            public ConcreteStateNormal(Context ctr, int ind)
            {
                this.ctr = ctr;
                this.ind = ind;
            }
            public override string GetNextToken()
            {
                State str = null;
                string info = "";
                bool j = false;
                while (ctr.GetCharAt(ind) != '.')
                {
                    switch (ctr.GetCharAt(ind))
                    {
                        case '"':
                            j = true;
                            str = new ConcreteStateString(ctr, ind + 1);
                            break;
                        case '{':
                            j = true;
                            str = new ConcreteStateComm(ctr, ind + 1);
                            break;
                        default:
                            break;
                    }
                    if (j)
                        break;
                    info = info + ctr.GetCharAt(ind);
                    ind++;
                }
                if (ctr.GetCharAt(ind) == '.') str = new ConcreteStateFin();
                ctr.SetState(str);
                return "Normal:" + info;

            }
            class ConcreteStateString : State
            {
                Context ctr;
                int ind;
                public ConcreteStateString(Context ctr, int ind)
                {
                    this.ctr = ctr;
                    this.ind = ind;
                }
                public override string GetNextToken()
                {
                    State str = null;
                    string info = "";
                    bool j2 = false;
                    while (ctr.GetCharAt(ind) != '.')
                    {
                        switch (ctr.GetCharAt(ind))
                        {
                            case '"':
                                if (ctr.GetCharAt(ind + 1) != '"')
                                {
                                    j2 = true;
                                    str = new ConcreteStateNormal(ctr, ind + 1);
                                }
                                else ind++;
                                break;
                            default:
                                break;
                        }
                        if (j2) break;
                        info = info + ctr.GetCharAt(ind);
                        ind++;
                    }
                    if (ctr.GetCharAt(ind) == '.')
                    {
                        str = new ConcreteStateFin();
                        info = "ErrString:" + info;
                    }
                    else info = "String:" + info;
                    ctr.SetState(str);
                    return info;
                }
            }

        }
        class ConcreteStateComm : State
        {
            Context ctr;
            int ind;
            public ConcreteStateComm(Context ctr, int ind)
            {
                this.ctr = ctr;
                this.ind = ind;
            }
            public override string GetNextToken()
            {
                State str = null;
                string info = "";
                bool flag = false;
                while (ctr.GetCharAt(ind) != '.')
                {
                    switch (ctr.GetCharAt(ind))
                    {
                        case '}':
                            flag = true;
                            str = new ConcreteStateNormal(ctr, ind + 1);
                            break;
                        default:
                            break;
                    }
                    if (flag) break;
                    info = info + ctr.GetCharAt(ind);
                    ind++;
                }

                if (ctr.GetCharAt(ind) == '.')
                {
                    str = new ConcreteStateFin();
                    info = "ErrComm:" + info;
                }
                else info = "Comm:" + info;
                ctr.SetState(str);
                return info;
            }
        }
        class ConcreteStateFin : State
        {
            public override string GetNextToken()
            {
                return "";
            }
        }
        class Context
        {
            State currentState;
            String tmp;
            public Context(string tmp)
            {
                this.tmp = tmp;
            }
            public char GetCharAt(int ind)
            {
                return tmp[ind];
            }
            public void SetState(State newState)
            {
                this.currentState = newState;
            }
            public string GetNextToken()
            {
                return currentState.GetNextToken();
            }
        }
        public static void Solve()
        {
            Task("OOP3Behav10");
            string str = GetString();
            string inf;
            Context ctr = new Context(str);
            State s = new ConcreteStateNormal(ctr, 0);
            ctr.SetState(s);
            while ((inf = ctr.GetNextToken()).Length != 0)
            {
                Put(inf);
            }

        }



    }
}
