using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MODULS.MODUL07.DOM
{
    public interface IPaymentStrategy
    {
        void Pay(decimal amount);
    }

    public class CreditCardPayment : IPaymentStrategy
    {
        public void Pay(decimal amount)
        {
            Console.WriteLine($"Оплата банковской картой на сумму {amount} рублей.");
        }
    }

    public class PayPalPayment : IPaymentStrategy
    {
        public void Pay(decimal amount)
        {
            Console.WriteLine($"Оплата через PayPal на сумму {amount} рублей.");
        }
    }

    public class CryptoPayment : IPaymentStrategy
    {
        public void Pay(decimal amount)
        {
            Console.WriteLine($"Оплата с помощью криптовалюты на сумму {amount} рублей.");
        }
    }

    public class PaymentContext
    {
        private IPaymentStrategy _paymentStrategy;

        public void SetPaymentStrategy(IPaymentStrategy paymentStrategy)
        {
            _paymentStrategy = paymentStrategy;
        }

        public void Pay(decimal amount)
        {
            if (_paymentStrategy == null)
            {
                Console.WriteLine("Не выбрана стратегия оплаты.");
            }
            else
            {
                _paymentStrategy.Pay(amount);
            }
        }
    }

    internal class Program1
    {
        /* static void Main(string[] args)
        {
            PaymentContext context = new PaymentContext();
            bool exit = false;

            while (!exit)
            {
                Console.WriteLine("Выберите способ оплаты: 1 - Банковская карта, 2 - PayPal, 3 - Криптовалюта, 0 - Выйти");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        context.SetPaymentStrategy(new CreditCardPayment());
                        Console.WriteLine("Вы выбрали оплату банковской картой.");
                        break;
                    case "2":
                        context.SetPaymentStrategy(new PayPalPayment());
                        Console.WriteLine("Вы выбрали оплату через PayPal.");
                        break;
                    case "3":
                        context.SetPaymentStrategy(new CryptoPayment());
                        Console.WriteLine("Вы выбрали оплату криптовалютой.");
                        break;
                    case "0":
                        exit = true;
                        Console.WriteLine("Выход из программы.");
                        continue;
                    default:
                        Console.WriteLine("Неверный выбор. Пожалуйста, выберите снова.");
                        continue;
                }

                Console.WriteLine("Введите сумму для оплаты:");
                decimal amount;
                if (decimal.TryParse(Console.ReadLine(), out amount))
                {
                    context.Pay(amount);
                }
                else
                {
                    Console.WriteLine("Неверная сумма.");
                }

                Console.WriteLine("Хотите изменить способ оплаты? (y/n)");
                string changePayment = Console.ReadLine();
                if (changePayment.ToLower() != "y")
                {
                    exit = true;
                }
            }
        }*/ 
    }
}
