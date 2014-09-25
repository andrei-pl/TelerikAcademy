namespace _04.DeleteAlbumsWithBiggerPrice
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Xml;

    /// <summary>
    /// Using the DOM parser write a program to delete from catalog.xml all albums having price > 20.
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load("../../catalog.xml");
            XmlNode node = doc.DocumentElement;
            List<XmlNode> albumsForDelete = new List<XmlNode>();

            foreach (XmlNode child in node.ChildNodes)
            {
                if (int.Parse(child["price"].InnerText) > 20)
                {
                    albumsForDelete.Add(child);
                }
            }

            foreach (var album in albumsForDelete)
            {
                node.RemoveChild(album);
            }

            doc.Save("../../newCatalog.xml");
        }
    }
}
