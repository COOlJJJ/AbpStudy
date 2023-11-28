using Acme.BookStore.Domain;
using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.MySQL;
using Volo.Abp.Modularity;

namespace Acme.BookStore.EntityFrameworkCore
{
    [DependsOn(typeof(BookStoreDomainModule),
       typeof(AbpEntityFrameworkCoreMySQLModule))]
    public class BookStoreEntityFrameworkCoreModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddAbpDbContext<BookStoreDbContext>(options =>
            {
                options.AddDefaultRepositories();//添加Abp默认Repositories实现
            });

            Configure<AbpDbContextOptions>(options =>
            {
                options.UseMySQL();//使用Mysql数据库
            });
        }
    }
}