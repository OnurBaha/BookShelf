using Business.Dtos.Requests.UserOperationClaimRequests;
using Business.Dtos.Responses.UserOperationClaimResponses;
using Core.DataAccess.Paging;

namespace Business.Abstracts;

public interface IUserOperationClaimService
{
    Task<CreatedUserOperationClaimResponse> AddAsync(CreateUserOperationClaimRequest createUserOperationClaimRequest);
    Task<UpdatedUserOperationClaimResponse> UpdateAsync(UpdateUserOperationClaimRequest updateUserOperationClaimRequest);
    Task<DeletedUserOperationClaimResponse> DeleteAsync(Guid id);
    Task<IPaginate<GetListUserOperationClaimResponse>> GetListAsync(PageRequest pageRequest);
    Task<GetListUserOperationClaimResponse> GetByUserIdAndOperationClaimId(Guid userId, Guid operationClaimId);
    Task <IPaginate<GetListUserOperationClaimResponse>> GetByUserId(Guid userId );
}
