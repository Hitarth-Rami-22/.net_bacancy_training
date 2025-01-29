// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");
using System;
List<int> numbers = Enumerable.Range(1, 10).ToList();

var evenNumbers = numbers.Where(n => n % 2 == 0).ToList();

var multipliedNumbers = evenNumbers.Select(n => n * 2).ToList();

int sum = multipliedNumbers.Sum();

Console.WriteLine("Original List : " + string.Join(",", numbers));
Console.WriteLine("Even Numbers : " + string.Join(",", evenNumbers));
Console.WriteLine("Multiplied Numbers : " + string.Join(",", multipliedNumbers));
Console.WriteLine("Sum of even numbers : " + sum);