using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace Takke.Models
{
    public partial class Price
    {

        public int Id { get; set; }

        [DisplayName("السعر حسب Km")]
        [Required(ErrorMessage = "هذا الحقل اجباري")]
        public double KmPrice { get; set; }

        [DisplayName("السعر حسب الساعة")]
        [Required(ErrorMessage = "هذا الحقل اجباري")]
        public double HourPrice { get; set; }


        [DisplayName("قيمة كوبون 5000")]
        [Required(ErrorMessage = "هذا الحقل اجباري")]
        public double _5000Cobon { get; set; }

        [DisplayName("قيمة كوبون 10000")]
        [Required(ErrorMessage = "هذا الحقل اجباري")]
        public double _10000Cobon { get; set; }
        [DisplayName("قيمة كوبون 25000")]
        [Required(ErrorMessage = "هذا الحقل اجباري")]
        public double _25000Cobon { get; set; }

        [DisplayName("اصغر قيمة ممكنة")]
        [Required(ErrorMessage = "هذا الحقل اجباري")]
        public double LowestPrice { get; set; }

        public int? DriverWaitingPrice { get; set; }
        public int? ClientWaitingPrice { get; set; }
        public double? LowestDistance { get; set; }
        public int? LatencyPrice { get; set; }
    }
}
