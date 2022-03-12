using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace Takke.Models
{
    public partial class Driver
    {
        public Driver()
        {
            Cars = new HashSet<Car>();
            DriverPayments = new HashSet<DriverPayment>();
            DriverSalaries = new HashSet<DriverSalary>();
            Orders = new HashSet<Order>();
        }

        public int DriverId { get; set; }

        [DisplayName("اسم السائق")]
        [Required(ErrorMessage = "هذا الحقل اجباري")]
        public string DriverName { get; set; }

        [DisplayName("تاريخ الميلاد")]
        [DataType(DataType.Date)]
        [Required(ErrorMessage = "هذا الحقل اجباري")]
        public DateTime DriverBirthday { get; set; }

        [DisplayName("الجنس")]
        [Required(ErrorMessage = "هذا الحقل اجباري")]
        public string DriverGender { get; set; }

        [DisplayName("الشهادة")]
        [Required(ErrorMessage = "هذا الحقل اجباري")]
        public string Certificate { get; set; }

        [DisplayName("رقم الجوال")]
        [Required(ErrorMessage = "هذا الحقل اجباري")]
        [RegularExpression(@"^(9639)[0-9]{8}$", ErrorMessage = "يرجى ادخل رقم بصيغة 9639xxxxxxxx")]
        public string Mobile { get; set; }
        [DisplayName("تاريخ التسجيل")]
        [DataType(DataType.Date)]
        public DateTime Registerationdate { get; set; }
        public int? Isdeleted { get; set; }

        public virtual ICollection<Car> Cars { get; set; }
        public virtual ICollection<DriverPayment> DriverPayments { get; set; }
        public virtual ICollection<DriverSalary> DriverSalaries { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}
