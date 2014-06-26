using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.Animals
{
    class Dog : Animal
    {
        public Dog(int age, string name, string sex)
            : base(age, name, sex)
        {
        }

        public override void MakeNoise()
        {
            Console.WriteLine("Bau bau");
        }
    }
}
