namespace Task5_01
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const int n = 100;
            int[] array = new int[n];
            Random rnd = new Random();

            int even = 0;
            int odd = 0;
            for (int i = 0; i < n; i++)
            {
                array[i] = rnd.Next(0, n + 1);
                if (array[i] % 2 == 0)
                {
                    even++;
                }
                else
                {
                    odd++;
                }
            }

            if (even == odd)
            {
                Console.WriteLine("Четных и нечетных одинаковое количество");
            }
            else
            {
                if (even > odd)
                {
                    Console.WriteLine("Четных больше");
                }
                else
                {
                    Console.WriteLine("Нечетных больше");
                }
            }
            Console.ReadKey();
        }
    }
}
