using LibraryPlatform.Database;
using LibraryPlatform.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LibraryPlatform.Controllers.Loan;
[ApiController]
[Route("api/[controller]")]
public class LoanController(ILoanService service, LibraryContext libd):ControllerBase
{
    [HttpPost("/issue-book-loan")]
    public async Task<IActionResult> IssueBookLoan([FromQuery] IssueBookLoanRequest loan)
    {
        var book = await libd.Books.Where(x => x.Id == loan.BookId).FirstOrDefaultAsync();
        if (book == null)
        {
            return NotFound("Book not found.");
        }

        if (book.AvailableCopies > 0)
        {
            var issuedLoan = await service.IssueBookLoan(loan);
            return Ok(issuedLoan); // Return success with the issued loan details
        }
        else
        {
            return BadRequest("Insufficient copies available.");
        }
    }

    [HttpPost("/service-book-loan")]
    public async Task<bool> ServiceBookLoan([FromQuery] int id)
    {
        return await service.ServiceBookLoan(id);
    }

    [HttpGet("/get-loans-by-user-id")]
    public async Task<List<Models.Loan>> GetLoansByLoanId([FromQuery] int id)
    {
        return await service.GetLoansByUserId(id);
    }
    [HttpGet("/get-loans-by-staff-id")]
    public async Task<List<Models.Loan>> GetLoansByStaffId([FromQuery] int id)
    {
        return await service.GetLoansByUserId(id);
    }
}