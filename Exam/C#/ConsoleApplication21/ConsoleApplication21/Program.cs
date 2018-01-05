using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.IO;
using System.Xml;

namespace ConsoleApplication21
{
    class Program
    {
        static void Main(string[] args)
        {
            StreamReader sr;
            try
            {
                sr = new StreamReader(@"..\..\Books.txt");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.ReadLine();
                return;
            }
            XmlTextWriter xmltr = new XmlTextWriter(@"..\..\Books.xml", null);
            int i;
            string s = null;
            string[] Names;
            string[] Fields;

            s = sr.ReadLine();
            Names = s.Split('\t');
            xmltr.Formatting = Formatting.Indented;
            xmltr.WriteStartDocument();
            xmltr.WriteStartElement("Books");
            while ((s = sr.ReadLine()) != null)
            {
                Fields = s.Split('\t');
                if (Names.Length == Fields.Length)
                {
                    xmltr.WriteStartElement("Book");
                    for (i = 0; i < Names.Length; i++)
                    {
                        xmltr.WriteElementString(Names[i], Fields[i]);
                    }
                    xmltr.WriteEndElement();
                }
                else
                {
                    Console.WriteLine("Файл 'Books.txt' содержит ошибки.");
                    break;
                }
            }
            xmltr.WriteEndElement();
            xmltr.Close();
            Console.ReadLine();
        }
    }
}

