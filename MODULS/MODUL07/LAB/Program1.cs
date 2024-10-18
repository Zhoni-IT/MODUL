using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MODULS.MODUL07.LAB
{
    public interface IShippingStrategy
    {
        decimal CalculateShippingCost(decimal weight, decimal distance);
    }
    public class StandardShippingStrategy : IShippingStrategy
    {
        public decimal CalculateShippingCost(decimal weight, decimal distance)
        {
            return weight * 0.5m + distance * 0.1m;
        }
    }
    public class ExpressShippingStrategy : IShippingStrategy
    {
        public decimal CalculateShippingCost(decimal weight, decimal distance)
        {
            return (weight * 0.75m + distance * 0.2m) + 10;
        }
    }
    public class InternationalShippingStrategy : IShippingStrategy
    {
        public decimal CalculateShippingCost(decimal weight, decimal distance)
        {
            return weight * 1.0m + distance * 0.5m + 15;
        }
    }

    public class DeliveryContext
    {
        private IShippingStrategy _shippingStrategy;

        public void SetShippingStrategy(IShippingStrategy strategy)
        {
            _shippingStrategy = strategy;
        }

        public DeliveryContext(IShippingStrategy strategy)
        {
            _shippingStrategy = strategy;
        }

        public decimal CalculateCost(decimal weight, decimal distance)
        {
            if (_shippingStrategy == null)
            {
                throw new InvalidOperationException("Стратегия доставки не установлена.");
            }
            return _shippingStrategy.CalculateShippingCost(weight, distance);
        }
    }


    internal class Program1
    {
        public static void IsTrue(DeliveryContext deliveryContext)
        {
            string choice = "";
            bool isexit = true;
            do
            {
                Console.WriteLine("Выберите тип доставки: 1 - Стандартная, 2 - Экспресс, 3 - Международная");
                choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        deliveryContext.SetShippingStrategy(new StandardShippingStrategy());
                        isexit = false;
                        break;
                    case "2":
                        deliveryContext.SetShippingStrategy(new ExpressShippingStrategy());
                        isexit = false;
                        break;
                    case "3":
                        deliveryContext.SetShippingStrategy(new InternationalShippingStrategy());
                        isexit = false;
                        break;
                    case "":
                        deliveryContext.SetShippingStrategy(new StandardShippingStrategy());
                        isexit = false;
                        break;
                }
            } while (isexit);

        }
        /* static void Main(string[] args)
        {
            DeliveryContext deliveryContext = new DeliveryContext(new StandardShippingStrategy());

            IsTrue(deliveryContext);

            Console.WriteLine("Введите вес посылки (кг):");
            decimal weight = Convert.ToDecimal(Console.ReadLine());

            Console.WriteLine("Введите расстояние доставки (км):");
            decimal distance = Convert.ToDecimal(Console.ReadLine());

            decimal cost = deliveryContext.CalculateCost(weight, distance);
            Console.WriteLine($"Стоимость доставки: {cost:C}");
            Console.WriteLine("Продолжим?: 1 - Поменять доставку, 2 - Exit");
            string choice1 = Console.ReadLine();
            if (choice1 == "1")
            {
                IsTrue(deliveryContext);
            }
            else
            {
                Environment.Exit(0);
            }

            cost = deliveryContext.CalculateCost(weight, distance);
            Console.WriteLine($"Стоимость доставки: {cost:C}");
        }*/
    }
}
