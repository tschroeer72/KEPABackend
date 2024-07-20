using KEPABackend.DTOs.Output;
using KEPABackend.Enums;
using KEPABackend.Interfaces.DBServices;
using KEPABackend.Modell;
using Microsoft.EntityFrameworkCore;

namespace KEPABackend.DBServices;

/// <summary>
/// DBService für fie Spielergebnisse
/// </summary>
public class SpielergebnisseDBService : ISpielergebnisseDBService
{
    private readonly ApplicationDbContext DbContext;

    /// <summary>
    /// Constructor
    /// </summary>
    public SpielergebnisseDBService(ApplicationDbContext DbContext)
    {
        this.DbContext = DbContext;
    }

    /// <summary>
    /// Liefere alle Ergebnisse zu 6-Tage-Rennen
    /// </summary>
    /// <returns>Liste aller 6-Tage-Rennen</returns>
    public async Task<List<vwSpiel6TageRennen>> GetErgebnisse6TageRennenAsync(int SpieltagID = -1)
    {
        if (SpieltagID == -1)
        {
            var lst6TR = await DbContext.TblSpiel6TageRennens
                .Join(DbContext.TblMitglieders,
                        str => str.SpielerId1,
                        mgl1 => mgl1.Id,
                        (str, mgl1) => new { str, mgl1 })
                .Join(DbContext.TblMitglieders,
                        str => str.str.SpielerId2,
                        mgl2 => mgl2.Id,
                        (str, mgl2) => new { str, mgl2 })
                .Join(DbContext.TblSpieltags,
                        nrst => nrst.str.str.SpieltagId,
                        st => st.Id,
                        (nrst, st) => new vwSpiel6TageRennen
                        {
                            Spiel6TageRennenID = nrst.str.str.Id,
                            MeisterschaftsID = st.MeisterschaftsId,
                            Spieler1ID = nrst.str.str.SpielerId1,
                            SpieltagID = nrst.str.str.SpieltagId,
                            Spieltag = st.Spieltag,
                            Spieler1Vorname = nrst.str.mgl1.Vorname,
                            Spieler1Nachname = nrst.str.mgl1.Nachname,
                            Spieler1Spitzname = nrst.str.mgl1.Spitzname == null ? "" : nrst.str.mgl1.Spitzname,
                            Spieler2ID = nrst.mgl2.Id,
                            Spieler2Vorname = nrst.mgl2.Vorname,
                            Spieler2Nachname = nrst.mgl2.Nachname,
                            Spieler2Spitzname = nrst.mgl2.Spitzname == null ? "" : nrst.mgl2.Spitzname,
                            Runden = nrst.str.str.Runden,
                            Punkte = nrst.str.str.Punkte
                        })
                .OrderByDescending(o => o.Spieltag)
               .ToListAsync<vwSpiel6TageRennen>();

            return lst6TR;
        }
        else
        {
            var lst6TR = await DbContext.TblSpiel6TageRennens
                .Join(DbContext.TblMitglieders,
                        str => str.SpielerId1,
                        mgl1 => mgl1.Id,
                        (str, mgl1) => new { str, mgl1 })
                .Join(DbContext.TblMitglieders,
                        str => str.str.SpielerId2,
                        mgl2 => mgl2.Id,
                        (str, mgl2) => new { str, mgl2 })
                .Join(DbContext.TblSpieltags,
                        nrst => nrst.str.str.SpieltagId,
                        st => st.Id,
                        (nrst, st) => new vwSpiel6TageRennen
                        {
                            Spiel6TageRennenID = nrst.str.str.Id,
                            MeisterschaftsID = st.MeisterschaftsId,
                            Spieler1ID = nrst.str.str.SpielerId1,
                            SpieltagID = nrst.str.str.SpieltagId,
                            Spieltag = st.Spieltag,
                            Spieler1Vorname = nrst.str.mgl1.Vorname,
                            Spieler1Nachname = nrst.str.mgl1.Nachname,
                            Spieler1Spitzname = nrst.str.mgl1.Spitzname == null ? "" : nrst.str.mgl1.Spitzname,
                            Spieler2ID = nrst.mgl2.Id,
                            Spieler2Vorname = nrst.mgl2.Vorname,
                            Spieler2Nachname = nrst.mgl2.Nachname,
                            Spieler2Spitzname = nrst.mgl2.Spitzname == null ? "" : nrst.mgl2.Spitzname,
                            Runden = nrst.str.str.Runden,
                            Punkte = nrst.str.str.Punkte
                        })
                .OrderByDescending(o => o.Spieltag)
                .Where(w => w.SpieltagID == SpieltagID)
                .OrderByDescending(o => o.Spieltag)
               .ToListAsync<vwSpiel6TageRennen>();

            return lst6TR;
        }
    }

    /// <summary>
    /// Liefere alle Ergebnisse zu Blitztunier
    /// </summary>
    /// <returns>Liste aller Blitztunier</returns>
    public async Task<List<vwSpielBlitztunier>> GetErgebnisseBlitztunierAsync(int SpieltagID = -1)
    {
        if (SpieltagID == -1)
        {
            var lstBlitz = await DbContext.TblSpielBlitztuniers
                .Join(DbContext.TblMitglieders,
                        str => str.SpielerId1,
                        mgl1 => mgl1.Id,
                        (str, mgl1) => new { str, mgl1 })
                .Join(DbContext.TblMitglieders,
                        str => str.str.SpielerId2,
                        mgl2 => mgl2.Id,
                        (str, mgl2) => new { str, mgl2 })
                .Join(DbContext.TblSpieltags,
                        nrst => nrst.str.str.SpieltagId,
                        st => st.Id,
                        (nrst, st) => new vwSpielBlitztunier
                        {
                            SpielBlitztunierID = nrst.str.str.Id,
                            MeisterschaftsID = st.MeisterschaftsId,
                            Spieler1ID = nrst.str.str.SpielerId1,
                            SpieltagID = nrst.str.str.SpieltagId,
                            Spieltag = st.Spieltag,
                            Spieler1Vorname = nrst.str.mgl1.Vorname,
                            Spieler1Nachname = nrst.str.mgl1.Nachname,
                            Spieler1Spitzname = nrst.str.mgl1.Spitzname == null ? "" : nrst.str.mgl1.Spitzname,
                            Spieler2ID = nrst.mgl2.Id,
                            Spieler2Vorname = nrst.mgl2.Vorname,
                            Spieler2Nachname = nrst.mgl2.Nachname,
                            Spieler2Spitzname = nrst.mgl2.Spitzname == null ? "" : nrst.mgl2.Spitzname,
                            PunkteSpieler1 = nrst.str.str.PunkteSpieler1,
                            PunkteSpieler2 = nrst.str.str.PunkteSpieler2,
                            HinRückrunde = (HinRückrunde)nrst.str.str.HinRückrunde
                        })
                .OrderByDescending(o => o.Spieltag)
               .ToListAsync<vwSpielBlitztunier>();

            return lstBlitz;
        }
        else
        {
            var lstBlitz = await DbContext.TblSpielBlitztuniers
                .Join(DbContext.TblMitglieders,
                        str => str.SpielerId1,
                        mgl1 => mgl1.Id,
                        (str, mgl1) => new { str, mgl1 })
                .Join(DbContext.TblMitglieders,
                        str => str.str.SpielerId2,
                        mgl2 => mgl2.Id,
                        (str, mgl2) => new { str, mgl2 })
                .Join(DbContext.TblSpieltags,
                        nrst => nrst.str.str.SpieltagId,
                        st => st.Id,
                        (nrst, st) => new vwSpielBlitztunier
                        {
                            SpielBlitztunierID = nrst.str.str.Id,
                            MeisterschaftsID = st.MeisterschaftsId,
                            Spieler1ID = nrst.str.str.SpielerId1,
                            SpieltagID = nrst.str.str.SpieltagId,
                            Spieltag = st.Spieltag,
                            Spieler1Vorname = nrst.str.mgl1.Vorname,
                            Spieler1Nachname = nrst.str.mgl1.Nachname,
                            Spieler1Spitzname = nrst.str.mgl1.Spitzname == null ? "" : nrst.str.mgl1.Spitzname,
                            Spieler2ID = nrst.mgl2.Id,
                            Spieler2Vorname = nrst.mgl2.Vorname,
                            Spieler2Nachname = nrst.mgl2.Nachname,
                            Spieler2Spitzname = nrst.mgl2.Spitzname == null ? "" : nrst.mgl2.Spitzname,
                            PunkteSpieler1 = nrst.str.str.PunkteSpieler1,
                            PunkteSpieler2 = nrst.str.str.PunkteSpieler2,
                            HinRückrunde = (HinRückrunde)nrst.str.str.HinRückrunde
                        })
                .OrderByDescending(o => o.Spieltag)
                .Where(w => w.SpieltagID == SpieltagID)
                .OrderByDescending(o => o.Spieltag)
               .ToListAsync<vwSpielBlitztunier>();

            return lstBlitz;
        }
    }

    /// <summary>
    /// Liefere alle Ergebnisse zu Kombimeisterschaft
    /// </summary>
    /// <returns>Liste aller Kombimeisterschaft</returns>
    public async Task<List<vwSpielKombimeisterschaft>> GetErgebnisseKombimeisterschaftAsync(int SpieltagID = -1)
    {
        if (SpieltagID == -1)
        {
            var lstKombi = await DbContext.TblSpielKombimeisterschafts
                .Join(DbContext.TblMitglieders,
                        str => str.SpielerId1,
                        mgl1 => mgl1.Id,
                        (str, mgl1) => new { str, mgl1 })
                .Join(DbContext.TblMitglieders,
                        str => str.str.SpielerId2,
                        mgl2 => mgl2.Id,
                        (str, mgl2) => new { str, mgl2 })
                .Join(DbContext.TblSpieltags,
                        nrst => nrst.str.str.SpieltagId,
                        st => st.Id,
                        (nrst, st) => new vwSpielKombimeisterschaft
                        {
                            SpielKombimeisterschaftID = nrst.str.str.Id,
                            MeisterschaftsID = st.MeisterschaftsId,
                            Spieler1ID = nrst.str.str.SpielerId1,
                            SpieltagID = nrst.str.str.SpieltagId,
                            Spieltag = st.Spieltag,
                            Spieler1Vorname = nrst.str.mgl1.Vorname,
                            Spieler1Nachname = nrst.str.mgl1.Nachname,
                            Spieler1Spitzname = nrst.str.mgl1.Spitzname == null ? "" : nrst.str.mgl1.Spitzname,
                            Spieler2ID = nrst.mgl2.Id,
                            Spieler2Vorname = nrst.mgl2.Vorname,
                            Spieler2Nachname = nrst.mgl2.Nachname,
                            Spieler2Spitzname = nrst.mgl2.Spitzname == null ? "" : nrst.mgl2.Spitzname,
                            Spieler1Punkte3bis8 = nrst.str.str.Spieler1Punkte3bis8,
                            Spieler1Punkte5Kugeln = nrst.str.str.Spieler1Punkte5Kugeln,
                            Spieler2Punkte3bis8 = nrst.str.str.Spieler2Punkte3bis8,
                            Spieler2Punkte5Kugeln = nrst.str.str.Spieler2Punkte5Kugeln,
                            HinRückrunde = (HinRückrunde)nrst.str.str.HinRückrunde
                        })
                .OrderByDescending(o => o.Spieltag)
               .ToListAsync<vwSpielKombimeisterschaft>();

            return lstKombi;
        }
        else
        {
            var lstKombi = await DbContext.TblSpielKombimeisterschafts
                .Join(DbContext.TblMitglieders,
                        str => str.SpielerId1,
                        mgl1 => mgl1.Id,
                        (str, mgl1) => new { str, mgl1 })
                .Join(DbContext.TblMitglieders,
                        str => str.str.SpielerId2,
                        mgl2 => mgl2.Id,
                        (str, mgl2) => new { str, mgl2 })
                .Join(DbContext.TblSpieltags,
                        nrst => nrst.str.str.SpieltagId,
                        st => st.Id,
                        (nrst, st) => new vwSpielKombimeisterschaft
                        {
                            SpielKombimeisterschaftID = nrst.str.str.Id,
                            MeisterschaftsID = st.MeisterschaftsId,
                            Spieler1ID = nrst.str.str.SpielerId1,
                            SpieltagID = nrst.str.str.SpieltagId,
                            Spieltag = st.Spieltag,
                            Spieler1Vorname = nrst.str.mgl1.Vorname,
                            Spieler1Nachname = nrst.str.mgl1.Nachname,
                            Spieler1Spitzname = nrst.str.mgl1.Spitzname == null ? "" : nrst.str.mgl1.Spitzname,
                            Spieler2ID = nrst.mgl2.Id,
                            Spieler2Vorname = nrst.mgl2.Vorname,
                            Spieler2Nachname = nrst.mgl2.Nachname,
                            Spieler2Spitzname = nrst.mgl2.Spitzname == null ? "" : nrst.mgl2.Spitzname,
                            Spieler1Punkte3bis8 = nrst.str.str.Spieler1Punkte3bis8,
                            Spieler1Punkte5Kugeln = nrst.str.str.Spieler1Punkte5Kugeln,
                            Spieler2Punkte3bis8 = nrst.str.str.Spieler2Punkte3bis8,
                            Spieler2Punkte5Kugeln = nrst.str.str.Spieler2Punkte5Kugeln,
                            HinRückrunde = (HinRückrunde)nrst.str.str.HinRückrunde
                        })
                .OrderByDescending(o => o.Spieltag)
                .Where(w => w.SpieltagID == SpieltagID)
                .OrderByDescending(o => o.Spieltag)
               .ToListAsync<vwSpielKombimeisterschaft>();

            return lstKombi;
        }
    }

    /// <summary>
    /// Liefere alle Ergebnisse zu Meisterschaft
    /// </summary>
    /// <returns>Liste aller Meisterschaft</returns>
    public async Task<List<vwSpielMeisterschaft>> GetErgebnisseMeisterschaftAsync(int SpieltagID = -1)
    {
        if (SpieltagID == -1)
        {
            var lstMeister = await DbContext.TblSpielMeisterschafts
                .Join(DbContext.TblMitglieders,
                        str => str.SpielerId1,
                        mgl1 => mgl1.Id,
                        (str, mgl1) => new { str, mgl1 })
                .Join(DbContext.TblMitglieders,
                        str => str.str.SpielerId2,
                        mgl2 => mgl2.Id,
                        (str, mgl2) => new { str, mgl2 })
                .Join(DbContext.TblSpieltags,
                        nrst => nrst.str.str.SpieltagId,
                        st => st.Id,
                        (nrst, st) => new vwSpielMeisterschaft
                        {
                            SpielMeisterschaftID = nrst.str.str.Id,
                            MeisterschaftsID = st.MeisterschaftsId,
                            Spieler1ID = nrst.str.str.SpielerId1,
                            SpieltagID = nrst.str.str.SpieltagId,
                            Spieltag = st.Spieltag,
                            Spieler1Vorname = nrst.str.mgl1.Vorname,
                            Spieler1Nachname = nrst.str.mgl1.Nachname,
                            Spieler1Spitzname = nrst.str.mgl1.Spitzname == null ? "" : nrst.str.mgl1.Spitzname,
                            Spieler2ID = nrst.mgl2.Id,
                            Spieler2Vorname = nrst.mgl2.Vorname,
                            Spieler2Nachname = nrst.mgl2.Nachname,
                            Spieler2Spitzname = nrst.mgl2.Spitzname == null ? "" : nrst.mgl2.Spitzname,
                            HolzSpieler1 = nrst.str.str.HolzSpieler1,
                            HolzSpieler2 = nrst.str.str.HolzSpieler2,
                            HinRückrunde = (HinRückrunde)nrst.str.str.HinRückrunde
                        })
                .OrderByDescending(o => o.Spieltag)
               .ToListAsync<vwSpielMeisterschaft>();

            return lstMeister;
        }
        else
        {
            var lstMeister = await DbContext.TblSpielMeisterschafts
                .Join(DbContext.TblMitglieders,
                        str => str.SpielerId1,
                        mgl1 => mgl1.Id,
                        (str, mgl1) => new { str, mgl1 })
                .Join(DbContext.TblMitglieders,
                        str => str.str.SpielerId2,
                        mgl2 => mgl2.Id,
                        (str, mgl2) => new { str, mgl2 })
                .Join(DbContext.TblSpieltags,
                        nrst => nrst.str.str.SpieltagId,
                        st => st.Id,
                        (nrst, st) => new vwSpielMeisterschaft
                        {
                            SpielMeisterschaftID = nrst.str.str.Id,
                            MeisterschaftsID = st.MeisterschaftsId,
                            Spieler1ID = nrst.str.str.SpielerId1,
                            SpieltagID = nrst.str.str.SpieltagId,
                            Spieltag = st.Spieltag,
                            Spieler1Vorname = nrst.str.mgl1.Vorname,
                            Spieler1Nachname = nrst.str.mgl1.Nachname,
                            Spieler1Spitzname = nrst.str.mgl1.Spitzname == null ? "" : nrst.str.mgl1.Spitzname,
                            Spieler2ID = nrst.mgl2.Id,
                            Spieler2Vorname = nrst.mgl2.Vorname,
                            Spieler2Nachname = nrst.mgl2.Nachname,
                            Spieler2Spitzname = nrst.mgl2.Spitzname == null ? "" : nrst.mgl2.Spitzname,
                            HolzSpieler1 = nrst.str.str.HolzSpieler1,
                            HolzSpieler2 = nrst.str.str.HolzSpieler2,
                            HinRückrunde = (HinRückrunde)nrst.str.str.HinRückrunde
                        })
                .OrderByDescending(o => o.Spieltag)
                .Where(w => w.SpieltagID == SpieltagID)
                .OrderByDescending(o => o.Spieltag)
               .ToListAsync<vwSpielMeisterschaft>();

            return lstMeister;
        }
    }

    /// <summary>
    /// Liefere alle Ergebnisse zu Neuner/Ratten
    /// </summary>
    /// <returns>Liste aller Neuner/Ratten</returns>
    public async Task<List<vwNeunerRatten>> GetErgebnisseNeunerRattenAsync(int SpieltagID = -1)
    {
        if (SpieltagID == -1)
        {
            var lstNR = await DbContext.Tbl9erRattens
                .Join(DbContext.TblMitglieders,
                        nr => nr.SpielerId,
                        mgl => mgl.Id,
                        (nr, mgl) => new { nr, mgl })
                .Join(DbContext.TblSpieltags,
                        nrst => nrst.nr.SpieltagId,
                        st => st.Id,
                        (nrst, st) => new vwNeunerRatten
                        {
                            NeunerRattenID = nrst.nr.Id,
                            MeisterschaftsID = st.MeisterschaftsId,
                            SpielerID = nrst.nr.SpielerId,
                            SpieltagID = nrst.nr.SpieltagId,
                            Spieltag = st.Spieltag,
                            Vorname = nrst.mgl.Vorname,
                            Nachname = nrst.mgl.Nachname,
                            Spitzname = nrst.mgl.Spitzname == null ? "" : nrst.mgl.Spitzname,
                            Neuner = nrst.nr.Neuner,
                            Ratten = nrst.nr.Ratten
                        })
                .OrderByDescending(o => o.Spieltag)
               .ToListAsync<vwNeunerRatten>();

            return lstNR;
        }
        else
        {
            var lstNR = await DbContext.Tbl9erRattens
                .Join(DbContext.TblMitglieders,
                        nr => nr.SpielerId,
                        mgl => mgl.Id,
                        (nr, mgl) => new { nr, mgl })
                .Join(DbContext.TblSpieltags,
                        nrst => nrst.nr.SpieltagId,
                        st => st.Id,
                        (nrst, st) => new vwNeunerRatten
                        {
                            NeunerRattenID = nrst.nr.Id,
                            MeisterschaftsID = st.MeisterschaftsId,
                            SpielerID = nrst.nr.SpielerId,
                            SpieltagID = nrst.nr.SpieltagId,
                            Spieltag = st.Spieltag,
                            Vorname = nrst.mgl.Vorname,
                            Nachname = nrst.mgl.Nachname,
                            Spitzname = nrst.mgl.Spitzname == null ? "" : nrst.mgl.Spitzname,
                            Neuner = nrst.nr.Neuner,
                            Ratten = nrst.nr.Ratten
                        })
                .Where(w => w.SpieltagID == SpieltagID)
                .OrderByDescending(o => o.Spieltag)
               .ToListAsync<vwNeunerRatten>();

            return lstNR;
        }
    }

    /// <summary>
    /// Liefere alle Ergebnisse zu Pokalspielen
    /// </summary>
    /// <returns>Liste aller Pokalspiele</returns>
    public async Task<List<vwSpielPokal>> GetErgebnissePokalAsync(int SpieltagID = -1)
    {
        if (SpieltagID == -1)
        {
            var lstPokal = await DbContext.TblSpielPokals
                .Join(DbContext.TblMitglieders,
                        p => p.SpielerId,
                        mgl => mgl.Id,
                        (p, mgl) => new { p, mgl })
                .Join(DbContext.TblSpieltags,
                        nrst => nrst.p.SpieltagId,
                        st => st.Id,
                        (nrst, st) => new vwSpielPokal
                        {
                            SpielPokalID = nrst.p.Id,
                            MeisterschaftsID = st.MeisterschaftsId,
                            SpielerID = nrst.p.SpielerId,
                            SpieltagID = nrst.p.SpieltagId,
                            Spieltag = st.Spieltag,
                            Vorname = nrst.mgl.Vorname,
                            Nachname = nrst.mgl.Nachname,
                            Spitzname = nrst.mgl.Spitzname == null ? "" : nrst.mgl.Spitzname,
                            Platzierung = nrst.p.Platzierung
                        })
                .OrderByDescending(o => o.Spieltag)
               .ToListAsync<vwSpielPokal>();

            return lstPokal;
        }
        else
        {
            var lstPokal = await DbContext.TblSpielPokals
                .Join(DbContext.TblMitglieders,
                        p => p.SpielerId,
                        mgl => mgl.Id,
                        (p, mgl) => new { p, mgl })
                .Join(DbContext.TblSpieltags,
                        nrst => nrst.p.SpieltagId,
                        st => st.Id,
                        (nrst, st) => new vwSpielPokal
                        {
                            SpielPokalID = nrst.p.Id,
                            MeisterschaftsID = st.MeisterschaftsId,
                            SpielerID = nrst.p.SpielerId,
                            SpieltagID = nrst.p.SpieltagId,
                            Spieltag = st.Spieltag,
                            Vorname = nrst.mgl.Vorname,
                            Nachname = nrst.mgl.Nachname,
                            Spitzname = nrst.mgl.Spitzname == null ? "" : nrst.mgl.Spitzname,
                            Platzierung = nrst.p.Platzierung
                        })
                .Where(w => w.SpieltagID == SpieltagID)
                .OrderByDescending(o => o.Spieltag)
               .ToListAsync<vwSpielPokal>();

            return lstPokal;
        }
    }

    /// <summary>
    /// Liefere alle Ergebnisse zu Sargkegeln
    /// </summary>
    /// <returns>Liste aller Sargkegeln</returns>
    public async Task<List<vwSpielSargkegeln>> GetErgebnisseSargkegelnAsync(int SpieltagID = -1)
    {
        if (SpieltagID == -1)
        {
            var lstSarg = await DbContext.TblSpielSargKegelns
                .Join(DbContext.TblMitglieders,
                        s => s.SpielerId,
                        mgl => mgl.Id,
                        (s, mgl) => new { s, mgl })
                .Join(DbContext.TblSpieltags,
                        nrst => nrst.s.SpieltagId,
                        st => st.Id,
                        (nrst, st) => new vwSpielSargkegeln
                        {
                            SpielSargkegelnID = nrst.s.Id,
                            MeisterschaftsID = st.MeisterschaftsId,
                            SpielerID = nrst.s.SpielerId,
                            SpieltagID = nrst.s.SpieltagId,
                            Spieltag = st.Spieltag,
                            Vorname = nrst.mgl.Vorname,
                            Nachname = nrst.mgl.Nachname,
                            Spitzname = nrst.mgl.Spitzname == null ? "" : nrst.mgl.Spitzname,
                            Platzierung = nrst.s.Platzierung
                        })
                .OrderByDescending(o => o.Spieltag)
               .ToListAsync<vwSpielSargkegeln>();

            return lstSarg;
        }
        else
        {
            var lstSarg = await DbContext.TblSpielSargKegelns
                .Join(DbContext.TblMitglieders,
                        s => s.SpielerId,
                        mgl => mgl.Id,
                        (s, mgl) => new { s, mgl })
                .Join(DbContext.TblSpieltags,
                        nrst => nrst.s.SpieltagId,
                        st => st.Id,
                        (nrst, st) => new vwSpielSargkegeln
                        {
                            SpielSargkegelnID = nrst.s.Id,
                            MeisterschaftsID = st.MeisterschaftsId,
                            SpielerID = nrst.s.SpielerId,
                            SpieltagID = nrst.s.SpieltagId,
                            Spieltag = st.Spieltag,
                            Vorname = nrst.mgl.Vorname,
                            Nachname = nrst.mgl.Nachname,
                            Spitzname = nrst.mgl.Spitzname == null ? "" : nrst.mgl.Spitzname,
                            Platzierung = nrst.s.Platzierung
                        })
                .Where(w => w.SpieltagID == SpieltagID)
                .OrderByDescending(o => o.Spieltag)
               .ToListAsync<vwSpielSargkegeln>();

            return lstSarg;
        }
    }
}
