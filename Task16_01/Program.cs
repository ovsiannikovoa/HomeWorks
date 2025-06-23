namespace Task16_01
{
    internal class Program
    {
        static int[] GenerateArrayTask(int size)
        {
            Console.WriteLine("GenerateArrayTask начал работу");
            var random = new Random();
            int[] array = new int[size];
            Thread.Sleep(2000);

            for (int i = 0; i < size; i++)
            {
                array[i] = random.Next(1, 10);
                Console.Write($"{array[i]} ");
            }
            Console.WriteLine("GenerateArrayTask завершил работу");
            return array;
        }

        static double CalculateAverage(int[] array)
        {
            Console.WriteLine("CalculateAverage начал работу");
            Thread.Sleep(1500);

            double sum = 0;
            foreach (int item in array)
            {
                sum += item;
            }
            double average = sum / array.Length;
            Console.WriteLine("CalculateAverage завершил работу");
            return average;
        }
        static async Task<int[]> GenerateArrayTaskAsync(int size)
        {
            Console.WriteLine("GenerateArrayTaskAsync начал работу");
            int[] result = await Task.Run(() => GenerateArrayTask(size));
            Console.WriteLine("GenerateArrayTaskAsync завершил работу");
            return result;
        }

        static async Task<double> CalculateAverageAsync(int[] array)
        {
            Console.WriteLine("CalculateAverageAsync начал работу");
            double result = await Task.Run(() => CalculateAverage(array));
            Console.WriteLine("CalculateAverageAsync завершил работу");
            return result;
        }

        static void Main(string[] args)
        {
            // Урок 16. Задание 1.

            //Разработать метод для формирования массива и метод для расчета среднего арифметического всех чисел в массиве(в методах сделать искусственную задержку - имитация длительных вычислений).В методе Main выполнить проверку работы методов 2мя способами -сначала используя задачи продолжения, затем - с помощью async/ await

            Console.WriteLine("Main_начал работу\n");

            Console.WriteLine("Способ 1: Задачи продолжения.");
            Task<int[]> task1 = Task.Run(() => GenerateArrayTask(10));
            Task<double> task2 = task1.ContinueWith(t =>
            {
                int[] array = t.Result;
                return CalculateAverage(array);
            });
            Console.WriteLine($"Результат (продолжение): {task2.Result:F2}\n");

            Console.WriteLine("Способ 2: Async/Await.");
            ExecuteAsyncMethods().Wait();

            Console.WriteLine("\nMain_завершил работу");
            Console.ReadKey();
        }

        static async Task ExecuteAsyncMethods()
        {
            int[] array = await GenerateArrayTaskAsync(10);
            double average = await CalculateAverageAsync(array);
            Console.WriteLine($"Результат (async/await): {average:F2}");
        }


    }
}
