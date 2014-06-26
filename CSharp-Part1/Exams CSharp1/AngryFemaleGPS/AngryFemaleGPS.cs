using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AngryFemaleGPS
{
    class AngryFemaleGPS
    {
        static void Main(string[] args)
        {
            string direction = Console.ReadLine();
            int left = 0;
            int right = 0;

            for (int i = 0; i < direction.Length; i++)
            {
                if (char.IsDigit(direction[i]))
                {
                    int digit = Int32.Parse(direction[i].ToString());
                    if (digit % 2 == 0)
                    {
                        right += Int32.Parse(direction[i].ToString());
                    }
                    else
                    {
                        left += Int32.Parse(direction[i].ToString());
                    }
                }
            }

            if (left > right)
            {
                Console.WriteLine("left " + left);
            }
            else if (left < right)
            {
                Console.WriteLine("right " + right);
            }
            else
            {
                Console.WriteLine("straight " + left);
            }
        }
    }
}
