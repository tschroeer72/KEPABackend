using System;
using System.Collections.Generic;

namespace KEPABackend.Modell
{
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
    public partial class TblSpielMeisterschaft
    {
        public int Id { get; set; }
        public int SpieltagId { get; set; }
        public int SpielerId1 { get; set; }
        public int SpielerId2 { get; set; }
        public int HolzSpieler1 { get; set; }
        public int HolzSpieler2 { get; set; }
        public int HinRückrunde { get; set; }

        public virtual TblMitglieder SpielerId1Navigation { get; set; } = null!;
        public virtual TblMitglieder SpielerId2Navigation { get; set; } = null!;
        public virtual TblSpieltag Spieltag { get; set; } = null!;
    }
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
}
