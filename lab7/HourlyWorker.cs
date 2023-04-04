namespace cs_labs.lab7;

public class HourlyWorker : Worker
{
     private int hours;

     public int Hours
     {
          get => hours;
          set  {
          if (value < 0)
               throw new ArgumentException("value must be greater than zero");
          hours = value;
          }
     }
     
     public HourlyWorker(string lastName, string firstName, DateTime dateOfBirth, char gender, double salary, double bonus, int hours) : base(lastName, firstName, dateOfBirth, gender, salary, bonus)
     {
          this.hours = hours;
     }

     public override double TotalSalary()
     {
          return hours * Salary;
     }
     
     public override void DisplayInfo()
     {
          base.DisplayInfo();
          Console.WriteLine($"Salary: {Salary}");
          Console.WriteLine($"Bonus: {Bonus}");
          Console.WriteLine($"Hours: {Hours}");
          Console.WriteLine($"Total Salary: {TotalSalary()}");
          Console.WriteLine($"Income Tax: {IncomeTax()}");
          Console.WriteLine($"Net Salary: {NetSalary()}");
     }
}