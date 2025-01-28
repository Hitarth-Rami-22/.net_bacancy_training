using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace assignment_bacancy
{
    internal class Day_1

    {
        static void Main()
        {
            //input from user
            Console.WriteLine("Enter a number:");
            string input = Console.ReadLine();

          
            // Reverse the string
            char[] charArray = input.ToCharArray();
                Array.Reverse(charArray);
                string reverse = new string(charArray);

                Console.WriteLine($"Reversed (String Method): {reverse}");
                Console.WriteLine($"Reversed (String Method): {reverse}"); 
            }
        }
    }


