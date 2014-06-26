using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A_nacci
{
    class Anacci
    {
        static void Main(string[] args)
        {
            string[] letters = new string[2];
            letters[0] = Console.ReadLine();
            letters[1] = Console.ReadLine();
            ulong[] letterValues = new ulong [2];
            int rows = int.Parse(Console.ReadLine());
            int count = 0;
            ulong sum = 0;

            for (int i = 0; i < 2; i++)
			{
                switch (letters[i])
                {
                    case "A": letterValues[i] = 1; break;
                    case "B": letterValues[i] = 2; break;
                    case "C": letterValues[i] = 3; break;
                    case "D": letterValues[i] = 4; break;
                    case "E": letterValues[i] = 5; break;
                    case "F": letterValues[i] = 6; break;
                    case "G": letterValues[i] = 7; break;
                    case "H": letterValues[i] = 8; break;
                    case "I": letterValues[i] = 9; break;
                    case "J": letterValues[i] = 10; break;
                    case "K": letterValues[i] = 11; break;
                    case "L": letterValues[i] = 12; break;
                    case "M": letterValues[i] = 13; break;
                    case "N": letterValues[i] = 14; break;
                    case "O": letterValues[i] = 15; break;
                    case "P": letterValues[i] = 16; break;
                    case "Q": letterValues[i] = 17; break;
                    case "R": letterValues[i] = 18; break;
                    case "S": letterValues[i] = 19; break;
                    case "T": letterValues[i] = 20; break;
                    case "U": letterValues[i] = 21; break;
                    case "V": letterValues[i] = 22; break;
                    case "W": letterValues[i] = 23; break;
                    case "X": letterValues[i] = 24; break;
                    case "Y": letterValues[i] = 25; break;
                    case "Z": letterValues[i] = 26; break;
                }
			}

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j <= i; j++)
                {
                    if (count < 2)
                    {
                        if (j == 0)
                        {
                            Console.Write(letters[count]);
                        }
                        else
                        {
                            Console.Write(" " + letters[count]);
                        }
                        count++;
                    }
                    else
                    {
                        if (j == 0 || i == j)
                        {
                            sum = letterValues[0] + letterValues[1];
                            letterValues[0] = letterValues[1];
                            letterValues[1] = sum;

                            switch (sum % 26)
                            {
                                case 1: letters[1] = "A"; break;
                                case 2: letters[1] = "B"; break;
                                case 3: letters[1] = "C"; break;
                                case 4: letters[1] = "D"; break;
                                case 5: letters[1] = "E"; break;
                                case 6: letters[1] = "F"; break;
                                case 7: letters[1] = "G"; break;
                                case 8: letters[1] = "H"; break;
                                case 9: letters[1] = "I"; break;
                                case 10: letters[1] = "J"; break;
                                case 11: letters[1] = "K"; break;
                                case 12: letters[1] = "L"; break;
                                case 13: letters[1] = "M"; break;
                                case 14: letters[1] = "N"; break;
                                case 15: letters[1] = "O"; break;
                                case 16: letters[1] = "P"; break;
                                case 17: letters[1] = "Q"; break;
                                case 18: letters[1] = "R"; break;
                                case 19: letters[1] = "S"; break;
                                case 20: letters[1] = "T"; break;
                                case 21: letters[1] = "U"; break;
                                case 22: letters[1] = "V"; break;
                                case 23: letters[1] = "W"; break;
                                case 24: letters[1] = "X"; break;
                                case 25: letters[1] = "Y"; break;
                                default: letters[1] = "Z"; break;
                            }
                        }
                        if (j == 0 || i == j)
                        {
                            Console.Write(letters[1]);
                        }
                        else
                        {
                            Console.Write(" ");
                        }
                    }
                }
                Console.WriteLine();
            }
        }
    }
}
