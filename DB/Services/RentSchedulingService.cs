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
    public class RentSchedulingService : IRentScheduling
    {
        private DatabaseContext _db;
        public RentSchedulingService(DatabaseContext db)
        {
            this._db = db;
        }
        public void addRentScheduling(RentSchedulingCarDTO rentScheduling, string userId)
        {
            var userScheduling = _db.User.Where(x => x.Id == userId).FirstOrDefault();
            var entity = RentSchedulingCarDTO.MappingRentDtoToEntity(rentScheduling);
            entity.Car = null;
            entity.Client = userScheduling;

            var car = _db.Cars.Where(x => x.Id == rentScheduling.Car.Id).Include(x => x.RentSchedulingCarList).FirstOrDefault();
            if (car != null)
                car.RentSchedulingCarList.Add(entity);

            var ownerCar = _db.User.Where(x => x.Id == userId).FirstOrDefault();
      
            _db.RentSchedulingCars.Add(entity);

            _db.SaveChanges();

            if (ownerCar.UserName != "admin")
            {
                var notification = new Notification()
                {
                    Type = "Adaugare cerere de inchiriere masina",
                    Author = userId,
                    Read = false,
                    Date = DateTime.Now,
                    Response = 0,
                    IdScheduling = entity.Id,
                };
                _db.Add(notification);
            }

            entity.Car = car;
            _db.SaveChanges();
        }

        public void AddRequestRetreatCar(RentSchedulingCarDTO requestRetreatDTO, string userId)
        {

            var userSchedulingRetreat = _db.User.Where(x => x.Id == userId).FirstOrDefault();
            var entity = RentSchedulingCarDTO.MappingRentDtoToEntity(requestRetreatDTO);
            entity.Car = null;
            entity.Client = userSchedulingRetreat;

            var car = _db.Cars.Where(x => x.Id == requestRetreatDTO.Car.Id).Include(x => x.RentSchedulingCarList).FirstOrDefault();

            _db.RentSchedulingCars.Add(entity);

            entity.Car = car;
            _db.SaveChanges();
        }

        public List<RentSchedulingCarDTO> GetRentSchedulingCarDTOs()
        {
            var rentSchedulingRequest = _db.RentSchedulingCars
                                           .Include(x => x.Client).Where(x => x.Response == false && x.SchedulingStatus == (int)StatusSchedulingEnum.None)
                                           .Include(x => x.Car)
                                           .Select(x => RentSchedulingCarDTO.MappingRentEntityToDto(x)).ToList();

            return rentSchedulingRequest;
        }



        public List<RentSchedulingCarDTO> GetSchedulingCarApproved()
        {
            var rentSchedulingRequest = _db.RentSchedulingCars
                                          .Include(x => x.Client).Where(x => x.Response == true && x.ResponseValue == true && x.SchedulingStatus == (int)StatusSchedulingEnum.SchedulingApprovedByAdmin)
                                          .Include(x => x.Car)
                                          .Select(x => RentSchedulingCarDTO.MappingRentEntityToDto(x)).ToList();

            return rentSchedulingRequest;
        }

        public List<RentSchedulingCarDTO> GetSchedulingStart()
        {
            var rentSchedulingRequest = _db.RentSchedulingCars
                                        .Include(x => x.Client).Where(x => x.Response == true && x.ResponseValue == true && x.SchedulingStatus == (int)StatusSchedulingEnum.SchedulingStart)
                                        .Include(x => x.Car)
                                        .Select(x => RentSchedulingCarDTO.MappingRentEntityToDto(x)).ToList();

            return rentSchedulingRequest;
        }

        public void ResponseRequestScheduling(int id, bool response)
        {
            var requestScheduling = _db.RentSchedulingCars.Where(x => x.Id == id).FirstOrDefault();
            requestScheduling.Response = true;
            requestScheduling.SchedulingStatus = (int)StatusSchedulingEnum.SchedulingApprovedByAdmin;
            requestScheduling.ResponseValue = response;

            var not = _db.Notifications.Where(x => x.IdScheduling == requestScheduling.Id).FirstOrDefault();
            if (response == true && not != null)
            {

                not.Response = 1;
            }
            if (response == false && not != null)
            {

                not.Response = 2;
            }
            _db.SaveChanges();
        }

        public List<RentSchedulingCarDTO> GetRequestRetreatCarTemporary()
        {
            var requestList = _db.RentSchedulingCars.Include(x => x.Car.CarOwner)
                                                    .Where(x => x.SchedulingStatus == (int)StatusSchedulingEnum.SchedulingRetreatTemporary
                                                                && x.Response == false
                                                                && x.Car.ActiveFlag == true)
                                                    .Select(x => RentSchedulingCarDTO.MappingRentEntityToDto(x))
                                                    .ToList();

            return requestList;

        }

        public List<RentSchedulingCarDTO> GetRequestRetreatCarPermanent()
        {
            var requestList = _db.RentSchedulingCars.Include(x => x.Car.CarOwner)
                                                    .Where(x => x.SchedulingStatus == (int)StatusSchedulingEnum.SchedulingRetreatPermanen
                                                                && x.Response == false && x.Car.ActiveFlag == true)
                                                    .Select(x => RentSchedulingCarDTO.MappingRentEntityToDto(x))
                                                    .ToList();
            return requestList;

        }

        public List<RentSchedulingCarDTO> GetNextSchedulingRetreatCar(int idCar, DateTime startData, DateTime endData)
        {
            var result = _db.RentSchedulingCars.Include(x => x.Car)
                                               .Include(x => x.Client)
                                                .Where(x => x.SchedulingStatus == (int)StatusSchedulingEnum.SchedulingApprovedByAdmin
                                                           && x.Car.Id == idCar && ((startData > x.StarDate && startData < x.FinishDate)
                                                                                || (endData < x.FinishDate && endData > x.StarDate)
                                                                                 || (startData < x.StarDate && endData > x.FinishDate)))
                                                .Select(x => RentSchedulingCarDTO.MappingRentEntityToDto(x))
                                                .ToList();

            return result;
        }

        public List<RentSchedulingCarDTO> GetNextSchedulingRetreatCarPermanent(int idCar, DateTime startData)
        {
            var result = _db.RentSchedulingCars.Include(x => x.Car)
                                               .Include(x => x.Client)
                                               .Where(x => x.SchedulingStatus == (int)StatusSchedulingEnum.SchedulingApprovedByAdmin
                                                           && x.Car.Id == idCar && startData < x.FinishDate)
                                               .Select(x => RentSchedulingCarDTO.MappingRentEntityToDto(x))
                                               .ToList();
            return result;
        }

        public void ResponseRetreatCarRequest(int idRequest, string typeRequestRetreat, bool response)
        {
            if (typeRequestRetreat == "temporary")
            {
                if (response == false)
                {
                    var requestEntity = _db.RentSchedulingCars.Where(x => x.Id == idRequest).FirstOrDefault();
                    if (requestEntity != null)
                    {
                        requestEntity.SchedulingStatus = (int)StatusSchedulingEnum.SchedulingDecline;
                        requestEntity.Response = response;
                        _db.SaveChanges();
                    }
                }
                else
                {
                    var requestEntity = _db.RentSchedulingCars.Include(x => x.Car).Where(x => x.Id == idRequest).FirstOrDefault();
                    if (requestEntity != null)
                    {
                        requestEntity.SchedulingStatus = (int)StatusSchedulingEnum.ScheduliingRetreatTemporaryApproved;
                        requestEntity.Car.RetreatTemporary = true;
                        requestEntity.Response = response;
                        _db.SaveChanges();
                    }

                }
            }
            if (typeRequestRetreat == "permanent")
            {
                if (response == false)
                {
                    var requestEntity = _db.RentSchedulingCars.Where(x => x.Id == idRequest).FirstOrDefault();
                    if (requestEntity != null)
                    {
                        requestEntity.SchedulingStatus = (int)StatusSchedulingEnum.SchedulingDecline;
                        requestEntity.Response = response;
                        _db.SaveChanges();

                    }
                }
                else
                {
                    var requestEntity = _db.RentSchedulingCars.Include(x => x.Car).Where(x => x.Id == idRequest).FirstOrDefault();
                    if (requestEntity != null)
                    {
                        requestEntity.SchedulingStatus = (int)StatusSchedulingEnum.SchedulingRetreatPermanentApproved;
                        requestEntity.Car.RetreatTemporary = false;
                        // requestEntity.Car.ActiveFlag = false; blocat aici ca nu mai returneaza dupa la myCar daca e inaite de data, dar se face fals
                        // daca daca Start >= Data.Now la get AllCar
                        requestEntity.Response = response;
                        _db.SaveChanges();
                    }
                }
            }
        }
        public List<UserHistoryDTO> GetHistoryCar(int idCar) {
            
            var result = _db.UserHistory.Where(x => x.CarId == idCar && x.StatusScheduling == (int)StatusSchedulingEnum.SchedulingEnd)
                                         .Select(x => UserHistoryDTO.MapperEntityToDto(x))
                                         .ToList();

            return result;


        }

        public List<UserHistoryDTO> GetAllHistoryCar(int idCar) {
            var result = _db.UserHistory.Where(x => x.CarId == idCar)
                                     .Select(x => UserHistoryDTO.MapperEntityToDto(x))
                                     .ToList();

            return result;
        }

        public List<Notification> getAlert(string userRole, string userId) {
            List<Notification> result = new List<Notification>();
            if (userRole == "Admin") {
                result = _db.Notifications.Where(x => x.Response == 0).OrderByDescending(x => x.Date).ToList();
            }
            if (userRole == "User") {
                result = _db.Notifications.Where(x => x.Author == userId && x.Response != 0 && x.Read == false).OrderByDescending(x => x.Date).ToList();
            }

            return result;
        }

        public List<Notification> getAllAlert(string userRole, string userId) {
            List<Notification> result = new List<Notification>();
            if (userRole == "Admin")
            {
                result = _db.Notifications.Where(x => x.Response == 0).OrderByDescending(x => x.Date).ToList();
            }
            if (userRole == "User")
            {
                result = _db.Notifications.Where(x => x.Author == userId).OrderByDescending(x => x.Date).ToList();
              /*  if (result != null)
                {
                    foreach (var notificatin in result)
                    {
                        if (notificatin.Response != 0)
                        {
                            notificatin.Read = true;
                        }
                        _db.SaveChanges();
                    }
                }*/
            }
           
            return result;

        }
    }

    
}
