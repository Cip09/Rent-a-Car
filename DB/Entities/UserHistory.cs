using System;
using System.Collections.Generic;
using System.Text;

namespace DB.Entities
{
    public class UserHistory
    {
        public int Id { get; set; }

        public string FullNameClient { get; set; }

        public string BrandCar { get; set; }

        public string ModelCar { get; set; }

        public int DayNumber { get; set; }

        public int StatusScheduling { get; set; }

        public int MoneyPaid { get; set; }

        public string Mention { get; set; }

        public string DeclineReason { get; set; }

        public int KmTraveled { get; set; }

        public  string StartData { get; set; }

        public int DayLate { get; set; }
        public string NameCategoryCar { get; set; }

        public bool ExternalDefects { get; set; }

        public bool InternalDefects { get; set; }

        public bool ReturnWarranty { get; set; }

        public string EndData { get; set; }
        public int SchedulingId { get; set; }
        public int CarId { get; set; }

        public string ClientId { get; set; }
    }
}
