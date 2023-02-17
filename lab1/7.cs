namespace cs_labs.lab1;
using System;

public class Task7 {
    static void Main(string[] args) {
        Console.Write("Введите длину массива: ");
        int n = int.Parse(Console.ReadLine());

        int[] arr = new int[n];
        for (int i = 0; i < n; i++) {
            Console.Write($"Введите элемент {i+1}: ");
            arr[i] = int.Parse(Console.ReadLine());
        }

        Console.Write("Введите число для удаления: ");
        int x = int.Parse(Console.ReadLine());

        int count = 0;
        for (int i = 0; i < n; i++) {
            if (arr[i] != x) {
                arr[count++] = arr[i];
            }
        }

        Array.Resize(ref arr, count);

        Console.WriteLine("Итоговый массив:");
        foreach (int i in arr) {
            Console.Write(i + " ");
        }
    }
}
