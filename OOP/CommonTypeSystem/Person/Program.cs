namespace Person
{
    using System;

    /// <summary>
    /// 4. Create a class Person with two fields – name and age. Age can be left unspecified (may contain null value. 
    /// Override ToString() to display the information of a person and if age is not specified – to say so. Write a program to test this functionality.
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            Person person = new Person("Pesgho", null);
            Person otherPerson = new Person("Vanio", 32);
            Console.WriteLine(person);
            Console.WriteLine(otherPerson);
        }
    }
}
