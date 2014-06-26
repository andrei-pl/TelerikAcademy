using System;

namespace _11.VersionAttribute
{

    [VersionAttribute("2.11")]
    class Program
    {
        static void Main()
        {
            object[] versionAttributes = typeof(Program).GetCustomAttributes(typeof(VersionAttribute), false);

            Console.WriteLine("Version: {0}", versionAttributes[0]);
        }
    }
}
