namespace cs_labs.lab1;
using System;

public class Task5
{
    static void Main(string[] args)
    {
        Console.Write("Введите целое неотрицательное число: ");
        int n = int.Parse(Console.ReadLine());

        Console.WriteLine($"Простые числа в промежутке [2, {n}]:");

        for (int i = 2; i <= n; i++)
        {
            if (IsPrime(i))
            {
                Console.WriteLine(i);
            }
        }
    }

    static bool IsPrime(int number)
    {
        if (number < 2)
        {
            return false;
        }

        for (int i = 2; i <= Math.Sqrt(number); i++)
        {
            if (number % i == 0)
            {
                return false;
            }
        }

        return true;
    }
}
