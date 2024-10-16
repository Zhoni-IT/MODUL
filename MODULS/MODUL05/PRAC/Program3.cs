using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MODULS.MODUL05.PRAC
{
    // Интерфейс для всех документов
    public interface IDocument
    {
        void Open();
    }

    // Класс для отчета
    public class Report : IDocument
    {
        public void Open()
        {
            Console.WriteLine("Открыт документ: Отчет");
        }
    }

    // Класс для резюме
    public class Resume : IDocument
    {
        public void Open()
        {
            Console.WriteLine("Открыт документ: Резюме");
        }
    }

    // Класс для письма
    public class Letter : IDocument
    {
        public void Open()
        {
            Console.WriteLine("Открыт документ: Письмо");
        }
    }

    // Класс для счета
    public class Invoice : IDocument
    {
        public void Open()
        {
            Console.WriteLine("Открыт документ: Счет");
        }
    }

    // Абстрактный класс создателя документа
    public abstract class DocumentCreator
    {
        public abstract IDocument CreateDocument();
    }

    // Класс создателя для отчета
    public class ReportCreator : DocumentCreator
    {
        public override IDocument CreateDocument()
        {
            return new Report();
        }
    }

    // Класс создателя для резюме
    public class ResumeCreator : DocumentCreator
    {
        public override IDocument CreateDocument()
        {
            return new Resume();
        }
    }

    // Класс создателя для письма
    public class LetterCreator : DocumentCreator
    {
        public override IDocument CreateDocument()
        {
            return new Letter();
        }
    }

    // Класс создателя для счета
    public class InvoiceCreator : DocumentCreator
    {
        public override IDocument CreateDocument()
        {
            return new Invoice();
        }
    }

    internal class Program3
    {
        /* static void Main(string[] args)
        {
            Console.WriteLine("Выберите тип документа: 1 - Отчет, 2 - Резюме, 3 - Письмо, 4 - Счет");
            int choice = int.Parse(Console.ReadLine());

            DocumentCreator creator = null;

            switch (choice)
            {
                case 1:
                    creator = new ReportCreator();
                    break;
                case 2:
                    creator = new ResumeCreator();
                    break;
                case 3:
                    creator = new LetterCreator();
                    break;
                case 4:
                    creator = new InvoiceCreator();
                    break;
                default:
                    Console.WriteLine("Неверный выбор.");
                    return;
            }

            IDocument document = creator.CreateDocument();
            document.Open();

            Console.ReadLine();
        }*/ 
    }
}
