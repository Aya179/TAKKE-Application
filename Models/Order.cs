using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace Takke.Models
{
    public partial class Order
    {
        [DisplayName("رقم الطلبية")]

        public int OrderId { get; set; }

        [DisplayName("تاريخ الطلبية")]
        [DataType(DataType.Date)]
        [Required(ErrorMessage = "هذا الحقل اجباري")]
        public DateTime? OrderDate { get; set; }

        [DisplayName("الكفة التقريبية")]
        [Required(ErrorMessage = "هذا الحقل اجباري")]
        public int? ApproximateCost { get; set; }

        [DisplayName("الكلفة")]
        [Required(ErrorMessage = "هذا الحقل اجباري")]
        public int? Cost { get; set; }

        [DisplayName("الحالة")]
        [Required(ErrorMessage = "هذا الحقل اجباري")]
        public string Status { get; set; }

        [DisplayName("المبلغ المدفوع")]
        [Required(ErrorMessage = "هذا الحقل اجباري")]
        public int? Paid { get; set; }

        [DisplayName("تفاصيل المصدر")]
        [Required(ErrorMessage = "هذا الحقل اجباري")]
        public string SourceDetails { get; set; }

        [DisplayName("تفاصيل الوجهة")]
        [Required(ErrorMessage = "هذا الحقل اجباري")]
        public string DestenationDetails { get; set; }

        [DisplayName("الزبون")]
        [Required(ErrorMessage = "هذا الحقل اجباري")]
        public int ClientId { get; set; }

        [DisplayName("السائق")]
        [Required(ErrorMessage = "هذا الحقل اجباري")]
        public int DriverId { get; set; }

        [DisplayName("المصدر")]
        [Required(ErrorMessage = "هذا الحقل اجباري")]
        public string SourceLocation { get; set; }


        [DisplayName("الوجهة")]
        [Required(ErrorMessage = "هذا الحقل اجباري")]
        public string DestenationLocation { get; set; }

        [DisplayName("نوع الطلبية")]
        [Required(ErrorMessage = "هذا الحقل اجباري")]
        public int? OrderType { get; set; }


        [DisplayName("تاريخ وصول السائق")]
        [DataType(DataType.Date)]
        public DateTime? Driverarrivingtime { get; set; }
        [DisplayName("تاريخ وصول الزبون")]
        [DataType(DataType.Date)]
        public DateTime? Clientarrivingtime { get; set; }

        [DisplayName("تاريخ بدءالطلبية")]
        [DataType(DataType.Date)]

        public DateTime? Orderstarttime { get; set; }

        [DisplayName("تاريخ الانتظار")]
        [DataType(DataType.Date)]
        public DateTime? Waitingtime { get; set; }


        [DisplayName("تاريخ الوصول")]
        [DataType(DataType.Date)]
        public DateTime? Arrivingtime { get; set; }

        [DisplayName("تاريخ الوصول المتوقع")]
        [DataType(DataType.Date)]
        public DateTime? Estimatedarrivingtime { get; set; }

        [DisplayName("الزبون")]
        public virtual Client Client { get; set; }

        [DisplayName("السائق")]
        public virtual Driver Driver { get; set; }

        [DisplayName("نوع الطلبية")]

        public virtual OrderType OrderTypeNavigation { get; set; }
    }
}
