namespace cs_labs.lab1_ind;

public class Task2
{
    static void Main(string[] args)
    {

        double h1 = ReadPositiveDouble("Введите высоту первого цилиндра: ");
        double r1 = ReadPositiveDouble("Введите радиус первого цилиндра: ");
        double h2 = ReadPositiveDouble("Введите высоту второго цилиндра: ");
        double r2 = ReadPositiveDouble("Введите радиус второго цилиндра: ");
        double h3 = ReadPositiveDouble("Введите высоту третьего цилиндра: ");
        double r3 = ReadPositiveDouble("Введите радиус третьего цилиндра: ");


        double v1 = CylinderVolume(h1, r1);
        double v2 = CylinderVolume(h2, r2);
        double v3 = CylinderVolume(h3, r3);
        double s1 = CylinderSideArea(h1, r1);
        double s2 = CylinderSideArea(h2, r2);
        double s3 = CylinderSideArea(h3, r3);


        double minVolume = Math.Min(v1, Math.Min(v2, v3));
        double totalSideArea = s1 + s2 + s3;
        int countSmallVolume = (v1 < 10 ? 1 : 0) + (v2 < 10 ? 1 : 0) + (v3 < 10 ? 1 : 0);
        
        Console.WriteLine($"Наименьший объем: {minVolume:F2}");
        Console.WriteLine($"Сумма площадей боковой поверхности: {totalSideArea:F2}");
        Console.WriteLine($"Количество цилиндров с объемом менее 10: {countSmallVolume}");
        
    }
    
    static double ReadPositiveDouble(string prompt)
    {
        Console.Write(prompt);
        return double.Parse(Console.ReadLine());
    }
    
    static double CylinderVolume(double h, double r)
    {
        return Math.PI * r * r * h;
    }
    
    static double CylinderSideArea(double h, double r)
    {
        return 2 * Math.PI * r * h;
    }

}