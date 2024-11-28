using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MODULS.MODUL12.LAB
{
    // Определение возможных состояний системы
    public enum BookingState
    {
        Idle,               // Начальное состояние, ожидание действий пользователя
        RoomSelected,       // Пользователь выбрал номер
        BookingConfirmed,   // Бронирование подтверждено, но не оплачено
        Paid,               // Бронирование оплачено, номер закреплен за пользователем
        BookingCancelled    // Бронирование отменено
    }

    // Класс для управления процессом бронирования
    public class BookingManager
    {
        public BookingState CurrentState { get; private set; } = BookingState.Idle;

        // Метод для выбора номера
        public void SelectRoom()
        {
            if (CurrentState == BookingState.Idle)
            {
                CurrentState = BookingState.RoomSelected;
                Console.WriteLine("Номер выбран. Перейдите к подтверждению бронирования.");
            }
            else
            {
                Console.WriteLine("Невозможно выбрать номер в текущем состоянии.");
            }
        }

        // Метод для подтверждения бронирования
        public void ConfirmBooking()
        {
            if (CurrentState == BookingState.RoomSelected)
            {
                CurrentState = BookingState.BookingConfirmed;
                Console.WriteLine("Бронирование подтверждено. Ожидание оплаты.");
            }
            else
            {
                Console.WriteLine("Невозможно подтвердить бронирование в текущем состоянии.");
            }
        }

        // Метод для оплаты бронирования
        public void PayBooking()
        {
            if (CurrentState == BookingState.BookingConfirmed)
            {
                CurrentState = BookingState.Paid;
                Console.WriteLine("Бронирование оплачено. Номер закреплен за пользователем.");
            }
            else if (CurrentState == BookingState.Paid)
            {
                Console.WriteLine("Бронирование уже оплачено.");
            }
            else
            {
                Console.WriteLine("Невозможно провести оплату в текущем состоянии.");
            }
        }

        // Метод для отмены бронирования
        public void CancelBooking()
        {
            if (CurrentState != BookingState.Paid)
            {
                CurrentState = BookingState.BookingCancelled;
                Console.WriteLine("Бронирование отменено.");
            }
            else
            {
                Console.WriteLine("Невозможно отменить бронирование после оплаты.");
            }
        }
    }
    internal class Program1
    {
        /*static void Main(string[] args)
        {
            BookingManager bookingManager = new BookingManager();

            // Демонстрация работы системы
            bookingManager.SelectRoom();        // Выбор номера
            bookingManager.ConfirmBooking();    // Подтверждение бронирования
            bookingManager.PayBooking();        // Оплата
            bookingManager.CancelBooking();     // Попытка отмены после оплаты
        }*/
    }
}
