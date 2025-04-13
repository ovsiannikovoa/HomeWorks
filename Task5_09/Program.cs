namespace Task5_09
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const int m = 4;
            const int n = 5;
            int[,] array = new int[m, n];
            Random rnd = new Random();

            int top = 0;
            int bottom = m - 1;
            int left = 0;
            int right = n - 1;
            int num = 1;

            for (int i = left; i <= right; i++)
            {
                array[top, i] = num++;
            }

            for (int i = top + 1; i <= bottom; i++)
            {
                array[i,right] = num++;
            }

           

            Console.ReadKey();
        }
    }
}
