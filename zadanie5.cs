using System;

class Program
{
    static void Main(string[] args)
    {
        double x = CalculateX();
        Console.WriteLine($"Значение x: {x:F3}");
    }

    static double CalculateX()
    {
        double result = 0;
        
  
        result += CalculateExpression(3);
        result += CalculateExpression(5);
        result += CalculateExpression(7);

        return result;
    }

    static double CalculateExpression(int oddNumber)
    {

        double numerator = 1 + Math.Pow(oddNumber, 2);
        double denominator = 1 + Math.Pow(oddNumber + 8, 2);
        
        return numerator / denominator;
    }
}