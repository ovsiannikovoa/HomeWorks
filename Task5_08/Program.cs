namespace Task5_08
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const int n = 5;
            int[] array = new int[n];
            Random rnd = new Random();

            for (int i = 0; i < n; i++)
            {
                array[i] = rnd.Next(0, 11);
                Console.Write("{0} ",array[i]);
            }
            Console.WriteLine();

            int max1 = 0;
            int max2 = 0;

            if (array[0] < array[1])
            {
                max1 = array[1];
                max2= array[0];
            }
            else
            {
                max1 = array[0];
                max2 = array[1];
            }

            for(int i = 2;i < n;i++)
            {
                if (max1< array[i])
                {
                    max2 = max1;
                    max1 = array[i];
                }
                else
                {
                    if(max2< array[i])
                    {
                        max2= array[i];
                    }
                }
            }

            Console.WriteLine("{0} {1}", max1, max2);
            Console.ReadKey();
        }
    }
}
