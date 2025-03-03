namespace Task4_03
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int a = Convert.ToInt32(Console.ReadLine());
            int b = Convert.ToInt32(Console.ReadLine());

            if (a <= 0 || b <= 0)
            {
                Console.WriteLine("Введенные значения не соответствуют требованиям");
            }
            else
            {
                int result = a;
                for (int i = 2; i <= b; i++)
                {
                    result *= a;
                }
                Console.WriteLine(result);
            }
            Console.ReadKey();
        }
    }
}
