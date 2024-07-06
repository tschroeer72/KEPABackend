using KEPABackend.Interfaces;
using KEPABackend.Repositorys;
using KEPABackend.Validations;

namespace KEPABackend.Services;

public static class DIConfigurations
{
    public static void RegisterServices(IServiceCollection services)
    {
        services.AddScoped<MitgliederService>();
        services.AddScoped<MitgliederValidator>();
        services.AddScoped<IMitgliederRepository, MitgliederRepository>();

        services.AddAutoMapper(typeof(DtoEntityMapperProfile));
    }
}
