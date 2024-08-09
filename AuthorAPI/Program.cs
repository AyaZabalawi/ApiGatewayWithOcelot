using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Author.Core.Domain.Entities;
using Author.Infrastucture.Repositories;
using Author.Infrastucture;
using Author.Core.Application.Services;
using Author.Core.Domain.ServiceContracts;
using Author.Core.Domain.RepositoryContracts;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Swagger services
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "AuthorAPI", Version = "v1" });
});

// Custom services
builder.Services.AddScoped<IAuthorRepository, AuthorRepository>();
builder.Services.AddScoped<IAddAuthorService, AddAuthorService>();
builder.Services.AddScoped<IDeleteAuthorService, DeleteAuthorService>();
builder.Services.AddScoped<IUpdateAuthorService, UpdateAuthorService>();
builder.Services.AddScoped<IGetAuthorService, GetAuthorService>();

var app = builder.Build();

// HTTP request pipeline
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

// Middleware configuration
//app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();

// Swagger middleware
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "AuthorAPI V1");
});

app.MapControllers();

app.Run();
