using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MODULS.MODUL13.DOM
{
    // Класс для клиента
    public class Client
    {
        public string Name { get; set; }
        public void RequestBooking(DateTime eventDate)
        {
            Console.WriteLine($"Клиент {Name} запросил бронирование на {eventDate:dd.MM.yyyy}.");
        }

        public void ConfirmBooking()
        {
            Console.WriteLine($"Клиент {Name} подтвердил бронирование.");
        }
    }

    // Класс для системы
    public class System
    {
        public bool CheckAvailability(DateTime eventDate)
        {
            Console.WriteLine($"Система проверяет доступность площадок на {eventDate:dd.MM.yyyy}.");
            // Имитация доступности площадки
            return eventDate.Day % 2 == 0;
        }

        public void NotifyClient(string message)
        {
            Console.WriteLine($"Система уведомляет клиента: {message}");
        }

        public void NotifyAdmin(string message)
        {
            Console.WriteLine($"Система уведомляет администратора площадки: {message}");
        }

        public void NotifyContractors(List<string> tasks)
        {
            Console.WriteLine("Система уведомляет подрядчиков о задачах:");
            foreach (var task in tasks)
            {
                Console.WriteLine($"- {task}");
            }
        }
    }

    // Класс для работы с платежами
    public class PaymentGateway
    {
        public bool ProcessPayment()
        {
            Console.WriteLine("Платежный шлюз обрабатывает платеж...");
            // Имитация успешного платежа
            return true;
        }
    }

    // Класс для администратора
    public class Admin
    {
        public void PrepareTasks()
        {
            Console.WriteLine("Администратор подготавливает список задач.");
        }

        public void ReceiveReport()
        {
            Console.WriteLine("Администратор получил отчет о выполнении задач.");
        }
    }

    // Класс для подрядчиков
    public class Contractor
    {
        public void ConfirmTaskCompletion(string task)
        {
            Console.WriteLine($"Подрядчик подтвердил выполнение задачи: {task}");
        }
    }

    // Основная программа
    internal class Program2
    {
        /*public static void Main(string[] args)
        {
            // Инициализация объектов
            Client client = new Client { Name = "Макс Бакижанов" };
            System system = new System();
            PaymentGateway paymentGateway = new PaymentGateway();
            Admin admin = new Admin();
            Contractor contractor = new Contractor();

            // Этап 1: Запрос на бронирование
            DateTime eventDate = new DateTime(2024, 12, 25);
            client.RequestBooking(eventDate);

            if (system.CheckAvailability(eventDate))
            {
                system.NotifyClient("Площадка доступна. Условия и стоимость отправлены.");

                // Этап 2: Подтверждение бронирования
                client.ConfirmBooking();
                if (paymentGateway.ProcessPayment())
                {
                    system.NotifyClient("Платеж прошел успешно. Бронирование подтверждено.");
                    system.NotifyAdmin("Новое бронирование подтверждено.");

                    // Этап 3: Организация мероприятия
                    admin.PrepareTasks();
                    List<string> tasks = new List<string> { "Декорации", "Еда", "Оборудование" };
                    system.NotifyContractors(tasks);

                    foreach (var task in tasks)
                    {
                        contractor.ConfirmTaskCompletion(task);
                    }

                    admin.ReceiveReport();
                }
                else
                {
                    system.NotifyClient("Платеж отклонен. Попробуйте еще раз.");
                }
            }
            else
            {
                system.NotifyClient("Площадка недоступна. Выберите другую дату или площадку.");
            }

            // Этап 4: Завершение мероприятия
            system.NotifyClient("Спасибо за использование нашей системы! Оцените качество сервиса.");
            Console.WriteLine("Система собирает отзывы и отправляет отчет менеджеру.");
        }*/
    }
}
