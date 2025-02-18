namespace Task2_5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double length = Convert.ToDouble (Console.ReadLine());
            int lengthTotal = (int)Math.Ceiling(length);
            Console.WriteLine (lengthTotal);
            Console.ReadKey();
        }
    }
}
