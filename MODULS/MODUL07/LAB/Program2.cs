using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MODULS.MODUL07.LAB
{
    public interface IObserver
    {
        void Update(float temperature);
    }

    public interface ISubject
    {
        void RegisterObserver(IObserver observer);
        void RemoveObserver(IObserver observer);
        void NotifyObservers();
    }

    public class WeatherStation : ISubject
    {
        private List<IObserver> observers;
        private float temperature;

        public WeatherStation()
        {
            observers = new List<IObserver>();
        }

        public void RegisterObserver(IObserver observer)
        {
            observers.Add(observer);
        }

        public void RemoveObserver(IObserver observer)
        {
            observers.Remove(observer);
        }

        public void NotifyObservers()
        {
            foreach (var observer in observers)
            {
                observer.Update(temperature);
            }
        }

        public void SetTemperature(float newTemperature)
        {
            Console.WriteLine($"Изменение температуры: {newTemperature}°C");
            temperature = newTemperature;
            NotifyObservers();
        }
    }
    public class WeatherDisplay : IObserver
    {
        private string _name;

        public WeatherDisplay(string name)
        {
            _name = name;
        }

        public void Update(float temperature)
        {
            Console.WriteLine($"{_name} показывает новую температуру: {temperature}°C");
        }
    }

    internal class Program2
    {
        /*static void Main(string[] args)
        {
            WeatherStation weatherStation = new WeatherStation();

            // Создаем несколько наблюдателей
            WeatherDisplay mobileApp = new WeatherDisplay("Мобильное приложение");
            WeatherDisplay digitalBillboard = new WeatherDisplay("Электронное табло");

            // Регистрируем наблюдателей в системе
            weatherStation.RegisterObserver(mobileApp);
            weatherStation.RegisterObserver(digitalBillboard);

            // Изменяем температуру на станции, что приводит к уведомлению наблюдателей
            weatherStation.SetTemperature(25.0f);
            weatherStation.SetTemperature(30.0f);

            // Убираем один из дисплеев и снова меняем температуру
            weatherStation.RemoveObserver(digitalBillboard);
            weatherStation.SetTemperature(28.0f);
        }*/

    }
}
