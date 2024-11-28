using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MODULS.MODUL12.DOM
{
    // Интерфейс для состояний автомата
    public interface ITicketMachineState
    {
        void SelectTicket();
        void InsertMoney(decimal amount);
        void DispenseTicket();
        void CancelTransaction();
    }

    // Контекст: автомат по продаже билетов
    public class TicketVendingMachine
    {
        public ITicketMachineState IdleState { get; private set; }
        public ITicketMachineState WaitingForMoneyState { get; private set; }
        public ITicketMachineState MoneyReceivedState { get; private set; }
        public ITicketMachineState TicketDispensedState { get; private set; }
        public ITicketMachineState TransactionCanceledState { get; private set; }

        public ITicketMachineState CurrentState { get; set; }
        public decimal Balance { get; private set; }
        public decimal TicketPrice { get; private set; }

        public TicketVendingMachine(decimal ticketPrice)
        {
            IdleState = new IdleState(this);
            WaitingForMoneyState = new WaitingForMoneyState(this);
            MoneyReceivedState = new MoneyReceivedState(this);
            TicketDispensedState = new TicketDispensedState(this);
            TransactionCanceledState = new TransactionCanceledState(this);

            CurrentState = IdleState;
            TicketPrice = ticketPrice;
            Balance = 0;
        }

        public void SetBalance(decimal amount)
        {
            Balance = amount;
        }

        public void SelectTicket() => CurrentState.SelectTicket();
        public void InsertMoney(decimal amount) => CurrentState.InsertMoney(amount);
        public void DispenseTicket() => CurrentState.DispenseTicket();
        public void CancelTransaction() => CurrentState.CancelTransaction();
    }

    // Состояние: Ожидание
    public class IdleState : ITicketMachineState
    {
        private readonly TicketVendingMachine _machine;

        public IdleState(TicketVendingMachine machine)
        {
            _machine = machine;
        }

        public void SelectTicket()
        {
            Console.WriteLine("Билет выбран. Пожалуйста, внесите деньги.");
            _machine.CurrentState = _machine.WaitingForMoneyState;
        }

        public void InsertMoney(decimal amount)
        {
            Console.WriteLine("Сначала выберите билет.");
        }

        public void DispenseTicket()
        {
            Console.WriteLine("Нет билета для выдачи.");
        }

        public void CancelTransaction()
        {
            Console.WriteLine("Нет транзакции для отмены.");
        }
    }

    // Состояние: Ожидание внесения денег
    public class WaitingForMoneyState : ITicketMachineState
    {
        private readonly TicketVendingMachine _machine;

        public WaitingForMoneyState(TicketVendingMachine machine)
        {
            _machine = machine;
        }

        public void SelectTicket()
        {
            Console.WriteLine("Билет уже выбран.");
        }

        public void InsertMoney(decimal amount)
        {
            _machine.SetBalance(amount);
            Console.WriteLine($"Внесено: {amount:C}. Проверка суммы...");
            if (_machine.Balance >= _machine.TicketPrice)
            {
                _machine.CurrentState = _machine.MoneyReceivedState;
            }
            else
            {
                Console.WriteLine("Недостаточно средств. Внесите ещё.");
            }
        }

        public void DispenseTicket()
        {
            Console.WriteLine("Сначала внесите деньги.");
        }

        public void CancelTransaction()
        {
            Console.WriteLine("Транзакция отменена. Возврат в начальное состояние.");
            _machine.CurrentState = _machine.TransactionCanceledState;
        }
    }

    // Состояние: Деньги получены
    public class MoneyReceivedState : ITicketMachineState
    {
        private readonly TicketVendingMachine _machine;

        public MoneyReceivedState(TicketVendingMachine machine)
        {
            _machine = machine;
        }

        public void SelectTicket()
        {
            Console.WriteLine("Билет уже выбран.");
        }

        public void InsertMoney(decimal amount)
        {
            Console.WriteLine("Деньги уже внесены.");
        }

        public void DispenseTicket()
        {
            Console.WriteLine("Выдача билета...");
            _machine.CurrentState = _machine.TicketDispensedState;
        }

        public void CancelTransaction()
        {
            Console.WriteLine("Транзакция отменена. Возврат денег.");
            _machine.SetBalance(0);
            _machine.CurrentState = _machine.TransactionCanceledState;
        }
    }

    // Состояние: Билет выдан
    public class TicketDispensedState : ITicketMachineState
    {
        private readonly TicketVendingMachine _machine;

        public TicketDispensedState(TicketVendingMachine machine)
        {
            _machine = machine;
        }

        public void SelectTicket()
        {
            Console.WriteLine("Операция завершена. Начните заново.");
        }

        public void InsertMoney(decimal amount)
        {
            Console.WriteLine("Операция завершена. Начните заново.");
        }

        public void DispenseTicket()
        {
            Console.WriteLine("Билет уже выдан.");
        }

        public void CancelTransaction()
        {
            Console.WriteLine("Нельзя отменить. Билет уже выдан.");
        }
    }

    // Состояние: Транзакция отменена
    public class TransactionCanceledState : ITicketMachineState
    {
        private readonly TicketVendingMachine _machine;

        public TransactionCanceledState(TicketVendingMachine machine)
        {
            _machine = machine;
        }

        public void SelectTicket()
        {
            Console.WriteLine("Начните заново. Выберите билет.");
            _machine.CurrentState = _machine.IdleState;
        }

        public void InsertMoney(decimal amount)
        {
            Console.WriteLine("Транзакция отменена. Начните заново.");
        }

        public void DispenseTicket()
        {
            Console.WriteLine("Транзакция отменена. Нет билета для выдачи.");
        }

        public void CancelTransaction()
        {
            Console.WriteLine("Транзакция уже отменена.");
        }
    }
    internal class Program2
    {
        /*static void Main()
        {
            var machine = new TicketVendingMachine(50);

            machine.SelectTicket();
            machine.InsertMoney(30);
            machine.InsertMoney(20);
            machine.DispenseTicket();
        }*/
    }
}
