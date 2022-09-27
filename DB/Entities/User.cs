using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DB.Entities
{
    public enum UserRole{ 
        Admin,
        User
    };
    public class User: IdentityUser
    {

        [Column(TypeName = "nvarchar(150)")]
        public string FullName { get; set; }

        [Column(TypeName = "nvarchar(15)")]
        //public string Phone { get; set; }

        public virtual IList<Preferences> PreferencesCarList { get; set; }

        public virtual IList<HistoryClient> HistoryClients { get; set; }

        public virtual IList<Car> OwnedCar { get; set; } 

        public virtual IList<SmartDevice> smartDeviceList { get; set; }
    }
}
