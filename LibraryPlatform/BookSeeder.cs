using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using LibraryPlatform.Database;
using LibraryPlatform.Models;
using Microsoft.EntityFrameworkCore;

public class BookSeeder
{
    private readonly LibraryContext _context;

    public BookSeeder(LibraryContext context)
    {
        _context = context;
    }

    public async Task SeedAsync()
    {
        // Seed Categories first
        if (!await _context.Categories.AnyAsync())
        {
            var categories = new List<Category>
            {
                new Category { Id = 1, Name = "Classic Literature" },
                new Category { Id = 2, Name = "Science Fiction" },
                new Category { Id = 3, Name = "Fantasy" }
            };
            await _context.Categories.AddRangeAsync(categories);
            await _context.SaveChangesAsync();

            Console.WriteLine("Categories seeded successfully.");
        }
        else
        {
            Console.WriteLine("Categories table already contains data. No seeding required.");
        }

        // Seed Books with Category IDs
        if (!await _context.Books.AnyAsync())
        {
            var books = new List<Book>
            {
                new Book { Title = "To Kill a Mockingbird", Author = "Harper Lee", ISBN = "9780061120084", PublishedDate = new DateTime(1960, 7, 11), TotalCopies = 10, AvailableCopies = 8, CategoryId = 1 },
                new Book { Title = "1984", Author = "George Orwell", ISBN = "9780451524935", PublishedDate = new DateTime(1949, 6, 8), TotalCopies = 15, AvailableCopies = 10, CategoryId = 2 },
                new Book { Title = "Pride and Prejudice", Author = "Jane Austen", ISBN = "9780141040349", PublishedDate = new DateTime(1813, 1, 28), TotalCopies = 12, AvailableCopies = 9, CategoryId = 1 },
                new Book { Title = "The Great Gatsby", Author = "F. Scott Fitzgerald", ISBN = "9780743273565", PublishedDate = new DateTime(1925, 4, 10), TotalCopies = 20, AvailableCopies = 17, CategoryId = 1 },
                new Book { Title = "Moby-Dick", Author = "Herman Melville", ISBN = "9781503280786", PublishedDate = new DateTime(1851, 10, 18), TotalCopies = 8, AvailableCopies = 5, CategoryId = 1 },
                new Book { Title = "The Catcher in the Rye", Author = "J.D. Salinger", ISBN = "9780316769488", PublishedDate = new DateTime(1951, 7, 16), TotalCopies = 18, AvailableCopies = 14, CategoryId = 1 },
                new Book { Title = "The Lord of the Rings", Author = "J.R.R. Tolkien", ISBN = "9780544003415", PublishedDate = new DateTime(1954, 7, 29), TotalCopies = 25, AvailableCopies = 22, CategoryId = 3 },
                new Book { Title = "The Chronicles of Narnia", Author = "C.S. Lewis", ISBN = "9780066238500", PublishedDate = new DateTime(1950, 10, 16), TotalCopies = 10, AvailableCopies = 7, CategoryId = 3 },
                new Book { Title = "Frankenstein", Author = "Mary Shelley", ISBN = "9780486282114", PublishedDate = new DateTime(1818, 1, 1), TotalCopies = 6, AvailableCopies = 4, CategoryId = 2 },
                new Book { Title = "Brave New World", Author = "Aldous Huxley", ISBN = "9780060850524", PublishedDate = new DateTime(1932, 1, 1), TotalCopies = 14, AvailableCopies = 11, CategoryId = 2 }
            };
            
            await _context.Books.AddRangeAsync(books);
            await _context.SaveChangesAsync();

            Console.WriteLine("Books seeded successfully.");
        }
        else
        {
            Console.WriteLine("Books table already contains data. No seeding required.");
        }
    }
}
