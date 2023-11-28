using AbpModuleDemo.Application.Contracts;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp;
using Volo.Abp.Application.Services;

namespace AbpModuleDemo.Application
{
    /// <summary>
    /// RemoteService 动态Api Abp框架会识别一些基础的方法转成Api 也可以自己定义和常规的方式一样   这边不要漏了在Api那边注入Autofac！！
    /// Auto Api就可以不需要Api控制器了 直接将应用层Service变成可以访问的Api接口 否则将需要Api层
    /// </summary>

    [RemoteService]
    public class DemoService : ApplicationService, IDemoService
    {
        public async Task<DemoDto> GetAsync(int id)
        {
            await Task.CompletedTask;
            return new DemoDto { Id = id, Description = "************", Name = "XiaoTian" };
        }
    }
}