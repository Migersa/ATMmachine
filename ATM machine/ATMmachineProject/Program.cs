using DI;
using Domain.Mappings;
using Entities.Models;
using Lamar.Microsoft.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

var ConnectionStrings = builder.Configuration.GetConnectionString("ATMdatabase");
builder.Services.AddDbContext<ATMmachine5Context>(options => options.UseSqlServer(ConnectionStrings).UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking));




// Add services to the container.

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAutoMapper(typeof(GeneralProfile));



builder.Services.AddCors(options =>
{
    options.AddPolicy("default", policy => policy.AllowAnyMethod().AllowAnyHeader().AllowAnyOrigin());
});




///e shtuar

builder.Services.AddControllersWithViews()
    .AddJsonOptions(options =>
    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles
);



// use Lamar as DI.
builder.Host.UseLamar((context, registry) =>
{
    // register services using Lamar
    registry.IncludeRegistry<RecrutimentRegistry>();
    registry.IncludeRegistry<MapperRegistry>();
    // add the controllers
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();
app.UseCors("default");

app.Run();
