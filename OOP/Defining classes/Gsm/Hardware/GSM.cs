using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gsm.Software;

namespace Gsm.Hardware
{
    class GSM
    {
        //11. Add a method that calculates the total price of the calls in the call history. 
        //Assume the price per minute is fixed and is provided as a parameter.

        private const decimal pricePerMinute = 0.37M;

        //6. Add a static field and a property IPhone4S in the GSM class to hold the information about iPhone 4S.
        private static readonly GSM iPhone4S = new GSM("Iphone4S", "Apple", 1000M, null, new Battery(Battery.BatteryType.LiIon, 0, 0), new Display(4.3, 3200000));
        public static GSM IPhone4S
        {
            get { return iPhone4S; }
        }

        //1. Define a class that holds information about a mobile phone device: model, manufacturer, price, owner, 
        //battery characteristics (model, hours idle and hours talk) and display characteristics (size and number of colors). 
        //Define 3 separate classes (class GSM holding instances of the classes Battery and Display).

        Battery battery;
        Display display;

            //5. Use properties to encapsulate the data fields inside the GSM, Battery and Display classes. 
            //Ensure all fields hold correct data at any given time.
        private string model;
        public string Model
        {
            get { return model; }
            set
            {
                if (String.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Null or empty model name!");
                }
                foreach (var ch in value.Trim())
                {
                    if (!Char.IsLetterOrDigit(ch))
                    {
                        throw new FormatException("Invalid model name!");
                    }
                }
                model = value.Trim();
            }
        }

        private string manufacturer;
        public string Manufacturer
        {
            get { return manufacturer; }
            set
            {
                if (String.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Null or empty manufacturer name!");
                }
                foreach (var ch in value.Trim())
                {
                    if (!Char.IsLetter(ch))
                    {
                        throw new FormatException("Invalid manufacturer name!");
                    }
                }
                manufacturer = value.Trim();
            }
        }

        private decimal? pricePhone;
        public decimal? PricePhone
        {
            get { return pricePhone; }
            set
            {
                if (value > 0)
                {
                    pricePhone = value;
                }
                else
                {
                    throw new ArgumentException("Invalid price!");
                }
            }
        }

        private string owner;
        public string Owner
        {
            get { return owner; }
            set
            {
                if (String.IsNullOrEmpty(value))
                {
                    owner = null;
                }
                else
                {
                    foreach (var ch in value.Trim())
                    {
                        if (!Char.IsLetter(ch) && !Char.IsWhiteSpace(ch))
                        {
                            throw new FormatException("Invalid owner name!");
                        }
                    }
                    owner = value.Trim();
                }
            }
        }
        //9. Add a property CallHistory in the GSM class to hold a list of the performed calls. Try to use the system class List<Call>.

        public List<Call> CallHistory { get; private set; }

        //10. Add methods in the GSM class for adding and deleting calls from the calls history. Add a method to clear the call history.

        //public void AddCall(Call call)    //it's the same in GSMCallHistoryClass
        //{
        //    CallHistory.Add(call);
        //}

        //public void RemoveCall(Call call)
        //{
        //    CallHistory.Remove(call);
        //}

        //public void RemoveCallAt(int index)
        //{
        //    CallHistory.RemoveAt(index);
        //}

        //public void ClearHistory()
        //{
        //    CallHistory.Clear();
        //}

        //11. Add a method that calculates the total price of the calls in the call history. 
        //Assume the price per minute is fixed and is provided as a parameter.

        public decimal GetTotalPrice()
        {
            return (decimal)(this.CallHistory.Sum(
                call => Math.Ceiling(call.Duration.TotalSeconds / 60.0))) * pricePerMinute;
        }

        //2. Define several constructors for the defined classes that take different sets of arguments 
        //(the full information for the class or part of it). Assume that model and manufacturer are mandatory (the others are optional). 
        //All unknown data fill with null.

        public GSM(string model, string manufacturer, decimal? price = null, string owner = null,Battery battery = null, Display display = null)
        {
            Model = model;
            Manufacturer = manufacturer;
            PricePhone = price;
            Owner = owner;
            this.battery = battery;
            this.display = display;

            CallHistory = new List<Call>();
        }

        //4. Add a method in the GSM class for displaying all information about it. Try to override ToString().

        public override string ToString()
        {
            List<string> info = new List<string>();
            if (Owner != null)
            {
                info.Add("Owner: " + Owner);
            }

            info.Add("Manufacturer: " + Manufacturer);
            info.Add("Model: " + Model);

            if (PricePhone != null)
            {
                info.Add("Price: " + PricePhone);
            }

            if (battery != null)
            {
                info.Add("Battery: " + battery.ToString());
            }

            if (display != null)
            {
                info.Add("Dysplay: " + display.ToString());
            }

            if (CallHistory.Count != 0)
            {
                info.Add("Call History: " + CallHistory.ToString());
            }

            return String.Join(Environment.NewLine, info);
        }

    }
}
