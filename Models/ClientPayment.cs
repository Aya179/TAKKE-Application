using System;
using System.Collections.Generic;

#nullable disable

namespace Takke.Models
{
    public partial class ClientPayment
    {
        public int Id { get; set; }
        public int Paid { get; set; }
        public DateTime Paymentdate { get; set; }
        public int ClientId { get; set; }
        public int? Isfromorder { get; set; }

        public virtual Client Client { get; set; }
    }
}
