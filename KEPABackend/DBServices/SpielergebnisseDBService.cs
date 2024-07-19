using KEPABackend.DTOs.Output;
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
    public async Task<List<vwSpiel6TageRennen>> GetAllErgebnisse6TageRennenAsync(int SpieltagID = -1)
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
    /// Liefere alle Ergebnisse zu Neuner/Ratten
    /// </summary>
    /// <returns>Liste aller Neuner/Ratten</returns>
    public async Task<List<vwNeunerRatten>> GetAllErgebnisseNeunerRattenAsync(int SpieltagID = -1)
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
}
