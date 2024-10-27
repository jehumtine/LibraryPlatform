using LibraryPlatform.Database;
using LibraryPlatform.Models;
using Microsoft.EntityFrameworkCore;

namespace LibraryPlatform.Controllers.LibraryStaff;

public class LibraryStaffService(LibraryContext libdb): ILibraryStaffService
{
    public async Task<LibraryStaffResponse> CreateLibraryStaff(LibraryStaffRequest request)
    {
        var libraryStaff = new Models.LibraryStaff
        {
            FirstName = request.FirstName,
            LastName = request.LastName,
            Email = request.Email,
            Role = request?.Role,
            Password = request.Password
        };
        libdb.LibraryStaffs.Add(libraryStaff);
        await libdb.SaveChangesAsync();
        return new LibraryStaffResponse
        {
            Id = libraryStaff.Id,
            FirstName = libraryStaff.FirstName,
            LastName = libraryStaff.LastName,
            Email = libraryStaff.Email,
            Role = libraryStaff.Role
        };
    }

    public async Task<bool> DeleteLibraryStaff(int id)
    {
        var staff = await libdb.LibraryStaffs.FindAsync(id);
        libdb.Remove(staff);
        libdb.SaveChangesAsync();
        return true;
    }

    public async Task<Models.LibraryStaffResponse?> FindLibraryStaffById(int id)
    {
        var staff = await libdb.LibraryStaffs.FirstOrDefaultAsync(x => x.Id == id);
        return new LibraryStaffResponse
        {
            Id = staff.Id,
            FirstName = staff.FirstName,
            LastName = staff.LastName,
            Email = staff.Email,
            Role = staff.Role
        };
    }

    public async Task<List<Models.LibraryStaffResponse>> GetAllLibraryStaff()
    {
        var staffList =  await libdb.LibraryStaffs.Select(staff => new LibraryStaffResponse
        {
            Id = staff.Id,
            FirstName = staff.FirstName,
            LastName = staff.LastName,
            Email = staff.Email,
            Role = staff.Role
        }).ToListAsync();
        return staffList;   
    }
}