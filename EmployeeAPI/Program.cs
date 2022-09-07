using EmployeeAPI.Data;
using EmployeeAPI.ExceptionHandler;
using EmployeeAPI.Repo.Interfaces;
using EmployeeAPI.Repo.Repositories;
using EmployeeAPI.Service.Interfaces;
using EmployeeAPI.Service.Repositories;
using EmployeeAPI.Service.ServiceExceptionHandler;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//register dependencies here. Register both the base repository and employee repository
#region register dependencies
builder.Services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
builder.Services.AddScoped<ICustomService<Employee>, EmployeeService>();
builder.Services.AddScoped<IQueryExHandler, QueryExHandler>();
builder.Services.AddScoped<IServiceQueryExHandler, ServiceQueryExHandler>();
#endregion register dependencies



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
