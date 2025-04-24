namespace Task10_01
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Урок 10. Задание 1.
            // Создайте базовый класс Building(описывает здание) со следующими характеристиками:
            //  Поля:
            //      _address(строка) - адрес здания
            //      _area(double) - площадь в квадратных метрах
            //      _yearBuilt(int) - год постройки
            //  Конструктор, инициализирующий эти поля
            //  Виртуальные методы:
            //      CalculateTax() - рассчитывает налог(базовая формула: площадь × 1000)
            //      DisplayInfo() - выводит информацию о здании
            //  Свойство:
            //      BuildingAge(только чтение) - возраст здания в годах

            // Создайте производный класс MultiBuilding(многоэтажное здание), который:
            //  Добавляет новые поля:
            //      _floors(int) - количество этажей
            //      _hasElevator(bool) - наличие лифта
            //  Модифицирует поведение:
            //      Переопределяет CalculateTax() с учетом:
            //          Повышающего коэффициента за этажи(1 + (_floors - 1) * 0.05)
            //          Доплаты 5000 за наличие лифта
            //      Переопределяет DisplayInfo() для вывода дополнительной информации
            //  Добавляет новые возможности:
            //      Свойство AreaPerFloor(только чтение) -средняя площадь на этаж
            //  Запрещает наследование

            //  В методе Main продемонстрируйте:
            //      Создание объектов обоих типов
            //      Upcasting(приведение производного класса к базовому)
            //      Downcasting(обратное приведение с проверкой типа)
            //      Вызов переопределенных методов
            //      Использование уникальных методов производного класса

            Building building = new Building("Улица Пушкина, дом Колотушкина", 999.99, 2025);
            building.DisplayInfo();
            
            Console.WriteLine();

            MultiBuilding multiBuilding = new MultiBuilding("Улица Пушкина, дом Колотушкина", 999.99, 2025, 11, true);
            multiBuilding.DisplayInfo();

            Console.WriteLine();

            Building buildingUpcast = multiBuilding;
            Console.WriteLine("\nПосле upcasting:");
            buildingUpcast.DisplayInfo();

            Console.WriteLine();

            if (buildingUpcast is MultiBuilding)
            {
                MultiBuilding buildingDowncast = (MultiBuilding)buildingUpcast;
                Console.WriteLine("\nПосле downcasting:");
                buildingDowncast.DisplayInfo();
            }

            Console.WriteLine();

            Console.WriteLine($"Налог для многоэтажки: {multiBuilding.CalculateTax()}");

            Console.WriteLine($"Площадь на этаж: {multiBuilding.AreaPerFloor}");

            Console.ReadKey();
        }
    }

    public class Building
    {
        protected string _address;
        protected double _area;
        protected int _yearBuilt;

        public Building(string address, double area, int yearBuilt)
        {
            _address = address;
            _area = area;
            _yearBuilt = yearBuilt;
        }

        public virtual double CalculateTax()
        {
            return _area * 1000;
        }

        public virtual void DisplayInfo()
        {
            Console.WriteLine($"Адрес здания - {_address}.\nПлощадь здания - {_area}.\nГод постройки - {_yearBuilt}.");
        }

        public int BuildingAge
        {
            get
            {
                return DateTime.Now.Year - _yearBuilt;
            }
        }
    }

    sealed class MultiBuilding : Building
    {
        protected int _floors;
        protected bool _hasElevator;

        public MultiBuilding(string address, double area, int yearBuilt, int floors, bool hasElevator)
            : base(address, area, yearBuilt)
        {
            _floors = floors;
            _hasElevator = hasElevator;
        }

        public override double CalculateTax()
        {
            double baseTax = _area * 1000;
            double coef = 1 + (_floors - 1) * 0.05;
            double totalTax = baseTax * coef;
            if (_hasElevator)
            {
                totalTax += 5000;
            }
            return totalTax;
        }

        public override void DisplayInfo()
        {
            Console.WriteLine($"Адрес здания - {_address}.\nПлощадь здания - {_area}.\nГод постройки - {_yearBuilt}.\nКоличество этажей - {_floors}.\nНаличие лифта - {_hasElevator}.");
        }

        public double AreaPerFloor
        {
            get
            {
                return _area / _floors;
            }
        }
    }
}
