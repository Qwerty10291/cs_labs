namespace cs_labs.lab1;

using System;

class Task1
{
    public static void Run(string[] args)
    {
        Console.Write("Введите ваше имя: ");
        string name = Console.ReadLine();

        Console.Write("Введите ваш возраст: ");
        int age = int.Parse(Console.ReadLine());

        Console.WriteLine("Привет, {0}! В следующем году вам исполнится {1} лет.", name, age + 1);

        Console.ReadKey();
    }
}