namespace Business.Dtos.Requests.MailRequests;

public class SendPasswordResetMailRequest
{
    public string To { get; set; }
    public Guid  UserId { get; set; }
    public string ResetToken { get; set; }

}
