using Acme.BookStore.Application;
using Acme.BookStore.EntityFrameworkCore;
using Acme.BookStore.HttpApi;
using Microsoft.OpenApi.Models;
using Volo.Abp;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Autofac;
using Volo.Abp.Modularity;

namespace Acme.BookStore
{
    [DependsOn(
        typeof(BookStoreHttpApiModule),
        typeof(AbpAutofacModule),
        typeof(AbpAspNetCoreMvcModule),//用到Abp自动生成自动创建Controller方法
        typeof(BookStoreApplicationModule),//用到了Application层，提供服务
        typeof(BookStoreEntityFrameworkCoreModule)
       )]//用到了数据库实现
    public class BookStoreWebApiModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            var hostingEnvironment = context.Services.GetHostingEnvironment();
            var configuration = context.Services.GetConfiguration();

            ConfigureAutoApiControllers();
            ConfigureSwaggerServices(context.Services);
        }

        public override void OnApplicationInitialization(ApplicationInitializationContext context)
        {
            var app = context.GetApplicationBuilder();
            var env = context.GetEnvironment();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();
            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/swagger/v1/swagger.json", "Acme.BookStore.WebApi");
            });

            app.UseRouting();
            app.UseConfiguredEndpoints();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGet("/", async context =>
                {
                    context.Response.Redirect("/swagger");
                });
            });
        }


        private void ConfigureAutoApiControllers()
        {
            Configure<AbpAspNetCoreMvcOptions>(options =>
            {
                //自动创建Controller
                options.ConventionalControllers.Create(typeof(BookStoreApplicationModule).Assembly);
            });
        }


        private void ConfigureSwaggerServices(IServiceCollection services)
        {
            services.AddSwaggerGen(
                options =>
                {
                    options.SwaggerDoc("v1", new OpenApiInfo
                    { Title = "Acme.BookStore.WebApi", Version = "v1.0" });
                    options.DocInclusionPredicate((docName, description) => true);
                    options.CustomSchemaIds(type => type.FullName);
                }
            );
        }
    }
}
