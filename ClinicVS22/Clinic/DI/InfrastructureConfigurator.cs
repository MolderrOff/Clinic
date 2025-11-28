using Clinic.Domain.Interfaces;
using Clinic.Infrastructure.Persistens;
using Clinic.Infrastructure.Persistens.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Clinic.DI;

internal static class InfrastructureConfigurator
{
    public static void ConfigureInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("SqlConnection");
        services.AddDbContext<ApplicationDbContext>(options =>
        {
            options.UseSqlServer(connectionString,
                x => x.MigrationsHistoryTable("__EFMigrationsHistory"));
        });

        ConfigureRepositories(services, configuration);
    }
    public static void ConfigureRepositories(IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<IPatientRepository, PatientRepository>();
        services.AddScoped<IDiseaseRepository, DiseaseRepository>();
        services.AddScoped<IDoctorRepository, DoctorRepository>();
    }
}
