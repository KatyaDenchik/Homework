using System;

namespace IZVP3_1Triangle
{



    public class Triangle
    {
        public double a;
        public double c;
        public double b;

        public Triangle() { }
        public Triangle(double a, double b, double c)
        {
            Console.WriteLine($"Сторона a: {a}");
            Console.WriteLine($"Сторона b: {b}");
            Console.WriteLine($"Сторона c: {c}");
        }

        public Triangle(int x1, int x2, int x3, int y1, int y2, int y3)
        {
            a = Math.Sqrt(Math.Pow((x1 - x2), 2) + Math.Pow((y1 - y2), 2));
            b = Math.Sqrt(Math.Pow((x1 - x3), 2) + Math.Pow((y1 - y3), 2));
            c = Math.Sqrt(Math.Pow((x3 - x2), 2) + Math.Pow((y3 - y2), 2));
            Console.WriteLine($"Сторона a: {a}");
            Console.WriteLine($"Сторона b: {b}");
            Console.WriteLine($"Сторона c: {c}");
        }
        public void Perimeter()
        {
            Console.WriteLine($"Периметр: {(a + b + c)}");
        }

        public void Square()
        {
            double p = (a + b + c) / 2;
            Console.WriteLine($"Площа: {Math.Sqrt(p * (p - a) * (p - b) * (p - c))}");
        }
    };

    public class RactangleTriangle : Triangle
    {
        public RactangleTriangle(int x1, int x2, int x3, int y1, int y2, int y3)
        {
            a = Math.Sqrt(Math.Pow((x1 - x2), 2) + Math.Pow((y1 - y2), 2));
            b = Math.Sqrt(Math.Pow((x1 - x3), 2) + Math.Pow((y1 - y3), 2));
            c = Math.Sqrt(Math.Pow((x3 - x2), 2) + Math.Pow((y3 - y2), 2));
            Console.WriteLine($"Сторона a(1 катет): {a}");
            Console.WriteLine($"Сторона b(2 катет): {b}");
            Console.WriteLine($"Сторона c(гіпетинуза): {c}");
        }

        public RactangleTriangle(double a_RactangleTriangle, double b_RactangleTriangle, double c_RactangleTriangle)
        {
            a = a_RactangleTriangle;
            b = b_RactangleTriangle;
            c = c_RactangleTriangle;

            Console.WriteLine($"Сторона a(1 катет): {a}");
            Console.WriteLine($"Сторона b(2 катет): {b}");
            Console.WriteLine($"Сторона c(гiпетинуза): {c}");
        }

        public void Square()
        {
            Console.WriteLine($"Площа прямокутного трикутника: {(a * b) / 2}");
        }
        public void Perimeter()
        {
            Console.WriteLine($"Периметр прямокутного трикутника: {(a + b + c)}");
        }
    }

    public class EquilateralTriangle : Triangle
    {
        public EquilateralTriangle(int x1, int x2, int x3, int y1, int y2, int y3)
        {
            a = Math.Sqrt(Math.Pow((x1 - x2), 2) + Math.Pow((y1 - y2), 2));
            b = Math.Sqrt(Math.Pow((x1 - x3), 2) + Math.Pow((y1 - y3), 2));
            c = Math.Sqrt(Math.Pow((x3 - x2), 2) + Math.Pow((y3 - y2), 2));
            Console.WriteLine($"Сторона a: {a}");
            Console.WriteLine($"Сторона b: {b}");
            Console.WriteLine($"Сторона c: {c}");
        }

        public EquilateralTriangle(double a_EquilateralTriangle, double b_EquilateralTriangle, double c_EquilateralTriangle)
        {
            a = a_EquilateralTriangle;
            b = b_EquilateralTriangle;
            c = c_EquilateralTriangle;
            Console.WriteLine($"Сторона а: {a}");
            Console.WriteLine($"Сторона b: {b}");
            Console.WriteLine($"Сторона c: {c}");
        }

        public void Square()
        {
            Console.WriteLine($"Площа прямокутного трикутника: {((Math.Pow(a, 2) * Math.Sqrt(3)) / 4)}");
        }
        public void Perimeter()
        {
            Console.WriteLine($"Периметр прямокутного трикутника: {a * 3}");
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Triangle triangle = new Triangle(3, 6, 2, 3, 6, 3);
            triangle.Perimeter();
            triangle.Square();
            Console.WriteLine();
            RactangleTriangle recTrinagle = new RactangleTriangle(2, 3, 6);
            recTrinagle.Perimeter();
            recTrinagle.Square();
            Console.WriteLine();
            EquilateralTriangle equilTrinagle = new EquilateralTriangle(8, 8, 8);
            equilTrinagle.Perimeter();
            equilTrinagle.Square();
        }
    }
}
