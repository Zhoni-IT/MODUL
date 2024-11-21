using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MODULS.MODUL11.LAB
{
    public interface IUserService
    {
        User Register(string username, string password);
        User Login(string username, string password);
    }

    public interface IProductService
    {
        List<Product> GetProducts();
        Product AddProduct(Product product);
    }

    public interface IOrderService
    {
        Order CreateOrder(int userId, List<int> productIds);
        Order GetOrderStatus(int orderId);
    }

    public interface IPaymentService
    {
        bool ProcessPayment(int orderId, decimal amount);
    }

    public interface INotificationService
    {
        void SendNotification(int userId, string message);
    }
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
    }

    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
    }

    public class Order
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public List<Product> Products { get; set; }
        public string Status { get; set; }
    }

    public class UserService : IUserService
    {
        private List<User> users = new List<User>();

        public User Register(string username, string password)
        {
            var user = new User { Id = users.Count + 1, Name = username, Email = $"{username}@example.com" };
            users.Add(user);
            return user;
        }

        public User Login(string username, string password)
        {
            return users.FirstOrDefault(u => u.Name == username);
        }
    }

    public class ProductService : IProductService
    {
        private List<Product> products = new List<Product>();

        public List<Product> GetProducts()
        {
            return products;
        }

        public Product AddProduct(Product product)
        {
            products.Add(product);
            return product;
        }
    }

    public class OrderService : IOrderService
    {
        private readonly IProductService _productService;
        private readonly IPaymentService _paymentService;
        private readonly INotificationService _notificationService;

        public OrderService(IProductService productService, IPaymentService paymentService, INotificationService notificationService)
        {
            _productService = productService;
            _paymentService = paymentService;
            _notificationService = notificationService;
        }

        public Order CreateOrder(int userId, List<int> productIds)
        {
            var products = _productService.GetProducts().Where(p => productIds.Contains(p.Id)).ToList();
            if (!products.Any())
            {
                throw new Exception("Продукты не найдены.");
            }

            var order = new Order { UserId = userId, Products = products, Status = "Created" };
            decimal totalAmount = products.Sum(p => p.Price);

            if (_paymentService.ProcessPayment(order.Id, totalAmount))
            {
                order.Status = "Paid";
                _notificationService.SendNotification(userId, "Ваш заказ успешно оплачен.");
            }
            else
            {
                order.Status = "Payment Failed";
                _notificationService.SendNotification(userId, "Платеж не прошел. Попробуйте снова.");
            }

            return order;
        }

        public Order GetOrderStatus(int orderId)
        {
            return new Order { Id = orderId, Status = "In Progress" };
        }
    }

    public class PaymentService : IPaymentService
    {
        public bool ProcessPayment(int orderId, decimal amount)
        {
            Console.WriteLine($"Обработка платежа для заказа {orderId} на сумму {amount:C}");
            return true;
        }
    }

    public class NotificationService : INotificationService
    {
        public void SendNotification(int userId, string message)
        {
            Console.WriteLine($"Отправлено уведомление пользователю {userId}: {message}");
        }
    }

    internal class Program2
    {
        /*static void Main(string[] args)
        {
            IUserService userService = new UserService();
            IProductService productService = new ProductService();
            IPaymentService paymentService = new PaymentService();
            INotificationService notificationService = new NotificationService();
            IOrderService orderService = new OrderService(productService, paymentService, notificationService);

            var user = userService.Register("Maks", "password123");

            productService.AddProduct(new Product { Id = 1, Name = "Laptop", Price = 1200.50m });
            productService.AddProduct(new Product { Id = 2, Name = "Smartphone", Price = 800.75m });

            var order = orderService.CreateOrder(user.Id, new List<int> { 1, 2 });

            Console.WriteLine($"Заказ #{order.Id} для пользователя {user.Name} статус: {order.Status}");

            var status = orderService.GetOrderStatus(order.Id);
            Console.WriteLine($"Статус заказа: {status.Status}");
        }*/
    }

}
