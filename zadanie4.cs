using System;

public class FunctionCalculator
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Введите значение x: ");
        if (double.TryParse(Console.ReadLine(), out double x))
        {
            try
            {
                double v = CalculateFunction(x);
                Console.WriteLine($"v = f(x) = {v:F3}");
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
            }
        }
        else
        {
            Console.WriteLine("Некорректный ввод. Введите числовое значение.");
        }
    }

    private static double CalculateFunction(double x)
    {

        if (Math.Abs(Math.Cos(x)) < double.Epsilon) 
        {
            throw new ArgumentException("Значение x приводит к делению на ноль.");
        }

        double v = (Math.Tan(x) + Math.Sqrt(Math.Pow(Math.Sin(x), 2) + 4)) / (Math.Pow(Math.Cos(x), 2) + 4);
        return v;
    }
}