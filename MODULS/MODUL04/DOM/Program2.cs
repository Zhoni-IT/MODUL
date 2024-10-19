using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MODULS.MODUL04.DOM
{
    public class Employee
    {
        public string Name { get; set; }
        public double BaseSalary { get; set; }
        public ISalaryCalculator SalaryCalculator { get; set; }

        public double CalculateSalary()
        {
            return SalaryCalculator.CalculateSalary(BaseSalary);
        }
    }

    public interface ISalaryCalculator
    {
        double CalculateSalary(double baseSalary);
    }

    public class PermanentEmployeeSalaryCalculator : ISalaryCalculator
    {
        public double CalculateSalary(double baseSalary)
        {
            return baseSalary * 1.2;
        }
    }

    public class ContractEmployeeSalaryCalculator : ISalaryCalculator
    {
        public double CalculateSalary(double baseSalary)
        {
            return baseSalary * 1.1;
        }
    }

    public class InternEmployeeSalaryCalculator : ISalaryCalculator
    {
        public double CalculateSalary(double baseSalary)
        {
            return baseSalary * 0.8;
        }
    }

    // Новый класс для нового типа сотрудника
    public class FreelancerEmployeeSalaryCalculator : ISalaryCalculator
    {
        public double CalculateSalary(double baseSalary)
        {
            return baseSalary * 1.15;
        }
    }
    internal class Program2
    {
        /*public static void Main(string[] args)
        {
            List<Employee> employees = new List<Employee>
        {
            new Employee { Name = "Ernar", BaseSalary = 1000, SalaryCalculator = new PermanentEmployeeSalaryCalculator() },
            new Employee { Name = "Maks", BaseSalary = 1000, SalaryCalculator = new ContractEmployeeSalaryCalculator() },
            new Employee { Name = "Asia", BaseSalary = 800, SalaryCalculator = new InternEmployeeSalaryCalculator() },
            new Employee { Name = "Madi", BaseSalary = 1200, SalaryCalculator = new FreelancerEmployeeSalaryCalculator() } // Новый тип сотрудника
        };

            foreach (var employee in employees)
            {
                Console.WriteLine($"{employee.Name} получает зарплату: {employee.CalculateSalary()}");
            }
        }*/
    }
}
