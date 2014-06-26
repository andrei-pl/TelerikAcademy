using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pillars
{
    class Pillars
    {
        static void Main(string[] args)
        {
            byte[] number = new byte[8];

            for (int i = 0; i < 8; i++)
            {
                number[i] = byte.Parse(Console.ReadLine());
            }
           
            int pillar = -1;
            int fullCells = 0;

            for (int pil = 0; pil < 8; pil++)
            {
                int leftSide = 0;
                for (int row = 0; row < 8; row++)
                {
                    for (int col = 0; col < pil; col++)
                    {
                        if ((byte)((number[row] >> col) & 1) == 1)
                        {
                            leftSide++;
                        }
                    }
                }

                int rightSide = 0;
                for (int row = 0; row < 8; row++)
                {
                    for (int col = pil + 1; col < 8; col++)
                    {
                        if ((byte)((number[row] >> col) & 1) == 1)
                        {
                            rightSide++;
                        }
                    }
                }
                if (leftSide == rightSide)
                {
                    fullCells = leftSide;
                    pillar = pil;
                }
            }
            if (pillar != -1)
            {
                Console.WriteLine(pillar);
                Console.WriteLine(fullCells);
            }
            else
            {
                Console.WriteLine("No");
            }
        }
    }
}
