using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace Takke.Models
{
    public partial class OrderType
    {
        public OrderType()
        {
            FavouriteTypes = new HashSet<FavouriteType>();
        }


        public int Id { get; set; }

        [DisplayName("اسم النوع")]
        [Required(ErrorMessage = "هذا الحقل اجباري")]
        public string Typename { get; set; }

        [DisplayName("الوصف")]
        [Required(ErrorMessage = "هذا الحقل اجباري")]
        public string Description { get; set; }

        public virtual Order IdNavigation { get; set; }
        public virtual ICollection<FavouriteType> FavouriteTypes { get; set; }
    }
}
