using Core.CrossCuttingConcerns.Caching;
using Core.CrossCuttingConcerns.Caching.Microsoft;
using Core.CrossCuttingConcerns.Logging.SeriLog.Logger;
using Core.Utilities.IoC;
using Microsoft.Extensions.DependencyInjection;
using Serilog;
using System.Diagnostics;

namespace Core.DependencyResolvers;

public class CoreModule : ICoreModule
{
    public void Load(IServiceCollection services)
    {

        services.AddMemoryCache();


        services.AddSingleton<ICachingService, InMemoryCacheManager>();
        services.AddTransient<MsSqlLogger>();
        services.AddTransient<FileLogger>();
        services.AddSingleton(Log.Logger);

        services.AddSingleton<Stopwatch>();
        services.AddHttpContextAccessor();
    }
}
