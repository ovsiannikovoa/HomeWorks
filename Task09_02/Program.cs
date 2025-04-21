using System.Security.Cryptography;

namespace Task09_02
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Урок 9. Задание 2.
            // Создайте класс BankAccount, который моделирует банковский счет:

            //  Поля:
            //      _balance(текущий баланс, private)
            //  Статическое поле:
            //      TotalAccounts(общее количество созданных счетов)
            //  Свойства:
            //      AccountNumber(номер счета, readonly)
            //      Balance(public геттер, private сеттер)
            //  Конструктор:
            //      Увеличивает TotalAccounts и генерирует AccountNumber(например, случайный 4-значный номер).
            //  Методы:
            //      Deposit(decimal amount) – пополняет баланс.
            //      Withdraw(decimal amount) – снимает деньги(если хватает средств, иначе выбрасывает исключение).

            BankAccount acc = new BankAccount(1000);
            BankAccount acc1 = new BankAccount(9999);

            acc.Deposit(300);
            acc1.Withdraw(88);

            BankAccount.DisplayTotalAccounts();

            acc.GetInfo();
            acc1.GetInfo();

            Console.ReadKey();
        }
    }

    public class BankAccount
    {
        private int _balance;
        public static int TotalAccounts = 0;
        public readonly int AccountNumber;

        public int Balance { get; private set; }

        public BankAccount (int balance)
        {
            Balance = balance;
            AccountNumber = RandomNumberGenerator.GetInt32(1000,10000);
            TotalAccounts++;
        }   

        public int Deposit(int amount)
        {
            return Balance += amount;
        }

        public int Withdraw(int amount)
        {
            if ((Balance - amount) < 0)
            {
                throw new ArgumentException("Недостаточно средств!");
            }
            return Balance -= amount;
        }

        public void GetInfo()
        {
            Console.WriteLine($"{Balance}, {AccountNumber}");
        }

        public static void DisplayTotalAccounts()
        {
            Console.WriteLine($"Всего аккаунтов: {TotalAccounts}");
        }
    }
}
