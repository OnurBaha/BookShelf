using System.Reflection;
using Business.Abstracts;
using Business.Concrete;
using Business.Concretes;
using Core.Business.Rules;
using Core.Utilities.Helpers;
using Core.Utilities.Security.JWT;
using DataAccess.Abstracts;
using Microsoft.Extensions.DependencyInjection;


namespace Business;

public static class BusinessServiceRegistration
{
    public static IServiceCollection AddBusinessServices(this IServiceCollection services)
    {
        services.AddScoped<IAuthService, AuthManager>();
        services.AddScoped<ITokenHelper, JwtHelper>();
        services.AddScoped<IUserService, UserManager>();
        services.AddScoped<IOperationClaimService, OperationClaimManager>();
        services.AddScoped<IUserOperationClaimService, UserOperationClaimManager>();
        services.AddScoped<IBookService, BookManager>();



        services.AddScoped<IOperationClaimService, OperationClaimManager>();
        services.AddScoped<IFileHelper, FileHelper>();
   
        services.AddScoped<IFileHelper, FileHelper>();
        services.AddScoped<FileBusinessRules>();
        services.AddScoped<IMailService, MailManager>();



        services.AddAutoMapper(Assembly.GetExecutingAssembly());
        services.AddSubClassesOfType(Assembly.GetExecutingAssembly(), typeof(BaseBusinessRules));
        return services;

    }

    public static IServiceCollection AddSubClassesOfType(
        this IServiceCollection services,
        Assembly assembly,
        Type type,
        Func<IServiceCollection, Type, IServiceCollection>? addWithLifeCycle = null)
    {
        var types = assembly.GetTypes().Where(t => t.IsSubclassOf(type) && type != t).ToList();
        foreach (var item in types)
            if (addWithLifeCycle == null)
                services.AddScoped(item);

            else
                addWithLifeCycle(services, type);
        return services;
    }
}