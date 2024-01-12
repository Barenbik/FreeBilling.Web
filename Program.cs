using System.Reflection;
using FreeBilling.Web.Data;

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

var app = builder.Build();

// Serve index.html as the default webpage.
app.UseDefaultFiles();

// Serve files from wwwroot.
app.UseStaticFiles();

app.MapRazorPages();
app.MapControllers();

app.Run();
