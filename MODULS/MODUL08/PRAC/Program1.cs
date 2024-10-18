using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MODULS.MODUL08.PRAC
{
    public interface ICommand
    {
        void Execute();
        void Undo();
    }

    public class Light
    {
        public void On() => Console.WriteLine("Свет включен");
        public void Off() => Console.WriteLine("Свет выключен");
    }

    public class AirConditioner
    {
        public void On() => Console.WriteLine("Кондиционер включен");
        public void Off() => Console.WriteLine("Кондиционер выключен");
        public void SetTemperature(int temperature) => Console.WriteLine($"Температура установлена на {temperature} градусов");
    }

    public class TV
    {
        public void On() => Console.WriteLine("Телевизор включен");
        public void Off() => Console.WriteLine("Телевизор выключен");
        public void SetChannel(int channel) => Console.WriteLine($"Канал переключен на {channel}");
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
            _light.On();
        }

        public void Undo()
        {
            _light.Off();
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
            _light.Off();
        }

        public void Undo()
        {
            _light.On();
        }
    }

    public class ACOnCommand : ICommand
    {
        private AirConditioner _ac;

        public ACOnCommand(AirConditioner ac)
        {
            _ac = ac;
        }

        public void Execute()
        {
            _ac.On();
        }

        public void Undo()
        {
            _ac.Off();
        }
    }

    public class ACOffCommand : ICommand
    {
        private AirConditioner _ac;

        public ACOffCommand(AirConditioner ac)
        {
            _ac = ac;
        }

        public void Execute()
        {
            _ac.Off();
        }

        public void Undo()
        {
            _ac.On();
        }
    }

    public class TVOnCommand : ICommand
    {
        private TV _tv;

        public TVOnCommand(TV tv)
        {
            _tv = tv;
        }

        public void Execute()
        {
            _tv.On();
        }

        public void Undo()
        {
            _tv.Off();
        }
    }

    public class TVOffCommand : ICommand
    {
        private TV _tv;

        public TVOffCommand(TV tv)
        {
            _tv = tv;
        }

        public void Execute()
        {
            _tv.Off();
        }

        public void Undo()
        {
            _tv.On();
        }
    }

    public class MacroCommand : ICommand
    {
        private List<ICommand> _commands;

        public MacroCommand(List<ICommand> commands)
        {
            _commands = commands;
        }

        public void Execute()
        {
            foreach (var command in _commands)
            {
                command.Execute();
            }
        }

        public void Undo()
        {
            foreach (var command in _commands)
            {
                command.Undo();
            }
        }
    }

    public class RemoteControl
    {
        private ICommand[] _onCommands;
        private ICommand[] _offCommands;
        private ICommand _undoCommand;

        public RemoteControl()
        {
            _onCommands = new ICommand[7];
            _offCommands = new ICommand[7];

            ICommand noCommand = new NoCommand();
            for (int i = 0; i < 7; i++)
            {
                _onCommands[i] = noCommand;
                _offCommands[i] = noCommand;
            }
            _undoCommand = noCommand;
        }

        public void SetCommand(int slot, ICommand onCommand, ICommand offCommand)
        {
            _onCommands[slot] = onCommand;
            _offCommands[slot] = offCommand;
        }

        public void OnButtonWasPushed(int slot)
        {
            _onCommands[slot].Execute();
            _undoCommand = _onCommands[slot];
        }

        public void OffButtonWasPushed(int slot)
        {
            _offCommands[slot].Execute();
            _undoCommand = _offCommands[slot];
        }

        public void UndoButtonWasPushed()
        {
            _undoCommand.Undo();
        }
    }

    public class NoCommand : ICommand
    {
        public void Execute()
        {
            Console.WriteLine("Команда не назначена.");
        }

        public void Undo()
        {
            Console.WriteLine("Команда не назначена.");
        }
    }
    internal class Program1
    {
        /* public static void Main(string[] args)
        {
            RemoteControl remoteControl = new RemoteControl();

            Light livingRoomLight = new Light();
            AirConditioner ac = new AirConditioner();
            TV tv = new TV();

            // Команды для света
            LightOnCommand livingRoomLightOn = new LightOnCommand(livingRoomLight);
            LightOffCommand livingRoomLightOff = new LightOffCommand(livingRoomLight);

            // Команды для кондиционера
            ACOnCommand acOn = new ACOnCommand(ac);
            ACOffCommand acOff = new ACOffCommand(ac);

            // Команды для телевизора
            TVOnCommand tvOn = new TVOnCommand(tv);
            TVOffCommand tvOff = new TVOffCommand(tv);

            // Назначаем команды на пульт
            remoteControl.SetCommand(0, livingRoomLightOn, livingRoomLightOff);
            remoteControl.SetCommand(1, acOn, acOff);
            remoteControl.SetCommand(2, tvOn, tvOff);

            // Тестирование выполнения команд
            remoteControl.OnButtonWasPushed(0); // Включение света
            remoteControl.OffButtonWasPushed(0); // Выключение света
            remoteControl.UndoButtonWasPushed(); // Отмена действия

            remoteControl.OnButtonWasPushed(1); // Включение кондиционера
            remoteControl.OnButtonWasPushed(2); // Включение телевизора

            // Макрокоманды
            List<ICommand> partyOn = new List<ICommand> { livingRoomLightOn, acOn, tvOn };
            MacroCommand partyMacro = new MacroCommand(partyOn);

            Console.WriteLine("\nВыполнение макрокоманды:");
            partyMacro.Execute();
            Console.WriteLine("\nОтмена макрокоманды:");
            partyMacro.Undo();
        }*/
    }
}
