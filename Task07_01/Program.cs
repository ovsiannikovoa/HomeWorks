namespace Task07_01
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int a1 = 3;
            int b1 = 4;
            int c1 = 5;

            int a2 = 4;
            int b2 = 5;
            int c2 = 6;

            double area1 = Area(a1, b1, c1);
            double area2 = Area(a2, b2, c2);

            if (area1 < area2)
            {
                Console.WriteLine("Площадь второго треугольника ({0}) больше площади первого треугольника ({1})", area2, area1);
            }
            else
            {
                Console.WriteLine("Площадь первого треугольника ({0}) больше площади второго треугольника ({1})", area1, area2);
            }
            Console.ReadKey();
        }

        static double Area(double a, double b, double c)
        {
            double perimeter = (a + b + c) / 2;
            double area = Math.Sqrt(perimeter * (perimeter - a) * (perimeter - b) * (perimeter - c));
            return area;
        }
    }
}
