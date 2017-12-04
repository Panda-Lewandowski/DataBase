using System;
using System.Xml;    
using System.IO;

namespace Wrox
{
    class consoleApp
   {
      static void Main(string[] args)
      {
            // 1. Reading document
            XmlDocument myDocument = new XmlDocument();
            FileStream myFile = new FileStream("../../task.xml", FileMode.Open); 
            myDocument.Load(myFile);

            // 2. Finding information 
            Console.Write("This names was found in the entire document:\r\n");
            XmlNodeList names = myDocument.GetElementsByTagName("Name");
            for (int i = 0; i < names.Count; i++)
                Console.Write(names[i].ChildNodes[0].Value + "\r\n");
            
            Console.Write("\n\nThis passenger has ID=797:\r\n");
            XmlElement id = myDocument.GetElementById("797"); 
            Console.Write(id.ChildNodes[1].ChildNodes[0].Value + "\r\n");

            Console.Write("\n\nSex of survival passengers is:\r\n");
            XmlNodeList sur = myDocument.SelectNodes("//Passenger/Sex/text()[../../Survival/text()='1']"); 
            for (int i = 0; i < sur.Count; i++)
                Console.Write(sur[i].Value + "\r\n");

            Console.Write("\n\nAge of the first survival passenger is:\r\n");
            XmlNode surOne = myDocument.SelectSingleNode("//Passenger/Sex/text()[../../Survival/text()='1']");
            Console.Write(surOne.Value + "\r\n");

            // 3. Access to nodes
            Console.Write("\n\n" + myDocument.DocumentElement.ChildNodes[0].Value + "\r\n");

            Console.Write("\n\nInformation about Doctors: \n");
            XmlNodeList pass = myDocument.GetElementsByTagName("Passenger");
            for (int i = 0; i < pass.Count; i++)
                Console.Write(pass[i].ChildNodes[1].InnerText + " " + pass[i].ChildNodes[4].Value + "\r\n"); 

            XmlProcessingInstruction myPI = (XmlProcessingInstruction) myDocument.DocumentElement.ChildNodes[0];
            Console.Write("\n\nInstruction: \n Name: " + myPI.Name + "\r\n");
            Console.Write("Data: " + myPI.Data + "\r\n");

            Console.Write("\n\nIDs of Passengers: \n");
            for (int i = 0; i < pass.Count; i++)
                Console.Write(pass[i].ChildNodes[1].InnerText + " : " + pass[i].Attributes[0].Value + "\r\n"); 

            //3. Changes file
            XmlElement pcElement = (XmlElement)myDocument.GetElementsByTagName("Age")[1]; 
            pass[1].RemoveChild(pcElement);
            Console.Write("Delete the first passenge's age..."  + "\r\n");
            myDocument.Save("../../task-del.xml");

            XmlNodeList ageValues = myDocument.SelectNodes("//Passenger/Age/text()"); 
            for (int i = 0; i < ageValues.Count; i++)
                ageValues[i].Value = ageValues[i].Value + " years old";
            Console.Write("Change format of age..." + "\r\n");
            myDocument.Save("../../task-chg.xml");

            XmlElement PassElement = myDocument.CreateElement("Passenger");
            XmlElement SurElement = myDocument.CreateElement("Survival");
            XmlElement NameElement = myDocument.CreateElement("Name");
            XmlElement SexElement = myDocument.CreateElement("Sex");
            XmlElement AgeElement = myDocument.CreateElement("Age");

            XmlText SurText = myDocument.CreateTextNode("1");
            XmlText NameText = myDocument.CreateTextNode("Smith Dr. Brenda");
            XmlText SexText = myDocument.CreateTextNode("female");
            XmlText AgeText = myDocument.CreateTextNode("30");

            SurElement.AppendChild(SurText);
            NameElement.AppendChild(NameText);
            SexElement.AppendChild(SexText);
            AgeElement.AppendChild(AgeText);

            PassElement.AppendChild(SurElement);
            PassElement.AppendChild(NameElement);
            PassElement.AppendChild(SexElement);
            PassElement.AppendChild(AgeElement);

            myDocument.DocumentElement.AppendChild(PassElement);
            myDocument.Save("../../task-new.xml");

            XmlDocument newDocument = new XmlDocument();
            FileStream newFile = new FileStream("../../task-new.xml", FileMode.Open);
            newDocument.Load(newFile);

            XmlElement newElement = (XmlElement)myDocument.GetElementsByTagName("Passenger")[7];
            newElement.SetAttribute("PassengerId", "900");
            myDocument.Save("../../task-attr.xml");

            newFile.Close();
            myFile.Close();
         
      }
   }
}
