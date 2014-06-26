using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07.SortArray
{
    //Sorting an array means to arrange its elements in increasing order. Write a program to sort an array. 
    //Use the "selection sort" algorithm: Find the smallest element, move it at the first position, find the smallest from the rest, 
    //move it at the second position, etc.

    class SortArray
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Write array length");
            int n = int.Parse(Console.ReadLine());
            List<int> list = new List<int>();

            for (int i = 0; i < n; i++)
            {
                Console.Write((i + 1) + ". ");

                list.Add(int.Parse(Console.ReadLine()));
            }
            
            for (int i = 0; i < list.Count; i++)
            {
                for (int j = i + 1; j < list.Count; j++)
                {
                    if (list[i] > list[j])
                    {
                        int temp = list[i];
                        list[i] = list[j];
                        list[j] = temp;
                    }
                }
            }
            Console.WriteLine("List sorted using selection sort");
            Console.WriteLine(string.Join(", ", list));
        }
    }
}
