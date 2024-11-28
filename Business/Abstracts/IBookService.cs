
using Business.Dtos.Requests.BookRequests;
using Business.Dtos.Responses.BookResponses;
using Core.DataAccess.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstracts;

public interface IBookService
{
    Task<IPaginate<GetListBookResponse>> GetListAsync(PageRequest pageRequest);
    Task<CreatedBookResponse> AddAsync(CreateBookRequest createBookRequest);
    Task<UpdatedBookResponse> UpdateAsync(UpdateBookRequest updateBookRequest);
    Task<DeletedBookResponse> DeleteAsync(Guid id);
    Task<CreatedBookResponse> GetById(Guid id);
}
