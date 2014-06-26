using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Kitana_01
{
    public class Validation
    {
        public static bool ValidatePersonName(string name)
        {
            Regex rgxName = new Regex(@"^[A-z]+[A-z|-][A-z]+$");
            if (rgxName.IsMatch(name))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

 

    }
}