using LibraryPlatform.Models;

namespace LibraryPlatform.Controllers.Authentication;

public interface IAuthService
{
    public Task<ServerResponse> LoginMember(string email, string password);
    public Task<ServerResponse> LoginStaff(string email, string password);
}