using System;

internal class RectangCalculatorV2
{
    static void Main()
    {
        Console.WriteLine("Введите длину первого катета:");
        double cathetus1 = Convert.ToDouble(Console.ReadLine());

        Console.WriteLine("Введите длину второго катета:");
        double cathetus2 = Convert.ToDouble(Console.ReadLine());


        double hypotenuse = Math.Sqrt(cathetus1 * cathetus1 + cathetus2 * cathetus2);


        double median = 0.5 * Math.Sqrt(2 * (cathetus1 * cathetus1 + cathetus2 * cathetus2) - hypotenuse * hypotenuse);

        Console.WriteLine("Длина медианы, проведенной к гипотенузе: " + median);
    }
}