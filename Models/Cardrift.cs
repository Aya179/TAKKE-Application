using System;
using System.Collections.Generic;

#nullable disable

namespace Takke.Models
{
    public partial class Cardrift
    {
        public Cardrift()
        {
            Driftpassengers = new HashSet<Driftpassenger>();
        }

        public int Id { get; set; }
        public int? Clientid { get; set; }
        public DateTime? AnnData { get; set; }
        public DateTime? Departdate { get; set; }
        public TimeSpan? Departtime { get; set; }
        public string Departaddress { get; set; }
        public string Arriveaddress { get; set; }
        public string Departlocation { get; set; }
        public string Arrivelocation { get; set; }
        public string Cartype { get; set; }
        public int? Numofclients { get; set; }
        public int? Cost { get; set; }

        public virtual Client Client { get; set; }
        public virtual ICollection<Driftpassenger> Driftpassengers { get; set; }
    }
}
