namespace Business.Dtos.Responses.UserResponses;

public class ChangedPasswordResponse
{
    public Guid UserId { get; set; }
    public string NewPassword { get; set; }
}
