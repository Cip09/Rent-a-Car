using DB.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DB.DTO
{
    public class RentSchedulingCarDTO
    {
        public int Id { get; set; }
        public DateTime StarDate { get; set; }

        public string StartDataFormat { get; set; }

        public string FinishDataFormat { get; set; }

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

        public string Mention   { get; set; }

        public int SchedulingStatus { get; set; }

        public bool Gps { get; set; }

        public bool ChildSeatOption     { get; set; }

        public bool WindshieldFluid { get; set; }
        public bool SnowChains { get; set; }
        
        public string PayMethod { get; set; }


        public bool Answer {get; set; }
        public bool IsActiv { get; set; }



        public ApplicationUserModel Client { get; set; }

        public CarDTO Car { get; set; }


        public static RentSchedulingCar MappingRentDtoToEntity(RentSchedulingCarDTO schedulingCarDTO)
        {
            TimeZoneInfo easternZone = TimeZoneInfo.FindSystemTimeZoneById("E. Europe Standard Time");
        

            var entity = new RentSchedulingCar()
            {
                StarDate = TimeZoneInfo.ConvertTime(schedulingCarDTO.StarDate, easternZone),
                FinishDate = TimeZoneInfo.ConvertTime(schedulingCarDTO.FinishDate, easternZone),
                TotalPrice = schedulingCarDTO.TotalPrice,
                Mention = schedulingCarDTO.Mention,
                TakeLocation = schedulingCarDTO.TakeLocation,
                ReturnLocation = schedulingCarDTO.ReturnLocation,
                NumberOfDay = schedulingCarDTO.NumberOfDay,
                TakeTime = schedulingCarDTO.TakeTime,
                ReturnTime = schedulingCarDTO.ReturnTime,
                CompletName = schedulingCarDTO.CompletName,
                Address = schedulingCarDTO.Address,
                PhoneNumber = schedulingCarDTO.PhoneNumber,
                Gps = schedulingCarDTO.Gps,
                ChildSeatOption = schedulingCarDTO.ChildSeatOption,
                WindshieldFluid = schedulingCarDTO.WindshieldFluid,
                SnowChains = schedulingCarDTO.SnowChains,
                PayMethod = schedulingCarDTO.PayMethod,
                SchedulingStatus = schedulingCarDTO.SchedulingStatus,
              
            };

            if (schedulingCarDTO.Car != null) { 
                var carEntity = CarDTO.MapperDtoToEntity(schedulingCarDTO.Car);
                entity.Car = carEntity;
            }
            if (schedulingCarDTO.Client != null)
            {
                var clientEntity = ApplicationUserModel.MapperDtoToEntity(schedulingCarDTO.Client);
              
                entity.Client = clientEntity;
            }

            return entity;
        }

        public static RentSchedulingCarDTO MappingRentEntityToDto(RentSchedulingCar entity)
        {
            var dto = new RentSchedulingCarDTO()
            {
                Id = entity.Id,
                StarDate = entity.StarDate,
                FinishDate = entity.FinishDate,
                TotalPrice = entity.TotalPrice,
                Mention = entity.Mention,
                TakeLocation = entity.TakeLocation,
                ReturnLocation = entity.ReturnLocation,
                NumberOfDay = entity.NumberOfDay,
                TakeTime = entity.TakeTime,
                ReturnTime = entity.ReturnTime,
                CompletName = entity.CompletName,
                Address = entity.Address,
                PhoneNumber = entity.PhoneNumber,
                Gps = entity.Gps,
                ChildSeatOption = entity.ChildSeatOption,
                WindshieldFluid = entity.WindshieldFluid,
                SnowChains = entity.SnowChains,
                PayMethod = entity.PayMethod,
                StartDataFormat = entity.StarDate.ToString("dd/MM/yyyy"),
                FinishDataFormat = entity.FinishDate.ToString("dd/MM/yyyy"),
                SchedulingStatus = entity.SchedulingStatus,

            };
            if (entity.Car != null)
            {
                var carDTO = CarDTO.MapperEntityToDto(entity.Car);
                dto.Car = carDTO;
            }
            if (entity.Client != null)
            {
                var clientDTO = ApplicationUserModel.MapperEntityToDto(entity.Client);
                dto.Client = clientDTO;
            }


            return dto;
        }
    }


}
