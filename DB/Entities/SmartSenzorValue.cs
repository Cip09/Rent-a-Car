using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DB.Entities
{
    public class SmartSenzorValue
    {
        [Key]
        public int Id { get; set; }

        public int IdSenzor { get; set; }
        public double MeasurementValue { get; set; }

        public long TimeStamp { get; set; }

    /*    [ForeignKey("smartSenzorValue")]
        public int? smartValueId { get; set; }
        public virtual SmartSenzor SmartSenzor { get; set; }*/


    }
}
