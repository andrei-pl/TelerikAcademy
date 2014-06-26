namespace _02.PrintStatistics
{
    using System;

    public class Program
    {
        public double Max { get; private set; }

        public double TemporaryNumber { get; private set; }

        public void PrintStatistics(double[] arrayOfNumbers, int count)
        {
            for (int i = 0; i < count; i++)
            {
                if (arrayOfNumbers[i] > this.Max)
                {
                    this.Max = arrayOfNumbers[i];
                }
            }

            this.PrintMax(this.Max);

            this.TemporaryNumber = 0;
            this.Max = 0;

            for (int i = 0; i < count; i++)
            {
                if (arrayOfNumbers[i] < this.Max)
                {
                    this.Max = arrayOfNumbers[i];
                }
            }

            this.PrintMin(this.Max);

            this.TemporaryNumber = 0;

            for (int i = 0; i < count; i++)
            {
                this.TemporaryNumber += arrayOfNumbers[i];
            }

            this.PrintAvg(this.TemporaryNumber / count);
        }

        private void PrintAvg(double avg)
        {
            throw new NotImplementedException();
        }

        private void PrintMin(double min)
        {
            throw new NotImplementedException();
        }

        private void PrintMax(double max)
        {
            throw new NotImplementedException();
        }
    }
}
