using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MODULS.MODUL10.PRAC
{
    public class RoomBookingSystem
    {
        public void BookRoom(int roomNumber)
        {
            Console.WriteLine($"Номер {roomNumber} забронирован.");
        }

        public void CancelRoomBooking(int roomNumber)
        {
            Console.WriteLine($"Бронирование номера {roomNumber} отменено.");
        }
    }

    public class RestaurantSystem
    {
        public void ReserveTable(int tableNumber)
        {
            Console.WriteLine($"Стол {tableNumber} зарезервирован.");
        }

        public void OrderFood(string dish)
        {
            Console.WriteLine($"Блюдо заказано: {dish}.");
        }
    }

    public class EventManagementSystem
    {
        public void ReserveEventHall(int hallNumber)
        {
            Console.WriteLine($"Конференц-зал {hallNumber} зарезервирован.");
        }

        public void BookEquipment(string equipment)
        {
            Console.WriteLine($"Оборудование забронировано: {equipment}.");
        }
    }

    public class CleaningService
    {
        public void ScheduleCleaning(int roomNumber, string time)
        {
            Console.WriteLine($"Запланирована уборка номера {roomNumber} на {time}.");
        }

        public void RequestImmediateCleaning(int roomNumber)
        {
            Console.WriteLine($"Запрошена немедленная уборка для номера {roomNumber}.");
        }
    }

    public class HotelFacade
    {
        private readonly RoomBookingSystem _roomBooking;
        private readonly RestaurantSystem _restaurant;
        private readonly EventManagementSystem _eventManagement;
        private readonly CleaningService _cleaning;

        public HotelFacade(RoomBookingSystem roomBooking, RestaurantSystem restaurant, EventManagementSystem eventManagement, CleaningService cleaning)
        {
            _roomBooking = roomBooking;
            _restaurant = restaurant;
            _eventManagement = eventManagement;
            _cleaning = cleaning;
        }

        public void BookRoomWithService(int roomNumber, string dish, string cleaningTime)
        {
            _roomBooking.BookRoom(roomNumber);
            _restaurant.OrderFood(dish);
            _cleaning.ScheduleCleaning(roomNumber, cleaningTime);
            Console.WriteLine("Номер, еда и уборка успешно организованы.\n");
        }

        public void OrganizeEvent(int hallNumber, string equipment, int roomNumber)
        {
            _eventManagement.ReserveEventHall(hallNumber);
            _eventManagement.BookEquipment(equipment);
            _roomBooking.BookRoom(roomNumber);
            Console.WriteLine("Мероприятие, оборудование и размещение успешно организованы.\n");
        }

        public void ReserveTableWithTaxi(int tableNumber)
        {
            _restaurant.ReserveTable(tableNumber);
            Console.WriteLine("Такси вызвано.");
            Console.WriteLine("Стол и такси успешно забронированы.\n");
        }

        public void CancelRoomBooking(int roomNumber)
        {
            _roomBooking.CancelRoomBooking(roomNumber);
            Console.WriteLine("Бронирование номера отменено.\n");
        }

        public void RequestImmediateCleaning(int roomNumber)
        {
            _cleaning.RequestImmediateCleaning(roomNumber);
            Console.WriteLine("Немедленная уборка запрошена.\n");
        }
    }

    internal class Program
    {
        /*static void Main(string[] args)
        {
            RoomBookingSystem roomBooking = new RoomBookingSystem();
            RestaurantSystem restaurant = new RestaurantSystem();
            EventManagementSystem eventManagement = new EventManagementSystem();
            CleaningService cleaning = new CleaningService();

            HotelFacade hotel = new HotelFacade(roomBooking, restaurant, eventManagement, cleaning);

            hotel.BookRoomWithService(101, "Паста", "10:00 утра");

            hotel.OrganizeEvent(1, "Проектор", 102);

            hotel.ReserveTableWithTaxi(5);

            hotel.CancelRoomBooking(101);

            hotel.RequestImmediateCleaning(102);
        }*/
    }
}