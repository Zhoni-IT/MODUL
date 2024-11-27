using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MODULS.MODUL12.PRAC
{
    public class Product
    {
        public string Name { get; set; }
        public decimal Price { get; set; }

        public Product(string name, decimal price)
        {
            Name = name;
            Price = price;
        }
    }

    public class Cart
    {
        public List<Product> Products { get; private set; } = new List<Product>();

        public void AddProduct(Product product)
        {
            Products.Add(product);
            Console.WriteLine($"Товар {product.Name} добавлен в корзину.");
        }

        public decimal GetTotalPrice()
        {
            decimal total = 0;
            foreach (var product in Products)
            {
                total += product.Price;
            }
            return total;
        }
    }

    public class Order
    {
        public Cart Cart { get; private set; }
        public string CustomerName { get; set; }
        public string ShippingAddress { get; set; }

        public Order(Cart cart, string customerName, string shippingAddress)
        {
            Cart = cart;
            CustomerName = customerName;
            ShippingAddress = shippingAddress;
        }
    }

    public class Payment
    {
        public decimal Amount { get; set; }
        public bool IsPaid { get; private set; }

        public Payment(decimal amount)
        {
            Amount = amount;
        }

        public void Pay()
        {
            Console.WriteLine($"Процесс оплаты на сумму {Amount}...");
            IsPaid = true;
            Console.WriteLine("Оплата прошла успешно.");
        }
    }

    public class OrderProcessor
    {
        public void ProcessOrder(Order order)
        {
            Console.WriteLine($"Обработка заказа для {order.CustomerName}...");
            Console.WriteLine("Заказ обработан на складе.");
        }

        public void ShipOrder(Order order)
        {
            Console.WriteLine("Заказ отправлен на доставку.");
        }
    }
    internal class Program3
    {
        /*static void Main(string[] args)
        {
            var product1 = new Product("Ноутбук", 50000);
            var product2 = new Product("Телефон", 30000);

            var cart = new Cart();
            cart.AddProduct(product1);
            cart.AddProduct(product2);

            Console.WriteLine("Оформление заказа...");
            var order = new Order(cart, "Макс Бак", "Алматы, ул. Абая, д. 10");

            var payment = new Payment(cart.GetTotalPrice());
            payment.Pay();

            if (payment.IsPaid)
            {
                var orderProcessor = new OrderProcessor();
                orderProcessor.ProcessOrder(order);

                orderProcessor.ShipOrder(order);
            }
            else
            {
                Console.WriteLine("Оплата не прошла. Заказ отменен.");
            }

            Console.WriteLine("Процесс завершен.");
        }*/
    }
}
