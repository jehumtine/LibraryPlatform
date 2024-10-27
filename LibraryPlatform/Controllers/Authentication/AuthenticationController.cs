using LibraryPlatform.Models;
using Microsoft.AspNetCore.Mvc;

namespace LibraryPlatform.Controllers.Authentication;


[ApiController]
[Route("api/[controller]")]
public class AuthenticationController(IAuthService service): ControllerBase
{
    [HttpGet("login-member")]
    public async Task<Response> LoginMember([FromQuery] string email, string password)
    {
        return await service.LoginMember(email, password);
    }
    [HttpGet("login-staff")]
    public async Task<Response> LoginStaff([FromQuery] string email, string password)
    {
        return await service.LoginStaff(email, password);
    }
}