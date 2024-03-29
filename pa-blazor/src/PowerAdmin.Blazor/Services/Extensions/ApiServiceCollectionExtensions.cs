﻿namespace PowerAdmin.Blazor.Services.Extensions;

using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using PowerAdmin.Blazor.Common.RemoteRequest.Extensions;

public static class ApiServiceCollectionExtensions {
  public static IServiceCollection
  AddServices(this IServiceCollection services,
              IWebAssemblyHostEnvironment hostEnvironment) {
    services.AddRemoteRequest<IUserApi>(
        options => { options.BaseAddress = hostEnvironment.BaseAddress; });

    return services;
  }
}