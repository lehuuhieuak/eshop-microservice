namespace Ordering.API
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApiServices(this IServiceCollection services)
        {
            return services;
        }

        // configure the HTTP request lifecycle
        public static WebApplication UseApiServices(this WebApplication app)
        {
            return app;
        }
    }
}
