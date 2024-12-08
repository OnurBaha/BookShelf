using Business.Abstracts;
using Business.Dtos.Requests.AuthRequests;
using Business.Dtos.Requests.UserRequests;
using Core.CrossCuttingConcerns.Validation;
using Microsoft.AspNetCore.Mvc;


namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthController : Controller
{
    private IAuthService _authService;

    public AuthController(IAuthService authService)
    {
        _authService = authService;
    }

    [HttpPost("Login")]
    public async Task<IActionResult> Login([FromBody] LoginAuthRequest loginAuthRequest)
    {
        var userToLogin = await _authService.Login(loginAuthRequest);
        var result = await _authService.CreateAccessToken(userToLogin);
        return Ok(result);
    }

    [HttpPost("Register")]
    [CustomValidation(typeof(RegisterAuthRequest))]

    public async Task<IActionResult> Register([FromBody] RegisterAuthRequest registerAuthRequest)
    {
        var registerResult = await _authService.Register(registerAuthRequest, registerAuthRequest.Password);
        return Ok(registerResult);
    }

    [HttpPost("ChangePassword")]
    public async Task<IActionResult> ChangePassword([FromBody] ChangePasswordRequest changePasswordRequest)
    {
        await _authService.ChangePassword(changePasswordRequest);
        return Ok(true);
    }


    [HttpPost("ChangeForgotPassword")]
    public async Task<IActionResult> ChangeForgotPasswordAsync([FromBody] ResetPasswordRequest resetPasswordRequest)
    {
        await _authService.ChangeForgotPassword(resetPasswordRequest);
        return Ok(true);
    }

    [HttpGet("PasswordReset")]
    public async Task<IActionResult> PasswordResetAsync([FromQuery] string email)
    {
        await _authService.PasswordResetAsync(email);
        return Ok(true);
    }

}