using System;
using System.Xml.Linq;

namespace ConsoleApplication22
{
    class Program
    {
        static void Main(string[] args)
        {
            XElement movies = new XElement("Movies");

            movies.Add(
                new XElement("Movie",
                    new XAttribute("Name", "Transformers: Dark of the Moon"),
                    new XAttribute("Year", "2011"),
                    new XAttribute("RunningTime", 157.ToString()),
                    new XElement("Director", "Michael Bay"),
                    new XElement("Stars",
                        new XElement("Actor", "Shia LaBeouf"),
                        new XElement("Actress", "Rosie Huntington-Whiteley")
                    ),
                    new XElement("DVD",
                        new XElement("Price", "25.00"),
                        new XElement("Discount", (0.1).ToString())
                    ),
                    new XElement("BluRay",
                        new XElement("Price", "36.00"),
                        new XElement("Discount", (0.1).ToString())
                    )
                )
            );

            XDocument doc = new XDocument(new XDeclaration("1.0", "utf-8", ""), movies);
        doc.Save(@"..\..\Movies.xml");
        }
    }
}
/*
<?xml version="1.0" encoding="utf-8"?>
<Movies>
  <Movie Name="Transformers: Dark of the Moon" Year="2011" RunningTime="157">
    <Director>Michael Bay</Director>
    <Stars>
      <Actor>Shia LaBeouf</Actor>
      <Actress>Rosie Huntington-Whiteley</Actress>
    </Stars>
    <DVD>
      <Price>25.00</Price>
      <Discount>0,1</Discount>
    </DVD>
    <BluRay>
      <Price>36.00</Price>
      <Discount>0,1</Discount>
    </BluRay>
  </Movie>
</Movies>
*/

