using Domain.Repositories;
using Infrastructure;
using Microsoft.EntityFrameworkCore;
using Service.Abstractions;
using Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers()
                .AddApplicationPart(typeof(Presantation.AssemblyReference).Assembly);
builder.Services.AddAutoMapper(typeof(MappingProfile).Assembly);

RepositoryDIConfiguration.Configure(builder.Services);
ServicesDIConfiguration.Configure(builder.Services, builder.Configuration);

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(connectionString));


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
