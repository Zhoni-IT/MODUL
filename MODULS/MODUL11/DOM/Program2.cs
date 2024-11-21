using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MODULS.MODUL11.DOM
{
    public interface IHotelService
    {
        List<Hotel> SearchHotels(string location, string roomType, decimal maxPrice);
    }

    public interface IBookingService
    {
        Booking CreateBooking(User user, Hotel hotel, DateTime checkIn, DateTime checkOut);
        bool CheckAvailability(Hotel hotel, DateTime checkIn, DateTime checkOut);
        List<Booking> GetUserBookings(User user);
    }

    public interface IPaymentService
    {
        bool ProcessPayment(User user, decimal amount, string paymentMethod);
    }

    public interface INotificationService
    {
        void SendNotification(User user, string message);
    }

    public interface IUserManagementService
    {
        User Register(string name, string email, string password);
        User Login(string email, string password);
    }
    public class User
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }

    public class Hotel
    {
        public string Name { get; set; }
        public string Location { get; set; }
        public string RoomType { get; set; }
        public decimal PricePerNight { get; set; }
        public int RoomsAvailable { get; set; }
    }

    public class Booking
    {
        public User User { get; set; }
        public Hotel Hotel { get; set; }
        public DateTime CheckIn { get; set; }
        public DateTime CheckOut { get; set; }
        public decimal TotalPrice { get; set; }
    }
    public class HotelService : IHotelService
    {
        private List<Hotel> hotels = new List<Hotel>
    {
        new Hotel { Name = "Grand Hotel", Location = "Almaty", RoomType = "Deluxe", PricePerNight = 200, RoomsAvailable = 5 },
        new Hotel { Name = "Sulutor Hotel", Location = "Almaty", RoomType = "Standard", PricePerNight = 100, RoomsAvailable = 10 },
    };

        public List<Hotel> SearchHotels(string location, string roomType, decimal maxPrice)
        {
            return hotels.Where(h => h.Location == location && h.RoomType == roomType && h.PricePerNight <= maxPrice).ToList();
        }
    }
    public class BookingService : IBookingService
    {
        private List<Booking> bookings = new List<Booking>();

        public Booking CreateBooking(User user, Hotel hotel, DateTime checkIn, DateTime checkOut)
        {
            if (!CheckAvailability(hotel, checkIn, checkOut))
            {
                throw new Exception("Номера на выбранные даты недоступны.");
            }

            var booking = new Booking
            {
                User = user,
                Hotel = hotel,
                CheckIn = checkIn,
                CheckOut = checkOut,
                TotalPrice = (checkOut - checkIn).Days * hotel.PricePerNight
            };

            bookings.Add(booking);
            hotel.RoomsAvailable -= 1;
            return booking;
        }

        public bool CheckAvailability(Hotel hotel, DateTime checkIn, DateTime checkOut)
        {
            return hotel.RoomsAvailable > 0;
        }

        public List<Booking> GetUserBookings(User user)
        {
            return bookings.Where(b => b.User == user).ToList();
        }
    }
    public class PaymentService : IPaymentService
    {
        public bool ProcessPayment(User user, decimal amount, string paymentMethod)
        {
            Console.WriteLine($"Обработка  {paymentMethod} платежа  {amount} для  {user.Name}...");
            return true;
        }
    }
    public class NotificationService : INotificationService
    {
        public void SendNotification(User user, string message)
        {
            Console.WriteLine($"Уведомление для {user.Name}: {message}");
        }
    }
    public class UserManagementService : IUserManagementService
    {
        private List<User> users = new List<User>();

        public User Register(string name, string email, string password)
        {
            var user = new User { Name = name, Email = email, Password = password };
            users.Add(user);
            return user;
        }

        public User Login(string email, string password)
        {
            return users.FirstOrDefault(u => u.Email == email && u.Password == password);
        }
    }
    internal class Program2
    {
        /*public static void Main(string[] args)
        {
            IHotelService hotelService = new HotelService();
            IBookingService bookingService = new BookingService();
            IPaymentService paymentService = new PaymentService();
            INotificationService notificationService = new NotificationService();
            IUserManagementService userService = new UserManagementService();

            var user = userService.Register("Maks", "maks@example.com", "password123");
            Console.WriteLine("Пользователь успешно зарегистрировался.");

            var hotels = hotelService.SearchHotels("Almaty", "Deluxe", 250);
            Console.WriteLine("Доступные отели:");
            hotels.ForEach(h => Console.WriteLine($"{h.Name}, {h.Location}, {h.PricePerNight}/ночь"));

            var booking = bookingService.CreateBooking(user, hotels.First(), DateTime.Now.AddDays(1), DateTime.Now.AddDays(3));
            Console.WriteLine($"Бронирование, созданное для {booking.Hotel.Name}. Итоговая цена: {booking.TotalPrice}");

            paymentService.ProcessPayment(user, booking.TotalPrice, "Кредитная карта");

            notificationService.SendNotification(user, "Ваше бронирование подтверждено.");
        }*/
    }
}
