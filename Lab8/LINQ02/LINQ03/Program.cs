using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace LINQ_to_XML
{
    class Program
    {
        static void Main(string[] args)
        {
            //ReadXML();
            //ReadFirstXML();
            //UpdateXML();
            WriteXML();
            Console.WriteLine("Это все...");
            Console.ReadLine();
        }

        // ПРИМЕР 1. ЧТЕНИЕ ДАННЫХ ИЗ ДОКУМЕНТА XML
        static void ReadXML()
        {
            XDocument xdoc = XDocument.Load(@"task.xml");
            var query = from people in xdoc.Descendants("Passenger")
                        select people.Value; 
            Console.WriteLine("Найдено  {0} персонажей", query.Count());
            Console.WriteLine();
            foreach (var item in query)
            {
                Console.WriteLine(item);
            }
            Console.ReadLine();
        }

        // ПРИМЕР 2. ЧТЕНИЕ ОДНОГО ЭЛЕМЕНТА ИЗ ДОКУМЕНТА XML
        static void ReadFirstXML()
        {
            XDocument xdoc = XDocument.Load(@"task.xml");
            Console.WriteLine(xdoc.Element("Doctors").Element("Passenger").Element("Name").Value);
            Console.ReadLine();
        }
        
        // ПРИМЕР 3. МОДИФИКАЦИЯ ДАННЫХ В ДОКУМЕНТЕ XML
        static void UpdateXML()
        {
            XDocument xdoc = XDocument.Load(@"task.xml");
            xdoc.Element("Doctors").Element("Passenger").Element("Age").SetValue(27);
            Console.WriteLine(xdoc.Element("Doctors").Element("Passenger").Element("Age").Value);
            Console.ReadLine();
        }

        // ПРИМЕР 4. ЗАПИСЬ ДАННЫХ В ДОКУМЕНТ XML
        static void WriteXML()
        {
            XDocument xdoc = XDocument.Load(@"task.xml");
            XElement xe = new XElement("Passenger", "Иван IV Грозный, первый русский царь");
            xdoc.Element("Doctors").Add(xe);
            var query = from people in xdoc.Descendants("Passenger")
                        select people.Value; 
            Console.WriteLine("Найдено {0} персонажей", query.Count());
            Console.WriteLine();
            foreach (var item in query)
            {
                Console.WriteLine(item);
            }
            Console.ReadLine();
        }
    }
}
