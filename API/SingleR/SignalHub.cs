using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.SingleR
{
    public class SignalHub : Hub
    {
        public Task UpdateNotification(string user, string message)
        {
            var list_ = new List<string>() { user, message };
            return Clients.All.SendCoreAsync("UpdateNotificationClient", list_.ToArray());
        }
        public Task UpdateNotificationst(string user, string message)
        {
            var list_ = new List<string>() { user, message };
            return Clients.All.SendCoreAsync("UpdateNotificationClient", list_.ToArray());
        }
    }
}

