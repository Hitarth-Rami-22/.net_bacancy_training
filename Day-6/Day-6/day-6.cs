//Library management system
/*program to allow user to:
1.view available books
2.issue books
3.return books
4.exit the system*/

using System;
using System.Collections.Generic;

namespace Day_6
{
    internal class Book
    {
        //book properties(title,author,ISBN)
        public string Title { get; }
        public string Author { get; }
        public string ISBN { get; }
        private int availableCopies;//available copies
        private bool isEbook;

        //constructor to initialize book
        public Book(string title, string author, string isbn, int copies, bool isEbook = false)
        {
            Title = title;
            Author = author;
            ISBN = isbn;
            this.isEbook = isEbook;
            availableCopies = isEbook ? int.MaxValue : copies;//here ebook unlimited copies,physical book limited 
        }

        public void DisplayDetails()//display book info
        {
            Console.WriteLine($"{Title} by {Author}, ISBN: {ISBN}, Copies: {(isEbook ? "Unlimited" : availableCopies.ToString())}");
        }
        //issue a book
        public bool IssueBook()
        {
            if (isEbook)
            {
                Console.WriteLine($"eBook Issued: {Title} (Unlimited Copies Available)");
                return true;
            }
            //check if a physical book is available
            if (availableCopies > 0)
            {
                availableCopies--;
                Console.WriteLine($"Issued: {Title}, Remaining Copies: {availableCopies}");
                return true;
            }
            Console.WriteLine($"No copies available: {Title}");
            return false;
        }
        //returns a book
        public void ReturnBook()
        {
            if (isEbook)
            {
                Console.WriteLine($"eBook '{Title}' doesn't need to be returned.");
                return;
            }
            availableCopies++;
            Console.WriteLine($"Returned: {Title}, Total Copies: {availableCopies}");
        }
    }

    internal class Library
    {
        //list to store book in the library
        private List<Book> books = new List<Book>();

        //adds a book to the library
        public void AddBook(Book book)
        {
            books.Add(book);
        }
        //display all books available i the library
        public void DisplayBooks()
        {
            Console.WriteLine("\nLibrary Books:");
            foreach (var book in books)
            {
                book.DisplayDetails();
            }
        }
        //book searching.......
        public Book? FindBook(string? title)
        {
            if (string.IsNullOrWhiteSpace(title))
            {
                return null;
            }
            //find the book
            return books.Find(b => b.Title.Equals(title, StringComparison.OrdinalIgnoreCase));
        }
    }

    internal class Program
    {
        static void Main()
        {
            Library library = new Library();

            // Adding Physical Books
            library.AddBook(new Book("Astro Boy Omnibus Volume 1", "Osamu Tezuka", "123456", 3));
            library.AddBook(new Book("Death Note Vol-1", "Tsugumi Ohba", "234567", 2));
            library.AddBook(new Book("One Piece", "Eiichiro Oda", "345678", 4));
            library.AddBook(new Book("Vampire Knight", "Matsuri Hino", "456789", 1));
            library.AddBook(new Book("Skip Beat!", "Yoshiki Nakamura", "567890", 5));

            // Adding eBooks
            library.AddBook(new Book("Animal Farm", "George Orwell", "678901", 0, true));
            library.AddBook(new Book("A Tale of Two Cities", "Charles Dickens", "789012", 0, true));
            library.AddBook(new Book("Alice in Wonderland", "Lewis Carroll", "890123", 0, true));

            while (true)//infinite loop
            {
                //display menu
                Console.WriteLine("\n1. Display Books\n2. Issue Book\n3. Return Book\n4. Exit");
                Console.Write("Choice: ");
                //valide input
                if (!int.TryParse(Console.ReadLine(), out int choice))
                {
                    Console.WriteLine("Invalid input! Enter a number.");
                    continue;
                }
                //handling user choices
                //process user input 
                switch (choice)
                {
                    case 1:
                        //display
                        library.DisplayBooks();
                        break;
                    case 2:
                        //issue bok
                        Console.Write("Enter book title: ");
                        string? titleToIssue = Console.ReadLine();
                        Book? bookToIssue = library.FindBook(titleToIssue);
                        if (bookToIssue != null) bookToIssue.IssueBook();
                        else Console.WriteLine("Book not found!");
                        break;
                    case 3:
                        //return book
                        Console.Write("Enter book title: ");
                        string? titleToReturn = Console.ReadLine();
                        Book? bookToReturn = library.FindBook(titleToReturn);
                        if (bookToReturn != null) bookToReturn.ReturnBook();
                        else Console.WriteLine("Book not found!");
                        break;
                    case 4:
                        //exit program
                        Console.WriteLine("Exiting...");
                        return;
                    default:
                        Console.WriteLine("Invalid choice! Try again.");
                        break;
                }
            }
        }
    }
}
