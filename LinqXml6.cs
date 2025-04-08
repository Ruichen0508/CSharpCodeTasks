// File: "LinqXml6"
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
        // When solving tasks of the LinqXml group, the following
        // additional methods defined in the taskbook are available:
        // (*) Show() and Show(cmt) (extension methods) - debug output
        //       of a sequence, cmt - string comment;
        // (*) Show(e => r) and Show(cmt, e => r) (extension methods) -
        //       debug output of r values, obtained from elements e
        //       of a sequence, cmt - string comment.

        public static void Solve()
        {
            Task("LinqXml6");
            string name = GetString();
            var a = File.ReadLines(name);
            XDocument d = new XDocument(
            new XDeclaration(null, "us-ascii", null),//
            new XElement("root",
            a.Select(thedata => new XElement("line",new XAttribute("sum", thedata.Split().Select(data1 => int.Parse(data1)).Sum()),
                          thedata.Split().OrderByDescending(data2 => int.Parse(data2)).Select(data3 => new XElement("number", int.Parse(data3)))))));
            d.Save(GetString());


        }
    }
}