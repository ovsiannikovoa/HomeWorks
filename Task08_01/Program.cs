namespace Task08_01
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Урок 8. Задание 1.
            // Смоделируйте работу простого калькулятора. Программа должна запрашивать 2 целых числа, а затем – код операции (например, 1 – сложение, 2 – вычитание, 3 – произведение, 4 – частное). После этого на консоль выводится ответ. Используйте обработку деления на ноль (DivideByZeroException), нечислового ввода (FormatException).

            try
            {
                Console.WriteLine("Введите первое число:");
                int num1 = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Введите второе число:");
                int num2 = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Введите код операции:");
                int switchOperation = Convert.ToInt32(Console.ReadLine());

                int result = 0;

                switch (switchOperation)
                {
                    case 1:
                        result = num1 + num2;
                        Console.WriteLine(result);
                        break;
                    case 2:
                        result = num1 - num2;
                        Console.WriteLine(result);
                        break;
                    case 3:
                        result = num1 * num2;
                        Console.WriteLine(result);
                        break;
                    case 4:
                        result = num1 / num2;
                        Console.WriteLine(result);
                        break;
                    default:
                        Console.WriteLine("Ошибка. Неверный код операции.");
                        break;
                }
            }
            catch (DivideByZeroException e)
            {
                Console.WriteLine($"Деление на 0 - {e.Message}");
            }
            catch (FormatException e)
            {
                Console.WriteLine($"Некорректный формат числа - {e.Message}");
            }

            Console.ReadKey();
        }
    }
}
