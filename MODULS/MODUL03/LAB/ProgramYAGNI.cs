using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MODULS.MODUL03.LAB
{
    // Избыточное создание абстракций
    public class Circle
    {
        private double _radius;

        public Circle(double radius)
        {
            _radius = radius;
        }

        public double CalculateArea()
        {
            return Math.PI * _radius * _radius;
        }
    }

    public class Square
    {
        private double _side;

        public Square(double side)
        {
            _side = side;
        }

        public double CalculateArea()
        {
            return _side * _side;
        }
    }

    // Излишняя параметризация методов
    public class MathOperations
    {
        public int Add(int a, int b)
        {
            return a + b;
        }
    }

    internal class ProgramYAGNI
    {
    }
}
