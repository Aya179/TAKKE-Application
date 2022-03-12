using System;
using System.Collections.Generic;

#nullable disable

namespace Takke.Models
{
    public partial class DriverSalary
    {
        public int Id { get; set; }
        public int ReceiptNumber { get; set; }
        public int Salary { get; set; }
        public DateTime Date { get; set; }
        public int DriverId { get; set; }

        public virtual Driver Driver { get; set; }
    }
}
