using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MODULS.MODUL09.DOM
{
    public abstract class Beverage
    {
        public abstract string GetDescription();
        public abstract double Cost();
    }

    public class Espresso : Beverage
    {
        public override string GetDescription() => "Эспрессо";
        public override double Cost() => 1.50;
    }

    public class Tea : Beverage
    {
        public override string GetDescription() => "Чай";
        public override double Cost() => 1.00;
    }

    public class Latte : Beverage
    {
        public override string GetDescription() => "Латте";
        public override double Cost() => 2.00;
    }

    public class Mocha : Beverage
    {
        public override string GetDescription() => "Мокко";
        public override double Cost() => 2.50;
    }

    public abstract class BeverageDecorator : Beverage
    {
        protected Beverage _beverage;

        public BeverageDecorator(Beverage beverage)
        {
            _beverage = beverage;
        }

        public override string GetDescription() => _beverage.GetDescription();
        public override double Cost() => _beverage.Cost();
    }

    public class Milk : BeverageDecorator
    {
        public Milk(Beverage beverage) : base(beverage) { }

        public override string GetDescription() => _beverage.GetDescription() + ", с молоком";
        public override double Cost() => _beverage.Cost() + 0.50;
    }

    public class Sugar : BeverageDecorator
    {
        public Sugar(Beverage beverage) : base(beverage) { }

        public override string GetDescription() => _beverage.GetDescription() + ", с сахаром";
        public override double Cost() => _beverage.Cost() + 0.20;
    }

    public class WhippedCream : BeverageDecorator
    {
        public WhippedCream(Beverage beverage) : base(beverage) { }

        public override string GetDescription() => _beverage.GetDescription() + ", со взбитыми сливками";
        public override double Cost() => _beverage.Cost() + 0.70;
    }

    // Новые добавки
    public class Vanilla : BeverageDecorator
    {
        public Vanilla(Beverage beverage) : base(beverage) { }

        public override string GetDescription() => _beverage.GetDescription() + ", с ванилью";
        public override double Cost() => _beverage.Cost() + 0.60;
    }

    public class Caramel : BeverageDecorator
    {
        public Caramel(Beverage beverage) : base(beverage) { }

        public override string GetDescription() => _beverage.GetDescription() + ", с карамелью";
        public override double Cost() => _beverage.Cost() + 0.75;
    }
    internal class Program1
    {
        /*static void Main(string[] args)
        {
            Beverage beverage = new Espresso();
            beverage = new Milk(beverage);
            beverage = new Sugar(beverage);
            beverage = new WhippedCream(beverage);

            Console.WriteLine($"Описание напитка: {beverage.GetDescription()}");
            Console.WriteLine($"Итоговая стоимость: {beverage.Cost():0.00}");

            Beverage anotherBeverage = new Latte();
            anotherBeverage = new Vanilla(anotherBeverage);
            anotherBeverage = new Caramel(anotherBeverage);

            Console.WriteLine($"\nОписание напитка: {anotherBeverage.GetDescription()}");
            Console.WriteLine($"Итоговая стоимость: {anotherBeverage.Cost():0.00}");
        }*/
    }
}
