using LibraryPlatform.Database;
using Microsoft.EntityFrameworkCore;

namespace LibraryPlatform.Controllers.Stats;

public class StatsService(LibraryContext libdb): IStatsService
{
    public async Task<int> GetBooksBorrowedCount()
    {
        return await libdb.Loans.Where(x => x.Returned == false).CountAsync();
    }

    public async Task<int> GetTotalBooksCount()
    {
        var booksCount = await libdb.Books.CountAsync(x => x.Status ==1);
        return booksCount;
    }

    public async Task<int> GetMemberCount()
    {
        var count = await libdb.Members.CountAsync(x => x.Status == 1);
        return count;
    }

    public async Task<int> GetLibraryStaffCount()
    {
        var count = await libdb.LibraryStaffs.CountAsync();
        return count;
    }
}