using CarrefourBankTest.Application.Interfaces;
using CarrefourBankTest.Application.Services;
using CarrefourBankTest.Domain.Repositories;
using CarrefourBankTest.Domain.Services;
using CarrefourBankTest.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using CarrefourBankTest.Infrastructure.Context;
using CarrefourBankTest.Domain.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Configure services and dependencies
builder.Services.AddScoped<IAccountRepository, AccountRepository>();
builder.Services.AddScoped<ITransactionRepository, TransactionRepository>();
builder.Services.AddScoped<IAccountService, AccountService>();
builder.Services.AddScoped<IAccountAppService, AccountAppService>();
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("SQLiteConnection")));

// Add services to the container.

builder.Services.AddControllers();
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
