﻿using System;
using System.Collections.Generic;

namespace KEPABackend.Modell
{
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
    public partial class TblSpiel6TageRennen
    {
        public int Id { get; set; }
        public int SpieltagId { get; set; }
        public int SpielerId1 { get; set; }
        public int SpielerId2 { get; set; }
        public int Runden { get; set; }
        public int Punkte { get; set; }
        public int? Spielnummer { get; set; }

        public virtual TblMitglieder SpielerId1Navigation { get; set; } = null!;
        public virtual TblMitglieder SpielerId2Navigation { get; set; } = null!;
        public virtual TblSpieltag Spieltag { get; set; } = null!;
    }
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
}
