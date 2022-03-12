using System;
using System.Collections.Generic;

#nullable disable

namespace Takke.Models
{
    public partial class Notification
    {
        public int Id { get; set; }
        public int NotificationId { get; set; }
        public string NotificationText { get; set; }
        public string Title { get; set; }
        public bool IsRead { get; set; }
        public int ClientId { get; set; }
        public DateTime? Notificationdate { get; set; }

        public virtual Client Client { get; set; }
    }
}
