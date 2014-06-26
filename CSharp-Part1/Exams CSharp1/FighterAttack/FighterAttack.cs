using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FighterAttack
{
    class FighterAttack
    {
        static void Main(string[] args)
        {

            int pX1, pX2, pY1, pY2, d, fX, fY;

            pX1 = int.Parse(Console.ReadLine());
            pY1 = int.Parse(Console.ReadLine());
            pX2 = int.Parse(Console.ReadLine());
            pY2 = int.Parse(Console.ReadLine());
            fX = int.Parse(Console.ReadLine());
            fY = int.Parse(Console.ReadLine());
            d = int.Parse(Console.ReadLine());

            int minX1 = Math.Min(pX1, pX2);
            int maxX2 = Math.Max(pX1, pX2);
            int maxY1 = Math.Max(pY1, pY2);
            int minY2 = Math.Min(pY1, pY2);

            int damage = 0;
            fX += d;
            int fXFront = fX + 1;
            int fYUp = fY + 1;
            int fYDown = fY - 1;

            if (fYUp <= maxY1 && fYUp >= minY2 && fX >= minX1 && fX <= maxX2)
            {
                damage += 50;
            } 
            if (fYDown <= maxY1 && fYDown >= minY2 && fX >= minX1 && fX <= maxX2)
            {
                damage += 50;
            } 
            if (fY <= maxY1 && fY >= minY2 && fX >= minX1 && fX <= maxX2)
            {
                damage += 100;
            } 
            if (fY <= maxY1 && fY >= minY2 && fXFront >= minX1 && fXFront <= maxX2)
            {
                damage += 75;
            }
            
            Console.WriteLine(damage + "%");
        }
    }
}
