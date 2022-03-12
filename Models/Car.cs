using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace Takke.Models
{
    public partial class Car
    {
        public int Id { get; set; }

        [DisplayName("رقم السيارة")]
        [Required(ErrorMessage = "هذا الحقل اجباري")]
        public string CarNumber { get; set; }

        [DisplayName("الحالة")]
        [Required(ErrorMessage = "هذا الحقل اجباري")]
        public string Status { get; set; }

        [DisplayName("سنة الصنع")]
        [Required(ErrorMessage = "هذا الحقل اجباري")]
        public int Madeyear { get; set; }

        [DisplayName("الشركة المصنعة")]
        [Required(ErrorMessage = "هذا الحقل اجباري")]
        public string Manufacture { get; set; }

        [DisplayName("المسافة المقطوعة")]
        public string TarvelDistance { get; set; }

        [DisplayName("موديل السيارة")]
        [Required(ErrorMessage = "هذا الحقل اجباري")]
        public string CarModel { get; set; }
        [DisplayName("السائق")]
        [Required(ErrorMessage = "هذا الحقل اجباري")]
        public int DriverId { get; set; }

        public virtual Driver Driver { get; set; }
    }
}
