namespace Colored_Rabbits
{
    using System;
    using System.Collections.Generic;

    class Program
    {
        static void Main(string[] args)
        {
            int numberOfRabbitsAsked = int.Parse(Console.ReadLine());
            int rabbitsAnswers = 0;
            Dictionary<int, int> rabbits = new Dictionary<int, int>(); // key is the answer, value -> number of all rabbits

            for (int i = 0; i < numberOfRabbitsAsked; i++)
            {
                rabbitsAnswers = int.Parse(Console.ReadLine());
                if(!rabbits.ContainsKey(rabbitsAnswers))
                {
                    rabbits.Add(rabbitsAnswers, 0);
                }

                rabbits[rabbitsAnswers]++;
            }

            int result = 0;
            foreach (var rabbit in rabbits)
            {
                result += ((rabbit.Value / (rabbit.Key + 1)) * (rabbit.Key + 1));
                if(rabbit.Value % (rabbit.Key + 1) > 0)
                {
                    result += rabbit.Key + 1;
                }
            }

            Console.WriteLine(result);
        }
    }
}
