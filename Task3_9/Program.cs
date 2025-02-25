namespace Task3_9
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int num = Convert.ToInt32(Console.ReadLine());
            if (num <= -10 || num <= 10)
            {
                Console.WriteLine("да");
            }
            else
            {
                Console.WriteLine("нет");
            }
            Console.ReadKey();
        }
    }
}
