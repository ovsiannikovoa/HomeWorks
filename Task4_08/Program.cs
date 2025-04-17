namespace Task4_08
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int num = Convert.ToInt32(Console.ReadLine());
            int count = 0;
            int numReverse = 0;
            if (num == 0)
            {
                Console.WriteLine(num);
            }
            else
            {
                num = (num < 0) ? -num : num;
                int numCount = num;
                while (numCount > 0)
                {
                    numCount /= 10;
                    count++;
                }
                int x = 1;
                while (count > 0)
                {
                    for (int i = 1; i < count; i++)
                    {
                        x *= 10;
                    }
                    numReverse += num % 10 * x;
                    num /= 10;
                    count--;
                    x = 1;
                }
                Console.WriteLine(numReverse);
            }
            Console.ReadKey();
        }
    }
}
