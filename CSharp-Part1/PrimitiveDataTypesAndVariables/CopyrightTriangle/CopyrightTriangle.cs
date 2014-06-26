using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CopyrightTriangle
{
    //Write a program that prints an isosceles triangle of 9 copyright symbols ©. Use Windows Character Map to find the Unicode code of the © symbol.
    //Note: the © symbol may be displayed incorrectly.

    class CopyrightTriangle
    {
        static void Main(string[] args)
        {
            char copyright = '\u00A9';
            int a = 3;
            int b = 3;

            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 7; j++)
                {
                    if (i == 0 && j == 3)           //for the first row
                    {
                        Console.Write(copyright);
                        a--;
                        b++;
                        j++;
                    }
                    else if (a == j)                //all ather rows
                    {
                        Console.Write(copyright);
                        a--;
                    }
                    else if (b == j)
                    {
                        Console.Write(copyright);
                        b++;
                        j++;
                    }
                    else if (i == 3 && (j % 2) == 0)  //for the last row
                    {
                        Console.Write(copyright);
                    }
                    else
                    {
                        Console.Write(" ");
                    }
                    
                }
                Console.WriteLine();
            }

           
        }
    }
}
