using KEPABackend.DTOs.Output;
using KEPABackend.Enums;
using KEPABackend.Models;

namespace KEPABackend.Interfaces.DBServices;

/// <summary>
/// Interface für SpieleingabeDBService
/// </summary>
public interface ISpieleingabeDBService
{
    /// <summary>
    /// Erstelle einen Spieltag
    /// </summary>
    /// <param name="spieltag"></param>
    /// <returns>ID des neuen Spieltages</returns>
    Task<int> CreateSpieltagAsync(TblSpieltag spieltag);

    /// <summary>
    /// Überprüfe, ob Spieltag bereits existiert
    /// </summary>
    /// <param name="MeisterschaftsID"></param>
    /// <param name="Spieltag"></param>
    /// <returns>NULL oder ID des Spieltages</returns>
    Task<int?> CheckSpieltagExistingAsync(int MeisterschaftsID, DateTime Spieltag);

    /// <summary>
    /// Hole den Spieltag der ID
    /// </summary>
    /// <param name="SpieltagID"></param>
    /// <returns>NULL oder Spieltag</returns>
    Task<TblSpieltag?> GetSpieltagByIDAsync(int SpieltagID);

    /// <summary>
    /// Spieltag abschließen
    /// (keine weitere Eingabe möglich)
    /// </summary>
    /// <param name="SpieltagID"></param>
    Task CloseSpieltagAsync(int SpieltagID);

    /// <summary>
    /// Spieltag löschen
    /// (keine weitere Eingabe möglich)
    /// </summary>
    /// <param name="SpieltagID"></param>
    Task DeleteSpieltagAsync(int SpieltagID);

    /// <summary>
    /// Hole den Spieltag der in Bearbeitung ist
    /// </summary>
    /// <returns>ID und Datum des Spieltag</returns>
    Task<AktuellerSpieltag?> GetSpieltagInBearbeitungAsync();

    /// <summary>
    /// Erzeuge Tabelleneintrag für 9er und Ratten
    /// </summary>
    /// <param name="neunerRatten"></param>
    /// <returns></returns>
    Task<int> Create9erRattenAsync(Tbl9erRatten neunerRatten);

    /// <summary>
    /// Überprüfe, ob es bereits einen Eintrag für diesen Spieltag für diesen Spieler gibt
    /// </summary>
    /// <param name="SpieltagID"></param>
    /// <param name="SpielerID"></param>
    /// <returns>NULL oder ID der Entität</returns>
    Task<int?> Check9erRattenExistingAsync(int SpieltagID, int SpielerID);

    /// <summary>
    /// Aktualisiere NeunerRatten Entität
    /// </summary>
    /// <returns></returns>
    Task Update9erRattenAsync();

    /// <summary>
    /// Hole die NeunerRatten-Entität
    /// </summary>
    /// <param name="ID"></param>
    /// <returns>NULL oder Neuner/Ratten-Entität</returns>
    Task<Tbl9erRatten?> Get9erRattenByID(int ID);

    /// <summary>
    /// Neuner/Ratten löschen
    /// </summary>
    /// <param name="SpieltagID"></param>
    Task DeleteNeunerRattenAsync(int SpieltagID);

    /// <summary>
    /// Erzeuge Mannschaft für das 6-Tage-Rennen
    /// </summary>
    /// <param name="spiel6TageRennen"></param>
    /// <returns></returns>
    Task<int> CreateSpiel6TageRennenAsync(TblSpiel6TageRennen spiel6TageRennen);

    /// <summary>
    /// Überprüfe, ob es bereits diese Mannschaft für diesen Spieltag gibt
    /// </summary>
    /// <param name="SpieltagID"></param>
    /// <param name="SpielerID1"></param>
    /// <param name="SpielerID2"></param>
    /// <returns>NULL oder ID der Entität</returns>
    Task<int?> CheckSpiel6TageRennenExistingAsync(int SpieltagID, int SpielerID1, int SpielerID2);

    /// <summary>
    /// Aktualisiere Spiel6TagreRennen Entität
    /// </summary>
    /// <returns></returns>
    Task UpdateSpiel6TageRennenAsync();

    /// <summary>
    /// Hole die Spiel6TageRennen-Entität
    /// </summary>
    /// <param name="ID"></param>
    /// <returns>NULL oder Spiel6TageRennen-Entität</returns>
    Task<TblSpiel6TageRennen?> GetSpiel6TageRennenByID(int ID);

    /// <summary>
    /// Mannschaft auf 6-Tage-Rennen löschen
    /// </summary>
    /// <param name="SpieltagID"></param>
    Task DeleteSpiel6TageRennenAsync(int SpieltagID);

    /// <summary>
    /// Erzeuge Eintrag für Blitztunier
    /// </summary>
    /// <param name="spielBlitztunier"></param>
    /// <returns></returns>
    Task<int> CreateSpielBlitztunierAsync(TblSpielBlitztunier spielBlitztunier);

    /// <summary>
    /// Überprüfe, ob es bereits einen Eintrag für diese Partie an diesem Spieltag gibt
    /// </summary>
    /// <param name="SpieltagID"></param>
    /// <param name="SpielerID1"></param>
    /// <param name="SpielerID2"></param>
    /// <returns>NULL oder ID der Entität</returns>
    Task<int?> CheckSpielBlitztunierExistingAsync(int SpieltagID, int SpielerID1, int SpielerID2);

    /// <summary>
    /// Aktualisiere SpielBlitztunier Entität
    /// </summary>
    /// <returns></returns>
    Task UpdateSpielBlitztunierAsync();

    /// <summary>
    /// Hole die SpielBlitztunier-Entität
    /// </summary>
    /// <param name="ID"></param>
    /// <returns>NULL oder SpielBlitztunier-Entität</returns>
    Task<TblSpielBlitztunier?> GetSpielBlitztunierByID(int ID);

    /// <summary>
    /// Paarung aus Blitztunier löschen
    /// </summary>
    /// <param name="SpieltagID"></param>
    Task DeleteSpielBlitztunierAsync(int SpieltagID);

    /// <summary>
    /// Erzeuge Eintrag für Meisterschaft
    /// </summary>
    /// <param name="spielMeisterschaft"></param>
    /// <returns></returns>
    Task<int> CreateSpielMeisterschaftAsync(TblSpielMeisterschaft spielMeisterschaft);

    /// <summary>
    /// Überprüfe, ob es bereits einen Eintrag für diese Partie an diesem Spieltag gibt
    /// </summary>
    /// <param name="SpieltagID"></param>
    /// <param name="SpielerID1"></param>
    /// <param name="SpielerID2"></param>
    /// <returns>NULL oder ID der Entität</returns>
    Task<int?> CheckSpielMeisterschaftExistingAsync(int SpieltagID, int SpielerID1, int SpielerID2);

    /// <summary>
    /// Aktualisiere SpielMeisterschaft Entität
    /// </summary>
    /// <returns></returns>
    Task UpdateSpielMeisterschaftAsync();

    /// <summary>
    /// Hole die SpielMeisterschaft-Entität
    /// </summary>
    /// <param name="ID"></param>
    /// <returns>NULL oder GetSpielMeisterschaftByID-Entität</returns>
    Task<TblSpielMeisterschaft?> GetSpielMeisterschaftByID(int ID);

    /// <summary>
    /// Paarung aus Meisterschaft löschen
    /// </summary>
    /// <param name="SpieltagID"></param>
    Task DeleteSpielMeisterschaftAsync(int SpieltagID);

    /// <summary>
    /// Erzeuge Eintrag für Kombimeisterschaft
    /// </summary>
    /// <param name="spielKombimeisterschaft"></param>
    /// <returns></returns>
    Task<int> CreateSpielKombimeisterschaftAsync(TblSpielKombimeisterschaft spielKombimeisterschaft);

    /// <summary>
    /// Überprüfe, ob es bereits einen Eintrag für diese Partie an diesem Spieltag gibt
    /// </summary>
    /// <param name="SpieltagID"></param>
    /// <param name="SpielerID1"></param>
    /// <param name="SpielerID2"></param>
    /// <param name="HinRückrunde"></param>
    /// <returns>NULL oder ID der Entität</returns>
    Task<int?> CheckSpielKombimeisterschaftExistingAsync(int SpieltagID, int SpielerID1, int SpielerID2, HinRückrunde HinRückrunde);

    /// <summary>
    /// Aktualisiere SpielKombimeisterschaft Entität
    /// </summary>
    /// <returns></returns>
    Task UpdateSpielKombimeisterschaftAsync();

    /// <summary>
    /// Hole die GetSpielKombimeisterschaftByID-Entität
    /// </summary>
    /// <param name="ID"></param>
    /// <returns>NULL oder GetSpielKombimeisterschaftByID-Entität</returns>
    Task<TblSpielKombimeisterschaft?> GetSpielKombimeisterschaftByID(int ID);

    /// <summary>
    /// Paarung aus Kombimeisterschaft löschen
    /// </summary>
    /// <param name="SpieltagID"></param>
    Task DeleteSpielKombimeisterschaftAsync(int SpieltagID);

    /// <summary>
    /// Erzeuge Tabelleneintrag für Pokalspiel
    /// </summary>
    /// <param name="spielPokal"></param>
    /// <returns></returns>
    Task<int> CreateSpielPokalAsync(TblSpielPokal spielPokal);

    /// <summary>
    /// Überprüfe, ob es bereits einen Eintrag für diese Entity gibt
    /// </summary>
    /// <param name="SpieltagID"></param>
    /// <param name="SpielerID"></param>
    /// <returns>NULL oder ID der Entität</returns>
    Task<int?> CheckSpielPokalExistingAsync(int SpieltagID, int SpielerID);

    /// <summary>
    /// Aktualisiere SpielPokal Entität
    /// </summary>
    /// <returns></returns>
    Task UpdateSpielPokalAsync();

    /// <summary>
    /// Hole die GetSpielPokalByID-Entität
    /// </summary>
    /// <param name="ID"></param>
    /// <returns>NULL oder }-Entität</returns>
    Task<TblSpielPokal?> GetSpielPokalByID(int ID);

    /// <summary>
    /// Pokal löschen
    /// </summary>
    /// <param name="SpieltagID"></param>
    Task DeleteSpielPokalAsync(int SpieltagID);

    /// <summary>
    /// Erzeuge Tabelleneintrag für Sargkegeln
    /// </summary>
    /// <param name="spielSargkegeln"></param>
    /// <returns></returns>
    Task<int> CreateSpielSargkegelnAsync(TblSpielSargKegeln spielSargkegeln);

    /// <summary>
    /// Überprüfe, ob es bereits einen Eintrag für diese Entity gibt
    /// </summary>
    /// <param name="SpieltagID"></param>
    /// <param name="SpielerID"></param>
    /// <returns>NULL oder ID der Entität</returns>
    Task<int?> CheckSpielSargkegelnExistingAsync(int SpieltagID, int SpielerID);

    /// <summary>
    /// Aktualisiere SpielSargkegeln Entität
    /// </summary>
    /// <returns></returns>
    Task UpdateSpielSargkegelnAsync();

    /// <summary>
    /// Hole die GetSpielSargkegelnByID-Entität
    /// </summary>
    /// <param name="ID"></param>
    /// <returns>NULL oder }-Entität</returns>
    Task<TblSpielSargKegeln?> GetSpielSargkegelnByID(int ID);

    /// <summary>
    /// Sargkegeln löschen
    /// </summary>
    /// <param name="SpieltagID"></param>
    Task DeleteSpielSargkegelnAsync(int SpieltagID);
}
