using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Localization;

namespace Acme.BookStore.HttpApi.Controllers
{
    public abstract class BookStoreController : AbpControllerBase
    {
        protected BookStoreController()
        {
           
        }
    }

}
