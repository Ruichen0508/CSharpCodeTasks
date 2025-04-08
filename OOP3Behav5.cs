// File: "OOP3Behav7"
using PT4;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PT4Tasks
{
    public class MyTask : PT
    {
        public abstract class Aggregate
        {
            public abstract Iterator CreateIterator();
        }

        // Implement the ConcreteAggregateA, ConcreteAggregateB
        //   and ConcreteAggregateC descendant classes
        public class ConcreteAggregateA : Aggregate
        {
            public ConcreteAggregateA(int data) => Data = data;
            public override Iterator CreateIterator() => new ConcreteIteratorA(this);

            public int Data { get; set; }
            public int Divied { get; set; } = 1;
        }

        public class ConcreteAggregateB : Aggregate
        {
            public ConcreteAggregateB(string data) => Data = data;
            public override Iterator CreateIterator() => new ConcreteIteratorB(this);

            public string Data { get; set; }
            public int Index { get; set; } = 0;
        }
        public class ConcreteAggregateC : Aggregate
        {
            public ConcreteAggregateC(int[] data) => Data = data;
            public override Iterator CreateIterator() => new ConcreteIteratorC(this);

            public int[] Data { get; set; }
            public int Index { get; set; } = 0;
            public int Divied { get; set; } = 1;
        }

        public abstract class Iterator
        {
            public abstract void First();
            public abstract void Next();
            public abstract bool IsDone();
            public abstract int CurrentItem();
        }
        public class ConcreteIteratorA : Iterator
        {
            public ConcreteIteratorA(ConcreteAggregateA aggr) => this.aggr = aggr;
            public override void First() => aggr.Divied = 1;
            public override void Next() => aggr.Divied *= 10;
            public override bool IsDone()
                => aggr.Data != 0 && aggr.Data / aggr.Divied == 0 || aggr.Data == 0 && aggr.Divied == 10;
            public override int CurrentItem() => Math.Abs(aggr.Data / aggr.Divied % 10);

            private ConcreteAggregateA aggr;
        }

        public class ConcreteIteratorB : Iterator
        {
            public ConcreteIteratorB(ConcreteAggregateB aggr) => this.aggr = aggr;

            public override void First()
            {
                aggr.Index = aggr.Data.Length - 1;
                while (aggr.Index >= 0 && !char.IsDigit(aggr.Data[aggr.Index]))
                {
                    aggr.Index--;
                }
            }

            public override void Next()
            {
                aggr.Index--;
                while (aggr.Index >= 0 && !char.IsDigit(aggr.Data[aggr.Index]))
                {
                    aggr.Index--;
                }
            }

            public override bool IsDone() => aggr.Index < 0;
            public override int CurrentItem() => aggr.Data[aggr.Index] - '0';

            private ConcreteAggregateB aggr;
        }
        
        public class ConcreteIteratorC : Iterator
        {
            public ConcreteIteratorC(ConcreteAggregateC aggr) => this.aggr = aggr;

            public override void First()
            {
                aggr.Index = aggr.Data.Length - 1;
                aggr.Divied = 1;
            }

            public override void Next()
            {
                aggr.Divied *= 10;
                int data = aggr.Data[aggr.Index];
                int divied = aggr.Divied;
                if (data != 0 && data / divied == 0 || data == 0 && divied == 10)
                { aggr.Index--; aggr.Divied = 1; }
            }

            public override bool IsDone() => aggr.Index < 0;
            public override int CurrentItem() => Math.Abs(aggr.Data[aggr.Index] / aggr.Divied % 10);

            private ConcreteAggregateC aggr;
        }
        
        public static void Solve()
        {
            Task("OOP3Behav7");

            int count = GetInt();
            int data1;
            string data2;
            int[] data3;
            var aggr = new Aggregate[count];
            for (int i = 0; i < count; i++)
            {
                char type = GetChar();
                if (type == 'A')
                {
                    data1 = GetInt();
                    aggr[i] = new ConcreteAggregateA(data1);
                }
                else if (type == 'B')
                {
                    data2 = GetString();
                    aggr[i] = new ConcreteAggregateB(data2);
                }
                else
                {
                    int k = GetInt();
                    data3 = new int[k];
                    for (int j = 0; j < k; j++)
                    { int num = GetInt(); data3[j] = num; }
                    aggr[i] = new ConcreteAggregateC(data3);
                }
            }

            foreach (var a in aggr.Reverse())
            {
                var digits = new List<int>();
                var it = a.CreateIterator();
                for (it.First(); !it.IsDone(); it.Next())
                    digits.Add(it.CurrentItem());
                Put(digits.Sum());
                foreach (var d in digits)
                    Put(d);
            }
        }
    }
}