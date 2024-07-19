using AutoMapper;
using FluentValidation;
using KEPABackend.DTOs.Output;
using KEPABackend.Interfaces.DBServices;
using KEPABackend.Modell;
using KEPABackend.Validations;
using Microsoft.EntityFrameworkCore;

namespace KEPABackend.DBServices;

/// <summary>
/// DBService für TblMeisterschaftstypen
/// </summary>
public class MeisterschaftstypenDBService : IMeisterschaftstypenDBService
{
    private ApplicationDbContext DbContext { get; }

    /// <summary>
    /// Constuctur
    /// </summary>
    /// <param name="dbContext"></param>
    public MeisterschaftstypenDBService(ApplicationDbContext dbContext)
    {
        DbContext = dbContext;
    }

    /// <summary>
    /// Service GetAllMeisterschaftstypenAsync
    /// </summary>
    /// <returns>Liste aller Meisterschaftstypen</returns>
    public async Task<List<Meisterschaftstypen>> GetAllMeisterschaftstypenAsync()
    {
        var lst = await DbContext.TblMeisterschaftstyps
            .Select(s => new Meisterschaftstypen
            {
                ID = s.Id,
                Meisterschaftstyp = s.Meisterschaftstyp
            }).ToListAsync();

        return lst;
    }

    /// <summary>
    /// Suche Meisterschaftstyp mit der ID
    /// </summary>
    /// <param name="ID"></param>
    /// <returns>Meisterschaftstyp oder null</returns>
    public async Task<Meisterschaftstypen?> GetMeisterschaftstypByIDAsync(int ID)
    {
        var mt = await DbContext.TblMeisterschaftstyps
            .Where(w => w.Id == ID)
            .Select(s => new Meisterschaftstypen
            {
                ID = s.Id,
                Meisterschaftstyp = s.Meisterschaftstyp
            }).SingleOrDefaultAsync();

        return mt;
    }
}

