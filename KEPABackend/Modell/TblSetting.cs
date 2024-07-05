using System;
using System.Collections.Generic;

namespace KEPABackend.Modell
{
    public partial class TblSetting
    {
        public int Id { get; set; }
        public string Computername { get; set; } = null!;
        public string Parametername { get; set; } = null!;
        public string Parameterwert { get; set; } = null!;
    }
}
