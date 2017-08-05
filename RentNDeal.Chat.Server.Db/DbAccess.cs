using RentNDeal.Chat.Server.Entity;
using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dapper;
using RentNDeal.Chat.Server.Util;
using System.Data.SqlClient;
using RentNDeal.Chat.Server.Util.Constant;

namespace RentNDeal.Chat.Server.Db
{
    public class DbAccess
    {
        private IDbConnection _db = null;

        public DbAccess()
        {
            _db = new SqlConnection(WebConfigHelper.DefaultConnection);
        }

        public LoginResponse Login(String connectionId, DateTime date,
                          String fromSessionId, String fromUserName,
                          String fromUserAppPd, String host, String ip)
        {
            LoginResponse reponse = new LoginResponse();
            reponse.ConnectionId = connectionId;
            reponse.DisplayName = fromUserName;
            reponse.Host = host;
            reponse.ID = Guid.NewGuid().ToString();
            reponse.Ip = ip;
            reponse.LoginDate = date;
            reponse.LoginStatus = (int)LoginStatus.Online;
            reponse.SessionId = fromSessionId;
            reponse.UserId = fromUserAppPd;

            reponse = _db.QueryFirstOrDefault<LoginResponse>(sql: "UspLoginChatUser", param: reponse, commandType: CommandType.StoredProcedure);

            return reponse;
        }

        public List<LoginResponse> GetAllLoggedInUsers(String host, String id)
        {
            var cmd = new CommandDefinition("SELECT * FROM DtChatUser WHERE @Host=@Host AND LoginStatus<>-1;", new { Host = host, ID = id });
            return _db.Query<LoginResponse>(cmd).ToList();
        }

        public bool LogOff(String chatId)
        {
            var cmd = new CommandDefinition("UPDATE DtChatUser SET LoginStatus=-1 WHERE ID=@ID", new { ID = chatId });
            _db.Execute(cmd);
            return true;
        }
    }
}
