﻿using System.ComponentModel.DataAnnotations;

namespace Task3_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int num1 = Convert.ToInt32(Console.ReadLine());
            int num2 = Convert.ToInt32(Console.ReadLine());
            int num3 = Convert.ToInt32(Console.ReadLine());

            int max = (num1 >= num2) ? num1 : num2;
            max = (num3 >= max) ? num3 : max;

            if (num1 == num2 && num1 == num3)
            {
                Console.WriteLine("Все введенные числа равны");
            }
            else
            {
                if (num1 == max && num2 == max || num2 == max && num3 == max || num1 == max && num3 == max)
                {
                    Console.WriteLine("Два числа имеют максимальное значение: {0}", max);
                }
                else
                {
                    Console.WriteLine("Наибольшее число: {0}", max);
                }
            }
            Console.ReadKey();
        }
    }
}
