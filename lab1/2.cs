namespace cs_labs.lab1;
using System;

public class Task2
{
    const double CHARKA_TO_LITER = 0.123;
    const double SHKALIK_TO_LITER = 0.06;

    static void Main(string[] args)
    {
        Console.Write("Введите имя первого человека: ");
        string person1Name = Console.ReadLine();
        Console.Write("Введите количество выпитых им чарок: ");
        int person1Charka = int.Parse(Console.ReadLine());

        Console.Write("Введите имя второго человека: ");
        string person2Name = Console.ReadLine();
        Console.Write("Введите количество выпитых им шкаликов: ");
        int person2Shkalik = int.Parse(Console.ReadLine());

        Console.Write("Введите имя третьего человека: ");
        string person3Name = Console.ReadLine();
        Console.Write("Введите количество выпитых им чарок: ");
        int person3Charka = int.Parse(Console.ReadLine());
        Console.Write("Введите количество выпитых им шкаликов: ");
        int person3Shkalik = int.Parse(Console.ReadLine());

        double person1Volume = ConvertToLiters(person1Charka, 0);
        double person2Volume = ConvertToLiters(0, person2Shkalik);
        double person3Volume = ConvertToLiters(person3Charka, person3Shkalik);

        Console.WriteLine($"{person1Name} выпил {person1Volume:F2} литров");
        Console.WriteLine($"{person2Name} выпил {person2Volume:F2} литров");
        Console.WriteLine($"{person3Name} выпил {person3Volume:F2} литров");

        string[] bigDrinkers = GetBigDrinkers(person1Volume, person2Volume, person3Volume);
        Console.WriteLine($"Больше 0.5 л и меньше 1 л выпили: {string.Join(", ", bigDrinkers)}");

        double totalVolume = person1Volume + person2Volume + person3Volume;
        Console.WriteLine($"Всего выпито {totalVolume:F2} литров");

        double maxVolume = Max(person1Volume, person2Volume, person3Volume);
        Console.WriteLine($"Наибольший объем выпил: {maxVolume:F2} литров");
    }

    static double ConvertToLiters(int charka, int shkalik)
    {
        return charka * CHARKA_TO_LITER + shkalik * SHKALIK_TO_LITER;
    }

    static string[] GetBigDrinkers(double volume1, double volume2, double volume3)
    {
        string[] result = new string[3];
        int count = 0;
        if (volume1 > 0.5 && volume1 < 1)
        {
            result[count] = "первый человек";
            count++;
        }
        if (volume2 > 0.5 && volume2 < 1)
        {
            result[count] = "второй человек";
            count++;
        }
        if (volume3 > 0.5 && volume3 < 1)
        {
            result[count] = "третий человек";
            count++;
        }
        Array.Resize(ref result, count);
        return result;
    }

    static double Max(double a, double b, double c)
    {
        return Math.Max(Math.Max(a, b), c);
    }
}
