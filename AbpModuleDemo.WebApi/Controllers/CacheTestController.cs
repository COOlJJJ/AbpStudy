using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;
using Volo.Abp.Caching;

namespace AbpModuleDemo.WebApi.Controllers
{
    [Route("api/CacheTest")]
    [ApiController]
    public class CacheTestController : ControllerBase
    {
        private readonly IDistributedCache<DataCacheModel> _cache;

        public CacheTestController(IDistributedCache<DataCacheModel> cache)
        {
            _cache = cache;
        }

        [Route("GetDataAsync")]
        [HttpGet]
        public async Task<DataCacheModel> GetDataAsync(Guid guid)
        {
            var data = await _cache.GetOrAddAsync(guid.ToString(),
                 async () => await GetDataFromDatabaseAsync(guid),
                 () => new DistributedCacheEntryOptions()
                 {
                     AbsoluteExpiration = DateTimeOffset.Now.AddHours(1),
                 });
            return data;
        }

        [HttpGet]
        [Route("GetDataFromDatabaseAsync")]
        public async Task<DataCacheModel> GetDataFromDatabaseAsync(Guid guid)
        {
            await Task.CompletedTask;
            Console.WriteLine("从DB获取数据" + DateTime.Now.ToString());
            return new DataCacheModel
            {
                Id = guid,
                Name = "Dongjie",
                Phone = "123456748"
            };
        }
    }


    public class DataCacheModel
    {
        public Guid? Id { get; set; }
        public string? Name { get; set; }
        public string? Phone { get; set; }
    }
}
