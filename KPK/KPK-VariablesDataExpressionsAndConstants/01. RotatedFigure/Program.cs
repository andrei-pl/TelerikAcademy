﻿namespace _01.RotatedFigure
{
    using System;

    public class Program
    {
        public static Coordinates Rotate(Coordinates coordinates, double angle)
        {
            double sin = Math.Abs(Math.Sin(angle));
            double cos = Math.Abs(Math.Cos(angle));

            return new Coordinates(
                cos * coordinates.X + sin * coordinates.Y,
                sin * coordinates.X + cos * coordinates.Y);
        }

        public class Coordinates
        {
            public Coordinates(double x, double y)
            {
                this.X = x;
                this.Y = y;
            }

            public double X { get; private set; }

            public double Y { get; private set; }
        }
    }
}
