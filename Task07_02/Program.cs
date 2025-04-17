namespace Task07_02
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int edgeLength = 5;
            int surfaceArea, volume;
            CalcCube(edgeLength, out surfaceArea, out volume);

            Console.WriteLine($"Объем куба: {volume}");
            Console.WriteLine($"Площадь поверхности куба: {surfaceArea}");

            Console.ReadKey();
        }

        static void CalcCube(int a, out int surfaceArea, out int volume)
        {
            surfaceArea = a*a;
            volume = a*a*a;
        }
    }
}
