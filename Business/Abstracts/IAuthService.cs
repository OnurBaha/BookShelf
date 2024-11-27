using Business.Dtos.Requests.AuthRequests;
using Business.Dtos.Requests.UserRequests;
using Business.Dtos.Responses.AuthResponses;
using Core.Entities;

namespace Business.Abstracts;

public interface IAuthService
{
    Task<LoginResponse> Register(RegisterAuthRequest registerAuthRequest, string password);
    Task<User> Login(LoginAuthRequest loginAuthRequest);
    Task<LoginResponse> CreateAccessToken(User user);
    Task ChangePassword(ChangePasswordRequest changePasswordRequest);
    Task ChangeForgotPassword(ResetPasswordRequest resetPasswordRequest);
    Task<bool> PasswordResetAsync(string email);
}
