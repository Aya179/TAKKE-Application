using System;
using System.Collections.Generic;

#nullable disable

namespace Takke.Models
{
    public partial class FavouriteType
    {
        public int Id { get; set; }
        public int Typename { get; set; }

        public virtual OrderType TypenameNavigation { get; set; }
    }
}
