using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MOD
{
    internal class Program2
    {
        public class DatabaseService
        {
            public void Connect()
            {
                string connectionString = "Server=myServer;Database=myDb;User Id=myUser;Password=myPass;";
                // Логика подключения к базе данных
            }
        }
        public class LoggingService
        {
            public void Log(string message)
            {
                string connectionString = "Server=myServer;Database=myDb;User Id=myUser;Password=myPass;";
                // Логика записи лога в базу данных
            }
        }

        static void Main(string[] args)
        {
            Program2 program = new Program2();

        }
    }
}
