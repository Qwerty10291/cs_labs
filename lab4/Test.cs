namespace cs_labs.lab4;
using System;
public class Test
{
    public static void Run()
    {
        var arr = new DynamicArray<int>();
        arr.Append(1);
        Console.WriteLine("{0} {1} {2}", arr, arr.len, arr.capacity);
        arr.Append(2);
        Console.WriteLine("{0} {1} {2}", arr, arr.len, arr.capacity);
        arr.Append(3);
        Console.WriteLine("{0} {1} {2}", arr, arr.len, arr.capacity);
        arr.Remove(0);
        Console.WriteLine("{0} {1} {2}", arr, arr.len, arr.capacity);
        arr.Remove(val:3);
        Console.WriteLine("{0} {1} {2}", arr, arr.len, arr.capacity);
        arr.Append(4);
        arr.Append(5);
        arr.Append(6, 1);
        Console.WriteLine("{0} {1} {2}", arr, arr.len, arr.capacity);
        arr.SetValue(1, 7);
        Console.WriteLine(arr.GetValue(1));
        Console.WriteLine(arr.Max());
    }
}