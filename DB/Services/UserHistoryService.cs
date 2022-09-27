using DatabaseClass;
using DB.DTO;
using DB.Services.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DB.Services
{
    public class UserHistoryService : IUserHistoryService
    {
        private DatabaseContext _db { get; set; }
        public UserHistoryService(DatabaseContext db)
        {
            this._db = db;
        }

        public void updateStatus(int id, int status)
        {
            var scheduling = _db.RentSchedulingCars.Where(x => x.Id == id).FirstOrDefault();
            scheduling.SchedulingStatus = status;
            _db.SaveChanges();
        }

        public void addHistory(UserHistoryDTO historyDTO)
        {
            var carEntity = _db.Cars.Include(x => x.CategoryCar).Where(x => x.Id == historyDTO.CarId).FirstOrDefault();
            carEntity.CarKm = carEntity.CarKm + historyDTO.KmTraveled;
            var entity = UserHistoryDTO.MapperDtoToEntity(historyDTO);
            var scheduling = _db.RentSchedulingCars.Where(x => x.Id == historyDTO.SchedulingId).FirstOrDefault();
            scheduling.SchedulingStatus = (int)historyDTO.StatusScheduling;
            entity.NameCategoryCar = carEntity.CategoryCar.FirstOrDefault().NameCategoryCar;
            _db.UserHistory.Add(entity);
            _db.SaveChanges();
        }

        public List<UserHistoryDTO> GetUserHistory(string id)
        {
          var historyList = _db.UserHistory.Where(x => x.ClientId == id).Select(x => UserHistoryDTO.MapperEntityToDto(x)).ToList();
            return historyList;  
        }
        public List<UserHistoryDTO> GetAll()
        {
            return _db.UserHistory.Select(x => UserHistoryDTO.MapperEntityToDto(x)).ToList();
        }
    }
}
