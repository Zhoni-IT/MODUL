using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MOD
{
    internal class Program1
    {
        /*
        public void LogError(string message)
        {
            Console.WriteLine($"ERROR: {message}");
        }
        public void LogWarning(string message)
        {
            Console.WriteLine($"WARNING: {message}");
        }
        public void LogInfo(string message)
        {
            Console.WriteLine($"INFO: {message}");
        }
        */

        public void Log(string level, string message)
        {
            Console.WriteLine($"{level.ToUpper()}: {message}");
        }

        static void Main(string[] args)
        {
            Program1 program = new Program1();

            /*
            program.LogError("Произошла ошибка.");
            program.LogWarning("Предупреждение.");
            program.LogInfo("Информаций.");
            */

            program.Log("error", "Произошла ошибка.");
            program.Log("warning", "Предупреждение.");
            program.Log("info", "Информаций.");
        }
    }
}
