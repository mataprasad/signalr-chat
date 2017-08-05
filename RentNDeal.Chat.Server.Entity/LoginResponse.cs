using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RentNDeal.Chat.Server.Entity
{
    public class LoginResponse
    {
        public string ID { get; set; }

        public string Host { get; set; }

        public string UserId { get; set; }

        public string SessionId { get; set; }

        public string ConnectionId { get; set; }

        public DateTime LoginDate { get; set; }

        public string DisplayName { get; set; }

        public string Ip { get; set; }

        public int LoginStatus { get; set; }
    }
}
