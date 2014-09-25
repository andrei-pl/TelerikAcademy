namespace Salaries
{
    using System;
    using System.Linq;
    using System.IO;

    class Program
    {
        static void Main()
        {
            Console.SetIn(new StringReader(
                                                @"6
                                            NNNNNN
                                            YNYNNY
                                            YNNNNY
                                            NNNNNN
                                            YNYNNN
                                            YNNYNN"));

            var count = int.Parse(Console.ReadLine());

            // dynamic programming solution:
            // determine the number of people each person manages (directly or 
            // indirectly)
            // then calculate salaries in ascending order of managed people

            // dynamic programming table
            var salary = new long[count];

            // order of evaluation
            var managedCount = new long[count];

            // adjacency matrix
            var edge = new bool[count, count];

            for (var i = 0; i < count; ++i)
            {
                var j = 0;

                foreach (var ch in Console.ReadLine().Trim())
                {
                    edge[i, j] = (ch == 'Y');
                    managedCount[i] += edge[i, j] ? 1 : 0;
                    j += 1;
                }

                if (managedCount[i] == 0)
                {
                    salary[i] = 1;
                }
            }

            Func<int, long> getSalary = null;

            getSalary = x =>
            {
                if (salary[x] == 0)
                {
                    for (var i = 0; i < count; ++i)
                    {
                        if (edge[x, i])
                            salary[x] += getSalary(i);
                    }
                }
                return salary[x];
            };

            long total = Enumerable.Range(0, count)
                                   .OrderBy(who => managedCount[who])
                                   .Select(getSalary)
                                   .Sum();

            Console.WriteLine(total);
        }
    }
}
