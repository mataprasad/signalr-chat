namespace RentNDeal.Chat.Server.Util
{
    using System;
    [Serializable]
    public class ExceptionManager : IExceptionManager
    {
        /// <summary>
        /// The synchronization object.
        /// </summary>
        private static object syncObject = new object();

        private static ILogger logger{get {return Log4NetLogger.Instance;}}

        private static volatile ExceptionManager ExceptionManagerInstance = null;
         public static ExceptionManager Instance
         {
             get
             {
                 if (ExceptionManagerInstance == null)
                 {
                     lock (syncObject)
                     {
                         if (ExceptionManagerInstance == null)
                         {
                             ExceptionManagerInstance = new ExceptionManager();
                         }
                     }
                 }

                 return ExceptionManagerInstance;
             }
         }
        #region IExceptionManager Members

        public virtual void HandleException(Exception exception)
        {
            HandleException(exception, string.Empty, false);
        }

        public virtual void HandleException(Exception exception, string additionalMessage)
        {
            HandleException(exception, additionalMessage, false);
        }

        public virtual void HandleException(Exception exception, string additionalMessage = "", bool sendNotification = false)
        {
            logger.Error(exception);

            if (!string.IsNullOrEmpty(additionalMessage))
            {
                logger.Error(additionalMessage);
            }

            if (sendNotification)
            {
                SendExceptionEmail(FormatException(exception));
            }
        }

        private void SendExceptionEmail(string message)
        {
            EmailRequest emailRequest = new EmailRequest();
            emailRequest.Body = message;
            emailRequest.To = WebConfigHelper.AdminMailId;
            emailRequest.SenderUserName = WebConfigHelper.AdminMailId;
            emailRequest.Subject = "Fatal Exception";
            EmailHelper.SendEmail(emailRequest);
        }

        private string FormatException(Exception exception)
        {
            throw new NotImplementedException("FormatException");
        }

        #endregion
    }
}
