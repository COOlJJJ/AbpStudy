using AbpModuleDemo.Application.Contracts;
using Volo.Abp.Application;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Modularity;

namespace AbpModuleDemo.Application
{

    [DependsOn(
        typeof(AbpModuleDemoApplicationContractsModule)
        )]
    public class AbpModuleDemoApplicationModule : AbpModule
    {

    }
}
