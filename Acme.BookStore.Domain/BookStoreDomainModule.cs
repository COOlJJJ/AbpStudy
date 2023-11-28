using Acme.BookStore.Domain.Shared;
using Volo.Abp.Modularity;

/// <summary>
/// Acme.BookStore.Domain包含你的实体, 领域服务和其他核心域对象.
/// </summary>
namespace Acme.BookStore.Domain
{
    [DependsOn(
        typeof(BookStoreDomainSharedModule)
    )]
    public class BookStoreDomainModule : AbpModule
    {

    }
}