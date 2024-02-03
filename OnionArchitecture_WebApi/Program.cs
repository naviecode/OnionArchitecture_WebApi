using Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using Persistence;
using Persistence.Repositories;
using Services;
using Services.Abstractions;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//dieu huong toi library  mong muon
builder.Services.AddControllers().AddApplicationPart(typeof(Presentation.AssemblyReference).Assembly);
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Add Services
builder.Services.AddScoped<IServiceManager, ServiceManger>();
builder.Services.AddScoped<IRepositoryManager, RepositoryManager>();

//Add DbContext
builder.Services.AddDbContext<RepositoryDbContext>(options =>
{
    var connectString = builder.Configuration.GetConnectionString("DataBase");
    options.UseSqlServer(connectString, x=>x.MigrationsAssembly("OnionArchitecture_WebApi"));
});

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
