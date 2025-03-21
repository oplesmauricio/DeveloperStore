using Microsoft.EntityFrameworkCore;
using SalesApi.Application.Handlers.Product;
using SalesApi.Application.Handlers.Sale;
using SalesApi.Application.Interfaces;
using SalesApi.Application.Services;
using SalesApi.Domain.Services;
using SalesApi.Domain.Services.Validations;
using SalesApi.Infrastructure.Persistence;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.WebHost.UseUrls("http://*:8090");
builder.Services.AddControllers();

var connectionString = builder.Configuration.GetConnectionString("Postgres");

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseNpgsql(connectionString));

ConfigureRepositorys(builder);
builder.Services.AddScoped<IEventLogger, EventLogger>();

ConfigureStrategys(builder);

builder.Services.AddMediatR(cfg =>
{
    cfg.RegisterServicesFromAssembly(typeof(CreateProductHandler).Assembly);
    cfg.RegisterServicesFromAssembly(typeof(GetAllProductsHandler).Assembly);
    cfg.RegisterServicesFromAssembly(typeof(CreateSaleHandler).Assembly);
    cfg.RegisterServicesFromAssembly(typeof(GetAllSalesHandler).Assembly);
    cfg.RegisterServicesFromAssembly(typeof(CancelSaleHandler).Assembly);
});


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

static void ConfigureRepositorys(WebApplicationBuilder builder)
{
    builder.Services.AddScoped<ISaleRepository, SaleRepository>();
    builder.Services.AddScoped<IProductRepository, ProductRepository>();
}

static void ConfigureStrategys(WebApplicationBuilder builder)
{
    builder.Services.AddScoped<IDiscountStrategy, NoDiscountStrategy>();
    builder.Services.AddScoped<IDiscountStrategy, TenPercentDiscountStrategy>();
    builder.Services.AddScoped<IDiscountStrategy, TwentyPercentDiscountStrategy>();
    builder.Services.AddScoped<IQuantityValidationStrategy, MaxQuantityValidationStrategy>();
}