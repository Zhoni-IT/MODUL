using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MODULS.MODUL13.PRAC
{
    // Класс для представления товара
    public class Product
    {
        public string Name { get; set; }
        public int Quantity { get; set; }

        public Product(string name, int quantity)
        {
            Name = name;
            Quantity = quantity;
        }
    }

    // Класс пользователя
    public class User
    {
        public string Username { get; set; }

        public User(string username)
        {
            Username = username;
        }

        public void AddToCart(Cart cart, Product product)
        {
            cart.AddProduct(product);
            Console.WriteLine($"{Username} добавил {product.Name} в корзину.");
        }

        public void ConfirmOrder(Order order)
        {
            Console.WriteLine($"{Username} подтвердил заказ.");
            order.ProcessOrder();
        }
    }

    // Класс для корзины
    public class Cart
    {
        public List<Product> Products { get; set; } = new List<Product>();

        public void AddProduct(Product product)
        {
            Products.Add(product);
        }
    }

    // Класс для представления заказа
    public class Order
    {
        private readonly Cart _cart;

        public Order(Cart cart)
        {
            _cart = cart;
        }

        public void ProcessOrder()
        {
            Console.WriteLine("Система проверяет доступность товаров на складе...");
            if (CheckInventory())
            {
                Console.WriteLine("Все товары доступны. Заказ подтвержден.");
                NotifyWarehouse();
            }
            else
            {
                Console.WriteLine("Некоторые товары недоступны. Предложите изменить корзину.");
            }
        }

        private bool CheckInventory()
        {
            // Проверка доступности товаров (заглушка)
            return true; // Предположим, что все товары доступны
        }

        private void NotifyWarehouse()
        {
            Console.WriteLine("Уведомление склада о необходимости сборки заказа.");
        }

        public void ProcessPayment(bool isOnline)
        {
            if (isOnline)
            {
                Console.WriteLine("Система обрабатывает платеж через платежный шлюз...");
                if (ProcessOnlinePayment())
                {
                    Console.WriteLine("Оплата успешно завершена.");
                }
                else
                {
                    Console.WriteLine("Оплата не удалась. Повторите попытку.");
                }
            }
            else
            {
                Console.WriteLine("Оплата будет произведена при доставке.");
            }
        }

        private bool ProcessOnlinePayment()
        {
            // Обработка платежа через платежный шлюз (заглушка)
            return true; // Предположим, что платеж успешен
        }
    }

    internal class Program2
    {
        /*public static void Main()
        {
            User user = new User("Макс");
            Cart cart = new Cart();
            Product product1 = new Product("Ноутбук", 1);

            user.AddToCart(cart, product1);

            Order order = new Order(cart);
            user.ConfirmOrder(order);

            order.ProcessPayment(true);
        }*/
    }
}
