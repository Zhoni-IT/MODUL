using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MODULS.MODUL13.LAB
{
    class OnlineCourseSystem
    {
        // База данных для хранения данных о студентах и курсах
        private Dictionary<string, List<string>> database = new Dictionary<string, List<string>>();

        // Метод регистрации студента на курс
        public string RegisterStudent(string student, string course)
        {
            if (IsCourseAvailable(course))
            {
                if (!database.ContainsKey(student))
                {
                    database[student] = new List<string>();
                }
                database[student].Add(course);
                return "Регистрация успешна.";
            }
            else
            {
                return "Курс недоступен.";
            }
        }

        // Метод проверки доступности курса
        private bool IsCourseAvailable(string course)
        {
            // Для примера курс всегда доступен
            return true;
        }

        // Метод обработки оплаты
        public string ProcessPayment(string paymentMethod, bool isPaymentSuccessful)
        {
            if (paymentMethod == "online")
            {
                if (isPaymentSuccessful)
                {
                    return "Оплата прошла успешно.";
                }
                else
                {
                    return "Оплата отклонена. Повторите попытку.";
                }
            }
            else if (paymentMethod == "bank")
            {
                return "Оплата через банковский перевод принята.";
            }
            else
            {
                return "Неизвестный способ оплаты.";
            }
        }

        // Метод прохождения курса
        public string CompleteCourse(string student, bool isTestSuccessful)
        {
            if (isTestSuccessful)
            {
                return "Поздравляем! Сертификат выдан.";
            }
            else
            {
                return "Результаты неудовлетворительные. Попробуйте пересдать тесты.";
            }
        }

        // Метод для скачивания сертификата
        public void DownloadCertificate(string student)
        {
            Console.WriteLine($"Сертификат для {student} успешно скачан.");
        }
    }
    internal class Program2
    {
        /*static void Main(string[] args)
        {
            // Создание объекта системы онлайн-курсов
            OnlineCourseSystem courseSystem = new OnlineCourseSystem();

            // Регистрация студента на курс
            Console.WriteLine("Введите имя студента:");
            string student = Console.ReadLine();

            Console.WriteLine("Введите название курса:");
            string course = Console.ReadLine();

            string registrationResult = courseSystem.RegisterStudent(student, course);
            Console.WriteLine(registrationResult);

            if (registrationResult == "Регистрация успешна.")
            {
                // Выбор способа оплаты
                Console.WriteLine("Выберите способ оплаты (online/bank):");
                string paymentMethod = Console.ReadLine();

                bool isPaymentSuccessful = false;

                if (paymentMethod == "online")
                {
                    // Для упрощения: симуляция успешного/неуспешного платежа
                    Console.WriteLine("Введите результат онлайн-платежа (успех/ошибка):");
                    string paymentStatus = Console.ReadLine();
                    isPaymentSuccessful = paymentStatus.ToLower() == "успех";
                }
                else if (paymentMethod == "bank")
                {
                    isPaymentSuccessful = true; // Считаем банковский перевод успешным
                }

                string paymentResult = courseSystem.ProcessPayment(paymentMethod, isPaymentSuccessful);
                Console.WriteLine(paymentResult);

                if (paymentResult == "Оплата прошла успешно." || paymentResult == "Оплата через банковский перевод принята.")
                {
                    // Начало прохождения курса
                    Console.WriteLine($"Студент {student} начинает обучение...");

                    Console.WriteLine("Введите результат выполнения тестов (удовлетворительно/неудовлетворительно):");
                    string testResult = Console.ReadLine();
                    bool isTestSuccessful = testResult.ToLower() == "удовлетворительно";

                    string completionResult = courseSystem.CompleteCourse(student, isTestSuccessful);
                    Console.WriteLine(completionResult);

                    if (completionResult == "Поздравляем! Сертификат выдан.")
                    {
                        // Скачивание сертификата
                        courseSystem.DownloadCertificate(student);
                    }
                    else
                    {
                        Console.WriteLine("Пожалуйста, пересдайте тесты.");
                    }
                }
                else
                {
                    Console.WriteLine("Оплата не завершена, процесс регистрации прерван.");
                }
            }
            else
            {
                Console.WriteLine("Попробуйте выбрать другой курс.");
            }
        }*/
    }
}
