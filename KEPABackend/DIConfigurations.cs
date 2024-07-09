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
        services.AddScoped<MitgliederService>();
        services.AddScoped<MitgliederCreateValidator>();
        services.AddScoped<MitgliederUpdateValidator>();
        services.AddScoped<IMitgliederDBService, MitgliederDBService>();

        services.AddScoped<MeisterschaftstypenService>();
        services.AddScoped<IMeisterschaftstypenDBService, MeisterschaftstypenDBService>();

        services.AddScoped<MeisterschaftService>();
        services.AddScoped<MeisterschaftCreateValidator>();
        services.AddScoped<IMeisterschaftsDBService, MeisterschaftDBService>();

        services.AddAutoMapper(typeof(DtoEntityMapperProfile));
    }
}
