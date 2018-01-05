using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace ConsoleApplication32
{
    class Program
    {
        static void Main(string[] args)
        {
            XElement root = XElement.Load("PurchaseOrders.xml");
            IEnumerable<XElement> purchaseOrders =
                from el in root.Elements("PurchaseOrder")
                where
                    (from add in el.Elements("Address")
                     where
                         (string)add.Attribute("Type") == "Shipping" &&
                         (string)add.Element("State") == "NY"
                     select add).Any()
                select el;
            foreach (XElement el in purchaseOrders)
                Console.WriteLine((string)el.Attribute("PurchaseOrderNumber"));
        }
    }
}
