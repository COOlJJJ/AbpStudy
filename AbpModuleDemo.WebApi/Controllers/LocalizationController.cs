using AbpModuleDemo.WebApi.Localizations;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using Volo.Abp.Localization;

namespace AbpModuleDemo.WebApi.Controllers
{
    /// <summary>
    /// 本地化测试
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class LocalizationController : ControllerBase
    {
        private readonly IStringLocalizer<TestResource> _stringLocalizer;

        public LocalizationController(IStringLocalizer<TestResource> stringLocalizer)
        {
            _stringLocalizer = stringLocalizer;
        }

        [HttpGet]
        [Route("GetName")]
        public string GetName()
        {
            //切换语言
            CultureHelper.Use("cn");

            var Name = _stringLocalizer.GetString("HelloWorld");
            var Name2 = _stringLocalizer["HelloWorld"];
            //参数化
            var Name3 = _stringLocalizer["Welcome", "Dong Jie"];
            return Name + Name2;
        }
    }
}
