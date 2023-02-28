namespace cs_labs.lab1;
using System;

public class Task3
{
    public static void Run(string[] args)
    {
        Console.Write("Введите дату своего рождения в формате дд.мм.гггг: ");
        DateTime birthDate = DateTime.ParseExact(Console.ReadLine(), "dd.MM.yyyy", null);

        DateTime currentDate = DateTime.Now;
        int age = currentDate.Year - birthDate.Year;
        if (currentDate.Month < birthDate.Month || (currentDate.Month == birthDate.Month && currentDate.Day < birthDate.Day))
        {
            age--;
        }

        string yearsWord;
        int lastDigit = age % 10;
        if (lastDigit == 1)
        {
            yearsWord = "год";
        }
        else if (lastDigit >= 2 && lastDigit <= 4)
        {
            yearsWord = "года";
        }
        else
        {
            yearsWord = "лет";
        }

        Console.WriteLine($"Вам {age} {yearsWord}");
    }
}
