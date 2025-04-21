namespace Task11_01
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Урок 11. Задание 1.

            // Создайте абстрактный класс Animal с:
            //  абстрактным свойством Name(string),
            //  абстрактным методом Say(), который выводит звук, который издает животное,
            //  неабстрактным методом ShowInfo(), который выводит на консоль последовательно название, а затем звук(вызывая метод Say()).

            // Реализуйте два класса - наследника:
            //  Dog(собака), который переопределяет Say()(выводит "Гав!") и задает название животного,
            //  Cat (кошка), который переопределяет Say() (выводит "Мяу!") и задает название животного.

            // В методе Main продемонстрируйте:
            //  создание массива, содержащего объекты обоих типов,
            //  использование полиморфизма(вызовите для каждого элемента в массиве метод ShowInfo()).

            Animal[] animals = new Animal[]
            {
                new Dog(),
                new Cat()
            };

            foreach (Animal animal in animals)
            {
                animal.ShowInfo();
                Console.WriteLine();
            }

            Console.ReadKey();
        }
    }

    public abstract class Animal
    {
        public abstract string Name { get; }
        public abstract void Say();
        public void ShowInfo()
        {
            Console.WriteLine(Name);
            Say();
        }
    }

    public class Dog : Animal
    {
        public override string Name => "Шарик";
        public override void Say()
        {
            Console.WriteLine("Гав!");
        }
    }

    public class Cat : Animal
    {
        public override string Name => "Барсик";
        public override void Say()
        {
            Console.WriteLine("Мяу!");
        }
    }

}
