using System.Reflection.Metadata;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Task14_03
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Урок 14. Задание 3.

            // Разработайте систему управления подписчиками, используя HashSet<string> для хранения email-адресов.Система должна обеспечивать уникальность подписчиков  и поддерживать основные операции с множествами.
            // Требования:
            //  Создайте HashSet для хранения email - подписчиков с регистронезависимым сравнением
            //  Реализуйте следующий функционал:
            //      Добавление новых подписчиков:
            //          alice @example.com
            //          bob@example.com
            //          charlie@example.com
            //      Попытку добавления дубликата с выводом результата операции
            //      Проверку наличия подписчиков в системе
            //  Создайте второе множество newSubscribers с подписчиками:
            //      bob @example.com(существующий)
            //      dave @example.com(новый)
            //      eve @example.com(новый)
            //  Выполните операции с множествами:
            //      Объединение множеств(добавление новых подписчиков)
            //      Поиск пересечения(общих подписчиков)
            //  Реализуйте:
            //      Удаление подписчика
            //      Проверку на подмножество
            //      Очистку всей коллекции
            // Пример вывода:
            //  Дубликат alice@example.com добавлен? False
            //  Есть ли bob@example.com в подписчиках? True
            //  Есть ли dave @example.com в подписчиках? False
            //  Подписчики после объединения:
            //  -alice@example.com
            //  - bob@example.com
            //  - charlie@example.com
            //  - dave@example.com
            //  - eve@example.com
            //  Общие подписчики:
            //  -bob@example.com
            //  - charlie@example.com
            //  Удалили charlie @example.com? True
            //  Всего подписчиков: 4
            //  testGroup является подмножеством? True
            //  Подписчиков после очистки: 0

            // Создаем HashSet для хранения email-адресов
            HashSet<string> userEmails = new HashSet<string>();

            // Добавление новых подписчиков
            userEmails.Add("alice@example.com");
            userEmails.Add("bob@example.com");
            userEmails.Add("charlie@example.com");

            // Попытка добавить дубликат
            bool addDublicate = userEmails.Add("alice@example.com");
            Console.WriteLine($"Дубликат alice@example.com добавлен? {addDublicate}");

            //Проверка наличия подписчиков в системе
            Console.WriteLine($"Есть ли bob@example.com в подписчиках? {userEmails.Contains("bob@example.com")}");
            Console.WriteLine($"Есть ли dave@example.com в подписчиках? {userEmails.Contains("dave@example.com")}");

            // Создание второго множества с подписчиками
            HashSet<string> newSubscribers = new HashSet<string>();
            newSubscribers.Add("bob@example.com");
            newSubscribers.Add("dave@example.com");
            newSubscribers.Add("eve@example.com");

            // Объединение множеств
            HashSet<string> allUsers = new HashSet<string>(userEmails);
            allUsers.UnionWith(newSubscribers);
            Console.WriteLine("Подписчики после объединения:");
            foreach (string user in allUsers)
            {
                Console.WriteLine($"- {user}");
            }

            // Пересечение множеств
            HashSet<string> intersectionUsers = new HashSet<string>(userEmails);
            intersectionUsers.UnionWith(newSubscribers);
            Console.WriteLine("Общие подписчики:");
            foreach (string user in intersectionUsers)
            {
                Console.WriteLine($"- {user}");
            }

            // Удаление подписчика
            Console.WriteLine($"Удалили charlie@example.com? {allUsers.Remove("charlie@example.com")}");
            Console.WriteLine($"Всего подписчиков: {allUsers.Count}");

            // Проверка на подмножество
            HashSet<string> testGroup = new HashSet<string> { "bob@example.com", "dave@example.com" };
            Console.WriteLine($"testGroup является подмножеством? {testGroup.IsSubsetOf(allUsers)}");

            //Очистка коллекции
            allUsers.Clear();
            Console.WriteLine($"Подписчиков после очистки: {allUsers.Count}");

            Console.ReadKey();
        }
    }
}
