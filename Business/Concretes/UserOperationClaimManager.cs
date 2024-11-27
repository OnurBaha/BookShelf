using AutoMapper;
using Business.Abstracts;
using Business.Dtos.Requests.UserOperationClaimRequests;
using Business.Dtos.Responses.UserOperationClaimResponses;
using Business.Rules.BusinessRules;
using Core.DataAccess.Paging;
using Core.Entities;
using DataAccess.Abstracts;
using Microsoft.EntityFrameworkCore;

namespace Business.Concretes;

public class UserOperationClaimManager : IUserOperationClaimService
{
    IUserOperationClaimDal _userOperationClaimDal;
    IMapper _mapper;
    UserOperationClaimBusinessRules _userOperationClaimBusinessRules;

    public UserOperationClaimManager(IUserOperationClaimDal userOperationClaimDal, IMapper mapper, UserOperationClaimBusinessRules userOperationClaimBusinessRules)
    {
        _userOperationClaimDal = userOperationClaimDal;
        _mapper = mapper;
        _userOperationClaimBusinessRules = userOperationClaimBusinessRules;
    }

    public async Task<CreatedUserOperationClaimResponse> AddAsync(CreateUserOperationClaimRequest createUserOperationClaimRequest)
    {
        UserOperationClaim userOperationClaim = _mapper.Map<UserOperationClaim>(createUserOperationClaimRequest);
        UserOperationClaim addedUserOperationClaim = await _userOperationClaimDal.AddAsync(userOperationClaim);
        CreatedUserOperationClaimResponse createdUserOperationClaimResponse = _mapper.Map<CreatedUserOperationClaimResponse>(addedUserOperationClaim);
        return createdUserOperationClaimResponse;
    }

    public async Task<DeletedUserOperationClaimResponse> DeleteAsync(Guid id)
    {
        await _userOperationClaimBusinessRules.IsExistsUserOperationClaim(id);
        UserOperationClaim userOperationClaim = await _userOperationClaimDal.GetAsync(predicate: uop => uop.Id == id);
        UserOperationClaim deletedUserOperationClaim = await _userOperationClaimDal.DeleteAsync(userOperationClaim);
        DeletedUserOperationClaimResponse deletedUserOperationClaimResponse = _mapper.Map<DeletedUserOperationClaimResponse>(deletedUserOperationClaim);
        return deletedUserOperationClaimResponse;
    }

    public async Task<IPaginate<GetListUserOperationClaimResponse>> GetByUserId(Guid userId)
    {
        var userOperationClaim = await _userOperationClaimDal.GetListAsync(
           predicate: a => a.UserId == userId,
           include: er => er.Include(er => er.User).Include(er=>er.OperationClaim));
        var mappedExamResult = _mapper.Map<Paginate<GetListUserOperationClaimResponse>>(userOperationClaim);
        return mappedExamResult;
    }

    public async Task<GetListUserOperationClaimResponse> GetByUserIdAndOperationClaimId(Guid userId, Guid operationClaimId)
    {
        var userOperationClaim = await _userOperationClaimDal.GetAsync(
           predicate: a => a.UserId == userId && a.OperationClaimId == operationClaimId,
           include: al => al
           .Include(al => al.OperationClaim)
           .Include(al => al.User));
        var mappedListed = _mapper.Map<GetListUserOperationClaimResponse>(userOperationClaim);
        return mappedListed;
             
    }

    public async Task<IPaginate<GetListUserOperationClaimResponse>> GetListAsync(PageRequest pageRequest)
    {
        var userOperationClaim = await _userOperationClaimDal.GetListAsync(
                       index: pageRequest.PageIndex,
                       size: pageRequest.PageSize,
                       include:er=>er.Include(er => er.OperationClaim)
                       );
        var mappedUserOperationClaim = _mapper.Map<Paginate<GetListUserOperationClaimResponse>>(userOperationClaim);
        return mappedUserOperationClaim;
    }

    public async Task<UpdatedUserOperationClaimResponse> UpdateAsync(UpdateUserOperationClaimRequest updateUserOperationClaimRequest)
    {
        UserOperationClaim userOperationClaim = _mapper.Map<UserOperationClaim>(updateUserOperationClaimRequest);
        UserOperationClaim updatedUserOperationClaim = await _userOperationClaimDal.UpdateAsync(userOperationClaim);
        UpdatedUserOperationClaimResponse updatedUserOperationClaimResponse = _mapper.Map<UpdatedUserOperationClaimResponse>(updatedUserOperationClaim);
        return updatedUserOperationClaimResponse;
    }
}
