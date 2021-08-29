using Core.Payments.Options;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using Microsoft.Extensions.Options;
using Core.Payments.Interfaces;
using Core.Payments.Implements;
using PayPalCheckoutSdk.Core;

namespace Core.Payments.Infrastructure
{
    public static class PaymentExtension
    {
        public static IServiceCollection AddPayPal(this IServiceCollection services, Action<PayPalOption> action)
        {
            services.Configure(action);

            services.AddScoped((provider) =>
            {
                var option = provider.GetRequiredService<IOptions<PayPalOption>>()?.Value;
                return new SandboxEnvironment(option?.ClientId, option?.ClientSecret);
            });

            services.AddTransient<IPayPalService, PaypalService>();

            return services;
        }
    }
}
