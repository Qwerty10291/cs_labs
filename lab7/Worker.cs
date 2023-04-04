namespace cs_labs.lab7;

public class Worker : Person, IWorker
{
    private double salary;
    private double bonus;

    public Worker(string lastName, string firstName, DateTime dateOfBirth, char gender, double salary, double bonus) : base(lastName, firstName, dateOfBirth, gender)
    {
        this.salary = salary;
        this.bonus = bonus;
    }

    public double Salary
    {
        get { return salary; }
        set { salary = value; }
    }

    public double Bonus
    {
        get { return bonus; }
        set { bonus = value; }
    }

    public virtual double TotalSalary()
    {
        return salary + bonus * salary;
    }

    public double IncomeTax()
    {
        return TotalSalary() * 0.13;
    }

    public double NetSalary()
    {
        return TotalSalary() - IncomeTax();
    }

    public override void DisplayInfo()
    {
        base.DisplayInfo();
        Console.WriteLine($"Salary: {salary}");
        Console.WriteLine($"Bonus: {bonus}");
        Console.WriteLine($"Total Salary: {TotalSalary()}");
        Console.WriteLine($"Income Tax: {IncomeTax()}");
        Console.WriteLine($"Net Salary: {NetSalary()}");
    }

    public override void ReadInfo()
    {
        base.ReadInfo();
        Console.Write("Salary: ");
        salary = double.Parse(Console.ReadLine());
        Console.Write("Bonus: ");
        bonus = double.Parse(Console.ReadLine());
    }
}

public interface IWorker
{
    double Salary { get; set; }
    double Bonus { get; set; }
    double TotalSalary();
    double IncomeTax();
    double NetSalary();
    void DisplayInfo();
    void ReadInfo();
}