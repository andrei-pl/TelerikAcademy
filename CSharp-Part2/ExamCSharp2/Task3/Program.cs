using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int[,] matrix = new int[n, n];

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                int[] values = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = values[j];
                }
            }

            int[,] zero = {
                              {0 ,0, 0},
                              {0, 10, 0},
                              {0, 10, 0},
                              {0, 10, 0},
                              {0, 0, 0}
                          };
            int[,] one = {
                              {10 ,10, 1},
                              {10, 1, 1},
                              {1, 10, 1},
                              {10, 10, 1},
                              {10, 10, 1}
                          };
            int[,] two = {
                              {10 ,2, 10},
                              {2, 10, 2},
                              {10, 10, 2},
                              {10, 2, 10},
                              {2, 2, 2},
                          };
            int[,] three = {
                              {3 ,3, 3},
                              {10, 10, 3},
                              {10, 3, 3},
                              {10, 10, 3},
                              {3, 3, 3}
                          };
            int[,] four = {
                              {4 ,10, 4},
                              {4, 10, 4},
                              {4, 4, 4},
                              {10, 10, 4},
                              {10, 10, 4}
                          };
            int[,] five = {
                              {5 ,5, 5},
                              {5, 10, 10},
                              {5, 5, 5},
                              {10, 10, 5},
                              {5, 5, 5}
                          };
            int[,] six = {
                              {6 ,6, 6},
                              {6, 10, 10},
                              {6, 6, 6},
                              {6, 10, 6},
                              {6, 6, 6}
                          };
            int[,] seven = {
                              {7 ,7, 7},
                              {10, 10, 7},
                              {10, 7, 10},
                              {10, 7, 10},
                              {10, 7, 10}
                          };
            int[,] eight = {
                              {8 ,8, 8},
                              {8, 10, 8},
                              {10, 8, 10},
                              {8, 10, 8},
                              {8, 8, 8}
                          };
            int[,] nine = {
                              {9 ,9, 9},
                              {9, 10, 9},
                              {10, 9, 9},
                              {10, 10, 9},
                              {9, 9, 9}
                          };

            Dictionary<int, int[,]> dict = new Dictionary<int, int[,]>();

            dict.Add(0, zero);
            dict.Add(1, one);
            dict.Add(2, two);
            dict.Add(3, three);
            dict.Add(4, four);
            dict.Add(5, five);
            dict.Add(6, six);
            dict.Add(7, seven);
            dict.Add(8, eight);
            dict.Add(9, nine);

            int counter = 0;
            for (int num = 1; num < 10; num++)
            {
                int[,] currNum = dict[num];
                for (int i = 0; i < matrix.GetLength(0) - 4; i++)
                {
                    for (int j = 0; j < matrix.GetLength(1) - 2; j++)
                    {
                        bool isValidNumber = true;
                        for (int row = 0; row < 5; row++)
                        {
                            for (int col = 0; col < 3; col++)
                            {
                                if (currNum[row, col] == num)
                                {
                                    if (matrix[i + row, j + col] != currNum[row, col])
                                    {
                                        isValidNumber = false;
                                        break;
                                    }
                                }
                            }
                            if (!isValidNumber)
                            {
                                break;
                            }
                        }
                        if (isValidNumber)
                        {
                            counter += num;
                        }
                    }
                }
            }

            Console.WriteLine(counter);
        }
    }
}
