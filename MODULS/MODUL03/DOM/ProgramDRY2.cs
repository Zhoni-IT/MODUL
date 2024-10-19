using System;

namespace MODULS.MODUL03.DOM
{
    public class ConfigSettings
    {
        public string ConnectionString { get; private set; }

        public ConfigSettings()
        {
            ConnectionString = "Server=myServer;Database=myDb;User Id=myUser;Password=myPass;";
        }
    }

    public class DatabaseService
    {
        private readonly ConfigSettings _configSettings;

        public DatabaseService(ConfigSettings configSettings)
        {
            _configSettings = configSettings;
        }

        public void Connect()
        {
            string connectionString = _configSettings.ConnectionString;
            Console.WriteLine($"Подключение к базе данных с использованием строки подключения: {connectionString}");
        }
    }

    public class LoggingService
    {
        private readonly ConfigSettings _configSettings;

        public LoggingService(ConfigSettings configSettings)
        {
            _configSettings = configSettings;
        }

        public void Log(string message)
        {
            string connectionString = _configSettings.ConnectionString;
            Console.WriteLine($"Запись лога в базу данных с использованием строки подключения: {connectionString}");
        }
    }

    internal class ProgramDRY2
    {
        /*static void Main(string[] args)
        {
            ConfigSettings configSettings = new ConfigSettings();

            DatabaseService databaseService = new DatabaseService(configSettings);
            LoggingService loggingService = new LoggingService(configSettings);

            databaseService.Connect();
            loggingService.Log("Это сообщение лога.");

            Console.ReadLine();
        }*/
    }
}
