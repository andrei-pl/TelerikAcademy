namespace _10.CreateAlbumsXMLWithXDocument
{
    using System;
    using System.IO;
    using System.Linq;
    using System.Xml.Linq;

    /// <summary>
    /// Rewrite the last exercises using XDocument, XElement and XAttribute.
    /// </summary>
    class Program
    {
        public static XElement CreateXML(string sourceDirectory)
        {
            try
            {

                FileInfo fileInfoSource = new FileInfo(sourceDirectory);

                XElement roothDirectory = new XElement("directory",
                new XAttribute("name", fileInfoSource.Name));

                var files = Directory.EnumerateFiles(sourceDirectory);
                foreach (var file in files)
                {
                    FileInfo fileInfo = new FileInfo(file);
                    roothDirectory.Add(new XElement("file"),
                        new XElement("name", fileInfo.Name),
                        new XElement("type", fileInfo.Extension)
                        );

                }

                var directories = Directory.EnumerateDirectories(sourceDirectory);
                foreach (var directory in directories)
                {
                    roothDirectory.Add(CreateXML(directory));
                }

                return roothDirectory;
            }
            catch (Exception e)
            {
                throw new ArgumentException("Error" + e.Message);
            }
        }
        static void Main()
        {
            string startDirectory = @".\";

            XElement booksXml = new XElement("directories",
                CreateXML(startDirectory)
            );

            booksXml.Save("../../directories.xml");
        }
    }
}
