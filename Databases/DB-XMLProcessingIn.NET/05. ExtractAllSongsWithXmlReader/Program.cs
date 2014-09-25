namespace _05.ExtractAllSongsWithXmlReader
{
    using System;
    using System.Linq;
    using System.Xml;

    /// <summary>
    /// Write a program, which using XmlReader extracts all song titles from catalog.xml.
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            XmlReader reader = XmlReader.Create("../../../catalog.xml");

            while(reader.Read())
            {
                if(reader.NodeType == XmlNodeType.Element && reader.Name == "title")
                {
                    Console.WriteLine(reader.ReadElementString());
                }
            }
        }
    }
}
