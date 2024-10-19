using System;

namespace MODULS.MODUL03.DOM
{
    internal class ProgramKISS
    {
        /*static void Main(string[] args)
        {
            int[] numbers = { 1, -2, 3, 0, 4, -5 };
            ProcessNumbers(numbers);
            PrintPositiveNumbers(numbers);

            int result = Divide(10, 2);
            Console.WriteLine($"10 / 2 = {result}");

            result = Divide(10, 0);
            Console.WriteLine($"10 / 0 = {result}");
        }*/

        public static void ProcessNumbers(int[] numbers)
        {
            if (numbers == null || numbers.Length == 0) return;

            foreach (var number in numbers)
            {
                if (number > 0)
                {
                    Console.WriteLine(number);
                }
            }
        }

        public static void PrintPositiveNumbers(int[] numbers)
        {
            foreach (var number in numbers)
            {
                if (number > 0)
                {
                    Console.WriteLine(number);
                }
            }
        }

        public static int Divide(int a, int b)
        {
            if (b == 0) return 0;
            return a / b;
        }
    }
}
