using System;

namespace Task3_12
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введите число в диапазоне 100-999: ");
            int num = Convert.ToInt32(Console.ReadLine());
            int firstDigit = num / 100;
            string firstDigitStr = " ";
            int secondDigit = num / 10 % 10;
            string secondDigitStr = " ";
            int thirdDigit = num % 10;
            string thirdDigitStr = " ";
            int lastTwoDigits = num% 100;
            string lastTwoDigitsStr = " ";

            if (num < 100 || num > 999)
            {
                Console.WriteLine("Число {0} не входит в указанный диапазон", num);
            }
            else
            {
                switch (firstDigit)
                {
                    case 1:
                        firstDigitStr = "Сто ";
                        break;
                    case 2:
                        firstDigitStr = "Двести ";
                        break;
                    case 3:
                        firstDigitStr = "Триста ";
                        break;
                    case 4:
                        firstDigitStr = "Четыреста ";
                        break;
                    case 5:
                        firstDigitStr = "Пятьсот ";
                        break;
                    case 6:
                        firstDigitStr = "Шестьсот ";
                        break;
                    case 7:
                        firstDigitStr = "Семьсот ";
                        break;
                    case 8:
                        firstDigitStr = "Восемьсот ";
                        break;
                    case 9:
                        firstDigitStr = "Девятьсот ";
                        break;
                }
                if (secondDigit > 1 && secondDigit <= 9)
                {
                    switch (secondDigit)
                    {
                        case 2:
                            secondDigitStr = "двадцать ";
                            break;
                        case 3:
                            secondDigitStr = "тридцать ";
                            break;
                        case 4:
                            secondDigitStr = "сорок ";
                            break;
                        case 5:
                            secondDigitStr = "пятьдесят ";
                            break;
                        case 6:
                            secondDigitStr = "шестьдесят ";
                            break;
                        case 7:
                            secondDigitStr = "семьдесят ";
                            break;
                        case 8:
                            secondDigitStr = "восемьдесят ";
                            break;
                        case 9:
                            secondDigitStr = "девяносто ";
                            break;
                    }
                }
                else
                {
                    switch (lastTwoDigits)
                    {
                        case 0:
                            lastTwoDigitsStr = "";
                            break;
                        case 1:
                            lastTwoDigitsStr = "один";
                            break;
                        case 2:
                            lastTwoDigitsStr = "два";
                            break;
                        case 3:
                            lastTwoDigitsStr = "три";
                            break;
                        case 4:
                            lastTwoDigitsStr = "четыре";
                            break;
                        case 5:
                            lastTwoDigitsStr = "пять";
                            break;
                        case 6:
                            lastTwoDigitsStr = "шесть";
                            break;
                        case 7:
                            lastTwoDigitsStr = "семь";
                            break;
                        case 8:
                            lastTwoDigitsStr = "восемь";
                            break;
                        case 9:
                            lastTwoDigitsStr = "девять";
                            break;
                        case 10:
                            lastTwoDigitsStr = "десять";
                            break;
                        case 11:
                            lastTwoDigitsStr = "одиннадцать";
                            break;
                        case 12:
                            lastTwoDigitsStr = "двенадцать";
                            break;
                        case 13:
                            lastTwoDigitsStr = "тринадцать";
                            break;
                        case 14:
                            lastTwoDigitsStr = "четырнадцать";
                            break;
                        case 15:
                            lastTwoDigitsStr = "пятнадцать";
                            break;
                        case 16:
                            lastTwoDigitsStr = "шестнадцать";
                            break;
                        case 17:
                            lastTwoDigitsStr = "семнадцать";
                            break;
                        case 18:
                            lastTwoDigitsStr = "восемнадцать";
                            break;
                        case 19:
                            lastTwoDigitsStr = "девятнадцать";
                            break;
                    }
                }
                switch (thirdDigit)
                {
                    case 0:
                        thirdDigitStr = "";
                        break;
                    case 1:
                        thirdDigitStr = "один";
                        break;
                    case 2:
                        thirdDigitStr = "два";
                        break;
                    case 3:
                        thirdDigitStr = "три";
                        break;
                    case 4:
                        thirdDigitStr = "четыре";
                        break;
                    case 5:
                        thirdDigitStr = "пять";
                        break;
                    case 6:
                        thirdDigitStr = "шесть";
                        break;
                    case 7:
                        thirdDigitStr = "семь";
                        break;
                    case 8:
                        thirdDigitStr = "восемь";
                        break;
                    case 9:
                        thirdDigitStr = "девять";
                        break;
                }
            }
            if (secondDigit > 1 && secondDigit <= 9)
            {
                Console.WriteLine(firstDigitStr + secondDigitStr + thirdDigitStr);
            }
            else
            {
                Console.WriteLine(firstDigitStr + lastTwoDigitsStr);
            }
            Console.ReadKey();
        }
    }
}