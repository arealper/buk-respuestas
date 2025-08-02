using SalesDatePrediction.API.Context;
using SalesDatePrediction.API.Repositories;
using SalesDatePrediction.API.Repositories.Interfaces;
using SalesDatePrediction.API.Services;
using SalesDatePrediction.API.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAngularApp", policy =>
    {
        policy.WithOrigins(["http://localhost:54621", "http://localhost:5017"])
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

// Add services to the container.
builder.Services.AddSingleton<DapperContext>();

builder.Services.AddScoped<ICustomerService, CustomerService>();
builder.Services.AddScoped<IEmployeeService, EmployeeService>();
builder.Services.AddScoped<IOrderService, OrderService>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IShipperService, ShipperService>();

builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IOrderRepository, OrderRepository>();
builder.Services.AddScoped<IShipperRepository, ShipperRepository>();
builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

app.UseCors("AllowAngularApp");

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
