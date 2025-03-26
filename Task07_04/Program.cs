namespace Task07_04
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
                array[i] = rnd.Next(0, 100);
            }

            for (int i = 0;i < n; i++)
            {
                Console.Write(array[i] + " ");
            }
            Console.WriteLine();
            FindMax(array);

            Console.ReadKey();
        }

        static void FindMax(params int[] nums)
        {
            int maxNumber = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] > maxNumber)
                {
                    maxNumber = nums[i];
                }
            }
            Console.WriteLine($"Max number: {maxNumber}");
        }
    }
}
