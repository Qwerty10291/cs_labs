namespace cs_labs.lab7;


public class Task1
{
    static void Run2()
    {
        Worker worker = new Worker("Ivanov", "Ivan", new DateTime(2000, 1, 1), 'M', 1000, 0.1);
        worker.DisplayInfo();

        Console.WriteLine();

        worker.LastName = "Petrov";
        worker.FirstName = "Petr";
        worker.DateOfBirth = new DateTime(1995, 2, 3);
        worker.Gender = 'M';
        worker.Salary = 2000;
        worker.Bonus = 0.05;
        worker.DisplayInfo();

        Console.WriteLine();

        worker.ReadInfo();
        worker.DisplayInfo();
    }
    
    static void Run3()
    {
        var worker = new HourlyWorker("Ivanov", "Ivan", new DateTime(2000, 1, 1), 'M', 750, 0.1, 100);
        worker.DisplayInfo();

        Console.WriteLine();

        worker.LastName = "Petrov";
        worker.FirstName = "Petr";
        worker.DateOfBirth = new DateTime(1995, 2, 3);
        worker.Gender = 'M';
        worker.Salary = 2000;
        worker.Bonus = 0.05;
        worker.Hours = 120;
        worker.DisplayInfo();

        Console.WriteLine();

        worker.ReadInfo();
        worker.DisplayInfo();
    }

    public void Run4()
    {
    }
}