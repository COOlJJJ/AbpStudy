using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;
using Volo.Abp.Localization;

namespace Acme.BookStore.Application
{
    public abstract class BookStoreAppService : ApplicationService
    {
        protected BookStoreAppService()
        {

        }
    }
}
