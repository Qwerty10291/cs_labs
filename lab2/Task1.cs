namespace cs_labs.lab2;

using System;

    class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        private DateTime birthDate;
        public char Gender { get; set; }
        

        public Person(string firstName, string lastName, DateTime birthDate, char gender)
        {
            FirstName = firstName;
            LastName = lastName;
            BirthDate = birthDate;
            Gender = gender;
        }

        public Person(Person otherPerson)
        {
            FirstName = otherPerson.FirstName;
            LastName = otherPerson.LastName;
            BirthDate = otherPerson.BirthDate;
            Gender = otherPerson.Gender;
        }

        public DateTime BirthDate
        {
            get { return birthDate; }
            set
            {
                if (value > DateTime.Now)
                {
                    throw new ArgumentException("Дата рождения не может быть в будущем");
                }
                birthDate = value;
            }
        }

        public int Age
        {
            get
            {
                int age = DateTime.Now.Year - BirthDate.Year;
                if (DateTime.Now.DayOfYear < BirthDate.DayOfYear)
                {
                    age--;
                }
                return age;
            }
        }

        public override string ToString()
        {
            return $"{LastName}, {FirstName}, {BirthDate.ToShortDateString()}, {Gender}";
        }

        public void Print()
        {
            Console.WriteLine(this);
        }

        public static Person Read()
        {
            Console.WriteLine("Имя:");
            string firstName = Console.ReadLine();

            Console.WriteLine("Фамилия:");
            string lastName = Console.ReadLine();

            Console.WriteLine("Дата рождения (yyyy-MM-dd):");
            DateTime birthDate = DateTime.Parse(Console.ReadLine());

            Console.WriteLine("Пол (M/F):");
            char gender = char.Parse(Console.ReadLine());

            return new Person(firstName, lastName, birthDate, gender);
        }
        
    }


public class Task1
{
    public static void Run(string[] args)
    {
        Console.WriteLine("Введите количество людей:");
        int n = int.Parse(Console.ReadLine());

        Person[] people = new Person[n];
        for (int i = 0; i < n; i++)
        {
            Console.WriteLine($"Введите данные фигуры #{i + 1} :");
            people[i] = Person.Read();
        }

        Console.WriteLine("People:");
        foreach (Person person in people)
        {
            Console.WriteLine($"{person.LastName}, {person.FirstName.Substring(0, 1)}, {person.Age}, {person.Gender}");
        }
    }
}