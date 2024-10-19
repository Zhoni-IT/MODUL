using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MODULS.MODUL04.LAB
{

    // Интерфейс для стратегии расчета скидки
    public interface IDiscountStrategy
    {
        double CalculateDiscount(double amount);
    }

    // Класс для расчета скидки для обычного клиента
    public class RegularDiscount : IDiscountStrategy
    {
        public double CalculateDiscount(double amount)
        {
            return amount;
        }
    }

    // Класс для расчета скидки для серебряного клиента
    public class SilverDiscount : IDiscountStrategy
    {
        public double CalculateDiscount(double amount)
        {
            return amount * 0.9;
        }
    }

    // Класс для расчета скидки для золотого клиента
    public class GoldDiscount : IDiscountStrategy
    {
        public double CalculateDiscount(double amount)
        {
            return amount * 0.8;
        }
    }

    // Класс для расчета скидки для платинового клиента
    public class PlatinumDiscount : IDiscountStrategy
    {
        public double CalculateDiscount(double amount)
        {
            return amount * 0.7;
        }
    }

    // Класс, который использует стратегии для расчета скидок
    public class DiscountCalculator
    {
        private readonly Dictionary<CustomerType, IDiscountStrategy> _discountStrategies;

        public DiscountCalculator()
        {
            _discountStrategies = new Dictionary<CustomerType, IDiscountStrategy>
        {
            { CustomerType.Regular, new RegularDiscount() },
            { CustomerType.Silver, new SilverDiscount() },
            { CustomerType.Gold, new GoldDiscount() },
            { CustomerType.Platinum, new PlatinumDiscount() }
        };
        }

        public double CalculateDiscount(CustomerType customerType, double amount)
        {
            if (_discountStrategies.TryGetValue(customerType, out var discountStrategy))
            {
                return discountStrategy.CalculateDiscount(amount);
            }
            throw new ArgumentException("Неизвестный тип клиента");
        }
    }

    // Перечисление типов клиентов
    public enum CustomerType
    {
        Regular,
        Silver,
        Gold,
        Platinum
    }
    internal class Program2
    {
        /*public static void Main(string[] args)
        {
            DiscountCalculator discountCalculator = new DiscountCalculator();

            double amount = 1000;

            Console.WriteLine($"Обычный клиент: {discountCalculator.CalculateDiscount(CustomerType.Regular, amount)}");
            Console.WriteLine($"Серебряный клиент: {discountCalculator.CalculateDiscount(CustomerType.Silver, amount)}");
            Console.WriteLine($"Золотой клиент: {discountCalculator.CalculateDiscount(CustomerType.Gold, amount)}");
            Console.WriteLine($"Платиновый клиент: {discountCalculator.CalculateDiscount(CustomerType.Platinum, amount)}");
        }*/
    }
}
