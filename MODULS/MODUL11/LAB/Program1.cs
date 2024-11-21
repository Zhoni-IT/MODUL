using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MODULS.MODUL11.LAB
{
    public class Book
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public string ISBN { get; set; }
        public bool IsAvailable { get; private set; } = true;

        public void MarkAsLoaned()
        {
            IsAvailable = false;
        }

        public void MarkAsAvailable()
        {
            IsAvailable = true;
        }
    }

    public class Reader
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public List<Book> BorrowedBooks { get; private set; } = new List<Book>();

        public void BorrowBook(Book book)
        {
            if (book.IsAvailable)
            {
                book.MarkAsLoaned();
                BorrowedBooks.Add(book);
                Console.WriteLine($"{Name} взял книгу: {book.Title}");
            }
            else
            {
                Console.WriteLine($"Книга  '{book.Title}' недоступна.");
            }
        }

        public void ReturnBook(Book book)
        {
            if (BorrowedBooks.Contains(book))
            {
                book.MarkAsAvailable();
                BorrowedBooks.Remove(book);
                Console.WriteLine($"{Name} вернул книгу: {book.Title}");
            }
            else
            {
                Console.WriteLine($"Книга '{book.Title}' не заимствован другими {Name}.");
            }
        }
    }

    public class Librarian
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Position { get; set; }
        private List<Book> Books { get; set; } = new List<Book>();

        public void AddBook(Book book)
        {
            Books.Add(book);
            Console.WriteLine($"Книга '{book.Title}' добавлено в библиотеку.");
        }

        public void RemoveBook(Book book)
        {
            if (Books.Remove(book))
            {
                Console.WriteLine($"Книга '{book.Title}' удалено из библиотеки.");
            }
            else
            {
                Console.WriteLine($"Книга '{book.Title}' не найден в библиотеке.");
            }
        }
    }

    public class Loan
    {
        public Book Book { get; private set; }
        public Reader Reader { get; private set; }
        public DateTime LoanDate { get; private set; }
        public DateTime ReturnDate { get; private set; }

        public void IssueLoan(Book book, Reader reader)
        {
            if (book.IsAvailable)
            {
                Book = book;
                Reader = reader;
                LoanDate = DateTime.Now;
                book.MarkAsLoaned();
                reader.BorrowBook(book);
                Console.WriteLine($"Выданный кредит: {book.Title} для  {reader.Name}");
            }
            else
            {
                Console.WriteLine($"Книга '{book.Title}' недоступен для получения кредита.");
            }
        }

        public void CompleteLoan()
        {
            if (Book != null && Reader != null)
            {
                ReturnDate = DateTime.Now;
                Book.MarkAsAvailable();
                Reader.ReturnBook(Book);
                Console.WriteLine($"Выданный кредит завершен: {Book.Title} для {Reader.Name}");
            }
        }
    }

    internal class Program1
    {
        /*static void Main(string[] args)
        {
            Librarian librarian = new Librarian { Id = 1, Name = "Asia", Position = "Главный библиотекарь" };
            Reader reader = new Reader { Id = 1, Name = "Maks", Email = "maks@example.com" };

            Book book1 = new Book { Title = "C# Programming", Author = "Jane Smith", ISBN = "1234567890" };
            Book book2 = new Book { Title = "Introduction to Algorithms", Author = "Thomas H. Cormen", ISBN = "9876543210" };

            librarian.AddBook(book1);
            librarian.AddBook(book2);

            reader.BorrowBook(book1);
            reader.ReturnBook(book1);

            Loan loan = new Loan();
            loan.IssueLoan(book2, reader);
            loan.CompleteLoan();
        }*/
    }
}