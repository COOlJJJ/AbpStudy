using Acme.BookStore.Application.Contracts;
using Acme.BookStore.Domain.Books;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace Acme.BookStore.Application
{
    public class BookAppService :
        CrudAppService<
            Book, //Book实体
            BookDto, //用于展示
            Guid, //实体主键类型
            PagedAndSortedResultRequestDto, //用于分页
            CreateUpdateBookDto>, //用于新增或修改
        IBookAppService //实现IBookAppService
    {
        public BookAppService(IRepository<Book, Guid> repository)
            : base(repository)
        {

        }
    }
}
