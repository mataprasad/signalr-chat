namespace RentNDeal.Chat.Server.Util
{
    using System;

    public interface IExceptionManager
    {
        void HandleException(Exception exception);

        void HandleException(Exception exception, string additionalMessage);

        void HandleException(Exception exception, string additionalMessage = "", bool sendNotification = false); 
    }
}