using System;
using System.Xml;

namespace ConsoleApplication20
{
    class Program
    {
        static void Main(string[] args)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(@"..\..\Books.xml");

            // Извлекаем все цены и строим список.
            XmlNodeList prices = doc.GetElementsByTagName("Price");

            decimal totalPrice = 0;
            foreach (XmlNode price in prices)
            {
                // Получаем внутренний текст для каждого сопоставляемого элемента.
                totalPrice += Decimal.Parse(price.ChildNodes[0].Value);
            }

            decimal averagePrice = totalPrice / prices.Count;

            Console.WriteLine("Средняя цена книги: " + averagePrice.ToString());
            Console.ReadLine();
        }
    }
}
/*
Средняя цена книги: 46,79
*/
