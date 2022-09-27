using DB.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DB.DTO
{
    public class UserHistoryDTO
    {
        public int Id { get; set; }

        public string FullNameClient { get; set; }

        public string BrandCar { get; set; }

        public string ModelCar { get; set; }

        public int DayNumber { get; set; }

        public int StatusScheduling { get; set; }

        public string Mention { get; set; }

        public string DeclineReason { get; set; }

        public int KmTraveled { get; set; }

        public string StartData { get; set; }

        public string EndData { get; set; }

        public int DayLate { get; set; }

        public int MoneyPaid { get; set; }

        public bool ExternalDefects { get; set; }

        public bool InternalDefects { get; set; }

        public bool ReturnWarranty { get; set; }
        public string NameCategoryCar { get; set; }
        public int SchedulingId { get; set; }

        public int CarId { get; set; }

        public string ClientId { get; set; }

        public static UserHistory MapperDtoToEntity(UserHistoryDTO userHistoryDTO)
        {
            var userHistory = new UserHistory()
            {
                FullNameClient = userHistoryDTO.FullNameClient,
                BrandCar = userHistoryDTO.BrandCar,
                ModelCar = userHistoryDTO.ModelCar,
                DayNumber = userHistoryDTO.DayNumber,
                StatusScheduling = userHistoryDTO.StatusScheduling,
                Mention = userHistoryDTO.Mention,
                DeclineReason = userHistoryDTO.DeclineReason,
                KmTraveled = userHistoryDTO.KmTraveled,
                StartData = userHistoryDTO.StartData,
                EndData = userHistoryDTO.EndData,
                DayLate = userHistoryDTO.DayLate,
                ExternalDefects = userHistoryDTO.ExternalDefects,
                InternalDefects = userHistoryDTO.InternalDefects,
                ReturnWarranty = userHistoryDTO.ReturnWarranty,
                MoneyPaid = userHistoryDTO.MoneyPaid,

                SchedulingId = userHistoryDTO.SchedulingId,
                CarId = userHistoryDTO.CarId,
                ClientId = userHistoryDTO.ClientId,

                NameCategoryCar = userHistoryDTO.NameCategoryCar

            };
          

            return userHistory;
        }

        public static UserHistoryDTO MapperEntityToDto(UserHistory userHistory) {
            
            var userHistoryDTO = new UserHistoryDTO()
            {
                Id = userHistory.Id,
                FullNameClient = userHistory.FullNameClient,
                BrandCar = userHistory.BrandCar,
                ModelCar = userHistory.ModelCar,
                DayNumber = userHistory.DayNumber,
                StatusScheduling = userHistory.StatusScheduling,
                Mention = userHistory.Mention,
                DeclineReason = userHistory.DeclineReason,
                KmTraveled = userHistory.KmTraveled,
                StartData = userHistory.StartData,
                EndData = userHistory.EndData,
                MoneyPaid = userHistory.MoneyPaid,

                DayLate = userHistory.DayLate,
                ExternalDefects = userHistory.ExternalDefects,
                InternalDefects = userHistory.InternalDefects,
                ReturnWarranty = userHistory.ReturnWarranty,


                SchedulingId = userHistory.SchedulingId,
                CarId = userHistory.CarId,
                ClientId = userHistory.ClientId,
                NameCategoryCar = userHistory.NameCategoryCar
            };


            return userHistoryDTO;
        }

    }

   
}
