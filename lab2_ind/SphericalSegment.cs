using System;
namespace cs_labs.lab2_ind;
class SphericalSegment
    {
    private string name;
    private double radius;
    private double height;

    public SphericalSegment(string name, double radius, double height)
    {
        this.name = name;
        this.radius = radius;
        this.height = height;
    }

    public SphericalSegment(double radius, double height)
    {
        this.name = "Spherical Segment";
        this.radius = radius;
        this.height = height;
    }

    public void SetName(string name)
    {
        this.name = name;
    }

    public string GetName()
    {
        return name;
    }

    public void SetRadius(double radius)
    {
        this.radius = radius;
    }

    public double GetRadius()
    {
        return radius;
    }

    public void SetHeight(double height)
    {
        this.height = height;
    }

    public double GetHeight()
    {
        return height;
    }

    public double GetSurfaceArea()
    {
        double baseArea = Math.PI * Math.Pow(radius, 2);
        double basePerimeter = 2 * Math.PI * radius;
        double capArea = baseArea * (height / radius);
        double lateralArea = basePerimeter * height;
        return capArea + lateralArea;
    }

    public double GetVolume()
    {
        double baseArea = Math.PI * Math.Pow(radius, 2);
        double volume = (1.0 / 3) * height * baseArea;
        return volume;
    }

    public void PrintInfo()
    {
        Console.WriteLine("Имя: {0}", name);
        Console.WriteLine("Радиус: {0}", radius);
        Console.WriteLine("Высота: {0}", height);
        Console.WriteLine("Площадь поверхности: {0}", GetSurfaceArea());
        Console.WriteLine("Обьем: {0}", GetVolume());
    }

    public static SphericalSegment ReadFromConsole()
    {
        Console.Write("Введите имя: ");
        string name = Console.ReadLine();

        Console.Write("Введите радиус: ");
        double radius = double.Parse(Console.ReadLine());

        Console.Write("Введите высоту: ");
        double height = double.Parse(Console.ReadLine());

        return new SphericalSegment(name, radius, height);
    }

    public SphericalSegment Resized(double factor)
    {
        return new SphericalSegment(this.name, radius * factor, height * factor);
    }

}
