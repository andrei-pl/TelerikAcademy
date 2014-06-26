using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TripleRotationOfDigits
{
    class TripleRotationOfDigits
    {
        static void Main(string[] args)
        {
            string number = Console.ReadLine();
            int k = int.Parse(number);
            string newNumber = "";
            
            for (int i = 0; i < 3; i++)
            {
                newNumber = number[number.Length - 1].ToString();
                for (int j = 0; j < number.Length - 1; j++)
                {
                    newNumber += number[j];
                }
                k = int.Parse(newNumber);
                number = k.ToString();
            }
            Console.WriteLine(k);
        }
    }
}
