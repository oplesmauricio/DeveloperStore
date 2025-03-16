using Microsoft.EntityFrameworkCore;
using SalesApi.Application.Interfaces;
using SalesApi.Application.Services;
using SalesApi.Domain.Services;
using SalesApi.Domain.Services.Validations;
using SalesApi.Infrastructure.Persistence;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

var connectionString = builder.Configuration.GetConnectionString("Postgres");

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseNpgsql(connectionString));

builder.Services.AddScoped<ISaleService, SaleService>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<ISaleRepository, SaleRepository>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IEventLogger, EventLogger>();
builder.Services.AddScoped<IDiscountStrategy, NoDiscountStrategy>();
builder.Services.AddScoped<IDiscountStrategy, TenPercentDiscountStrategy>();
builder.Services.AddScoped<IDiscountStrategy, TwentyPercentDiscountStrategy>();
builder.Services.AddScoped<IQuantityValidationStrategy, MaxQuantityValidationStrategy>();

builder.Services.AddAutoMapper(typeof(ProfileMapper));

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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