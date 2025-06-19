using System.Runtime.InteropServices;

namespace Task15_01
{
    internal class Program
    {
        class Computer
        {
            public int Code { get; set; }
            public string BrandName { get; set; }
            public string ProcessorType { get; set; }
            public double ProcessorFrequency { get; set; }
            public int RAM { get; set; }
            public int HDD { get; set; }
            public int GPUVRAM { get; set; }
            public decimal Price { get; set; }
            public int Quantity { get; set; }
            public override string ToString()
            {
                return $"Код: {Code}, Марка: {BrandName}, Процессор: {ProcessorType} ({ProcessorFrequency} ГГц), " +
                       $"ОЗУ: {RAM} ГБ, HDD: {HDD} ГБ, VRAM: {GPUVRAM} ГБ, Цена: {Price}, Количество: {Quantity}";
            }
        }

        static void Main(string[] args)
        {
            // Урок 15. Задание 1

            // Модель  компьютера  характеризуется  кодом  и  названием  марки компьютера,  типом  процессора,  частотой  работы  процессора,  объемом оперативной памяти, объемом жесткого диска, объемом памяти видеокарты, стоимостью компьютера в условных единицах и количеством экземпляров, имеющихся в наличии. Создать список, содержащий 6-10 записей с различным набором значений характеристик.

            // Определить:
            //  -все компьютеры с указанным процессором. Название процессора запросить у пользователя;
            //  -все компьютеры с объемом ОЗУ не ниже, чем указано.Объем ОЗУ запросить у пользователя;
            //  -вывести весь список, отсортированный по увеличению стоимости;
            //  -вывести весь список, сгруппированный по типу процессора;
            //  -найти самый дорогой и самый бюджетный компьютер;
            //  -есть ли хотя бы один компьютер в количестве не менее 30 штук?

            List<Computer> computers = new List<Computer>
        {
            new Computer { Code = 1, BrandName = "Dell", ProcessorType = "Intel i5", ProcessorFrequency = 3.2, RAM = 8, HDD = 1000, GPUVRAM = 2, Price = 500, Quantity = 15 },
            new Computer { Code = 2, BrandName = "HP", ProcessorType = "AMD Ryzen 5", ProcessorFrequency = 3.6, RAM = 16, HDD = 512, GPUVRAM = 4, Price = 650, Quantity = 8 },
            new Computer { Code = 3, BrandName = "Lenovo", ProcessorType = "Intel i7", ProcessorFrequency = 4.0, RAM = 32, HDD = 2000, GPUVRAM = 6, Price = 1200, Quantity = 5 },
            new Computer { Code = 4, BrandName = "Asus", ProcessorType = "AMD Ryzen 7", ProcessorFrequency = 4.2, RAM = 64, HDD = 1000, GPUVRAM = 8, Price = 1500, Quantity = 35 },
            new Computer { Code = 5, BrandName = "Acer", ProcessorType = "Intel i5", ProcessorFrequency = 3.0, RAM = 8, HDD = 500, GPUVRAM = 2, Price = 450, Quantity = 20 },
            new Computer { Code = 6, BrandName = "Apple", ProcessorType = "M1 Pro", ProcessorFrequency = 3.2, RAM = 16, HDD = 512, GPUVRAM = 4, Price = 2000, Quantity = 12 },
            new Computer { Code = 7, BrandName = "MSI", ProcessorType = "Intel i9", ProcessorFrequency = 5.0, RAM = 64, HDD = 2000, GPUVRAM = 12, Price = 2500, Quantity = 3 },
            new Computer { Code = 8, BrandName = "Samsung", ProcessorType = "AMD Ryzen 5", ProcessorFrequency = 3.4, RAM = 8, HDD = 1000, GPUVRAM = 3, Price = 550, Quantity = 25 }
        };

            Console.WriteLine("Введите название процессора: ");
            string processor = Console.ReadLine();
            var byProcessor = computers
                .Where(proc => proc.ProcessorType == processor)
                .ToList();
            Console.WriteLine($"Компьютеры с процессором {processor}:");
            foreach (Computer computer in byProcessor)
            {
                Console.WriteLine(computer.ToString());
            }

            Console.WriteLine("Введите объём ОЗУ: ");
            int ram = Convert.ToInt32(Console.ReadLine());
            var byMinRam = computers
                .Where(r => r.RAM >= ram)
                .ToList();
            Console.WriteLine($"Компьютеры с объёмом ОЗУ не меньше {ram}:");
            foreach (Computer computer in byMinRam)
            {
                Console.WriteLine(computer.ToString());
            }

            var byPrice = computers
                .OrderBy(r => r.Price);
            Console.WriteLine($"Компьютеры, отсортированные по возрастанию стоимости:");
            foreach (Computer computer in byPrice)
            {
                Console.WriteLine(computer.ToString());
            }

            var groupedByProcessor = computers
                .GroupBy(r => r.ProcessorType);
            Console.WriteLine("Компьютеры, сгруппированные по типу процессора: ");
            foreach (var group in groupedByProcessor)
            {
                Console.WriteLine($"Тип процессора: {group.Key}");
                foreach (var computer in group)
                {
                    Console.WriteLine(computer.ToString());
                }
            }

            var mostExpensive = computers
                .OrderByDescending(mE => mE.Price)
                .First();
            var cheapest = computers
                .OrderBy(mE => mE.Price)
                .First();
            Console.WriteLine($"Самый дорогой: {mostExpensive.BrandName} ({mostExpensive.Price})");
            Console.WriteLine($"Самый бюджетный: {cheapest.BrandName} ({cheapest.Price})");

            bool moreThan30 = computers
                .Any(c => c.Quantity >= 0);
            Console.WriteLine($"Наличие компьютеров (>=30 шт.): {(moreThan30 ? "Да" : "Нет")}");


            Console.ReadKey();
        }
    }
}
