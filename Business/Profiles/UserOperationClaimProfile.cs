using AutoMapper;
using Business.Dtos.Requests.UserOperationClaimRequests;
using Business.Dtos.Responses.UserOperationClaimResponses;
using Core.DataAccess.Paging;
using Core.Entities;

namespace Business.Profiles;

public class UserOperationClaimProfile : Profile
{
    public UserOperationClaimProfile()
    {
        CreateMap<UserOperationClaim, CreateUserOperationClaimRequest>().ReverseMap();
        CreateMap<UserOperationClaim, CreatedUserOperationClaimResponse>().ReverseMap();

        CreateMap<UserOperationClaim, UpdateUserOperationClaimRequest>().ReverseMap();
        CreateMap<UserOperationClaim, UpdatedUserOperationClaimResponse>().ReverseMap();

        CreateMap<UserOperationClaim, DeletedUserOperationClaimResponse>().ReverseMap();

        CreateMap<UserOperationClaim, GetListUserOperationClaimResponse>()
            .ForMember(destinationMember: dest => dest.OperationClaimName,
            memberOptions: opt => opt.MapFrom(u => u.OperationClaim.Name)).ReverseMap();
            ;
        
        CreateMap<IPaginate<UserOperationClaim>, Paginate<GetListUserOperationClaimResponse>>().ReverseMap();
    }
}
