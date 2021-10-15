using FLS.Server.WebApi.Middleware;
using Microsoft.AspNetCore.Builder;

/// <summary>
/// Namespace should be taken from DI
/// <seealso cref="https://docs.microsoft.com/en-us/dotnet/core/extensions/dependency-injection-usage"/>
/// </summary>
namespace Microsoft.Extensions.DependencyInjection
{
    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class ExceptionMiddlewareExtensions
    {
        public static IApplicationBuilder UseExceptionMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ExceptionMiddleware>();
        }
    }
}
