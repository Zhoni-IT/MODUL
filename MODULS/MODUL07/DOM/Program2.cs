using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MODULS.MODUL07.DOM
{
    public interface IObserver
    {
        void Update(decimal exchangeRate);
    }
    public interface ISubject
    {
        void RegisterObserver(IObserver observer);
        void RemoveObserver(IObserver observer);
        void NotifyObservers();
    }
    public class CurrencyExchange : ISubject
    {
        private List<IObserver> observers;
        private decimal _exchangeRate;

        public CurrencyExchange()
        {
            observers = new List<IObserver>();
        }

        public void SetExchangeRate(decimal newRate)
        {
            _exchangeRate = newRate;
            NotifyObservers();
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
                observer.Update(_exchangeRate);
            }
        }
    }
    public class SmsObserver : IObserver
    {
        public void Update(decimal exchangeRate)
        {
            Console.WriteLine($"[SMS] Курс валют обновлён: {exchangeRate} рублей за доллар.");
        }
    }
    public class DisplayObserver : IObserver
    {
        public void Update(decimal exchangeRate)
        {
            Console.WriteLine($"[Дисплей] Текущий курс валют: {exchangeRate} рублей за доллар.");
        }
    }
    public class EmailObserver : IObserver
    {
        public void Update(decimal exchangeRate)
        {
            Console.WriteLine($"[Email] Курс валют обновлён: {exchangeRate} рублей за доллар.");
        }
    }

    internal class Program2
    {
        /*static void Main(string[] args)
        {
            CurrencyExchange currencyExchange = new CurrencyExchange();

            // Создаём наблюдателей
            IObserver smsObserver = new SmsObserver();
            IObserver emailObserver = new EmailObserver();
            IObserver displayObserver = new DisplayObserver();

            // Регистрируем наблюдателей
            currencyExchange.RegisterObserver(smsObserver);
            currencyExchange.RegisterObserver(emailObserver);
            currencyExchange.RegisterObserver(displayObserver);

            // Изменяем курс валют
            currencyExchange.SetExchangeRate(75.25m);

            // Удаляем одного наблюдателя и снова меняем курс
            currencyExchange.RemoveObserver(emailObserver);
            currencyExchange.SetExchangeRate(76.00m);
        }*/
    }
}
