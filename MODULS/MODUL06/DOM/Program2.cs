using MODULS.MODUL05.PRAC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MODULS.MODUL06.DOM
{
    public interface IReportBuilder
    {
        void SetHeader(string header);
        void SetContent(string content);
        void SetFooter(string footer);
        Report GetReport();
    }
    public class TextReportBuilder : IReportBuilder
    {
        private Report _report;

        public TextReportBuilder()
        {
            _report = new Report();
        }

        public void SetHeader(string header)
        {
            _report.Header = header;
        }

        public void SetContent(string content)
        {
            _report.Content = content;
        }

        public void SetFooter(string footer)
        {
            _report.Footer = footer;
        }

        public Report GetReport()
        {
            return _report;
        }
    }
    public class HtmlReportBuilder : IReportBuilder
    {
        private Report _report;

        public HtmlReportBuilder()
        {
            _report = new Report();
        }

        public void SetHeader(string header)
        {
            _report.Header = $"<h1>{header}</h1>";
        }

        public void SetContent(string content)
        {
            _report.Content = $"<p>{content}</p>";
        }

        public void SetFooter(string footer)
        {
            _report.Footer = $"<footer>{footer}</footer>";
        }

        public Report GetReport()
        {
            return _report;
        }
    }
    public class Report
    {
        public string Header { get; set; }
        public string Content { get; set; }
        public string Footer { get; set; }

        public override string ToString()
        {
            return $"{Header}\n{Content}\n{Footer}";
        }
    }
    public class ReportDirector
    {
        public void ConstructReport(IReportBuilder builder, string header, string content, string footer)
        {
            builder.SetHeader(header);
            builder.SetContent(content);
            builder.SetFooter(footer);
        }
    }

    internal class Program2
    {
        /* static void Main(string[] args)
        {
            var director = new ReportDirector();

            // Создание текстового отчета
            IReportBuilder textBuilder = new TextReportBuilder();
            director.ConstructReport(textBuilder, "Текстовый Отчет", "Это содержимое текстового отчета.", "Конец отчета");
            Report textReport = textBuilder.GetReport();
            Console.WriteLine("Текстовый Отчет:");
            Console.WriteLine(textReport.ToString());

            Console.WriteLine();

            // Создание HTML-отчета
            IReportBuilder htmlBuilder = new HtmlReportBuilder();
            director.ConstructReport(htmlBuilder, "HTML Отчет", "Это содержимое HTML отчета.", "Конец отчета");
            Report htmlReport = htmlBuilder.GetReport();
            Console.WriteLine("HTML Отчет:");
            Console.WriteLine(htmlReport.ToString());
        }*/ 
    }
}
