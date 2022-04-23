using System;
using Volo.Abp.Application;
using Volo.Abp.Modularity;

namespace Book.Application
{
    [DependsOn(typeof(AbpDddApplicationModule))]

    public class BookApplicationModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {

        }
    }
}
