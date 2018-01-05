using System;
using System.Linq;
using System.Xml;
using System.Xml.Linq;
using System.Collections.Generic;


namespace ConsoleApplicationDOM
{
    class Program
    {
        static void Main(string[] args)
        {
            XElement root = XElement.Load("Books.xml");
            IEnumerable<XElement> tests =
                from el in root.Elements("Book")
                where ((string)el.Element("PublicationDate")).Contains("2008")
                select el;
            foreach (XElement el in tests)
                Console.WriteLine((string)el.Element("Title"));
            Console.ReadLine();
        }
    }
}
