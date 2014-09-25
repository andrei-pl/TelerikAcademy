namespace _08.CreateAlbumsXMLWithXmlWriter
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;

    /// <summary>
    /// Write a program, which (using XmlReader and XmlWriter) reads the file catalog.xml and creates the file album.xml, 
    /// in which stores in appropriate way the names of all albums and their authors.
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            List<string> autors = new List<string>();
            List<string> albums = new List<string>();

            using (XmlReader reader = XmlReader.Create("../../../catalog.xml"))
            {
                while (reader.Read())
                {
                    if ((reader.NodeType == XmlNodeType.Element) &&
                        (reader.Name == "artist"))
                    {
                        autors.Add(reader.ReadElementString());
                    }
                    if ((reader.NodeType == XmlNodeType.Element) &&
                        (reader.Name == "name"))
                    {
                        albums.Add(reader.ReadElementString());
                    }
                }
            }

            string fileName = "../../albums.xml";
            Encoding encoding = Encoding.GetEncoding("windows-1251");
            using (XmlTextWriter writer = new XmlTextWriter(fileName, encoding))
            {

                writer.Formatting = Formatting.Indented;
                writer.IndentChar = '\t';
                writer.Indentation = 1;

                writer.WriteStartDocument();
                writer.WriteStartElement("albums");
                for (int i = 0; i < albums.Count; i++)
                {
                    writer.WriteStartElement("album");
                    writer.WriteElementString("name", albums[i]);
                    writer.WriteElementString("author", autors[i]);
                    writer.WriteEndElement();
                }

                writer.WriteEndDocument();
            }
        }
    }
}
