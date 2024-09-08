using MediatR;
using Microsoft.EntityFrameworkCore;
using CA.Persistence;
using CA.Application.Interfaces;
using CA.Application.Repositories;
using CA.Application.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddDbContext<ShopDbContext>(options =>
                options.UseSqlServer(
                    builder.Configuration.GetConnectionString("DockerConnection")));

builder.Services.AddStackExchangeRedisCache(options =>
{
    options.Configuration = builder.Configuration.GetValue<String>("CacheSettings:DockerConnectionString");
});

builder.Services.AddScoped(typeof(IDbContext), typeof(ShopDbContext));
builder.Services.AddScoped(typeof(ICartRepository), typeof(CartRepository));
builder.Services.AddScoped(typeof(ICartService), typeof(CartService));
builder.Services.AddScoped(typeof(ICatalogService), typeof(CatalogService));
builder.Services.AddScoped(typeof(IOrderService), typeof(OrderService));



builder.Services.AddMediatR(AppDomain.CurrentDomain.GetAssemblies()); //application

var app = builder.Build();

#region Configuration

if (builder.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();

    app.UseRouting();
    app.UseAuthorization();
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "CleanArchitecture");
    });
    app.MapControllers();
}
#endregion



app.Run();
