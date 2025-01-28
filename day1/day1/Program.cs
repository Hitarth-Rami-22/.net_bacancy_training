// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");
using System;
Console.WriteLine("Enter a number:");
string input = Console.ReadLine();

// Reverse the string
char[] charArray = input.ToCharArray();
Array.Reverse(charArray);
string reverse = new string(charArray);

Console.WriteLine($"Reversed (String Method): {reverse}");
