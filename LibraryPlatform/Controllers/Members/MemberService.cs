using LibraryPlatform.Database;
using LibraryPlatform.Models;
using Microsoft.EntityFrameworkCore;
using BCrypt.Net;  // for password hashing

namespace LibraryPlatform.Controllers;

public class MemberService(LibraryContext libdb):IMemberService
{
    public async Task<Member> AddMember(MemberRequest request)
    {
        var member = new Member
        {
            FirstName = request.FirstName,
            LastName = request.LastName,
            Email = request.Email,
            PhoneNumber = request.PhoneNumber,
            MembershipDate = DateTime.UtcNow,
            Password = BCrypt.Net.BCrypt.HashPassword(request.Password)
        };
        libdb.Members.Add(member);
        await libdb.SaveChangesAsync();
        return member;
    }

    public async Task<MemberResponse?> GetMemberById(int id)
    {
        var member = await libdb.Members.FirstOrDefaultAsync(x => x.Id == id);
        var memberResponse = new MemberResponse
        {
            Id = member.Id,
            FirstName = member.FirstName,
            LastName = member.LastName,
            Email = member.Email,
            PhoneNumber = member.PhoneNumber,
            MembershipDate = member.MembershipDate,
        };
        return memberResponse;
    }

    public async Task<Member> EditMember(MemberUpdateRequest request)
    {
        var oldMember = await libdb.Members.FirstOrDefaultAsync(x => x.Id == request.Id);
        if (request.FirstName != null)
        {
            oldMember.FirstName = request.FirstName;
        }else if (request.LastName != null)
        {
            oldMember.LastName = request.LastName;
        }else if (request.Email != null)
        {
            oldMember.Email = request.Email;
        }else if (request.PhoneNumber != null)
        {
            oldMember.PhoneNumber = request.PhoneNumber;
        }
        await libdb.SaveChangesAsync();
        return oldMember;
    }

    public async Task<bool> DeleteMember(int id)
    {
        var member = await libdb.Members.FirstOrDefaultAsync(x => x.Id == id);
        if (member != null) libdb.Members.Remove(member);
        await libdb.SaveChangesAsync();
        return true;
    }

    public async Task<List<MemberResponse>> GetAllMembers()
    {
        return await libdb.Members.Select(m => new MemberResponse
        {
            Id = m.Id,
            FirstName = m.FirstName,
            LastName = m.LastName,
            Email = m.Email,
            PhoneNumber = m.PhoneNumber,
            MembershipDate = m.MembershipDate
        }).ToListAsync();
    }
}