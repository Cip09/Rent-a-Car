using DB.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Internal;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;

namespace DB.DTO
{
    public class CarDTO
    {
        public int Id { get; set; }
        public string CarBrand { get; set; }

        public string ModelCar { get; set; }
        public string ColorCar { get; set; }

        public int DoorNumbers { get; set; }

        public int SeatNumbers { get; set; }

        public double CarKm { get; set; }

        public DateTime LastServicesData { get; set; }

        public string LastServicesDataFormat { get; set; }

        public DateTime ITP { get; set; }

        public string ITPFormat { get; set; }

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

        public List<CategoryCarDTO> CategoryCar { get; set; }

        
        public IFormFile File { get; set; }

        public string Base64Image { get; set; }

        public virtual ApplicationUserModel CarOwner { get; set; }

        public bool ActiveFlag { get; set; }
        public bool RetreatTemporary { get; set; }

        public virtual List<RentSchedulingCarDTO> RentSchedulingCarListDTO { get; set; }

        public static Car MapperDtoToEntity(CarDTO carDTO)
        {
            TimeZoneInfo easternZone = TimeZoneInfo.FindSystemTimeZoneById("E. Europe Standard Time");

            var entity = new Car()
            {
                Id = carDTO.Id,
                CarBrand = carDTO.CarBrand,
                ModelCar = carDTO.ModelCar,
                ColorCar = carDTO.ColorCar,
                DoorNumbers = carDTO.DoorNumbers,
                CarKm = carDTO.CarKm,
                SeatNumbers = carDTO.SeatNumbers,
                LastServicesData = TimeZoneInfo.ConvertTime(carDTO.LastServicesData, easternZone),
                ITP = TimeZoneInfo.ConvertTime(carDTO.ITP, easternZone),
                LastServicesKm = carDTO.LastServicesKm,
                Fuel = carDTO.Fuel,
                Engine = carDTO.Engine,
                PricePerDay = carDTO.PricePerDay,
                Year = carDTO.Year,
                GearBox = carDTO.GearBox,
                EnginePower = carDTO.EnginePower,
                Navigation = carDTO.Navigation,
                BoardComputer = carDTO.BoardComputer,
                Climate =  carDTO.Climate,
                FuelConsumption = carDTO.FuelConsumption,
                Traction = carDTO.Traction,
                ActiveFlag = carDTO.ActiveFlag,
                Image = ImageStream(carDTO.File),
                RetreatTemporary = carDTO.RetreatTemporary,
            };
            if (carDTO.CategoryCar != null)
            {
                entity.CategoryCar = CategoryCarDTO.MappterDtoToEntity(carDTO.CategoryCar);
            }

            return entity;
        }

        public static CarDTO MapperEntityToDto(Car entity)
        {
            if (entity != null)
            {
                var dto = new CarDTO()
                {
                    Id = entity.Id,
                    CarBrand = entity.CarBrand,
                    ModelCar = entity.ModelCar,
                    ColorCar = entity.ColorCar,
                    DoorNumbers = entity.DoorNumbers,
                    CarKm = entity.CarKm,
                    SeatNumbers = entity.SeatNumbers,
                    LastServicesData = entity.LastServicesData,
                    LastServicesDataFormat = entity.LastServicesData.ToString("dd/MM/yyyy"),
                    ITP = entity.ITP,
                    ITPFormat = entity.ITP.ToString("dd/MM/yyyy"),
                    LastServicesKm = entity.LastServicesKm,
                    Engine = entity.Engine,
                    Fuel = entity.Fuel,
                    PricePerDay = entity.PricePerDay,
                    Year = entity.Year,
                    GearBox = entity.GearBox,
                    EnginePower = entity.EnginePower,
                    Navigation = entity.Navigation,
                    Climate = entity.Climate,
                    BoardComputer = entity.BoardComputer,
                    Traction = entity.Traction,
                    FuelConsumption = entity.FuelConsumption,
                    ActiveFlag = entity.ActiveFlag,
                    RetreatTemporary = entity.RetreatTemporary,
                    Base64Image = entity.Image != null ? "data:image/png;base64," + Convert.ToBase64String(entity.Image) : null



                };
                if (entity.CarOwner != null)
                    dto.CarOwner = ApplicationUserModel.MapperEntityToDto(entity.CarOwner);
                if (entity.CategoryCar != null)
                    dto.CategoryCar = CategoryCarDTO.MappterEntityToDto(entity.CategoryCar);
                return dto;
            }
            return new CarDTO();
        }

        public static byte[] ImageStream(IFormFile formFile)
        {
           /* if (formFile != null)
            {*/
                byte[] Bytes = null;
                if (formFile?.Length > 0)
                {
                    using (var memoryStream = new MemoryStream())
                    {
                        formFile.CopyToAsync(memoryStream);

                        Bytes = memoryStream.ToArray();

                    }
                }
                return Bytes;
          /*  }
            return byte[] Bytes;*/

        }



    }
}
