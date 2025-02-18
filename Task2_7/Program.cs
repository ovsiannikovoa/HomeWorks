namespace Task2_7
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите первое число:");
            int firstNum = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Введите второе число:");
            int secondNum = Convert.ToInt32(Console.ReadLine());

            firstNum = firstNum + secondNum;
            secondNum = firstNum - secondNum;
            firstNum = firstNum - secondNum;    

            Console.WriteLine("{0},{1}", firstNum, secondNum);
            Console.ReadKey();
        }
    }
}
