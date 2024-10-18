using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static MODULS.MODUL06.LAB.OfficeComputerBuilder;

namespace MODULS.MODUL06.LAB
{
    public class Computer
    {
        public string CPU { get; set; }

        public string RAM { get; set; }

        public string HDDorSSD { get; set; }

        public string GPU { get; set; }

        public string OS { get; set; }

        public override string ToString()
        {
            return $":Компьютер CPU - {CPU}, RAM - {RAM}, HDD/SSD - {HDDorSSD}, GPU - {GPU}, OS- {OS}";
        }
    }
    public interface IComputerBuilder
    {
        void SetCPU();
        void SetRAM();
        void SetHDDorSSD();
        void SetGPU();
        void SetOS();
        Computer GetComputer();
    }
    public class OfficeComputerBuilder : IComputerBuilder
    {
        private Computer computer = new Computer();
        public void SetCPU()
        {
            computer.CPU = "Intel i3";
        }
        public void SetRAM()
        {
            computer.RAM = "8GB RAM";
        }
        public void SetHDDorSSD()
        {
            computer.HDDorSSD = "512gb HDD";
        }

        public void SetGPU()
        {
            computer.GPU = "AMD Radeon RX 500";
        }

        public void SetOS()
        {
            computer.OS = "windows 10";
        }

        public Computer GetComputer()
        {
            return computer;
        }
    }
    public class GamingComputerBuilder : IComputerBuilder
    {
        private Computer computer = new Computer();

        public void SetCPU()
        {
            computer.CPU = "Intel i9";
        }
        public void SetRAM()
        {
            computer.RAM = "32GB RAM";
        }
        public void SetHDDorSSD()
        {
            computer.HDDorSSD = "1Tb HDD";
        }

        public void SetGPU()
        {
            computer.GPU = "NVIDIA RTX 4080";
        }

        public void SetOS()
        {
            computer.OS = "windows 11";
        }

        public Computer GetComputer()
        {
            return computer;
        }

    }
    public class ComputerDirector
    {
        private IComputerBuilder _builder;

        public ComputerDirector(IComputerBuilder builder)
        {
            _builder = builder;
        }

        public void ConstructComputer()
        {
            _builder.SetCPU();
            _builder.SetRAM();
            _builder.SetHDDorSSD();
            _builder.SetGPU();
            _builder.SetOS();
        }

        public Computer GetComputer()
        {
            return _builder.GetComputer();
        }
    }
    internal class Program2
    {
        /*static void Main(string[] args)
        {
            IComputerBuilder officeBuilder = new OfficeComputerBuilder();
            ComputerDirector director = new ComputerDirector(officeBuilder);
            director.ConstructComputer();
            Computer officeComputer = director.GetComputer();
            Console.WriteLine("офисный компьютер");
            Console.WriteLine(officeComputer);

            IComputerBuilder gamingBuilder = new GamingComputerBuilder();
            director = new ComputerDirector(gamingBuilder);
            director.ConstructComputer();
            Computer gamingComputer = director.GetComputer();
            Console.WriteLine("игровой компьютер");
            Console.WriteLine(gamingComputer);

        }*/
    }
}

