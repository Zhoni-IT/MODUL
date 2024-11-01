using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MODULS.MODUL09.PRAC
{
    public interface IInternalDeliveryService
    {
        void DeliverOrder(string orderId);
        string GetDeliveryStatus(string orderId);
        decimal CalculateDeliveryCost();
    }

    public class InternalDeliveryService : IInternalDeliveryService
    {
        public void DeliverOrder(string orderId)
        {
            Console.WriteLine($"Внутренняя служба: Доставка заказа {orderId} начата.");
        }

        public string GetDeliveryStatus(string orderId)
        {
            return $"Внутренняя служба: Статус заказа {orderId} - в пути.";
        }

        public decimal CalculateDeliveryCost()
        {
            return 5.00m;
        }
    }

    public class ExternalLogisticsServiceA
    {
        public void ShipItem(int itemId)
        {
            Console.WriteLine($"ExternalLogisticsServiceA: Отправка товара {itemId}.");
        }

        public string TrackShipment(int shipmentId)
        {
            return $"ExternalLogisticsServiceA: Статус отправления {shipmentId} - в пути.";
        }

        public decimal CalculateCost()
        {
            return 10.00m;
        }
    }

    public class ExternalLogisticsServiceB
    {
        public void SendPackage(string packageInfo)
        {
            Console.WriteLine($"ExternalLogisticsServiceB: Отправка пакета с информацией: {packageInfo}.");
        }

        public string CheckPackageStatus(string trackingCode)
        {
            return $"ExternalLogisticsServiceB: Статус пакета {trackingCode} - доставлен.";
        }

        public decimal GetShippingCost()
        {
            return 8.50m;
        }
    }

    public class ExternalLogisticsServiceC
    {
        public void InitiateShipment(double packageWeight)
        {
            Console.WriteLine($"ExternalLogisticsServiceC: Инициирование отправки с весом {packageWeight} кг.");
        }

        public string GetShipmentStatus()
        {
            return "ExternalLogisticsServiceC: Статус отправки - в пути.";
        }

        public decimal ComputeShippingCost()
        {
            return 15.00m;
        }
    }

    public class LogisticsAdapterA : IInternalDeliveryService
    {
        private readonly ExternalLogisticsServiceA _externalServiceA;

        public LogisticsAdapterA(ExternalLogisticsServiceA externalServiceA)
        {
            _externalServiceA = externalServiceA;
        }

        public void DeliverOrder(string orderId)
        {
            int itemId = int.Parse(orderId);
            _externalServiceA.ShipItem(itemId);
        }

        public string GetDeliveryStatus(string orderId)
        {
            int shipmentId = int.Parse(orderId);
            return _externalServiceA.TrackShipment(shipmentId);
        }

        public decimal CalculateDeliveryCost()
        {
            return _externalServiceA.CalculateCost();
        }
    }

    public class LogisticsAdapterB : IInternalDeliveryService
    {
        private readonly ExternalLogisticsServiceB _externalServiceB;

        public LogisticsAdapterB(ExternalLogisticsServiceB externalServiceB)
        {
            _externalServiceB = externalServiceB;
        }

        public void DeliverOrder(string orderId)
        {
            _externalServiceB.SendPackage(orderId);
        }

        public string GetDeliveryStatus(string orderId)
        {
            return _externalServiceB.CheckPackageStatus(orderId);
        }

        public decimal CalculateDeliveryCost()
        {
            return _externalServiceB.GetShippingCost();
        }
    }

    public class LogisticsAdapterC : IInternalDeliveryService
    {
        private readonly ExternalLogisticsServiceC _externalServiceC;

        public LogisticsAdapterC(ExternalLogisticsServiceC externalServiceC)
        {
            _externalServiceC = externalServiceC;
        }

        public void DeliverOrder(string orderId)
        {
            double weight = double.Parse(orderId);
            _externalServiceC.InitiateShipment(weight);
        }

        public string GetDeliveryStatus(string orderId)
        {
            return _externalServiceC.GetShipmentStatus();
        }

        public decimal CalculateDeliveryCost()
        {
            return _externalServiceC.ComputeShippingCost();
        }
    }

    public class DeliveryServiceFactory
    {
        public static IInternalDeliveryService GetDeliveryService(string serviceType)
        {
            if (serviceType == "internal")
            {
                return new InternalDeliveryService();
            }
            else if (serviceType == "externalA")
            {
                return new LogisticsAdapterA(new ExternalLogisticsServiceA());
            }
            else if (serviceType == "externalB")
            {
                return new LogisticsAdapterB(new ExternalLogisticsServiceB());
            }
            else if (serviceType == "externalC")
            {
                return new LogisticsAdapterC(new ExternalLogisticsServiceC());
            }
            else
            {
                throw new ArgumentException("Неизвестный тип службы доставки");
            }
        }
    }
    internal class Program2
    {
        /*static void Main(string[] args)
        {
            Console.WriteLine("Выберите службу доставки (internal, externalA, externalB, externalC):");
            string serviceType = Console.ReadLine();

            IInternalDeliveryService deliveryService = DeliveryServiceFactory.GetDeliveryService(serviceType);

            Console.WriteLine("Введите ID заказа для доставки:");
            string orderId = Console.ReadLine();

            deliveryService.DeliverOrder(orderId);
            Console.WriteLine(deliveryService.GetDeliveryStatus(orderId));

            decimal cost = deliveryService.CalculateDeliveryCost();
            Console.WriteLine($"Стоимость доставки: {cost} руб.");
        }*/
    }
}
