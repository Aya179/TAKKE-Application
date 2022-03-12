using System;
using System.Collections.Generic;

#nullable disable

namespace Takke.Models
{
    public partial class Driftpassenger
    {
        public int Id { get; set; }
        public int? Driftid { get; set; }
        public int? Clientid { get; set; }
        public DateTime? Requestdate { get; set; }
        public TimeSpan? Requesttime { get; set; }
        public bool? Isapproved { get; set; }
        public bool? Ispayed { get; set; }

        public virtual Cardrift Drift { get; set; }
    }
}
