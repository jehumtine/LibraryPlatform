using LibraryPlatform.Models;
using Microsoft.AspNetCore.Mvc;

namespace LibraryPlatform.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BooksController(IBooksService service): ControllerBase
{
    [HttpGet("/get-all-books")]
    public async Task<List<Book>> GetAllBooks()
    {
        var books =await service.GetAllBooks();
        return books;
    }

    [HttpGet("/add-book")]
    public async Task<Book> AddBook([FromQuery] BookRequest request)
    {
        var book = new Book
        {
            Title = request.Title,
            Author = request.Author,
            ISBN = request.ISBN,
            PublishedDate = request.PublishedDate,
            TotalCopies = request.TotalCopies,
            AvailableCopies = request.AvailableCopies,
            CategoryId = request.CategoryId
        };
        return await service.AddBook(book);
    }

    [HttpPost("/get-book-by-id")]
    public async Task<Book?> GetBookById([FromQuery] int id)
    {
        var book = await service.GetBookById(id);
        return book;
    }

    [HttpPost("/edit-book")]
    public async Task<Book> EditBook([FromQuery] BookUpdateRequest book)
    {
        return await service.EditBook(book);
    }

    [HttpGet("/get-book-by-category/")]
    public async Task<List<Book>> GetBookByCategory([FromQuery] int id)
    {
        return await service.GetBooksByCategory(id);
    }
    [HttpGet("/get-book-by-author/")]
    public async Task<List<Book>> GetBookByAuthor([FromQuery] string name)
    {
        return await service.GetBooksByAuthor(name);
    }

    [HttpGet("/get-categories")]
    public async Task<List<Category>> GetCategories()
    {
        return await service.GetCategories();
    }
    [HttpGet("/delete-book")]
    public async Task<ServerResponse> DeleteBook([FromQuery] int id)
    {
        return await service.DeleteBook(id);
    }
    
}