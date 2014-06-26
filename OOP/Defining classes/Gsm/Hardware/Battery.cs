using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gsm.Hardware
{
    class Battery
    {
        //5. Use properties to encapsulate the data fields inside the GSM, Battery and Display classes. 
            //Ensure all fields hold correct data at any given time.
        public BatteryType Model
        {
            get;
            private set;
        }

        private int hoursIdle;
        public int HoursIdle
        {
            get { return hoursIdle; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Invalid size!");
                }
                hoursIdle = value;
            }
        }

        private int hoursTalk;
        public int HoursTalk
        {
            get { return hoursTalk; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Invalid size!");
                }
                hoursTalk = value;
            }
        }

        public Battery(BatteryType model = BatteryType.LiIon, int hoursIdle = 0, int hoursTalk = 0)
        {
            Model = model;
            HoursIdle = hoursIdle;
            HoursTalk = hoursTalk;
        }

        //3. Add an enumeration BatteryType (Li-Ion, NiMH, NiCd, …) and use it as a new field for the batteries.

        public enum BatteryType { LiIon, NiMH, NiCd }

        //4. Add a method in the GSM class for displaying all information about it. Try to override ToString().

        public override string ToString()
        {
            string info = Model + ", Hours Idle: " + HoursIdle + ", Hours Talk: " + HoursTalk;

            return info;
        }
    }
}
