namespace Task4_01
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int num = Convert.ToInt32(Console.ReadLine());
            long fact = 1;
            for (int i = 2; i <= num; i++)
            {
                fact *= i;
            }
            Console.WriteLine(fact);
            Console.ReadKey();
        }
    }
}
