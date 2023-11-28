using Volo.Abp.Application.Services;

namespace AbpModuleDemo.Application.Contracts
{
    public interface IDemoService:IApplicationService
    {
        Task<DemoDto> GetAsync(int id);
    }
}