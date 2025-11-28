using Clinic.Application.Interfaces;
using Clinic.Application.Services;

namespace Clinic.DI;

internal static class ApplicationConfigurator
{
    public static IServiceCollection ConfigureApplicationServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<IPatientService, PatientService>();
        services.AddScoped<IDoctorService, DoctorService>();
        services.AddScoped<IDiseaseService, DiseaseService>();

        return services;
    }
}
