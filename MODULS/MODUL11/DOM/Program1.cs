using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MODULS.MODUL11.DOM
{
    public class Book
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public string ISBN { get; set; }
        public bool IsAvailable { get; set; }

        public Book(string title, string author, string isbn)
        {
            Title = title;
            Author = author;
            ISBN = isbn;
            IsAvailable = true;
        }

        public override string ToString()
        {
            return $"{Title} около {Author} (ISBN: {ISBN}) - {(IsAvailable ? "Доступный" : "Арендованный")}";
        }
    }

    public class Reader
    {
        public string Name { get; set; }
        public List<Book> RentedBooks { get; set; }

        private const int MaxBooks = 3;

        public Reader(string name)
        {
            Name = name;
            RentedBooks = new List<Book>();
        }

        public bool RentBook(Book book)
        {
            if (RentedBooks.Count >= MaxBooks)
            {
                Console.WriteLine($"{Name} не может взять больше {MaxBooks} книг.");
                return false;
            }

            if (!book.IsAvailable)
            {
                Console.WriteLine($"Книга '{book.Title}' недоступна.");
                return false;
            }

            RentedBooks.Add(book);
            book.IsAvailable = false;
            Console.WriteLine($"Читатель {Name} успешно арендовал книгу '{book.Title}'.");
            return true;
        }

        public void ReturnBook(Book book)
        {
            if (RentedBooks.Remove(book))
            {
                book.IsAvailable = true;
                Console.WriteLine($"Читатель {Name} успешно вернул книгу '{book.Title}'.");
            }
            else
            {
                Console.WriteLine($"Книга '{book.Title}' не найдена в списке арендованных.");
            }
        }
    }

    public class Library
    {
        public List<Book> Books { get; set; }

        public Library()
        {
            Books = new List<Book>();
        }

        public void AddBook(Book book)
        {
            Books.Add(book);
        }

        public void DisplayAvailableBooks()
        {
            Console.WriteLine("Список доступных книг в библиотеке:");
            foreach (var book in Books.Where(b => b.IsAvailable))
            {
                Console.WriteLine(book);
            }
        }

        public void DisplayAllBooks()
        {
            Console.WriteLine("Все книги в библиотеке:");
            foreach (var book in Books)
            {
                Console.WriteLine(book);
            }
        }

        public List<Book> SearchBooks(string query)
        {
            return Books.Where(b => b.Title.IndexOf(query, StringComparison.OrdinalIgnoreCase) >= 0 ||
                                    b.Author.IndexOf(query, StringComparison.OrdinalIgnoreCase) >= 0).ToList();
        }
    }

    internal class Program1
    {
        /*public static void Main()
        {
            Library library = new Library();
            library.AddBook(new Book("Война и мир", "Лев Толстой", "123456789"));
            library.AddBook(new Book("Преступление и наказание", "Федор Достоевский", "987654321"));
            library.AddBook(new Book("Мастер и Маргарита", "Михаил Булгаков", "111222333"));

            Reader reader = new Reader("Иван Иванов");

            library.DisplayAvailableBooks();

            var bookToRent = library.Books.First();
            reader.RentBook(bookToRent);

            library.DisplayAvailableBooks();

            reader.RentBook(bookToRent);

            reader.ReturnBook(bookToRent);

            library.DisplayAvailableBooks();

            Console.WriteLine("Введите название книги для поиска:");
            string query = Console.ReadLine();
            var searchResults = library.SearchBooks(query);
            Console.WriteLine("Результат поиска:");
            foreach (var book in searchResults)
            {
                Console.WriteLine(book);
            }

            reader.RentBook(library.Books[1]);
            reader.RentBook(library.Books[2]);
            reader.RentBook(bookToRent);

            reader.RentBook(new Book("Четвертая книга", "Автор", "444555666"));
        }*/
    }
}
