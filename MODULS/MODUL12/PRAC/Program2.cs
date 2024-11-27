using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MODULS.MODUL12.PRAC
{

    public enum UserRole
    {
        Guest,
        RegisteredUser,
        Admin
    }

    public class Event
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public DateTime Date { get; set; }
        public string Location { get; set; }
    }

    public class User
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public UserRole Role { get; set; }
    }

    public class Booking
    {
        public int ID { get; set; }
        public User User { get; set; }
        public Event Event { get; set; }
        public string Status { get; set; }
    }

    public class EventSystem
    {
        private List<Event> _events = new List<Event>();
        private List<Booking> _bookings = new List<Booking>();
        private List<User> _users = new List<User>();

        public EventSystem()
        {
            SeedData();
        }

        private void SeedData()
        {
            _events.Add(new Event { ID = 1, Title = "Tech Conference", Date = DateTime.Now.AddDays(10), Location = "Conference Hall A" });
            _events.Add(new Event { ID = 2, Title = "Music Festival", Date = DateTime.Now.AddDays(20), Location = "Open Air Stage" });

            _users.Add(new User { ID = 1, Name = "John Doe", Role = UserRole.RegisteredUser });
            _users.Add(new User { ID = 2, Name = "Jane Admin", Role = UserRole.Admin });
            _users.Add(new User { ID = 3, Name = "Guest User", Role = UserRole.Guest });
        }

        public void ViewEvents()
        {
            Console.WriteLine("Список мероприятий:");
            foreach (var e in _events)
            {
                Console.WriteLine($"ID: {e.ID}, Название: {e.Title}, Дата: {e.Date}, Место: {e.Location}");
            }
        }

        public void BookEvent(int userId, int eventId)
        {
            var user = _users.FirstOrDefault(u => u.ID == userId);
            var selectedEvent = _events.FirstOrDefault(e => e.ID == eventId);

            if (user == null || selectedEvent == null || user.Role == UserRole.Guest)
            {
                Console.WriteLine("Бронирование невозможно. Убедитесь, что вы зарегистрированный пользователь.");
                return;
            }

            var booking = new Booking
            {
                ID = _bookings.Count + 1,
                User = user,
                Event = selectedEvent,
                Status = "Confirmed"
            };

            _bookings.Add(booking);
            Console.WriteLine($"Мероприятие '{selectedEvent.Title}' успешно забронировано для пользователя {user.Name}.");
        }

        public void CancelBooking(int userId, int bookingId)
        {
            var booking = _bookings.FirstOrDefault(b => b.ID == bookingId && b.User.ID == userId);

            if (booking == null)
            {
                Console.WriteLine("Бронирование не найдено или отмена невозможна.");
                return;
            }

            booking.Status = "Cancelled";
            Console.WriteLine($"Бронирование '{booking.Event.Title}' отменено.");
        }

        public void ManageEvents(int adminId, string action, Event newEvent = null, int eventId = 0)
        {
            var admin = _users.FirstOrDefault(u => u.ID == adminId && u.Role == UserRole.Admin);

            if (admin == null)
            {
                Console.WriteLine("Управление мероприятиями доступно только для администраторов.");
                return;
            }

            switch (action.ToLower())
            {
                case "add":
                    if (newEvent != null)
                    {
                        _events.Add(newEvent);
                        Console.WriteLine($"Мероприятие '{newEvent.Title}' добавлено.");
                    }
                    break;
                case "edit":
                    var eventToEdit = _events.FirstOrDefault(e => e.ID == eventId);
                    if (eventToEdit != null && newEvent != null)
                    {
                        eventToEdit.Title = newEvent.Title;
                        eventToEdit.Date = newEvent.Date;
                        eventToEdit.Location = newEvent.Location;
                        Console.WriteLine($"Мероприятие '{eventToEdit.Title}' обновлено.");
                    }
                    break;
                case "delete":
                    var eventToDelete = _events.FirstOrDefault(e => e.ID == eventId);
                    if (eventToDelete != null)
                    {
                        _events.Remove(eventToDelete);
                        Console.WriteLine($"Мероприятие '{eventToDelete.Title}' удалено.");
                    }
                    break;
                default:
                    Console.WriteLine("Неизвестное действие.");
                    break;
            }
        }

        public void ViewAllBookings(int adminId)
        {
            var admin = _users.FirstOrDefault(u => u.ID == adminId && u.Role == UserRole.Admin);

            if (admin == null)
            {
                Console.WriteLine("Просмотр всех бронирований доступен только для администраторов.");
                return;
            }

            Console.WriteLine("Список бронирований:");
            foreach (var booking in _bookings)
            {
                Console.WriteLine($"ID: {booking.ID}, Мероприятие: {booking.Event.Title}, Пользователь: {booking.User.Name}, Статус: {booking.Status}");
            }
        }
    }
    internal class Program2
    {
        /*static void Main(string[] args)
        {
            var system = new EventSystem();

            system.ViewEvents();

            system.BookEvent(1, 1);
            system.ViewEvents();

            system.CancelBooking(1, 1);

            system.ManageEvents(2, "add", new Event { ID = 3, Title = "Art Workshop", Date = DateTime.Now.AddDays(15), Location = "Art Center" });

            system.ViewAllBookings(2);
        }*/
    }
}
