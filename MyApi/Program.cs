using Data;
using Data.Repositories;
using ElmahCore.Mvc;
using ElmahCore.Sql;
using Microsoft.EntityFrameworkCore;
using NLog;
using NLog.Web;
using System.Net;
using WebFramework.Middlewares;

var builder = WebApplication.CreateBuilder(args);

builder.Logging.ClearProviders();
builder.WebHost.UseNLog();

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
	options.UseSqlServer(builder.Configuration.GetConnectionString("SqlServer"));
});

builder.Services.AddElmah<SqlErrorLog>(options =>
{
	options.Path = "/elmah-errors";
	options.ConnectionString = builder.Configuration.GetConnectionString("Elmah");
});

builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddScoped<IUserRepository, UserRepository>();

var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseCustomExceptionHandler();
app.UseHttpsRedirection();

app.UseAuthorization();

app.UseElmah();

app.MapControllers();


//Set deafult proxy
WebRequest.DefaultWebProxy = new WebProxy("http://127.0.0.1:8118", true) { UseDefaultCredentials = true };

var logger = LogManager.GetCurrentClassLogger();

try
{
	logger.Debug("init main");
	app.Run();
}
catch (Exception ex)
{
	//NLog: catch setup errors
	logger.Error(ex, "Stopped program because of exception");
	throw;
}
finally
{
	// Ensure to flush and stop internal timers/threads before application-exit (Avoid segmentation fault on Linux)
	LogManager.Shutdown();
}
