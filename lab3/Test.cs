namespace cs_labs.lab3;

public class Test
{
    public static void Run()
    {
        // Создаем несколько векторов
        var a = new Vector(1, 2, 3);
        var b = new Vector(4, 5, 6);
        var c = new Vector(-1, 2, -3, 4, -5);

        // Выводим на экран векторы
        Console.WriteLine("a = " + a);
        Console.WriteLine("b = " + b);
        Console.WriteLine("c = " + c);

        // Вводим новый вектор с консоли
        var d = Vector.FromConsoleInput();
        Console.WriteLine("d = " + d);

        // Выводим на экран модули векторов
        Console.WriteLine("|a| = " + a.Magnitude());
        Console.WriteLine("|b| = " + b.Magnitude());
        Console.WriteLine("|c| = " + c.Magnitude());
        Console.WriteLine("|d| = " + d.Magnitude());

        // Выводим на экран наибольшие элементы векторов
        Console.WriteLine("max(a) = " + a.Max());
        Console.WriteLine("max(b) = " + b.Max());
        Console.WriteLine("max(c) = " + c.Max());
        Console.WriteLine("max(d) = " + d.Max());

        // Выводим на экран индексы наименьших элементов векторов
        Console.WriteLine("minIndex(a) = " + a.MinIndex());
        Console.WriteLine("minIndex(b) = " + b.MinIndex());
        Console.WriteLine("minIndex(c) = " + c.MinIndex());
        Console.WriteLine("minIndex(d) = " + d.MinIndex());

        // Выводим на экран новые векторы, состоящие только из положительных элементов
        Console.WriteLine("positiveOnly(a) = " + a.PositiveOnly());
        Console.WriteLine("positiveOnly(b) = " + b.PositiveOnly());
        Console.WriteLine("positiveOnly(c) = " + c.PositiveOnly());
        Console.WriteLine("positiveOnly(d) = " + d.PositiveOnly());

        // Складываем векторы
        var e = Vector.Add(a, b);
        Console.WriteLine("a + b = " + e);

        // Скалярно умножаем векторы
        var f = Vector.Dot(a, b);
        Console.WriteLine("a * b = " + f);

        // Проверяем векторы на равенство
        Console.WriteLine("a == b: " + Vector.Equal(a, b));
        Console.WriteLine("a == c: " + Vector.Equal(a, c));
        Console.WriteLine("a == d: " + Vector.Equal(a, d));
        Console.WriteLine("a == a: " + Vector.Equal(a, a));
    }
}