using LibraryPlatform.Models;

namespace LibraryPlatform.Controllers;

public interface IMemberService
{
    public Task<Member> AddMember(MemberRequest member);
    public Task<MemberResponse?> GetMemberById(int id);
    public Task<Member> EditMember(MemberUpdateRequest member);
    public Task<bool> DeleteMember(int id);
    
    public Task<List<MemberResponse>> GetAllMembers();
}