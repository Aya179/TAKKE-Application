using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace Takke.Models
{
    public partial class Setting
    {
        [Key]
        public int Id { get; set; }
        public string Entryname { get; set; }
        public string Entryvalue { get; set; }
        public string Entrytype { get; set; }
    }
}
