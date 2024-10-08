﻿using KEPABackend.DBServices;
using KEPABackend.Validations;
using KEPABackend.Services;
using KEPABackend.DTOs;
using KEPABackend.Interfaces.DBServices;
using KEPABackend.Interfaces.ControllerServices;
using KEPABackend.Models;

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
        services.AddScoped<ILoginService, LoginService>();

        services.AddTransient<IMitgliederDBService, MitgliederDBService>();
        services.AddTransient<IMitgliederService, MitgliederService>();
        services.AddTransient<MitgliederCreateValidator>();
        services.AddTransient<MitgliederUpdateValidator>();

        services.AddTransient<IMeisterschaftstypenDBService, MeisterschaftstypenDBService>();
        services.AddTransient<IMeisterschaftstypenService, MeisterschaftstypenService>();

        services.AddTransient<IMeisterschaftDBService, MeisterschaftDBService>();
        services.AddTransient<IMeisterschaftService, MeisterschaftService>();
        services.AddTransient<MeisterschaftCreateValidator>();
        services.AddTransient<MeisterschaftUpdateValidator>();

        services.AddTransient<ISpieleingabeDBService, SpieleingabeDBService>();
        services.AddTransient<ISpieleingabeService, SpieleingabeService>();
        services.AddTransient<SpieltagCreateValidator>();
        services.AddTransient<NeunerRattenUpdateValidator>();
        services.AddTransient<Spiel6TageRennenUpdateValidator>();
        services.AddTransient<SpielBlitztunierUpdateValidator>();
        services.AddTransient<SpielMeisterschaftUpdateValidator>();
        services.AddTransient<SpielKombimeisterschaftCreateValidator>();
        services.AddTransient<SpielKombimeisterschaftUpdateValidator>();
        services.AddTransient<SpielPokalUpdateValidator>();
        services.AddTransient<SpielSargkegelnUpdateValidator>();

        services.AddTransient<ISpielergebnisseDBService, SpielergebnisseDBService>();
        services.AddTransient<ISpielergebnisseService, SpielergebnisseService>();

        //services.AddTransient<IdentitySeed>();

        services.AddAutoMapper(typeof(DtoEntityMapperProfile));
    }
}
