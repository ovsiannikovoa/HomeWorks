namespace Task3_10
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int buildings = Convert.ToInt32(Console.ReadLine());
            switch (buildings % 10)
            {
                case 1:
                    Console.WriteLine("Мы построили {0} дом", buildings);
                    break;
                case 2:
                case 3:
                case 4:
                    Console.WriteLine("Мы построили {0} дома", buildings);
                    break;
                case 0:
                case 5:
                case 6:
                case 7:
                case 8:
                case 9:
                    Console.WriteLine("Мы построили {0} домов", buildings);
                    break;
            }
            Console.ReadKey();
        }
    }
}
