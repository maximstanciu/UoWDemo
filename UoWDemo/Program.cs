using System.Reflection;
using Microsoft.EntityFrameworkCore;
using UoWDemo.Persistence;
using UoWDemo.Repositories;
using MediatR;
using UoWDemo.Behavior;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using UoWDemo.Errors;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddControllers(opt => opt.Filters.Add<UoWDemoExceptionHandlerAttribute>());

builder.Services.AddDbContext<MainDbContext>(options =>
  options.UseSqlite(builder.Configuration.GetConnectionString("MainConnectionString"))
);

builder.Services.AddScoped<IMainDbContext, MainDbContext>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());
builder.Services.AddMediatR(Assembly.GetExecutingAssembly());
builder.Services.AddScoped(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
builder.Services.AddSingleton<ProblemDetailsFactory, UoWDemoProblemDetailsFactory>();


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

