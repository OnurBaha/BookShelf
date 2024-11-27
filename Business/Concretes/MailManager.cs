using Business.Abstracts;
using Business.Dtos.Requests.MailRequests;
using Microsoft.Extensions.Configuration;
using System.Net;
using System.Net.Mail;
using System.Text;

namespace Business.Concretes;

public class MailManager : IMailService
{
    private readonly IConfiguration _configuration;

    public MailManager(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public async Task<bool> SendMailAsync(SendMailRequest sendMailRequest)
    {
        MailMessage mail = new();

        mail.From = new(_configuration.GetSection("Smtp:Username").Value?.ToString(), "Tobeto Platform", System.Text.Encoding.UTF8);
        mail.To.Add(sendMailRequest.To);
        mail.Subject = sendMailRequest.Subject;
        mail.Body = sendMailRequest.Body;
        mail.IsBodyHtml = true;

        SmtpClient client = new();
        client.Credentials = new NetworkCredential(_configuration.GetSection("Smtp:Username").Value?.ToString(), _configuration.GetSection("Smtp:Token").Value?.ToString());
        client.Port = Convert.ToInt32(_configuration.GetSection("Smtp:Port").Value);
        client.Host = _configuration.GetSection("Smtp:Host").Value?.ToString();
        client.EnableSsl = true;

        await client.SendMailAsync(mail);
        return true;
    }

    public async Task SendPasswordResetMailAsync(SendPasswordResetMailRequest sendPasswordResetMailRequest)
    {
        StringBuilder mail = new StringBuilder();

        mail.AppendLine($"Merhaba <br> Eğer yeni şifre talebinde bulundaysanız aşağıdaki linkten şifrenizi yenileyebilirsiniz. <br><strong><a target=\"_blank\" href=\"http://localhost:3000/reset-password/{Uri.EscapeDataString(sendPasswordResetMailRequest.UserId.ToString())}/{Uri.EscapeDataString(sendPasswordResetMailRequest.ResetToken)}\"> Yeni şifre talebi için tıklayınız.. </a></strong><br><br><span style=\"font-size:12px;\">NOT : Eğer ki bu talep tarafınızdan gerçekleştirilmediyse bu maili ciddiye almayınız.");

        SendMailRequest sendMailRequest = new SendMailRequest
        {
            To = sendPasswordResetMailRequest.To,
            Subject = "Şifre Yenileme Talebi",
            Body = mail.ToString(),
        };

        await SendMailAsync(sendMailRequest);
    }
}
