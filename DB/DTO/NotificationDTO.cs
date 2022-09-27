using System;
using System.Collections.Generic;
using System.Text;

namespace DB.DTO
{
    public class NotificationDTO
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public int Response { get; set; }
        public string Author { get; set; }

        public bool Read { get; set; }
        public DateTime Date { get; set; }

        public string DateFormat { get; set; }

        public int IdScheduling { get; set; }


    }
}
