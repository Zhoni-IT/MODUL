using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using System.IO;
using System.Threading;

namespace MODULS.MODUL06.LAB
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
        private LogLevel _logLevel;
        private string _logFilePath;

        private Logger()
        {
            _logLevel = LogLevel.INFO;
            _logFilePath = @"C:\Users\User\Desktop\SU\Шаблоны проектирования приложений\MODUL\MODULS\log.txt";
        }

        // Метод для получения единственного экземпляра Logger
        public static Logger GetInstance()
        {
            return _instance.Value;
        }

        // Метод для установки пути к файлу логов
        public void SetLogFilePath(string path)
        {
            _logFilePath = path;
        }

        // Метод для установки уровня логирования
        public void SetLogLevel(LogLevel level)
        {
            _logLevel = level;
        }

        // Метод для записи логов
        public void Log(string message, LogLevel level)
        {
            if (level < _logLevel)
                return;

            lock (_instance)
            {
                using (StreamWriter writer = new StreamWriter(_logFilePath, true))
                {
                    writer.WriteLine($"{DateTime.Now}: [{level}] {message}");
                }
            }
        }

        // Метод для чтения логов из файла и отображения их на экране
        public void ReadLogs()
        {
            lock (_instance)
            {
                if (File.Exists(_logFilePath))
                {
                    using (StreamReader reader = new StreamReader(_logFilePath))
                    {
                        string line;
                        while ((line = reader.ReadLine()) != null)
                        {
                            Console.WriteLine(line);
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Файл логов не найден.");
                }
            }
        }
    }
    internal class Program1
    {
        /* static void Main(string[] args)
        {
            Logger logger = Logger.GetInstance();
            logger.SetLogLevel(LogLevel.INFO);
            logger.SetLogFilePath(@"C:\Users\User\Desktop\SU\Шаблоны проектирования приложений\MODUL\MODULS\log.txt");

            // Создаем несколько потоков для записи логов
            Thread t1 = new Thread(() => logger.Log("Это информационное сообщение", LogLevel.INFO));
            Thread t2 = new Thread(() => logger.Log("Это предупреждение", LogLevel.WARNING));
            Thread t3 = new Thread(() => logger.Log("Это сообщение об ошибке", LogLevel.ERROR));
            Thread t4 = new Thread(() => logger.Log("Еще одно информационное сообщение", LogLevel.INFO));

            // Запускаем потоки
            t1.Start();
            t2.Start();
            t3.Start();
            t4.Start();

            // Ожидание завершения потоков
            t1.Join();
            t2.Join();
            t3.Join();
            t4.Join();

            Console.WriteLine("Логи записаны.");

            // Чтение логов из файла
            Console.WriteLine("Содержимое логов:");
            logger.ReadLogs();
        }*/
    }
}
