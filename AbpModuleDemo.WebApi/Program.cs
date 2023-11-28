using AbpModuleDemo.WebApi;

/// <summary>
/// Abp ģ�黯 ����AutoFac Redis 
/// </summary>
var builder = WebApplication.CreateBuilder(args);
builder.Services.ReplaceConfiguration(builder.Configuration);
builder.Host.UseAutofac();
builder.Services.AddApplication<AbpModuleWebApiModule>();

var app = builder.Build();
app.InitializeApplication();

app.MapGet("/TestRecord", () =>
{
    //ѧ����������20
    Student student = new() { Age = 20 };
    Teacher teacher = new(30, 1);
    return teacher;
}).WithName("TestRecord");

app.Run();


