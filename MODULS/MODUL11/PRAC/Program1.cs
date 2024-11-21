using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MODULS.MODUL11.PRAC
{
    /*public class Book
    {
        public string Title { get; set; }
        public string ISBN { get; set; }
        public string Author { get; set; }
        public int PublicationYear { get; set; }
        public bool AvailabilityStatus { get; set; } = true;

        public void ChangeAvailabilityStatus(bool status)
        {
            AvailabilityStatus = status;
        }

        public string GetBookInfo()
        {
            return $"{Title} by {Author}, ISBN: {ISBN}, Year: {PublicationYear}, Available: {AvailabilityStatus}";
        }
    }

    public abstract class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }

        public abstract void Register(string name, string email);
        public abstract void Login(string email);
    }

    public class Reader : User
    {
        public override void Register(string name, string email)
        {
            Name = name;
            Email = email;
            Console.WriteLine($"{Name} зарегистрирован как читатель.");
        }

        public override void Login(string email)
        {
            Console.WriteLine($"{Name} вошел в систему.");
        }

        public void BorrowBook(Book book)
        {
            if (book.AvailabilityStatus)
            {
                book.ChangeAvailabilityStatus(false);
                Console.WriteLine($"{Name} взял книгу: {book.Title}");
            }
            else
            {
                Console.WriteLine("Книга уже занята.");
            }
        }
    }

    public class Librarian : User
    {
        public override void Register(string name, string email)
        {
            Name = name;
            Email = email;
            Console.WriteLine($"{Name} зарегистрирован как библиотекарь.");
        }

        public override void Login(string email)
        {
            Console.WriteLine($"{Name} вошел в систему как библиотекарь.");
        }

        public void AddBook(Library library, Book book)
        {
            library.Books.Add(book);
            Console.WriteLine($"Книга '{book.Title}' добавлена в библиотеку.");
        }

        public void RemoveBook(Library library, Book book)
        {
            library.Books.Remove(book);
            Console.WriteLine($"Книга '{book.Title}' удалена из библиотеки.");
        }

        public void EditBook(Book book, string newTitle, string newAuthor)
        {
            book.Title = newTitle;
            book.Author = newAuthor;
            Console.WriteLine($"Книга '{book.ISBN}' отредактирована.");
        }
    }

    public class Loan
    {
        public Book Book { get; set; }
        public Reader Reader { get; set; }
        public DateTime LoanDate { get; set; }
        public DateTime ReturnDate { get; set; }

        public void IssueLoan(Book book, Reader reader)
        {
            Book = book;
            Reader = reader;
            LoanDate = DateTime.Now;
            Console.WriteLine($"Книга '{book.Title}' выдана читателю {reader.Name}.");
        }

        public void ReturnBook()
        {
            Book.ChangeAvailabilityStatus(true);
            Console.WriteLine($"Книга '{Book.Title}' возвращена.");
        }
    }

    public class Library
    {
        public List<Book> Books { get; set; } = new List<Book>();
        public List<Loan> Loans { get; set; } = new List<Loan>();

        public void AddBook(Book book)
        {
            Books.Add(book);
            Console.WriteLine($"Книга '{book.Title}' добавлена в библиотеку.");
        }

        public void RemoveBook(Book book)
        {
            Books.Remove(book);
            Console.WriteLine($"Книга '{book.Title}' удалена из библиотеки.");
        }

        public List<Book> SearchBook(string title)
        {
            return Books.Where(b => b.Title.Contains(title)).ToList();
        }

        public void GenerateReport()
        {
            Console.WriteLine("Отчет по библиотеке:");
            Console.WriteLine($"Всего книг: {Books.Count}");
            Console.WriteLine($"Всего выдач: {Loans.Count}");
        }
    }

    public class Report
    {
        public void GenerateReport(Library library)
        {
            Console.WriteLine("Отчет по популярности книг:");
            foreach (var book in library.Books)
            {
                Console.WriteLine($"{book.Title}: {library.Loans.Count(l => l.Book == book)} аренды");
            }
        }
    }
    */
    internal class Program1
    {
        /*public static void Main(string[] args)
        {
            Library library = new Library();
            Librarian librarian = new Librarian();
            Reader reader = new Reader();

            librarian.Register("Бакижанов Максат", "maks@library.com");
            reader.Register("Калдарбек Ернар", "eryema@library.com");

            librarian.Login("maks@library.com");
            reader.Login("eryema@library.com");

            Book book1 = new Book { Title = "Мастер и Маргарита", ISBN = "123456", Author = "Михаил Булгаков", PublicationYear = 1967 };
            Book book2 = new Book { Title = "1984", ISBN = "654321", Author = "Джордж Оруэлл", PublicationYear = 1949 };

            librarian.AddBook(library, book1);
            librarian.AddBook(library, book2);

            var searchResults = library.SearchBook("1984");
            Console.WriteLine("Результаты поиска:");
            foreach (var book in searchResults)
            {
                Console.WriteLine(book.GetBookInfo());
            }

            reader.BorrowBook(book1);

            library.GenerateReport();
            Report report = new Report();
            report.GenerateReport(library);
        }*/
    }
}
