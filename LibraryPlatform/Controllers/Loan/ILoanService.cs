using LibraryPlatform.Models;

namespace LibraryPlatform.Controllers.Loan;

public interface ILoanService
{
    public Task<Models.Loan> IssueBookLoan(IssueBookLoanRequest request);
    public Task<bool> ServiceBookLoan(int id);
    public Task<List<Models.Loan>> GetLoansByUserId(int id);
    public Task<List<Models.Loan>> GetLoansByStaffId();
}