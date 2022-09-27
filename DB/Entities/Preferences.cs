using System;
using System.Collections.Generic;
using System.Text;

namespace DB.Entities
{
    public class Preferences
    {
        public int Id { get; set; }

        public string CarBrand { get; set; }

        public int DoorNumbers { get; set; }

        public string CategoryCar { get; set; }

        public virtual User Client { get; set; }
    }
}
