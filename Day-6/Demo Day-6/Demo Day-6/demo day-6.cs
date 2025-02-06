using System;
using System.Collections.Generic;
using System.Reflection.Metadata;

namespace LibraryManagementSystem
{
    internal class Book
    {
        //Properties for the title, author, ISBN, and available copies of the book
        public string Title { get; }
        public string Author { get; }
        public string ISBN { get; }
        private int availableCopies;//track the available copies

        //Constructor to initialize the book details and set the available copies
        public Book(string title, string author, string isbn, int copies)
        {
            Title = title;
            Author = author;
            ISBN = isbn;
            availableCopies = copies >= 0 ? copies : throw new ArgumentException("Copies cannot be negative.");
        }

        // Method to issue a book, reducing the number of available copies
        public bool IssueBook()
        {
            if (availableCopies > 0)
            {
                availableCopies--;
                Console.WriteLine($"Issued: {Title}, Remaining Copies: {availableCopies}");
                return true;
            }
            Console.WriteLine($"No copies available: {Title}");
            return false;
        }

        //Method to return a book, increasing the number of available copies
        public void ReturnBook()
        {
            availableCopies++;
            Console.WriteLine($"Returned: {Title}, Total Copies: {availableCopies}");
        }

        //number of available copies
        public int GetAvailableCopies()
        {
            return availableCopies;
        }

        //print a message when the book object is removed from memory
        ~Book()

        {
            Console.WriteLine($"Book '{Title}' is removed from memory.");
        }
    }

    // Main class for managing the library inventory
    internal class Inventory
    {
        static void Main()
        {
            List<Book> books = new List<Book>
            {
                new Book("Astro Boy Omnibus Volume 1", "Osamu Tezuka", "123456", 3),
                new Book("Death Note Vol-1", "Tsugumi Ohba", "234567", 2),
                new Book("One Piece", "Eiichiro Oda", "345678", 4),
                new Book("Vampire Knight", "Matsuri Hino", "456789", 1),
                new Book("Skip Beat!", "Yoshiki Nakamura", "567890", 5),
                new Book("Animal Farm", "George Orwell", "678901", int.MaxValue),
                new Book("A Tale of Two Cities", "Charles Dickens", "789012", int.MaxValue),
                new Book("Alice in Wonderland", "Lewis Carroll", "890123", int.MaxValue)
            };
            //loop for the library menu
            while (true)
            {
                Console.WriteLine("\n1 AvailableCopies \n2. Issue Book\n3. Return Book\n4. Exit");
                Console.Write("Choice: ");
                //// Read user input for menu choice
                if (!int.TryParse(Console.ReadLine(), out int choice))
                {
                    Console.WriteLine("Invalid input! Enter a number.");
                    continue;
                }

                switch (choice)
                {
                    case 1://Display available books
                        Console.WriteLine("\nLibrary Books:");
                        foreach (var book in books)
                        {
                            Console.WriteLine($"{book.Title} by {book.Author}, ISBN: {book.ISBN}, Copies: {(book.GetAvailableCopies() == int.MaxValue ? "Unlimited" : book.GetAvailableCopies().ToString())}");
                        }
                        break;
                    case 2:// Issue a book
                        Console.Write("Enter book title: ");
                        string? titleToIssue = Console.ReadLine();
                        Book? bookToIssue = books.Find(b => b.Title.Equals(titleToIssue, StringComparison.OrdinalIgnoreCase));
                        if (bookToIssue != null) bookToIssue.IssueBook();
                        else Console.WriteLine("Book not found!");
                        break;
                    case 3://Return a book
                        Console.Write("Enter book title: ");
                        string? titleToReturn = Console.ReadLine();
                        Book? bookToReturn = books.Find(b => b.Title.Equals(titleToReturn, StringComparison.OrdinalIgnoreCase));
                        if (bookToReturn != null) bookToReturn.ReturnBook();
                        else Console.WriteLine("Book not found!");
                        break;
                    case 4://exit program
                        Console.WriteLine("Exiting...");
                        return;
                    default://show invalid choice in menu
                        Console.WriteLine("Invalid choice! please try again.");
                        break;
                }
            }
        }
    }
}
