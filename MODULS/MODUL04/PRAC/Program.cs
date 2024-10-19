using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MODULS.MODUL04.PRAC
{
    public class Item
    {
        public string Name { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }

        public Item(string name, int quantity, double price)
        {
            Name = name;
            Quantity = quantity;
            Price = price;
        }
    }

    public class Order
    {
        public List<Item> Items { get; private set; } = new List<Item>();
        public IPayment PaymentMethod { get; set; }
        public IDelivery DeliveryMethod { get; set; }

        public void AddItem(Item item)
        {
            Items.Add(item);
        }

        public double CalculateTotal(DiscountCalculator discountCalculator)
        {
            double total = 0;
            foreach (var item in Items)
            {
                total += item.Price * item.Quantity;
            }
            return discountCalculator.ApplyDiscount(total);
        }
    }
    public interface IPayment
    {
        void ProcessPayment(double amount);
    }

    public class CreditCardPayment : IPayment
    {
        public void ProcessPayment(double amount)
        {
            Console.WriteLine($"Оплата кредитной картой на сумму: {amount}");
        }
    }

    public class PayPalPayment : IPayment
    {
        public void ProcessPayment(double amount)
        {
            Console.WriteLine($"Оплата через PayPal на сумму: {amount}");
        }
    }

    public class BankTransferPayment : IPayment
    {
        public void ProcessPayment(double amount)
        {
            Console.WriteLine($"Банковский перевод на сумму: {amount}");
        }
    }
    public interface IDelivery
    {
        void DeliverOrder(Order order);
    }

    public class CourierDelivery : IDelivery
    {
        public void DeliverOrder(Order order)
        {
            Console.WriteLine("Заказ доставлен курьером.");
        }
    }

    public class PostDelivery : IDelivery
    {
        public void DeliverOrder(Order order)
        {
            Console.WriteLine("Заказ доставлен почтой.");
        }
    }

    public class PickUpPointDelivery : IDelivery
    {
        public void DeliverOrder(Order order)
        {
            Console.WriteLine("Заказ готов к самовывозу.");
        }
    }
    public interface INotification
    {
        void SendNotification(string message);
    }

    public class EmailNotification : INotification
    {
        public void SendNotification(string message)
        {
            Console.WriteLine($"Отправка Email: {message}");
        }
    }

    public class SmsNotification : INotification
    {
        public void SendNotification(string message)
        {
            Console.WriteLine($"Отправка SMS: {message}");
        }
    }
    public class DiscountCalculator
    {
        public double ApplyDiscount(double amount)
        {
            return amount;
        }
    }

    internal class Program
    {
        /* public static void Main(string[] args)
        {
            // Создание списка товаров
            List<Item> availableItems = new List<Item>
        {
            new Item("Товар 1", 0, 100),
            new Item("Товар 2", 0, 150),
            new Item("Товар 3", 0, 200)
        };

            Console.WriteLine("Доступные товары:");
            for (int i = 0; i < availableItems.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {availableItems[i].Name} - Цена: {availableItems[i].Price} (Введите количество)");
            }

            Order order = new Order();
            while (true)
            {
                Console.Write("Выберите товар (номер) или 0 для завершения выбора: ");
                int itemNumber = int.Parse(Console.ReadLine());

                if (itemNumber == 0)
                {
                    break;
                }

                if (itemNumber < 1 || itemNumber > availableItems.Count)
                {
                    Console.WriteLine("Некорректный номер товара. Попробуйте снова.");
                    continue;
                }

                Console.Write("Введите количество: ");
                int quantity = int.Parse(Console.ReadLine());

                var selectedItem = availableItems[itemNumber - 1];
                order.AddItem(new Item(selectedItem.Name, quantity, selectedItem.Price));
            }

            Console.WriteLine("Выберите способ оплаты:");
            Console.WriteLine("1. Кредитная карта");
            Console.WriteLine("2. PayPal");
            Console.WriteLine("3. Банковский перевод");
            Console.Write("Ваш выбор: ");
            int paymentChoice = int.Parse(Console.ReadLine());

            switch (paymentChoice) {
                case 1:
                    order.PaymentMethod = new CreditCardPayment();
                    break;
                case 2:
                    order.PaymentMethod = new PayPalPayment();
                    break;
                case 3:
                    order.PaymentMethod = new BankTransferPayment();
                    break;
                default: throw new ArgumentException("Некорректный выбор способа оплаты.");
            }

            Console.WriteLine("Выберите способ доставки:");
            Console.WriteLine("1. Курьерская доставка");
            Console.WriteLine("2. Почтовая доставка");
            Console.WriteLine("3. Самовывоз");
            Console.Write("Ваш выбор: ");
            int deliveryChoice = int.Parse(Console.ReadLine());

            switch (deliveryChoice)
            {
                case 1:
                    order.DeliveryMethod = new CourierDelivery(); 
                    break;
                case 2:
                    order.DeliveryMethod = new PostDelivery();
                    break;
                case 3:
                    order.DeliveryMethod = new PickUpPointDelivery();
                    break;
                default: throw new ArgumentException("Некорректный выбор способа доставки.");

            }

            DiscountCalculator discountCalculator = new DiscountCalculator();
            double total = order.CalculateTotal(discountCalculator);
            Console.WriteLine($"Общая стоимость заказа: {total}");

            order.PaymentMethod.ProcessPayment(total);

            order.DeliveryMethod.DeliverOrder(order);

            INotification notification = new EmailNotification();
            notification.SendNotification("Ваш заказ успешно оформлен!");
        }*/
    }
}
