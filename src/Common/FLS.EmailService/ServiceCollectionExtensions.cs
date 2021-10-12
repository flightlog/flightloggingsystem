using FLS.Common.Validators;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace FLS.EmailService
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
