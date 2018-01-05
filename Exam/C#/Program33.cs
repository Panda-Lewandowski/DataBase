using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace ConsoleApplication33
{
    class Program
    {
        static void Main(string[] args)
        {
            XElement root = XElement.Load("Tests.xml");
            IEnumerable<XElement> tests =
                from el in root.Elements("Test")
                where (string)el.Element("CommandLine") == "Examp2.EXE"
                select el;
            foreach (XElement el in tests)
                Console.WriteLine((string)el.Attribute("TestId"));
        }
    }
}
/*
Создать проект консольного приложения на C#, которое загружает предложенный XML-файл 'Tests.xml', 
содержащий описания тестов программ, и выбирает те значения атрибута TestId элемента Test, 
который имеет дочерний элемент CommandLine со значением, совпадающим со значением, вводимым с консоли.
*/
