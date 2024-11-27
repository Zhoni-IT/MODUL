using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MODULS.MODUL12.PRAC
{
    public enum OrderState
    {
        Idle,
        CarSelected,
        OrderConfirmed,
        CarArrived,
        InTrip,
        TripCompleted,
        TripCancelled
    }

    public class CarOrderSystem
    {
        private OrderState _currentState;

        public CarOrderSystem()
        {
            _currentState = OrderState.Idle;
            Console.WriteLine("Система запущена. Ожидание действия пользователя (Idle).");
        }

        public void TransitionTo(OrderState newState)
        {
            Console.WriteLine($"Переход из состояния {_currentState} в {newState}.");
            _currentState = newState;
        }

        public void SelectCar()
        {
            if (_currentState == OrderState.Idle)
            {
                TransitionTo(OrderState.CarSelected);
                Console.WriteLine("Автомобиль выбран. Ожидание подтверждения.");
            }
            else
            {
                Console.WriteLine("Невозможно выбрать автомобиль в текущем состоянии.");
            }
        }

        public void ConfirmOrder()
        {
            if (_currentState == OrderState.CarSelected)
            {
                TransitionTo(OrderState.OrderConfirmed);
                Console.WriteLine("Заказ подтвержден. Автомобиль в пути.");
            }
            else
            {
                Console.WriteLine("Невозможно подтвердить заказ в текущем состоянии.");
            }
        }

        public void CarArrives()
        {
            if (_currentState == OrderState.OrderConfirmed)
            {
                TransitionTo(OrderState.CarArrived);
                Console.WriteLine("Автомобиль прибыл. Ожидание посадки.");
            }
            else
            {
                Console.WriteLine("Невозможно выполнить действие в текущем состоянии.");
            }
        }

        public void StartTrip()
        {
            if (_currentState == OrderState.CarArrived)
            {
                TransitionTo(OrderState.InTrip);
                Console.WriteLine("Поездка началась.");
            }
            else
            {
                Console.WriteLine("Невозможно начать поездку в текущем состоянии.");
            }
        }

        public void CompleteTrip()
        {
            if (_currentState == OrderState.InTrip)
            {
                TransitionTo(OrderState.TripCompleted);
                Console.WriteLine("Поездка завершена. Ожидание оплаты.");
            }
            else
            {
                Console.WriteLine("Невозможно завершить поездку в текущем состоянии.");
            }
        }

        public void CancelOrder()
        {
            if (_currentState != OrderState.InTrip && _currentState != OrderState.TripCompleted)
            {
                TransitionTo(OrderState.TripCancelled);
                Console.WriteLine("Заказ отменен.");
            }
            else
            {
                Console.WriteLine("Невозможно отменить заказ на данном этапе.");
            }
        }

        public void ResetToIdle()
        {
            TransitionTo(OrderState.Idle);
            Console.WriteLine("Система возвращена в начальное состояние.");
        }
    }
    internal class Program1
    {
        /*static void Main(string[] args)
        {
            var system = new CarOrderSystem();

            system.SelectCar();
            system.ConfirmOrder();
            system.CarArrives();
            system.StartTrip();
            system.CompleteTrip();
            system.ResetToIdle();

            Console.WriteLine("----");

            system.SelectCar();
            system.CancelOrder();
        }*/
    }
}
