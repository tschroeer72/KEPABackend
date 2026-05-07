using KEPABackend.Models;
using HotChocolate.Data;
using KEPABackend.Interfaces.ControllerServices;
using KEPABackend.DTOs.Output;

namespace KEPABackend.GraphQL;

public class Query
{
    [UsePaging]
    [UseProjection]
    [UseFiltering]
    [UseSorting]
    public IQueryable<TblMitglieder> GetMitglieder(ApplicationDbContext context) 
        => context.TblMitglieders;

    [UsePaging]
    [UseProjection]
    [UseFiltering]
    [UseSorting]
    public IQueryable<TblMeisterschaften> GetMeisterschaften(ApplicationDbContext context) 
        => context.TblMeisterschaftens;
        
    [UsePaging]
    [UseProjection]
    [UseFiltering]
    [UseSorting]
    public IQueryable<TblSpieltag> GetSpieltage(ApplicationDbContext context) 
        => context.TblSpieltags;

    [UsePaging]
    [UseProjection]
    [UseFiltering]
    [UseSorting]
    public IQueryable<TblMeisterschaftstyp> GetMeisterschaftstypen(ApplicationDbContext context)
        => context.TblMeisterschaftstyps;

    [UsePaging]
    [UseProjection]
    [UseFiltering]
    [UseSorting]
    public IQueryable<TblTeilnehmer> GetTeilnehmer(ApplicationDbContext context)
        => context.TblTeilnehmers;

    public async Task<List<Mitgliederliste>> GetAllMitgliederAsync(IMitgliederService service, bool aktiv = true)
        => await service.GetAllMitgliederAsync(aktiv);

    public async Task<Mitgliederliste> GetMitgliedByIDAsync(IMitgliederService service, int id)
        => await service.GetMitgliedByIDAsync(id);

    public async Task<Meisterschaft> GetMeisterschaftByIDAsync(IMeisterschaftService service, int id)
        => await service.GetMeisterschaftByIDAsync(id);

    public async Task<AktuellerSpieltag?> GetSpieltagInBearbeitungAsync(ISpieleingabeService service)
        => await service.GetSpieltagInBearbeitungAsync();
}
