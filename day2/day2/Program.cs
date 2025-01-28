// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");

using System;
Console.WriteLine("Enter the number of the students:--");
int n = int.Parse(Console.ReadLine());

string topStudent = "";
double highestAverage = 0;

Console.WriteLine("\nEnter the student details:--");

for (int i = 0; i < n; i++)
{
    Console.Write($"\nEnter name of student {i + 1}: ");
    string name = Console.ReadLine();

    int totalMarks = 0;
    bool allAbove70 = true;

    for (int j = 1; j <= 3; j++)
    {
        Console.Write($"Enter marks for subject {j}:");
        int marks = int.Parse(Console.ReadLine());
        totalMarks += marks;

        if (marks <= 70)
        {
            allAbove70 = false;
        }

    }
    double average = totalMarks / 3.0;
    Console.WriteLine($"{name}- Total: {totalMarks}, {average:F2}");

    //check for highest average 
    if (average > highestAverage)
    {
        highestAverage = average;
        topStudent = name;
    }
    if (allAbove70)
    {
        Console.WriteLine($"{name} second more than 70 marks in all subject!");
    }
}
Console.WriteLine($"\n Student with the  highest average: {topStudent} ({highestAverage:F2})");
