namespace Task4_07
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int num = Convert.ToInt32(Console.ReadLine());
            int count = 0;

            if (num == 0)
            {
                count = 1;
            }
            else
            {
                num = (num < 0) ? -num : num;

                while (num > 0)
                {
                    num /= 10;
                    count++;
                }
            }
            Console.WriteLine(count);
            Console.ReadKey();
        }
    }
}
