using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace Takke.Models
{
    public partial class Client
    {
        public Client()
        {
            ActivationCodes = new HashSet<ActivationCode>();
            Cardrifts = new HashSet<Cardrift>();
            ClientPayments = new HashSet<ClientPayment>();
            Cobons = new HashSet<Cobon>();
            Detailes = new HashSet<Detaile>();
            FavouriteAddresses = new HashSet<FavouriteAddress>();
            Massages = new HashSet<Massage>();
            Notifications = new HashSet<Notification>();
            Orders = new HashSet<Order>();
        }

        public int ClientId { get; set; }



        [DisplayName("الاسم")]
        [Required(ErrorMessage = "هذا الحقل اجباري")]
        public string ClientName { get; set; }

        [DisplayName("رقم العميل")]
        [Required(ErrorMessage = "هذا الحقل اجباري")]
        public string ClientNumber { get; set; }

        [DisplayName("رقم الجوال")]
        [Required(ErrorMessage = "هذا الحقل اجباري")]
        [RegularExpression(@"^(9639)[0-9]{8}$", ErrorMessage = "يرجى ادخل رقم بصيغة 9639xxxxxxxx")]
        public string ClientMobile { get; set; }

        [DisplayName("الجنس")]
        [Required(ErrorMessage = "هذا الحقل اجباري")]
        public bool ClientGender { get; set; }

        [DisplayName("تاريخ الميلاد")]
        [DataType(DataType.Date)]
        [Required(ErrorMessage = "هذا الحقل اجباري")]
        public DateTime? ClientBirthday { get; set; }
        public bool? IsDeleted { get; set; }


        [DisplayName("هل الحساب مفعل")]
        [Required(ErrorMessage = "هذا الحقل اجباري")]
        public bool IsActive { get; set; }

        [DisplayName("تاريخ التسجيل")]
        [DataType(DataType.Date)]
        public DateTime RegisterationDate { get; set; }

        [DisplayName("ملاحظات")]
        public string Notes { get; set; }
        public string Token { get; set; }

        [DisplayName("البريد الالكتروني")]
        public string Email { get; set; }

        [DisplayName("الصورة الاساسية")]
        public string Mainphoto { get; set; }

        public virtual ICollection<ActivationCode> ActivationCodes { get; set; }
        public virtual ICollection<Cardrift> Cardrifts { get; set; }
        public virtual ICollection<ClientPayment> ClientPayments { get; set; }
        public virtual ICollection<Cobon> Cobons { get; set; }
        public virtual ICollection<Detaile> Detailes { get; set; }
        public virtual ICollection<FavouriteAddress> FavouriteAddresses { get; set; }
        public virtual ICollection<Massage> Massages { get; set; }
        public virtual ICollection<Notification> Notifications { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}
