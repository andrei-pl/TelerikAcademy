namespace Binary_passwords
{
    using System;
    using System.Linq;
    using System.Numerics;

    class Program
    {
        static BigInteger combinations = 0;

        static void Main(string[] args)
        {
            string password = Console.ReadLine();
            int count = 0;

            foreach (var star in password)
            {
                if (star == '*')
                {
                    count++;
                }
            }

            //Better way - Without recursion

            //BigInteger result = 1;
            //for (int i = 0; i < count; i++)
            //{
            //    result = result << 1;
            //}

            //Console.WriteLine(result);

            Forwgray(count);
            Console.WriteLine(combinations);
        }

        static void Print()
        {
            combinations++;
        }

        static void Backgray(int k)
        {
            if (0 == k) { Print(); return; }
            Forwgray(k - 1);
            Backgray(k - 1);
        }
        static void Forwgray(int k)
        {
            if (0 == k) { Print(); return; }
            Forwgray(k - 1);
            Backgray(k - 1);
        }

    }
}
