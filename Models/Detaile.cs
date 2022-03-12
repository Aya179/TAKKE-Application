using System;
using System.Collections.Generic;

#nullable disable

namespace Takke.Models
{
    public partial class Detaile
    {
        public int Id { get; set; }
        public int Clientid { get; set; }
        public string Detailvalue { get; set; }
        public string Detailname { get; set; }

        public virtual Client Client { get; set; }
    }
}
