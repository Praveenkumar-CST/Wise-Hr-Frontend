using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using WiseHR;
using WiseHR.Services;
using MudBlazor.Services;
using MudBlazor;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

//  Root components
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

//  Base address for API requests
var backendBaseUrl = "http://localhost:5243/"; // 👈 Update if backend URL changes

//  MudBlazor config
builder.Services.AddMudServices(config =>
{
    config.SnackbarConfiguration.PositionClass = Defaults.Classes.Position.TopCenter;
    config.SnackbarConfiguration.HideTransitionDuration = 100;
    config.SnackbarConfiguration.ShowTransitionDuration = 100;
    config.SnackbarConfiguration.VisibleStateDuration = 3000;
});

//  Register services
builder.Services.AddScoped<AuthService>();
builder.Services.AddScoped<EmployeeService>();
builder.Services.AddScoped<BankingService>();
builder.Services.AddScoped<ExperienceService>();
builder.Services.AddScoped<IUserService, UserService>();

// HttpClient with backend base URI
builder.Services.AddScoped(sp => new HttpClient
{
    BaseAddress = new Uri(backendBaseUrl)
});

await builder.Build().RunAsync();
