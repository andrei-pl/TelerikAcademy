using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.Animals
{
    class Program
    {
        static void Main(string[] args)
        {
            Animal[] animals = 
            {
                new Dog(12, "Sharo", "male"),
                new TomCat(4, "Pisan"),
                new Kitten(2, "Pisana"),
                new Dog(1, "Sara", "female"),
                new Frog(1, "Kikirica", "female"),
                new Frog(2, "Kikirik", "male")
            };
            foreach (var item in animals)
            {
                Console.Write(item.Name + " " + item.Sex + " ");
                item.MakeNoise();
            }

            double avAge = animals.Average(x => x.Age);
            Console.WriteLine("Average age of all: " + avAge);

            var averageAges = Animal.AverageAge(animals);

            foreach (var typeAnimal in averageAges)
            {
                Console.WriteLine("Animal: {0} with average age: {1:F2}.", typeAnimal.Item1, typeAnimal.Item2);
            }
        }
    }
}
