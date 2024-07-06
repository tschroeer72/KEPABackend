using KEPABackend.DTOs;
using KEPABackend.Modell;

namespace KEPABackend.Interfaces;

public interface IMitgliederRepository
{
    Task<long> CreateMitgliederAsync(TblMitglieder mitglied);
    Task<List<GetMitgliederliste>> GetAllMitgliederAsync();
    Task<GetMitgliederliste?> GetMitgliedByIDAsync(int ID);
}
