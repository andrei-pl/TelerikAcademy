﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringConcatenation
{
    class StringConcatenation
    {
        //Declare two string variables and assign them with “Hello” and “World”. 
        //Declare an object variable and assign it with the concatenation of the first two variables (mind adding an interval). 
        //Declare a third string variable and initialize it with the value of the object variable (you should perform type casting).

        static void Main(string[] args)
        {
            string hello = "Hello";
            string world = "world!";
            object concatenation = hello + " " + world;

            string concStrings = (string)concatenation;

            Console.WriteLine(concStrings);
        }
    }
}
