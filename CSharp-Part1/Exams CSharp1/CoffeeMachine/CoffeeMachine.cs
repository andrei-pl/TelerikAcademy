using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeMachine
{
    class CoffeeMachine
    {
        static void Main(string[] args)
        {
            System.Threading.Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.InvariantCulture;

            double lev1 = 0.05;
            double lev2 = 0.10;
            double lev3 = 0.20;
            double lev4 = 0.50;
            double lev5 = 1.00;

            int n1 = int.Parse(Console.ReadLine());
            int n2 = int.Parse(Console.ReadLine());
            int n3 = int.Parse(Console.ReadLine());
            int n4 = int.Parse(Console.ReadLine());
            int n5 = int.Parse(Console.ReadLine());

            double n1Sum = (double)n1 * lev1;
            double n2Sum = (double)n2 * lev2;
            double n3Sum = (double)n3 * lev3;
            double n4Sum = (double)n4 * lev4;
            double n5Sum = (double)n5 * lev5;

            double A = double.Parse(Console.ReadLine());
            double P = double.Parse(Console.ReadLine());

            double moneyMachine = n1Sum + n2Sum + n3Sum + n4Sum + n5Sum;

            if (A - P < 0)
            {
                Console.WriteLine("More {0:F2}", (P - A));
            }
            else if (A - P <= moneyMachine)
            {
                Console.WriteLine("Yes {0:F2}", (moneyMachine - (A - P)));
            }
            else if (A - P > moneyMachine)
            {
                Console.WriteLine("No {0:F2}", (A - P - moneyMachine));
            }
            
        }
    }
}
