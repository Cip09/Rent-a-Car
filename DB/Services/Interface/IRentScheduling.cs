using DB.DTO;
using DB.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DB.Services.Interface
{
    public interface IRentScheduling
    {
        void addRentScheduling(RentSchedulingCarDTO rent, string userId);
        List<RentSchedulingCarDTO> GetRentSchedulingCarDTOs();

        void ResponseRequestScheduling(int id, bool response);

        List<RentSchedulingCarDTO> GetSchedulingCarApproved();
        List<RentSchedulingCarDTO> GetSchedulingStart();

        void AddRequestRetreatCar(RentSchedulingCarDTO requestRetreat, string userId);

        List<RentSchedulingCarDTO> GetRequestRetreatCarTemporary();
        List<RentSchedulingCarDTO> GetRequestRetreatCarPermanent();

        List<RentSchedulingCarDTO> GetNextSchedulingRetreatCar(int idCar, DateTime startData, DateTime endData);
        List<RentSchedulingCarDTO> GetNextSchedulingRetreatCarPermanent(int idCar, DateTime startData);

        void ResponseRetreatCarRequest(int idRequest, string typeRequestRetreat, bool response);

        List<UserHistoryDTO> GetHistoryCar(int idCar);
        List<UserHistoryDTO> GetAllHistoryCar(int idCar);
        List<Notification> getAlert(string userRole, string userId);

        List<Notification> getAllAlert(string userRole, string userId);
    }
}
