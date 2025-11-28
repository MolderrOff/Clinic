using Clinic.Application.Mapper;
using Clinic.DI;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddCors(options =>
{
    options.AddPolicy("MyCorsPolicy", builder =>
    {
        builder.WithOrigins("http://localhost:5173", "http://localhost:3000")
               .AllowAnyMethod()
               .AllowAnyHeader();
    });
});
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAutoMapper(typeof(MapperProfile).Assembly);
builder.Services.ConfigureModule(builder.Configuration);


builder.Services.AddOpenApi();

var app = builder.Build();

app.UseCors("MyCorsPolicy");

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
