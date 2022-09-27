using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DB.Entities
{
    public class Notification
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public int Response { get; set; }
        public string Author { get; set; }

        public bool Read { get; set; }
        public DateTime Date { get; set; }

        public int IdScheduling { get; set; }

        [NotMapped]
        public string DateFormat => Date.ToString("dd/MM/yyyy la HH:mm");
    }
}
