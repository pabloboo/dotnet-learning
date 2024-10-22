using System;

namespace MyNamespace
{
    class Program
    {
        static void Main() // Main method is the entry point of the program
        {
            Console.WriteLine("Hello, World!");
            var p1 = new Person("Pablo", "Boo", new DateOnly(2000, 02, 15));
            var p2 = new Person("David", "Beckham", new DateOnly(1975, 05, 02));
            List<Person> people = [p1, p2];
        }
    }
}

public class Person(string firstName, string lastName, DateOnly birthday)
{
    public string FirstName { get; } = firstName;
    public string LastName { get; } = lastName;
    public DateOnly Birthday { get; } = birthday;
}