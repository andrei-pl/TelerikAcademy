using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExcelColumns
{
    class ExcelColumns
    {
        static void Main(string[] args)
        {
            int columnSequence = int.Parse(Console.ReadLine());
            string[] numColumn = new string[columnSequence];
            double column = 0;

            for (int i = numColumn.Length - 1; i >= 0 ; i--)
            {
                numColumn[i] = Console.ReadLine();

                switch (numColumn[i])
                {
                    case "A": column += Math.Pow(26, i)*1; break;
                    case "B": column += Math.Pow(26, i)*2; break;
                    case "C": column += Math.Pow(26, i)*3; break;
                    case "D": column += Math.Pow(26, i)*4; break;
                    case "E": column += Math.Pow(26, i)*5; break;
                    case "F": column += Math.Pow(26, i)*6; break;
                    case "G": column += Math.Pow(26, i)*7; break;
                    case "H": column += Math.Pow(26, i)*8; break;
                    case "I": column += Math.Pow(26, i)*9; break;
                    case "J": column += Math.Pow(26, i)*10; break;
                    case "K": column += Math.Pow(26, i)*11; break;
                    case "L": column += Math.Pow(26, i)*12; break;
                    case "M": column += Math.Pow(26, i)*13; break;
                    case "N": column += Math.Pow(26, i)*14; break;
                    case "O": column += Math.Pow(26, i)*15; break;
                    case "P": column += Math.Pow(26, i)*16; break;
                    case "Q": column += Math.Pow(26, i)*17; break;
                    case "R": column += Math.Pow(26, i)*18; break;
                    case "S": column += Math.Pow(26, i)*19; break;
                    case "T": column += Math.Pow(26, i)*20; break;
                    case "U": column += Math.Pow(26, i)*21; break;
                    case "V": column += Math.Pow(26, i)*22; break;
                    case "W": column += Math.Pow(26, i)*23; break;
                    case "X": column += Math.Pow(26, i)*24; break;
                    case "Y": column += Math.Pow(26, i)*25; break;
                    case "Z": column += Math.Pow(26, i)*26; break;
                }
            }
            Console.WriteLine(column);
        }
    }
}
