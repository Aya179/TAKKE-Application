using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace Takke.Models
{
    public partial class Cobon
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "هذا الحقل اجباري")]
        [DisplayName("القيمة")]

        public int CobonValue { get; set; }

        [DisplayName("تاريخ الانشاء")]
        [DataType(DataType.Date)]
        public DateTime CreationDate { get; set; }


        [DisplayName("تاريخ التفعيل")]
        [DataType(DataType.Date)]
        public DateTime ActivationCode { get; set; }


        [DisplayName("مفعل ؟")]
        public bool Activated { get; set; }

        [DisplayName("الزبون")]
        [Required(ErrorMessage = "هذا الحقل اجباري")]

        public int ClientId { get; set; }

        [DisplayName("النوع")]
        [Required(ErrorMessage = "هذا الحقل اجباري")]

        public int? Cobontype { get; set; }

        [DisplayName("الزبون")]
        public virtual Client Client { get; set; }
    }
}
