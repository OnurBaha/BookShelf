using Business.Dtos.Requests.MailRequests;

namespace Business.Abstracts;

public interface IMailService
{
    Task<bool> SendMailAsync(SendMailRequest sendMailRequest);
    Task SendPasswordResetMailAsync(SendPasswordResetMailRequest sendPasswordResetMailRequest);
}