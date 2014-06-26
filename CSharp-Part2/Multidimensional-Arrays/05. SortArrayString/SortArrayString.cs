using System;
using System.Collections;

namespace _05.SortArrayString
{
    //You are given an array of strings. Write a method that sorts the array by the length of its elements (the number of characters composing them).

    class SortArrayString
    {
        class StringComparer : IComparer
        {
            public int Compare(object x, object y)
            {
                if (x.ToString().Length != y.ToString().Length)
                {
                    return x.ToString().Length.CompareTo(y.ToString().Length);
                }
                return x.ToString().CompareTo(y.ToString());
 
            }
        }
        static void Main(string[] args)
        {
            //Variant 1:
            Console.WriteLine("Enter some array of strings.");
            string text = Console.ReadLine();
            string[] separators = new string[] { " ", "\t" };
            string[] array = text.Split(separators, StringSplitOptions.RemoveEmptyEntries);

            Array.Sort(array, new StringComparer());
           //Array.Sort(array, (x, y) => x.ToString().Length.CompareTo(y.ToString().Length));  //Variant 2

            foreach (var element in array)
            {
                Console.WriteLine(element);
            }
            //Variant 3:
            //string[] unsortedString = { "a", "aaaaa", "aaaawasdawd", "a", "12355asdf", "wdasdwe" };
            //foreach (var item in unsortedString.OrderBy(uSorted => uSorted.Length))
            //{
            //    Console.WriteLine(item);
            //}

            //Variant 4:
            //foreach (string s in SortByLength(array))
            //{
            //    Console.WriteLine(s);
            //}

        }

        //static IEnumerable<string> SortByLength(IEnumerable<string> e)
        //{
        //    var sorted = from s in e
        //                 orderby s.Length ascending
        //                 select s;
        //    return sorted;
        //}
    }
}
