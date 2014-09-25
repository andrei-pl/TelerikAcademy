namespace _3.FileSizeSumOfSubTree
{
    using System;
    using System.Collections.Generic;
    
    /// <summary>
    /// Define classes File { string name, int size } and Folder { string name, File[] files, Folder[] childFolders } 
    /// and using them build a tree keeping all files and folders on the hard drive starting from C:\WINDOWS. 
    /// Implement a method that calculates the sum of the file sizes in given subtree of the tree and test it accordingly. 
    /// Use recursive DFS traversal.
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Tree is building, please wait for few seconds...");
            DirectoryTree dirTree = new DirectoryTree("C:\\Windows");

            Console.WriteLine("Done.");

            Console.WriteLine("\nTree size: ");
            double sizeInMB = dirTree.CalculateSizeOfTree();
            Console.WriteLine("{0} megabytes", sizeInMB);
            Console.WriteLine("{0} or gigabytes", sizeInMB / 1024);

            //in windows 8 AppCompat exists, you can try any other folder in Windows directory
            Console.WriteLine("\nCalculate size of tree folder and subfolders: ");
            sizeInMB = dirTree.CalculateSizeOfFolder("AppCompat");
            Console.WriteLine("{0} megabytes", sizeInMB);
            Console.WriteLine("{0} or gigabytes", sizeInMB / 1024);
        }
    }
}
