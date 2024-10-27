using LibraryPlatform.Models;

namespace LibraryPlatform.Controllers.Authentication;

public interface IAuthService
{
    public Task<Response> LoginMember(string email, string password);
    public Task<Response> LoginStaff(string email, string password);
}