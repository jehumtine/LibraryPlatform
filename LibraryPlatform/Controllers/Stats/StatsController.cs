using Microsoft.AspNetCore.Mvc;

namespace LibraryPlatform.Controllers.Stats;

public class StatsController(IStatsService service): ControllerBase
{
    [HttpGet("/get-book-borrowed-count/")]
    public async Task<int> BookBorrowedCount()
    {
        return await service.GetBooksBorrowedCount();
    }
    [HttpGet("/get-books-count/")]
    public async Task<int> BookCount()
    {
        return await service.GetTotalBooksCount();
    }
    [HttpGet("/get-member-count")]
    public async Task<int> GetMembersCount()
    {
        return await service.GetMemberCount();
    }
    [HttpGet("/get-library-staff-count")]
    public async Task<int> GetLibraryStaffCount()
    {
        return await service.GetLibraryStaffCount();
    }
}