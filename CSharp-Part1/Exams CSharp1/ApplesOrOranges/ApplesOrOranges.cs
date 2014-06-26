using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplesOrOranges
{
    class ApplesOrOranges
    {
        static void Main(string[] args)
        {
            string fruits = Console.ReadLine();
            int apples = 0;
            int oranges = 0;

            for (int i = 0; i < fruits.Length; i++)
            {
                if (i % 2 == 0)
                {
                    oranges += Int32.Parse(fruits[i].ToString());
                }
                else
                {
                    apples += Int32.Parse(fruits[i].ToString());
                }
            }

            if (apples > oranges)
            {
                Console.WriteLine("apples " + apples);
            }
            else if (apples < oranges)
            {
                Console.WriteLine("oranges " + oranges);
            }
            else
            {
                Console.WriteLine("both " + apples);
            }
        }
    }
}
