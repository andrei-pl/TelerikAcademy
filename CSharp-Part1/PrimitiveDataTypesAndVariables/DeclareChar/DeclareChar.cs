﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeclareChar
{
    //Declare a character variable and assign it with the symbol that has Unicode code 72. Hint: 
    //first use the Windows Calculator to find the hexadecimal representation of 72.

    class DeclareChar
    {
        static void Main(string[] args)
        {
            char charAssign = (char)0x48;
            Console.WriteLine(charAssign);
        }
    }
}
