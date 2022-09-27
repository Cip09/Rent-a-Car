using DatabaseClass;
using DB.DTO;
using DB.Entities;
using DB.Entities.Enum;
using DB.Services.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DB.Services
{
    public class CarService : ICarService
    {
        private DatabaseContext _db { get; set; }
        public CarService(DatabaseContext db)
        {
            this._db = db;
        }
        public void addCar(CarDTO carDTO)
        {
            var entityCar = CarDTO.MapperDtoToEntity(carDTO);

            var entitiRentScheduling = carDTO.RentSchedulingCarListDTO.Select(x => RentSchedulingCarDTO.MappingRentDtoToEntity(x)).ToList();

            entityCar.RentSchedulingCarList = entitiRentScheduling;

            _db.Cars.Add(entityCar);
            _db.SaveChanges();


        }

        public void deleteCar(int id)
        {
            var car = _db.Cars.FirstOrDefault(x => x.Id == id);
            if (car != null && car.ActiveFlag == true)
            {
                car.ActiveFlag = false;
                _db.SaveChanges();
            }

        }

        public List<CarDTO> GetAllCars()
        {
            var entitiRequest = _db.RentSchedulingCars.Include(x => x.Car).Where(x => x.SchedulingStatus == (int)StatusSchedulingEnum.SchedulingRetreatPermanentApproved
                                                                               && x.StarDate <= DateTime.Now).ToList();
            foreach (var entity in entitiRequest)
            {
                entity.Car.ActiveFlag = false;
            }
            _db.SaveChanges();

            var carList = _db.Cars.Where(x => x.ActiveFlag == true)
                                  .Include(z => z.RentSchedulingCarList)
                                  .Include(x => x.CategoryCar)
                                  .ToList();


            List<CarDTO> carDtoList = new List<CarDTO>();
            foreach (var element in carList)
            {
                var dtoElement = CarDTO.MapperEntityToDto(element);
                if (element.RentSchedulingCarList != null)
                    dtoElement.RentSchedulingCarListDTO = element.RentSchedulingCarList
                                                                 .Select(x => RentSchedulingCarDTO.MappingRentEntityToDto(x))
                                                                 .ToList();
                carDtoList.Add(dtoElement);
            }

            return carDtoList;
        }

        public CarDTO GetCarById(int carId)
        {
            var result = _db.Cars.Where(x => x.Id == carId && x.ActiveFlag == true)
                                 .Include(x => x.CarOwner)
                                 .Include(x => x.CategoryCar).FirstOrDefault();
            return CarDTO.MapperEntityToDto(result);
        }

        public CarDTO GetDisabledCarById(int idCar)
        {
            var result = _db.Cars.Where(x => x.Id == idCar)
                                  .Include(x => x.CarOwner)
                                 .Include(x => x.CategoryCar).FirstOrDefault();
            return CarDTO.MapperEntityToDto(result);
        }



        public List<CarDTO> GetCarsByUserId(string userId)
        {
            var entity = _db.Cars?.Include(x => x.CarOwner)
                                 .Where(x => x.CarOwner.Id == userId && x.ActiveFlag == true)
                                 .ToList();
            var listCarDto = new List<CarDTO>();
            foreach (var car in entity)
            {
                var dto = CarDTO.MapperEntityToDto(car);
                listCarDto.Add(dto);
            }


            return listCarDto;
        }

        public List<UserHistoryDTO> GetHistoryCar(int id)
        {
            var history = _db.UserHistory.Where(x => x.CarId == id).Select(x => UserHistoryDTO.MapperEntityToDto(x)).ToList();
            return history;
        }

        public List<CarDTO> GetActivCarForAdmin()
        {
            var result = _db.Cars.Include(x => x.CarOwner)
                                 .Where(x => x.ActiveFlag == true)
                                 .Select(x => CarDTO.MapperEntityToDto(x))
                                 .ToList();
            return result;

        }

        public List<RentSchedulingCarDTO> GetRetreatCarList()
        {
            var result = _db.RentSchedulingCars.Include(x => x.Car.CarOwner)
                                               .Where(x => (x.SchedulingStatus == (int)StatusSchedulingEnum.ScheduliingRetreatTemporaryApproved
                                                            || x.SchedulingStatus == (int)StatusSchedulingEnum.SchedulingRetreatPermanentApproved)
                                                           && x.Car.ActiveFlag == true && x.StarDate >= DateTime.Now)
                                               .Select(x => RentSchedulingCarDTO.MappingRentEntityToDto(x))
                                               .ToList();
            return result;
        }

        public List<RentSchedulingCarDTO> GetDisabledCarList()
        {
            /*     var result = _db.Cars.Include(x => x.CarOwner)
                                      .Include(x => x.RentSchedulingCarList.FirstOrDefault(x => x.SchedulingStatus == (int)StatusSchedulingEnum.SchedulingRetreatPermanentApproved
                                               && x.StarDate <= DateTime.Now))
                                      .Where(x => x.ActiveFlag == false && x.RentSchedulingCarList != null)
                                      .Select(x => CarDTO.MapperEntityToDto(x))
                                      .ToList();*/
            var result = _db.RentSchedulingCars.Include(x => x.Car.CarOwner)
                                               .Where(x => x.SchedulingStatus == (int)StatusSchedulingEnum.SchedulingRetreatPermanentApproved
                                                      && x.StarDate <= DateTime.Now)

                                               .ToList();
            foreach (var entity in result)
            {
                entity.Car.ActiveFlag = false;
            }
            _db.SaveChanges();
            var resultListDto = result.Select(x => RentSchedulingCarDTO.MappingRentEntityToDto(x)).ToList();

            /*    var CarDtoList = result.Select(x => new CarDTO
                {
                    Id = x.Car.Id,
                    CarOwner = ApplicationUserModel.MapperEntityToDto(x.Car.CarOwner),
                    CarBrand = x.Car.CarBrand,
                    ModelCar = x.Car.ModelCar,
                    PricePerDay = x.Car.PricePerDay,

                }).ToList();*/

            return resultListDto;

        }


        public void updateCar(int idCar, UpdateCarDTO newCar)
        {
            var entity = _db.Cars.Include(c => c.CarOwner).FirstOrDefault(x => x.Id == idCar);

            TimeZoneInfo easternZone = TimeZoneInfo.FindSystemTimeZoneById("E. Europe Standard Time");

            if (entity != null)
            {

                if (newCar.NewServiceDate.Year > 2000)
                {
                    entity.LastServicesData = TimeZoneInfo.ConvertTime(newCar.NewServiceDate, easternZone);
                }
                if (newCar.NewKmService != 0)
                {
                    entity.LastServicesKm = newCar.NewKmService;
                }
                if (newCar.NewCarKm != 0)
                {
                    entity.CarKm = newCar.NewCarKm;
                }
                if (newCar.NewITP.Year > 2000)
                {
                    entity.ITP = TimeZoneInfo.ConvertTime(newCar.NewITP, easternZone);
                }
                _db.SaveChanges();

            }
        }

        public List<CarDTO> GetCarFilter(Filter filterList)
        {
            //pe masininile care sunt activ
            var carEntities = _db.Cars.Where(x => x.ActiveFlag == true);
            var carDtos = new List<CarDTO>();
            if (filterList == null)
            {
                carDtos = carEntities.ToList().Select(x => CarDTO.MapperEntityToDto(x)).ToList();
                return carDtos;
            }



            if (filterList.BrandFilterList.Count > 0)
            {
                carEntities = carEntities.Where(x => filterList.BrandFilterList.Contains(x.CarBrand));
            }
            if (filterList.GearBoxFilterList.Count > 0)
            {
                carEntities = carEntities.Where(x => filterList.GearBoxFilterList.Contains(x.GearBox));
            }
            if (filterList.FuelFilterList.Count > 0)
            {
                carEntities = carEntities.Where(x => filterList.FuelFilterList.Contains(x.Fuel));
            }
            if (filterList.TractionFilterList.Count > 0)
            {
                carEntities = carEntities.Where(x => filterList.TractionFilterList.Contains(x.Traction));
            }

            carEntities = carEntities.Include(z => z.RentSchedulingCarList)
                                 .Include(x => x.CategoryCar);


            if (filterList.StartDate.Year > 1970 && filterList.EndDate.Year > 1970)
            {

                var start = filterList.StartDate.Date;
                start = start.AddDays(1);
                var end = filterList.EndDate.Date;
                end = end.AddDays(1);

                foreach (var car in carEntities.ToList())
                {
                    /*  if (!car.RentSchedulingCarList.Any(x =>
                        !(start > x.FinishDate || end < x.StarDate ) &&

                        x.SchedulingStatus != (int)StatusSchedulingEnum.SchedulingApprovedByAdmin ||
                        x.SchedulingStatus != (int)StatusSchedulingEnum.SchedulingStart ||
                        x.SchedulingStatus != (int)StatusSchedulingEnum.ScheduliingRetreatTemporaryApproved
                        ||
                        (x.SchedulingStatus != (int)StatusSchedulingEnum.SchedulingRetreatPermanentApproved && end < x.StarDate)
                          ))
                      {
                          carDtos.Add(CarDTO.MapperEntityToDto(car));
                      }*/
                    if (!car.RentSchedulingCarList.Any(x =>
                        (start < x.FinishDate || end > x.StarDate) &&
                        (x.SchedulingStatus == (int)StatusSchedulingEnum.SchedulingApprovedByAdmin ||
                        x.SchedulingStatus == (int)StatusSchedulingEnum.SchedulingStart ||
                        x.SchedulingStatus == (int)StatusSchedulingEnum.ScheduliingRetreatTemporaryApproved)
                        || (x.SchedulingStatus == (int)StatusSchedulingEnum.SchedulingRetreatPermanentApproved && end > x.StarDate)
                        ))
                    {
                        carDtos.Add(CarDTO.MapperEntityToDto(car));
                    }
                }

            }
            else if (filterList.StartDate.Year > 1970)
            {
                var start = filterList.StartDate.Date;
                start = start.AddDays(1);

                foreach (var car in carEntities.ToList())
                {
                    if (!car.RentSchedulingCarList.Any(x =>
                      start > x.FinishDate &&

                      x.SchedulingStatus != (int)StatusSchedulingEnum.SchedulingApprovedByAdmin &&
                      x.SchedulingStatus != (int)StatusSchedulingEnum.SchedulingStart &&
                      x.SchedulingStatus != (int)StatusSchedulingEnum.ScheduliingRetreatTemporaryApproved
                      ||
                      (x.SchedulingStatus != (int)StatusSchedulingEnum.SchedulingRetreatPermanentApproved && start < x.StarDate)
                        ))
                    {
                        carDtos.Add(CarDTO.MapperEntityToDto(car));
                    }
                }
            }
            else if (filterList.EndDate.Year > 1970)
            {
                var end = filterList.EndDate.Date;
                end = end.AddDays(1);

                foreach (var car in carEntities.ToList())
                {
                    if (!car.RentSchedulingCarList.Any(x =>
                      end > x.StarDate &&

                      x.SchedulingStatus != (int)StatusSchedulingEnum.SchedulingApprovedByAdmin &&
                      x.SchedulingStatus != (int)StatusSchedulingEnum.SchedulingStart &&
                      x.SchedulingStatus != (int)StatusSchedulingEnum.ScheduliingRetreatTemporaryApproved
                      ||
                      (x.SchedulingStatus != (int)StatusSchedulingEnum.SchedulingRetreatPermanentApproved && end < x.StarDate)
                        ))
                    {
                        carDtos.Add(CarDTO.MapperEntityToDto(car));
                    }
                }
            }

            if (carDtos.Count == 0)
            {
                carDtos = carEntities.ToList()
                         .Select(x => CarDTO.MapperEntityToDto(x)).ToList();

            }


            return carDtos;
        }

    }
}
