using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Acme.BookStore.Application.Contracts
{
    public interface IBookAppService : IApplicationService
    {
        Task<int> CreateAsync(BookDto input);
        Task<int> DeleteBookByNameAsync(string name);
    }
}
