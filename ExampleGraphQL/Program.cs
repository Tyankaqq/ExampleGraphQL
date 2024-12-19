using CarRentalGraphQL;
using CarRentalGraphQL.Data;
using Microsoft.AspNetCore.Builder; // Добавьте это пространство имен
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection; // Добавьте это пространство имен
using Microsoft.Extensions.Hosting;

// Создание и настройка приложения
var builder = WebApplication.CreateBuilder(args);

// Настройка сервисов
builder.Services.AddDbContext<RentalDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddGraphQLServer().AddQueryType<Query>().AddMutationType<Mutation>().AddProjections().AddFiltering().AddSorting();

// Создание экземпляра приложения
var app = builder.Build();

// Настройка конвейера
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var dbContext = services.GetRequiredService<RentalDbContext>();
    dbContext?.Database.EnsureCreated();
    DataSeeder.SeedData(dbContext!);
}

app.MapGraphQL("/graphql");

app.Run();
