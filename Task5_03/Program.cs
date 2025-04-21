namespace Task5_03
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
                array[i] = rnd.Next(0, 51);
            }

            int max = array[0];
            int min = array[0];
            int maxIndex = 0;
            int minIndex = 0;

            for (int i = 0; i < n; i++)
            {
                if (array[i] > max)
                {
                    max = array[i];
                    maxIndex = i;
                }

                if (array[i] < min)
                {
                    min = array[i];
                    minIndex = i;
                }
            }
            Console.WriteLine("Максимальны элемент: {0}, его индекс: {1}", max, maxIndex);
            Console.WriteLine("Минимальный элемент: {0}, его индекс: {1}", min, minIndex);

            Console.ReadKey();
        }
    }
}
