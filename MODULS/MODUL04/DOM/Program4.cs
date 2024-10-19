using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MODULS.MODUL04.DOM
{
    public interface INotificationSender
    {
        void Send(string message);
    }

    public class EmailSender : INotificationSender
    {
        public void Send(string message)
        {
            Console.WriteLine("Email отправлен: " + message);
        }
    }

    public class SmsSender : INotificationSender
    {
        public void Send(string message)
        {
            Console.WriteLine("SMS отправлено: " + message);
        }
    }

    public class NotificationService
    {
        private readonly INotificationSender[] _notificationSenders;

        public NotificationService(INotificationSender[] notificationSenders)
        {
            _notificationSenders = notificationSenders;
        }

        public void SendNotification(string message)
        {
            foreach (var sender in _notificationSenders)
            {
                sender.Send(message);
            }
        }
    }
    internal class Program4
    {
        /*public static void Main(string[] args)
        {
            INotificationSender[] senders = new INotificationSender[]
            {
            new EmailSender(),
            new SmsSender()
            };

            NotificationService notificationService = new NotificationService(senders);
            notificationService.SendNotification("Привет! Это тестовое сообщение.");
        }*/
    }
}
