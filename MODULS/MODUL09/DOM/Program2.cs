using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MODULS.MODUL09.DOM
{
    public interface IPaymentProcessor
    {
        void ProcessPayment(double amount);
    }

    public class PayPalPaymentProcessor : IPaymentProcessor
    {
        public void ProcessPayment(double amount)
        {
            Console.WriteLine($"Оплата на сумму {amount} выполнена через PayPal.");
        }
    }

    public class StripePaymentService
    {
        public void MakeTransaction(double totalAmount)
        {
            Console.WriteLine($"Платеж на сумму {totalAmount} выполнен через Stripe.");
        }
    }

    public class StripePaymentAdapter : IPaymentProcessor
    {
        private StripePaymentService _stripeService;

        public StripePaymentAdapter(StripePaymentService stripeService)
        {
            _stripeService = stripeService;
        }

        public void ProcessPayment(double amount)
        {
            _stripeService.MakeTransaction(amount);
        }
    }

    public class SquarePaymentService
    {
        public void CompletePayment(double paymentAmount)
        {
            Console.WriteLine($"Платеж на сумму {paymentAmount} выполнен через Square.");
        }
    }

    public class SquarePaymentAdapter : IPaymentProcessor
    {
        private SquarePaymentService _squareService;

        public SquarePaymentAdapter(SquarePaymentService squareService)
        {
            _squareService = squareService;
        }

        public void ProcessPayment(double amount)
        {
            _squareService.CompletePayment(amount);
        }
    }
    internal class Program2
    {
        /*static void Main(string[] args)
        {
            IPaymentProcessor paypalProcessor = new PayPalPaymentProcessor();
            paypalProcessor.ProcessPayment(100.0);

            StripePaymentService stripeService = new StripePaymentService();
            IPaymentProcessor stripeAdapter = new StripePaymentAdapter(stripeService);
            stripeAdapter.ProcessPayment(200.0);

            SquarePaymentService squareService = new SquarePaymentService();
            IPaymentProcessor squareAdapter = new SquarePaymentAdapter(squareService);
            squareAdapter.ProcessPayment(150.0);
        }*/
    }
}
