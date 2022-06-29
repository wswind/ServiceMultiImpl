using ServiceMultiImpl;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddTransient<IService, Service1>();
builder.Services.AddTransient<IService, Service2>();

builder.Services.AddFactory<IService, string>()
    .Add<Service1>("1")
    .Add<Service2>("2");

var app = builder.Build();


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
