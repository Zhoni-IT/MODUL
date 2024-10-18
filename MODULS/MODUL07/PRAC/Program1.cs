using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MODULS.MODUL07.PRAC
{
    public interface ICostCalculationStrategy
    {
        decimal CalculateCost(double Distance, int Passengers, int ServiceClass, bool HasDiscount);
    }
    public class AirplaneCostCalculationStrategy : ICostCalculationStrategy
    {
        public decimal CalculateCost(double Distance, int Passengers, int ServiceClass, bool HasDiscount)
        {
            decimal baseCostPerKm = 0.15m;
            decimal cost = (decimal)Distance * baseCostPerKm * Passengers;

            // Учитываем класс обслуживания
            if (ServiceClass == 2)
            {
                cost *= 1.5m;
            }

            // Учитываем скидки
            if (HasDiscount)
            {
                cost *= 0.8m; // 20% скидка
            }

            return cost;
        }
    }
    public class TrainCostCalculationStrategy : ICostCalculationStrategy
    {
        public decimal CalculateCost(double Distance, int Passengers, int ServiceClass, bool HasDiscount)
        {
            decimal baseCostPerKm = 0.07m;
            decimal cost = (decimal)Distance * baseCostPerKm * Passengers;

            // Учитываем класс обслуживания
            if (ServiceClass == 2)
            {
                cost *= 1.3m;
            }

            // Учитываем скидки
            if (HasDiscount)
            {
                cost *= 0.9m; // 10% скидка
            }

            return cost;
        }
    }
    public class BusCostCalculationStrategy : ICostCalculationStrategy
    {
        public decimal CalculateCost(double Distance, int Passengers, int ServiceClass, bool HasDiscount)
        {
            decimal baseCostPerKm = 0.05m;
            decimal cost = (decimal)Distance * baseCostPerKm * Passengers;

            // У автобусов нет бизнес-класса, поэтому просто применим скидки
            if (HasDiscount)
            {
                cost *= 0.85m; // 15% скидка
            }

            return cost;
        }
    }
    public class TravelBookingContext
    {
        private ICostCalculationStrategy _costCalculationStrategy;

        public void SetCostCalculationStrategy(ICostCalculationStrategy strategy)
        {
            _costCalculationStrategy = strategy;
        }

        public decimal CalculateTripCost(double Distance, int Passengers, int ServiceClass, bool HasDiscount)
        {
            if (_costCalculationStrategy == null)
            {
                throw new InvalidOperationException("Стратегия расчета стоимости не установлена.");
            }
            return _costCalculationStrategy.CalculateCost(Distance, Passengers, ServiceClass, HasDiscount);
        }
    }




    internal class Program1
    {
        /* static void Main(string[] args)
        {
            TravelBookingContext bookingContext = new TravelBookingContext();

            Console.WriteLine("Введите расстояние (в километрах): ");
            double Distance = double.Parse(Console.ReadLine());

            Console.WriteLine("Введите количество пассажиров: ");
            int Passengers = int.Parse(Console.ReadLine());

            Console.WriteLine("Выберите класс обслуживания: 1 - эконом или 2 - бизнес");
            int ServiceClass = int.Parse(Console.ReadLine());

            Console.WriteLine("Есть ли скидка (дети, пенсионеры)? (y/n): ");
            string discountInput = Console.ReadLine();
            bool HasDiscount = discountInput.ToLower() == "y";

            bool exit = false;

            while (!exit)
            {
                Console.WriteLine("Выберите тип транспорта: 1 - Самолет, 2 - Поезд, 3 - Автобус, 0 - Выйти");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        bookingContext.SetCostCalculationStrategy(new AirplaneCostCalculationStrategy());
                        break;
                    case "2":
                        bookingContext.SetCostCalculationStrategy(new TrainCostCalculationStrategy());
                        break;
                    case "3":
                        bookingContext.SetCostCalculationStrategy(new BusCostCalculationStrategy());
                        break;
                    case "0":
                        exit = true;
                        continue;
                    default:
                        Console.WriteLine("Неверный выбор. Попробуйте снова.");
                        continue;
                }

                decimal cost = bookingContext.CalculateTripCost(Distance, Passengers, ServiceClass, HasDiscount);
                Console.WriteLine($"Стоимость поездки: {cost:C}");
            }
        }*/ 
    }
}
