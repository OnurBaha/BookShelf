using AutoMapper;
using Business.Dtos.Requests.ReadingPlanRequests;
using Business.Dtos.Responses.ReadingPlanResponses;
using Core.DataAccess.Paging;
using Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Profiles
{
    public class ReadingPlanProfile:Profile
    {
        public ReadingPlanProfile()
        {
            CreateMap<CreateReadingPlanRequest, ReadingPlan>().ReverseMap();
            CreateMap<ReadingPlan, CreatedReadingPlanResponse>().ReverseMap();

            CreateMap<DeleteReadingPlanRequest, ReadingPlan>().ReverseMap();
            CreateMap<ReadingPlan, DeletedReadingPlanResponse>().ReverseMap();

            CreateMap<UpdateReadingPlanRequest, ReadingPlan>().ReverseMap();
            CreateMap<ReadingPlan, UpdatedReadingPlanResponse>().ReverseMap();

            CreateMap<ReadingPlan, GetListReadingPlanResponse>().ReverseMap();
            CreateMap<Paginate<ReadingPlan>, Paginate<GetListReadingPlanResponse>>().ReverseMap();
        }
    }
}
