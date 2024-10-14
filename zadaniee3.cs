using System;

public class NumberAnalysis
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Введите четырехзначное число:");
        int number = Convert.ToInt32(Console.ReadLine());
       
            int thousands = number / 1000;
            int hundreds = (number % 1000) / 100;
            int tens = (number % 100) / 10;
            int units = number % 10;

            Console.WriteLine("Число десятков: " + tens);
            Console.WriteLine("Число сотен: " + hundreds);
            Console.WriteLine("Сумма цифр: " + (thousands + hundreds + tens + units));
        }
        else
        {
            Console.WriteLine("Введенное число не является четырехзначным.");
        }
    }
}