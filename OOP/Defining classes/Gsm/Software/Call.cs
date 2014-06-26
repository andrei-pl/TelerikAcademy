using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gsm.Software
{
    class Call
    {
        //8. Create a class Call to hold a call performed through a GSM. It should contain date, time, dialed phone number and duration (in seconds).

        public Call(DateTime dateTime, string dialedNumber, TimeSpan currDuration)
        {
            Date = dateTime;
            DialedPhone = dialedNumber;
            Duration = currDuration;
        }

        public DateTime Date { get; private set; }

        private TimeSpan duration;
        public TimeSpan Duration
        {
            get { return duration; }

            private set
            {
                if (value.Equals(TimeSpan.Zero))
                {
                    throw new ArgumentNullException("Duration can't be zero!");
                }

                this.duration = value;
            }
        }

        private string dialedPhone;
        public string DialedPhone
        {
            get { return dialedPhone; }

            private set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("Dialed phone can't be null!");
                }
                foreach (var item in value)
                {
                    if (!Char.IsDigit(item))
                    {
                        throw new FormatException("Invalid phone number");
                    }
                }

                this.dialedPhone = value;
            }
        }
    }
}
