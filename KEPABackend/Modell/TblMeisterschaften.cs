using System;
using System.Collections.Generic;

namespace KEPABackend.Modell
{
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
    public partial class TblMeisterschaften
    {
        public TblMeisterschaften()
        {
            TblSpieltags = new HashSet<TblSpieltag>();
            TblTeilnehmers = new HashSet<TblTeilnehmer>();
        }

        public int Id { get; set; }
        public string Bezeichnung { get; set; } = null!;
        public DateTime Beginn { get; set; }
        public DateTime? Ende { get; set; }
        public int MeisterschaftstypId { get; set; }
        public int? TurboDbnummer { get; set; }
        public int Aktiv { get; set; }
        public string? Bemerkungen { get; set; }

        public virtual TblMeisterschaftstyp Meisterschaftstyp { get; set; } = null!;
        public virtual ICollection<TblSpieltag> TblSpieltags { get; set; }
        public virtual ICollection<TblTeilnehmer> TblTeilnehmers { get; set; }
    }
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
}
