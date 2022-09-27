using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DB.Entities
{
    public class HistoryClient
    {
        [Key]
        public int Id { get; set; }
        public DateTime StartDate { get; set; }
           
        public DateTime EndDate { get; set; }

        public int Raiting { get; set; }

        public double KmTraveled { get; set; }

        public int MoneyPaid { get; set; }

        public string Notest {get; set; }

        public virtual User Client { get; set; }

    }
}
