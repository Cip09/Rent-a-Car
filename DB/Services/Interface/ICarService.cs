

using DB.DTO;
using System.Collections.Generic;

namespace DB.Services.Interface
{
    public interface ICarService
    {
        void addCar(CarDTO carDTO);
        CarDTO GetCarById(int carId);

        CarDTO GetDisabledCarById(int idCar);

        List<CarDTO> GetCarsByUserId(string userId);

        List<CarDTO> GetAllCars();

        void updateCar(int idCar, UpdateCarDTO newCar);
        void deleteCar(int id);

        List<UserHistoryDTO> GetHistoryCar(int id);

        List<CarDTO> GetActivCarForAdmin();

        List<RentSchedulingCarDTO> GetRetreatCarList();

        List<RentSchedulingCarDTO> GetDisabledCarList();

        List<CarDTO> GetCarFilter(Filter filterList);

    }
}
