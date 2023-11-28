using Acme.BookStore.Application.Contracts;
using Volo.Abp.Modularity;

namespace Acme.BookStore.HttpApi
{


    [DependsOn(
        typeof(BookStoreApplicationContractsModule)
    )]
    public class BookStoreHttpApiModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {

        }

    }
}
