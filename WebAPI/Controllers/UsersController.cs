using Business.Abstracts;
using Core.CrossCuttingConcerns.Caching;
using Core.CrossCuttingConcerns.Logging.SeriLog.Logger;
using Core.CrossCuttingConcerns.Logging;
using Core.CrossCuttingConcerns.Validation;
using Core.DataAccess.Paging;
using Microsoft.AspNetCore.Mvc;
using Business.Rules.ValidationRules.FluentValidation.UserValidators;
using Business.Dtos.Requests.UserRequests;

namespace WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UsersController : ControllerBase
{
    IUserService _userService;

    public UsersController(IUserService userService)
    {
        _userService = userService;
    }

    [Logging(typeof(MsSqlLogger))]
    [Logging(typeof(FileLogger))]
    [Cache(60)]
    [HttpGet("GetList")]
    public async Task<IActionResult> GetListAsync([FromQuery] PageRequest pageRequest)
    {
        var result = await _userService.GetListAsync(pageRequest);
        return Ok(result);
    }

  

    [Logging(typeof(MsSqlLogger))]
    [Logging(typeof(FileLogger))]
    [Cache(10)]
    [HttpGet("GetListInstructor")]
    public async Task<IActionResult> GetListInstructorAsync([FromQuery] PageRequest pageRequest)
    {
        var result = await _userService.GetListInstructorAsync(pageRequest);
        return Ok(result);
    }



    [Logging(typeof(MsSqlLogger))]
    [Logging(typeof(FileLogger))]
    [Cache(10)]
    [HttpGet("GetListStudent")]
    public async Task<IActionResult> GetListStudent([FromQuery] PageRequest pageRequest)
    {
        var result = await _userService.GetListStudent(pageRequest);
        return Ok(result);
    }

    [Logging(typeof(MsSqlLogger))]
    [Logging(typeof(FileLogger))]
    [Cache]
    [HttpGet("GetById")]
    public async Task<IActionResult> GetByIdAsync(Guid id)
    {
        var result = await _userService.GetByIdAsync(id);
        return Ok(result);
    }

    [Logging(typeof(MsSqlLogger))]
    [Logging(typeof(FileLogger))]
    [Cache(10)]
    [HttpPost("GetByResetToken")]
    public async Task<IActionResult> GetByResetTokenAsync([FromBody] ResetTokenUserRequest resetTokenUserRequest)
    {
        var result = await _userService.GetByResetTokenAsync(resetTokenUserRequest);
        return Ok(result);
    }


    [Logging(typeof(MsSqlLogger))]
    [Logging(typeof(FileLogger))]
    [Cache(10)]
    [HttpGet("GetByMail")]
    public async Task<IActionResult> GetByMailAsync([FromQuery] string email)
    {
        var result = await _userService.GetByMailAsync(email);
        return Ok(result);
    }

    [Logging(typeof(MsSqlLogger))]
    [Logging(typeof(FileLogger))]
    [CacheRemove("Users.Get")]
    [CustomValidation(typeof(CreateUserRequestValidator))]
    [HttpPost]
    public async Task<IActionResult> AddAsync([FromBody] CreateUserRequest createUserRequest)
    {
        var result = await _userService.AddAsync(createUserRequest);
        return Ok(result);
    }


    [Logging(typeof(MsSqlLogger))]
    [Logging(typeof(FileLogger))]
    [CacheRemove("Users.Get")]
    [CustomValidation(typeof(UpdateUserRequestValidator))]
    [HttpPut]
    public async Task<IActionResult> UpdateAsync([FromBody] UpdateUserRequest updateUserRequest)
    {
        var result = await _userService.UpdateAsync(updateUserRequest);
        return Ok(result);
    }


    [Logging(typeof(MsSqlLogger))]
    [Logging(typeof(FileLogger))]
    [CacheRemove("Users.Get")]
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync([FromRoute] Guid id)
    {
        var result = await _userService.DeleteAsync(id);
        return Ok(result);
    }
}