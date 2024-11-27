using Business.Dtos.Requests.UserRequests;
using Business.Dtos.Responses.UserResponses;
using Core.DataAccess.Paging;
using Core.Entities;

namespace Business.Abstracts;

public interface IUserService
{
    Task<IPaginate<GetListUserResponse>> GetListAsync(PageRequest pageRequest);
    Task<CreatedUserResponse> AddAsync(CreateUserRequest createUserRequest);
    Task<UpdatedUserResponse> UpdateAsync(UpdateUserRequest updateUserRequest);
    Task<DeletedUserResponse> DeleteAsync(Guid id);
    Task<UpdatedUserResponse> UpdatePasswordAsync(User user);
    Task<UpdatedUserResponse> UpdateResetTokenAsync(ResetTokenUserRequest resetTokenUserRequest);
    Task<GetUserResponse> GetByIdAsync(Guid? id);
    Task<GetUserResponse> GetByMailAsync(string email);
    Task<List<OperationClaim>> GetClaimsAsync(User user);
    Task<IPaginate<GetListUserResponse>> GetListInstructorAsync(PageRequest pageRequest);
    Task<IPaginate<GetListUserResponse>> GetListStudent(PageRequest pageRequest);
    Task<GetUserResponse> GetByResetTokenAsync(ResetTokenUserRequest resetTokenUserRequest);
}
