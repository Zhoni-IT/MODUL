using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MODULS.MODUL03.DOM
{
    public enum LogLevel
    {
        Error,
        Warning,
        Info
    }

    public class Logger
    {
        public void LogMessage(LogLevel level, string message)
        {
            Console.WriteLine($"{level.ToString().ToUpper()}: {message}");
        }

        public void LogError(string message)
        {
            LogMessage(LogLevel.Error, message);
        }

        public void LogWarning(string message)
        {
            LogMessage(LogLevel.Warning, message);
        }

        public void LogInfo(string message)
        {
            LogMessage(LogLevel.Info, message);
        }
    }

    internal class ProgramDRY1
    {
        /*static void Main(string[] args)
        {
            Logger logger = new Logger();

            logger.LogError("Произошла ошибка в системе");
            logger.LogWarning("Внимание: возможна ошибка");
            logger.LogInfo("Информационное сообщение");

            Console.ReadLine();
        }*/
    }
}
