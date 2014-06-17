namespace CohesionAndCoupling
{
    using System;

    public static class RectangularCuboid
    {
        public static double Width { get; set; }

        public static double Height { get; set; }

        public static double Depth { get; set; }

        public static double CalcVolume()
        {
            double volume = Width * Height * Depth;
            return volume;
        }

        public static double CalcDiagonalXyz()
        {
            return GeometryUtils.CalcDistance3D(0, 0, 0, Width, Height, Depth);
        }

        public static double CalcDiagonalXY()
        {
            return GeometryUtils.CalcDistance2D(0, 0, Width, Height);
        }

        public static double CalcDiagonalXZ()
        {
            return GeometryUtils.CalcDistance2D(0, 0, Width, Depth);
        }

        public static double CalcDiagonalYZ()
        {
            return GeometryUtils.CalcDistance2D(0, 0, Height, Depth);
        }
    }
}
