using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MODULS.MODUL04.DOM
{
    public class Order
    {
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }

        public Order(string productName, int quantity, double price)
        {
            ProductName = productName;
            Quantity = quantity;
            Price = price;
        }
    }

    public class PriceCalculator
    {
        public double CalculateTotalPrice(Order order)
        {
            return order.Quantity * order.Price * 0.9;
        }
    }

    public class PaymentProcessor
    {
        public void ProcessPayment(Order order, string paymentDetails)
        {
            Console.WriteLine($"Платеж на сумму {order.Price * order.Quantity} обработан с использованием: {paymentDetails}");
        }
    }

    public class EmailService
    {
        public void SendConfirmationEmail(string email, Order order)
        {
            Console.WriteLine($"Подтверждающее письмо о заказе {order.ProductName} отправлено на: {email}");
        }
    }

    internal class Program
    {
        /* public static void Main(string[] args)
        {
            // Пример использования
            Order order = new Order("Ноутбук", 1, 1000.00);

            PriceCalculator priceCalculator = new PriceCalculator();
            PaymentProcessor paymentProcessor = new PaymentProcessor();
            EmailService emailService = new EmailService();

            // Рассчитываем итоговую цену
            double totalPrice = priceCalculator.CalculateTotalPrice(order);
            Console.WriteLine($"Общая стоимость: {totalPrice}");

            // Обрабатываем платеж
            paymentProcessor.ProcessPayment(order, "Кредитная карта");

            // Отправляем подтверждение
            emailService.SendConfirmationEmail("ernar@gmail.com", order);
        }*/
    }
}
