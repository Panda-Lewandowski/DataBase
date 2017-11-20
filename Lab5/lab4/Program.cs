using System;
using System.Xml;    
using System.Xml.Schema;

namespace ValidateCS
{
   class Class1
   {
      static void Main(string[] args)
      {
         // Create a cache of schemas, and add two schemas
            XmlSchemaCollection sc = new XmlSchemaCollection();
         sc.Add("urn:MyUri", "../../../doctors.xsd");
         //sc.Add("", "../../../doctors.xsd");

         // Create a validating reader object
         XmlTextReader tr = new XmlTextReader("../../../doctors.xml");
         XmlValidatingReader vr = new XmlValidatingReader(tr);

         // Specify the type of validation required
         vr.ValidationType = ValidationType.Schema;

         // Tell the validating reader to use the schema collection
         vr.Schemas.Add(sc);

         // Register a validation event handler method
         vr.ValidationEventHandler += new ValidationEventHandler(MyHandler);

         // Read and validate the XML document
         try
            {
                int num = 0;
                float avg_age = 0;
                while (vr.Read())
                {

                    if (vr.NodeType == XmlNodeType.Element &&
                       vr.LocalName == "P")
                    {
                        num++;

                        vr.MoveToFirstAttribute();
                        Console.WriteLine(vr.Value);
                        vr.MoveToNextAttribute();
                        vr.MoveToNextAttribute();
                        string val = vr.Value;
                        if (val != "male" && val != "female")
                        {
                            //Console.WriteLine(val);
                            avg_age += Convert.ToInt32(vr.Value);
                        }

                        vr.MoveToElement();


                    }

                }

                Console.WriteLine("Number of Passengers: " + num + "\n");
                Console.WriteLine("Average age: " + avg_age/num + "\n");
         }
         catch (XmlException ex)
         {
            Console.WriteLine("XMLException occurred: " + ex.Message);
         }
         finally
         {
            vr.Close();
         }
      }

      // Validation event handler method
      public static void MyHandler(object sender, ValidationEventArgs e) 
      {
         Console.WriteLine("Validation Error: " + e.Message);
      }
   }
}
