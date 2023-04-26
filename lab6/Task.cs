namespace cs_labs.lab6;
using System.Text.RegularExpressions;

public class Task
{
    public static void Task1()
    {
        //a
        var regex = new Regex(@"abcd(2023)1{7}0\1");
        var s = Console.ReadLine();
        if (regex.Match(s).Success)
        {
            Console.WriteLine(s.Replace("2023", "happy new year"));
        }
        Console.WriteLine("не совпадает с abcd2023111111102023");
        // b
        regex = new Regex(@"\d+");
        var nums = regex.Matches(s).Select(x => Int64.Parse(x.Value)).ToArray();
        var maxNum = nums.Max();
        Console.WriteLine("b) сумма: {0}, максимальное: {1}, индекс максмального: {2}", nums.Sum(), nums.Max(), Array.IndexOf(nums, maxNum));
        // c
        regex = new Regex(@"[\+\-]?\d+[,\.]?\d+");
    }

}