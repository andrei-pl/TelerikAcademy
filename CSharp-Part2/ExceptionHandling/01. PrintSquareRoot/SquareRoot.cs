using System;

namespace _01.PrintSquareRoot
{
    class SquareRoot
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter valid positive number!");
            try
            {
                double n = double.Parse(Console.ReadLine());
                if (n <= 0)
                {
                    throw new ArgumentOutOfRangeException();
                }
                Console.WriteLine(Math.Sqrt(n));
            }
            catch (ArgumentNullException)
            {
                Console.Error.WriteLine("Invalid number");
            }

            catch (FormatException)
            {
                Console.Error.WriteLine("Invalid number");
            }

            catch (OverflowException)
            {
                Console.Error.WriteLine("Invalid number");
            }
            catch (ArgumentOutOfRangeException)
            {
                Console.WriteLine("Invalid number");
            }

            finally
            {
                Console.WriteLine("Good bye!");
            }
        }
    }
}
