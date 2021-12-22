using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using PowerAdmin.UI.Common.RemoteRequest.Extensions;

namespace PowerAdmin.UI.Services.Extensions
{
    public static class ApiServiceCollectionExtensions
    {
        public static IServiceCollection AddServices(this IServiceCollection services, IWebAssemblyHostEnvironment hostEnvironment)
        {
            services.AddRemoteRequest<IUserApi>(options =>
            {
                options.BaseAddress = hostEnvironment.BaseAddress;
            });

            return services;
        }
    }
}
