using System;
using System.Collections.Generic;

namespace KEPABackend.Models
{
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
    public partial class TblMeisterschaftstyp
    {
        public TblMeisterschaftstyp()
        {
            TblMeisterschaftens = new HashSet<TblMeisterschaften>();
        }

        public int Id { get; set; }
        public string Meisterschaftstyp { get; set; } = null!;

        public virtual ICollection<TblMeisterschaften> TblMeisterschaftens { get; set; }
    }
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
}
