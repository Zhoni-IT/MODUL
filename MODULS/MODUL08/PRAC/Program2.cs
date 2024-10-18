using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MODULS.MODUL08.PRAC
{
    public abstract class ReportGenerator
    {
        // Шаблонный метод, определяющий общий алгоритм создания отчета
        public void GenerateReport()
        {
            GatherData();
            FormatData();
            CreateHeader();
            CreateContent();
            if (CustomerWantsSave())
            {
                SaveReport();
            }
            else
            {
                SendReportByEmail();
            }
        }

        // Общие шаги (не могут быть изменены подклассами)
        private void GatherData()
        {
            Console.WriteLine("Сбор данных для отчета...");
        }

        // Шаги, которые переопределяются в подклассах
        protected abstract void FormatData();
        protected abstract void CreateHeader();
        protected abstract void CreateContent();

        // Шаг, который может быть изменен в подклассах (перехватываемый метод, hook)
        protected virtual bool CustomerWantsSave()
        {
            while (true)
            {
                Console.WriteLine("Вы хотите сохранить отчет? (y/n)");
                string input = Console.ReadLine().ToLower();
                if (input == "y")
                {
                    return true;
                }
                else if (input == "n")
                {
                    return false;
                }
                else
                {
                    Console.WriteLine("Неверный ввод, попробуйте снова.");
                }
            }
        }

        // Конкретная реализация сохранения отчета (можно не изменять)
        protected virtual void SaveReport()
        {
            Console.WriteLine("Отчет сохранен на диск.");
        }

        // Опциональный шаг - отправка по электронной почте
        protected virtual void SendReportByEmail()
        {
            Console.WriteLine("Отчет отправлен по электронной почте.");
        }
    }
    public class PdfReport : ReportGenerator
    {
        protected override void FormatData()
        {
            Console.WriteLine("Форматирование данных для PDF-отчета...");
        }

        protected override void CreateHeader()
        {
            Console.WriteLine("Создание заголовка PDF-отчета...");
        }

        protected override void CreateContent()
        {
            Console.WriteLine("Создание содержимого PDF-отчета...");
        }
    }
    public class ExcelReport : ReportGenerator
    {
        protected override void FormatData()
        {
            Console.WriteLine("Форматирование данных для Excel-отчета...");
        }

        protected override void CreateHeader()
        {
            Console.WriteLine("Создание заголовка Excel-отчета...");
        }

        protected override void CreateContent()
        {
            Console.WriteLine("Создание содержимого Excel-отчета...");
        }

        // Переопределяем метод сохранения, чтобы выполнить уникальные действия для Excel
        protected override void SaveReport()
        {
            Console.WriteLine("Excel-отчет сохранен как файл .xlsx.");
        }
    }
    public class HtmlReport : ReportGenerator
    {
        protected override void FormatData()
        {
            Console.WriteLine("Форматирование данных для HTML-отчета...");
        }

        protected override void CreateHeader()
        {
            Console.WriteLine("Создание заголовка HTML-отчета...");
        }

        protected override void CreateContent()
        {
            Console.WriteLine("Создание содержимого HTML-отчета...");
        }

        // Пример перехвата сохранения: этот отчет по умолчанию отправляется по email, а не сохраняется
        protected override bool CustomerWantsSave()
        {
            return false; // Для HTML-отчета предпочтение отдаётся отправке по email
        }
    }
    public class CsvReport : ReportGenerator
    {
        protected override void FormatData()
        {
            Console.WriteLine("Форматирование данных для CSV-отчета...");
        }

        protected override void CreateHeader()
        {
            Console.WriteLine("Создание заголовка CSV-отчета...");
        }

        protected override void CreateContent()
        {
            Console.WriteLine("Создание содержимого CSV-отчета...");
        }

        protected override void SaveReport()
        {
            Console.WriteLine("CSV-отчет сохранен как файл .csv.");
        }
    }


    internal class Program2
    {
        /*static void Main(string[] args)
        {
            Console.WriteLine("Генерация PDF-отчета:");
            ReportGenerator pdfReport = new PdfReport();
            pdfReport.GenerateReport();

            Console.WriteLine("\nГенерация Excel-отчета:");
            ReportGenerator excelReport = new ExcelReport();
            excelReport.GenerateReport();

            Console.WriteLine("\nГенерация HTML-отчета:");
            ReportGenerator htmlReport = new HtmlReport();
            htmlReport.GenerateReport();

            Console.WriteLine("\nГенерация CSV-отчета:");
            ReportGenerator csvReport = new CsvReport();
            csvReport.GenerateReport();
        }*/
    }
}
