using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfPage
{
    class GameOfPage
    {
        static bool topLeft = false;
        static bool topMiddle = false;
        static bool topRight = false;
        static bool middleLeft = false;
        static bool middleRight = false;
        static bool bottomLeft = false;
        static bool bottomMiddle = false;
        static bool bottomRight = false;

        static void Main(string[] args)
        {
            const double price = 1.79;

            char[][] cookiePan = new char[16][];
            for (int i = 0; i < cookiePan.GetLength(0); i++)
            {
                cookiePan[i] = Console.ReadLine().ToCharArray();
            }

            string word = Console.ReadLine();
            double spend = 0;

            while (word != "paypal")
            {
                int x;
                int y;
                bool isCookie = false;

                topLeft = false;
                topMiddle = false;
                topRight = false;
                middleLeft = false;
                middleRight = false;
                bottomLeft = false;
                bottomMiddle = false;
                bottomRight = false;

                if (word == "what is")
                {
                    x = int.Parse(Console.ReadLine());
                    y = int.Parse(Console.ReadLine());

                    isCookie = checkIsCookie(cookiePan, x, y);

                    if (isCookie)
                    {
                        Console.WriteLine("cookie");
                    }
                    else
                    {
                        if (!topLeft && !topMiddle && !topRight && !middleLeft && !middleRight && !bottomLeft && !bottomMiddle && !bottomRight && cookiePan[x][y] == '0' || cookiePan[x][y] == '0')
                        {
                            Console.WriteLine("smile");
                        }
                        else if (cookiePan[x][y] == '1' && !topLeft && !topMiddle && !topRight && !middleLeft && !middleRight && !bottomLeft && !bottomMiddle && !bottomRight)
                        {
                            Console.WriteLine("cookie crumb");
                        }
                        else
                        {
                            Console.WriteLine("broken cookie");
                        }
                    }
                }
                else if (word == "buy")
                {
                    x = int.Parse(Console.ReadLine());
                    y = int.Parse(Console.ReadLine());

                    isCookie = checkIsCookie(cookiePan, x, y);
                    if (isCookie)
                    {
                        spend += price;

                        cookiePan[x - 1][y - 1] = cookiePan[x - 1][y] = cookiePan[x - 1][y + 1] = cookiePan[x][y - 1] = cookiePan[x][y] = cookiePan[x][y + 1] = cookiePan[x + 1][y - 1] = cookiePan[x + 1][y] = cookiePan[x + 1][y + 1] = '0';
                    }
                    else
                    {
                        if (!topLeft && !topMiddle && !topRight && !middleLeft && !middleRight && !bottomLeft && !bottomMiddle && !bottomRight && cookiePan[x][y] == '0' || cookiePan[x][y] == '0')
                        {
                            Console.WriteLine("smile");
                        }
                        else
                        {
                            Console.WriteLine("page");
                        }
                    }

                }

                word = Console.ReadLine();
            }

            Console.WriteLine("{0:0.00}", spend);
        }

        private static bool checkIsCookie(char[][] cookiePan, int x, int y)
        {
            int row = x;
            int col = y;

            if (row > 0)
            {
                if (cookiePan[row - 1][col] == '1')
                {
                    topMiddle = true;
                }
                if (col > 0)
                {
                    if (cookiePan[row - 1][col - 1] == '1')
                    {
                        topLeft = true;
                    }
                }
                if (col < 15)
                {
                    if (cookiePan[row - 1][col + 1] == '1')
                    {
                        topRight = true;
                    }
                }
            }
            if (col > 0)
            {
                if (cookiePan[row][col - 1] == '1')
                {
                    middleLeft = true;
                }
            }
            if (col < 15)
            {
                if (cookiePan[row][col + 1] == '1')
                {
                    middleRight = true;
                }
            }
            if (row < 15)
            {
                if (cookiePan[row + 1][col] == '1')
                {
                    bottomMiddle = true;
                }
                if (col > 0)
                {
                    if (cookiePan[row + 1][col - 1] == '1')
                    {
                        bottomLeft = true;
                    }
                }
                if (col < 15)
                {
                    if (cookiePan[row + 1][col + 1] == '1')
                    {
                        bottomRight = true;
                    }
                }
            }

            return topLeft && topMiddle && topRight && middleLeft && middleRight && bottomLeft && bottomMiddle && bottomRight;
        }
    }
}
