using System.Globalization;
using System.Xml.Linq;

namespace Task09_01
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Урок 9.Задание 1.
            //    Создайте класс Book, который содержит:
            //  Поля:
            //      _title(название книги, private)
            //      _author(автор, private)
            //  Автосвойства:
            //      Year(год издания, public геттер, public сеттер)
            //      Pages(количество страниц, public геттер, public сеттер)
            //  Конструктор:
            //      Инициализирует все поля и свойства
            //  Метод:
            //      GetInfo() – возвращает строку с информацией о книге(например: "Война и мир, Л. Толстой, 1869, 1225 стр.")

            Book book = new Book("Война и мир", "Л. Толстой", 1869, 1225);
            Book book1 = new Book("Евгений Онегин", "А. Пушкин", 1111, 2222);

            Book.DisplayTotalBooks();

            book.GetInfo();
            book1.GetInfo();

            book.Year = 333;
            book1.Author = "О.Овсянников";

            book.GetInfo();
            book1.GetInfo();



            Console.ReadKey();
        }
    }

    public class Book
    {
        private string _title;
        private string _author;
        public static int TotalBooks = 0;

        public int Year { get; set; }
        public int Pages { get; set; }

        public string Title
        {
            get
            {
                return _title;
            }
            set
            {
                try
                {
                    _title = value;
                }
                catch (FormatException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
        public string Author
        {
            get
            {
                return _author;
            }
            set
            {
                try
                {
                    _author = value;
                }
                catch (FormatException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }


        public Book(string title, string author, int year, int pages)
        {
            Title = title;
            Author = author;
            Year = year;
            Pages = pages;
            TotalBooks++;
        }

        public void GetInfo()
        {
            Console.WriteLine($"{Title}, {Author}, {Year}, {Pages} стр.");
        }

        public static void DisplayTotalBooks()
        {
            Console.WriteLine($"Всего книг: {TotalBooks}");
        }
    }
}
