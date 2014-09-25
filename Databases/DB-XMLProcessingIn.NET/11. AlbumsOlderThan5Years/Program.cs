namespace _11.AlbumsOlderThan5Years
{
    using System;
    using System.Linq;
    using System.Xml;

    /// <summary>
    /// Write a program, which extract from the file catalog.xml the prices for all albums, published 5 years ago or earlier.
    /// Use XPath query.
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load("../../../catalog.xml");
            string xPathQuery = "/catalog/album";

            XmlNodeList albumsList = xmlDoc.SelectNodes(xPathQuery);

            foreach (XmlNode node in albumsList)
            {
                int year = int.Parse(node.SelectSingleNode("year").InnerText);
                if (DateTime.Now.Year - year >= 5)
                {
                    decimal price = decimal.Parse(node.SelectSingleNode("price").InnerText);
                    Console.WriteLine(price);
                }
            }
        }
    }
}
