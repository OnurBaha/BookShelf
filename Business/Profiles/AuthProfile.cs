using AutoMapper;
using Business.Dtos.Responses.AuthResponses;
using Business.Dtos.Responses.OperationClaimResponses;
using Core.Entities;
using Core.Utilities.Security.JWT;

namespace Business.Profiles;

public class AuthProfile:Profile
{
	public AuthProfile()
	{
		CreateMap<AccessToken, LoginResponse>().ReverseMap();
		CreateMap<GetListOperationClaimResponse, OperationClaim>()

			.ReverseMap();
	}
}

