namespace RentNDeal.Chat.Server.Util
{
    using System;
    
    public interface ILogger
    {
        /// <summary>
        /// The debug information
        /// </summary>
        /// <param name="message">The message.</param>
        void Debug(object message);

        /// <summary>
        /// The error message.
        /// </summary>
        /// <param name="message">The message.</param>
        void Error(string message);

        /// <summary>
        /// Errors the specified exception.
        /// </summary>
        /// <param name="exceptionToLog">The exception to log.</param>
        void Error(Exception exceptionToLog);

        /// <summary>
        /// The error message.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="exception">The exception</param>
        void Error(object message, Exception exception);

        /// <summary>
        /// The information method
        /// </summary>
        /// <param name="message">The information message.</param>
        void Info(object message);

        /// <summary>
        /// The Warning method.
        /// </summary>
        /// <param name="message">The message.</param>
        void Warning(object message);

        /// <summary>
        /// The Fatal method.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="systemAdminEmail">The system admin's email to be informed of this exception</param>
        void Fatal(object message, string systemAdminEmail); 
    }
}
