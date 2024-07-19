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
