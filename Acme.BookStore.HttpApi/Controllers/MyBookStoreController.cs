using Acme.BookStore.Application.Contracts;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acme.BookStore.HttpApi.Controllers
{
    /* Inherit your controllers from this class.
  */
    // [ApiController]
    [ControllerName("TheMyBookStore")]
    [Route("api/book")]
    public class MyBookStoreController(IBookAppService bookAppService) : BookStoreController
    {
        private readonly IBookAppService _bookAppService = bookAppService;

        [Route("getMyBookName")]
        [HttpGet]
        public async Task<int> GetMyBookName(BookDto BookDto)
        {
            int i = await _bookAppService.CreateAsync(BookDto);
            return 1;
        }

        [Route("deleteBook")]
        [HttpPost]
        public async Task<int> DeleteBook(string Name)
        {
            int i = await _bookAppService.DeleteBookByNameAsync(Name);
            return 1;
        }
    }

}
