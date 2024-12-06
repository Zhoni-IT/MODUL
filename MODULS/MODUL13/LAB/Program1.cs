using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MODULS.MODUL13.LAB
{
    internal class Program1
    {
        /*public static void Main(string[] args)
        {
            // Клиент создает заказ
            var order = new Order(new List<string> { "Item1", "Item2" });
            Console.WriteLine("Клиент создал заказ.");

            // Проверка наличия товаров на складе
            var warehouse = new Warehouse();
            if (warehouse.CheckAvailability(order))
            {
                Console.WriteLine("Все товары в наличии. Заказ подтвержден.");
            }
            else
            {
                Console.WriteLine("Некоторые товары отсутствуют. Клиенту отправлено уведомление об изменении заказа.");
                return;
            }

            // Выбор способа оплаты
            Console.WriteLine("Выберите способ оплаты: 1 - Онлайн, 2 - При доставке");
            var paymentMethod = int.Parse(Console.ReadLine() ?? "0");

            if (paymentMethod == 1)
            {
                var paymentGateway = new PaymentGateway();
                if (paymentGateway.ProcessPayment(order))
                {
                    Console.WriteLine("Оплата прошла успешно. Переход к сборке заказа.");
                }
                else
                {
                    Console.WriteLine("Оплата отклонена. Клиенту отправлено уведомление о повторной оплате.");
                    return;
                }
            }
            else
            {
                Console.WriteLine("Оплата будет произведена при доставке. Переход к сборке заказа.");
            }

            // Сборка и доставка заказа
            warehouse.AssembleOrder(order);
            Console.WriteLine("Сборка заказа завершена.");

            Console.WriteLine("Выберите способ доставки: 1 - Курьер, 2 - Самовывоз");
            var deliveryMethod = int.Parse(Console.ReadLine() ?? "0");

            if (deliveryMethod == 1)
            {
                var deliveryService = new DeliveryService();
                deliveryService.DeliverOrder(order);
                Console.WriteLine("Заказ доставлен клиенту.");
            }
            else
            {
                Console.WriteLine("Клиенту отправлено уведомление о готовности заказа к самовывозу.");
            }

            // Завершение заказа
            Console.WriteLine("Клиент подтвердил получение. Заказ завершен. Электронный чек отправлен клиенту.");
        }*/
    }

    public class Order
    {
        public List<string> Items { get; set; }

        public Order(List<string> items)
        {
            Items = items;
        }
    }

    public class Warehouse
    {
        public bool CheckAvailability(Order order)
        {
            // Проверка наличия товаров на складе (заглушка)
            return true;
        }

        public void AssembleOrder(Order order)
        {
            // Логика сборки заказа (заглушка)
            Console.WriteLine("Заказ собран.");
        }
    }

    public class PaymentGateway
    {
        public bool ProcessPayment(Order order)
        {
            // Логика обработки онлайн-платежа (заглушка)
            return true;
        }
    }

    public class DeliveryService
    {
        public void DeliverOrder(Order order)
        {
            // Логика доставки заказа (заглушка)
            Console.WriteLine("Заказ доставлен курьером.");
        }
    }
}
