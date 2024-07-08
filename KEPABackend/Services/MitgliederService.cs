using AutoMapper;
using FluentValidation;
using KEPABackend.DTOs;
using KEPABackend.Exceptions;
using KEPABackend.Interfaces;
using KEPABackend.Modell;
using KEPABackend.DBServices;
using KEPABackend.Validations;
using Microsoft.EntityFrameworkCore;
using System.Runtime.Serialization;

namespace KEPABackend.Services;

public class MitgliederService
{
    public IMitgliederDBService MitgliederDBService { get; }
    public IMapper Mapper { get; }
    public MitgliederValidator MitgliederValidator { get; }

    public MitgliederService(IMitgliederDBService mitgliederDBService, IMapper mapper, MitgliederValidator mitgliederValidator)
    {
        MitgliederDBService = mitgliederDBService;
        Mapper = mapper;
        MitgliederValidator = mitgliederValidator;
    }

    
    /// <summary>
    /// Service CreateMitgliederAsync
    /// </summary>
    /// <param name="mitgliedCreate"></param>
    /// <returns>ID der neuen Entität</returns>
    public async Task<long> CreateMitgliederAsync(MitgliedCreate mitgliedCreate)
    {
        try
        {
            await MitgliederValidator.ValidateAndThrowAsync(mitgliedCreate);
        }
        catch (ValidationException ex)
        {
            string message = ex.Message;
            throw;
        }

        var mitglied = Mapper.Map<TblMitglieder>(mitgliedCreate);
        long lngID = await MitgliederDBService.CreateMitgliederAsync(mitglied);
        return lngID;
    }

    /// <summary>
    /// Service GetAllMitgliederAsync
    /// </summary>
    /// <param name="bAktiv" true (Default) = nur aktive Mitglieder; false = alle Mitglieder
    /// <returns>Liste aller Mitglieder</returns>
    public async Task<List<GetMitgliederliste>> GetAllMitgliederAsync(bool bAktiv = true)
    {
        return await MitgliederDBService.GetAllMitgliederAsync(bAktiv);
    }

    /// <summary>
    /// Service GetMitgliedByIDAsync
    /// </summary>
    /// <param name="ID"></param>
    /// <returns>Mitglied mit der ID </returns>
    public async Task<GetMitgliederliste> GetMitgliedByIDAsync(int ID)
    {

        GetMitgliederliste? mitglied = await MitgliederDBService.GetMitgliedByIDAsync(ID);

        if (mitglied == null)
        {
            throw new MitgliedNotFoundException();
        }

        return mitglied;
    }    
}
