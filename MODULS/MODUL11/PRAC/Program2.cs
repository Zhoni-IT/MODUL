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
        public string Author { get; set; }
        public string Genre { get; set; }
        public string ISBN { get; set; }

        public Book(string title, string author, string genre, string isbn)
        {
            Title = title;
            Author = author;
            Genre = genre;
            ISBN = isbn;
        }

        public string GetBookInfo()
        {
            return $"{Title} by {Author}, Genre: {Genre}, ISBN: {ISBN}";
        }
    }

    public class Reader
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string LibraryCardNumber { get; set; }

        public Reader(string firstName, string lastName, string libraryCardNumber)
        {
            FirstName = firstName;
            LastName = lastName;
            LibraryCardNumber = libraryCardNumber;
        }
    }

    public class Librarian
    {
        private AccountingSystem _accountingSystem;

        public Librarian(AccountingSystem accountingSystem)
        {
            _accountingSystem = accountingSystem;
        }

        public void IssueBook(Book book, Reader reader)
        {
            Console.WriteLine($"{reader.FirstName} {reader.LastName} взял книгу: {book.GetBookInfo()}");
            _accountingSystem.TrackIssuedBooks(book, reader);
        }

        public void ReturnBook(Book book, Reader reader)
        {
            Console.WriteLine($"{reader.FirstName} {reader.LastName} вернул книгу: {book.GetBookInfo()}");
            _accountingSystem.TrackReturnedBooks(book, reader);
        }
    }

    public class Catalog
    {
        public List<Book> Books { get; set; }

        public Catalog()
        {
            Books = new List<Book>();
        }

        public List<Book> SearchBookByTitle(string title)
        {
            return Books.Where(b => b.Title.Contains(title)).ToList();
        }

        public List<Book> SearchBookByAuthor(string author)
        {
            return Books.Where(b => b.Author.Contains(author)).ToList();
        }

        public List<Book> SearchBookByGenre(string genre)
        {
            return Books.Where(b => b.Genre.Contains(genre)).ToList();
        }
    }

    public class AccountingSystem
    {
        private List<string> _transactions;

        public AccountingSystem()
        {
            _transactions = new List<string>();
        }

        public void TrackIssuedBooks(Book book, Reader reader)
        {
            var transaction = $"{reader.FirstName} {reader.LastName} взял книгу: {book.GetBookInfo()}";
            _transactions.Add(transaction);
            RecordTransaction(transaction);
        }

        public void TrackReturnedBooks(Book book, Reader reader)
        {
            var transaction = $"{reader.FirstName} {reader.LastName} вернул книгу: {book.GetBookInfo()}";
            _transactions.Add(transaction);
            RecordTransaction(transaction);
        }

        private void RecordTransaction(string transaction)
        {
            Console.WriteLine($"Запись транзакции: {transaction}");
        }
    }*/
    internal class Program2
    {
        /*public static void Main(string[] args)
        {
            var catalog = new Catalog();
            var accountingSystem = new AccountingSystem();
            var librarian = new Librarian(accountingSystem);

            catalog.Books.Add(new Book("Война и мир", "Лев Толстой", "Роман", "978-5-17-118118-4"));
            catalog.Books.Add(new Book("Преступление и наказание", "Фёдор Достоевский", "Роман", "978-5-17-118119-1"));

            var reader = new Reader("Асия", "Закирова", "12345");

            var booksFound = catalog.SearchBookByTitle("Война и мир");
            foreach (var book in booksFound)
            {
                Console.WriteLine(book.GetBookInfo());
            }

            librarian.IssueBook(booksFound[0], reader);

            librarian.ReturnBook(booksFound[0], reader);
        }*/
    }
}
