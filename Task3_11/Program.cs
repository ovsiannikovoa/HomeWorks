namespace Task3_11
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int a = Convert.ToInt32(Console.ReadLine());
            int b = Convert.ToInt32(Console.ReadLine());
            int p = Convert.ToInt32(Console.ReadLine());
            int q = Convert.ToInt32(Console.ReadLine());
            int r = Convert.ToInt32(Console.ReadLine());
            int s = Convert.ToInt32(Console.ReadLine());

            if ((p + r <= a && Math.Max(q, s) <= b) ||
                (p + r <= b && Math.Max(q, s) <= a) ||
                (q + s <= b && Math.Max(p, r) <= a) ||
                (q + s <= a && Math.Max(p, r) <= b))
            {
                Console.WriteLine("Можно разместить");
            }
            else
            {
                if ((p + s <= a && Math.Max(q, r) <= b) ||
                    (p + s <= b && Math.Max(q, r) <= a) ||
                    (q + r <= b && Math.Max(p, s) <= a) ||
                    (q + r <= a && Math.Max(p, s) <= b))
                {
                    Console.WriteLine("Можно разместить");
                }
                else
                {
                    if ((q + r <= a && Math.Max(p, s) <= b) ||
                        (q + r <= b && Math.Max(p, s) <= a) ||
                        (p + s <= b && Math.Max(q, r) <= a) ||
                        (p + s <= a && Math.Max(q, r) <= b))
                    {
                        Console.WriteLine("Можно разместить");
                    }
                    else
                    {
                        if ((q + s <= a && Math.Max(p, r) <= b) ||
                            (q + s <= b && Math.Max(p, r) <= a) ||
                            (p + r <= b && Math.Max(q, s) <= a) ||
                            (p + r <= a && Math.Max(q, s) <= b))
                        {
                            Console.WriteLine("Можно разместить");
                        }
                        else
                        {
                            Console.WriteLine("Нельзя разместить");
                        }
                    }
                }
            }
            Console.ReadKey();
        }
    }
}