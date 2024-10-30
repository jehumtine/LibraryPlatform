using LibraryPlatform.Database;
using LibraryPlatform.Models;
using Microsoft.EntityFrameworkCore;

namespace LibraryPlatform.Controllers;

public class BooksService(LibraryContext libdb): IBooksService
{
    public async Task<List<Book>> GetAllBooks()
    {
        return libdb.Books.ToList();
    }

    public async Task<Book> AddBook(Book book)
    {
        await libdb.Books.AddAsync(book);
        await libdb.SaveChangesAsync();
        return book;
    }

    public async Task<Book?> GetBookById(int id)
    {
        return await libdb.Books.FirstOrDefaultAsync(x => x.Id == id)!;
    }

    public async Task<Book> EditBook(BookUpdateRequest book)
    {
        var oldBook = await libdb.Books.FirstOrDefaultAsync(x => x.Id == book.Id);
        if (book.Title != null)
        {
            oldBook.Title = book.Title;
        }else if (book.TotalCopies != null)
        {
            oldBook.TotalCopies = (int)book.TotalCopies;
        }else if (book.Author != null)
        {
            oldBook.Author = book.Author;
        }else if (book.AvailableCopies != null)
        {
            oldBook.AvailableCopies = (int)book.AvailableCopies;
        }
        await libdb.SaveChangesAsync();
        return oldBook;
    }

    public async Task<List<Book>> GetBooksByCategory(int id)
    {
        var category = await libdb.Categories.Include(x => x.Books).FirstOrDefaultAsync(x => x.Id == id);
        var books = category.Books.ToList();
        return books;
    }

    public async Task<List<Book>> GetBooksByAuthor(string name)
    {
        return await libdb.Books.Where(x => x.Author.ToLower().Contains(name)).ToListAsync();
    }

    public async Task<List<Category>> GetCategories()
    {
        return await libdb.Categories.Include(x => x.Books).ToListAsync();
    }

    public async Task<int> GetBooksBorrowedCount()
    {
        var books = await libdb.Books.ToListAsync();
        int bookBorrowedCount = 0;
        foreach (var book in books)
        {
            if (book.Status ==1)
            {
                var copiesBorrowed = book.TotalCopies - book.AvailableCopies;
                bookBorrowedCount += copiesBorrowed;    
            }
            
        }
        
        return bookBorrowedCount;
    }

    public async Task<int> GetTotalBooksCount()
    {
        
        var booksCount = await libdb.Books.CountAsync(x => x.Status ==1);
        return booksCount;
    }
}