namespace Abstraction
{
    using System;
    using System.Collections.Generic;

    public abstract class Figure : IFigure
    {
        public abstract double Perimeter { get; }

        public abstract double Area { get; }

        public override string ToString()
        {
            List<string> info = new List<string>();

            info.Add(string.Format("I am a {0}.", this.GetType().Name));
            info.Add(string.Format("My perimeter is {0:F2}.", this.Perimeter));
            info.Add(string.Format("My surface is {0:F2}.", this.Area));

            return string.Join(" ", info);
        }

        protected void PositiveExceptionHelper(double value, string property)
        {
            if (value <= 0)
            {
                throw new ArgumentOutOfRangeException(property, "Value must be positive.");
            }
        }
    }
}
