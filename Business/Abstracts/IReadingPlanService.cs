using Business.Dtos.Requests.ReadingPlanRequests;
using Business.Dtos.Responses.ReadingPlanResponses;
using Core.DataAccess.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstracts
{
    public interface IReadingPlanService
    {
        Task<IPaginate<GetListReadingPlanResponse>> GetListAsync(PageRequest pageRequest);
        Task<CreatedReadingPlanResponse> AddAsync(CreateReadingPlanRequest createReadingPlanRequest);
        Task<UpdatedReadingPlanResponse> UpdateAsync(UpdateReadingPlanRequest updateReadingPlanRequest);
        Task<DeletedReadingPlanResponse> DeleteAsync(Guid id);
        Task<CreatedReadingPlanResponse> GetById(Guid id);
    }
}
