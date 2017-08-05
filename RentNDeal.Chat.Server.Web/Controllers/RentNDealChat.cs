using System;
using System.Collections.Concurrent;
using System.Linq;
using System.Threading.Tasks;
using SignalR.Hubs;
using RentNDeal.Chat.Server.Db;
using RentNDeal.Chat.Server.Entity;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace RentNDeal.Chat.Server.Web.Controllers
{
    [HubName("RentNDealChat")]
    public class RentNDealChat : Hub
    {
        private DbAccess _db = new DbAccess();

        public string Login(DateTime date,
                          String sessionId, String userName,
                          String userId, String host, String ip)
        {
            var response = _db.Login(Context.ConnectionId, date, sessionId, userName, userId, host, ip);

            var loggedUserList = _db.GetAllLoggedInUsers(host, response.ID);

            Clients[Context.ConnectionId].loginCallback(response);
            //notify all user for user stat change
            Clients.refreshUserList(loggedUserList);

            return Context.ConnectionId;
        }

        public string ChangeStatus(string userId, string userName)
        {
            //notify all user for user stat change
            Clients.refreshUserList(new List<LoginResponse>());
            return Context.ConnectionId;
        }

        public string LogOff(string chatId,string host)
        {
            var response = _db.LogOff(chatId);

            var loggedUserList = _db.GetAllLoggedInUsers(host, chatId);

            return Context.ConnectionId;
        }

        public void SendMessage(ClientMessage message)
        {
            if (message != null)
            {
                if (message.ToConnectionId == null)
                {
                    Clients.receiveMessage(message);
                }
                else
                {
                    Clients[message.ToConnectionId].receiveMessage(message);
                }
            }
        }
    }
}