using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using OrderProject.Data.DbContexs;
using OrdersProject.Extensions;
using OrdersProject.Middlewares;
using OrdersProject.Service.Exceptions;
using OrdersProject.Service.Helpers;
using OrdersProject.Service.Mappers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<OrdersProjectDbContex>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddControllers().AddNewtonsoftJson(options =>
    options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore);


builder.Services.AddCustomerService();
builder.Services.AddAutoMapper(typeof(MappingProfile));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

EnviromentHelpers.WebRootPath = app.Services.GetRequiredService<IWebHostEnvironment>().WebRootPath;

app.UseMiddleware<OrdersProjectMiddleware>();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
