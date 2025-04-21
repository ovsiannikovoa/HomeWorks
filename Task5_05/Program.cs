namespace Task5_05
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const int n = 10;
            int[] array = new int[n];
            Random rnd = new Random();

            for (int i = 0; i < n; i++)
            {
                array[i] = rnd.Next(-50, 51);
                Console.Write("{0} ", array[i]);
            }
            Console.WriteLine();

            for (int i = 0; i < n / 2 - 1; i++)
            {
                for (int j = i; j < n / 2 - i; j++)
                {
                    if (array[j] > array[j + 1])
                    {
                        int num = array[j];
                        array[j] = array[j + 1];
                        array[j + 1] = num;

                    }
                }
            }
            Console.WriteLine();

            for (int i = 0; i < n - 1; i++)
            {
                for (int j = n / 2; j < n - 1 - i; j++)
                {
                    if (array[j] < array[j + 1])
                    {
                        int num = array[j];
                        array[j] = array[j + 1];
                        array[j + 1] = num;

                    }
                }
            }

            Console.WriteLine("Новый массив:");
            foreach (int num in array)
            {
                Console.Write("{0} ", num);
            }
            Console.ReadKey();
        }
    }
}
