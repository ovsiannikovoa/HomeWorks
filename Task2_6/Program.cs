namespace Task2_6
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double len = Convert.ToDouble(Console.ReadLine());
            double roundedLen = Math.Round(len * 2) / 2;

            Console.WriteLine(roundedLen);
            Console.ReadKey();
        }
    }
}
