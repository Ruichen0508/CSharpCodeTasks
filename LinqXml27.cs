    using PT4;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Xml.Linq;

namespace PT4Tasks
{
    using System.Xml;

    public class MyTask : PT
    {
        public static void Solve()
        {
            Task("LinqXml27");
            string filename = GetString();
            XDocument d = XDocument.Load(filename);
            d.Root.Elements().Elements().Nodes().Where(x => x.NextNode != null).Remove();
            d.Save(filename);

        }
    }
}

    
