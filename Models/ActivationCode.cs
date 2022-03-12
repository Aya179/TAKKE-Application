using System;
using System.Collections.Generic;

#nullable disable

namespace Takke.Models
{
    public partial class ActivationCode
    {
        public int Id { get; set; }
        public int ClientId { get; set; }
        public string Code { get; set; }
        public DateTime CreatingDate { get; set; }
        public int Duration { get; set; }
        public DateTime RegisterationDate { get; set; }

        public virtual Client Client { get; set; }
    }
}
