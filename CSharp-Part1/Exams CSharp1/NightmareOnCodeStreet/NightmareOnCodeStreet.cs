using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NightmareOnCodeStreet
{
    class NightmareOnCodeStreet
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();
            int count = 0;
            int result = 0;

            for (int i = 0; i < text.Length; i++)
            {
                if (i % 2 != 0)
                {
                    if (char.IsDigit(text[i]))
                    {
                        count++;
                        result += text[i] - '0';
                    }
                }
            }

            Console.WriteLine(count + " " + result);
        }
    }
}
