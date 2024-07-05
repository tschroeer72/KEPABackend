using AutoMapper;
using FluentValidation;
using KEPABackend.DTOs;
using KEPABackend.Modell;
using KEPABackend.Validations;

namespace KEPABackend.Services;

public class MitgliederService
{
    public ApplicationDbContext DbContext { get; }
    public MitgliederCreateValidator MitgliederValidator { get; }
    public IMapper Mapper { get; }

    public MitgliederService(ApplicationDbContext dbContext, MitgliederCreateValidator mitgliederCreateValidator, IMapper mapper)
    {
        DbContext = dbContext;
        MitgliederValidator = mitgliederCreateValidator;
        Mapper = mapper;
    }

    public async Task<long> CreateMitgliederAsync(MitgliedCreate mitgliedCreate)
    {
        try
        {
            await MitgliederValidator.ValidateAndThrowAsync(mitgliedCreate);
        }
        catch (ValidationException ex)
        {
            throw;
        }

        //await MitgliederValidator.ValidateAndThrowAsync(mitgliedCreate);

        var mitglied = Mapper.Map<TblMitglieder>(mitgliedCreate);
        await DbContext.TblMitglieders.AddAsync(mitglied);
        await DbContext.SaveChangesAsync();
        long lngID = mitglied.Id;
        return lngID;
    }
}
