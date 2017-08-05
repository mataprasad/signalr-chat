using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;

namespace RentNDeal.Chat.Server.Util
{
    public static class WebConfigHelper
    {
        #region Email Config

        public static string BulkSenderEmailId
        {
            get
            {
                return ConfigurationManager.AppSettings["BulkSenderEmailId"];
            }
        }

        public static string BulkSenderEmailPassword
        {
            get
            {
                return ConfigurationManager.AppSettings["BulkSenderEmailPassword"];
            }
        }

        public static string SMTPHost
        {
            get
            {
                return ConfigurationManager.AppSettings["SMTPHost"];
            }
        }

        public static int SMTPPort
        {
            get
            {
                return Convert.ToInt32(ConfigurationManager.AppSettings["SMTPPort"]);
            }
        }

        public static string AdminMailId
        {
            get
            {
                return ConfigurationManager.AppSettings["AdminMailId"];
            }
        }

        #endregion

        #region DbConnectionString

        public static string DefaultConnection
        {
            get
            {
                return ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            }
        }

        #endregion
    }
}
