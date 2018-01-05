using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;


namespace ConsoleApplication29
{
    class Program
    {
        static void Main(string[] args)
        {
            XElement root = XElement.Parse(@"<Root>
  <Child1>
    <Text>Child One Text</Text>
    <Type Value=""Yes""/>
  </Child1>
  <Child2>
    <Text>Child Two Text</Text>
    <Type Value=""Yes""/>
  </Child2>
  <Child3>
    <Text>Child Three Text</Text>
    <Type Value=""No""/>
  </Child3>
  <Child4>
    <Text>Child Four Text</Text>
    <Type Value=""Yes""/>
  </Child4>
  <Child5>
    <Text>Child Five Text</Text>
  </Child5>
</Root>");
            var cList =
                from typeElement in root.Elements().Elements("Type")
                where (string)typeElement.Attribute("Value") == "Yes"
                select (string)typeElement.Parent.Element("Text");
            foreach (string str in cList)
                Console.WriteLine(str);
        }
    }
}
