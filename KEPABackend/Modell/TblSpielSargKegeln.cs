using System;
using System.Collections.Generic;

namespace KEPABackend.Modell
{
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
    public partial class TblSpielSargKegeln
    {
        public int Id { get; set; }
        public int SpieltagId { get; set; }
        public int SpielerId { get; set; }
        public int Platzierung { get; set; }

        public virtual TblMitglieder Spieler { get; set; } = null!;
        public virtual TblSpieltag Spieltag { get; set; } = null!;
    }
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
}
