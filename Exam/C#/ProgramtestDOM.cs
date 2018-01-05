using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.IO;

namespace testDOM
{
    class Program
    {
        static void Main(string[] args)
        {
            XmlDocument doc = new XmlDocument();
            try
            {
                FileStream str = new FileStream("bookstore.xml", FileMode.Open);
                doc.Load(str);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                doc = null;
                return;
            }

            Console.WriteLine("begin");
            Console.WriteLine("Number of nodes = "+doc.DocumentElement.ChildNodes.Count.ToString());
            if (doc.DocumentElement.ChildNodes.Count != 0)
            {
                foreach (XmlNode x in doc.DocumentElement.ChildNodes)
                {
                    if (x.NodeType == XmlNodeType.Element && x.Name == "book")
                    {
                        Console.WriteLine(x.Name);
                        if (x.ChildNodes.Count != 0)
                        {
                            foreach (XmlNode y in x.ChildNodes)
                            {
                                if (y.NodeType == XmlNodeType.Element && y.Name == "title")
                                {
                                    Console.WriteLine(y.Name);
                                    if (y.ChildNodes.Count == 1)
                                    {
                                        if (y.ChildNodes[0].NodeType == XmlNodeType.Text)
                                        {
                                            XmlText t = (XmlText)y.ChildNodes[0];
                                            Console.WriteLine(t.Data);
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}
