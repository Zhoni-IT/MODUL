using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MODULS.MODUL01.LAB
{
    // Базовый класс Сотрудник
    public abstract class Employee
    {
        public string Name { get; set; }
        public int EmployeeId { get; set; }
        public string Position { get; set; }

        public Employee(string name, int employeeId, string position)
        {
            Name = name;
            EmployeeId = employeeId;
            Position = position;
        }

        public abstract double CalculateSalary();

        public virtual void DisplayEmployeeInfo()
        {
            Console.WriteLine($"Имя: {Name}, ID: {EmployeeId}, Должность: {Position}");
        }
    }

    // Класс Рабочий
    public class Worker : Employee
    {
        public double HourlyRate { get; set; }
        public int HoursWorked { get; set; }

        public Worker(string name, int employeeId, double hourlyRate, int hoursWorked)
            : base(name, employeeId, "Рабочий")
        {
            HourlyRate = hourlyRate;
            HoursWorked = hoursWorked;
        }

        public override double CalculateSalary()
        {
            return HourlyRate * HoursWorked;
        }

        public override void DisplayEmployeeInfo()
        {
            base.DisplayEmployeeInfo();
            Console.WriteLine($"Ставка за час: {HourlyRate}, Количество часов: {HoursWorked}");
            Console.WriteLine($"Зарплата: {CalculateSalary()} руб.\n");
        }
    }

    // Класс Менеджер
    public class Manager : Employee
    {
        public double FixedSalary { get; set; }
        public double Bonus { get; set; }

        public Manager(string name, int employeeId, double fixedSalary, double bonus)
            : base(name, employeeId, "Менеджер")
        {
            FixedSalary = fixedSalary;
            Bonus = bonus;
        }

        public override double CalculateSalary()
        {
            return FixedSalary + Bonus;
        }

        public override void DisplayEmployeeInfo()
        {
            base.DisplayEmployeeInfo();
            Console.WriteLine($"Фиксированная зарплата: {FixedSalary}, Премия: {Bonus}");
            Console.WriteLine($"Зарплата: {CalculateSalary()} руб.\n");
        }
    }

    // Класс для управления сотрудниками
    public class EmployeeManagement
    {
        private List<Employee> employees = new List<Employee>();

        public void AddEmployee(Employee employee)
        {
            employees.Add(employee);
        }

        public void DisplayAllEmployees()
        {
            foreach (var employee in employees)
            {
                employee.DisplayEmployeeInfo();
            }
        }
    }

    internal class Program
    {
        /*public static void Main()
        {
            EmployeeManagement employeeManagement = new EmployeeManagement();

            Worker worker1 = new Worker("Ускенбаев Даурен", 101, 500, 40);
            Worker worker2 = new Worker("Калдарбек Ернар", 102, 450, 35);

            Manager manager1 = new Manager("Закирова Асия", 201, 80000, 15000);
            Manager manager2 = new Manager("Ким Регина", 202, 75000, 20000);

            employeeManagement.AddEmployee(worker1);
            employeeManagement.AddEmployee(worker2);
            employeeManagement.AddEmployee(manager1);
            employeeManagement.AddEmployee(manager2);

            Console.WriteLine("Список сотрудников и их зарплаты:");
            employeeManagement.DisplayAllEmployees();
        }*/
    }
}
