using System.ComponentModel.DataAnnotations;
using System.Net.Mime;

namespace Task3_4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int num1 = Convert.ToInt32(Console.ReadLine());
            int num2 = Convert.ToInt32(Console.ReadLine());
            int num3 = Convert.ToInt32(Console.ReadLine());

            int max = Math.Max(Math.Max(num1, num2), num3);
            int min = Math.Min(Math.Min(num1, num2), num3);

            int median = num1 + num2 + num3 - max - min;
            Console.WriteLine(median);
            Console.ReadKey();
        }
    }
}
