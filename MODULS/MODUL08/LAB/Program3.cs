using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MODULS.MODUL08.LAB
{
    public interface IMediator
    {
        void SendMessage(string message, Colleague colleague);
    }
    public abstract class Colleague
    {
        protected IMediator _mediator;

        public Colleague(IMediator mediator)
        {
            _mediator = mediator;
        }

        public abstract void ReceiveMessage(string message);
    }
    public class ChatMediator : IMediator
    {
        private List<Colleague> _colleagues;

        public ChatMediator()
        {
            _colleagues = new List<Colleague>();
        }

        public void RegisterColleague(Colleague colleague)
        {
            _colleagues.Add(colleague);
        }

        public void SendMessage(string message, Colleague sender)
        {
            foreach (var colleague in _colleagues)
            {
                if (colleague != sender)
                {
                    colleague.ReceiveMessage(message);
                }
            }
        }
    }
    public class User : Colleague
    {
        private string _name;

        public User(IMediator mediator, string name) : base(mediator)
        {
            _name = name;
        }

        public void Send(string message)
        {
            Console.WriteLine($"{_name} отправляет сообщение: {message}");
            _mediator.SendMessage(message, this);
        }

        public override void ReceiveMessage(string message)
        {
            Console.WriteLine($"{_name} получил сообщение: {message}");
        }
    }

    internal class Program3
    {
        /* static void Main(string[] args)
        {
            // Создаем посредника
            ChatMediator chatMediator = new ChatMediator();

            // Создаем участников
            User user1 = new User(chatMediator, "Ернар");
            User user2 = new User(chatMediator, "Макс");
            User user3 = new User(chatMediator, "Асия");

            // Регистрируем участников в чате
            chatMediator.RegisterColleague(user1);
            chatMediator.RegisterColleague(user2);
            chatMediator.RegisterColleague(user3);

            // Участники обмениваются сообщениями
            user1.Send("Привет всем!");
            user2.Send("Привет, Ернар!");
            user3.Send("Всем привет!");
        }*/

    }
}
