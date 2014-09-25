namespace _2.TraverseWindows
{
    using System;
    using System.Collections.Generic;
    using System.IO;

    /// <summary>
    /// Write a program to traverse the directory C:\WINDOWS and all its subdirectories recursively and to display all files matching the mask *.exe. 
    /// Use the class System.IO.Directory.
    /// </summary>
    public class Program
    {
        private static List<string> files = new List<string>();

        public static void Main()
        {
            string rootPath = @"D:\Install"; //If you want change it to C\Windows but there you'll have access denied exception
            string fileExtension = "*.exe";

            TraverseDirectory(rootPath, fileExtension);

            foreach (string file in files)
            {
                Console.WriteLine(file);
            }
        }

        private static void TraverseDirectory(string currentPath, string fileExtension)
        {
            string[] currentDirFiles = Directory.GetFiles(currentPath, fileExtension);
            files.AddRange(currentDirFiles);

            string[] curretDirDirectories = Directory.GetDirectories(currentPath);
            foreach (var dir in curretDirDirectories)
            {
                TraverseDirectory(dir, fileExtension);
            }
        }
    }
}
