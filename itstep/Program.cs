using Core.Interfaces;
using Core.MapperProfiles;
using Core.Services;
using Data.Data;
using Data.Entities;
using Data.Repositories;
using FluentValidation;
using FluentValidation.AspNetCore;
using itstep.Middlewares;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddFluentValidationClientsideAdapters();
builder.Services.AddValidatorsFromAssemblies(AppDomain.CurrentDomain.GetAssemblies());

string? connectionString = builder.Configuration.GetConnectionString("LocalDb");

builder.Services.AddDbContext<ITStepDbContext>(opt => opt.UseSqlServer(connectionString));
builder.Services.AddIdentity<User, IdentityRole>(options =>
    options.SignIn.RequireConfirmedAccount = false)
    .AddDefaultTokenProviders()
    .AddEntityFrameworkStores<ITStepDbContext>();

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ITStepDbContext>(options =>
    options.UseSqlServer(connectionString)
);


builder.Services.AddScoped<IEducationService, EducationService>();
builder.Services.AddScoped<IAccountsService, AccountsService>();


builder.Services.AddAutoMapper(typeof(AppProfile));
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

builder.Services.AddExceptionHandler<HttpExceptionHandler>();
builder.Services.AddProblemDetails();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseExceptionHandler();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
