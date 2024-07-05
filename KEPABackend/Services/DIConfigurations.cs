using KEPABackend.Validations;

namespace KEPABackend.Services;

public static class DIConfigurations
{
    public static void RegisterServices(IServiceCollection services)
    {
        services.AddScoped<MitgliederService>();
        services.AddScoped<MitgliederCreateValidator>();

        services.AddAutoMapper(typeof(DtoEntityMapperProfile));
    }
}
