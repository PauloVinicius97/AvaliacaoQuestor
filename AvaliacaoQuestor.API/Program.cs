using Autofac;
using Autofac.Extensions.DependencyInjection;
using AvaliacaoQuestor.Application.AutoMapper;
using AvaliacaoQuestor.Infra.CrossCutting.IOC;
using AvaliacaoQuestor.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// AutoMapper
builder.Services.AddAutoMapper(typeof(DomainToViewModelMappingProfile), typeof(ViewModelToDomainMappingProfile));

// AutoFac
builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
builder.Host.ConfigureContainer<ContainerBuilder>(builder =>
{
    builder.RegisterModule(new ModuleIOC());
});

// Entity Framework
builder.Services.AddDbContext<AvaliacaoQuestorContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("AvaliacaoQuestorDB"), b => b.MigrationsAssembly("AvaliacaoQuestor.Infra")));

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
