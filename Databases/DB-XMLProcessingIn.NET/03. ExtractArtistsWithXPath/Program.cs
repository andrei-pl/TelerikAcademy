namespace _03.ExtractArtistsWithXPath
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Xml;

    /// <summary>
    /// Implement the previous using XPath.
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load("../../../catalog.xml");
            string xPathQuery = "/catalog/album";
            Hashtable hash = new Hashtable();
            List<string> autorsList = new List<string>();

            XmlNodeList autors = doc.SelectNodes(xPathQuery);
            foreach (XmlNode autor in autors)
            {
                string name = autor.SelectSingleNode("artist").InnerText;
                if (!hash.ContainsKey(name))
                {
                    hash.Add(name, 1);
                    autorsList.Add(name);
                }
                else
                {
                    hash[name] = (int)hash[name] + 1;
                }
            }

            foreach (var autor in autorsList)
            {
                Console.WriteLine("{0} have {1} albums", autor, hash[autor]);
            }
            Console.WriteLine();
        }
    }
}
