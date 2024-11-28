using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MODULS.MODUL12.LAB
{
    // Интерфейс состояния заявки
    public interface IBookingState
    {
        void Handle(BookingRequest bookingRequest);
    }

    // Реализация состояния "Создана"
    public class CreatedState : IBookingState
    {
        public void Handle(BookingRequest bookingRequest)
        {
            Console.WriteLine("Заявка в состоянии 'Создана'. Переход в 'Ожидает оплаты'.");
            bookingRequest.State = new WaitingForPaymentState();
        }
    }

    // Реализация состояния "Ожидает оплаты"
    public class WaitingForPaymentState : IBookingState
    {
        public void Handle(BookingRequest bookingRequest)
        {
            Console.WriteLine("Заявка в состоянии 'Ожидает оплаты'. Клиент оплатил?");

            // Пример проверки условий для перехода в следующее состояние
            bool paymentReceived = true; // Платеж подтвержден (можно заменить на реальные проверки)
            if (paymentReceived)
            {
                Console.WriteLine("Оплата получена. Переход в 'Оплачена'.");
                bookingRequest.State = new PaidState();
            }
            else
            {
                Console.WriteLine("Оплата не получена в срок. Переход в 'Отменена'.");
                bookingRequest.State = new CancelledState();
            }
        }
    }

    // Реализация состояния "Оплачена"
    public class PaidState : IBookingState
    {
        public void Handle(BookingRequest bookingRequest)
        {
            Console.WriteLine("Заявка в состоянии 'Оплачена'. Переход в 'Подтверждена'.");
            bookingRequest.State = new ConfirmedState();
        }
    }

    // Реализация состояния "Подтверждена"
    public class ConfirmedState : IBookingState
    {
        public void Handle(BookingRequest bookingRequest)
        {
            Console.WriteLine("Заявка в состоянии 'Подтверждена'. Операция завершена.");
            // Переход к финальному состоянию не требуется, так как это уже подтвержденная заявка.
        }
    }

    // Реализация состояния "Отменена"
    public class CancelledState : IBookingState
    {
        public void Handle(BookingRequest bookingRequest)
        {
            Console.WriteLine("Заявка в состоянии 'Отменена'. Операция завершена.");
            // Переход к финальному состоянию не требуется, так как это конечное состояние.
        }
    }

    // Класс заявки
    public class BookingRequest
    {
        public IBookingState State { get; set; }

        public BookingRequest()
        {
            // Начальное состояние заявки – "Создана"
            State = new CreatedState();
        }

        public void Process()
        {
            State.Handle(this);
        }
    }
    internal class Program2
    {
        /*public static void Main(string[] args)
        {
            BookingRequest bookingRequest = new BookingRequest();

            // Симуляция обработки заявки по этапам
            bookingRequest.Process(); // Переход из 'Создана' в 'Ожидает оплаты'
            bookingRequest.Process(); // Переход из 'Ожидает оплаты' в 'Оплачена'
            bookingRequest.Process(); // Переход из 'Оплачена' в 'Подтверждена'
        }*/
    }
}
