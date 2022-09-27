using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DB.Entities
{
    public class SmartDevice
    {
        [Key]
        public int id { get; set; }
        //[Required]
        public string description { get; set; }
        //[Required]
        public string locatin { get; set; }
        //[Required]
        public int maxEnergyConsumtion { get; set; }
        //[Required]
        public int baselineEnergyConsumtion { get; set; }

        public virtual User client { get; set; }

        [ForeignKey("smartSenzor")]
        public int? smartSenzorId { get; set; }

        public virtual SmartSenzor smartSenzor { get; set; }
    }
}
