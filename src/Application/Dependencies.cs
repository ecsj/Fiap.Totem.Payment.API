using System.Diagnostics.CodeAnalysis;
using Application.Interfaces;
using Application.UseCases;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Application;

[ExcludeFromCodeCoverage]
public class Dependencies
{
    public static IServiceCollection ConfigureServices(IConfiguration configuration, IServiceCollection services)
    {        
        services.AddScoped<IPaymentService, PaymentService>();

        return services;
    }
}