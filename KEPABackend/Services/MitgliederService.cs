using AutoMapper;
using FluentValidation;
using KEPABackend.DTOs;
using KEPABackend.Exceptions;
using KEPABackend.Interfaces;
using KEPABackend.Modell;
using KEPABackend.Repositorys;
using KEPABackend.Validations;
using Microsoft.EntityFrameworkCore;
using System.Runtime.Serialization;

namespace KEPABackend.Services;

public class MitgliederService
{
    public IMitgliederDBService MitgliederRepository { get; }
    public IMapper Mapper { get; }
    public MitgliederValidator MitgliederValidator { get; }

    public MitgliederService(IMitgliederDBService mitgliederRepository, IMapper mapper, MitgliederValidator mitgliederValidator)
    {
        MitgliederRepository = mitgliederRepository;
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
            throw;
        }

        var mitglied = Mapper.Map<TblMitglieder>(mitgliedCreate);
        long lngID = await MitgliederRepository.CreateMitgliederAsync(mitglied);
        return lngID;
    }

    /// <summary>
    /// Service GetAllMitgliederAsync
    /// </summary>
    /// <returns>Liste aller Mitglieder</returns>
    public async Task<List<GetMitgliederliste>> GetAllMitgliederAsync()
    {
        return await MitgliederRepository.GetAllMitgliederAsync();
    }

    /// <summary>
    /// Service GetMitgliedByIDAsync
    /// </summary>
    /// <param name="ID"></param>
    /// <returns>Mitglied mit der ID </returns>
    public async Task<GetMitgliederliste> GetMitgliedByIDAsync(int ID)
    {

        GetMitgliederliste? mitglied = await MitgliederRepository.GetMitgliedByIDAsync(ID);

        if (mitglied == null)
        {
            throw new MitgliedNotFoundException();
        }

        return mitglied;
    }    
}
