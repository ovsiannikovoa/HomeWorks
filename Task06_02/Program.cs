namespace Task06_02
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введите предложение: ");
            string input = Console.ReadLine();

            string input2 = input.Replace(" ", "").ToLower();
            
            bool isPalindrome = true;
            int length = input2.Length;

            for (int i = 0; i < length / 2; i++)
            {
                if (input2[i] == input2[length - 1 - i])
                {
                    Console.WriteLine("Успешно");
                }
                else
                {
                    isPalindrome = false;
                    Console.WriteLine("Ошибка");
                    break;
                }
            }

            Console.WriteLine(isPalindrome ? "Палиндром" : "Не палиндром");
            Console.ReadKey();
        }
    }
}
