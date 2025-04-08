    // File: "LinqXml88"
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
            Task("LinqXml88");

            string getstr = GetString();

            XDocument XDo = XDocument.Load(getstr);
            XElement XEl = XDo.Root;
            XNamespace ns = XEl.Name.Namespace;
            var elements = XEl.Elements().ToList();
            XEl.RemoveAll();

            var filedata = from element in elements
                        let classnum = element.Attribute("number").Value
                        let childs = element.Elements()
                        select (classnum, childs)
                        into element2
                        from elements2 in element2.childs
                        let name = elements2.Attribute("name").Value
                        let subject = elements2.Attribute("subject").Value
                        let mark = elements2.Attribute("mark").Value
                        orderby subject
                        group (element2.classnum, name, mark) by subject;

            foreach (var item in filedata)
            {
                var ele = new XElement(ns + "subject");
                ele.Add(new XAttribute("name", item.Key));

                var datas2 = from data in item
                             orderby int.Parse(data.classnum), data.name, data.mark descending
                             group data.mark by (data.classnum, data.name)
                             into tmp
                             where tmp.Count() > 2
                             select tmp;

                foreach (var item2 in datas2)
                {
                    var str = item2.ToList();

                    var ele2 = new XElement(ns + "pupil");
                    ele2.Add(new XAttribute("class", item2.Key.classnum));
                    ele2.Add(new XAttribute("name", item2.Key.name));
                    for (int i = 0; i < str.Count; i++)
                        ele2.Add(new XAttribute("m{i + 1}", str[i]));
                    ele.Add(ele2);
                }
                XEl.Add(ele);
            }
            XDo.Save(getstr);
        }
    }
}

    
