using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MODULS.MODUL03.PRAC
{
    public class User
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }

        public User(string name, string email, string role)
        {
            Name = name;
            Email = email;
            Role = role;
        }

        public void Update(string name, string email, string role)
        {
            Name = name;
            Email = email;
            Role = role;
        }

        public override string ToString()
        {
            return $"Имя: {Name}, Email: {Email}, Роль: {Role}";
        }
    }

    public class UserManager
    {
        private List<User> _users = new List<User>();

        public void AddUser(string name, string email, string role)
        {
            var user = new User(name, email, role);
            _users.Add(user);
            Console.WriteLine($"Пользователь {name} добавлен.");
        }

        public void RemoveUser(string email)
        {
            var user = _users.Find(u => u.Email == email);
            if (user != null)
            {
                _users.Remove(user);
                Console.WriteLine($"Пользователь {user.Name} удален.");
            }
            else
            {
                Console.WriteLine($"Пользователь с адресом электронной почты {email} не найден.");
            }
        }

        public void UpdateUser(string email, string newName, string newEmail, string newRole)
        {
            var user = _users.Find(u => u.Email == email);
            if (user != null)
            {
                user.Update(newName, newEmail, newRole);
                Console.WriteLine($"Пользователь {newName} обновлен.");
            }
            else
            {
                Console.WriteLine($"Пользователь с адресом электронной почты {email} не найден.");
            }
        }

        public void ListUsers()
        {
            Console.WriteLine("Текущие пользователи:");
            foreach (var user in _users)
            {
                Console.WriteLine(user.ToString());
            }
        }
    }
    internal class Program
    {
        /*public static void Main(string[] args)
        {
            UserManager userManager = new UserManager();

            // Добавление пользователей
            userManager.AddUser("Ernar", "Ernar@gmail.com", "Админ");
            userManager.AddUser("Maks", "Maks@gmail.com", "Пользователь");

            // Обновление пользователя
            userManager.UpdateUser("Ernar@gmail.com", "Ernar", "Ernar.updated@gmail.com", "Админ");

            // Удаление пользователя
            userManager.RemoveUser("Ernar.updated@gmail.com");

            // Вывод списка пользователей
            userManager.ListUsers();
        }*/
    }
}
