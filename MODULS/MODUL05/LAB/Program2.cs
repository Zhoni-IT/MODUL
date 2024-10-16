using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MODULS.MODUL05.LAB
{
    // Интерфейс для всех транспортных средств
    public interface ITransport
    {
        void Move();
        void FuelUp();
    }

    // Класс для автомобиля
    public class Car : ITransport
    {
        public string Model { get; }
        public int Speed { get; }

        public Car(string model, int speed)
        {
            Model = model;
            Speed = speed;
        }

        public void Move()
        {
            Console.WriteLine($"Автомобиль {Model} движется со скоростью {Speed} км/ч.");
        }

        public void FuelUp()
        {
            Console.WriteLine($"Автомобиль {Model} заправляется бензином.");
        }
    }

    // Класс для мотоцикла
    public class Motorcycle : ITransport
    {
        public string Model { get; }
        public int Speed { get; }

        public Motorcycle(string model, int speed)
        {
            Model = model;
            Speed = speed;
        }

        public void Move()
        {
            Console.WriteLine($"Мотоцикл {Model} движется со скоростью {Speed} км/ч.");
        }

        public void FuelUp()
        {
            Console.WriteLine($"Мотоцикл {Model} заправляется бензином.");
        }
    }

    // Класс для самолета
    public class Plane : ITransport
    {
        public string Model { get; }
        public int Speed { get; }

        public Plane(string model, int speed)
        {
            Model = model;
            Speed = speed;
        }

        public void Move()
        {
            Console.WriteLine($"Самолет {Model} летит со скоростью {Speed} км/ч.");
        }

        public void FuelUp()
        {
            Console.WriteLine($"Самолет {Model} заправляется авиационным топливом.");
        }
    }

    // Класс для велосипеда
    public class Bicycle : ITransport
    {
        public string Model { get; }
        public int Speed { get; }

        public Bicycle(string model, int speed)
        {
            Model = model;
            Speed = speed;
        }

        public void Move()
        {
            Console.WriteLine($"Велосипед {Model} едет со скоростью {Speed} км/ч.");
        }

        public void FuelUp()
        {
            Console.WriteLine($"Велосипед {Model} не нуждается в заправке.");
        }
    }

    // Абстрактный класс фабрики транспорта
    public abstract class TransportFactory
    {
        public abstract ITransport CreateTransport(string model, int speed);
    }

    // Фабрика для автомобиля
    public class CarFactory : TransportFactory
    {
        public override ITransport CreateTransport(string model, int speed)
        {
            return new Car(model, speed);
        }
    }

    // Фабрика для мотоцикла
    public class MotorcycleFactory : TransportFactory
    {
        public override ITransport CreateTransport(string model, int speed)
        {
            return new Motorcycle(model, speed);
        }
    }

    // Фабрика для самолета
    public class PlaneFactory : TransportFactory
    {
        public override ITransport CreateTransport(string model, int speed)
        {
            return new Plane(model, speed);
        }
    }

    // Фабрика для велосипеда
    public class BicycleFactory : TransportFactory
    {
        public override ITransport CreateTransport(string model, int speed)
        {
            return new Bicycle(model, speed);
        }
    }

    internal class Program2
    {
        /* static void Main(string[] args)
        {
            Console.WriteLine("Выберите тип транспорта: 1 - Автомобиль, 2 - Мотоцикл, 3 - Самолет, 4 - Велосипед");
            int choice = int.Parse(Console.ReadLine());

            Console.WriteLine("Введите модель транспорта:");
            string model = Console.ReadLine();

            Console.WriteLine("Введите скорость транспорта (в км/ч):");
            int speed = int.Parse(Console.ReadLine());

            TransportFactory factory = null;

            switch (choice)
            {
                case 1:
                    factory = new CarFactory();
                    break;
                case 2:
                    factory = new MotorcycleFactory();
                    break;
                case 3:
                    factory = new PlaneFactory();
                    break;
                case 4:
                    factory = new BicycleFactory();
                    break;
                default:
                    Console.WriteLine("Неверный выбор.");
                    break;
            }

            if (factory != null)
            {
                ITransport transport = factory.CreateTransport(model, speed);
                transport.Move();
                transport.FuelUp();
            }

            Console.ReadLine();
        }*/ 
    }
}
