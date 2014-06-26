using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.Animals
{
    abstract class Animal : ISound
    {
        public int Age { get; set; }
        public string Name { get; set; }
        public string Sex { get; set; }

        public Animal(int age, string name, string sex)
        {
            Age = age;
            Name = name;
            Sex = sex;
        }

        public static IEnumerable<Tuple<string, double>> AverageAge(Animal[] animals)
        {
            var averageAges =
                from animal in animals
                group animal by animal.GetType() into animalType
                select new Tuple<string, double>(animalType.Key.Name, animalType.Average(a => a.Age));

            return averageAges;
        } 

        abstract public void MakeNoise();
    }
}
