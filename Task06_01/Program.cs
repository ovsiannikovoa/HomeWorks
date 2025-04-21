namespace Task06_01
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введите предложение: ");
            string input = Console.ReadLine();

            string[] words = input.Split(new[] { ' ' });
            string longestWord = "";

            foreach (string word in words)
            {
                if(word.Length > longestWord.Length)
                {
                    longestWord = word;
                }
            }

            Console.WriteLine(longestWord);
            Console.ReadKey();
        }
    }
}
