using KEPABackend.DTOs.Get;
using KEPABackend.Modell;

namespace KEPABackend.Interfaces;

public interface IMitgliederDBService
{
    Task<long> CreateMitgliederAsync(TblMitglieder mitglied);
    Task UpdateMitgliederAsync();
    Task<List<Mitgliederliste>> GetAllMitgliederAsync(bool bAktiv = true);
    Task<TblMitglieder?> GetMitgliedByIDAsync(int ID);
}
