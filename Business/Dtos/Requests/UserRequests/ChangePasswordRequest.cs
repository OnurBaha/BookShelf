namespace Business.Dtos.Requests.UserRequests;


public class ChangePasswordRequest
{
    public Guid UserId { get; set; }
    public string OldPassword { get; set; }
    public string NewPassword { get; set; }
}
