using System;

namespace UKFlag
{
    class UKFlag
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int x = n/2;
            int y = n/2;
            int l = 0;
            int r = n - 1;

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (j == n / 2)
                    {
                        if (i == y)
                        {
                            Console.Write("*");
                            l++;
                            r--;
                        }
                        else
                        {
                            Console.Write("|");
                        }
                    }
                    else if (i == x)
                    {
                        Console.Write("-");
                    }
                    else if (j == l && i == l)
                    {
                        Console.Write("\\");
                        l++;
                    }
                    else if (j == r)
                    {
                        Console.Write("/");
                        r--;
                    }
                    else
                    {
                        Console.Write(".");
                    }
			    }
                Console.WriteLine();
            }
        }
    }
}
