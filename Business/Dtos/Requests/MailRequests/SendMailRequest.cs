namespace Business.Dtos.Requests.MailRequests;

public class SendMailRequest
{
    public string To { get; set; }
    public string Subject { get; set; }
    public string Body { get; set; }
}
