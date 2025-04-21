namespace Task4_02
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int num = Convert.ToInt32(Console.ReadLine());
            double result = 0.0;
            for (int i = 1; i <= num; i++)
            {
                result = result + 1.0 / i;
            }
            Console.WriteLine(result);
            Console.ReadKey();
        }
    }
}
