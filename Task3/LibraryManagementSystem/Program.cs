using System;
using System.Collections.Generic;

class Book
{
    public string Title { get; set; }
    public string Author { get; set; }
    public string ISBN { get; set; }
    public bool Availability { get; set; }


    public Book(string title, string author, string isbn)
    {
        Title = title;
        Author = author;
        ISBN = isbn;
        Availability = true;
    }
}

class Library
{
    private List<Book> books = new List<Book>();


    public void AddBook(Book book)
    {
        books.Add(book);
        Console.WriteLine($"Added '{book.Title}' by {book.Author} to the library.");
    }


    public void BorrowBook(string searchTerm)
    {
        Book book = books.Find(b => b.Title.Contains(searchTerm, StringComparison.OrdinalIgnoreCase) ||
                                    b.Author.Contains(searchTerm, StringComparison.OrdinalIgnoreCase));
        if (book != null && book.Availability)
        {
            book.Availability = false; // Mark as borrowed
            Console.WriteLine($"You have borrowed '{book.Title}'.");
        }
        else if (book != null)
        {
            Console.WriteLine($"Sorry, '{book.Title}' is currently not available.");
        }
        else
        {
            Console.WriteLine($"Sorry, no book found for '{searchTerm}'.");
        }
    }


    public void ReturnBook(string searchTerm)
    {
        Book book = books.Find(b => b.Title.Contains(searchTerm, StringComparison.OrdinalIgnoreCase) ||
                                    b.Author.Contains(searchTerm, StringComparison.OrdinalIgnoreCase));
        if (book != null && !book.Availability)
        {
            book.Availability = true;
            Console.WriteLine($"You have returned '{book.Title}'.");
        }
        else if (book != null)
        {
            Console.WriteLine($"'{book.Title}' is not borrowed, so it can't be returned.");
        }
        else
        {
            Console.WriteLine($"Sorry, no book found for '{searchTerm}'.");
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        Library library = new Library();

        library.AddBook(new Book("The Great Gatsby", "F. Scott Fitzgerald", "9780743273565"));
        library.AddBook(new Book("To Kill a Mockingbird", "Harper Lee", "9780061120084"));
        library.AddBook(new Book("1984", "George Orwell", "9780451524935"));


        Console.WriteLine("Searching and borrowing books...");
        library.BorrowBook("Gatsby");
        library.BorrowBook("1984");
        library.BorrowBook("Harry Potter");


        Console.WriteLine("\nReturning books...");
        library.ReturnBook("Gatsby");
        library.ReturnBook("Harry Potter");

        Console.ReadLine();
    }
}
