using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RentNDeal.Chat.Server.Entity
{
    public class ClientMessage
    {
        public string ToConnectionId { get; set; }
        public string FromConnectionId { get; set; }
        public string ToSessionId { get; set; }
        public string FromSessionId { get; set; }
        public string ToUserAppPId { get; set; }
        public string FromUserAppPd { get; set; }
        public string ToUserName { get; set; }
        public string FromUserName { get; set; }
        public string ToChatId { get; set; }
        public string FromChatId { get; set; }

        public string Message { get; set; }
        public string Time { get; set; }
        public bool IsFile { get; set; }
        public string FileName { get; set; }
        public string FileUrl { get; set; }
    }
}
