namespace Task07_03
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = { 1, 2, 3, 4, 5 };

            PrintNumbers(numbers);
            Console.WriteLine();

            PrintNumbers(numbers, true);
            Console.WriteLine();


            Console.ReadKey();
        }

        static void PrintNumbers(int[] numbers, bool reverse = false)
        {
            if (!reverse)
            {
                foreach (int i in numbers)
                {
                    Console.Write(i + " ");
                }
                Console.WriteLine();
            }
            else
            {
                int[] numbersReverse = new int[numbers.Length];
                for (int i = 0; i < numbers.Length; i++)
                {
                    numbersReverse[i] = numbers[i];
                }

                for (int i = 0; i < numbers.Length; i++)
                {
                    numbers[i] = numbersReverse[numbers.Length - 1 - i];
                    Console.Write("{0} ", numbers[i]);
                }
            }
        }
    }
}
