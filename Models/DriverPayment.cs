using System;
using System.Collections.Generic;

#nullable disable

namespace Takke.Models
{
    public partial class DriverPayment
    {
        public int Id { get; set; }
        public DateTime PaymentDate { get; set; }
        public int Paid { get; set; }
        public int DriverId { get; set; }
        public int? Orderid { get; set; }

        public virtual Driver Driver { get; set; }
    }
}
