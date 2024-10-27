using LibraryPlatform.Models;

namespace LibraryPlatform.Controllers;

public interface IBooksService
{
    Task<List<Book>> GetAllBooks();
    Task<Book> AddBook(Book book);
    Task<Book> GetBookById(int id);
    Task<Book> EditBook(BookUpdateRequest book);
    Task<List<Book>> GetBooksByCategory(int id);
    Task<List<Book>> GetBooksByAuthor(string name);
}