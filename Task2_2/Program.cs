namespace Task2_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int deg = Convert.ToInt32(Console.ReadLine());
            int min = Convert.ToInt32(Console.ReadLine());
            int sec = Convert.ToInt32(Console.ReadLine());

            int degInSec = deg * 60 * 60 + min * 60 + sec;
            double degInRad = (degInSec * Math.PI / 180 / 60 / 60);

            Console.WriteLine(degInRad);
            Console.ReadKey();
        }
    }
}
