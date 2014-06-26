using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BullsAndCows
{
    class BullsAndCows
    {
        static void Main(string[] args)
        {
            int secretNumber = int.Parse(Console.ReadLine());

            int bulls = int.Parse(Console.ReadLine());

            int cows = int.Parse(Console.ReadLine());

            bool match = false;
            
            for (int i = 1111; i <= 9999; i++)
            {
                char[] secretN = secretNumber.ToString().ToCharArray();
                char[] iString = i.ToString().ToCharArray();
                int bullsCounter = 0;
                int cowsCounter = 0;

                if (!iString.Contains('0'))
                {
                    for (int m = 0; m < 4; m++)
                    {
                        if (secretN[m] == iString[m])
                        {
                            bullsCounter++;
                            secretN[m] = '#';
                            iString[m] = '*';
                        }
                    }
                    for (int m = 0; m < 4; m++)
                    {
                        for (int n = 0; n < 4; n++)
                        {
                            if (secretN[m] == iString[n])
                            {
                                cowsCounter++;
                                secretN[m] = '#';
                                iString[n] = '*';
                            }

                        }
                    }
                    if (bullsCounter == bulls && cowsCounter == cows)
                    {
                        match = true;
                        Console.Write(i + " ");
                    }
                }
            }

            if (match == false)
            {
                Console.WriteLine("No");
            }
        }
    }
}
