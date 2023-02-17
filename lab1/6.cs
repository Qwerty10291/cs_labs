namespace cs_labs.lab1;
using System;

public class Task6
{
    static void Main(string[] args)
    {
        double a = 0;
        double b = 0.9;
        double epsilon = 0.001;

        Console.WriteLine($"Вычисление корня уравнения lg(x^2 - 3x + 2) = 0 на отрезке [{a}, {b}] с точностью {epsilon} методом деления отрезка пополам");

        double x = BisectionMethod(a, b, epsilon);

        Console.WriteLine($"Корень уравнения: {x:F3}");
    }

    static double BisectionMethod(double a, double b, double epsilon)
    {
        if (a >= b)
        {
            throw new ArgumentException("Некорректный интервал");
        }

        double fa = f(a);
        double fb = f(b);

        if (fa * fb >= 0)
        {
            throw new ArgumentException("Функция не меняет знак на концах интервала");
        }

        while (b - a >= epsilon)
        {
            double c = (a + b) / 2;
            double fc = f(c);

            if (fc == 0)
            {
                return c;
            }
            else if (fa * fc < 0)
            {
                b = c;
                fb = fc;
            }
            else
            {
                a = c;
                fa = fc;
            }
        }

        return (a + b) / 2;
    }

    static double f(double x)
    {
        return Math.Log10(x * x - 3 * x + 2) / Math.Log10(2);
    }
}
