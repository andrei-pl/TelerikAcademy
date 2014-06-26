namespace _01.Cooking
{
    using System;

    public class Program
    {
        public void Cook();

        public void Cook()
        {
            Potato potato = this.GetPotato();
            this.Peel(this.potato);
            this.Cut(this.potato);

            Carrot carrot = this.GetCarrot();
            this.Peel(this.carrot);
            this.Cut(this.carrot);

            Bowl bowl = this.GetBowl();
            this.bowl.Add(this.carrot);
            this.bowl.Add(this.potato);
        }

        private Potato GetPotato()
        {
            //...
        }

        public class Chef
        {
            private Bowl GetBowl()
            {
                //... 
            }

            private Carrot GetCarrot()
            {
                //...
            }

            private void Cut(Vegetable potato)
            {
                //...
            }
        }
    }
}
