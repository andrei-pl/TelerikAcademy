using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace Task2
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] area = Console.ReadLine().Split(new string[] { " ", "," }, StringSplitOptions.RemoveEmptyEntries);
            int[] terrain = new int[area.Length];
            for (int i = 0; i < area.Length; i++)
            {
                terrain[i] = int.Parse(area[i]);
            }
           
            BigInteger flowersMolly = 0;
            BigInteger flowersDolly = 0;
           // bool[] isVisited = new bool[terrain.Length];
            int posMolly = 0;
            int posDolly = terrain.Length - 1;

            while (true)
            {
                int stepMolly = terrain[posMolly];
                int stepDolly = terrain[posDolly];

                if (terrain[posMolly] != 0)
                {
                    if (posDolly != posMolly)
                    {
                        flowersMolly += (BigInteger)stepMolly;
                    }
                    else
                    {
                        flowersMolly += ((BigInteger)stepMolly / 2);
                    }

                }
                if (terrain[posDolly] != 0)
                {
                    if (posDolly != posMolly)
                    {
                        flowersDolly += (BigInteger)stepDolly;
                    }
                    else
                    {
                        flowersDolly += ((BigInteger)stepDolly / 2);
                    }
                }

                if (terrain[posMolly] == 0 || terrain[posDolly] == 0)
                {
                    if (terrain[posDolly] == 0 && terrain[posMolly] == 0)
                    {
                        Console.WriteLine("Draw");
                    }
                    else if (terrain[posDolly] == 0 && terrain[posMolly] != 0)
                    {
                        Console.WriteLine("Molly");
                    }
                    else
                    {
                        Console.WriteLine("Dolly");
                    }
                    break;
                }
                if (posDolly == posMolly)
                {
                    if (stepMolly % 2 == 1)
                    {
                        terrain[posMolly] = 1;
                    }
                    else
                    {
                        terrain[posMolly] = 0;
                    }
                }
                else
                {
                    terrain[posMolly] = 0;
                    terrain[posDolly] = 0;
                }
                posMolly = (posMolly + stepMolly) % terrain.Length;
                posDolly = (terrain.Length + posDolly - (stepDolly % terrain.Length)) % terrain.Length;
            }
            Console.WriteLine(flowersMolly + " " + flowersDolly);
        }
    }
}
