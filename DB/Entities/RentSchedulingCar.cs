using System;
using System.Collections.Generic;
using System.Text;

namespace DB.Entities
{
    public class RentSchedulingCar
    {
        public int Id { get; set; }
        public DateTime StarDate { get; set; }

        public DateTime FinishDate { get; set; }

        public double TotalPrice { get; set; }

        public string TakeLocation { get; set; }

        public string ReturnLocation { get; set; }

        public int NumberOfDay { get; set; }


        public string TakeTime { get; set; }
        public string ReturnTime { get; set; }

        public string CompletName { get; set; }

        public string Address { get; set; }

        public string PhoneNumber { get; set; }

        public string Mention { get; set; }

        public int SchedulingStatus { get; set; }

        public bool Gps { get; set; }

        public bool ChildSeatOption { get; set; }

        public bool WindshieldFluid { get; set; }
        public bool SnowChains { get; set; }
        public string PayMethod { get; set; }


        public bool ResponseValue { get; set; }

        public bool Response { get; set; }



        public virtual User Client { get; set; }

        public virtual Car Car { get; set; }
    }
}
