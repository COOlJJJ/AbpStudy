using Acme.BookStore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.ReplaceConfiguration(builder.Configuration);
builder.Host.UseAutofac();
builder.Services.AddApplication<BookStoreWebApiModule>();//���Application

var app = builder.Build();
app.InitializeApplication();//��ʼ��Application
app.Run();
