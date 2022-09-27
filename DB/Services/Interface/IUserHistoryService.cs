using DB.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace DB.Services.Interface
{
    public interface IUserHistoryService
    {
        void updateStatus(int id, int status);

        void addHistory(UserHistoryDTO historyDTO);

        List<UserHistoryDTO> GetUserHistory(string id);
        List<UserHistoryDTO> GetAll();
    }
}
