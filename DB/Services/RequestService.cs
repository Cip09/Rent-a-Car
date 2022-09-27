using DatabaseClass;
using DB.DTO;
using DB.Entities;
using DB.Services.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DB.Services
{
    public class RequestService : IRequestService
    {
        private DatabaseContext _db;

        public RequestService(DatabaseContext db)
        {
            this._db = db;
        }
        public void AddRequest(RequestDTO requestDTO, string idUser)
        {
            var requestEntity = RequestDTO.MapperDtoToEntity(requestDTO);
            var ownerCar = _db.User.Where(x => x.Id == idUser).FirstOrDefault();
            requestEntity.Car.CarOwner = ownerCar;
           
            _db.Requests.Add(requestEntity);

            

            if (ownerCar.UserName != "admin")
            {
                var notification = new Notification()
                {
                    Type = "Adaugare masina pentru inchiriere",
                    Author = idUser,
                    Read = false,
                    Date = DateTime.Now,
                    Response = 0,
                    IdScheduling = _db.Requests.OrderByDescending(x => x.Id).First().Id + 1,
                };
                _db.Add(notification);
            }
            _db.SaveChanges();
        }

        public void deleteRequest(int idRequest)
        {
            throw new NotImplementedException();
        }

        public List<RequestDTO> GetAllRequests()
        {
            var requestList = _db.Requests
                .Where(x => x.Response == false)
                .Include(x => x.Car)
                .Include(x => x.Car.CarOwner)
                .Include(x => x.Car.CategoryCar)
               .Select(x => new RequestDTO
               {
                   Id = x.Id,
                   Response = x.Response,
                   Message = x.Message,
                   CarDTO = CarDTO.MapperEntityToDto(x.Car)

               })

                .ToList();
            return requestList;

        }

        public List<RequestDTO> GetRequestsByUser(int userId)
        {
            if (userId > 0)
            {
                var entityList = _db.Requests.Where(x => x.Id == userId).Include(z => z.Car).ToList();
                if (entityList != null)
                    return entityList.Select(x => RequestDTO.MapperEntityToDto(x)).ToList();
            }
            return null;
        }

        public void ResponseRequest(int id, bool response)
        {
            var entity = _db.Requests.Include(x => x.Car).Where(x => x.Id == id).FirstOrDefault();
            entity.Response = true;
            entity.Car.ActiveFlag = response;
            var not = _db.Notifications.Where(x => x.IdScheduling == entity.Id).FirstOrDefault();
            if (response == true && not != null) {
               
                not.Response = 1;
            }
            if (response == false && not != null)
            {
    
                not.Response = 2;
            }
            _db.SaveChanges();
        }

        public void updateRequest(RequestDTO requestDTO, int id)
        {
            var entity = _db.Requests.Where(x => x.Id == id).FirstOrDefault();
            var newRequest = RequestDTO.MapperDtoToEntity(requestDTO);

            if (entity != null)
            {
                entity.Response = newRequest.Response;
                entity.Message = newRequest.Message;
                _db.SaveChanges();
            }

        }
    }
}
