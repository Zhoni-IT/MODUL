using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MODULS.MODUL04.DOM
{
    public interface IPrinter
    {
        void Print(string content);
    }

    public interface IScanner
    {
        void Scan(string content);
    }

    public interface IFax
    {
        void Fax(string content);
    }

    public class AllInOnePrinter : IPrinter, IScanner, IFax
    {
        public void Print(string content)
        {
            Console.WriteLine("Печать: " + content);
        }

        public void Scan(string content)
        {
            Console.WriteLine("Сканирование: " + content);
        }

        public void Fax(string content)
        {
            Console.WriteLine("Факс: " + content);
        }
    }

    public class BasicPrinter : IPrinter
    {
        public void Print(string content)
        {
            Console.WriteLine("Печать: " + content);
        }
    }

    public class SimpleScanner : IScanner
    {
        public void Scan(string content)
        {
            Console.WriteLine("Сканирование: " + content);
        }
    }
    internal class Program3
    {
        /*public static void Main(string[] args)
        {
            IPrinter basicPrinter = new BasicPrinter();
            basicPrinter.Print("Документ 1");

            IScanner simpleScanner = new SimpleScanner();
            simpleScanner.Scan("Документ 2");

            IPrinter allInOnePrinter = new AllInOnePrinter();
            allInOnePrinter.Print("Документ 3");

            ((IScanner)allInOnePrinter).Scan("Документ 4");

            ((IFax)allInOnePrinter).Fax("Документ 5");
        }*/
    }
}
