namespace Task2_1;

class Program
{
    static void Main(string[] args)
    {
        int a = Convert.ToInt32(Console.ReadLine());

        int b = Convert.ToInt32(Console.ReadLine());

        int c = Convert.ToInt32(Console.ReadLine());

        int t = c;
        c = b;
        b = a;
        a = t;

        Console.WriteLine("a={0}, b={1}, c={2}", a, b, c);
        Console.ReadKey();
    }
}
