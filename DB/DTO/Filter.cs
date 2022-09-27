using System;
using System.Collections.Generic;
using System.Text;

namespace DB.DTO
{
    public class Filter
    {
        public List<string> BrandFilterList { get; set; }
        public List<string> GearBoxFilterList { get; set; }
        public List<string> FuelFilterList { get; set; }
        public List<string> TractionFilterList { get; set; }

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

    }
}
