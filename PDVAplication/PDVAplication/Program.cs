using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using PDVAplication.Data.Context;
using PDVAplication.Shared.Mapper;
using PDVAplications.Ioc.Dependeces;
using static System.Runtime.InteropServices.JavaScript.JSType;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddDbContext<AppDbContext>(options =>
            options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"),
            x => x.MigrationsAssembly("PDVAplication")));

// dotnet ef migrations add Init -o Data\Migrations -s RELATIVE_PATH_TO_STARTUP_PROJECT

builder.Services.AddMediatRApi();
builder.Services.AddDepencies();
builder.Services.AddAutoMapper(cfg => { }, typeof(PDVAplicationMappingProfile));


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

app.Run();
