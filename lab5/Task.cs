using System.Runtime.InteropServices.JavaScript;
using cs_labs.lab1;

namespace cs_labs.lab5;

public class Task
{
    public static void Task1()
    {
        var names =  Console.ReadLine().Split(" ")
            .Select(x => x)
            .Where(x => x.CompareTo("Маша") < 0)
            .ToArray();
        Console.WriteLine(String.Join("\n", names));
    }

    public static void Task2()
    {
        Console.WriteLine(String.Join(" ", 
            Console.ReadLine().
                Split(" ").
                Select(x => x.Length == 4 ? "love_is": x)
            )
        );
    }

    public static void Task3()
    {
        var n = Int32.Parse(Console.ReadLine());
        var counter = 0;
        Console.WriteLine(
            Console.ReadLine().Split().Select((x) =>
            {
                counter++;
                if (counter == n)
                {
                    counter = 0;
                    return x + new String("");
                }

                return x;
            }).ToString()
        );
    }

    public static void Task4()
    {
        var words = Console.ReadLine().Split(" ");
        var minWord = new String("");
        var maxWord = new String("");
        foreach (var word in words)
        {
            if (word.Length < minWord.Length)
                minWord = word;
            else if (word.Length > maxWord.Length)
                maxWord = word;
        }
        Console.WriteLine( 
            String.Join(",", Enumerable.Range(0, minWord.Length).Select(x => minWord)) + " " + 
            String.Join(",", Enumerable.Range(0, maxWord.Length).Select(x => maxWord))
            );
    }

    public static void Task5()
    {
        var words = new HashSet<String>();
        Console.WriteLine(String.Join(" ", 
            Console.ReadLine().
                Split(" ").
                Select(x => x).
                Where(x =>
                {
                    if (words.Contains(x))
                    {
                        return false;
                    }
                    words.Add(x);
                    return true;
                })
            )
        );
    }

    public static void Task6()
    {
        
    }
}