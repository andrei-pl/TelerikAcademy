using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShipDamage
{
    class ShipDamage
    {
        static void Main(string[] args)
        {
            int x1, x2, y1, y2, h, cX1, cY1, cX2, cY2, cX3, cY3;

            x1 = int.Parse(Console.ReadLine());
            y1 = int.Parse(Console.ReadLine());
            x2 = int.Parse(Console.ReadLine());
            y2 = int.Parse(Console.ReadLine());
            h = int.Parse(Console.ReadLine());
            cX1 = int.Parse(Console.ReadLine());
            cY1 = int.Parse(Console.ReadLine());
            cX2 = int.Parse(Console.ReadLine());
            cY2 = int.Parse(Console.ReadLine());
            cX3 = int.Parse(Console.ReadLine());
            cY3 = int.Parse(Console.ReadLine());

            if (x1 > x2)
            {
                int temp = x1;
                x1 = x2;
                x2 = temp;
            }
            if (y1 < y2)
            {
                int temp = y1;
                y1 = y2;
                y2 = temp;
            }
            int damage = 0;

            cY1 = 2 * h - cY1;
            cY2 = 2 * h - cY2;
            cY3 = 2 * h - cY3;

            if (cX1 >= x1 && cX1 <= x2 && cY1 <= y1 && cY1 >= y2)
            {
                if((cX1 == x1 || cX1 == x2) && (cY1 == y1 || cY1 == y2))
                {
                    damage += 25;
                }
                else if ((cX1 > x1 && cX1 < x2 && (cY1 == y1 || cY1 == y2)) || (cY1 < y1 && cY1 > y2 && (cX1 == x1 || cX1 == x2)))
                {
                    damage += 50;
                }
                else
                {
                    damage += 100;
                }
            }
            if (cX2 >= x1 && cX2 <= x2 && cY2 <= y1 && cY2 >= y2)
            {
                if ((cX2 == x1 || cX2 == x2) && (cY2 == y1 || cY2 == y2))
                {
                    damage += 25;
                }
                else if ((cX2 > x1 && cX2 < x2 && (cY2 == y1 || cY2 == y2)) || (cY2 < y1 && cY2 > y2 && (cX2 == x1 || cX2 == x2)))
                {
                    damage += 50;
                }
                else
                {
                    damage += 100;
                }
            }
            if (cX3 >= x1 && cX3 <= x2 && cY3 <= y1 && cY3 >= y2)
            {
                if ((cX3 == x1 || cX3 == x2) && (cY3 == y1 || cY3 == y2))
                {
                    damage += 25;
                }
                else if ((cX3 > x1 && cX3 < x2 && (cY3 == y1 || cY3 == y2)) || (cY3 < y1 && cY3 > y2 && (cX3 == x1 || cX3 == x2)))
                {
                    damage += 50;
                }
                else
                {
                    damage += 100;
                }
            }
            Console.WriteLine(damage + "%");
        }
    }
}
