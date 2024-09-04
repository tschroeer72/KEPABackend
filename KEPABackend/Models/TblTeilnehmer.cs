using System;
using System.Collections.Generic;

namespace KEPABackend.Models
{
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
    public partial class TblTeilnehmer
    {
        public int Id { get; set; }
        public int MeisterschaftsId { get; set; }
        public int SpielerId { get; set; }

        public virtual TblMeisterschaften Meisterschafts { get; set; } = null!;
        public virtual TblMitglieder Spieler { get; set; } = null!;
    }
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
}
