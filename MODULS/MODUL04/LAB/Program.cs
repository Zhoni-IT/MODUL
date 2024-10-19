using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MODULS.MODUL04.LAB
{
    public class Invoice
    {
        public int Id { get; set; }
        public List<Item> Items { get; set; } = new List<Item>();
        public double TaxRate { get; set; }
    }

    public class Item
    {
        public string Name { get; set; }
        public double Price { get; set; }
    }

    public class InvoiceCalculator
    {
        public double CalculateTotal(Invoice invoice)
        {
            double subTotal = 0;
            foreach (var item in invoice.Items)
            {
                subTotal += item.Price;
            }
            return subTotal + (subTotal * invoice.TaxRate);
        }
    }

    public class InvoiceRepository
    {
        public void SaveToDatabase(Invoice invoice)
        {
            Console.WriteLine($"Счет-фактура с ID {invoice.Id} сохранен в базу данных.");
        }
    }

    public class Program
    {
        /*public static void Main(string[] args)
        {
            Invoice invoice = new Invoice
            {
                Id = 1,
                TaxRate = 0.2
            };

            invoice.Items.Add(new Item { Name = "Товар 1", Price = 100 });
            invoice.Items.Add(new Item { Name = "Товар 2", Price = 150 });

            InvoiceCalculator calculator = new InvoiceCalculator();
            double total = calculator.CalculateTotal(invoice);
            Console.WriteLine($"Общая сумма счета-фактуры: {total}");

            InvoiceRepository repository = new InvoiceRepository();
            repository.SaveToDatabase(invoice);
        }*/
    }

}
