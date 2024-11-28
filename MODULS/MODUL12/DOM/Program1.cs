using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MODULS.MODUL12.DOM
{
    // Базовый интерфейс пользователя
    public interface IUser
    {
        void Register(string name);
    }

    // Читатель
    public class Reader : IUser
    {
        public string Name { get; private set; }
        public List<string> BookingHistory { get; private set; } = new List<string>();

        public void Register(string name)
        {
            Name = name;
            Console.WriteLine($"Читатель {Name} зарегистрирован.");
        }

        public void ViewBooks(List<string> books)
        {
            Console.WriteLine("Доступные книги:");
            foreach (var book in books)
            {
                Console.WriteLine($"- {book}");
            }
        }

        public void ReserveBook(string book)
        {
            Console.WriteLine($"Книга '{book}' забронирована.");
            BookingHistory.Add(book);
        }

        public void CancelReservation(string book)
        {
            Console.WriteLine($"Бронирование книги '{book}' отменено.");
            BookingHistory.Remove(book);
        }

        public void ViewBookingHistory()
        {
            Console.WriteLine("История бронирований:");
            foreach (var book in BookingHistory)
            {
                Console.WriteLine($"- {book}");
            }
        }
    }

    // Библиотекарь
    public class Librarian : Reader
    {
        public void AddBook(List<string> books, string book)
        {
            books.Add(book);
            Console.WriteLine($"Книга '{book}' добавлена в каталог.");
        }

        public void RemoveBook(List<string> books, string book)
        {
            books.Remove(book);
            Console.WriteLine($"Книга '{book}' удалена из каталога.");
        }

        public void IssueBook(string book)
        {
            Console.WriteLine($"Книга '{book}' выдана.");
        }

        public void ReturnBook(string book)
        {
            Console.WriteLine($"Книга '{book}' возвращена.");
        }
    }

    // Администратор
    public class Admin : Librarian
    {
        public void ManageBranch(string branch, bool add)
        {
            if (add)
                Console.WriteLine($"Филиал '{branch}' добавлен.");
            else
                Console.WriteLine($"Филиал '{branch}' удален.");
        }

        public void ViewAnalytics()
        {
            Console.WriteLine("Просмотр аналитики...");
        }
    }
    internal class Program1
    {
        /*static void Main()
        {
            List<string> books = new List<string> { "Книга A", "Книга B", "Книга C" };

            Reader reader = new Reader();
            reader.Register("Максат");
            reader.ViewBooks(books);
            reader.ReserveBook("Книга A");
            reader.ViewBookingHistory();
            reader.CancelReservation("Книга A");

            Librarian librarian = new Librarian();
            librarian.AddBook(books, "Книга D");
            librarian.RemoveBook(books, "Книга B");
            librarian.IssueBook("Книга C");
            librarian.ReturnBook("Книга C");

            Admin admin = new Admin();
            admin.ManageBranch("Филиал 1", true);
            admin.ViewAnalytics();
        }*/
    }
}
