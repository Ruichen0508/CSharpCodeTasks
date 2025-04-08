using PT4;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Xml.Linq;

namespace PT4Tasks
{
    public class MyTask : PT
    { 
        public static void Solve()
        {
            Task("LinqXml17");
            var doc = XDocument.Load(GetString());
            var result = doc.Root.DescendantNodes()
                            .OfType<XText>()
                            .Where(e => e.Value != "")
                            .Select(elem => new
                            {
                                name = elem.Parent.Name.LocalName,
                                text = elem.Value
                            })
                            .OrderBy(e => e.name)
                            .GroupBy(e => e.name);

            foreach (var k in result)
            {
                Put(k.Key);
                var textValues = k.Select(e => e.text);
                foreach (var v in textValues)
                    Put(v);
            }
        }
    }
}
