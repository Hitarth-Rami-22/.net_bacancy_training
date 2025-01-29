using System;
//using System.Collections;
using System.Collections.Generic;
using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

namespace Day__3
{
    internal class day_3
    {
        static void Main()
        {
            //here this creates a list of numbers from 1 to 10.
            List<int> numbers = Enumerable.Range(1, 10).ToList();

            //Filters out the even numbers.
            var evenNumbers = numbers.Where(n => n % 2 == 0).ToList();

            //Multiplies each even number by 2.
            var multipliedNumbers = evenNumbers.Select(n => n * 2).ToList();

            //Finds the sum of all the multiplied even numbers and
            int sum = multipliedNumbers.Sum();

           
            //Displays all the results step by step.
            //here is print list of all numbers 1 to 10.
            Console.WriteLine("Original List : " + string.Join(",", numbers));
            
            //here is print all of even number in 1 to 10.
            Console.WriteLine("Even Numbers : " + string.Join(",", evenNumbers));
            
            //here is multiplied all even number by 2.
            Console.WriteLine("Multiplied Numbers : " + string.Join(",", multipliedNumbers));
            
            //here is print all sum of even number between 1 to 10.
            Console.WriteLine("Sum of even numbers : " + sum);
        }
    }
}
