﻿using System;
using System.Collections.Generic;

namespace KEPABackend.Models
{
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
    public partial class TblSpielKombimeisterschaft
    {
        public int Id { get; set; }
        public int SpieltagId { get; set; }
        public int SpielerId1 { get; set; }
        public int SpielerId2 { get; set; }
        public int Spieler1Punkte3bis8 { get; set; }
        public int Spieler1Punkte5Kugeln { get; set; }
        public int Spieler2Punkte3bis8 { get; set; }
        public int Spieler2Punkte5Kugeln { get; set; }
        /// <summary>
        /// 0 = Hinrunde; 1 = Rückrunde
        /// </summary>
        public int HinRückrunde { get; set; }

        public virtual TblMitglieder SpielerId1Navigation { get; set; } = null!;
        public virtual TblMitglieder SpielerId2Navigation { get; set; } = null!;
    }
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
}
