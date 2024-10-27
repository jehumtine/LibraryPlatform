using LibraryPlatform.Database;
using LibraryPlatform.Models;
using Microsoft.EntityFrameworkCore;

namespace LibraryPlatform.Controllers.Loan;

public class LoanService(LibraryContext libdb): ILoanService
{
    public async Task<Models.Loan> IssueBookLoan(IssueBookLoanRequest request)
    {
        var book = await libdb.Books.Where(x => x.Id == request.BookId).FirstOrDefaultAsync();
        var loan = new Models.Loan
        {
            BookId = request.BookId,
            MemberId = request.MemberId,
            LoanDate = DateTimeOffset.UtcNow,
            ReturnDate = request.ReturnDate,
            Returned = false
        };
        
        book.TotalCopies= book.TotalCopies-1 ;
        libdb.Loans.Add(loan);
        await libdb.SaveChangesAsync();
        return loan;
    }

    public async Task<bool> ServiceBookLoan(int id)
    {
        var loan = libdb.Loans.FirstOrDefault(l => l.BookId == id);
        
        loan.Returned = true;
        libdb.SaveChangesAsync();
        return true;
    }


    public async Task<List<Models.Loan>> GetLoansByUserId(int id)
    {
        var loans = libdb.Loans.Include(x => x.Book).Include(x => x.Member).Where(l => l.MemberId == id).ToList();
        return loans;
    }

    public Task<List<Models.Loan>> GetLoansByStaffId()
    {
        throw new NotImplementedException();
    }
}