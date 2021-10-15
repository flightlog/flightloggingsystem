using FLS.Common.Validators;
using FLS.EmailService;
using System;

/// <summary>
/// Namespace should be taken from DI
/// <seealso cref="https://docs.microsoft.com/en-us/dotnet/core/extensions/dependency-injection-usage"/>
/// </summary>
namespace Microsoft.Extensions.DependencyInjection
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddMailService(this IServiceCollection services, Action<EmailServiceSettings> options)
        {
            services.AddTransient<IEmailService, MailkitEmailService>();

            options.ArgumentNotNull(nameof(options));

            services.Configure(options);

            return services;
        }
    }
}
