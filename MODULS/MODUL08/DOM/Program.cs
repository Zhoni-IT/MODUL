using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MODULS.MODUL08.DOM
{
    public interface ICommand
    {
        void Execute();
        void Undo();
    }
    public class Light
    {
        public void TurnOn()
        {
            Console.WriteLine("Свет включен.");
        }

        public void TurnOff()
        {
            Console.WriteLine("Свет выключен.");
        }
    }
    public class Door
    {
        public void Open()
        {
            Console.WriteLine("Дверь открыта.");
        }

        public void Close()
        {
            Console.WriteLine("Дверь закрыта.");
        }
    }

    public class Thermostat
    {
        private int temperature;

        public Thermostat(int initialTemperature)
        {
            temperature = initialTemperature;
        }

        public void IncreaseTemperature(int amount)
        {
            temperature += amount;
            Console.WriteLine($"Температура увеличена на {amount} градусов. Текущая температура: {temperature}°C.");
        }

        public void DecreaseTemperature(int amount)
        {
            temperature -= amount;
            Console.WriteLine($"Температура уменьшена на {amount} градусов. Текущая температура: {temperature}°C.");
        }
    }

    public class LightOnCommand : ICommand
    {
        private Light _light;

        public LightOnCommand(Light light)
        {
            _light = light;
        }

        public void Execute()
        {
            _light.TurnOn();
        }

        public void Undo()
        {
            _light.TurnOff();
        }
    }

    public class LightOffCommand : ICommand
    {
        private Light _light;

        public LightOffCommand(Light light)
        {
            _light = light;
        }

        public void Execute()
        {
            _light.TurnOff();
        }

        public void Undo()
        {
            _light.TurnOn();
        }
    }

    public class DoorOpenCommand : ICommand
    {
        private Door _door;

        public DoorOpenCommand(Door door)
        {
            _door = door;
        }

        public void Execute()
        {
            _door.Open();
        }

        public void Undo()
        {
            _door.Close();
        }
    }

    public class DoorCloseCommand : ICommand
    {
        private Door _door;

        public DoorCloseCommand(Door door)
        {
            _door = door;
        }

        public void Execute()
        {
            _door.Close();
        }

        public void Undo()
        {
            _door.Open();
        }
    }

    public class ThermostatIncreaseCommand : ICommand
    {
        private Thermostat _thermostat;
        private int _amount;

        public ThermostatIncreaseCommand(Thermostat thermostat, int amount)
        {
            _thermostat = thermostat;
            _amount = amount;
        }

        public void Execute()
        {
            _thermostat.IncreaseTemperature(_amount);
        }

        public void Undo()
        {
            _thermostat.DecreaseTemperature(_amount);
        }
    }

    public class ThermostatDecreaseCommand : ICommand
    {
        private Thermostat _thermostat;
        private int _amount;

        public ThermostatDecreaseCommand(Thermostat thermostat, int amount)
        {
            _thermostat = thermostat;
            _amount = amount;
        }

        public void Execute()
        {
            _thermostat.DecreaseTemperature(_amount);
        }

        public void Undo()
        {
            _thermostat.IncreaseTemperature(_amount);
        }
    }
    public class Invoker
    {
        private ICommand _lastCommand;

        public void ExecuteCommand(ICommand command)
        {
            command.Execute();
            _lastCommand = command;
        }

        public void UndoLastCommand()
        {
            if (_lastCommand != null)
            {
                _lastCommand.Undo();
            }
            else
            {
                Console.WriteLine("Нет команды для отмены.");
            }
        }
    }

    internal class Program
    {
        /* static void Main(string[] args)
        {
            Light light = new Light();
            Door door = new Door();
            Thermostat thermostat = new Thermostat(22);

            ICommand lightOn = new LightOnCommand(light);
            ICommand lightOff = new LightOffCommand(light);
            ICommand doorOpen = new DoorOpenCommand(door);
            ICommand doorClose = new DoorCloseCommand(door);
            ICommand tempIncrease = new ThermostatIncreaseCommand(thermostat, 5);
            ICommand tempDecrease = new ThermostatDecreaseCommand(thermostat, 3);

            Invoker invoker = new Invoker();

            // Выполняем команды
            invoker.ExecuteCommand(lightOn);
            invoker.ExecuteCommand(doorOpen);
            invoker.ExecuteCommand(tempIncrease);

            // Отменяем последнюю команду
            invoker.UndoLastCommand();

            // Отменяем ещё одну команду
            invoker.UndoLastCommand();
        }*/ 
    }
}
