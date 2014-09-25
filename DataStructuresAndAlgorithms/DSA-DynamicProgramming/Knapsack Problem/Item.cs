namespace Knapsack_Problem
{
    public class Item
    {
        private decimal value;
        private double weight;
        private string name;
        public Item( string name, double weight, decimal value)
        {
            this.value = value;
            this.weight = weight;
            this.name = name;
        }
        public string Name
        {
            get
            {
                return this.name;
            }
        }

        public double Weight
        {
            get
            {
                return this.weight;
            }
        }

        public decimal Value
        {
            get
            {
                return this.value;
            }
        }
    }
}
