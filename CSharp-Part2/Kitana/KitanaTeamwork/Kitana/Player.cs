using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Formatters.Binary;

namespace Kitana_01
{
    [Serializable]
    public class Player

    {
        private string firstName;
        private double totalScore;

        public string FirstName
        {
            get { return firstName; }
            set
            {
                if (Validation.ValidatePersonName(value))
                {
                    firstName = value;
                }
                else
                {
                    throw new ApplicationException("The entered name is not valid!\nAllowed symbols are: A-Z (case insensitive) and -, starting with letter.");
                }
            }
        }

        public double TotalScore
        {
            get { return totalScore; }
            set
            {
               totalScore = value;
                
            }
        }

        public Player(string firstName)
        {
            this.FirstName = firstName;       
        }

        public Player(string firstName, double totalScore)
        {
            this.FirstName = firstName;
            this.TotalScore = totalScore;
        }

       

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            result.Append(this.FirstName + " " + "Total Score " + this.TotalScore + "\n");
            return result.ToString();
        }
    }
}
