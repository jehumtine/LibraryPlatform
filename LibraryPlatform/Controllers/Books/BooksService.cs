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

    public async Task<ServerResponse> DeleteBook(int id)
    {
        var book = await libdb.Books.FirstOrDefaultAsync(x => x.Id == id);
        if (book == null)
        {
            return new ServerResponse
            {
                status = "Book not found",
            };    
        }
        book.Status = 0;
        await libdb.SaveChangesAsync();
        return new ServerResponse
        {
            status = "Success"
        };
    }
}