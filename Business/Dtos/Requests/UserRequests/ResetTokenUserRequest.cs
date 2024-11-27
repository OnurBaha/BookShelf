namespace Business.Dtos.Requests.UserRequests;

public class ResetTokenUserRequest
{
    public Guid Id { get; set; }
    public string PasswordReset { get; set; }
}
