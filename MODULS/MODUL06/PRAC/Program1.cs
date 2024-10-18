using System;
using System.IO;
using System.Threading;
using Newtonsoft.Json.Linq;

namespace MODULS.MODUL06.PRAC
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

        public void Log(string message, LogLevel level)
        {
            if (level >= _logLevel)
            {
                lock (_lock) // Блокировка для обеспечения потокобезопасности
                {
                    try
                    {
                        using (StreamWriter writer = new StreamWriter(_logFilePath, append: true))
                        {
                            string logMessage = $"{DateTime.Now}: [{level}] {message}";
                            writer.WriteLine(logMessage);
                        }
                    }
                    catch (IOException ex)
                    {
                        Console.WriteLine($"Ошибка записи в лог: {ex.Message}");
                    }
                }
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
    }

    internal class Program1
    {
        /* static void Main()
        {
            Logger logger = Logger.GetInstance();
            logger.LoadConfiguration("config.json");

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

            LogReader logReader = new LogReader("application.log");
            logReader.DisplayLogs(LogLevel.WARNING); // Чтение логов только уровня WARNING и выше
        }*/
    }
}
