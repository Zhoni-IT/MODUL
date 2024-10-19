using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MODULS.MODUL01.PRAC
{
    // Базовый класс Транспортное средство
    public abstract class Vehicle
    {
        public string Make { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }

        public Vehicle(string make, string model, int year)
        {
            Make = make;
            Model = model;
            Year = year;
        }

        // Метод для запуска двигателя
        public virtual void StartEngine()
        {
            Console.WriteLine($"Запуск двигателя {Make} {Model} ({Year})...");
        }

        // Метод для остановки двигателя
        public virtual void StopEngine()
        {
            Console.WriteLine($"Остановка двигателя {Make} {Model} ({Year})...");
        }

        public virtual void DisplayInfo()
        {
            Console.WriteLine($"Транспортное средство: {Make} {Model}, Год: {Year}");
        }
    }

    // Производный класс Автомобиль
    public class Car : Vehicle
    {
        public int DoorCount { get; set; }
        public string TransmissionType { get; set; }

        public Car(string make, string model, int year, int doorCount, string transmissionType)
            : base(make, model, year)
        {
            DoorCount = doorCount;
            TransmissionType = transmissionType;
        }

        // Переопределение метода для отображения информации
        public override void DisplayInfo()
        {
            base.DisplayInfo();
            Console.WriteLine($"Автомобиль: Количество дверей: {DoorCount}, Тип трансмиссии: {TransmissionType}\n");
        }
    }

    // Производный класс Мотоцикл
    public class Motorcycle : Vehicle
    {
        public string BodyType { get; set; }
        public bool HasBox { get; set; }

        public Motorcycle(string make, string model, int year, string bodyType, bool hasBox)
            : base(make, model, year)
        {
            BodyType = bodyType;
            HasBox = hasBox;
        }

        // Переопределение метода для отображения информации
        public override void DisplayInfo()
        {
            base.DisplayInfo();
            Console.WriteLine($"Мотоцикл: Тип кузова: {BodyType}, Наличие бокса: {(HasBox ? "Да" : "Нет")}\n");
        }
    }

    // Класс Гараж, использующий композицию для хранения транспортных средств
    public class Garage
    {
        public string Name { get; set; }
        private List<Vehicle> vehicles;

        public Garage(string name)
        {
            Name = name;
            vehicles = new List<Vehicle>();
        }

        // Метод для добавления транспортного средства в гараж
        public void AddVehicle(Vehicle vehicle)
        {
            vehicles.Add(vehicle);
            Console.WriteLine($"Добавлено транспортное средство в гараж {Name}: {vehicle.Make} {vehicle.Model}");
        }

        // Метод для удаления транспортного средства из гаража
        public void RemoveVehicle(Vehicle vehicle)
        {
            vehicles.Remove(vehicle);
            Console.WriteLine($"Удалено транспортное средство из гаража {Name}: {vehicle.Make} {vehicle.Model}");
        }

        // Отображение информации обо всех транспортных средствах в гараже
        public void DisplayVehicles()
        {
            Console.WriteLine($"\nТранспортные средства в гараже {Name}:");
            foreach (var vehicle in vehicles)
            {
                vehicle.DisplayInfo();
            }
        }
    }

    // Класс Автопарк, использующий композицию для хранения гаражей
    public class Fleet
    {
        private List<Garage> garages;

        public Fleet()
        {
            garages = new List<Garage>();
        }

        public void AddGarage(Garage garage)
        {
            garages.Add(garage);
            Console.WriteLine($"Добавлен гараж: {garage.Name}");
        }

        public void RemoveGarage(Garage garage)
        {
            garages.Remove(garage);
            Console.WriteLine($"Удален гараж: {garage.Name}");
        }

        public void DisplayAllVehicles()
        {
            foreach (var garage in garages)
            {
                garage.DisplayVehicles();
            }
        }
    }
    internal class Program
    {
        /*public static void Main()
        {
            Car car1 = new Car("Toyota", "Camry", 2020, 4, "Автоматическая");
            Car car2 = new Car("Ford", "Focus", 2018, 4, "Механическая");
            Motorcycle moto1 = new Motorcycle("Honda", "CBR500R", 2019, "Спортбайк", true);
            Motorcycle moto2 = new Motorcycle("Yamaha", "MT-07", 2021, "Нейкед", false);

            Garage garage1 = new Garage("Гараж #1");
            Garage garage2 = new Garage("Гараж #2");

            garage1.AddVehicle(car1);
            garage1.AddVehicle(moto1);
            garage2.AddVehicle(car2);
            garage2.AddVehicle(moto2);

            Fleet fleet = new Fleet();
            fleet.AddGarage(garage1);
            fleet.AddGarage(garage2);

            Console.WriteLine("\nАвтопарк:");
            fleet.DisplayAllVehicles();
        }*/
    }
}
