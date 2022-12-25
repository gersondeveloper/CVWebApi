using CVWebApi.DataAccess.Repository.IRepository;
using CVWebApi.Models.Entities;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddScoped<IValidator<Experience>, ExperienceValidator>();
builder.Services.AddScoped<IValidator<Reference>, ReferenceValidator>();
builder.Services.AddScoped<IValidator<Education>, EducationValidator>();
builder.Services.AddScoped<IValidator<PersonalData>, PersonalDataValidator>();
builder.Services.AddScoped<IValidator<Skill>, SkillValidator>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<CVDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

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
