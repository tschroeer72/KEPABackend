using System;
using System.Collections.Generic;

namespace KEPABackend.Modell
{
    public partial class TblMitglieder
    {
        public TblMitglieder()
        {
            Tbl9erRattens = new HashSet<Tbl9erRatten>();
            TblSpiel6TageRennenSpielerId1Navigations = new HashSet<TblSpiel6TageRennen>();
            TblSpiel6TageRennenSpielerId2Navigations = new HashSet<TblSpiel6TageRennen>();
            TblSpielBlitztunierSpielerId1Navigations = new HashSet<TblSpielBlitztunier>();
            TblSpielBlitztunierSpielerId2Navigations = new HashSet<TblSpielBlitztunier>();
            TblSpielKombimeisterschaftSpielerId1Navigations = new HashSet<TblSpielKombimeisterschaft>();
            TblSpielKombimeisterschaftSpielerId2Navigations = new HashSet<TblSpielKombimeisterschaft>();
            TblSpielMeisterschaftSpielerId1Navigations = new HashSet<TblSpielMeisterschaft>();
            TblSpielMeisterschaftSpielerId2Navigations = new HashSet<TblSpielMeisterschaft>();
            TblSpielPokals = new HashSet<TblSpielPokal>();
            TblSpielSargKegelns = new HashSet<TblSpielSargKegeln>();
            TblTeilnehmers = new HashSet<TblTeilnehmer>();
        }

        public int Id { get; set; }
        public string Vorname { get; set; } = null!;
        public string Nachname { get; set; } = null!;
        public string? Spitzname { get; set; }
        public string? Straße { get; set; }
        public string? Plz { get; set; }
        public string? Ort { get; set; }
        public DateTime? Geburtsdatum { get; set; }
        public DateTime MitgliedSeit { get; set; }
        public DateTime? PassivSeit { get; set; }
        public DateTime? AusgeschiedenAm { get; set; }
        public ulong Ehemaliger { get; set; }
        public string? Notizen { get; set; }
        public string? Bemerkungen { get; set; }
        public string? Anrede { get; set; }
        public string? Email { get; set; }
        public string? TelefonPrivat { get; set; }
        public string? TelefonFirma { get; set; }
        public string? TelefonMobil { get; set; }
        public string? Fax { get; set; }
        public int? SpAnz { get; set; }
        public int? SpGew { get; set; }
        public int? SpUn { get; set; }
        public int? SpVerl { get; set; }
        public int? HolzGes { get; set; }
        public int? HolzMax { get; set; }
        public int? HolzMin { get; set; }
        public int? Punkte { get; set; }
        public string? Platz { get; set; }
        public int? TurboDbnummer { get; set; }

        public virtual ICollection<Tbl9erRatten> Tbl9erRattens { get; set; }
        public virtual ICollection<TblSpiel6TageRennen> TblSpiel6TageRennenSpielerId1Navigations { get; set; }
        public virtual ICollection<TblSpiel6TageRennen> TblSpiel6TageRennenSpielerId2Navigations { get; set; }
        public virtual ICollection<TblSpielBlitztunier> TblSpielBlitztunierSpielerId1Navigations { get; set; }
        public virtual ICollection<TblSpielBlitztunier> TblSpielBlitztunierSpielerId2Navigations { get; set; }
        public virtual ICollection<TblSpielKombimeisterschaft> TblSpielKombimeisterschaftSpielerId1Navigations { get; set; }
        public virtual ICollection<TblSpielKombimeisterschaft> TblSpielKombimeisterschaftSpielerId2Navigations { get; set; }
        public virtual ICollection<TblSpielMeisterschaft> TblSpielMeisterschaftSpielerId1Navigations { get; set; }
        public virtual ICollection<TblSpielMeisterschaft> TblSpielMeisterschaftSpielerId2Navigations { get; set; }
        public virtual ICollection<TblSpielPokal> TblSpielPokals { get; set; }
        public virtual ICollection<TblSpielSargKegeln> TblSpielSargKegelns { get; set; }
        public virtual ICollection<TblTeilnehmer> TblTeilnehmers { get; set; }
    }
}
