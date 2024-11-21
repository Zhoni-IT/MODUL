 using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MODULS.MODUL10.PRAC
{
    public abstract class OrganizationComponent
    {
        public string Name { get; set; }
        public abstract decimal GetBudget();
        public abstract int GetEmployeeCount();
        public abstract void DisplayHierarchy(string indent = "");

        public virtual void Add(OrganizationComponent component) { }
        public virtual void Remove(OrganizationComponent component) { }
        public virtual OrganizationComponent FindByName(string name) => null;
    }

    public class Employee : OrganizationComponent
    {
        public string Position { get; set; }
        public decimal Salary { get; set; }

        public Employee(string name, string position, decimal salary)
        {
            Name = name;
            Position = position;
            Salary = salary;
        }

        public override decimal GetBudget() => Salary;
        public override int GetEmployeeCount() => 1;

        public override void DisplayHierarchy(string indent = "")
        {
            Console.WriteLine($"{indent}- Сотрудник: {Name}, Должность: {Position}, Зарплата: {Salary} руб.");
        }

        public override OrganizationComponent FindByName(string name) => Name == name ? this : null;
    }

    public class Department : OrganizationComponent
    {
        private readonly List<OrganizationComponent> _components = new List<OrganizationComponent>();

        public Department(string name)
        {
            Name = name;
        }

        public override decimal GetBudget()
        {
            return _components.Sum(component => component.GetBudget());
        }

        public override int GetEmployeeCount()
        {
            return _components.Sum(component => component.GetEmployeeCount());
        }

        public override void DisplayHierarchy(string indent = "")
        {
            Console.WriteLine($"{indent}Отдел: {Name}");
            foreach (var component in _components)
            {
                component.DisplayHierarchy(indent + "  ");
            }
        }

        public override void Add(OrganizationComponent component)
        {
            _components.Add(component);
        }

        public override void Remove(OrganizationComponent component)
        {
            _components.Remove(component);
        }

        public override OrganizationComponent FindByName(string name)
        {
            if (Name == name) return this;

            foreach (var component in _components)
            {
                var found = component.FindByName(name);
                if (found != null) return found;
            }

            return null;
        }

        public List<Employee> GetAllEmployees()
        {
            var employees = new List<Employee>();
            foreach (var component in _components)
            {
                if (component is Employee employee)
                {
                    employees.Add(employee);
                }
                else if (component is Department department)
                {
                    employees.AddRange(department.GetAllEmployees());
                }
            }
            return employees;
        }
    }
    internal class Program2
    {
        /*static void Main(string[] args)
        {
            var emp1 = new Employee("Иван Иванов", "Инженер", 50000);
            var emp2 = new Employee("Мария Петрова", "Менеджер", 60000);
            var emp3 = new Employee("Сергей Смирнов", "Разработчик", 70000);
            var emp4 = new Employee("Алина Попова", "Аналитик", 55000);

            var itDepartment = new Department("ИТ Отдел");
            itDepartment.Add(emp1);
            itDepartment.Add(emp3);

            var hrDepartment = new Department("Отдел кадров");
            hrDepartment.Add(emp2);
            hrDepartment.Add(emp4);

            var mainDepartment = new Department("Главный офис");
            mainDepartment.Add(itDepartment);
            mainDepartment.Add(hrDepartment);

            Console.WriteLine("Иерархия компании:");
            mainDepartment.DisplayHierarchy();

            Console.WriteLine($"\nОбщий бюджет компании: {mainDepartment.GetBudget()} руб.");

            Console.WriteLine($"\nОбщее количество сотрудников: {mainDepartment.GetEmployeeCount()}");

            string searchName = "Сергей Смирнов";
            var foundEmployee = mainDepartment.FindByName(searchName);
            if (foundEmployee != null)
            {
                Console.WriteLine($"\nСотрудник {searchName} найден:");
                foundEmployee.DisplayHierarchy();
            }
            else
            {
                Console.WriteLine($"\nСотрудник {searchName} не найден.");
            }

            Console.WriteLine("\nСписок всех сотрудников Главного офиса:");
            foreach (var employee in mainDepartment.GetAllEmployees())
            {
                Console.WriteLine($"- {employee.Name}, {employee.Position}, {employee.Salary} руб.");
            }
        }*/
    }
}
