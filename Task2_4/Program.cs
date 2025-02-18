namespace Task2_4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int num = Convert.ToInt32(Console.ReadLine());
            int n4 = num % 10;
            int n3 = num % 100 / 10;
            int n2 = num % 1000 / 100;
            int n1 = num / 1000;
            int numReverse = n4 * 1000 + n3 * 100 + n2 * 10 + n1;

            Console.WriteLine(numReverse);
            Console.ReadKey();
        }
    }
}
