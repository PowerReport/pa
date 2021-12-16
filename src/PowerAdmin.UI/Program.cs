using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using PowerAdmin.UI;
using PowerAdmin.UI.Models;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddAntDesign();
builder.Services.Configure<AppSettings>(builder.Configuration.GetSection("ProSettings"));

await builder.Build().RunAsync();