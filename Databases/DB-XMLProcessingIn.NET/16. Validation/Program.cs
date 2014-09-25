namespace _16.Validation
{
    using System;
    using System.Linq;
    using System.Xml.Linq;
    using System.Xml.Schema;

    /// <summary>
    /// Using Visual Studio generate an XSD schema for the file catalog.xml. Write a C# program that takes an XML file 
    /// and an XSD file (schema) and validates the XML file against the schema. Test it with valid XML catalogs and invalid XML catalogs.
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            XmlSchemaSet schemas = new XmlSchemaSet();
            schemas.Add("", "../../catalog.xsd");

            //Valid xml file
            XDocument doc = XDocument.Load("../../catalog.xml");

            //Invalid xml file
            //XDocument doc = XDocument.Load("../../InvalidCatalog.xml");
            string msg = "";
            doc.Validate(schemas, (o, e) =>
            {
                msg = e.Message;
            });
            Console.WriteLine(msg == "" ? "Document is valid" : "Document invalid: " + msg);
        }
    }
}
