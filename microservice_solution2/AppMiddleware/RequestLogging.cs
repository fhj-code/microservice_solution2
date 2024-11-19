using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace microservice_solution2.Middleware
{
    public static class RequestLoggingExt
    {
        private static RequestLoggingOptions Options = new RequestLoggingOptions();

        public static IApplicationBuilder UseRequestLogging(this IApplicationBuilder builder, params string[] exclude)
        {
            Options.Exclude = exclude;

            return builder.UseMiddleware<RequestLoggingMiddleware>();
        }

        public static IServiceCollection AddRequestLogging(this IServiceCollection services)
        {
            return services.AddSingleton(Options);
        }
    }
}
