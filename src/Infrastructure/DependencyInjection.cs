using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using Infrastructure.Repositories;
using Infrastructure.DbContexts;
using Domain.Interfaces;

namespace Microsoft.Extensions.DependencyInjection;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {
        // Setting DBContexts
        var connectionString = configuration.GetConnectionString("DefaultConnection");
        services.AddDbContext<StudentManagementDBContext>(options => options.UseNpgsql(connectionString, o => o.UseNodaTime()));
        services.AddHealthChecks().AddNpgSql(connectionString, "StudentManagementDB");

        AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

        services.AddScoped<IStudentRepository, StudentRepository>();

        return services;
    }
}
