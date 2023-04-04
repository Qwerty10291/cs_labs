namespace cs_labs.lab7;

using System;

public class Person
{
    private string lastName;
    private string firstName;
    private DateTime dateOfBirth;
    private char gender;

    public Person(string lastName, string firstName, DateTime dateOfBirth, char gender)
    {
        this.lastName = lastName;
        this.firstName = firstName;
        this.dateOfBirth = dateOfBirth;
        this.gender = gender;
    }

    public string LastName
    {
        get { return lastName; }
        set { lastName = value; }
    }

    public string FirstName
    {
        get { return firstName; }
        set { firstName = value; }
    }

    public DateTime DateOfBirth
    {
        get { return dateOfBirth; }
        set { dateOfBirth = value; }
    }

    public char Gender
    {
        get { return gender; }
        set
        {
            if (value == 'M' || value == 'F')
            {
                gender = value;
            }
            else
            {
                throw new ArgumentException("Gender must be 'M' or 'F'");
            }
        }
    }

    public int Age
    {
        get
        {
            int age = DateTime.Today.Year - dateOfBirth.Year;
            if (dateOfBirth > DateTime.Today.AddYears(-age))
            {
                age--;
            }
            return age;
        }
    }

    public virtual void DisplayInfo()
    {
        Console.WriteLine($"Name: {firstName} {lastName}");
        Console.WriteLine($"Date of Birth: {dateOfBirth.ToShortDateString()}");
        Console.WriteLine($"Gender: {gender}");
        Console.WriteLine($"Age: {Age}");
    }

    public virtual void ReadInfo()
    {
        Console.Write("Last Name: ");
        lastName = Console.ReadLine();
        Console.Write("First Name: ");
        firstName = Console.ReadLine();
        Console.Write("Date of Birth (dd/mm/yyyy): ");
        dateOfBirth = DateTime.Parse(Console.ReadLine());
        Console.Write("Gender (M/F): ");
        Gender = char.Parse(Console.ReadLine().ToUpper());
    }
}