namespace LibraryPlatform.Models;

public class Loan
{
    public int Id { get; set; }
    public int BookId { get; set; }
    public int MemberId { get; set; }
    public DateTimeOffset LoanDate { get; set; }
    public DateTimeOffset ReturnDate { get; set; }  // Nullable, because the book might not have been returned yet
    public Book Book { get; set; }  // Navigation property
    public Member Member { get; set; }  // Navigation property
    public bool Returned { get; set; }
}

public class IssueBookLoanRequest
{
    public int BookId { get; set; }
    public int MemberId { get; set; }
    public int LibraryStaffId { get; set; }
    public DateTimeOffset ReturnDate { get; set; }
}