using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using System.Xml;
using System.IO;

namespace BC3XML
{
    public partial class Bc3xml : Form
    {
        public Bc3xml()
        {
            InitializeComponent();
        }

        private void loadXmlButton_Click(object sender, EventArgs e)
        {
            StreamReader reader = null;
            try
            {
                openFileDialog.ShowDialog();
                reader = new StreamReader(openFileDialog.FileName);
                xmlTextBox.Text = reader.ReadToEnd();
            }
            catch (IOException ex)
            {
                MessageBox.Show("Can't read!");
            }
        }

        // DOM
        private void domButton_Click(object sender, EventArgs e)
        {
            try
            {
                XmlDocument doc = new XmlDocument();
                doc.LoadXml(xmlTextBox.Text);
                XmlNodeList books = doc.GetElementsByTagName("Book");
                String booksTitles = "";
                foreach (XmlNode book in books)
                {
                    XmlNodeList authors = ((XmlElement)book).GetElementsByTagName("Author");
                    foreach (XmlNode author in authors)
                    {
                        if (author.InnerText == "Bill Evjen")
                        {
                            booksTitles += "Title: " + ((XmlElement)book).GetElementsByTagName("Title").Item(0).InnerText + "\n";
                        }
                    }
                }

                resultTextBox.Text = booksTitles;
            }
            catch (Exception ex)
            {
                MessageBox.Show("There is an error with creating the dom!");
            }
            
        }

        // Linq
        private void linqButton_Click(object sender, EventArgs e)
        {
            try
            {
                resultTextBox.Text = "";
                XDocument books = XDocument.Parse(xmlTextBox.Text);
                var titles = from book in books.Descendants("Book")
                             from title in book.Descendants("Title")
                             from author in book.Descendants("Author")
                             where author.Value == "Bill Evjen"
                             select title.Value;
                foreach (String title in titles)
                {
                    resultTextBox.Text += "Title: " + title + "\n";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("There is an error with creating the XDocument!");
            }
            
        }
    }
}
