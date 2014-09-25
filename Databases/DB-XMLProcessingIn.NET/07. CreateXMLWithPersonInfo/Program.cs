namespace _07.CreateXMLWithPersonInfo
{
    using System;
    using System.IO;
    using System.Linq;
    using System.Xml.Linq;

    /// <summary>
    /// In a text file we are given the name, address and phone number of given person (each at a single line). 
    /// Write a program, which creates new XML document, which contains these data in structured XML format.
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            StreamReader reader = new StreamReader(@"..\..\person.txt");

            string name = null;
            string address = null;
            string phone = null;

            using (reader)
            {
                string info = reader.ReadLine();
                int count = 1;

                while(info != null)
                {
                    if(count == 1)
                    {
                        name = info;
                    }
                    else if (count == 2)
                    {
                        address = info;
                    }
                    else
                    {
                        phone = info;
                    }

                    count++;
                    info = reader.ReadLine();
                }
            }

            XElement element = new XElement("person",
                new XElement("Name", name),
                new XElement("Address", address),
                new XElement("Phone", phone)
                );

            Console.WriteLine(element);
            element.Save(@"..\..\person.xml");
        }
    }
}
