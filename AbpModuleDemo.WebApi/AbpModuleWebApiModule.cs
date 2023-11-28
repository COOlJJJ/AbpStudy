using AbpModuleDemo.Application;
using AbpModuleDemo.WebApi.Localizations;
using Microsoft.Extensions.Caching.StackExchangeRedis;
using Microsoft.OpenApi.Models;
using Volo.Abp;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Autofac;
using Volo.Abp.Caching;
using Volo.Abp.Caching.StackExchangeRedis;
using Volo.Abp.Localization;
using Volo.Abp.Modularity;
using Volo.Abp.VirtualFileSystem;

[DependsOn(
    typeof(AbpAspNetCoreMvcModule),
    typeof(AbpCachingStackExchangeRedisModule),
    typeof(AbpLocalizationModule),
    //AbpAutofacModule 不能漏 不然Auto Api无法使用
    typeof(AbpAutofacModule),
    //typeof(AbpCachingModule)
    typeof(AbpModuleDemoApplicationModule)
    )]
public class AbpModuleWebApiModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        var service = context.Services;
        Configure<RedisCacheOptions>(options =>
        {
            options.Configuration = "127.0.0.1:6379,defaultDatabase=4,password=Aa123456";
            options.InstanceName = "Abcd";
        });

        Configure<AbpVirtualFileSystemOptions>(options =>
        {
            // "YourRootNameSpace" 是项目的根命名空间名字. 如果你的项目的根命名空间名字为空,则无需传递此参数.
            options.FileSets.AddEmbedded<AbpModuleWebApiModule>("AbpModuleDemo.WebApi");
        });

        Configure<AbpLocalizationOptions>(options =>
        {
            options.Resources
                .Add<TestResource>("en")
                .AddVirtualJson("/Localizations");

        });

        Configure<AbpAspNetCoreMvcOptions>(options =>
        {
            options.ConventionalControllers
                   .Create(typeof(AbpModuleDemoApplicationModule).Assembly, options =>
                   {
                       //路由默认以Api开头 /api/Test/ServiceName/...
                       options.RootPath = "Test";
                   });
        });

        service.AddControllers();
        service.AddEndpointsApiExplorer();

        service.AddSwaggerGen(options =>
        {
            options.SwaggerDoc("v1", new OpenApiInfo { Title = "Demo API", Version = "v1" });
            options.DocInclusionPredicate((docName, descrption) => true);
            options.CustomSchemaIds(type => type.FullName);
        });
    }
    public override void OnApplicationInitialization(ApplicationInitializationContext context)
    {
        var app = (WebApplication)context.GetApplicationBuilder();

        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }
        app.MapControllers();
    }
}