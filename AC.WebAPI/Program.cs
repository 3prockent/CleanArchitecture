using MediatR;
using Microsoft.EntityFrameworkCore;
using CA.Persistence;
using CA.Application.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

//builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddDbContext<ShopDbContext>(options =>
                options.UseSqlServer(
                    builder.Configuration.GetConnectionString("DefaultConnection")));

//builder.Services.AddScoped<IDbContext>(provider => provider.GetService<ShopDbContext>());

builder.Services.AddScoped(typeof(IDbContext), typeof(ShopDbContext));


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
