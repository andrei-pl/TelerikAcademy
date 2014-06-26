using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfPage
{
    class Program
    {
        static void Main(string[] args)
        {
            string cookies = "";
            char[][] cookiesArray = new char[16][];
            for (int i = 0; i < 16; i++)
            {
                cookies = Console.ReadLine();
                cookiesArray[i] = cookies.ToCharArray();
            }
         
            string question = Console.ReadLine();
            int boughtCookies = 0;
            bool[] isCookie = { false, false, false, false, false, false, false, false, false };

            do
            {
                if (question == "paypal")
                {
                    break;
                }
                int row = int.Parse(Console.ReadLine());
                int col = int.Parse(Console.ReadLine());
                if (cookiesArray[row][col] == '1')
                {
                    isCookie[0] = true;
                }
                if (col - 1 >= 0)
                {
                    if (cookiesArray[row][col - 1] == '1')
                    {
                        isCookie[1] = true;
                    }
                }
                if (row - 1 >= 0)
                {
                    if (cookiesArray[row - 1][col] == '1')
                    {
                        isCookie[3] = true;
                        
                    }
                    if (col - 1 >= 0)
                    {
                        if (cookiesArray[row - 1][col - 1] == '1')
                        {
                            isCookie[2] = true;
                        }
                    }
                }
                if (col + 1 < 16)
                {
                    if (cookiesArray[row][col + 1] == '1')
                    {
                        isCookie[5] = true;
                        
                    }
                    if (row - 1 >= 0)
                    {
                        if (cookiesArray[row - 1][col + 1] == '1')
                        {
                            isCookie[4] = true;
                        }
                    }
                }
                if (row + 1 < 16)
                {
                    if (cookiesArray[row + 1][col] == '1')
                    {
                        isCookie[7] = true;
                    }
                    if (col + 1 < 16)
                    {
                        if (cookiesArray[row + 1][col + 1] == '1')
                        {
                            isCookie[6] = true;
                        }
                    }
                    if (col - 1 >= 0)
                    {
                        if (cookiesArray[row + 1][col - 1] == '1')
                        {
                            isCookie[8] = true;
                        }
                    }
                }

                
                if (question == "what is")
                {
                    if (isCookie[0] == true && isCookie[1] == true && isCookie[2] == true && isCookie[3] == true && isCookie[4] == true && isCookie[5] == true && isCookie[6] == true && isCookie[7] == true && isCookie[8] == true)
                    {
                        Console.WriteLine("cookie");
                    }
                    else if (isCookie[0] == true && isCookie[1] == false && isCookie[2] == false && isCookie[3] == false && isCookie[4] == false && isCookie[5] == false && isCookie[6] == false && isCookie[7] == false && isCookie[8] == false)
                    {
                        Console.WriteLine("cookie crumb");
                    }
                    else if (isCookie[0] == false)
                    {
                        Console.WriteLine("smile");
                    }
                    else
                    {
                        Console.WriteLine("broken cookie");
                    }
                }
                else if (question == "buy")
                {
                    if (isCookie[0] == true && isCookie[1] == true && isCookie[2] == true && isCookie[3] == true && isCookie[4] == true && isCookie[5] == true && isCookie[6] == true && isCookie[7] == true && isCookie[8] == true)
                    {
                        boughtCookies++;
                        cookiesArray[row][col] = cookiesArray[row][col - 1] = cookiesArray[row][col + 1] = cookiesArray[row - 1][col] = cookiesArray[row -1][col - 1] = cookiesArray[row - 1][col + 1] = cookiesArray[row + 1][col] = cookiesArray[row + 1][col - 1] = cookiesArray[row + 1][col + 1] = '0';
                    }
                    else if (isCookie[0] == false && isCookie[1] == false && isCookie[2] == false && isCookie[3] == false && isCookie[4] == false && isCookie[5] == false && isCookie[6] == false && isCookie[7] == false && isCookie[8] == false)
                    {
                        Console.WriteLine("smile");
                    }
                    else
                    {
                        Console.WriteLine("page");
                    }
                }
                for (int i = 0; i < 9; i++)
                {
                    isCookie[i] = false;
                }
                question = Console.ReadLine();
            } while (question != "paypal");
            Console.WriteLine("{0:F2}",boughtCookies * 1.79f);

        }
    }
}
