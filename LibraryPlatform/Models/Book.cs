namespace LibraryPlatform.Models;

public class Book
{
    public int Id { get; set; }  
    public string Title { get; set; }
    public string Author { get; set; }
    public string ISBN { get; set; }  
    
    private DateTime _publishedDate;  
    public DateTime PublishedDate
    {
        get => _publishedDate;
        set => _publishedDate = DateTime.SpecifyKind(value, DateTimeKind.Utc);  
    }
    public int TotalCopies { get; set; }  
    public int AvailableCopies { get; set; }  
    public int CategoryId { get; set; }
}

public class BookRequest
{
    public string Title { get; set; }
    public string Author { get; set; }
    public string ISBN { get; set; }
    public DateTime PublishedDate { get; set; }
    public int TotalCopies { get; set; }
    public int AvailableCopies { get; set; }
    public int CategoryId { get; set; }
    
}

public class BookUpdateRequest
{
    public int Id { get; set; }
    public string? Title { get; set; }
    public string? Author { get; set; }
    public int? TotalCopies { get; set; }
    public int? AvailableCopies { get; set; }
    public int? CategoryId { get; set; }
}

public class Category
{
    public int Id { get; set; }
    public string Name { get; set; }
    public ICollection<Book> Books { get; set; } 
}
