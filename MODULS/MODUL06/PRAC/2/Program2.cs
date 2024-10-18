using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MODULS.MODUL06.PRAC._2
{
    public enum LogLevel
    {
        INFO,
        WARNING,
        ERROR
    }

    public class Logger
    {
        private static readonly Lazy<Logger> _instance = new Lazy<Logger>(() => new Logger());
        private static readonly object _lock = new object();
        private LogLevel _logLevel = LogLevel.INFO;
        private string _logFilePath = "application.log";
        private long _maxLogSize = 1024 * 1024; // 1 MB

        private Logger() { }

        public static Logger GetInstance()
        {
            return _instance.Value;
        }

        public void SetLogLevel(LogLevel level)
        {
            _logLevel = level;
        }

        public void SetLogFilePath(string path)
        {
            _logFilePath = path;
        }

        public void SetMaxLogSize(long size)
        {
            _maxLogSize = size;
        }

        public void Log(string message, LogLevel level)
        {
            if (level >= _logLevel)
            {
                lock (_lock) // Блокировка для обеспечения потокобезопасности
                {
                    CheckLogFileSize(); // Проверка размера лог-файла перед записью
                    try
                    {
                        using (StreamWriter writer = new StreamWriter(_logFilePath, append: true))
                        {
                            string logMessage = $"{DateTime.Now:yyyy-MM-dd HH:mm:ss}: [{level}] {message}";
                            writer.WriteLine(logMessage);
                            Console.WriteLine(logMessage); // Логирование также в консоль
                        }
                    }
                    catch (IOException ex)
                    {
                        Console.WriteLine($"Ошибка записи в лог: {ex.Message}");
                    }
                }
            }
        }

        private void CheckLogFileSize()
        {
            FileInfo logFileInfo = new FileInfo(_logFilePath);
            if (logFileInfo.Exists && logFileInfo.Length >= _maxLogSize)
            {
                string newFilePath = $"{_logFilePath}_{DateTime.Now:yyyyMMdd_HHmmss}.log";
                logFileInfo.MoveTo(newFilePath);
            }
        }

        public void LoadConfiguration(string configFilePath)
        {
            try
            {
                var json = File.ReadAllText(configFilePath);
                var config = JObject.Parse(json);
                SetLogLevel((LogLevel)Enum.Parse(typeof(LogLevel), config["LogLevel"].ToString()));
                SetLogFilePath(config["LogFilePath"].ToString());
                SetMaxLogSize((long)config["MaxLogSize"]);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка загрузки конфигурации: {ex.Message}");
            }
        }
    }

    public class LogReader
    {
        private string _logFilePath;

        public LogReader(string logFilePath)
        {
            _logFilePath = logFilePath;
        }

        public void DisplayLogs(LogLevel filterLevel)
        {
            using (StreamReader reader = new StreamReader(_logFilePath))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    var parts = line.Split(new[] { ": [" }, StringSplitOptions.None);
                    if (parts.Length > 1)
                    {
                        var level = (LogLevel)Enum.Parse(typeof(LogLevel), parts[1].TrimEnd(']'));
                        if (level >= filterLevel)
                        {
                            Console.WriteLine(line);
                        }
                    }
                }
            }
        }

        // Метод для фильтрации по времени
        public void DisplayLogsByDate(DateTime startDate, DateTime endDate)
        {
            using (StreamReader reader = new StreamReader(_logFilePath))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    var parts = line.Split(new[] { ": [" }, StringSplitOptions.None);
                    if (parts.Length > 1)
                    {
                        var datePart = parts[0];
                        DateTime logDate = DateTime.Parse(datePart);
                        if (logDate >= startDate && logDate <= endDate)
                        {
                            Console.WriteLine(line);
                        }
                    }
                }
            }
        }
    }
    internal class Program2
    {
        /* static void Main()
        {
            Logger logger = Logger.GetInstance();
            logger.LoadConfiguration(@"C:\Users\User\Desktop\SU\Шаблоны проектирования приложений\MODUL\MODULS\config.json");

            Thread[] threads = new Thread[5];
            for (int i = 0; i < threads.Length; i++)
            {
                threads[i] = new Thread(() =>
                {
                    var logLevel = (LogLevel)(new Random().Next(0, 3));
                    logger.Log($"Log message at level {logLevel}", logLevel);
                });
                threads[i].Start();
            }

            foreach (var thread in threads)
            {
                thread.Join();
            }

            LogReader logReader = new LogReader(@"C:\Users\User\Desktop\SU\Шаблоны проектирования приложений\MODUL\MODULS\application.log");
            logReader.DisplayLogs(LogLevel.WARNING); // Чтение логов только уровня WARNING и выше

            // Пример фильтрации логов по времени
            DateTime startDate = DateTime.Now.AddHours(-1); // Начало - 1 час назад
            DateTime endDate = DateTime.Now; // Конец - текущее время
            Console.WriteLine("\nЛоги за последний час:");
            logReader.DisplayLogsByDate(startDate, endDate);
        }*/
    }
}
