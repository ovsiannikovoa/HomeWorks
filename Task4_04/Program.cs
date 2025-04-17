namespace Task4_04
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int a = Convert.ToInt32(Console.ReadLine());
            int b = Convert.ToInt32(Console.ReadLine());

            if (a <= 0 || b >= 0)
            {
                Console.WriteLine("Введенные значения не соответствуют требованиям");
            }
            else
            {
                double result = a;
                int bAbs = b * (-1);
                for (int i = 2; i <= bAbs; i++)
                {
                    result *= a;
                }
                result = 1 / result;
                Console.WriteLine(result);
            }
            Console.ReadKey();
        }
    }
}
