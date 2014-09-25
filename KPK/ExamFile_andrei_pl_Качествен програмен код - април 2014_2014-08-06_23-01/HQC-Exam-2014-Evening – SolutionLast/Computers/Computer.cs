namespace Computers.UI.Console
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Computer : IComputer
    {
        private readonly LaptopBattery battery;

        internal Computer(ComputerType type, Processor cpu, RAM ram, IEnumerable<HDD> hardDrives, HDD videoCard, LaptopBattery battery)
        {
            this.Cpu = cpu;
            this.Ram = ram;
            this.HardDrives = hardDrives;
            this.VideoCard = videoCard;
            if (type != ComputerType.Laptop && type != ComputerType.PC)
            {
                this.VideoCard.IsMonochrome = true;
            }

            this.battery = battery;
        }

        public Processor Cpu { get; private set; }

        public RAM Ram { get; private set; }

        private IEnumerable<HDD> HardDrives { get; set; }

        private HDD VideoCard { get; set; }

        public void Play(int guessNumber)
        {
            this.Cpu.GetRandomNumber(1, 10);
            var number = this.Ram.LoadValue();
            if (number != guessNumber)
            {
                this.VideoCard.Draw(string.Format("You didn't guess the number {0}.", number));
            }
            else
            {
                this.VideoCard.Draw("You win!");
            }
        }

        public void ChargeBattery(int percentage)
        {
            this.battery.Charge(percentage);

            this.VideoCard.Draw(string.Format("Battery status: {0}", this.battery.Percentage));
        }

        public void Proccess(int data)
        {
            this.Ram.SaveValue(data);
            
            this.Cpu.SquareNumber();
        }
    }
}
