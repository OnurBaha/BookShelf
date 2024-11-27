using AutoMapper;
using Business.Dtos.Requests.OperationClaimRequests;
using Business.Dtos.Responses.OperationClaimResponses;
using Core.DataAccess.Paging;
using Core.Entities;

namespace Business.Profiles;

public class OperationClaimProfile : Profile
{
    public OperationClaimProfile()
    {

        CreateMap<OperationClaim, CreateOperationClaimRequest>().ReverseMap();
        CreateMap<OperationClaim, CreatedOperationClaimResponse>().ReverseMap();


        CreateMap<OperationClaim, UpdateOperationClaimRequest>().ReverseMap();
        CreateMap<OperationClaim, UpdatedOperationClaimResponse>().ReverseMap();

        CreateMap<OperationClaim, DeletedOperationClaimResponse>().ReverseMap();

        CreateMap<OperationClaim, GetListOperationClaimResponse>().ReverseMap();
        CreateMap<IPaginate<OperationClaim>, Paginate<GetListOperationClaimResponse>>().ReverseMap();
    }
}
