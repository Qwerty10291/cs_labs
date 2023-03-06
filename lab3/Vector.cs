namespace cs_labs.lab3;

using System;
using System.Linq;

public class Vector
{
    protected double[] data;

    public double[] Data
    {
        get => data;
        set => data = value;
    }

    public Vector(int n)
    {
        data = new double[n];
    }

    public Vector(params double[] data)
    {
        this.data = data;
    }
    
    public Vector(Vector other)
    {
        data = (double[])other.data.Clone();
    }

    public static Vector FromConsoleInput()
    {
        Console.WriteLine("Введите элементы вектора через пробел:");
        var input = Console.ReadLine();
        var data = input.Split().Select(double.Parse).ToArray();
        return new Vector(data);
    }

    public override string ToString()
    {
        return $"({string.Join(", ", data)})";
    }

    public double Magnitude()
    {
        return Math.Sqrt(data.Select(x => x * x).Sum());
    }

    public double Max()
    {
        return data.Max();
    }

    public int MinIndex()
    {
        return Array.IndexOf(data, data.Min());
    }

    public Vector PositiveOnly()
    {
        return new Vector(data.Where(x => x > 0).ToArray());
    }

    public static Vector Add(Vector a, Vector b)
    {
        if (a.data.Length != b.data.Length)
        {
            throw new ArgumentException("Векторы должны иметь одинаковую длину.");
        }

        var result = new Vector(a.data.Length);
        for (int i = 0; i < result.data.Length; i++)
        {
            result.data[i] = a.data[i] + b.data[i];
        }
        return result;
    }

    public static double Dot(Vector a, Vector b)
    {
        if (a.data.Length != b.data.Length)
        {
            throw new ArgumentException("Векторы должны иметь одинаковую длину.");
        }

        return a.data.Zip(b.data, (x, y) => x * y).Sum();
    }

    public static bool Equal(Vector a, Vector b)
    {
        if (a.data.Length != b.data.Length)
        {
            return false;
        }

        return a.data.SequenceEqual(b.data);
    }
}