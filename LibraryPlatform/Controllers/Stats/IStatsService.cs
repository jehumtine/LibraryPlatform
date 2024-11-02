namespace LibraryPlatform.Controllers.Stats;

public interface IStatsService
{
    Task<int> GetBooksBorrowedCount();
    Task<int> GetTotalBooksCount();
    public Task<int> GetMemberCount();
    public Task<int> GetLibraryStaffCount();
}