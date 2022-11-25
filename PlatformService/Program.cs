using Microsoft.EntityFrameworkCore;
using PlatformService.Data;
using PlatformService.Services.Interfaces;
using PlatformService.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<PlatfromDbContext>(opt => opt.UseInMemoryDatabase("TempDatabaseForPlatfrom"));
builder.Services.AddScoped<IPlatformService, PlatformServiceClass>();
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

SeedingData.PrepForPopulatingData(app);
app.Run();
