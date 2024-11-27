using Core.CrossCuttingConcerns.Authorization;
using Core.CrossCuttingConcerns.Caching;
using Core.CrossCuttingConcerns.Logging.SeriLog;
using Microsoft.AspNetCore.Builder;

namespace Core.Extensions;

public static class MiddlewareExtensions
{
    public static void ConfigureCustomExceptionMiddleware(this IApplicationBuilder app)
        => app.UseMiddleware<ExceptionMiddleware>().
        UseMiddleware<AuthorizationMiddleware>().
        UseMiddleware<ValidationMiddleware>().
        UseMiddleware<CacheMiddleware>().
        UseMiddleware<SeriLogMiddleware>().
        UseMiddleware<AuthorizationMiddleware>();
} 