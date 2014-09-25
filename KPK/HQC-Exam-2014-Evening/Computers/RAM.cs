namespace Computers.UI.Console
{
    public class RAM
    {
        private int value;

        internal RAM(byte amount)
        {
            this.Amount = amount;
        }

        public byte Amount { get; private set; }

        public void SaveValue(int newValue)
        {
            this.value = newValue;
        }

        public int LoadValue()
        {
            return this.value;
        }
    }
}