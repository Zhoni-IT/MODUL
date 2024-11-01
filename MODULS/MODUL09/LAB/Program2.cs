using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MODULS.MODUL09.LAB
{
    public interface IPaymentProcessor
    {
        void ProcessPayment(double amount);
        void RefundPayment(double amount);
    }
    public class InternalPaymentProcessor : IPaymentProcessor
    {
        public void ProcessPayment(double amount)
        {
            Console.WriteLine($"Обработка платежа на сумму {amount} через внутреннюю систему.");
        }

        public void RefundPayment(double amount)
        {
            Console.WriteLine($"Возврат платежа на сумму {amount} через внутреннюю систему.");
        }
    }

    public class ExternalPaymentSystemA
    {
        public void MakePayment(double amount)
        {
            Console.WriteLine($"Выполнение платежа на сумму {amount} через Внешнюю Платежную Систему A.");
        }

        public void MakeRefund(double amount)
        {
            Console.WriteLine($"Возврат платежа на сумму {amount} через Внешнюю Платежную Систему A.");
        }
    }

    public class ExternalPaymentSystemB
    {
        public void SendPayment(double amount)
        {
            Console.WriteLine($"Отправка платежа на сумму {amount} через Внешнюю Платежную Систему B.");
        }

        public void ProcessRefund(double amount)
        {
            Console.WriteLine($"Обработка возврата на сумму {amount} через Внешнюю Платежную Систему B.");
        }
    }
    public class PaymentAdapterA : IPaymentProcessor
    {
        private ExternalPaymentSystemA _externalSystemA;

        public PaymentAdapterA(ExternalPaymentSystemA externalSystemA)
        {
            _externalSystemA = externalSystemA;
        }

        public void ProcessPayment(double amount)
        {
            _externalSystemA.MakePayment(amount);
        }

        public void RefundPayment(double amount)
        {
            _externalSystemA.MakeRefund(amount);
        }
    }
    public class PaymentAdapterB : IPaymentProcessor
    {
        private ExternalPaymentSystemB _externalSystemB;

        public PaymentAdapterB(ExternalPaymentSystemB externalSystemB)
        {
            _externalSystemB = externalSystemB;
        }

        public void ProcessPayment(double amount)
        {
            _externalSystemB.SendPayment(amount);
        }

        public void RefundPayment(double amount)
        {
            _externalSystemB.ProcessRefund(amount);
        }
    }

    internal class Program2
    {
        /*static void Main(string[] args)
        {
            IPaymentProcessor internalProcessor = new InternalPaymentProcessor();
            internalProcessor.ProcessPayment(100.0);
            internalProcessor.RefundPayment(50.0);

            ExternalPaymentSystemA externalSystemA = new ExternalPaymentSystemA();
            IPaymentProcessor adapterA = new PaymentAdapterA(externalSystemA);
            adapterA.ProcessPayment(200.0);
            adapterA.RefundPayment(100.0);

            ExternalPaymentSystemB externalSystemB = new ExternalPaymentSystemB();
            IPaymentProcessor adapterB = new PaymentAdapterB(externalSystemB);
            adapterB.ProcessPayment(300.0);
            adapterB.RefundPayment(150.0);
        }*/

    }
}
