using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MODULS.MODUL09.PRAC
{
    public interface IReport
    {
        string Generate();
    }

    public class SalesReport : IReport
    {
        public string Generate()
        {
            return "Отчет по продажам: \n- Продукт 1: $100\n- Продукт 2: $200";
        }
    }

    public class UserReport : IReport
    {
        public string Generate()
        {
            return "Отчет по пользователям: \n- Пользователь 1\n- Пользователь 2";
        }
    }

    public abstract class ReportDecorator : IReport
    {
        protected IReport _report;

        public ReportDecorator(IReport report)
        {
            _report = report;
        }

        public virtual string Generate()
        {
            return _report.Generate();
        }
    }

    public class DateFilterDecorator : ReportDecorator
    {
        private DateTime _startDate;
        private DateTime _endDate;

        public DateFilterDecorator(IReport report, DateTime startDate, DateTime endDate) : base(report)
        {
            _startDate = startDate;
            _endDate = endDate;
        }

        public override string Generate()
        {
            return $"{_report.Generate()}\n(Фильтр по дате: с {_startDate.ToShortDateString()} по {_endDate.ToShortDateString()})";
        }
    }

    public class SortingDecorator : ReportDecorator
    {
        private string _sortBy;

        public SortingDecorator(IReport report, string sortBy) : base(report)
        {
            _sortBy = sortBy;
        }

        public override string Generate()
        {
            return $"{_report.Generate()}\n(Сортировка по: {_sortBy})";
        }
    }

    public class CsvExportDecorator : ReportDecorator
    {
        public CsvExportDecorator(IReport report) : base(report) { }

        public override string Generate()
        {
            return $"{_report.Generate()}\n(Экспорт в формат CSV)";
        }
    }

    public class PdfExportDecorator : ReportDecorator
    {
        public PdfExportDecorator(IReport report) : base(report) { }

        public override string Generate()
        {
            return $"{_report.Generate()}\n(Экспорт в формат PDF)";
        }
    }
    internal class Program1
    {
        /*static void Main(string[] args)
        {
            IReport report = new SalesReport();

            report = new DateFilterDecorator(report, DateTime.Now.AddMonths(-1), DateTime.Now);
            report = new SortingDecorator(report, "Сумма продажи");

            report = new CsvExportDecorator(report);
            report = new PdfExportDecorator(report);

            Console.WriteLine(report.Generate());
        }*/
    }
}
