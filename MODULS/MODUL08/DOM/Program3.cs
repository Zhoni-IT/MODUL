using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MODULS.MODUL08.DOM
{
    // Интерфейс для посредника
    public interface IMediator
    {
        void RegisterUser(User user);
        void SendMessage(string message, User sender, User receiver = null);
    }

    // Класс ChatRoom как конкретный посредник
    public class ChatRoom : IMediator
    {
        private List<User> _users = new List<User>();

        public void RegisterUser(User user)
        {
            _users.Add(user);
            user.SetMediator(this);
            NotifyAllUsers($"{user.Name} присоединился к чату.");
        }

        public void SendMessage(string message, User sender, User receiver = null)
        {
            if (receiver == null)
            {
                foreach (var user in _users)
                {
                    if (user != sender)
                    {
                        user.ReceiveMessage(message);
                    }
                }
            }
            else
            {
                receiver.ReceiveMessage($"Личное сообщение от {sender.Name}: {message}");
            }
        }

        private void NotifyAllUsers(string message)
        {
            foreach (var user in _users)
            {
                user.ReceiveMessage(message);
            }
        }
    }

    // Класс User
    public abstract class User
    {
        protected IMediator _mediator;
        public string Name { get; private set; }

        protected User(string name)
        {
            Name = name;
        }

        public void SetMediator(IMediator mediator)
        {
            _mediator = mediator;
        }

        public abstract void SendMessage(string message, User receiver = null);
        public abstract void ReceiveMessage(string message);
    }

    // Конкретный класс пользователя
    public class NormalUser : User
    {
        public NormalUser(string name) : base(name) { }

        public override void SendMessage(string message, User receiver = null)
        {
            Console.WriteLine($"{Name} отправляет сообщение: {message}");
            _mediator.SendMessage(message, this, receiver);
        }

        public override void ReceiveMessage(string message)
        {
            Console.WriteLine($"{Name} получил сообщение: {message}");
        }
    }
    internal class Program3
    {
        /*static void Main(string[] args)
        {
            ChatRoom chatRoom = new ChatRoom();

            User user1 = new NormalUser("Ернар");
            User user2 = new NormalUser("Макс");
            User user3 = new NormalUser("Асия");

            chatRoom.RegisterUser(user1);
            chatRoom.RegisterUser(user2);
            chatRoom.RegisterUser(user3);

            // Обмен сообщениями
            user1.SendMessage("Привет всем!");
            user2.SendMessage("Привет, Ернар!");
            user3.SendMessage("Как дела, ребята?");
            user2.SendMessage("Это личное сообщение", user1);
        }*/
    }
}
