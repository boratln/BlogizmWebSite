using Blogizm.Application.Features.CQRS.Handlers.AboutBannerHandlers;
using Blogizm.Application.Features.CQRS.Handlers.AboutHandlers;
using Blogizm.Application.Interfaces;
using Blogizm.Persistence.Context;
using Blogizm.Persistence.Repositories;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<BlogContext>();
//About
builder.Services.AddScoped<GetAboutQueryHandler>();
builder.Services.AddScoped<GetAboutByIdQueryHandler>();
builder.Services.AddScoped<RemoveAboutCommandHandler>();
builder.Services.AddScoped<CreateAboutCommandHandler>();
builder.Services.AddScoped<UpdateAboutCommandHandler>();
//About Banner
builder.Services.AddScoped<GetAboutBannerQueryHandler>();
builder.Services.AddScoped<GetAboutBannerByIdQueryHandler>();
builder.Services.AddScoped<RemoveAboutBannerCommandHandler>();
builder.Services.AddScoped<CreateAboutBannerCommandHandler>();
builder.Services.AddScoped<UpdateAboutBannerCommandHandler>();
//Author
builder.Services.AddScoped<GetAuthorQueryHandler>();
builder.Services.AddScoped<GetAuthorByIdQueryHandler>();
builder.Services.AddScoped<RemoveAuthorCommandHandler>();
builder.Services.AddScoped<CreateAuthorCommandHandler>();
builder.Services.AddScoped<UpdateAuthorCommandHandler>();
//Client
builder.Services.AddScoped<GetClientQueryHandler>();
builder.Services.AddScoped<GetClientByIdQueryHandler>();
builder.Services.AddScoped<RemoveClientCommandHandler>();
builder.Services.AddScoped<CreateClientCommandHandler>();
builder.Services.AddScoped<UpdateClientCommandHandler>();
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
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
