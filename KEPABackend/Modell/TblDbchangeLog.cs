using System;
using System.Collections.Generic;

namespace KEPABackend.Modell
{
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
    public partial class TblDbchangeLog
    {
        public int Id { get; set; }
        public string? Computername { get; set; }
        public string? Tablename { get; set; }
        public string? Changetype { get; set; }
        public string? Command { get; set; }
        public DateTime Zeitstempel { get; set; }
    }
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
}
