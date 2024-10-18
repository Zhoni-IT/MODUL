using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MODULS.MODUL08.DOM
{
    // Абстрактный класс Beverage
    public abstract class Beverage
    {
        // Шаблонный метод
        public void PrepareRecipe()
        {
            BoilWater();
            Brew();
            PourInCup();
            if (CustomerWantsCondiments())
            {
                AddCondiments();
            }
        }

        protected abstract void Brew();
        protected abstract void AddCondiments();

        protected virtual bool CustomerWantsCondiments()
        {
            return true;
        }

        private void BoilWater()
        {
            Console.WriteLine("Кипятим воду.");
        }

        private void PourInCup()
        {
            Console.WriteLine("Наливаем в чашку.");
        }
    }

    // Конкретный класс Tea
    public class Tea : Beverage
    {
        protected override void Brew()
        {
            Console.WriteLine("Завариваем чай.");
        }

        protected override void AddCondiments()
        {
            Console.WriteLine("Добавляем лимон.");
        }

        protected override bool CustomerWantsCondiments()
        {
            Console.Write("Хотите добавить лимон? (y/n): ");
            string answer = Console.ReadLine();
            return answer.ToLower() == "y";
        }
    }

    // Конкретный класс Coffee
    public class Coffee : Beverage
    {
        protected override void Brew()
        {
            Console.WriteLine("Завариваем кофе.");
        }

        protected override void AddCondiments()
        {
            Console.WriteLine("Добавляем молоко и сахар.");
        }

        protected override bool CustomerWantsCondiments()
        {
            Console.Write("Хотите добавить молоко и сахар? (y/n): ");
            string answer = Console.ReadLine();
            return answer.ToLower() == "y";
        }
    }

    // Конкретный класс HotChocolate
    public class HotChocolate : Beverage
    {
        protected override void Brew()
        {
            Console.WriteLine("Готовим горячий шоколад.");
        }

        protected override void AddCondiments()
        {
            Console.WriteLine("Добавляем взбитые сливки.");
        }

        protected override bool CustomerWantsCondiments()
        {
            Console.Write("Хотите добавить взбитые сливки? (y/n): ");
            string answer = Console.ReadLine();
            return answer.ToLower() == "y";
        }
    }
    internal class Program2
    {
        /*static void Main(string[] args)
        {
            Console.WriteLine("Приготовление чая:");
            Beverage tea = new Tea();
            tea.PrepareRecipe();

            Console.WriteLine("\nПриготовление кофе:");
            Beverage coffee = new Coffee();
            coffee.PrepareRecipe();

            Console.WriteLine("\nПриготовление горячего шоколада:");
            Beverage hotChocolate = new HotChocolate();
            hotChocolate.PrepareRecipe();
        }*/
    }
}
