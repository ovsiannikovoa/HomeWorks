namespace Task08_02
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Урок 8. Задание 2.
            // Напишите метод ValidateAge, проверяющий корректность возраста. Если возраст:
            //  •   < 0 - выбросить ArgumentException("Возраст не может быть отрицательным"),
            //  •   > 150 - выбросить ArgumentOutOfRangeException("Слишком большой возраст").

            int age = Convert.ToInt32(Console.ReadLine());
            
            ValidateAge(age);

            Console.ReadKey();
        }

        static void ValidateAge (int age)
        {
            if (age < 0 || age > 150)
                throw new ArgumentException($"Возраст = {age} выходит за допустимый диапазон [0-150]");
        }
    }
}
