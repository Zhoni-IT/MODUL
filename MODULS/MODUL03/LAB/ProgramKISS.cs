using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MODULS.MODUL03.LAB
{
    // Избегание чрезмерного использования абстракций
    public class Calculator
    {
        public void Add(int a, int b)
        {
            Console.WriteLine(a + b);
        }
    }
    // Избегание избыточного использования шаблонов проектирования

    public class Utility
    {
        public static void DoSomething()
        {
            Console.WriteLine("Doing something...");
        }
    }

    public class Client
    {
        public void Execute()
        {
            Utility.DoSomething();
        }
    }

    internal class ProgramKISS
    {
    }
}
