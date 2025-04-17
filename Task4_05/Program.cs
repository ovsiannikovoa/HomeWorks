namespace Task4_05
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введите число в диапазоне [20; 60]:");
            int num = Convert.ToInt32(Console.ReadLine());
            while (!(num >= 20 && num <= 60))
            {
                Console.Write("Число {0} не соответствует требованиям. Введите другое число:", num);
                int num2 = Convert.ToInt32(Console.ReadLine());
                num = num2;
            }
            Console.WriteLine("Число {0} соответствует требованиям",num);
            Console.ReadKey();
        }
    }
}
