using DataAccess.Abstracts;
using DataAccess.Concretes;
using DataAccess.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DataAccess;

public static class DataAccessServiceRegistration
{
    public static IServiceCollection AddDataAccessServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<BookShelfContext>(options => options.UseSqlServer(configuration.GetConnectionString("BookShelfContext")));

      
        services.AddScoped<IUserDal, EfUserDal>();
        services.AddScoped<IBookDal, EfBookDal>();
       
        services.AddScoped<IOperationClaimDal, EfOperationClaimDal>();
        services.AddScoped<IUserOperationClaimDal, EfUserOperationClaimDal>();
        services.AddScoped<IOperationClaimDal, EfOperationClaimDal>();



        return services;
    }
}