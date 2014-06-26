using System;
using System.Text.RegularExpressions;

namespace _12.ParseURL
{
    //Write a program that parses an URL address given in the format:
    //[protocol]://[server]/[resource] and extracts from it the [protocol], [server] and [resource] elements. 
    //For example from the URL http://www.devbg.org/forum/index.php the following information should be extracted:
	//[protocol] = "http"	[server] = "www.devbg.org"	[resource] = "/forum/index.php"
    class ParseURL
    {
        static void Main(string[] args)
        {
            string uri = "http://www.devbg.org/forum/index.php";

            var fragments = Regex.Match(uri, "(.*)://(.*?)(/.*)").Groups;

            Console.WriteLine(fragments[1]);
            Console.WriteLine(fragments[2]);
            Console.WriteLine(fragments[3]);
        }
    }
}
