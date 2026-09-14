using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using SmartX.Clients;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

// IMPORTANT: Change 5001 to match the port of your API (Check SmartX System/Properties/launchSettings.json)
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:5012 /") });

await builder.Build().RunAsync();