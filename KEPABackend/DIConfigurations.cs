using KEPABackend.Interfaces;
using KEPABackend.DBServices;
using KEPABackend.Validations;
using KEPABackend.Services;
using KEPABackend.DTOs;

namespace KEPABackend;

/// <summary>
/// Dependency Injection Konfigurationen
/// </summary>
public static class DIConfigurations
{
    /// <summary>
    /// Dependency Injection Konfigurationen
    /// </summary>
    /// <param name="services"></param>
    public static void RegisterServices(IServiceCollection services)
    {
        services.AddTransient<IMitgliederDBService, MitgliederDBService>();
        services.AddTransient<MitgliederService>();
        services.AddTransient<MitgliederCreateValidator>();
        services.AddTransient<MitgliederUpdateValidator>();

        services.AddTransient<IMeisterschaftstypenDBService, MeisterschaftstypenDBService>();
        services.AddTransient<MeisterschaftstypenService>();

        services.AddTransient<IMeisterschaftDBService, MeisterschaftDBService>();
        services.AddTransient<MeisterschaftService>();
        services.AddTransient<MeisterschaftCreateValidator>();

        services.AddAutoMapper(typeof(DtoEntityMapperProfile));
    }
}
