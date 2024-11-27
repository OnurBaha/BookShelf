using AutoMapper;
using Business.Abstracts;
using Business.Dtos.Requests.UserRequests;
using Business.Dtos.Responses.UserResponses;
using Business.Messages;
using Business.Rules.BusinessRules;
using Core.DataAccess.Paging;
using Core.Entities;
using DataAccess.Abstracts;
using Microsoft.EntityFrameworkCore;

namespace Business.Concretes;

public class UserManager : IUserService
{
    IUserDal _userDal;
    IOperationClaimService _operationClaimService;
    IMapper _mapper;
    UserBusinessRules _userBusinessRules;

    public UserManager(IUserDal userDal, IMapper mapper, UserBusinessRules userBusinessRules, IOperationClaimService operationClaimService)
    {
        _mapper = mapper;
        _userDal = userDal;
        _userBusinessRules = userBusinessRules;
        _operationClaimService = operationClaimService;
    }

    public async Task<CreatedUserResponse> AddAsync(CreateUserRequest createUserRequest)
    {
        User user = _mapper.Map<User>(createUserRequest);
        User addedUser = await _userDal.AddAsync(user);
        var responseUser = _mapper.Map<CreatedUserResponse>(addedUser);
        return responseUser;
    }

    public async Task<UpdatedUserResponse> UpdateAsync(UpdateUserRequest updateUserRequest)
    {
        await _userBusinessRules.IsExistsUser(updateUserRequest.Id);
        User user = _mapper.Map<User>(updateUserRequest);

        var updatedUser = await _userDal.UpdateAsync(user);
        UpdatedUserResponse mappedUser = _mapper.Map<UpdatedUserResponse>(updatedUser);
        return mappedUser;
    }

    public async Task<DeletedUserResponse> DeleteAsync(Guid id)
    {
        await _userBusinessRules.IsExistsUser(id);
        User user = await _userDal.GetAsync(predicate: u => u.Id == id);
        User deletedUser = await _userDal.DeleteAsync(user);
        DeletedUserResponse responseUser = _mapper.Map<DeletedUserResponse>(deletedUser);
        return responseUser;
    }

    public async Task<IPaginate<GetListUserResponse>> GetListAsync(PageRequest pageRequest)
    {
        var userList = await _userDal.GetListAsync(
              include: u => u.Include(u => u.UserOperationClaims)
              .ThenInclude(uopc => uopc.OperationClaim),
        index: pageRequest.PageIndex,
        size: pageRequest.PageSize);
        var mappedList = _mapper.Map<Paginate<GetListUserResponse>>(userList);
        return mappedList;
    }


    public async Task<IPaginate<GetListUserResponse>> GetListInstructorAsync(PageRequest pageRequest)
    {
        var userList = await _userDal.GetListAsync(
            include: u => u.Include(u => u.UserOperationClaims),
            predicate: u => u.UserOperationClaims.Any(uoc => uoc.OperationClaim.Name.Contains(Roles.Instructor)),
        index: pageRequest.PageIndex,
        size: pageRequest.PageSize);
        var mappedList = _mapper.Map<Paginate<GetListUserResponse>>(userList);
        return mappedList;
    }
    public async Task<IPaginate<GetListUserResponse>> GetListStudent(PageRequest pageRequest)
    {
        var userList = await _userDal.GetListAsync(
            include: u => u.Include(u => u.UserOperationClaims),
            predicate: u => u.UserOperationClaims.Any(uoc => uoc.OperationClaim.Name.Contains(Roles.Student)),
        index: pageRequest.PageIndex,
        size: pageRequest.PageSize);
        var mappedList = _mapper.Map<Paginate<GetListUserResponse>>(userList);
        return mappedList;
    }

    public async Task<GetUserResponse> GetByIdAsync(Guid? id)
    {
        User user = await _userDal.GetAsync(
            predicate: u => u.Id == id,
            enableTracking: false);
        GetUserResponse getUserResponse = _mapper.Map<GetUserResponse>(user);
        return getUserResponse;
    }

    public async Task<GetUserResponse> GetByMailAsync(string email)
    {
        await _userBusinessRules.IsExistsUserByMail(email);
        var getUser = await _userDal.GetAsync(u => u.Email == email, enableTracking: false);
        GetUserResponse getUserResponse = _mapper.Map<GetUserResponse>(getUser);
        return getUserResponse;
    }

    public async Task<GetUserResponse> GetByResetTokenAsync(ResetTokenUserRequest resetTokenUserRequest)
    {
        await _userBusinessRules.IsExistsResetToken(resetTokenUserRequest.PasswordReset);
        User user = await _userDal.GetAsync(predicate: u => u.PasswordReset == resetTokenUserRequest.PasswordReset,
            enableTracking: false);
        GetUserResponse getUserResponse = _mapper.Map<GetUserResponse>(user);
        return getUserResponse;
    }

    public async Task<List<OperationClaim>> GetClaimsAsync(User user)
    {
        var operationClaims = await _operationClaimService.GetByUserIdAsync(user.Id);
        var mappedOperationClaims = _mapper.Map<List<OperationClaim>>(operationClaims);
        return mappedOperationClaims;
    }

    public async Task<UpdatedUserResponse> UpdatePasswordAsync(User user)
    {
        await _userBusinessRules.IsExistsUser(user.Id);
        var updatedUser = await _userDal.UpdateAsync(user);
        UpdatedUserResponse mappedUser = _mapper.Map<UpdatedUserResponse>(updatedUser);
        return mappedUser;
    }

    public async Task<UpdatedUserResponse> UpdateResetTokenAsync(ResetTokenUserRequest resetTokenUserRequest)
    {
        await _userBusinessRules.IsExistsUser(resetTokenUserRequest.Id);
        User user = await _userDal.GetAsync(predicate: u => u.Id == resetTokenUserRequest.Id, enableTracking: false);
        user.PasswordReset = resetTokenUserRequest.PasswordReset;
        var updatedUser = await _userDal.UpdateAsync(user);
        UpdatedUserResponse mappedUser = _mapper.Map<UpdatedUserResponse>(updatedUser);
        return mappedUser;
    }
}
