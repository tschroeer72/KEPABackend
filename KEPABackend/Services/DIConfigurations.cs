using KEPABackend.Interfaces;
using KEPABackend.DBServices;
using KEPABackend.Validations;

namespace KEPABackend.Services;

public static class DIConfigurations
{
    public static void RegisterServices(IServiceCollection services)
    {
        services.AddScoped<MitgliederService>();
        services.AddScoped<MitgliederCreateValidator>();
        services.AddScoped<MitgliederUpdateValidator>();
        services.AddScoped<IMitgliederDBService, MitgliederDBService>();

        services.AddAutoMapper(typeof(DtoEntityMapperProfile));
    }
}
