namespace cs_labs.lab10;

public class Task
{
    public static void Task2()
    {
        var dir0 = new DirectoryInfo("lab10/basedir/dir0");
        Console.WriteLine(dir0.GetFiles().Length + dir0.GetDirectories().Length);
        Console.WriteLine(String.Join(" ", dir0.GetDirectories().Select(x => x.Name)));
        Console.WriteLine(String.Join(" ", dir0.GetFiles().Where(x => x.Name.EndsWith(".txt"))));
        printAllEmptyDirs(new DirectoryInfo("lab10/basedir"));
        Console.WriteLine(new FileInfo("lab10/basedir/dir0/ёлки.txt").FullName);
    }

    public static void Task3()
    {
        Directory.CreateDirectory("lab10/basedir/Picture");
        Directory.CreateDirectory("lab10/basedir/Texts/History");
        Directory.CreateDirectory("lab10/basedir/Texts/Horror/First");

        for (int i = 1; i < 7; i++)
        {
            File.Create($"lab10/basedir/Picture/{i}.txt");
        }
        File.Move("lab10/basedir/Picture/5.txt", "lab10/basedir/Picture/5000.txt");
        File.Move("lab10/basedir/Picture/5000.txt", "basedir/Texts/History/5000.txt");
        File.Delete("lab10/basedir/Picture/6.txt");
        File.Delete($"lab10/basedir/Picture/{Console.ReadLine()}");
        Directory.Delete("lab10/basedir/Texts/Horror");
        Directory.Delete("lab10/basedir/Picture");
    }

    public static void Task4()
    {
        var nums = File.ReadAllText("lab10/basedir/data/dataset_1.txt").Split(" ").Select(s => int.Parse(s)).ToArray();
        Console.WriteLine($"{nums[0] + nums[1]} {nums[0] * nums[1]} {nums[0] + nums[1] * nums[1]}");
        Console.WriteLine(
            File
                .ReadLines("lab10/basedir/data/dataset_2.txt")
                .Select(l => int.Parse(l))
                .Count(n => (n & 1) == 0)
            );
        var file3Nums = File.ReadAllText("lab10/basedir/data/dataset_3.txt").
            Split(" ")
            .Select(s => int.Parse(n))
            .Where(n => n < 9999)
            ;
        File.OpenWrite("lab10/basedir/data/res_3.txt").Write();
    }
    
    private static void printAllEmptyDirs(DirectoryInfo root)
    {
        if (root.GetFiles().Length + root.GetDirectories().Length == 0)
        {
            Console.WriteLine(root.FullName);
            return;
        }

        foreach (var dir in root.GetDirectories())
        {
            printAllEmptyDirs(dir);
        }
        
    }
}