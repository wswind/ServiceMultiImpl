//Origin Author is 'T Brown' from https://stackoverflow.com/a/59338701/7726468
//Licence: CC BY-SA 4.0
//Updated by Vincent Wang https://github.com/wswind/ServiceMultiImpl

using ServiceMultiImpl;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddTransient<IService, Service1>();
builder.Services.AddTransient<IService, Service2>();


builder.Services.AddMultiImplServiceFactory<IService, string>()
    .Add<Service1>("1")
    .Add<Service2>("2");

var app = builder.Build();


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
