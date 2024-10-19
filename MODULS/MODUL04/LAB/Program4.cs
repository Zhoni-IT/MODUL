using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MODULS.MODUL04.LAB
{
    public interface INotificationService
    {
        void SendNotification(string message);
    }

    public class EmailService : INotificationService
    {
        public void SendNotification(string message)
        {
            Console.WriteLine($"Отправка Email: {message}");
        }
    }

    public class SmsService : INotificationService
    {
        public void SendNotification(string message)
        {
            Console.WriteLine($"Отправка SMS: {message}");
        }
    }

    public class Notification
    {
        private readonly INotificationService _notificationService;

        public Notification(INotificationService notificationService)
        {
            _notificationService = notificationService;
        }

        public void Send(string message)
        {
            _notificationService.SendNotification(message);
        }
    }

    public class Program4
    {
        /*public static void Main(string[] args)
        {
            INotificationService emailService = new EmailService();
            INotificationService smsService = new SmsService();

            Notification emailNotification = new Notification(emailService);
            emailNotification.Send("Это тестовое сообщение Email.");

            Notification smsNotification = new Notification(smsService);
            smsNotification.Send("Это тестовое сообщение SMS.");
        }*/
    }
}
