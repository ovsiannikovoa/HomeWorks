namespace Task2_3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int inches = Convert.ToInt32(Console.ReadLine());
            double allMillimeters = inches * 2.54 * 10;
            int meters = (int)allMillimeters / 1000;
            int centimeters = (int)allMillimeters / 10 - meters * 100;
            double millimeters = allMillimeters - meters * 1000 - centimeters * 10;
            Console.WriteLine("{0} inches = {1} m {2} cm {3} mm", inches, meters, centimeters, millimeters);
            Console.ReadKey();
        }
    }
}
