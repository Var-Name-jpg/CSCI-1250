using System;

class Book
{
    public string Title;
    public double Rating;
    public bool IsRead;
}

class Program
{
    // Fixed-size array for demo purposes
    static Book[] books = new Book[100];
    static int bookCount = 0;

    static void Main()
    {
        // Seed a few books
        AddBook("Dune", 4.5, true);
        AddBook("The Hobbit", 5.0, true);
        AddBook("War and Peace", 0.0, false);
        AddBook("Neuromancer", 0.0, false);

        bool running = true;
        while (running)
        {
            Console.WriteLine("\nBook TBR List");
            Console.WriteLine("1. Add book");
            Console.WriteLine("2. Print all books");
            Console.WriteLine("3. Print unread books");
            Console.WriteLine("4. Print highly rated (>=4.0)");
            Console.WriteLine("5. Show average rating");
            Console.WriteLine("6. Quit");
            Console.Write("Choose an option: ");

            string choice = Console.ReadLine();
            Console.WriteLine();

            switch (choice)
            {
                case "1":
                    AddBookFromInput();
                    break;
                case "2":
                    PrintTBR();
                    break;
                case "3":
                    PrintUnread();
                    break;
                case "4":
                    PrintHighlyRated(4.0);
                    break;
                case "5":
                    PrintAverageRating();
                    break;
                case "6":
                    running = false;
                    break;
                default:
                    Console.WriteLine("Invalid option.");
                    break;
            }
        }
    }

    // Method 1: AddBook (core add logic)
    static void AddBook(string title, double rating, bool isRead)
    {
        if (bookCount >= books.Length)
        {
            Console.WriteLine("TBR list is full.");
            return;
        }

        books[bookCount] = new Book
        {
            Title = title,
            Rating = rating,
            IsRead = isRead
        };
        bookCount++;
    }

    // Helper to read input and call AddBook
    static void AddBookFromInput()
    {
        Console.Write("Enter book title: ");
        string title = Console.ReadLine();

        Console.Write("Has it been read? (y/n): ");
        bool isRead = Console.ReadLine().Trim().ToLower() == "y";

        double rating = 0.0;
        if (isRead)
        {
            Console.Write("Enter rating (0.0 - 5.0): ");
            double.TryParse(Console.ReadLine(), out rating);
        }

        AddBook(title, rating, isRead);
        Console.WriteLine("Book added.");
    }

    // Method 2: PrintTBR (uses foreach over array slice)
    static void PrintTBR()
    {
        Console.WriteLine("Full TBR List:");
        foreach (Book b in GetCurrentBooks())
        {
            PrintBook(b);
        }
    }

    // Extra: filter unread
    static void PrintUnread()
    {
        Console.WriteLine("Unread Books:");
        foreach (Book b in GetCurrentBooks())
        {
            if (!b.IsRead)
            {
                PrintBook(b);
            }
        }
    }

    // Extra: filter highly rated
    static void PrintHighlyRated(double minRating)
    {
        Console.WriteLine($"Books rated >= {minRating}:");
        foreach (Book b in GetCurrentBooks())
        {
            if (b.IsRead && b.Rating >= minRating)
            {
                PrintBook(b);
            }
        }
    }

    // Extra: average rating using foreach
    static void PrintAverageRating()
    {
        double sum = 0.0;
        int count = 0;

        foreach (Book b in GetCurrentBooks())
        {
            if (b.IsRead)
            {
                sum += b.Rating;
                count++;
            }
        }

        if (count == 0)
        {
            Console.WriteLine("No read books to average.");
        }
        else
        {
            double avg = sum / count;
            Console.WriteLine($"Average rating of read books: {avg:F2}");
        }
    }

    // Helper: get only the filled part of the array
    static Book[] GetCurrentBooks()
    {
        Book[] current = new Book[bookCount];
        for (int i = 0; i < bookCount; i++)
        {
            current[i] = books[i];
        }
        return current;
    }

    // Helper: pretty-print a single book
    static void PrintBook(Book b)
    {
        string status = b.IsRead ? $"Read, rating {b.Rating:F1}" : "Unread";
        Console.WriteLine($"- {b.Title} [{status}]");
    }
}
