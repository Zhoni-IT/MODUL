using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MODULS.MODUL03.LAB
{
    // Использование методов для устранения дублирования кода
    public class OrderService
    {
        public void CreateOrder(string productName, int quantity, double price)
        {
            double totalPrice = CalculateTotalPrice(quantity, price);
            PrintOrderMessage(productName, totalPrice, "created");
        }

        public void UpdateOrder(string productName, int quantity, double price)
        {
            double totalPrice = CalculateTotalPrice(quantity, price);
            PrintOrderMessage(productName, totalPrice, "updated");
        }

        private double CalculateTotalPrice(int quantity, double price)
        {
            return quantity * price;
        }

        private void PrintOrderMessage(string productName, double totalPrice, string action)
        {
            Console.WriteLine($"Order for {productName} {action}. Total: {totalPrice}");
        }
    }

    // Использование общих базовых классов
    public class Vehicle
    {
        public void Start()
        {
            Console.WriteLine($"{GetType().Name} is starting");
        }

        public void Stop()
        {
            Console.WriteLine($"{GetType().Name} is stopping");
        }
    }

    public class Car : Vehicle
    {
        // Дополнительная логика для Car может быть добавлена здесь, если нужно
    }

    public class Truck : Vehicle
    {
        // Дополнительная логика для Truck может быть добавлена здесь, если нужно
    }

    internal class ProgramDRY1
    {
    }
}
