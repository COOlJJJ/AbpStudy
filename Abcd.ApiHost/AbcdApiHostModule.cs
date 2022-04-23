using Book.Application;
using Exam.Application;
using Student.Application;
using Teacher.Application;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Volo.Abp;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Modularity;


namespace Abcd.ApiHost
{
    /// <summary>
    /// 拆分了Swagger模块 作为例子
    /// BookApplicationModule 作为应用模块 ApiHost入口需要哪个服务就挂载哪个服务
    /// </summary>
    [DependsOn(
        typeof(AbpAspNetCoreMvcModule),
        typeof(OpenApiInfoModule),
        typeof(BookApplicationModule),
        typeof(ExamApplicationModule),
        typeof(StudentApplicationModule),
        typeof(TeacherApplicatonModule)
        )]
    public class AbcdApiHostModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            var services = context.Services;

            services.AddControllers();

        }

        public override void OnApplicationInitialization(ApplicationInitializationContext context)
        {

            var env = context.GetEnvironment();
            var app = context.GetApplicationBuilder();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Admin API v1");
                c.RoutePrefix = "";
            });

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }

}
