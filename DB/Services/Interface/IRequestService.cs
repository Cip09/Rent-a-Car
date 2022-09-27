using DB.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace DB.Services.Interface
{
    public interface IRequestService
    {
        void AddRequest(RequestDTO requestDTO, string idUser);
        List<RequestDTO> GetAllRequests(); 

        List<RequestDTO> GetRequestsByUser(int userId);

        void updateRequest(RequestDTO requestDTO, int id);

        void deleteRequest(int idRequest);

        void ResponseRequest(int id, bool response);
    }
}
