using AttendanceTracking.Application.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AttendanceTracking.Persistence;

public static class DependencyInjection
{
    public static IServiceCollection AddPersistence(this IServiceCollection services,
        IConfiguration configuration)
    {
        var connectionsStrings = configuration.GetConnectionString("DefaultConnection");
        services.AddDbContext<AttendanceDbContext>(options =>
        {
            options.UseNpgsql(connectionsStrings);
        });
        services.AddScoped<IAttendanceDbContext>(provider=>
            provider.GetService<AttendanceDbContext>());
        return services;
    }
}