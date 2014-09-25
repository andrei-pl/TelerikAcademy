namespace _13.CatalogAsHTML
{
    using System;
    using System.Linq;
    using System.Xml.Xsl;

    /// <summary>
    /// Create an XSL stylesheet, which transforms the file catalog.xml into HTML document, formatted for viewing in a standard Web-browser.
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            XslCompiledTransform html = new XslCompiledTransform();
            html.Load(@"..\..\catalog.xslt");
            html.Transform(@"..\..\catalog.xml", @"..\..\catalog.html");
        }
    }
}
