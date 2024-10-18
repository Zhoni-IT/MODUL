using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MODULS.MODUL07.PRAC
{
    public interface IObserver
    {
        void Update(string stockSymbol, decimal price);
    }
    public interface ISubject
    {
        void RegisterObserver(IObserver observer, string stockSymbol);
        void RemoveObserver(IObserver observer, string stockSymbol);
        void NotifyObservers(string stockSymbol);
    }

    public class StockExchange : ISubject
    {
        private Dictionary<string, decimal> _stocks = new Dictionary<string, decimal>();
        private Dictionary<string, List<IObserver>> _observers = new Dictionary<string, List<IObserver>>();

        // Добавляем акцию и ее начальную цену
        public void AddStock(string stockSymbol, decimal initialPrice)
        {
            _stocks[stockSymbol] = initialPrice;
            _observers[stockSymbol] = new List<IObserver>();
        }

        // Обновляем цену акции и уведомляем наблюдателей
        public void UpdateStockPrice(string stockSymbol, decimal newPrice)
        {
            _stocks[stockSymbol] = newPrice;
            NotifyObservers(stockSymbol);
        }

        public void RegisterObserver(IObserver observer, string stockSymbol)
        {
            if (_observers.ContainsKey(stockSymbol))
            {
                _observers[stockSymbol].Add(observer);
            }
        }

        public void RemoveObserver(IObserver observer, string stockSymbol)
        {
            if (_observers.ContainsKey(stockSymbol))
            {
                _observers[stockSymbol].Remove(observer);
            }
        }

        public void NotifyObservers(string stockSymbol)
        {
            if (_observers.ContainsKey(stockSymbol))
            {
                decimal stockPrice = _stocks[stockSymbol];
                foreach (var observer in _observers[stockSymbol])
                {
                    observer.Update(stockSymbol, stockPrice);
                }
            }
        }
    }
    public class Trader : IObserver
    {
        private string _name;

        public Trader(string name)
        {
            _name = name;
        }

        public void Update(string stockSymbol, decimal price)
        {
            Console.WriteLine($"Трейдер {_name}: Цена акции {stockSymbol} изменилась на {price:C}");
        }
    }
    public class TradingRobot : IObserver
    {
        private string _stockSymbol;
        private decimal _threshold;

        public TradingRobot(string stockSymbol, decimal threshold)
        {
            _stockSymbol = stockSymbol;
            _threshold = threshold;
        }

        public void Update(string stockSymbol, decimal price)
        {
            if (stockSymbol == _stockSymbol)
            {
                if (price > _threshold)
                {
                    Console.WriteLine($"Торговый робот: Продаю акцию {stockSymbol} по цене {price:C}");
                }
                else
                {
                    Console.WriteLine($"Торговый робот: Покупаю акцию {stockSymbol} по цене {price:C}");
                }
            }
        }
    }


    internal class Program2
    {
        /* static void Main(string[] args)
        {
            // Создаем биржу
            StockExchange stockExchange = new StockExchange();

            // Добавляем акции
            stockExchange.AddStock("KSPI", 150m);
            stockExchange.AddStock("HSBK", 2800m);

            // Создаем наблюдателей
            Trader trader1 = new Trader("Ернар");
            Trader trader2 = new Trader("Максат");
            TradingRobot robot = new TradingRobot("KSPI", 200m);

            // Регистрируем наблюдателей на акции
            stockExchange.RegisterObserver(trader1, "KSPI");
            stockExchange.RegisterObserver(trader2, "HSBK");
            stockExchange.RegisterObserver(robot, "KSPI");

            // Изменяем цену акции и уведомляем наблюдателей
            stockExchange.UpdateStockPrice("KSPI", 160m);  // Трейдер Ернар и робот получат уведомление
            stockExchange.UpdateStockPrice("HSBK", 2900m); // Трейдер Максат получит уведомление

            // Изменение цены ниже порогового значения для робота
            stockExchange.UpdateStockPrice("KSPI", 140m);  // Робот купит акцию
        }*/
    }
}
