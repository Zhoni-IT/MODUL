using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MODULS.MODUL06.DOM
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Threading;

    public class ConfigurationManager
    {
        private static ConfigurationManager _instance;
        private static readonly object _lock = new object();
        private Dictionary<string, string> _settings;

        private ConfigurationManager()
        {
            _settings = new Dictionary<string, string>();
        }

        // Метод для получения единственного экземпляра класса
        public static ConfigurationManager GetInstance()
        {
            if (_instance == null)
            {
                lock (_lock) // Блокируем доступ для других потоков
                {
                    if (_instance == null)
                    {
                        _instance = new ConfigurationManager();
                    }
                }
            }
            return _instance;
        }

        // Метод для загрузки настроек из файла
        public void LoadSettingsFromFile(string filePath)
        {
            if (!File.Exists(filePath))
            {
                throw new FileNotFoundException("Файл настроек не найден");
            }

            var lines = File.ReadAllLines(filePath);
            foreach (var line in lines)
            {
                var parts = line.Split('=');
                if (parts.Length == 2)
                {
                    _settings[parts[0].Trim()] = parts[1].Trim();
                }
            }
        }

        // Метод для сохранения настроек в файл
        public void SaveSettingsToFile(string filePath)
        {
            using (var writer = new StreamWriter(filePath))
            {
                foreach (var kvp in _settings)
                {
                    writer.WriteLine($"{kvp.Key}={kvp.Value}");
                }
            }
        }

        // Метод для получения значения настройки по ключу
        public string GetSetting(string key)
        {
            if (_settings.ContainsKey(key))
            {
                return _settings[key];
            }
            throw new KeyNotFoundException($"Настройка с ключом '{key}' не найдена.");
        }

        // Метод для добавления или обновления настройки
        public void SetSetting(string key, string value)
        {
            _settings[key] = value;
        }
    }

    internal class Program1
    {
        /*static void Main(string[] args)
        {
            // Путь к файлу настроек
            string filePath = @"C:\Users\User\Desktop\SU\Шаблоны проектирования приложений\MODUL\MODULS\config.txt";

            // Многопоточное тестирование
            Parallel.For(0, 5, i =>
            {
                var config = ConfigurationManager.GetInstance();
                config.SetSetting($"Thread{i}", $"Value from thread {i}");
            });

            // Получаем единственный экземпляр и загружаем настройки из файла
            var manager = ConfigurationManager.GetInstance();
            manager.LoadSettingsFromFile(filePath);

            // Выводим загруженные настройки
            Console.WriteLine("Настройки после загрузки из файла:");
            Console.WriteLine(manager.GetSetting("AppMode"));
            Console.WriteLine(manager.GetSetting("LogLevel"));

            // Сохраняем новые настройки в файл
            manager.SaveSettingsToFile(filePath);
        }*/
    }
}
