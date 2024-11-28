using AutoMapper;
using Business.Dtos.Requests.BookRequests;
using Business.Dtos.Responses.BookResponses;
using Core.DataAccess.Paging;
using Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Profiles
{
    public class BookProfile:Profile
    {
        public BookProfile()
        {
            CreateMap<CreateBookRequest, Book>().ReverseMap();
            CreateMap<Book, CreatedBookResponse>().ReverseMap();

            CreateMap<DeleteBookRequest, Book>().ReverseMap();
            CreateMap<Book, DeletedBookResponse>().ReverseMap();

            CreateMap<UpdateBookRequest, Book>().ReverseMap();
            CreateMap<Book, UpdatedBookResponse>().ReverseMap();

            CreateMap<Book, GetListBookResponse>().ReverseMap();
            CreateMap<Paginate<Book>, Paginate<GetListBookResponse>>().ReverseMap();
        }
    }
}
