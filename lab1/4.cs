using System;
namespace cs_labs.lab1;

class Task4
{
    public static void Run(string[] args)
    {
        int n;
        Console.Write("Введите количество чисел: ");
        n = int.Parse(Console.ReadLine());

        double[] x = ReadNums(n);
        double[] fx = new double[n];
        int inArea = 0;
        for (int i = 0; i < n; i++)
        {
            fx[i] = CalculateFx(x[i]);
            if (IsInArea(x[i], fx[i]))
            {
                inArea++;
            }
        }
        for (int i = 0; i < n; i++)
        {
            Console.WriteLine($"({x[i]},{fx[i]})");
        }
        Console.WriteLine($"количество точек в заштрихованной области:{inArea}");
        Console.ReadKey();
    }

    static double CalculateFx(double x)
    {
        double fx;
        if (x < -3)
        {
            fx = (1 + x * x) / (2 * x);
        }
        else if (x >= -3 && x < Math.PI / 4)
        {
            fx = (x * x - 3) * Math.Sin(x);
        }
        else
        {
            fx = 2 + 1.0 / 3;
        }
        return fx;
    }
    
    static double[] ReadNums(int count)
    {
        double[] x = new double[count];
        Console.WriteLine("введите {0} чисел:", count);
        for (int i = 0; i < count; i++)
        {
            x[i] = double.Parse(Console.ReadLine());
        }

        return x;
    }

    static bool IsInArea(double x, double y)
    {
        if (x >= 0 && y > 0)
        {
            return (y <= -2 * x + 4);
        } else if (x >= 0 && y <= 0)
        {
            return (x <= 2 && y >= -4);
        } else if (x < 0 && y < 0)
        {
            return (y >= -x - 4);
        }
        return x * x + y * y < 16;
    }
}