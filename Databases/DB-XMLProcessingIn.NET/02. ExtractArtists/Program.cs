using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.ExtractArtists
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Xml;

    /// <summary>
    /// Write program that extracts all different artists which are found in the catalog.xml. 
    /// For each author you should print the number of albums in the catalogue. Use the DOM parser and a hash-table.
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            Hashtable hash = new Hashtable();

            XmlDocument doc = new XmlDocument();

            doc.Load("..\\..\\..\\catalog.xml");

            XmlNode rootNode = doc.DocumentElement;
            List<string> autors = new List<string>();

            foreach (XmlNode element in rootNode.ChildNodes)
            {
                string autor = element["artist"].InnerText;
                if (!hash.ContainsKey(autor))
                {
                    hash.Add(autor, 1);
                    autors.Add(autor);
                }
                else
                {
                    int count = (int)hash[autor];
                    hash[autor] = count + 1;
                }
            }

            foreach (var autor in autors)
            {
                Console.WriteLine("{0} have {1} albums", autor, hash[autor]);
            }
            Console.WriteLine();
        }
    }
}
