using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Add a new student (Name, Age, Class, Roll Number, Address)
//View all students
//Search student by Name or Roll Number
//Update student details

namespace Student_Management
{
    internal class Student_Management
    {
     
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

    }
}
