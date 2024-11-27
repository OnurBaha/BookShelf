using Business.Abstracts;
using Business.Dtos.Requests.MailRequests;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class MailsController : ControllerBase
{
    IMailService _mailService;

    public MailsController(IMailService mailService)
    {
        _mailService = mailService;
    }

    [HttpPost]
    public async Task<IActionResult> SendMail([FromBody] SendMailRequest sendMailRequest)
    {
       var result = await _mailService.SendMailAsync(sendMailRequest);
        return Ok(result);
    }
}
