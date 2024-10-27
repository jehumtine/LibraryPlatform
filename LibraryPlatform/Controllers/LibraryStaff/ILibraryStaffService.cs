using LibraryPlatform.Models;

namespace LibraryPlatform.Controllers.LibraryStaff;

public interface ILibraryStaffService
{
    public Task<LibraryStaffResponse> CreateLibraryStaff(LibraryStaffRequest libraryStaff);
    public Task<bool> DeleteLibraryStaff(int id);
    public Task<Models.LibraryStaffResponse?> FindLibraryStaffById(int id);
    public Task<List<Models.LibraryStaffResponse>> GetAllLibraryStaff();
}