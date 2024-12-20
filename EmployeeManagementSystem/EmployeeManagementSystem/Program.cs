using EMSDataAccess;
using EMSDataAccess.Managers;
using Microsoft.EntityFrameworkCore;
using Telerik.Reporting.Services;

var builder = WebApplication.CreateBuilder(args);

Environment.SetEnvironmentVariable("ASPNETCORE_ENVIRONMENT", "Development"); 
builder.Configuration.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true).AddEnvironmentVariables();
builder.Configuration.AddJsonFile($"appsettings.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT")}.json").AddEnvironmentVariables();

#region Services
builder.Services.AddScoped<IEmployee, EmployeeManager>();
#endregion Services

// Add services to the container.
builder.Services.AddRazorPages();

string dbCon = builder.Configuration.GetValue<string>("DbConnections:Local");
CommonLib.Utils.ConnectionString = dbCon;


builder.Services.AddDbContext<EMSModel>(
    op => op.UseSqlServer(dbCon, x => x.MigrationsAssembly("EMSDataAccess")
    .CommandTimeout(90).MinBatchSize(1).MaxBatchSize(40).UseQuerySplittingBehavior(QuerySplittingBehavior.SingleQuery)), ServiceLifetime.Transient);

builder.Services.AddKendo();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
