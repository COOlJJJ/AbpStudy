using Acme.BookStore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.ReplaceConfiguration(builder.Configuration);
builder.Host.UseAutofac();
builder.Services.AddApplication<BookStoreWebApiModule>();//ÃÌº”Application

var app = builder.Build();
app.InitializeApplication();//≥ı ºªØApplication
app.Run();
