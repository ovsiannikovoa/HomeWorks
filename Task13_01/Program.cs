namespace Task13_01
{
    internal class Program
    {
        public delegate int Transformer(int number);

        public static int[] Transform(int[] numbers, Transformer transformer)
        {
            int[] result = new int[numbers.Length];
            for (int i = 0; i < numbers.Length; i++)
            {
                result[i] = transformer(numbers[i]);
            }
            return result;
        }

        static void Main(string[] args)
        {
            // Урок 13. Задание 1.

            // Реализуйте метод Transform, который принимает массив чисел и делегат для преобразования элементов.Метод должен возвращать новый массив с преобразованными значениями.
            // Требования:
            //  Создайте делегат Transformer, принимающий число и возвращающий число.
            //  Реализуйте метод Transform, который:
            //      Принимает массив int[] и делегат Transformer
            //      Возвращает новый массив, где каждый элемент преобразован через делегат
            //  Продемонстрируйте работу:
            //      Удвоение всех чисел
            //      Возведение в квадрат
            //      Замена чисел на их модули

            int[] numbers = [-1, 2, 7, -6, 3];

            Transformer doubler = x => x * 2;
            int[] doubled = Transform(numbers, doubler);
            Console.WriteLine($"Удвоение: {string.Join(", ", doubled)}");

            Transformer squarer = x => x * x;
            int[] squared = Transform(numbers, squarer);
            Console.WriteLine($"Возведение в квадрат: {string.Join(", ", squared)}");

            Transformer absolute =x=> Math.Abs(x);
            int[] absoluted = Transform(numbers, absolute);
            Console.WriteLine($"Замена на модули: {string.Join(", ", absoluted)}");

            Console.ReadKey();
        }
    }
}
