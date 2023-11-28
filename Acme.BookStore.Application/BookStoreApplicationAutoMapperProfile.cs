using Acme.BookStore.Application.Contracts;
using Acme.BookStore.Domain.Books;
using AutoMapper;

namespace Acme.BookStore.Application
{
    public class BookStoreApplicationAutoMapperProfile : Profile
    {
        public BookStoreApplicationAutoMapperProfile()
        {
            CreateMap<Book, BookDto>().ReverseMap();
        }
    }
}
