namespace Task5_04
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
                array[i] = rnd.Next(0, 11);
                Console.Write("{0} ", array[i]);
            }
            Console.WriteLine();

            int[] array2 = new int[n];
            for (int i = 0; i < n; i++)
            {
                array2[i] = array[i];
                Console.Write("{0} ", array2[i]);
            }
            Console.WriteLine();

            for (int i = 0; i < n; i++)
            {
                array[i] = array2[n - 1 - i];
                Console.Write("{0} ", array[i]);
            }
            Console.ReadKey();
        }
    }
}
