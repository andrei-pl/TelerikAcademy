namespace _12.AlbumsOlderThan5YearsLinq
{
    using System;
    using System.Linq;
    using System.Xml.Linq;

    /// <summary>
    /// Rewrite the previous using LINQ query.
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            XDocument xmlDoc = XDocument.Load("../../../catalog.xml");

            var prices = from album in xmlDoc.Descendants("album")
                         where (DateTime.Now.Year - int.Parse(album.Element("year").Value) >= 5)
                         select album.Element("price").Value;

            foreach (var price in prices)
            {
                Console.WriteLine(price);
            }
        }
    }
}
