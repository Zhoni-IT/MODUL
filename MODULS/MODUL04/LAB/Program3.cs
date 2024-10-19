using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MODULS.MODUL04.LAB
{
    public interface IWorkable
    {
        void Work();
    }

    public interface IEatable
    {
        void Eat();
    }

    public interface ISleepable
    {
        void Sleep();
    }

    public class HumanWorker : IWorkable, IEatable, ISleepable
    {
        public void Work()
        {
            Console.WriteLine("Человек работает.");
        }

        public void Eat()
        {
            Console.WriteLine("Человек ест.");
        }

        public void Sleep()
        {
            Console.WriteLine("Человек спит.");
        }
    }

    public class RobotWorker : IWorkable
    {
        public void Work()
        {
            Console.WriteLine("Робот работает.");
        }

    }

    public class Program3
    {
        /* public static void Main(string[] args)
        {
            IWorkable human = new HumanWorker();
            IWorkable robot = new RobotWorker();

            human.Work();
            ((IEatable)human).Eat();
            ((ISleepable)human).Sleep();

            robot.Work();
        }*/
    }

}
