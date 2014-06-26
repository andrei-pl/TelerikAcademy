using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThreeInOne
{
    class ThreeInOne
    {
        static void Main(string[] args)
        {
            int[] bridge = Console.ReadLine().Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int[] cake = Console.ReadLine().Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            Array.Sort(cake);
            Array.Reverse(cake);
            int friends = int.Parse(Console.ReadLine());
            int[] problem3 = Console.ReadLine().Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            
            
            Console.WriteLine(Task1(bridge));
            Console.WriteLine(Task2(cake, friends));
        }

        //static int Task3(int[] arr)
        //{
        //    int[] current = arr.Take(3).ToArray();
        //    int[] target = arr.Skip(3).Take(3).ToArray();

        //    const int GOLD = 0;
        //    const int SILVER = 1;
        //    const int BRONZE = 2;

        //    if (true)
        //    {
                
        //    }


        //    return 0;
        //}

        static int Task2(int[] cake, int friends)
        {
            int[] everyOne = new int[friends + 1];
            
            for (int i = 0; i < cake.Length; i++)
            {
                everyOne[i % 3] = everyOne[i % 3] + cake[i];
            }
            return everyOne[0];
        }

        static int Task1(int[] arr)
        {
            int winners = 1;
            int max = arr[0];
            for (int i = 1; i < arr.Length; i++)
            {
                if (arr[i] > max)
                {
                    max = arr[i];
                    winners = 1;
                }
                else if (arr[i] == max)
                {
                    winners++;
                }
            }

            if (winners > 1) return -1;
            return 0;
        }
    }
}
