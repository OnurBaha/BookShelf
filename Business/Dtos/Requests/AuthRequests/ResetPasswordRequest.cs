namespace Business.Dtos.Requests.AuthRequests;

public class ResetPasswordRequest
{
    public Guid UserId { get; set; }
    public string NewPassword { get; set; }
}
