namespace LibraryPlatform.Models;

public class Member
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
    public DateTime MembershipDate { get; set; }
    public string Password { get; set; }
}

public class MemberResponse
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
    public DateTime MembershipDate { get; set; }
}

public class MemberRequest
{
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? Email { get; set; }
    public string? PhoneNumber { get; set; }
    public DateTime MembershipDate  => DateTime.UtcNow;
    public string Password { get; set; }
}

public class MemberUpdateRequest : MemberRequest
{
    public int Id { get; set; }
}
