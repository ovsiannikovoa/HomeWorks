namespace Task06_03
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Месяц: ");
            string month = Console.ReadLine();

            Console.Write("Год: ");
            string year = Console.ReadLine();

            Console.Write("Общая сумма продаж: ");
            string amountOfSales = Console.ReadLine();

            Console.Write("Количество проданных товаров: ");
            string amountOfThings = Console.ReadLine();

            string result = string.Empty;
            result = String.Format("{0:F2}",5000);
            Console.WriteLine(result);

            string divider = "----------";

            Console.WriteLine("{0}", divider);
            Console.WriteLine("Отчет о продажах за {0} {1}", month, year);
            Console.WriteLine("{0}", divider);
            Console.WriteLine("Общая сумма продаж {0}", result);


            Console.WriteLine("{0}", divider);
            Console.ReadKey();
        }
    }
}
