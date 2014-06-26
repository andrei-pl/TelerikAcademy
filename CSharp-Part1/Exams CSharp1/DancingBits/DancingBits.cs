using System;

namespace DancingBits
{
    class DancingBits
    {
        static void Main(string[] args)
        {
            int k = int.Parse(Console.ReadLine());
            int n = int.Parse(Console.ReadLine());
            string dancingNumber = "";

            for (int i = 0; i < n; i++)
            {
                int number = int.Parse(Console.ReadLine());
                dancingNumber += Convert.ToString(number, 2);
            }

            int counter = 1;
            char digit = dancingNumber[0];
            int dancingBits = 0;

            for (int i = 1; i < dancingNumber.Length; i++)
            {
                if (digit == dancingNumber[i])
                {
                    counter++;
                }
                else
                {
                    if (counter == k)
                    {
                        dancingBits++;
                    }
                    digit = dancingNumber[i];
                    counter = 1;
                }
                if (i == dancingNumber.Length - 1)
                {
                    if (counter == k)
                    {
                        dancingBits++;
                    }
                }
            }
            Console.WriteLine(dancingBits);
        }
    }
}
