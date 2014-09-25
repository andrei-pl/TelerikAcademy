namespace Computers.UI.Console
{
    using System;

    public class Processor : IMotherboard
    {
        private static readonly Random RandomNumber = new Random();

        private readonly byte numberOfBits;

        private readonly RAM ram;

        private readonly HDD videoCard;

        internal Processor(byte numberOfCores, byte numberOfBits, RAM ram, HDD videoCard)
        {
            this.numberOfBits = numberOfBits;
            this.ram = ram;
            this.NumberOfCores = numberOfCores;
            this.videoCard = videoCard;
        }

        private byte NumberOfCores { get; set; }

        public void SquareNumber()
        {
            var data = this.LoadRamValue();
            if (data < 0)
            {
                this.videoCard.Draw("Number too low.");
                return;
            }

            if (this.numberOfBits == 32)
            {
                if (data > 500)
                {
                    this.videoCard.Draw("Number too high.");
                    return;
                }
            }
            else if (this.numberOfBits == 64)
            {
                if (data > 1000)
                {
                    this.videoCard.Draw("Number too high.");
                    return;
                }
            }
            else if (this.numberOfBits == 128)
            {
                if (data > 2000)
                {
                    this.videoCard.Draw("Number too high.");
                    return;
                }
            }

            int value = data * data;

            this.DrawOnVideoCard(string.Format("Square of {0} is {1}.", data, value));
        }

        public int LoadRamValue()
        {
            return this.ram.LoadValue();
        }

        public void SaveRamValue(int value)
        {
            this.ram.SaveValue(value);
        }

        public void DrawOnVideoCard(string data)
        {
            this.videoCard.Draw(data);
        }

        internal void GetRandomNumber(int minValue, int maxValue)
        {
            int randomNumber;
            randomNumber = RandomNumber.Next(minValue, maxValue);
            this.SaveRamValue(randomNumber);
        }
    }
}