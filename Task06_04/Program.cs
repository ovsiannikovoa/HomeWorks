using System.Text;

namespace Task06_04
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введите имя: ");
            string name = Console.ReadLine();

            Console.Write("Введите возраст: ");
            string age = Console.ReadLine();

            Console.Write("Введите город: ");
            string city = Console.ReadLine();

            StringBuilder sb = new StringBuilder();
            sb.Append("Имя: ");
            sb.Append(name);
            sb.Append(". Возраст: ");
            sb.Append(age);
            sb.Append(". Город: ");
            sb.Append(city);
            Console.Write(sb.ToString());

            Console.ReadKey();
        }
    }
}
