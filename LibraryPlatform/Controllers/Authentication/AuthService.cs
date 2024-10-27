using LibraryPlatform.Database;
using LibraryPlatform.Models;
using Microsoft.EntityFrameworkCore;

namespace LibraryPlatform.Controllers.Authentication;

public class AuthService(LibraryContext libdb): IAuthService
{
    public async Task<Response> LoginMember(string email, string password)
    {
        var member = await libdb.Members.Where(x => x.Email == email).FirstOrDefaultAsync();
        if (member != null)
        {
            if (BCrypt.Net.BCrypt.Verify(password, member.Password))
            {
                return new Response
                {
                    status = "Success",
                };
            }
        }
        return new Response
        {
            status = "User Not Found or Invalid Credentials",
        };
    }

    public async Task<Response> LoginStaff(string email, string password)
    {
        var staff = await libdb.LibraryStaffs.Where(x => x.Email == email).FirstOrDefaultAsync();
        if (staff != null)
        {
            if (BCrypt.Net.BCrypt.Verify(password, staff.Password))
            {
                return new Response
                {
                    status = "Success",
                };
            }
        }
        return new Response
        {
            status = "User Not Found or Invalid Credentials",
        };
    }
}