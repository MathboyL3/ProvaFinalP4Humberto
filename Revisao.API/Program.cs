using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Revisao.Application.AutoMapper;
using Revisao.Application.Interfaces;
using Revisao.Application.Services;
using Revisao.Data;
using Revisao.Data.AutoMapper;
using Revisao.Data.Interfaces;
using Revisao.Data.Mongo;
using Revisao.Data.Mongo.Interfaces;
using Revisao.Domain.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.Configure<MongoSettings>(builder.Configuration.GetSection("MongoSettings"));
builder.Services.AddSingleton<IMongoSettings>(provider =>
    provider.GetRequiredService<IOptions<MongoSettings>>().Value);

builder.Services.AddScoped(typeof(IMongoRepository<>), typeof(MongoRepository<>));
builder.Services.AddScoped<IRegistroJogoService, RegistroJogoService>();
builder.Services.AddScoped<IRegistroJogoRepository, RegistroJogoRepository>();

builder.Services.AddAutoMapper(typeof(ApplicationToDomain), typeof(DomainToApplication));
builder.Services.AddAutoMapper(typeof(CollectionToDomain), typeof(DomainToCollection));

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
