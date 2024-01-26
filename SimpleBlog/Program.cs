using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using SimpleBlog.Features.Posts.GetPostByIds;
using SimpleBlog.Features.Posts.CreatePosts;
using SimpleBlog.Infrastructure;
using Swashbuckle.Swagger;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

string connection = builder.Configuration.GetValue<string>("ConnectionString:sqlServer");
builder.Services.AddSqlServer<BlogDbContext>(connection);
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "posts", Version = "v1" });
});
builder.Services.AddControllers();
builder.Services.AddScoped<SimpleBlog.Features.Posts.CreatePosts.AppService>();
builder.Services.AddScoped<IValidator<SimpleBlog.Features.Posts.CreatePosts.Input>, SimpleBlog.Features.Posts.CreatePosts.Validator>();

builder.Services.AddScoped<SimpleBlog.Features.Posts.GetPostByIds.AppService>();

builder.Services.AddScoped<SimpleBlog.Features.Posts.EditPosts.AppService>();
builder.Services.AddScoped<IValidator<SimpleBlog.Features.Posts.EditPosts.Input>, SimpleBlog.Features.Posts.EditPosts.Validator>();

builder.Services.AddScoped<SimpleBlog.Features.Posts.DeletePosts.AppService>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
    });

    
}

app.UseHttpsRedirection();

app.Run();