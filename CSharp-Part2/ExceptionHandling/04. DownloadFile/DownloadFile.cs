using System;
using System.Net;
using System.IO;
using System.Security;

namespace _04.DownloadFile
{
    //Write a program that downloads a file from Internet (e.g. http://www.devbg.org/img/Logo-BASD.jpg) and stores it the current directory. 
    //Find in Google how to download files in C#. Be sure to catch all exceptions and to free any used resources in the finally block.

    class DownloadFile
    {
        static void Main(string[] args)
        {
            string uri = "http://www.devbg.org/img/";
            string fileName = "Logo-BASD.jpg";
            string myStringWebResource = null;

            using (WebClient myWebClient = new WebClient())
            {
                try
                {
                    myStringWebResource = uri + fileName;
                    myWebClient.DownloadFile(myStringWebResource, @"..\..\" + fileName);

                    Console.WriteLine("File {0} is successfully downloaded from {1}", fileName, uri);
                    Console.WriteLine("\nDownloaded file saved in {0}", Path.GetFullPath(@"..\..\" + fileName));
                }
                catch (ArgumentNullException)
                {
                    Console.WriteLine("Invalid file");
                }
                catch (WebException)
                {
                    Console.WriteLine("No network access");
                }
                catch (NotSupportedException)
                {
                    Console.WriteLine("Method is not supported");
                }
                catch (ArgumentException)
                {
                    Console.WriteLine("Invalid file");
                }
                catch (PathTooLongException)
                {
                    Console.WriteLine("The path is too long");
                }
                catch (SecurityException)
                {
                    Console.WriteLine("You don't have permissions to view this file path");
                }
            }
        }
    }
}
