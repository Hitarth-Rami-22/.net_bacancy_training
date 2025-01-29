// using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

namespace assignment_bacancy
{ 
    internal class Day_2
    {
        static void Main()
        {
            //This's my User input value
            Console.WriteLine("Enter the number of the students:--");
            int n = int.Parse(Console.ReadLine());

            //here my initiale variable
            string topStudent = "";
            double highestAverage = 0;

            Console.WriteLine("\nEnter the student details:--");

            //loop through each student name 
            //code asking for student's name
            for (int i = 0; i < n; i++)
            {
                Console.Write($"\nEnter name of student {i + 1}: ");
                string name = Console.ReadLine();

                int totalMarks = 0;
                bool allAbove70 = true;

                //get marks from user for each student
                //get each subject marks, add to totalmarks
                //here in marks are less then 70 set allabove70=false
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
                //here we are claculate the marks and display
                double average = totalMarks / 3.0;
                Console.WriteLine($"{name}- Total: {totalMarks}, {average:F2}");

                //check highest average 
                if (average > highestAverage)
                {
                    highestAverage = average;
                    topStudent = name;
                }
                //check marks above 70
                if (allAbove70)
                {
                    Console.WriteLine($"{name} second more than 70 marks in all subject!");
                }
            }
            //displaythe student name and highest average marks score
            Console.WriteLine($"\n Student with the  highest average: {topStudent} ({highestAverage:F2})");



            }

        }


    }

