using System;
using System.Threading;

namespace Garden
{
    class Garden
    {
        static void Main(string[] args)
        {
            Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.InvariantCulture;

            int tomatoSeedsAmount = int.Parse(Console.ReadLine());
            int tomatoArea = int.Parse(Console.ReadLine());
            int cucunberSeedsAmount = int.Parse(Console.ReadLine());
            int cucunberArea = int.Parse(Console.ReadLine());
            int potatoSeedsAmount = int.Parse(Console.ReadLine());
            int potatoArea = int.Parse(Console.ReadLine());
            int carrotSeedsAmount = int.Parse(Console.ReadLine());
            int carrotArea = int.Parse(Console.ReadLine());
            int cabbageSeedsAmount = int.Parse(Console.ReadLine());
            int cabbageArea = int.Parse(Console.ReadLine());
            int beansSeedsAmount = int.Parse(Console.ReadLine());

            double tomatoSeedsCost = 0.5;
            double cucumberSeedsCost = 0.4;
            double potatoSeedsCost = 0.25;
            double carrotSeedsCost = 0.6;
            double cabbageSeedsCost = 0.3;
            double beansSeedsCost = 0.4;
            int totalArea = 250;
            double price = tomatoSeedsAmount * tomatoSeedsCost + cucunberSeedsAmount * cucumberSeedsCost + potatoSeedsAmount * potatoSeedsCost + carrotSeedsAmount * carrotSeedsCost + cabbageSeedsAmount * cabbageSeedsCost + beansSeedsAmount * beansSeedsCost;
            int areaLeft = totalArea - tomatoArea - cucunberArea - potatoArea - carrotArea - cabbageArea;

            Console.WriteLine("Total costs: {0:F2}", price);

            if(areaLeft > 0)
            {
                Console.WriteLine("Beans area: " + areaLeft);
            }
            else if (areaLeft == 0)
            {
                Console.WriteLine("No area for beans");
            }
            else
            {
                Console.WriteLine("Insufficient area");
            }

        }
    }
}
