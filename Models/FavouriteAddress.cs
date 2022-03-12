using System;
using System.Collections.Generic;

#nullable disable

namespace Takke.Models
{
    public partial class FavouriteAddress
    {
        public int AddressId { get; set; }
        public int ClientId { get; set; }
        public string Location { get; set; }
        public int? Typeid { get; set; }

        public virtual Client Client { get; set; }
    }
}
