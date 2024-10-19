using System;

namespace MODULS.MODUL03.DOM
{
    internal class ProgramYAGNI
    {
        /*static void Main(string[] args)
        {
            // Пример работы с классом User
            User user = new User { Name = "Ernar Kaldarbek", Email = "era@gmail.com", Address = "123 Abaya St" };

            // Сохранение пользователя в базу данных
            UserService userService = new UserService();
            userService.SaveToDatabase(user);

            // Отправка письма пользователю
            EmailService emailService = new EmailService();
            emailService.SendEmail(user);

            // Печать адресного ярлыка
            PrintService printService = new PrintService();
            printService.PrintAddressLabel(user);

            // Чтение файла без ненужных настроек
            FileReader fileReader = new FileReader();
            string content = fileReader.ReadFile("path/to/file.txt");
            Console.WriteLine(content);

            // Генерация PDF отчета
            ReportGenerator reportGenerator = new ReportGenerator();
            reportGenerator.GeneratePdfReport();
        }*/

        // Упрощенный класс User
        public class User
        {
            public string Name { get; set; }
            public string Email { get; set; }
            public string Address { get; set; }
        }

        // Сервис для сохранения пользователя в базу данных
        public class UserService
        {
            public void SaveToDatabase(User user)
            {
                Console.WriteLine($"User {user.Name} saved to database.");
            }
        }

        // Сервис для отправки электронного письма
        public class EmailService
        {
            public void SendEmail(User user)
            {
                Console.WriteLine($"Email sent to {user.Email}.");
            }
        }

        // Сервис для печати адресного ярлыка
        public class PrintService
        {
            public void PrintAddressLabel(User user)
            {
                Console.WriteLine($"Address label for {user.Address} printed.");
            }
        }

        // Упрощенный класс FileReader без избыточных настроек
        public class FileReader
        {
            public string ReadFile(string filePath)
            {
                return "file content";
            }
        }

        // Упрощенный класс ReportGenerator, только с одной функцией
        public class ReportGenerator
        {
            public void GeneratePdfReport()
            {
                Console.WriteLine("PDF report generated.");
            }
        }
    }
}
