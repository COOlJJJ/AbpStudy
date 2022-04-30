using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Acme.BookStore.Application.Contracts
{
    public interface IBookAppService :
       ICrudAppService< //定义CRUD方法
           BookDto, //用于展示
           Guid, //实体主键类型
           PagedAndSortedResultRequestDto, //用于分页
           CreateUpdateBookDto> //用于新增或修改
    {

    }
}
