namespace Methods
{
    using System;

    public class Program
    {
        public static double CalcTriangleArea(double a, double b, double c)
        {
            if (a <= 0 || b <= 0 || c <= 0)
            {
                throw new ArgumentOutOfRangeException("Sides should be positive.");
            }

            if (a + b < c || b + c < a || a + c < b)
            {
                throw new ArgumentException("Impossible to form a triangle with this sides.");
            }

            double p = (a + b + c) / 2;
            double area = Math.Sqrt(p * (p - a) * (p - b) * (p - c));
            return area;
        }

        public static readonly string[] DigitsAsString = { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };

        public static string NumberToDigit(int number)
        {
            int digitsLength = DigitsAsString.Length;
            if (number > digitsLength || number < 0)
            {
                throw new ArgumentException("This is not a digit. Must be in the range [0, 9]!");
            }

            return DigitsAsString[number];
        }

        public static int FindMax(params int[] elements)
        {
            if (elements == null)
            {
                throw new ArgumentNullException("Elements not found!");
            }

            if (elements.Length == 0)
            {
                throw new ArgumentException("Enter at least one argument!");
            }

            int maximalElement = elements[0];

            for (int i = 1; i < elements.Length; i++)
            {
                if (elements[i] > maximalElement)
                {
                    maximalElement = elements[i];
                }
            }

            return maximalElement;
        }

        public static void PrintAsFloat(object number)
        {
            Console.WriteLine("{0:f2}", number);
        }

        public static void PrintAsPercent(object number)
        {
            Console.WriteLine("{0:p0}", number);
        }

        public static void PrintRightAligned(object number)
        {
            Console.WriteLine("{0,8}", number);
        }

        public static bool IsVertical(Point p1, Point p2)
        {
            return p1.X == p2.X;
        }

        public static bool IsHorizontal(Point p1, Point p2)
        {
            return p1.Y == p2.Y;
        }

        public static double CalcDistance(Point p1, Point p2)
        {
            double x = Math.Pow(p2.X - p1.X, 2);
            double y = Math.Pow(p2.Y - p1.Y, 2);

            return Math.Sqrt(x + y);
        }

        public static void Main()
        {
            Console.WriteLine(CalcTriangleArea(3, 4, 5));

            Console.WriteLine(NumberToDigit(5));

            Console.WriteLine(FindMax(5, -1, 3, 2, 14, 2, 3));

            PrintAsFloat(1.3);
            PrintAsPercent(0.75);
            PrintRightAligned(2.30);

            Point p1 = new Point(3, -1);
            Point p2 = new Point(3.0, 2.5);

            bool horizontal = IsHorizontal(p1, p2);
            bool vertical = IsVertical(p1, p2);

            Console.WriteLine(CalcDistance(p1, p2));
            Console.WriteLine("Horizontal? " + horizontal);
            Console.WriteLine("Vertical? " + vertical);

            Student peter = new Student() { FirstName = "Peter", LastName = "Ivanov" };
            peter.BirthDate = new DateTime(1992, 03, 17);
            peter.OtherInfo = "From Sofia";

            Student stella = new Student() { FirstName = "Stella", LastName = "Markova" };
            stella.BirthDate = new DateTime(1993, 11, 03);
            stella.OtherInfo = "From Vidin, gamer, high results";

            Console.WriteLine("{0} older than {1} -> {2}", peter.FirstName, stella.FirstName, peter.IsOlderThan(stella));
        }
        
        private struct Point
        {
            public Point(double a, double b)
                : this()
            {
                this.X = a;
                this.Y = b;
            }

            public double X { get; private set; }

            public double Y { get; private set; }
        }
    }
}
