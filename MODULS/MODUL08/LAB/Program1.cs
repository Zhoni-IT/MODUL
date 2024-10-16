using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MODULS.MODUL08.LAB
{
    public interface ICommand { 
        void Execute();
        void Undo();
    }
    public class Light
    {
        public void On()
        {
            Console.WriteLine("Свет включен.");
        }

        public void Off()
        {
            Console.WriteLine("Свет выключен.");
        }
    }
    public class Television
    {
        public void On()
        {
            Console.WriteLine("Телевизор включен.");
        }

        public void Off()
        {
            Console.WriteLine("Телевизор выключен.");
        }
    }
    public class Сonditioner
    {
        public void On()
        {
            Console.WriteLine("Кондиционер включен.");
        }

        public void Off()
        {
            Console.WriteLine("Кондиционер выключен.");
        }
    }


    public class LightOnCommand : ICommand
    {
        private Light _light;

        public LightOnCommand(Light light) {
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
    public class TelevisionOnCommand : ICommand{ 
        private Television _television;
        public TelevisionOnCommand(Television television)
        {
            _television = television;
        }

        public void Execute()
        {
            _television.On();
        }

        public void Undo()
        {
            _television.Off();
        }
    }
    public class TelevisionOffCommand : ICommand
    {
        private Television _television;
        public TelevisionOffCommand(Television television)
        {
            _television = television;
        }

        public void Execute()
        {
            _television.Off();
        }

        public void Undo()
        {
            _television.On();
        }
    }
    public class СonditionerOnCommand : ICommand
    {
        private Сonditioner _сonditioner;

        public СonditionerOnCommand(Сonditioner сonditioner)
        {
            _сonditioner = сonditioner;
        }
        public void Execute()
        {
            _сonditioner.On();
        }
        public void Undo()
        {
            _сonditioner.Off();
        }
    }
    public class СonditionerOffCommand : ICommand
    {
        private Сonditioner _сonditioner;

        public СonditionerOffCommand(Сonditioner сonditioner)
        {
            _сonditioner = сonditioner;
        }
        public void Execute()
        {
            _сonditioner.Off();
        }
        public void Undo()
        {
            _сonditioner.On();
        }
    }
    public class RemoteControl {
        private ICommand _onCommand;
        private ICommand _offCommand;
        public void SetCommand(ICommand onCommand, ICommand offCommand) { 
            _onCommand = onCommand;
            _offCommand = offCommand;
        }
        public void PressOnButton() {
            _onCommand.Execute();
        }
        public void PressOffButton()
        {
            _offCommand.Execute();
        }
        public void PressUndoButton() { 
            _onCommand.Undo();
        }
    }



    internal class Program1
    {
        /* static void Main(string[] args)
        {
            Light light = new Light();
            Television television = new Television();
            Сonditioner conditioner = new Сonditioner();

            ICommand lightOn = new LightOnCommand(light);
            ICommand lightOff = new LightOffCommand(light);

            ICommand tvOn = new TelevisionOnCommand(television);
            ICommand tvOff  = new TelevisionOffCommand(television);

            ICommand conditionerOn = new СonditionerOnCommand(conditioner);
            ICommand conditionerOff = new СonditionerOffCommand(conditioner);

            RemoteControl remoteControl = new RemoteControl();
            remoteControl.SetCommand(lightOn, lightOff);
            Console.WriteLine("Управление светом");
            remoteControl.PressOnButton();
            remoteControl.PressOffButton();
            remoteControl.PressUndoButton();

            remoteControl.SetCommand(tvOn, tvOff);
            Console.WriteLine("\nУправление теликом");
            remoteControl.PressOnButton();
            remoteControl.PressOffButton();
            remoteControl.PressUndoButton();

            remoteControl.SetCommand(conditionerOn, conditionerOff);
            Console.WriteLine("\nУправление кондицонером");
            remoteControl.PressOnButton();
            remoteControl.PressOffButton();
            remoteControl.PressUndoButton();
        }*/ 
    }
}
