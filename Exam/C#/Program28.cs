using System;
using System.Xml;
using System.Collections.Generic;

namespace ConsoleApplicationDOM
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> books = new List<string>();
            List<string> names = new List<string>();
            XmlDocument doc = new XmlDocument();
            doc.Load("XMLFile2.xml");

            XmlNodeList list = doc.DocumentElement.SelectNodes("course");
            //foreach (XmlNode x in list)
            //{
            //    XmlAttributeCollection attr = ((XmlElement)x).Attributes;
            //    //if (attr["department"].Value == "software engineering")
            //    //    Console.WriteLine(attr["number"].Value);
            //    if (attr["department"].Value == "computing science")
            //        Console.WriteLine(attr["number"].Value);
            //}

            //foreach (XmlNode x in list)
            //{
            //    XmlAttributeCollection attr = ((XmlElement)x).Attributes;
            //    //if (attr["department"].Value == "software engineering")
            //    //    Console.WriteLine(attr["number"].Value);
            //    if (attr["department"].Value == "computing science")
            //        foreach (XmlElement y in x.ChildNodes)
            //            if (y.Name == "students")
            //                foreach (XmlElement z in y.ChildNodes)
            //                    if (z.Name == "student")
            //                        foreach (XmlElement u in z.ChildNodes)
            //                            if (u.Name == "name")
            //                                if (!names.Contains(u.InnerText))
            //                                    names.Add(u.InnerText);
            //                                //Console.WriteLine(u.InnerText);
            //}
            //foreach (string s in names)
            //    Console.WriteLine("\t" + s);
            //Console.WriteLine("{0}", names.Count);
            
            string s = "";
            foreach (XmlNode x in list)
                if (x.Name == "course")
                {
                    //Console.WriteLine(x.Name.ToString());
                    foreach (XmlElement y in x.ChildNodes)
                        if (y.Name == "students")
                        {
                            //Console.WriteLine(y.Name.ToString());
                            foreach (XmlElement z in y.ChildNodes)
                                if (z.Name == "student")
                                {
                                    //Console.WriteLine(z.Name.ToString());
                                    foreach (XmlElement u in z.ChildNodes)
                                    {
                                        if (u.Name == "name") s = u.InnerText;
                                        if (u.Name == "email" && u.InnerText.EndsWith("ualberta.ca"))
                                            if (!names.Contains(s)) names.Add(s);
                                    }
                                }
                        }
                }
            foreach (string n in names) Console.WriteLine("\t" + n);
            Console.WriteLine("{0}", names.Count);

            //XmlNodeList list = doc.DocumentElement.GetElementsByTagName("name");
            //foreach (XmlNode x in list)
            //    if (!books.Contains(x.InnerText))
            //        books.Add(x.InnerText);
            //foreach (string s in books)
            //    Console.WriteLine("\t" + s);

            //XmlNodeList list = doc.DocumentElement.GetElementsByTagName("instructor");
            //foreach (XmlNode x in list)
            //    if (!books.Contains(x.InnerText))
            //        books.Add(x.InnerText);
            //foreach (string s in books)
            //    Console.WriteLine("\t" + s);

            //XmlNodeList list = doc.DocumentElement.GetElementsByTagName("Textbook");
            //foreach (XmlNode x in list)
            //    if (!books.Contains(x.InnerText))
            //        books.Add(x.InnerText);
            //foreach (string s in books)
            //    Console.WriteLine("\t" + s);

            Console.ReadLine();
        }
    }
}
