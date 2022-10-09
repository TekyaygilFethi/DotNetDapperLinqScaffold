using Dapper.Extensions.Linq.CastleWindsor;
using Dapper.Extensions.Linq.Core.Configuration;
using DapperLinqScaffold.Business.DapperFolder.Dialects;
using DapperLinqScaffold.Business.DapperFolder.Mappers;
using DapperLinqScaffold.Business.Services.HeroServiceFolder;
using DapperLinqScaffold.Business.UnitOfWorkFolder;
using DapperLinqScaffold.Database.DbContexts;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
IConfiguration configuration = builder.Configuration;

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


#region UnitOfWork Injection
builder.Services.AddTransient<IUnitOfWork, UnitOfWork>();
#endregion


#region DbContext Injection
builder.Services.AddDbContext<DapperLinqScaffoldDbContext>(options =>
{
    options.UseNpgsql(configuration.GetConnectionString("PostgreSQLConnString"));
    options.EnableSensitiveDataLogging();
});
#endregion

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

DapperConfiguration.Use()
                  .UseClassMapper(typeof(CustomTableMapper<>))
                  .UseContainer<ContainerForWindsor>(c => c.UseExisting(new Castle.Windsor.WindsorContainer()))
                  .UseSqlDialect(new CustomPostgreSqlDialect())
                  .Build();

app.Run();
