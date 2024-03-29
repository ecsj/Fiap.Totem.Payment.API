using Application.Interfaces;
using Infra.MessageQueue;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Diagnostics.CodeAnalysis;

namespace Infra;
[ExcludeFromCodeCoverage]

public class Dependencies
{
    public static IServiceCollection ConfigureServices(IConfiguration configuration, IServiceCollection services)
    {
        services.AddSingleton<IMessageQueueService, RabbitMQService>();

        return services;
    }
}
