using System;
using System.Collections.Generic;

#nullable disable

namespace Takke.Models
{
    public partial class Massage
    {
        public int MassageId { get; set; }
        public int MassageType { get; set; }
        public int ClientId { get; set; }
        public string MessageContent { get; set; }
        public DateTime ReadDate { get; set; }
        public string PhoneNumber { get; set; }
        public string Title { get; set; }
        public bool? Isread { get; set; }

        public virtual Client Client { get; set; }
    }
}
