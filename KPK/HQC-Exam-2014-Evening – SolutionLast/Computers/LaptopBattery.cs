namespace Computers.UI.Console
{
    public class LaptopBattery
    {
        private const int BatteryPowerPercentage = 50;

        public LaptopBattery()
        {
            this.Percentage = BatteryPowerPercentage;
        }

        public int Percentage { get; set; }

        public void Charge(int chargingValue)
        {
            this.Percentage += chargingValue;
            if (this.Percentage > 100)
            {
                this.Percentage = 100;
            }

            if (this.Percentage < 0)
            {
                this.Percentage = 0;
            }
        }
    }
}