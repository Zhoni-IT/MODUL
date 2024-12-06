using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MODULS.MODUL13.PRAC
{
    internal class Program1
    {
        /*static void Main(string[] args)
        {
            Console.WriteLine("Добро пожаловать в библиотеку!");

            // Проверка читательского билета
            Console.Write("У вас есть читательский билет? (да/нет): ");
            string hasCard = Console.ReadLine()?.ToLower();

            if (hasCard != "да")
            {
                Console.WriteLine("Необходимо оформить читательский билет.");
                IssueLibraryCard();
            }

            // Выбор книги
            Console.WriteLine("Выберите книгу из каталога:");
            var catalog = new List<string> { "Мастер и Маргарита", "Преступление и наказание", "Война и мир" };
            DisplayCatalog(catalog);

            while (true)
            {
                Console.Write("Введите название книги: ");
                string selectedBook = Console.ReadLine();

                if (CheckBookAvailability(selectedBook, catalog))
                {
                    RegisterBookIssue(selectedBook);
                    Console.WriteLine($"Книга \"{selectedBook}\" выдана. Приятного чтения!");
                    break;
                }
                else
                {
                    Console.WriteLine("Книга недоступна. Пожалуйста, выберите другую.");
                }
            }
        }*/

        // Метод оформления читательского билета
        static void IssueLibraryCard()
        {
            Console.WriteLine("Читательский билет успешно оформлен!");
        }

        // Метод отображения каталога
        static void DisplayCatalog(List<string> catalog)
        {
            Console.WriteLine("Доступные книги:");
            foreach (var book in catalog)
            {
                Console.WriteLine($"- {book}");
            }
        }

        // Метод проверки доступности книги
        static bool CheckBookAvailability(string book, List<string> catalog)
        {
            return catalog.Contains(book);
        }

        // Метод регистрации выдачи книги
        static void RegisterBookIssue(string book)
        {
            Console.WriteLine($"Книга \"{book}\" зарегистрирована как выданная.");
        }
    }
}
