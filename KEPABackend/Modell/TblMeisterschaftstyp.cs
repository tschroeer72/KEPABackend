using System;
using System.Collections.Generic;

namespace KEPABackend.Modell
{
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
}
