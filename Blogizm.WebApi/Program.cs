using Blogizm.Application.Interfaces;
using Blogizm.Persistence.Repositories;
using Blogizm.Application.Services;
using Blogizm.Persistence.Context;
using Blogizm.Application.Containers;
using Blogizm.Persistence.Repositories.BlogCategoryRepositories;
using Blogizm.Application.Interfaces.BlogCategoryInterfaces;
using Blogizm.Persistence.Repositories.BlogRepositories;
using Blogizm.Application.Interfaces.BlogInterfaces;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<BlogContext>();
// CQRS handlers
builder.Services.ContainerDependecies();
//Mediator
builder.Services.AddApplicationService(builder.Configuration);
//Repositories
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddScoped(typeof(IBlogCategoryRepository), typeof(BlogCategoryRepository));
builder.Services.AddScoped(typeof(IBlogRepository), typeof(BlogRepository));
var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
