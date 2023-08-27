using Microsoft.Extensions.DependencyInjection;
using VooIt.Domain.Contracts.Services;
using VooIt.Domain.Services;

namespace VooIT.Common.IoC;

public static class DependencyInjection
{
    public static void AddIoC(this IServiceCollection services)
    {
        services.AddScoped<IWebSiteService, WebSiteService>();
    }
}
