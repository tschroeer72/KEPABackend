using KEPABackend.DTOs.Input;
using KEPABackend.DTOs.Output;
using KEPABackend.Interfaces.ControllerServices;

namespace KEPABackend.GraphQL;

public class Mutation
{
    // Mitglieder
    public async Task<EntityID> CreateMitgliederAsync(IMitgliederService service, MitgliedCreate mitgliedCreate)
        => await service.CreateMitgliederAsync(mitgliedCreate);

    public async Task<Mitgliederliste> UpdateMitgliederAsync(IMitgliederService service, MitgliedUpdate mitgliedUpdate)
        => await service.UpdateMitgliederAsync(mitgliedUpdate);

    // Meisterschaften
    public async Task<EntityID> CreateMeisterschaftAsync(IMeisterschaftService service, MeisterschaftCreate meisterschaftCreate)
        => await service.CreateMeisterschaftAsync(meisterschaftCreate);

    public async Task<Meisterschaft> UpdateMeisterschaftAsync(IMeisterschaftService service, MeisterschaftUpdate meisterschaftUpdate)
        => await service.UpdateMeisterschaftAsync(meisterschaftUpdate);

    public async Task<bool> AddTeilnehmerAsync(IMeisterschaftService service, int meisterschaftsID, int teilnehmerID)
    {
        await service.AddTeilnehmerAsync(meisterschaftsID, teilnehmerID);
        return true;
    }

    public async Task<bool> DeleteTeilnehmerAsync(IMeisterschaftService service, int meisterschaftsID, int teilnehmerID)
    {
        await service.DeleteTeilnehmerAsync(meisterschaftsID, teilnehmerID);
        return true;
    }

    // Spieleingabe - Spieltag
    public async Task<EntityID> CreateSpieltagAsync(ISpieleingabeService service, SpieltagCreate spieltagCreate)
        => await service.CreateSpieltagAsync(spieltagCreate);

    public async Task<bool> CloseSpieltagAsync(ISpieleingabeService service, int spieltagID)
    {
        await service.CloseSpieltagAsync(spieltagID);
        return true;
    }

    public async Task<bool> DeleteSpieltagAsync(ISpieleingabeService service, int spieltagID)
    {
        await service.DeleteSpieltagAsync(spieltagID);
        return true;
    }

    // Spieleingabe - 9erRatten
    public async Task<EntityID> Create9erRattenAsync(ISpieleingabeService service, NeunerRattenCreate neunerRattenCreate)
        => await service.Create9erRattenAsync(neunerRattenCreate);

    public async Task<NeunerRatten> Update9erRattenAsync(ISpieleingabeService service, NeunerRattenUpdate neunerRattenUpdate)
        => await service.Update9erRattenAsync(neunerRattenUpdate);

    public async Task<bool> Delete9erRattenAsync(ISpieleingabeService service, int spieltagID)
    {
        await service.DeleteNeunerRattenAsync(spieltagID);
        return true;
    }

    // Spieleingabe - 6-Tage-Rennen
    public async Task<EntityID> Create6TageRennenAsync(ISpieleingabeService service, Spiel6TageRennenCreate spiel6TageRennenCreate)
        => await service.CreateSpiel6TageRennenAsync(spiel6TageRennenCreate);

    public async Task<Spiel6TageRennen> Update6TageRennenAsync(ISpieleingabeService service, Spiel6TageRennenUpdate spiel6TageRennenUpdate)
        => await service.UpdateSpiel6TageRennenAsync(spiel6TageRennenUpdate);

    public async Task<bool> Delete6TageRennenAsync(ISpieleingabeService service, int spieltagID)
    {
        await service.DeleteSpiel6TageRennenAsync(spieltagID);
        return true;
    }

    // Spieleingabe - Blitztunier
    public async Task<EntityID> CreateBlitztunierAsync(ISpieleingabeService service, SpielBlitztunierCreate spielBlitztunierCreate)
        => await service.CreateSpielBlitztunierAsync(spielBlitztunierCreate);

    public async Task<SpielBlitztunier> UpdateBlitztunierAsync(ISpieleingabeService service, SpielBlitztunierUpdate spielBlitztunierUpdate)
        => await service.UpdateSpielBlitztunierAsync(spielBlitztunierUpdate);

    public async Task<bool> DeleteBlitztunierAsync(ISpieleingabeService service, int spieltagID)
    {
        await service.DeleteSpielBlitztunierAsync(spieltagID);
        return true;
    }

    // Spieleingabe - Meisterschaft (Spiel)
    public async Task<EntityID> CreateSpielMeisterschaftAsync(ISpieleingabeService service, SpielMeisterschaftCreate spielMeisterschaftCreate)
        => await service.CreateSpielMeisterschaftAsync(spielMeisterschaftCreate);

    public async Task<SpielMeisterschaft> UpdateSpielMeisterschaftAsync(ISpieleingabeService service, SpielMeisterschaftUpdate spielMeisterschaftUpdate)
        => await service.UpdateSpielMeisterschaftAsync(spielMeisterschaftUpdate);

    public async Task<bool> DeleteSpielMeisterschaftAsync(ISpieleingabeService service, int spieltagID)
    {
        await service.DeleteSpielMeisterschaftAsync(spieltagID);
        return true;
    }

    // Spieleingabe - Kombimeisterschaft
    public async Task<EntityID> CreateKombimeisterschaftAsync(ISpieleingabeService service, SpielKombimeisterschaftCreate spielKombimeisterschaftCreate)
        => await service.CreateSpielKombimeisterschaftAsync(spielKombimeisterschaftCreate);

    public async Task<SpielKombimeisterschaft> UpdateKombimeisterschaftAsync(ISpieleingabeService service, SpielKombimeisterschaftUpdate spielKombimeisterschaftUpdate)
        => await service.UpdateSpielKombimeisterschaftAsync(spielKombimeisterschaftUpdate);

    public async Task<bool> DeleteKombimeisterschaftAsync(ISpieleingabeService service, int spieltagID)
    {
        await service.DeleteSpielKombimeisterschaftAsync(spieltagID);
        return true;
    }

    // Spieleingabe - Pokal
    public async Task<EntityID> CreatePokalAsync(ISpieleingabeService service, SpielPokalCreate spielPokalCreate)
        => await service.CreateSpielPokalAsync(spielPokalCreate);

    public async Task<SpielPokal> UpdatePokalAsync(ISpieleingabeService service, SpielPokalUpdate spielPokalUpdate)
        => await service.UpdateSpielPokalAsync(spielPokalUpdate);

    public async Task<bool> DeletePokalAsync(ISpieleingabeService service, int spieltagID)
    {
        await service.DeleteSpielPokalAsync(spieltagID);
        return true;
    }

    // Spieleingabe - Sargkegeln
    public async Task<EntityID> CreateSargkegelnAsync(ISpieleingabeService service, SpielSargkegelnCreate spielSargkegelnCreate)
        => await service.CreateSpielSargkegelnAsync(spielSargkegelnCreate);

    public async Task<SpielSargkegeln> UpdateSargkegelnAsync(ISpieleingabeService service, SpielSargkegelnUpdate spielSargkegelnUpdate)
        => await service.UpdateSpielSargkegelnAsync(spielSargkegelnUpdate);

    public async Task<bool> DeleteSargkegelnAsync(ISpieleingabeService service, int spieltagID)
    {
        await service.DeleteSpielSargkegelnAsync(spieltagID);
        return true;
    }
}
