using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gsm.Hardware
{
    class Display
    {
        //5. Use properties to encapsulate the data fields inside the GSM, Battery and Display classes. 
        //Ensure all fields hold correct data at any given time.
        private double size;
        public double Size 
        {
            get { return size; }
            set
            {
                if (value <= 0 || value > 10)
                {
                    throw new ArgumentOutOfRangeException("Invalid size!");
                }
                size = value;
            }
        }

        private int numberOfColors;
        public int NumberOfColors
        {
            get { return numberOfColors; }
            set
            {
                if (value <= 0 || value > 16000000)
                {
                    throw new ArgumentOutOfRangeException("Invalid number of colors!");
                }
                numberOfColors = value;
            }
        }
        
        public Display (double size = 0, int numberOfColors = 0)
        {
            Size = size;
            NumberOfColors = numberOfColors;
        }

        public override string ToString()
        {
            string info = "";
           
            if (Size > 0)
            {
                info += "Size: " + Size + " inch. ";
            }
            
            if (NumberOfColors > 0)
            {
                info += "Colors: " + NumberOfColors;
            }
            return info;
        }
    }
}
