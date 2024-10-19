using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MODULS.MODUL01.DOM
{
    public class Book
    {
        public string Title { get; }
        public string Author { get; }
        public string ISBN { get; }
        private int availableCopies;

        public Book(string title, string author, string isbn, int copies)
        {
            Title = title;
            Author = author;
            ISBN = isbn;
            availableCopies = copies;
        }

        // Метод для проверки доступности книги
        public bool IsAvailable()
        {
            return availableCopies > 0;
        }

        // Метод для выдачи книги
        public bool LendBook()
        {
            if (IsAvailable())
            {
                availableCopies--;
                return true;
            }
            return false;
        }

        // Метод для возврата книги
        public void ReturnBook()
        {
            availableCopies++;
        }

        public void DisplayInfo()
        {
            Console.WriteLine($"{Title}, {Author}, ISBN: {ISBN}, Доступные экземпляры: {availableCopies}");
        }
    }

    public class Reader
    {
        public string Name { get; }
        public int ReaderID { get; }

        public Reader(string name, int id)
        {
            Name = name;
            ReaderID = id;
        }

        public void DisplayInfo()
        {
            Console.WriteLine($"Читатель: {Name}, ID: {ReaderID}");
        }
    }

    public class Library
    {
        private List<Book> books = new List<Book>();
        private List<Reader> readers = new List<Reader>();

        // Добавление книги в библиотеку
        public void AddBook(Book book)
        {
            books.Add(book);
            Console.WriteLine($"Добавлена книга: {book.Title}");
        }

        // Удаление книги
        public void RemoveBook(Book book)
        {
            books.Remove(book);
            Console.WriteLine($"Удалена книга: {book.Title}");
        }

        // Регистрация читателя
        public void RegisterReader(Reader reader)
        {
            readers.Add(reader);
            Console.WriteLine($"Зарегистрирован читатель: {reader.Name}");
        }

        // Удаление читателя
        public void RemoveReader(Reader reader)
        {
            readers.Remove(reader);
            Console.WriteLine($"Удален читатель: {reader.Name}");
        }

        // Выдача книги читателю
        public bool LendBookToReader(Book book, Reader reader)
        {
            if (book.LendBook())
            {
                Console.WriteLine($"Книга \"{book.Title}\" выдана читателю {reader.Name}");
                return true;
            }
            else
            {
                Console.WriteLine($"Нет доступных экземпляров книги \"{book.Title}\"");
                return false;
            }
        }

        // Возврат книги
        public void ReturnBookFromReader(Book book, Reader reader)
        {
            book.ReturnBook();
            Console.WriteLine($"Читатель {reader.Name} вернул книгу \"{book.Title}\"");
        }

        // Вывод информации о книгах
        public void DisplayBooks()
        {
            Console.WriteLine("\nДоступные книги:");
            foreach (var book in books)
            {
                book.DisplayInfo();
            }
        }
    }
    internal class Program
    {
        /* public static void Main()
        {
            Library library = new Library();

            Book book1 = new Book("Великий Гэтсби", "Ф. Скотт Фицджеральд", "9780743273565", 3);
            Book book2 = new Book("1984", "Джордж Оруэлл", "9780451524935", 2);

            Reader reader1 = new Reader("Ернар", 1);
            Reader reader2 = new Reader("Максат", 2);

            library.RegisterReader(reader1);
            library.RegisterReader(reader2);
            library.AddBook(book1);
            library.AddBook(book2);

            library.LendBookToReader(book1, reader1);
            library.LendBookToReader(book2, reader2);

            library.DisplayBooks();

            library.ReturnBookFromReader(book1, reader1);
            library.DisplayBooks();

            // Удаление книги
            library.RemoveBook(book1);
            library.DisplayBooks();
        }*/
    }
}
