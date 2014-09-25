namespace _06.AllSongsWithLinq
{
    using System;
    using System.Linq;
    using System.Xml;
    using System.Xml.Linq;

    /// <summary>
    /// Rewrite the same using XDocument and LINQ query.
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            XDocument doc = XDocument.Load("../../../catalog.xml");
            var albums = from song in doc.Descendants("song")
                         select
                         new
                         {
                             Title = song.Element("title").Value
                         };

            foreach (var song in albums)
            {
                Console.WriteLine(song.Title);
            }
        }
    }
}
