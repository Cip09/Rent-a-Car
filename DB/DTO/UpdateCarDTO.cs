using System;
using System.Collections.Generic;
using System.Text;

namespace DB.DTO
{
    public class UpdateCarDTO
    {
        public DateTime NewServiceDate { get; set; }

        public int NewKmService { get; set; }
        
        public int NewCarKm { get; set; }

        public DateTime NewITP { get; set; }


    }
}
