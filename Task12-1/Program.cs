using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography.X509Certificates;

namespace Task12_01
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Урок 12. Задание 1.

            // Создайте обобщенный класс Book<T, U>, который представляет книгу со следующими свойствами:
            //  Code - уникальный код книги(тип T)
            //  Title - название книги(тип string)
            //  PublicationYear - год публикации(тип U)
            //  Author - автор книги(тип string)

            // Реализуйте в классе:
            //  Конструктор, принимающий все параметры
            //  Переопределенный метод ToString(), возвращающий информацию в формате:
            //  Код: { Code} ({ тип T}), Название: { Title}, Автор: { Author}, Год: { PublicationYear} ({ тип U})

            // Создайте обобщенный метод FindBook, который:
            //  Принимает массив книг Book<T, U>[] и код книги code типа T
            //  Возвращает книгу с указанным кодом или null, если книга не найдена

            // В методе Main продемонстрируйте работу:
            //  Создайте два массива книг:
            //      Первый массив: Code - string(шифр книги), PublicationYear - int
            //      Второй массив: Code - int(инвентарный номер), PublicationYear - string(исторические периоды)
            //  Найдите и выведите информацию о книгах:
            //      Книгу с кодом "F-1234" из первого массива
            //      Книгу с кодом 42 из второго массива

            Book<string, int>[] books1 = new Book<string, int>[]
            {
                new Book<string, int>("F-1234", "Война и мир", 1900, "Толстой"),
                new Book<string, int>("F-1235", "Евгений Онегин", 1850, "Пушкин"),
            };

            Book<int, int>[] books2 = new Book<int, int>[]
            {
                new Book<int, int>(42, "Мир и война", 2020, "Худой"),
                new Book<int, int>(43, "Онегин Евгений", 2025, "Дюма"),
            };

            var book1 = FindBook(books1, "F-1234");
            Console.WriteLine(book1?.ToString() ?? "Не найден");

            var book2 = FindBook(books2, 42);
            Console.WriteLine(book2?.ToString() ?? "Не найден");


            Console.ReadKey();
        }

        public static Book<T, U> FindBook<T, U>(Book<T, U>[] books, T code)
        {
            foreach (Book<T, U> book in books)
            {
                if (book.Code.Equals(code))
                    return book;
            }
            return null;
        }

        public class Book<T, U>
        {
            public T Code { get; set; }
            public string Title { get; set; }
            public U PublicationYear { get; set; }
            public string Author { get; set; }
            public Book(T code, string title, U publicationYear, string author)
            {
                Code = code;
                Title = title;
                PublicationYear = publicationYear;
                Author = author;
            }
            public override string ToString()
            {
                return $"Код: {Code} ({typeof(T).Name}), Название: {Title}, Автор: {Author}, Год: {PublicationYear} ({typeof(U).Name})";
            }
        }
    }
}
