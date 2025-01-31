// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");
using System;

public class Student
{
    public string Name;
    public int Age;
    public string Class;
    public int RollNumber;
    public string Address;

    public void Display()
    {
        Console.WriteLine("Name: " + Name);
        Console.WriteLine("Age: " + Age);
        Console.WriteLine("Class: " + Class);
        Console.WriteLine("Roll Number: " + RollNumber);
        Console.WriteLine("Address: " + Address);
        Console.WriteLine("--------------------");
    }
}