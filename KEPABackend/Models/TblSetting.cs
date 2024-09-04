using System;
using System.Collections.Generic;

namespace KEPABackend.Models
{
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
    public partial class TblSetting
    {
        public int Id { get; set; }
        public string Computername { get; set; } = null!;
        public string Parametername { get; set; } = null!;
        public string Parameterwert { get; set; } = null!;
    }
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
}
