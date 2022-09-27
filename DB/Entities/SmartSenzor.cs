using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DB.Entities
{
    public class SmartSenzor
    {
        [Key]
        public int id { get; set; }
        //[Required]
        public string senzorDescription { get; set; }

        // [Required]
        public int maximumValue { get; set; }

     /*   [ForeignKey("smartSenzorValue")]
        public int? smartValueId { get; set; }
        public virtual SmartSenzorValue SmartSenzorValue { get; set; }*/


        [ForeignKey("smartDevice")]
        public int? smartDeviceId { get; set; }
        public virtual SmartDevice smartDevice { get; set; }
    }
}
