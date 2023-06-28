using HotelFinder.Business.Abstract;
using HotelFinder.Business.Concrete;
using HotelFinder.DataAccess;
using HotelFinder.DataAccess.Abstract;
using HotelFinder.DataAccess.Concrete;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddSingleton<HotelDbContext>();      
builder.Services.AddSingleton<IHotelRepository,HotelRepository>();
builder.Services.AddSingleton<IHotelService,HotelService>();
builder.Services.AddSwaggerDocument(config =>
{
    config.PostProcess = (doc =>
    {
        doc.Info.Title = "ALL HOTEL API";
        doc.Info.Version = "1.0.13";
        doc.Info.Contact = new NSwag.OpenApiContact()
        {
            Name = "Aykut TOPRAK",
            Url = "https://www.google.com",
            Email = "aykut@gmail.com"
        };
    });
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{


}

app.UseRouting();
app.UseOpenApi();
app.UseSwaggerUi3();

app.UseAuthorization();

app.MapControllers();

app.Run();
