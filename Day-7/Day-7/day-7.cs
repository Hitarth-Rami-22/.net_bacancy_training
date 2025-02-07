using System;
using System.Collections.Generic;

// Base class - LibraryItem
//here LibraryItem represents the book - 3 propertiess
public class LibraryItem
{
    public string Title { get; set; }
    public string Author { get; set; }
    public string ISBN { get; set; }

    public LibraryItem(string title, string author, string isbn)
    {
        Title = title;
        Author = author;
        ISBN = isbn;
    }
    //DisplayDetails() is a virtual method (mean can be overriden in derived)
    public virtual void DisplayDetails()
    {
        Console.WriteLine($"Title: {Title}, Author: {Author}, ISBN: {ISBN}");
    }
}

// Derived class - PrintedBook
public class PrintedBook : LibraryItem
{
    public int AvailableCopies { get; set; }

    public PrintedBook(string title, string author, string isbn, int availableCopies)
        : base(title, author, isbn)
    {
        AvailableCopies = availableCopies;
    }
    //AvailableCopies (track how many copies are available)
    public override void DisplayDetails()
    {
        base.DisplayDetails();
        Console.WriteLine($"Available Copies: {AvailableCopies}");
    }
}

// Derived class - EBook
public class EBook : LibraryItem
{
    public EBook(string title, string author, string isbn)
        : base(title, author, isbn)
    {
    }

    public override void DisplayDetails()
    {
        base.DisplayDetails();
        Console.WriteLine("EBook - No physical copies available.");
    }
}

// Abstract class - LibraryResource
public abstract class LibraryResource
{
    //cannot create an object of this class.
    public abstract string GetResourceType();//it abstract method ,must impliment by dirived class
    public void PrintLibraryInfo()
    {
        Console.WriteLine("Library Management System");
    }
}

// Interface - ILibraryOperations
//interface only defines method names not implementation
public interface ILibraryOperations
{
    void AddBook(LibraryItem book);
    void IssueBook(string isbn);
    void DisplayBooks();
}

// Class implementing interface explicitly
//Implements ILibraryOperations (use three methods )
public class LibraryManager : ILibraryOperations
{
    private List<LibraryItem> books = new List<LibraryItem>();//store books

    void ILibraryOperations.AddBook(LibraryItem book)
    {
        books.Add(book);//book to list
    }

    void ILibraryOperations.IssueBook(string isbn)
    {
        //Finds book by ISBN and issues it if it’s a PrintedBook and has copies available.
        LibraryItem book = books.Find(b => b.ISBN == isbn);
        if (book is PrintedBook printedBook && printedBook.AvailableCopies > 0)
        {
            printedBook.AvailableCopies--;
            LibraryDatabase.LogTransaction($"Book with ISBN {isbn} issued.");
        }
        else
        {
            Console.WriteLine("Book not available for issue.");
        }
    }

    void ILibraryOperations.DisplayBooks()
    {
        foreach (var book in books)
        {
            book.DisplayDetails();//Prints details of all books.
        }
    }
}

// Sealed class - LibraryDatabase
//cannot be inherited
public sealed class LibraryDatabase
{
    public static void LogTransaction(string message)// is a static method not need to create obj to use it
    {
        Console.WriteLine($"Transaction Log: {message}");
    }
}

// Partial Class - LibraryOperations (Part 1)
//here class  split into two partial definitions but acts as one.
public partial class LibraryOperations
{
    private List<LibraryItem> books = new List<LibraryItem>();

    public void AddBook(LibraryItem book)
    {
        books.Add(book);
    }

    public void IssueBook(string isbn)
    {
        LibraryItem book = books.Find(b => b.ISBN == isbn);
        if (book is PrintedBook printedBook && printedBook.AvailableCopies > 0)
        {
            printedBook.AvailableCopies--;
            LibraryDatabase.LogTransaction($"Book with ISBN {isbn} issued.");
        }
        else
        {
            Console.WriteLine("Book not available for issue.");
        }
    }
}

// Partial Class - LibraryOperations (Part 2)
public partial class LibraryOperations
{
    public void ReturnBook(string isbn)
    {
        Console.WriteLine($"Book with ISBN {isbn} returned.");
    }

    public void DisplayBooks()
    {
        foreach (var book in books)
        {
            book.DisplayDetails();
        }
    }
}

// Main Program
//create LibraryManager obj
class Program
{
    static void Main()
    {
        ILibraryOperations libraryManager = new LibraryManager();
        LibraryItem book1 = new PrintedBook("Astro Boy Omnibus Volume 1", "Osamu Tezuka", "123456", 3);
        LibraryItem book2 = new PrintedBook("Death Note Vol-1", "Tsugumi Ohba", "234567", 2);
        
        LibraryItem book3 = new EBook("Animal Farm", "George Orwell", "678901");
        LibraryItem book4 = new EBook("Alice in Wonderland", "Lewis Carroll", "890123");

        libraryManager.AddBook(book1);
        libraryManager.AddBook(book2);

        libraryManager.DisplayBooks();
        libraryManager.IssueBook("12345");
        libraryManager.IssueBook("67890");
    }
}
