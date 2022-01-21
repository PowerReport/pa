using Refit;

namespace PowerAdmin.Blazor.Common.RemoteRequest.Extensions
{
    public static class RemoteRequestServiceCollectionExtensions
    {
        public static IServiceCollection AddRemoteRequest<IApi>(this IServiceCollection services, Action<RemoteRequestOptions> options) where IApi : class
        {
            var remoteRequestOptions = new RemoteRequestOptions();
            options.Invoke(remoteRequestOptions);

            services.AddRefitClient<IApi>()
                .ConfigureHttpClient(httpClient =>
                {
                    httpClient.BaseAddress = new Uri(remoteRequestOptions.BaseAddress);
                });

            return services;
        }
    }

    public class RemoteRequestOptions
    {
        public string BaseAddress { get; set; } = default!;
    }
}
