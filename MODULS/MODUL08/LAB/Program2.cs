using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MODULS.MODUL08.LAB
{
    public abstract class Beverage {
        public void PrepareRecipe()
        {
            BoilWater();
            Brew();
            PourInCup();
            AddCondiments();
        }
        private void BoilWater()
        {
            Console.WriteLine("Кипячение воды");
        }

        private void PourInCup()
        {
            Console.WriteLine("Наливание в чашку");
        }
        protected abstract void Brew();
        protected abstract void AddCondiments();
    }
    public class Tea : Beverage {
        protected override void Brew()
        {
            Console.WriteLine("Заваривание чая");
        }
        protected override void AddCondiments()
        {
            Console.WriteLine("Добавление лимона");
        }
    }
    public class Coffee : Beverage
    {
        protected override void Brew()
        {
            Console.WriteLine("Заваривание кофе");
        }
        protected override void AddCondiments()
        {
            Console.WriteLine("Добавление сливки");
        }
    }
    internal class Program2
    {
        /* static void Main(string[] args)
        {
            Beverage tea = new Tea();
            Console.WriteLine("Приготовление чая:");
            tea.PrepareRecipe();

            Console.WriteLine();

            Beverage coffee = new Coffee();
            Console.WriteLine("Приготовление кофе:");
            coffee.PrepareRecipe();

        }*/ 
    }
}
