namespace cs_labs.lab8;



public class Task
{

    public static void Task1()
    {
        var f1 = Math.Cos;
        var f2 = (double x) => 2 * Math.Sqrt(Math.Abs(x - 1)) + 1;
        var f3 = delegate (double x)
        {
            return -Math.Pow(x / Math.PI, 2) - 2 * x + 5 * Math.PI; 
        };
        var f5 = (double x) =>
        {
            if (x < 0)
            {
                return Math.Pow(Math.Sin(x), 2) / 2 + 1; 
            }

            return Math.Cos(x) / 2 - 1;
        };

        var funcList = new Func<double, double>[5] { f1, f2, f3, f4, f5 };
        foreach (var func in funcList)
        {
            Tabulate(-2 * Math.PI, 2 * Math.PI, Math.PI / 6, func);
        }
    }

    public static void Task2()
    {
        var fa1 = (string a) =>  a.All(x => !Char.IsUpper(x));
        var fa2 = (string a) => a.Take(a.Length / 2).SequenceEqual(a.TakeLast(a.Length / 2));
        var fb1 = (string a) => a.Length == 10;
        var fb2 = (string a) => a.Split().Where(x => x.Length == 5);
        var fc1 = (string a) => a.Split().Where(x => x.First() == 'W');
        var fc2 = (string a) => a.Split();
    }
    
    public static void Tabulate(double a, double b, double step, Func<double, double> func)
    {
        for (double x = a; x < b; x+= step)
        {
            Console.WriteLine($"{x}\t{func(x)}");
        }
    }

    public static int FilterTabulator(double a, double b, double step, Func<double, double> func, Predicate<double> filter)
    {
        int c = 0;
        for (double x = a; x <= b; x += step)
        {
            c += filter(func(x)) ? 1 : 0;
        }

        return c;
    }

    private static double f4(double x)
    {
        return Enumerable.Range(1, 100)
            .Select(k => Math.Pow(x / (Math.PI * k) - 1, 2))
            .Aggregate((d, d1) => d + d1);
    }

}