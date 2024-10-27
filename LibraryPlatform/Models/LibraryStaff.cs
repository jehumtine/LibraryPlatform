namespace LibraryPlatform.Models;

public class LibraryStaff
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Role { get; set; }  // Role could be 'Librarian', 'Assistant', etc.
    public string Password { get; set; }
}

public class LibraryStaffRequest
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string? Role { get; set; }  // Role could be 'Librarian', 'Assistant', etc.
    public string Password { get; set; }
}

public class LibraryStaffResponse
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Role { get; set; }  // Role could be 'Librarian', 'Assistant', etc.
}