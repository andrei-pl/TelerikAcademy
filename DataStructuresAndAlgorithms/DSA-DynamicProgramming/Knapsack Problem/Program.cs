namespace Knapsack_Problem
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    class Program
    {
        static void Main(string[] args)
        {
            List<Item> items = new List<Item>{
                new Item("beer", 3, 2),
                new Item("vodka", 8, 12),
                new Item("chhese", 4, 5),
                new Item("nuts", 1, 4),
                new Item("ham", 2, 3),
                new Item("whiskey", 8, 13)
            };

            int capacity = 10;

            Console.WriteLine("The best choise is: ");

            KnapsackRecursive(items, capacity);
            Console.WriteLine(String.Join(" ", KnapsackRecursive(items, capacity).Select(r => r.Name)));
            Console.WriteLine("Dynamic: " + String.Join(" ", KnapsackDynamic(items, capacity).Select(r => r.Name)));
        }

        // hacky debugging helper
        public static void PrintMatrix(int[,] mx, int untilRow, List<Item> items)
        {
            const int FOO = 17;
            // Console.Write(new string(' ', FOO));

            Console.Write("R ITEM     W  V |");

            for (int col = 0; col < mx.GetLength(1); ++col)
            {
                Console.Write((col + "").PadLeft(2, ' ').PadRight(3, ' '));
            }
            Console.WriteLine();
            Console.WriteLine(new string('-', FOO + mx.GetLength(1) * 3));

            for (int row = 0; row <= untilRow; ++row)
            {
                Console.Write("{0} ", row);
                Console.Write("{0:0} ", items[row].Name.PadRight(8, ' '));
                Console.Write("{0:0} ", items[row].Weight);
                Console.Write("{0:0} |", (items[row].Value + "").PadLeft(2, ' '));

                for (int col = 0; col < mx.GetLength(1); ++col)
                {
                    Console.Write("{0:00} ", mx[row, col]);
                }
                Console.WriteLine();
            }
            Console.WriteLine();

        }
        public static List<Item> KnapsackDynamic(List<Item> items, decimal capacity)
        {
            // for the recursive implementation

            if (capacity == 0)
                return new List<Item>();

            if (items.Count == 0)
                return new List<Item>();


            // row X contains the maximal value using items[0..X]
            // valuesArray[X,Y]: contains the maximal value for capacity = Y using items[0..X]

            // the max solution using items[0..X+1] for capacity Y is:
            // (let currentItem = items[X+1])
            // a) the max solution for the same capacity without currentItem, i.e. valuesArray[X,Y]
            // b) the max solution for capacity (Y - currentItem.Weight), without currentItem, + currentItem.Value
            // i.e. valuesArray[X,Y - currentItem.Weight] + currentItem.Value

            decimal[,] valuesArray = new decimal[items.Count, (int)capacity + 1];

            // keepArray[X,Y]: if item X is included in the maximal solution for capacity Y

            decimal[,] keepArray = new decimal[items.Count, (int)capacity + 1];


            // fill the base cases 

            // capacity 0 => maximum solution is 0, with no items taken

            for (int x = 0; x <= items.Count - 1; x++)
            {
                valuesArray[x, 0] = 0;
                keepArray[x, 0] = 0;
            }

            // only 1 item => either we take it or we don't

            for (int y = 1; y <= capacity; y++)
            {
                if (items[0].Weight <= y)
                {
                    valuesArray[0, y] = items[0].Value;
                    keepArray[0, y] = 1;
                }
                else
                {
                    valuesArray[0, y] = 0;
                    keepArray[0, y] = 0;
                }
            }


            // now fill the table

            for (int x = 0; x <= items.Count - 2; x++)
            {
                for (int y = 1; y <= capacity; y++)
                {
                    var currentItem = items[x + 1];

                    if (currentItem.Weight > y)
                    {
                        // not enough space - just skip the current item

                        valuesArray[x + 1, y] = valuesArray[x, y];

                        continue;
                    }

                    // decide whether we take or drop the current item

                    decimal valueWhenDropping = valuesArray[x, y];
                    decimal valueWhenTaking = valuesArray[x, y - (int)currentItem.Weight] + currentItem.Value;

                    // which is better?

                    if (valueWhenTaking > valueWhenDropping)
                    {
                        valuesArray[x + 1, y] = valueWhenTaking;
                        keepArray[x + 1, y] = 1;
                    }
                    else
                    {
                        valuesArray[x + 1, y] = valueWhenDropping;
                        keepArray[x + 1, y] = 0;
                    }
                }
            }
            var bestItems = new List<Item>();

            {
                decimal remainingSpace = capacity;
                int item = items.Count - 1;

                while (item >= 0 && remainingSpace >= 0)
                {
                    // if we've taken the item

                    if (keepArray[item, (int)remainingSpace] == 1)
                    {
                        // go up and left

                        bestItems.Add(items[item]);
                        remainingSpace -= (decimal)items[item].Weight;
                        item -= 1;
                    }
                    else
                    {
                        // else go up

                        item -= 1;
                    }
                }
            }

            return bestItems;
        }
        public static List<Item> KnapsackRecursive(List<Item> items, double capacity)
        {
            // base cases

            if (capacity <= 0 || items.Count == 0)
                return new List<Item>();

            // decide whether we take or drop the current item

            var x = items.Count - 1;
            var currentItem = items[x];

            var bestWhenDropping = KnapsackRecursive(items.Take(x).ToList(), capacity);

            if (capacity < currentItem.Weight)
                return bestWhenDropping;

            var bestWhenTaking = KnapsackRecursive(items.Take(x).ToList(), capacity - currentItem.Weight);

            bestWhenTaking.Add(currentItem);

            var valueWhenTaking = bestWhenTaking.Sum(i => i.Value);
            var valueWhenDropping = bestWhenDropping.Sum(i => i.Value);

            if (valueWhenTaking > valueWhenDropping)
            {
                return bestWhenTaking;
            }
            else
            {
                return bestWhenDropping;
            }
        }
    }
}
