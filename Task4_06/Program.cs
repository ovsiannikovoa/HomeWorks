namespace Task4_06
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = Convert.ToInt32(Console.ReadLine());

            if (n <= 0)
            {
                Console.WriteLine("нет");
            }
            else
            {
                while (n % 2 == 0)
                {
                    n /= 2;
                }
                if (n == 1)
                {
                    Console.WriteLine("да");
                }
                else
                {
                    Console.WriteLine("нет");
                }
            }
            Console.ReadKey();
        }
    }
}
