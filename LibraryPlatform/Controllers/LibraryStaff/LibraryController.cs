using LibraryPlatform.Models;
using Microsoft.AspNetCore.Mvc;

namespace LibraryPlatform.Controllers.LibraryStaff;

[ApiController]
[Route("api/[controller]")]
public class LibraryStaffController(ILibraryStaffService service): ControllerBase
{
    [HttpPost("/add-library-staff")]
    public async Task<Models.LibraryStaffResponse> AddLibraryStaff([FromQuery]LibraryStaffRequest request)
    {
        return await service.CreateLibraryStaff(request);
    }

    [HttpPost("/delete-library-staff")]
    public async Task<bool> DeleteLibraryStaff([FromQuery]int id)
    {
        return await service.DeleteLibraryStaff(id);
    }

    [HttpGet("/get-library-staff")]
    public async Task<Models.LibraryStaffResponse?> GetLibraryStaff([FromQuery] int id)
    {
        var staff = await service.FindLibraryStaffById(id);
        return staff;
    }

    [HttpGet("/get-all-library-staff/")]
    public async Task<List<Models.LibraryStaffResponse>> GetAllLibraryStaff()
    {
        return await service.GetAllLibraryStaff();
    }
}