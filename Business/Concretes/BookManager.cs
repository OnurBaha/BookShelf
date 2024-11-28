using AutoMapper;
using Business.Abstracts;
using Business.Dtos.Requests.BookRequests;
using Business.Dtos.Responses.BookResponses;
using Core.DataAccess.Paging;
using Core.Entities;
using DataAccess.Abstracts;
using Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concretes
{
    public class BookManager:IBookService
    {
        IBookDal _bookDal;
        IMapper _mapper;

        public BookManager(IBookDal bookDal, IMapper mapper)
        {
            _bookDal = bookDal;
            _mapper = mapper;
        }
        public async Task<CreatedBookResponse> AddAsync(CreateBookRequest createBookRequest)
        {
            Book book = _mapper.Map<Book>(createBookRequest);
            Book createdBook = await _bookDal.AddAsync(book);
            CreatedBookResponse createdBookResponse = _mapper.Map<CreatedBookResponse>(createdBook);
            return createdBookResponse;
        }

        public async Task<DeletedBookResponse> DeleteAsync(Guid id)
        {
            var data = await _bookDal.GetAsync(i => i.Id == id);
            var result = await _bookDal.DeleteAsync(data);
            var result2 = _mapper.Map<DeletedBookResponse>(result);
            return result2;
        }

        public async Task<CreatedBookResponse> GetById(Guid id)
        {
            var result = await _bookDal.GetAsync(c => c.Id == id);
            Book mappedBook = _mapper.Map<Book>(result);
            CreatedBookResponse createdBookResponse = _mapper.Map<CreatedBookResponse>(mappedBook);
            return createdBookResponse;
        }
        public async Task<IPaginate<GetListBookResponse>> GetListAsync(PageRequest pageRequest)
        {
            var data = await _bookDal.GetListAsync(
                index: pageRequest.PageIndex,
                size: pageRequest.PageSize
            );
            var result = _mapper.Map<Paginate<GetListBookResponse>>(data);
            return result;
        }

        public async Task<UpdatedBookResponse> UpdateAsync(UpdateBookRequest updateBookRequest)
        {
            var data = await _bookDal.GetAsync(i => i.Id == updateBookRequest.Id);
            _mapper.Map(updateBookRequest, data);
            await _bookDal.UpdateAsync(data);
            var result = _mapper.Map<UpdatedBookResponse>(data);
            return result;
        }
    }
}
