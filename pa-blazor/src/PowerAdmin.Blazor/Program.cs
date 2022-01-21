using AntDesign.ProLayout;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using PowerAdmin.Blazor;
using PowerAdmin.Blazor.Common.Configuration;
using PowerAdmin.Blazor.Services.Extensions;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");

// ע��ӿڷ���
builder.Services.AddServices(builder.HostEnvironment);

builder.Services.AddAntDesign();

// ����Ӧ��������
builder.Services.Configure<ProSettings>(builder.Configuration.GetSection("ProSettings"));
builder.Services.Configure<AppSettings>(builder.Configuration.GetSection("App"));

await builder.Build().RunAsync();