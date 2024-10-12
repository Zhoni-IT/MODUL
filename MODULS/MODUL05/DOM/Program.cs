using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MODULS.MODUL05.DOM
{
    // Интерфейс для всех транспортных средств
    public interface IVehicle
    {
        void Drive();
        void Refuel();
    }

    // Класс для автомобиля
    public class Car : IVehicle
    {
        public string Brand { get; }
        public string Model { get; }
        public string FuelType { get; }

        public Car(string brand, string model, string fuelType)
        {
            Brand = brand;
            Model = model;
            FuelType = fuelType;
        }

        public void Drive()
        {
            Console.WriteLine($"{Brand} {Model} едет.");
        }

        public void Refuel()
        {
            Console.WriteLine($"{Brand} {Model} заправляется с использованием топлива: {FuelType}.");
        }
    }

    // Класс для мотоцикла
    public class Motorcycle : IVehicle
    {
        public string Type { get; }
        public int EngineCapacity { get; }

        public Motorcycle(string type, int engineCapacity)
        {
            Type = type;
            EngineCapacity = engineCapacity;
        }

        public void Drive()
        {
            Console.WriteLine($"{Type} мотоцикл с двигателем {EngineCapacity}cc едет.");
        }

        public void Refuel()
        {
            Console.WriteLine($"{Type} мотоцикл заправляется.");
        }
    }

    // Класс для грузовика
    public class Truck : IVehicle
    {
        public int LoadCapacity { get; }
        public int Axles { get; }

        public Truck(int loadCapacity, int axles)
        {
            LoadCapacity = loadCapacity;
            Axles = axles;
        }

        public void Drive()
        {
            Console.WriteLine($"Грузовик с грузоподъемностью {LoadCapacity} кг и {Axles} осями едет.");
        }

        public void Refuel()
        {
            Console.WriteLine("Грузовик заправляется.");
        }
    }

    // Класс для автобуса
    public class Bus : IVehicle
    {
        public int PassengerCapacity { get; }

        public Bus(int passengerCapacity)
        {
            PassengerCapacity = passengerCapacity;
        }

        public void Drive()
        {
            Console.WriteLine($"Автобус с пассажировместимостью {PassengerCapacity} едет.");
        }

        public void Refuel()
        {
            Console.WriteLine("Автобус заправляется.");
        }
    }

    // Абстрактный класс фабрики
    public abstract class VehicleFactory
    {
        public abstract IVehicle CreateVehicle();
    }

    // Фабрика для автомобиля
    public class CarFactory : VehicleFactory
    {
        private readonly string _brand;
        private readonly string _model;
        private readonly string _fuelType;

        public CarFactory(string brand, string model, string fuelType)
        {
            _brand = brand;
            _model = model;
            _fuelType = fuelType;
        }

        public override IVehicle CreateVehicle()
        {
            return new Car(_brand, _model, _fuelType);
        }
    }

    // Фабрика для мотоцикла
    public class MotorcycleFactory : VehicleFactory
    {
        private readonly string _type;
        private readonly int _engineCapacity;

        public MotorcycleFactory(string type, int engineCapacity)
        {
            _type = type;
            _engineCapacity = engineCapacity;
        }

        public override IVehicle CreateVehicle()
        {
            return new Motorcycle(_type, _engineCapacity);
        }
    }

    // Фабрика для грузовика
    public class TruckFactory : VehicleFactory
    {
        private readonly int _loadCapacity;
        private readonly int _axles;

        public TruckFactory(int loadCapacity, int axles)
        {
            _loadCapacity = loadCapacity;
            _axles = axles;
        }

        public override IVehicle CreateVehicle()
        {
            return new Truck(_loadCapacity, _axles);
        }
    }

    // Фабрика для автобуса
    public class BusFactory : VehicleFactory
    {
        private readonly int _passengerCapacity;

        public BusFactory(int passengerCapacity)
        {
            _passengerCapacity = passengerCapacity;
        }

        public override IVehicle CreateVehicle()
        {
            return new Bus(_passengerCapacity);
        }
    }

    // Основная программа
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Выберите тип транспорта: 1 - Автомобиль, 2 - Мотоцикл, 3 - Грузовик, 4 - Автобус");
            int choice = int.Parse(Console.ReadLine());

            VehicleFactory factory = null;

            switch (choice)
            {
                case 1:
                    Console.WriteLine("Введите марку, модель и тип топлива для автомобиля:");
                    string brand = Console.ReadLine();
                    string model = Console.ReadLine();
                    string fuelType = Console.ReadLine();
                    factory = new CarFactory(brand, model, fuelType);
                    break;
                case 2:
                    Console.WriteLine("Введите тип и объем двигателя для мотоцикла:");
                    string type = Console.ReadLine();
                    int engineCapacity = int.Parse(Console.ReadLine());
                    factory = new MotorcycleFactory(type, engineCapacity);
                    break;
                case 3:
                    Console.WriteLine("Введите грузоподъемность и количество осей для грузовика:");
                    int loadCapacity = int.Parse(Console.ReadLine());
                    int axles = int.Parse(Console.ReadLine());
                    factory = new TruckFactory(loadCapacity, axles);
                    break;
                case 4:
                    Console.WriteLine("Введите пассажировместимость для автобуса:");
                    int passengerCapacity = int.Parse(Console.ReadLine());
                    factory = new BusFactory(passengerCapacity);
                    break;
                default:
                    Console.WriteLine("Неверный выбор.");
                    break;
            }

            if (factory != null)
            {
                IVehicle vehicle = factory.CreateVehicle();
                vehicle.Drive();
                vehicle.Refuel();
            }

            Console.ReadLine();
        }
    }
}

