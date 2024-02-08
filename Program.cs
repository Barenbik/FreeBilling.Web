using System.Reflection;
using FluentValidation;
using FreeBilling.Web.Apis;
using FreeBilling.Web.Data;
using FreeBilling.Web.Validators;

var builder = WebApplication.CreateBuilder(args);

IConfigurationBuilder configBuilder = builder.Configuration;
configBuilder.Sources.Clear();
configBuilder.AddJsonFile("appSettings.json")    
    .AddUserSecrets(Assembly.GetExecutingAssembly())
    .AddEnvironmentVariables()
    .AddCommandLine(args);

builder.Services.AddDbContext<BillingContext>();
builder.Services.AddScoped<IBillingRepository, BillingRepository>();

builder.Services.AddRazorPages();
builder.Services.AddControllers();

builder.Services.AddValidatorsFromAssemblyContaining<TimeBillModelValidator>();

var app = builder.Build();

// Serve index.html as the default webpage.
app.UseDefaultFiles();

// Serve files from wwwroot.
app.UseStaticFiles();

app.MapRazorPages();

TimeBillsApi.Register(app);

app.MapControllers();

app.Run();
