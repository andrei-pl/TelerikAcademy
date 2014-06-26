using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lines
{
    class Program
    {
        static void Main(string[] args)
        {
            byte[] arrayN = new byte[8];

            for (int i = 0; i < 8; i++)
			{
                arrayN[i] = byte.Parse(Console.ReadLine());
			}

            bool[] isVerticalLine = { false, false, false, false, false, false, false, false };
            bool[] isVerticalLineFinish = { false, false, false, false, false, false, false, false };

            int[] verticalCount = { 0, 0, 0, 0, 0, 0, 0, 0 };
            int[] resultLines = { 0, 0, 0, 0, 0, 0, 0, 0 };
            
            for (int row = 0; row < 8; row++)
            {
                bool isHorizontalline = false;
                int horizontalCount = 0;
                for (int col = 0; col < 8; col++)
                {
                    byte mask = (byte)(1 << col);
                    if ((byte)((arrayN[row] & mask) >> col) == 1)
                    {
                        if (row != 7)
                        {
                            if ((byte)((arrayN[row + 1] & mask) >> (col)) == 1)
                            {
                                isVerticalLine[col] = true;
                                verticalCount[col]++;
                            }
                            else
                            {
                                if (isVerticalLine[col] == true)
                                {
                                    verticalCount[col]++;
                                    resultLines[verticalCount[col] - 1]++;
                                }
                                if (isVerticalLine[col] == true)
                                {
                                    isVerticalLineFinish[col] = true;
                                }
                                verticalCount[col] = 0;
                            }
                        }
                        else
                        {
                            if (isVerticalLine[col] == true)
                            {
                                verticalCount[col]++;
                                resultLines[verticalCount[col] - 1]++;
                            }
                            if (isVerticalLine[col] == true)
                            {
                                isVerticalLineFinish[col] = true;
                            }
                            verticalCount[col] = 0;
                        }
                        if (col != 7)
                        {
                            if ((byte)((arrayN[row] & (mask << 1)) >> (col + 1)) == 1)
                            {
                                isHorizontalline = true;
                                horizontalCount++;
                            }
                            else
                            {
                                if (isVerticalLine[col] == false || (isVerticalLine[col] == true && isHorizontalline == true))
                                {
                                    horizontalCount++;
                                    resultLines[horizontalCount - 1]++;
                                }
                                isHorizontalline = false;
                                horizontalCount = 0;
                            }
                        }
                        else
                        {
                            if (isVerticalLine[col] == false || (isVerticalLine[col] == true && isHorizontalline == true))
                            {
                                horizontalCount++;
                                resultLines[horizontalCount - 1]++;
                            }
                            isHorizontalline = false;
                            horizontalCount = 0;
                        }
                        if (isVerticalLineFinish[col])
                        {
                            isVerticalLine[col] = false;
                            isVerticalLineFinish[col] = false;
                        }
                    }
                }
            }
            int numberOfLines = 0;
            int cells = 0;
            for (int i = 0; i < 8; i++)
            {
                if (resultLines[i] != 0)
                {
                    cells = i + 1;
                    numberOfLines = resultLines[i];
                }
            }
            Console.WriteLine(cells);
            Console.WriteLine(numberOfLines);
        }
    }
}
