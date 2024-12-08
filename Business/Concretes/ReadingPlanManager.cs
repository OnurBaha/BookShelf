using AutoMapper;
using Business.Abstracts;
using Business.Dtos.Requests.ReadingPlanRequests;
using Business.Dtos.Requests.ReadingPlanRequests;
using Business.Dtos.Requests.ReadingPlanRequests;
using Business.Dtos.Responses.ReadingPlanResponses;
using Business.Dtos.Responses.ReadingPlanResponses;
using Business.Dtos.Responses.ReadingPlanResponses;
using Business.Dtos.Responses.ReadingPlanResponses;
using Business.Dtos.Responses.ReadingPlanResponses;
using Business.Dtos.Responses.ReadingPlanResponses;
using Core.DataAccess.Paging;
using DataAccess.Abstracts;
using DataAccess.Concretes;
using Entities.Concretes;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concretes
{
    public class ReadingPlanManager : IReadingPlanService
    {
        IReadingPlanDal _readingPlanDal;
        IMapper _mapper;

        public ReadingPlanManager(IReadingPlanDal readingPlanDal, IMapper mapper)
        {
            _readingPlanDal = readingPlanDal;
            _mapper = mapper;
        }

        public async Task<CreatedReadingPlanResponse> AddAsync(CreateReadingPlanRequest createReadingPlanRequest)
        {
            // Kitapları veritabanından çek
            var books = await _readingPlanDal.GetBooksByIdsAsync(createReadingPlanRequest.BookIds);

            if (books == null || !books.Any())
                throw new ArgumentException("Belirtilen kitaplar bulunamadı.");

            // ReadingPlan entity'si oluştur
            var readingPlan = new ReadingPlan
            {
                Id = Guid.NewGuid(),
                UserName = createReadingPlanRequest.UserName,
                StartDate = createReadingPlanRequest.StartDate,
                EndDate = createReadingPlanRequest.EndDate,
                Books = books.ToList() // Çekilen kitaplar ekleniyor
            };

            // Veritabanına ekle
            var createdReadingPlan = await _readingPlanDal.AddAsync(readingPlan);

            // Sonuç döndür
            var response = _mapper.Map<CreatedReadingPlanResponse>(createdReadingPlan);
            return response;
        }


        public async Task<DeletedReadingPlanResponse> DeleteAsync(Guid id)
        {
            var data = await _readingPlanDal.GetAsync(i => i.Id == id);
            var result = await _readingPlanDal.DeleteAsync(data);
            var result2 = _mapper.Map<DeletedReadingPlanResponse>(result);
            return result2;
        }

        public async Task<CreatedReadingPlanResponse> GetById(Guid id)
        {
            var result = await _readingPlanDal.GetAsync(rp => rp.Id == id);
            ReadingPlan mappedReadingPlan = _mapper.Map<ReadingPlan>(result);
            CreatedReadingPlanResponse createdReadingPlanResponse = _mapper.Map<CreatedReadingPlanResponse>(mappedReadingPlan);
            return createdReadingPlanResponse;
        }

        public async Task<IPaginate<GetListReadingPlanResponse>> GetListAsync(PageRequest pageRequest)
        {
            var data = await _readingPlanDal.GetListAsync(
               index: pageRequest.PageIndex,
               size: pageRequest.PageSize
           );
            var result = _mapper.Map<Paginate<GetListReadingPlanResponse>>(data);
            return result;
        }

        public async Task<UpdatedReadingPlanResponse> UpdateAsync(UpdateReadingPlanRequest updateReadingPlanRequest)
        {
            var data = await _readingPlanDal.GetAsync(i => i.Id == updateReadingPlanRequest.Id);
            _mapper.Map(updateReadingPlanRequest, data);
            await _readingPlanDal.UpdateAsync(data);
            var result = _mapper.Map<UpdatedReadingPlanResponse>(data);
            return result;
        }
    }
}
