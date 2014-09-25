namespace _2.StringsOddTimesInSequence
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Write a program that extracts from a given sequence of strings all elements that present in it odd number of times. 
    /// Example: {C#, SQL, PHP, PHP, SQL, SQL }  {C#, SQL}
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter sequense of text (separated by \",\").");
            string[] textArr = Console.ReadLine().Split(',').Select(x => x.Trim()).ToArray();

            IDictionary<string, int> dict = new SortedDictionary<string, int>();

            foreach (var item in textArr)
            {
                if (!dict.ContainsKey(item))
                {
                    dict[item] = 0;
                }
                dict[item]++;
            }

            //dict = dict.SelectMany(x => x).Where(x => x  = x% 2 !=0).ToDictionary<string, int>(item => "asd", item => true);  ne bachka

            List<string> newDict = new List<string>();

            foreach (var item in dict)
            {
                if (item.Value % 2 != 0)
                {
                    newDict.Add(item.Key);
                }
            }

            Console.WriteLine(string.Join(", ", newDict));
        }
    }
}
