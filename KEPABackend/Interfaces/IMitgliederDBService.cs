using KEPABackend.DTOs;
using KEPABackend.Modell;

namespace KEPABackend.Interfaces;

public interface IMitgliederDBService
{
    Task<long> CreateMitgliederAsync(TblMitglieder mitglied);
    Task<List<GetMitgliederliste>> GetAllMitgliederAsync(bool bAktiv = true);
    Task<GetMitgliederliste?> GetMitgliedByIDAsync(int ID);
}
