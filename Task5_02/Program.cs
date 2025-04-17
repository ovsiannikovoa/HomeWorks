namespace Task5_02
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const int n = 10;
            int[] array = new int[n];
            Random rnd = new Random();

            int positive = 0;
            int negative = 0;
            int zero = 0;
            for (int i = 0; i < n; i++)
            {
                array[i] = rnd.Next(-20, 21);
                if (array[i] == 0)
                {
                    zero++;
                }
                else
                {
                    if (array[i] > 0)
                    {
                        positive++;
                    }
                    else
                    {
                        negative++;
                    }
                }
            }

            Console.WriteLine("Равны нулю - {0}; Положительных - {1}; Отрицательных - {2}", zero, positive, negative);
            Console.ReadKey();
        }
    }
}
