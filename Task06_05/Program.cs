using System.Text.RegularExpressions;

namespace Task06_05
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введите телефонный номер: ");
            string number = Console.ReadLine();

            Regex regex = new Regex(@"^\+7\([0-9]{3,3}\)[0-9]{3,3}-[0-9]{2,2}-[0-9]{2,2}$");


            if (regex.IsMatch(number))
                Console.WriteLine("\"{0}\" - ok", number);
            else
                Console.WriteLine("\"{0}\" -  не ok", number);

            Console.ReadKey();
        }
    }
}
