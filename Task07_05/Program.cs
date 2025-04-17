namespace Task07_05
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Multiply(2, 3)); 
            Console.WriteLine(Multiply(2.5, 3.5)); 

            Console.ReadKey();
        }

        static int Multiply(int a, int b)
        {
            return a * b;
        }

        static double Multiply(double a, double b)
        {
            return a * b;
        }
    }
}
