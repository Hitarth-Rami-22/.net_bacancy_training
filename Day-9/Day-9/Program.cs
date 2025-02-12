// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");
using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        List<Student> students = GetStudents();

        //get student who have more than 80 marks
        var topStudents = students.Where(s => s.Marks > 80).ToList();
        Console.WriteLine("Student with more than 80 marks:");
        foreach (var student in topStudents)
            Console.WriteLine($"{student.Name} - {student.Marks}");
        Console.WriteLine("\n----------------------------------------\n");

        //retriive student names along with their subjects
        var studentSubject = students.Select(s => new { s.Name, s.Subjects }).ToList();
        Console.WriteLine("Student Name and Subjects:");
        foreach (var student in studentSubject)
            Console.WriteLine($"{student.Name}: {string.Join(",", student.Subjects)}");
        Console.WriteLine("\n----------------------------------------\n");

        //retrive all subjects as a flat list
        //distinct for dont'repeat subject
        var allSubjects = students.SelectMany(s => s.Subjects).Distinct().ToList();
        Console.WriteLine("All unique subjects:");
        Console.WriteLine(string.Join(",", allSubjects));
        Console.WriteLine("\n----------------------------------------\n");

        //get students orderes by marks descending then by name
        //thenby for desending marks & thenby assending name
        var sortedStudents = students.OrderByDescending(s => s.Marks).ThenBy(s => s.Name).ToList();
        Console.WriteLine("Students Ordered by Marks (Descending) then name");
        foreach (var s in sortedStudents)
            Console.WriteLine($"{s.Name} {s.Marks}");
        Console.WriteLine("\n----------------------------------------\n");

        //find total, average, min, max marks
        var totalMarks = students.Sum(s => s.Marks ?? 0);
        var averageMarks = students.Average(s => s.Marks ?? 0);
        var minMarks = students.Min(s => s.Marks ?? int.MaxValue);
        var maxMarks = students.Max(s => s.Marks ?? int.MinValue);

        Console.WriteLine($"Total Marks: {totalMarks}");
        Console.WriteLine($"Average Marks: {averageMarks}");
        Console.WriteLine($"Minimum Marks: {minMarks}");
        Console.WriteLine($"Maximum Marks: {maxMarks}");
        Console.WriteLine("\n---------------------------------------\n");

        //Retrieve students grouped by marks range (0-40, 41-80, 81-100)
        var groupedStudents = students.GroupBy(s => s.Marks <= 40 ? "0-40" : s.Marks <= 80 ? "41-80" : " 81-100");//? ternery operation
        Console.WriteLine("Students grouped by Marks range:");
        foreach (var group in groupedStudents)
        {
            Console.WriteLine($"{group.Key}: {string.Join(", ", group.Select(s => s.Name))}");
        }
        Console.WriteLine("\n----------------------------------------\n");

        //Get names of students who have at least one subject
        var studentsWithSubjects = students.Where(s => s.Subjects.Any()).Select(s => s.Name).ToList();//s.Sub.Any() if students has at least one sub in subjects list
        Console.WriteLine("Students with at least one subject:");
        Console.WriteLine(string.Join(",", studentsWithSubjects));
        Console.WriteLine("\n----------------------------------------\n");

        //get students who haven't recived marks (handeling nullable values)
        var studentsWithoutMarks = students.Where(s => !s.Marks.HasValue).ToList();//hasvalue check (true if not null)
        Console.WriteLine("Students without marks");
        foreach (var s in studentsWithoutMarks)
            Console.WriteLine(s.Name);
        Console.WriteLine("\n----------------------------------------\n");

        //Find the highst mark obtained in each subject 
        var highestMarksPerSubject = students
            .SelectMany(s => s.Subjects, (s, subject) => new { subject, s.Marks })//Flattens the list of subjects for all students
            .GroupBy(x => x.subject)//Groups the data by subject.
            .Select(g => new { Subject = g.Key, MaxMark = g.Max(x => x.Marks ?? 0) })// Finds the highest mark in that subject
            .ToList();
        Console.WriteLine("Highest marks per subject:");
        foreach (var s in highestMarksPerSubject)
            Console.WriteLine($"{s.Subject}: {s.MaxMark}");
        Console.WriteLine("\n-----------------------------------------\n");


        //get the count of students in each subject
        var studentContPerSubject = students
            .SelectMany(s => s.Subjects, (s, subject) => subject)
            .GroupBy(subject => subject)
            .Select(g => new{ Subject = g.Key, Count = g.Count()})
            .ToList();

        Console.WriteLine("Student count per subject:");
        foreach (var s in studentContPerSubject)
            Console.WriteLine($"{s.Subject}: {s.Count}");
    }
    //student list
    public static List<Student> GetStudents()//GetStudents() method returns a List<Student>, which contains multiple students as objects
    {
             return new List<Student>//groups multiple students together, allowing us to perform:

             {
                new Student { Id = 1, Name = "Alice", Marks = 85, Subjects = new List<string> { "Math", "Science" } },
                new Student { Id = 2, Name = "Bob", Marks = 70, Subjects = new List<string> { "English", "History" } },
                new Student { Id = 3, Name = "Charlie", Marks = null, Subjects = new List<string> { "Physics" } },
                new Student { Id = 4, Name = "David", Marks = 90, Subjects = new List<string> { "Math", "Biology" } },
                new Student { Id = 5, Name = "Emma", Marks = 40, Subjects = new List<string> { "Chemistry", "Geography" } },
                new Student { Id = 6, Name = "Frank", Marks = 55, Subjects = new List<string> { "Math", "Physics" } },
                new Student { Id = 7, Name = "Grace", Marks = 92, Subjects = new List<string> { "Biology", "History" } },
                new Student { Id = 8, Name = "Hannah", Marks = null, Subjects = new List<string> { "English" } },
                new Student { Id = 9, Name = "Ivy", Marks = 76, Subjects = new List<string> { "Math", "Geography" } },
                new Student { Id = 10, Name = "Jake", Marks = 81, Subjects = new List<string> { "Chemistry", "Biology" } }
            };
    }        
}
    //student class
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }    
        public  int? Marks { get; set; }
        public List<string> Subjects { get; set; }
    }
