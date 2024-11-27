
namespace Core.Entities;

public class User : Entity<Guid>
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public byte[] PasswordSalt { get; set; }
    public byte[] PasswordHash { get; set; }
    public string? PasswordReset { get; set; }
    public bool Status { get; set; }
    public ICollection<UserOperationClaim> UserOperationClaims { get; set; }
}
