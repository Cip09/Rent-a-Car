using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DB.Entities
{
    public class Car
    {
        public Car()
        {
            List<RentSchedulingCar> RentSchedulingCarList = new List<RentSchedulingCar>();
        }
        [Key]
        public int Id { get; set; }
        
        public string CarBrand { get; set; }

        public string ModelCar { get; set; }
        public string ColorCar { get; set; }

        public int DoorNumbers {get; set; }
    
        public int SeatNumbers {get; set; }

        public double CarKm { get; set; }

        public DateTime LastServicesData { get; set; }

        public DateTime ITP { get; set; }

        public int LastServicesKm { get; set; }

        public string Fuel { get; set; }

        public double FuelConsumption { get; set; }

        public string Engine { get; set; }

        public int PricePerDay { get; set; }

        public int Year { get; set; }

        public bool Climate { get; set; }

        public string GearBox { get; set; }

        public int EnginePower { get; set; }

        public bool Navigation { get; set; }

        public bool BoardComputer { get; set; }

        public string Traction { get; set; }

        public List<CategoryCar> CategoryCar {get; set; }

        public bool ActiveFlag { get; set; }

        public bool RetreatTemporary { get; set; }


        public  byte[] Image { get; set; }

        public virtual User CarOwner { get; set; }

        public virtual List<RentSchedulingCar> RentSchedulingCarList { get; set; }

       

    }

    
}
