using System;
using System.Collections.Generic;

namespace KEPABackend.Modell
{
    public partial class TblSpieltag
    {
        public TblSpieltag()
        {
            Tbl9erRattens = new HashSet<Tbl9erRatten>();
            TblSpiel6TageRennens = new HashSet<TblSpiel6TageRennen>();
            TblSpielBlitztuniers = new HashSet<TblSpielBlitztunier>();
            TblSpielMeisterschafts = new HashSet<TblSpielMeisterschaft>();
            TblSpielPokals = new HashSet<TblSpielPokal>();
            TblSpielSargKegelns = new HashSet<TblSpielSargKegeln>();
        }

        public int Id { get; set; }
        public int MeisterschaftsId { get; set; }
        public DateTime Spieltag { get; set; }
        public ulong InBearbeitung { get; set; }

        public virtual TblMeisterschaften Meisterschafts { get; set; } = null!;
        public virtual ICollection<Tbl9erRatten> Tbl9erRattens { get; set; }
        public virtual ICollection<TblSpiel6TageRennen> TblSpiel6TageRennens { get; set; }
        public virtual ICollection<TblSpielBlitztunier> TblSpielBlitztuniers { get; set; }
        public virtual ICollection<TblSpielMeisterschaft> TblSpielMeisterschafts { get; set; }
        public virtual ICollection<TblSpielPokal> TblSpielPokals { get; set; }
        public virtual ICollection<TblSpielSargKegeln> TblSpielSargKegelns { get; set; }
    }
}
