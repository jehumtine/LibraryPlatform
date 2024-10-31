using LibraryPlatform.Models;
using Microsoft.AspNetCore.Mvc;

namespace LibraryPlatform.Controllers;

[ApiController]
[Route("api/[controller]")]
public class MemberController(IMemberService service): ControllerBase
{
    [HttpPost("/add-member")]
    public async Task<Member> AddMember([FromQuery] MemberRequest request)
    {
        return await service.AddMember(request);
    }

    [HttpGet("/get-member")]
    public async Task<MemberResponse?> GetMemberById([FromQuery] int id)
    {
        return await service.GetMemberById(id);
    }

    [HttpPost("/update-member")]
    public async Task<Member> UpdateMember([FromQuery] MemberUpdateRequest request)
    {
        return await service.EditMember(request);
    }

    [HttpPost("/delete-member")]
    public async Task<bool> DeleteMember([FromQuery] int id)
    {
        return await service.DeleteMember(id);
    }

    [HttpGet("/get-all-members")]
    public async Task<List<MemberResponse>> GetAllMembers()
    {
        return await service.GetAllMembers();
    }
    [HttpGet("/get-member-count")]
    public async Task<int> GetMembersCount()
    {
        return await service.GetMemberCount();
    }
}