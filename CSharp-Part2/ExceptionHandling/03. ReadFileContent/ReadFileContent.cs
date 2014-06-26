using System;
using System.Text;
using System.IO;
using System.Security;

namespace _03.ReadFileContent
{
    //Write a program that enters file name along with its full file path (e.g. C:\WINDOWS\win.ini), reads its contents and prints it on the console. 
    //Find in MSDN how to use System.IO.File.ReadAllText(…). Be sure to catch all possible exceptions and print user-friendly error messages.

    class ReadFileContent
    {
        static void Main(string[] args)
        {
            string path = @"D:\test.txt";
            if (!File.Exists(path))
            {
                string text = "Some text" + Environment.NewLine;
                File.WriteAllText(path, text, Encoding.GetEncoding("windows-1251"));
            }
            try
            {
                Console.WriteLine(File.ReadAllText(path, Encoding.GetEncoding("windows-1251")));
            }
            catch (DirectoryNotFoundException)
            {
                Console.WriteLine("The file path contains a directory that cannot be found!");
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("The file '{0}' was not found!");
            }
            catch (ArgumentNullException)
            {
                Console.WriteLine("No file path is given!");
            }
            catch (ArgumentException)
            {
                Console.WriteLine("The entered file path is not correct!");
            }
            catch (PathTooLongException)
            {
                Console.WriteLine("The entered file path is too long - 248 characters are the maximum!");
            }
            catch (UnauthorizedAccessException)
            {
                Console.WriteLine("You don't have the required permission.");
            }
            catch (NotSupportedException)
            {
                Console.WriteLine("Invalid file path format!");
            }
            catch (SecurityException)
            {
                Console.WriteLine("You don't have the required permission.");
            }
            catch (IOException)
            {
                Console.WriteLine("An I/O error occurred while opening the file.");
            }
        }
    }
}
