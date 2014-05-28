namespace Abstraction
{
    using System;

    public class Rectangle : Figure
    {
        private double width;

        private double height;

        public Rectangle()
            : this(0, 0)
        {
        }

        public Rectangle(double width, double height)
        {
            this.Width = width;
            this.Height = height;
        }

        public override double Perimeter
        {
            get { return 2 * (this.Width + this.Height); }
        }

        public override double Area
        {
            get { return this.Width * this.Height; }
        }

        public double Width
        {
            get
            {
                return this.width;
            }

            set
            {
                this.PositiveExceptionHelper(value, "Rectangle");

                this.width = value;
            }
        }

        public double Height
        {
            get
            {
                return this.height;
            }

            set
            {
                this.PositiveExceptionHelper(value, "Rectangle");

                this.height = value;
            }
        }
    }
}
